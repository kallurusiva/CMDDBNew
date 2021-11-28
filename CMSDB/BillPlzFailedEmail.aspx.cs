using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Net;
using System.Net.Mail;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;

public partial class BillPlzFailedEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string nameTo = Request.QueryString["name"].ToString();
        string emailTo = Request.QueryString["email"].ToString();
        string productCode = Request.QueryString["productcode"].ToString();
        string domain = Request.QueryString["domain"].ToString();

        sndMailgun(emailTo, nameTo, productCode,domain);
    }

    public static void sndMailgun(string VEmailTO, string vEmailToFullName, string vProductCode, string vDomain)
    {
        string tmpHtmlBody = string.Empty;
        string vEmailSubject = "EBook Delivery";
        string eMessage = "Your Purchase Transaction for EBook: " + vProductCode.ToString() + " through BillPlz was Failed at " + vDomain + ".";
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

                       + 

                       @"<br /><br />
                                </div>
                            "

                       +

                            @"


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

        
        request.Method = Method.POST;
        client.Execute(request);
    }
}