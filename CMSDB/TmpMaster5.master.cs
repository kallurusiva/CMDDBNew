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

public partial class TmpMaster5 : System.Web.UI.MasterPage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;

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
        TmpMasterCss.Href = "App_Themes/Common/" + Session["MasterPageCss"];

        //ltrLoginID.Text = Resources.LangResources.Login;
        //ltrPassword.Text = Resources.LangResources.Password;
        //btnSignIn.Text = Resources.LangResources.SignIn;
        
        if (!IsPostBack)
        {
            CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();

            
            string tmpCurrPageName = Path.GetFileNameWithoutExtension(Request.PhysicalPath);




            if (tmpCurrPageName.Contains("default"))
            {
                PanelContentLeft.Visible = false;
               // tblLoginArea.Visible = true;
                //trLoginRow.Visible = true;
                dvContentRight.Attributes.Add("class", "ContentRight99");
            }
            else
            {
                PanelContentLeft.Visible = true;
               // tblLoginArea.Visible = false;
                //trLoginRow.Visible = false;
                dvContentRight.Attributes.Add("class", "ContentRight99");
            }
            

           

            MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));

            RenderCSS(); 


            tbMenu = MainDS.Tables[0];              //tbltopMenuLinks
            tbHomePgContent = MainDS.Tables[1];     //tblHomePgSettings
            tbTopRowLinks = MainDS.Tables[8];      //tblRow Links
            tbLangDropDown = MainDS.Tables[9];      // Language Drop down 



            //..Populating the Language Dropdown 
            ddlChangeLanguage.Items.Clear();
            ddlChangeLanguage.DataSource = tbLangDropDown;
            ddlChangeLanguage.DataTextField = "LangName";
            ddlChangeLanguage.DataValueField = "LangValue";
            ddlChangeLanguage.DataBind();

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



                if (Session["defLanguage"].ToString() == GlobalVar.Lang_SimplifedChinese)
                {
                    ddlChangeLanguage.SelectedIndex = 2;
                }
                else if (Session["defLanguage"].ToString() == GlobalVar.Lang_BahasaMalay)
                {
                    ddlChangeLanguage.SelectedIndex = 1;
                }
                else
                {
                    ddlChangeLanguage.SelectedIndex = 0;
                }
               
                //}


              

              //  //Images
              //  string tmpLogoImage = HpgRow["LogoImg"].ToString();
              //  if (tmpLogoImage.Substring(0, 8) == "LogoTemp")
              //  {
              //      string tmpCompanyName = HpgRow["CompanyName"].ToString();
              //      string tmpLogoHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
              //      //tmpLogoHtml = tmpLogoHtml + "&nbsp; <font class='LogoText'>" + tmpCompanyName + "</font>";
              //      dvLogoImage.InnerHtml = tmpLogoHtml;
              //      //dvLogoText.InnerHtml = "<font class='LogoText'>" + tmpCompanyName + "</font>";
              //      lblLogoText.Text = tmpCompanyName;
              //      lblLogoText.CssClass = "LogoText";
                    
              //      //dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
              //  }
              //  else
              //  {
              //      dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
              //  }


              //  // if Banner is a flash file (.swf) then 

              //  if (HpgRow["BannerImg"].ToString().Contains(".swf"))
              //  {
              //     // rdoBannerImage.Items.Add(new ListItem(String.Format("<object width='800' height='200'><param name='movie' value='{0}'><embed src='{0}' width='800' height='200'></embed></object>", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString())); ;
              //      dvBannerImg.InnerHtml = "<object width='820' height='200'><param name='movie' value='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "'><embed src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' width='820' height='200'></embed></object>";
              //  }
              //  else
              //  {
              //      dvBannerImg.InnerHtml = "<img alt='banner image'  class='divCssBannerImg' src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' />";
              //  }
                
              //// dvCopyRights.InnerText = HpgRow["CopyRightsInfo"].ToString();


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
            
            // Rendering User Own Buttons First 

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


            // Rendering Other Buttons next

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
                        if (ObjimgCustLogin != null) ObjimgCustLogin.Visible = false;
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

    //protected void btnSignIn_Click(object sender, EventArgs e)
    //{

    //    //SqlConnection dbConn;
    //    //SqlCommand dbCmd;
    //    //SqlDataReader dbReader;
    //    //string strSQL = string.Empty;

    //    DataSet dsCheck;
    //    DataTable dtUserRecord = new DataTable();
    //    DataTable dtUserStatus = new DataTable();

    //    CMSv3.BAL.User objUser = new CMSv3.BAL.User();

    //    bool LoginStatus = false;

    //    //string selectedLanguage;

    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);

    //    string mUserName = txtLoginID.Text;
    //    string mPassword = txtPassword.Text;

    //    try
    //    {
    //        #region Commented Password

    //        ////strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";


    //        //dsCheck = objUser.CheckUser_LoginStatus(CommonFunctions.SafeSql(mUserName), CommonFunctions.SafeSql(mPassword));

    //        //if (dsCheck.Tables.Count == 2)
    //        //{
    //        //    dtUserStatus = dsCheck.Tables[0];
    //        //    dtUserRecord = dsCheck.Tables[1];
    //        //}
    //        //else
    //        //{
    //        //    dtUserStatus = dsCheck.Tables[0];
    //        //}

    //        //DataRow UserStatus_Row = dtUserStatus.Rows[0];
    //        //string UserStatus_Value = UserStatus_Row["userStatus"].ToString();


    //        //if (UserStatus_Value == "MATCHED")
    //        //{
    //        //    DataRow UserRecord_Row = dtUserRecord.Rows[0];

    //        //    Session["UserID"] = UserRecord_Row["UserID"].ToString();
    //        //    Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
    //        //    Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();

    //        //    LoginStatus = true;
    //        //    Session["PasswordStatus"] = UserStatus_Value;
    //        //}
    //        //else if (UserStatus_Value == "EXPIRED")
    //        //{
    //        //    //LtrErrMessage.Text = "Account Expired ...";
    //        //    LoginStatus = false;
    //        //    Session["PasswordStatus"] = UserStatus_Value;
    //        //}
    //        //else
    //        //{
    //        //    // LtrErrMessage.Text = "Invalid <br/>Password ...";
    //        //    LoginStatus = false;
    //        //    Session["PasswordStatus"] = UserStatus_Value;
    //        //    CommonFunctions.AlertMessageAndRedirect("Invalid Password...", "Default.aspx");
    //        //}
    //        #endregion




    //        string tmpCountryPrefix = mUserName.Substring(0, 2);

    //        //..Additional Code for Brunei as it has three digit country prefix 
    //        string tmpForBruneiPrefix = mUserName.Substring(0, 3);
    //        if (tmpForBruneiPrefix == "673")
    //            tmpCountryPrefix = "673";

    //        String ValidStatusText = string.Empty;
    //        int ValidStatus = 0;
    //        ValidStatusText = CommonFunctions.ValidateLoginStatusNEW(mUserName, mPassword, "PARTNER", ref ValidStatus);


    //        if ((ValidStatus == 0) || (ValidStatus == 3))
    //        {
    //            if (ValidStatus == 3)
    //            {
    //                CommonFunctions.AlertMessage(ValidStatusText);
    //            }
    //            //if ((tmpCountryPrefix == "60") || (tmpCountryPrefix == "65") || (tmpCountryPrefix == "62") || (tmpCountryPrefix == "673"))
    //            if (CommonFunctions.IsNumeric(tmpCountryPrefix))
    //            {

    //                //validate the User. 
    //                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
    //                string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(mUserName, mPassword);

    //                if (tmpMID == "0")
    //                {
    //                    // invalid login 
    //                    //LtrErrMessage.Text = "Invalid Password ...";
    //                    CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.BizPartnerLogin), 0);
    //                    CommonFunctions.AlertMessageAndRedirect("Invalid Password...", "Default.aspx");

    //                }
    //                else if (tmpMID == "1")
    //                {
    //                    //LtrErrMessage.Text = "Not Subscribed to SMSBIZ.";

    //                    StringBuilder sbm = new StringBuilder();

    //                    sbm.Append(@"\n This M-Commerce Partner Login is strictly for SMS Entrepreneur Only.");
    //                    sbm.Append(@"\n ");
    //                    sbm.Append(@"\n Please consult your referral for explaination on ");
    //                    sbm.Append(@"\n SMS Business Requirement and ask for instructions ");
    //                    sbm.Append(@"\n on how to set SMS Business Status to YES.  ");
    //                    sbm.Append(@"\n\n ");
    //                    sbm.Append(@"\n Thank you.");

    //                    //CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));
    //                    CommonFunctions.AlertMessageAndRedirect(Server.HtmlEncode(sbm.ToString()), "Default.aspx");
    //                    // CommonFunctions.AlertMessage(Server.HtmlEncode(@"Not Subscribed \n Thank you")); 


    //                }
    //                else
    //                {
    //                    // CommonFunctions.CheckSubDomainByLoginID(tmpCountryPrefix, mUserName, mPassword);
    //                    CommonFunctions.LogUserWebInfo(tmpMID, mUserName);
    //                    CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.BizPartnerLogin), 1);
    //                    CommonFunctions.Redirect2Logins(tmpCountryPrefix, mUserName, mPassword);

    //                }
    //            }
    //            else
    //            {

    //                StringBuilder sb1 = new StringBuilder();

    //                sb1.Append(@"\n Only Partners can login from here.");
    //                sb1.Append(@"\n ");
    //                sb1.Append(@"\n Please make use Customer Login link ");
    //                sb1.Append(@"\n if you have mistakenly trying to login from here.");
    //                CommonFunctions.AlertMessage(Server.HtmlEncode(sb1.ToString()));


    //                ////if loggin in by Domain Names...
    //                //Boolean isValidLogin = ValidateLoginByDomain(mUserName, mPassword);


    //                //if (isValidLogin)
    //                //{
    //                //    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

    //                //    int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));
    //                //    CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName); 
    //                //    Response.Redirect("~/Admin/Ad_Welcome.aspx");
    //                //    //Server.Transfer("~/Admin/Welcome.aspx");

    //                //}


    //            }
    //        }
    //        else
    //        {
    //            CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.BizPartnerLogin), 3);
    //            CommonFunctions.AlertMessage(ValidStatusText); 
    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //    finally
    //    {

    //    }

    //    //if (LoginStatus)
    //    //{
    //    //    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

    //    //    int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));

    //    //    Response.Redirect("~/Admin/Ad_Welcome.aspx");
    //    //    //Server.Transfer("~/Admin/Welcome.aspx");

    //    //}

    //}



    protected Boolean ValidateLoginByDomain(string vUserID, string vPassword)
    {


        SqlConnection dbConn;
        //SqlCommand dbCmd;
        //SqlDataReader dbReader;
        //SqlDataAdapter dbAdap;
        DataSet dsCheck;
        string strSQL = string.Empty;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        bool LoginStatus = false;

        //string selectedLanguage;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);


        try
        {
            //strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";

            //strSQL = "Exec [usp_User_CheckLogin] " + "'" + CommonFunctions.SafeSql(mUserName) + "' , '" + CommonFunctions.SafeSql(mPassword) + "'";

            dsCheck = objUser.CheckUser_LoginStatus(CommonFunctions.SafeSql(vUserID), CommonFunctions.SafeSql(vPassword));

            if (dsCheck.Tables.Count == 2)
            {
                dtUserStatus = dsCheck.Tables[0];
                dtUserRecord = dsCheck.Tables[1];
            }
            else
            {
                dtUserStatus = dsCheck.Tables[0];
            }

            DataRow UserStatus_Row = dtUserStatus.Rows[0];
            string UserStatus_Value = UserStatus_Row["userStatus"].ToString();


            if (UserStatus_Value == "MATCHED")
            {
                DataRow UserRecord_Row = dtUserRecord.Rows[0];

                Session["UserID"] = UserRecord_Row["UserID"].ToString();
                Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
                Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();

                LoginStatus = true;
            }
            else if (UserStatus_Value == "EXPIRED")
            {
               // LtrErrMessage.Text = "Account Expired ...";
                CommonFunctions.AlertMessageAndRedirect("Account Expired...", "Default.aspx");
                LoginStatus = false;
            }
            else
            {
                //LtrErrMessage.Text = "Invalid Password ...";
                CommonFunctions.AlertMessageAndRedirect("Invalid Password...", "Default.aspx");
                LoginStatus = false;
            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {

        }

        return LoginStatus;

    }

    //protected void ddlChangeLanguage_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int selLanguageCode = Convert.ToInt16(ddlChangeLanguage.SelectedValue);
    //    string selectedLanguage = string.Empty;
    //    string mLangCulture = string.Empty;

    //    if (selLanguageCode == 1)
    //    {
    //        mLangCulture = "en-US";
    //    }
    //    else
    //    {
    //        mLangCulture = "ms-MY";
    //    }

    //    Session["defLanguage"] = mLangCulture;
    //    //lblErrMessage.Text = "User Sucessfully Logged IN ";
    //    selectedLanguage = Session["defLanguage"].ToString();
    //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
    //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
    //    Response.Redirect("default_T1.aspx");
    //}


    protected void ddlChangeLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int selLanguageCode = Convert.ToInt16(ddlChangeLanguage.SelectedValue);
        string selLanguageCode = ddlChangeLanguage.SelectedValue;
        string selectedLanguage = string.Empty;
        string mLangCulture = string.Empty;
        string strSQL = string.Empty;

        if (selLanguageCode == "EN")
        {
            mLangCulture = "en-US";
            strSQL = "Update tblHomePageSettings set LanguageCode=1 where UserID =" + Convert.ToInt32(Session["ClientID"]);
        }
        else if (selLanguageCode == "BM")
        {
            mLangCulture = "ms-MY";
            strSQL = "Update tblHomePageSettings set LanguageCode=2 where UserID =" + Convert.ToInt32(Session["ClientID"]);
        }
        else if (selLanguageCode == "CN")
        {
            mLangCulture = "zh-CN";
            strSQL = "Update tblHomePageSettings set LanguageCode=3 where UserID =" + Convert.ToInt32(Session["ClientID"]);
        }


        try
        {
            dbConn = new SqlConnection(GlobalVar.GetDbConnString);
            dbConn.Open();
           
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.ExecuteNonQuery();


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }



        Session["defLanguage"] = mLangCulture;
        //lblErrMessage.Text = "User Sucessfully Logged IN ";
        selectedLanguage = Session["defLanguage"].ToString();
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
        Response.Redirect("default.aspx");
    }

    protected void RenderCSS()
    {

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

    }
}
