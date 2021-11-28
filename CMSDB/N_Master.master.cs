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

public partial class N_Master : System.Web.UI.MasterPage
{
    DataSet MainDS;
    DataTable tbTopRowLinks;

    protected void Page_Load(object sender, EventArgs e)
    {

        //Session["ClientID"] = "7661";
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURLnew().ToString();
        }
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
        if (facebookPixel != "")
        {
            Page.Header.Controls.Add(
            new LiteralControl(facebookPixel));
        }

        //HtmlGenericControl newControl = new HtmlGenericControl("head");
        //newControl.Attributes["someAttr"] = "some value";
        //Page.Header.Controls.Add(newControl);

        //Page.ClientScript.RegisterClientScriptBlock(GetType(), "myAlertScript", "alert('Welcome to ebooks world')", true);  

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

        //sb.AppendLine("<asp:TextBox ID='tmpSearch' CssClass='form-control' runat='server' ToolTip='Search' Visible='true' Width='150px'></asp:TextBox>");
        //sb.AppendLine("<asp:Button ID='btnSearch' CssClass='fa fa-home' runat='server' Text='Search' Width='65px' OnClick='btnSearch_Click'/>");

        if (tbTopRowLinks.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)tbTopRowLinks.Rows[0];

            foreach (DataRow cRow in tbTopRowLinks.Rows)
            {
                if (cRow["LinkName"].ToString().ToUpper() == "HOME")
                {
                    if (tmpMasterfile == "N_Master.master" || tmpMasterfile == "TmpMasterGen1.master")
                    {
                        sb.AppendLine("<a href='N_Main.aspx'><i class='fa fa-home' aria-hidden='true'></i> Home</a>");
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
                        sb.AppendLine("<a href='N_Main.aspx'><i class='fa fa-home' aria-hidden='true'></i> Home</a>");
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
                    sb.AppendLine("<a href='http://www.evenchiselogin.com/ev.html' target='_blank'><i class='fa fa-lock' aria-hidden='true'></i> DFranchisee Login</a>");
                }
                if (cRow["LinkName"].ToString().ToUpper() == "GOOGLE TRANSLATER")
                {
                    dvGoogleTranslater.Visible = true;
                }

            }
        }


        //sb.AppendLine("<a href='#'><i class='fa fa-home' aria-hidden='true'></i> Search</a>");

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

            if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
            {
                sbUM.AppendLine("<ul class='nav navbar-nav navbar-right'>");
                sbUM.AppendLine("<li class='dropdown'>");
                sbUM.AppendLine("<a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-expanded='false'><i class='fa fa-user' aria-hidden='true'></i> " + cLogin.ToString() + " <span class='caret'></span></a>");
                sbUM.AppendLine("<ul class='dropdown-menu' role='menu'>");
                sbUM.AppendLine("<li><a href='N_User_Login.aspx'>Sign In/ Register</a></li>");
                sbUM.AppendLine("<li class='divider'></li>");
                sbUM.AppendLine("<li><a href='N_User_Account.aspx'>My Account</a></li>");
                sbUM.AppendLine("<li class='divider'></li>");
                sbUM.AppendLine("<li><a href='N_User_ChangePassword.aspx'>Change Password</a></li>");
                sbUM.AppendLine("<li class='divider'></li>");
                //sbUM.AppendLine("<li><a href='N_User_CreditInfo.aspx'>Credit Info</a></li>");
                //sbUM.AppendLine("<li><a href='N_User_Topup.aspx'>Top Up Credit</a></li>");
                //sbUM.AppendLine("<li><a href='N_User_TopupHistory.aspx'>Top Up History</a></li>");
                //sbUM.AppendLine("<li class='divider'></li>");
                //sbUM.AppendLine("<li><a href='N_User_PrepaidPurchase_History.aspx'>Prepaid</a></li>");
                //sbUM.AppendLine("<li><a href='N_User_DirectBankin_Hitory.aspx'>Direct Bank-In</a></li>");
                sbUM.AppendLine("<li><a href='N_User_Paypal_History.aspx'>CreditCard Purchases</a></li>");
                sbUM.AppendLine("<li><a href='N_User_BookList_Purchased.aspx'>List EBook Purchased</a></li>");
                sbUM.AppendLine("<li class='divider'></li>");
                sbUM.AppendLine("<li><a href='N_User_Signout.aspx'>Sign Out</a></li>");
                sbUM.AppendLine("<li class='divider'></li>");
                sbUM.AppendLine("</ul>");
                sbUM.AppendLine("</li>");
                sbUM.AppendLine("</ul>");
            }
            else
            {
                DataSet ds2;
                newDBS clsObjNewDbs = new newDBS();
                ds2 = clsObjNewDbs.user_getBillPlzPurchaseHistory(Session["cLogin"].ToString());

                string[] arrsignin = Session["cLogin"].ToString().Split('-');

                sbUM.AppendLine("<ul class='nav navbar-nav navbar-right'>");
                sbUM.AppendLine("<li class='dropdown'>");
                sbUM.AppendLine("<a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-expanded='false'><i class='fa fa-user' aria-hidden='true'></i> " + cLogin.ToString() + " <span class='caret'></span></a>");
                sbUM.AppendLine("<ul class='dropdown-menu' role='menu'>");
                sbUM.AppendLine("<li class='divider'></li>");
                sbUM.AppendLine("<li><a href='N_User_Account.aspx'>My Account</a></li>");
                sbUM.AppendLine("<li class='divider'></li>");
                sbUM.AppendLine("<li><a href='N_User_ChangePassword.aspx'>Change Password</a></li>");
                sbUM.AppendLine("<li class='divider'></li>");
                //sbUM.AppendLine("<li><a href='N_User_CreditInfo.aspx'>Credit Info</a></li>");
                //sbUM.AppendLine("<li><a href='N_User_Topup.aspx'>Top Up Credit</a></li>");
                //sbUM.AppendLine("<li><a href='N_User_TopupHistory.aspx'>Top Up History</a></li>");
                //sbUM.AppendLine("<li class='divider'></li>");
                //sbUM.AppendLine("<li><a href='N_User_PrepaidPurchase_History.aspx'>Prepaid</a></li>");
                //sbUM.AppendLine("<li><a href='N_User_DirectBankin_Hitory.aspx'>Direct Bank-In</a></li>");
                sbUM.AppendLine("<li><a href='N_User_Paypal_History.aspx'>CreditCard Purchases</a></li>");
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    sbUM.AppendLine("<li class='divider'></li>");
                    sbUM.AppendLine("<li><a href='N_User_Banking_History.aspx'>NetBank Purchases</a></li>");
                }
                sbUM.AppendLine("<li class='divider'></li>");
                sbUM.AppendLine("<li><a href='N_User_BookList_Purchased.aspx'>List EBook Purchased</a></li>");
                sbUM.AppendLine("<li class='divider'></li>");
                sbUM.AppendLine("<li><a href='N_User_Signout.aspx'>Sign Out</a></li>");
                sbUM.AppendLine("</ul>");
                sbUM.AppendLine("</li>");
                sbUM.AppendLine("</ul>");
            }

            dvUserMenu.InnerHtml = sbUM.ToString();
        }

        dvTopMostMenu.InnerHtml = sb.ToString();

    }

    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        Server.Transfer("N_SearchList.aspx?sVal=" + tmpSearch.Text.ToString());
    }

    public int GetUserIdfromURLnew()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;
        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();
        string tmpMainURL = Request.Url.OriginalString;
        string OrgURL = Request.Url.OriginalString;
        //tmpMainURL = "www.testhari88.com";
        //tmpMainURL = "eb60123238595.1smsbusiness.com";
        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://
        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        if (tmpMainURL.Contains(OurWebSiteName))
        {
            //subdomain
            string tmpSubDomainURL = tmpMainURL;
            string[] MainURLArr = tmpMainURL.Split('.');
            string userSubDomainName = string.Empty;
            // see if user has typed in www
            if (MainURLArr[0].ToString() == "www")
            {
                userSubDomainName = MainURLArr[1].ToString();
            }
            else
            {
                userSubDomainName = MainURLArr[0].ToString();
            }
            if (userSubDomainName == OurWebSiteName)
            {
                //..user comes to direct website setting the userid to demo as default
                newUserID = 105;
            }
            else
            {
                //..user comes to his sub domain
                newUserID = objBAL_User.GetUserID_BySubDomainName(userSubDomainName);
                CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                //..function get all the details of 1malaysia user into MasUser entity 
                MasFunc.Get_1MalaysiaUser_Details(userSubDomainName, ref objMasUser);

                //if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
                Session["MasUSER"] = objMasUser;
                //.................................................................
                if (objMasUser.MID != "NONE")
                {
                    //Response.Redirect("Mas1UserWebRegistration.aspx");
                }
            }
        }
        else
        {
            //owndomain  or subDomain ??
            //string ownDomain = tmpMainURL;
            string[] OwnURLArr = tmpMainURL.Split('.');
            string userOwnDomainName = string.Empty;
            int DomainType = -1;
            // see if user has typed in www
            if (OwnURLArr[0].ToString() == "www")
            {
                userOwnDomainName = OwnURLArr[1].ToString();
                if (OwnURLArr.Count() > 4)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain
            }
            else
            {
                userOwnDomainName = OwnURLArr[0].ToString();
                if (OwnURLArr.Count() > 3)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain

            }
            //..user comes to his sub domain
            newUserID = objBAL_User.GetUserID_BySubDomainName2(userOwnDomainName, DomainType);
            CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
            CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(userOwnDomainName, ref objMasUser);
            // if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
            Session["MasUSER"] = objMasUser;
            //    //.................................................................

            if (objMasUser.MID != "NONE")
            {
                // Response.Redirect("Mas1UserWebRegistration.aspx");
                //String WebRegURL = "Mas1UserWebRegistration.aspx";
                //StringBuilder sburl = new StringBuilder();
                //sburl.Append("<script>");
                //sburl.Append("window.open('page.html','_blank')");
                //sburl.Append("</script>");
                //Response.Write(sburl.ToString());
                //Response.End();
                //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", WebRegURL));
            }
        }

        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {
            Response.Redirect("PartnerWebRegistrationNew.aspx");
            //Response.Redirect("InValidDomain.aspx");
        }
        return newUserID;
    }

}
