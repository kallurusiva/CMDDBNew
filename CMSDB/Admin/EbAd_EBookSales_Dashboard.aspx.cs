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

public partial class Admin_EbAd_EBookSales_Dashboard : System.Web.UI.Page
{
    DataSet ds;
    DataView dv;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        newDBS objPS = new newDBS();
        ds = objPS.EBookSalesDashboard(Session["UserID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            DataRow utRow = ds.Tables[0].Rows[0];
            lblFreeToday.Text = utRow["freeToday"].ToString();
            lblMWalletToday.Text = utRow["mwalletToday"].ToString();
            lblCCToday.Text = utRow["onlineToday"].ToString();
            lblOnlineToday.Text = utRow["ccToday"].ToString();

            lblFree.Text = utRow["free"].ToString();
            lblMWallet.Text = utRow["mwallet"].ToString();
            lblCC.Text = utRow["online"].ToString();
            lblOnline.Text = utRow["cc"].ToString();

            lblOwnAdminBooks.Text = utRow["ownSalesAdminBook"].ToString();
            lblOtherAdminBooks.Text = utRow["otherSalesAdminBook"].ToString();
        }
    }
}