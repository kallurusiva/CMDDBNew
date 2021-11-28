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
using System.Configuration; 


public partial class Admin_Ad_ChangePassword : BasePage 
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlCommand dbCmd1;
    SqlDataReader dbReader;
    SqlDataReader dbReader1;

    string strSQL = string.Empty;
    



    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        String dbString = ConfigurationManager.AppSettings["CommonDB32"].ToString();
        dbConn = new SqlConnection(dbString);


        
        #region // rendering language resources

        ltrCurrentPassword.Text = Resources.LangResources.Currentpassword;
        ltrNewPassword.Text = CommonFunctions.TitleCase(Resources.LangResources.New + " password");;
        ltrRetypeNewPassword.Text = Resources.LangResources.retype + " password";
       // ltrForGotPassword.Text = Resources.LangResources.ForgotPassword;
        #endregion

        

        if(!IsPostBack)
        {

           // LoadPassword();
        }


    }




    protected int CheckCurrentPassword()
    {
        try
        {
            if (dbConn.State == ConnectionState.Closed)
            dbConn.Open();
            //strSQL = "EXEC [usp_ChangePwdCheck] " + Session["MobileLoginID"].ToString() + ",'" + txtCurrentPassword.Text + "'";
            strSQL = "EXEC esms.dbo.USPT_ChangePasswordChk '" + Session["MobileLoginID"].ToString() + "','" + txtCurrentPassword.Text + "','" + txtNewPassword.Text + "'";
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            int isRightPassword = 0; 

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    isRightPassword  = Convert.ToInt16(dbReader["isRightPassword"].ToString());
                }
            }

            if(isRightPassword == 0)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";
                lblErrMessage.Text = "Entered current password is wrong. Please try again.";
                lblErrMessage.CssClass = "font_12Msg_Error";

                txtCurrentPassword.Text = "";
                txtNewPassword.Text = "";
                txtRetypePassword.Text = "";

                return 0;
            }
            else
            {
                //ChangePasword();
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                lblErrMessage.Text = "Password changed successfully. Your next login would be with new password.";
                lblErrMessage.CssClass = "font_12Msg_Success";
                btnSave.Visible = false;
                btnCancel.Visible = false;
                return 1;
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

    protected void ChangePasword()
    {

        string mCurrentPassword = txtCurrentPassword.Text;
        string newPassword = txtNewPassword.Text;
        //[usp_Password_Update_ByUserID] userid, currentPassword, NewPassword 
        //strSQL = "EXEC [usp_ChangePassword_Update] " + Session["MobileLoginID"].ToString() + ",'" + mCurrentPassword + "','" + newPassword + "'";
        strSQL = "EXEC esms.dbo.USPT_UpdatePassword '" + Session["MobileLoginID"].ToString() + "','" + newPassword + "'";
        int isError = 0;
        
        try
        {
            if (dbConn.State == ConnectionState.Closed)
            dbConn.Open();
           
            dbCmd1 = new SqlCommand(strSQL, dbConn);
            dbReader1 = dbCmd1.ExecuteReader();

            if (dbReader1.HasRows)
            {
                while (dbReader1.Read())
                {
                    isError = Convert.ToInt16(dbReader1["errorno"].ToString());
                }
            }


            if (isError == 0)
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

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        int isCurrentPwdChecked = 0;

        isCurrentPwdChecked = CheckCurrentPassword();

        //if (isCurrentPwdChecked == 1)
        //    ChangePasword(); 
    }


    //protected void btnSave_Click(object sender, EventArgs e)
    //{

    //    //get the entere values. 

    //    string mCurrentPassword = txtCurrentPassword.Text;
    //    string newPassword = txtNewPassword.Text;
    //    //[usp_Password_Update_ByUserID] userid, currentPassword, NewPassword 
    //    strSQL = "EXEC [usp_Password_Update_ByUserID] " + Convert.ToInt32(Session["UserID"]) + ",'" + mCurrentPassword + "','" +
    //                    newPassword + "'";

    //    int rowCount = 0;
        
    //    try
    //    {
    //        dbConn.Open();
           
    //        dbCmd = new SqlCommand(strSQL, dbConn);
    //        rowCount = dbCmd.ExecuteNonQuery();

           
    //   if (rowCount >= 1)
    //    {
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";
    //        lblErrMessage.Text = "Password changed successfully. Your next login would be with new password.";
    //        lblErrMessage.CssClass = "font_12Msg_Success";

            

    //    }
    //    else
    //    {
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //        lblErrMessage.Text = "Unable to complete the operation. Please contant Administrator";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //    }



    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        dbConn.Close();
    //    }




    //    if (rowCount >= 1)
    //    {
    //   // LoadPassword();
    //        txtCurrentPassword.Text = "";
    //    txtNewPassword.Text = "";
    //    txtRetypePassword.Text = "";
    //    }




    //}


    protected void btnCancel_Click(object sender, EventArgs e)
    {

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
