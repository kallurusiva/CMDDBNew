using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Globalization;


public partial class Admin_SMS_EbAd_MySMSAccount : System.Web.UI.Page
{
    DataSet ds;
    DataView dv;
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
            Retrieve_UserAccountDetails();
            Populate_NewsInfo();
        }
    }
    protected void Retrieve_UserAccountDetails()
    {
        ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            DataRow utRow = ds.Tables[0].Rows[0];

            double iCdtLimitBalance = Convert.ToDouble(utRow["CreditLimit"]);
            double iCdtCurrentBalance = Convert.ToDouble(utRow["BalanceCredit"]);

            Literal3.Text = "Welcome Back  " + utRow["MName"].ToString();

            //if (utRow["Mcode"].ToString().ToUpper() == utRow["ComplexCode"].ToString().ToUpper())
            //{
            //    lblBusinessCode.Text = utRow["Mcode"].ToString();
            //}
            //else
            //{
            //    lblBusinessCode.Text = utRow["ComplexCode"].ToString() + " " + utRow["Mcode"].ToString();
            //}

            //LabelLoginIDVal.Text = utRow["Login"].ToString().Substring(2); //Replace Eb601XXXXXXX
            String tSubscriptionDate = utRow["Exp_Date"].ToString();
            DateTime dtToday = DateTime.Now;
            DateTime dt = DateTime.Now;

            if (tSubscriptionDate.Length > 7)
            {
                string[] datetime = tSubscriptionDate.Split('/');

                tSubscriptionDate = datetime[0].ToString() + "/" + datetime[1].ToString() + "/" + datetime[2].ToString();

               // dt = DateTime.Parse(tSubscriptionDate);
                dt = DateTime.ParseExact(tSubscriptionDate, "MM/dd/yyyy",CultureInfo.InvariantCulture); 
            }

            String tRegisterDate = utRow["MDate"].ToString();
            DateTime dtR = DateTime.Now;

            if (tRegisterDate.Length > 7)
            {
                string[] datetimeR = tRegisterDate.Split('/');

                tRegisterDate = datetimeR[1].ToString() + "/" + datetimeR[0].ToString() + "/" + datetimeR[2].ToString();

                //dtR = DateTime.Parse(tRegisterDate);

                dtR = DateTime.ParseExact(tRegisterDate, "dd/MM/yyyy", CultureInfo.InvariantCulture); 

            }           

            //lblLongCode.Text = utRow["SCode"].ToString();
            //lblTimeZone.Text = utRow["TimeZone"].ToString();
            lblTotalCreditSMS.Text = String.Format("{0:0.00}", utRow["TotalCredit"]); //String.Format("{0:C2}", utRow["TotalCredit"]);
            lblTotalSMSCdtUsed.Text = String.Format("{0:0.00}", utRow["UsedCredit"]);
            lblSMSCreditUsed.Text = String.Format("{0:0.00}", utRow["BalanceCredit"]);
            //lblSubscriptionDate.Text = dt.ToString("d MMM yyyy") + " " + dt.DayOfWeek ;
            lblRegisterDate.Text = dtR.ToString("d MMM yyyy")  + " " + dtR.DayOfWeek ;
            
        }
    }
    protected void Populate_NewsInfo()
    {
        ds = objMalaysia.Retrieve_NewsInfo(5);

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;

            //GridViewNews.DataSource = dv;
            //GridViewNews.DataBind();
        }
    }
}
