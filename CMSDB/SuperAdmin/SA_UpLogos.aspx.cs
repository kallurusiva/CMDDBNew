using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using CMSv3.BAL;


public partial class SA_UpLogos : BasePage 
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
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        Page.MaintainScrollPositionOnPostBack = true;
       // LtrDispWebsite.Text = Resources.LangResources.DisplayatWebsite;
        FileWasUpload = Getbool();

       

        if (!IsPostBack)
        {
            ViewState["LogoWasUploaded"] = "false";
            ViewState["BannerWasUploaded"] = "false";
            ViewState["FileImageUrl"] = "";

            if ((Request.QueryString["ImgToDelete"] != null) && (Request.QueryString["ImgToDelete"].ToString() != ""))
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
        

        ds = objBAL_AccountSettings.RetrieveALL_Settings_HomePage_Defaults(Convert.ToInt32(Session["saUserID"]));

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

            #region --  Code to render CopyRightsInfo // commented code 
            //mCopyRightInfo = uRow["CopyrightsInfo"].ToString();

            //if (mCopyRightInfo.Trim() == "")
            //{
            //    //   Later to use domain name for the copyrights information.
            //    //   rdoCopyRightsDefault.Text = "All rights reserved @2010. " + mCompanyName.ToString();

            //    //Currently
            //    rdoCopyRightsDefault.Text = "Copyrights@2010.  All Rights Reserved.";

            //    rdoCopyRightsDefault.Checked = true;
            //    rdoCopyRightsNewText.Checked = false;
            //}
            //else
            //{
            //    rdoCopyRightsDefault.Text = "Copyrights@2010.  All Rights Reserved.";
            //    //rdoCopyRightsNewText.Text = mCopyRightInfo.ToString();
            //    txtNewCopyRightsInfo.Text = mCopyRightInfo.ToString();
            //    rdoCopyRightsNewText.Checked = true;
            //    rdoCopyRightsDefault.Checked = false;
            //}


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
            
           // rdoCopyRightsDefault.Text = "Copyrights @ 2010 . All rights reserved. ";
            mLogoImgId = 12;
            mBannerImgId = 10;
            tmpDefaultLanguage = "en-US";
            mTopMenuLinks = "1,2,3,4,5,6,7,8";
            mCompanyName = "";
            mCompanyInfo = "";
            mCopyRightInfo = "";
        }

     
                
        #region Code Section: Logo and Banner Images 

                
                    string temp = GlobalVar.GetImgStoreFolder.ToString(); 
                    string ImageFolder = @".." + GlobalVar.GetImgStoreFolder.ToString();
                    //int FirstSysLogoItem = 1; 
                    // rendering Logos 
                   foreach (DataRow Lrow in dtLogos.Rows)
                    {
                      string tmpLogoImageName = Lrow["ImgName"].ToString() ;
                        
                      // //showing different logo image for templates. 
                      //if (tmpLogoImageName.Substring(0, 8) == "LogoTemp")
                      //{
                      //    rdoLogoImage.Items.Add(new ListItem(String.Format("<img class='SelLogoCss' height='80px' width='180px' src='{0}'>", ImageFolder + Lrow["ImgActualName"].ToString()), Lrow["ImageID"].ToString()));
                      //    ListItem CurrItem = rdoLogoImage.Items.FindByValue(Lrow["ImageID"].ToString());
                      //    CurrItem.Text = tmpLogoImageName.Substring(0, 13) + " <br/>" + CurrItem.Text;

                        

                      //}
                      //else
                      //{
                          rdoLogoImage.Items.Add(new ListItem(String.Format("<img class='SelLogoCss' height='80px' width='180px' src='{0}'> &nbsp;  <img alt='Delete Logo' title='Delete Logo' onclick='fnDeleteImage(" + Lrow["ImageID"].ToString()  + ")' src='../Images/round_notactive.gif' />", ImageFolder + Lrow["ImgName"].ToString()), Lrow["ImageID"].ToString()));
                          
                          
                          ListItem CurrItem = rdoLogoImage.Items.FindByValue(Lrow["ImageID"].ToString());
                          CurrItem.Text = "[" + tmpLogoImageName.Substring(0,tmpLogoImageName.IndexOf(".")) + "] <br/>" + CurrItem.Text;
                      //}

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


    public void SaveUploads()
    {

        CMSv3.Entities.AdminSettings objWebSettings = new CMSv3.Entities.AdminSettings();
        CMSv3.BAL.AdminSettings objBAL_AdminSettings = new CMSv3.BAL.AdminSettings();


        

        string strLogoImgFileName = string.Empty;
        string strBannerImgFileName = string.Empty;

        string strLogo_ImgActual_FileName = string.Empty;
        string strBanner_ImgActual_FileName = string.Empty;


        string strLogoImgFileURL = string.Empty;
        string strBannerImgFileURL = string.Empty;
        Random rnum = new Random();



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


        objWebSettings.ModifiedBy = Convert.ToInt32(Session["saUserID"]);

        //int inStatus = objBAL_AccountSettings.Update_Settings_HomePageDefaults(objWebSettings, Convert.ToInt32(Session["saUserID"]));
        int inStatus = objBAL_AccountSettings.Update_LogoSettings(objWebSettings, Convert.ToInt32(Session["saUserID"]));

        

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Logo successfully uploaded";
            lblErrMessage.CssClass = "font_12Msg_Success";

            // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
            Response.Redirect("SA_UpLogos.aspx");

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


    protected void Button1_Click(object sender, EventArgs e)
    {

        CMSv3.Entities.AdminSettings objWebSettings = new CMSv3.Entities.AdminSettings();
        CMSv3.BAL.AdminSettings objBAL_AdminSettings = new CMSv3.BAL.AdminSettings();


     

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
        //    strLogoImgFileName = Session["saUserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + AsyncFup_Logo.FileName;
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


        
        objWebSettings.ModifiedBy = Convert.ToInt32(Session["saUserID"]);

        //int inStatus = objBAL_AccountSettings.Update_Settings_HomePageDefaults(objWebSettings, Convert.ToInt32(Session["saUserID"]));
        int inStatus = objBAL_AccountSettings.Save_NewLogo(objWebSettings, Convert.ToInt32(Session["saUserID"])); 

        

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Logo uploaded successfully";
            lblErrMessage.CssClass = "font_12Msg_Success";

           // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
            Response.Redirect("SA_UpLogos.aspx");
            
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

            ImgFileName = Session["saUserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Logo.FileName;

            ImgFileName = "LogoTemplate" + "_" + Convert.ToString(rnum.Next(9999999)) + ".jpg";

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

            FU_Logo.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessage.Text = "Image uploaded : " + FU_Logo.FileName;
            FileWasUpload = true;
            ViewState["FileImageUrl"] = ImgFileUrl;
            ViewState["FileImageName"] = ImgFileName;
            ViewState["ActualFileName"] = FU_Logo.FileName;
            ViewState["LogoWasUploaded"] = "true";

            SaveUploads();
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


 
}
