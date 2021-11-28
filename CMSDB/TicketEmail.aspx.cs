using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;

public partial class TicketEmail : System.Web.UI.Page
{

    string TID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["TID"] != null)
                {
                    TID = Request.QueryString["TID"].ToString();
                }
            }
            ViewState["TID"] = TID;

            newDBS ndbs = new newDBS();
            DataSet ds = ndbs.Ticket_getEmailDetails(TID.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                string vMobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                string vEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                string vTDate = ds.Tables[0].Rows[0]["TDate"].ToString();
                string vCode = ds.Tables[0].Rows[0]["tCode"].ToString();
                string VName = ds.Tables[0].Rows[0]["tName"].ToString();
                string VImage = ds.Tables[0].Rows[0]["tImage"].ToString();
                string vEmailAddedInfo = ds.Tables[0].Rows[0]["tEmailAddedInfo"].ToString();
                string downloadURL = "http://www.vtdvy.com/VT/?E" + TID.ToString();
                string emailBranding = ds.Tables[0].Rows[0]["emailBranding"].ToString();

                string eMessage = "";
                string vEmailSubject = "Ticket Delivery";
                if (emailBranding.ToString() != "") { vEmailSubject = emailBranding + " - " + "Ticket Delivery"; }

                string tmpHtmlBody = string.Empty;
                String tmpEbfileFolder = "http://183.81.165.117/DocumentRepository/Ticket/";
                string BookImageURL = tmpEbfileFolder + VImage.ToString();
                String BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL.Replace(" ", "%20") + "' />";

                eMessage = eMessage.Replace(Environment.NewLine, "<br/>");
                eMessage = eMessage + "Ticket Code: " + vCode.ToString() + "<br>";
                eMessage = eMessage + "Ticket Name: " + VName.ToString() + "<br>";
                eMessage = eMessage + "Purchased On: " + vTDate.ToString() + "<br>";
                eMessage = eMessage + "Receipt No: " + ViewState["TID"].ToString() + "<br>";
                eMessage = eMessage + "<br><br>";
                eMessage = eMessage + vEmailAddedInfo.ToString() + "<br>";

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
                                            <img src='http://183.81.165.117/Images/ebImages/bookimgbanner.jpg' />
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

                               + BookImageHtml +

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
                request.AddParameter("from", "Ticket Delivery <me@maildly.ebdvy.com>");
                request.AddParameter("to", vEmail);
                //request.AddParameter("bcc", "kodur_siva@yahoo.com,kallurusiva@hotmail.com");
                request.AddParameter("subject", vEmailSubject);
                //request.AddParameter("text", "Testing some Mailgun awesomness!");
                request.AddParameter("html", tmpHtmlBody);

                request.Method = Method.POST;
                client.Execute(request);


            }


        }
    }
}