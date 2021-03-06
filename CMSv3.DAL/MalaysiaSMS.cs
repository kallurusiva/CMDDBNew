using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMSv3.DAL
{
    public class MalaysiaSMS
    {

        #region variables

        protected SqlConnection IFM_dbConn;
        protected SqlConnection ABEST_dbConn;
        protected SqlConnection API_dbConn;
        protected SqlConnection Ebook_dbConn;
        protected SqlConnection GsPayPal_dbConn;

        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;

        string IFM_dbString = ConfigurationSettings.AppSettings["IFMdb"].ToString();
        string ABEST_dbString = ConfigurationSettings.AppSettings["ABESTdb"].ToString();
        string API_dbString = ConfigurationSettings.AppSettings["ApiDb"].ToString();
        string GsPayPal_dbString = ConfigurationSettings.AppSettings["GsPayPalDb"].ToString();		

        #endregion       


         #region Functionality

        // Constructor to open the dbConnection 
        public MalaysiaSMS()
        {
         try
            {
                IFM_dbConn = new SqlConnection(IFM_dbString);
               // IFM_dbConn.Open();

                ABEST_dbConn = new SqlConnection(ABEST_dbString);
               // ABEST_dbConn.Open();

                API_dbConn = new SqlConnection(API_dbString);
                // ABEST_dbConn.Open();

                GsPayPal_dbConn = new SqlConnection(GsPayPal_dbString);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Function to reteive Account Type of 1 Malaysia User 
        /// </summary>
        /// <param name="sc">1MalaysiaUSER</param>
        /// <returns>integer</returns>
        /// <remarks>This function reteive Account Type of 1 Malaysia User </remarks> 
        /// 
        public DataSet Get_1MalaysiaUser_AccountDetails(string vMobileNo)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();


                dbCmd = new SqlCommand("[USP_Retrieve_ActType]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vMobileNo;

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
                IFM_dbConn.Close();
            }
        }



        /// <summary>
        /// Function to reteive SMS Balance Details of 1 Malaysia User 
        /// </summary>
        /// <param name="sc">1MalaysiaUSER</param>
        /// <returns>integer</returns>
        /// <remarks>This function reteive SMS Balance Details  of 1 Malaysia User </remarks> 
        /// 
        public DataSet Get_1MalaysiaUser_SMSBalanceDetails(string vMerchantID)
        {

            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();


                dbCmd = new SqlCommand("[USP_Retrieve_Mer_SMSBalance]", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMerChantID", SqlDbType.VarChar).Value = vMerchantID;

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
                ABEST_dbConn.Close();
            }
        }



        /// <summary>
        /// Function to Validate user login for 1Malaysia or 1Singapore 
        /// </summary>
        /// <param name="sc">1MalaysiaUSER</param>
        /// <returns>integer</returns>
        /// <remarks>This function to validate user login for 1Malaysia or 1Singapore </remarks> 
        /// 
        public string ValidateUserLoing_1MAS_1Sing(string vLoginID,string vPassword)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[USP_ValidateLogin_1MAS_1SING_SMSBIZVERSION]", IFM_dbConn);
                //dbCmd = new SqlCommand("USP_ValidateLogin_1MAS_1SING", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = vPassword;

                string tmpMID = dbCmd.ExecuteScalar().ToString();
                return tmpMID; 


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IFM_dbConn.Close();
            }
        }


        /// <summary>
        /// Function to Validate user login for 1Malaysia or 1Singapore 
        /// </summary>
        /// <param name="sc">1MalaysiaUSER</param>
        /// <returns>integer</returns>
        /// <remarks>This function to validate user login for 1Malaysia or 1Singapore </remarks> 
        /// 
        public DataSet ValidateLoginStatus(string vLoginID, string vPassword, String vType)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();
                
                dbCmd = new SqlCommand("[USP_ValidateLoginStatus]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = vPassword;
                dbCmd.Parameters.Add("@vType", SqlDbType.VarChar).Value = vType;

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
                IFM_dbConn.Close();
            }
        }


        /// <summary>
        /// Function to Validate user login for WebEmailSMS user  
        /// </summary>
        /// <param name="sc">1MalaysiaUSER</param>
        /// <returns>integer</returns>
        /// <remarks>This function to validate user login for WebEmailSMS user  </remarks> 
        /// 
        public string ValidateLogin_WebEmailSMS(string vLoginID, string vPassword)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[USP_ValidateLogin_WebEmailSMS]", IFM_dbConn);
                //dbCmd = new SqlCommand("USP_ValidateLogin_1MAS_1SING", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = vPassword;

                string tmpMID = dbCmd.ExecuteScalar().ToString();
                return tmpMID;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IFM_dbConn.Close();
            }
        }


        /// <summary>
        /// Function to Validate user login for 1Malaysia or 1Singapore 
        /// </summary>
        /// <param name="sc">1MalaysiaUSER</param>
        /// <returns>integer</returns>
        /// <remarks>This function to validate user login for 1Malaysia or 1Singapore </remarks> 
        /// 
        public DataSet ValidateUserLoing_1MAS_1Sing_ByMobileLoginID(string vMobileLoginID)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();



                dbCmd = new SqlCommand("[USP_ValidateLogin_1MAS_1SING_MobileLoginID]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;


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
                IFM_dbConn.Close();
            }
        }


        public string RetreiveMID_ByMobileLoginID(string vMobileLoginID)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();



                dbCmd = new SqlCommand("[USP_RetreiveMID_ByMobile]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;

                string tmpMID = dbCmd.ExecuteScalar().ToString();
                return tmpMID;


                //dbAdap = new SqlDataAdapter(dbCmd);
                //ds = new DataSet();
                //dbAdap.Fill(ds);
                //return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IFM_dbConn.Close();
            }
        }


        //public int SubDomain_Reg_atMLMSMS(CMSv3.Entities.webDomain vObjDomain, string vICNO, bool vChkAgreement)
        //{

        //    try
        //    {

        //        if (IFM_dbConn.State == ConnectionState.Closed)
        //            IFM_dbConn.Open();

        //        dbCmd = new SqlCommand("[USP_SubDomain_RegAtMLMSMS]", IFM_dbConn);
        //        dbCmd.CommandType = CommandType.StoredProcedure;

        //        dbCmd.Parameters.Add("@vICNO", SqlDbType.VarChar).Value = vICNO;
        //        dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vObjDomain.Email;
        //        dbCmd.Parameters.Add("@vCountryCode", SqlDbType.Int).Value = vObjDomain.CountryCode;
        //        dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vObjDomain.MobileNo;
        //        dbCmd.Parameters.Add("@vStreet", SqlDbType.VarChar).Value = vObjDomain.Street;
        //        dbCmd.Parameters.Add("@vCity", SqlDbType.VarChar).Value = vObjDomain.City;
        //        dbCmd.Parameters.Add("@vState", SqlDbType.VarChar).Value = vObjDomain.State;
        //        dbCmd.Parameters.Add("@vPostCode", SqlDbType.VarChar).Value = vObjDomain.PostCode;
        //        dbCmd.Parameters.Add("@vChkAgreement", SqlDbType.Bit).Value = vChkAgreement;

        //        dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;


        //        int rowCount = dbCmd.ExecuteNonQuery();

        //        //return rowCount;
        //        int NewUserID = (int)dbCmd.Parameters["@Result"].Value;

        //        return NewUserID;

        //        //if (MyResult == 1)
        //        //    return true;
        //        //else
        //        //    return false;


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        IFM_dbConn.Close();
        //    }

        //}



        /// <summary>
        /// Function to reteive Account Type of 1 Malaysia User 
        /// </summary>
        /// <param name="sc">1MalaysiaUSER</param>
        /// <returns>integer</returns>
        /// <remarks>This function retreive Email System purchasers Info </remarks> 
        /// 
        public DataSet Get_1MasUser_EMSDetails(string vSearchQuery)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();


                dbCmd = new SqlCommand("[usp_EmailSystem_RetreiveALL]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vSearchQuery", SqlDbType.VarChar).Value = vSearchQuery;

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
                IFM_dbConn.Close();
            }
        }


        public DataSet EMS_GetPlatinumUsers(string vSearchQuery)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();


                dbCmd = new SqlCommand("[usp_EmailSystem_GetPlatinumUsers]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vSearchQuery", SqlDbType.VarChar).Value = vSearchQuery;

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
                IFM_dbConn.Close();
            }
        }




        public DataSet Get_1MasUser_Details(string vMobileLoginID)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();


                dbCmd = new SqlCommand("[USP_Retrieve_MobileNoUser_Info]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobileLoginID;

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
                IFM_dbConn.Close();
            }
        }


        public int Check_EMS_Purchase(string vMobileLoginID)
        {

            try
            {

                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_EmailSystem_ChkPurchase]", IFM_dbConn);
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
                IFM_dbConn.Close();
            }
        }


        public int CheckSME_UserID(string vUserID)
        {

            try
            {

                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_SME_CheckUserID]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vsme_UserID", SqlDbType.VarChar).Value = vUserID;
               
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
                IFM_dbConn.Close();
            }

        }

        public int CheckSME_PinNumber(string vPinNumber)
        {

            try
            {

                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_SME_CheckPinNumber]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vsme_PinNumber", SqlDbType.VarChar).Value = vPinNumber;

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
                IFM_dbConn.Close();
            }

        }


        public int CheckPS_PinNumber(string vPinNumber)
        {

            try
            {

                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_PS_CheckPinNumber]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vPinNumber", SqlDbType.VarChar).Value = vPinNumber;

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
                IFM_dbConn.Close();
            }

        }


      
        public int Update_EMS_Creation(long vMobileLoginID)
        {

            try
            {

                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_EmailSystem_UpdateCreation]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.BigInt).Value = vMobileLoginID;
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
                IFM_dbConn.Close();
            }
        }




        public int PS_CheckUseridPin_Status(string vUserID, string vPinNumber)
        {

            try
            {

                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();

                dbCmd = new SqlCommand("[usp_PS_CheckLoginPinStatus]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vPinNumber", SqlDbType.VarChar).Value = vPinNumber;
                

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
                IFM_dbConn.Close();
            }

        }


        /// <summary>
        /// Function to Show/Hide Domain Button based on conditions 
        /// </summary>
        /// <param name="sc">1MalaysiaUSER</param>
        /// <returns>integer</returns>
        /// <remarks>This function Show/Hide Domain Button based on conditions  </remarks> 
        /// 
        public DataSet ShowHide_DomainButton(String vMobileLoginID)
        {

            try
            {
                if (IFM_dbConn.State == ConnectionState.Closed)
                    IFM_dbConn.Open();


                dbCmd = new SqlCommand("[USP_Domain_Button]", IFM_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMobileID", SqlDbType.VarChar).Value = vMobileLoginID;

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
                IFM_dbConn.Close();
            }
        }



        public int Insert_SEKEmailInfo(String vMID, String vParam, String vMailType, String vCatID, String iSuccess, String iFailure, String vMessage, String vSubject, String vBodyHTML, String vAttachment, String vEmailAddressList)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                //vMailType=0 means by SEK CODE,vMailType=1 means by ADCHOC,vMailType=2 means by CATEGORY
                dbCmd = new SqlCommand("USP_Insert_SEKEmailInfoTest", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@vParam", SqlDbType.VarChar).Value = vParam;
                dbCmd.Parameters.Add("@vMailType", SqlDbType.Int).Value = vMailType;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.BigInt).Value = vCatID;
                dbCmd.Parameters.Add("@vSuccessEntries", SqlDbType.BigInt).Value = iSuccess;
                dbCmd.Parameters.Add("@vFailureEntries", SqlDbType.BigInt).Value = iFailure;
                dbCmd.Parameters.Add("@vMessage", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@vSubject", SqlDbType.VarChar).Value = vSubject;
                dbCmd.Parameters.Add("@vBodyHTML", SqlDbType.NVarChar).Value = vBodyHTML;
                dbCmd.Parameters.Add("@vAttachment", SqlDbType.NVarChar).Value = vAttachment;
                dbCmd.Parameters.Add("@vEmailAddressList", SqlDbType.VarChar).Value = vEmailAddressList;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();

                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
                return MyResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ABEST_dbConn.Close();
            }

        }

        /// <summary>
        /// Function to User : Retrieve SMS RC List by Group
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to retrieve sms rc list by group</remarks> 

        public DataSet Retrieve_EbookRequestListings(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_EbookRequestListings", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }

        /// <summary>
        /// Function to User : Retrieve User Account Details
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to retrieve user account details</remarks> 

        public DataSet Retrieve_AccountDetails(String vMID)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_AccountDetails", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }

        /// <summary>
        /// Function to User : Send Message
        /// </summary>
        /// <param name="Api">API</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to send message</remarks> 

        public int Send_MessageUpdated(String vMID, String vCategory, String vMobileList, String vPrefix, String vPersonalize, String vMessage, String vMessageType, String vSender, String @vSchedule, String vDeductSMSCdt, String vCreditType, String vMsgCHN, String vReportName)
        {
            try
            {
                if (API_dbConn.State == ConnectionState.Closed)
                    API_dbConn.Open();

                dbCmd = new SqlCommand("USP_Send_SMSMessageInputUpdated", API_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@USERID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@CATEGORY", SqlDbType.BigInt).Value = vCategory;
                dbCmd.Parameters.Add("@MOBILELIST", SqlDbType.VarChar).Value = vMobileList;
                dbCmd.Parameters.Add("@PREFIX", SqlDbType.VarChar).Value = vPrefix;
                dbCmd.Parameters.Add("@PERSONALIZE", SqlDbType.VarChar).Value = vPersonalize;
                dbCmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@MESSAGETYPE", SqlDbType.TinyInt).Value = vMessageType;
                dbCmd.Parameters.Add("@SENDER", SqlDbType.VarChar).Value = vSender;
                dbCmd.Parameters.Add("@SCHEDULED", SqlDbType.VarChar).Value = vSchedule;
                dbCmd.Parameters.Add("@deductSMSCredits", SqlDbType.Money).Value = vDeductSMSCdt;
                dbCmd.Parameters.Add("@creditType", SqlDbType.VarChar).Value = vCreditType;
                dbCmd.Parameters.Add("@MESSAGECHN", SqlDbType.VarChar).Value = vMsgCHN;
                dbCmd.Parameters.Add("@ReportName", SqlDbType.VarChar).Value = vReportName;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
                return MyResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                API_dbConn.Close();
            }
        }

        /// <summary>
        /// Function to User : Retrieve DayLight and TimeZone Info
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to retrieve countries info</remarks> 

        public DataSet Retrieve_DayLightTimeZoneInfo(String vMID)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_DayLightSavingStatus", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                //dbCmd.ExecuteNonQuery();               
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
                ABEST_dbConn.Close();
            }
        }
        /// <summary>
        /// Function to User : Retrieve Profit Share by Premium User
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to retrieve profit share by premium user</remarks> 

        public DataSet Retrieve_ProfitShare(String vMID, String vStatus, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_ProfitShare", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@vStatus", SqlDbType.TinyInt).Value = vStatus;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.VarChar).Value = vPageNo;
                dbCmd.Parameters.Add("vPageSize", SqlDbType.VarChar).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }

        /// <summary>
        /// Function to User : Retrieve Payment Request by Premium User
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to retrieve payment request by premium user</remarks> 

        public DataSet Retrieve_PaymentRequest(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_PaymentRequest", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.VarChar).Value = vPageNo;
                dbCmd.Parameters.Add("vPageSize", SqlDbType.VarChar).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }



        /// <summary>
        /// Function to User : Retrieve SMS RC List by Group
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to retrieve sms rc list by group</remarks> 

        public DataSet Retrieve_EbookFreeRequestListings(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_EbookFreeRequestListings", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }


        /// <summary>
        /// Function to User : Retrieve Profit Share by Premium User
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to retrieve profit share by premium user</remarks> 

        public DataSet Retrieve_CurrentProfitShare(String vMID, String vMonth, String vYear)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_CurrentProfitShare", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@vMonth", SqlDbType.TinyInt).Value = vMonth;
                dbCmd.Parameters.Add("@vYear", SqlDbType.Int).Value = vYear;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }


        public DataSet Retrieve_1WayReport(String vMID, String vPageNo, String vPageSize, String vTimeDiff, String vSearchSQL)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_1WayReport", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vTimeDiff", SqlDbType.Int).Value = vTimeDiff;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }

        public DataSet Retrieve_1WayReport_Specific(String vHistID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (API_dbConn.State == ConnectionState.Closed)
                    API_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_1WayReport_Specific", API_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vHistID", SqlDbType.Int).Value = vHistID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;
                //dbCmd.ExecuteNonQuery();
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
                API_dbConn.Close();
            }
        }




        public DataSet Retrieve_2WayReport(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_2WayReport", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }

        public DataSet Retrieve_2WayReport_Specific(String vHistID)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_2WayReport_Specific", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vHistID", SqlDbType.Int).Value = vHistID;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }





        public DataSet Retrieve_NewsInfo(int vTopNews)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_NewsInfo", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vTopNews", SqlDbType.VarChar).Value = vTopNews;
                //dbCmd.ExecuteNonQuery();
                //*Remark
                //@vTopNews means no news to be displayed for eg: Top 5
                //@vTopNews = 5
                //To display all news insert 0
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
                ABEST_dbConn.Close();
            }
        }

        public DataSet Retrieve_CreditCardCharges()
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_CreditCharges", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }

        public DataSet Retrieve_SMSHistory(String vMID, String vSearchSQL, String vPageNo)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_SMSHistory", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.VarChar).Value = vPageNo;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }

        public DataSet Retrieve_GSPayPalHistory(String vUType, String vMID, String vSearchSQL)
        {
            try
            {
                if (GsPayPal_dbConn.State == ConnectionState.Closed)
                    GsPayPal_dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_GSPayPalByUserIDHistory", GsPayPal_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUType", SqlDbType.VarChar).Value = vUType;
                dbCmd.Parameters.Add("@vMID", SqlDbType.VarChar).Value = vMID;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;

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
                GsPayPal_dbConn.Close();
            }
        }


        /// <summary>
        /// Function to User : Validate User Login FROM EBOOK
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to validate user login</remarks> 

        public DataSet Validate_HitechSMS_EBOOK(String vMID)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("[USP_Validate_EBOOKbyMID]", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.VarChar).Value = vMID;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }


        public DataSet Validate_PaymentRequest(String vMID)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Validate_EbookPaymentRequest", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                //dbCmd.ExecuteNonQuery();
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
                ABEST_dbConn.Close();
            }
        }

        public int Insert_PaymentRequest(String vMID, String vReqAmt)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                dbCmd = new SqlCommand("USP_Insert_EBookPaymentRequest", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@vReqAmt", SqlDbType.Money).Value = vReqAmt;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
                return MyResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ABEST_dbConn.Close();
            }

        }


        public DataSet Validate_1WayReport_Specific(String vHistID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (API_dbConn.State == ConnectionState.Closed)
                    API_dbConn.Open();
                dbCmd = new SqlCommand("USP_Validate_1WayReport_Specific", API_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vHistID", SqlDbType.Int).Value = vHistID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;

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
                API_dbConn.Close();
            }
        }

        public int Insert_EbookEmailMarketing(String vMID, String vParam, String vMailType, String vCatID, String iSuccess, String iFailure, String vMessage, String vSubject, String vBodyHTML, String vAttachment, String vEmailAddressList)
        {
            try
            {
                if (ABEST_dbConn.State == ConnectionState.Closed)
                    ABEST_dbConn.Open();
                //vMailType=0 means by SEK CODE,vMailType=1 means by ADCHOC,vMailType=2 means by CATEGORY
                dbCmd = new SqlCommand("USP_Insert_EbookEmailMarketing", ABEST_dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@vParam", SqlDbType.VarChar).Value = vParam;
                dbCmd.Parameters.Add("@vMailType", SqlDbType.Int).Value = vMailType;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.BigInt).Value = vCatID;
                dbCmd.Parameters.Add("@vSuccessEntries", SqlDbType.BigInt).Value = iSuccess;
                dbCmd.Parameters.Add("@vFailureEntries", SqlDbType.BigInt).Value = iFailure;
                dbCmd.Parameters.Add("@vMessage", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@vSubject", SqlDbType.VarChar).Value = vSubject;
                dbCmd.Parameters.Add("@vBodyHTML", SqlDbType.NVarChar).Value = vBodyHTML;
                dbCmd.Parameters.Add("@vAttachment", SqlDbType.NVarChar).Value = vAttachment;
                dbCmd.Parameters.Add("@vEmailAddressList", SqlDbType.VarChar).Value = vEmailAddressList;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();

                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
                return MyResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ABEST_dbConn.Close();
            }
        }

        #endregion
    }  
    

}
