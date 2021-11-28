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
    public class PayPal
    {
        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataReader dbReader;
        protected SqlDataAdapter dbAdap;


        protected SqlConnection IFM_dbConn;


        DataSet ds;
        String dbConnString = ConfigurationSettings.AppSettings["GsPayPalDb"].ToString();
        string strSQL = string.Empty;

        public PayPal()
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

  

       public DataSet EB_PayPal_RetrieveTX(int vUserID , string vSearchQuery)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Retreive_PayPalTx]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchBy", SqlDbType.VarChar).Value = vSearchQuery;
                
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



       public int EB_PostPaymentDetails_Update(String vTxID, String PytStatus, String PytAmt,  String PytCurrency, String vUniqueID, String vItemNumber, String vCustomMsg)
       {

           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();


               dbCmd = new SqlCommand("[usp_PostDetails_Update]", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vTxID", SqlDbType.VarChar).Value = vTxID;
               dbCmd.Parameters.Add("@PytStatus", SqlDbType.VarChar).Value = PytStatus;
               dbCmd.Parameters.Add("@PytAmt", SqlDbType.VarChar).Value = PytAmt;
               dbCmd.Parameters.Add("@PytCurrency", SqlDbType.VarChar).Value = PytCurrency;
               dbCmd.Parameters.Add("@vUniqueID", SqlDbType.VarChar).Value = vUniqueID;
               dbCmd.Parameters.Add("@vItemNumber", SqlDbType.VarChar).Value = vItemNumber;
               dbCmd.Parameters.Add("@vCustomMsg", SqlDbType.VarChar).Value = vCustomMsg;
               
             

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



       public DataSet EB_PayPal_RetrieveDetailsByUniqueID(String vUniqueID,String vItemNumber, int vUserID)
       {
           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();

               dbCmd = new SqlCommand("[usp_EB_Retreive_PayPalTx_ByUniqueID]", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vUniqueID", SqlDbType.VarChar).Value = vUniqueID;
               dbCmd.Parameters.Add("@vItemNumber", SqlDbType.VarChar).Value = vItemNumber;
               dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
               

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
