using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using FredCK.FCKeditorV2;


public partial class SA_EMS_DPEEmailSetup : System.Web.UI.Page
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //SqlDataAdapter dbAdap;
    DataSet ds;
    DataTable dt;
    string strSQL = string.Empty;
    //int qLgType = 1;
    //int qAdSense4UserID = 0;
    //int qAdSenseID = 1; 
    string FormMode = string.Empty;
    //FormViewMode tmpFormMode;

    string qMobileLoginID = string.Empty;
    string qFullName = string.Empty;

    
    //CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User(); 
    //CMSv3.BAL.GemailSystem objBAL_Gems = new CMSv3.BAL.GemailSystem();
    //CMSv3.BAL.MalaysiaSMS objBAL_MASuser = new CMSv3.BAL.MalaysiaSMS();

    //CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook(); 

    CMSv3.BAL.DPE objDPE = new CMSv3.BAL.DPE();  



    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 
        
  
        if (Request.QueryString["qMobileLoginID"].ToString() != null)
        {
            if (Request.QueryString["qMobileLoginID"].ToString() != "")
                qMobileLoginID = Request.QueryString["qMobileLoginID"].ToString();        }

        //if (Request.QueryString["qFullName"] != null)
        //{
        //    if (Request.QueryString["qFullName"].ToString() != "")
        //        qFullName = Request.QueryString["qFullName"].ToString(); 
        //}



        if (!IsPostBack)
        {
            if (qMobileLoginID == "")
            {
                CommonFunctions.AlertMessage("Please select the User for whom you would like to Enter Email Deatils");
                Response.Redirect("SA_EMS_DPEListing.aspx"); 
            }

            ViewState["qMobileLoginID"] = qMobileLoginID;
           // ViewState["qFullName"] = qFullName;

            //String vSearchStr = " and MobileloginID = '" + qMobileLoginID + "'";
            //ViewState["vSearchStr"] = vSearchStr;

            String vSearchStr = string.Empty; 
            ViewState["vSearchStr"] = "";
            ViewState["vSubDomain"] = "";
            ViewState["vOwnDomain"] = "";
            ViewState["vMemberName"] = ""; 


         
            LoadEMSContent(qMobileLoginID, vSearchStr);

        }


    }


    protected void RenderInsertButton()
    {
        FvEMS.ChangeMode(FormViewMode.Insert);
    
    }



    protected void LoadEMSContent(string qMobileLoginID, string vSearchStr)
    {

        string SearchStr = " AND TopUpMobile = '" + qMobileLoginID + "'";


        //ds = objEbook.Retrieve_EMSContent(qMobileLoginID, vSearchStr);

        ds = ds = objDPE.DPE_GetUserForEMS(SearchStr); 

            //ds = objBAL_Gems.Retrieve_EMSContent(vSearchStr); 

            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                FvEMS.DataSource = dt;
                FvEMS.DataBind();
            }
            else
            {
                FvEMS.ChangeMode(FormViewMode.Insert);
            }


          

    }

    protected void FvEMS_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FvEMS.ChangeMode(e.NewMode);
        LoadEMSContent(ViewState["qMobileLoginID"] .ToString(), ViewState["vSearchStr"].ToString()); 
    }




    protected void FvEMS_DataBound(object sender, EventArgs e)
    {
        FormViewRow fRow = (FormViewRow)FvEMS.Row;
        string tmpContent = string.Empty;
        string mLanguage = string.Empty;


        //TextBox objtxtMobileLoginID = (TextBox)fRow.FindControl("txtMobileNo");
        //if (objtxtMobileLoginID != null)
        //    objtxtMobileLoginID.Text = ViewState["qMobileLoginID"].ToString(); 


        //TextBox objtxtFullName = (TextBox)fRow.FindControl("txtFullName");
        //if (objtxtFullName != null)
        //    objtxtFullName.Text = ViewState["vMemberName"].ToString();

        //TextBox objtxtSubDomain = (TextBox)fRow.FindControl("txtSubDomain");
        //if (objtxtSubDomain != null)
        //    objtxtSubDomain.Text = ViewState["vSubDomain"].ToString();

        //TextBox ObjtxtOwnDomain = (TextBox)fRow.FindControl("txtOwnDomain");
        //if (ObjtxtOwnDomain != null)
        //    ObjtxtOwnDomain.Text = ViewState["vOwnDomain"].ToString(); 



             //ViewState["qMobileLoginID"] = qMobileLoginID;
        //ViewState["qFullName"] = qFullName;

        

        if ((FvEMS.CurrentMode == FormViewMode.Insert) || (FvEMS.CurrentMode == FormViewMode.Edit))
        {
            //FCKeditor obkFckEditor = (FCKeditor)fRow.FindControl("FCKEditor1");
            //obkFckEditor.BasePath = "~/OtherUtils/fckeditor/";
            //obkFckEditor.ImageBrowserURL = "~/Images/";
            //obkFckEditor.AutoDetectLanguage = true;
            //obkFckEditor.Width = 1024;
            //obkFckEditor.Height = 512;

           
        }

        //if (FvEMS.CurrentMode == FormViewMode.Insert)
        //{
        //    Label objLblButtonNo = (Label)fRow.FindControl("lblButtonNo");

        //    DropDownList objDDLcategory = (DropDownList)fRow.FindControl("ddlCategory");
        //    if (objDDLcategory != null)
        //        LoadCategories(objDDLcategory); 

        //}

        if (FvEMS.CurrentMode == FormViewMode.Edit)
        {
            //DropDownList objDDLcategory = (DropDownList)fRow.FindControl("ddlCategory");
            //if (objDDLcategory != null)
            //    LoadCategories(objDDLcategory); 
            
        }


        
      

        if (FvEMS.CurrentMode == FormViewMode.ReadOnly)
        {
            
            
        }

                
    }
    protected void FvEMS_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {


        TextBox objtxtAdmLoginID = (TextBox)FvEMS.Row.FindControl("txtAdmLoginID");
        TextBox objtxtAdmPassword = (TextBox)FvEMS.Row.FindControl("txtAdmPassword");

        TextBox objtxtEnquiryID = (TextBox)FvEMS.Row.FindControl("txtEnqLoginID");
        TextBox objtxtEnquiryPwd = (TextBox)FvEMS.Row.FindControl("txtEnqPassword");

        TextBox objtxttxtHttpURLlink = (TextBox)FvEMS.Row.FindControl("txtHttpURLlink");


       // bool upStatus = objBAL_OwnButton.Update_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, qMenuButtonNo);
      //  int upStatus = objBAL_OwnButton.Insert_DefWebButtonBySA(SelButtonNo, objtxtButtonName.Text.Trim(), TA_Editor.Value, Convert.ToInt32(HdAnchorDomainId.Value),1);
        
        int upStatus = objDPE.DPE_InsertUpdate_EMSContent(objtxtAdmLoginID.Text, objtxtAdmPassword.Text, objtxtEnquiryID.Text, objtxtEnquiryPwd.Text, objtxttxtHttpURLlink.Text, Convert.ToInt64(ViewState["qMobileLoginID"].ToString())); 
        //int upStatus = objBAL_AdSense.InsertUpdate_AdSenseContent(objtxtAdsLoginID.Text, objtxtAdsPassword.Text, objtxtAdsCode.Text, Convert.ToInt32(ViewState["defAdsID"].ToString())); 

        FvEMS.ChangeMode(FormViewMode.ReadOnly);
        LoadEMSContent(ViewState["qMobileLoginID"].ToString(), ViewState["vSearchStr"].ToString()); 
    }


    protected void FvEMS_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (Page.IsValid)
        {


            TextBox objtxtAdmLoginID = (TextBox)FvEMS.Row.FindControl("txtAdmLoginID");
            TextBox objtxtAdmPassword = (TextBox)FvEMS.Row.FindControl("txtAdmPassword");

            TextBox objtxtEnquiryID = (TextBox)FvEMS.Row.FindControl("txtEnqLoginID");
            TextBox objtxtEnquiryPwd = (TextBox)FvEMS.Row.FindControl("txtEnqPassword");

            TextBox objtxttxtHttpURLlink = (TextBox)FvEMS.Row.FindControl("txtHttpURLlink");
            
            

            //int status = objBAL_OwnButton.Insert_OwnButtonData(objtxtButtonName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, MenuButtonNo);
            int upStatus = objDPE.DPE_InsertUpdate_EMSContent(objtxtAdmLoginID.Text, objtxtAdmPassword.Text, objtxtEnquiryID.Text, objtxtEnquiryPwd.Text, objtxttxtHttpURLlink.Text, Convert.ToInt64(ViewState["qMobileLoginID"].ToString()));

            //if (upStatus == 1)
            //{
            //    //Update the MLMSMS to notify that the EMS has been created for this mobileLoginID

            //    int MasUpstatus = objBAL_MASuser.Update_EMS_Creation(Convert.ToInt64(ViewState["qMobileLoginID"].ToString()));

            //}
            FvEMS.ChangeMode(FormViewMode.ReadOnly);
            LoadEMSContent(ViewState["qMobileLoginID"].ToString(), ViewState["vSearchStr"].ToString()); 
        }
    }



    protected void btnBackToListing_Click(object sender, EventArgs e)
    {

            Response.Redirect("SA_EMS_DPeListing.aspx"); 
    }

  

    protected void CustomVdr_Button_ServerValidate(object source, ServerValidateEventArgs args)
    {
        RadioButton objRdoButton1 = (RadioButton)FvEMS.Row.FindControl("rdoButton1");
        RadioButton objRdoButton2 = (RadioButton)FvEMS.Row.FindControl("rdoButton2");
        RadioButton objRdoButton3 = (RadioButton)FvEMS.Row.FindControl("rdoButton3");

        if((objRdoButton1.Checked) || (objRdoButton2.Checked) || (objRdoButton3.Checked))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }


}
