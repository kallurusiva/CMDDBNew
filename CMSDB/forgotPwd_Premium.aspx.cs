using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;



public partial class forgotPwd_Premium : System.Web.UI.Page
{
    string qPageType = string.Empty;
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL = string.Empty;



    protected void Page_Load(object sender, EventArgs e)
    {

        qPageType = Request.QueryString["PageType"];

        if(!IsPostBack)
        {
            lblSuccessMsg.Visible = false;
            lblMessage.Visible = false;
        }


       
    }

    protected void btnSendFpwd_Click(object sender, EventArgs e)
    {

       
        string vLoginID = string.Empty;

        string vEmailSubject = string.Empty;
        string vEmailFrom_Name = string.Empty;
        string vEmailFrom_Addr = string.Empty;


        switch (qPageType)
        {
            case "IOD":
                vLoginID = "PD" + txtloginID.Text;
                vEmailSubject = "1PREMIUMSMSIOD - PASSWORD REQUEST";
                vEmailFrom_Name = "1PREMIUMSMSIOD";
                vEmailFrom_Addr = "sms@smslogin.com";
                dbConn = new SqlConnection(ConfigurationManager.AppSettings["ABESTdb"].ToString());
                strSQL = "Select Login, Email, MCode,MPassword from  TMerchant_Details where  Login='" + vLoginID + "'";
                break;

            case "SUBSCRIBE":
                vLoginID = "SM" + txtloginID.Text;
                vEmailSubject = "1PREMIUMSMSSUBSCRIPTION - PASSWORD REQUEST";
                vEmailFrom_Name = "1PREMIUMSMSSUBSCRIPTION";
                vEmailFrom_Addr = "sms@smslogin.com";
                dbConn = new SqlConnection(ConfigurationManager.AppSettings["Luckydb"].ToString());

                strSQL = "Select Login,EMAIL,COMPANY,PASSWORD from T001_Account_Details where Login='" + vLoginID + "'";

                break;

            case "3WAY":
                vLoginID = "P3D" + txtloginID.Text;
                vEmailSubject = "1PREMIUMSMS3WAY - PASSWORD REQUEST";
                vEmailFrom_Name = "1PREMIUMSMS3WAY";
                vEmailFrom_Addr = "sms@smslogin.com";
                dbConn = new SqlConnection(ConfigurationManager.AppSettings["ABESTdb"].ToString());
                strSQL = "Select Login, Email, MCode,MPassword from  TMerchant_Details where  Login='" + vLoginID + "'";
                break;
        }



        dbConn.Open();
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        string vEmail = string.Empty;
        string vUserID = string.Empty;
        string vPassword = string.Empty;


        if (dbReader.HasRows)
        {

            while (dbReader.Read())
            {

                if (qPageType == "SUBSCRIBE")
                {
                    vEmail = dbReader["Email"].ToString();
                    vUserID = dbReader["Login"].ToString();
                    vPassword = dbReader["Password"].ToString();
                }
                else
                {
                    vEmail = dbReader["Email"].ToString();
                    vUserID = dbReader["Mcode"].ToString();
                    vPassword = dbReader["MPassword"].ToString();
                }
              

                //Sending Email 

                SmtpClient smtpClient = new SmtpClient();
                MailMessage objMessage = new MailMessage();
                string m_fromName = string.Empty;
                m_fromName = "EBookAdmin";

                MailAddress m_fromAddress = new MailAddress(vEmailFrom_Addr, "EBookAdmin");
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
                objMessage.Subject = vEmailSubject;

                // CC and BCC optional

                //objMessage.Bcc.Add("srihari@globalsurf.com.my");
               // objMessage.Bcc.Add("msri_hari@hotmail.com");

                //Body can be Html or text format

                //Specify true if it  is html message

               // smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;

                objMessage.IsBodyHtml = true;
                // Message body content
                //string m_MessageBody = "Your Registration at SMSentreprenuer.com is successful";

                string tmpHtmlBody = " ---------------------------------------------- </br></br>" +
                                     " Login ID :  " + txtloginID.Text + "</br>" +
                                     " Password :  " + vPassword + "</br>" +
                                     " ---------------------------------------------- </br></br>";
                
                objMessage.Body = tmpHtmlBody;

                // Send SMTP mail
                smtpClient.Send(objMessage);

                // lblStatus.Text = "Email successfully sent.";

                lblSuccessMsg.Visible = true;
                lblSuccessMsg.Text = "Password has been successfully sent to your Email Account. ";

                }

        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Invalid Login ID entered.  Please enter LoginID and try again.";
        }

        dbConn.Close();


    }
}
