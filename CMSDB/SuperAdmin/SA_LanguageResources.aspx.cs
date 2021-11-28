using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_LanguageResources : System.Web.UI.Page
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;
    DataSet ds;

    String strSQL = string.Empty;
    CMSv3.BAL.HomePage objBAL_Homepage = new CMSv3.BAL.HomePage();

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        LtrLangAdd.Text = Resources.LangResources.Language + " " + Resources.LangResources.Listing;

        if (!IsPostBack)
        {
            LoadLanguageList();
        }

    }

    protected void LoadLanguageList()
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            strSQL = "select LangID, LangCode, LangName,LangCulture from tblLanguages where deleted = 0";

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbAdap = new SqlDataAdapter(dbCmd);

            ds = new DataSet();
            dbAdap.Fill(ds);

            GridLanguage.DataSource = ds;
            GridLanguage.DataBind();


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

    protected void GridLanguage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridLanguage.EditIndex = -1;
        LoadLanguageList();
    }

    protected void GridLanguage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridLanguage.EditIndex = e.NewEditIndex;
        LoadLanguageList();

    }




    protected void GridLanguage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridLanguage.Rows[e.RowIndex];
        HiddenField hdLangID = (HiddenField)gvRow.FindControl("hdLangID");


        string strSQL = "Update tblLanguages set Deleted = 1 where LangID = " + Convert.ToInt32(hdLangID.Value);

        try
        {
            dbConn = new SqlConnection(GlobalVar.GetDbConnString);
            dbConn.Open();

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }

        LoadLanguageList();

    }


    protected void GridLanguage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridLanguage.Rows[e.RowIndex];
        HiddenField hdLangID = (HiddenField)gvRow.FindControl("hdLangID");
        TextBox objTxtLangName = (TextBox)gvRow.FindControl("txtLangName");

        if (objTxtLangName != null)
        {

            dbConn = new SqlConnection(GlobalVar.GetDbConnString);

            try
            {
                dbConn.Open();
                strSQL = "Update tblLanguages set LangName='" + objTxtLangName.Text + "' where LangID=" + hdLangID.Value;

                dbCmd = new SqlCommand(strSQL, dbConn);
                dbCmd.ExecuteNonQuery();

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
        GridLanguage.EditIndex = -1;
        LoadLanguageList();

    }


    protected void AddNewMenuItem_Click(object sender, EventArgs e)
    {
        TextBox objNewLangCode = (TextBox)GridLanguage.FooterRow.FindControl("txt_NewLangCode");
        TextBox objNewLangName = (TextBox)GridLanguage.FooterRow.FindControl("txt_NewLangName");
        //CheckBox objNewActive = (CheckBox)GridLanguage.FooterRow.FindControl("chk_newActive");

        int inStatus = objBAL_Homepage.Insert_LanguageItem(objNewLangCode.Text, objNewLangName.Text);

        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "New Language Item successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";
        }
        else if (inStatus == 2)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Entered language Code already exists. Please enter another language code";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
          //  lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
            lblErrMessage.Text = "Entered language Code already exists. Please enter another language code";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }


        LoadLanguageList();

    }

}
