using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;


public partial class TestEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //fnSendEmailHTML();
        fnSendHmail(); 
    }


    protected void fnSendHmail()
    {
        hMailServer.Application objApp_Hmail = new hMailServer.Application();

        objApp_Hmail.Authenticate("Administrator", "X943!8j2");
        objApp_Hmail.Connect();


        hMailServer.Message objMsg_Hmail = new hMailServer.Message();


        objMsg_Hmail.AddRecipient("Sri Hari", "hari.meena@gmail.com");
        objMsg_Hmail.From = "info@1smsbusiness.com";
        objMsg_Hmail.FromAddress = "mail@globaluser.small-dns.net";

        objMsg_Hmail.Subject = "Test mail by Hari at " + DateTime.Now.ToString();
        objMsg_Hmail.HTMLBody = " Please ignore this Mail.   Testing Email ";
        objMsg_Hmail.Save();


    }


    protected void fnSendEmailHTML()
    {

    //     protected void fnSendEmailHTML(string VEmailTO, string VEmailFrom, string vEmailBody, string vEmailSubject, string vEmailToFullName, string vField1, string vField2)


        string VEmailTO = "hari.meena@gmail.com";
        string vEmailFrom = string.Empty;
        string vEmailSubject = "1mal subject " + DateTime.Now;
        string vEmailToFullName = "1mal User";
        string vEmailBody = " Testing email for Local server ";



        string tmpHtmlBody = @"
     <html xmlns='http://www.w3.org/1999/xhtml'>
<head >
    <title></title>
    <style type='text/css'>
        .style2        {            height: 18px;        }
        .font_12BlueBold	{ FONT-SIZE: 12px;  font-weight:bold; COLOR: #2291A1; height:25px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .font_12Normal		{ FONT-SIZE: 12px; COLOR: #03C0C6; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .stdtableBorder_Main		{ background-color:#FAFCFA; border: #CDF2D6 1px solid; FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
        .bkgFooter		    {background-color:#FAFCFA;
                  		     filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FAFCFA', endColorstr='#FFFFFF'); /* for IE */
                            background: -webkit-gradient(linear, left top, left bottom, from(#FAFCFA), to(#FFFFFF)); /* for webkit browsers */
                            background: -moz-linear-gradient(top,  #FAFCFA,  #FFFFFF); /* for firefox 3.6+ */ 
                  		     }
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
            <td colspan='3' style='background-image: url(Images/Mail/header1_green.jpg); background-repeat: no-repeat; height: 100px;'>
            
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
            <td>
                Hi <font class='font_12BlueBold'>" + vEmailToFullName + @" </font>,</td>
            <td>
                &nbsp;</td>
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
            <td>
                Greetings from 1SMSBusiness.com</td>
            <td>
                &nbsp;</td>
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
            <td>"  + vEmailBody  +
            @"</td>
            <td>
                &nbsp;</td>
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
            <td>
                Thank you,<br />
                Support Team @ 1SMSBusiness.com</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class='bkgFooter' height='50px'>
        <td>
                &nbsp;</td>
            <td align='right'  valign='middle'>
                &nbsp; All Copyrights Reserved @2010
                </td>
                <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
</body>
</html>";



        SmtpClient smtpClient = new SmtpClient();
        MailMessage objMessage = new MailMessage();

        try
        {

            MailAddress m_fromAddress = new MailAddress("mail@globalsuer.small-dns.net","ADMINISTRATOR");
            // You can specify the host name or ipaddress of your server

            // Default in IIS will be localhost 
            //smtpClient.Host = "localhost";
            smtpClient.Host = "127.0.0.1";

            //Default port will be 25
            smtpClient.Port = 25;

            //From address will be given as a MailAddress Object
            objMessage.From = m_fromAddress;

            // To address collection of MailAddress

            objMessage.To.Add(VEmailTO);
            objMessage.Subject = vEmailSubject;

            // CC and BCC optional

            // MailAddressCollection class is used to send the email to various users

            // You can specify Address as new MailAddress("admin1@yoursite.com")

            //objMessage.CC.Add("admin1@yoursite.com");
            //objMessage.CC.Add("admin2@yoursite.com");

            // You can specify Address directly as string

            //objMessage.Bcc.Add(new MailAddress("admin3@yoursite.com"));
            //objMessage.Bcc.Add(new MailAddress("admin4@yoursite.com"));

            objMessage.Bcc.Add("msri_hari@yahoo.com");
            
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
