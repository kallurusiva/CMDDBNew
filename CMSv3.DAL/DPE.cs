using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace CMSv3.DAL
{
    public class DPE
    {

        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;

        string dbString = ConfigurationSettings.AppSettings["DPEdb"].ToString();



        #endregion


        #region Functionality

        // Constructor to open the dbConnection 
        public DPE()
        {

            try
            {
                dbConn = new SqlConnection(dbString);
                //dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Function to Validate user login for DPE Customers 
        /// </summary>
        /// <param name="sc">DPE</param>
        /// <returns>integer</returns>
        /// <remarks>This function to validate user login for DPE Customers  </remarks> 
        /// 
        public DataSet DPE_ValidateLoginStatus(string vMobileLoginID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[USP_DPE_ValidateLoginStatus]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;

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



        public DataSet DPE_GetDetails(string vMobileLoginID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[USP_DPE_GetDetailsByMobileLoginID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;

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



        public DataSet DPE_Retrieve_EMSContent(String vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_DPE_EMailSystem_ByUserID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
               
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



        public DataSet DPE_GetUserForEMS(string vSearchQuery)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_DPE_GetEmailSetupListing]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vSearchQuery", SqlDbType.VarChar).Value = vSearchQuery;

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


        public int DPE_InsertUpdate_EMSContent(string vAdminID, string vAdminPwd, string vEnquiryID, string vEnquiryPwd, string vHttpUrlLink, long vMobileLoginID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_DPE_EMS_InsertUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vAdminID", SqlDbType.VarChar).Value = vAdminID;
                dbCmd.Parameters.Add("@vAdminPwd", SqlDbType.VarChar).Value = vAdminPwd;
                dbCmd.Parameters.Add("@vEnquiryID", SqlDbType.VarChar).Value = vEnquiryID;
                dbCmd.Parameters.Add("@vEnquiryPwd", SqlDbType.VarChar).Value = vEnquiryPwd;
                dbCmd.Parameters.Add("@vHttpUrlLink", SqlDbType.VarChar).Value = vHttpUrlLink;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.BigInt).Value = vMobileLoginID;

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




        #endregion
    }

}
