using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_WelComePageSettings : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL;

    string tmpWpDescription = string.Empty;
    int qLgType = 1;
    //int mLanguage = 1; 
    


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 


        ltrWelcomePageDesc.Text = Resources.LangResources.Welcome + Resources.LangResources.Page + " Description";

        if (Request.QueryString["LgType"] != null)
            qLgType = Convert.ToInt16(Request.QueryString["LgType"]);


        //ddlLanguage.SelectedValue = Convert.ToString(mLanguage);

        if (!IsPostBack)
        {

            LoadDescription(qLgType);

        }

     }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        //PreSelecting the Language DropDown --
        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");

        if (objddlSelLang.Items[0].ToString() == "ALL")
        {
            objddlSelLang.Items.RemoveAt(0);
        }

        //if (qLgType != null)
        //    objddlSelLang.SelectedValue = Convert.ToString(qLgType);


        //if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        //{
        //    // qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        //    if (Request.QueryString["LgType"] == "0")
        //    {
        //        //gridFaq.Columns[5].Visible = false;

        //        int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridFaq);
        //        gridFaq.Columns[ColIdx].Visible = false;
        //    }
        //}
        //else if (qLgType == 0)
        //{
        //    int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridFaq);
        //    gridFaq.Columns[ColIdx].Visible = false;
        //}
    }

    protected void LoadDescription(int vLanguage)
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        String tmpWpDescription = string.Empty;

        strSQL = "Select top 1 Description,UserID,LgType from tblWelcomePage where UserID = " + Convert.ToInt32(Session["saUserID"]) + " and LgType = " + vLanguage;
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpWpDescription = dbReader["Description"].ToString();
            }

        }
        else
        {
            tmpWpDescription = "<br/> No description for Welcome Page has been added yet. <br/> To Create, click on the Add WelcomePage Description";
        }

        dbConn.Close();

        tmpWpDescription = tmpWpDescription.Replace("<br/>", Environment.NewLine);
        txtDescription.Text = tmpWpDescription;


    }





    protected void BtnSave_Click(object sender, EventArgs e)
    {


        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;


        //int inStatus;       

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        string tmpDescription = txtDescription.Text.ToString();
        tmpDescription = tmpDescription.Replace(Environment.NewLine, "<br/>");


        strSQL = "EXEC usp_WelComePage_InsertUpdate N'" + tmpDescription + "'," + Convert.ToUInt32(Session["saUserID"]) + "," + mSelLanguage + ",1"; 
        dbCmd = new SqlCommand(strSQL, dbConn);
        int rowCount = dbCmd.ExecuteNonQuery();

        dbConn.Close();

        if (rowCount >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Description successfully added";
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
}
