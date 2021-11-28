using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FredCK.FCKeditorV2;


public partial class SA_SpButtonWebAdd : System.Web.UI.Page
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //SqlDataAdapter dbAdap;
    DataSet ds;
    DataTable dt;
    string strSQL = string.Empty;
    //int qLgType = 1;
    //int qMenuButtonNo = 0;
    //int qAnchorDomainID = 0; 
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

 
        if (!IsPostBack)
        {
 
            LoadButtonContent(); 
            
        }


        




    }


    protected void RenderInsertButton()
    {
        FvSpButton.ChangeMode(FormViewMode.Insert);
    }



    protected void LoadButtonContent()
    {

        //if (vButtonNo == 0)
        //{
        //    FvSpButton.ChangeMode(FormViewMode.Insert);
        //}
        //else
        //{

        ds = objBAL_OwnButton.Retrieve_ExtraButtonInfoBYSA(); 

            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {

                FvSpButton.DataSource = dt;
                FvSpButton.DataBind();
            }
            else
            {
                FvSpButton.ChangeMode(FormViewMode.Insert);
            }


      //  }       

    }

    protected void FvSpButton_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FvSpButton.ChangeMode(e.NewMode);
        LoadButtonContent();
    }




    protected void FvSpButton_DataBound(object sender, EventArgs e)
    {
        FormViewRow fRow = (FormViewRow)FvSpButton.Row;
        string tmpContent = string.Empty;
        string mLanguage = string.Empty;

        

 
        

        if ((FvSpButton.CurrentMode == FormViewMode.Insert) || (FvSpButton.CurrentMode == FormViewMode.Edit))
        {
            //FCKeditor obkFckEditor = (FCKeditor)fRow.FindControl("FCKEditor1");
            //obkFckEditor.BasePath = "~/OtherUtils/fckeditor/";
            //obkFckEditor.ImageBrowserURL = "~/Images/";
            //obkFckEditor.AutoDetectLanguage = true;
            //obkFckEditor.Width = 1024;
            //obkFckEditor.Height = 512;

           
        }

        if (FvSpButton.CurrentMode == FormViewMode.Insert)
        {
           

        }

        if (FvSpButton.CurrentMode == FormViewMode.Edit)
        {
            HiddenField ObjHdGadsPosition = (HiddenField)fRow.FindControl("hidGAdsPosition");

            if (ObjHdGadsPosition != null)
            {
                RadioButtonList objRdoBtnGads = (RadioButtonList)fRow.FindControl("RdoBtnShowPosition");

                if (objRdoBtnGads != null)
                {
                    objRdoBtnGads.SelectedIndex = Convert.ToInt16(ObjHdGadsPosition.Value) - 1;

                }
            }
            
        }


        if (FvSpButton.CurrentMode == FormViewMode.ReadOnly)
        {

            HiddenField ObjHdGadsPosition = (HiddenField)fRow.FindControl("hidGAdsPosition");
            RadioButtonList objRdoBtnGads = (RadioButtonList)fRow.FindControl("RdoBtnShowPosition");

            if (objRdoBtnGads != null)
            {
                objRdoBtnGads.SelectedIndex = Convert.ToInt16(ObjHdGadsPosition.Value) - 1;

            }

            #region Showing Checkbox ticked image


            //need to find out if the logged users is not a superadmin disable the last cell 

            //============
            HiddenField objHidActive = (HiddenField)fRow.FindControl("HidActive");
            Image objImgActive = (Image)fRow.FindControl("ImgActive");
            Label objLblShowHide = (Label)fRow.FindControl("lblShowHide"); 

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (objImgActive != null)
            {
                if (objHidActive.Value != "")
                {
                    if (Convert.ToBoolean(objHidActive.Value))
                    {

                        //objImgActive.ImageUrl = @"~\Images\Active_Show.jpg";
                        objImgActive.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                        objLblShowHide.Text = "SHOWN at Website";

                    }
                    else
                    {
                        //objImgActive.ImageUrl = @"~\Images\Active_Hide.jpg";
                        objImgActive.ImageUrl = @"~\Images\checkbox_empty.jpg";
                        objLblShowHide.Text = "HIDDEN at Website";
                    }
                }
            }

            #endregion
        }

                
    }
    protected void FvSpButton_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {


        TextBox objtxtButtonName = (TextBox)FvSpButton.Row.FindControl("txtButtonName");

        //FCKeditor obkFckEditor = (FCKeditor)FvSpButton.Row.FindControl("FCKEditor1");
        HtmlTextArea TA_Editor = (HtmlTextArea)FvSpButton.Row.FindControl("myEditor");

      

        CheckBox chkActive = (CheckBox)FvSpButton.Row.FindControl("chkShowHide");

        RadioButtonList objRdoBtnGads = (RadioButtonList)FvSpButton.Row.FindControl("RdoBtnShowPosition");

        int tmpGadsPosition = 0;

        if (objRdoBtnGads != null)
            tmpGadsPosition = Convert.ToInt16(objRdoBtnGads.SelectedValue);


       // bool upStatus = objBAL_OwnButton.Update_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, qMenuButtonNo);
        int upStatus = objBAL_OwnButton.Insert_ExtraButtonBySA(objtxtButtonName.Text, TA_Editor.Value, chkActive.Checked, 9, tmpGadsPosition);
            
        
        FvSpButton.ChangeMode(FormViewMode.ReadOnly);
        LoadButtonContent();
        
    }


    protected void FvSpButton_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (Page.IsValid)
        {

            TextBox objtxtButtonName = (TextBox)FvSpButton.Row.FindControl("txtButtonName");

            HtmlTextArea TA_Editor = (HtmlTextArea)FvSpButton.Row.FindControl("myEditor");

            CheckBox chkActive = (CheckBox)FvSpButton.Row.FindControl("chkShowHide");

            RadioButtonList objRdoBtnGads = (RadioButtonList)FvSpButton.Row.FindControl("RdoBtnShowPosition");


            int tmpGadsPosition = 0;

            if (objRdoBtnGads != null)
                tmpGadsPosition = Convert.ToInt16(objRdoBtnGads.SelectedValue);



            //int status = objBAL_OwnButton.Insert_OwnButtonData(objtxtButtonName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, MenuButtonNo);
            int inStatus = objBAL_OwnButton.Insert_ExtraButtonBySA(objtxtButtonName.Text, TA_Editor.Value, chkActive.Checked, 9, Convert.ToInt16(objRdoBtnGads.SelectedValue));

            
            FvSpButton.ChangeMode(FormViewMode.ReadOnly);
            LoadButtonContent();
        }
    }



    protected void CheckAndRenderPage(int vAnchorDomainId)
    {

        ds = objBAL_OwnButton.Retrieve_DefWebButtonsByAnchorDomainID(vAnchorDomainId,1); 

        DataTable dt = ds.Tables[0];


        bool ChkButtonNo1 = false;
        bool ChkButtonNo2 = false;
        bool ChkButtonNo3 = false;
        RadioButton objRdoButton1 = (RadioButton)FvSpButton.Row.FindControl("rdoButton1");
        RadioButton objRdoButton2 = (RadioButton)FvSpButton.Row.FindControl("rdoButton2");
        RadioButton objRdoButton3 = (RadioButton)FvSpButton.Row.FindControl("rdoButton3");
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
            Label objLblOverMsg = (Label)FvSpButton.FindControl("lblOverMessage");
            if (objLblOverMsg != null)
                objLblOverMsg.Text = "All the Buttons for this Anchor Domain has already been created.";
        }


    }


    protected void CustomVdr_Button_ServerValidate(object source, ServerValidateEventArgs args)
    {
        RadioButton objRdoButton1 = (RadioButton)FvSpButton.Row.FindControl("rdoButton1");
        RadioButton objRdoButton2 = (RadioButton)FvSpButton.Row.FindControl("rdoButton2");
        RadioButton objRdoButton3 = (RadioButton)FvSpButton.Row.FindControl("rdoButton3");

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
