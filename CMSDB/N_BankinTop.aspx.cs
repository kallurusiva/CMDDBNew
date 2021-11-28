﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using CMSv3.BAL;
using System.Threading;
using System.Configuration;
using System.Security.Cryptography;


public partial class N_BankinTop : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;
    //int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0;
    int vClientId = 0;

    long MaxEbookImageSize = 2097152;   // 2MB

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"].ToString() == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            if (Request.QueryString["CpUri"] != null)
                ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString();
            else
                ViewState["CallingPage"] = "";

            if (Request.QueryString["qtrID"] != null)
                ViewState["TransactionID"] = Request.QueryString["qtrID"].ToString();
            else
                ViewState["TransactionID"] = "";

            RenderUserBanksDDL();
            GetUserInfo();
            txtTransactionID.Text = ViewState["TransactionID"].ToString();
        }
    }

    protected void GetUserInfo()
    {
        //...Get Estore ID and Email Address of the User
        int vUserID = Convert.ToInt32(Session["ClientID"].ToString());
        DataSet ds = objBALebook.Bank_GetUserInfo(vUserID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dRow = ds.Tables[0].Rows[0];
            lblVendorMobile.Text = dRow["userMobile"].ToString();
            lblVendorEmail.Text = dRow["eMailID"].ToString();
        }
    }


    protected void RenderUserBanksDDL()
    {
        int vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        ds = objBALebook.BankIn_GetUserBanks(vClientId, "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBanks.DataSource = ds;
            ddlBanks.DataTextField = "ddlBankText";
            ddlBanks.DataValueField = "BankID";
            ddlBanks.DataBind();
            ddlBanks.Items.Insert(0, new ListItem("Select Bank", "0"));
        }
    }

    protected void ddlBanks_SelectedIndexChanged(object sender, EventArgs e)
    {
        vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        string strSearch = " AND BU.BankID = " + ddlBanks.SelectedValue;
        ds = objBALebook.BankIn_GetUserBanks(vClientId, strSearch);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dRow = ds.Tables[0].Rows[0];
            String StrBankLogo = dRow["BankLogo"].ToString();
            String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
            ImgBank.ImageUrl = tmpImageFolder + "BankLogos/" + StrBankLogo;
            lblBankActName.Text = "Account Name : " + dRow["FullName"].ToString();
            lblBankActNo.Text = "Account No. : " + dRow["BankActNo"].ToString();
            lblCountry.Text = "Country : " + dRow["CountryName"].ToString();
            lblSwiftCode.Text = "Swift Code : " + dRow["SwiftCode"].ToString();
            ImgCountryFlag.ImageUrl = @"\eBookAdminX\Images\Flags\48\" + dRow["CountryName"].ToString() + ".png";
            dvSelBankDetails.Visible = true;
        }
    }

    protected void lnkBuyNow_Click(object sender, EventArgs e)
    {
        //Store all the items in a table and before paypal transaction. 
        vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        //     long tmpCartID = objBALebook.ShoppingCart_PreInsert(vClientId, ViewState["ItemsString"].ToString(), Convert.ToInt32(lblTotalItems.Text), Convert.ToDecimal(lbltotalAmount.Text)); 
    }

    public string GetUniqueKey(int maxSize)
    {
        char[] chars = new char[62];
        chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVW XYZ1234567890".ToCharArray();
        byte[] data = new byte[1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        data = new byte[maxSize];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(maxSize);
        foreach (byte b in data)
        {
            result.Append(chars[b % (chars.Length - 1)]);
        }
        return result.ToString();
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        String vBankInBy = txtBankinBy.Text.Trim();
        String vBankInDate = txtBankInDate.Text.Trim();
        String vBankInTime = txtBankInTime.Text.Trim();
        String vBankInRef = txtBankInRef.Text.Trim();
        String vPurchaseDesc = txtBankInDesc.Text.Trim();
        String vBankInAmount = txtBankInAmount.Text.Trim();
        int vBankID = Convert.ToInt32(ddlBanks.SelectedValue);
        String vBankInSlipImage = string.Empty;
        if (UploadImgCtrl.HasFile)
        {
            int iImageSize1 = UploadImgCtrl.PostedFile.ContentLength;
            if (iImageSize1 > 0)
            {
                if (iImageSize1 < MaxEbookImageSize)
                {
                    //Get the name of the file
                    string fileName = UploadImgCtrl.FileName;
                    Random rnum = new Random();
                    String ImgFileName = Convert.ToString(rnum.Next(9999)) + "_" + UploadImgCtrl.FileName;

                    vBankInSlipImage = ImgFileName;
                    String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
                    //instead of server.mapPath set the path in web.config file and use that path.
                    String ImgFileUrl = Server.MapPath("~") + tmpImageFolder + "/BankInSlips/";

                    UploadImgCtrl.SaveAs(ImgFileUrl + ImgFileName);
                    //lblUpMessage.Text = "Image uploaded : " + UploadImgCtrl.FileName;

                    ViewState["FileImageUrl"] = ImgFileUrl;
                    ViewState["FileImageName"] = ImgFileName;
                    ViewState["FileImageUploaded"] = true;
                }
                else
                {
                    UploadImgCtrl.Focus();
                    CustomValidator_BookImage.IsValid = false;

                    lblErrorImg.Text = "Ebook Image Size cannot exceed 2MB. Please try again.";
                    CommonFunctions.AlertMessage("Ebook Image Size cannot exceed 2MB. Please try again.");
                    return;
                }
            }
        }

        String vPurchaseItems = "";
        String vTranID = txtTransactionID.Text;
        int reStatus = objBALebook.Bank_Client_Add(vBankID, vBankInBy, vBankInAmount, vBankInDate, vBankInTime, vBankInSlipImage, vBankInRef, vPurchaseDesc, vPurchaseItems, vTranID, vClientId);
        if (reStatus == 1)
        {
            //Show the purchase reciept. 
            // CommonFunctions.AlertMessage("To Show the Purchase Receipt.");


            dvInVoice.Visible = true;
            dvBookDetails.Visible = false;
            BtnSubmit.Visible = false;
            lblTransactionID.Text = vTranID;
            lblDateTime.Text = DateTime.Now.ToString();
            lblInvoiceHeader2.Text = "Invoice for Purchase # " + vTranID;
            lblItemsDesc.Text = vPurchaseItems;
            lblItemsPrice.Text = vBankInAmount;
            lblItemsPriceTotal.Text = vBankInAmount;
        }
    }

    protected void HandleFileUploads()
    {
        // FOR IMAGE 
        // store the FileUpload object in Session. 
        // "FileUpload1" is the ID of your FileUpload control
        // This condition occurs for first time you upload a file
        if (Session["FileUpload1"] == null && UploadImgCtrl.HasFile)
        {
            Session["FileUpload1"] = UploadImgCtrl;
            lblErrorImg.Text = UploadImgCtrl.FileName; // get the name  
        }
        // This condition will occur on next postbacks        
        else if (Session["FileUpload1"] != null && (!UploadImgCtrl.HasFile))
        {
            UploadImgCtrl = (FileUpload)Session["FileUpload1"];
            lblErrorImg.Text = UploadImgCtrl.FileName;
        }
        //  when Session will have File but user want to change the file 
        // i.e. wants to upload a new file using same FileUpload control
        // so update the session to have the newly uploaded file
        else if (UploadImgCtrl.HasFile)
        {
            Session["FileUpload1"] = UploadImgCtrl;
            lblErrorImg.Text = UploadImgCtrl.FileName;
        }
    }

    protected void CustomVdr_eBookImage_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //30720 = 15 KB  ( 1024 * 30 )
        //Get the name of the file
        string fileName = UploadImgCtrl.FileName;
        int fileSize = UploadImgCtrl.PostedFile.ContentLength;

        if (UploadImgCtrl.FileBytes.Length > MaxEbookImageSize)
        {
            lblErrorImg.Text = "Filesize of image is too large. Maximum file size permitted is 2MB";
            CommonFunctions.AlertMessage("Ebook Image Size cannot be greater then 2MB.");
            args.IsValid = false;
            return;
        }
        else
        {
            args.IsValid = true;
        }
    }

    public int GetUserIdfromURL()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;
        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();
        string tmpMainURL = Request.Url.OriginalString;
        string OrgURL = Request.Url.OriginalString;
        //tmpMainURL = "www.testhari88.com";
        //tmpMainURL = "eb60123238595.1smsbusiness.com";
        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://
        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        if (tmpMainURL.Contains(OurWebSiteName))
        {
            //subdomain
            string tmpSubDomainURL = tmpMainURL;
            string[] MainURLArr = tmpMainURL.Split('.');
            string userSubDomainName = string.Empty;
            // see if user has typed in www
            if (MainURLArr[0].ToString() == "www")
            {
                userSubDomainName = MainURLArr[1].ToString();
            }
            else
            {
                userSubDomainName = MainURLArr[0].ToString();
            }
            if (userSubDomainName == OurWebSiteName)
            {
                //..user comes to direct website setting the userid to demo as default
                newUserID = 105;
            }
            else
            {
                //..user comes to his sub domain
                newUserID = objBAL_User.GetUserID_BySubDomainName(userSubDomainName);
                CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                //..function get all the details of 1malaysia user into MasUser entity 
                MasFunc.Get_1MalaysiaUser_Details(userSubDomainName, ref objMasUser);

                //if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
                Session["MasUSER"] = objMasUser;
                //.................................................................
                if (objMasUser.MID != "NONE")
                {
                    //Response.Redirect("Mas1UserWebRegistration.aspx");
                }
            }
        }
        else
        {
            //owndomain  or subDomain ??
            //string ownDomain = tmpMainURL;
            string[] OwnURLArr = tmpMainURL.Split('.');
            string userOwnDomainName = string.Empty;
            int DomainType = -1;
            // see if user has typed in www
            if (OwnURLArr[0].ToString() == "www")
            {
                userOwnDomainName = OwnURLArr[1].ToString();
                if (OwnURLArr.Count() > 4)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain
            }
            else
            {
                userOwnDomainName = OwnURLArr[0].ToString();
                if (OwnURLArr.Count() > 3)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain

            }
            //..user comes to his sub domain
            newUserID = objBAL_User.GetUserID_BySubDomainName2(userOwnDomainName, DomainType);
            CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
            CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(userOwnDomainName, ref objMasUser);
            // if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
            Session["MasUSER"] = objMasUser;
            //    //.................................................................

            if (objMasUser.MID != "NONE")
            {
                // Response.Redirect("Mas1UserWebRegistration.aspx");
                //String WebRegURL = "Mas1UserWebRegistration.aspx";
                //StringBuilder sburl = new StringBuilder();
                //sburl.Append("<script>");
                //sburl.Append("window.open('page.html','_blank')");
                //sburl.Append("</script>");
                //Response.Write(sburl.ToString());
                //Response.End();
                //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", WebRegURL));
            }
        }

        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {
            Response.Redirect("PartnerWebRegistrationNew.aspx");
            //Response.Redirect("InValidDomain.aspx");
        }
        return newUserID;
    }

}