using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Net;

public partial class Admin_EbAd_EmailVerification : System.Web.UI.Page
{
    //DataView dv;
    DataSet ds;

    String tmp_WebSiteName = "http://www.worlddigitalbiz.com";

    String tmp_EmailVerifyValidateLink = "http://14.102.146.116/WebApps/ebook/MyEmailVerification.aspx";
 
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        if (!IsPostBack)
        {
            ds = objEbook.Retrieve_EMSContent_ByUserID(Convert.ToInt32(Session["UserID"].ToString()));

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];
                Retrieve_UserEmail(utRow["Identifier"].ToString());
                ViewState["Identifier"]=utRow["Identifier"].ToString();
            }  
        }
    }
    protected void Retrieve_UserEmail(String vIdentifier)
    {
        ds = objEbook.Retrieve_UserEmailInfo(vIdentifier);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];

            String tEmail = utRow["Email"].ToString();
            String tEmailStatus = utRow["EmailStatus1"].ToString();

            String tNewEmail = utRow["NewEmail"].ToString();
            String tNewEmailStatus = utRow["NewEmailStatus1"].ToString();

            String tVerifiedEmailStatus = utRow["VerifiedEmailStatus"].ToString();
                     
            if ((tEmail == "") || (tEmail == null))
            {
                trCurrentEmail.Visible = false;
                tNewEmail = "-";
                tNewEmailStatus = "<font color='red'>Please update your email address.</font>";
            }

            if ((tVerifiedEmailStatus == "0") || (tNewEmail == null))
            {
                trNewEmail.Visible = false;
            }
          

            lblCurrentEmail.Text = tEmail;
            lblCurrentEmailStatus.Text = tEmailStatus;
            lblNewEmail.Text = tNewEmail;
            lblNewEmailStatus.Text = tNewEmailStatus;
           
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        String tEmail = TextBox_Email.Text;

        if (tEmail.Contains("@") == true)
        {
            int tmpStatus = objEbook.InsertUpdate_UserEmailInfo(ViewState["Identifier"].ToString(), tEmail);
            String msgAlert = String.Empty;

            if ((tmpStatus == 1) || (tmpStatus == 3))
            {
                msgAlert = "Your New Email Address is updated.\\nYour new Email will be activated upon your existing email only if your email is verified ";
                GetUserInfoandSendEmail(ViewState["Identifier"].ToString(), "CHANGED", msgAlert);
            }
            else if ((tmpStatus == 2) || (tmpStatus == 4))
            {
                msgAlert = "Kindly verify your email address!";
                GetUserInfoandSendEmail(ViewState["Identifier"].ToString(), "CHANGED", msgAlert);
            }
            else
            {
                msgAlert = "Technical Error.Please try again later!";
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
    }
    protected void GetUserInfoandSendEmail(String vIdentifier, String vEmailType, String vMsgAlert)
    {
        ds = objEbook.Retrieve_UserProfileInfo(vIdentifier);

        if (ds.Tables[1].Rows.Count > 0)
        {
            DataRow utRow1 = ds.Tables[1].Rows[0];

            String MobileUsrName = utRow1["MemberName"].ToString();
            String MobileNo = utRow1["Mobile"].ToString();
            String CurrentEmail = utRow1["Email"].ToString();

            //String strNote = "";
            String strMsg1 = "You recently entered a new contact email address.<br/>Kindly verify your email information is valid.";
            String strMsg2 = "Once done,confirm your new email address, by clicking the link below :-<br>";
            strMsg2 = strMsg2 + "<h3><a class='txtBlueMedium' href=" + tmp_EmailVerifyValidateLink + " target='_blank'>Click here for Email Verification</a></h3>";
            strMsg2 = strMsg2 + "<br><br>";
            strMsg2 = strMsg2 + "In case, if you are unable to click on the above link please copy and paste the following URL in your browser. &nbsp;";
            strMsg2 = strMsg2 + "<font class='txtBlueMedium'>" + tmp_EmailVerifyValidateLink + "</font>";

            String Contact_EmailBody = @"

                    <style type='text/css'>
                    .style2        {            height: 18px;        }
                    .font_12BlueBold	{ FONT-SIZE: 12px;  font-weight:bold; COLOR: #2291A1; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
                    .font_12Normal		{ FONT-SIZE: 12px; COLOR: #03C0C6; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
                    .stdtableBorder_Main		{ background-color:#FAFCFA; border: #CDF2D6 1px solid; FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
                    .stdtableBorder_Search		{ background-color:#F7F9E5; BORDER-BOTTOM: #b8e0fb 1px solid; BORDER-TOP: #b8e0fb 1px solid; width:98%;
                      		                       FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
                    .SearchLabelBold        {height:25px; FONT-SIZE: 12px; COLOR: #221F0B; padding-left:10px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif; font-weight:bold;}
                    .SearchLabel            {height:25px; text-align:left; FONT-SIZE: 12px; COLOR: #44412F; padding-left:5px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif;}

                    .bkgFooter		    {background-color:#D0EBBF;}

                    .std_table_Email{border:1px solid #D4E594;background-color:#fff;padding-left:10px;padding-right:10px;line-height:23px;}
                    .std_table_Email_Row{border-bottom:1px solid #D4E594;font-family:Arial;font-weight:bold;font-size:11px;line-height:18px;background-color:#f1f0f0}
                    .txtBlueMedium{font-family:Arial;font-size:12px;color:#0066FF;text-decoration:none;}

                    </style> ";

            Contact_EmailBody = Contact_EmailBody + @"<br><br> " +


            "<div><table border='0' cellpadding='5' cellspacing='1' width='100%' class='std_table_Email'>" +
            "<tr><td class='txtBlackMedium' colspan='2'>Hi, <b>" + MobileUsrName + "</b></td></tr>" +
            "<tr><td colspan='2' class='txtBlackMedium'>" + strMsg1 + "</td></tr>" +
            "<tr><td colspan='2'>&nbsp;</td></tr>" +
            "<tr><td class='std_table_Email_Row'>New Email Address</td><td class='std_table_Email_Row'> : <span class='txtBlueMedium'><b>" + CurrentEmail + "</span></td></tr>" +

            "<tr><td class='std_table_Email_Row'>Contact Number</td><td class='std_table_Email_Row'> : " + MobileNo + "</td></tr>" +
                //"<tr><td class='std_table_Email_Row' colspan='2'>&nbsp;</td></tr>" +

            "<tr><td colspan='2' class='txtBlackMedium'>" + strMsg2 + "</td></tr>" +
            "<tr><td colspan='2' class='txtBlackMedium'>From ,</td></tr>" +
            "<tr><td colspan='2' class='txtBlackMedium'><b>The " + tmp_WebSiteName + " Support Team.</b></td></tr>" +
                //<tr><td colspan='2' class='txtBlackMedium'><img src='../" + Hitech_Constants.tmp_WebSiteLogo + "'/></td></tr>" +  
            "</table></div>" +
            "<br><br>";
        
            //MyMail.Send_EmailGeneric(MobileUsrName, CurrentEmail, tmp_WebSiteName + " - Email confirmation", Contact_EmailBody);

            #region sending Email using HmailServer.

           // hMailServer.Application objApp_Hmail = new hMailServer.Application();

           // hMailServer.Message objMsg_Hmail = new hMailServer.Message();

           // objMsg_Hmail.AddRecipient("", CurrentEmail);

           // objMsg_Hmail.From = "admin@worlddigitalbiz.com";
           // objMsg_Hmail.FromAddress = "admin@worlddigitalbiz.com";

           // objMsg_Hmail.Subject = tmp_WebSiteName + " - Email confirmation";
           // objMsg_Hmail.HTMLBody = Contact_EmailBody;

           //objMsg_Hmail.Save();
            //CommonFunctions.AlertMessage("Email has been Sent");
           #endregion




           #region Sending mail using SmarterMail

           String vEmailToName = CurrentEmail;
           String vEmailToAddress = CurrentEmail;

           //String vEmailFromName = "EBookAdmin";
           String VEmailFromAddress = "noreply@ebooksmsdelivery.com";

           String vEmailSubject = tmp_WebSiteName + " - Email confirmation"; 



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



               String tmpEbooks = String.Empty;
               String tmpEbfileFolder = "../" + ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
               //... Get the List of Books to be Attached. 



               String sHtmlBody = Contact_EmailBody;


               //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
               NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
               smtpClient.UseDefaultCredentials = false;
               smtpClient.Credentials = authinfo;

               // Send SMTP mail
               smtpClient.Send(objMessage);


               CommonFunctions.AlertMessage("Email has been Sent");



           }
           catch (Exception ex)
           {
               throw ex;

           }

           #endregion

           CommonFunctions.AlertMessageAndRedirect(vMsgAlert,@"EbAd_EmailVerification.aspx");

        }
    }
}
