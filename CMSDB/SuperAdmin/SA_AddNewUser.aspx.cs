using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using System.Web.Mail;
using System.Net.Mail;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;


public partial class SuperAdmin_SA_AddNewUser : BasePage 
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    string strSQL = string.Empty;
    



    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        #region // rendering language resources

        //ltrCurrentPassword.Text = Resources.LangResources.Currentpassword;
        //ltrNewPassword.Text = CommonFunctions.TitleCase(Resources.LangResources.New + " password");;
        //ltrRetypeNewPassword.Text = Resources.LangResources.retype + " password";
        //ltrForGotPassword.Text = Resources.LangResources.forgot + " password";
        #endregion


        txtMobileNo.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtSubDomainName.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");
        DdlCountry.Attributes.Add("onchange", "javascript:return ChangeMobileText(event)");

        txtDebtorMobile.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtPurchaserMobile.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
      //  rdolstDomainType.Attributes.Add("onclick", "javascript:return ShowHideDivOwnDomain()");

        string vDomainName = string.Empty;
        Page.MaintainScrollPositionOnPostBack = true;

        if(!IsPostBack)
        {

           if ((Request.QueryString["regDomainName"] != null) && (Request.QueryString["regDomainName"] != ""))
            {
                vDomainName = Request.QueryString["regDomainName"].ToString();

                tblRegister.Visible =false;
                tblRegSucess.Visible = true;
                LoadDomainRegDetails(vDomainName);
            }
            else
            {

                tblRegister.Visible =true;
                tblRegSucess.Visible = false;
            }
            


          //  LoadPassword();
        }


    }




    protected void LoadPassword()
    {

       

        try
        {
            dbConn.Open();
            strSQL = "EXEC usp_Password_Retrieve_byUserID " + Convert.ToInt32(Session["saUserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {

                  //  txtCurrentPassword.Text = dbReader["LoginPassword"].ToString();

                }

            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }



    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        //get the entere values. 

 //       string mCurrentPassword = txtCurrentPassword.Text;
  //      string newPassword = txtNewPassword.Text;
        //[usp_Password_Update_ByUserID] userid, currentPassword, NewPassword 
    //    strSQL = "EXEC [usp_Password_Update_ByUserID] " + Convert.ToInt32(Session["saUserID"]) + ",'" + mCurrentPassword + "','" +
   //                     newPassword + "'";
//
        int rowCount = 0;
        
        try
        {
            dbConn.Open();
           
            dbCmd = new SqlCommand(strSQL, dbConn);
            rowCount = dbCmd.ExecuteNonQuery();

           
       if (rowCount >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Password changed successfully. Your next login would be with new password.";
            lblErrMessage.CssClass = "font_12Msg_Success";

            

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Unable to complete the operation. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }



        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }




        if (rowCount >= 1)
        {
        LoadPassword();
   //     txtNewPassword.Text = "";
     //   txtRetypePassword.Text = "";
        }




    }


    protected void txtSubDomainName_TextChanged(object sender, EventArgs e)
    {

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        //Check if the subDomain already exists.
        if (txtSubDomainName.Text != "")
        {
            bool isSubDomainExists = objBAL_User.CheckSubDomainExists(txtSubDomainName.Text);
            tr_ShowDomainError.Visible = true;
            if (isSubDomainExists)
            {
                dv_ShowSbError.InnerHtml = "<img src='../Images/inf_Error.gif' />&nbsp;<font class='font_11Msg_Error'>Entered SubDomain already taken. Please try another.</font>";
            }
            else
            {
                dv_ShowSbError.InnerHtml = "<img src='../Images/inf_Sucess.gif' />&nbsp;<font class='font_11Msg_Success'>Entered SubDomain is available.</font>";
            }

        }

        txtPassword.Focus();


    }



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
        objWebDomain.LanguageCode = Convert.ToInt16(rdolstLanguage.SelectedValue);
        objWebDomain.Company = txtName.Text;


        //bool isSubDomainExists = objBAL_User.CheckSubDomainExists(txtSubDomainName.Text);
       
        int DomainStatus = objBAL_User.CheckSubDomainExists_MobileLoginID(txtSubDomainName.Text.Trim(), txtMobileNo.Text.Trim());


        if (DomainStatus == 1)
        {
            lblErrMessage.Text = "Entered Domain Already exists. Please check and re-enter again.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

        }
        else if (DomainStatus == 2)
        {
            lblErrMessage.Text = "Could not register your SubDomain. Technical error or a SubDomain already exists for your mobile.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

        }
        else if (DomainStatus == 3)
        {
            lblErrMessage.Text = "Could not register your SubDomain. entered SubDomain already exists.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

        }
        else
        {

            //objWebDomain.DomainType = pinBuyCode.ToString().Substring(3, pinBuyCode.Length - 3);
            //objWebDomain.PurchasedBy = pinPurchasedBy;
            //objWebDomain.PurchasedTo = pinMobileTo;
            objWebDomain.DomainType = rdolstDomainType.SelectedValue; 
            objWebDomain.PurchasedBy = txtPurchaserMobile.Text;
            objWebDomain.PurchasedTo = txtDebtorMobile.Text;

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
                ASCIIEncoding encoding = new ASCIIEncoding();

                //---- Update Activation status to PIN to the other SERVER ------------
                #region // Sending Activatation data to another Server which return code 200 if successful
                string tmpWebsite = objWebDomain.DomainName + ".smsEntreprenuer.com";
                //---- Checking for the Valid PIN from Another SERVER------------
                ASCIIEncoding AC_encoding = new ASCIIEncoding();
                string AC_postData = "PIN=" + objWebDomain.PinNo;
                AC_postData += ("&Mobile=" + objWebDomain.PurchasedTo);
                AC_postData += ("&WebSite=" + tmpWebsite);
                AC_postData += ("&Login=" + objWebDomain.DomainName);
                AC_postData += ("&Password=" + objWebDomain.DomainPassword);
                AC_postData += ("&Domaintype=" + objWebDomain.DomainType);
                AC_postData += ("&DebtorMobile=" + objWebDomain.PurchasedBy);
                AC_postData += ("&PurchaserMobile=" + objWebDomain.PurchasedTo);
                byte[] AC_data = encoding.GetBytes(AC_postData);


                // Prepare web request...
                String SA_AddNewUserURL = ConfigurationManager.AppSettings["SA_AddNewUser_URL"].ToString();

                //HttpWebRequest http_ACpinRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/AdminX/WebPin_AddNewUser_ByAdmin_Post.asp");
                HttpWebRequest http_ACpinRequest = (HttpWebRequest)WebRequest.Create(SA_AddNewUserURL);
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


            CommonFunctions.fnSendEmailHTML(objWebDomain.Email, objWebDomain.MobileNo, objWebDomain.FullName, objWebDomain.DomainName, objWebDomain.DomainPassword);

            //Redirecting to reg success page
            Response.Redirect("SA_AddNewUser.aspx?regDomainName=" + objWebDomain.DomainName);


        }



      


    }


    protected void LoadDomainRegDetails(string vDomainName)
    {
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);


        strSQL = "Select RegisteredPin,LoginID,LoginPassword, SubDomain, FullName,Country,HandPhone, Email,CountryName " +
                 "From tblUsers U " +
                 "INNER JOIN tblUserDetails UD on U.UserId = UD.UserID " +
                 "INNER JOIN tblCountry C on C.CountryCode = UD.Country " +
                 " Where LoginID  ='" + vDomainName + "'";

        dbConn.Open();
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                txtSuc_PinNo.Text = dbReader["RegisteredPin"].ToString();
                txtSuc_SubDomainName.Text = dbReader["SubDomain"].ToString();
                txtSuc_loginPassword.Text = dbReader["LoginPassword"].ToString();
                txtSuc_Name.Text = dbReader["Fullname"].ToString();
                txtSuc_Email.Text = dbReader["Email"].ToString();
                txtSuc_CountryName.Text = dbReader["CountryName"].ToString();
                lblInstantSubdomainName.Text = dbReader["SubDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName; 


            }
        }
        else
        {

        }





    }




    protected void lnkForgotPassword_Click(object sender, EventArgs e)
    {

        //-- Send Email -- //
        //MailMessage ObjMsg = new MailMessage();

        //ObjMsg.To = "msri_hari@yahoo.com";
        //ObjMsg.From = "msri_hari@yahoo.com";

        //ObjMsg.Subject = "Test";
        //ObjMsg.Body = "Change Password would be mailed here";
        //ObjMsg.BodyFormat = MailFormat.Text;

        //SmtpMail.SmtpServer = "localhost";
        //SmtpMail.Send(ObjMsg);

        //SmtpMail objSm = new SmtpMail;



        SmtpClient mailObj = new SmtpClient("127.0.0.1");
        MailMessage mail = new MailMessage("msri_hari@yahoo.com", "hari.meena@gmail.com",
        "Testing", "Hello Everybody");
        mailObj.Send(mail);

                
        

        //create the mail message

        //MailMessage objTestMail = new MailMessage();

        //MailMessage objm = new MailMessage();
        //objm.To ="ddd.dkd";

 
        ////'set the addresses
        //objTestMail.To = "hari.meena@gmail.com";
        //objTestMail.From = "msri_hari@yahoo.com";
        //objTestMail.To 

        //objTestMail.Subject = "Test";
        //objTestMail.Body = "Change Password would be mailed here";
        //objTestMail.BodyFormat = MailFormat.Text;

        //SmtpClient cntSmtp = new SmtpClient("127.0.0.1");
        //cntSmtp.Send(objTestMail);



//        // Create a mailman object for sending email.

//Chilkat.MailMan mailman = new Chilkat.MailMan();

//// Any string argument automatically begins the 30-day trial.

//mailman.UnlockComponent("30-day trial");

//// Set the SMTP server hostname.

//mailman.SmtpHost = "smtp.earthlink.net";

//// Create a simple email.

//Chilkat.Email email = new Chilkat.Email();

//email.Body = "This is the body";

//email.Subject = "This is the subject";

//email.AddTo("Chilkat Support","support@chilkatsoft.com");

//email.From = "Jack Johnson <jj@chilkatsoft.com>";



//// Send mail.

//bool success;

//success = mailman.SendEmail(email);

//if (success)

//{

//MessageBox.Show("Sent mail!");
    

//}

//else

//{

//MessageBox.Show(mailman.LastErrorText);

//}


        


    }
}
