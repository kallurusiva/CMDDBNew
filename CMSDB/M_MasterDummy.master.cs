using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Threading;
using CMSv3.BAL;
using System.Data.SqlClient;
using System.IO;

public partial class M_MasterDummy : System.Web.UI.MasterPage
{
    DataSet MainDS;
    DataTable tbTopRowLinks;

    protected void Page_Load(object sender, EventArgs e)
    {

        //Session["ClientID"] = "7661";
        newDBS nds = new newDBS();
        string cssVal = nds.WebDesign_getCSSnew(Convert.ToInt32(Session["ClientID"].ToString()));

        Session["css"] = cssVal;

        string tmpMasterfile = string.Empty;
        string tmpMasterCss = string.Empty;

        DataSet mps = nds.retrieve_MainPageSettings(Session["ClientID"].ToString());
        DataTable dtSettings = mps.Tables[0];

        string domainTitle = "";
        string domainDescription = "";
        string domainKeyword = "";
        string facebookPixel = "";

        //========= USER eStore Settings 

        if (dtSettings.Rows.Count > 0)
        {
            DataRow dr = dtSettings.Rows[0];

            domainTitle = dr["domainTitle"].ToString();
            domainDescription = dr["domainDescription"].ToString();
            domainKeyword = dr["domainKeyword"].ToString();
            facebookPixel = dr["facebookPixel"].ToString();
        }

        if (domainTitle != "") { Page.Title = domainTitle.ToString(); }
        if (domainTitle != "") { metaTitle.Content = domainTitle.ToString(); }
        if (domainDescription != "") { metaDescription.Content = domainDescription.ToString(); }
        if (domainKeyword != "") { metaKeywords.Content = domainKeyword.ToString(); }
        //if (facebookPixel != "")
        //{
        //    if (Page != null && !Page.ClientScript.IsClientScriptBlockRegistered("f, b, e, v, n, t, s"))
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(typeof(CommonFunctions), "f, b, e, v, n, t, s", facebookPixel);
        //    }
        //}

        HtmlGenericControl newControl = new HtmlGenericControl("head");
        newControl.Attributes["someAttr"] = "some value";
        Page.Header.Controls.Add(newControl);

        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myAlertScript", "alert('hello!')", true);

        if (Session["css"].ToString().ToUpper() == "RED")
        {
            tmpMasterPluginCSS.Href = "AssetsNew/css/red/css/bootstrap.min.css";
            tmpMasterStyleCSS.Href = "AssetsNew/css/red/css/bootstrap-theme.min.css";
            tmpMasterStyleAwesome.Href = "AssetsNew/css/red/css/font-awesome.min.css";
            tmpMasterStyleMain.Href = "AssetsNew/css/red/css/main.css";
        }
        else if (Session["css"].ToString().ToUpper() == "ORANGE")
        {
            tmpMasterPluginCSS.Href = "AssetsNew/css/orange/css/bootstrap.min.css";
            tmpMasterStyleCSS.Href = "AssetsNew/css/orange/css/bootstrap-theme.min.css";
            tmpMasterStyleAwesome.Href = "AssetsNew/css/orange/css/font-awesome.min.css";
            tmpMasterStyleMain.Href = "AssetsNew/css/orange/css/main.css";
        }
        else if (Session["css"].ToString().ToUpper() == "BLUE")
        {
            tmpMasterPluginCSS.Href = "AssetsNew/css/blue/css/bootstrap.min.css";
            tmpMasterStyleCSS.Href = "AssetsNew/css/blue/css/bootstrap-theme.min.css";
            tmpMasterStyleAwesome.Href = "AssetsNew/css/blue/css/font-awesome.min.css";
            tmpMasterStyleMain.Href = "AssetsNew/css/blue/css/main.css";
        }
        else if (Session["css"].ToString().ToUpper() == "GREEN")
        {
            tmpMasterPluginCSS.Href = "AssetsNew/css/green/css/bootstrap.min.css";
            tmpMasterStyleCSS.Href = "AssetsNew/css/green/css/bootstrap-theme.min.css";
            tmpMasterStyleAwesome.Href = "AssetsNew/css/green/css/font-awesome.min.css";
            tmpMasterStyleMain.Href = "AssetsNew/css/green/css/main.css";
        }
        else if (Session["css"].ToString().ToUpper() == "BLACK")
        {
            tmpMasterPluginCSS.Href = "AssetsNew/css/black/css/bootstrap.min.css";
            tmpMasterStyleCSS.Href = "AssetsNew/css/black/css/bootstrap-theme.min.css";
            tmpMasterStyleAwesome.Href = "AssetsNew/css/black/css/font-awesome.min.css";
            tmpMasterStyleMain.Href = "AssetsNew/css/black/css/main.css";
        }
        else
        {
            tmpMasterPluginCSS.Href = "AssetsNew/css/blue/css/bootstrap.min.css";
            tmpMasterStyleCSS.Href = "AssetsNew/css/blue/css/bootstrap-theme.min.css";
            tmpMasterStyleAwesome.Href = "AssetsNew/css/blue/css/font-awesome.min.css";
            tmpMasterStyleMain.Href = "AssetsNew/css/blue/css/main.css";
        }

        CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();
        MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));
        tbTopRowLinks = MainDS.Tables[8];

        SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();
        SqlCommand dbCmd = new SqlCommand("usp_Retreive_UserMasterPageAndCss", dbConn);
        dbCmd.CommandType = CommandType.StoredProcedure;
        dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = Convert.ToInt32(Session["ClientID"]);
        SqlDataReader dbReader;
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpMasterfile = dbReader["MasterPageName"].ToString();
                tmpMasterCss = dbReader["MasterCSS"].ToString();
            }
        }

        dbConn.Close();

        StringBuilder sb = new StringBuilder();
        StringBuilder sb1 = new StringBuilder();

        if (tbTopRowLinks.Rows.Count > 0)
        {

            DataRow tRows = (DataRow)tbTopRowLinks.Rows[0];

            foreach (DataRow cRow in tbTopRowLinks.Rows)
            {
                if (cRow["LinkName"].ToString().ToUpper() == "HOME")
                {
                    if (tmpMasterfile == "N_Master.master" || tmpMasterfile == "TmpMasterGen1.master")
                    {
                        sb.AppendLine("<a href='N_MainDummy.aspx'><i class='fa fa-home' aria-hidden='true'></i> Home</a>");
                    }
                    else if (tmpMasterfile == "N_Master2.master" || tmpMasterfile == "TmpMasterGen2.master")
                    {
                        sb.AppendLine("<a href='N_Main2.aspx'><i class='fa fa-home' aria-hidden='true'></i> Home</a>");
                    }
                    else if (tmpMasterfile == "N_Master3.master" || tmpMasterfile == "TmpMasterGen3.master")
                    {
                        sb.AppendLine("<a href='N_Main3.aspx'><i class='fa fa-home' aria-hidden='true'></i> Home</a>");
                    }
                    else
                    {
                        sb.AppendLine("<a href='N_MainDummy.aspx'><i class='fa fa-home' aria-hidden='true'></i> Home</a>");
                    }
                }
                if (cRow["LinkName"].ToString().ToUpper() == "CONTACT US")
                {
                    sb.AppendLine("<a href='N_ContactUs.aspx'><i class='fa fa-phone' aria-hidden='true'></i> Contact Us</a>");
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim().Substring(0, 4) == "BANK")
                {
                    sb.AppendLine("<a href='N_BankInTop.aspx'><i class='fa fa-file-text' aria-hidden='true'></i> Bank-in Form</a>");
                }
                if (cRow["LinkName"].ToString().ToUpper() == "EVENDOR LOGIN")
                {
                    sb.AppendLine("<a href='http://14.102.146.116/WebApps/EBook/ebook.html' target='_blank'><i class='fa fa-lock' aria-hidden='true'></i> E-vendor Login</a>");
                }
                if (cRow["LinkName"].ToString().ToUpper() == "GOOGLE TRANSLATER")
                {
                    dvGoogleTranslater.Visible = true;
                }
            }
        }

        string cLogin = string.Empty;
        string storeidVal = string.Empty;
        newDBS ndspp = new newDBS();
        storeidVal = ndspp.user_getStoreID(Convert.ToInt32(Session["ClientID"].ToString()));

        if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
        {
            cLogin = "My Account";
        }
        else
        {
            cLogin = Session["cLogin"].ToString() + " Account";
            cLogin = cLogin.Replace(storeidVal + "-", "");
        }

        if (storeidVal == "")
        {
        }
        else
        {
            StringBuilder sbUM = new StringBuilder();
            sbUM.AppendLine("<ul class='nav navbar-nav navbar-right'>");
            sbUM.AppendLine("<li class='dropdown'>");
            sbUM.AppendLine("<a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-expanded='false'><i class='fa fa-user' aria-hidden='true'></i> " + cLogin.ToString() + " <span class='caret'></span></a>");
            sbUM.AppendLine("<ul class='dropdown-menu' role='menu'>");
            sbUM.AppendLine("<li><a href='N_User_Login.aspx'>Sign In/ Register</a></li>");
            sbUM.AppendLine("<li class='divider'></li>");
            sbUM.AppendLine("<li><a href='N_User_Account.aspx'>My Account</a></li>");
            sbUM.AppendLine("<li><a href='N_User_ChangePassword.aspx'>Change Password</a></li>");
            sbUM.AppendLine("<li class='divider'></li>");
            //sbUM.AppendLine("<li><a href='N_User_CreditInfo.aspx'>Credit Info</a></li>");
            //sbUM.AppendLine("<li><a href='N_User_Topup.aspx'>Top Up Credit</a></li>");
            //sbUM.AppendLine("<li><a href='N_User_TopupHistory.aspx'>Top Up History</a></li>");
            //sbUM.AppendLine("<li class='divider'></li>");
            //sbUM.AppendLine("<li><a href='N_User_PrepaidPurchase_History.aspx'>Prepaid</a></li>");
            sbUM.AppendLine("<li><a href='N_User_DirectBankin_Hitory.aspx'>Direct Bank-In</a></li>");
            sbUM.AppendLine("<li><a href='N_User_Paypal_History.aspx'>Paypal</a></li>");
            sbUM.AppendLine("<li class='divider'></li>");
            sbUM.AppendLine("<li><a href='N_User_Signout.aspx'>Sign Out</a></li>");
            sbUM.AppendLine("</ul>");
            sbUM.AppendLine("</li>");
            sbUM.AppendLine("</ul>");

            dvUserMenu.InnerHtml = sbUM.ToString();
        }

        dvTopMostMenu.InnerHtml = sb.ToString();

    }
}
