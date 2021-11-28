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
using System.Net;
using System.Net.Mail;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;


public partial class N_DirectBankinConfirm : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0;
    int vClientId = 0;
    long MaxEbookImageSize = 2097152;   // 2MB

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
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

            LoadCartItems();
            RenderUserBanks_LIST();
            RenderUserBanksDDL();
            GetUserInfo();

            lbltranID.Text = ViewState["TransactionID"].ToString();
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
            lblNoteEmailID.Text = dRow["eMailID"].ToString();
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

    protected void RenderUserBanks_LIST()
    {
        int vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        ds = objBALebook.BankIn_GetUserBanks(vClientId, "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataView dv = ds.Tables[0].DefaultView;
            GridBanks.DataSource = dv;
            GridBanks.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            GridBanks.DataSource = ds;
            GridBanks.DataBind();

            int ColCount = GridBanks.Rows[0].Cells.Count;
            GridBanks.Rows[0].Cells.Clear();
            GridBanks.Rows[0].Cells.Add(new TableCell());
            GridBanks.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridBanks.Rows[0].Cells[0].Text = "No records Found";
            GridBanks.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }

    protected void GridBanks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");

            ////To get the up/down image at the sorted column 
            //CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");
            //.. getting reference the gridview row in row databound event. 
            string strLoginName = string.Empty;
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
            Literal objLtrCountryName = (Literal)e.Row.FindControl("LtrCountryName");
            if (objLtrCountryName.Text != "")
            {
                Image objImgCountry = (Image)e.Row.FindControl("ImgCountry");
                if (objImgCountry != null)
                    objImgCountry.ImageUrl = @"\eBookAdminX\Images\Flags\48\" + objLtrCountryName.Text + ".png";
            }
            Literal objLtrBankLogo = (Literal)e.Row.FindControl("LtrBankLogo");
            if (objLtrBankLogo.Text != "")
            {
                Image objImgBankLogo = (Image)e.Row.FindControl("ImgBankLogo");
                if (objImgBankLogo != null)
                    objImgBankLogo.ImageUrl = tmpImageFolder + "BankLogos/" + objLtrBankLogo.Text;
            }
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

        String vPurchaseItems = ViewState["ItemsString"].ToString();
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

            //Send_TransactionInvoice_ToBuyer(vBankersFullName, vBankdersMobile, vBankdersEmail, vPurchaseAmount, vPurchaseCurrency, vPurchaseItems, vClientId, vTranID);
            Send_PaymentInvoice_ToBuyer(vBankInBy, vBankInDate, vBankInTime, vBankInAmount, vBankInRef, vPurchaseDesc, vPurchaseItems, vClientId, vTranID);
            //Send_TransactionInvoice_ToBuyer(String vbFullName, String vbMobile, String vbEmail, string vbTotalAmount, String vbCurrency, string vPurchaseItems, int vUserID, string vTranID)
        }
        else if (reStatus == 3)
        {
            CommonFunctions.AlertMessage("Details for this TransactionID has already been submitted. \\n\\n Please check your email.");
            return;
        }
        else
        {
            CommonFunctions.AlertMessage("TransactionID could not be validated.  \\n\\n Please check your email for Transaction Reference No. and Try Again.");
            return;
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
                    VbookImgs += "<div style='float: left; margin-left: 6px; padding: 2px;'> " + tmpID + "<br/>" + "<img alt='bkimg' height='60' src='" + tmpImgUrl + "' title='" + tmpTitle + "'> </div>";
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

    protected void Send_TransactionInvoice_ToBuyer(String vbFullName, String vbMobile, String vbEmail, string vbTotalAmount, String vbCurrency, string vPurchaseItems, int vUserID, string vTranID)
    {
        String InVoiceTrackId = vUserID + "#" + vTranID + "#" + vPurchaseItems;
        String strDescription = string.Empty;
        String userEmail = "";
        newDBS ndbs1 = new newDBS();
        DataSet dst = ndbs1.Ebook_getUserEmailID(vUserID.ToString());
        userEmail = dst.Tables[0].Rows[0]["email"].ToString();
        StringBuilder sb = new StringBuilder();
        //vbEmail = "";
        //newDBS ndbs2 = new newDBS();
        //DataSet dst2 = ndbs2.Ebook_getBankersEmailID(vTranID.ToString());
        //vbEmail = dst2.Tables[0].Rows[0]["email"].ToString();

        sb.AppendLine("<tr> <td> Transaction Reference ID  </td>" + "<td>" + vTranID + "</td> </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Purchased Item codes </td>" + "<td>" + vPurchaseItems + "</td>  </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Amount Paid </td>" + "<td>" + vbCurrency + ' ' + vbTotalAmount + "</td> </tr>");
        sb.AppendLine("<br/>");

        strDescription = sb.ToString();

        String strSubmitLink = "http://14.102.146.116/O_dtBankInConfirmVEmail.aspx?vTID=" + Server.UrlEncode(CommonFunctions.Encrypt(InVoiceTrackId));
        String strSubmitLinkURL = @"<a class='HeaderFont' href='" + strSubmitLink + "' target='_blank'> CLICK HERE to submit your Payment Details to Vendor. </a>";


        StringBuilder sHtml = new StringBuilder();

        String tmpHtmlBody = @"<!DOCTYPE html>
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head>
                                    <title></title>
                                    <style type='text/css'>
                                        .NoteFont  {FONT-SIZE: 12px;COLOR: #BB1717;FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;}
                                        .CotentFont {FONT-SIZE: 12px;COLOR: #296692;FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;}
                                        .HeaderFont {FONT-SIZE: 14px;COLOR: #296692; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; font-weight: bold; }
                                        .dvemailBox { border: 5px solid #BAC0C7;   padding: 15px; }

                                        table.gridtable { font-family: verdana,arial,sans-serif; font-size: 11px; color: #333333; border: 1px solid #666666; border-collapse: collapse; width: 600px; }
                                        table.gridtable th {border: 1px solid #666666; padding: 8px; background-color: #dedede;}
                                        table.gridtable td {border: 1px solid #666666; padding: 8px; background-color: #ffffff; font-weight: bold; }
                                    </style>
                                </head>
                                <body>
                                    <div id='dvEmail' class='dvemailBox'>
                                        <div id='dvHeader' style='align-content: center;'>
                                            <img src='http://14.102.146.116/Images/ebImages/bookimgbanner.jpg' />
                                            <br />
                                        </div>
                                     <div id='dvContent'>
                                        <table width='90%'>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class='HeaderFont'>&nbsp;Direct Bank-In Invoice </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
              
                                            <tr>
                                                <td class='CotentFont'>

                                                    Thank you for your making your purchase payment via Bank. .&nbsp; We will deliver the books via Email as soon as we confirm your payment receipt. 
                                                    <br />

                                                    The following is an invoice detailing your transaction details.&nbsp;
                                                    <br />
                                                    Please print or save a copy of this invoice for your records.
                                                    <br />
                                                    <br />
                                                    For any further queries , please let us know.

                                                </td>

                                            </tr>
                                           
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    <table class='gridtable'>
                                                        <tr>
                                                            <th width='45%'>Description</th>
                                                            <th width='55%'>Price</th>
                                                        </tr>
                                                        " +

                                                              strDescription

                                                       + @" 
                                                        
                                                    </table>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr><td>&nbsp;</td></tr>
                                            <tr><td>&nbsp;</td></tr>
                                            <tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td></tr>

                                        </table>
                                        </div>
                                    </div>
                                </body>
                                </html>

            ";
        String vVendorMobileID = string.Empty;
        String vVendorEmailID = String.Empty;

        //#region sending Email using HmailServer.
        //hMailServer.Application objApp_Hmail = new hMailServer.Application();
        //hMailServer.Message objMsg_Hmail = new hMailServer.Message();
        //String eSenderEmailID = "noreply@ebooksmsdelivery.com";
        //objMsg_Hmail.AddRecipient("", vbEmail);
        //objMsg_Hmail.From = "Admin";
        //objMsg_Hmail.FromAddress = eSenderEmailID;
        //objMsg_Hmail.Subject = "Transaction Invoice For your Purchase : " + vTranID;
        //objMsg_Hmail.HTMLBody = tmpHtmlBody;
        //objMsg_Hmail.Save();
        ////CommonFunctions.AlertMessage("Email has been Sent");
        //#endregion

        SmtpClient smtpClient = new SmtpClient();
        MailMessage objMessage = new MailMessage();
        string m_fromName = string.Empty;
        try
        {
            m_fromName = "EBookAdmin";
            MailAddress m_fromAddress = new MailAddress("noreply@ebooksmsdelivery.com", "EBookAdmin");
            smtpClient.Host = "127.0.0.1";
            smtpClient.Port = 25;
            objMessage.From = m_fromAddress;

            objMessage.To.Add(vbEmail);
            objMessage.Subject = "Transaction Invoice For your Purchase : " + vTranID;
            if (userEmail != "")
            {
                objMessage.Bcc.Add(userEmail + ',' + vbEmail);
            }

            objMessage.IsBodyHtml = true;
            objMessage.Body = tmpHtmlBody;

            NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = authinfo;

            smtpClient.Send(objMessage);
        }
        catch
        {

        }
    }

    protected void Send_PaymentInvoice_ToBuyer(String vbFullName, String vBankInDate, String vBankInTime, string vBankInAmount, String vBankInRef, string vPurchaseDesc, string vPurchaseItems, int vUserID, string vTranID)
    {
        String InVoiceTrackId = vUserID + "#" + vTranID + "#" + vPurchaseItems;
        String strDescription = string.Empty;
        String userEmail = "";
        newDBS ndbs1 = new newDBS();
        DataSet dst = ndbs1.Ebook_getUserEmailID(vUserID.ToString());
        userEmail = dst.Tables[0].Rows[0]["email"].ToString();

        string vbEmail = "";
        newDBS ndbs2 = new newDBS();
        DataSet dst2 = ndbs2.Ebook_getBankersEmailID(vTranID.ToString());
        vbEmail = dst2.Tables[0].Rows[0]["bEmail"].ToString();

        //Response.Write(userEmail.ToString());
        //Response.Write(vbEmail.ToString());
        //Response.End();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<tr> <td> Transaction Reference ID  </td>" + "<td>" + vTranID + "</td> </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Purchased Item codes </td>" + "<td>" + vPurchaseItems + "</td>  </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Full Name </td>" + "<td>" + vbFullName + "</td> </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Date Time </td>" + "<td>" + vBankInDate + "  " + vBankInTime + "</td> </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Amount Paid </td>" + "<td>" + vBankInAmount + "</td> </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Purcahse Description </td>" + "<td>" + vPurchaseDesc + "</td> </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<br/>");

        strDescription = sb.ToString();

        String strSubmitLink = "http://210.5.45.8/eBooksBankInSubmitvEmail.aspx?vTID=" + Server.UrlEncode(CommonFunctions.Encrypt(InVoiceTrackId));
        String strSubmitLinkURL = @"<a class='HeaderFont' href='" + strSubmitLink + "' target='_blank'> CLICK HERE to submit your Payment Details to Vendor. </a>";

        StringBuilder sHtml = new StringBuilder();

        String tmpHtmlBody = @"<!DOCTYPE html>
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head>
                                    <title></title>
                                    <style type='text/css'>
                                        .NoteFont  {FONT-SIZE: 12px;COLOR: #BB1717;FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;}
                                        .CotentFont {FONT-SIZE: 12px;COLOR: #296692;FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;}
                                        .HeaderFont {FONT-SIZE: 14px;COLOR: #296692; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; font-weight: bold; }
                                        .dvemailBox { border: 5px solid #BAC0C7;   padding: 15px; }

                                        table.gridtable { font-family: verdana,arial,sans-serif; font-size: 11px; color: #333333; border: 1px solid #666666; border-collapse: collapse; width: 600px; }
                                        table.gridtable th {border: 1px solid #666666; padding: 8px; background-color: #dedede;}
                                        table.gridtable td {border: 1px solid #666666; padding: 8px; background-color: #ffffff; font-weight: bold; }
                                    </style>
                                </head>
                                <body>
                                    <div id='dvEmail' class='dvemailBox'>
                                        <div id='dvHeader' style='align-content: center;'>
                                            <img src='http://14.102.146.116/Images/ebImages/bookimgbanner.jpg' />
                                            <br />
                                        </div>
                                     <div id='dvContent'>
                                        <table width='90%'>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class='HeaderFont'>&nbsp;Direct Bank-In Invoice </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
              
                                            <tr>
                                                <td class='CotentFont'>

                                                    Thank you for your making your purchase payment via Bank. .&nbsp; 
                                                    <br />
                                                    <br />
                                                    <br />
                                                    Please print or save a copy of this invoice for your records.
                                                    <br />
                                                    <br />
                                                    Following is the reference to the information submitted by you.
                                                </td>

                                            </tr>
                                           
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    <table class='gridtable'>
                                                        <tr>
                                                            <th width='45%'>Description</th>
                                                            <th width='55%'>Price</th>
                                                        </tr>
                                                        " +

                                                              strDescription

                                                       + @" 
                                                        
                                                    </table>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>

                                          
                                            <tr><td>&nbsp;  We will deliver the books via Email as soon as we confirm your payment receipt.</td></tr>

                                        <tr><td>&nbsp;</td></tr>

                                        </table>
                                        </div>
                                    </div>
                                </body>
                                </html>

            ";

        //.. Get Vendor Details. 

        String vVendorMobileID = string.Empty;
        String vVendorEmailID = String.Empty;

        ViewState["vbEmail"] = vbEmail;

        if (ViewState["vbEmail"] != null)
        {
            if (ViewState["vbEmail"].ToString() != "")
            {
                String EmailTo = ViewState["vbEmail"].ToString();
                //#region sending Email using HmailServer.
                //hMailServer.Application objApp_Hmail = new hMailServer.Application();
                //hMailServer.Message objMsg_Hmail = new hMailServer.Message();
                //String eSenderEmailID = "noreply@ebooksmsdelivery.com";
                //objMsg_Hmail.AddRecipient("", EmailTo);
                //objMsg_Hmail.From = "Admin";
                //objMsg_Hmail.FromAddress = eSenderEmailID;
                //objMsg_Hmail.Subject = "Payment Details For your Purchase : " + vTranID;
                //objMsg_Hmail.HTMLBody = tmpHtmlBody;
                //objMsg_Hmail.Save();
                ////CommonFunctions.AlertMessage("Email has been Sent");
                //#endregion

                SmtpClient smtpClient = new SmtpClient();
                MailMessage objMessage = new MailMessage();
                string m_fromName = string.Empty;

                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                                "key-0ad485da45bb169cabfea074c9e87e2d");
                RestRequest request = new RestRequest();
                request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
                request.Resource = "{domain}/messages";
                request.AddParameter("from", "EbookDelivery <me@maildly.ebdvy.com>");
                request.AddParameter("to", vbEmail);
                request.AddParameter("bcc", userEmail + ',' + vbEmail);
                request.AddParameter("subject", "Transaction Invoice For your Purchase : " + vTranID);
                //request.AddParameter("text", "Testing some Mailgun awesomness!");
                request.AddParameter("html", tmpHtmlBody);
                request.Method = Method.POST;
                client.Execute(request);   

                //try
                //{
                //    m_fromName = "EBookAdmin";
                //    MailAddress m_fromAddress = new MailAddress("noreply@ebooksmsdelivery.com", "EBookAdmin");
                //    smtpClient.Host = "127.0.0.1";
                //    smtpClient.Port = 25;
                //    objMessage.From = m_fromAddress;

                //    objMessage.To.Add(vbEmail);
                //    objMessage.Subject = "Transaction Invoice For your Purchase : " + vTranID;
                //    if (userEmail != "")
                //    {
                //        objMessage.Bcc.Add(userEmail + ',' + vbEmail);
                //    }

                //    objMessage.IsBodyHtml = true;
                //    objMessage.Body = tmpHtmlBody;

                //    NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
                //    smtpClient.UseDefaultCredentials = false;
                //    smtpClient.Credentials = authinfo;

                //    smtpClient.Send(objMessage);
                //}
                //catch
                //{

                //}
            }
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