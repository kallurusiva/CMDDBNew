using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;

public partial class EbSendEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int tmpStatus = -10;
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        CMSv3.BAL.MalaysiaSMS obj1Malaysia = new CMSv3.BAL.MalaysiaSMS();
        String tmpBookID = String.Empty;

        if (!IsPostBack)
        {
            if (Request.Form.Count > 0)
            {
                tmpBookID = Request.Form["hdn_BookID"].ToString().Trim();
                String tmpEmail = Request.Form["hdn_Email"].ToString().Trim();
                String tmpMID = Request.Form["hdn_MID"].ToString().Trim();

                DataSet ds = objEbook.EBOOK_GetBook2EmailDetails(tmpBookID);
                DataTable dt = ds.Tables[0];

                //Send Email
                if (dt.Rows.Count > 0)
                {
                    DataRow drow = dt.Rows[0];

                    String eBookTitle = drow["Title"].ToString();
                    String eBookName = drow["BookName"].ToString();
                    String eSubject = drow["eSubject"].ToString();
                    String eSenderEmailID = drow["esenderEmailID"].ToString();
                    String eMessage = drow["eMessage"].ToString();
                    String eAttachment = drow["eAttachment"].ToString();

                    eMessage = eMessage.Replace(Environment.NewLine, "<br/>");
                    string tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head >
                                <title></title>
                                <style type='text/css'>
                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
                                </style>
                                </head>
                                <body>
                                    <div id='dvEmail' class='dvemailBox'> 
                                    <div id='dvHeader' style='align-content: center;'>
                                            <img src='http://14.102.146.116/Images/ebImages/bookimgbanner.jpg' />
                                                    <br />
                                     </div>
                                    <div id='dvContent' style='font: bold 12px Verdana'>
                                    "
                               + eMessage +

                               @"
                                </div>
                                </div>
   
                            </body>
                            </html>
                            ";


                    //#region sending Email using HmailServer.

                    ////hMailServer.Application objApp_Hmail = new hMailServer.Application();

                    ////hMailServer.Message objMsg_Hmail = new hMailServer.Message();

                    ////objMsg_Hmail.AddRecipient("", tmpEmail);

                    ////objMsg_Hmail.From = eSenderEmailID;
                    ////objMsg_Hmail.FromAddress = eSenderEmailID;

                    

                    ////objMsg_Hmail.Subject = eSubject;
                    ////objMsg_Hmail.HTMLBody = tmpHtmlBody;

                    ////String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

                    ////if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment)))
                    ////{
                    ////    objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment)));
                    ////}

                    ////objMsg_Hmail.Save();
                    ////CommonFunctions.AlertMessage("Email has been Sent");
                    //#endregion


                    #region Sending mail using SmarterMail

                    String vEmailToName = tmpEmail;
                    String vEmailToAddress = tmpEmail;

                    String vEmailFromName = eSenderEmailID;
                    String VEmailFromAddress = eSenderEmailID;

                    String vEmailSubject = eSubject;
                    String sHtmlBody = tmpHtmlBody;


                    SmtpClient smtpClient = new SmtpClient();
                    MailMessage objMessage = new MailMessage();
                    string m_fromName = string.Empty;
                    try
                    {


                        m_fromName = "EBookAdmin";
                        VEmailFromAddress = "noreply@ebooksmsdelivery.com";

                        MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EBookAdmin");
                        smtpClient.Host = "localhost";
                        smtpClient.Port = 25;

                        objMessage.From = m_fromAddress;

                        objMessage.To.Add(vEmailToAddress);
                        objMessage.Subject = vEmailSubject;


                        objMessage.IsBodyHtml = true;
                        objMessage.Body = sHtmlBody;


                        String tmpeBookfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();


                        if (File.Exists(Server.MapPath(tmpeBookfileFolder + "/" + eAttachment)))
                        {
                            Attachment objAtt = new Attachment(Server.MapPath(tmpeBookfileFolder + "/" + eAttachment));
                            objMessage.Attachments.Add(objAtt);
                        }



                        //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
                        NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = authinfo;

                        // Send SMTP mail
                        smtpClient.Send(objMessage);



                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                    #endregion



                    //End
                    tmpStatus = obj1Malaysia.Insert_SEKEmailInfo(tmpMID, tmpBookID, "1", "0", "1", "0", "Ebook Name " + eBookName, eSubject, eMessage, eAttachment, tmpEmail);                    
                }                
            }

            Response.Redirect(@"http://183.81.165.110/WebApps/HitechSMS/m1/Ebook_Contact_Sendemail.aspx?StatusCode=" + tmpStatus + "&BookCode=" + tmpBookID);
        }
    }
}
