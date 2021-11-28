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
    public class MbMainIFM
    {
        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataReader dbReader;
        protected SqlDataAdapter dbAdap;


        protected SqlConnection IFM_dbConn;


        DataSet ds;



        String dbConnString = ConfigurationSettings.AppSettings["CMSdb"].ToString();
        string strSQL = string.Empty;
        string IFM_dbString = ConfigurationSettings.AppSettings["IFMdb"].ToString();


        public MbMainIFM()
        {

            try
            {
                dbConn = new SqlConnection(dbConnString);
                IFM_dbConn = new SqlConnection(IFM_dbString);
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




     
        


    }
}
