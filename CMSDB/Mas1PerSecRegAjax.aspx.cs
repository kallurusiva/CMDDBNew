using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Mas1PerSecRegAjax : System.Web.UI.Page
{

    CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
    string CountryCode = string.Empty;
    //string strMasRegPassword;
    //string strMobileLoginID;
    //string strCountryPrefix;
    string strRegPageFrom = string.Empty;
    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

    protected void Page_Load(object sender, EventArgs e)
    {

     

        //txtMobileNo.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        //txtSubDomainName.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");


        txtPerSecPIN.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");
        txtPerSecUserID.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");

        

       // DdlCountry.Attributes.Add("onchange", "javascript:return ChangeMobileText(event)");

        btnRegister.Enabled = true;
        lblMasUserMessage.Text = "Please fill in all the details below to complete the registration";

        if (!IsPostBack)
        {
            //LoadMasUserDetails();
           // LoadCategories();
        }

    }



    public void fnSendEmail()
    {

        SmtpClient smtpClient = new SmtpClient();
        MailMessage objMessage = new MailMessage();

        try
        {

            MailAddress m_fromAddress = new MailAddress("kallurusiva@gmail.com", "EBookAdmin");
            // You can specify the host name or ipaddress of your server

            // Default in IIS will be localhost 
            smtpClient.Host = "localhost";

            //Default port will be 25
            smtpClient.Port = 25;

            //From address will be given as a MailAddress Object
            objMessage.From = m_fromAddress;

            // To address collection of MailAddress

            objMessage.To.Add(ViewState["Email"].ToString());
            objMessage.Subject = "Registration details at " + GlobalVar.GetAnchorDomainName; 
            
            // CC and BCC optional

            // MailAddressCollection class is used to send the email to various users

            // You can specify Address as new MailAddress("admin1@yoursite.com")

            //objMessage.CC.Add("admin1@yoursite.com");
            //objMessage.CC.Add("admin2@yoursite.com");

            // You can specify Address directly as string

            //objMessage.Bcc.Add(new MailAddress("admin3@yoursite.com"));
            //objMessage.Bcc.Add(new MailAddress("admin4@yoursite.com"));

            //Body can be Html or text format

            //Specify true if it  is html message

            objMessage.IsBodyHtml = true;
            // Message body content
            string m_MessageBody = "Your Registration at " + GlobalVar.GetAnchorDomainName + " is successful";
            objMessage.Body = m_MessageBody;

            // Send SMTP mail

            smtpClient.Send(objMessage);

            // lblStatus.Text = "Email successfully sent.";




        }
        catch
        {

        }


    }



 protected void btnRegister_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid)
            return;

        btnRegister.Enabled = false;

       // return;
        
        //CMSv3.Entities.webDomain objWebDomain = new CMSv3.Entities.webDomain();
        CMSv3.Entities.webDomain objWebDomain = new CMSv3.Entities.webDomain(); 
     
        CMSv3.BAL.MalaysiaSMS objBAL_MasUser = new CMSv3.BAL.MalaysiaSMS(); 


        //acquiring entered Values;

        #region  // gathering values 
    
            //... UserID and PIN Details
        string PerSec_UserID = txtPerSecUserID.Text;
        string PerSec_Password = txtPerSecPwd.Text;
        string PerSec_PinNumber = txtPerSecPIN.Text;


        #endregion  // end of gathering values; 
        
       ////fnLogintoWebPortal(smeUserID, smePassword);

        //.. Pass smeUserID and smePinNumber to Siva's Page to Get the Reponse. 

        int PSRegStatus = 0;
        string tmpResponse = string.Empty;

        //..First Check UserID, Pin Validation 
        int PerSecPreCheck = -1;
        PerSecPreCheck = objBAL_MasUser.PS_CheckUseridPin_Status(PerSec_UserID, PerSec_PinNumber);
        //[usp_PS_CheckLoginPinStatusPerSec_Password
        ////PerSecPreCheck = -99;


        if (PerSecPreCheck != 0)
        {
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

            switch (PerSecPreCheck)
            {
                case 1: lblErrMessage.Text = "Entered UserID Already exists. Please re-enter again."; break;
                case 2: lblErrMessage.Text = "Entered Pin Number already in use. Please check and try again."; break;
                case 3: lblErrMessage.Text = "Entered Pin Number already . Please check and try again."; break;
                //default: break;
            }
            btnRegister.Enabled = true;
        }
        else
        {

            #region // Sending Request for PinNo Validation to Another Server, Which returns the status as 0, 1 or 2


            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "smeUSERID=" + PerSec_UserID;
            postData += ("&smePassword=" + PerSec_Password);
            postData += ("&smePIN=" + PerSec_PinNumber);
            postData += ("&smeFullName=" + txtPerSecFullName.Text.Trim());
            postData += ("&smeMobile=" + txtPerSecMobile.Text.Trim());
            
            //string postData = "PIN=" + smePinNumber;
            //postData += ("&Mobile=" + smePassword);

            byte[] data = encoding.GetBytes(postData);

            // Prepare web request...
            //HttpWebRequest http_pinRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/AdminX/webSMEStatus.asp");
            HttpWebRequest http_pinRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/offline/PSreg.asp");

            //http://64.78.18.32/mlmsms/offline/PSreg.asp?smeUSERID=abc&smePassword=123456&smePIN=1234567890&smeFullName=abc&smeMobile=60126583065


            http_pinRequest.Method = "POST";
            http_pinRequest.ContentType = "application/x-www-form-urlencoded";
            http_pinRequest.ContentLength = data.Length;
            Stream newStream = http_pinRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();


            try
            {

                // *** Retrieve request info headers
                HttpWebResponse http_pinResponse = (HttpWebResponse)http_pinRequest.GetResponse();
                Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page
                StreamReader loResponseStream = new StreamReader(http_pinResponse.GetResponseStream(), enc);
                string Html_PinResponse = loResponseStream.ReadToEnd();
                http_pinResponse.Close();
                loResponseStream.Close();

                string[] pinResponseArray = Html_PinResponse.Split(',');

                PSRegStatus = Convert.ToInt16(pinResponseArray[0]);
                //smeMobileNumber = pinResponseArray[1];
                //string pinBuyCode = pinResponseArray[2];


            }
            catch (Exception ex)
            {
                if (ex is WebException && ((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                {
                    StringBuilder errSB = new StringBuilder();
                    WebResponse errResp = ((WebException)ex).Response;
                    // using(Stream respStream = errResp.GetResponseStream())
                    using (StreamReader exReader = new StreamReader(errResp.GetResponseStream()))
                    {
                        // read the error response
                        string line;
                        while ((line = exReader.ReadLine()) != null)
                        {
                            errSB.AppendLine(line);
                        }

                    }

                    string tempError = errSB.ToString();
                    lblErrMessage.CssClass = "font_12Msg_Error";
                    tblMessageBar.Visible = true;
                    MessageImage.Src = "~/Images/inf_Error.gif";
                    lblErrMessage.Text = "Registration failed. Please contact administrator.<br/>" + tempError;
                    btnRegister.Enabled = true;
                }
            }



            PSRegStatus = 1;


            #endregion

            if (PSRegStatus != 1)
            {
                lblErrMessage.CssClass = "font_12Msg_Error";
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";

                switch (PSRegStatus)
                {
                        //2 - Blank Login not valid
                        //3 - Blank Password not valid
                        //4 - Blank Pin not valid
                        //5 - Blank Full Name not valid
                        //6 - Pin does not exists.
                        //7 - Pin is in usage
                        //8 - Login is not available.

                    case 2: lblErrMessage.Text = "UserID / Login cannot be blank."; break;
                    case 3: lblErrMessage.Text = "Password cannot be blank."; break;
                    case 4: lblErrMessage.Text = "PinNumber cannot be blank."; break;
                    case 5: lblErrMessage.Text = "Full Name cannot be blank"; break;
                    case 6: lblErrMessage.Text = "Entered PinNumber has could be validated. Please check and try again."; break;
                    case 7: lblErrMessage.Text = "Entered PinNumber has been already activated. Please check and try again."; break;
                    case 8: lblErrMessage.Text = "Entered LoginID/UserID Already exists. Please re-enter again."; break;
                    //default: break;
                }
                btnRegister.Enabled = true;
            }
            else
            {
                //.. Directly to Logging to SMS System.

                #region ... SubDomain Registration

                               
                    //.. Directing to SMS System Login 

                    //string mUserName = "60149664566";
                    //string mPassword = "27272727";
                    
                    string mUserName = PerSec_UserID;
                    string mPassword = PerSec_Password; 

                    //string strReferringURL = "";


                    //fnLogintoSMSsystem("60149664566", "552255");
                    fnLogintoSMSsystem(mUserName, mPassword);

                    //fnLogintoWebPortal(mUserName, mPassword);

                    #region Directing to SMSsystem Login
                    
                        //string strURL = string.Empty;
                        //string mMobileNumber = txtMobileNo.Text;

                        //int UsrCountryCode = Convert.ToInt32(mMobileNumber.Substring(0, 2));
                        //string tmpForBruneiPrefix2 = mMobileNumber.Substring(0, 3);
                        //if (tmpForBruneiPrefix2 == "673")
                        //    UsrCountryCode = 673;

                        //if (UsrCountryCode == 66)
                        //    UsrCountryCode = 60;


                        //switch (UsrCountryCode.ToString())
                        //{

                        //    case "60":  /* Malaysia  */ strURL = "http://64.78.18.147/Hitech/Includes/1SmsWebsite_MAS_BizLoginCheck_Hitech.asp"; break;
                        //    case "65":  /* Singapore */ strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck_NEW.asp"; break;
                        //    case "673": /* Brunei    */ strURL = "http://64.78.18.147/Hitech/Includes/SmsSystemLogin_Brunei.asp"; break;

                        //}
                        //Page.SmartNavigation = false;


                        //HttpContext.Current.Response.Clear();
                        //StringBuilder sb = new StringBuilder();
                        //sb.Append("<html>");
                        //sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                        //sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
                        //sb.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", mUserName);
                        //sb.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", mPassword);
                        //sb.AppendFormat("<input type='hidden' name='MLoginFrom' value='{0}'>", "SMSLOGIN");
                        //sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
                        //// Other params go here
                        //sb.Append("</form>");
                        //sb.Append("</body>");
                        //sb.Append("</html>");

                        //HttpContext.Current.Response.Write(sb.ToString());
                        ////HttpContext.Current.Response.End();
                        //HttpContext.Current.ApplicationInstance.CompleteRequest();

                    #endregion //end of directing to smsSystem login


                //}

                #endregion  //..end of sub-domain reg.

            } //.end of smsRegStatus

        }


            

    }

 protected void fnSendEmailHTML(string vEmail, string VmobileNo , string vFullName, string vDomainName, string vDomainPassword)
{

    string DomainURL = "www." + vDomainName + ".1worldsms.com";

    string tmpWebSiteName = GlobalVar.GetAnchorDomainName;

     string tmpHtmlBody = @"
     <html xmlns='http://www.w3.org/1999/xhtml'>
<head >
    <title></title>
    <style type='text/css'>
        .style2        {            height: 18px;        }
        .SearchLabelBold        {height:25px; FONT-SIZE: 12px; COLOR: #221F0B; padding-left:10px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif; font-weight:bold;}
        .SearchLabel            {height:25px; FONT-SIZE: 12px; COLOR: #44412F; padding-left:2px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif;}
        .stdtableBorder_Search		{ background-color:#F7F9E5; BORDER-BOTTOM: #b8e0fb 1px solid; BORDER-TOP: #b8e0fb 1px solid; width:98%;
                              		   FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: 'Lucida Console', Arial,Verdana, Helvetica, sans-serif;}
        .font_12BlueBold	{ FONT-SIZE: 12px;  font-weight:bold; COLOR: #2291A1; height:25px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .subHeaderFontGrad  	{font: bold 120%/100% 'Trebuchet MS','Lucida Console', Arial, sans-serif;	position: relative;	margin: 30px 0 50px; vertical-align:middle;	color: #687367; font-style:italic;}
        .stdtableBorder_Main		{ background-color:#F6F7F6; border: #CDF2D6 1px solid; FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
        .bkgNewsBoxOren		    {background-color:#F3D651;}
        .font_12Normal		{ FONT-SIZE: 12px; COLOR: #03C0C6; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
    </style>
</head>
<body>
    <div>
        <table cellpadding='0' cellspacing='0' align='center' width='80%' class='stdtableBorder_Main'>
            <tr class='bkgNewsBoxOren subHeaderFontGrad'>
                <td class='style2' style='height: 40px;' align='center'>" + tmpWebSiteName + @"</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Dear <font class='font_12BlueBold'>" +  vFullName + @" </font>,</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Greetings from " + tmpWebSiteName + @"</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    You have recently registered <b> " + DomainURL + @"</b> using this email address.<br />
&nbsp;we are delighted to have 
                    you as a registered user. </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class='font_12Normal'>
                    Please find your login information below.</td>
            </tr>
            <tr>
                <td align='center'>
                    <table cellpadding='0' cellspacing='0' width='80%' class='stdtableBorder_Search' >
                        <tr>
                            <td width='40%' class='SearchLabelBold'>
                                Admin Login</td>
                            <td width='60%' align='left' class='SearchLabel'>
                                " + vDomainName + @"</td>
                        </tr>
                        <tr>
                            <td  class='SearchLabelBold'>
                                Admin Password</td>
                            <td align='left' class='SearchLabel'>
                                " + vDomainPassword + @"</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td  class='SearchLabelBold'>
                                Registered Mobile</td>
                            <td align='left' class='SearchLabel'>
                                " + VmobileNo + @"</td>
                        </tr>
                        <tr>
                            <td class='SearchLabelBold'>
                                Registered Name
                            </td>
                            <td align='left' class='SearchLabel'>
                                " + vFullName + @"</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Click here to open your registered website :&nbsp; <a href='#'>" + DomainURL + @"</a></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Regards,</td>
            </tr>
            <tr>
                <td>
                    Support Team, </td>
            </tr>
            <tr>
                <td>
                    "+ tmpWebSiteName + @"</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>NOTE</b>:&nbsp; This is a system generated email. Please do not reply this email.</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</body>
</html>";


     string frmEmailAddress = "supportTeam@" + tmpWebSiteName + ".com";

     SmtpClient smtpClient = new SmtpClient();
     MailMessage objMessage = new MailMessage();

     try
     {

         MailAddress m_fromAddress = new MailAddress(frmEmailAddress, "EBookAdmin");
         // You can specify the host name or ipaddress of your server

         // Default in IIS will be localhost 
         //smtpClient.Host = "localhost";
         smtpClient.Host = "127.0.0.1";

         //Default port will be 25
         smtpClient.Port = 25;

         //From address will be given as a MailAddress Object
         objMessage.From = m_fromAddress;

         // To address collection of MailAddress

         objMessage.To.Add(vEmail);
         objMessage.Subject = tmpWebSiteName + " - Registration Details";

         // CC and BCC optional

         // MailAddressCollection class is used to send the email to various users

         // You can specify Address as new MailAddress("admin1@yoursite.com")

         //objMessage.CC.Add("admin1@yoursite.com");
         //objMessage.CC.Add("admin2@yoursite.com");

         // You can specify Address directly as string

         //objMessage.Bcc.Add(new MailAddress("admin3@yoursite.com"));
         //objMessage.Bcc.Add(new MailAddress("admin4@yoursite.com"));

         objMessage.Bcc.Add("srihari@globalsurf.com.my");
         //objMessage.Bcc.Add("msri_hari@hotmail.com");
         objMessage.Bcc.Add("samvoon@gmail.com");

         //Body can be Html or text format

         //Specify true if it  is html message

         objMessage.IsBodyHtml = true;
         // Message body content
         //string m_MessageBody = "Your Registration at SMSentreprenuer.com is successful";
         objMessage.Body = tmpHtmlBody;

         // Send SMTP mail
         smtpClient.Send(objMessage);

         // lblStatus.Text = "Email successfully sent.";




     }
     catch
     {

     }



}


 protected void fnLogintoWebPortal(string vUserName, string vPassword)
 {

     string mUserName = vUserName;
     string mPassword = vPassword;
     string mReturnedMobileNo = string.Empty;

     int UsrCountryCode = 0;
     String tmpUserPrefix = mUserName.Substring(0, 2);
     string tmpForBruneiPrefix = mUserName.Substring(0, 3);
     if (tmpForBruneiPrefix == "673")
         tmpUserPrefix = "673";


     if (IsNumeric(tmpUserPrefix))
     {
         UsrCountryCode = Convert.ToInt32(tmpUserPrefix);
     }
     else
     {
         //..Check if the Login is Valid in the SpecialLogin Table. 

         SqlConnection IFM_dbConn;
         SqlCommand IFM_dbCmd;


         IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);
         IFM_dbConn.Open();

         IFM_dbCmd = new SqlCommand("[USP_Verify_SpecialLoginNameCMS]", IFM_dbConn);
         IFM_dbCmd.CommandType = CommandType.StoredProcedure;
         IFM_dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = mUserName;
         //IFM_dbCmd.Parameters.Add("@vResult", SqlDbType.VarChar).Size = 20;
         //IFM_dbCmd.Parameters.Add("@vResult", SqlDbType.VarChar).Direction = ParameterDirection.Output;



         //int status = IFM_dbCmd.ExecuteScalar

         //mReturnedMobileNo = (string)IFM_dbCmd.Parameters["@Result"].Value;

         mReturnedMobileNo = IFM_dbCmd.ExecuteScalar().ToString();

         if (mReturnedMobileNo == "00")
         {
             UsrCountryCode = 0;
         }
         else
         {
             UsrCountryCode = Convert.ToInt32(mReturnedMobileNo.Substring(0, 2));
             string tmpForBruneiPrefix2 = mReturnedMobileNo.Substring(0, 3);
             if (tmpForBruneiPrefix2 == "673")
                 UsrCountryCode = 673;

             mUserName = mReturnedMobileNo;
         }
     }



     if (UsrCountryCode == 66)
         UsrCountryCode = 60;


         //.. Before Redirecting Check if the User has registered a SubDomain. if NOT prompt message. 

         CMSv3.BAL.User objUser = new CMSv3.BAL.User();

         DataSet dsCheck;
         string strSQL = string.Empty;
         DataTable dtUserRecord = new DataTable();
         DataTable dtUserStatus = new DataTable();

         dsCheck = objUser.CheckUser_ValidateByMobileLogin(CommonFunctions.SafeSql(mUserName));

         if (dsCheck.Tables.Count == 2)
         {
             dtUserStatus = dsCheck.Tables[0];
             dtUserRecord = dsCheck.Tables[1];
         }
         else
         {
             dtUserStatus = dsCheck.Tables[0];
         }

         DataRow UserStatus_Row = dtUserStatus.Rows[0];
         string UserStatus_Value = UserStatus_Row["userStatus"].ToString();


         if (UserStatus_Value == "MATCHED")
         {
             DataRow UserRecord_Row = dtUserRecord.Rows[0];

             Session["UserID"] = UserRecord_Row["UserID"].ToString();
             Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
             Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
             Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
             Session["LoggedInFrom"] = "SMSSYSTEM_WPY";
             CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
             Response.Redirect("~/Admin/Ad_Welcome.aspx");
         }
         else
         {
             CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
         }


    



 }



 protected void fnLogintoSMSsystem(string vUserName, string vPassword)
 {

     string mUserName = vUserName;
     string mPassword = vPassword;
     string mMID = string.Empty;

     SqlConnection IFM_dbConn;
     SqlCommand IFM_dbCmd;

     String IFM_ConnString = ConfigurationManager.AppSettings["IFMdb"].ToString();
     IFM_dbConn = new SqlConnection(IFM_ConnString);
     IFM_dbConn.Open();

     IFM_dbCmd = new SqlCommand("[USP_ValidateLogin_SMSSystem]", IFM_dbConn);
     IFM_dbCmd.CommandType = CommandType.StoredProcedure;
     IFM_dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = mUserName;
     IFM_dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = mPassword;

     mMID = IFM_dbCmd.ExecuteScalar().ToString();


     if (mMID == "0")
     {
         // invalid login 
         lblErrMessage.Text = "Invalid Password ...";

     }
     else
     {

         string strURL = "http://183.81.165.110/WebApps/hitechsms/ValidateUserLogin_FromMyHitech.aspx";

         HttpContext.Current.Response.Clear();
         StringBuilder sb = new StringBuilder();
         sb.Append("<html>");
         sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
         sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
         sb.AppendFormat("<input type='hidden' name='tmpMID' value='{0}'>", mMID);
         sb.AppendFormat("<input type='hidden' name='tmpUsrType' value='{0}'>", 1);
         sb.AppendFormat("<input type='hidden' name='tmpLoginFrom' value='{0}'>", "PSLOGIN");
         //sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
         // Other params go here
         sb.Append("</form>");
         sb.Append("</body>");
         sb.Append("</html>");

         HttpContext.Current.Response.Write(sb.ToString());
         //HttpContext.Current.Response.End();
         HttpContext.Current.ApplicationInstance.CompleteRequest();


     }

 }


 protected void fnLogintoSMSsystem22(string vUserName, string vPassword)
 {

        string mUserName = vUserName;
        string mPassword = vPassword;
        string mReturnedMobileNo = string.Empty;

        int UsrCountryCode = 0;
        String tmpUserPrefix = mUserName.Substring(0, 2);
        string tmpForBruneiPrefix = mUserName.Substring(0, 3);
        if (tmpForBruneiPrefix == "673")
            tmpUserPrefix = "673";


        if (IsNumeric(tmpUserPrefix))
        {
            UsrCountryCode = Convert.ToInt32(tmpUserPrefix);
        }
        else
        {
            //..Check if the Login is Valid in the SpecialLogin Table. 

            SqlConnection IFM_dbConn;
            SqlCommand IFM_dbCmd;


            IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);
            IFM_dbConn.Open();

            IFM_dbCmd = new SqlCommand("[USP_Verify_SpecialLoginNameCMS]", IFM_dbConn);
            IFM_dbCmd.CommandType = CommandType.StoredProcedure;
            IFM_dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = mUserName;
            //IFM_dbCmd.Parameters.Add("@vResult", SqlDbType.VarChar).Size = 20;
            //IFM_dbCmd.Parameters.Add("@vResult", SqlDbType.VarChar).Direction = ParameterDirection.Output;



            //int status = IFM_dbCmd.ExecuteScalar

            //mReturnedMobileNo = (string)IFM_dbCmd.Parameters["@Result"].Value;

            mReturnedMobileNo = IFM_dbCmd.ExecuteScalar().ToString();

            if (mReturnedMobileNo == "00")
            {
                UsrCountryCode = 0;
            }
            else
            {
                UsrCountryCode = Convert.ToInt32(mReturnedMobileNo.Substring(0, 2));
                string tmpForBruneiPrefix2 = mReturnedMobileNo.Substring(0, 3);
                if (tmpForBruneiPrefix2 == "673")
                    UsrCountryCode = 673;

                mUserName = mReturnedMobileNo;
            }
        }


        //String tmpUserPrefix = mUserName.Substring(0, 2);
        //string tmpForBruneiPrefix = mUserName.Substring(0, 3);
        //if (tmpForBruneiPrefix == "673")
        //    tmpUserPrefix = "673";
        //int tmpCountryCode = Convert.ToInt32(tmpUserPrefix);

        if (UsrCountryCode == 66)
            UsrCountryCode = 60;

       string strURL = string.Empty;

       switch (UsrCountryCode.ToString())
        {

            case "60":  /* Malaysia  */ strURL = "http://64.78.18.147/Hitech/Includes/1SmsWebsite_MAS_BizLoginCheck_Hitech.asp"; break;
            case "65":  /* Singapore */ strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck_NEW.asp"; break;
            case "673": /* Brunei    */ strURL = "http://64.78.18.147/Hitech/Includes/SmsSystemLogin_Brunei.asp"; break;

        }
        //Page.SmartNavigation = false;


        String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
        strReferringURL = strReferringURL.Replace("http://", "");
        int GetFirstSlashidx = strReferringURL.IndexOf(@":");
        if (GetFirstSlashidx > 0)
            strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx); 

     

        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();
        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
        sb.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", mUserName);
        sb.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", mPassword);
        sb.AppendFormat("<input type='hidden' name='MLoginFrom' value='{0}'>", "PSLOGIN");
        sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
        // Other params go here
        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();



 }

 protected void txtPerSecUserID_TextChanged(object sender, EventArgs e)
 {
     
     int smeUserIDCheck = -1;

     CMSv3.BAL.MalaysiaSMS objMAS_User = new CMSv3.BAL.MalaysiaSMS();

     smeUserIDCheck = objMAS_User.CheckSME_UserID(txtPerSecUserID.Text);

     if (smeUserIDCheck == 0)
     {
         dvUserAvailability.InnerText = " UserID available";
         dvUserAvailability.Attributes.Add("class", "valid");
     }
     else
     {
         dvUserAvailability.InnerText = "UserID already taken";
         dvUserAvailability.Attributes.Add("class", "invalid");
     }


 }

 protected void txtPerSecPIN_TextChanged(object sender, EventArgs e)
 {
     int PsPinNumberCheck = -1;
     
     CMSv3.BAL.MalaysiaSMS objMAS_User = new CMSv3.BAL.MalaysiaSMS();

     PsPinNumberCheck = objMAS_User.CheckPS_PinNumber(txtPerSecPIN.Text);

     switch (PsPinNumberCheck)
     {

         case 1: dvPinNumberCheck.InnerText = "Entered PinNumber was validated successfully.";
                dvPinNumberCheck.Attributes.Add("class", "valid");
                break;

         case 2: dvPinNumberCheck.InnerText = "Entered PinNumber is inValid";
                dvPinNumberCheck.Attributes.Add("class", "invalid");
                break;

         case 3: dvPinNumberCheck.InnerText = "Entered PinNumber has been used already.";
                dvPinNumberCheck.Attributes.Add("class", "invalid");
                break;

     }


     //if (PsPinNumberCheck == 0)
     //{
     //    dvPinNumberCheck.InnerText = "Entered PinNumber was validated successfully.";
     //    dvPinNumberCheck.Attributes.Add("class", "valid");
     //}
     //else
     //{
     //    dvPinNumberCheck.InnerText = "Entered PinNumber could not be Validated. Please Check!!!";
     //    dvPinNumberCheck.Attributes.Add("class", "invalid");
         
     //}
 }


 public static Boolean IsNumeric(string stringToTest)
 {
     int result;
     return int.TryParse(stringToTest, out result);
 }

}

