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

public partial class BizApPay_CreateCollection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpWebRequest WebReq = null;
            HttpWebResponse WebResp;

            string strSMSvalue = "https://www.bizappay.com/staging/api/createNewCategory";
            WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

            //WebReq.ClientCertificates.Add(Cert);
            WebReq.Method = "POST";
            WebResp = (HttpWebResponse)WebReq.GetResponse();
            if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
            {
                Stream _Answer = WebResp.GetResponseStream();
                StreamReader Answer = new StreamReader(_Answer);
                String strTemp = Answer.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }        

    }
}