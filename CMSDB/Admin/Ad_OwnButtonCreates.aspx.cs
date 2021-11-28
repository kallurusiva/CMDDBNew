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


public partial class Admin_Ad_OwnButtonCreates : BasePage
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    //SqlDataReader dbReader;
    SqlDataAdapter dbAdap;
    DataSet ds;
    DataTable dt;
    string strSQL = string.Empty;
    int qLgType = 1;
    int MenuButtonNo = 0; 


    CMSv3.BAL.OwnButton objBAL_OwnButton = new CMSv3.BAL.OwnButton();


    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 



        if (Request.QueryString["LgType"] != null)
            qLgType = Convert.ToInt16(Request.QueryString["LgType"]);

        MenuButtonNo = Convert.ToInt32(Request.QueryString["MyButtonNo"]);

        #region Language resources

        LtrAddNewButtonPage.Text = "Create My Menu Button and Page : " + MenuButtonNo.ToString();
        //lblButtonName.Text = "Enter new button Name";
        //lblEnterPageContent = "Enter new Page content here";

        #endregion

        #region Code to Hide Left ContentHolder

        HtmlGenericControl myDivLeftBar;
        myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

        myDivLeftBar.Style.Clear();
        myDivLeftBar.Style.Value = "width:0px;";


        HtmlGenericControl myDivRightBar;
        myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

        myDivRightBar.Style.Clear();
        myDivRightBar.Style.Value = " width: 96%; padding-left:20px;";

        #endregion

        if (!IsPostBack)
        {


            LoadUserContent();
            
        }


       

    }


    protected void LoadUserContent()
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            strSQL = "Select UserLinkID, userLinkName, userPagecontent, Active,LgType from tblTopMenuLinkByUser where deleted=0 and  UserID = " + Convert.ToInt32(Session["UserID"]) + " and LgType = " + qLgType + " and ButtonNo = " + MenuButtonNo;

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);

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


            //FormViewRow fvRow = FvOwnPage.Row;

            //FCKeditor obkFckEditor = (FCKeditor)fvRow.FindControl("FCKEditor1");
            //obkFckEditor.BasePath = "~/OtherUtils/fckeditor/";
            //obkFckEditor.ImageBrowserURL = "~/Images/";
            //obkFckEditor.AutoDetectLanguage = true;
            //obkFckEditor.Width = 1024;
            //obkFckEditor.Height = 512;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }

    }

    protected void FvOwnPage_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FvOwnPage.ChangeMode(e.NewMode);
        LoadUserContent();
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
            //mLanguage = DataBinder.Eval(FvOwnPage.DataItem, "LgType").ToString();

            
            //UserControl uc = (UserControl)FvOwnPage.Row.FindControl("ucSelectLanguage4Create");
            UserControl uc = (UserControl)FvOwnPage.Row.FindControl("ucSelectLanguage");
            DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
            //int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);
            objddlSelLang.SelectedValue = qLgType.ToString();

            if (objddlSelLang.Items[0].ToString() == "ALL")
            {
                objddlSelLang.Items.RemoveAt(0);
            }

        }

        if (FvOwnPage.CurrentMode == FormViewMode.Edit)
        {
           // mLanguage = DataBinder.Eval(FvOwnPage.DataItem, "LgType").ToString();

            UserControl uc = (UserControl)FvOwnPage.Row.FindControl("ucSelectLanguage");
            DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
            //int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);
            objddlSelLang.SelectedValue = qLgType.ToString();

            if (objddlSelLang.Items[0].ToString() == "ALL")
            {
                objddlSelLang.Items.RemoveAt(0);
            }
            
        }


        
        Literal objLtrDisplayatWebsite = (Literal)fRow.FindControl("ltrDisplayatWebsite");
        objLtrDisplayatWebsite.Text = Resources.LangResources.DisplayatWebsite;

      

        if (FvOwnPage.CurrentMode == FormViewMode.ReadOnly)
        {
            HiddenField objHidActive = (HiddenField)fRow.FindControl("hidActive");
            Image objImgActive = (Image)fRow.FindControl("ImgActive");

            UserControl uc = (UserControl)FvOwnPage.Row.FindControl("ucSelectLanguage");
            DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
            //int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);
            objddlSelLang.SelectedValue = qLgType.ToString();

            if (objddlSelLang.Items[0].ToString() == "ALL")
            {
                objddlSelLang.Items.RemoveAt(0);
            }


            if (objHidActive != null)
            {
                if ((objHidActive.Value == "1") || (objHidActive.Value == "True"))
                {
                    objImgActive.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                }
                else
                {
                    objImgActive.ImageUrl = @"~\Images\checkbox_empty.jpg";
                }
            }

        }

                
    }
    protected void FvOwnPage_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {

        TextBox objTxtLinkName = (TextBox)FvOwnPage.Row.FindControl("txtButtonName");
        CheckBox objChkActive = (CheckBox)FvOwnPage.Row.FindControl("chkActive");
        //FCKeditor obkFckEditor = (FCKeditor)FvOwnPage.Row.FindControl("FCKEditor1");
        HtmlTextArea TA_Editor = (HtmlTextArea)FvOwnPage.Row.FindControl("myEditor");

        //-- accessing the Selected Language 
        UserControl uc = (UserControl)FvOwnPage.Row.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;




        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            //dbConn.Open();
            //strSQL = "Update tblTopMenuLinkByUser set userLinkName = N'" + objTxtLinkName.Text + "',userPagecontent = N'" + obkFckEditor.Value + "', "
            //         + " Active = " + Convert.ToInt16(objChkActive.Checked) + " where UserID = " + Convert.ToInt32(Session["UserID"]);

            //dbCmd = new SqlCommand(strSQL, dbConn);
            //int status = dbCmd.ExecuteNonQuery();

            bool upStatus = objBAL_OwnButton.Update_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["UserID"]), objChkActive.Checked, qLgType, MenuButtonNo);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }
        FvOwnPage.ChangeMode(FormViewMode.ReadOnly);
        LoadUserContent();
    }


    protected void FvOwnPage_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        TextBox objTxtLinkName = (TextBox)FvOwnPage.Row.FindControl("txtButtonName");
        //FCKeditor obkFckEditor = (FCKeditor)FvOwnPage.Row.FindControl("FCKEditor1");
        HtmlTextArea TA_Editor = (HtmlTextArea)FvOwnPage.Row.FindControl("myEditor");

        CheckBox objChkActive = (CheckBox)FvOwnPage.Row.FindControl("chkActive");

        //-- accessing the Selected Language 
       // ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;

        //UserControl uc = (UserControl)FvOwnPage.Row.FindControl("ucSelectLanguage4Create");
        UserControl uc = (UserControl)FvOwnPage.Row.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);
        
        if (mSelLanguage == 0)
            mSelLanguage = 1;


        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            //dbConn.Open();
            //strSQL = "Insert into tblTopMenuLinkByUser (userLinkName, userPagecontent,UserId,Active,LgType) Values (N'"
            //        + objTxtLinkName.Text + "',N'" + obkFckEditor.Value  + "'," +  Convert.ToInt32(Session["UserID"]) + "," + Convert.ToInt16(objChkActive.Checked) + "," + mSelLanguage + ")";
            
            //dbCmd = new SqlCommand(strSQL, dbConn);
            //int status = dbCmd.ExecuteNonQuery();

            int status = objBAL_OwnButton.Insert_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["UserID"]), objChkActive.Checked, qLgType, MenuButtonNo);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }

        FvOwnPage.ChangeMode(FormViewMode.ReadOnly);
        LoadUserContent();
    }

   
}
