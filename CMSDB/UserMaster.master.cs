using System;
using System.Collections.Generic;
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

public partial class UserMaster : System.Web.UI.MasterPage
{
    CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();

    protected void Page_PreInit(object sender, EventArgs e)
    {
       // HtmlLink CssLink = new HtmlLink();
       // CssLink = (HtmlLink)Master.FindControl("UserMasterCss");
       //// CssLink.Href = "App_Themes/Common/TestCommonStyleSheet.css";
       // string vMasterCSSname = objBAL_HomePg.GetMasterCSS(Convert.ToInt32(Session["UserID"]));
       // CssLink.Href = "App_Themes/Common/" + vMasterCSSname;

    }



    protected void Page_Load(object sender, EventArgs e)
    {

       
        DataSet MainDS;
        DataTable tbMenu;
        //DataTable tbNews;
        DataTable tbHomePgContent;
        //DataTable tbEvents;
        //DataTable tbTestimonials;
        //DataTable tbFollowus;
        DataTable tbTopRowLinks;


        //UserMasterCss.Href = "App_Themes/Common/TestCommonStyleSheet.css";

        //HtmlLink CssLink = new HtmlLink();
        //CssLink = (HtmlLink)Master.FindControl("UserMasterCss");
        // CssLink.Href = "App_Themes/Common/TestCommonStyleSheet.css";

        //string vMasterCSSname = objBAL_HomePg.GetMasterCSS(Convert.ToInt32(Session["ClientID"]));
        //UserMasterCss.Href = "App_Themes/Common/" + vMasterCSSname;

        if(Session["MasterPageCss"] != null)
        UserMasterCss.Href = "App_Themes/Common/" + Session["MasterPageCss"].ToString();

            //UserMasterCss.Href = "App_Themes/Common/UserMaster_Green.css";
            


       if (!IsPostBack)
        {
           

            string tmpCurrPageName = Path.GetFileNameWithoutExtension(Request.PhysicalPath);

            if (tmpCurrPageName.Contains("default") || (tmpCurrPageName.Contains("dt")) || tmpCurrPageName.Contains("Users"))
            {
                PanelContentLeft.Visible = false;
                dvContentRight.Attributes.Add("class", "ContentRight99");
            }
            else
            {
                PanelContentLeft.Visible = true;
                dvContentRight.Attributes.Add("class", "ContentRight");
            }
            

            //MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["UserID"]));

            MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));


            tbMenu = MainDS.Tables[0];              //tbltopMenuLinks
            tbHomePgContent = MainDS.Tables[1];     //tblHomePgSettings
            tbTopRowLinks = MainDS.Tables[8];      //tblRow Links

            int i = 1;

            //--- Load other Homepage Content and Title  --//
            #region Retrieve HomePageContent


            for (i = 0; i <= tbHomePgContent.Rows.Count - 1; i++)
            {
                DataRow HpgRow = tbHomePgContent.Rows[i];

                //DateTime dtn = Convert.ToDateTime(HpgRow["tstCreatedDate"].ToString());
                //string tFooter = "By " + HpgRow["tstByName"].ToString() + " - " + dtn.ToString("MMM dd, yyyy");

                //.Default Language 

                string selectedLanguage = string.Empty;
                string tmpDefLang = HpgRow["LangCulture"].ToString();

                if ((Session["defLanguage"].ToString() == null) || (Session["defLanguage"].ToString() == ""))
                {

                if (tmpDefLang.Trim() == "")
                    selectedLanguage = GlobalVar.Lang_English;
                else
                    selectedLanguage = tmpDefLang.Trim();


                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

                Session["defLanguage"] = selectedLanguage;
               
                }


              

                //Images
                string tmpLogoImage = HpgRow["LogoImg"].ToString();
                if (tmpLogoImage.Substring(0, 8) == "LogoTemp")
                {
                    string tmpCompanyName = HpgRow["CompanyName"].ToString();
                    string tmpLogoHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                    //tmpLogoHtml = tmpLogoHtml + "&nbsp; <font class='LogoText'>" + tmpCompanyName + "</font>";
                    dvLogoImage.InnerHtml = tmpLogoHtml;

                    if (tmpCompanyName.Length > 25)
                    {
                        dvLogoText.InnerHtml = "<font class='LogoText3'>" + tmpCompanyName + "</font>";
                    }
                    else if (tmpCompanyName.Length > 20)
                    {
                        dvLogoText.InnerHtml = "<font class='LogoText2'>" + tmpCompanyName + "</font>";
                    }
                    else
                    {
                        dvLogoText.InnerHtml = "<font class='LogoText'>" + tmpCompanyName + "</font>";
                    }

                    //dvLogoText.InnerHtml = "<font class='LogoText'>" + tmpCompanyName + "</font>";
                    
                    //dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                }
                else
                {
                    dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                }


                // if Banner is a flash file (.swf) then 

                if (HpgRow["BannerImg"].ToString().Contains(".swf"))
                {
                    // rdoBannerImage.Items.Add(new ListItem(String.Format("<object width='800' height='200'><param name='movie' value='{0}'><embed src='{0}' width='800' height='200'></embed></object>", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString())); ;
                    dvBannerImg.InnerHtml = "<object width='800' height='200'><param name='movie' value='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "'><embed src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' width='800' height='200'></embed></object>";
                }
                else
                {
                    dvBannerImg.InnerHtml = "<img alt='banner image'  class='divCssBannerImg' src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' />";
                }

                //dvBannerImg.InnerHtml = "<img alt='banner image'  class='divCssBannerImg' src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' />";

                
              // dvCopyRights.InnerText = HpgRow["CopyRightsInfo"].ToString();


            }

            #endregion


            //retrieve Menu table data 
            #region Retrieve Menu Links

            string tmpCultureMenuName = string.Empty;
            string tmpMenuName = string.Empty;

            StringBuilder sbMenu = new StringBuilder();
            StringBuilder SbMenuMore = new StringBuilder();
            string strMenuBarChars = string.Empty;

            sbMenu.Append("<ul>");

            foreach (DataRow mRow in tbMenu.Rows)
            {

                String TmpMenuEncodedName = "UsersOwnPage.aspx?Bt=" + mRow["ButtonNo"].ToString() + "&BN=" + HttpUtility.UrlEncode(mRow["LinkName"].ToString());
                //if (i < 10)
                //{
                sbMenu.Append("<li>");
                if (mRow["LinkURL"].ToString().Contains("UsersOwnPage"))
                    sbMenu.Append("<a class='links_MainMenuBar' href='" + TmpMenuEncodedName + "'>");
                else
                    sbMenu.Append("<a class='links_MainMenuBar' href='" + mRow["LinkURL"].ToString() + "'>");


                    tmpMenuName = mRow["LinkName"].ToString().Trim();
                    tmpCultureMenuName = (string)GetGlobalResourceObject("LangResources", tmpMenuName.ToLower());
                    if (tmpCultureMenuName != null)
                    {
                        sbMenu.Append(tmpCultureMenuName);
                        strMenuBarChars += tmpCultureMenuName;
                    }
                    else
                    {
                        sbMenu.Append(mRow["LinkName"].ToString());
                        strMenuBarChars += mRow["LinkName"].ToString();
                    }

                    sbMenu.Append("</a></li>");
                //}
                //else
                //{
                //    //SbMenuMore.Append("<li>");
                //    //SbMenuMore.Append("<a class='indentmenuDropDown' href='" + mRow["LinkURL"].ToString() + "'>");
                //    //SbMenuMore.Append(mRow["LinkName"].ToString());
                //    //SbMenuMore.Append("</a></li>");
                //}


                i++;


                //Response.Write(mRow["LinkID"].ToString() + "|" + mRow["LinkName"].ToString() + "-");
            }

            //sbMenu.Append("<li>");
            //sbMenu.Append("<a href='#'> MORE </a>");
            //sbMenu.Append(SbMenuMore.ToString());
            //sbMenu.Append("</li>");

            sbMenu.Append("</ul>");

            if (strMenuBarChars.Length > 81)
            {
                sbMenu.Replace("links_MainMenuBar", "links_MainMenuBar70");
            }

            dvTopMenu.InnerHtml = "";
            dvTopMenu.InnerHtml = sbMenu.ToString();

           // DownMenu.InnerHtml = sbMenu.ToString();


            #endregion


            //retrieve Top Most Menu Links 
            #region Code Section : TopMost Row Links

            //retrieve and Render TopMenu Menu 
            StringBuilder topRowMenu = new StringBuilder();
            String tmpTopRowLinkName = string.Empty;

            foreach (DataRow mRow in tbTopRowLinks.Rows)
            {
                tmpTopRowLinkName = mRow["LinkName"].ToString().Trim();

                UserControl ucTopMenu = (UserControl)Page.Master.FindControl("TopMostMenu1");
                if (ucTopMenu != null)
                {

                    if (tmpTopRowLinkName.ToUpper().Contains("HOME"))
                    {
                        HyperLink objHypHome = (HyperLink)ucTopMenu.FindControl("HypHome");
                        if (objHypHome != null) objHypHome.Visible = true;

                        HtmlImage objImgHome = (HtmlImage)ucTopMenu.FindControl("imgHome");
                        if (objImgHome != null) objImgHome.Visible = true;
                    }
                    else if (tmpTopRowLinkName.ToUpper().Contains("FREE"))
                    {
                        HyperLink objHypFreeSMS = (HyperLink)ucTopMenu.FindControl("HypFreeSMS");
                        if (objHypFreeSMS != null) objHypFreeSMS.Visible = true;
                    }
                    else if (tmpTopRowLinkName.ToUpper().Contains("CONTACT"))
                    {
                        HyperLink objHypContactUs = (HyperLink)ucTopMenu.FindControl("HypContactUs");
                        if (objHypContactUs != null) objHypContactUs.Visible = true;
                    }
                    else if (tmpTopRowLinkName.ToUpper().Contains("CUSTOMER"))
                    {
                        HyperLink objHypSMSlogin = (HyperLink)ucTopMenu.FindControl("HypSMSlogin");
                        if (objHypSMSlogin != null) objHypSMSlogin.Visible = true;

                        HtmlImage ObjimgCustLogin = (HtmlImage)ucTopMenu.FindControl("imgCustLogin");
                        if (ObjimgCustLogin != null) ObjimgCustLogin.Visible = true;
                    }
                    else if (tmpTopRowLinkName.ToUpper().Contains("LANGUAGE"))
                    {

                        //... the language dropdown is outside of the Top Menu 
                        HtmlGenericControl objDvLangDpd = (HtmlGenericControl)Page.Master.FindControl("dvLangdropDown");
                        if (objDvLangDpd != null) objDvLangDpd.Visible = true;

                    }




                }



            }

            #endregion  //... end of Topmost Row Links 


        }


    }
}

