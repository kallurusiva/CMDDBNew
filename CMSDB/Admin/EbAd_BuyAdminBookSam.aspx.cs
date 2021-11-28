using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net;

public partial class Admin_EbAd_BuyAdminBookSam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString.Count > 0)
        //{
        //    ViewState["BookdID"] = Request.QueryString["BookID"].ToString();
        //}

        ViewState["BookdID"] = "EH2052";

        string buyStatus = string.Empty;
        newDBS objValidate = new newDBS();
        DataSet dsv = objValidate.buy_AdminBook_samValidate(ViewState["BookdID"].ToString());
        if (dsv.Tables[0].Rows.Count > 0)
        {
            DataRow drv = dsv.Tables[0].Rows[0];
            buyStatus = drv["buyStatus"].ToString();
        }

        if (buyStatus == "0")
        {
            string returnMessage = string.Empty;
            string TID = string.Empty;
            string urlString = string.Empty;
            string premiumSMSAlertsURL = string.Empty;
            string bookPassword = string.Empty;
            String strSMSvalue = string.Empty;
            string smsMessage = string.Empty;
            string BPChatid = string.Empty;

            newDBS ndbsd = new newDBS();
            DataSet ds = ndbsd.buy_AdminBook("7661", ViewState["BookdID"].ToString(), "60162531066", "samvoon@yahoo.com", "sam", "0", "");

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                returnMessage = dr["returnMessage"].ToString();
                TID = dr["TID"].ToString();
                urlString = dr["urlStringNew"].ToString();
                premiumSMSAlertsURL = dr["premiumSMSAlertsURL"].ToString();
                bookPassword = dr["bookPassword"].ToString();
                smsMessage = dr["smsMessage"].ToString();
                BPChatid = dr["BPChatid"].ToString();
            }

            HttpWebRequest WebReq = null;
            HttpWebResponse WebResp;

            strSMSvalue = "http://gt.evenchise.com/PremiumSMSAlerts.aspx?TID=" + TID.ToString();

            WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
            WebReq.Method = "GET";
            WebResp = (HttpWebResponse)WebReq.GetResponse();
            if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
            {
                Stream _Answer = WebResp.GetResponseStream();
                StreamReader Answer = new StreamReader(_Answer);
                String strTemp = Answer.ReadToEnd();
            }

            strSMSvalue = urlString.ToString();

            WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
            WebReq.Method = "GET";
            WebResp = (HttpWebResponse)WebReq.GetResponse();
            if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
            {
                Stream _Answer = WebResp.GetResponseStream();
                StreamReader Answer = new StreamReader(_Answer);
                String strTemp = Answer.ReadToEnd();
            }

            Response.Write("Transaction Completed.");
        }
        else
        {
            Response.Write("Duplicate Purchase not allowed.");
        }
    }

}