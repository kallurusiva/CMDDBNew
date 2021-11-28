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

public partial class eBooksBuyPPSuccessTest : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {

        HttpWebRequest WebReq = null;
        HttpWebResponse WebResp;
        string strSMSvalue = "";
        int rcount = 0;
        newDBS ldbs = new newDBS();
        DataSet ppReward = ldbs.get_EBookPaypalReward_DetailsTest("1283225204");
        if (ppReward.Tables[1].Rows.Count > 0)
        {
            DataRow rrow = ppReward.Tables[1].Rows[0];
            rcount = Convert.ToInt32(rrow["counter"].ToString());
        }
        if (ppReward.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow myRow in ppReward.Tables[0].Rows)
            {
                if (myRow["chatid"].ToString() != "0" && Convert.ToDecimal(myRow["finalshare"].ToString()) > 0)
                {
                    strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + myRow["chatid"].ToString();
                    strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode("EBookBizTech - Congratulation Someone Purchased an EBook using Credit Card.");
                    strSMSvalue = strSMSvalue + "\n\nYou Earned Incentive USD " + myRow["finalshare"].ToString() + "\n\nPurchased By: " + myRow["pMobile"].ToString();
                    strSMSvalue = strSMSvalue + "\nProduct Code: " + myRow["BookCode"].ToString() + "\nProduct Name: " + myRow["BookName"].ToString();
                    WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
                    WebReq.Method = "GET";
                    WebResp = (HttpWebResponse)WebReq.GetResponse();
                    if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                    {
                        Stream _Answer = WebResp.GetResponseStream();
                        StreamReader Answer = new StreamReader(_Answer);
                        String strTemp = Answer.ReadToEnd();
                    }
                }
                if (myRow["SChatid"].ToString() != "0" && Convert.ToDecimal(myRow["sponsorshare"].ToString()) > 0)
                {
                    strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + myRow["SChatid"].ToString();
                    strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode("EBookBizTech - Congratulation Someone Purchased an EBook using Credit Card.");
                    strSMSvalue = strSMSvalue + "\n\nYou Earned Direct Incentive USD " + myRow["sponsorshare"].ToString() + "\n\nPurchased By: " + myRow["pMobile"].ToString();
                    strSMSvalue = strSMSvalue + "\nProduct Code: " + myRow["BookCode"].ToString() + "\nProduct Name: " + myRow["BookName"].ToString();

                    WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
                    WebReq.Method = "GET";
                    WebResp = (HttpWebResponse)WebReq.GetResponse();
                    if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                    {
                        Stream _Answer = WebResp.GetResponseStream();
                        StreamReader Answer = new StreamReader(_Answer);
                        String strTemp = Answer.ReadToEnd();
                    }
                }
                if (myRow["AChatid"].ToString() != "0" && Convert.ToDecimal(myRow["AuthorShare"].ToString()) > 0)
                {
                    strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + myRow["AChatid"].ToString();
                    strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode("EBookBizTech - Congratulation Someone Purchased an EBook using Credit Card.");
                    strSMSvalue = strSMSvalue + "\n\nYou Earned Author Incentive USD " + myRow["AuthorShare"].ToString() + "\n\nPurchased By: " + myRow["pMobile"].ToString();
                    strSMSvalue = strSMSvalue + "\nProduct Code: " + myRow["BookCode"].ToString() + "\nProduct Name: " + myRow["BookName"].ToString();

                    WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
                    WebReq.Method = "GET";
                    WebResp = (HttpWebResponse)WebReq.GetResponse();
                    if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                    {
                        Stream _Answer = WebResp.GetResponseStream();
                        StreamReader Answer = new StreamReader(_Answer);
                        String strTemp = Answer.ReadToEnd();
                    }
                }
                if (myRow["IChatid"].ToString() != "0" && Convert.ToDecimal(myRow["IntroducerShare"].ToString()) > 0)
                {
                    strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + myRow["IChatid"].ToString();
                    strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode("EBookBizTech - Congratulation Someone Purchased an EBook using Credit Card.");
                    strSMSvalue = strSMSvalue + "\n\nYou Earned Introducer Incentive USD " + myRow["IntroducerShare"].ToString() + "\n\nPurchased By: " + myRow["pMobile"].ToString();
                    strSMSvalue = strSMSvalue + "\nProduct Code: " + myRow["BookCode"].ToString() + "\nProduct Name: " + myRow["BookName"].ToString();

                    WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
                    WebReq.Method = "GET";
                    WebResp = (HttpWebResponse)WebReq.GetResponse();
                    if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                    {
                        Stream _Answer = WebResp.GetResponseStream();
                        StreamReader Answer = new StreamReader(_Answer);
                        String strTemp = Answer.ReadToEnd();
                    }
                }
            }
        }

    }



   
}




