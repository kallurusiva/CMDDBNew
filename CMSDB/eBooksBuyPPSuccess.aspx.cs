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
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

public partial class eBooksBuyPPsuccess : System.Web.UI.Page
{    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    //DataTable dt;
    //int qCatID = 0;
    string vCurrency = string.Empty;

    String vBookID = String.Empty;
    String vCallingPage = String.Empty;
    
    String vBookName = string.Empty;

    String qTransactionId = string.Empty;
    String qTransactionType = string.Empty;
    String qPytFee = string.Empty;
    String qPytAmount = String.Empty;
    String qPytStatus = String.Empty; 
    String qCurrencyCode = String.Empty;
    String qCustomText = String.Empty;

    String qUniqueID = string.Empty;
    String qitemNumber = String.Empty;
    String qItemName = String.Empty; 

    protected void Page_Load(object sender, EventArgs e)
    {
       

        #region //rendering top left panel 

        //if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet")) 
        //{

        //    HtmlGenericControl myDivObject;
        //    myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        //    //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
        //    sb.Append("<tr>");
        //    sb.Append("<td align='left' valign='top'>");
        //    sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        //    sb.Append("</td>");
        //    sb.Append("<td>");
        //    sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
        //    sb.Append("</td>");
        //    sb.Append("</tr>");
        //    sb.Append("</table>");

        //    myDivObject.InnerHtml = sb.ToString();

        //    //myDivObject.InnerHtml = "<table border='0' class='dvBannerLeftPanel'><tr><td><img alt='imbnLeftimg' src='Images/faq_head.jpg' /> </td></tr></table>";
        //}
        #endregion 


        String ctMobileNo = string.Empty;
        String ctUserID = string.Empty;
        String ctUniqueID = string.Empty;
        String ctWebSite = string.Empty;
        

        if (!IsPostBack)
        {

            ViewState["BookId"] = "";
            ViewState["ClientID"] = "";
            ViewState["CallingPageURi"] = "";              

            if (Request.QueryString.Count > 0)
            {
                //foreach (String key in Request.QueryString.AllKeys)
                //{
                //    Response.Write(key + " : " + Request.QueryString[key] + "<br/>");
                //}


                //TransactionID=2TG784829L656200D
                //&PytAmount=1.00
                //&PytStatus=Completed
                //&CurrencyCode=USD
                //&itemNumber=EC1213
                //&UniqueID=7729473507
                //&CustomText=60149664566_7729_7729473507_WorldDigitalBiz.com_0%23EC1213%231.00%23USD%23WDB%23lohchuenleong%40gmail.com%2360149664566

                ////string rawURL = HttpContext.Current.Request.ServerVariables["query_string"];
                //Response.Write(rawURL); 

                qTransactionId = Request.QueryString["TransactionID"].ToString();
                qPytStatus = Request.QueryString["PytStatus"].ToString();
                qPytAmount = Request.QueryString["PytAmount"].ToString();
                qCurrencyCode = Request.QueryString["CurrencyCode"].ToString();
                qUniqueID = Request.QueryString["UniqueID"].ToString();
                qItemName = Request.QueryString["itemName"].ToString();
                qitemNumber = Request.QueryString["itemNumber"].ToString();
                qCustomText = Request.QueryString["CustomText"].ToString();

                //qTransactionId = "7MH70179W8759113B";
                //qPytStatus = "Completed";
                //qPytAmount = "7.50";
                //qCurrencyCode = "MYR";
                //qUniqueID = "7661396621";
                //qItemName = "EE1447,EC1187,EP1102";
                //qitemNumber = "766198608";
                //qCustomText = "0126583065_7661_7661396621_HappySameBooks.com_7661#766198608#1#7.50#MYR#HS#kodur_siva@yahoo.com#0126583065";

                StoreReturnedValues(qTransactionId, qPytStatus, qPytAmount, qCurrencyCode, qUniqueID,qitemNumber, qCustomText);

                ParseQueryValues(qTransactionId, qPytStatus, qPytAmount, qCurrencyCode, qUniqueID,qitemNumber, qCustomText);
                Session["defLanguage"] = "en-US";             
                
                //Response.Redirect("eBooksBuyPPsuccess.aspx?" + rawURL);
                //Server.Transfer("eBooksBuyPPsuccess.aspx?" + rawURL); 
               // Response.End();

                lblHeader.Text = "Successful PayPal Payment Transaction done"; 

                lblTxDetails.Text = qTransactionId;

                lblBookID.Text = qitemNumber;

                lblBookName.Text = qItemName; 
                
                decimal vPytAmount = Convert.ToDecimal(qPytAmount);
                lblPytMade.Text = qCurrencyCode + " " + String.Format("{0:n2}", vPytAmount); //  tmpBookPrice = tmpBookCurrency + " " + String.Format("{0:n2}", qPytAmount);

                lblPytStatus.Text = qPytStatus;
                vBookID = qitemNumber;  

                // 60149664566_7550_7550378922_smsbizsolution.com_0 #EE1516 #5.00 #USD #EBS #hari_Biz@globalsurf.com.my #60149664566
                // vClientID + "#" + vBookID + "#" + vBookPrice + "#" + vBookCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;
                // 60149664566_7550_7550104455_smsbizsolution.com_0
                // Response.Write(vCustomText + "#" + vBookID + "#" + vBookPrice + "#" + vBookCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile);

                string redirectURL = lnkToWebsite.PostBackUrl.ToString();
                Response.Redirect(redirectURL.ToString());
            }         

        }

    }

    protected void ParseQueryValues(String qTransactionId, String qPytStatus, String qPytAmount, String qCurrencyCode, String qUniqueID, String qitemNumber, String qCustomText)
    {


        //Custom Message
        String[] StringArray = qCustomText.Split('_');

        String tmpMobileNo = StringArray[0];
        String tmpUserID = StringArray[1];
        String tmpUniqueID = StringArray[2];
        String tmpWebsite = StringArray[3];
        String tmpCustomMsg = StringArray[4];

        String[] CmArray = tmpCustomMsg.Split('#');

        //vUserID + "#" + vBookID + "#" + vBookPrice + "#" + vBookCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;

        String tmpUserID2 = CmArray[0];
        String tmpBookID = CmArray[1];
        String tmpBookPrice = CmArray[2];
        String tmpCurrency = CmArray[3];
        String tmpeStoreID = CmArray[4];
        String tmpBusiness = CmArray[5];
        String tmpBuyerMobile = CmArray[6];


        Session["ClientID"] = tmpUserID;
        string tmpMasterfile = string.Empty;
        string tmpMasterCss = string.Empty;
        string ppwebsite = string.Empty;


                SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                dbConn.Open();
                SqlCommand dbCmd = new SqlCommand("usp_Retreive_UserMasterPageAndCss", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = Convert.ToInt32(Session["ClientID"]);
                SqlDataReader dbReader;
                dbReader = dbCmd.ExecuteReader();

                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {
                        tmpMasterfile = dbReader["MasterPageName"].ToString();
                        tmpMasterCss = dbReader["MasterCSS"].ToString();
                        ppwebsite = dbReader["ppWebsite"].ToString();
                    }
                }
    
                dbConn.Close();

                if (!tmpMasterfile.Equals(string.Empty))
                {
                    Session["MasterPageFile"] = tmpMasterfile;
                    Session["MasterPageCss"] = tmpMasterCss;
                }


        //Navigation to Website 
                if (tmpWebsite == "")
                    tmpWebsite = "WorldDigitalBiz.com"; 
                //lnkToWebsite.PostBackUrl = "http://www." + tmpWebsite;
                lnkToWebsite.PostBackUrl = ppwebsite + "/DefaultRedirectPaypal.aspx?UD=" + qitemNumber.ToString();

                newDBS ldbs = new newDBS();
                DataSet ls = ldbs.get_LifeReportLogsPaypal(qitemNumber.ToString());

                string dob = string.Empty;
                string Email = string.Empty;
                string FName = string.Empty;
                string LFRName = string.Empty;
                if (ls.Tables[0].Rows.Count > 0)
                {
                    DataRow krow = ls.Tables[0].Rows[0];

                    dob = krow["DOB"].ToString();
                    Email = krow["Email"].ToString();
                    FName = krow["FName"].ToString();
                    LFRName = krow["itemname"].ToString();
                }
                
                CMSv3.BAL.PayPal objPayPal = new CMSv3.BAL.PayPal();

                if (LFRName.Substring(0, 3) == "LFR")
                {
                }
                else
                {
                    LoadBookDetails(tmpBookID, Convert.ToInt32(tmpUserID));
                    objPayPal.EB_PostPaymentDetails_Update(qTransactionId, qPytStatus, qPytAmount, qCurrencyCode, qUniqueID, qitemNumber, qCustomText);
                    SendBookByMail(qUniqueID, qitemNumber, tmpUserID);
                    SendCCAlerts(tmpBookID, tmpUserID);
                }                
    }

    protected void SendCCAlerts(String vBookID, String vUserId)
    {

        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.EBOOK_GetBook2EmailDetails(vBookID);
        DataTable dt = ds.Tables[0];


       // String vReturnMessage = objEbook.EBOOK_SendCCalerts(vMobileID, vMessage, vMsgID, vShortcode, vKeyword, vBookCode, vEmail, vFullName);

    }

    protected void SendBookByMail(String vUniqueId, String vItemNumber, String vUserId)
    {

        CMSv3.BAL.PayPal objPayPal = new CMSv3.BAL.PayPal();

        ds = objPayPal.EB_PayPal_RetrieveDetailsByUniqueID(vUniqueId, vItemNumber, Convert.ToInt32(vUserId));
        DataTable dtTx = ds.Tables[0];

        if (dtTx.Rows.Count > 0)
        {
            DataRow Drow = dtTx.Rows[0];

            String vUserName = Drow["UserName"].ToString();
            String vMobileNo = Drow["MobileNo"].ToString();
            String vBuyerEmail = Drow["BuyerEmail"].ToString();
            String vBookID = Drow["ItemName"].ToString();
            string vUserId1 = Drow["UserId"].ToString();
            string bPassword = Drow["bookpassword"].ToString();

            //string bPassword = vMobileNo + vUserName;
            //bPassword = bPassword.Replace(" ", "");
            //if (bPassword.Length > 19) { bPassword = bPassword.Substring(0, 20).ToLower(); }

            string QKeyword = string.Empty;
            DataSet ds3 = objBALebook.Ebook_KeywordDetails_ByUserID(Convert.ToInt32(vUserId1));
            if (ds3.Tables[0].Rows.Count > 0)
            {
                DataRow krow = ds3.Tables[0].Rows[0];
                QKeyword = krow["VendorCode"].ToString();
            }

            newDBS objDBS = new newDBS();
            objDBS.SMSEbook_getDetails(vItemNumber.ToString(), "1");
            MgMail.sndMailgunLinks(vItemNumber.ToString(), "1", vBuyerEmail.ToString());

            //EBookEmailCentral.getTransactionDetails(vBuyerEmail, "", QKeyword, "", "", vBookID, bPassword);
            
            //if (vBookID.Substring(0, 3).ToUpper() == "EVB")
            //{
            //    Send_ValueBuy_Ebook(vBookID, vUserName, vBuyerEmail);
            //}

            //else
            //{
            //    vBookID = vBookID.Replace(",", ""); 
            //    Send_Ebook(vBookID, vUserName, vBuyerEmail);
            //}

        }
    }

    protected void LoadBookDetails(String vBookID, int vUserID)
    {
        ds = objBALebook.Eb_WEB_BuyBook(vBookID, vUserID);
        DataTable dtBook = ds.Tables[0];

        if (dtBook.Rows.Count > 0)
        {
            DataRow krow = dtBook.Rows[0];

            lblBookID.Text = krow["BookID"].ToString();
            lblBookName.Text = krow["BookName"].ToString();

            String tmpBookPrice = krow["NetPrice"].ToString();
            String tmpBookCurrency = krow["UserCurrency"].ToString();

            ImgEbook.ImageUrl = krow["ImageFileFullURL"].ToString();

            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice);
                tmpBookPrice = tmpBookCurrency + " " + String.Format("{0:n2}", vPrice);
            }

            //string redirectURL = lnkToWebsite.PostBackUrl.ToString();
            //Response.Redirect(redirectURL.ToString());

            //
            //String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));
            // lblTxDetails.Text = tmpBookPrice;


        }
    }

    protected void StoreReturnedValues(String qTransactionId, String qPytStatus, String qPytAmount, String qCurrencyCode, String qUniqueID, String qitemNumber, String qCustomText)
    {
        //Custom Message
        String[] StringArray = qCustomText.Split('_');

        String tmpMobileNo = StringArray[0];
        String tmpUserID = StringArray[1];
        String tmpUniqueID = StringArray[2];
        String tmpWebsite = StringArray[3];
        String tmpCustomMsg = StringArray[4];

        String[] CmArray = tmpCustomMsg.Split('#');        

        //vUserID + "#" + vBookID + "#" + vBookPrice + "#" + vBookCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;              

        String tmpUserID2 = CmArray[0];
        String tmpBookID = CmArray[1];
        String tmpBookPrice = CmArray[2];
        String tmpCurrency = CmArray[3];
        String tmpeStoreID = CmArray[4];
        String tmpBusiness = CmArray[5];        
        String tmpBuyerMobile = CmArray[6];

        newDBS ldbs = new newDBS();
        DataSet ls = ldbs.get_LifeReportLogsPaypal(qitemNumber.ToString());

        string dob = string.Empty;
        string Email = string.Empty;
        string FName = string.Empty;
        string LFRName = string.Empty;
        if (ls.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ls.Tables[0].Rows[0];

            dob = krow["DOB"].ToString();
            Email = krow["Email"].ToString();
            FName = krow["FName"].ToString();
            LFRName = krow["itemname"].ToString();
        }

        CMSv3.BAL.PayPal objPayPal = new CMSv3.BAL.PayPal();

        objPayPal.EB_PostPaymentDetails_Update(qTransactionId, qPytStatus, qPytAmount, qCurrencyCode, qUniqueID, qitemNumber, qCustomText);

                    HttpWebRequest WebReq = null;
                    HttpWebResponse WebResp;

                    objPayPal.EB_PostPaymentDetails_Update(qTransactionId, qPytStatus, qPytAmount, qCurrencyCode, qUniqueID, qitemNumber, qCustomText);

                    String strSMSvalue = "";
                    int rcount;
                    DataSet ppReward = ldbs.get_EBookPaypalReward_Details(qitemNumber.ToString());
                    if (ppReward.Tables[1].Rows.Count > 0)
                    {
                        DataRow rrow = ppReward.Tables[1].Rows[0];
                        rcount = Convert.ToInt32( rrow["counter"].ToString());
                    }
                    if (ppReward.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow myRow in ppReward.Tables[0].Rows)
                        {
                            if (myRow["chatid"].ToString() != "0" && Convert.ToDecimal(myRow["finalshare"].ToString()) > 0)
                            {
                                strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + myRow["chatid"].ToString();
                                strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode("EBookBizTech - Congratulations Someone Purchased an EBook using Credit Card.");
                                strSMSvalue = strSMSvalue + "\n\nYou Earned Incentive USD " + myRow["finalshare"].ToString() + "\n\nPurchased By: " + myRow["pMobile"].ToString();
                                strSMSvalue = strSMSvalue + "\nProduct Code: " + myRow["BookCode"].ToString() + "\nProduct Name: " + myRow["BookName"].ToString();
                                WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
                                WebReq.Method = "GET";
                                WebResp = (HttpWebResponse)WebReq.GetResponse();
                                if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                                {
                                    Stream _Answer = WebResp.GetResponseStream();
                                    StreamReader Answer = new StreamReader(_Answer);
                                    String strTemp = Answer.ReadToEnd();
                                }
                            }
                            if (myRow["SChatid"].ToString() != "0" && Convert.ToDecimal(myRow["sponsorshare"].ToString()) > 0)
                            {
                                strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + myRow["SChatid"].ToString();
                                strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode("EBookBizTech - Congratulations Someone Purchased an EBook using Credit Card.");
                                strSMSvalue = strSMSvalue + "\n\nYou Earned Direct Incentive USD " + myRow["sponsorshare"].ToString() + "\n\nPurchased By: " + myRow["pMobile"].ToString();
                                strSMSvalue = strSMSvalue + "\nProduct Code: " + myRow["BookCode"].ToString() + "\nProduct Name: " + myRow["BookName"].ToString();

                                WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
                                WebReq.Method = "GET";
                                WebResp = (HttpWebResponse)WebReq.GetResponse();
                                if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                                {
                                    Stream _Answer = WebResp.GetResponseStream();
                                    StreamReader Answer = new StreamReader(_Answer);
                                    String strTemp = Answer.ReadToEnd();
                                }
                            }
                            if (myRow["AChatid"].ToString() != "0" && Convert.ToDecimal(myRow["AuthorShare"].ToString()) > 0)
                            {
                                strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + myRow["AChatid"].ToString();
                                strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode("EBookBizTech - Congratulations Someone Purchased an EBook using Credit Card.");
                                strSMSvalue = strSMSvalue + "\n\nYou Earned Author Incentive USD " + myRow["AuthorShare"].ToString() + "\n\nPurchased By: " + myRow["pMobile"].ToString();
                                strSMSvalue = strSMSvalue + "\nProduct Code: " + myRow["BookCode"].ToString() + "\nProduct Name: " + myRow["BookName"].ToString();

                                WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
                                WebReq.Method = "GET";
                                WebResp = (HttpWebResponse)WebReq.GetResponse();
                                if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                                {
                                    Stream _Answer = WebResp.GetResponseStream();
                                    StreamReader Answer = new StreamReader(_Answer);
                                    String strTemp = Answer.ReadToEnd();
                                }
                            }
                            if (myRow["IChatid"].ToString() != "0" && Convert.ToDecimal(myRow["IntroducerShare"].ToString()) > 0)
                            {
                                strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + myRow["IChatid"].ToString();
                                strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode("EBookBizTech - Congratulations Someone Purchased an EBook using Credit Card.");
                                strSMSvalue = strSMSvalue + "\n\nYou Earned Introducer Incentive USD " + myRow["IntroducerShare"].ToString() + "\n\nPurchased By: " + myRow["pMobile"].ToString();
                                strSMSvalue = strSMSvalue + "\nProduct Code: " + myRow["BookCode"].ToString() + "\nProduct Name: " + myRow["BookName"].ToString();

                                WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
                                WebReq.Method = "GET";
                                WebResp = (HttpWebResponse)WebReq.GetResponse();
                                if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                                {
                                    Stream _Answer = WebResp.GetResponseStream();
                                    StreamReader Answer = new StreamReader(_Answer);
                                    String strTemp = Answer.ReadToEnd();
                                }
                            }
                        }
                    }

                    //strSMSvalue = "https://api.telegram.org/bot364356589:AAGhOab_5vuTD__0l-fGRxMEX-9c__ZFHFc/sendmessage?chat_id=306615026&text=Paypal Transaction happend for ebook: " + tmpBookID;
                    strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=306615026&message=Paypal Transaction happend for ebook: " + tmpBookID;
                    WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

                    //WebReq.ClientCertificates.Add(Cert);
                    WebReq.Method = "GET";
                    WebResp = (HttpWebResponse)WebReq.GetResponse();
                    if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                    {
                        Stream _Answer = WebResp.GetResponseStream();
                        StreamReader Answer = new StreamReader(_Answer);
                        String strTemp = Answer.ReadToEnd();
                    }

                    if (LFRName.Substring(0, 3) == "LFR")
                    {
                        ImgEbook.ImageUrl = "~/Images/NumerologyDisp.jpg";
                        lnkToWebsite.Visible = false;

                        strSMSvalue = "http://183.81.165.110/WebApps/NReportPDF/NMReport/LifeReportPaypal.aspx?TID=" + qitemNumber.ToString();

                        WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

                        //WebReq.ClientCertificates.Add(Cert);
                        WebReq.Method = "GET";
                        WebResp = (HttpWebResponse)WebReq.GetResponse();
                        if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                        {
                            Stream _Answer = WebResp.GetResponseStream();
                            StreamReader Answer = new StreamReader(_Answer);
                            String strTemp = Answer.ReadToEnd();
                        }
                        sendLifeReport();
                        //lnkReport.Visible = true;
                        //lnkReport.PostBackUrl = "http://nmdvy.com/?t=" + qitemNumber.ToString();
                    }
                    else
                    {
                        SendBookByMail(qUniqueID, qitemNumber, tmpUserID);
                        LoadBookDetails(qitemNumber, Convert.ToInt32(tmpUserID));
                    }        
    }

    protected void Send_Ebook(String vBookID, string vFullName, String vEmailID)
    {        
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.EBOOK_GetBook2EmailDetails(vBookID);
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow drow = dt.Rows[0];
            String eSubject = drow["eSubject"].ToString();
            String eSenderEmailID = drow["esenderEmailID"].ToString();
            String eMessage = drow["eMessage"].ToString();
            String eAttachment = drow["eAttachment"].ToString();
            String BookImage = drow["ImageFileName"].ToString();
            String BookImageURL = "http://14.102.146.116/DocumentRepository/eBookImages/" + BookImage;
            String BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL + "' />";

            eMessage = eMessage.Replace(Environment.NewLine, "<br/>");

            string tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head >
                                <title></title>
                                <style type='text/css'>
                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
                                </style>
                                </head>
                                <body>
                                    <div id='dvEmail' class='dvemailBox'> 
                                    <div id='dvHeader' style='align-content: center;'>
                                            <img src='http://14.102.146.116/Images/ebImages/bookimgbanner.jpg' />
                                                    <br />
                                     </div>
                                    <div id='dvContent' style='font: bold 12px Verdana'>
                                    "
                       + eMessage +

                       @"
                                </div>
                            <div id='dvBookImage'>"

                       + BookImageHtml +

                            @"</div>


                                </div>
   
                            </body>
                            </html>
                            ";


            String vEmailToName = vFullName;
            String vEmailToAddress = vEmailID;
            
            String vEmailFromName = "";
            if (eSenderEmailID == "")
                vEmailFromName = "EBookAdmin";
            else
                vEmailFromName = eSenderEmailID;

            String VEmailFromAddress = "noreply@ebooksmsdelivery.com";
                vEmailFromName = "EBookAdmin";


            String vEmailSubject = eSubject;

            #region Sending mail using SmarterMail


            SmtpClient smtpClient = new SmtpClient();
            MailMessage objMessage = new MailMessage();
            string m_fromName = string.Empty;
            try
            {
                m_fromName = "EBookAdmin";

                MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EBookAdmin");
                smtpClient.Host = "localhost";
                smtpClient.Port = 25;

                objMessage.From = m_fromAddress;

                objMessage.To.Add(vEmailToAddress);
                objMessage.Subject = vEmailSubject;

                objMessage.IsBodyHtml = true;
                objMessage.Body = tmpHtmlBody;

                String tmpeBookfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
                
                if (File.Exists(Server.MapPath(tmpeBookfileFolder + "/" + eAttachment)))
                {
                    Attachment objAtt = new Attachment(Server.MapPath(tmpeBookfileFolder + "/" + eAttachment));
                    objMessage.Attachments.Add(objAtt);
                }

                //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
                NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = authinfo;

                // Send SMTP mail
                smtpClient.Send(objMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }

    }

    protected void Send_ValueBuy_Ebook(String vBookID, string vFullName, String vEmailID)
    {

        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.EBOOK_GetBook2EmailDetails2(vBookID);
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow drow = dt.Rows[0];

            String eSubject = drow["eSubject"].ToString();
            String eSenderEmailID = drow["esenderEmailID"].ToString();
            String eMessage = drow["eMessage"].ToString();
            String eAttachment1 = drow["eAttachment1"].ToString();
            String eAttachment2 = drow["eAttachment2"].ToString();
            String eAttachment3 = drow["eAttachment3"].ToString();
            String eAttachment4 = drow["eAttachment4"].ToString();
            String eAttachment5 = drow["eAttachment5"].ToString();

            eMessage = eMessage.Replace(Environment.NewLine, "<br/>");

            string tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head >
                                <title></title>
                                <style type='text/css'>
                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
                                </style>
                                </head>
                                <body>
                                    <div id='dvEmail' class='dvemailBox'> 
                                    <div id='dvHeader' style='align-content: center;'>
                                            <img src='http://210.5.45.8/Images/ebImages/bookimgbanner.jpg' />
                                                    <br />
                                     </div>
                                    <div id='dvContent' style='font: bold 12px Verdana'>
                                    "
                       + eMessage +

                       @"
                                </div>
                                </div>
   
                            </body>
                            </html>
                            ";
            

            String vEmailToName = vFullName;
            String vEmailToAddress = vEmailID;

            String VEmailFromAddress = "noreply@ebooksmsdelivery.com";

            String vEmailFromName = "";
            if (eSenderEmailID == "")
                vEmailFromName = "EBookAdmin";
            else
                vEmailFromName = eSenderEmailID;

            String vEmailSubject = eSubject;

            #region Sending mail using SmarterMail

            SmtpClient smtpClient = new SmtpClient();
            MailMessage objMessage = new MailMessage();
            string m_fromName = string.Empty;
            try
            {
                m_fromName = "EBookAdmin";
                VEmailFromAddress = "noreply@ebooksmsdelivery.com";

                MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EBookAdmin");
                smtpClient.Host = "localhost";
                smtpClient.Port = 25;

                objMessage.From = m_fromAddress;

                objMessage.To.Add(vEmailToAddress);
                objMessage.Subject = vEmailSubject;

                objMessage.IsBodyHtml = true;
                objMessage.Body = tmpHtmlBody;

                String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
              
                if (eAttachment1 != "")
                {
                    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment1)))
                    {
                        Attachment objAtt1 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment1));
                        objMessage.Attachments.Add(objAtt1);
                    }
                }

                // == ATTACHEMENT    2   ===
                if (eAttachment2 != "")
                {
                    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment2)))
                    {
                        //objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment2)));

                        Attachment objAtt2 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment2));
                        objMessage.Attachments.Add(objAtt2);

                    }
                }

                // == ATTACHEMENT    3   ===
                if (eAttachment3 != "")
                {
                    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment3)))
                    {
                       // objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment3)));
                        Attachment objAtt3 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment3));
                        objMessage.Attachments.Add(objAtt3);
                    }
                }

                // == ATTACHEMENT    4   ===
                if (eAttachment4 != "")
                {
                    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment4)))
                    {
                       // objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment4)));

                        Attachment objAtt4 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment4));
                        objMessage.Attachments.Add(objAtt4);
                    }
                }

                // == ATTACHEMENT    5   ===
                if (eAttachment5 != "")
                {
                    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment5)))
                    {
                        //objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment5)));

                        Attachment objAtt5 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment5));
                        objMessage.Attachments.Add(objAtt5);
                    }
                }

                //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
                NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = authinfo;

                // Send SMTP mail
                smtpClient.Send(objMessage);
            }
            catch (Exception ex)
            {
                throw ex;

            }

            #endregion

        }

    }

    protected void sendLifeReport()
    {
        string dob = string.Empty;
        string Email = string.Empty;
        string FName = string.Empty;

        newDBS ldbs = new newDBS();
        DataSet ls = ldbs.get_LifeReportLogsPaypal(qitemNumber.ToString());

        if (ls.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ls.Tables[0].Rows[0];

            dob = krow["DOB"].ToString();
            Email = krow["Email"].ToString();
            FName = krow["FName"].ToString();
        }

        string eMessage = FName.ToString() + " Life Report. Date of Birth: " + dob.ToString();
        //string BookImageHtml = "http://www.happysamebooks.com/images/NumerologyDisp.jpg";
        String vEmailSubject = FName.ToString() + " Life Report";

        string tmpHtmlBody = @"
                                        <html xmlns='http://www.w3.org/1999/xhtml'>
                                        <head >
                                        <title></title>
                                        <style type='text/css'>
                                            .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
                                        </style>
                                        </head>
                                        <body>
                                            <div id='dvEmail' class='dvemailBox'> 
                                            <div id='dvHeader' style='align-content: center;'>
                                                    <img src='http://14.102.146.116/Images/ebImages/bookimgbanner.jpg' />
                                                            <br />
                                             </div>
                                            <div id='dvContent' style='font: bold 12px Verdana'>
                                            "
                   + eMessage +

                        @"</div>
        
        
                                        </div>
           
                                    </body>
                                    </html>
                                    ";

        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-0ad485da45bb169cabfea074c9e87e2d");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "EbookDelivery <me@maildly.ebdvy.com>");
        request.AddParameter("to", Email);
        //request.AddParameter("bcc", "kodur_siva@yahoo.com,kallurusiva@hotmail.com");
        request.AddParameter("subject", vEmailSubject);
        //request.AddParameter("text", "Testing some Mailgun awesomness!");
        request.AddParameter("html", tmpHtmlBody);

        String eAttachment = qitemNumber + ".pdf";
        //request.AddFile("attachment", Path.Combine(HttpContext.Current.Server.MapPath(tmpEbfileFolder), eAttachment), "multipart/form-data");
        request.AddFile("attachment", Path.Combine(@"C:\inetpub\wwwroot\WebApps\NReportPDF\pdfRepository\", eAttachment), "");

        request.Method = Method.POST;
        client.Execute(request);
    }
    
}




