using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using CMSv3.BAL;


public partial class Admin_Ad_LogoSettings : BasePage 
{

    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();
    DataSet ds;
    DataTable dtTopMenu;
    DataTable dtLogos;
    DataTable dtBanners;
    DataTable dtUserInfo;
    DataTable dtTopRow; 

    bool FileWasUpload = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;


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

        //tr_bannerBody.Visible = false;
        //tr_bannerHead.Visible = false;

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

    private static bool Getbool()
    {
        return false;
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
        string mTopRowLinks = string.Empty;
        int mLogoImgId;
        //int mBannerImgId;
        string mCompanyName = string.Empty;
        string mCompanyInfo = string.Empty;
        string mCopyRightInfo = string.Empty;
        

        ds = objBAL_AccountSettings.RetrieveALL_Settings_HomePage_Defaults(Convert.ToInt32(Session["UserID"]));

        dtTopMenu = ds.Tables[0];
        dtLogos = ds.Tables[1];
        dtBanners = ds.Tables[2];
        dtUserInfo = ds.Tables[3];
        dtTopRow = ds.Tables[4];





        //User Info
        if (dtUserInfo.Rows.Count > 0)
        {

            DataRow uRow = (DataRow)dtUserInfo.Rows[0];

             mLogoImgId = Convert.ToInt16(uRow["ImageID_Logo"]);
            

        }
        else
        {
            
            //rdoCopyRightsDefault.Text = "Copyrights @ 2010 . All rights reserved. ";
            mLogoImgId = 12;
            //mBannerImgId = 10;
            tmpDefaultLanguage = "en-US";
            mTopMenuLinks = "1,2,3,4,5,6,7,8";
            mTopRowLinks = "1,2,3,4,5";
            mCompanyName = "";
            mCompanyInfo = "";
            mCopyRightInfo = "";
        }

   

                
        #region Code Section: Logo  Images 

                
                string temp = GlobalVar.GetImgStoreFolder.ToString();
                string ImageFolder = @".." + GlobalVar.GetImgStoreFolder.ToString();
                int FirstSysLogoItem = 1;
                // rendering Logos 
                foreach (DataRow Lrow in dtLogos.Rows)
                {
                    string tmpLogoImageName = Lrow["ImgName"].ToString();

                    //showing different logo image for templates. 
                    if (tmpLogoImageName.Substring(0, 8) == "LogoTemp")
                    {
                        rdoLogoImage.Items.Add(new ListItem(String.Format("<div id='dvLogo' style='border: solid 1px #234565; width: 180px; height:80px;'><img  style='max-width:180px; max-height:75px;' src='{0}'></div>", ImageFolder + Lrow["ImgName"].ToString()), Lrow["ImageID"].ToString()));
                        ListItem CurrItem = rdoLogoImage.Items.FindByValue(Lrow["ImageID"].ToString());
                        CurrItem.Text = tmpLogoImageName.Substring(0, tmpLogoImageName.IndexOf(".")) + " <br/>" + CurrItem.Text;


                        //disabling the logo radio buttons for WEB10 users
                        if (Session["UserDomainType"].ToString() == "WEB10")
                        {
                            if (FirstSysLogoItem != 1)  // skipping the first logo button 
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



                #endregion


    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        CMSv3.Entities.AdminSettings objWebSettings = new CMSv3.Entities.AdminSettings();
        CMSv3.BAL.AdminSettings objBAL_AdminSettings = new CMSv3.BAL.AdminSettings();



        objWebSettings.Logo_ImgID = Convert.ToInt16(rdoLogoImage.SelectedValue);
       
        //Check to see if the user has ticked Display at Website for Logo 
           objWebSettings.User_LogoTicked = chkActive_Logo.Checked;
        
      
        string strLogoImgFileName = string.Empty;
        string strLogo_ImgActual_FileName = string.Empty;
        string strLogoImgFileURL = string.Empty;
       
        Random rnum = new Random();



        if (FU_Logo.HasFile)
        {

            ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Logo.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

            FU_Logo.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessage.Text = "Image to be uploaded : " + FU_Logo.FileName + "<br/>";
            FileWasUpload = true;
            //ViewState["FileImageUrl"] = ImgFileUrl;
            //ViewState["FileImageName"] = ImgFileName;
            //ViewState["ActualFileName"] = FU_Logo.FileName;
            //ViewState["LogoWasUploaded"] = "true";

            objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
            objWebSettings.Logo_ImgPath = @"\ImageRepository\";
            objWebSettings.Logo_ImgName = ImgFileName;
            objWebSettings.Logo_ImgActualName = FU_Logo.FileName; 

        }
        else
        {

            objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
            objWebSettings.Logo_ImgPath = @"\ImageRepository\";
            objWebSettings.Logo_ImgName = strLogoImgFileName;
            objWebSettings.Logo_ImgActualName = strLogo_ImgActual_FileName;

        }

        //if (ViewState["LogoWasUploaded"].ToString() == "true")
        //{
        //    objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
        //    objWebSettings.Logo_ImgPath = @"\ImageRepository\";
        //    objWebSettings.Logo_ImgName = ViewState["FileImageName"].ToString();
        //    objWebSettings.Logo_ImgActualName = ViewState["ActualFileName"].ToString();

        //}
        //else
        //{

        //    objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
        //    objWebSettings.Logo_ImgPath = @"\ImageRepository\";
        //    objWebSettings.Logo_ImgName = strLogoImgFileName;
        //    objWebSettings.Logo_ImgActualName = strLogo_ImgActual_FileName;

        //}

        
        objWebSettings.ModifiedBy = Convert.ToInt32(Session["UserID"]);

        //int inStatus = objBAL_AccountSettings.Update_Settings_HomePageDefaults22(objWebSettings, Convert.ToInt32(Session["UserID"]));
        int inStatus = objBAL_AccountSettings.Update_LogoSettings(objWebSettings, Convert.ToInt32(Session["UserID"])); 



        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Logo settings successfully updated";
            lblErrMessage.CssClass = "font_12Msg_Success";

           // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
            Response.Redirect("Ad_LogoSettings.aspx");
            
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

    //protected void btn_FU_Logo_Click(object sender, EventArgs e)
    //{
    //    //Store Image file prefixed with userid_randomNo_fileName 
    //    Random rnum = new Random();


    //    if (FU_Logo.HasFile)
    //    {

    //        ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Logo.FileName;

    //        //instead of server.mapPath set the path in web.config file and use that path.
    //        ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

    //        FU_Logo.SaveAs(ImgFileUrl + ImgFileName);
    //        lblUpMessage.Text = "Image uploaded : " + FU_Logo.FileName + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>";
    //        FileWasUpload = true;
    //        ViewState["FileImageUrl"] = ImgFileUrl;
    //        ViewState["FileImageName"] = ImgFileName;
    //        ViewState["ActualFileName"] = FU_Logo.FileName;
    //        ViewState["LogoWasUploaded"] = "true";
    //    }
    //}

    

    protected void CustomVdr_Logo_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //30720 = 15 KB  ( 1024 * 30 )
        if (FU_Logo.FileBytes.Length > 30720)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }


   
}
