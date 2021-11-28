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
    public class News
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
        //-- Admin
        private const string SP_InsertNewsData = "usp_News_InsertData";
        private const string SP_UpdateNews_ByUserId = "usp_News_Update_ByUserID";
        private const string SP_DeleteNews_ByUserId = "usp_News_Delete_ByUserID";
        private const string SP_DeleteNews_ByUserId_Multiple = "usp_News_Delete_ByUserID_Multiple";
        private const string SP_RetrieveAll_News_ByUserID = "usp_News_Retrieve_ByUserID";

        //-- System
        private const string SP_Update_SystemNews_ByUserID = "usp_SystemNews_Update_ByUserID";



        //-- User
        private const string SP_USER_GET_News_ByUserID = "usp_USER_News_GET_ByUserID";

        
        

    #endregion


    #region Functionality

      // Constructor to open the dbConnection 
      public News()
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
      /// Function to insert News record into tblNews table
      /// </summary>
      /// <param name="sc">CMSV3</param>
      /// <returns>integer</returns>
      /// <remarks>This function inserts the News record and returns 1 if inserted else 0</remarks> 
      /// 
      public int InsertNewsData(string vNewstitle, string vNewsContent, bool vNewsDisplay, int vUserID, int mSelLanguage)
      {

          try
          {
              if (dbConn.State == ConnectionState.Closed)
                  dbConn.Open();


              dbCmd = new SqlCommand(SP_InsertNewsData,dbConn);
              dbCmd.CommandType = CommandType.StoredProcedure;
              dbCmd.Parameters.Add("@NewsTitle", SqlDbType.NVarChar).Value = vNewstitle;
              dbCmd.Parameters.Add("@NewsContent", SqlDbType.NVarChar).Value = vNewsContent;
              dbCmd.Parameters.Add("@NewsDisplay", SqlDbType.Bit).Value = vNewsDisplay;
              dbCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = vUserID;
              dbCmd.Parameters.Add("@LgType", SqlDbType.Int).Value = mSelLanguage;

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


      public DataSet Retrieve_AllNewsByUserID(int mUserId, string mRetreiveType, int mSelLanguage)
      {
          try
          {
              if (dbConn.State == ConnectionState.Closed)
                  dbConn.Open();

              dbCmd = new SqlCommand(SP_RetrieveAll_News_ByUserID, dbConn);
              dbCmd.CommandType = CommandType.StoredProcedure;
              dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = mUserId;
              dbCmd.Parameters.Add("@RtrType", SqlDbType.VarChar).Value = mRetreiveType;
              dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = mSelLanguage;

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



       

      public bool UpdateNewsData(string vTitle, string vContent, int vUserID, int vNewsID, bool vActive, int mSelLanguage)
      {
          int rowCount;

          try
          {
              if (dbConn.State == ConnectionState.Closed)
                  dbConn.Open();

              dbCmd = new SqlCommand(SP_UpdateNews_ByUserId, dbConn);
              dbCmd.CommandType = CommandType.StoredProcedure;
              dbCmd.Parameters.Add("@NewsTitle", SqlDbType.NVarChar).Value = vTitle;
              dbCmd.Parameters.Add("@NewsContent", SqlDbType.NVarChar).Value = vContent;
              dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserID;
              dbCmd.Parameters.Add("@NewsID", SqlDbType.Int).Value = vNewsID;
              dbCmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = vActive;
              dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = mSelLanguage;

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


      public bool DeleteNewsData(int vUserId, int vNewsID)
      {

          try
          {
              if (dbConn.State == ConnectionState.Closed)
                  dbConn.Open();


              dbCmd = new SqlCommand(SP_DeleteNews_ByUserId, dbConn);
              dbCmd.CommandType = CommandType.StoredProcedure;
              dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
              dbCmd.Parameters.Add("@NewsId", SqlDbType.Int).Value = vNewsID;

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

    public bool DeleteNewsData_Multiple(int vUserId, string vNewsIDs)
      {

          try
          {
              if (dbConn.State == ConnectionState.Closed)
                  dbConn.Open();


              dbCmd = new SqlCommand(SP_DeleteNews_ByUserId_Multiple, dbConn);
              dbCmd.CommandType = CommandType.StoredProcedure;
              dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
              dbCmd.Parameters.Add("@NewsIds", SqlDbType.VarChar).Value = vNewsIDs;

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
        




        

      public bool Update_SystemNewsData(CMSv3.Entities.News vobjNews, bool vActive, int mSelLanguage)
      {
          int rowCount;

          try
          {
              if (dbConn.State == ConnectionState.Closed)
                  dbConn.Open();

              dbCmd = new SqlCommand(SP_Update_SystemNews_ByUserID, dbConn);
              dbCmd.CommandType = CommandType.StoredProcedure;
              dbCmd.Parameters.Add("@NewsTitle", SqlDbType.NVarChar).Value = vobjNews.NewsTitle;
              dbCmd.Parameters.Add("@NewsContent", SqlDbType.NVarChar).Value = vobjNews.NewsContent;
              dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vobjNews.NewsUserID;
              dbCmd.Parameters.Add("@NewsID", SqlDbType.Int).Value = vobjNews.NewsID;
              dbCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = vActive;
              dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = mSelLanguage;

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



    #endregion


    #region  USER related functionality


    /// <summary>
    /// Function to retrive all the News on the home page. 
    /// </summary>
    /// <param name="sc">CMSV3</param>
    /// <returns>bool</returns>
    /// <remarks>This function updates and returns 1 if inserted else 0</remarks> 
    /// 
    public DataSet User_GETAll_News_ByUserID(int mUserId)
    {
        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand(SP_USER_GET_News_ByUserID, dbConn);
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





    }
}
