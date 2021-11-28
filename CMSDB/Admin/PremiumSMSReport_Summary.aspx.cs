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

public partial class Admin_PremiumSMSReport_Summary : System.Web.UI.Page
{
    DataSet dsB;
    DataView dvB;
    DataSet dsP;
    DataView dvP;
    DataSet dsA;
    DataView dvA;
    DataSet dsI;
    DataView dvI;
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
        Decimal vBookstore = 0;
        Decimal vPartner = 0;
        Decimal vAuthor = 0;
        Decimal vIntroducer = 0;

         int vUserID = Convert.ToInt32(Session["UserID"]);

         //ds = objPS.PremiumSMS_Summary(ViewState["mobileValPS"].ToString());

         dsB = objPS.PremiumSMS_ReportFULL_Bookstore(ViewState["mobileValPS"].ToString(), 0);
         dsP = objPS.PremiumSMS_ReportFULL_Sponsor(ViewState["mobileValPS"].ToString(), 0);
         dsA = objPS.PremiumSMS_ReportFULL_Author(ViewState["mobileValPS"].ToString(), 0);
         dsI = objPS.PremiumSMS_ReportFULL_Introducer(ViewState["mobileValPS"].ToString(), 0);

         if (dsB.Tables[1].Rows.Count > 0)
         {
             dvB = dsB.Tables[1].DefaultView;
             DataRow utRowB = dsB.Tables[1].Rows[0];
             lblIncentive.Text = "USD " + utRowB["SumPrice"].ToString();
             vBookstore = Convert.ToDecimal(utRowB["SumPrice"].ToString());
         }

         if (dsP.Tables[1].Rows.Count > 0)
         {
             dvP = dsP.Tables[1].DefaultView;
             DataRow utRowP = dsP.Tables[1].Rows[0];
             lblIncentiveS.Text = "USD " + utRowP["SumPrice"].ToString();
             vPartner = Convert.ToDecimal(utRowP["SumPrice"].ToString());
         }

         if (dsA.Tables[1].Rows.Count > 0)
         {
             dvA = dsA.Tables[1].DefaultView;
             DataRow utRowA = dsA.Tables[1].Rows[0];
             lblIncentiveA.Text = "USD " + utRowA["SumPrice"].ToString();
             vAuthor = Convert.ToDecimal(utRowA["SumPrice"].ToString());
         }

         if (dsI.Tables[1].Rows.Count > 0)
         {
             dvI = dsI.Tables[1].DefaultView;
             DataRow utRowI = dsI.Tables[1].Rows[0];
             lblIncentiveI.Text = "USD " + utRowI["SumPrice"].ToString();
             vIntroducer = Convert.ToDecimal(utRowI["SumPrice"].ToString());
         }

         lblTotal.Text = "USD " + (vBookstore + vPartner + vAuthor + vIntroducer);
    }
}