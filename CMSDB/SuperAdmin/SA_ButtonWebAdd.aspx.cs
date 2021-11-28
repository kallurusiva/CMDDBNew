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


public partial class SA_ButtonWebAdd : System.Web.UI.Page
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //SqlDataAdapter dbAdap;
    DataSet ds;
    DataTable dt;
    string strSQL = string.Empty;
    //int qLgType = 1;
    int qMenuButtonNo = 0;
    int qAnchorDomainID = 0; 
    string FormMode = string.Empty;
    //FormViewMode tmpFormMode; 


    CMSv3.BAL.OwnButton objBAL_OwnButton = new CMSv3.BAL.OwnButton();


    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        if (Request.QueryString["btID"] != null)
        {
            if (Request.QueryString["btID"].ToString() != "")
            qMenuButtonNo = Convert.ToInt32(Request.QueryString["btID"].ToString());
        }

        if (Request.QueryString["Aid"] != null)
        {
            if (Request.QueryString["Aid"].ToString() != "")
            qAnchorDomainID = Convert.ToInt32(Request.QueryString["Aid"].ToString());
        }

        if (!IsPostBack)
        {
            ViewState["defButtonNo"] = qMenuButtonNo;
            ViewState["defAnchorDomainID"] = qAnchorDomainID;

            LoadButtonContent(Convert.ToInt32(ViewState["defButtonNo"].ToString()), Convert.ToInt32(ViewState["defAnchorDomainID"].ToString())); 
            
        }


    }


    protected void RenderInsertButton()
    {
        FvOwnPage.ChangeMode(FormViewMode.Insert);



    }


    protected void LoadCategories(DropDownList ddlCat)
    {
        DataSet dsCat;
        DataView dvCat;

        CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();

        dsCat = objBAL_Domains.Retrieve_AnchorDomains(""); 
        dvCat = dsCat.Tables[0].DefaultView;

        ddlCat.DataSource = dsCat;
        ddlCat.DataTextField = "AnchorDomain";
        ddlCat.DataValueField = "TID";
        ddlCat.DataBind();

        ddlCat.Items.Insert(0, new ListItem("Select AnchorDomain", "0"));
        
    
    }


    protected void LoadButtonContent(int vButtonNo, int vAnchorDomainID)
    {

        if (vButtonNo == 0)
        {
            FvOwnPage.ChangeMode(FormViewMode.Insert);
        }
        else
        {
            ds = objBAL_OwnButton.Retrieve_DefWebButtonInfoBYSA(vButtonNo, vAnchorDomainID,1);

            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                FvOwnPage.DataSource = dt;
                FvOwnPage.DataBind();
            }
            else
            {
                FvOwnPage.ChangeMode(FormViewMode.Insert);
            }


        }       

    }

    protected void FvOwnPage_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FvOwnPage.ChangeMode(e.NewMode);
        LoadButtonContent(Convert.ToInt32(ViewState["defButtonNo"].ToString()), Convert.ToInt32(ViewState["defAnchorDomainID"].ToString())); 
    }




    protected void FvOwnPage_DataBound(object sender, EventArgs e)
    {
        FormViewRow fRow = (FormViewRow)FvOwnPage.Row;
        string tmpContent = string.Empty;
        string mLanguage = string.Empty;

        

 
        

        if ((FvOwnPage.CurrentMode == FormViewMode.Insert) || (FvOwnPage.CurrentMode == FormViewMode.Edit))
        {
            //FCKeditor obkFckEditor = (FCKeditor)fRow.FindControl("FCKEditor1");
            //obkFckEditor.BasePath = "~/OtherUtils/fckeditor/";
            //obkFckEditor.ImageBrowserURL = "~/Images/";
            //obkFckEditor.AutoDetectLanguage = true;
            //obkFckEditor.Width = 1024;
            //obkFckEditor.Height = 512;

           
        }

        if (FvOwnPage.CurrentMode == FormViewMode.Insert)
        {
            Label objLblButtonNo = (Label)fRow.FindControl("lblButtonNo");

            DropDownList objDDLcategory = (DropDownList)fRow.FindControl("ddlCategory");
            if (objDDLcategory != null)
                LoadCategories(objDDLcategory); 

        }

        if (FvOwnPage.CurrentMode == FormViewMode.Edit)
        {
            //DropDownList objDDLcategory = (DropDownList)fRow.FindControl("ddlCategory");
            //if (objDDLcategory != null)
            //    LoadCategories(objDDLcategory); 
            
        }


        
      

        if (FvOwnPage.CurrentMode == FormViewMode.ReadOnly)
        {
            

        }

                
    }
    protected void FvOwnPage_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {


        TextBox objtxtButtonName = (TextBox)FvOwnPage.Row.FindControl("txtButtonName");

        Label objLblButtonNo = (Label)FvOwnPage.Row.FindControl("lblEditButtonNo");
        HiddenField HdAnchorDomainId = (HiddenField)FvOwnPage.Row.FindControl("HdEditAnchorDomainID");

        int SelButtonNo = 0;

        if (objLblButtonNo != null)
            SelButtonNo = Convert.ToInt32(objLblButtonNo.Text);

        

        //FCKeditor obkFckEditor = (FCKeditor)FvOwnPage.Row.FindControl("FCKEditor1");
        HtmlTextArea TA_Editor = (HtmlTextArea)FvOwnPage.Row.FindControl("myEditor");



       // bool upStatus = objBAL_OwnButton.Update_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, qMenuButtonNo);
        int upStatus = objBAL_OwnButton.Insert_DefWebButtonBySA(SelButtonNo, objtxtButtonName.Text.Trim(), TA_Editor.Value, Convert.ToInt32(HdAnchorDomainId.Value),1);
            

        FvOwnPage.ChangeMode(FormViewMode.ReadOnly);
        LoadButtonContent(Convert.ToInt32(ViewState["defButtonNo"].ToString()), Convert.ToInt32(ViewState["defAnchorDomainID"].ToString())); 
    }


    protected void FvOwnPage_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (Page.IsValid)
        {

            DropDownList objddlCategory = (DropDownList)FvOwnPage.Row.FindControl("ddlCategory");

            RadioButton objRdoButton1 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton1");
            RadioButton objRdoButton2 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton2");
            RadioButton objRdoButton3 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton3");

            int SelButtonNo = 0;

            if (objRdoButton1.Checked)
                SelButtonNo = 1;
            else if (objRdoButton2.Checked)
                SelButtonNo = 2;
            else if (objRdoButton3.Checked)
                SelButtonNo = 3;


            TextBox objtxtButtonName = (TextBox)FvOwnPage.Row.FindControl("txtButtonName");

            HtmlTextArea TA_Editor = (HtmlTextArea)FvOwnPage.Row.FindControl("myEditor");

            //int status = objBAL_OwnButton.Insert_OwnButtonData(objtxtButtonName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, MenuButtonNo);
            int inStatus = objBAL_OwnButton.Insert_DefWebButtonBySA(SelButtonNo, objtxtButtonName.Text.Trim(), TA_Editor.Value, Convert.ToInt32(objddlCategory.SelectedValue),1);

            ViewState["defButtonNo"] = SelButtonNo;
            ViewState["defAnchorDomainID"] = objddlCategory.SelectedValue;
            FvOwnPage.ChangeMode(FormViewMode.ReadOnly);
            LoadButtonContent(Convert.ToInt32(ViewState["defButtonNo"].ToString()), Convert.ToInt32(ViewState["defAnchorDomainID"].ToString()));
        }
    }



    protected void btnBackToListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("SA_ButtonWebListing.aspx"); 
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList objddlCategory = (DropDownList)FvOwnPage.Row.FindControl("ddlCategory");

        int selAchorDomainID = Convert.ToInt32(objddlCategory.SelectedValue);

        CheckAndRenderPage(selAchorDomainID); 


    }


    protected void CheckAndRenderPage(int vAnchorDomainId)
    {

        ds = objBAL_OwnButton.Retrieve_DefWebButtonsByAnchorDomainID(vAnchorDomainId,1); 

        DataTable dt = ds.Tables[0];


        bool ChkButtonNo1 = false;
        bool ChkButtonNo2 = false;
        bool ChkButtonNo3 = false;
        RadioButton objRdoButton1 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton1");
        RadioButton objRdoButton2 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton2");
        RadioButton objRdoButton3 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton3");
        objRdoButton1.Text = "Button 1";
        objRdoButton2.Text = "Button 2";
        objRdoButton3.Text = "Button 3";

        int tmpButtonNo = 0;

        foreach (DataRow dtRow in dt.Rows)
        {
            tmpButtonNo = Convert.ToInt32(dtRow["ButtonNo"].ToString());

            switch (tmpButtonNo)
            {
                case 1: ChkButtonNo1 = true; break;
                case 2: ChkButtonNo2 = true;  break;
                case 3: ChkButtonNo3 = true;  break;
            }
        }

        

        objRdoButton1.Enabled = true;
        objRdoButton2.Enabled = true;
        objRdoButton3.Enabled = true;


        if (ChkButtonNo1)
        {
            objRdoButton1.Enabled = false;
            objRdoButton1.Text = "Button 1 (Exists)";
        }

        if (ChkButtonNo2)
        {
            objRdoButton2.Enabled = false;
            objRdoButton2.Text = "Button 2 (Exists)";
        }

        if (ChkButtonNo3)
        {
            objRdoButton3.Enabled = false;
            objRdoButton3.Text = "Button 3 (Exists)";
        }

          if ((ChkButtonNo1 == true) && (ChkButtonNo2 == true) && (ChkButtonNo3 == true))
        {
            Label objLblOverMsg = (Label)FvOwnPage.FindControl("lblOverMessage");
            if (objLblOverMsg != null)
                objLblOverMsg.Text = "All the Buttons for this Anchor Domain has already been created.";
        }


    }


    protected void CustomVdr_Button_ServerValidate(object source, ServerValidateEventArgs args)
    {
        RadioButton objRdoButton1 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton1");
        RadioButton objRdoButton2 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton2");
        RadioButton objRdoButton3 = (RadioButton)FvOwnPage.Row.FindControl("rdoButton3");

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
