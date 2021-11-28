﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;

public partial class Admin_EbAd_SetDesign13 : BasePage
{
    string strSQL = string.Empty;
    String vWelcomePageText = string.Empty;
    String vPhotoURL = string.Empty;
    String vFBpageURL = string.Empty;
    long MaxImageSize = 1024000;   // 1MB
    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();
    CMSv3.BAL.User objUser = new CMSv3.BAL.User();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion       

        ltrSetDefaultTemplate.Text = Resources.LangResources.Set + " " + "Default Template";
        ltrNoteLanguage.Text = "";
        ltrNote.Text = Resources.LangResources.Note;

        if ((Session.SessionID != null) && (Session["UserID"] != null))
            lblSessionValues.Text = Session.SessionID + " | " + Session["UserID"].ToString();

        if (!IsPostBack)
        {
            LoadTemplateInfo();
        }
    }

    protected void LoadTemplateInfo()
    {
        string dbMasterPageNameValue = string.Empty;
        string dbUserDomainType = string.Empty;
        string dbMasterCssName = string.Empty;

        DataSet ds = objUser.EB_WebDesign2_GetSettings(Convert.ToInt32(Session["UserID"].ToString()));

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow Trow = ds.Tables[0].Rows[0];

            dbMasterPageNameValue = Trow["MasterPageName"].ToString();
            dbMasterCssName = Trow["MasterCSS"].ToString();

            vPhotoURL = Trow["PhotoURL"].ToString();
            vFBpageURL = Trow["FBpageURL"].ToString();
            vWelcomePageText = Trow["WelcomePageText"].ToString();

            if (vFBpageURL == "")
                vFBpageURL = "Worlddigitalbiz";

            txtFBpageURL.Text = vFBpageURL;
            txtWelcomePage.Text = vWelcomePageText.Replace("<br/>", Environment.NewLine);  //vWelcomePageText;

            String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();

            if (vPhotoURL != "")
            {
                ImgPhotoGraph1.ImageUrl = tmpImageFolder + vPhotoURL;
            }

            ViewState["PhotoURL"] = vPhotoURL;
        }
        else
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Welcome to my ebook Store. the first in the World to offer the convenience of SMS Purchase on top of PayPal Purchase!!.");
            sb.AppendLine("");
            sb.AppendLine("My Store keeps an extensive collection of eBooks of many genres from Children, Marketing, Beauty, Wellness to Finance etc.,  Browse through our easy navigating eBook catalog and you will be surprised by the number of ebooks available.");
            sb.AppendLine("");
            sb.AppendLine("If you have no idea what to purchase, you may visit the Value Buys, Feature Buys or the Best Sellers sections. Here you will find some of the well read and best value eBooks being offered at a price you can't resist.");

            txtWelcomePage.Text = sb.ToString();

            String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();

            ImgPhotoGraph1.ImageUrl = tmpImageFolder + "executiveCC.png";
            ViewState["PhotoURL"] = "executiveCC.png";
        }


        if (dbMasterPageNameValue == "TmpMasterGen2.master" || dbMasterPageNameValue == "N_Master2.master")
        //--- ********  --- ebook template 1 ------- *********   --     
        {
            if (dbMasterCssName == "BLACK")
            {
                rdoEbD2template_Black.Checked = true;
            }
            else if (dbMasterCssName == "BLUE")
            {
                rdoEbD2template_Blue.Checked = true;
            }

            else if (dbMasterCssName == "GREEN")
            {
                rdoEbD2template_Green.Checked = true;
            }

            else if (dbMasterCssName == "ORANGE")
            {
                rdoEbD2template_Orange.Checked = true;
            }

            else if (dbMasterCssName == "RED")
            {
                rdoEbD2template_Red.Checked = true;
            }
        }
        else
        {
            rdoEbD2template_Red.Checked = true;
        }
    }

    protected void PreValidatePhoto()
    {
        if (!FU_Photo1.HasFile)
        {
            if (ViewState["PhotoURL"].ToString() == "")
            {
                CustomVdr_Photo1.IsValid = false;
                CustomVdr_Photo1.ErrorMessage = "Please Select the PhotoGraph to be Shown on Website.";
                CommonFunctions.AlertMessage("For this Web Design, a Photograph is Compnulsory. Please Upload !!!");
                return;
            }
        }
        else
        {
            if (FU_Photo1.FileBytes.Length > MaxImageSize)
            {
                CustomVdr_Photo1.IsValid = false;
                return;
            }
        }
    }

    protected void CustomVdr_Photo1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //30720 = 15 KB  ( 1024 * 30 )
        if (FU_Photo1.FileBytes.Length > MaxImageSize)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        PreValidatePhoto();

        if (!Page.IsValid)
            return;
        //return; 

        string mSelValue = string.Empty;
        string mCssvalue = string.Empty;

        // ............. Ebook Template 1..........................

        if (rdoEbD2template_Black.Checked == true)
        {
            mSelValue = "N_Master2.master";
            mCssvalue = "BLACK";
        }
        else if (rdoEbD2template_Blue.Checked == true)
        {
            mSelValue = "N_Master2.master";
            mCssvalue = "BLUE";
        }
        else if (rdoEbD2template_Green.Checked == true)
        {
            mSelValue = "N_Master2.master";
            mCssvalue = "GREEN";
        }
        else if (rdoEbD2template_Orange.Checked == true)
        {
            mSelValue = "N_Master2.master";
            mCssvalue = "ORANGE";
        }
        else if (rdoEbD2template_Red.Checked == true)
        {
            mSelValue = "N_Master2.master";
            mCssvalue = "RED";
        }
        else
        {
            mSelValue = "N_Master2.master";
            mCssvalue = "RED";
        }

        //Getting Photograph 1
        Random rnum = new Random();

        bool ImgFileUploaded1 = Getbool();
        string ImgFileName1 = string.Empty;
        string ImgFileUrl1 = string.Empty;

        String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();

        if (FU_Photo1.HasFile)
        {

            if (FU_Photo1.FileBytes.Length < MaxImageSize)
            {
                ImgFileUploaded1 = false;
                //Get the name of the file
                string fileName = FU_Photo1.FileName;

                ImgFileName1 = Convert.ToString(rnum.Next(9999)) + "_" + FU_Photo1.FileName;

                //instead of server.mapPath set the path in web.config file and use that path.
                ImgFileUrl1 = Server.MapPath("~") + tmpImageFolder;

                FU_Photo1.SaveAs(ImgFileUrl1 + ImgFileName1);
                lblUpMessage1.Text = "Image uploaded : " + FU_Photo1.FileName;
                ImgFileUploaded1 = true;
                FU_Photo1.Dispose();
            }
        }
        else
        {
            ImgFileName1 = ViewState["PhotoURL"].ToString();
        }

        vFBpageURL = txtFBpageURL.Text.Trim();
        // vFBpageURL = "https://www.facebook.com/" + vFBpageURL; 
        vWelcomePageText = txtWelcomePage.Text.Trim();
        int upStatus = objUser.EB_WebDesign2_UpdateSettings(vFBpageURL, vWelcomePageText, ImgFileName1, mSelValue, mCssvalue, Convert.ToInt32(Session["UserID"].ToString()));

        if (upStatus > 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Web Template Changed Successfully. The Changes would be visible on your next visit to the web page.";
            lblErrMessage.CssClass = "font_12Msg_Success";
            CommonFunctions.AlertMessage("Web Template Updated successfully.");
            LoadTemplateInfo();
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

    private static bool Getbool()
    {
        return false;
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {

    }
}
