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

public partial class eBooksBankInPre : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    //DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0;
    int vClientId = 0;

    //long MaxEbookImageSize = 2097152;   // 2MB


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


        //int reStatus = objBALebook.Bank_Client_Add(vBankID, vBankInBy, vBankInAmount, vBankInDate, vBankInTime, vBankInSlipImage, vBankInRef, vPurchaseDesc, vPurchaseItems,vTranID, vClientId);

        int reStatus = objBALebook.Bank_Client_PreInsert(vBankersFullName, vBankdersMobile, vBankdersEmail, vPurchaseAmount, vPurchaseCurrency, vPurchaseItems, vClientId, vTranID); 

        if (reStatus == 1)
        {


            //Send 'Transaction Deails' as  email to the User based on the Email Given

            Send_TransactionInvoice_ToBuyer(vBankersFullName, vBankdersMobile, vBankdersEmail, vPurchaseAmount, vPurchaseCurrency, vPurchaseItems, vClientId, vTranID); 
           
 
            //..Create a new Buyer User if not already created with this email and Send an Email to him of the Login Details. 

            StoreBuyerDetails(vBankersFullName, vBankdersMobile, vBankdersEmail, vClientId, vTranID); 


            // redirect the page to Submit Bankin Details. 
            Server.Transfer("eBooksBankInPost.aspx?qtrID=" + vTranID); 



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


    protected void Send_TransactionInvoice_ToBuyer(String vbFullName, String vbMobile, String vbEmail, string vbTotalAmount, String vbCurrency, string vPurchaseItems, int vUserID, string vTranID)
    {

        String InVoiceTrackId = vUserID + "#" + vTranID + "#" + vPurchaseItems + "#" + vbEmail;

        String strDescription = string.Empty;
        String userEmail = "";
        newDBS ndbs1 = new newDBS();
        DataSet dst = ndbs1.Ebook_getUserEmailID(vUserID.ToString());
        userEmail = dst.Tables[0].Rows[0]["email"].ToString();

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
                if (userEmail!="")
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
            vVendorEmailID  = dRow["eMailID"].ToString();
          

        }


    }




}




