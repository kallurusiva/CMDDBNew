using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using CMSv3.BAL;


public partial class Admin_Ad_WebSettings : BasePage 
{

    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();
    DataSet ds;
    DataTable dtTopMenu;
    DataTable dtLogos;
    DataTable dtBanners;
    DataTable dtUserInfo;
    DataTable dtTopRow;
    DataTable dtLogins;

    //bool FileWasUpload = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;
    string NCode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        Page.MaintainScrollPositionOnPostBack = true;
        //LtrDispWebsite.Text = Resources.LangResources.DisplayatWebsite;


        //tr_bannerBody.Visible = false;
        //tr_bannerHead.Visible = false;

        if (!IsPostBack)
        {
           // ViewState["LogoWasUploaded"] = "false";
           // ViewState["BannerWasUploaded"] = "false";
           // ViewState["FileImageUrl"] = "";

            //if ((Request.QueryString["ImgToDelete"] != null) && (Request.QueryString["ImgToDelete"] != ""))
            //{
            //    DeleteImage(Request.QueryString["ImgToDelete"]);
            //}

            LoadHomePageDefaults();

         //   String ClientIpAddress = CommonFunctions.GetClientIPAddress();
         //   Response.Write(ClientIpAddress); 
     
        }
    }


    protected void DeleteImage(string vImageID2Delete)
    {

        int tmpImageIDDelete = Convert.ToInt32(vImageID2Delete);

        int delStatus = objBAL_AccountSettings.Settings_DeleteUserImage(tmpImageIDDelete);
        
        //alert javascript to show image delete
        CommonFunctions.AlertMessage("Image has been Deleted.");

    }

    protected void LoadHomePageDefaults()
    {

        string tmpDefaultLanguageCode = string.Empty;
        string mTopMenuLinks = string.Empty;
        string mTopRowLinks = string.Empty;
        string mLoginsToshow = string.Empty; 


        string mLanguagesDropDown = string.Empty;
        int mLogoImgId;
        int mBannerImgId;
        string mCompanyName = string.Empty;
        string mCompanyInfo = string.Empty;
        string mCopyRightInfo = string.Empty;
        string vtmpMobileLoginId = string.Empty;


        ds = objBAL_AccountSettings.RetrieveALL_Settings_HomePage_Defaults(Convert.ToInt32(Session["UserID"]));

        dtTopMenu = ds.Tables[0];
        dtLogos = ds.Tables[1];
        dtBanners = ds.Tables[2];
        dtUserInfo = ds.Tables[3];
        dtTopRow = ds.Tables[4];
        dtLogins = ds.Tables[5]; 


        //User Info
        if (dtUserInfo.Rows.Count > 0)
        {

            DataRow uRow = (DataRow)dtUserInfo.Rows[0];

           // mCompanyName = uRow["CompanyName"].ToString();
            //  mCompanyInfo = uRow["CompanyInfo"].ToString().Replace("<br/>",Environment.NewLine);

            #region --  Code to render CopyRightsInfo 
            mCopyRightInfo = uRow["CopyrightsInfo"].ToString();

            DateTime vDateTime = DateTime.Now;
            int vYear = vDateTime.Year;

            if (mCopyRightInfo.Trim() == "")
            {
                //   Later to use domain name for the copyrights information.
                //   rdoCopyRightsDefault.Text = "All rights reserved @2010. " + mCompanyName.ToString();

                //Currently..

              

                rdoCopyRightsDefault.Text = "Copyrights@" + vYear  + ".  All Rights Reserved.";

                rdoCopyRightsDefault.Checked = true;
                rdoCopyRightsNewText.Checked = false;
            }
            else
            {
                rdoCopyRightsDefault.Text = "Copyrights@" + vYear + ".  All Rights Reserved.";
                //rdoCopyRightsNewText.Text = mCopyRightInfo.ToString();
                txtNewCopyRightsInfo.Text = mCopyRightInfo.ToString();
                rdoCopyRightsNewText.Checked = true;
                rdoCopyRightsDefault.Checked = false;
            }


            //txtNewCopyRightsInfo.Text = mCopyRightInfo.ToString();

            //if (mCopyRightInfo.ToString() != "")
            //{
            //    rdoCopyRightsNewText.Checked = true;
            //}
            //else
            //{
            //    rdoCopyRightsDefault.Checked = true;
            //}


            #endregion


            vtmpMobileLoginId = uRow["MobileLoginID"].ToString();
            mTopMenuLinks = uRow["TopMenuLinkstoShow"].ToString();
            mTopRowLinks = uRow["TopRowLinksToShow"].ToString();
            NCode = uRow["NCode"].ToString();

                if (NCode != "")
                {
                    NCode = " (" + NCode + ")";
                }

             mLogoImgId = Convert.ToInt16(uRow["ImageID_Logo"]);
             mBannerImgId = Convert.ToInt16(uRow["ImageID_Banner"]);             

             tmpDefaultLanguageCode = uRow["LanguageCode"].ToString();
             mLanguagesDropDown = uRow["LanguagesDropDown"].ToString();

             mLoginsToshow = uRow["LoginsToShow"].ToString(); 

        }
        else
        {
            
            rdoCopyRightsDefault.Text = "Copyrights @ 2010 . All rights reserved. ";
            mLogoImgId = 12;
            mBannerImgId = 10;
            tmpDefaultLanguageCode = "1";
            mTopMenuLinks = "1,2,3,4,5,6,7,8";
            mTopRowLinks = "1,2,3,4,6";
            mLanguagesDropDown = "1,";
            mCompanyName = "";
            mCompanyInfo = "";
            mCopyRightInfo = "";
        }

        #region //Commented // Code Section : Default Language 
        
        //Default Language  -----------------------
        String mDefLanguage;


        if (tmpDefaultLanguageCode == "")
        {
            //mDefLanguage = GlobalVar.Lang_English;
            mDefLanguage = GlobalVar.LanguagueEnums.Lang_English.ToString();
        }
        else
        {
            mDefLanguage = tmpDefaultLanguageCode;
        }

        //... now allowing ebook users to select website language as well
        //if (Session["UserDomainType"].ToString() == "EBOOK")
        //{
        //    trdefLang1.Visible = false;
        //    trdefLang2.Visible = false;
        //}
        //else
        //{
            foreach (ListItem LangItem in rdoDefLanguague.Items)
            {
                if (LangItem.Value == mDefLanguage)
                { LangItem.Selected = true;  }
            }

       // }
            //--------------------------------------

        #endregion
        
      
        //... Get User MobileLoginID 
        String UserAccountType = string.Empty;

            CMSv3.Entities.MasUser objLoginUser = new CMSv3.Entities.MasUser();
            MasFunc.Get_1MalaysiaUser_Details(vtmpMobileLoginId, ref objLoginUser);
            // MasFunc.Get_1MalaysiaUser_Details("60162531066", ref objLoginUser);
            Session["LoginUser"] = objLoginUser;
            UserAccountType = objLoginUser.AccountType; 

        #region Code Section : Top Menu Links
            



                    //...Top Menu Links... 
                chkList_TopMenuItems.DataSource = dtTopMenu;
                chkList_TopMenuItems.DataTextField = "LinkName";
                chkList_TopMenuItems.DataValueField = "LinkID";
                chkList_TopMenuItems.DataBind();               

                string[] TopMenuLinksArray = mTopMenuLinks.Split(',');

                string ExtraButtonID = ConfigurationManager.AppSettings["ExtraWebButtonID"].ToString(); 

                foreach (ListItem ckL in chkList_TopMenuItems.Items)
                {                   

                    if (ckL.Value == "23")
                    {
                        ckL.Text = ckL.Text + NCode;
                    }

                    if (TopMenuLinksArray.Contains(ckL.Value))
                    {
                        ckL.Selected = true;

                        if (ckL.Value == ExtraButtonID)
                        {
                            ckL.Enabled = true; 
                            if (UserAccountType == "FREE")
                            {
                                ckL.Enabled = false; 
                            }
                        }
                    }

                }

            #endregion


        #region Code Section : Top Row Links
                

                //...Top Menu Links... 
                chkTopRowBtnList.DataSource = dtTopRow;
                chkTopRowBtnList.DataTextField = "LinkName";
                chkTopRowBtnList.DataValueField = "LinkID";
                chkTopRowBtnList.DataBind();


                string[] TopRowLinksArray = mTopRowLinks.Split(',');


                foreach (ListItem ckL in chkTopRowBtnList.Items)
                {
                    if (TopRowLinksArray.Contains(ckL.Value))
                    {
                        ckL.Selected = true;
                    }

                }


        #endregion



                #region Code Section : Logins To Show

            
                ////...Top Menu Links... 
                //chkList_Logins.DataSource = dtLogins;
                //chkList_Logins.DataTextField = "LoginName";
                //chkList_Logins.DataValueField = "LoginTypeID";
                //chkList_Logins.DataBind();


                //string[] LoginArray = mLoginsToshow.Split(',');


                //foreach (ListItem ckL in chkList_Logins.Items)
                //{
                //    if (LoginArray.Contains(ckL.Value))
                //    {
                //        ckL.Selected = true;
                //    }

                //}


                #endregion


                #region Code Section : Languages Dropdown 
                
                //string[] LangDropdownArray = mLanguagesDropDown.Split(',');

                //foreach (ListItem ckLg in chkLangDropdown.Items)
                //{
                //    if (LangDropdownArray.Contains(ckLg.Value))
                //    {
                //        ckLg.Selected = true;
                //    }

                //}


                #endregion




                #region Code Section: Logo and Banner Images

                
                string temp = GlobalVar.GetImgStoreFolder.ToString();
                string ImageFolder = @".." + GlobalVar.GetImgStoreFolder.ToString();
                
                // rendering Logos 
                DataView dvLogoImages = dtLogos.DefaultView; 
                dvLogoImages.RowFilter = "ImageID = " + mLogoImgId.ToString();                

                foreach (DataRowView Lrow in dvLogoImages)
                {
                    String tmpLogoImageID = Lrow["ImageID"].ToString();
                    string tmpLogoImageName = Lrow["ImgName"].ToString();
                    if (tmpLogoImageID == mLogoImgId.ToString())
                        dvSelectedLogo.InnerHtml = "<img alt='logo img' style='border: dashed 1px #B3C3B3;' class='divCssLogoImage' src='" + @"../ImageRepository/" + tmpLogoImageName + "' />";
                }

                //foreach (DataRow Lrow in dtLogos.Rows)
                //{
                //    String tmpLogoImageID = Lrow["ImageID"].ToString(); 
                //    string tmpLogoImageName = Lrow["ImgName"].ToString();

                    
                //    if(tmpLogoImageID == mLogoImgId.ToString())
                //        dvSelectedLogo.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + tmpLogoImageName + "' />";

                //}


                // rendering selected Banner 

                DataView dvBannerImages = dtBanners.DefaultView;
                dvBannerImages.RowFilter = "ImageID = " + mBannerImgId.ToString();

                //Response.Write(mBannerImgId.ToString());

                foreach (DataRowView Bnrow in dvBannerImages)
                {
                    String tmpBannerID = Bnrow["ImageID"].ToString();
                    string tmpBannerName = Bnrow["ImgName"].ToString();
                    //String imgFolder = @"../ImageRepository/";                    

                    if (tmpBannerID == mBannerImgId.ToString())
                    {
                        if (tmpBannerName.Contains(".swf"))
                        {

                            dvSeletedBanner.InnerHtml = String.Format("<object width='720' style='border: dashed 1px #B3C3B3;' height='180'><param name='movie' value='{0}'><embed src='{0}' width='720' height='180'></embed></object>", ImageFolder + tmpBannerName);
                        }
                        else
                        {

                            dvSeletedBanner.InnerHtml = String.Format("<img style='border: dashed 1px #B3C3B3;' class='SelBannerCss' src='{0}'>", ImageFolder + tmpBannerName);
                        }

                         //= "<img alt='banner image'  class='divCssBannerImg' src='" +  + tmpBannerName + "' />";
                    }

                }
          

                #endregion

        #region  // Commented Code Section: Company information
        
           // txtCompanyInfo.Text = mCompanyInfo.ToString();
           // txtCompanyName.Text = mCompanyName.ToString();
            //txtNewCopyRightsInfo.Text = mCopyRightInfo.ToString();

            //if (mCopyRightInfo.ToString() != "")
            //{
            //    rdoCopyRightsNewText.Checked = true;
            //}
            //else
            //{
            //    rdoCopyRightsDefault.Checked = true;
            //}


        #endregion


    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        CMSv3.Entities.AdminSettings objWebSettings = new CMSv3.Entities.AdminSettings();
        CMSv3.BAL.AdminSettings objBAL_AdminSettings = new CMSv3.BAL.AdminSettings();

        //-- Languages to be shown in the Dropdown 
        String strSel_ddlLangs = string.Empty;

       

        //foreach (ListItem sel_ddlLangs in chkLangDropdown.Items)
        //{
        //    if (sel_ddlLangs.Selected)
        //        strSel_ddlLangs = strSel_ddlLangs + sel_ddlLangs.Value + ',';
        //}
        objWebSettings.LanguagesDp = strSel_ddlLangs; 

        //-- Top Row Links. 
        string strSel_TopRowLinks = string.Empty;
        foreach (ListItem sel_topRowLinks in chkTopRowBtnList.Items)
        {
            if(sel_topRowLinks.Selected)
                strSel_TopRowLinks = strSel_TopRowLinks + sel_topRowLinks.Value + ',';

        }
        objWebSettings.TopRowLinks = strSel_TopRowLinks; 


        //--Top menu links.
        string strSel_TopLinks = string.Empty;
        foreach (ListItem Sellist_TopLinks in chkList_TopMenuItems.Items)
        {
            if (Sellist_TopLinks.Selected)
                strSel_TopLinks = strSel_TopLinks + Sellist_TopLinks.Value + ',';
        }

        objWebSettings.TopMenuLinks = strSel_TopLinks;




        ////--Login Types 
        //string strSel_Logins = string.Empty;
        //foreach (ListItem Sellist_Logins in chkList_Logins.Items) 
        //{
        //    if (Sellist_Logins.Selected)
        //        strSel_Logins = strSel_Logins + Sellist_Logins.Value + ',';
        //}

        objWebSettings.LoginsToShow = "";



        //.. check to see if the user selected default or Entered new text
        if (rdoCopyRightsNewText.Checked)
        {
            objWebSettings.CopyRightInfo = txtNewCopyRightsInfo.Text;
        }
        else
        {
            objWebSettings.CopyRightInfo = rdoCopyRightsDefault.Text;
        }



       ////'' objWebSettings.Logo_ImgID = Convert.ToInt16(rdoLogoImage.SelectedValue);
        //objWebSettings.Banner_ImgID = Convert.ToInt16(rdoBannerImage.SelectedValue);

        //Check to see if the user has ticked Display at Website for Logo 
          ////'' objWebSettings.User_LogoTicked = chkActive_Logo.Checked;
        
        //Check to see if the user has ticked Display at Website for Banner
        //   objWebSettings.User_BannerTicked = chkActive_Banner.Checked;

        objWebSettings.DefLanguage = rdoDefLanguague.SelectedValue;

        //if (Session["UserDomainType"].ToString() == "EBOOK")
        //{
        //    objWebSettings.DefLanguage = "1"; 
        //}
        //else
        //{ objWebSettings.DefLanguage = rdoDefLanguague.SelectedValue; }

       
        objWebSettings.ModifiedBy = Convert.ToInt32(Session["UserID"]);


        
        //int inStatus = objBAL_AccountSettings.Update_Settings_HomePageDefaults22(objWebSettings, Convert.ToInt32(Session["UserID"]));
        int inStatus = objBAL_AccountSettings.Update_WebSettings(objWebSettings, Convert.ToInt32(Session["UserID"]));


        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Web Settings successfully updated";
            lblErrMessage.CssClass = "font_12Msg_Success";

           // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
            Response.Redirect("Ad_WebSettings.aspx");
            
            return;

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }




    }
    
   
}
