using System;
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


public partial class Admin_EbAd_SetDesign15 : BasePage
{
    string strSQL = string.Empty;
    String vWelcomePageText = string.Empty;
    String vPhotoURL = string.Empty;
    String vFBpageURL = string.Empty;
    //long MaxImageSize = 1024000;   // 1MB

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

        #region Code to Hide Left ContentHolder

        //HtmlGenericControl myDivLeftBar;
        //myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

        //myDivLeftBar.Style.Clear();
        //myDivLeftBar.Style.Value = "width:0px;";


        //HtmlGenericControl myDivRightBar;
        //myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

        //myDivRightBar.Style.Clear();
        //myDivRightBar.Style.Value = " width: 96%; padding-left:20px;";

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

        String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();

        //DataSet ds = objUser.EB_WebDesign2_GetSettings(Convert.ToInt32(Session["UserID"].ToString()));
        newDBS nds = new newDBS();
        DataSet ds = nds.WebDesign15_GetSettings(Convert.ToInt32(Session["UserID"].ToString()));

        DataSet dsH = nds.design_homePageProducts(Convert.ToInt32(Session["UserID"].ToString()), 11);
        DataTable dsHSettings = dsH.Tables[0];
        if (dsHSettings.Rows.Count > 0)
        {
            DataRow dr = dsHSettings.Rows[0];
            //rdoADM_FeatureBuy.SelectedValue = dr["FeatureBuy"].ToString();
            //rdoADM_BestSeller.SelectedValue = dr["BestSeller"].ToString();
            //rdoADM_NewReleases.SelectedValue = dr["NewReleases"].ToString();
            //rdoADM_ValueBuy.SelectedValue = dr["ValueBuy"].ToString();
            //rdoADM_Free.SelectedValue = dr["Free"].ToString();
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow Trow = ds.Tables[0].Rows[0];

            ////dbMasterPageNameValue = Trow["MasterPageName"].ToString();
            dbMasterCssName = Trow["MasterCSS"].ToString();

            //string vPicture11 = Trow["Picture1"].ToString();
            //if (vPicture11 == "")
            //{
            //    vPicture11 = "../assets/images/homesliders/slide1.jpg";
            //    ViewState["Picture11"] = "";
            //}
            //else
            //{
            //    ViewState["Picture11"] = vPicture11.ToString();
            //    vPicture11 = tmpImageFolder + vPicture11;
            //}
            ////ImgPhotoGraph1.ImageUrl = vPicture11.ToString();

            //string vPicture12 = Trow["Picture2"].ToString();
            //if (vPicture12 == "")
            //{
            //    vPicture12 = "../assets/images/homesliders/slide2.jpg";
            //    ViewState["Picture12"] = "";
            //}
            //else
            //{
            //    ViewState["Picture12"] = vPicture12.ToString();
            //    vPicture12 = tmpImageFolder + vPicture12;
            //}
            ////ImgPhotoGraph2.ImageUrl = vPicture12.ToString();

            //string vPicture13 = Trow["Picture3"].ToString();
            //if (vPicture13 == "")
            //{
            //    vPicture13 = "../assets/images/homesliders/slide3.jpg";
            //    ViewState["Picture13"] = "";
            //}
            //else
            //{
            //    ViewState["Picture13"] = vPicture13.ToString();
            //    vPicture13 = tmpImageFolder + vPicture13;
            //}
            ////ImgPhotoGraph3.ImageUrl = vPicture13.ToString();

            //string vPicture14 = Trow["Picture4"].ToString();
            //if (vPicture14 == "")
            //{
            //    vPicture14 = "../assets/images/banners/banner1.jpg";
            //    ViewState["Picture14"] = "";
            //}
            //else
            //{
            //    ViewState["Picture14"] = vPicture14.ToString();
            //    vPicture14 = tmpImageFolder + vPicture14;
            //}
            ////ImgPhotoGraph4.ImageUrl = vPicture14.ToString();

            //string vPicture15 = Trow["Picture5"].ToString();
            //if (vPicture15 == "")
            //{
            //    vPicture15 = "../assets/images/banners/banner2.jpg";
            //    ViewState["Picture15"] = "";
            //}
            //else
            //{
            //    ViewState["Picture15"] = vPicture15.ToString();
            //    vPicture15 = tmpImageFolder + vPicture15;
            //}
            ////ImgPhotoGraph5.ImageUrl = vPicture15.ToString();

            //ViewState["ECode1"] = string.Empty;
            //ViewState["ECode2"] = string.Empty;
            //ViewState["ECode3"] = string.Empty;
            //ViewState["ECode4"] = string.Empty;
            //ViewState["ECode5"] = string.Empty;

            //if (Trow["ECode1"].ToString().Trim() != "") { ViewState["ECode1"] = Trow["ECode1"].ToString(); }
            //if (Trow["ECode2"].ToString().Trim() != "") { ViewState["ECode2"] = Trow["ECode2"].ToString(); }
            //if (Trow["ECode3"].ToString().Trim() != "") { ViewState["ECode3"] = Trow["ECode3"].ToString(); }
            //if (Trow["ECode4"].ToString().Trim() != "") { ViewState["ECode4"] = Trow["ECode4"].ToString(); }
            //if (Trow["ECode5"].ToString().Trim() != "") { ViewState["ECode5"] = Trow["ECode5"].ToString(); }

            ////txtCode1.Text = ViewState["ECode1"].ToString();
            ////txtCode2.Text = ViewState["ECode2"].ToString();
            ////txtCode3.Text = ViewState["ECode3"].ToString();
            ////txtCode4.Text = ViewState["ECode4"].ToString();
            ////txtCode5.Text = ViewState["ECode5"].ToString();

        }
        else
        {
        }

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


    protected void PreValidatePhoto()
    {
    }

    protected void CustomVdr_Photo1_ServerValidate(object source, ServerValidateEventArgs args)
    {
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
            mCssvalue = "BLACK";
        }
        else if (rdoEbD2template_Blue.Checked == true)
        {
            mCssvalue = "BLUE";
        }
        else if (rdoEbD2template_Green.Checked == true)
        {
            mCssvalue = "GREEN";
        }
        else if (rdoEbD2template_Orange.Checked == true)
        {
            mCssvalue = "ORANGE";
        }
        else if (rdoEbD2template_Red.Checked == true)
        {
            mCssvalue = "RED";
        }
        else
        {
            mCssvalue = "RED";
        }

        //Getting Photograph 1
        Random rnum = new Random();

        //bool ImgFileUploaded1 = false;
        string ImgFileName1 = string.Empty;
        string ImgFileUrl1 = string.Empty;
        string ImgFileName2 = string.Empty;
        string ImgFileName3 = string.Empty;
        string ImgFileName4 = string.Empty;
        string ImgFileName5 = string.Empty;

        String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();

        //if (Picture11.HasFile)
        //{
        //    //Get the name of the file
        //    string fileName = Picture11.FileName;
        //    ImgFileName1 = Convert.ToString(rnum.Next(9999)) + "_" + Picture11.FileName;
        //    //instead of server.mapPath set the path in web.config file and use that path.
        //    ImgFileUrl1 = Server.MapPath("~") + tmpImageFolder;
        //    Picture11.SaveAs(ImgFileUrl1 + ImgFileName1);
        //    //lblUpMessage1.Text = "Image uploaded : " + FU_Photo1.FileName;
        //    ImgFileUploaded1 = true;
        //    Picture11.Dispose();
        //}
        //else
        //{
        //    ImgFileName1 = ViewState["Picture11"].ToString();
        //}

        //if (Picture12.HasFile)
        //{
        //    //Get the name of the file
        //    string fileName = Picture12.FileName;
        //    ImgFileName2 = Convert.ToString(rnum.Next(9999)) + "_" + Picture12.FileName;
        //    //instead of server.mapPath set the path in web.config file and use that path.
        //    ImgFileUrl1 = Server.MapPath("~") + tmpImageFolder;
        //    Picture11.SaveAs(ImgFileUrl1 + ImgFileName2);
        //    //lblUpMessage1.Text = "Image uploaded : " + FU_Photo1.FileName;
        //    ImgFileUploaded1 = true;
        //    Picture12.Dispose();
        //}
        //else
        //{
        //    ImgFileName2 = ViewState["Picture12"].ToString();
        //}

        //if (Picture13.HasFile)
        //{
        //    //Get the name of the file
        //    string fileName = Picture13.FileName;
        //    ImgFileName3 = Convert.ToString(rnum.Next(9999)) + "_" + Picture13.FileName;
        //    //instead of server.mapPath set the path in web.config file and use that path.
        //    ImgFileUrl1 = Server.MapPath("~") + tmpImageFolder;
        //    Picture13.SaveAs(ImgFileUrl1 + ImgFileName3);
        //    //lblUpMessage1.Text = "Image uploaded : " + FU_Photo1.FileName;
        //    ImgFileUploaded1 = true;
        //    Picture13.Dispose();
        //}
        //else
        //{
        //    ImgFileName3 = ViewState["Picture13"].ToString();
        //}

        //if (Picture14.HasFile)
        //{
        //    //Get the name of the file
        //    string fileName = Picture14.FileName;
        //    ImgFileName4 = Convert.ToString(rnum.Next(9999)) + "_" + Picture14.FileName;
        //    //instead of server.mapPath set the path in web.config file and use that path.
        //    ImgFileUrl1 = Server.MapPath("~") + tmpImageFolder;
        //    Picture14.SaveAs(ImgFileUrl1 + ImgFileName4);
        //    //lblUpMessage1.Text = "Image uploaded : " + FU_Photo1.FileName;
        //    ImgFileUploaded1 = true;
        //    Picture14.Dispose();
        //}
        //else
        //{
        //    ImgFileName4 = ViewState["Picture14"].ToString();
        //}

        //if (Picture15.HasFile)
        //{
        //    //Get the name of the file
        //    string fileName = Picture15.FileName;
        //    ImgFileName5 = Convert.ToString(rnum.Next(9999)) + "_" + Picture15.FileName;
        //    //instead of server.mapPath set the path in web.config file and use that path.
        //    ImgFileUrl1 = Server.MapPath("~") + tmpImageFolder;
        //    Picture15.SaveAs(ImgFileUrl1 + ImgFileName5);
        //    //lblUpMessage1.Text = "Image uploaded : " + FU_Photo1.FileName;
        //    ImgFileUploaded1 = true;
        //    Picture15.Dispose();
        //}
        //else
        //{
        //    ImgFileName5 = ViewState["Picture15"].ToString();
        //}

        //String vECode1 = txtCode1.Text.ToString();
        //String vECode2 = txtCode2.Text.ToString();
        //String vECode3 = txtCode3.Text.ToString();
        //String vECode4 = txtCode4.Text.ToString();
        //String vECode5 = txtCode5.Text.ToString();

        newDBS nds = new newDBS();
        int upStatus = nds.WebDesign15_UpdateSettings(mCssvalue, Convert.ToInt32(Session["UserID"].ToString()));
        //int upStatus = nds.WebDesign11_UpdateSettings(mCssvalue, Convert.ToInt32(Session["UserID"].ToString()), ImgFileName1.ToString(), ImgFileName2.ToString(), ImgFileName3.ToString(), ImgFileName4.ToString(), ImgFileName5.ToString(), vECode1.ToString(), vECode2.ToString(), vECode3.ToString(), vECode4.ToString(), vECode5.ToString());

        //strSQL = "Update [tblUserMasterPage] set MasterPageName = '" + mSelValue + "', MasterCSS = '" +
        //         mCssvalue + "'where UserID = " + Convert.ToInt32(Session["UserID"]);
        //dbCmd = new SqlCommand(strSQL, dbConn);
        //int upStatus = dbCmd.ExecuteNonQuery();

        //Session["MasterPageFile"] = mSelValue;
        //Session["MasterPageCss"] = mCssvalue;



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


    //protected void BtnSaveAdminShowHide_Click(object sender, EventArgs e)
    //{
    //    int vUserID = Convert.ToInt32(Session["UserID"].ToString());
    //    int tmpADM_FeatureBuy = Convert.ToInt16(rdoADM_FeatureBuy.SelectedValue);
    //    int tmpADM_BestSeller = Convert.ToInt16(rdoADM_BestSeller.SelectedValue);
    //    int tmpADM_NewReleases = Convert.ToInt16(rdoADM_NewReleases.SelectedValue);
    //    int tmpADM_ValueBuy = Convert.ToInt16(rdoADM_ValueBuy.SelectedValue);
    //    int tmpADM_Free = Convert.ToInt16(rdoADM_Free.SelectedValue);

    //    newDBS nds = new newDBS();
    //    nds.design_homePageProducts_update(Convert.ToInt32(Session["UserID"].ToString()), 11, tmpADM_FeatureBuy.ToString(), tmpADM_BestSeller.ToString(), tmpADM_NewReleases.ToString(), tmpADM_ValueBuy.ToString(), tmpADM_Free.ToString());

    //    CommonFunctions.AlertMessage("Home Page Product Settings successfully saved.");
    //    return;

    //}

    protected void BtnCancel_Click(object sender, EventArgs e)
    {

    }
}
