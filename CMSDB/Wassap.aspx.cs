using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using System.IO;

public partial class Wassap : System.Web.UI.Page
{
    //int tmpStatus = 0;
    DataSet ds;
    //SqlDataAdapter dbAdap;
    //bool isDEPUser = false;
    String strLoginFrom = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    { 
            String tLoginID = txtLoginID.Text.ToString();
            String tPwd = txtPwd.Text.ToString();

            tLoginID = tLoginID.Replace(",", "");
            tPwd = tPwd.Replace(",", "");

            String LoginMobileNumber = string.Empty;
            String LoginMerID = string.Empty;
            String LoginUserID = string.Empty;
            String LoginSeqNo = string.Empty;
            String bcode = string.Empty;
            String expiryStatus = string.Empty;
            String smsStatus = string.Empty;
            String expiryDate = string.Empty;

            newDBS objNewDB = new newDBS();
            ds = objNewDB.wassap_validateLogin(tLoginID, tPwd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                LoginMobileNumber = dr["vGenMobileNo"].ToString();
                LoginMerID = dr["vMERID"].ToString();
                LoginUserID = dr["vUSERID"].ToString();
                LoginSeqNo = dr["seqno"].ToString();
                bcode = dr["bcode"].ToString();
                expiryStatus = dr["expiryStatus"].ToString();
                smsStatus = dr["smsStatus"].ToString();
                expiryDate = dr["expiryDate"].ToString();
            }

            if (LoginMobileNumber.ToString().Trim() == "0")
            {
                String vAlertMsg = "Invalid LoginID/Password";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
            }
            else if (expiryStatus.ToString() == "1")
            {
                String vAlertMsg = "Your Account Subscription Already Expired on " + expiryDate.ToString();
                 vAlertMsg = vAlertMsg + ".  Please consult your Software Consultant for renewal. Account will be deleted from the system after  1 month of non renewal.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
            }
            else if (smsStatus.ToString() == "1")
            {
                String vAlertMsg = "Your Account have insufficient SMS Credit , Please Topup to access your Account.  Please ensure that you account have sufficient SMS credits at ALL Times. TQ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
            }
            else
            {
                Session["UserID"] = LoginUserID.ToString();
                Session["LoginID"] = tLoginID.ToString();
                Session["MobileLoginID"] = LoginMobileNumber.ToString();
                Session["MERID"] = LoginMerID.ToString();
                Session["LoggedInFrom"] = tLoginID;
                Session["SeqNo"] = LoginSeqNo;
                Session["bcode"] = bcode;
                Session["menunav"] = "1";
                Response.Redirect("~/Wassap/W_Dashboard.aspx");
            }
    }
}