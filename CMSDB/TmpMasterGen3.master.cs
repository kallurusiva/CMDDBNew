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

public partial class TmpMasterGen3 : System.Web.UI.MasterPage
{

    //SqlConnection dbConn;
    //SqlCommand dbCmd;

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
        DataTable tbLangDropDown;


      


        //tbllogin.Visible = false;


        //TmpMasterCss.Href = "App_Themes/Common/TmpStyleSheet3.css";
       

        //ltrLoginID.Text = Resources.LangResources.Login;
        //ltrPassword.Text = Resources.LangResources.Password;
        //btnSignIn.Text = Resources.LangResources.SignIn;


        if (Session["ClientID"] == null)
            Session["ClientID"] = CommonFunctions.fnGetUserIdfromURL(); 
        



        if (Session["MasterPageCss"] == null)
        {

            string tmpMasterfile = string.Empty;
            string tmpMasterCss = string.Empty;


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

            if (!tmpMasterfile.Equals(string.Empty))
            {
                Session["MasterPageFile"] = tmpMasterfile;
                Session["MasterPageCss"] = tmpMasterCss;


                TmpMasterCss.Href = "App_Themes/Common/" + tmpMasterCss;

            }

        }
        else
        {

            TmpMasterCss.Href = "App_Themes/Common/" + Session["MasterPageCss"];
        }
        
        

        if (!IsPostBack)
        {
            CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();

            
            string tmpCurrPageName = Path.GetFileNameWithoutExtension(Request.PhysicalPath);




            if (tmpCurrPageName.Contains("default") || (tmpCurrPageName.Contains("dt")) || tmpCurrPageName.Contains("Users"))
            {
                //PanelContentLeft.Visible = false;
                //tblLoginArea.Visible = true;
                //trLoginRow.Visible = true;
                dvContentRight.Attributes.Add("class", "ContentRight99");
            }
            else
            {
               // PanelContentLeft.Visible = true;
               // tblLoginArea.Visible = false;
                //trLoginRow.Visible = false;
                dvContentRight.Attributes.Add("class", "ContentRight");
            }
            

            //MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["UserID"]));

            MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));


            tbMenu = MainDS.Tables[0];              //tbltopMenuLinks
            tbHomePgContent = MainDS.Tables[1];     //tblHomePgSettings
            tbTopRowLinks = MainDS.Tables[8];      //tblRow Links
            tbLangDropDown = MainDS.Tables[9];      // Language Drop down 

            //..Populating the Language Dropdown 
            //ddlChangeLanguage.Items.Clear();
            //ddlChangeLanguage.DataSource = tbLangDropDown;
            //ddlChangeLanguage.DataTextField = "LangName";
            //ddlChangeLanguage.DataValueField = "LangValue";
            //ddlChangeLanguage.DataBind();


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

                //if ((Session["defLanguage"] == null) || (Session["defLanguage"] == ""))
                //{


                if ((Session["defLanguage"] != null))
                {
                    selectedLanguage = Session["defLanguage"].ToString();

                }
                else
                {
                    if (tmpDefLang.Trim() == "")
                    {
                        selectedLanguage = GlobalVar.Lang_English;
                    }
                    else
                    {
                        selectedLanguage = tmpDefLang.Trim();


                    }
                }


                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

                Session["defLanguage"] = selectedLanguage;




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



            DataRow[] tbMenu_OwnButton_Rows;
            DataRow[] tbMenu_OtherButton_Rows;
            tbMenu_OwnButton_Rows = tbMenu.Select("LinkURL like 'UsersOwnPage%'", "Priority");
            tbMenu_OtherButton_Rows = tbMenu.Select("LinkUrl Not Like 'UsersOwnPage%'", "Priority");


            // Rendering Other Buttons First

            foreach (DataRow mRow in tbMenu_OtherButton_Rows)
            {

                //if (mRow["LinkURL"].ToString().ToLower().Contains("usersownpage.aspx"))
                //{
                sbMenu.Append("<li>");
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

                i++;

            }



            // Rendering User Own Buttons Next 

            //foreach (DataRow mRow in tbMenu.Rows)
            foreach (DataRow mRow in tbMenu_OwnButton_Rows)
            {

                String TmpMenuEncodedName = "UsersOwnPage.aspx?Bt=" + mRow["ButtonNo"].ToString() + "&BN=" + HttpUtility.UrlEncode(mRow["LinkName"].ToString());
                //if (i < 10)
                //{
                sbMenu.Append("<li>");
                if (mRow["LinkURL"].ToString().Contains("UsersOwnPage"))
                    sbMenu.Append(@"<a class='links_MainMenuBar' href=""" + TmpMenuEncodedName + @""">");
                else
                    sbMenu.Append(@"<a class='links_MainMenuBar' href=""" + mRow["LinkURL"].ToString() + @""">");

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
                
                i++;
                
            }


          




            sbMenu.Append("</ul>");

            dvTopMenu.InnerHtml = "";
            dvTopMenu.InnerHtml = sbMenu.ToString();

                       


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

                    else if (tmpTopRowLinkName.ToUpper().Contains("BANK"))
                    {
                        HyperLink objHypBankInForm = (HyperLink)ucTopMenu.FindControl("HypBankIN");
                        if (objHypBankInForm != null) objHypBankInForm.Visible = true;

                    }
                    else if (tmpTopRowLinkName.ToUpper().Contains("PREPAID"))
                    {
                        HyperLink objHypPrepaid = (HyperLink)ucTopMenu.FindControl("HypPrepaid");
                        if (objHypPrepaid != null) objHypPrepaid.Visible = true;
                    }
                     else if (tmpTopRowLinkName.ToUpper().Contains("EVENDOR"))
                    {
                        HyperLink objHypEbook = (HyperLink)ucTopMenu.FindControl("HypEbook");
                        if (objHypEbook != null) objHypEbook.Visible = true;

                        HtmlImage ObjimgCustLogin = (HtmlImage)ucTopMenu.FindControl("imgCustLogin");
                        if (ObjimgCustLogin != null) ObjimgCustLogin.Visible = true;
                    }

                    else if (tmpTopRowLinkName.ToUpper().Contains("LANGUAGE"))
                    {

                        //... the language dropdown is outside of the Top Menu 
                        HtmlGenericControl objDvLangDpd = (HtmlGenericControl)Page.Master.FindControl("dvLangdropDown");
                        if (objDvLangDpd != null) objDvLangDpd.Visible = true;

                    }
                    else if (tmpTopRowLinkName.ToUpper().Contains("GOOGLE"))
                    {

                        //... the language dropdown is outside of the Top Menu 
                        HtmlGenericControl objdvGoogleTranslater = (HtmlGenericControl)Page.Master.FindControl("dvGoogleTranslater");
                        if (objdvGoogleTranslater != null) objdvGoogleTranslater.Visible = true;

                    }




                }



            }

            #endregion  //... end of Topmost Row Links 


        }


    }

   


    protected void ddlChangeLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////int selLanguageCode = Convert.ToInt16(ddlChangeLanguage.SelectedValue);
        //string selLanguageCode = ddlChangeLanguage.SelectedValue;
        //string selectedLanguage = string.Empty;
        //string mLangCulture = string.Empty;
        //string strSQL = string.Empty;

        //if (selLanguageCode == "EN")
        //{
        //    mLangCulture = "en-US";
        //    strSQL = "Update tblHomePageSettings set LanguageCode=1 where UserID =" + Convert.ToInt32(Session["ClientID"]);
        //}
        //else if (selLanguageCode == "BM")
        //{
        //    mLangCulture = "ms-MY";
        //    strSQL = "Update tblHomePageSettings set LanguageCode=2 where UserID =" + Convert.ToInt32(Session["ClientID"]);
        //}
        //else if (selLanguageCode == "CN")
        //{
        //    mLangCulture = "zh-CN";
        //    strSQL = "Update tblHomePageSettings set LanguageCode=3 where UserID =" + Convert.ToInt32(Session["ClientID"]);
        //}

        //try
        //{
        //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        //    dbConn.Open();
           
        //    dbCmd = new SqlCommand(strSQL, dbConn);
        //    dbCmd.ExecuteNonQuery();


        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //    dbConn.Close();
        //}



        //Session["defLanguage"] = mLangCulture;
        ////lblErrMessage.Text = "User Sucessfully Logged IN ";
        //selectedLanguage = Session["defLanguage"].ToString();
        //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
        //Response.Redirect("default.aspx");
    }
}
