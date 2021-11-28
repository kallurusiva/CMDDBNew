using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using CMSv3.BAL;




public partial class Admin_Settings_HomePage : BasePage
{

    CMSv3.BAL.AdminSettings objBAL_AdminSettings = new CMSv3.BAL.AdminSettings();
    
    DataSet ds;


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 


        if (!IsPostBack)
        {

            RenderFormLiterals();

            //Load Top Menu Links
            LoadTopMenuLInks();
            LoadCommAppsItems();

        }


    }


    protected void RenderFormLiterals()
    {

        try
        {
            string resCompanyName = (string)GetGlobalResourceObject("LangResources", "Company");

            LtrSelectTopMenuLinks.Text = (string)GetGlobalResourceObject("LangResources", "AdHom_SelTopMenuLinks");
            LtrCompanyName.Text =  resCompanyName + " " + (string)GetGlobalResourceObject("LangResources", "Name");
            LtrCompanyInfo.Text = resCompanyName + " " + (string)GetGlobalResourceObject("LangResources", "Information");
        }
        catch(Exception ex) 
        {
            throw ex;
        }

    }


    protected void LoadTopMenuLInks()
    {

        //Get top menu links
        ds = objBAL_AdminSettings.GetAll_TopmenuLinks();

        chkList_TopMenuItems.DataSource = ds;
        chkList_TopMenuItems.DataTextField = "LinkName";
        chkList_TopMenuItems.DataValueField = "LinkID";
        chkList_TopMenuItems.DataBind();


    }

    protected void LoadCommAppsItems()
    {


        ds = objBAL_AdminSettings.GetAll_CommApps();

        chkLst_CommLinks.DataSource = ds;
        chkLst_CommLinks.DataTextField = "ComAppName";
        chkLst_CommLinks.DataValueField = "ComAppId";
        chkLst_CommLinks.DataBind();


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        String strSel_TopLinks = string.Empty;
        String strSel_ComApps = string.Empty;

        Random rnum = new Random();

        
        //Get the filled in form values; 

        //--top menu links.
        foreach (ListItem Sellist_TopLinks in chkList_TopMenuItems.Items)
        {
            if(Sellist_TopLinks.Selected)
            strSel_TopLinks = strSel_TopLinks + Sellist_TopLinks.Value + ',';
        }

        //-- Communication Applications .
        foreach (ListItem Sellist_ComApps in chkLst_CommLinks.Items)
        {
            if(Sellist_ComApps.Selected)
                strSel_ComApps = strSel_ComApps + Sellist_ComApps.Value + ',';
        }

   
        string strLogoImgFileName = string.Empty;
        string strBannerImgFileName = string.Empty;

        string strLogo_ImgActual_FileName = string.Empty;
        string strBanner_ImgActual_FileName = string.Empty;


        string strLogoImgFileURL = string.Empty;
        string strBannerImgFileURL = string.Empty;


        //.. Logo Image
        if (AsyncFup_Logo.HasFile)
        {
            strLogoImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + AsyncFup_Logo.FileName;
            strLogo_ImgActual_FileName = AsyncFup_Logo.FileName;
            //instead of server.mapPath set the path in web.config file and use that path.
            strLogoImgFileURL = Server.MapPath("~") + @"\ImageRepository\";
            AsyncFup_Logo.SaveAs(strLogoImgFileURL + strLogoImgFileName);
        }


        //.. Banner Image
        if (AsyncFup_Banner.HasFile)
        {

            strBannerImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + AsyncFup_Banner.FileName;
            strBanner_ImgActual_FileName = AsyncFup_Banner.FileName;
            //instead of server.mapPath set the path in web.config file and use that path.
            strBannerImgFileURL = Server.MapPath("~") + @"\ImageRepository\";
            AsyncFup_Banner.SaveAs(strBannerImgFileURL + strBannerImgFileName);
        }



        CMSv3.Entities.AdminSettings obj_AdminSettings = new CMSv3.Entities.AdminSettings();

        obj_AdminSettings.CompanyInfo = txtCompanyInfo.Text;
        obj_AdminSettings.CompanyName = txtCompanyName.Text;
        obj_AdminSettings.CopyRightInfo = txtCopyRightInfo.Text;
        //obj_AdminSettings.DefLanguage 
        obj_AdminSettings.CommAppsToShow = strSel_ComApps;
        obj_AdminSettings.TopMenuLinks = strSel_TopLinks;
        obj_AdminSettings.ModifiedBy = Convert.ToInt32(Session["UserID"].ToString());

        //obj_AdminSettings.ShowEvents = chkEvents.Checked;
        //obj_AdminSettings.ShowNews = chkNews.Checked;

        obj_AdminSettings.Logo_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
        obj_AdminSettings.Logo_ImgPath = @"\ImageRepository\";
        obj_AdminSettings.Logo_ImgName = strLogoImgFileName;
        obj_AdminSettings.Logo_ImgActualName = strLogo_ImgActual_FileName;

        obj_AdminSettings.Banner_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.BannerImage);
        obj_AdminSettings.Banner_ImgPath = @"\ImageRepository\";
        obj_AdminSettings.Banner_ImgName = strBannerImgFileName;
        obj_AdminSettings.Banner_ImgActualName = strBanner_ImgActual_FileName;

        
            //-- The Following code was to store the image directly to database using varbinary field

            ////--- LOGO IMAGE 
            //Stream imgLogoStream = AsyncFup_Logo.PostedFile.InputStream;
            //int imgLogoLen = AsyncFup_Logo.PostedFile.ContentLength;
            //string imgLogoContentType = AsyncFup_Logo.PostedFile.ContentType;
            //string imgLogoName = AsyncFup_Logo.FileName;
            //Byte[] imgLogoBinaryData = new Byte[imgLogoLen];
            //int ImgLogoStatus = imgLogoStream.Read(imgLogoBinaryData, 0, imgLogoLen);


            //obj_AdminSettings.LogoImage_BinaryData = imgLogoBinaryData;
            //obj_AdminSettings.LogoImage_Name = imgLogoName;
            //obj_AdminSettings.LogoImage_ContentType = imgLogoContentType;


            //--- BANNER IMAGE
            //Stream imgBannerStream = AsyncFup_Banner.PostedFile.InputStream;
            //int imgBannerLen = AsyncFup_Banner.PostedFile.ContentLength;
            //string imgBannerContentType = AsyncFup_Banner.PostedFile.ContentType;
            //string imgBannerName = AsyncFup_Banner.FileName;
            //Byte[] imgBannerBinaryData = new Byte[imgBannerLen];
            //int ImgBannerStatus = imgBannerStream.Read(imgBannerBinaryData, 0, imgBannerLen);


            //obj_AdminSettings.BannerImage_BinaryData = imgBannerBinaryData;
            //obj_AdminSettings.BannerImage_ContentType = imgBannerContentType;
            //obj_AdminSettings.BannerImage_Name = imgBannerName;
        
        int inStatus = objBAL_AdminSettings.Insert_AdminSettings(obj_AdminSettings);

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
            //Response.Redirect("EventsListing.aspx");
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



    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
