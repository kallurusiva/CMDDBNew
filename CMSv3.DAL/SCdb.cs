using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data; 

namespace CMSv3.DAL
{
     public class SCdb
    {

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataReader dbReader;
        protected SqlDataAdapter dbAdap;

        DataSet ds;



        String dbConnString = ConfigurationSettings.AppSettings["SCdb"].ToString();
        string strSQL = string.Empty;

        public SCdb()
        {

            try
            {
                dbConn = new SqlConnection(dbConnString);
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        /// <summary>
        /// Function to User : Validate Keyword 
        /// </summary>
        /// <param name="SC">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to validate keyword</remarks> 
        ///

        public DataSet Check_KeywordAvailability(String vKeyword, String vShortcode)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("[USP_KeywordAvailability]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                dbCmd.Parameters.Add("@vShortCode", SqlDbType.VarChar).Value = vShortcode;
                //dbCmd.ExecuteNonQuery();
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
        /// Function to User : Validate Keyword 
        /// </summary>
        /// <param name="SC">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to request keyword</remarks> 

        public int ebook_KeywordRequest(String vKeyword, String vShortcode)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("[USP_Ebook_KeywordRequest]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                dbCmd.Parameters.Add("@vShortCode", SqlDbType.VarChar).Value = vShortcode;
                //dbCmd.ExecuteNonQuery();
                //dbAdap = new SqlDataAdapter(dbCmd);
                //ds = new DataSet();
                //dbAdap.Fill(ds);

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



    }
}
