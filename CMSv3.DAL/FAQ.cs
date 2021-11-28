using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace CMSv3.DAL
{
    public class FAQ
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

        private const string SP_InsertFaqsData = "usp_Faqs_InsertData";
        private const string SP_UpdateFaqs_ByUserId = "usp_Faqs_Update_ByUserID";
        private const string SP_DeleteFaqs_ByUserId = "usp_Faqs_Delete_ByUserID";
        private const string SP_DeleteFaqs_ByUserId_Multiple = "usp_Faqs_Delete_ByUserID_Multiple";
        private const string SP_RetrieveAll_Faqs_ByUserID = "usp_Faqs_Retrieve_ByUserID";

        private const string SP_Retrieve_FaqSummary = "usp_Faq_Retreive_Summary";


        private const string SP_USER_GET_Faqs_ByUserID = "usp_USER_Faqs_GET_ByUserID";


        #endregion


        #region Functionality

        // Constructor to open the dbConnection 
        public FAQ()
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
        /// Function to insert Faq record into tblFaq table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts the Faq record and returns 1 if inserted else 0</remarks> 
        /// 
        public int InsertFaqData(string vFaqQuestion, string vFaqAnswer, int vUserID, bool vActive, int vSelLanguage)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_InsertFaqsData, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@FaqQuestion", SqlDbType.NVarChar).Value = vFaqQuestion;
                dbCmd.Parameters.Add("@FaqAnswer", SqlDbType.NVarChar).Value = vFaqAnswer;
                dbCmd.Parameters.Add("@FaqUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = vActive;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vSelLanguage;



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



        public DataSet Retrieve_AllFaqByUserID(int mUserId, string mRetreiveType, int vSelLanguage)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_Faqs_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@FaqUserID", SqlDbType.Int).Value = mUserId;
                dbCmd.Parameters.Add("@RtrType", SqlDbType.VarChar).Value = mRetreiveType;
                dbCmd.Parameters.Add("@LgType", SqlDbType.VarChar).Value = vSelLanguage;

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

        public bool UpdateFaqData(string vQuestion, string vAnswer, int vUserID, int vFaqID, bool vActive, int vSelLanguage)
        {
            int rowCount;

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_UpdateFaqs_ByUserId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@FaqQuestion", SqlDbType.NVarChar).Value = vQuestion;
                dbCmd.Parameters.Add("@FaqAnswer", SqlDbType.NVarChar).Value = vAnswer;
                dbCmd.Parameters.Add("@FaqUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@FaqID", SqlDbType.Int).Value = vFaqID;
                dbCmd.Parameters.Add("@FaqActive", SqlDbType.Bit).Value = vActive;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vSelLanguage;


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


        public bool DeleteFaqData(int vUserId, int vFaqID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_DeleteFaqs_ByUserId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@FaqId", SqlDbType.Int).Value = vFaqID;

                int rowCount = dbCmd.ExecuteNonQuery();

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

        public bool DeleteFaqData_Multiple(int vUserId, string vFaqIDs)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_DeleteFaqs_ByUserId_Multiple, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@FaqIds", SqlDbType.VarChar).Value = vFaqIDs;

                int rowCount = dbCmd.ExecuteNonQuery();

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



        public DataSet Retrieve_FaqSUmmary_ByUserID(int mUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Retrieve_FaqSummary, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = mUserId;
                
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
        
        #endregion



        #region  USER related functionality

        public DataSet User_GETAllFaq_ByUserID(int mUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_USER_GET_Faqs_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@FaqUserID", SqlDbType.Int).Value = mUserId;
               
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


        #endregion




    }
}
