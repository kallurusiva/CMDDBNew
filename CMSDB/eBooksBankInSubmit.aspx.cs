using System;
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


public partial class eBooksBankInSubmit : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0;
    int vClientId = 0;

    long MaxEbookImageSize = 2097152;   // 2MB


    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = "~/UserEbookMaster.master";
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"].ToString() == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        #region //rendering top left panel 

        if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet")) 
        {

            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

            //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
            sb.Append("<tr>");
            sb.Append("<td align='left' valign='top'>");
            sb.Append("<img src='Images/table_top_Leftarc.gif' />");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            myDivObject.InnerHtml = sb.ToString();

            //myDivObject.InnerHtml = "<table border='0' class='dvBannerLeftPanel'><tr><td><img alt='imbnLeftimg' src='Images/faq_head.jpg' /> </td></tr></table>";
        }
        #endregion 


          
        if (!IsPostBack)
        {


            if (Request.QueryString["CpUri"] != null)
                ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString();
            else
                ViewState["CallingPage"] = ""; 


            LoadCartItems(); 
            RenderUserBanks();

        }


    }


    protected void RenderUserBanks()
    {
        int vClientId = Convert.ToInt32(Session["ClientID"].ToString());

        ds = objBALebook.BankIn_GetUserBanks(vClientId, "");

        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlBanks.DataSource = ds;
            ddlBanks.DataTextField = "BankName";
            ddlBanks.DataValueField = "BankID";
            ddlBanks.DataBind();

            ddlBanks.Items.Insert(0, new ListItem("Select Bank", "0"));

        }

    }

  
  
    protected void lnkBuyNow_Click(object sender, EventArgs e)
    {


      //Store all the items in a table and before paypal transaction. 

        vClientId = Convert.ToInt32(Session["ClientID"].ToString());

   //     long tmpCartID = objBALebook.ShoppingCart_PreInsert(vClientId, ViewState["ItemsString"].ToString(), Convert.ToInt32(lblTotalItems.Text), Convert.ToDecimal(lbltotalAmount.Text)); 
               
        
       

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

            dvBankDetails.Visible = true;

        }


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


        String vPurchaseItems = ViewState["ItemsString"].ToString();

        String vTranID = GetUniqueKey(12); 

        int reStatus = objBALebook.Bank_Client_Add(vBankID, vBankInBy, vBankInAmount, vBankInDate, vBankInTime, vBankInSlipImage, vBankInRef, vPurchaseDesc, vPurchaseItems,vTranID, vClientId);

        if (reStatus == 1)
        {
            //Show the purchase reciept. 

           // CommonFunctions.AlertMessage("To Show the Purchase Receipt.");

            dvInVoice.Visible = true;
            dvBookDetails.Visible = false;

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



    protected void LoadCartItems()
    {

        ViewState["ItemsString"] = "";
        DataTable CartDataTable = null;

        if (HttpContext.Current.Session["basket"] != null)
        {
            CartDataTable = (DataTable)HttpContext.Current.Session["basket"];

        }

        if (CartDataTable != null)
        {
            if (CartDataTable.Rows.Count > 0)
            {
                tmpRowCount = CartDataTable.Rows.Count;
                ViewState["ItemsCount"] = tmpRowCount;

                String vBookIds = string.Empty;
                String vBookIds2Show = string.Empty;
                String VbookImgs = String.Empty;

                decimal vTotalAmt = 0;

                foreach (DataRow cRow in CartDataTable.Rows)
                {

                    vBookIds += cRow["id"].ToString() + ",";
                    vBookIds2Show += cRow["id"].ToString() + ";&nbsp;&nbsp;&nbsp;";
                    vTotalAmt += Convert.ToDecimal(cRow["price"].ToString());


                    String tmpID = cRow["id"].ToString();
                    String tmpImgUrl = cRow["ImageUrl"].ToString();
                    String tmpCurrency = cRow["currency"].ToString();
                    String tmpPrice = cRow["price"].ToString();
                    String tmpTitle = cRow["name"].ToString() + "\n" + tmpCurrency + ' ' + tmpPrice;


                    tmpImgUrl = tmpImgUrl.Substring(1);

                    VbookImgs += "<div style='float: left; margin-left: 6px; padding: 2px;'> " + tmpID + "<br/>" + "<img alt='bkimg' class='cartBookBox CartBookImgCss' src='" + tmpImgUrl + "' title='" + tmpTitle + "'> </div>";

                }

                String vCurrency = string.Empty;

                if (Session["UserCurrency"] != null)
                    vCurrency = Session["UserCurrency"].ToString();
                else
                    vCurrency = "";

                lblTotalItems.Text = tmpRowCount.ToString();
                //lblBookID.Text = vBookIds2Show;
                lblBookID.Text = "<div>" + VbookImgs + "</div>";

                //lbluCurrency.Text = tmpCurrency;
                lblAmtCurrency.Text = vCurrency;
                lbltotalAmount.Text = vTotalAmt.ToString();

                ViewState["ItemsString"] = vBookIds;


            }
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





}




