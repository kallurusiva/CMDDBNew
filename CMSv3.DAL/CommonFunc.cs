using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMSv3.DAL
{
    public class CommonFunc
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

        private const string SP_Retreive_Countries = "usp_Country_RetreiveAll";
        private const string SP_ChangePriorityOrder = "usp_ALTER_ProrityOrder";
        private const string SP_InsertUpdate_ShowAdminItems = "usp_ShowAdminIds_InsertUpdate";
        private const string SP_InsertUpdate_AboutUs = "usp_AboutUsPage_InsertUpdate";

        private const string SP_UpdateDomainName = "Usp_DomainName_Request";
        private const string SP_UpdateDomainRequestStatus = "Usp_DomainName_RequestUpdate";

        #endregion


        public CommonFunc()
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


        public DataSet GetCountryList()
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Retreive_Countries, dbConn);
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


        public int ChangePriorityOrder(string TableName, string ColName, string IXname, string CurrPriority, string CurrID, string PrevPriority, string PrevID, string vUserID)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_ChangePriorityOrder, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Table_Name", SqlDbType.VarChar).Value = TableName;
                dbCmd.Parameters.Add("@Col_name", SqlDbType.VarChar).Value = ColName;
                dbCmd.Parameters.Add("@IX_name", SqlDbType.VarChar).Value = IXname;
                dbCmd.Parameters.Add("@Curr_Priority", SqlDbType.VarChar).Value = CurrPriority;
                dbCmd.Parameters.Add("@Curr_ID", SqlDbType.VarChar).Value = CurrID;
                dbCmd.Parameters.Add("@Prev_Priority", SqlDbType.VarChar).Value = PrevPriority;
                dbCmd.Parameters.Add("@Prev_ID", SqlDbType.VarChar).Value = PrevID;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                int rowCount = dbCmd.ExecuteNonQuery();

                return rowCount;

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



       public bool InsertUpdate_ShowAdminItems(string TableName, string ItemIDs, int ForUserID)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_InsertUpdate_ShowAdminItems, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tblName", SqlDbType.VarChar).Value = TableName;
                dbCmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ItemIDs;
                dbCmd.Parameters.Add("@ForUserID", SqlDbType.Int).Value = ForUserID;
               
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


       public bool InsertUpdate_AboutUsPage(string vDescription,int vUserID,int vLanguage, bool vActive)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_InsertUpdate_AboutUs, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = vDescription;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vLanguage;
                dbCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = vActive;
               
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


       public bool Update_DomainNameRegistration(string vDomainName, int vUserId)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_UpdateDomainName, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@DomainName", SqlDbType.VarChar).Value = vDomainName;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserId;
                
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


       public bool Update_DomainRequestStatus(string vDomainName, int vUserId, int vApproveReject, int vReqID)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_UpdateDomainRequestStatus, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@DomainName", SqlDbType.VarChar).Value = vDomainName;
                dbCmd.Parameters.Add("@ReqID", SqlDbType.Int).Value = vReqID;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@ApproveReject", SqlDbType.TinyInt).Value = vApproveReject;
                
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
        

       

        
    }
}
