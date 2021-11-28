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
using System.IO;
using System.Data.SqlClient;
using RestSharp;
using RestSharp.Authenticators;

public partial class forgotPwd_Wassap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        newDBS clsObjNewDbs = new newDBS();
        DataSet ds;

        string vuserid = string.Empty;
        vuserid = txtLoginID.Text;

        ds = clsObjNewDbs.Wassap_getEmailPassword(vuserid.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow1 = ds.Tables[0].Rows[0];

            String userid = utRow1["ALogin"].ToString();
            String password = utRow1["Password"].ToString();
            String Email = utRow1["Email"].ToString();
            String fullname = utRow1["Member_Name"].ToString();
            string merid = utRow1["merid"].ToString();
            string mobile = utRow1["mobile"].ToString();

            if (userid == "")
            {
                CommonFunctions.AlertMessage("Invalid LoginId. Please provide LoginID");
            }
            else
            {
                String strMsg1 = "Hi " + fullname + ",";
                strMsg1 = strMsg1 + "<br><br>";
                strMsg1 = strMsg1 + "Please login at www.BigdataLogin.club to use the facilities. Your Login Deatails as follows:";
                strMsg1 = strMsg1 + "<br>";
                strMsg1 = strMsg1 + "LoginID: " + vuserid.ToString();
                strMsg1 = strMsg1 + "<br>";
                strMsg1 = strMsg1 + "Password: " + password;
                strMsg1 = strMsg1 + "<br><br><br>";
                strMsg1 = strMsg1 + "from";
                strMsg1 = strMsg1 + "<br>";
                strMsg1 = strMsg1 + "BigdataLogin.club Support Team";

                String Contact_EmailBody = strMsg1;

                DataSet dst = clsObjNewDbs.bigdata_sendSMS(merid.ToString(), mobile.ToString(), "Password Request.\nBigdataLogin.club\nLogin:" + userid.ToString() + "\nPassword:" + password.ToString());

                sendMail(Email, "noreply@ebooksmsdelivery.com", Contact_EmailBody, "BigdataLogin.Club", fullname, "", "");
            }
        }
        else
        {
            CommonFunctions.AlertMessage("Invalid LoginId. Please provide LoginID/Please consult your Sales Consultant. Thank You.");
        }
    }

    protected void sendMail(string VEmailTO, string VEmailFrom, string vEmailBody, string vEmailSubject, string vEmailToFullName, string vField1, string vField2)
    {
        string tmpHtmlBody = @"
    <html xmlns='http://www.w3.org/1999/xhtml'>
    <head>
    <title></title>
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

    </style>
</head>
<body>
    <div>
     <table cellpadding='0' cellspacing='0' width='600px' class='stdtableBorder_Main'>
        <tr height='0px'>
            <td width='3%'>
                </td>
            <td width='94%'>
                </td>
            <td width='3%'>
                </td>
        </tr>
        <tr>
            <td colspan='3' style='background-image: url(http://14.102.146.116/Images/ebImages/bookimgbanner.jpg); background-repeat: no-repeat; height: 100px;'>            
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>" + vEmailBody + @"</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr height='50px'>
        <td class='bkgFooter'>
                &nbsp;</td>
            <td align='right'class='bkgFooter'  valign='middle'>
                &nbsp; All Copyrights Reserved @2010
                </td>
                <td class='bkgFooter'>
                &nbsp;</td>
        </tr>
    </table>
    </div>
</body>
</html>";

        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-0ad485da45bb169cabfea074c9e87e2d");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "BigdataLogin.club <me@maildly.ebdvy.com>");
        request.AddParameter("to", VEmailTO);
        request.AddParameter("subject", vEmailSubject);
        request.AddParameter("html", tmpHtmlBody);
        request.Method = Method.POST;
        client.Execute(request);     

        //SmtpClient smtpClient = new SmtpClient();
        //MailMessage objMessage = new MailMessage();
        //string m_fromName = string.Empty;
        //try
        //{
        //    m_fromName = "EBookAdmin";
        //    MailAddress m_fromAddress = new MailAddress("noreply@ebooksmsdelivery.com", "EBookAdmin");
        //    smtpClient.Host = "127.0.0.1";
        //    smtpClient.Port = 25;
        //    objMessage.From = m_fromAddress;

        //    objMessage.To.Add(VEmailTO);
        //    objMessage.Subject = vEmailSubject;

        //    objMessage.IsBodyHtml = true;
        //    objMessage.Body = tmpHtmlBody;

        //    NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.Credentials = authinfo;

        //    smtpClient.Send(objMessage);
        //}
        //catch
        //{

        //}
        CommonFunctions.AlertMessageAndRedirect("Password sent to you Email", "Wassap.aspx");
    }

}