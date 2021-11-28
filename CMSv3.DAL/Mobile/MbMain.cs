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
    public class MbMain
    {
        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataReader dbReader;
        protected SqlDataAdapter dbAdap;


        protected SqlConnection IFM_dbConn;


        DataSet ds;



        String dbConnString = ConfigurationSettings.AppSettings["CMSdb"].ToString();
        String IFMConnString = ConfigurationSettings.AppSettings["IFMdb"].ToString();

        string strSQL = string.Empty;
       

        public MbMain()
        {

            try
            {
                dbConn = new SqlConnection(dbConnString);
                IFM_dbConn = new SqlConnection(IFMConnString); 
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }



        public DataSet RetrieveAll_MobiPageContent(int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                
                dbCmd = new SqlCommand("usp_mb_Retrieve_HomePage", dbConn);
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


        public DataSet RetrieveAll_MobiButtonsInfo()
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_mb_Retrieve_ButtonsInfo", dbConn);
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
                dbConn.Close();
            }



        }



        public DataSet Retrieve_SelectedButtonsByUserID(int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_Retrieve_SelBtnsByUserID_NEW]", dbConn);
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


        public int UpdateButtonSelection(int vUserId, string SelItemStr, string vTitle1, string vTitle2, int vTemplateID, bool vMwDetection)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_InsertUpdate_SelBtnsByUserID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vSelBtnsStr", SqlDbType.VarChar).Value = SelItemStr;
                dbCmd.Parameters.Add("@vTitle1", SqlDbType.VarChar).Value = vTitle1;
                dbCmd.Parameters.Add("@vTitle2", SqlDbType.VarChar).Value = vTitle2;
                dbCmd.Parameters.Add("@vTemplateID", SqlDbType.Int).Value = vTemplateID;
                dbCmd.Parameters.Add("@vMwDetection", SqlDbType.Bit).Value = vMwDetection; 



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



        public int UpdateTemplateSelection(int vUserId, string vTemplateCSS, string vTitle1, string vTitle2)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_InsertUpdate_Template]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vTemplateCSS", SqlDbType.VarChar).Value = vTemplateCSS;
                dbCmd.Parameters.Add("@vTitle1", SqlDbType.NVarChar).Value = vTitle1;
                dbCmd.Parameters.Add("@vTitle2", SqlDbType.NVarChar).Value = vTitle2;
    


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


        
        public DataSet Retrieve_SelectedTemplate(int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_Retrieve_Template]", dbConn);
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




        public DataSet Retrieve_ALLTemplates()
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_Template_RetreiveALL]", dbConn);
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
                dbConn.Close();
            }



        }




        public DataSet Retrieve_TrialPeriodInfo(int vUserId, DateTime vOLDtpStartDate)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_TrlPeriodInfo]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vOLDuserTPstartdate", SqlDbType.DateTime).Value = vOLDtpStartDate;
              
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

        public int CheckMobileWebPurchase(string vMobileNo)
        {

            try
            {

                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_MobileWeb_ChkPurchase]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileNo;
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


        public int CheckMobileWebAccess(string vMobileNo)
        {

            try
            {

                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_MobileWeb_ValidateAccess]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileNo;
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




    }
}
