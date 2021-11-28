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

public partial class O_MasterBlue : System.Web.UI.MasterPage
{
    DataSet MainDS;
    DataTable tbTopRowLinks;

    protected void Page_Load(object sender, EventArgs e)
    {
        string tmpSearch = string.Empty;
        tmpSearch = txtSearch.Text.ToString();

        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURLnew().ToString();
        }

        if (tmpSearch.Trim() != "")
        {
            Server.Transfer("O_dtSearchList.aspx?sVal=" + tmpSearch.ToString());
        }                   
            newDBS nds = new newDBS();
            string cssVal = nds.WebDesign_getCSSnew(Convert.ToInt32(Session["ClientID"].ToString()));
            Session["css"] = cssVal;
            string masterPageVal = nds.WebDesign_getMasterPagenew(Convert.ToInt32(Session["ClientID"].ToString()));
            Session["MasterPageFile"] = masterPageVal;
       
        if (Session["css"].ToString().ToUpper() == "RED")
        {
            tmpMasterPluginCSS.Href = "assets/css/Red/plugins.min.css";
            tmpMasterStyleCSS.Href = "assets/css/Red/style.css";
        }
        else if (Session["css"].ToString().ToUpper() == "ORANGE")
        {
            tmpMasterPluginCSS.Href = "assets/css/Orange/plugins.min.css";
            tmpMasterStyleCSS.Href = "assets/css/Orange/style.css";
        }
        else if (Session["css"].ToString().ToUpper() == "BLUE")
        {
            tmpMasterPluginCSS.Href = "assets/css/Blue/plugins.min.css";
            tmpMasterStyleCSS.Href = "assets/css/Blue/style.css";
        }
        else if (Session["css"].ToString().ToUpper() == "GREEN")
        {
            tmpMasterPluginCSS.Href = "assets/css/Green/plugins.min.css";
            tmpMasterStyleCSS.Href = "assets/css/Green/style.css";
        }
        else if (Session["css"].ToString().ToUpper() == "BLACK")
        {
            tmpMasterPluginCSS.Href = "assets/css/Black/plugins.min.css";
            tmpMasterStyleCSS.Href = "assets/css/Black/style.css";
        }
        else
        {
            tmpMasterPluginCSS.Href = "assets/css/Black/plugins.min.css";
            tmpMasterStyleCSS.Href = "assets/css/Black/style.css";
        }

        if (HttpContext.Current.Session["cLogin"] == null)
        { }
        else if (HttpContext.Current.Session["cLogin"].ToString() == "")
        { }
        else
        {
            string[] arrsignin = Session["cLogin"].ToString().Split('-');

            hypUserLogin.HRef = "#";
            lblSignin.Text = arrsignin[1].ToString();

            DataSet ds2;
            newDBS clsObjNewDbs = new newDBS();
            ds2 = clsObjNewDbs.user_getBillPlzPurchaseHistory(Session["cLogin"].ToString());
            if (ds2.Tables[0].Rows.Count > 0)
            {
                hypBankingHistory.Visible = true;
            }
        }        

        CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();
        MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));
        tbTopRowLinks = MainDS.Tables[8];

        StringBuilder sb = new StringBuilder();
        StringBuilder sb1 = new StringBuilder();
       
        sb.AppendLine("<div class='container-fluid'>");
        sb.AppendLine("<ul class='top-dropdowns'>");

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

        //liEvendorLogin.Visible = false;
        //liPrepaidLogin.Visible = false;

        if (tbTopRowLinks.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)tbTopRowLinks.Rows[0];
            foreach (DataRow cRow in tbTopRowLinks.Rows)
            {
                //string abc = cRow["LinkName"].ToString().ToUpper().Trim();
                //Response.Write(cRow["LinkName"].ToString() + "<br>");
                if (cRow["LinkName"].ToString().ToUpper() == "HOME")
                {
                    if (Session["MasterPageFile"].ToString().ToUpper() == "O_MASTERNEW.MASTER")
                    {
                        sb.AppendLine("<li><a href='O_dtNew.aspx'><span>Home</span></a></li>");
                    }
                    else
                    {
                        sb.AppendLine("<li><a href='O_dtBlue.aspx'><span>Home</span></a></li>");
                    }
                }
                if (cRow["LinkName"].ToString().ToUpper() == "CONTACT US")
                {
                    sb.AppendLine("<li><a href='O_dtContctUs.aspx'><span>Contact Us</span></a></li>");
                }
                if (cRow["LinkName"].ToString().ToUpper() == "EVENDOR LOGIN")
                {
                    sb.AppendLine("<li><a href='http://www.evenchiselogin.com/ev.html' target='_blank'><span>DFranchisee Login</span></a></li>");
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim().Substring(0,4) == "BANK")
                {
                    sb1.AppendLine("<a href='O_dtBankInTop.aspx' title='Bank-In Form '><i class='fa fa-user fa-2x fa-university'></i></a>");
                }
                if (cRow["LinkName"].ToString().ToUpper() == "GOOGLE TRANSLATER")
                {
                    dvGoogleTranslater.Visible = true;
                } 
            }
        }

        sb.AppendLine("</ul>");
        sb.AppendLine("</div>");

        dvTopMostMenu.InnerHtml = sb.ToString();
        dvBankInForm.InnerHtml = sb1.ToString();

        newDBS ndspp = new newDBS();
        string storeidVal = string.Empty;
        storeidVal = ndspp.user_getStoreID(Convert.ToInt32(Session["ClientID"].ToString()));
        if (storeidVal == "")
        {
            dvUserMenu.Visible = false;
        }

        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["ClientID"]).ToString());
        string userCurrency = string.Empty;
        userCurrency = "$";
        if (dst.Tables[0].Rows.Count>0)
        {
            userCurrency = dst.Tables[0].Rows[0]["Currency"].ToString();
        }

        dvSCart.Visible = false;
        DataTable CartDataTable = null;
        int tmpRowCount = 0;
        decimal tmpPrice = 0;
        StringBuilder sbP = new StringBuilder();
        if (HttpContext.Current.Session["basket"] != null)
        {
            CartDataTable = (DataTable)HttpContext.Current.Session["basket"];
        }
        if (CartDataTable != null)
        {
            if (CartDataTable.Rows.Count > 0)
            {
                tmpRowCount = CartDataTable.Rows.Count;
                ViewState["ItemsCount"] = tmpRowCount;
                for (int i = 0; i < CartDataTable.Rows.Count; i++)
                {
                    //tmpPrice = CartDataTable.Rows[i][2].ToString();
                    tmpPrice = tmpPrice + Convert.ToDecimal(String.Format("{0:0.00}", CartDataTable.Rows[i][2].ToString()));

                    sbP.AppendLine("<div class='product product-sm'>");
                    sbP.AppendLine("<figure>");
                    sbP.AppendLine("<img Height='150' Width='80' src='" + ResolveUrl(CartDataTable.Rows[i]["ImageURL"].ToString()) + "'>");
                    sbP.AppendLine("</figure>");
                    sbP.AppendLine("<div class='product-meta'>");
                    sbP.AppendLine("<h5 class='product-title'>" + CartDataTable.Rows[i]["name"].ToString() + "</h5>");
                    sbP.AppendLine("<div class='product-price-container'><span class='product-price'>" + userCurrency + " " + CartDataTable.Rows[i][2].ToString() + "</span></div>");
                    sbP.AppendLine("</div>");
                    //sbP.AppendLine("<a href='O_dtCart.aspx' class='icon delete-btn lighter' title='Delete Product'><span class='sr-only'>Delete product</span></a>");
                    sbP.AppendLine("</div>");
                }
                LTLprice.Text = tmpPrice.ToString();
                LTLprice1.Text = tmpPrice.ToString();
                dvProductList.InnerHtml = sbP.ToString();
            }
        }

        if (tmpRowCount>0)
        {
            dvSCart.Visible = true;
            LTLcartFA.Text = tmpRowCount.ToString();
            LTLcartFA1.Text = tmpRowCount.ToString();            
        }

        if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
        {
            cLogin.Title = "My Account";
        }
        else
        {
            string cLoginVal = Session["cLogin"].ToString();
            cLoginVal = cLoginVal.Replace(storeidVal + "-", "");
            cLogin.Title = cLoginVal + " Account";            
        }
        
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
