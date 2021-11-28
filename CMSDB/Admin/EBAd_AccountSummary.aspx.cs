using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;

public partial class Admin_EBAd_AccountSummary : System.Web.UI.Page
{
    DataSet ds;
    DataView dv;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        newDBS objPS = new newDBS();
        ds = objPS.EBookAccountSummary(Session["LoginID"].ToString().Replace("EB",""));

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            DataRow utRow = ds.Tables[0].Rows[0];

            lblAccountSum.Text = "Account Summary of " + utRow["MName"].ToString();

            LabelTotalSumAmtTT.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["FundTT"].ToString()));
            //LabelTotalSMSINCAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["PremiumSMSIncentive"].ToString()));
            LabelTotalGlobalQAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["Total_Bonus"].ToString()));
            LabelTotalCPIncentive.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["CPIncentive"].ToString()));
            //LabelTotalCDTCUR1.Text = Resources.LangResources.Total + " (" + utRow["Denomination"].ToString() + ")";

            double TotalCDTAmtCUR1 = (Convert.ToDouble(utRow["GrandCDT_Total"]) - Convert.ToDouble(utRow["TotalIncCDT"])) * Convert.ToDouble(utRow["LocalExchange"]);
            double TotalDBTAmtCUR1 = Convert.ToDouble(utRow["CreditTT"]) * Convert.ToDouble(utRow["LocalExchange"]);
            //LabelTotalCDTAmtCUR1.Text = Hitech_Functions.currencyFormat(TotalCDTAmtCUR1, CtryCode);
            //LabelTotalDBTAmtCUR1.Text = Hitech_Functions.currencyFormat(TotalDBTAmtCUR1, CtryCode);

            LabelTotalINCAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["TotalINC"].ToString()));
            LabelTotalDPINCAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["RbtAMT"].ToString()));
            LabelTotalTopSMSINCAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["TopRWD"].ToString()));
            //LabelTotalTopEBookPayAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["ebookPayment"].ToString()));
            LabelTotalTopEBookPayAmt.Text = String.Format("{0:0.00}", (Convert.ToDecimal(utRow["ebookPayment"].ToString()) + Convert.ToDecimal(utRow["PremiumSMSIncentive"].ToString())));

            LabelTotalCdtTT.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["CreditTT"].ToString()));

            //LabelTotalCDTCur2.Text = Resources.LangResources.Total + " " + Resources.LangResources.IncEarnings + " (" + utRow["Denomination"].ToString() + ")";
            LabelTotalIncCdt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["TotalIncCDT"].ToString()));

            LabelTotalDPAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["TotalDP"].ToString()));
            LabelTotalTopupPurchaseAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["TotalTopDP"].ToString()));
            LabelTotalRedeemAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["TotalRDM"].ToString()));

            //LabelTotalDBTCUR2.Text = Resources.LangResources.Total + " " + Resources.LangResources.Debit + " " + " (" + utRow["Denomination"].ToString() + ")";
            LabelTotalDecDBT.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["TotalDBT"].ToString()));

            double TotalDBTAmtCUR2 = Convert.ToDouble(utRow["TotalDBT"]) * Convert.ToDouble(utRow["LocalExchange"]);
            //LabelTotalDBTAmtCUR2.Text = Hitech_Functions.currencyFormat(TotalDBTAmtCUR2, CtryCode);

            //LabelTotalDBTCUR3.Text = Resources.LangResources.Total + " " + Resources.LangResources.Payment + " " + " (" + utRow["Denomination"].ToString() + ")";

            int Total_Maintenance = Convert.ToInt32(utRow["Total_Maintenance"]);

            //if (Total_Maintenance > 0) { phIT.Visible = true; }

            LabelTotalPayPendAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["Total_PendingPAY"].ToString()));
            LabelTotalAmtPaidDateAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["Total_Payment"].ToString()));
            LabelTotalPaymentDBT.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["TotalPaymentDBT"].ToString()));

            double TotalDBTAmtCUR3 = Convert.ToDouble(utRow["TotalPaymentDBT"]) * Convert.ToDouble(utRow["LocalExchange"]);
            //LabelTotalDBTAmtCUR3.Text = Hitech_Functions.currencyFormat(TotalDBTAmtCUR3, CtryCode);

            LabelGrandCDT1.Text = "USD" + " " + String.Format("{0:0.00}", Convert.ToDecimal(utRow["GrandCDT_Total"].ToString()));
            LabelGrandDBT1.Text = "USD" + " " + String.Format("{0:0.00}", Convert.ToDecimal(utRow["GrandDBT_Total"].ToString()));
            LabelNetBalance.Text = "USD" + " " + String.Format("{0:0.00}", Convert.ToDecimal(utRow["NetBal"].ToString()));

            string Denomination = utRow["Denomination"].ToString();
            string DisplayDenomination = utRow["DisplayDenomination"].ToString();
            String LocalCurrencyStatus = utRow["LocalCurrencyStatus"].ToString();

            double TotalCDTAmtCur2 = Convert.ToDouble(utRow["TotalIncCDT"]) * Convert.ToDouble(utRow["LocalExchange"]);
            //LabelTotalCDTAmtCur2.Text = Hitech_Functions.currencyFormat(TotalCDTAmtCur2, CtryCode);

            //ImageCtry.ImageUrl = "../Images/" + Session["CtryCode"].ToString() + "_flag.gif";

            //lblAdjusterheader.Text = "Adjustment";
            //lblAdjustertitle.Text = "Adjustment made due to change in Local currency exchange.";
            //lblAdjustedMWP.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["AdjustedMWP"].ToString()));

            //if (CtryCode != "60")
            //{
            //    trAdjustCurrencyRow1.Visible = true;
            //    trAdjustCurrencyRow2.Visible = true;
            //}
            //else
            //{
            //    trAdjustCurrencyRow1.Visible = false;
            //    trAdjustCurrencyRow2.Visible = false;
            //}
            //phCurrency.Visible = true;

            ////lblNBalance.Text = "Balance Available ToDate: " + utRow["Denomination"].ToString() + " " + String.Format("{0:0.00}", Convert.ToDecimal(utRow["showBal"].ToString()));
            ////lblCashout.Text = "Cashout Balance (Exchange Rate " + String.Format("{0:0.00}", Convert.ToDecimal(utRow["exchangeRate"].ToString())) + ") : " + utRow["Denomination"].ToString() + " " + String.Format("{0:0.00}", Convert.ToDecimal(utRow["cashout"].ToString()));

            //lblTableExchangeRate.Text = Resources.LangResources.TbNoteCurLocalExchange + " (" + Session["CtryName"].ToString() + ")";
            //lblSno1.Text = Resources.LangResources.Sno;
            //lblCtry1.Text = Resources.LangResources.Country;
            //lblDenom1.Text = Resources.LangResources.Denomination;
            //lblExchange1.Text = Resources.LangResources.LocalExchange + " (" + utRow["Denomination"].ToString() + ")";

            //lblCtry2.Text = Session["CtryName"].ToString();
            //lblDenom2.Text = utRow["Denomination"].ToString();
            //lblExchange2.Text = String.Format("{0:0.00}", Convert.ToDecimal(utRow["LocalExchange"].ToString()));
        }
    }
}