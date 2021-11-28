using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using RestSharp;
using RestSharp.Authenticators;

public partial class vVoucher : System.Web.UI.Page
{
    string glbFrom;
    string glbText;
    string glbMsgID;
    string glbSCode;
    //string glbTelcoID;
    string prmMessage;

    string glbVCode;
    string glbEmail;
    string glbFullName;
    string glbCName;

    //string glbDay;
    //string glbMonth;
    //string glbYear;

    protected void Page_Load(object sender, EventArgs e)
    {
        glbFrom = Request.QueryString["Mobile"].ToString().Trim();
        glbText = Request.QueryString["message"].ToString().Trim();
        glbMsgID = Request.QueryString["msgid"].ToString().Trim();
        glbSCode = Request.QueryString["shortcode"].ToString().Trim();
        //glbTelcoID = Request.QueryString["telcoid"].ToString().Trim();

        prmMessage = glbText.ToString();

        prmMessage = prmMessage.ToString().Replace("\r", " ");
        prmMessage = prmMessage.ToString().Replace("\n", " ");
        prmMessage = prmMessage.ToString().Replace("'", " ");
        prmMessage = prmMessage.ToString().Replace("  ", " ");
        prmMessage = prmMessage.ToString().Replace("  ", " ");

        string[] arrMessage = prmMessage.Split(' ');

        glbVCode = "";
        glbEmail = "";
        glbFullName = "";
        glbCName = "";

        if (arrMessage.Length > 1) { glbVCode = arrMessage[1]; }
        if (arrMessage.Length > 2) { glbEmail = arrMessage[2]; }
        if (arrMessage.Length > 3) { glbFullName = arrMessage[3]; }
        if (arrMessage.Length > 4) { glbFullName = glbFullName + " " + arrMessage[4]; }
        if (arrMessage.Length > 5) { glbFullName = glbFullName + " " + arrMessage[5]; }
        if (arrMessage.Length > 6) { glbFullName = glbFullName + " " + arrMessage[6]; }

        glbCName = ConvertToAscii(glbFullName);

        //Response.Write(glbFrom + "<br>" + glbEmail + "<br>" + glbFullName + "<br>" + glbSCode + "<br>" + glbMsgID + "<br>" + glbCName + "<br>" + glbVCode);
        //Response.End();

        string errorCode = "";
        string rMessage = "";
        string TID = "";

        newDBS ndbs = new newDBS();
        DataSet ds = ndbs.Voucher_Purchase(glbFrom.ToString(), glbVCode.ToString(), glbFullName.ToString(), glbCName.ToString(), glbEmail.ToString(), glbText.ToString(), glbMsgID.ToString(), glbSCode.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            errorCode = ds.Tables[0].Rows[0]["errorCode"].ToString();
            rMessage = ds.Tables[0].Rows[0]["rMessage"].ToString();
            TID = ds.Tables[0].Rows[0]["TID"].ToString();
        }

        //if (errorCode == "0")
        //{
            var webRequest = WebRequest.Create("http://183.81.165.117/VoucherEmail.aspx?TID=" + TID);
            var responseStream = webRequest.GetResponse().GetResponseStream();

            var webRequest1 = WebRequest.Create("http://gt.evenchise.com/BigDataSaleAlert.aspx?TID=" + TID);
            var responseStream1 = webRequest1.GetResponse().GetResponseStream();

            var webRequest2 = WebRequest.Create("http://gt.evenchise.com/MerchantSaleAlert.aspx?TID=" + TID);
            var responseStream2 = webRequest2.GetResponse().GetResponseStream();
        //}

        Response.Write("200 OK");
        Response.End();
    }

    public static string ConvertToAscii(string str)
    {
        char[] charArr = str.ToCharArray();
        String strUniCode = String.Empty;

        try
        {
            foreach (char ch in charArr)
            {
                const int MaxAnsiCode = 255;
                int charAnsii = Convert.ToInt32(ch);

                if (charAnsii > MaxAnsiCode)
                {
                    strUniCode = strUniCode + "&#" + charAnsii + ";";
                }
                else
                {
                    strUniCode = strUniCode + ch;
                }
            }
        }
        catch (FormatException e)
        {
            strUniCode = e.Message;
        }
        return strUniCode;
    }

    public void sendEmail(string TID)
    {
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

            string eMessage = "";
            string vEmailSubject = "Ticket";

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
            request.AddParameter("from", "EbookDelivery <me@maildly.ebdvy.com>");
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