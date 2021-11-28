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


public partial class SuperAdmin_SA_AncDomainsCreate : System.Web.UI.Page
{
    SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //SqlDataAdapter dbAdap;
    DataSet ds;
    DataTable dt;
    string strSQL = string.Empty;
    //int qLgType = 1;
    int MenuButtonNo = 0; 


    CMSv3.BAL.OwnButton objBAL_OwnButton = new CMSv3.BAL.OwnButton();


    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        MenuButtonNo = Convert.ToInt32(Request.QueryString["bt"]);
        if(MenuButtonNo == 0)
            MenuButtonNo = 1;

        if (!IsPostBack)
        {

            LoadUserContent();
            
        }


    }


    protected void LoadUserContent()
    {

        ds = objBAL_OwnButton.Retrieve_ButtonInfoBYSA(Convert.ToInt32(Session["saUserID"]), MenuButtonNo); 

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

        Label objLblButtonNo = (Label)fRow.FindControl("lblButtonNo");

        if (objLblButtonNo != null)
            objLblButtonNo.Text = "Mobile Web Button No : " + MenuButtonNo.ToString(); 
        

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

            if (objLblButtonNo != null)
                objLblButtonNo.Text = "Create Mobile Web Button No : " + MenuButtonNo.ToString(); 
        }

        if (FvOwnPage.CurrentMode == FormViewMode.Edit)
        {

            if (objLblButtonNo != null)
                objLblButtonNo.Text = "EDIT Mobile Web Button No : " + MenuButtonNo.ToString(); 
        }


        
      

        if (FvOwnPage.CurrentMode == FormViewMode.ReadOnly)
        {
            

        }

                
    }
    protected void FvOwnPage_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {

        TextBox objTxtLinkName = (TextBox)FvOwnPage.Row.FindControl("txtButtonName");
        
        //FCKeditor obkFckEditor = (FCKeditor)FvOwnPage.Row.FindControl("FCKEditor1");
        HtmlTextArea TA_Editor = (HtmlTextArea)FvOwnPage.Row.FindControl("myEditor");



        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            //dbConn.Open();
            //strSQL = "Update tblTopMenuLinkByUser set userLinkName = N'" + objTxtLinkName.Text + "',userPagecontent = N'" + obkFckEditor.Value + "', "
            //         + " Active = " + Convert.ToInt16(objChkActive.Checked) + " where UserID = " + Convert.ToInt32(Session["UserID"]);

            //dbCmd = new SqlCommand(strSQL, dbConn);
            //int status = dbCmd.ExecuteNonQuery();

            bool upStatus = objBAL_OwnButton.Update_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, MenuButtonNo);
            

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

      
        //-- accessing the Selected Language 
       // ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;

      

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            //dbConn.Open();
            //strSQL = "Insert into tblTopMenuLinkByUser (userLinkName, userPagecontent,UserId,Active,LgType) Values (N'"
            //        + objTxtLinkName.Text + "',N'" + obkFckEditor.Value  + "'," +  Convert.ToInt32(Session["UserID"]) + "," + Convert.ToInt16(objChkActive.Checked) + "," + mSelLanguage + ")";
            
            //dbCmd = new SqlCommand(strSQL, dbConn);
            //int status = dbCmd.ExecuteNonQuery();

            int status = objBAL_OwnButton.Insert_OwnButtonData(objTxtLinkName.Text, TA_Editor.Value, Convert.ToInt32(Session["saUserID"]), true, 1, MenuButtonNo);


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
