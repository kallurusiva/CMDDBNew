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

public partial class Admin_Ad_MainPageSetting : System.Web.UI.Page
{

    DataSet ds;
    //DataView dv;
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

    int vUserID = 0;
    int vMerchantID = 0;
    String vMobileLoginID = string.Empty;
    String vEStoreID = string.Empty;

    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;


    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion


        Page.MaintainScrollPositionOnPostBack = true;

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

            LoadSettings();
        }

        tblMessageBar.Visible = false;

    }

    protected void LoadSettings()
    {
        string domainTitle = "";
        string domainDescription = "";
        string domainKeyword = "";
        string facebookPixel = "";

        newDBS objPS = new newDBS();
        ds = objPS.retrieve_MainPageSettings(Session["UserID"].ToString());
        DataTable dtSettings = ds.Tables[0];
       

        //========= USER eStore Settings 

        if (dtSettings.Rows.Count > 0)
        {
            DataRow dr = dtSettings.Rows[0];

            domainTitle = dr["domainTitle"].ToString();
            domainDescription = dr["domainDescription"].ToString();
            domainKeyword = dr["domainKeyword"].ToString();
            facebookPixel = dr["facebookPixel"].ToString();

            txtNotifyMobile1.Text = domainTitle.ToString();
            txtNotifyMobile2.Text = domainDescription.ToString();
            txtNotifyMobile3.Text = domainKeyword.ToString();
            txtNotifyMobile4.Text = facebookPixel.ToString();

        }

    }


    protected void BtnNotifications_Click(object sender, EventArgs e)
    {
        string domainTitle = txtNotifyMobile1.Text.ToString();
        string domainDescription = txtNotifyMobile2.Text.ToString();
        string domainKeyword = txtNotifyMobile3.Text.ToString();
        string facebookPixel = txtNotifyMobile4.Text.ToString();

        vUserID = Convert.ToInt32(Session["UserID"].ToString());

        newDBS objPS = new newDBS();
        objPS.update_MainPageSettings(vUserID.ToString(), domainTitle.ToString(), domainDescription.ToString(), domainKeyword.ToString(), facebookPixel.ToString());
        
            CommonFunctions.AlertMessage("Main Page Settings updated Successfully saved.");
            return;
        
    }
   
}
