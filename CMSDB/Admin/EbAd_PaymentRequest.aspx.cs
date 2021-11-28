using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_EbAd_PaymentRequest : System.Web.UI.Page
{
    DataSet ds;
    //DataView dv;

    double iBalanceAmt = 0;
    double iRequestPaymentAmt = 255;

    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion
        
        if(!IsPostBack)
        {
            Check_BankDetails();
        }
    }
    protected void Check_BankDetails()
    {
        ds = objMalaysia.Validate_PaymentRequest(Session["MERID"].ToString());
        String tmpStatus = ds.Tables[0].Rows[0][0].ToString();

        lblRpDate.Text = DateTime.Today.AddMonths(-5).ToString("MMMM,yyyy");
        lblLastPayment.Text = DateTime.Today.AddMonths(-5).ToString("MMMM,yyyy");

        if (tmpStatus != "0")
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[1].Rows[0];

                String tPayee = utRow["MemberName"].ToString();
                String tBankName = utRow["BankCode"].ToString();
                String tBankAcc = utRow["AcNo"].ToString();
                String ProfitPercentage = utRow["ProfitPercentage"].ToString();
                DateTime PayDate = Convert.ToDateTime(utRow["PayDate"].ToString());
                DateTime ExecDate = Convert.ToDateTime(utRow["ExecDate"].ToString());

                iBalanceAmt = Convert.ToDouble(utRow["BalanceAmt"]);
                lblPayOut.Text = "RM " + String.Format("{0:0.00}", utRow["PayOutAmt"]);
                ltrBalancePayOutVal.Text = "RM " + String.Format("{0:0.00}", iBalanceAmt);
                lblBalance.Text = "RM " + String.Format("{0:0.00}", iBalanceAmt);
                lblBalPaymentAmt.Text = "RM " + String.Format("{0:0.00}", iBalanceAmt);

                if (tPayee == "" || tBankName == "" || tBankAcc == "")
                {
                    CommonFunctions.AlertMessageAndRedirect("Please update Bank Info", @"SMSpay_BankIn_Add.aspx");
                }
                else
                {
                    lblRpDate.Text = PayDate.ToString("MMMM,yyyy");
                }

                if ((DateTime.Now.Day >= 5))
                {
                    plholder1.Visible = true;
                    plholder2.Visible = false;
                    plholder3.Visible = false;
                }
                else
                {
                    if (iBalanceAmt < iRequestPaymentAmt)
                    {
                        tblMessageBar.Visible = true;
                        lblErrMessage.Text = "Payment Request is not Allowed.Your Balance for Request Payment is insufficient";
                        TextBoxPayAmt.Enabled = false;
                        btnSave.Enabled = false;
                    }
                }
            }
            else
            {
                CommonFunctions.AlertMessageAndRedirect("Sorry you cannot request for payment.Kindly contact administrator!", @"EbAd_BankInfo.aspx");
            }
        }
        else
        {
         
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Sorry you cannot request for payment.Kindly contact administrator!";
            TextBoxPayAmt.Enabled = false;
            btnSave.Enabled = false;
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        double Num;
        string Str = TextBoxPayAmt.Text.Trim();

        bool isNum = double.TryParse(Str, out Num);
        if (isNum)
        {
            double iRequestedAmount = Convert.ToDouble(TextBoxPayAmt.Text) + 25;
            TextBoxTotalPayAmt.Text = iRequestedAmount.ToString();
        }
        else
        {
            TextBoxTotalPayAmt.Text = "0.00";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        double iRequestedAmount = Convert.ToDouble(TextBoxPayAmt.Text) + 25;
        TextBoxTotalPayAmt.Text = iRequestedAmount.ToString();
        ltrTotalRequestAmtVal.Text = "RM " + String.Format("{0:0.00}", iRequestedAmount);
        lblRequestedAmt.Text = "RM " + String.Format("{0:0.00}", Convert.ToDouble(TextBoxPayAmt.Text));

        plholder2.Visible = false;
        plholder3.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        double iRequestedAmount = Convert.ToDouble(TextBoxPayAmt.Text);
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        double iRequestedAmount = Convert.ToDouble(TextBoxPayAmt.Text);
        int tmpStatus = objMalaysia.Insert_PaymentRequest(Session["MERID"].ToString(), iRequestedAmount.ToString());

        String strMsg = String.Empty;

        if (tmpStatus == 1)
        {
            strMsg = "Payment Request RM " + iRequestedAmount + " Received Successfully!";
        }
        else if (tmpStatus == 0)
        {
            strMsg = "Payment Request Rejected.Please update your Bank Details!";
        }
        else
        {
            strMsg = "Technical Error.Please try again later!";
        }        
        CommonFunctions.AlertMessageAndRedirect(strMsg, @"EbAd_PaymentRequest.aspx");        
                        
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        double iRequestedAmount = Convert.ToDouble(TextBoxPayAmt.Text) + 25;
        TextBoxTotalPayAmt.Text = iRequestedAmount.ToString();

        plholder1.Visible = false;
        plholder3.Visible = false;
        plholder2.Visible = true;
    } 

}
