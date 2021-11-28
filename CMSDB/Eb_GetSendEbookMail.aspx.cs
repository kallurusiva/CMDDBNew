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


public partial class Eb_GetSendEbookMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int tmpStatus = -10;
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        CMSv3.BAL.MalaysiaSMS obj1Malaysia = new CMSv3.BAL.MalaysiaSMS();

        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                String tmpBookID = Request.QueryString["tmpBookID"].ToString().Trim();
                String tmpEmail = Request.QueryString["tmpEmail"].ToString().Trim();
                String tmpMID = Request.QueryString["tmpMID"].ToString().Trim();

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
                                            <img src='http://210.5.45.8/Images/ebImages/bookimgbanner.jpg' />
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
                    #region sending Email using HmailServer.

                    hMailServer.Application objApp_Hmail = new hMailServer.Application();

                    hMailServer.Message objMsg_Hmail = new hMailServer.Message();

                    objMsg_Hmail.AddRecipient("", tmpEmail);

                    objMsg_Hmail.From = eSenderEmailID;
                    objMsg_Hmail.FromAddress = eSenderEmailID;

                    objMsg_Hmail.Subject = eSubject;
                    objMsg_Hmail.HTMLBody = tmpHtmlBody;

                    String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

                    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment)))
                    {
                        objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment)));
                    }

                    objMsg_Hmail.Save();
                    //CommonFunctions.AlertMessage("Email has been Sent");
                    #endregion

                    //End
                    tmpStatus = obj1Malaysia.Insert_SEKEmailInfo(tmpMID, tmpBookID, "1", "0", "1", "0", "Ebook Name " + eBookName, eSubject, eMessage, eAttachment, tmpEmail);
                }
            }
            Response.Write(tmpStatus);
        }
    }
}