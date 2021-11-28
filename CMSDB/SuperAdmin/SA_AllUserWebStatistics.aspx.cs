using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


public partial class SuperAdmin_SA_AllUserWebStatistics : System.Web.UI.Page
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    protected void Page_Load(object sender, EventArgs e)
    {

        // Declare our variables
        String[] sMonths = new String[24];
        Int32[] iMonthCount = new Int32[24];
        int iYear;
        int iMonth;
        int iDay; 
        int iCount;
        int i = 0;
        

        string strSQL = "EXEC [usp_WebSts_ByMonthWise_AllUsers]";

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();


            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {

                    iYear = Convert.ToInt32(dbReader["Year"].ToString());
                    iMonth = Convert.ToInt32(dbReader["Month"].ToString());
                    iCount = Convert.ToInt32(dbReader["LogCount"].ToString());

                    sMonths[i] = CommonFunctions.GetMonthName(iMonth,false) + ", " + iYear.ToString();
                    iMonthCount[i] = iCount;
                    i++;
                }
            }
        }
            catch(Exception ex)
        {
                throw ex;
            }
        finally{
            dbConn.Close();
        }


        // Set our axis values
        MyBarChart1.YAxisValues = iMonthCount;

        // Set our axis strings
        MyBarChart1.YAxisItems = sMonths;

        // Provide a title
       // MyBarChart1.ChartTitle = "<b>Breakdown of Users Visting our Site:</b>";

        // Provide an title for the X-Axis
        MyBarChart1.XAxisTitle = "(No. of Users Logged in Month-Wise.)";   

        //*-***************-----------**********************---------------

        // Creating chart for Day wise 
         strSQL = "EXEC [usp_WebSts_ByDayWise_AllUsers]";

         iYear = 0;
         iMonth = 0;
         iDay = 0;
         iCount = 0;
         String[] DMonths = new String[365];
         Int32[] dMonthCount = new Int32[365];
         
         try
         {
             dbConn.Open();
             dbCmd = new SqlCommand(strSQL, dbConn);
             dbReader = dbCmd.ExecuteReader();


             if (dbReader.HasRows)
             {
                 while (dbReader.Read())
                 {

                     iYear = Convert.ToInt32(dbReader["Year"].ToString());
                     iMonth = Convert.ToInt32(dbReader["Month"].ToString());
                     iDay = Convert.ToInt32(dbReader["Day"].ToString());
                     iCount = Convert.ToInt32(dbReader["LogCount"].ToString());

                     DMonths[i] = iDay.ToString() + " " + CommonFunctions.GetMonthName(iMonth, true) + ", " + iYear.ToString();
                     dMonthCount[i] = iCount;
                     i++;
                 }
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

        
         // Set our axis values
         MyBarChart_Day.YAxisValues = dMonthCount;

         // Set our axis strings
         MyBarChart_Day.YAxisItems = DMonths;

         // Provide a title
        // MyBarChart_Day.ChartTitle = "<b>Breakdown of Users Visting our Site:  Daily wise</b>";

         // Provide an title for the X-Axis
         MyBarChart_Day.XAxisTitle = "(No. of Users Logged in Daily -Wise.)";   




    }

}
