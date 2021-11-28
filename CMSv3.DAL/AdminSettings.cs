using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMSv3.DAL
{
    public class AdminSettings
    {


        #region ----- variables

            protected SqlConnection dbConn;
            protected SqlCommand dbCmd;
            protected SqlDataAdapter dbAdap;
            protected SqlDataReader dbReader;
            DataSet ds;
           // DataTable dt;

            string dbConnString = ConfigurationSettings.AppSettings["CMSdb"].ToString();


        #endregion

        
        #region ---- SqlConstants

            private const string SP_Insert_HomepageSettings_Data = "usp_Settings_Insert_HomePageData";
            private const string SP_Insert_MainMenuLinks_Data = "usp_Settings_Insert_MainMenuLinks";
            private const string SP_IsExists_MainMenuLink = "usp_Settings_isExists_MainMenuLink";

        

            private const string SP_UpdateTestimonial_ByUserId = "usp_Testimonial_Update_ByUserID";
            private const string SP_DeleteTestimonial_ByUserId = "usp_Testimonial_Delete_ByUserID";
            private const string SP_DeleteTestimonial_ByUserId_Multiple = "usp_Testimonial_Delete_ByUserID_Multiple";

        
            private const string SP_RetrieveAll_TopMenuLinks_ByUserID = "usp_Settings_GetTopMenuLinks";
            private const string SP_RetrieveAll_CommApps_ByUserID = "usp_Settings_GetCommApps";
        
        


        #endregion


        public AdminSettings()
        {
        try
            {
                dbConn = new SqlConnection(dbConnString);
                //dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public DataSet GetAll_TopmenuLinks()
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_TopMenuLinks_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                //dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserId;

                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
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


        public DataSet GetAll_CommApps()
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_CommApps_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                //dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserId;

                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
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


        public int IsExists_MainMenuLink(string vMenuLinkName, int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_IsExists_MainMenuLink, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@MenuLinkName", SqlDbType.NVarChar).Value = vMenuLinkName;
                dbCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = vUserId;

                int recExists = dbCmd.ExecuteNonQuery();
                return recExists;



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


        public int Insert_MainMenuLInks(string vMenuLinkName, string vMenuLinkURL, int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_Insert_MainMenuLinks_Data, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@MenuLinkName", SqlDbType.NVarChar).Value = vMenuLinkName;
                dbCmd.Parameters.Add("@MenuLinkURL", SqlDbType.VarChar).Value = vMenuLinkURL;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserId;
                int inStatus = dbCmd.ExecuteNonQuery();
                return inStatus;



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


        public int Insert_AdminSettings(CMSv3.Entities.AdminSettings vObjAdminSettings)
        {
           
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_Insert_HomepageSettings_Data, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@CompanyInfo", SqlDbType.NVarChar).Value = vObjAdminSettings.CompanyInfo;
                dbCmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = vObjAdminSettings.CompanyName;
                dbCmd.Parameters.Add("@CopyRightInfo", SqlDbType.NVarChar).Value = vObjAdminSettings.CopyRightInfo;

                dbCmd.Parameters.Add("@ShowEvents", SqlDbType.Bit).Value = vObjAdminSettings.ShowEvents;
                dbCmd.Parameters.Add("@ShowNews", SqlDbType.Bit).Value = vObjAdminSettings.ShowNews;

                dbCmd.Parameters.Add("@TopMenuLinks", SqlDbType.VarChar).Value = vObjAdminSettings.TopMenuLinks;
                dbCmd.Parameters.Add("@CommAppItems", SqlDbType.VarChar).Value = vObjAdminSettings.CommAppsToShow;
                dbCmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = vObjAdminSettings.ModifiedBy;

                dbCmd.Parameters.Add("@Logo_ImgType", SqlDbType.Int).Value = vObjAdminSettings.Logo_ImgType;
                dbCmd.Parameters.Add("@Logo_ImgPath", SqlDbType.VarChar).Value = vObjAdminSettings.Logo_ImgPath;
                dbCmd.Parameters.Add("@Logo_ImgName", SqlDbType.VarChar).Value = vObjAdminSettings.Logo_ImgName;
                dbCmd.Parameters.Add("@Logo_ImgActualName", SqlDbType.VarChar).Value = vObjAdminSettings.Logo_ImgActualName;
                
                dbCmd.Parameters.Add("@Banner_ImgType", SqlDbType.Int).Value = vObjAdminSettings.Banner_ImgType;
                dbCmd.Parameters.Add("@Banner_ImgPath", SqlDbType.VarChar).Value = vObjAdminSettings.Banner_ImgPath;
                dbCmd.Parameters.Add("@Banner_ImgName", SqlDbType.VarChar).Value = vObjAdminSettings.Banner_ImgName;
                dbCmd.Parameters.Add("@Banner_ImgActualName", SqlDbType.VarChar).Value = vObjAdminSettings.Banner_ImgActualName;


                int rowcount = dbCmd.ExecuteNonQuery();
                return rowcount;


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

        /// <summary>
        /// Function to Insert Web Error Log
        /// </summary>
        /// <param name="yb">YBproject</param>
        /// <returns>int</returns>
        public int Insert_WEB_ErrorLog(string vURL, string vSource, string vMessage, string vStackTrace, string vBaseException)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("USP_ERROR_Insert_ErrorLog", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vURL", SqlDbType.VarChar).Value = vURL;
                dbCmd.Parameters.Add("@vSource", SqlDbType.VarChar).Value = vSource;
                dbCmd.Parameters.Add("@vMessage", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@vStackTrace", SqlDbType.VarChar).Value = vStackTrace;
                dbCmd.Parameters.Add("@vBaseException", SqlDbType.VarChar).Value = vBaseException;

                int status = dbCmd.ExecuteNonQuery();
                return status;



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




        public DataSet GetSummary_ByTable(int vUserID, string vTable, string vColumn)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_TableItem_RetreiveSummary_New]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vTable", SqlDbType.VarChar).Value = vTable;
                dbCmd.Parameters.Add("@vColumn", SqlDbType.VarChar).Value = vColumn;
                    

                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
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

    }
}
