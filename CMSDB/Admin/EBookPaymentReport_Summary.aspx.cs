using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

public partial class Admin_EBookPaymentReport_Summary : System.Web.UI.Page
{
    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;


    newDBS objPS = new newDBS();
    string mobileValPS = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        mobileValPS = Session["LoginID"].ToString();
        mobileValPS = mobileValPS.Replace("EB", "");
        ViewState["mobileValPS"] = mobileValPS;

        int vUserID = Convert.ToInt32(Session["UserID"]);

        ds = objPS.EBookPayment_Summary(ViewState["mobileValPS"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            DataRow utRow = ds.Tables[0].Rows[0];
            lblIncentive.Text = "USD " + utRow["pIncentive"].ToString();
            lblIncentiveS.Text = "USD " + utRow["pIncentiveS"].ToString();
            lblIncentiveA.Text = "USD " + utRow["pIncentiveA"].ToString();
            lblIncentiveI.Text = "USD " + utRow["pIncentiveI"].ToString();
            lblTotal.Text = "USD " + utRow["pIncentiveT"].ToString();
        }
    }
}