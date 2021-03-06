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

public partial class Admin_EBAd_InfoFranchiseGSP : System.Web.UI.Page
{
    DataSet ds;
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

    int vUserID = 0;
    int vMerchantID = 0;
    String vMobileLoginID = string.Empty;
    String vEStoreID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        if (!IsPostBack)
        {
            vUserID = Convert.ToInt32(Session["UserID"].ToString());
            vMerchantID = 0;
            vMobileLoginID = "";

            if (Session["MERID"] != null)
                vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
            else
                vMerchantID = 0;


            if (Session["MobileLoginID"] != null)
                vMobileLoginID = Session["MobileLoginID"].ToString();
            else
                vMobileLoginID = "";


            LoadDashBoard();

        }
    }

    protected void LoadDashBoard()
    {
        ds = objEbook.Ebook_GeteStoreID(vUserID);
        DataTable dt = ds.Tables[3];

        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];

            lblInfo.Text = dr["gsinfo"].ToString();

        }
    }

}