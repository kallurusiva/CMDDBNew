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

public partial class Admin_EBAd_TopReferral : System.Web.UI.Page
{
    DataSet ds;

    string currentmonth = string.Empty;
    string lastmonth = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        newDBS objPS = new newDBS();
        ds = objPS.ebook_topUpgrades(Session["LoginID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];
            currentmonth = utRow["currentMonth"].ToString() + " " + utRow["currentYear"].ToString();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            DataRow utRow1 = ds.Tables[1].Rows[0];
            lastmonth = utRow1["lastMonth"].ToString() + " " + utRow1["lastYear"].ToString();
        }

        lblTotAdmBooksText.Text = "No. of Free Signup";
        lblTotAdmBooksCMonthText.Text = "No of FREE Upgraded Partners Current Month (" + currentmonth.ToString() + ")";
        lblTotAdmBooksLMonthText.Text = "No of FREE Upgraded Partners Last  Month (" + lastmonth.ToString() + ")";

        lblCurrentMonthTitle.Text = "Current Month - " + currentmonth.ToString();
        lblLastMonthTitle.Text = "Last Month - " + lastmonth.ToString();

        if (ds.Tables[2].Rows.Count > 0)
        {
            DataRow utRow2 = ds.Tables[2].Rows[0];
            lblTotAdmBooks.Text = utRow2["totFREEsignup"].ToString();
            lblTotAdmBooksCMonth.Text = utRow2["totUpgradeCurrentMonth"].ToString();
            lblTotAdmBooksLMonth.Text = utRow2["totUpgradeLastMonth"].ToString();
        }

        if (ds.Tables[3].Rows.Count > 0)
        {
            DataView dv1 = ds.Tables[3].DefaultView;
            gridBankInBys.DataSource = dv1;
            gridBankInBys.DataBind();
        }

        if (ds.Tables[5].Rows.Count > 0)
        {
            DataView dv2 = ds.Tables[5].DefaultView;
            GridView1.DataSource = dv2;
            GridView1.DataBind();
        }

        if (ds.Tables[4].Rows.Count > 0)
        {
            DataView dv3 = ds.Tables[4].DefaultView;
            GridView2.DataSource = dv3;
            GridView2.DataBind();
        }

        if (ds.Tables[6].Rows.Count > 0)
        {
            DataView dv4 = ds.Tables[6].DefaultView;
            GridView3.DataSource = dv4;
            GridView3.DataBind();
        }

    }
}