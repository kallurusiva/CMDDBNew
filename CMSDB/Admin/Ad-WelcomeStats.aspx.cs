using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Data.SqlClient;




public partial class Admin_Ad_WelcomeStats : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        // Set series chart type
        Chart1.Series["Series1"].ChartType = SeriesChartType.Bar;

        // Set series point width
        Chart1.Series["Series1"]["PointWidth"] = "0.6";

        // Show chart with right-angled axes
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = true;

        // Show columns as clustered
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = false;

        // Show X axis end labels
        Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = true;

        // Set rotational angles
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;


        // Initialize a connection string    
        SqlConnection dbConn;
        SqlCommand dbCmd;
        SqlDataReader dbReader;
        //SqlDataAdapter dbAdap;
        //DataSet ds;

        String tmpUserID = "111";
        DateTime tmpCurrDate = DateTime.Now; 

        

        

        // Define the database query    
        String strSQL = "EXEC [usp_Mb_Stats_DayWise] " + tmpUserID + "," + (tmpCurrDate.Month) + "," + tmpCurrDate.Year;

        // Create a database connection object using the connection string    
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        // Create a database command on the connection using query    
        dbConn.Open();

        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        

        // Since the reader implements IEnumerable, pass the reader directly into
        //   the DataBind method with the name of the Column selected in the query    
        Chart1.Series["Series1"].Points.DataBindXY(dbReader, "Day", dbReader, "Logcount");

        dbReader.Close();


        //dbCmd = new SqlCommand(strSQL, dbConn);

        //dbAdap = new SqlDataAdapter(dbCmd);
        //ds = new DataSet();
        //dbAdap.Fill(ds);

        //WebChartControl1.DataSource = ds;
        //WebChartControl1.SeriesDataMember = "Day";
        //WebChartControl1.SeriesTemplate.ArgumentDataMember = "Logcount";
        //WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Logcount" });
        //WebChartControl1.SeriesTemplate.View = new SideBySideBarSeriesView();
        //WebChartControl1.DataBind(); 
       

        // Close the reader and the connection
      
        dbConn.Close();



    }
}
