using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.Sql; 
using System.Data.SqlClient;

public partial class Admin_Ad_MobileOwnButtonCreate : System.Web.UI.Page
{
    DataSet ds;
    DataTable dtBtnContent;  
    int mUserID;
    int mButtonNo;
    String mIconImgID;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;
    bool FileWasUpload;
    String tmpPictureImg = string.Empty;
    String tmpPictureImgID = string.Empty;
    CMSv3.BAL.MbOwnButtons objMbOwnBtns = new CMSv3.BAL.MbOwnButtons(); 

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        #region Code to Hide Menu buttons for WebPortal

        //HtmlTableRow tr1 = (HtmlTableRow)Master.FindControl("MROW1");
        //tr1.Visible = false;


        //HtmlTableRow tr2 = (HtmlTableRow)Master.FindControl("MROW2");
        //tr2.Visible = false;

        //HtmlTableRow tr3 = (HtmlTableRow)Master.FindControl("MROW3");
        //tr3.Visible = false;

        //HtmlContainerControl tmpDivHeader = (HtmlContainerControl)Master.FindControl("headercontent");
        //tmpDivHeader.Attributes.Add("height", "80px");

        #endregion

        #region to hide left contentplaceholder

        HtmlGenericControl myDivLeftBar;
        myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

        myDivLeftBar.Style.Clear();
        myDivLeftBar.Style.Value = "width:0px;";


        HtmlGenericControl myDivRightBar;
        myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

        myDivRightBar.Style.Clear();
        myDivRightBar.Style.Value = " width: 96%; padding-left:20px;";

        #endregion

        FileWasUpload = GetBoolean();
        Page.MaintainScrollPositionOnPostBack = false;

        if ((Request.QueryString["bt"] != null) && (Request.QueryString["bt"].ToString() != ""))
            mButtonNo = Convert.ToInt32(Request.QueryString["bt"].ToString());
        else
            mButtonNo = 1;


        mUserID = Convert.ToInt32(Session["UserID"].ToString()); 


        if (!IsPostBack)
        {

            ViewState["LogoWasUploaded"] = "false";
            ViewState["PictureWasUploaded"] = "false";
            ViewState["ExistingPicImgId"] = "";
            ViewState["FileImageUrl"] = 0;

            if (Request.QueryString["ImgToDelete"] != null)
            {
                if(Request.QueryString["ImgToDelete"].ToString() != "")
                        DeleteImage(Request.QueryString["ImgToDelete"]);
            }

            LoadOwnButtonInfo(mButtonNo, mUserID); 

        }

    }

    private static bool GetBoolean()
    {
        return false;

    }
    protected void LoadOwnButtonInfo(int vButtonNo,int vUserId)
    {

        ltrOwnButtonHeader.Text = "My Mobile Button : " + vButtonNo.ToString(); 

        ds = objMbOwnBtns.Retrieve_OwnButtonContent(vButtonNo, vUserId);

        dtBtnContent = ds.Tables[0];

        foreach (DataRow dtBtnRow in dtBtnContent.Rows)
        {

            //chkActive.Checked = Convert.ToBoolean(dtBtnRow["Active"].ToString());

            //if (chkActive.Checked)
            //    chkActive.Text = " Uncheck to hide this button at mobile website.";
            //else
            //    chkActive.Text = " Check to show this button at mobile website.";



            txtButtonName.Text = dtBtnRow["OwnBtnName"].ToString();
            txtBtnContent.Text = dtBtnRow["OwnBtnDesc"].ToString();
            txtVideoLink.Text = dtBtnRow["YouTubeLink"].ToString();
            tmpPictureImg = dtBtnRow["OwnBtnPicture"].ToString();
            ViewState["ExistingPicImgId"] = dtBtnRow["OwnBtnPicImgId"].ToString(); 
            mIconImgID = dtBtnRow["OwnBtnIconImgID"].ToString(); 

        }

        //..Rendering Mobile Icons...

        ds = objMbOwnBtns.Retrieve_OwnButtonIcons(vUserId);
        DataTable dtLogos = new DataTable();

        dtLogos = ds.Tables[0];


        string temp = GlobalVar.GetImgStoreFolder.ToString();
        string ImageFolder = @"../.." + GlobalVar.GetImgStoreFolder.ToString() + @"Mobile/";

        rdoIconImage.Items.Clear(); 

        foreach (DataRow Lrow in dtLogos.Rows)
        {
            string tmpLogoImageName = Lrow["ImgName"].ToString();
            int tmpLogoUserID = Convert.ToInt32(Lrow["UserID"].ToString());

            //showing different logo image for templates. 
            //if (tmpLogoImageName.Substring(0, 8) == "IconTemp")
            if(tmpLogoUserID == 101)
            {
                rdoIconImage.Items.Add(new ListItem(String.Format("<div id='dvLogo' style='border: solid 1px #234565; width:150px; height:75px;'><img  style='max-width:180px; max-height:75px;' src='{0}'></div>", ImageFolder + Lrow["ImgName"].ToString()), Lrow["ImageID"].ToString()));
                ListItem CurrItem = rdoIconImage.Items.FindByValue(Lrow["ImageID"].ToString());
                CurrItem.Text = tmpLogoImageName.Substring(0, tmpLogoImageName.IndexOf(".")) + " <br/>" + CurrItem.Text;

            }
            else
            {
                rdoIconImage.Items.Add(new ListItem(String.Format("<div id='dvUsrLogo' style='border: solid 1px #234565; width:150px; height:75px; float:left;'><img style='max-width:180px; max-height:75px;' src='{0}'></div> <div id='dvdel' style='float:left;'><img alt='Delete Logo' title='Delete Icon' onclick='fnDeleteImage(" + Lrow["ImageID"].ToString() + ")' src='../../Images/round_notactive.gif' /></div>", ImageFolder + Lrow["ImgName"].ToString()), Lrow["ImageID"].ToString()));


                ListItem CurrItem = rdoIconImage.Items.FindByValue(Lrow["ImageID"].ToString());
                CurrItem.Text = "User Logo  [ID :" + Lrow["ImgName"].ToString().Substring(4, 7) + "] <br/>" + CurrItem.Text;
            }

        }

        bool isLogoSelected = false;
        // Marking user selection for logos

        if (mIconImgID != "")
        {
            foreach (ListItem Logoitem in rdoIconImage.Items)
            {
                //Logoitem.Text = "abc " + Logoitem.Text;
                if (Convert.ToInt16(Logoitem.Value) == Convert.ToInt16(mIconImgID))
                {
                    Logoitem.Selected = true;
                    isLogoSelected = true;
                }
            }
        }


        if (!isLogoSelected)
            rdoIconImage.Items[0].Selected = true;

        

        //..Rendering Picture image 

        if (tmpPictureImg != string.Empty)
        {
            ImgUserPicture.ImageUrl = ImageFolder + tmpPictureImg;
            btnRemoveImage.Visible = true;
        }
        else
        {
            ImgUserPicture.ImageUrl = ImageFolder + "noImage.jpg";
            btnRemoveImage.Visible = false;
        }
        




    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid)
            return;

        string strLogoImgFileName = string.Empty;
        string strLogo_ImgActual_FileName = string.Empty;

        string strPictureImgFilename = string.Empty;
        string strPic_ImgActual_Filename = string.Empty;
        

        //bool vChkActive = chkActive.Checked;
        string vBtnName = txtButtonName.Text.Trim();
        string vBtnContent = txtBtnContent.Text.Trim();
        string vVideoLink = txtVideoLink.Text.Trim();



        CMSv3.Entities.AdminSettings objWebSettings = new CMSv3.Entities.AdminSettings();

        /// --------------------------------------------------
        /// using  LOGO --->  ICON  and    BANNER --> PICTURE 
        /// --------------------------------------------------
        

        objWebSettings.Logo_ImgID = Convert.ToInt16(rdoIconImage.SelectedValue);
      
        //Check to see if the user has ticked Display at Website for Icon 
        objWebSettings.User_LogoTicked = chkActive_Logo.Checked;

        ////-- Gathering ICON details
        //if (ViewState["LogoWasUploaded"].ToString() == "true")
        //{
        //    objWebSettings.Logo_ImgType = 1;
        //    objWebSettings.Logo_ImgPath = @"\ImageRepository\";
        //    objWebSettings.Logo_ImgName = ViewState["FileImageName"].ToString();
        //    objWebSettings.Logo_ImgActualName = ViewState["ActualFileName"].ToString();

        //}
        //else
        //{

        //    objWebSettings.Logo_ImgType = 1;
        //    objWebSettings.Logo_ImgPath = @"\ImageRepository\";
        //    objWebSettings.Logo_ImgName = strLogoImgFileName;
        //    objWebSettings.Logo_ImgActualName = strLogo_ImgActual_FileName;

        //}


        //..Gathering ICON Details 

        //Store Image file prefixed with userid_randomNo_fileName 
        Random inum = new Random();


        if (FU_Logo.HasFile)
        {
            if (FU_Logo.FileBytes.Length < 30720)
            {
                FileWasUpload = false;
                ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(inum.Next(9999999)) + "_" + FU_Logo.FileName;

                //instead of server.mapPath set the path in web.config file and use that path.
                ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\Mobile\";

                FU_Logo.SaveAs(ImgFileUrl + ImgFileName);
                lblUpMessage.Text = "Icon uploaded : " + FU_Logo.FileName + "";
                FileWasUpload = true;

                objWebSettings.Logo_ImgType = 1;
                objWebSettings.Logo_ImgPath = @"\ImageRepository\";
                objWebSettings.Logo_ImgName = ImgFileName;
                objWebSettings.Logo_ImgActualName = FU_Logo.FileName;

            }
        }
        else
        {
            objWebSettings.Logo_ImgType = 1;
            objWebSettings.Logo_ImgPath = @"\ImageRepository\";
            objWebSettings.Logo_ImgName = strLogoImgFileName;
            objWebSettings.Logo_ImgActualName = strLogo_ImgActual_FileName;
        }




        //..Gathering Picture Details 
        if (FU_Picture.HasFile)
        {
            if (FU_Picture.FileBytes.Length < 102400)
            {
                FileWasUpload = false;
                Random rnum = new Random();
                ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Picture.FileName;

                //instead of server.mapPath set the path in web.config file and use that path.
                ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\Mobile\";

                FU_Picture.SaveAs(ImgFileUrl + ImgFileName);
                lblPIC_UpMessage.Text = "Image uploaded : " + FU_Picture.FileName;
                //lblPIC_UpMessage.Text = "Image uploaded : " + FU_Picture.FileName + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>";
                FileWasUpload = true;
                // ViewState["PIC_FileImageUrl"] = ImgFileUrl;
                // ViewState["PIC_FileImageName"] = ImgFileName;
                // ViewState["PIC_ActualFileName"] = FU_Picture.FileName;
                // ViewState["PictureWasUploaded"] = "true";


                objWebSettings.Banner_ImgID = 0;
                objWebSettings.Banner_ImgType = 2;
                objWebSettings.Banner_ImgPath = @"\ImageRepository\";
                objWebSettings.Banner_ImgName = ImgFileName;
                objWebSettings.Banner_ImgActualName = FU_Picture.FileName;


            }
        }
        else
        {
            if (ViewState["ExistingPicImgId"].ToString() != "")
                objWebSettings.Banner_ImgID = Convert.ToInt32(ViewState["ExistingPicImgId"].ToString());
            else
                objWebSettings.Banner_ImgID = 0;

            objWebSettings.Banner_ImgType = 2;
            objWebSettings.Banner_ImgPath = @"\ImageRepository\";
            objWebSettings.Banner_ImgName = strPictureImgFilename;
            objWebSettings.Banner_ImgActualName = strPic_ImgActual_Filename;

        }

       

        //if (ViewState["PictureWasUploaded"].ToString() == "true")
        //{
        //    objWebSettings.Banner_ImgID = 0; 
        //    objWebSettings.Banner_ImgType = 2;
        //    objWebSettings.Banner_ImgPath = @"\ImageRepository\";
        //    objWebSettings.Banner_ImgName = ViewState["PIC_FileImageName"].ToString();
        //    objWebSettings.Banner_ImgActualName = ViewState["PIC_ActualFileName"].ToString();

        //}
        //else
        //{
        //    if(ViewState["ExistingPicImgId"].ToString() != "")
        //        objWebSettings.Banner_ImgID = Convert.ToInt32(ViewState["ExistingPicImgId"].ToString()); 
        //    else
        //        objWebSettings.Banner_ImgID = 0;

        //    objWebSettings.Banner_ImgType = 2; 
        //    objWebSettings.Banner_ImgPath = @"\ImageRepository\";
        //    objWebSettings.Banner_ImgName = strPictureImgFilename;
        //    objWebSettings.Banner_ImgActualName = strPic_ImgActual_Filename;

        //}

        
        

        int status = objMbOwnBtns.Save_OwnButtonContent(mButtonNo, mUserID, vBtnName, vBtnContent, objWebSettings.Logo_ImgID, vVideoLink, objWebSettings);

        if (status >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Own Button successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Create / Update failed for OwnButton";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }

        LoadOwnButtonInfo(mButtonNo, mUserID); 

    }

    protected void btn_FU_Logo_Click(object sender, EventArgs e)
    {
        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();


        if (FU_Logo.HasFile)
        {
            if (FU_Logo.FileBytes.Length < 30720)
            {
                FileWasUpload = false;
                ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Logo.FileName;

                //instead of server.mapPath set the path in web.config file and use that path.
                ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\Mobile\";

                FU_Logo.SaveAs(ImgFileUrl + ImgFileName);
                lblUpMessage.Text = "Image uploaded : " + FU_Logo.FileName + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>";
                FileWasUpload = true;
                ViewState["FileImageUrl"] = ImgFileUrl;
                ViewState["FileImageName"] = ImgFileName;
                ViewState["ActualFileName"] = FU_Logo.FileName;
                ViewState["LogoWasUploaded"] = "true";
            }
        }
    }



    protected void CustomVdr_Logo_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //15360 = 15 KB  ( 1024 * 15 )
        if (FU_Logo.FileBytes.Length > 30720)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }


    protected void DeleteImage(string vImageID2Delete)
    {

        int tmpImageIDDelete = Convert.ToInt32(vImageID2Delete);


        int delStatus = objMbOwnBtns.Delete_UserIcon(tmpImageIDDelete);

        //alert javascript to show image delete
        CommonFunctions.AlertMessage("User Icon has been Deleted.");

    }



    protected void btn_FU_Picture_Click(object sender, EventArgs e)
    {
        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();

        
        if (FU_Picture.HasFile)
        {
            if (FU_Picture.FileBytes.Length < 102400)
            {
                FileWasUpload = false;
                ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Picture.FileName;

                //instead of server.mapPath set the path in web.config file and use that path.
                ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\Mobile\";

                FU_Picture.SaveAs(ImgFileUrl + ImgFileName);
                lblPIC_UpMessage.Text = "Image uploaded : " + FU_Picture.FileName + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>";
                FileWasUpload = true;
                ViewState["PIC_FileImageUrl"] = ImgFileUrl;
                ViewState["PIC_FileImageName"] = ImgFileName;
                ViewState["PIC_ActualFileName"] = FU_Picture.FileName;
                ViewState["PictureWasUploaded"] = "true";
            }
        }
    }


    protected void CustomVdr_Picture_ServerValidate(object source, ServerValidateEventArgs args)
    {

        //30720 = 30 KB  ( 1024 * 30 )
        if (FU_Picture.FileBytes.Length > 102400)
        {
            args.IsValid = false;
            //dvImgUploadError.Visible = true;
            //dvImgUploadError.InnerHtml = "Image size should be less 100KB";
            CommonFunctions.AlertMessage("Image size should be less then 100kb:");
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void btnRemoveImage_Click(object sender, EventArgs e)
    {

        int delstatus = objMbOwnBtns.Delete_UserImage(mUserID, mButtonNo);


        if (delstatus > 1)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                lblErrMessage.Text = "Image successfully deleted.";
                lblErrMessage.CssClass = "font_12Msg_Success";
                CommonFunctions.AlertMessage("Image successfully deleted."); 

            }
            else
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";
                lblErrMessage.Text = "Image could not be deleted.";
                lblErrMessage.CssClass = "font_12Msg_Error";
                CommonFunctions.AlertMessage("Image could not be deleted."); 
            }

        LoadOwnButtonInfo(mUserID, mButtonNo); 
       
    }
}

