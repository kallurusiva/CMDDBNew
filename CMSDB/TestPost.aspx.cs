using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mail;

public partial class TestPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpWebRequest WebReq = null;
        HttpWebResponse WebResp;
        string strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=306615026&message=New Admin Book Request by: 60126583065";
        WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
        WebReq.Method = "GET";
        WebResp = (HttpWebResponse)WebReq.GetResponse();


        //HttpWebRequest request = WebRequest.Create(strSMSvalue) as HttpWebRequest;
        //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
        //request.Method = "GET";
        //request.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        //request.Accept = "text/xml";
        //request.AllowAutoRedirect = true;
        //request.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
           
    }
}