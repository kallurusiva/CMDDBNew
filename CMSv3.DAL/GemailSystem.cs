using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMSv3.DAL
{
    public class GemailSystem
    {

        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;

        string dbString = ConfigurationSettings.AppSettings["CMSdb"].ToString();



         // Constructor to open the dbConnection 
        public GemailSystem()
        {

            try
            {
                dbConn = new SqlConnection(dbString);
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public DataSet Retrieve_EMSContent(string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EMS_RetrieveDetails]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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



        /// <summary>
        /// Function to insert/Updates EMail System Content For USER
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function insert/Updates EMail System for the USer </remarks> 
        /// 
        public int InsertUpdate_EMSContent(string vAdminID, string vAdminPwd, string vEnquiryID, string vEnquiryPwd, string vHttpUrlLink, long vMobileLoginID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EMS_InsertUpdate]", dbConn);
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



        public int Check_EMS_Exists(string vMobileLoginID)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EMS_isExists]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;
                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();

                int MyResult = (int)dbCmd.Parameters["@Result"].Value;
                return MyResult;

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
