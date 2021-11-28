using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.Text;
using System.IO;

public partial class TmpDomainNameCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {


        string tmpDomain2check = txtDomainName.Text;

        string tmpNameCheapLink = string.Empty;

        tmpNameCheapLink = "https://api.namecheap.com/xml.response?" +
                            "ApiUser=samvoon" +
                            "&ApiKey=a75db07a1e43441db02c920eebe43d41" +
                            "&UserName=samvoon" +
                            "&Command=namecheap.domains.check" +
                            "&ClientIp=" + Request.UserHostAddress +
            // "&ClientIp=192.168.1.4" +
                            "&DomainList=" + tmpDomain2check;

        Uri tmpUri = new Uri(tmpNameCheapLink);

        #region // Sending Request for Domain Name availability to NameCheap.com

        ASCIIEncoding encoding = new ASCIIEncoding();
        string postData = "ApiUser=samvoon";
        postData += ("&ApiKey=a75db07a1e43441db02c920eebe43d41");
        postData += ("&UserName=samvoon");
        postData += ("&Command=namecheap.domains.check");
        //postData += ("&ClientIp=192.168.1.4" + Request.UserHostAddress);
        postData += ("&ClientIp=122.174.136.47");
        postData += ("&DomainList=" + tmpDomain2check);
        byte[] data = encoding.GetBytes(postData);


        // Prepare web request...
        HttpWebRequest http_DomainNameCheckRequest = (HttpWebRequest)WebRequest.Create(tmpUri);
        http_DomainNameCheckRequest.Method = WebRequestMethods.Http.Get;
        // http_DomainNameCheckRequest.ContentType = "application/x-www-form-urlencoded";
        //http_DomainNameCheckRequest.ContentLength = data.Length;
        //Stream newStream = http_DomainNameCheckRequest.GetRequestStream();
        //// Send the data.
        //newStream.Write(data, 0, data.Length);
        //newStream.Close();


        // *** Retrieve request info headers
        HttpWebResponse http_DomainCheckResponse = (HttpWebResponse)http_DomainNameCheckRequest.GetResponse();
        Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page
        StreamReader loResponseStream = new StreamReader(http_DomainCheckResponse.GetResponseStream(), enc);
        string Html_DomainNameCheckResponse = loResponseStream.ReadToEnd();
        http_DomainCheckResponse.Close();
        loResponseStream.Close();

        Response.Write(Html_DomainNameCheckResponse);
        lblResult.Text = Html_DomainNameCheckResponse;

        #endregion


    }
}
