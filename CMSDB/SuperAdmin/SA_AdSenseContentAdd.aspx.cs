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


public partial class SA_AdSenseContentAdd : System.Web.UI.Page
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //SqlDataAdapter dbAdap;
    DataSet ds;
    DataTable dt;
    string strSQL = string.Empty;
    //int qLgType = 1;
    int qAdSense4UserID = 0;
    //int qAdSenseID = 1; 
    string FormMode = string.Empty;
    //FormViewMode tmpFormMode;

    string qMobileLoginID = string.Empty;
    string qFullName = string.Empty;


    CMSv3.BAL.gAdSense objBAL_AdSense = new CMSv3.BAL.gAdSense(); 

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        if (Request.QueryString["Ads4UID"].ToString() != null)
        {
            if (Request.QueryString["Ads4UID"].ToString() != "")
                qAdSense4UserID = Convert.ToInt32(Request.QueryString["Ads4UID"].ToString());
        }

        if (Request.QueryString["qMobileLoginID"].ToString() != null)
        {
            if (Request.QueryString["qMobileLoginID"].ToString() != "")
                qMobileLoginID = Request.QueryString["qMobileLoginID"].ToString();        }

        if (Request.QueryString["qFullName"].ToString() != null)
        {
            if (Request.QueryString["qFullName"].ToString() != "")
                qFullName = Request.QueryString["qFullName"].ToString(); 
        }

        if (!IsPostBack)
        {
            if (qAdSense4UserID == 0)
            {
                CommonFunctions.AlertMessage("Please select the User for whom you would like to Enter AdSense Code");
                Response.Redirect("SA_AdsUserListing.aspx"); 
            }
            ViewState["defAdsID"] = qAdSense4UserID;

            ViewState["qMobileLoginID"] = qMobileLoginID;
            ViewState["qFullName"] = qFullName;
           

            LoadAdSenseContent(Convert.ToInt32(ViewState["defAdsID"].ToString())); 
            
        }


    }


    protected void RenderInsertButton()
    {
        FvAdSenseCode.ChangeMode(FormViewMode.Insert);
    
    }





    protected void LoadAdSenseContent(int AdsUserID)
    {

        //ViewState["qMobileLoginID"] = qMobileLoginID;
        //ViewState["qFullName"] = qFullName;

        
            ds = objBAL_AdSense.Retrieve_AdSenseContent(AdsUserID,""); 

            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                FvAdSenseCode.DataSource = dt;
                FvAdSenseCode.DataBind();
            }
            else
            {
                FvAdSenseCode.ChangeMode(FormViewMode.Insert);
            }


          

    }

    protected void FvAdSenseCode_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FvAdSenseCode.ChangeMode(e.NewMode);
        LoadAdSenseContent(Convert.ToInt32(ViewState["defAdsID"].ToString())); 
    }




    protected void FvAdSenseCode_DataBound(object sender, EventArgs e)
    {
        FormViewRow fRow = (FormViewRow)FvAdSenseCode.Row;
        string tmpContent = string.Empty;
        string mLanguage = string.Empty;


        TextBox objtxtMobileLoginID = (TextBox)fRow.FindControl("txtMobileNo");
        if (objtxtMobileLoginID != null)
            objtxtMobileLoginID.Text = ViewState["qMobileLoginID"].ToString(); 


        TextBox objtxtFullName = (TextBox)fRow.FindControl("txtFullName");
        if (objtxtFullName != null)
            objtxtFullName.Text = ViewState["qFullName"].ToString(); 


             //ViewState["qMobileLoginID"] = qMobileLoginID;
        //ViewState["qFullName"] = qFullName;

        

        if ((FvAdSenseCode.CurrentMode == FormViewMode.Insert) || (FvAdSenseCode.CurrentMode == FormViewMode.Edit))
        {
            //FCKeditor obkFckEditor = (FCKeditor)fRow.FindControl("FCKEditor1");
            //obkFckEditor.BasePath = "~/OtherUtils/fckeditor/";
            //obkFckEditor.ImageBrowserURL = "~/Images/";
            //obkFckEditor.AutoDetectLanguage = true;
            //obkFckEditor.Width = 1024;
            //obkFckEditor.Height = 512;

           
        }

        //if (FvAdSenseCode.CurrentMode == FormViewMode.Insert)
        //{
        //    Label objLblButtonNo = (Label)fRow.FindControl("lblButtonNo");

        //    DropDownList objDDLcategory = (DropDownList)fRow.FindControl("ddlCategory");
        //    if (objDDLcategory != null)
        //        LoadCategories(objDDLcategory); 

        //}

        if (FvAdSenseCode.CurrentMode == FormViewMode.Edit)
        {
            //DropDownList objDDLcategory = (DropDownList)fRow.FindControl("ddlCategory");
            //if (objDDLcategory != null)
            //    LoadCategories(objDDLcategory); 
            
        }


        
      

        if (FvAdSenseCode.CurrentMode == FormViewMode.ReadOnly)
        {
            

        }

                
    }
    protected void FvAdSenseCode_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {


        TextBox objtxtAdsLoginID = (TextBox)FvAdSenseCode.Row.FindControl("txtAdsLoginID");
        TextBox objtxtAdsPassword = (TextBox)FvAdSenseCode.Row.FindControl("txtAdsPassword");
        TextBox objtxtAdsCode = (TextBox)FvAdSenseCode.Row.FindControl("txtAdCode");


       // bool upStatus = objBAL_OwnButton.Update_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, qMenuButtonNo);
      //  int upStatus = objBAL_OwnButton.Insert_DefWebButtonBySA(SelButtonNo, objtxtButtonName.Text.Trim(), TA_Editor.Value, Convert.ToInt32(HdAnchorDomainId.Value),1);

        int upStatus = objBAL_AdSense.InsertUpdate_AdSenseContent(objtxtAdsLoginID.Text, objtxtAdsPassword.Text, objtxtAdsCode.Text, Convert.ToInt32(ViewState["defAdsID"].ToString())); 

        FvAdSenseCode.ChangeMode(FormViewMode.ReadOnly);
        LoadAdSenseContent(Convert.ToInt32(ViewState["defAdsID"].ToString())); 
    }


    protected void FvAdSenseCode_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (Page.IsValid)
        {


            TextBox objtxtAdsLoginID = (TextBox)FvAdSenseCode.Row.FindControl("txtAdsLoginID");
            TextBox objtxtAdsPassword = (TextBox)FvAdSenseCode.Row.FindControl("txtAdsPassword");
            TextBox objtxtAdsCode = (TextBox)FvAdSenseCode.Row.FindControl("txtAdCode");
            
            

            //int status = objBAL_OwnButton.Insert_OwnButtonData(objtxtButtonName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, MenuButtonNo);
            int inStatus = objBAL_AdSense.InsertUpdate_AdSenseContent(objtxtAdsLoginID.Text, objtxtAdsPassword.Text, objtxtAdsCode.Text, Convert.ToInt32(ViewState["defAdsID"].ToString())); 

            FvAdSenseCode.ChangeMode(FormViewMode.ReadOnly);
            LoadAdSenseContent(Convert.ToInt32(ViewState["defAdsID"].ToString()));
        }
    }



    protected void btnBackToListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("SA_AdsUserListing.aspx"); 
    }

  

    protected void CustomVdr_Button_ServerValidate(object source, ServerValidateEventArgs args)
    {
        RadioButton objRdoButton1 = (RadioButton)FvAdSenseCode.Row.FindControl("rdoButton1");
        RadioButton objRdoButton2 = (RadioButton)FvAdSenseCode.Row.FindControl("rdoButton2");
        RadioButton objRdoButton3 = (RadioButton)FvAdSenseCode.Row.FindControl("rdoButton3");

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
