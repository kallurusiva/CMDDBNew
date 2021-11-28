using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Xml;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using CMSv3.Entities;


public partial class PartnerWebRegistration : UserWeb
{

//    SqlConnection dbConn;
//    SqlCommand dbCmd;
//    SqlDataReader dbReader;
    //DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {



        #region Language Resources

        ltrContactUs.Text = Resources.LangResources.ContactUs;
        //LblCompanyName.Text = Resources.LangResources.Company;
        //lblNickName.Text = Resources.LangResources.Nickname;
        //lblHomephone.Text = Resources.LangResources.Home + Resources.LangResources.Phone;
        //lblHandPhone.Text = Resources.LangResources.Phone;
        //lblAddress.Text = Resources.LangResources.Address;

        lblName.Text = Resources.LangResources.Name;
        lblMobileNo.Text = Resources.LangResources.contact + " " + Resources.LangResources.number;
        lblEmail.Text = "Email";
       
        #endregion 

        txtMobileNo.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtSubDomainName.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");
            
        


        #region -- Rendering Top Left Panel --
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
        #endregion

        if (!IsPostBack)
        {
           // LoadUserContactDetails();
            LoadCountries();
        }

    }


    //protected void CheckMobile_CountryPrefix(object sender, ServerValidateEventArgs e)
    //{
    //    int tmpCd = Convert.ToInt16(DdlCountry.SelectedValue);

    //    int StartingTwoChar = Convert.ToInt16(e.Value.Substring(0, 2));
        

    //    if (tmpCd == 60)
    //    {
    //        if (StartingTwoChar == 60)
    //            e.IsValid = true;
    //        else
    //            e.IsValid = false;
    //        CustVd_Prefix.ErrorMessage = "Should start with 60 only";

    //    }
    //    else if (tmpCd == 65)
    //    {
    //        if (StartingTwoChar == 65)
    //            e.IsValid = true;
    //        else
    //            e.IsValid = false;
    //        CustVd_Prefix.ErrorMessage = "Should start with 65 only";
    //    }




    //}

    //protected void LoadUserContactDetails()
    //{

    //    string strSQL = "EXEC usp_USER_ContactUs_GET_ByUserID " + Convert.ToInt32(GlobalVar.GetTestLoginUser);

    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);
    //    try
    //    {
    //        dbConn.Open();
    //        dbCmd = new SqlCommand(strSQL, dbConn);
    //        dbReader = dbCmd.ExecuteReader();

    //        if (dbReader.HasRows)
    //        {
    //            while (dbReader.Read())
    //            {
    //                ltrCompanyName.Text = dbReader["CompanyName"].ToString();

    //                if (dbReader["NickNamechk"].ToString() == "True")
    //                    LtrNickName.Text = dbReader["NickName"].ToString();

    //                if (dbReader["MobileNochk"].ToString() == "True")
    //                    LtrHandPhone.Text = dbReader["HandPhone"].ToString();

    //                if (dbReader["HomePhonechk"].ToString() == "True")
    //                    ltrHomephone.Text = dbReader["HomePhone"].ToString();

    //                if (dbReader["FaxNochk"].ToString() == "True")
    //                    ltrFaxNo.Text = dbReader["FaxNo"].ToString();


    //                if (dbReader["Emailchk"].ToString() == "True")
    //                    ltrEmail.Text = dbReader["Email"].ToString();
                    

    //                if (dbReader["Addresschk"].ToString() == "True")
    //                {
    //                    string tmpAddress = dbReader["Address"].ToString();
    //                    tmpAddress = tmpAddress.Replace("<br/>", Environment.NewLine);
    //                    LtrAddress.Text = dbReader["Address"].ToString();
    //                }

    //                if (dbReader["UserPhotoChk"].ToString() == "True")
    //                    ImgContact.ImageUrl = dbReader["FullImgPath"].ToString();
    //                else
    //                    ImgContact.ImageUrl = @"~\ImageRepository\Dummy_user.gif";

    //            }

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        dbConn.Close();
    //    }


    //}

    protected void btnRegister_Click(object sender, EventArgs e)
    {

        CMSv3.Entities.webDomain objWebDomain = new CMSv3.Entities.webDomain();
        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

        //acquiring entered Values;
        objWebDomain.PinNo = txtPinNo.Text;
        objWebDomain.DomainName = txtSubDomainName.Text;
        objWebDomain.DomainPassword = txtPassword.Text;
        objWebDomain.FullName = txtName.Text;
        objWebDomain.Email = txtEmail.Text;
        objWebDomain.MobileNo = txtMobileNo.Text;
        objWebDomain.CountryCode = Convert.ToInt16(DdlCountry.SelectedValue);



        //---- Checking for the Valid PIN from Another SERVER------------
        ASCIIEncoding encoding = new ASCIIEncoding();
        string postData = "PIN=" + objWebDomain.PinNo;
        postData += ("&Mobile=" + objWebDomain.MobileNo);
        byte[] data = encoding.GetBytes(postData);


    #region // Sending Request for PinNo Validation to Another Server, Which returns the status as 0, 1 or 2
        // Prepare web request...
        HttpWebRequest http_pinRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/AdminX/WebPinStatus_Post.asp");
        http_pinRequest.Method = "POST";
        http_pinRequest.ContentType = "application/x-www-form-urlencoded";
        http_pinRequest.ContentLength = data.Length;
        Stream newStream = http_pinRequest.GetRequestStream();
        // Send the data.
        newStream.Write(data, 0, data.Length);
        newStream.Close();



        // *** Retrieve request info headers
        HttpWebResponse http_pinResponse = (HttpWebResponse)http_pinRequest.GetResponse();
        Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page
        StreamReader loResponseStream = new StreamReader(http_pinResponse.GetResponseStream(), enc);
        string Html_PinResponse = loResponseStream.ReadToEnd();
        http_pinResponse.Close();
        loResponseStream.Close();

    #endregion

        //---- Checking for the Valid PIN ------------

        /* Response format is Parameter1 , Parameter2, Parameter3 
         * ------------------- StatusVal,   MobileVal , BuyCode
         * ---------------
         * Where Parameter1 = 0 or 1 or 2  
         * ---------------
         * 0 - still valid 
         * 1 - Activated
         * 2 - Pin does not exists
         * 
         * --------------
         * Parameter 2
         * --------------
         *  Mobile no. of the person from whom it was purchased. 
         * 
         * --------------
         * Parameter 3
         * --------------
         * Buy Code :  WEB10 or WEB30
         * 
        */


        string[] pinResponseArray = Html_PinResponse.Split(',');

        int pinStatus = Convert.ToInt16(pinResponseArray[0]);
        string pinMobileTo = pinResponseArray[1];
        string pinBuyCode = pinResponseArray[2];


        if (pinStatus == 2)
        {
            lblErrMessage.Text = "Wrong Pin entered. Please check and re-enter again.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }
        else if (pinStatus == 1)
        {
            lblErrMessage.Text = "Invalid Pin entered. Please check and re-enter again.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }
        else if (pinStatus == 0)
        {

            objWebDomain.DomainType = pinBuyCode.ToString().Substring(3,pinBuyCode.Length - 3);
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Registration is Successful. ";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

            //Registration Successfull  

            // update the database for registration date and status. 
            // if successfully stored the function returns the newly created USERID. 
            int Reg_UserID = objBAL_User.InsertUpdate_SubDomain_Registration(objWebDomain);


            if (Reg_UserID != -1)
            {
                //Send Success Email 
                fnSendEmail();

                //---- Update Activation status to PIN to the other SERVER ------------
                #region // Sending Activatation data to another Server which return code 200 if successful
                string tmpWebsite = objWebDomain.DomainName + ".smsEntreprenuer.com";
                //---- Checking for the Valid PIN from Another SERVER------------
                ASCIIEncoding AC_encoding = new ASCIIEncoding();
                string AC_postData = "PIN=" + objWebDomain.PinNo;
                AC_postData += ("&Mobile=" + objWebDomain.MobileNo);
                AC_postData += ("&WebSite=" + tmpWebsite);
                AC_postData += ("&Login=" + objWebDomain.DomainName);
                AC_postData += ("&Password=" + objWebDomain.DomainPassword);
                byte[] AC_data = encoding.GetBytes(AC_postData);


                // Prepare web request...
                HttpWebRequest http_ACpinRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/AdminX/WebPinUpdate_Post.asp");
                http_ACpinRequest.Method = "POST";
                http_ACpinRequest.ContentType = "application/x-www-form-urlencoded";
                http_ACpinRequest.ContentLength = AC_data.Length;
                Stream AC_newStream = http_ACpinRequest.GetRequestStream();
                // Send the data.
                AC_newStream.Write(AC_data, 0, AC_data.Length);
                AC_newStream.Close();



                // *** Retrieve request info headers
                HttpWebResponse http_ACpinResponse = (HttpWebResponse)http_ACpinRequest.GetResponse();
                Encoding AC_enc = Encoding.GetEncoding(1252);  // Windows default Code Page
                StreamReader AC_ResponseStream = new StreamReader(http_ACpinResponse.GetResponseStream(), AC_enc);
                string Html_AC_PinResponse = AC_ResponseStream.ReadToEnd();
                http_ACpinResponse.Close();
                AC_ResponseStream.Close();
                #endregion

                if (Html_AC_PinResponse == "200")
                {
                    //Pin Activated... 

                    // update the database for activation date and status. 
                    int upStatus = objBAL_User.Update_SubDomain_ActivationDetails(Reg_UserID);

                }

            }

            //Redirecting to reg success page
            Response.Redirect("PartnerWebRegistrationSuccess.aspx");

        }


       
        
      //// int inStatus = objBAL_enquiry.InsertEnquiryData(objEnquiry, Convert.ToInt32(GlobalVar.GetTestLoginUser));

        //if (pinStatus == 0)
        //{
        //    tblMessageBar.Visible = true;
        //    lblErrMessage.Text = "Registration is Successful. ";
        //    lblErrMessage.CssClass = "font_12Msg_Success";
        //    MessageImage.Src = "~/Images/inf_Sucess.gif";
           
        //}
        //else
        //{
        //    lblErrMessage.Text = "Could not send the Email due to Technical Error. Please try again.";
        //    lblErrMessage.CssClass = "font_12Msg_Error";
        //    tblMessageBar.Visible = true;
        //    MessageImage.Src = "~/Images/inf_Error.gif";
        //}


        ////-- Send Email -- //
        //MailMessage ObjMsg = new MailMessage();

        //ObjMsg.To = "msri_hari@yahoo.com";
        //ObjMsg.From = "support@1smswebsite.com";

        //ObjMsg.Subject = objEnquiry.Subject;
        //ObjMsg.Body = objEnquiry.Message;
        //ObjMsg.BodyFormat = MailFormat.Text;

        //SmtpMail.SmtpServer = "mail.1argentinasms.com";
        ////SmtpMail.Send(ObjMsg);


                //working mail
             //SmtpClient mailObj = new SmtpClient("127.0.0.1");
            //MailMessage mail = new MailMessage("msri_hari@yahoo.com", "hari.meena@gmail.com",
            //"Testing", "Hello Everybody");
            //mailObj.Send(mail);


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

            objMessage.To.Add(txtEmail.Text);
            objMessage.Subject = "Registration details at SMSEntreprenuer.com";

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

            objMessage.IsBodyHtml = false;

            // Message body content
            string m_MessageBody = "Your Registration at SMSentreprenuer.com is successful";
            objMessage.Body = m_MessageBody;

            // Send SMTP mail

            smtpClient.Send(objMessage);

           // lblStatus.Text = "Email successfully sent.";




        }
        catch
        {

        }


    }


    protected void LoadCountries()
    {
        CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
        DataSet ds = new DataSet();
        ds = objBAL_CommonFunc.GetCountryList();

        DdlCountry.DataSource = ds;
        DdlCountry.DataValueField = "CountryCode";
        DdlCountry.DataTextField = "CountryName";
        DdlCountry.SelectedValue = "60";
        DdlCountry.DataBind();



    }
    protected void txtSubDomainName_TextChanged(object sender, EventArgs e)
    {

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        //Check if the subDomain already exists.
        if(txtSubDomainName.Text != "")
        {
            bool isSubDomainExists = objBAL_User.CheckSubDomainExists(txtSubDomainName.Text);
            tr_ShowDomainError.Visible = true;
            if (isSubDomainExists)
            {
                dv_ShowSbError.InnerHtml = "<img src='Images/inf_Error.gif' />&nbsp;<font class='font_11Msg_Error'>Entered SubDomain already taken. Please try another.</font>"; 
            }
            else
            {
                dv_ShowSbError.InnerHtml = "<img src='Images/inf_Sucess.gif' />&nbsp;<font class='font_11Msg_Success'>Entered SubDomain is available.</font>"; 
            }

        }
        
        txtPassword.Focus();


    }

}
