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

public partial class Admin_EBAd_TopBestSellerBooks_Mwallet : System.Web.UI.Page
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
        ds = objPS.ebook_topBestSellerEBooksMWallet(Session["UserID"].ToString());

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

        //lblTotAdmBooksText.Text = "Your Total Admin EBooks";
        //lblTotAdmBooksCMonthText.Text = "Your Total Admin EBooks Current Month (" + currentmonth.ToString() + ")";
        //lblTotAdmBooksLMonthText.Text = "Your Total Admin EBooks Last Month (" + lastmonth.ToString() + ")";

        lblCurrentMonthTitle.Text = "Current Month - " + currentmonth.ToString();
        lblLastMonthTitle.Text = "Last Month - " + lastmonth.ToString();

        if (ds.Tables[2].Rows.Count > 0)
        {
            DataRow utRow2 = ds.Tables[2].Rows[0];
            //lblTotAdmBooks.Text = utRow2["yourAdminEBookscount"].ToString();
            //lblTotAdmBooksCMonth.Text = utRow2["yourAdminEBooksSoldCurrentMonth"].ToString();
            //lblTotAdmBooksLMonth.Text = utRow2["yourAdminEBooksSoldLastMonth"].ToString();
        }

        if (ds.Tables[3].Rows.Count > 0)
        {
            DataRow utRow3 = ds.Tables[3].Rows[0];
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            DataView dv1 = ds.Tables[2].DefaultView;
            gridBankInBys.DataSource = dv1;
            gridBankInBys.DataBind();
        }

        if (ds.Tables[3].Rows.Count > 0)
        {
            DataView dv2 = ds.Tables[3].DefaultView;
            GridView1.DataSource = dv2;
            GridView1.DataBind();
        }

    }
}