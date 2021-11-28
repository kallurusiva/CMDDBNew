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
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

public partial class LifeReportEmailTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dob = string.Empty;
        string Email = string.Empty;
        string FName = string.Empty;
        string TID = string.Empty;

        dob = Request.QueryString["DOB"].ToString();
        Email = Request.QueryString["Email"].ToString();
        FName = Request.QueryString["FName"].ToString();
        TID = Request.QueryString["TID"].ToString();

        string eMessage = FName.ToString() + " Life Report. Date of Birth: " + dob.ToString();
        string BookImageHtml = "http://www.happysamebooks.com/images/NumerologyDisp.jpg";
        String vEmailSubject = FName.ToString() + " Life Report";

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
                                            <img src='http://www.happysamebooks.com/images/NumerologyDisp.jpg' />
                                                    <br />
                                     </div>
                                    <div id='dvContent' style='font: bold 12px Verdana'>
                                    "
                           + eMessage.Replace("+", "%20") +
                            @"<br /><br />"

                           +

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
        request.AddParameter("from", "LifeReport <me@maildly.ebdvy.com>");
        request.AddParameter("to", Email);
        request.AddParameter("subject", vEmailSubject);
        request.AddParameter("text", "Congratulation!! Attached is your Numerology Life Report");

        String eAttachment = TID + ".pdf";
        request.AddFile("attachment", Path.Combine(@"C:\inetpub\wwwroot\WebApps\NReportPDF\pdfRepository", eAttachment), "");

        request.Method = Method.POST;
        client.Execute(request);


    }
}