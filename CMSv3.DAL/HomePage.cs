using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CMSv3.Entities;

namespace CMSv3.DAL
{
    public class HomePage
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
                            // This SP is used to retrieve all the data for Default Home Web PAge
        private const string SP_RetrieveAll_HomePageContent = "usp_RetrieveAll_HomePageSettings";
        private const string SP_RetrieveAll_TopMenuLInks = "usp_RetrieveAll_TopMenuLInks";
        private const string SP_insert_TopMenuLInks = "usp_TopMenuLInks_insert";

        private const string SP_insert_Languages = "usp_Languages_insert";
        private const string SP_Retreive_MasterCSS = "usp_Retreive_MasterCSS";
        
       
        #endregion


        #region Functionality


        // Constructor to open the dbConnection 
        public HomePage()
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


        public DataSet RetrieveAll_HomePageContent(int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_HomePageContent, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pUserID", SqlDbType.Int).Value = vUserId;

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


        public DataSet RetrieveAll_TopMenuLinks(int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_TopMenuLInks, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;

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


        public string GetMasterCSS(int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_Retreive_MasterCSS, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = vUserId;
                
                //int status = dbCmd.ExecuteNonQuery();
                //return status;
                string outMasterCSSName = string.Empty;

                dbReader = dbCmd.ExecuteReader();

                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {
                        outMasterCSSName = dbReader["MasterCSS"].ToString();
                    }
                }

                return outMasterCSSName;


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



        
        public int Insert_TopMenuLinkItem(string vLinkName, string vLinkURL, bool vActive)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_insert_TopMenuLInks, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@LinkName", SqlDbType.NVarChar).Value = vLinkName;
                dbCmd.Parameters.Add("@LinkURL", SqlDbType.VarChar).Value = vLinkURL;
                dbCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = vActive;

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



        public int Insert_LanguageItem(string vLangCode, string vLangName)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_insert_Languages, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@LangCode", SqlDbType.TinyInt).Value = Convert.ToInt16(vLangCode);
                dbCmd.Parameters.Add("@LangName", SqlDbType.NVarChar).Value = vLangName;
                //dbCmd.Parameters.Add("@Result", SqlDbType.Int).Value = vLangName;
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
