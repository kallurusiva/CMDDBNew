using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Ad_WelComePageSettingsWES : BasePage
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
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
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

        //strSQL = "Select top 1 Description,UserID,LgType from tblWelcomePage where UserID = " + Convert.ToInt32(Session["UserID"]) + " and LgType = " + vLanguage;
        strSQL = "EXEC usp_WelcomePage_Retrieve_ByUserID " + Convert.ToInt32(Session["UserID"]) + "," + qLgType;
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                if (dbReader["UserType"].ToString() == "0")
                {

                    tmpWpDescription = dbReader["Description"].ToString();
                    tmpWpDescription = tmpWpDescription.Replace("<br/>", Environment.NewLine);
                    txtDescriptionUser.Text = tmpWpDescription;
                    hidWelcomeIDUSER.Value = dbReader["Wid"].ToString();
                    break;
                }


                if (dbReader["UserType"].ToString() == "2")
                {
                    tmpWpDescription = dbReader["Description"].ToString();
                    tmpWpDescription = tmpWpDescription.Replace("<br/>", Environment.NewLine);
                    txtDescriptionUser.Text = tmpWpDescription;
                    hidWelcomeIDSA.Value = dbReader["Wid"].ToString();
                }
               
            }

        }
        else
        {
            tmpWpDescription = "<br/> No description for Welcome Page has been added yet. <br/> To Create, click on the Add WelcomePage Description";
            txtDescriptionUser.Text = tmpWpDescription;
            txtDescriptionUser.Text = tmpWpDescription;
           // chkActiveSA.Checked = false;
          //  chkActiveUser.Checked = false;
                    
        }

        dbConn.Close();

   


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

        //int rowCount=0;
        //int inStatus;       

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        string HdWelcomeID = hidWelcomeIDSA.Value;

        //if (txtDescriptionSA.Text.ToString() != "")
        //{
        //    string tmpDescriptionSA = txtDescriptionSA.Text.ToString();
        //    tmpDescriptionSA = tmpDescriptionSA.Replace(Environment.NewLine, "<br/>");

        //    strSQL = "EXEC usp_WelComePage_InsertUpdate '" + tmpDescriptionSA + "'," + Convert.ToUInt32(Session["UserID"]) + "," + mSelLanguage + "," + Convert.ToInt16(chkActiveSA.Checked);
        //    dbCmd = new SqlCommand(strSQL, dbConn);
        //    rowCount = dbCmd.ExecuteNonQuery();
        //}

        
        //CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
        //bool upStatus = objBAL_CommonFunc.InsertUpdate_ShowAdminItems("tblWelcomePage", HdWelcomeID, Convert.ToInt32(Session["UserID"]));


        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

        bool upStatus = false;

        if (txtDescriptionUser.Text.ToString() != "")
        {
            string tmpDescriptionUSER = txtDescriptionUser.Text.ToString();
            tmpDescriptionUSER = tmpDescriptionUSER.Replace(Environment.NewLine, "<br/>");

            upStatus = objBAL_User.InsertUpdate_WelcomePage(tmpDescriptionUSER,Convert.ToInt32(Session["UserID"]), mSelLanguage,true);
            //strSQL = "EXEC usp_WelComePage_InsertUpdate '" + tmpDescriptionUSER + "'," + Convert.ToUInt32(Session["UserID"]) + "," + mSelLanguage+ "," + Convert.ToInt16(rdoActiveUser.Checked);
            //dbCmd = new SqlCommand(strSQL, dbConn);
            //rowCount = dbCmd.ExecuteNonQuery();
        }




        dbConn.Close();

        if (upStatus)
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
