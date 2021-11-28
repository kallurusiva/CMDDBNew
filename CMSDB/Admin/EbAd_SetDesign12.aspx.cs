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

public partial class Admin_EbAd_SetDesign12 : BasePage
{
    string strSQL = string.Empty;
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    //    SqlDataAdapter dbAdap;

    //   DataSet ds;
    //   DataTable dtTemplates;
    //   DataTable dtSetTemplate;
    int TmpTemplateID;

    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();

    protected void Page_Load(object sender, EventArgs e)
    {


        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        TmpTemplateID = GetZero();
        ltrSetDefaultTemplate.Text = Resources.LangResources.Set + " " + "Default Template";
        ltrNoteLanguage.Text = "";

        ltrNote.Text = Resources.LangResources.Note;

        if ((Session.SessionID != null) && (Session["UserID"] != null))
            lblSessionValues.Text = Session.SessionID + " | " + Session["UserID"].ToString();

        if (!IsPostBack)
        {
            if (Request.QueryString["LangChanged"] != null)
            {
                if (Request.QueryString["LangChanged"] == "true")
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "SetLanguage", "alert('Note: You have Changed your default Language setting \\n\\n All the Buttons and correponding text would appear in Selected Language')", true);
                }
            }
            LoadTemplateInfo();
        }
    }

    private static int GetZero()
    {
        return 0;
    }

    protected void LoadTemplateInfo()
    {
        string dbMasterPageNameValue = string.Empty;
        string dbUserDomainType = string.Empty;
        string dbMasterCssName = string.Empty;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            strSQL = "select MasterPageID, MasterPageName,MasterCSS, M.UserID, UserDomainType from tblUserMasterPage M " +
                      " Left Outer join tblUsers U on U.UserID = M.USerID " +
                         " where M.UserId =" + Convert.ToInt32(Session["UserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    dbMasterPageNameValue = dbReader["MasterPageName"].ToString();
                    dbMasterCssName = dbReader["MasterCSS"].ToString();
                    dbUserDomainType = dbReader["UserDomainType"].ToString();
                }
            }

            if (dbMasterPageNameValue == "N_Master.master" || dbMasterPageNameValue == "TmpMasterGen1.master")
            //--- ********  --- ebook template 1 ------- *********   --     
            {
                TmpTemplateID = 1;
                if (dbMasterCssName == "BLACK")
                {
                    rdoWebTemplate1_Black.Checked = true;
                }
                else if (dbMasterCssName == "BLUE")
                {
                    rdoWebTemplate1_Blue.Checked = true;
                }

                else if (dbMasterCssName == "GREEN")
                {
                    rdoWebTemplate1_Green.Checked = true;
                }

                else if (dbMasterCssName == "ORANGE")
                {
                    rdoWebTemplate1_Orange.Checked = true;
                }

                else if (dbMasterCssName == "RED")
                {
                    rdoWebTemplate1_Red.Checked = true;
                }
            }
            
            else
            {
                rdoWebTemplate1_Red.Checked = true;
            }
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string mSelValue = string.Empty;
        string mCssvalue = string.Empty;

        // ............. Ebook Template 1..........................

        if (rdoWebTemplate1_Black.Checked == true)
        {
            mSelValue = "N_Master.master";
            mCssvalue = "BLACK";
        }
        else if (rdoWebTemplate1_Blue.Checked == true)
        {
            mSelValue = "N_Master.master";
            mCssvalue = "BLUE";
        }
        else if (rdoWebTemplate1_Green.Checked == true)
        {
            mSelValue = "N_Master.master";
            mCssvalue = "GREEN";
        }
        else if (rdoWebTemplate1_Orange.Checked == true)
        {
            mSelValue = "N_Master.master";
            mCssvalue = "ORANGE";
        }
        else if (rdoWebTemplate1_Red.Checked == true)
        {
            mSelValue = "N_Master.master";
            mCssvalue = "RED";
        }       
        else
        {
            mSelValue = "N_Master.master";
            mCssvalue = "RED";
        }

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            strSQL = "Update [tblUserMasterPage] set MasterPageName = '" + mSelValue + "', MasterCSS = '" +
                     mCssvalue + "'where UserID = " + Convert.ToInt32(Session["UserID"]);
            dbCmd = new SqlCommand(strSQL, dbConn);
            int upStatus = dbCmd.ExecuteNonQuery();

            Session["MasterPageFile"] = mSelValue;
            Session["MasterPageCss"] = mCssvalue;

            if (upStatus >= 1)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                lblErrMessage.Text = "Web Template Changed Successfully. The Changes would be visible on your next visit to the web page.";
                lblErrMessage.CssClass = "font_12Msg_Success";
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
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }
    }
}
