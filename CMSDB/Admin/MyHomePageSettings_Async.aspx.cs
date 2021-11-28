using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using CMSv3.BAL;


public partial class Admin_MyHomePageSettings_Async : BasePage 
{

    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();
    DataSet ds;
    DataTable dtTopMenu;
    DataTable dtLogos;
    DataTable dtBanners;
    DataTable dtUserInfo;

    bool FileWasUpload = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;


    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        Page.MaintainScrollPositionOnPostBack = true;
        LtrDispWebsite.Text = Resources.LangResources.DisplayatWebsite;
        FileWasUpload = Getbool();
       

        if (!IsPostBack)
        {
            ViewState["LogoWasUploaded"] = "false";
            ViewState["BannerWasUploaded"] = "false";
            ViewState["FileImageUrl"] = "";

            if ((Request.QueryString["ImgToDelete"] != null) && (Request.QueryString["ImgToDelete"] != ""))
            {
                DeleteImage(Request.QueryString["ImgToDelete"]);
            }

            LoadHomePageDefaults();

     
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

        string tmpDefaultLanguage = string.Empty;
        string mTopMenuLinks = string.Empty;
        int mLogoImgId;
        int mBannerImgId;
        string mCompanyName = string.Empty;
        string mCompanyInfo = string.Empty;
        string mCopyRightInfo = string.Empty;
        

        ds = objBAL_AccountSettings.RetrieveALL_Settings_HomePage_Defaults(Convert.ToInt32(Session["UserID"]));

        dtTopMenu = ds.Tables[0];
        dtLogos = ds.Tables[1];
        dtBanners = ds.Tables[2];
        dtUserInfo = ds.Tables[3];



        //User Info
        if (dtUserInfo.Rows.Count > 0)
        {

            DataRow uRow = (DataRow)dtUserInfo.Rows[0];

           // mCompanyName = uRow["CompanyName"].ToString();
            //  mCompanyInfo = uRow["CompanyInfo"].ToString().Replace("<br/>",Environment.NewLine);

            #region --  Code to render CopyRightsInfo 
            mCopyRightInfo = uRow["CopyrightsInfo"].ToString();

            if (mCopyRightInfo.Trim() == "")
            {
                //   Later to use domain name for the copyrights information.
                //   rdoCopyRightsDefault.Text = "All rights reserved @2010. " + mCompanyName.ToString();

                //Currently
                rdoCopyRightsDefault.Text = "Copyrights@2010.  All Rights Reserved.";

                rdoCopyRightsDefault.Checked = true;
                rdoCopyRightsNewText.Checked = false;
            }
            else
            {
                rdoCopyRightsDefault.Text = "Copyrights@2010.  All Rights Reserved.";
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

            mTopMenuLinks = uRow["TopMenuLinkstoShow"].ToString();

             mLogoImgId = Convert.ToInt16(uRow["ImageID_Logo"]);
             mBannerImgId = Convert.ToInt16(uRow["ImageID_Banner"]);

             tmpDefaultLanguage = uRow["LangCulture"].ToString();

        }
        else
        {
            
            rdoCopyRightsDefault.Text = "Copyrights @ 2010 . All rights reserved. ";
            mLogoImgId = 12;
            mBannerImgId = 10;
            tmpDefaultLanguage = "en-US";
            mTopMenuLinks = "1,2,3,4,5,6,7,8";
            mCompanyName = "";
            mCompanyInfo = "";
            mCopyRightInfo = "";
        }

        #region //Commented // Code Section : Default Language 
        
        //Default Language  -----------------------
            //string mDefLanguage;
          

            //if (tmpDefaultLanguage.Trim() == "")
            //{
            //    mDefLanguage = GlobalVar.Lang_English;}
            //else
            //    {
            //        mDefLanguage = tmpDefaultLanguage.Trim();
            //    }

            //foreach (ListItem LangItem in rdoDefLanguague.Items)
            //{
            //    if (LangItem.Value == mDefLanguage)
            //    {
            //        LangItem.Selected = true;
            //    }

            //}
            //--------------------------------------

        #endregion

        #region Code Section : Top Menu Links
            

                    //...Top Menu Links... 
                chkList_TopMenuItems.DataSource = dtTopMenu;
                chkList_TopMenuItems.DataTextField = "LinkName";
                chkList_TopMenuItems.DataValueField = "LinkID";
                chkList_TopMenuItems.DataBind();

                string[] TopMenuLinksArray = mTopMenuLinks.Split(',');
                

                foreach (ListItem ckL in chkList_TopMenuItems.Items)
                {
                    if (TopMenuLinksArray.Contains(ckL.Value))
                    {
                        ckL.Selected = true;
                    }

                }

            #endregion
                
        #region Code Section: Logo and Banner Images 

                
                    string temp = GlobalVar.GetImgStoreFolder.ToString(); 
                    string ImageFolder = @".." + GlobalVar.GetImgStoreFolder.ToString();
                    int FirstSysLogoItem = 1; 
                    // rendering Logos 
                   foreach (DataRow Lrow in dtLogos.Rows)
                    {
                      string tmpLogoImageName = Lrow["ImgName"].ToString() ;
                        
                       //showing different logo image for templates. 
                      if (tmpLogoImageName.Substring(0, 8) == "LogoTemp")
                      {
                          rdoLogoImage.Items.Add(new ListItem(String.Format("<div id='dvLogo' style='border: solid 1px #234565; width: 180px; height:80px;'><img  style='max-width:180px; max-height:75px;' src='{0}'></div>", ImageFolder + Lrow["ImgName"].ToString()), Lrow["ImageID"].ToString()));
                          ListItem CurrItem = rdoLogoImage.Items.FindByValue(Lrow["ImageID"].ToString());
                          CurrItem.Text = tmpLogoImageName.Substring(0, tmpLogoImageName.IndexOf(".")) + " <br/>" + CurrItem.Text;
                          

                          //disabling the logo radio buttons for WEB10 users
                          if (Session["UserDomainType"].ToString() == "WEB10")
                          {
                              if(FirstSysLogoItem != 1)  // skipping the first logo button 
                                CurrItem.Enabled = false;
                              FirstSysLogoItem += 1;

                          }


                      }
                      else
                      {
                          rdoLogoImage.Items.Add(new ListItem(String.Format("<div id='dvUsrLogo' style='border: solid 1px #234565; width: 180px; height:80px;float:left;'><img style='max-width:180px; max-height:80px;' src='{0}'></div> <div id='dvdel' style='float:left;'><img alt='Delete Logo' title='Delete Logo' onclick='fnDeleteImage(" + Lrow["ImageID"].ToString() + ")' src='../Images/round_notactive.gif' /></div>", ImageFolder + Lrow["ImgName"].ToString()), Lrow["ImageID"].ToString()));
                          
                          
                          ListItem CurrItem = rdoLogoImage.Items.FindByValue(Lrow["ImageID"].ToString());
                          CurrItem.Text = "User Logo  [ID :" + Lrow["ImgName"].ToString().Substring(4, 7) + "] <br/>" + CurrItem.Text;
                      }

                       //rdoLogoImage.Items.Add(new ListItem(string.Format("<img src='{0}'>"),ImageFolder + Lrow["ImgName"].ToString()),Lrow["ImageID"].ToString()) ;
                    

                   }


                  
                   bool isLogoSelected = false;
                    // Marking user selection for logos
                   foreach (ListItem Logoitem in rdoLogoImage.Items)
                   {
                       //Logoitem.Text = "abc " + Logoitem.Text;
                       if (Convert.ToInt16(Logoitem.Value) == mLogoImgId)
                       {
                           Logoitem.Selected = true;
                           isLogoSelected = true;
                       }
                    }


                   ////enabling only the first logo radio buttons for WEB10 users
                   //if (Session["UserDomainType"].ToString() == "WEB10")
                   //{
                   //    rdoLogoImage.Items[0].Enabled = true;
                   //}

                   if (!isLogoSelected)
                   rdoLogoImage.Items[0].Selected = true;



                   int FirstSysBannerItem = 1; 
                   bool isBannerSelected = false;
                    //rendering Banners 
                   foreach (DataRow Brow in dtBanners.Rows)
                   {
                       //rdoLogoImage.Items.Add(new ListItem(string.Format("<img src='{0}'>"),ImageFolder + Lrow["ImgName"].ToString()),Lrow["ImageID"].ToString()) ;

                       string tmpBannerImageName = Brow["ImgActualName"].ToString();

                       if (Brow["UserID"].ToString() == "101")
                       {
                           if (Brow["ImgName"].ToString().Contains(".swf"))
                           {
                              // rdoBannerImage.Items.Add(new ListItem(String.Format("<object width='800' height='200'><param name='movie' value='{0}'><embed src='{0}' width='800' height='200'></embed></object>", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString())); ;
                               rdoBannerImage.Items.Add(new ListItem(String.Format("<object width='800' height='200'><param name='movie' oninit=\"this.src='../imageRepository/116_1995021_101_3175354_sms1.swf'\" value='../imageRepository/116_1995021_101_3175354_sms1.swf'  onload=\"RetrievePicture(this,'{0}');\"><embed src='../imageRepository/116_1995021_101_3175354_sms1.swf' oninit=\"this.src='../imageRepository/116_1995021_101_3175354_sms1.swf'\"  onload=\"RetrievePicture(this,'{0}');\" width='800' height='200'></embed></object>", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString())); ;

                           }
                           else
                           {
                               rdoBannerImage.Items.Add(new ListItem(String.Format("<img class='SelBannerCss' src='../imagerepository/Banner1.jpg'  onerror=\"this.src='../images/inf_Error.gif'\" onload=\"RetrievePicture(this,'{0}');\">", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString()));
                           }
                           ListItem CurrItem = rdoBannerImage.Items.FindByValue(Brow["ImageID"].ToString());
                           CurrItem.Text = tmpBannerImageName.Substring(0, tmpBannerImageName.IndexOf(".")) + " <br/>" + CurrItem.Text;

                           //disabling the logo radio buttons for WEB10 users
                           if (Session["UserDomainType"].ToString() == "WEB10")
                           {
                               if (FirstSysBannerItem != 1)  // skipping the first logo button 
                                   CurrItem.Enabled = false;
                               FirstSysBannerItem += 1;

                           }

                       }
                       else
                       {

                           if (Brow["ImgName"].ToString().Contains(".swf"))
                           {
                               rdoBannerImage.Items.Add(new ListItem(String.Format("<object width='800' height='200'><param name='movie' value='{0}'><embed src='{0}' width='800' height='200'></embed></object> &nbsp; <img alt='Delete Logo' title='Delete Logo' onclick='fnDeleteImage(" + Brow["ImageID"].ToString() + ")' src='../Images/round_notactive.gif' />", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString())); ;

                           }
                           else
                           {
                               rdoBannerImage.Items.Add(new ListItem(String.Format("<img class='SelBannerCss' src='{0}'>  &nbsp; <img alt='Delete Logo' title='Delete Logo' onclick='fnDeleteImage(" + Brow["ImageID"].ToString() + ")' src='../Images/round_notactive.gif' />", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString()));
                               //rdoBannerImage.Items.Add(new ListItem(String.Format("<img class='SelBannerCss' src='Banner1.jpg'  onerror='this.src=''images/inf_Error.gif' onload='RetrievePicture(''{0}'');'>", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString()));
                           }
                           ListItem CurrItem = rdoBannerImage.Items.FindByValue(Brow["ImageID"].ToString());
                           CurrItem.Text = "User Banner [ID :" + Brow["ImgName"].ToString().Substring(4, 7) + "]" + " <br/>" + CurrItem.Text;
                       }
                   }

                   // Marking user selection for logos
                   foreach (ListItem Banneritem in rdoBannerImage.Items)
                   {
                       if (Convert.ToInt16(Banneritem.Value) == mBannerImgId)
                       {
                           Banneritem.Selected = true;
                           isBannerSelected = true;
                       }

                   }

                   ////enabling only the first the banner radio button for WEB10 users
                   //if (Session["UserDomainType"].ToString() == "WEB10")
                   //{
                   //    rdoBannerImage.Items[0].Enabled = true;
                   //}

                    if (!isBannerSelected)
                       rdoBannerImage.Items[0].Selected = true;
                    



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


       // objWebSettings.DefLanguage = rdoDefLanguague.SelectedValue;


        //--top menu links.
        string strSel_TopLinks = string.Empty;
        foreach (ListItem Sellist_TopLinks in chkList_TopMenuItems.Items)
        {
            if (Sellist_TopLinks.Selected)
                strSel_TopLinks = strSel_TopLinks + Sellist_TopLinks.Value + ',';
        }

        objWebSettings.TopMenuLinks = strSel_TopLinks;

        objWebSettings.Logo_ImgID = Convert.ToInt16(rdoLogoImage.SelectedValue);
        objWebSettings.Banner_ImgID = Convert.ToInt16(rdoBannerImage.SelectedValue);

        //Check to see if the user has ticked Display at Website for Logo 
           objWebSettings.User_LogoTicked = chkActive_Logo.Checked;
        
        //Check to see if the user has ticked Display at Website for Banner
           objWebSettings.User_BannerTicked = chkActive_Banner.Checked;
        



       // objWebSettings.CompanyInfo = txtCompanyInfo.Text;
       // objWebSettings.CompanyName = txtCompanyName.Text;

        //.. check to see if the user selected default or Entered new text
        if (rdoCopyRightsNewText.Checked)
        {
            objWebSettings.CopyRightInfo = txtNewCopyRightsInfo.Text;
        }
        else
        {
            objWebSettings.CopyRightInfo = rdoCopyRightsDefault.Text;
        }


        string strLogoImgFileName = string.Empty;
        string strBannerImgFileName = string.Empty;

        string strLogo_ImgActual_FileName = string.Empty;
        string strBanner_ImgActual_FileName = string.Empty;


        string strLogoImgFileURL = string.Empty;
        string strBannerImgFileURL = string.Empty;
        Random rnum = new Random();


        //.. Logo Image
        //if (AsyncFup_Logo.HasFile)
        //{
        //    strLogoImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + AsyncFup_Logo.FileName;
        //    strLogo_ImgActual_FileName = AsyncFup_Logo.FileName;
        //    //instead of server.mapPath set the path in web.config file and use that path.
        //    strLogoImgFileURL = Server.MapPath("~") + @"\ImageRepository\";
        //    AsyncFup_Logo.SaveAs(strLogoImgFileURL + strLogoImgFileName);
        //}

        if (ViewState["LogoWasUploaded"].ToString() == "true")
        {
            objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
            objWebSettings.Logo_ImgPath = @"\ImageRepository\";
            objWebSettings.Logo_ImgName = ViewState["FileImageName"].ToString();
            objWebSettings.Logo_ImgActualName = ViewState["ActualFileName"].ToString();

        }
        else
        {

            objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
            objWebSettings.Logo_ImgPath = @"\ImageRepository\";
            objWebSettings.Logo_ImgName = strLogoImgFileName;
            objWebSettings.Logo_ImgActualName = strLogo_ImgActual_FileName;

        }


        if (ViewState["BannerWasUploaded"].ToString() == "true")
        {
            objWebSettings.Banner_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.BannerImage);
            objWebSettings.Banner_ImgPath = @"\ImageRepository\";
            objWebSettings.Banner_ImgName = ViewState["Bnr_FileImageName"].ToString();
            objWebSettings.Banner_ImgActualName = ViewState["Bnr_ActualFileName"].ToString();

        }
        else
        {

            objWebSettings.Banner_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
            objWebSettings.Banner_ImgPath = @"\ImageRepository\";
            objWebSettings.Banner_ImgName = strBannerImgFileName;
            objWebSettings.Banner_ImgActualName = strBanner_ImgActual_FileName;

        }



        
        objWebSettings.ModifiedBy = Convert.ToInt32(Session["UserID"]);

        int inStatus = objBAL_AccountSettings.Update_Settings_HomePageDefaults(objWebSettings, Convert.ToInt32(Session["UserID"]));


        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "HomePage Settings successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

           // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
            Response.Redirect("MyHomePageSettings.aspx");
            
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
    protected void btn_FU_Logo_Click(object sender, EventArgs e)
    {
        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();


        if (FU_Logo.HasFile)
        {
            FileWasUpload = false;
            ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Logo.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

            FU_Logo.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessage.Text = "Image uploaded : " + FU_Logo.FileName + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>";
            FileWasUpload = true;
            ViewState["FileImageUrl"] = ImgFileUrl;
            ViewState["FileImageName"] = ImgFileName;
            ViewState["ActualFileName"] = FU_Logo.FileName;
            ViewState["LogoWasUploaded"] = "true";
        }
    }
    protected void btn_Banner_Logo0_Click(object sender, EventArgs e)
    {


        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();


        if (FU_Banner.HasFile)
        {
            FileWasUpload = false;
            ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Banner.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

            FU_Banner.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessageBanner.Text = "Image uploaded : " + FU_Banner.FileName  + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>"; ;
            FileWasUpload = true;
            ViewState["Bnr_FileImageUrl"] = ImgFileUrl;
            ViewState["Bnr_FileImageName"] = ImgFileName;
            ViewState["Bnr_ActualFileName"] = FU_Banner.FileName;
            ViewState["BannerWasUploaded"] = "true";
        }


    }


    protected void CustomVdr_Logo_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //15360 = 15 KB  ( 1024 * 15 )
        if (FU_Logo.FileBytes.Length > 15360)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }


    protected void CustomVdr_Banner_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //71680 = 70 KB  ( 1024 * 70 )
        //102400 = 70 KB  ( 1024 * 100 )
        //512000 = 500 KB


        //For flash files max size limit is 500 KB and for Jpg Banners is 100KB


        Boolean tmpValid = false;


        if (FU_Banner.FileName.Contains(".swf"))
        {
            //flash
            if (FU_Banner.FileBytes.Length > 204800)
                tmpValid = false;
            else
                tmpValid = true;

            CustomVdr_Banner.ErrorMessage = "Flash file should not be greater than 500KB.";
        }
        else
        {
            //others
            if (FU_Banner.FileBytes.Length > 102400)
                tmpValid = false;
            else
                tmpValid = false;
            CustomVdr_Banner.ErrorMessage = "Image size should not be greater than 100KB.";

        }

        args.IsValid = tmpValid;

        ////if (FU_Banner.FileBytes.Length > 71680)
        ////{
        ////    args.IsValid = false;
        ////}
        ////else
        ////{
        ////    args.IsValid = true;
        ////}
    }

}
