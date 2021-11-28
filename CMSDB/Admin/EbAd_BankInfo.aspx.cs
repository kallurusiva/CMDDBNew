using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_EbAd_BankInfo : System.Web.UI.Page
{
    DataSet ds;
    //DataView dv;

    String tmpBankUID = string.Empty; 


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
            ds = objEbook.Retrieve_EMSContent_ByUserID(Convert.ToInt32(Session["UserID"].ToString()));

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];
                Retrieve_BankInfo(utRow["Identifier"].ToString());
            }
        }
    }

    protected void Retrieve_BankInfo(String vIdentifier)
    {
        ds = objEbook.Retrieve_UserBankInfo(vIdentifier);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];

            lblMNameVal.Text = utRow["MemberName"].ToString();
            lblMobileVal.Text = utRow["Mobile"].ToString();
            lblICVal.Text = utRow["IC"].ToString();
            lblBankNameVal.Text = utRow["BankName"].ToString();
            lblBankAddVal.Text = utRow["BankAddress"].ToString();
            lblAccountNoVal.Text = utRow["AcNo"].ToString();
            lblBankCountryVal.Text = utRow["Country"].ToString();



            tmpBankUID = utRow["BankUID"].ToString();
            String tmpBankAcctNo = utRow["AcNo"].ToString();

            //if (tmpBankAcctNo == "")
            //{
            //    Response.Redirect("EBAd_BankIn_Add.aspx");
            //}
        }
    }


    protected void btnEditBank_Click(object sender, EventArgs e)
    {
      
      //String BankEditUrl = "EBAd_BankIn_Edit.aspx?qUID=" + Server.UrlEncode(CommonFunctions.Encrypt(tmpBankUID));
      //Response.Redirect(BankEditUrl);
    }
}
