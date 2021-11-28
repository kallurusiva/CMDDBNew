using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for MyMail
/// </summary>
public class MyMail
{
    public MyMail()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static void CommonSendEmail(string VEmailTO, string VEmailFrom, string vEmailBody, string vEmailSubject, string vEmailToFullName, string vField1, string vField2)
    {

        string tmpWebSiteName = GlobalVar.GetAnchorDomainName;

        string tmpHtmlBody = @"
     <html xmlns='http://www.w3.org/1999/xhtml'>
<head >
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
            <td colspan='3' style='background-image: url(http://www.1smsbusiness.com/Images/Mail/header1_green.jpg); background-repeat: no-repeat; height: 100px;'>
            
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
                <td style='white-space:nowrap; width: 200px;'>
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
        </tr> "

            + vField1 + 

        @"<tr>
            <td>
                &nbsp;</td>
            <td>" + vEmailBody +
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
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
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


        String ChkHostString = ConfigurationManager.AppSettings["HostingServer"].ToString();

       
            #region Commented the Earlier email sending Code


            SmtpClient smtpClient = new SmtpClient();
            MailMessage objMessage = new MailMessage();
            string m_fromName = string.Empty;
            try
            {
                if (vField2 == "fromSystemNEWS")
                {
                    m_fromName = "EBookAdmin";
                }
                else
                {
                    m_fromName = vEmailToFullName;
                }
                MailAddress m_fromAddress = new MailAddress("noreply@ebooksmsdelivery.com", "EBookAdmin");
                smtpClient.Host = "127.0.0.1";
                smtpClient.Port = 25;
                objMessage.From = m_fromAddress;
                objMessage.To.Add(VEmailTO);
                objMessage.Subject = vEmailSubject;
                objMessage.Bcc.Add("siva@globalsurf.com.my");
                objMessage.IsBodyHtml = true;
                objMessage.Body = tmpHtmlBody;
                smtpClient.Send(objMessage);
            }
            catch
            {

            }

            #endregion
    }

}
