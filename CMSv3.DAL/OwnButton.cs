using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMSv3.DAL
{
    public class OwnButton
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

        private const string SP_InsertOwnButton = "usp_OwnButton_InsertData";
        private const string SP_Update_OwnButton_ByUserId = "usp_OwnButton_Update_ByUserID";
        
        #endregion


                #region Functionality

        // Constructor to open the dbConnection 
        public OwnButton()
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
        /// Function to insert Own button 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts the Own Button record and returns 1 if inserted else 0</remarks> 
        /// 
        public int Insert_OwnButtonData(string vLinkName, string vContent, int vUserID, bool vActive, int vSelLanguage, int vButtonNo)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_InsertOwnButton, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLinkName", SqlDbType.NVarChar).Value = vLinkName;
                dbCmd.Parameters.Add("@vContent", SqlDbType.NVarChar).Value = vContent;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = vActive;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vSelLanguage;
                dbCmd.Parameters.Add("@vButtonNo", SqlDbType.TinyInt).Value = vButtonNo;



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



        public bool Update_OwnButtonData(string vLinkName, string vContent, int vUserID, bool vActive, int vSelLanguage, int vButtonNo)
        {
            int rowCount;

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Update_OwnButton_ByUserId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLinkName", SqlDbType.NVarChar).Value = vLinkName;
                dbCmd.Parameters.Add("@vContent", SqlDbType.NVarChar).Value = vContent;
                dbCmd.Parameters.Add("@vuserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = vActive;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vSelLanguage;
                dbCmd.Parameters.Add("@vButtonNo", SqlDbType.TinyInt).Value = vButtonNo;



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




        public DataSet Retrieve_ButtonInfoBYSA(int vUserID,int vButtonNo)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_OwnButtonSA_ByButtonNo", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vButtonNo", SqlDbType.Int).Value = vButtonNo;

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



        public int Delete_DefWebButtonsBYSA(int vButtonUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("usp_DefButton_DeleteByUID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vButtonUID", SqlDbType.Int).Value = vButtonUID;



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

        public DataSet Retrieve_DefWebButtonsBYSA(string vSearchTxt, int vButtonType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_DefWebButton_RetreiveALL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vButtonType", SqlDbType.TinyInt).Value = vButtonType; 
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchTxt;
             
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


        public DataSet Retrieve_DefWebButtonInfoBYSA(int vButtonNo, int vAnchorDomainID, int vButtonType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_DefWebButton_Retreive", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vButtonNo", SqlDbType.Int).Value = vButtonNo;
                dbCmd.Parameters.Add("@vAnchorDomainID", SqlDbType.Int).Value = vAnchorDomainID;
                dbCmd.Parameters.Add("@vButtonType", SqlDbType.Int).Value = vButtonType;

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


        public int Insert_DefWebButtonBySA(int vButtonNo, string vButtonName, string vContent, int vAnchorDomainID, int vButtonType)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

               
                dbCmd = new SqlCommand("usp_DefWebButton_InsertUpdate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vButtonNo", SqlDbType.Int).Value = vButtonNo;
                dbCmd.Parameters.Add("@vButtonName", SqlDbType.NVarChar).Value = vButtonName;
                dbCmd.Parameters.Add("@vContent", SqlDbType.NVarChar).Value = vContent;
                dbCmd.Parameters.Add("@vAnchorDomainID", SqlDbType.Int).Value = vAnchorDomainID;
                dbCmd.Parameters.Add("@vButtonType", SqlDbType.Int).Value = vButtonType;
                
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


        public DataSet Retrieve_DefWebButtonsByAnchorDomainID(int vAnchorDomainID, int vButtonType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_DefWebButton_RetreiveByAnchorDomainID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vAnchorDomainID", SqlDbType.Int).Value = vAnchorDomainID;
                dbCmd.Parameters.Add("@vButtonType", SqlDbType.Int).Value = vButtonType;

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


        public DataSet Retrieve_ExtraButtonInfoBYSA()
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_ExtraWebBtnSA_Retreive", dbConn);
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

        public int Insert_ExtraButtonBySA(string vButtonName, string vContent,bool vActive,int vButtonType,int vGadsPosition)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_ExtraWebButton_InsertUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vButtonName", SqlDbType.NVarChar).Value = vButtonName;
                dbCmd.Parameters.Add("@vContent", SqlDbType.NVarChar).Value = vContent;
                dbCmd.Parameters.Add("@vActive", SqlDbType.Bit).Value = vActive;
                dbCmd.Parameters.Add("@vButtonType", SqlDbType.Int).Value = vButtonType;
                dbCmd.Parameters.Add("@vGadsPosition", SqlDbType.Int).Value = vGadsPosition;

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

#endregion


    }
}
