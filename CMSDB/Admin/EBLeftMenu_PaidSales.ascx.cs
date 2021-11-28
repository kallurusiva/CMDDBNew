using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EBLeftMenu_PaidSales : System.Web.UI.UserControl
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    CMSv3.BAL.User BALobjUser = new CMSv3.BAL.User();
    string tmpUserType = string.Empty;
    string mlmStatusPack = string.Empty;
    string mlmCompleteStatus = string.Empty;
    string smsBalance = string.Empty;
    string subdomainstatus = string.Empty;
    string subdomainstoreidstatus = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        String tmpAdminLanguageCode = string.Empty;

        if (Session["MobileLoginID"] != null)
        {
            //get and set  the session details
            String mUserId = Session["MobileLoginID"].ToString().Replace("EB", "");
            string strSQL = "EXEC eSMS.dbo.uspT_getUserPackageType " + mUserId;

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
                        mlmStatusPack = dbReader["mlmStatus"].ToString();
                        mlmCompleteStatus = dbReader["completeStatus"].ToString();
                        smsBalance = dbReader["smsBalance"].ToString();
                        subdomainstatus = dbReader["subdomainStatus"].ToString();
                        subdomainstoreidstatus = dbReader["storeidStatus"].ToString();
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
        }

        if (mlmStatusPack == "0")
        {
            HyperLink1.Visible = false;
            HyperLink3.Visible = false;
            HyperLink4.Visible = false;
            HyperLink5.Visible = false;
            HyperLink6.Visible = false;
        }

    }
}