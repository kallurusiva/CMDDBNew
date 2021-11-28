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
using System.IO;

public partial class O_dtPrepaidPre : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    //DataSet ds;
    //DataTable dt;
    //DataSet dpt;
    int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0;
    int vClientId = 0;
    decimal tmpPrepaidTotal = 0;
    int tmpTotalItemsCount = 0;
    //long MaxEbookImageSize = 2097152;   // 2MB
    string vPrepaidPassword = string.Empty; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
        {
            CommonFunctions.AlertMessageAndRedirect("Please Login to checkout", "O_dt_User_Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CpUri"] != null)
                    ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString();
                else
                    ViewState["CallingPage"] = "";

                LoadCartItems();
            }

            DataSet ds2;
            newDBS clsObjNewDbs = new newDBS();
            ds2 = clsObjNewDbs.user_getCreditInfo(Session["cLogin"].ToString());
            if (ds2.Tables[0].Rows.Count > 0)
            {
                string storeidVal = string.Empty;
                newDBS ndspp = new newDBS();
                storeidVal = ndspp.user_getStoreID(Convert.ToInt32(Session["ClientID"].ToString()));

                DataRow krow = ds2.Tables[0].Rows[0];
                vPrepaidPassword = krow["password"].ToString();
                txtPrepaidLogin.Text = Session["cLogin"].ToString().Replace(storeidVal + "-", "");
                txtPrepaidPoints.Text = krow["CreditsBalance"].ToString();
            }
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
        String vPurchaseItems = ViewState["ItemsString"].ToString();
        String vPurchaseAmount = lbltotalAmount.Text.Trim();
        String vPurchaseAmt = vPurchaseAmount.Replace("Prepaid Points", "");
        vPurchaseAmt = vPurchaseAmt.Replace(".00", "");
        vPurchaseAmt = vPurchaseAmt.TrimEnd();
        vPurchaseAmt = vPurchaseAmt.TrimStart();
        vPurchaseAmt = vPurchaseAmt.Trim();

        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.user_PrepaidTransaction(vClientId.ToString(), Session["cLogin"].ToString(), vPrepaidPassword.ToString(), vPurchaseAmt.ToString(), vPurchaseItems.ToString(), "");
        //DataSet dst = ndbs.user_PrepaidTransaction("7485", vPrepaidLogin.ToString(), vPrepaidPassword.ToString(), vPurchaseAmt.ToString(), vPurchaseItems.ToString(), vBankdersEmail.ToString());
        String tempErrorCode = dst.Tables[0].Rows[0]["errocode"].ToString();
        String tempretMessage = dst.Tables[0].Rows[0]["retMessage"].ToString();
        String tempTranID = dst.Tables[0].Rows[0]["tranid"].ToString();
        String tempEmail = dst.Tables[0].Rows[0]["email"].ToString();
        string tempFullName = dst.Tables[0].Rows[0]["fullname"].ToString();

        CommonFunctions.AlertMessage(tempretMessage);

        if (int.Parse(tempErrorCode) == 0)
        {
            BtnSubmit.Visible = false;            
            //hypUser.Visible = true;
            HttpContext.Current.Session["basket"] = null;
            sendEbookEmailToPrepaidPurchase(tempTranID.ToString(), tempEmail.ToString(), vPurchaseItems.ToString(), tempFullName.ToString());
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
                    //vBookIds += cRow["id"].ToString() + ",";
                    //vBookIds2Show += cRow["id"].ToString() + ";&nbsp;&nbsp;&nbsp;";
                    //vTotalAmt += Convert.ToDecimal(cRow["price"].ToString());
                    //String tmpID = cRow["id"].ToString();
                    //String tmpImgUrl = cRow["ImageUrl"].ToString();
                    //String tmpCurrency = cRow["currency"].ToString();
                    //String tmpPrice = cRow["price"].ToString();
                    //String tmpTitle = cRow["name"].ToString() + "\n" + tmpCurrency + ' ' + tmpPrice;

                    String rBookId = cRow["id"].ToString();

                    newDBS ndbs = new newDBS();
                    DataSet dst = ndbs.getPrepaidPrice(rBookId.ToString());
                    String tempPrepaid = dst.Tables[0].Rows[0]["PrepaidPrice"].ToString();
                    tmpPrepaidTotal = tmpPrepaidTotal + Decimal.Parse(tempPrepaid);

                    if (Decimal.Parse(tempPrepaid) > 0)
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
                        tmpTotalItemsCount = tmpTotalItemsCount + 1;
                        VbookImgs += "<div style='float: left; margin-left: 6px; padding: 2px;'> " + tmpID + "<br/>" + "<img alt='bkimg' height='60' src='" + tmpImgUrl + "' title='" + tmpTitle + "'> </div>";
                    }
                    //tmpImgUrl = tmpImgUrl.Substring(1);
                    //VbookImgs += "<div style='float: left; margin-left: 6px; padding: 2px;'> " + tmpID + "<br/>" + "<img alt='bkimg' class='cartBookBox CartBookImgCss' src='" + tmpImgUrl + "' title='" + tmpTitle + "'> </div>";
                }

                String vCurrency = string.Empty;

                if (Session["UserCurrency"] != null)
                    vCurrency = Session["UserCurrency"].ToString();
                else
                    vCurrency = "";

                lblTotalItems.Text = tmpTotalItemsCount.ToString();
                //lblTotalItems.Text = tmpRowCount.ToString();
                //lblBookID.Text = vBookIds2Show;
                lblBookID.Text = "<div>" + VbookImgs + "</div>";

                //lbluCurrency.Text = tmpCurrency;
                //lblAmtCurrency.Text = vCurrency;
                lbltotalAmount.Text = tmpPrepaidTotal.ToString() + " Prepaid Points";
                ViewState["ItemsCount"] = tmpTotalItemsCount;
                ViewState["ItemsString"] = vBookIds;

                BtnSubmit.Visible = false;
                if (int.Parse(tmpTotalItemsCount.ToString()) > 0)
                {
                    BtnSubmit.Visible = true;
                }
            }
        }
    }

    protected void Send_TransactionInvoice_ToBuyer(String vbFullName, String vbMobile, String vbEmail, string vbTotalAmount, String vbCurrency, string vPurchaseItems, int vUserID, string vTranID)
    {
        String InVoiceTrackId = vUserID + "#" + vTranID + "#" + vPurchaseItems + "#" + vbEmail;
        String strDescription = string.Empty;
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<tr> <td> Transaction Reference ID  </td>" + "<td>" + vTranID + "</td> </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Purchased Item codes </td>" + "<td>" + vPurchaseItems + "</td>  </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Amount Due </td>" + "<td>" + vbCurrency + ' ' + vbTotalAmount + "</td> </tr>");
        sb.AppendLine("<br/>");

        strDescription = sb.ToString();

        String strSubmitLink = "http://14.102.146.116/eBooksBankInSubmitvEmail.aspx?vTID=" + Server.UrlEncode(CommonFunctions.Encrypt(InVoiceTrackId));
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

                                                    Thank you for your purchase!.&nbsp; The following is an invoice detailing your transaction details.&nbsp;
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

                                            <tr>
                                                <td class='NoteFont'><b>NOTE :</b>  After you make the payment via Bank, please clink on the link below to Submit your transaction Details. </td>
                                            </tr>

                                            <tr>
                                                <td>" + strSubmitLinkURL + @" </td>
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


        //.. Get Vendor Details. 
        String vVendorMobileID = string.Empty;
        String vVendorEmailID = String.Empty;
        // GetVendorInfo(ref vVendorEmailID); 
        //..Send Email... 
        #region sending Email using HmailServer.
        //hMailServer.Application objApp_Hmail = new hMailServer.Application();
        //hMailServer.Message objMsg_Hmail = new hMailServer.Message();
        //String eSenderEmailID = "Admin@WorldDigitalBiz.com";

        //objMsg_Hmail.AddRecipient("", vbEmail);
        //objMsg_Hmail.From = "Admin";
        //objMsg_Hmail.FromAddress = eSenderEmailID;
        //objMsg_Hmail.Subject = "Transaction Invoice For your Purchase : " + vTranID;
        //objMsg_Hmail.HTMLBody = tmpHtmlBody;
        //objMsg_Hmail.Save();
        ////CommonFunctions.AlertMessage("Email has been Sent");
        #endregion

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

            //objMessage.Bcc.Add("srihari@globalsurf.com.my");

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

    protected void StoreBuyerDetails(String vbFullName, String vbMobile, String vbEmail, int vClientId, String vTranID)
    {
        //...Create new user if not exists (check against emailid as unique) 
        //...
        newDBS clsObjNewDbs = new newDBS();
        int inStatus = clsObjNewDbs.ebook_Bank_Client_StoreBuyer(vbFullName, vbMobile, vbEmail, vClientId, vTranID);
        // int inStatus = objBALebook.Bank_Client_StoreBuyer(vbFullName, vbMobile, vbEmail, vClientId, vTranID); 
    }

    protected void GetVendorInfo(ref string vVendorEmailID)
    {
        //...Get Estore ID and Email Address of the User
        int vUserID = Convert.ToInt32(Session["ClientID"].ToString());
        DataSet ds = objBALebook.Bank_GetUserInfo(vUserID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dRow = ds.Tables[0].Rows[0];
            String vVendorMobile = dRow["userMobile"].ToString();
            vVendorEmailID = dRow["eMailID"].ToString();
        }
    }

    protected void sendEbookEmailToPrepaidPurchase(string vTranid, string vEmail, string vBooks, string vFullName)
    {
        //Response.Write(vTranid.ToString() + "<br>");
        //Response.Write(vEmail.ToString() + "<br>");
        //Response.Write(vBooks.ToString() + "<br>");
        //Response.Write(vFullName.ToString() + "<br>");
        String eAttachment = "";
        //String eAttachment1 = "";
        //String eAttachment2 = "";
        //String eAttachment3 = "";
        //String eAttachment4 = "";
        string eMessage = "";
        String eSenderEmailID = "";
        //vBooks = "EA1124,EA1125,";

        newDBS ndbs = new newDBS();
        DataSet dpt = ndbs.user_sendEBook_PrepaidPurchase(vBooks.ToString());
        if (dpt.Tables[0].Rows.Count > 0)
        {
            DataRow drow = dpt.Tables[0].Rows[0];
            eSenderEmailID = drow["esenderEmailID"].ToString();
            eMessage = drow["eMessage"].ToString();
            eAttachment = drow["eAttachment"].ToString();
            eMessage = eMessage.Replace(Environment.NewLine, "<br/>");
        }

        int vUserID2 = Convert.ToInt32(Session["ClientID"]);
        string QKeyword = string.Empty;
        DataSet ds3 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserID2);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds3.Tables[0].Rows[0];
            QKeyword = krow["VendorCode"].ToString();
        }

        //EBookEmailCentral.getTransactionDetails(vEmail, "", QKeyword, "", "", vBooks);

        //if (dpt.Tables[0].Rows.Count > 1)
        //{
        //    DataRow drow1 = dpt.Tables[0].Rows[1];
        //    eAttachment1 = drow1["eAttachment"].ToString(); ;
        //}
        //if (dpt.Tables[0].Rows.Count > 2)
        //{
        //    DataRow drow2 = dpt.Tables[0].Rows[2];
        //    eAttachment2 = drow2["eAttachment"].ToString(); ;
        //}
        //if (dpt.Tables[0].Rows.Count > 3)
        //{
        //    DataRow drow3 = dpt.Tables[0].Rows[3];
        //    eAttachment3 = drow3["eAttachment"].ToString(); ;
        //}
        //if (dpt.Tables[0].Rows.Count > 4)
        //{
        //    DataRow drow4 = dpt.Tables[0].Rows[4];
        //    eAttachment4 = drow4["eAttachment"].ToString();
        //}

//        string tmpHtmlBody = @"
//                                <html xmlns='http://www.w3.org/1999/xhtml'>
//                                <head >
//                                <title></title>
//                                <style type='text/css'>
//                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
//                                </style>
//                                </head>
//                                <body>
//                                    <div id='dvEmail' class='dvemailBox'> 
//                                    <div id='dvHeader' style='align-content: center;'>
        //                                            <img src='http://14.102.146.116/Images/ebImages/bookimgbanner.jpg' />
//                                                    <br />
//                                     </div>
//                                    <div id='dvContent' style='font: bold 12px Verdana'>
//                                    "
//                       + eMessage +

//                       @"
//                                </div>
//                                </div>
//   
//                            </body>
//                            </html>
//                            ";



        //String vEmailToName = vFullName;
        //String vEmailToAddress = vEmail;
        //String vEmailFromName = eSenderEmailID;
        //String VEmailFromAddress = "mail@globauser.small-dns.net";
        //String vEmailSubject = "EBook Prepaid Purchase - Transaction " + vTranid.ToString();

        //SmtpClient smtpClient = new SmtpClient();
        //MailMessage objMessage = new MailMessage();
        //string m_fromName = string.Empty;

        //VEmailFromAddress = "noreply@ebooksmsdelivery.com";
        //m_fromName = "EBookAdmin";

        //MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EBookAdmin");
        //smtpClient.Host = "localhost";
        //smtpClient.Port = 25;

        //objMessage.From = m_fromAddress;

        //objMessage.To.Add(vEmailToAddress);
        //objMessage.Subject = vEmailSubject;
        //objMessage.IsBodyHtml = true;

        //String tmpEbooks = String.Empty;
        //String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        ////... Get the List of Books to be Attached. 

        //// == ATTACHEMENT    1   ===

        //if (eAttachment != "")
        //{
        //    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment)))
        //    {
        //        Attachment objAtt1 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment));
        //        objMessage.Attachments.Add(objAtt1);
        //        //objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment1)));
        //    }
        //}

        //if (eAttachment1 != "")
        //{
        //    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment1)))
        //    {
        //        Attachment objAtt1 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment1));
        //        objMessage.Attachments.Add(objAtt1);
        //        //objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment1)));
        //    }
        //}

        //// == ATTACHEMENT    2   ===
        //if (eAttachment2 != "")
        //{
        //    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment2)))
        //    {
        //        Attachment objAtt2 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment2));
        //        objMessage.Attachments.Add(objAtt2);
        //        //objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment2)));
        //    }
        //}

        //// == ATTACHEMENT    3   ===
        //if (eAttachment3 != "")
        //{
        //    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment3)))
        //    {
        //        Attachment objAtt3 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment3));
        //        objMessage.Attachments.Add(objAtt3);
        //        // objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment3)));
        //    }
        //}

        //// == ATTACHEMENT    4   ===
        //if (eAttachment4 != "")
        //{
        //    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment4)))
        //    {
        //        Attachment objAtt4 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment4));
        //        objMessage.Attachments.Add(objAtt4);
        //        // objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment4)));
        //    }
        //}


        //String sHtmlBody = tmpHtmlBody;
        //objMessage.Body = sHtmlBody;

        ////NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
        //NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
        //smtpClient.UseDefaultCredentials = false;
        //smtpClient.Credentials = authinfo;

        //// Send SMTP mail
        //smtpClient.Send(objMessage);
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