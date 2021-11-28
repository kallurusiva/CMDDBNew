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
    public class Events
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

            private const string SP_InsertEventsData = "usp_Events_InsertData";
            private const string SP_UpdateEvents_ByUserId = "usp_Events_Update_ByUserID";
            private const string SP_DeleteEvents_ByUserId = "usp_Events_Delete_ByUserID";
            private const string SP_DeleteEvents_ByUserId_Multiple = "usp_Events_Delete_ByUserID_Multiple";
            private const string SP_RetrieveAll_Events_ByUserID = "usp_Events_Retrieve_ByUserID";

            private const string SP_USER_GET_Events_ByUserID = "usp_USER_Events_GET_ByUserID";
        
            

        #endregion

        #region Functionality

        // Constructor to open the dbConnection 
        public Events()
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
        /// Function to insert record into tblEvents table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts and returns 1 if inserted else 0</remarks> 
        /// 
        public int InsertEventData(CMSv3.Entities.Events objEvnt, bool vActive, int vSelLanguage)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_InsertEventsData, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@evtTitle", SqlDbType.NVarChar).Value = objEvnt.EventTitle;
                dbCmd.Parameters.Add("@evtContent", SqlDbType.NVarChar).Value = objEvnt.EventContent;
                dbCmd.Parameters.Add("@evtUserId", SqlDbType.Int).Value = objEvnt.UserID;
                dbCmd.Parameters.Add("@evtDateFROM", SqlDbType.DateTime).Value = objEvnt.EventDateFROM;
                dbCmd.Parameters.Add("@evtDateTO", SqlDbType.DateTime).Value = objEvnt.EventDateTO;
                dbCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = vActive;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vSelLanguage;


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

        /// <summary>
        /// Function to Retrieves records from the tblEvents table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves all the records based on UserId and returns a Dataset</remarks> 
        /// 
        public DataSet RetrieveAllEvents_ByUserID(int vUserId, string mRetreiveType, int mSelectedLanguage)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_Events_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@evtUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@RtrType", SqlDbType.VarChar).Value = mRetreiveType;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = mSelectedLanguage;
                

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
        /// Function to update record into tblEvents table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>bool</returns>
        /// <remarks>This function updates and returns 1 if inserted else 0</remarks> 
        /// 
        public bool UpdateEventsData(CMSv3.Entities.Events objEvt, bool vActive, int vSelLanguage)
        {

            int rowCount;

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_UpdateEvents_ByUserId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@evtTitle", SqlDbType.NVarChar).Value = objEvt.EventTitle;
                dbCmd.Parameters.Add("@evtContent", SqlDbType.NVarChar).Value = objEvt.EventContent;
                dbCmd.Parameters.Add("@evtUserID", SqlDbType.Int).Value = objEvt.UserID;
                dbCmd.Parameters.Add("@eventID", SqlDbType.Int).Value = objEvt.EventID;
                dbCmd.Parameters.Add("@eventFrom", SqlDbType.DateTime).Value = objEvt.EventDateFROM;
                dbCmd.Parameters.Add("@eventTO", SqlDbType.DateTime).Value = objEvt.EventDateTO;
                dbCmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = vActive;
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



        /// <summary>
        /// Function to insert record into tblEvents table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts and returns 1 if inserted else 0</remarks> 
        /// 
        public bool DeleteEventsData(int vUserId, int vEventID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_DeleteEvents_ByUserId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@EventId", SqlDbType.Int).Value = vEventID;

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


        public bool DeleteEventsData_Multiple(int vUserId, string vEventIdsStr)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_DeleteEvents_ByUserId_Multiple, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@EventIds", SqlDbType.VarChar).Value = vEventIdsStr;

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

        #endregion



        #region  USER related functionality


        /// <summary>
        /// Function to retrive all the events on the home page. 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>bool</returns>
        /// <remarks>This function updates and returns 1 if inserted else 0</remarks> 
        /// 
        public DataSet User_GETAll_Events_ByUserID(int mUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_USER_GET_Events_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@EvtUserID", SqlDbType.Int).Value = mUserId;

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

