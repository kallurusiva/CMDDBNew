using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMSv3.DAL
{
    public class gAdSense
    {

        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;

        string dbString = ConfigurationSettings.AppSettings["CMSdb"].ToString();



        #endregion


        #region SqlConstants

       // private const string SP_InsertOwnButton = "usp_OwnButton_InsertData";
       //  private const string SP_Update_OwnButton_ByUserId = "usp_OwnButton_Update_ByUserID";
        
        #endregion


                #region Functionality

        // Constructor to open the dbConnection 
        public gAdSense()
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

        /// <summary>
        /// Function to Insert AdSense Content For USER
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts the Adsense Content for the USer </remarks> 
        /// 
        public int InsertUpdate_AdSenseContent(string vAdSenseID, string vAdSensePwd,string vAdsCode, int vUserID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_AdSense_InsertUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vAdSenseID", SqlDbType.VarChar).Value = vAdSenseID;
                dbCmd.Parameters.Add("@vAdSensePwd", SqlDbType.VarChar).Value = vAdSensePwd;
                dbCmd.Parameters.Add("@vAdsCode", SqlDbType.VarChar).Value = vAdsCode;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
               
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



        public bool Update_AdSenseContent(string vAdSenseID, string vAdSensePwd, string vAdsCode, int vUserID)
        {
            int rowCount;

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("USP_AdSense_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vAdSenseID", SqlDbType.VarChar).Value = vAdSenseID;
                dbCmd.Parameters.Add("@vAdSensePwd", SqlDbType.VarChar).Value = vAdSensePwd;
                dbCmd.Parameters.Add("@vAdsCode", SqlDbType.VarChar).Value = vAdsCode;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
               
                rowCount = dbCmd.ExecuteNonQuery();

                if (rowCount > 0)
                    return true;
                else
                    return false;



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




        public DataSet Retrieve_AdSenseContent(int vUserID,string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_AdSense_RetrieveByUID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
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



        public int Delete_AdSenseContent(int vAdSenseID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("usp_AdSense_DeleteByUID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vAdSenseID", SqlDbType.Int).Value = vAdSenseID;



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
