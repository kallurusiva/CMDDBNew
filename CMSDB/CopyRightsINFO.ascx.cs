using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.Entities;

public partial class CopyRightsINFO : System.Web.UI.UserControl
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    string strSQL = string.Empty;
   // CMSv3.Entities.ClientData objClientData = new CMSv3.Entities.ClientData();


    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["CopyRightsInfo"] == null) || (Session["CopyRightsInfo"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        if (!IsPostBack)
        {
            //LoadCopyRightsInfo();
            dvCopyRights.InnerText = Session["CopyRightsInfo"].ToString();

            //objClientData = (CMSv3.Entities.ClientData)Session["ClientData"];
            //dvCopyRights.InnerText = objClientData.CopyRightsInfo;

        }

    }

    protected void LoadCopyRightsInfo()
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            strSQL = "select CopyRightsInfo from tblHomePageSettings where userid = " + Convert.ToInt32(Session["ClientID"]);

            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    dvCopyRights.InnerText = dbReader["CopyRightsInfo"].ToString();

                }

            }




        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            dbConn.Close();
        }


    }
}
