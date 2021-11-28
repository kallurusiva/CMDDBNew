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

public partial class Admin_EbAd_BuyAdminBookFranchiseGSP : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Session Check

        if (Session["UserID"] == null)
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        else
        {
            if (Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                ViewState["BookdID"] = Request.QueryString["BookID"].ToString();
            }
            int vUserID = Convert.ToInt32(Session["UserID"].ToString());
            LoadEMSDetails(vUserID);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string returnMessage = string.Empty;
            string TID = string.Empty;
            string urlString = string.Empty;
            string premiumSMSAlertsURL = string.Empty;
            string bookPassword = string.Empty;
            String strSMSvalue = string.Empty;
            string smsMessage = string.Empty;
            string BPChatid = string.Empty;

            int vUserId = Convert.ToInt32(Session["UserID"].ToString());
            newDBS ndbsd = new newDBS();
            DataSet ds = ndbsd.buy_AdminBook(vUserId.ToString(), ViewState["BookdID"].ToString(), txtcMobile.Text.ToString(), txtcEmail.Text.ToString(), txtcName.Text.ToString(), "0", "");
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

            btnSave.Visible = false;

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

            if (BPChatid.ToString() == "")
            { }
            else
            {
                strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=" + BPChatid.ToString() + "&message=" + Server.UrlEncode(smsMessage.ToString());
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

            //CommonFunctions.AlertMessage(returnMessage.ToString());
            CommonFunctions.AlertMessageAndRedirect(returnMessage.ToString(), "EBAd_BookListingAdminFranchise.aspx");
        }
    }

    protected void LoadEMSDetails(int vUserID)
    {
        string bookTitle = string.Empty;
        String bookimage = string.Empty;
        string prestasiStatus = string.Empty;

        Decimal bookPrice = 0;
        Decimal mWallet = 0;
        prestasiStatus = "0";

        int vUserId = Convert.ToInt32(Session["UserID"].ToString());
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.Ebook_GetBookDetails(ViewState["BookdID"].ToString(), vUserId);

        if (ds.Tables[1].Rows.Count > 0)
        {
            DataRow krow = ds.Tables[1].Rows[0];
            bookimage = krow["bookImage"].ToString();
            bookPrice = Convert.ToDecimal(krow["BookPrice"].ToString());
            mWallet = Convert.ToDecimal(krow["MWallet"].ToString());
            lblImageFilePath.ImageUrl = bookimage;
            lblBookCode.Text = ViewState["BookdID"].ToString();
            lblDescription.Text = krow["description"].ToString();
            lblActualPrice.Text = "USD " + krow["Price"].ToString();
            lblDiscount.Text = krow["discount"].ToString() + " %";
            lblBookPrice.Text = "USD " + bookPrice.ToString();
            lblMWallet.Text = "USD " + mWallet.ToString();
            lblBookTitle.Text = krow["title"].ToString();
            txtcName.Text = krow["fullName"].ToString();
            txtcEmail.Text = krow["email"].ToString();
            txtcMobile.Text = krow["mobile"].ToString();
            lblDate.Text = krow["DateCreated"].ToString();
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            DataRow frow = ds.Tables[3].Rows[0];
            prestasiStatus = frow["GSPStatus"].ToString();
        }

        if (bookPrice > mWallet)
        {
            CommonFunctions.AlertMessage("InSufficient MWallet Balance to buy this Book");
            btnSave.Visible = false;
        }

        if (prestasiStatus == "1")
        {
            CommonFunctions.AlertMessage("You are not qualified to purchase GS Publication Books.");
            btnSave.Visible = false;
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            DataRow utRow2 = ds.Tables[2].Rows[0];
            string upgrade = utRow2["buyadminbook"].ToString();
            string upgrademessage = utRow2["buyadminbookmessage"].ToString();

            if (upgrade.ToString() == "1")
            {
                btnSave.Visible = false;
                btnCancel.Visible = false;
                lblFreeze.Visible = true;
                lblFreeze.Text = upgrademessage.ToString();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("EBAd_BookListingAdminFranchiseGSP.aspx");
    }

}