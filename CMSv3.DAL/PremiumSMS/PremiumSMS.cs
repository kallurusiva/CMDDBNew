using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMSv3.DAL
{
    public class PremiumSMS
    {

        #region variables

        protected SqlConnection IFM_dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;

        string IFM_dbString = ConfigurationSettings.AppSettings["IFMdb"].ToString();



        #endregion


        #region SqlConstants

       // private const string SP_InsertOwnButton = "usp_OwnButton_InsertData";
       //  private const string SP_Update_OwnButton_ByUserId = "usp_OwnButton_Update_ByUserID";
        
        #endregion


                #region Functionality

        // Constructor to open the dbConnection 
        public PremiumSMS()
        {

            try
            {
                IFM_dbConn = new SqlConnection(IFM_dbString);
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet Retrieve_PS_Keyword(string vMobile, string vSearchSql)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_RetrieveKeywordProfitSharing]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vSearchSql", SqlDbType.VarChar).Value = vSearchSql;

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
                IFM_dbConn.Close();
            }

        }



        public DataSet Retrieve_PS_ByKeywordScode(string vKeyword, string vShortcode)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_PS_ByKeywordScode]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                dbCmd.Parameters.Add("@vShortcode", SqlDbType.VarChar).Value = vShortcode;

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
                IFM_dbConn.Close();
            }

        }



        public DataSet Retrieve_PS_ByOperator(string vMonth, string vYear, string vKeyword, string vShortcode)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_PS_ByOperator]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMonth", SqlDbType.VarChar).Value = vMonth;
                dbCmd.Parameters.Add("@vYear", SqlDbType.VarChar).Value = vYear;
                dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                dbCmd.Parameters.Add("@vShortcode", SqlDbType.VarChar).Value = vShortcode;

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
                IFM_dbConn.Close();
            }

        }



        public DataSet Retrieve_PS_Monthly(string vMobile)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_RetrievePS_Monthly]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobile;
                //dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                //dbCmd.Parameters.Add("@vShortcode", SqlDbType.VarChar).Value = vShortCode;

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
                IFM_dbConn.Close();
            }

        }


        public DataSet Retrieve_PS_MonthlyDetails(string vMobile,String vKeyword,String vShortCode,int vMonth,int vYear)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_RetrievePS_MonthlyDetails]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                dbCmd.Parameters.Add("@vShortcode", SqlDbType.VarChar).Value = vShortCode;
                dbCmd.Parameters.Add("@vMonth", SqlDbType.VarChar).Value = vMonth;
                dbCmd.Parameters.Add("@vYear", SqlDbType.VarChar).Value = vYear;

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
                IFM_dbConn.Close();
            }

        }


        

        public DataSet Retrieve_PS_PurchasesMy(string vMobile)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_PSMS_PurchasesMY]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobile;
                //dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                //dbCmd.Parameters.Add("@vShortcode", SqlDbType.VarChar).Value = vShortCode;

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
                IFM_dbConn.Close();
            }

        }



        public DataSet Retrieve_PS_PurchasesALL(string vMobile)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_PSMS_PurchasesALL]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobile;
                //dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                //dbCmd.Parameters.Add("@vShortcode", SqlDbType.VarChar).Value = vShortCode;

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
                IFM_dbConn.Close();
            }

        }


        public DataSet Retrieve_PS_KeywordsList(string vMobile)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_PSMS_KeywordsList]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobile;
                //dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                //dbCmd.Parameters.Add("@vShortcode", SqlDbType.VarChar).Value = vShortCode;

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
                IFM_dbConn.Close();
            }

        }


        public DataSet Retrieve_PS_GetUserDetails(string vMobile)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("usp_Retrieve_PSMS_UserProfile", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobile;


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
                IFM_dbConn.Close();
            }

        }


        public DataSet Retrieve_PS_ShowPremiumInfo()
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_PSMS_ShowPremiumInfo]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
               

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
                IFM_dbConn.Close();
            }

        }

        public DataSet Retrieve_PS_ShowFAQList()
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_PSMS_ShowFaqList]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;


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
                IFM_dbConn.Close();
            }

        }


        public DataSet Retrieve_PS_ShowNewsList(string vSearchSql)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_PSMS_ShowNewList]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vSearchSql", SqlDbType.VarChar).Value = vSearchSql;


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
                IFM_dbConn.Close();
            }

        }


        public int Retrieve_PS_CheckAccess(string vMobile)
        {
            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_PS_CheckAccess]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;
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
                IFM_dbConn.Close();
            }

        }




#endregion


    }
}
