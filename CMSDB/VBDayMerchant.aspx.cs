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

public partial class VBDayMerchant : System.Web.UI.Page
{
    string glbFrom;
    string glbText;
    string glbMsgID;
    string glbSCode;
    //string glbTelcoID;
    string prmMessage;

    string glbUniqueID;
    string glbDOB;
    string glbEmail;
    string glbFullName;
    string glbCName;

    string glbDay;
    string glbMonth;
    string glbYear;

    protected void Page_Load(object sender, EventArgs e)
    {
        glbFrom = Request.QueryString["Mobile"].ToString().Trim();
        glbText = Request.QueryString["message"].ToString().Trim();
        glbMsgID = Request.QueryString["msgid"].ToString().Trim();
        glbSCode = Request.QueryString["shortcode"].ToString().Trim();
        //glbTelcoID		= Request.QueryString["telcoid"].ToString().Trim();

        //glbFrom = "60126583065";
        //glbText = "MMP JOHN 60126583065 15101973 kallurusiva@gmail.com siva";
        //glbMsgID = "12312312";
        //glbSCode = "60146367111";

        prmMessage = glbText.ToString();

        prmMessage = prmMessage.ToString().Replace("\r", " ");
        prmMessage = prmMessage.ToString().Replace("\n", " ");
        prmMessage = prmMessage.ToString().Replace("  ", " ");
        prmMessage = prmMessage.ToString().Replace("  ", " ");
        prmMessage = prmMessage.ToString().Replace("  ", " ");

        string[] arrMessage = prmMessage.Split(' ');

        glbUniqueID = "";
        glbDOB = "";
        glbEmail = "";
        glbFullName = "";
        glbCName = "";

        glbDay = "";
        glbMonth = "";
        glbYear = "";

        if (arrMessage.Length > 1) { glbUniqueID = arrMessage[1]; }
        if (arrMessage.Length > 2) { glbDOB = arrMessage[2]; }
        if (arrMessage.Length > 3) { glbEmail = arrMessage[3]; }
        if (arrMessage.Length > 4) { glbFullName = arrMessage[4]; }
        if (arrMessage.Length > 5) { glbFullName = glbFullName + " " + arrMessage[5]; }
        if (arrMessage.Length > 6) { glbFullName = glbFullName + " " + arrMessage[6]; }
        if (arrMessage.Length > 7) { glbFullName = glbFullName + " " + arrMessage[7]; }

        if (glbDOB.Length > 1) { glbDay = glbDOB.Substring(0, 2); }
        if (glbDOB.Length > 3) { glbMonth = glbDOB.Substring(2, 2); }
        if (glbDOB.Length > 7) { glbYear = glbDOB.Substring(4, (glbDOB.Length - 4)); }

        glbCName = ConvertToAscii(glbFullName);

        //Response.Write(glbFrom + "<br>" + glbEmail + "<br>" + glbFullName + "<br>" + glbSCode + "<br>" + glbMsgID + "<br>" + glbCName);
        //Response.End();

        string errorCode = "";
        string rMessage = "";
        string TID = "";
        string VCode = "";
        string VName = "";
        string VImage = "";
        string vEmailAddedInfo = "";
        string bdayReplyStatus = "";

        newDBS ndbs = new newDBS();
        DataSet ds = ndbs.Merchant_Incoming(glbFrom.ToString(), glbUniqueID.ToString(), glbDay.ToString(), glbMonth.ToString(), glbYear.ToString(), glbFullName.ToString(), glbCName.ToString(), glbEmail.ToString(), glbText.ToString(), glbMsgID.ToString(), glbSCode.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            errorCode = ds.Tables[0].Rows[0]["errorCode"].ToString();
            rMessage = ds.Tables[0].Rows[0]["rMessage"].ToString();
            TID = ds.Tables[0].Rows[0]["TID"].ToString();
            VCode = ds.Tables[0].Rows[0]["VCode"].ToString();
            VName = ds.Tables[0].Rows[0]["VName"].ToString();
            VImage = ds.Tables[0].Rows[0]["VImage"].ToString();
            vEmailAddedInfo = ds.Tables[0].Rows[0]["vEmailAddedInfo"].ToString();
            bdayReplyStatus = ds.Tables[0].Rows[0]["bdayReplyStatus"].ToString();
        }
        var webRequest1 = WebRequest.Create("http://gt.evenchise.com/MerchantSaleAlert.aspx?TID=" + TID);
        var responseStream1 = webRequest1.GetResponse().GetResponseStream();
        if (bdayReplyStatus.ToString() == "1")
        {
            if (VCode.ToString() != "0")
            {
                sendEmail(VCode, VName, VImage, vEmailAddedInfo, rMessage);
            }
        }

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

    public void sendEmail(string vCode, string vcName, string vcImage, string vcEmailAddedInfo, string vcMessage)
    {
        string VName = vcName.ToString();
        string VImage = vcImage.ToString();
        string vEmailAddedInfo = vcEmailAddedInfo.ToString();

        string eMessage = "";
        string vEmailSubject = "Voucher";

        string tmpHtmlBody = string.Empty;
        String tmpEbfileFolder = "http://183.81.165.117/DocumentRepository/Vouchers/";
        string BookImageURL = tmpEbfileFolder + VImage.ToString();
        String BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL.Replace(" ", "%20") + "' />";

        eMessage = eMessage.Replace(Environment.NewLine, "<br/>");
        eMessage = eMessage + vcMessage.ToString() + "<br><br>";
        eMessage = eMessage + "Voucher Code: " + vCode.ToString() + "<br>";
        eMessage = eMessage + "Voucher Name: " + VName.ToString() + "<br>";
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
        request.AddParameter("to", glbEmail);
        //request.AddParameter("bcc", "kodur_siva@yahoo.com,kallurusiva@hotmail.com");
        request.AddParameter("subject", vEmailSubject);
        //request.AddParameter("text", "Testing some Mailgun awesomness!");
        request.AddParameter("html", tmpHtmlBody);

        request.Method = Method.POST;
        client.Execute(request);
    }

}