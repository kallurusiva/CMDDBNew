using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;
using CMSv3.Entities;

namespace CMSv3.DAL
{
    public class User
    {
        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataReader dbReader;
        protected SqlDataAdapter dbAdap;

        protected SqlConnection Common_dbConn;

        DataSet ds;

        

        String dbConnString = ConfigurationSettings.AppSettings["CMSdb"].ToString();
        string strSQL = string.Empty;

        String CommonDB32_ConnString = ConfigurationSettings.AppSettings["CommonDB32"].ToString();
        


        #region Constants

            private const string SP_GetUserDetailsbyID = "Usp_CMS_GetUserDetailsByUserID";
            private const string SP_CheckSubDomainExists = "usp_SubDomain_IsExists";
            private const string SP_SubDomain_InsertUpdateReg = "usp_SubDomain_InsertUpdateReg";
            
            private const string SP_SubDomain_UpdateActivation= "usp_SubDomain_Update_Activation";
            private const string SP_GetUserID_BySubDomainName = "usp_Retrieve_UserID_ByDomainName";
            private const string SP_Update_LastLoginDateTime = "usp_User_LastLogin";

            private const string SP_Retrieve_AllUsersData = "usp_Retreive_AllUsersData";
            private const string SP_Update_UserStatus = "usp_User_UpdateStatus";
            private const string SP_UserSummary_SAHomePage = "usp_SuperAdmin_Summary1";

            private const string SP_CheckUserLoginStatus = "usp_User_CheckLogin";
            private const string SP_Update_User_ExpiryDate = "usp_User_ExpiryDate";

            private const string SP_InsertUpdate_WelcomePage = "usp_WelComePage_InsertUpdate";
        
            
        
       
        #endregion



        public User()
        {

            try
            {
                dbConn = new SqlConnection(dbConnString);
                Common_dbConn = new SqlConnection(CommonDB32_ConnString);  
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }


        public CMSv3.Entities.User GetUserDetailsByID(int vUserID)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_GetUserDetailsbyID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserID;

                //dbAdap = new SqlDataAdapter(dbCmd);
                dbReader = dbCmd.ExecuteReader(CommandBehavior.SingleResult);

                //if (dbReader.HasRows)
                //{
                //    dbReader.Read();
                //    string muserid = dbReader["UserID"].ToString();
                //}
                //ds = new DataSet();
                //dbAdap.Fill(ds);
                //return ds;
                return BindData(dbReader);
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


        protected CMSv3.Entities.User BindData(SqlDataReader dbreader)
        {

            CMSv3.Entities.User objUser = new CMSv3.Entities.User();

            while (dbReader.Read())
            {
                if (dbReader["UserID"] != DBNull.Value)
                    objUser.UserId = Convert.ToInt32(dbreader["UserID"]);

                if (dbReader["LoginID"] != DBNull.Value)
                    objUser.LoginID = Convert.ToString(dbreader["LoginID"]);

                if (dbReader["UserType"] != DBNull.Value)
                    objUser.UserType = Convert.ToString(dbreader["UserType"]);

                if (dbReader["CreatedDate"] != DBNull.Value)
                    objUser.CreatedDateTime = Convert.ToDateTime(dbreader["CreatedDate"]);

            }

            dbreader.Dispose();
            return objUser;

        }


        public bool CheckSubDomainExists(string vSubDomainName)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_CheckSubDomainExists, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vSubDomainName", SqlDbType.VarChar).Value = vSubDomainName;
                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


                int status = dbCmd.ExecuteNonQuery();

                int MyResult = (int)dbCmd.Parameters["@Result"].Value;

                if (MyResult == 1)
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


        public int CheckSubDomainExists_MobileLoginID(string vSubDomainName, string vMobileNumber)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_SubDomain_IsExists_ByMobileID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vSubDomainName", SqlDbType.VarChar).Value = vSubDomainName;
                dbCmd.Parameters.Add("@vMobileNumber", SqlDbType.VarChar).Value = vMobileNumber;
                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


                int status = dbCmd.ExecuteNonQuery();

                int MyResult = (int)dbCmd.Parameters["@Result"].Value;
                return MyResult;


                //if (MyResult == 1)
                //    return true;
                //else
                //    return false;


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



        public int CheckUseridPinSbd_Status(string vUserID,string vPinNumber, string vSubDomainName)
        {

            try
            {

                if (Common_dbConn.State == ConnectionState.Closed)
                    Common_dbConn.Open();

                dbCmd = new SqlCommand("[usp_SME_CheckUserStatus]", Common_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vsme_UserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vsme_PinNumber", SqlDbType.VarChar).Value = vPinNumber;
                dbCmd.Parameters.Add("@vSubDomainName", SqlDbType.VarChar).Value = vSubDomainName;
                
                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


                int status = dbCmd.ExecuteNonQuery();

                int MyResult = (int)dbCmd.Parameters["@Result"].Value;
                return MyResult;


                //if (MyResult == 1)
                //    return true;
                //else
                //    return false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Common_dbConn.Close();
            }

        }


 

        public int GetUserID_BySubDomainName(string vSubDomainName)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_GetUserID_BySubDomainName, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vDomainName", SqlDbType.VarChar).Value = vSubDomainName;
                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


                int status = dbCmd.ExecuteNonQuery();

                int outUserID  = (int)dbCmd.Parameters["@Result"].Value;

                return outUserID;
                //if (MyResult == 1)
                //    return true;
                //else
                //    return false;


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


        public int GetUserID_BySubDomainName2(string vSubDomainName, int vDomainType)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_Retrieve_UserID_ByDomainName2", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vDomainName", SqlDbType.VarChar).Value = vSubDomainName;
                dbCmd.Parameters.Add("@vDomainType", SqlDbType.VarChar).Value = vDomainType;
                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


                int status = dbCmd.ExecuteNonQuery();

                int outUserID = (int)dbCmd.Parameters["@Result"].Value;

                return outUserID;
                //if (MyResult == 1)
                //    return true;
                //else
                //    return false;


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


        public long GetMobileLoginID_ByDomainName(string vSubDomainName, int vDomainType)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Retrieve_MobileLoginID_ByDomainName]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vDomainName", SqlDbType.VarChar).Value = vSubDomainName;
                dbCmd.Parameters.Add("@vDomainType", SqlDbType.VarChar).Value = vDomainType;
                dbCmd.Parameters.Add("@Result", SqlDbType.BigInt).Direction = ParameterDirection.Output;


                int status = dbCmd.ExecuteNonQuery();

                long outUserID = (long)dbCmd.Parameters["@Result"].Value;

                return outUserID;
                //if (MyResult == 1)
                //    return true;
                //else
                //    return false;


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


        public DataSet Get_UserDetails_ByDomainName(string vDomainName)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_User_CheckUserDetails_ByDomainName]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vDomainName", SqlDbType.VarChar).Value = vDomainName;
              
                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
            }
            //catch (SqlException sex)
            //{
            //    HttpContext.Current.Response.Redirect("Default.htm"); 

            //}
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public int InsertUpdate_SubDomain_Registration(CMSv3.Entities.webDomain vObjDomain)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_SubDomain_InsertUpdateReg, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vDomainName", SqlDbType.VarChar).Value = vObjDomain.DomainName;
                dbCmd.Parameters.Add("@vDomainPassword", SqlDbType.VarChar).Value = vObjDomain.DomainPassword;
                dbCmd.Parameters.Add("@vDomainType", SqlDbType.VarChar).Value = vObjDomain.DomainType;
                dbCmd.Parameters.Add("@vRegPin", SqlDbType.VarChar).Value = vObjDomain.PinNo;
                dbCmd.Parameters.Add("@vFullName", SqlDbType.VarChar).Value = vObjDomain.FullName;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vObjDomain.Email;
                dbCmd.Parameters.Add("@vCountryCode", SqlDbType.Int).Value = vObjDomain.CountryCode;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vObjDomain.MobileNo;
                dbCmd.Parameters.Add("@vLangCode", SqlDbType.Int).Value = vObjDomain.LanguageCode;
                dbCmd.Parameters.Add("@vPurchasedBy", SqlDbType.VarChar).Value = vObjDomain.PurchasedBy;
                dbCmd.Parameters.Add("@vPurchasedTo", SqlDbType.VarChar).Value = vObjDomain.PurchasedTo;
                dbCmd.Parameters.Add("@vCompany", SqlDbType.VarChar).Value = vObjDomain.Company;

                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


                int rowCount = dbCmd.ExecuteNonQuery();

                //return rowCount;
                int NewUserID = (int)dbCmd.Parameters["@Result"].Value;

                return NewUserID;

                //if (MyResult == 1)
                //    return true;
                //else
                //    return false;


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

        
        public int SubDomain_Reg_WithAnchorDomain(CMSv3.Entities.webDomain vObjDomain, int vAnchorDomainID)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[USP_SubDomain_Reg_WithAnchorDomain]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vDomainName", SqlDbType.VarChar).Value = vObjDomain.DomainName;
                dbCmd.Parameters.Add("@vDomainPassword", SqlDbType.VarChar).Value = vObjDomain.DomainPassword;
                dbCmd.Parameters.Add("@vDomainType", SqlDbType.VarChar).Value = vObjDomain.DomainType;
                dbCmd.Parameters.Add("@vRegPin", SqlDbType.VarChar).Value = vObjDomain.PinNo;
                dbCmd.Parameters.Add("@vFullName", SqlDbType.VarChar).Value = vObjDomain.FullName;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vObjDomain.Email;
                dbCmd.Parameters.Add("@vCountryCode", SqlDbType.Int).Value = vObjDomain.CountryCode;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vObjDomain.MobileNo;
                dbCmd.Parameters.Add("@vLangCode", SqlDbType.Int).Value = vObjDomain.LanguageCode;
                dbCmd.Parameters.Add("@vPurchasedBy", SqlDbType.VarChar).Value = vObjDomain.PurchasedBy;
                dbCmd.Parameters.Add("@vPurchasedTo", SqlDbType.VarChar).Value = vObjDomain.PurchasedTo;
                dbCmd.Parameters.Add("@vCompany", SqlDbType.VarChar).Value = vObjDomain.Company;

                dbCmd.Parameters.Add("@vStreet", SqlDbType.VarChar).Value = vObjDomain.Street;
                dbCmd.Parameters.Add("@vCity", SqlDbType.VarChar).Value = vObjDomain.City;
                dbCmd.Parameters.Add("@vState", SqlDbType.VarChar).Value = vObjDomain.State;
                dbCmd.Parameters.Add("@vPostCode", SqlDbType.VarChar).Value = vObjDomain.PostCode;
                dbCmd.Parameters.Add("@vAnchorDomainID", SqlDbType.Int).Value = vAnchorDomainID;


                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


                int rowCount = dbCmd.ExecuteNonQuery();

                //return rowCount;
                int NewUserID = (int)dbCmd.Parameters["@Result"].Value;

                return NewUserID;

                //if (MyResult == 1)
                //    return true;
                //else
                //    return false;


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


        public int SubDomain_Reg_WithAnchorDomain_SME(CMSv3.Entities.webDomain vObjDomain, int vAnchorDomainID, long vSMEGenMobile, string vSMEPinNumber)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[USP_SubDomain_Reg_WithAnchorDomain_SME]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vDomainName", SqlDbType.VarChar).Value = vObjDomain.DomainName;
                dbCmd.Parameters.Add("@vDomainPassword", SqlDbType.VarChar).Value = vObjDomain.DomainPassword;
                dbCmd.Parameters.Add("@vDomainType", SqlDbType.VarChar).Value = vObjDomain.DomainType;
                dbCmd.Parameters.Add("@vRegPin", SqlDbType.VarChar).Value = vObjDomain.PinNo;
                dbCmd.Parameters.Add("@vFullName", SqlDbType.VarChar).Value = vObjDomain.FullName;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vObjDomain.Email;
                dbCmd.Parameters.Add("@vCountryCode", SqlDbType.Int).Value = vObjDomain.CountryCode;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vObjDomain.MobileNo;
                dbCmd.Parameters.Add("@vLangCode", SqlDbType.Int).Value = vObjDomain.LanguageCode;
                dbCmd.Parameters.Add("@vPurchasedBy", SqlDbType.VarChar).Value = vObjDomain.PurchasedBy;
                dbCmd.Parameters.Add("@vPurchasedTo", SqlDbType.VarChar).Value = vObjDomain.PurchasedTo;
                dbCmd.Parameters.Add("@vCompany", SqlDbType.VarChar).Value = vObjDomain.Company;

                dbCmd.Parameters.Add("@vStreet", SqlDbType.VarChar).Value = vObjDomain.Street;
                dbCmd.Parameters.Add("@vCity", SqlDbType.VarChar).Value = vObjDomain.City;
                dbCmd.Parameters.Add("@vState", SqlDbType.VarChar).Value = vObjDomain.State;
                dbCmd.Parameters.Add("@vPostCode", SqlDbType.VarChar).Value = vObjDomain.PostCode;
                dbCmd.Parameters.Add("@vAnchorDomainID", SqlDbType.Int).Value = vAnchorDomainID;
                dbCmd.Parameters.Add("@vSMEGenMobileNo", SqlDbType.BigInt).Value = vSMEGenMobile;
                dbCmd.Parameters.Add("@vSMEPinNumber", SqlDbType.VarChar).Value = vSMEPinNumber;


                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


                int rowCount = dbCmd.ExecuteNonQuery();

                //return rowCount;
                int NewUserID = (int)dbCmd.Parameters["@Result"].Value;

                return NewUserID;

                //if (MyResult == 1)
                //    return true;
                //else
                //    return false;


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

        
        public int Update_SubDomain_ActivationDetails(int vUserId)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_SubDomain_UpdateActivation, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
               
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

        
       public int Update_User_LastLoginDetails(int vUserId)
        {

            try
            {

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Update_LastLoginDateTime, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
               
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

       public int Update_User_Status(int vUserId, bool vStatus, string vOwnDomainName, string vSubDomainName)
       {

           try
           {

               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();

               dbCmd = new SqlCommand(SP_Update_UserStatus, dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
               dbCmd.Parameters.Add("@vStatus", SqlDbType.Bit).Value = vStatus;
               dbCmd.Parameters.Add("@vOwnDomain", SqlDbType.VarChar).Value = vOwnDomainName;
               dbCmd.Parameters.Add("@vSubDomain", SqlDbType.VarChar).Value = vSubDomainName;
               

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


       public int Update_AdminLanguage(int vLanguageCode, int vUserId)
       {

           try
           {

               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();

               dbCmd = new SqlCommand("USP_AdminLanguage_Update", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@vLangCode", SqlDbType.Int).Value = vLanguageCode;
               dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;

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

       public DataSet Retrieve_AllUserData(string vSearchQuery, string vSortQuery)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Retrieve_AllUsersData, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@SearchQuery", SqlDbType.VarChar).Value = vSearchQuery;
                dbCmd.Parameters.Add("@SortByQuery", SqlDbType.VarChar).Value = vSortQuery;
              
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


       public DataSet Retrieve_AllUserData_byPage(string vSearchQuery, string vSortQuery, int vPageNo)
       {
           try
           {
               if (dbConn.State == ConnectionState.Closed)
                   dbConn.Open();

               dbCmd = new SqlCommand("[usp_Retreive_AllUsersData_ByPage]", dbConn);
               dbCmd.CommandType = CommandType.StoredProcedure;
               dbCmd.Parameters.Add("@SearchQuery", SqlDbType.VarChar).Value = vSearchQuery;
               dbCmd.Parameters.Add("@SortByQuery", SqlDbType.VarChar).Value = vSortQuery;
               dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;

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

     public DataSet Retrieve_AllUser_Summary()
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_UserSummary_SAHomePage, dbConn);
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


     public DataSet CheckUser_LoginStatus(string vLoginID, string vPassword)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand(SP_CheckUserLoginStatus, dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
             dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = vPassword;

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


     public DataSet CheckUser_ValidateByMobileLogin(string vMobileLogin)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[usp_User_CheckLogin_byMobileLogin]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLogin;
             
             

             dbAdap = new SqlDataAdapter(dbCmd);
             ds = new DataSet();
             dbAdap.Fill(ds);
             return ds;
         }
         //catch (SqlException sex)
         //{
         //    HttpContext.Current.Response.Redirect("Default.htm"); 
             
         //}
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             dbConn.Close();
         }

     }


     public DataSet CheckSUbDomain_ValidateByMobile(string vMobileLogin)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[usp_CheckSubDomain4MobileLoginID]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLogin;


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

     public int Check_SMEWEB_Purchase(string vMobileLoginID)
     {

         try
         {

             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[usp_SME_EmailSystem_ChkPurchase]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;
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

     public int Update_User_ExpiryDate(int vUserId, string vRenewBy, string vRenewalPinNo)
     {

         try
         {

             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand(SP_Update_User_ExpiryDate, dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@vUserId", SqlDbType.BigInt).Value = vUserId;
             dbCmd.Parameters.Add("@vRenewedBy", SqlDbType.VarChar).Value = vRenewBy;
             dbCmd.Parameters.Add("@vRenewPinNo", SqlDbType.VarChar).Value = vRenewalPinNo;

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

     public bool InsertUpdate_WelcomePage(string vDescription, int vUserID, int vLanguage, bool vActive)
     {

         try
         {

             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand(SP_InsertUpdate_WelcomePage, dbConn);
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




     public DataSet WelcomePage_Details(int vUserID)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[Usp_CMS_GetUserDetailsByUserID]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserID;


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



     public DataSet WelcomePage_QuickLinks(int vUserID)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[Usp_CMS_WpQuickLinks]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserID;


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



     public DataSet HomePage_ContactUs_ByUserID(int vUserID)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[usp_USER_ContactUs_GET_ByUserID]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserID;

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


     public DataSet EB_WebDesign2_GetSettings(int vUserID)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[usp_EB_Design2_GetSettings]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
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


     public int EB_WebDesign2_UpdateSettings(string vFBpageURL, string vWelcomePageText, String vPhotoGraph1, String vMasterPageName, String vMasterPageCSS,  int vUserID)
     {

         try
         {

             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("usp_EB_Design2_UpdateSettings", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@vFBpageURL", SqlDbType.NVarChar).Value = vFBpageURL;
             dbCmd.Parameters.Add("@vWelcomePageText", SqlDbType.NVarChar).Value = vWelcomePageText;
             dbCmd.Parameters.Add("@vPhotoGraph1", SqlDbType.NVarChar).Value = vPhotoGraph1;
             dbCmd.Parameters.Add("@vMasterPageName", SqlDbType.VarChar).Value = vMasterPageName;
             dbCmd.Parameters.Add("@vMasterPageCSS", SqlDbType.VarChar).Value = vMasterPageCSS;
             dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

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

     public DataSet EB_WebDesign3_GetSettings(int vUserID)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[usp_EB_Design3_GetSettings]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
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


     public int EB_WebDesign3_UpdateSettings(string vFBpageURL, string vWelcomePageText, String vPhotoGraph1, String vMasterPageName, String vMasterPageCSS, int vUserID)
     {

         try
         {

             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("usp_EB_Design3_UpdateSettings", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
             dbCmd.Parameters.Add("@vFBpageURL", SqlDbType.NVarChar).Value = vFBpageURL;
             dbCmd.Parameters.Add("@vWelcomePageText", SqlDbType.NVarChar).Value = vWelcomePageText;
             dbCmd.Parameters.Add("@vPhotoGraph1", SqlDbType.NVarChar).Value = vPhotoGraph1;
             dbCmd.Parameters.Add("@vMasterPageName", SqlDbType.VarChar).Value = vMasterPageName;
             dbCmd.Parameters.Add("@vMasterPageCSS", SqlDbType.VarChar).Value = vMasterPageCSS;
             dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

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

     public DataSet GetSavedTemplateDetails(int vUserID)
     {
         try
         {
             if (dbConn.State == ConnectionState.Closed)
                 dbConn.Open();

             dbCmd = new SqlCommand("[usp_Retreive_UserMasterPageAndCss]", dbConn);
             dbCmd.CommandType = CommandType.StoredProcedure;
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
