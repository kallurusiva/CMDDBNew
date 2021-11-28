using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Net;
using System.Net.Mail;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;

/// <summary>
/// Summary description for MgMail
/// </summary>
public class MgMail
{
	public MgMail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void sndMailEbook(string VEmailTO, string VEmailFrom, string vEmailSubject, string vEmailToFullName, string vField1, string vField2, string eAttachment, string eAttachment1, string eAttachment2, string eAttachment3, string eAttachment4, string bookImageURL, string eMessage, string bPassword)
    {
        String str = VEmailTO.ToUpper();
        int pos = str.IndexOf("GMAIL.", 0);
        //if (pos>=0)
        //{
        //    sndSmarterMail(VEmailTO, VEmailFrom, vEmailSubject, vEmailToFullName, vField1, vField2, eAttachment, eAttachment1, eAttachment2, eAttachment3, eAttachment4, bookImageURL, eMessage, bPassword);
        //}
        //else
        //{
        pos = str.IndexOf("YAHOO.", 0);
        //if (pos >= 0)
        //{
        //    sndSmarterMail(VEmailTO, VEmailFrom, vEmailSubject, vEmailToFullName, vField1, vField2, eAttachment, eAttachment1, eAttachment2, eAttachment3, eAttachment4, bookImageURL, eMessage, bPassword);
        //}
        //else
        //{
        sndMailgun(VEmailTO, VEmailFrom, vEmailSubject, vEmailToFullName, vField1, vField2, eAttachment, eAttachment1, eAttachment2, eAttachment3, eAttachment4, bookImageURL, eMessage, bPassword);
        //}
        //}
    }

    public static void sndSmarterMail(string VEmailTO, string VEmailFrom, string vEmailSubject, string vEmailToFullName, string vField1, string vField2, string eAttachment, string eAttachment1, string eAttachment2, string eAttachment3, string eAttachment4, string bookImageURL, string eMessage, string bPassword)
    {
        string tmpWebSiteName = GlobalVar.GetAnchorDomainName;
        string tmpHtmlBody = string.Empty;
        #region Sending mail using SmarterMail

        String vEmailToName = vEmailToFullName;
        String vEmailToAddress = VEmailTO;
        
        String VEmailFromAddress = VEmailFrom;

        SmtpClient smtpClient = new SmtpClient();
        MailMessage objMessage = new MailMessage();
        string m_fromName = string.Empty;

        eMessage = eMessage.Replace(Environment.NewLine, "<br/>");

        String BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + bookImageURL.Replace(" ", "%20") + "' />";

        //HttpContext.Current.Response.Write(eMessage + "<br>" + BookImageHtml);
        //HttpContext.Current.Response.End();

        tmpHtmlBody = @"
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

                       @"<br /><br />"

                       + "Password to open books: <div id='dvContent' style='font: bold 15px Verdana;color: red'>" + bPassword + "</div>" + 

                       @"<br /><br />
                                </div>
                            <div id='dvBookImage'>"

                       + BookImageHtml +

                            @"</div>


                                </div>
   
                            </body>
                            </html>
                            ";

        try
        {
            m_fromName = "EbookDelivery";
            VEmailFromAddress = "noreply@ebooksmsdelivery.com";

            MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EbookDelivery");
            smtpClient.Host = "localhost";
            smtpClient.Port = 25;
            objMessage.From = m_fromAddress;
            objMessage.To.Add(vEmailToAddress);
            objMessage.Subject = vEmailSubject;
            objMessage.IsBodyHtml = true;
            String tmpEbooks = String.Empty;
            String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
            //... Get the List of Books to be Attached. 
            // == ATTACHEMENT    1   ===

            if (eAttachment != "")
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment)))
                {
                    EBookPassword.CopyBookGeneratePassword(eAttachment, bPassword);
                    //Attachment objAtt = new Attachment(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment));
                    Attachment objAtt = new Attachment(@"E:Webs\PasswordeBooks\" + eAttachment);
                    objMessage.Attachments.Add(objAtt);
                }
            }
            if (eAttachment1 != "")
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment1)))
                {
                    EBookPassword.CopyBookGeneratePassword(eAttachment1, bPassword);
                    //Attachment objAtt1 = new Attachment(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment1));
                    Attachment objAtt1 = new Attachment(@"E:Webs\PasswordeBooks\" + eAttachment1);
                    objMessage.Attachments.Add(objAtt1);
                }
            }
            if (eAttachment2 != "")
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment2)))
                {
                    EBookPassword.CopyBookGeneratePassword(eAttachment2, bPassword);
                    //Attachment objAtt2 = new Attachment(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment2));
                    Attachment objAtt2 = new Attachment(@"E:Webs\PasswordeBooks\" + eAttachment2);
                    objMessage.Attachments.Add(objAtt2);
                }
            }
            if (eAttachment3 != "")
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment3)))
                {
                    EBookPassword.CopyBookGeneratePassword(eAttachment3, bPassword);
                    //Attachment objAtt3 = new Attachment(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment3));
                    Attachment objAtt3 = new Attachment(@"E:Webs\PasswordeBooks\" + eAttachment3);
                    objMessage.Attachments.Add(objAtt3);
                }
            }
            if (eAttachment4 != "")
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment4)))
                {
                    EBookPassword.CopyBookGeneratePassword(eAttachment4, bPassword);
                    //Attachment objAtt4 = new Attachment(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAttachment4));
                    Attachment objAtt4 = new Attachment(@"E:Webs\PasswordeBooks\" + eAttachment4);
                    objMessage.Attachments.Add(objAtt4);
                }
            }
            String sHtmlBody = tmpHtmlBody;
            objMessage.Body = sHtmlBody;
            //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
            NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = authinfo;
            // Send SMTP mail
            smtpClient.Send(objMessage);
        }
        catch (Exception ex)
        {
            //CommonFunctions.AlertMessage("Email Could not be Sent");
            HttpContext.Current.Response.Write(ex.Message);
        }
        finally
        {
            //CommonFunctions.AlertMessage("Email has been Sent");
        }
        #endregion
    }

    public static void sndMailgun(string VEmailTO, string VEmailFrom, string vEmailSubject, string vEmailToFullName, string vField1, string vField2, string eAttachment, string eAttachment1, string eAttachment2, string eAttachment3, string eAttachment4, string bookImageURL, string eMessage, string bPassword)
    {
        string tmpHtmlBody = string.Empty;
        String BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + bookImageURL + "' />";
        String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

        eMessage = eMessage.Replace(Environment.NewLine, "<br/>");
        
        tmpHtmlBody = @"
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
                       + eMessage.Replace("+", "%20") +
                        @"<br /><br />"

                       + "Password to open books: <div id='dvContent' style='font: bold 15px Verdana;color: red'>" + bPassword + "</div>" + 

                       @"<br /><br />
                                </div>
                            <div id='dvBookImage'>"

                       + BookImageHtml.Replace("+", "%20") +

                            @"</div>


                                </div>
   
                            </body>
                            </html>
                            ";

        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-0ad485da45bb169cabfea074c9e87e2d");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "EbookDelivery <me@maildly.ebdvy.com>");
        request.AddParameter("to", VEmailTO);
        //request.AddParameter("bcc", "kodur_siva@yahoo.com,kallurusiva@hotmail.com");
        request.AddParameter("subject", vEmailSubject);
        //request.AddParameter("text", "Testing some Mailgun awesomness!");
        request.AddParameter("html", tmpHtmlBody);

        if (eAttachment != "")
        {
            EBookPassword.CopyBookGeneratePassword(eAttachment, bPassword);
            //request.AddFile("attachment", Path.Combine(HttpContext.Current.Server.MapPath(tmpEbfileFolder), eAttachment), "multipart/form-data");
            request.AddFile("attachment", Path.Combine(@"E:Webs\PasswordeBooks\", eAttachment), "");
        }
        if (eAttachment1 != "")
        {
            EBookPassword.CopyBookGeneratePassword(eAttachment1, bPassword);
            //request.AddFile("attachment", Path.Combine(HttpContext.Current.Server.MapPath(tmpEbfileFolder), eAttachment1), "multipart/form-data");
            request.AddFile("attachment", Path.Combine(@"E:Webs\PasswordeBooks\", eAttachment1), "");
        }
        if (eAttachment2 != "")
        {
            EBookPassword.CopyBookGeneratePassword(eAttachment2, bPassword);
            //request.AddFile("attachment", Path.Combine(HttpContext.Current.Server.MapPath(tmpEbfileFolder), eAttachment2), "multipart/form-data");
            request.AddFile("attachment", Path.Combine(@"E:Webs\PasswordeBooks\", eAttachment2), "");
        }
        if (eAttachment3 != "")
        {
            EBookPassword.CopyBookGeneratePassword(eAttachment3, bPassword);
            //request.AddFile("attachment", Path.Combine(HttpContext.Current.Server.MapPath(tmpEbfileFolder), eAttachment3), "multipart/form-data");
            request.AddFile("attachment", Path.Combine(@"E:Webs\PasswordeBooks\", eAttachment3), "");
        }
        if (eAttachment4 != "")
        {
            EBookPassword.CopyBookGeneratePassword(eAttachment4, bPassword);
            //request.AddFile("attachment", Path.Combine(HttpContext.Current.Server.MapPath(tmpEbfileFolder), eAttachment4), "multipart/form-data");
            request.AddFile("attachment", Path.Combine(@"E:Webs\PasswordeBooks\", eAttachment4), "");
        }
        request.Method = Method.POST;
        client.Execute(request);     
    }

    public static void sndMailgunLinksTest(string vTranid, string pType, string optEmail)
    {
        String tmpHtmlBody = string.Empty;
        String BookImageHtml = string.Empty;
        String ebookLinksURL = string.Empty;
        String ebookLinks = "";
        String vEmailTo = string.Empty;
        String vEmailToFullName = string.Empty;
        String bookPassword = string.Empty;
        String vEmailSubject = "EBook Delivery - ";

        newDBS objDBS = new newDBS();
        DataSet dsBooks = objDBS.EmailEbook_getDetails(vTranid.ToString(), pType.ToString());
        DataTable dtInfo = dsBooks.Tables[0];

        if (dtInfo.Rows.Count > 0)
        {
            DataRow Drow = dtInfo.Rows[0];
            vEmailTo = Drow["email"].ToString();
            vEmailToFullName = Drow["name"].ToString();
            bookPassword = Drow["bookPassword"].ToString();
            vEmailSubject = vEmailSubject + Drow["ProductCode"].ToString();
        }

        if (optEmail != "")
        {
            vEmailTo = optEmail.ToString();
        }

        DataTable dtbooks = dsBooks.Tables[1];
        foreach (DataRow dRow in dtbooks.Rows)
        {
            String eBookID = dRow["BookID"].ToString();
            String eBookName = dRow["BookName"].ToString();
            String BookImage = dRow["ImageFileName"].ToString();
            ebookLinks = ebookLinks + dRow["bookURL"].ToString() + "<br/>";
            ebookLinksURL = dRow["bookURL"].ToString();
            BookImageHtml = BookImageHtml + " <img style='max-height: 205px; max-width: 165px;'  src='" + "http://14.102.146.116/DocumentRepository/eBookImages/" + HttpContext.Current.Server.HtmlEncode(BookImage) + "' />";
        }        
        
        String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

        ebookLinks = ebookLinks.Replace(Environment.NewLine, "<br/>");

        tmpHtmlBody = @"
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
                                            <div id='dvBookImage'>"

                       + BookImageHtml.Replace("+", "%20") +

                            @"</div>
                                     </div>
                                    <div id='dvContent' style='font: bold 12px Verdana'>"

                       + "Download eBook by the following Link: <br/><br/><a href='" + ebookLinksURL + "' target='_blank'>" + ebookLinks.Replace("+", "%20") + "</a>" + 
                        @"<br /><br />"

                       + "Password to open books: <div id='dvContent' style='font: bold 15px Verdana;color: red'>" + bookPassword + "</div>" +

                       @"<br /><br />
                                </div>


                                </div>
   
                            </body>
                            </html>
                            ";

        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-0ad485da45bb169cabfea074c9e87e2d");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "EbookDelivery <me@maildly.ebdvy.com>");
        request.AddParameter("to", vEmailTo);
        request.AddParameter("subject", vEmailSubject);
        request.AddParameter("html", tmpHtmlBody);        
        request.Method = Method.POST;
        client.Execute(request);     
    }

    public static void sndMailgunLinks(string vTranid, string pType, string optEmail)
    {
        string strSMSvalue = "http://gt.evenchise.biz/Emails/EBookEmail.aspx?vTranid=" + vTranid.ToString() + "&pType=" + pType.ToString() + "&optEmail=" + optEmail.ToString();
        var webRequest1 = WebRequest.Create(strSMSvalue.ToString());
        var responseStream1 = webRequest1.GetResponse().GetResponseStream();

//        String tmpHtmlBody = string.Empty;
//        String BookImageHtml = string.Empty;
//        String ebookLinksURL = string.Empty;
//        String ebookLinks = "";
//        String ebookHyperlink = "";
//        String vEmailTo = string.Empty;
//        String vEmailToFullName = string.Empty;
//        String bookPassword = string.Empty;
//        String vEmailSubject = "EBook Delivery - ";

//        newDBS objDBS = new newDBS();
//        DataSet dsBooks = objDBS.EmailEbook_getDetails(vTranid.ToString(), pType.ToString());
//        DataTable dtInfo = dsBooks.Tables[0];

//        if (dtInfo.Rows.Count > 0)
//        {
//            DataRow Drow = dtInfo.Rows[0];
//            vEmailTo = Drow["email"].ToString();
//            vEmailToFullName = Drow["name"].ToString();
//            bookPassword = Drow["bookPassword"].ToString();
//            vEmailSubject = vEmailSubject + Drow["ProductCode"].ToString();
//        }

//        if (optEmail != "")
//        {
//            vEmailTo = optEmail.ToString();
//        }

//        DataTable dtbooks = dsBooks.Tables[1];
//        foreach (DataRow dRow in dtbooks.Rows)
//        {
//            String eBookID = dRow["BookID"].ToString();
//            String eBookName = dRow["BookName"].ToString();
//            String BookImage = dRow["ImageFileName"].ToString();
//            ebookLinks = ebookLinks + dRow["bookURL"].ToString() + "<br/>";
//            ebookLinksURL = dRow["bookURL"].ToString();
//            ebookHyperlink = ebookHyperlink + dRow["bookHyperlink"].ToString() + "<br/><br/>";
//            BookImageHtml = BookImageHtml + " <img style='max-height: 205px; max-width: 165px;'  src='" + "http://183.81.165.117/DocumentRepository/eBookImages/" + HttpContext.Current.Server.HtmlEncode(BookImage) + "' />";
//        }

//        String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

//        ebookLinks = ebookLinks.Replace(Environment.NewLine, "<br/>");

//        tmpHtmlBody = @"
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
//                                            <div id='dvBookImage'>"

//                       + BookImageHtml.Replace("+", "%20") +

//                            @"</div>
//                                     </div>
//                                    <div id='dvContent' style='font: bold 12px Verdana'>"

//                       + "Download eBook by the following Link: <br/><br/>" + ebookHyperlink.Replace("+", "%20") +
//                        @"<br /><br />"

//                       + "Password to open books: <div id='dvContent' style='font: bold 15px Verdana;color: red'>" + bookPassword + "</div>" +

//                       @"<br /><br />
//                                </div>
//
//
//                                </div>
//   
//                            </body>
//                            </html>
//                            ";



//        RestClient client = new RestClient();
//        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
//        client.Authenticator =
//            new HttpBasicAuthenticator("api",
//                                        "key-0ad485da45bb169cabfea074c9e87e2d");
//        RestRequest request = new RestRequest();
//        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
//        request.Resource = "{domain}/messages";
//        request.AddParameter("from", "EbookDelivery <me@maildly.ebdvy.com>");
//        request.AddParameter("to", vEmailTo);
//        request.AddParameter("subject", vEmailSubject);
//        request.AddParameter("html", tmpHtmlBody);
//        request.Method = Method.POST;
//        client.Execute(request);
    }

    public static void chooseEmailSender(string vTranid, string pType, string optEmail)
    {
        string emailSender = "1";
        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.BillPlz_getGateway();
        if (dst.Tables[1].Rows.Count > 0)
        {
            emailSender = dst.Tables[1].Rows[0]["Email"].ToString();
        }
        if (emailSender.ToString() == "1")
        {
            sendEBookusingSmartermailLinks(vTranid, pType, optEmail);
        }
        else if (emailSender.ToString() == "2")
        {
            sendEBookusingMailgunLinks(vTranid, pType, optEmail);
        } 
    }

    public static void sendEBookusingMailgunLinks(string vTranid, string pType, string optEmail)
    {
        String tmpHtmlBody = string.Empty;
        String BookImageHtml = string.Empty;
        String ebookLinksURL = string.Empty;
        String ebookLinks = "";
        String ebookHyperlink = "";
        String vEmailTo = string.Empty;
        String vEmailToFullName = string.Empty;
        String bookPassword = string.Empty;
        String vEmailSubject = "EBook Delivery - ";
        String eBookID = string.Empty;
        String eBookName = string.Empty;
        String BookImage = string.Empty;

        newDBS objDBS = new newDBS();
        DataSet dsBooks = objDBS.EmailEbook_getDetails(vTranid.ToString(), pType.ToString());
        DataTable dtInfo = dsBooks.Tables[0];

        if (dtInfo.Rows.Count > 0)
        {
            DataRow Drow = dtInfo.Rows[0];
            vEmailTo = Drow["email"].ToString();
            vEmailToFullName = Drow["name"].ToString();
            bookPassword = Drow["bookPassword"].ToString();
            vEmailSubject = vEmailSubject + Drow["ProductCode"].ToString();
        }

        if (optEmail != "")
        {
            vEmailTo = optEmail.ToString();
        }

        DataTable dtbooks = dsBooks.Tables[1];
        foreach (DataRow dRow in dtbooks.Rows)
        {
            eBookID = dRow["BookID"].ToString();
            eBookName = dRow["BookName"].ToString();
            BookImage = dRow["ImageFileName"].ToString();
            ebookLinks = ebookLinks + dRow["bookURL"].ToString() + "<br/>";
            ebookLinksURL = dRow["bookURL"].ToString();
            ebookHyperlink = ebookHyperlink + dRow["bookHyperlink"].ToString() + "<br/><br/>";
            BookImageHtml = BookImageHtml + " <img style='max-height: 250px; max-width: 200px;'  src='" + "http://14.102.146.116/DocumentRepository/eBookImages/" + HttpContext.Current.Server.HtmlEncode(BookImage) + "' />";
        }

        String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

        ebookLinks = ebookLinks.Replace(Environment.NewLine, "<br/>");

        tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head >
                                <title></title>
                                <style type='text/css'>
                                    .dvemailBox {border: 3px solid #BAC0C7;  padding: 15px;
                                        height: 500px;
                                        width: 1198px;
                                    }
                                    .auto-style1 {
                                        width: 71%;
                                    }
                                    .auto-style2 {
                                        width: 170%;
                                    }
                                    .auto-style3 {
                                    }
                                    .auto-style4 {
                                        color: rgb(204, 0, 0);
                                    }
                                    .auto-style5 {
                                        width: 338px;
                                    }
                                    </style>
                                </head>
                                <body style='height: 358px; width: 1195px; margin-right: 8px'>
                                    
<div id='dvEmail' class='dvemailBox'> 
                                    <table class='auto-style1'>
                                        <tr>
                                            <td class='auto-style5'>
                                                " + BookImageHtml + @" </td>
                                            <td>
                                                <table class='auto-style2'>
                                                    <tr>
                                                        <td class='auto-style3' colspan='2'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>
                                                            Thank You for purchasing an EBook. Your purchased EBook details as follows:</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>EBook Code</span></td>
                                                        <td><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>EA" + eBookID + @"1149</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>EBook Name</span></td>
                                                        <td><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>" + eBookName + @"</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3' colspan='2'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>
                                                            please use the following URL to download EBook and use the following Password to open your EBook.<br />
                                                            </span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>Download at</span></td>
                                                        <td>
                                                            <a href='" + ebookLinksURL + @"' target=_blank>
                                                                <span style=color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;>
                                                                    " + ebookLinksURL + @"

                                                                </span>

                                                            </a>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class=auto-style3><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>EBook Password<br />
                                                            </span></td>
                                                        <td><span style='font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;' class='auto-style4'>" + bookPassword + @"</span><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'> </span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3' colspan='2'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>from<br />
                                                            evenchise.com support team</span></td>
                                                    </tr>
                                                </table>
                                            </td>
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
        request.AddParameter("from", "EbookDelivery <me@maildly.ebdvy.com>");
        request.AddParameter("to", vEmailTo);
        request.AddParameter("subject", vEmailSubject);
        request.AddParameter("html", tmpHtmlBody);
        request.Method = Method.POST;
        client.Execute(request);
    }

    public static void sendEBookusingSmartermailLinks(string vTranid, string pType, string optEmail)
    {
        String tmpHtmlBody = string.Empty;
        String BookImageHtml = string.Empty;
        String ebookLinksURL = string.Empty;
        String ebookLinks = "";
        String ebookHyperlink = "";
        String vEmailTo = string.Empty;
        String vEmailToFullName = string.Empty;
        String bookPassword = string.Empty;
        String vEmailSubject = "EBook Delivery - ";
        String eBookID = string.Empty;
        String eBookName = string.Empty;
        String BookImage = string.Empty;

        newDBS objDBS = new newDBS();
        DataSet dsBooks = objDBS.EmailEbook_getDetails(vTranid.ToString(), pType.ToString());
        DataTable dtInfo = dsBooks.Tables[0];

        if (dtInfo.Rows.Count > 0)
        {
            DataRow Drow = dtInfo.Rows[0];
            vEmailTo = Drow["email"].ToString();
            vEmailToFullName = Drow["name"].ToString();
            bookPassword = Drow["bookPassword"].ToString();
            vEmailSubject = vEmailSubject + Drow["ProductCode"].ToString();
        }

        if (optEmail != "")
        {
            vEmailTo = optEmail.ToString();
        }

        DataTable dtbooks = dsBooks.Tables[1];
        foreach (DataRow dRow in dtbooks.Rows)
        {
            eBookID = dRow["BookID"].ToString();
            eBookName = dRow["BookName"].ToString();
            BookImage = dRow["ImageFileName"].ToString();
            ebookLinks = ebookLinks + dRow["bookURL"].ToString() + "<br/>";
            ebookLinksURL = dRow["bookURL"].ToString();
            ebookHyperlink = ebookHyperlink + dRow["bookHyperlink"].ToString() + "<br/><br/>";
            BookImageHtml = BookImageHtml + " <img style='max-height: 250px; max-width: 200px;'  src='" + "http://14.102.146.116/DocumentRepository/eBookImages/" + HttpContext.Current.Server.HtmlEncode(BookImage) + "' />";
        }

        String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

        ebookLinks = ebookLinks.Replace(Environment.NewLine, "<br/>");

        tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head >
                                <title></title>
                                <style type='text/css'>
                                    .dvemailBox {border: 3px solid #BAC0C7;  padding: 15px;
                                        height: 500px;
                                        width: 1198px;
                                    }
                                    .auto-style1 {
                                        width: 71%;
                                    }
                                    .auto-style2 {
                                        width: 170%;
                                    }
                                    .auto-style3 {
                                    }
                                    .auto-style4 {
                                        color: rgb(204, 0, 0);
                                    }
                                    .auto-style5 {
                                        width: 338px;
                                    }
                                    </style>
                                </head>
                                <body style='height: 358px; width: 1195px; margin-right: 8px'>
                                    
<div id='dvEmail' class='dvemailBox'> 
                                    <table class='auto-style1'>
                                        <tr>
                                            <td class='auto-style5'>
                                                " + BookImageHtml + @" </td>
                                            <td>
                                                <table class='auto-style2'>
                                                    <tr>
                                                        <td class='auto-style3' colspan='2'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>
                                                            Thank You for purchasing an EBook. Your purchased EBook details as follows:</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>EBook Code</span></td>
                                                        <td><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>EA" + eBookID + @"1149</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>EBook Name</span></td>
                                                        <td><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>" + eBookName + @"</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3' colspan='2'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>
                                                            please use the following URL to download EBook and use the following Password to open your EBook.<br />
                                                            </span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>Download at</span></td>
                                                        <td>
                                                            <a href='" + ebookLinksURL + @"' target=_blank>
                                                                <span style=color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;>
                                                                    " + ebookLinksURL + @"

                                                                </span>

                                                            </a>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class=auto-style3><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>EBook Password<br />
                                                            </span></td>
                                                        <td><span style='font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;' class='auto-style4'>" + bookPassword + @"</span><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'> </span></td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3'>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class='auto-style3' colspan='2'><span style='color: rgb(136, 136, 136); font-family: Arial, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;'>from<br />
                                                            evenchise.com support team</span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        </table>
   </div>
                            </body>
                            </html>";

        //Response.Write(tmpHtmlBody.ToString());

        SmtpClient smtpClient = new SmtpClient();
        MailMessage objMessage = new MailMessage();
        string m_fromName = string.Empty;
        try
        {
            m_fromName = "EBook Delivery";
            MailAddress m_fromAddress = new MailAddress("delivery@gsprocess.com", m_fromName);
            smtpClient.Host = "smtp.gsprocess.com";
            //smtpClient.Host = "127.0.0.1";
            smtpClient.Port = 25;
            objMessage.From = m_fromAddress;

            objMessage.To.Add(vEmailTo);
            objMessage.Subject = vEmailSubject;

            objMessage.IsBodyHtml = true;
            objMessage.Body = tmpHtmlBody;

            objMessage.BodyEncoding = System.Text.Encoding.UTF8;
            objMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            NetworkCredential authinfo = new NetworkCredential("delivery@gsprocess.com", "gsurf123");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = authinfo;

            smtpClient.Send(objMessage);
        }
        catch
        {

        }

    }

    public static void sndMailgunLinksRedirect(string vTranid, string pType, string optEmail)
    {
        string strSMSvalue = "http://gt.evenchise.biz/Emails/EBookEmail.aspx?vTranid=" + vTranid.ToString() + "&pType=" + pType.ToString() + "&optEmail=" + optEmail.ToString();

        var webRequest1 = WebRequest.Create(strSMSvalue.ToString());
        var responseStream1 = webRequest1.GetResponse().GetResponseStream();

        //HttpWebRequest WebReq = null;
        //HttpWebResponse WebResp;

        //WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
        //WebReq.Method = "GET";
        //WebResp = (HttpWebResponse)WebReq.GetResponse();
        //if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
        //{
        //    Stream _Answer = WebResp.GetResponseStream();
        //    StreamReader Answer = new StreamReader(_Answer);
        //    String strTemp = Answer.ReadToEnd();
        //}
     
    }

}