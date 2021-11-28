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

public partial class EbSendBook : System.Web.UI.Page
{
    String qMID = string.Empty;
    String qBookID = string.Empty;
    String qFullName = string.Empty;
    String qEmail = string.Empty;
    string qKeyword = string.Empty;
    string qPassword = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString.Count> 0)
            {
                CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

                 qMID = Request.QueryString["qMID"];
                 qBookID = Request.QueryString["qBookID"];
                 qFullName = Request.QueryString["qFullName"];
                 qEmail = Request.QueryString["qEmail"];
                 qKeyword = Request.QueryString["qKeyword"];
                 qPassword = Request.QueryString["bPwd"];

                 EBookEmailCentral.getTransactionDetails(qEmail, qFullName, qKeyword, "", "", qBookID, qPassword);
            }
            else
            {
                Response.Write("Invalid or wrong parameters passed"); 
            }
        }
    }

    protected void Send_Ebook(String vBookID)
    {
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.EBOOK_GetBook2EmailDetails(vBookID);
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow drow = dt.Rows[0];

            String eSubject = drow["eSubject"].ToString();
            String eSenderEmailID = drow["esenderEmailID"].ToString();
            String eMessage = drow["eMessage"].ToString();
            String eAttachment = drow["eAttachment"].ToString();
            String BookImage = drow["ImageFileName"].ToString();
            String BookImageURL = "http://14.102.146.116/DocumentRepository/eBookImages/" + BookImage;
            String BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL + "' />";

            eMessage = eMessage.Replace(Environment.NewLine, "<br/>");
            MgMail.sndMailEbook(qEmail, eSenderEmailID, qKeyword + "-" + qBookID + "-" + eSubject, qFullName, "", "", eAttachment, "", "", "", "", BookImageURL, eMessage,"123456");    
        }

    }


    protected void Send_ValueBuy_Ebook(String vBookID)
    {

        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.EBOOK_GetBook2EmailDetails2(vBookID);
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow drow = dt.Rows[0];

            String eSubject = drow["eSubject"].ToString();
            String eSenderEmailID = drow["esenderEmailID"].ToString();
            String eMessage = drow["eMessage"].ToString();
            String eAttachment1 = drow["eAttachment1"].ToString();
            String eAttachment2 = drow["eAttachment2"].ToString();
            String eAttachment3 = drow["eAttachment3"].ToString();
            String eAttachment4 = drow["eAttachment4"].ToString();
            String eAttachment5 = drow["eAttachment5"].ToString();

            eMessage = eMessage.Replace(Environment.NewLine, "<br/>");
            MgMail.sndMailEbook(qEmail, eSenderEmailID, qKeyword + "-" + qBookID + "-" + eSubject, qFullName, "", "", eAttachment1, eAttachment2, eAttachment3, eAttachment4, eAttachment5, "", eMessage,"123456");


//            string tmpHtmlBody = @"
//                                <html xmlns='http://www.w3.org/1999/xhtml'>
//                                <head >
//                                <title></title>
//                                <style type='text/css'>
//                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
//                                </style>
//                                </head>
//                                <body>
//                                    <div id='dvEmail' class='dvemailBox'> 
//                                    <div id='dvHeader' style='align-content: center;'>
            //                                            <img src='http://14.102.146.116/Images/ebImages/bookimgbanner.jpg' />
//                                                    <br />
//                                     </div>
//                                    <div id='dvContent' style='font: bold 12px Verdana'>
//                                    "
//                       + eMessage +

//                       @"
//                                </div>
//                                </div>
//   
//                            </body>
//                            </html>
//                            ";


  
            #region Sending mail using SmarterMail

            //String vEmailToName = qFullName;
            //String vEmailToAddress = qEmail;

            //String vEmailFromName = eSenderEmailID;
            //String VEmailFromAddress = "mail@globauser.small-dns.net"; 

            //String vEmailSubject = eSubject;



            //SmtpClient smtpClient = new SmtpClient();
            //MailMessage objMessage = new MailMessage();
            //string m_fromName = string.Empty;
            //try
            //{


            //    m_fromName = "EBookAdmin";
            //    VEmailFromAddress = "noreply@ebooksmsdelivery.com";

            //    MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EBookAdmin");
            //    smtpClient.Host = "localhost";
            //    smtpClient.Port = 25;

            //    objMessage.From = m_fromAddress;

            //    objMessage.To.Add(vEmailToAddress);
            //    objMessage.Subject = qKeyword + "-" + qBookID + "-" + vEmailSubject;


            //    objMessage.IsBodyHtml = true;



            //    String tmpEbooks = String.Empty;
            //    String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
            //    //... Get the List of Books to be Attached. 



            //    // == ATTACHEMENT    1   ===

            //    if (eAttachment1 != "")
            //    {
            //        if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment1)))
            //        {
            //            Attachment objAtt1 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment1));
            //            objMessage.Attachments.Add(objAtt1);
            //            //objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment1)));
            //        }
            //    }

            //    // == ATTACHEMENT    2   ===
            //    if (eAttachment2 != "")
            //    {
            //        if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment2)))
            //        {
            //            Attachment objAtt2 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment2));
            //            objMessage.Attachments.Add(objAtt2);
            //            //objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment2)));
            //        }
            //    }

            //    // == ATTACHEMENT    3   ===
            //    if (eAttachment3 != "")
            //    {
            //        if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment3)))
            //        {
            //            Attachment objAtt3 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment3));
            //            objMessage.Attachments.Add(objAtt3);
            //           // objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment3)));
            //        }
            //    }

            //    // == ATTACHEMENT    4   ===
            //    if (eAttachment4 != "")
            //    {
            //        if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment4)))
            //        {
            //            Attachment objAtt4 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment4));
            //            objMessage.Attachments.Add(objAtt4);
            //           // objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment4)));
            //        }
            //    }

            //    // == ATTACHEMENT    5   ===
            //    if (eAttachment5 != "")
            //    {
            //        if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment5)))
            //        {
            //            Attachment objAtt5 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment5));
            //               objMessage.Attachments.Add(objAtt5);

            //            //objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment5)));
            //        }
            //    }


              

            //    String sHtmlBody = tmpHtmlBody;
            //    objMessage.Body = sHtmlBody;

            //    //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
            //    NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
            //    smtpClient.UseDefaultCredentials = false;
            //    smtpClient.Credentials = authinfo;

            //    // Send SMTP mail
            //    smtpClient.Send(objMessage);


              



            //}
            //catch (Exception ex)
            //{
            //    CommonFunctions.AlertMessage("Email Could not be Sent");
            //    Response.Write(ex.Message); 

            //}
            //finally
            //{
            //    CommonFunctions.AlertMessage("Email has been Sent");
            //}
            #endregion

        }

    }

}