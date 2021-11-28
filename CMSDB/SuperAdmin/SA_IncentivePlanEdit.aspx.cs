using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_IncentivePlanEdit : System.Web.UI.Page 
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL;
    //string tmpIncPlan;
    string mPlanID;
    int mLanguage = 1;
    
    


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        ////FCKeditor1.BasePath = "~/OtherUtils/fckeditor/";
        ////FCKeditor1.ImageBrowserURL = "~/Images/";
        ////FCKeditor1.AutoDetectLanguage = true;
        ////FCKeditor1.Width = 1024;
        ////FCKeditor1.Height = 512;
        
        if (Request.QueryString["LgType"] != null)
             mLanguage = Convert.ToInt16(Request.QueryString["LgType"]);
        

        ddlLanguage.SelectedValue = Convert.ToString(mLanguage);

        if (Request.QueryString["PlanID"] != null)
            mPlanID = Request.QueryString["PlanId"];
            

       
        LtrAddIncentivePlan.Text = Resources.LangResources.Incentiveplan;

        if (!IsPostBack)
        {
            LoadData(mPlanID, mLanguage);
        }


     }

    protected void LoadData(string vPlanId, int vLanguage)
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        String tmpIncPlanContent = string.Empty;

        strSQL = "Select top 1 PlanID, PlanData,UserID from tblIncentivePlan where UserID = " + Convert.ToInt32(Session["saUserID"]) + " and LgType = " + vLanguage + " and PlanID= " +  vPlanId + " order by CreatedDate desc";
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpIncPlanContent = dbReader["PlanData"].ToString();
                hidIncPlanID.Value = dbReader["PlanID"].ToString();
            }

        }
        else
        {
            tmpIncPlanContent = "<br> No Content for Incentive Plan has been added yet. To Create, click on the Add Incentive Plan";
        }

        dbConn.Close();

        // txtIncPlanContent.Value = tmpIncPlanContent;
        ////FCKeditor1.Value = tmpIncPlanContent;

        myEditor.Content = tmpIncPlanContent;



    }


    
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //string tmpEditorContent = FCKeditor1.Value;

        string tmpEditorContent = myEditor.Content.ToString();
        tmpEditorContent = tmpEditorContent.Replace("'", "''");

        int inStatus;
        int rowCount=0;

        try
        {
            dbConn = new SqlConnection(GlobalVar.GetDbConnString);
            dbConn.Open();

            strSQL = "Update tblIncentivePlan set PlanData = N'" + tmpEditorContent + "' Where UserID = " + Convert.ToUInt32(Session["saUserID"]) + " and LgType = " + mLanguage + " and PlanID = " + mPlanID;
            dbCmd = new SqlCommand(strSQL, dbConn);
            rowCount = dbCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }

        

        if (rowCount >= 1)
            inStatus = 1;
        else
            inStatus = -1;


        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Incentive Plan successfully updated";
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
