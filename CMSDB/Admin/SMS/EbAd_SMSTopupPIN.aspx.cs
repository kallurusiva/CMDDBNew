using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_SMS_EbAd_SMSTopupPIN : System.Web.UI.Page
{
    DataSet ds;
    //DataView dv;
    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

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
            Retrieve_UserAccountDetails();
        }
    }
    protected void Retrieve_UserAccountDetails()
    {
        ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];

            lblTotalCreditSMS.Text = String.Format("{0:0.00}", utRow["TotalCredit"]); //String.Format("{0:C2}", utRow["TotalCredit"]);
            lblTotalSMSCdtUsed.Text = String.Format("{0:0.00}", utRow["UsedCredit"]);
            lblSMSCreditUsed.Text = String.Format("{0:0.00}", utRow["BalanceCredit"]);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        String tSMSPin = TextBoxSMSPinNo.Text.Trim();
        int tmpStatus = objEbook.Insert_TopupPin(Session["MobileLoginId"].ToString().Replace("EB",""),Session["MobileLoginId"].ToString().Replace("EB",""),tSMSPin);

        if (tmpStatus == 11)
        {
            CommonFunctions.AlertMessageAndRedirect("Wrong Format.Topup Mobile is necessary to continue.Pls provide valid Topup Mobile to coninue.", "EbAd_SMSTopupPin.aspx");
        }
        else if (tmpStatus == 12)
        {
            CommonFunctions.AlertMessageAndRedirect("Wrong Format. Topup PIN is necessary to continue.Pls provide valid Topup PIN to coninue.", "EbAd_SMSTopupPin.aspx");
        }
        else if (tmpStatus == 13)
        {
            CommonFunctions.AlertMessageAndRedirect("Wrong Format. Invalid Topup Mobile.Topup Mobile must be Numeric.", "EbAd_SMSTopupPin.aspx");
        }
        else if (tmpStatus == 14)
        {
            CommonFunctions.AlertMessageAndRedirect("Topup Rejected. Invalid Topup Mobile.Topup Mobile does not exists.", "EbAd_SMSTopupPin.aspx");
        }
        else if (tmpStatus == 15)
        {
            CommonFunctions.AlertMessageAndRedirect("Topup Rejected. Invalid Topup PIN.Topup PIN does not exists.", "EbAd_SMSTopupPin.aspx");
        }
        else if (tmpStatus == 16)
        {
            CommonFunctions.AlertMessageAndRedirect("Topup Rejected. Invalid Topup PIN.Topup PIN is under usage.", "EbAd_SMSTopupPin.aspx");
        }
        else if (tmpStatus == 0)
        {
            CommonFunctions.AlertMessageAndRedirect("Topup Successful.", "EbAd_SMSTopupPin.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"EbAd_SMSTopupPin.aspx");
    }
}
