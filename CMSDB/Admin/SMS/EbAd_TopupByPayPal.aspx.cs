using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;

public partial class Admin_SMS_EbAd_TopupByPayPal : System.Web.UI.Page
{
    //int tmpRowCount;

    DataSet ds;

    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;
        
    CMSv3.BAL.IFMDomains objDomains = new CMSv3.BAL.IFMDomains();
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        if (!IsPostBack)
        {
            if (Request.QueryString.Count == 0)
            {
                ds = objEbook.Retrieve_EMSContent_ByUserID(Convert.ToInt32(Session["UserID"].ToString()));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow utRow = ds.Tables[0].Rows[0];
                    Retrieve_UserInfo(utRow["Identifier"].ToString());
                    Retrieve_SMSInfo();
                }
            }
            else
            {
                String sStatus = Request.QueryString["Status"].ToString().Trim();
            }
        }
    }
    protected void Retrieve_SMSInfo()
    {
        ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];

            LabelSMSBalanceVal.Text = String.Format("{0:0.00}", utRow["BalanceCredit"]);
        }
    }
    protected void Retrieve_UserInfo(String vIdentifier)
    {
        ds = objEbook.Retrieve_UserProfileInfo(vIdentifier);

        if (ds.Tables[1].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[1].Rows[0];

            cpFullName.Value = utRow["MemberName"].ToString(); //1.
            cpItemNumber.Value = cpUserID.Value = Session["MERID"].ToString();//7. //10.
            cpWebSiteName.Value = "";//HitechSMS_Constants.tmp_WebsiteName.ToString();//.9
            cpCurrencyCode.Value = utRow["CountryCode"].ToString();//3.

            lblMNameVal.Text = utRow["MemberName"].ToString();
            lblLoginIDVal.Text = Session["MobileLoginID"].ToString();
            lblMobileVal.Text = utRow["Mobile"].ToString();
            //lblMobileVal.Text = "http://" + HttpContext.Current.Request.Url.Host + "/Admin/SMS/EbAd_TopupbyPAYPALSuccess.aspx";
            Populate_ddlSMSVolume(cpCurrencyCode.Value);
        }
    }
  
    protected void Populate_ddlSMSVolume(String vCountryCode)
    {
        ds = objDomains.Retrieve_CreditCardPurchaseInfo(vCountryCode.ToString(), "SMS", "");

        if (ds.Tables[1].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[1].Rows[0];
            Boolean Status = Convert.ToBoolean(utRow["isDisplay"]);

            //if (Status == true) { Response.Redirect(HitechSMS_Constants.tmp_PayPalMaintainancePage.ToString()); }
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];

            cpCurrencyCode.Value = utRow["DENOMINATION"].ToString();

            ddlSMSVolume.DataSource = ds.Tables[0];
            ddlSMSVolume.DataTextField = "SMSDATA";
            ddlSMSVolume.DataValueField = "SMSVALUE";
            ddlSMSVolume.DataBind();
        }
    }
    protected void btBuyNow_Click(object sender, EventArgs e)
    {
        string strSMSVolume = ddlSMSVolume.SelectedValue;
        string[] strInfo = strSMSVolume.Split('#');

        for (int i = 0; i < strInfo.Length; i++)
        {
            cpItemName.Value = "SMS Topup Volume " + strInfo[0];//5.
            cpCustomText.Value = strInfo[0] + "#" + "SMSTOPUP"; //6.
            cpAmount.Value = strInfo[1];//2.
            //cpAmount.Value = "5.00";
        }

        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();

        String strURL = "http://183.81.165.110/WebApps/GsPayPal/Wsp_PayPalCall.aspx";

        String newSuccessURL = "http://" + HttpContext.Current.Request.Url.Host + "/Admin/SMS/EbAd_TopupbyPAYPALSuccess.aspx";
        string newCanlcelURL = "http://" + HttpContext.Current.Request.Url.Host + "/Admin/SMS/EbAd_TopupbyPAYPALCancel.aspx";
        string newFailureURL = "http://" + HttpContext.Current.Request.Url.Host + "/Admin/SMS/EbAd_TopupbyPAYPALFailure.aspx";

        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[0].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);

        // Start Collecting Parameters

        sb.AppendFormat("<input type='hidden' name='cpFullName' value='{0}'>", cpFullName.Value);
        sb.AppendFormat("<input type='hidden' name='cpAmount' value='{0}'>", cpAmount.Value);
        sb.AppendFormat("<input type='hidden' name='cpCurrencyCode' value='{0}'>", cpCurrencyCode.Value);
        sb.AppendFormat("<input type='hidden' name='cpMobileNo' value='{0}'>", cpMobileNo.Value);
        sb.AppendFormat("<input type='hidden' name='cpItemName' value='{0}'>", cpItemName.Value);
        sb.AppendFormat("<input type='hidden' name='cpCustomText' value='{0}'>", cpCustomText.Value);
        sb.AppendFormat("<input type='hidden' name='cpItemNumber' value='{0}'>", cpItemNumber.Value);
        sb.AppendFormat("<input type='hidden' name='cpUniqueID' value='{0}'>", cpUniqueID.Value);
        sb.AppendFormat("<input type='hidden' name='cpWebSiteName' value='{0}'>", "www.worlddigitalbiz.com");
        sb.AppendFormat("<input type='hidden' name='cpUserID' value='{0}'>", cpUserID.Value);
        sb.AppendFormat("<input type='hidden' name='cpSuccessURL' value='{0}'>", newSuccessURL);
        sb.AppendFormat("<input type='hidden' name='cpCancelURL' value='{0}'>", newCanlcelURL);
        sb.AppendFormat("<input type='hidden' name='cpFailureURL' value='{0}'>", newFailureURL);
        sb.AppendFormat("<input type='hidden' name='cpSkipTAC' value='{0}'>", cpSkipTAC.Value);

        // End

        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();

    }
}
