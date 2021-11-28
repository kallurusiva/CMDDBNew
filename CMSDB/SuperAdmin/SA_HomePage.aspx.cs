using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CMSv3.BAL;

public partial class SuperAdmin_SA_HomePage : System.Web.UI.Page
{

    CMSv3.BAL.User objUser = new CMSv3.BAL.User();
    DataSet ds;
    DataTable dt_Web = new DataTable();
    DataTable dt_Email = new DataTable();
    DataTable dt_Visits = new DataTable();
    DataTable dt_Domain = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 


      

        if (!IsPostBack)
        {


            LoadUsersData();

        }


       // ltrHomeSummary.Text = Resources.LangResources.User + " " + Resources.LangResources.Summary;
        ltrHomeSummary.Text = "Dashboard";
        lblCurrMonth.Text = CommonFunctions.GetMonthName(DateTime.Now.Month, false) + " - " + DateTime.Now.Year.ToString();


       
     }


    protected void LoadUsersData()
    {

        string mWeb30Cnt = string.Empty;
        string mWeb10Cnt = string.Empty;

        ds = objUser.Retrieve_AllUser_Summary();


        dt_Web = ds.Tables[0];          // Web30 and web10 users
        dt_Email = ds.Tables[1];        // Emails summary
        dt_Visits = ds.Tables[2];       // Visits summary
        dt_Domain = ds.Tables[3];       // Domain summary


        //Web 30- 10 
        foreach (DataRow mRow in dt_Web.Rows)
        {
            if (mRow["UserDomainType"].ToString() == "WEB30")
            {
                mWeb30Cnt = mRow["WbCount"].ToString();
                //lblWeB30.Text = mWeb30Cnt;
                lblWeb30.Text = mWeb30Cnt;
            }
            else if (mRow["UserDomainType"].ToString() == "WEB10")
            {
                mWeb10Cnt = mRow["WbCount"].ToString();
                //lblWeB10.Text = mWeb10Cnt;
                lblWEB10.Text = mWeb10Cnt;
            }

        }


        //Email Summary 

        foreach (DataRow eRow in dt_Email.Rows)
        {

            if (eRow["enqType"].ToString() == "1")
            {   
                lblContactUs.Text = eRow["eqCount"].ToString(); 
            }
            else if (eRow["enqType"].ToString() == "2")
            {   
                lblFreeSMS.Text = eRow["eqCount"].ToString();
            }


        }



        // Visits Summary 

        foreach (DataRow vRow in dt_Visits.Rows)
        {
            lblCurrMonthVisits.Text = vRow["ThisMonthCount"].ToString();
            lblTotalVisits.Text = vRow["TotalAccCount"].ToString();
        }


        // domain Requests.


        foreach (DataRow dRow in dt_Domain.Rows)
        {
            lblDomainRq.Text = dRow["PendingRequestsCount"].ToString();
            
        }



    }


}
