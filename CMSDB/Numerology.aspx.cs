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

public partial class Numerology : UserWeb
{


    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    String strSQL = string.Empty;
    int qButtonNo = 0;
    string qButtonText = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //ltrUserContent.Text = Resources.LangResources.My + " " + Resources.LangResources.Page;

        int vLangType = 1;

        if (!IsPostBack)
        {
            #region  // SessionCheck
            if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
            {
                Response.Redirect("~/Default.aspx");
            }
            #endregion

            if (Request.QueryString["LgType"] != null)
            {
                vLangType = Convert.ToUInt16(Request.QueryString["LgType"]);
                // ddlLanguage.SelectedValue = Convert.ToString(vLangType);
            }

            //if (Request.QueryString["BN"] != null)
            //{
            //    //qButtonNo = Convert.ToInt16(Request.QueryString["ButtonNo"]);
            //    qButtonText = HttpUtility.UrlDecode(Request.QueryString["BN"].ToString());
            //}

            //if (Request.QueryString["Bt"] != null)
            //{
            //    //qButtonNo = Convert.ToInt16(Request.QueryString["ButtonNo"]);
            //    qButtonNo = Convert.ToInt16(Request.QueryString["Bt"]);
            //}

            qButtonText = "Numerology";
            qButtonNo = 101;

            //LoadData(vLangType, qButtonNo);
            LoadData_ByButtonName(vLangType, qButtonText, qButtonNo);
        }


        if (Session["MasterPageCss"] != null)
        {
            if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet"))
            {
                HtmlGenericControl myDivObject;
                myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

                if (myDivObject != null)
                {
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
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        //--- hiding the login row for template 3 -- //
        #region hiding login row


        //string tmpCurrPageName = Path.GetFileNameWithoutExtension(Request.PhysicalPath);
        HtmlTable tmptblLogin = (HtmlTable)Master.FindControl("tblLoginArea");

        if (tmptblLogin != null)
        {

            tmptblLogin.Visible = false;

        }
        #endregion





    }

    protected void LoadData(int vLangType, int vButtonNo)
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        String tmpUserContent = string.Empty;

        // strSQL = "Select top 1 PlanID, PlanData,UserID from tblIncentivePlan where UserID = " + Convert.ToInt32(Session["UserID"]) + " and LgType = " + vLangType + " order by CreatedDate desc";
        // strSQL = "select userLinkID,UserLinkName,UserPageContent,Active,UserID,LgType from tblTopMenuLinkByUser where LgType = " + vLangType +
        // " and deleted = 0 and UserId = " + Convert.ToInt32(Session["ClientID"]) +  " and ButtonNo =" + vButtonNo + " order by CreatedDate desc";

        //EXEC [usp_UserOwnPage_Retrieve_ByUserID] 115 , 1  

        strSQL = "EXEC [usp_UserOwnPage_Retrieve_ByUserID] " + Convert.ToInt32(Session["ClientID"]) + "," + vButtonNo;

        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpUserContent = dbReader["UserPageContent"].ToString();
                //hidIncPlanID.Value = dbReader["PlanID"].ToString();
            }

        }
        else
        {
            tmpUserContent = "<br> No Content has been added yet. To Create, click on the Add the content";
        }

        dbConn.Close();

        // txtIncPlanContent.Value = tmpUserContent;
        lblUserContent.Text = tmpUserContent;



    }



    protected void LoadData_ByButtonName(int vLangType, string vButtonText, int vButtonNo)
    {


        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        String tmpUserContent = string.Empty;

        // strSQL = "Select top 1 PlanID, PlanData,UserID from tblIncentivePlan where UserID = " + Convert.ToInt32(Session["UserID"]) + " and LgType = " + vLangType + " order by CreatedDate desc";
        // strSQL = "select userLinkID,UserLinkName,UserPageContent,Active,UserID,LgType from tblTopMenuLinkByUser where LgType = " + vLangType +
        // " and deleted = 0 and UserId = " + Convert.ToInt32(Session["ClientID"]) +  " and ButtonNo =" + vButtonNo + " order by CreatedDate desc";

        //EXEC [usp_UserOwnPage_Retrieve_ByUserID] 115 , 1  

        // strSQL = "EXEC [usp_UserOwnPage_Retrieve_ByUserID] " + Convert.ToInt32(Session["ClientID"]) + "," + vButtonText;
        vButtonText = vButtonText.Replace("'", "''");

        strSQL = "EXEC  [usp_UserOwnPage_Retrieve_ByButtonName] " + Convert.ToInt32(Session["ClientID"]) + ",N'" + vButtonText + "'," + vButtonNo;

        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpUserContent = dbReader["UserPageContent"].ToString();
                //hidIncPlanID.Value = dbReader["PlanID"].ToString();
            }

        }
        else
        {
            tmpUserContent = "<br> No Content has been added yet. To Create, click on the Add the content";
        }

        dbConn.Close();

        // txtIncPlanContent.Value = tmpUserContent;
        lblUserContent.Text = tmpUserContent;



    }

}
