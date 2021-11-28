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

public partial class N_DirectBankin : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    //DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0;
    int vClientId = 0;

    //long MaxEbookImageSize = 2097152;   // 2MB

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
        {
            //CommonFunctions.AlertMessageAndRedirect("Please Login to checkout", "N_User_Login.aspx");
            Response.Redirect("N_User_LoginB.aspx");
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
        String vBankersFullName = txtcName.Text.Trim();
        String vBankdersMobile = txtcMobile.Text.Trim();
        String vBankdersEmail = txtcEmail.Text.Trim();
        String vPurchaseItems = ViewState["ItemsString"].ToString();
        String vPurchaseCurrency = lblAmtCurrency.Text.Trim();
        String vPurchaseAmount = lbltotalAmount.Text.Trim();
        String vTranID = GetUniqueKey(12);
        vTranID = vTranID.ToUpper();
        int reStatus = objBALebook.Bank_Client_PreInsert(vBankersFullName, vBankdersMobile, vBankdersEmail, vPurchaseAmount, vPurchaseCurrency, vPurchaseItems, vClientId, vTranID);
        if (reStatus == 1)
        {
            //Send 'Transaction Deails' as  email to the User based on the Email Given
            Send_TransactionInvoice_ToBuyer(vBankersFullName, vBankdersMobile, vBankdersEmail, vPurchaseAmount, vPurchaseCurrency, vPurchaseItems, vClientId, vTranID);
            //..Create a new Buyer User if not already created with this email and Send an Email to him of the Login Details. 
            StoreBuyerDetails(vBankersFullName, vBankdersMobile, vBankdersEmail, vClientId, vTranID);
            // redirect the page to Submit Bankin Details. 
            DataSet ds2;
            newDBS clsObjNewDbs = new newDBS();
            string cLoginuser = string.Empty;
            if ((cLoginuser == null) || (cLoginuser == ""))
            {
                cLoginuser = "siva";
            }
            if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
            {
                cLoginuser = "siva";
            }
            else
            {
                cLoginuser = Session["cLogin"].ToString();
            }
            ds2 = clsObjNewDbs.user_TransctionHistory(cLoginuser, vTranID,"1");
            Server.Transfer("N_DirectBankInConfirm.aspx?qtrID=" + vTranID);
        }
        else
        {
            CommonFunctions.AlertMessage("View are currently facing difficulty in saving your details.");
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

        newDBS ndbs = new newDBS();
        DataSet dstUser = ndbs.user_getProfile(Session["cLogin"].ToString());
        if (dstUser.Tables[0].Rows.Count > 0)
        {
            txtcName.Text = dstUser.Tables[0].Rows[0]["FullName"].ToString();
            txtcEmail.Text = dstUser.Tables[0].Rows[0]["email"].ToString();
            txtcMobile.Text = dstUser.Tables[0].Rows[0]["Mobile"].ToString();
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

    protected void Send_TransactionInvoice_ToBuyer(String vbFullName, String vbMobile, String vbEmail, string vbTotalAmount, String vbCurrency, string vPurchaseItems, int vUserID, string vTranID)
    {
        String strDescription = string.Empty;
        String userEmail = "";
        newDBS ndbs1 = new newDBS();
        DataSet dst = ndbs1.Ebook_getUserEmailID(vUserID.ToString());
        if (dst.Tables[0].Rows.Count > 0)
        {
            DataRow dRow = dst.Tables[0].Rows[0];
            userEmail = dRow["email"].ToString();
        }

        String InVoiceTrackId = vUserID + "#" + vTranID + "#" + vPurchaseItems + "#" + vbEmail;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<tr> <td> Transaction Reference ID  </td>" + "<td>" + vTranID + "</td> </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Purchased Item codes </td>" + "<td>" + vPurchaseItems + "</td>  </tr>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<tr> <td> Amount Due </td>" + "<td>" + vbCurrency + ' ' + vbTotalAmount + "</td> </tr>");
        sb.AppendLine("<br/>");

        strDescription = sb.ToString();
        String strSubmitLink = "http://14.102.146.116/eBooksBankInSubmitvEmail.aspx?vTID=" + Server.UrlEncode(CommonFunctions.Encrypt(InVoiceTrackId));
        //String strSubmitLink = "http://14.102.146.116/N_BankInConfirmVEmail.aspx?vTID=" + vTranID.ToString();
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
        string m_fromName = string.Empty;

        //userEmail = "kallurusiva@gmail.com";
        //vbEmail = "kodur_siva@yahoo.com";

        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-0ad485da45bb169cabfea074c9e87e2d");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "EbookDelivery <me@maildly.ebdvy.com>");
        request.AddParameter("to", userEmail.ToString());
        request.AddParameter("bcc", vbEmail.ToString());
        request.AddParameter("subject", "Transaction Invoice For your Purchase : " + vTranID);
        request.AddParameter("text", "Testing some Mailgun awesomness!");
        request.AddParameter("html", tmpHtmlBody);
        request.Method = Method.POST;
        client.Execute(request);

        //SmtpClient smtpClient = new SmtpClient();
        //MailMessage objMessage = new MailMessage();
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

