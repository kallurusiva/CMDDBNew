using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMSv3.DAL
{
    public class enquiry
    {

        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
       // DataSet ds;

        string dbString = ConfigurationSettings.AppSettings["CMSdb"].ToString();

        #endregion


        #region SqlConstants

            private const string SP_Insert_EnquiryData = "usp_Enquiry_InsertData";
   

        #endregion



         #region Functionality

        // Constructor to open the dbConnection 
        public enquiry()
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
        /// Function to insert record into tblEnquiry table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts and returns 1 if inserted else 0</remarks> 
        /// 
        public int InsertEnquiryData(CMSv3.Entities.Enquiry objEnquiry, int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_Insert_EnquiryData, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@eName", SqlDbType.NVarChar).Value = objEnquiry.Name;
                dbCmd.Parameters.Add("@eContactNo", SqlDbType.VarChar).Value = objEnquiry.ContactNo; ;
                dbCmd.Parameters.Add("@eEmail", SqlDbType.VarChar).Value = objEnquiry.Email; ;
                dbCmd.Parameters.Add("@eSubject", SqlDbType.NVarChar).Value = objEnquiry.Subject;
                dbCmd.Parameters.Add("@eBody", SqlDbType.NVarChar).Value = objEnquiry.Message;
                dbCmd.Parameters.Add("@CountryCode", SqlDbType.SmallInt).Value = objEnquiry.Countrycode;
                dbCmd.Parameters.Add("@eUserId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@enqType", SqlDbType.TinyInt).Value = objEnquiry.enquiryType;
                
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

#endregion


    }
}
