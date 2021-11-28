using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_TestEditor : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL;
    string tmpIncPlan;
    
    


    protected void Page_Load(object sender, EventArgs e)
    {
        FCKeditor1.BasePath = "~/OtherUtils/fckeditor/";
        FCKeditor1.ImageBrowserURL = "~/Images/";

        if(!IsPostBack)
        {

            dbConn = new SqlConnection(GlobalVar.GetDbConnString);
            dbConn.Open();

            strSQL = "Select top 1 PlanData,UserID from tblIncentivePlan order by PlanID desc"; 
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();
            //int rowCount = dbCmd.ExecuteNonQuery();
            
            if(dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    tmpIncPlan = dbReader["PlanData"].ToString();
                }

            }

            dbConn.Close();
            lblPlan.Text = tmpIncPlan;

        }

     }

    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string tmpstr = FCKeditor1.Value;
        tmpstr = tmpstr.Replace("'", "''");


        //int inStatus;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        strSQL = "Insert into tblIncentivePlan (PlanData,UserID) values (N'" + tmpstr + "',101)";
        dbCmd = new SqlCommand(strSQL, dbConn);
        int rowCount = dbCmd.ExecuteNonQuery();

        dbConn.Close();

        //if (rowCount >= 1)
        //    inStatus = 1;
        //else
        //    inStatus = -1;


    }
}
