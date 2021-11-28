using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using CMSv3.BAL;


public partial class SA_AncImageList : System.Web.UI.Page 
{

    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();
    DataSet ds;
    DataTable dtAnchorImages;
    DataTable dtSelectedAncImg; 

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
        if ((Session["saUserID"] != null))
        {
            if (Session["saUserID"].ToString() == "")
                Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        else
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }

        #endregion 

       // LtrDispWebsite.Text = Resources.LangResources.DisplayatWebsite;
        FileWasUpload = Getbool();

        if (!IsPostBack)
        {


            if ((Request.QueryString["ImgToDelete"] != null) && (Request.QueryString["ImgToDelete"] != ""))
            {
                DeleteImage(Request.QueryString["ImgToDelete"]);
            }

            LoadAnchorImageInfo();

     
        }
    }


    protected void DeleteImage(string vImageID2Delete)
    {

        int tmpImageIDDelete = Convert.ToInt32(vImageID2Delete);

        int delStatus = objBAL_AccountSettings.DeleteAnchorImage(tmpImageIDDelete); 
        
        //alert javascript to show image delete
        CommonFunctions.AlertMessage("Image has been Deleted.");

    }

    protected void LoadAnchorImageInfo()
    {

        ds = objBAL_AccountSettings.Retrieve_AnchorImages(Convert.ToInt32(Session["saUserID"]));

        dtAnchorImages = ds.Tables[0];
        dtSelectedAncImg = ds.Tables[1];

        //int isAnchorImgSelected;
        int mSelAnchorImageID; 

        //.... getting the selected AnchorImage ID 
        if (dtSelectedAncImg.Rows.Count > 0)
        {
            DataRow uRow = (DataRow)dtSelectedAncImg.Rows[0];
            mSelAnchorImageID = Convert.ToInt16(uRow["AnchorImageID"]);
        }
        else
        {
            mSelAnchorImageID = 21; 
        }



        #region Code Section: Retreiving Anchor Images

        
        string temp = GlobalVar.GetImgStoreFolder.ToString();
        string ImageFolder = @".." + GlobalVar.GetImgStoreFolder.ToString() + "Mobile/";
        //int FirstSysLogoItem = 1;


        // rendering AnchorImages  

        DataView dvAnchorImages = dtAnchorImages.DefaultView;
        dvAnchorImages.RowFilter = "UserID = 101";

        
        foreach (DataRowView Lrow in dvAnchorImages)
        {
            string tmpAnchorImageName = Lrow["ImgName"].ToString();
            string tmpCategoryName = Lrow["AnchorDomain"].ToString();

            //showing different logo image for templates. 
            if ((tmpAnchorImageName.Substring(0, 10) == "AnchorTemp") || (tmpAnchorImageName.Substring(0, 3) == "101"))
            {
                String tmpAncImageNametoShow = "AnchorTemplate" + Lrow["ImageID"].ToString() + "   <font class='HelpInputCss3'>[" + tmpCategoryName + "]</font>";
                rdoAnchorImage.Items.Add(new ListItem(String.Format("<div id='dvAnchor' style='border: solid 1px #234565; width: 300px; height:250px;'><img  style='width:300px; height:250px;' src='{0}'></div>", ImageFolder + Lrow["ImgName"].ToString()), Lrow["ImageID"].ToString()));
                ListItem CurrItem = rdoAnchorImage.Items.FindByValue(Lrow["ImageID"].ToString());
               // CurrItem.Text = tmpAnchorImageName.Substring(0, tmpAnchorImageName.IndexOf(".")) + " <br/>" + CurrItem.Text;
                CurrItem.Text = tmpAncImageNametoShow + " <br/>" + CurrItem.Text;
            }
            else
            {
                rdoAnchorImage.Items.Add(new ListItem(String.Format("<div id='dvUsrAnchor' style='border: solid 1px #234565; width: 300px; height:250px; float:left;'><img style='width:300px; height:250px;' src='{0}'></div> <div id='dvdel' style='float:left;'><img alt='Delete AnchorImage' title='Delete Anchor' onclick='fnDeleteImage(" + Lrow["ImageID"].ToString() + ")' src='../../Images/round_notactive.gif' /></div>", ImageFolder + Lrow["ImgName"].ToString()), Lrow["ImageID"].ToString()));


                ListItem CurrItem = rdoAnchorImage.Items.FindByValue(Lrow["ImageID"].ToString());
                CurrItem.Text = "User AnchorImage  [ID :" + Lrow["ImgName"].ToString().Substring(4, 7) + "] <br/>" + CurrItem.Text;
            }

            //rdoAnchorImage.Items.Add(new ListItem(string.Format("<img src='{0}'>"),ImageFolder + Lrow["ImgName"].ToString()),Lrow["ImageID"].ToString()) ;


        }



        bool isAnchorSelected = false;
        // Marking user selection for Anchors
        foreach (ListItem Anchoritem in rdoAnchorImage.Items)
        {
            //Anchoritem.Text = "abc " + Anchoritem.Text;
            if (Convert.ToInt16(Anchoritem.Value) == mSelAnchorImageID)
            {
                Anchoritem.Selected = true;
                isAnchorSelected = true;
            }
        }


        ////enabling only the first logo radio buttons for WEB10 users
        //if (Session["UserDomainType"].ToString() == "WEB10")
        //{
        //    rdoAnchorImage.Items[0].Enabled = true;
        //}

        if (!isAnchorSelected)
            rdoAnchorImage.Items[0].Selected = true;



        #endregion
        
    }


    //protected void Button1_Click(object sender, EventArgs e)
    //{

    //    CMSv3.Entities.AdminSettings objWebSettings = new CMSv3.Entities.AdminSettings();
    //    CMSv3.BAL.AdminSettings objBAL_AdminSettings = new CMSv3.BAL.AdminSettings();


    //    //... using Logo entity  -->   for Anchor Image .......


    //    objWebSettings.Logo_ImgID = Convert.ToInt16(rdoAnchorImage.SelectedValue);
       
    //    //Check to see if the user has ticked Display at Website for Logo 
    //       objWebSettings.User_LogoTicked = chkActive_AnchorImg.Checked;
        
      
    //    string strLogoImgFileName = string.Empty;
    //    string strLogo_ImgActual_FileName = string.Empty;
    //    string strLogoImgFileURL = string.Empty;
       
    //    Random rnum = new Random();



    //    if (FU_AnchorImg.HasFile)
    //    {

    //        ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_AnchorImg.FileName;

    //        //instead of server.mapPath set the path in web.config file and use that path.
    //        ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\Mobile\";

    //        FU_AnchorImg.SaveAs(ImgFileUrl + ImgFileName);
    //        lblUpMessage.Text = "Image to be uploaded : " + FU_AnchorImg.FileName + "<br/>";
    //        FileWasUpload = true;
    //        //ViewState["FileImageUrl"] = ImgFileUrl;
    //        //ViewState["FileImageName"] = ImgFileName;
    //        //ViewState["ActualFileName"] = FU_Logo.FileName;
    //        //ViewState["LogoWasUploaded"] = "true";

    //        objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.AnchorImage);
    //        objWebSettings.Logo_ImgPath = @"\ImageRepository\\Mobile";
    //        objWebSettings.Logo_ImgName = ImgFileName;
    //        objWebSettings.Logo_ImgActualName = FU_AnchorImg.FileName; 

    //    }
    //    else
    //    {

    //        objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.AnchorImage);
    //        objWebSettings.Logo_ImgPath = @"\ImageRepository\Mobile";
    //        objWebSettings.Logo_ImgName = strLogoImgFileName;
    //        objWebSettings.Logo_ImgActualName = strLogo_ImgActual_FileName;

    //    }

    //    //if (ViewState["LogoWasUploaded"].ToString() == "true")
    //    //{
    //    //    objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
    //    //    objWebSettings.Logo_ImgPath = @"\ImageRepository\";
    //    //    objWebSettings.Logo_ImgName = ViewState["FileImageName"].ToString();
    //    //    objWebSettings.Logo_ImgActualName = ViewState["ActualFileName"].ToString();

    //    //}
    //    //else
    //    //{

    //    //    objWebSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
    //    //    objWebSettings.Logo_ImgPath = @"\ImageRepository\";
    //    //    objWebSettings.Logo_ImgName = strLogoImgFileName;
    //    //    objWebSettings.Logo_ImgActualName = strLogo_ImgActual_FileName;

    //    //}

        
    //    objWebSettings.ModifiedBy = Convert.ToInt32(Session["UserID"]);

    //    //int inStatus = objBAL_AccountSettings.Update_Settings_HomePageDefaults22(objWebSettings, Convert.ToInt32(Session["UserID"]));
    //    int inStatus = objBAL_AccountSettings.Update_AnchorImageSettings(objWebSettings, Convert.ToInt32(Session["UserID"])); 


    //    if (inStatus >= 1)
    //    {
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";
    //        //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
    //        lblErrMessage.Text = "Anchor Image settings successfully updated";
    //        lblErrMessage.CssClass = "font_12Msg_Success";

    //       // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
    //        Response.Redirect("Ad_MobiAnchorImg.aspx");
            
    //        return;

    //    }
    //    else
    //    {
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //        lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //    }




    //}

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

    

    //protected void CustomVdr_Logo_ServerValidate(object source, ServerValidateEventArgs args)
    //{
    //    //30720 = 15 KB  ( 1024 * 30 )
    //    if (FU_AnchorImg.FileBytes.Length > 30720)
    //    {
    //        args.IsValid = false;
    //    }
    //    else
    //    {
    //        args.IsValid = true;
    //    }
    //}


   
}
