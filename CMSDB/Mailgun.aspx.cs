using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;
using System.Configuration;

public partial class Mailgun : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         SendMail();
        Response.Write("Done");
    }

     public void SendMail()
    {
        string eMessage = "Testing some Mailgun awesomness!";
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

        var path1 = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        var fileName = "8645_Buku 1 UPSR.pdf";
        
        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-0ad485da45bb169cabfea074c9e87e2d");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "Siva <me@maildly.ebdvy.com>");
        request.AddParameter("to", "kallurusiva@gmail.com");
        request.AddParameter("bcc", "kodur_siva@yahoo.com,kallurusiva@hotmail.com");
        request.AddParameter("subject", "siva - mailgun");
        //request.AddParameter("text", "Testing some Mailgun awesomness!");
        request.AddParameter("html", tmpHtmlBody);
        request.AddFile("attachment", Path.Combine(Server.MapPath(path1), fileName), "multipart/form-data");
        request.Method = Method.POST;
        client.Execute(request);        
    }
}