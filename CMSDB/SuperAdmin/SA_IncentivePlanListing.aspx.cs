using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_IncentivePlanListing : System.Web.UI.Page 
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    String strSQL= string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 


        int vLangType =1;


        if (!IsPostBack)
        {
            if (Request.QueryString["LgType"] != null)
            {
                vLangType = Convert.ToUInt16(Request.QueryString["LgType"]);
               // ddlLanguage.SelectedValue = Convert.ToString(vLangType);
            }
           
            LoadData(vLangType);
        }

        tblMessageBar.Visible = false;
        LtrIncentivePlan.Text = Resources.LangResources.Incentiveplan;

    }


    protected void LoadData(int vLangType)
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        String tmpIncPlanContent = string.Empty;

        strSQL = "Select top 1 PlanID, PlanData,UserID from tblIncentivePlan where UserID = " + Convert.ToInt32(Session["saUserID"]) + " and LgType = " + vLangType + " order by CreatedDate desc"; 
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
        lblIncentivePlan.Text = tmpIncPlanContent;
            


    }





    //protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    int tmpSelLanguage = Convert.ToUInt16(ddlLanguage.SelectedValue);
    //    string CurrentPgName = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);

    //    switch (tmpSelLanguage)
    //    {
    //        case 1: Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
    //                break;
    //        case 2: Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
    //                break;
    //        default:Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
    //                break;
    //    }


    //}
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        //string CurrentPgName = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
        //string CurrentQuery = System.Web.HttpContext.Current.Request.Url.Query;

        String mLanguague = "1";
        

        if (Request.QueryString["LgType"] != null)
        {
            mLanguague = Request.QueryString["LgType"];
        }

        Response.Redirect("SA_IncentivePlanEdit.aspx?Lgtype=" + mLanguague + "&PlanID=" + hidIncPlanID.Value);
         
    }
}