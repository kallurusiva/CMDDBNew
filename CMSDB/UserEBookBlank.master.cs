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
using System.IO;
using CMSv3.BAL;
using System.Data.SqlClient;

public partial class UserEBookBlank : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet MainDS;
        DataTable tbMenu;
        //DataTable tbNews;
        DataTable tbHomePgContent;
        //DataTable tbEvents;
        //DataTable tbTestimonials;
        //DataTable tbFollowus;


        ////--- hiding the login row for template 3 -- //
        //#region hiding login row


        //string tmpCurrPageName = Path.GetFileNameWithoutExtension(Request.PhysicalPath);
        //HtmlTable tmptblLogin = (HtmlTable)Page.FindControl("tblLoginArea");

        //if (tmptblLogin != null)
        //{
        //    if (tmpCurrPageName.Contains("default") || tmpCurrPageName.Contains("Users"))
        //    {
        //        tmptblLogin.Visible = true;
        //        //trLoginRow.Visible = true;
        //    }
        //    else
        //    {
        //        tmptblLogin.Visible = false;
        //        //trLoginRow.Visible = false;
        //    }
        //}
        //#endregion



        if (!IsPostBack)
        {
            CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();

            //MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["UserID"]));




            if (Session["ClientID"] == null)
                Session["ClientID"] = CommonFunctions.fnGetUserIdfromURL();


            MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));

            tbMenu = MainDS.Tables[0];              //tbltopMenuLinks
            tbHomePgContent = MainDS.Tables[1];     //tblHomePgSettings


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
                    // tmpLogoHtml = tmpLogoHtml + "&nbsp; <font class='LogoText'>" + tmpCompanyName + "</font>";
                 
                    //dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                }
                else
                {
                    //dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                }

              





                //dvCopyRights.InnerText = HpgRow["CopyRightsInfo"].ToString();


            }

            #endregion


            //retrieve Menu table data 
            #region Retrieve Menu Links

            string tmpCultureMenuName = string.Empty;
            string tmpMenuName = string.Empty;
            string strMenuBarChars = string.Empty;

            StringBuilder sbMenu = new StringBuilder();
            StringBuilder SbMenuMore = new StringBuilder();

            sbMenu.Append("<ul>");

            ////foreach (DataRow mRow in tbMenu.Rows)
            ////{

            ////    String TmpMenuEncodedName = "UsersOwnPage.aspx?Bt=" + mRow["ButtonNo"].ToString() + "&BN=" + HttpUtility.UrlEncode(mRow["LinkName"].ToString());
            ////    //if (i < 10)
            ////    //{
            ////    sbMenu.Append("<li>");
            ////    if (mRow["LinkURL"].ToString().Contains("UsersOwnPage"))
            ////        sbMenu.Append("<a class='links_MainMenuBar' href='" + TmpMenuEncodedName + "'>");
            ////    else
            ////        sbMenu.Append("<a class='links_MainMenuBar' href='" + mRow["LinkURL"].ToString() + "'>");


            ////    tmpMenuName = mRow["LinkName"].ToString().Trim();
            ////    tmpCultureMenuName = (string)GetGlobalResourceObject("LangResources", tmpMenuName.ToLower());
            ////    if (tmpCultureMenuName != null)
            ////    {
            ////        sbMenu.Append(tmpCultureMenuName);
            ////        strMenuBarChars += tmpCultureMenuName;
            ////    }
            ////    else
            ////    {
            ////        sbMenu.Append(mRow["LinkName"].ToString());
            ////        strMenuBarChars += mRow["LinkName"].ToString();
            ////    }

            ////    sbMenu.Append("</a></li>");
            ////    //}
            ////    //else
            ////    //{
            ////    //    //SbMenuMore.Append("<li>");
            ////    //    //SbMenuMore.Append("<a class='indentmenuDropDown' href='" + mRow["LinkURL"].ToString() + "'>");
            ////    //    //SbMenuMore.Append(mRow["LinkName"].ToString());
            ////    //    //SbMenuMore.Append("</a></li>");
            ////    //}


            ////    i++;


            ////    //Response.Write(mRow["LinkID"].ToString() + "|" + mRow["LinkName"].ToString() + "-");
            ////}

            //sbMenu.Append("<li>");
            //sbMenu.Append("<a href='#'> MORE </a>");
            //sbMenu.Append(SbMenuMore.ToString());
            //sbMenu.Append("</li>");

            sbMenu.Append("</ul>");

            ////if (strMenuBarChars.Length > 81)
            ////{
            ////    sbMenu.Replace("links_MainMenuBar", "links_MainMenuBar70");
            ////}

           
            // DownMenu.InnerHtml = sbMenu.ToString();


            #endregion
        }


    }
}
