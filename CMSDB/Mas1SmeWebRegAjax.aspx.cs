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

public partial class Mas1SmeWebRegAjax : System.Web.UI.Page
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

     


        #region -- Rendering Top Left Panel -- Commented
        //StringBuilder sb = new StringBuilder();
        //sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
        //sb.Append("<tr>");
        //sb.Append("<td align='left' valign='top'>");
        //sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        //sb.Append("</td>");
        //sb.Append("<td>");
        //sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
        //sb.Append("</td>");
        //sb.Append("</tr>");
        //sb.Append("</table>");

        //dvBannerLeftPanel.InnerHtml = sb.ToString();
        #endregion


        txtMobileNo.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtSubDomainName.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");
        txtSMEPIN.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtSMEUserID.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_Alpha(event)");

       // DdlCountry.Attributes.Add("onchange", "javascript:return ChangeMobileText(event)");

        btnRegister.Enabled = true;
        lblMasUserMessage.Text = "Please fill in all the details below to complete the registration";

        if (!IsPostBack)
        {
            //LoadMasUserDetails();
            LoadCategories();
        }

    }

    //protected void LoadMasUserDetails()
    //{

    //    CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();

    //    //..For testing Purpose 
    //    MasFunc.Get_1MalaysiaUser_Details("60162396360", ref objMasUser);
    //    Session["MasUSER"] = objMasUser;
    //    string strMobWebCheck = string.Empty;

    //   if (1==1)
    //    //if (Request.Form["MasRegMobileID"] != null)
    //    {

    //        strCountryPrefix = "60";
    //        strMobileLoginID = "60162396360";
    //        strMasRegPassword = "802780405";

    //        //strCountryPrefix = Request.Form["MasRegCountryPrefix"].ToString();
    //        //strMobileLoginID = Request.Form["MasRegMobileID"].ToString();
    //        //strMasRegPassword = Request.Form["MasRegPassword"].ToString();

    //        ViewState["strCountryPrefix"] = strCountryPrefix;
    //        ViewState["strMobileLoginID"] = strMobileLoginID;
    //        ViewState["strMasRegPassword"] = strMasRegPassword;

    //        if (Request.Form["MasRegPageFrom"] != null)
    //        {
    //            strRegPageFrom = Request.Form["MasRegPageFrom"].ToString(); 
    //        }
    //        ViewState["strRegPageFrom"] = strRegPageFrom;

           
    //       // Response.Write("|" + strCountryPrefix + "|" + strMobileLoginID + "|" + strMasRegPassword);
      

        

    //    //..function get all the details of 1malaysia user into MasUser entity 
    //    MasFunc.Get_1MalaysiaUser_Details(strMobileLoginID, ref objMasUser);

    //    if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
    //        Session["MasUSER"] = objMasUser;

       

    //        if (Session["MasUser"] == null)
    //        {
    //            Response.Redirect("~/inValidDomain.aspx");
    //        }

    //        objMasUser = (CMSv3.Entities.MasUser)Session["MasUser"];

    //        string tmpMobileNo = objMasUser.LoginID;
    //        CountryCode = tmpMobileNo.Substring(0, 2);

    //        if(CountryCode == "67")
    //            CountryCode = tmpMobileNo.Substring(0, 3);


    //        ViewState["CountryCode"] = CountryCode;

    //        //DdlCountry.SelectedValue = CountryCode; 


    //        ////lblUserMobileNo.Text = objMasUser.LoginID;
    //        ////lblFullName.Text = objMasUser.MemberName;

    //        txtFullName.Text = objMasUser.MemberName;
    //        txtMobileNo.Text = objMasUser.LoginID;
            
            
    //        txtMobileNo.Attributes.Add("readonly", "readonly");


            

    //        //lblUserEmail.Text = objMasUser.Email;



    //        ViewState["Password"] = objMasUser.Password;
    //        ViewState["MobileNo"] = objMasUser.LoginID;
    //        ViewState["FullName"] = objMasUser.MemberName;
    //        ViewState["Email"] = objMasUser.Email;
    //        ViewState["Company"] = objMasUser.Company; 
    //    }
    //    else
    //    {
    //        Response.Redirect("~/inValidDomain.aspx");
    //    }

    //    //txtMobileNo.Attributes.Add("readonly", "readonly");
    //    //txtEmail.Attributes.Add("readonly", "readonly");
    //    //txtName.Attributes.Add("readonly", "readonly"); 
        

    //}

    
   

    protected void LoadCategories()
    {
        
        DataSet dsCat;
        DataView dvCat;

        CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();

        dsCat = objBAL_Domains.Retrieve_AnchorDomains("");
        dvCat = dsCat.Tables[0].DefaultView;

        ddlAnchorDomain.DataSource = dsCat;
        ddlAnchorDomain.DataTextField = "AnchorDomain";
        ddlAnchorDomain.DataValueField = "TID";
        ddlAnchorDomain.DataBind();

        ddlAnchorDomain.Items.Insert(0, new ListItem("Select AnchorDomain", "0"));


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
        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();


        //acquiring entered Values;

        #region  // gathering values 
    
            //... UserID and PIN Details
            string smeUserID = txtSMEUserID.Text;
            string smePassword = txtSMEPwd.Text;
            string smePinNumber = txtSMEPIN.Text;

            objWebDomain.DomainPassword = txtSMEPwd.Text;


            //... SubDomain Details
            objWebDomain.DomainName = txtSubDomainName.Text;
           

            //... Other Details 
            objWebDomain.FullName = txtFullName.Text;
            objWebDomain.Email = txtEmail.Text;
            objWebDomain.MobileNo = txtMobileNo.Text;

            //Address 
            objWebDomain.CountryCode = Convert.ToInt16(ddlCountry.SelectedValue);
            objWebDomain.Street = txtStreet.Text;
            objWebDomain.City = txtCity.Text;
            objWebDomain.State = txtState.Text;
            objWebDomain.PostCode = txtPinCode.Text;
            objWebDomain.LanguageCode = 1; // Convert.ToInt16(rdolstLanguage.SelectedValue);

            //objWebDomain.Company = ViewState["Company"].ToString();
            objWebDomain.Company = objWebDomain.FullName;
          
            //AnchorDomain
            int vAnchorDomainID = Convert.ToInt32(ddlAnchorDomain.SelectedValue);

        #endregion  // end of gathering values; 
        
       ////fnLogintoWebPortal(smeUserID, smePassword);

        //.. Pass smeUserID and smePinNumber to Siva's Page to Get the Reponse. 

        int smsRegStatus = 0;
        string smeMobileNumber = string.Empty;

        //..First Check UserID, Pin and SubDomainName Validation 
        int smePreCheck = -1; 
        smePreCheck = objBAL_User.CheckUseridPinSbd_Status(smeUserID, smePinNumber, txtSubDomainName.Text);

        ////smePreCheck = -99;


        if (smePreCheck != 0)
        {
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

            switch (smePreCheck)
            {
                case 1: lblErrMessage.Text = "Entered UserID Already exists. Please re-enter again."; break;
                case 2: lblErrMessage.Text = "Entered Pin Number could not be validated. Please check and try again."; break;
                case 3:
                case 4:
                    lblErrMessage.Text = "Could not register your SubDomain. Entered SubDomain already exists."; break;
                //default: break;
            }
            btnRegister.Enabled = true;
        }
        else
        {

            #region // Sending Request for PinNo Validation to Another Server, Which returns the status as 0, 1 or 2


            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "smeUSERID=" + smeUserID;
            postData += ("&smePassword=" + smePassword);
            postData += ("&smePIN=" + smePinNumber);
            postData += ("&smeFullName=" + txtFullName.Text.Trim());

            //string postData = "PIN=" + smePinNumber;
            //postData += ("&Mobile=" + smePassword);

            byte[] data = encoding.GetBytes(postData);

            String SMEWEB_URL = ConfigurationManager.AppSettings["SMEWEBurl"].ToString();

            // Prepare web request...
            //HttpWebRequest http_pinRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/offline/SMEWEB.asp");
            HttpWebRequest http_pinRequest = (HttpWebRequest)WebRequest.Create(SMEWEB_URL);
        
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

                    smsRegStatus = Convert.ToInt16(pinResponseArray[0]);
                    smeMobileNumber = pinResponseArray[1];
                    //string pinBuyCode = pinResponseArray[2];


                } catch(Exception ex) {
                    if (ex is WebException && ((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                   {
                       StringBuilder errSB = new StringBuilder(); 
                       WebResponse errResp = ((WebException)ex).Response;
                     // using(Stream respStream = errResp.GetResponseStream())
                        using(StreamReader exReader = new StreamReader(errResp.GetResponseStream()))
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


            



           


            #endregion

            if (smsRegStatus != 1)
            {
                lblErrMessage.CssClass = "font_12Msg_Error";
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";

                switch (smsRegStatus)
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
                //.. SubDomain Registration 

                #region ... SubDomain Registration

                //int DomainStatus = objBAL_User.CheckSubDomainExists_MobileLoginID(txtSubDomainName.Text, smeMobileNumber);

                //if (DomainStatus != 0)
                //{
                //    lblErrMessage.CssClass = "font_12Msg_Error";
                //    tblMessageBar.Visible = true;
                //    MessageImage.Src = "~/Images/inf_Error.gif";

                //    switch (DomainStatus)
                //    {
                //        case 1: lblErrMessage.Text = "Entered Domain Already exists. Please check and re-enter again."; break;
                //        case 2: lblErrMessage.Text = "Could not register your SubDomain. Technical error or a SubDomain already exists for your mobile."; break;
                //        case 3: lblErrMessage.Text = "Could not register your SubDomain. entered SubDomain already exists."; break;
                //    }
                //    btnRegister.Enabled = true;

                //}
                //else
                //{

                    //..proceed to sub-domain registration 
                    objWebDomain.DomainType = "SME";
                    objWebDomain.PurchasedBy = "60890000000";
                    objWebDomain.PurchasedTo = txtMobileNo.Text;
                    objWebDomain.PinNo = "8899889988";

                    tblMessageBar.Visible = true;
                    lblErrMessage.Text = "Registration is Successful. Please wait while we navigate you to SMS system.";
                    lblErrMessage.CssClass = "font_12Msg_Success";
                    MessageImage.Src = "~/Images/inf_Sucess.gif";
                    tblEntryForm.Visible = false;

                    //Registration Successfull  

                    // update the database for registration date and status. 
                    // if successfully stored the function returns the newly created USERID. 

                    //Using Transaction for Successfuly Registration. 
                    Response.Write("Registering domain...");

                    //int Reg_UserID = -1;
                    int Reg_UserID = objBAL_User.SubDomain_Reg_WithAnchorDomain_SME(objWebDomain, vAnchorDomainID, Convert.ToInt64(smeMobileNumber),smePinNumber);

                    if (Reg_UserID != -1)
                    {
                        if (txtEmail.Text.Trim() != "")
                        {  //Send Success Email 
                            fnSendEmail();
                        }
                        Response.Write("Updating domain... status ");

                        // update the database for activation date and status. 
                        int upStatus = objBAL_User.Update_SubDomain_ActivationDetails(Reg_UserID);
                    }


                    //Dont redirect to success page.. straight away Login and take the user to AdminLogin Home page. 

                    Session["UserID"] = Reg_UserID;
                    Session["LoginID"] = objWebDomain.DomainName;
                    Session["UserDomainType"] = objWebDomain.DomainType;
                    Session["MobileLoginID"] = objWebDomain.MobileNo;

                    
                    //.. Directing to SMS System Login 

                    //string mUserName = "60149664566";
                    //string mPassword = "27272727";

                    string mUserName = smeUserID;
                    string mPassword = smePassword; 

                    //string strReferringURL = "";


                    //fnLogintoSMSsystem(mUserName, mPassword);

                    fnLogintoWebPortal(mUserName, mPassword);

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
        sb.AppendFormat("<input type='hidden' name='MLoginFrom' value='{0}'>", "SMSLOGIN");
        sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
        // Other params go here
        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();



 }


 //protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
 //{
 //    //15360 = 15 KB  ( 1024 * 15 )

 //    if (chkAgreement.Checked)
 //    {
 //        args.IsValid = true;
 //    }
 //    else
 //    {
 //        args.IsValid = false;
 //    }
 //}

 protected void txtSubDomainName_TextChanged(object sender, EventArgs e)
 {


     //Check if the subDomain already exists.
     if (txtSubDomainName.Text != "")
     {
         bool isSubDomainExists = objBAL_User.CheckSubDomainExists(txtSubDomainName.Text);

         if (isSubDomainExists)
         {
             //dvSubDomainCheck.InnerHtml = "<img src='Images/inf_Error.gif' />&nbsp;<font class='font_11Msg_Error'>Entered SubDomain already taken. Please try another.</font>";
             dvSubDomainCheck.InnerText = "Entered SubDomain already taken!. Please try another.";
             dvSubDomainCheck.Attributes.Add("class", "invalid");
         }
         else
         {
             dvSubDomainCheck.InnerText = "Entered SubDomain is available!";
             dvSubDomainCheck.Attributes.Add("class", "valid");
             //dvSubDomainCheck.InnerHtml = "<img src='Images/inf_Sucess.gif' />&nbsp;<font class='font_11Msg_Success'>Entered SubDomain is available.</font>";
         }

     }

     //txtPassword.Focus();


 }

 protected void txtSMEUserID_TextChanged(object sender, EventArgs e)
 {

     int smeUserIDCheck = -1;

     CMSv3.BAL.MalaysiaSMS objMAS_User = new CMSv3.BAL.MalaysiaSMS();

     smeUserIDCheck = objMAS_User.CheckSME_UserID(txtSMEUserID.Text);

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

 protected void txtSMEPIN_TextChanged(object sender, EventArgs e)
 {
     int smePinNumberCheck = -1;

     CMSv3.BAL.MalaysiaSMS objMAS_User = new CMSv3.BAL.MalaysiaSMS();

     smePinNumberCheck = objMAS_User.CheckSME_PinNumber(txtSMEPIN.Text);

     if (smePinNumberCheck == 0)
     {
         dvPinNumberCheck.InnerText = "Entered PinNumber was validated successfully.";
         dvPinNumberCheck.Attributes.Add("class", "valid");
     }
     else
     {
         dvPinNumberCheck.InnerText = "Entered PinNumber could not be Validated. Please Check!!!";
         dvPinNumberCheck.Attributes.Add("class", "invalid");
         
     }
 }


 public static Boolean IsNumeric(string stringToTest)
 {
     int result;
     return int.TryParse(stringToTest, out result);
 }

}

