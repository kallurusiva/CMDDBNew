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

public partial class Admin_SMS_EbAd_EBook_FreeSYS_MessageTelegram : System.Web.UI.Page
{

    #region Variables

    DataSet ds;
    DataSet dst;
    int vTimeDiff = 0;
    int iTotalCount;
    int EngMaxLen = 600;
    int ChiMaxLen = 240;
    int stdEngMaxLen = 150;
    int stdChiMaxLen = 60;
    string LID = string.Empty;
    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();

    #endregion    

    protected void Page_Load(object sender, EventArgs e)
    {

        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        LID = Request.QueryString["LID"].ToString();

        if (!IsPostBack)
        {
            ViewState["LID"] = LID;
            TextBoxMobileList.Text = "";
            newDBS ndbs = new newDBS();
            dst = ndbs.Ebook_CreateList_BookCode_sendSMS_getList_FreeSYS(Session["UserID"].ToString(), ViewState["LID"].ToString());
            if (dst.Tables[0].Rows.Count > 0)
            {
                DataRow utRow1 = dst.Tables[0].Rows[0];
                TextBoxMobileList.Text = utRow1["Txt"].ToString();
                hdnMobiles.Value = utRow1["Txt"].ToString();
            }
            if (dst.Tables[1].Rows.Count > 0)
            {
                DataRow utRow2 = dst.Tables[1].Rows[0];
                hdnMobileCount.Value = utRow2["cnt"].ToString();
                hdnCharges.Value = utRow2["charges"].ToString();
                lblCharges.Text = String.Format("{0:0.00}", utRow2["charges"]);
            }

            ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];
                LabelMerchantCodeVal.Text = utRow["Mcode"].ToString();
                LabelSMSBalanceVal.Text = String.Format("{0:0.00}", utRow["BalanceCredit"]);
                hdnBalance.Value = utRow["BalanceCredit"].ToString();
            }
        }
    }

    protected void btnBackMsg_Click(object sender, EventArgs e)
    {
        tblSendSMS.Visible = true;
        tblConfirmSMS.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Convert.ToDecimal(hdnCharges.Value) > Convert.ToDecimal(hdnBalance.Value))
            {
                CommonFunctions.AlertMessage("InSufficient SMS Credits to proceed.");
            }
            else
            {
                tblSendSMS.Visible = false;
                tblConfirmSMS.Visible = true;

                LabelMobileCountVal.Text = hdnMobileCount.Value;

                LabelMsgScheduleChgVal.Text = "0.5";
                LabelMsgFormatVal.Text = TextBoxReplyMsg.Text;
                LabelTotalMessageCdtChgsVal.Text = hdnCharges.Value;
                hdnReportName.Value = txtReportName.Text.ToString();
            }            
        }
    }

    protected void btnSaveContinue_Click(object sender, EventArgs e)
    {
       
    }

    protected void btnSendNow_Click(object sender, EventArgs e)
    {
        newDBS ndbs = new newDBS();
        DataSet dss = ndbs.Ebook_BookCodeFree_FreeSYSTelegramMessage(Session["MERID"].ToString(), LabelMsgFormatVal.Text.ToString(), hdnMobiles.Value, hdnCharges.Value, hdnReportName.Value);
        if (dss.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = dss.Tables[0].Rows[0];
            hdnHistID.Value = utRow["HISTID"].ToString();

            string strSMSvalue = "http://gt.evenchise.com/EBookFreeSystem_TelegramMessage.aspx?TID=" + utRow["HISTID"].ToString();

            HttpWebRequest WebReq = null;
            HttpWebResponse WebResp;

            WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);
            WebReq.Method = "GET";
            WebResp = (HttpWebResponse)WebReq.GetResponse();
            if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
            {
                Stream _Answer = WebResp.GetResponseStream();
                StreamReader Answer = new StreamReader(_Answer);
                String strTemp = Answer.ReadToEnd();
            }

            CommonFunctions.AlertMessage("Telegram Messgae has been sent successfully");
            Server.Transfer(@"EbAd_1WayReportSpecific.aspx");
        }
        
    }

    public static int Check_UserSMSBalanceSufficient(Double iDeductSMSCredits, Double iBalanceCredit)
    {
        int iStatus;

        if (iBalanceCredit > iDeductSMSCredits)
        {
            iStatus = 1;
        }
        else if (iBalanceCredit <= 0)
        {
            iStatus = -1;
        }
        else
        {
            iStatus = -1;
        }
        return iStatus;
    }

    protected void Get_DistinctMobile(List<string> list)
    {
        string tMobileDistinctList = string.Join(",", list.ToArray());
        TextBoxMobileList.Text = tMobileDistinctList;
    }

    protected static List<String> Get_DistinctList(String tStringList)
    {
        List<string> list = new List<string>();
        List<string> strDistinctList = new List<string>();
        try
        {

            String[] tString = tStringList.Split(',');
            foreach (string tWord in tString)
            {
                list.Add(tWord);
            }

            strDistinctList = list.Distinct().ToList();
        }
        catch (FormatException ex)
        {
            strDistinctList = list;
            Console.WriteLine(ex);
        }
        return strDistinctList;
    }

}
