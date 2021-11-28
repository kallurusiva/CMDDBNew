using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using AjaxControlToolkit.HTMLEditor;

public partial class Admin_Ad_OwnButtonCreatesEB : BasePage
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlConnection dbConn1;
    SqlCommand dbCmd1;
    SqlDataReader dbReader;
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
            Response.Redirect("~/SessionExpireEbook.aspx");
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
            strSQL = "If NOT EXISTS(Select UserLinkID, userLinkName, userPagecontent, Active,LgType from tblTopMenuLinkByUser where deleted=0 and  UserID = " + Convert.ToInt32(Session["UserID"]) + " and LgType = " + qLgType + " and ButtonNo = " + MenuButtonNo + ") ";
            strSQL = strSQL + " Insert into tblTopMenuLinkByUser (userLinkName,userPagecontent,Active,UserID,CreatedDate,Deleted,LgType,ButtonNo) values('','',1," + Convert.ToInt32(Session["UserID"]) + ",GETDATE(),0," + qLgType + "," + MenuButtonNo + ");   ";
            strSQL = strSQL + "Select UserLinkID, userLinkName, userPagecontent, Active,LgType from tblTopMenuLinkByUser where deleted=0 and  UserID = " + Convert.ToInt32(Session["UserID"]) + " and LgType = " + qLgType + " and ButtonNo = " + MenuButtonNo;

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

            validate_Page();
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
        
        Literal objLtrDisplayatWebsite = (Literal)fRow.FindControl("ltrDisplayatWebsite");
        objLtrDisplayatWebsite.Text = Resources.LangResources.DisplayatWebsite;      

        if (FvOwnPage.CurrentMode == FormViewMode.ReadOnly)
        {
            HiddenField objHidActive = (HiddenField)fRow.FindControl("hidActive");
            Image objImgActive = (Image)fRow.FindControl("ImgActive");
          
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
        //HtmlTextArea TA_Editor = (HtmlTextArea)FvOwnPage.Row.FindControl("myEditor");
        //AjaxControlToolkit.HtmlEditorExtender TA_Editor = (AjaxControlToolkit.HtmlEditorExtender)FvOwnPage.Row.FindControl("myEditor");
        AjaxControlToolkit.HTMLEditor.Editor TA_Editor = (AjaxControlToolkit.HTMLEditor.Editor)FvOwnPage.Row.FindControl("myEditor");

        int mSelLanguage = 1;      
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            bool upStatus = objBAL_OwnButton.Update_OwnButtonData(objTxtLinkName.Text, TA_Editor.Content.ToString(), Convert.ToInt32(Session["UserID"]), objChkActive.Checked, mSelLanguage, MenuButtonNo);
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
        HtmlTextArea TA_Editor = (HtmlTextArea)FvOwnPage.Row.FindControl("myEditor");

        CheckBox objChkActive = (CheckBox)FvOwnPage.Row.FindControl("chkActive");      
        int mSelLanguage = 1;       

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            int status = objBAL_OwnButton.Insert_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["UserID"]), objChkActive.Checked, mSelLanguage, MenuButtonNo);
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

    protected void validate_Page()
    {
        if (Session["MobileLoginID"] != null)
        {
            string mlmStatusPack = string.Empty;
            String mUserId = Session["MobileLoginID"].ToString().Replace("EB", "");
            string strSQL = "EXEC eSMS.dbo.uspT_getUserPackageType " + mUserId;

            dbConn1 = new SqlConnection(GlobalVar.GetDbConnString);

            try
            {
                dbConn1.Open();
                dbCmd1 = new SqlCommand(strSQL, dbConn1);
                dbReader = dbCmd1.ExecuteReader();

                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {
                        mlmStatusPack = dbReader["mlmStatus"].ToString();
                    }
                }

                if (mlmStatusPack == "0")
                {
                    //CommonFunctions.AlertMessage("This Facility is for upgraded Partners only. Please upgrade to enjoy this facility.");
                    CommonFunctions.AlertMessageAndRedirect("This Facility is for upgraded Partners only. Please upgrade to enjoy this facility.", "Ad_WelcomeEbook.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                dbConn1.Close();
            }
        }
    }
   
}
