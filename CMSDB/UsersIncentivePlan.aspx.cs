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


public partial class UsersIncentivePlan : UserWeb
{


    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    String strSQL = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        ltrIncentivePlan.Text = Resources.LangResources.Incentiveplan;

        int vLangType = 1;

        if (!IsPostBack)
        {
            if (Request.QueryString["LgType"] != null)
            {
                vLangType = Convert.ToUInt16(Request.QueryString["LgType"]);
                // ddlLanguage.SelectedValue = Convert.ToString(vLangType);
            }

            LoadData(vLangType);
        }


        HtmlGenericControl myDivObject;
        myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");
        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
        sb.Append("<tr>");
        sb.Append("<td align='left' valign='top'>");
        sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append("<img alt='imbnLeftimg' src='Images/Incentive_head.jpg' />");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        myDivObject.InnerHtml = sb.ToString();




    }

    protected void LoadData(int vLangType)
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        String tmpIncPlanContent = string.Empty;

       // strSQL = "Select top 1 PlanID, PlanData,UserID from tblIncentivePlan where UserID = " + Convert.ToInt32(Session["UserID"]) + " and LgType = " + vLangType + " order by CreatedDate desc";
        strSQL = "Select top 1 PlanID, PlanData,UserID from tblIncentivePlan where LgType = " + vLangType + " order by CreatedDate desc";
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpIncPlanContent = dbReader["PlanData"].ToString();
                //hidIncPlanID.Value = dbReader["PlanID"].ToString();
            }

        }
        else
        {
            tmpIncPlanContent = "<br> No Content for Incentive Plan has been added yet. To Create, click on the Add Incentive Plan";
        }

        dbConn.Close();

        // txtIncPlanContent.Value = tmpIncPlanContent;
        lblIncentivePlan.Text = tmpIncPlanContent;



    }

}
