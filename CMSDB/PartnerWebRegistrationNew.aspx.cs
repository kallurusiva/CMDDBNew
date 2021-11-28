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

public partial class PartnerWebRegistrationNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //... Get the URL and check if it contains a Numeric subDomain. 

        String OrgURL = Request.Url.OriginalString;
       // OrgURL = "http://60193312455.1carwebsite.com"; 
        string tmpMainURL = OrgURL; 
        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://
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


        if (CheckIsNumeric(userSubDomainName))
        {
           // Response.Write("Check mas user .... ");
            //check if the User is from/a 1MalaysiaSMS user. 
            CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
            CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();

            CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

            int newUserID = objBAL_User.GetUserID_BySubDomainName(userSubDomainName);
            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(userSubDomainName, ref objMasUser);

            Session["MasUSER"] = objMasUser;
            

            //.................................................................

            if ((objMasUser.MID != "NONE") && (newUserID != 0))
            {
                Response.Redirect("Mas1UserWebRegistration.aspx");
            }
        }

        //int newUserID = 0;
        //CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

        //newUserID = objBAL_User.GetUserID_BySubDomainName(userSubDomainName);





           


       




        #region -- Rendering Top Left Panel --
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

        dvBannerLeftPanel.InnerHtml = sb.ToString();
        #endregion


        //txtMobileNo.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        //txtSubDomainName.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");
        //DdlCountry.Attributes.Add("onchange", "javascript:return ChangeMobileText(event)");

        Page.MaintainScrollPositionOnPostBack = true;

    }

    
    //protected void txtSubDomainName_TextChanged(object sender, EventArgs e)
    //{

    //    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
    //    //Check if the subDomain already exists.
    //    if (txtSubDomainName.Text != "")
    //    {
    //        bool isSubDomainExists = objBAL_User.CheckSubDomainExists(txtSubDomainName.Text);
    //        tr_ShowDomainError.Visible = true;
    //        if (isSubDomainExists)
    //        {
    //            dv_ShowSbError.InnerHtml = "<img src='Images/inf_Error.gif' />&nbsp;<font class='font_11Msg_Error'>Entered SubDomain already taken. Please try another.</font>";
    //        }
    //        else
    //        {
    //            dv_ShowSbError.InnerHtml = "<img src='Images/inf_Sucess.gif' />&nbsp;<font class='font_11Msg_Success'>Entered SubDomain is available.</font>";
    //        }

    //    }

    //    txtPassword.Focus();


    //}


    public static bool CheckIsNumeric(string input)
    {
        if (input != null)
        {
            double output;
            return Double.TryParse(Convert.ToString(input), out output);
        }
        else
        {
            return false;
        }
    }




    //public void fnSendEmail()
    //{

    //    SmtpClient smtpClient = new SmtpClient();
    //    MailMessage objMessage = new MailMessage();

    //    try
    //    {

    //        MailAddress m_fromAddress = new MailAddress("msri_hari@yahoo.com", "ADMINISTRATOR");
    //        // You can specify the host name or ipaddress of your server

    //        // Default in IIS will be localhost 
    //        smtpClient.Host = "localhost";

    //        //Default port will be 25
    //        smtpClient.Port = 25;

    //        //From address will be given as a MailAddress Object
    //        objMessage.From = m_fromAddress;

    //        // To address collection of MailAddress

    //        objMessage.To.Add(txtEmail.Text);
    //        objMessage.Subject = "Registration details at SMSEntreprenuer.com";

    //        // CC and BCC optional

    //        // MailAddressCollection class is used to send the email to various users

    //        // You can specify Address as new MailAddress("admin1@yoursite.com")

    //        //objMessage.CC.Add("admin1@yoursite.com");
    //        //objMessage.CC.Add("admin2@yoursite.com");

    //        // You can specify Address directly as string

    //        //objMessage.Bcc.Add(new MailAddress("admin3@yoursite.com"));
    //        //objMessage.Bcc.Add(new MailAddress("admin4@yoursite.com"));

    //        //Body can be Html or text format

    //        //Specify true if it  is html message

    //        objMessage.IsBodyHtml = true;
    //        // Message body content
    //        string m_MessageBody = "Your Registration at SMSentreprenuer.com is successful";
    //        objMessage.Body = m_MessageBody;

    //        // Send SMTP mail

    //        smtpClient.Send(objMessage);

    //        // lblStatus.Text = "Email successfully sent.";




    //    }
    //    catch
    //    {

    //    }


    //}



    //protected void btnRegister_Click(object sender, EventArgs e)
    //{

    //    CMSv3.Entities.webDomain objWebDomain = new CMSv3.Entities.webDomain();
    //    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

    //    //acquiring entered Values;
    //    objWebDomain.PinNo = txtPinNo.Text;
    //    objWebDomain.DomainName = txtSubDomainName.Text;
    //    objWebDomain.DomainPassword = txtPassword.Text;
    //    objWebDomain.FullName = txtName.Text;
    //    objWebDomain.Email = txtEmail.Text;
    //    objWebDomain.MobileNo = txtMobileNo.Text;
    //    objWebDomain.CountryCode = Convert.ToInt16(DdlCountry.SelectedValue);
    //    objWebDomain.LanguageCode = Convert.ToInt16(rdolstLanguage.SelectedValue);


    //    bool isSubDomainExists = objBAL_User.CheckSubDomainExists(txtSubDomainName.Text);

    //    if (isSubDomainExists)
    //    {
    //        lblErrMessage.Text = "Entered Domain Already exists. Please check and re-enter again.";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";

    //    }
    //    else{


    //    //---- Checking for the Valid PIN from Another SERVER------------
    //    ASCIIEncoding encoding = new ASCIIEncoding();
    //    string postData = "PIN=" + objWebDomain.PinNo;
    //    postData += ("&Mobile=" + objWebDomain.MobileNo);
    //    byte[] data = encoding.GetBytes(postData);


    //    #region // Sending Request for PinNo Validation to Another Server, Which returns the status as 0, 1 or 2
    //    // Prepare web request...
    //    HttpWebRequest http_pinRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/AdminX/WebPinStatus_Post.asp");
    //    http_pinRequest.Method = "POST";
    //    http_pinRequest.ContentType = "application/x-www-form-urlencoded";
    //    http_pinRequest.ContentLength = data.Length;
    //    Stream newStream = http_pinRequest.GetRequestStream();
    //    // Send the data.
    //    newStream.Write(data, 0, data.Length);
    //    newStream.Close();



    //    // *** Retrieve request info headers
    //    HttpWebResponse http_pinResponse = (HttpWebResponse)http_pinRequest.GetResponse();
    //    Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page
    //    StreamReader loResponseStream = new StreamReader(http_pinResponse.GetResponseStream(), enc);
    //    string Html_PinResponse = loResponseStream.ReadToEnd();
    //    http_pinResponse.Close();
    //    loResponseStream.Close();

    //    #endregion

    //    //---- Checking for the Valid PIN ------------

    //    /* Response format is Parameter1 , Parameter2, Parameter3 
    //     * ------------------- StatusVal,   MobileVal , BuyCode
    //     * ---------------
    //     * Where Parameter1 = 0 or 1 or 2  
    //     * ---------------
    //     * 0 - still valid 
    //     * 1 - Activated
    //     * 2 - Pin does not exists
    //     * 
    //     * --------------
    //     * Parameter 2
    //     * --------------
    //     *  Mobile no. of the person from whom it was purchased. 
    //     * 
    //     * --------------
    //     * Parameter 3
    //     * --------------
    //     * Buy Code :  WEB10 or WEB30
    //     * 
    //    */


    //    string[] pinResponseArray = Html_PinResponse.Split(',');

    //    int pinStatus = Convert.ToInt16(pinResponseArray[0]);
    //    string pinMobileTo = pinResponseArray[1];
    //    string pinPurchasedBy = pinResponseArray[2];
    //    string pinBuyCode = pinResponseArray[3];


    //    if (pinStatus == 2)
    //    {
    //        lblErrMessage.Text = "Wrong Pin entered. Please check and re-enter again.";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //    }
    //    else if (pinStatus == 1)
    //    {
    //        lblErrMessage.Text = "Invalid Pin entered. Please check and re-enter again.";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //    }
    //    else if (pinStatus == 0)
    //    {

    //        objWebDomain.DomainType = pinBuyCode.ToString().Substring(3, pinBuyCode.Length - 3);
    //        objWebDomain.PurchasedBy = pinPurchasedBy;
    //        objWebDomain.PurchasedTo = pinMobileTo;
    //        tblMessageBar.Visible = true;
    //        lblErrMessage.Text = "Registration is Successful. ";
    //        lblErrMessage.CssClass = "font_12Msg_Success";
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";

    //        //Registration Successfull  

    //        // update the database for registration date and status. 
    //        // if successfully stored the function returns the newly created USERID. 
    //        int Reg_UserID = objBAL_User.InsertUpdate_SubDomain_Registration(objWebDomain);


    //        if (Reg_UserID != -1)
    //        {
    //            //Send Success Email 
    //            //fnSendEmail();

    //            //---- Update Activation status to PIN to the other SERVER ------------
    //            #region // Sending Activatation data to another Server which return code 200 if successful
    //            string tmpWebsite = objWebDomain.DomainName + "." + GlobalVar.GetAnchorDomainName; 
    //            //---- Checking for the Valid PIN from Another SERVER------------
    //            ASCIIEncoding AC_encoding = new ASCIIEncoding();
    //            string AC_postData = "PIN=" + objWebDomain.PinNo;
    //            AC_postData += ("&Mobile=" + objWebDomain.PurchasedTo);
    //            AC_postData += ("&WebSite=" + tmpWebsite);
    //            AC_postData += ("&Login=" + objWebDomain.DomainName);
    //            AC_postData += ("&Password=" + objWebDomain.DomainPassword);
    //            byte[] AC_data = encoding.GetBytes(AC_postData);


    //            // Prepare web request...
    //            HttpWebRequest http_ACpinRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/AdminX/WebPinUpdate_Post.asp");
    //            http_ACpinRequest.Method = "POST";
    //            http_ACpinRequest.ContentType = "application/x-www-form-urlencoded";
    //            http_ACpinRequest.ContentLength = AC_data.Length;
    //            Stream AC_newStream = http_ACpinRequest.GetRequestStream();
    //            // Send the data.
    //            AC_newStream.Write(AC_data, 0, AC_data.Length);
    //            AC_newStream.Close();



    //            // *** Retrieve request info headers
    //            HttpWebResponse http_ACpinResponse = (HttpWebResponse)http_ACpinRequest.GetResponse();
    //            Encoding AC_enc = Encoding.GetEncoding(1252);  // Windows default Code Page
    //            StreamReader AC_ResponseStream = new StreamReader(http_ACpinResponse.GetResponseStream(), AC_enc);
    //            string Html_AC_PinResponse = AC_ResponseStream.ReadToEnd();
    //            http_ACpinResponse.Close();
    //            AC_ResponseStream.Close();
    //            #endregion

    //            if (Html_AC_PinResponse == "200")
    //            {
    //                //Pin Activated... 

    //                // update the database for activation date and status. 
    //                int upStatus = objBAL_User.Update_SubDomain_ActivationDetails(Reg_UserID);

    //            }

    //        }



    //        CommonFunctions.fnSendEmailHTML(objWebDomain.Email, objWebDomain.MobileNo, objWebDomain.FullName, objWebDomain.DomainName, objWebDomain.DomainPassword);

    //        //Redirecting to reg success page
    //        Response.Redirect("PartnerWebRegistrationSucessNew.aspx?regDomainName=" + objWebDomain.DomainName);

    //    }


    //    }

    //}

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

}

