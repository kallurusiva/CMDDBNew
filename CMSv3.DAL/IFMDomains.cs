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
    public class IFMDomains
    {
        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataReader dbReader;
        protected SqlDataAdapter dbAdap;


        protected SqlConnection IFM_dbConn;
        protected SqlCommand IFM_dbCmd;
        protected SqlDataAdapter IFM_dbAdap; 


        DataSet ds;



        String dbConnString = ConfigurationSettings.AppSettings["IFMdb"].ToString();
        string strSQL = string.Empty;
      

        public IFMDomains()
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

  

       public DataSet Retrieve_AnchorDomains(string vSearchQuery)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_AncDomains_RetrieveALL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchQuery;
                
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


       public DataSet Retrieve_AncDomainCategories(string vSearchQuery)
       {
           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();

               dbCmd = new SqlCommand("usp_AncDomainCategories_RetrieveALL", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchQuery;

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


       public int Insert_AncDomainCategory(string vCategoryName)
       {

           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();


               dbCmd = new SqlCommand("usp_AncDomains_AddCategory", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vCategoryName", SqlDbType.NVarChar).Value = vCategoryName;
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


       public int Update_AncDomainCategory(string vCategoryName,int vCategoryId)
       {

           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();


               dbCmd = new SqlCommand("usp_AncDomains_UpdateCategory", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vCategoryName", SqlDbType.NVarChar).Value = vCategoryName;
               dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = vCategoryId;
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


       public int Delete_AncDomainCategory(int vCategoryId)
       {

           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();


               dbCmd = new SqlCommand("usp_AncDomains_DeleteCategory", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = vCategoryId;
              


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


       public int Update_AnchorDomains(int vAnchorID, string vAnchorDomain, int vCategoryId, string vSampleURL, bool vActive)
       {

           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();


               dbCmd = new SqlCommand("usp_AnchorDomains_Update", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vTid", SqlDbType.Int).Value = vAnchorID;
               dbCmd.Parameters.Add("@vAnchorDomain", SqlDbType.NVarChar).Value = vAnchorDomain;
               dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = vCategoryId;
               dbCmd.Parameters.Add("@vSampleURL", SqlDbType.NVarChar).Value = vSampleURL;
               dbCmd.Parameters.Add("@vActive", SqlDbType.Bit).Value = vActive;
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


       public int Delete_AnchorDomains(int vAnchorID)
       {

           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();


               dbCmd = new SqlCommand("usp_AnchorDomains_Delete", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vTid", SqlDbType.Int).Value = vAnchorID;



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

       public int Insert_AnchorDomains(string vAnchorDomain, string vSampleURL,int vCategoryID, bool vActive)
       {

           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();


               dbCmd = new SqlCommand("usp_AnchorDomains_Insert", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vAnchorDomain", SqlDbType.VarChar).Value = vAnchorDomain;
               dbCmd.Parameters.Add("@vSampleURL", SqlDbType.VarChar).Value = vSampleURL;
               dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = vCategoryID;
               dbCmd.Parameters.Add("@vActive", SqlDbType.Bit).Value = vActive;

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




         public DataSet Retrieve_CreditCardPurchaseInfo(String vCurrencyCode, String vProductName, String vMobileNo)
       {
           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();
               dbCmd = new SqlCommand("USP_Retrieve_CreditCardPurchaseInfo", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vCurrencyCode", SqlDbType.VarChar).Value = vCurrencyCode;
               dbCmd.Parameters.Add("@vProductName", SqlDbType.VarChar).Value = vProductName;
               dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobileNo;
          
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

       public DataSet Retrieve_PayPalHistory(String vPayPalID)
       {
           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();
               dbCmd = new SqlCommand("USP_RetrievePayPalHistory", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vPayPalId", SqlDbType.VarChar).Value = vPayPalID;

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


        public String GetRefMobileNumber(String vUserName)
       {
            

            try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();
               dbCmd = new SqlCommand("USP_Verify_SpecialLoginName_4SMSSystem", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vUserName;

               string mReturnedMobileNo = string.Empty;

               mReturnedMobileNo = dbCmd.ExecuteScalar().ToString();
               

               return mReturnedMobileNo;

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
