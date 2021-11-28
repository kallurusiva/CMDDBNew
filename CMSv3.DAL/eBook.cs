using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CMSv3.Entities;


namespace CMSv3.DAL
{
    public class eBook
    {


        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;
       // DataTable dt;

        string eBookdbConnString = ConfigurationSettings.AppSettings["eBookDB"].ToString();



        #endregion




        #region Functionality


        public eBook()
        {
            try
            {
                dbConn = new SqlConnection(eBookdbConnString);
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        /// Function to User : Validate User Login
        /// </summary>
        /// <param name="ebook">EBook</param>
        /// <returns>Int</returns>
        /// <remarks>Validate user login</remarks> 

        public DataSet Validate_UserLogin(String vLoginID, String vPwd)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Validate_UserLogin", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vPwd", SqlDbType.VarChar).Value = vPwd;

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




        /// Function to User : Validate User Login
        /// </summary>
        /// <param name="ebook">EBook</param>
        /// <returns>Int</returns>
        /// <remarks>Validate user login</remarks> 

        public DataSet EBOOK_GetDetailsbyMID(String vMID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_EBOOK_GetDetailsbyMID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.VarChar).Value = vMID;
                

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




        public DataSet EMS_GetEbookUsers(string vSearchQuery)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_EB_GetEmailSetupListing]", dbConn);
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
                dbConn.Close();
            }
        }
        


        public int InsertUpdate_Ebook_EMSContent(string vAdminID, string vAdminPwd, string vEnquiryID, string vEnquiryPwd, string vHttpUrlLink, long vMobileLoginID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Ebook_EMS_InsertUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vAdminID", SqlDbType.VarChar).Value = vAdminID;
                dbCmd.Parameters.Add("@vAdminPwd", SqlDbType.VarChar).Value = vAdminPwd;
                dbCmd.Parameters.Add("@vEnquiryID", SqlDbType.VarChar).Value = vEnquiryID;
                dbCmd.Parameters.Add("@vEnquiryPwd", SqlDbType.VarChar).Value = vEnquiryPwd;
                dbCmd.Parameters.Add("@vHttpUrlLink", SqlDbType.VarChar).Value = vHttpUrlLink;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.BigInt).Value = vMobileLoginID;

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



        public DataSet Retrieve_EMSContent(String vMobileId, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EBook_EMS_RetrieveDetails]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileId", SqlDbType.VarChar).Value = vMobileId;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Retrieve_EMSContent_ByUserID(int vUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EBook_EMS_RetrieveDetails_ByUserID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;
                
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


        public int PayPalSettings(int vUserID, int vEmailType, String vEmailID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EBook_PayPalSettings]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vEmailType", SqlDbType.Int).Value = vEmailType;
                dbCmd.Parameters.Add("@vEmailID", SqlDbType.VarChar).Value = vEmailID;
               
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




        public DataSet Category_Listing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoryListing_ByUserID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Category_HP_Listing_ByAdminID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoriesHP_ByAdminID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Category_HP_Listing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoriesHP_ByUserID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Category_Load_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoryListing4User]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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



        public  int CatMain_Add(string vCategoryName, bool vDisplay, int vUserID, int vMerchantID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CatMain_ADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.NVarChar).Value = vCategoryName;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = vDisplay;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = vMerchantID;
                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public  int CatMain_Update(int vUserID, int vCatId, string vCategoryName, bool vDisplay)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CatMain_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = vCatId;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.NVarChar).Value = vCategoryName;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = vDisplay;
                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public  int CatMain_Delete(int vCatId, int vUserID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CatMain_Delete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vCatId", SqlDbType.NVarChar).Value = vCatId;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

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


        public  int CatMain_Validate(int vUserID, string vCategoryName)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CatMain_NameValidate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.NVarChar).Value = vCategoryName;
                dbCmd.Parameters.Add("@returnStatus", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                // return status;

                int MyResult = (int)dbCmd.Parameters["@returnStatus"].Value;
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



        public DataSet CatMain_Listing(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CatMain_Listing]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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

        public DataSet CatMain_Categories(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CatMain_Categories]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Category_WP_Listing(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoryListing]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public int Category_WP_Add(int vCatMainId, string vCategoryName, bool vDisplay, int vUserID, int vMerchantID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoryADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = vCatMainId;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.NVarChar).Value = vCategoryName;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = vDisplay;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = vMerchantID;
                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public int Category_WP_Delete(int vCatId, int vUserID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoryDelete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vCatId", SqlDbType.NVarChar).Value = vCatId;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

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


        public int Category_WP_Update(int vUserID, int vCatId, string vCategoryName, bool vDisplay)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoryUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = vCatId;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.NVarChar).Value = vCategoryName;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = vDisplay;
                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public int Category_Validate(int vUserId, string vCategoryName)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoryNameValidate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.NVarChar).Value = vCategoryName;
                dbCmd.Parameters.Add("@returnStatus", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                // return status;

                int MyResult = (int)dbCmd.Parameters["@returnStatus"].Value;
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



        public DataSet HomePageItems_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_HomePageItems_ByUserID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet HomePageItems_Design3(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_HomePageItems_Design3]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        

        public DataSet Ebook_Listing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BooksListing_ByUserID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Ebook_FeatureBuyListing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WEB_FeatureBuyList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Ebook_FreeListing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WEB_FreeList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Ebook_BestSellerListing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WEB_BestSellerList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Ebook_NewReleaseListing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WEB_NewReleaseList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Ebook__ADM_ValueBuyListing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_ValueBuyList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Ebook_ValueBuyListing_ByUserID(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WEB_ValueBuyList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Ebook_ValueBuyListing_ByBookID(int vUserID, string vBookID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WEB_ValueBuyList_ByBookID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;

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


        public DataSet Ebook_KeywordDetails_ByUserID(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[USP_EBOOK_GetKeywodDetails]", dbConn);
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


       



        public  DataSet Ebook_Listing(int vUserId,int vUserType,int vPageNo,  string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                
               // dbCmd = new SqlCommand("[usp_EB_WP_eBooksListing]", dbConn);
                dbCmd = new SqlCommand("[usp_EB_WP_eBooksListing_Search]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = vUserType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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




        public DataSet Ebook_AdminSpPage(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_AdmPage_ViewByPageID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vPageID", SqlDbType.Int).Value = 0;
                dbCmd.Parameters.Add("@vPageType", SqlDbType.TinyInt).Value = 1;
                

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



        public int Ebook_ShowHide(int vUserID, string vBookID, int vBookUID, int vBookType, bool vChkDisplay)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Ebook_User_ShowHIDE]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookType", SqlDbType.TinyInt).Value = vBookType;

                dbCmd.Parameters.Add("@vChkDisplay", SqlDbType.Bit).Value = vChkDisplay;
                
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


        public int Ebook_ShowHide_HpItems(int vUserID, string vBookID, int vBookUID, int vBookType, bool vChkHpShow)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Ebook_ShowHIDE_HPitems]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookType", SqlDbType.TinyInt).Value = vBookType;
                dbCmd.Parameters.Add("@vChkHpItems", SqlDbType.Bit).Value = vChkHpShow;


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


        public int EBook_AddBook_ByUser(CMSv3.Entities.Ebook ebEntity)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookADD_Chn]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;

                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = ebEntity.catMainID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = ebEntity.catID;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.VarChar).Value = ebEntity.categoryName;

                dbCmd.Parameters.Add("@vPrice", SqlDbType.Money).Value = ebEntity.Price;
                dbCmd.Parameters.Add("@vDiscount", SqlDbType.TinyInt).Value = ebEntity.Discount;

                dbCmd.Parameters.Add("@vDescription", SqlDbType.NVarChar).Value = ebEntity.Description;

                dbCmd.Parameters.Add("@vSubject", SqlDbType.NVarChar).Value = ebEntity.ReplySubject;
                dbCmd.Parameters.Add("@vSenderEmailID", SqlDbType.VarChar).Value = ebEntity.SenderEmailID;
                dbCmd.Parameters.Add("@vSmsReply", SqlDbType.NVarChar).Value = ebEntity.ReplySMS;
                dbCmd.Parameters.Add("@vSmsReplych", SqlDbType.NVarChar).Value = ebEntity.ReplySMSch;
                dbCmd.Parameters.Add("@vSmsReplyType", SqlDbType.Int).Value = ebEntity.ReplySMStype;
                dbCmd.Parameters.Add("@vEmailReply", SqlDbType.NVarChar).Value = ebEntity.ReplyEmail;
                

                dbCmd.Parameters.Add("@vLaunchStatus", SqlDbType.TinyInt).Value = ebEntity.LaunchStatus;

                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = ebEntity.isDisplay;
                dbCmd.Parameters.Add("@vFeatured", SqlDbType.Bit).Value = ebEntity.isFeatured;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Bit).Value = ebEntity.isBestSeller;
                dbCmd.Parameters.Add("@vBuySMS", SqlDbType.Bit).Value = ebEntity.isBuySMS;
                dbCmd.Parameters.Add("@vBuyPayPal", SqlDbType.Bit).Value = ebEntity.isBuyPayPal;

                


                dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = ebEntity.ImgFileName;
                dbCmd.Parameters.Add("@vImageFileURL", SqlDbType.NVarChar).Value = ebEntity.ImgFilePath;
                dbCmd.Parameters.Add("@vEbookFileName", SqlDbType.NVarChar).Value = ebEntity.EbookFileName;
                dbCmd.Parameters.Add("@vEbookFileURL", SqlDbType.NVarChar).Value = ebEntity.EbookFilePath;

                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = ebEntity.CreatedBy;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = ebEntity.MerchantID;

                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3; 


                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;




                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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



        public int EBook_AddBook_ValueBuy_ByUser(int vUserID, CMSv3.Entities.Ebook ebEntity, String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5, int vBooksCount, bool vShowAtHp)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookADD_ValueBuy]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;
                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = ebEntity.catMainID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = ebEntity.catID;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.VarChar).Value = ebEntity.categoryName;

                dbCmd.Parameters.Add("@vPrice", SqlDbType.Money).Value = ebEntity.Price;
                dbCmd.Parameters.Add("@vDiscount", SqlDbType.TinyInt).Value = ebEntity.Discount;

                dbCmd.Parameters.Add("@vDescription", SqlDbType.NVarChar).Value = ebEntity.Description;

                dbCmd.Parameters.Add("@vSubject", SqlDbType.NVarChar).Value = ebEntity.ReplySubject;
                dbCmd.Parameters.Add("@vSenderEmailID", SqlDbType.VarChar).Value = ebEntity.SenderEmailID;
                dbCmd.Parameters.Add("@vSmsReply", SqlDbType.NVarChar).Value = ebEntity.ReplySMS;
                dbCmd.Parameters.Add("@vEmailReply", SqlDbType.NVarChar).Value = ebEntity.ReplyEmail;

                dbCmd.Parameters.Add("@vLaunchStatus", SqlDbType.TinyInt).Value = ebEntity.LaunchStatus;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = ebEntity.isDisplay;
                dbCmd.Parameters.Add("@vShowAtHp", SqlDbType.Bit).Value = vShowAtHp;

                dbCmd.Parameters.Add("@vFeatured", SqlDbType.Bit).Value = ebEntity.isFeatured;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Bit).Value = ebEntity.isBestSeller;
                dbCmd.Parameters.Add("@vBuySMS", SqlDbType.Bit).Value = ebEntity.isBuySMS;
                dbCmd.Parameters.Add("@vBuyPayPal", SqlDbType.Bit).Value = ebEntity.isBuyPayPal;


                dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = ebEntity.ImgFileName;
                dbCmd.Parameters.Add("@vImageFileURL", SqlDbType.NVarChar).Value = ebEntity.ImgFilePath;
                dbCmd.Parameters.Add("@vEbookFileName", SqlDbType.NVarChar).Value = ebEntity.EbookFileName;
                dbCmd.Parameters.Add("@vEbookFileURL", SqlDbType.NVarChar).Value = ebEntity.EbookFilePath;



                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = ebEntity.MerchantID;

                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3; 

                dbCmd.Parameters.Add("@vBookID1", SqlDbType.VarChar).Value = vBookID1;
                dbCmd.Parameters.Add("@vBookID2", SqlDbType.VarChar).Value = vBookID2;
                dbCmd.Parameters.Add("@vBookID3", SqlDbType.VarChar).Value = vBookID3;
                dbCmd.Parameters.Add("@vBookID4", SqlDbType.VarChar).Value = vBookID4;
                dbCmd.Parameters.Add("@vBookID5", SqlDbType.VarChar).Value = vBookID5;

                dbCmd.Parameters.Add("@vBooksCount", SqlDbType.VarChar).Value = vBooksCount;

                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;




                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public DataSet Ebook_CheckValueBuyBookIDs(int vBookCount, String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_CheckBookIDsValueBuy]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookCount", SqlDbType.Int).Value = vBookCount;
                dbCmd.Parameters.Add("@vBook1", SqlDbType.VarChar).Value = vBookID1;
                dbCmd.Parameters.Add("@vBook2", SqlDbType.VarChar).Value = vBookID2;
                dbCmd.Parameters.Add("@vBook3", SqlDbType.VarChar).Value = vBookID3;
                dbCmd.Parameters.Add("@vBook4", SqlDbType.VarChar).Value = vBookID4;
                dbCmd.Parameters.Add("@vBook5", SqlDbType.VarChar).Value = vBookID5;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = 7484;

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


        public DataSet Ebook_ValueBuy_Listing(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ValueBuy_Listing]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public int EBook_ValueBuy_Delete(int vValueBuyUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ValueBuy_Delete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vValueBuyUID", SqlDbType.Int).Value = vValueBuyUID;


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


        public DataSet Ebook_ValueBuy_Edit(string vBookID, int vUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ValueBuy_EditByBookID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;

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



        public int EBook_ValueBuy_Update(int vUserID, CMSv3.Entities.Ebook ebEntity, String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5, int vBooksCount, bool vShowAthp)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ValueBuy_UpdateByBookID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = ebEntity.BookID;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;
                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = ebEntity.catMainID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = ebEntity.catID;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.VarChar).Value = ebEntity.categoryName;

                dbCmd.Parameters.Add("@vPrice", SqlDbType.Money).Value = ebEntity.Price;
                dbCmd.Parameters.Add("@vDiscount", SqlDbType.TinyInt).Value = ebEntity.Discount;

                dbCmd.Parameters.Add("@vDescription", SqlDbType.NVarChar).Value = ebEntity.Description;
                dbCmd.Parameters.Add("@vLaunchStatus", SqlDbType.TinyInt).Value = ebEntity.LaunchStatus;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = ebEntity.isDisplay;
                dbCmd.Parameters.Add("@vShowAtHp", SqlDbType.Bit).Value = vShowAthp;

                dbCmd.Parameters.Add("@vFeatured", SqlDbType.Bit).Value = ebEntity.isFeatured;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Bit).Value = ebEntity.isBestSeller;
                dbCmd.Parameters.Add("@vBuySMS", SqlDbType.Bit).Value = ebEntity.isBuySMS;
                dbCmd.Parameters.Add("@vBuyPayPal", SqlDbType.Bit).Value = ebEntity.isBuyPayPal;


                dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = ebEntity.ImgFileName;
                dbCmd.Parameters.Add("@vImageFileURL", SqlDbType.NVarChar).Value = ebEntity.ImgFilePath;
                dbCmd.Parameters.Add("@vEbookFileName", SqlDbType.NVarChar).Value = ebEntity.EbookFileName;
                dbCmd.Parameters.Add("@vEbookFileURL", SqlDbType.NVarChar).Value = ebEntity.EbookFilePath;


                dbCmd.Parameters.Add("@vSubject", SqlDbType.NVarChar).Value = ebEntity.ReplySubject;
                dbCmd.Parameters.Add("@vSenderEmailID", SqlDbType.VarChar).Value = ebEntity.SenderEmailID;
                dbCmd.Parameters.Add("@vSmsReply", SqlDbType.NVarChar).Value = ebEntity.ReplySMS;
                dbCmd.Parameters.Add("@vEmailReply", SqlDbType.NVarChar).Value = ebEntity.ReplyEmail;


                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = ebEntity.MerchantID;

                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3; 


                dbCmd.Parameters.Add("@vBookID1", SqlDbType.VarChar).Value = vBookID1;
                dbCmd.Parameters.Add("@vBookID2", SqlDbType.VarChar).Value = vBookID2;
                dbCmd.Parameters.Add("@vBookID3", SqlDbType.VarChar).Value = vBookID3;
                dbCmd.Parameters.Add("@vBookID4", SqlDbType.VarChar).Value = vBookID4;
                dbCmd.Parameters.Add("@vBookID5", SqlDbType.VarChar).Value = vBookID5;

                dbCmd.Parameters.Add("@vBooksCount", SqlDbType.VarChar).Value = vBooksCount;

                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;





                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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




        public int EBook_UpdateBook_ByUser(CMSv3.Entities.Ebook ebEntity)  
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookUpdate_Chn]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.NVarChar).Value = ebEntity.BookID;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;
                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = ebEntity.catMainID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = ebEntity.catID;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.VarChar).Value = ebEntity.categoryName;

                dbCmd.Parameters.Add("@vPrice", SqlDbType.Money).Value = ebEntity.Price;
                dbCmd.Parameters.Add("@vDiscount", SqlDbType.TinyInt).Value = ebEntity.Discount;

                dbCmd.Parameters.Add("@vDescription", SqlDbType.NVarChar).Value = ebEntity.Description;

                dbCmd.Parameters.Add("@vSubject", SqlDbType.NVarChar).Value = ebEntity.ReplySubject;
                dbCmd.Parameters.Add("@vSenderEmailID", SqlDbType.VarChar).Value = ebEntity.SenderEmailID;
                dbCmd.Parameters.Add("@vSmsReply", SqlDbType.NVarChar).Value = ebEntity.ReplySMS;
                dbCmd.Parameters.Add("@vSmsReplych", SqlDbType.NVarChar).Value = ebEntity.ReplySMSch;
                dbCmd.Parameters.Add("@vSmsReplyType", SqlDbType.NVarChar).Value = ebEntity.ReplySMStype;
                dbCmd.Parameters.Add("@vEmailReply", SqlDbType.NVarChar).Value = ebEntity.ReplyEmail;

                dbCmd.Parameters.Add("@vLaunchStatus", SqlDbType.TinyInt).Value = ebEntity.LaunchStatus;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = ebEntity.isDisplay;
                dbCmd.Parameters.Add("@vFeatured", SqlDbType.Bit).Value = ebEntity.isFeatured;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Bit).Value = ebEntity.isBestSeller;
                dbCmd.Parameters.Add("@vBuySMS", SqlDbType.Bit).Value = ebEntity.isBuySMS;
                dbCmd.Parameters.Add("@vBuyPayPal", SqlDbType.Bit).Value = ebEntity.isBuyPayPal;


                dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = ebEntity.ImgFileName;
                dbCmd.Parameters.Add("@vImageFileURL", SqlDbType.NVarChar).Value = ebEntity.ImgFilePath;
                dbCmd.Parameters.Add("@vEbookFileName", SqlDbType.NVarChar).Value = ebEntity.EbookFileName;
                dbCmd.Parameters.Add("@vEbookFileURL", SqlDbType.NVarChar).Value = ebEntity.EbookFilePath;
                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = ebEntity.CreatedBy;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = ebEntity.MerchantID;

                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3; 


                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;




                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public  DataSet Ebook_Edit(string vBookID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookEdit_ByBookId]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;

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


        public  int EBook_Delete(string vBookID, int vUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookDelete_ByBookId]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;

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



        public DataSet EBOOK_GetBook2EmailDetails(string vBookID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Book2Email_ByBookId]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;

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

        public DataSet EBOOK_GetBook2EmailDetails2(string vBookID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Book2Email_ByBookId2]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;

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



        public  DataSet Ebook_GetBookDetails(string vBookID, int vUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_ebAD_GetDetails_byBookID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;

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



        public int Ebook_BestSeller_ADD(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_BestSeller_ADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@isShowatHP", SqlDbType.Bit).Value = vShowAtHp;
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



        public DataSet Ebook_BestSeller_LIST(int vUserID,string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_BestSellerList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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



        public DataSet Ebook_NewRelease_LIST(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_NewReleaseList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public int Ebook_NewRelease_ADD(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_NewRelease_ADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@isShowatHP", SqlDbType.Bit).Value = vShowAtHp;
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



        public int EBook_NewRelease_Delete(int vNewReleaseUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_NewRelease_Delete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vNewReleaseUID", SqlDbType.Int).Value = vNewReleaseUID;


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


        public int EBook_NewRelease_Update(int vNewReleaseUID, bool vShowatHP)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_NewRelease_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vNewReleaseUID", SqlDbType.Int).Value = vNewReleaseUID;
                dbCmd.Parameters.Add("@visShowAtHP", SqlDbType.Bit).Value = vShowatHP;


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




        public int EBook_BestSeller_Delete(int vBestSellerUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Delete_BestSeller]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBestSellerUID", SqlDbType.Int).Value = vBestSellerUID;


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


        public int EBook_BestSeller_Update(int vBestSellerUID, bool vShowatHP)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BestSeller_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBestSellerUID", SqlDbType.Int).Value = vBestSellerUID;
                dbCmd.Parameters.Add("@visShowAtHP", SqlDbType.Bit).Value = vShowatHP;


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




        public DataSet GET_BookIDs(String vPrefix)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("USP_GeteBookIds", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vPrefix", SqlDbType.VarChar).Value = vPrefix;

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


        // ---------  FreeEbook
        public int Ebook_FreeEbook_ADD(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_ADM_FreeEbook_ADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@isShowatHP", SqlDbType.Bit).Value = vShowAtHp;
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


        public DataSet Ebook_FreeEbook_LIST(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_FreeEbookList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public int EBook_FreeEbook_Delete(int vFreeBookUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_FreeEbook_Delete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vFreeBookUID", SqlDbType.Int).Value = vFreeBookUID;


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


        public int EBook_FreeEbook_Update(int vFreeBookUID, bool vShowatHP)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_FreeEbook_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vFreeBookUID", SqlDbType.Int).Value = vFreeBookUID;
                dbCmd.Parameters.Add("@visShowAtHP", SqlDbType.Bit).Value = vShowatHP;


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



        public int Ebook_FeatureBuy_ADD(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_ADD_FeatureBuy]", dbConn); 
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@isShowatHP", SqlDbType.Bit).Value = vShowAtHp;
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



        public DataSet Ebook_FeatureBuy_LIST(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_FeatureBuyList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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



        public int EBook_FeatureBuy_Delete(int vFeatureBuyUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Delete_FeatureBuy]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vFeatureBuyUID", SqlDbType.Int).Value = vFeatureBuyUID;


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


        public int EBook_FeatureBuy_Update(int vFeatureBuyUID, bool vShowatHP)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Update_FeatureBuy]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vFeatureBuyUID", SqlDbType.Int).Value = vFeatureBuyUID;
                dbCmd.Parameters.Add("@visShowAtHP", SqlDbType.Bit).Value = vShowatHP;


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



        public DataSet Ebook_DashBoard(int vUserID, int vMerchantID, string vMobileLoginID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_DashBoard]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = vMerchantID;
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
                dbConn.Close();
            }

        }



        public DataSet Ebook_eStore_ManagementView(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_eStoreMgmtView]", dbConn);
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



        public DataSet Ebook_GeteStoreID(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_StoreID_GetbyUserID]", dbConn);
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



        public int Ebook_eStoreID_Validity(string vStoreID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_StoreID_Validity]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vStoreID", SqlDbType.VarChar).Value = vStoreID;
                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public int Ebook_eStoreID_Create(string vStoreID, int vUserID, int vMerchantID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_StoreID_Create]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vStoreID", SqlDbType.VarChar).Value = vStoreID;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.VarChar).Value = vMerchantID;
                
                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public int Ebook_HomePage_HideCatIds(int vUserID, string vCatIDList, int vSelMainCatId, int vCatType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_HideCatIsatHomePage]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCatIDList", SqlDbType.VarChar).Value = vCatIDList;
                dbCmd.Parameters.Add("@vSelMainCatId", SqlDbType.Int).Value = vSelMainCatId;
                dbCmd.Parameters.Add("@vCatType", SqlDbType.TinyInt).Value = vCatType;

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


        public int Ebook_HomePage_Hide_MainCatIds(int vUserID, string vCatIDList, int vCatType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_Hide_MainCats_atHomePage]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCatIDList", SqlDbType.VarChar).Value = vCatIDList;
                dbCmd.Parameters.Add("@vCatType", SqlDbType.TinyInt).Value = vCatType;

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




        public int Ebook_eStore_SaveSettings(int vUserID, int vShowUserCat, int vShowAdminCat, int vAllowSMSBuy, int vAllowPayPalBuy,int vAllowDirectBankIn, string vSelectedCurrency)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_eStore_SaveSettings]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vShowUserCat", SqlDbType.Int).Value = vShowUserCat;
                dbCmd.Parameters.Add("@vShowAdminCat", SqlDbType.Int).Value = vShowAdminCat;
                dbCmd.Parameters.Add("@vAllowSMSBuy", SqlDbType.Int).Value = vAllowSMSBuy;
                dbCmd.Parameters.Add("@vAllowPayPalBuy", SqlDbType.Int).Value = vAllowPayPalBuy;
                dbCmd.Parameters.Add("@vAllowDirectBankIn", SqlDbType.Int).Value = vAllowDirectBankIn;
                dbCmd.Parameters.Add("@vSelectedCurrency", SqlDbType.VarChar).Value = vSelectedCurrency;

                
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


        public int Ebook_eStore_SaveAdminBookDisplaySettings(int vUserID, int vEbooks, int vfeaturebuy, int vBestSeller, int vNewReleases, int vValueBuy, int vFree)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_eStore_SaveAdmBkDispSettings]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vEbooks", SqlDbType.Int).Value = vEbooks;
                dbCmd.Parameters.Add("@vfeaturebuy", SqlDbType.Int).Value = vfeaturebuy;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Int).Value = vBestSeller;
                dbCmd.Parameters.Add("@vNewReleases", SqlDbType.Int).Value = vNewReleases;
                dbCmd.Parameters.Add("@vValueBuy", SqlDbType.Int).Value = vValueBuy;
                dbCmd.Parameters.Add("@vFree", SqlDbType.Int).Value = vFree;


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



        public int Ebook_eStore_SaveNotifications(int vUserID, int vMerchantID,  int vNotifyUsers, int vNotifyAdmin, String vMobile1, String vMobile2, String vMobile3, String vMobile4, String vMobile5)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WP_eStore_SaveNotifySettings]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = vMerchantID;
                dbCmd.Parameters.Add("@vNofifyUserEbooks", SqlDbType.Bit).Value = vNotifyUsers;
                dbCmd.Parameters.Add("@vNofityAdminEbooks", SqlDbType.Bit).Value = vNotifyAdmin;
                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = vMobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = vMobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = vMobile3;
                dbCmd.Parameters.Add("@vMobile4", SqlDbType.VarChar).Value = vMobile4;
                dbCmd.Parameters.Add("@vMobile5", SqlDbType.VarChar).Value = vMobile5;
                
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




        public DataSet AdminSpecialPage_View(int vPageID, int vPageType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_AdmPage_ViewByPageID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vPageID", SqlDbType.Int).Value = vPageID;
                dbCmd.Parameters.Add("@vPageType", SqlDbType.TinyInt).Value = vPageType;

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


        public DataSet WpInfo_LeftMenu()
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpInfo_LeftMenu]", dbConn);
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


        public DataSet WpNews_LeftMenu()
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpNews_LeftMenu]", dbConn);
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


        public DataSet WpTraining_LeftMenu()
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpTraining_LeftMenu]", dbConn);
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


        public DataSet WpInfo_ListByUID(int vUID, string vType)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpInfo_ListbyUID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
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
                dbConn.Close();
            }

        }

        public DataSet WpTraining_ListByUID(int vUID, string vType)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpTraining_ListbyUID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
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
                dbConn.Close();
            }

        }

        public DataSet WpNews_ListByUID(int vUID, string vType)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpNews_ListbyUID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
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
                dbConn.Close();
            }

        }



        public DataSet EbAd_SmsCreditBalance_Retrieve(int vMerID) 
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[USP_EB_GetSMSCreditsBalance]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMerID;
               
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



        public int EbAd_SmsCreditBalance_Deduct(int vMID, decimal vCredits)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[USP_EB_DeductSMSCredits]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vCredits", SqlDbType.VarChar).Value = vCredits;


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



        public DataSet Retrieve_2WayEbookCodes(String vUserID, String vMID, String vSearchSql)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("USP_Retrieve_2WayEbookCodes", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@vSearchSql", SqlDbType.VarChar).Value = vSearchSql;

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



        public DataSet Retrieve_UserBankInfo(String vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_UserBankInfo", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vIdentifier", SqlDbType.Int).Value = vUserID;

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


        public DataSet Retrieve_UserProfileInfo(String vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_UserProfileInfo", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vIdentifier", SqlDbType.Int).Value = vUserID;

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



        public DataSet Retrieve_UserProfileInfo_ByUserID(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_UserProfileInfo_ByUserID", dbConn);
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



        public DataSet Eb_WEB_BuyBook(String vBookID, int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_EB_WEB_BuyBookInfo", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
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


        public DataSet Eb_WEB_BuyBookMerchantInfo(String vBookID, int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("[USP_EB_WEB_BuyBook_MerchantInfo]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
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


        public DataSet Eb_WEB_GetMerchantInfo(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("[USP_EB_WEB_BuyCart_MerchantInfo]", dbConn);
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




        public DataSet Retrieve_UserEmailInfo(String vIdentifier)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_UserEmailInfo", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vIdentifier", SqlDbType.Int).Value = vIdentifier;

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
        public int InsertUpdate_UserEmailInfo(String vIdentifier, String vEmail)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Insert_UserEmailInfo", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vIdentifier", SqlDbType.Int).Value = vIdentifier;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vEmail;
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
                dbConn.Close();
            }
        }


        /// <summary>
        /// Function to User : Store eVendor Code for registration. 
        /// </summary>
        /// <param name="ebook">HITECH SMS</param>
        /// <returns>Int</returns>
        /// <remarks>SP to insert eVendor Code for Registration </remarks> 
        /// 

        public int eBook_eVendorCodeRegister(String vKeyword, String vShortCode, String vMobileNo, String vMerchantID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Ebook_InsertVendorCode", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vKeyword", SqlDbType.VarChar).Value = vKeyword;
                dbCmd.Parameters.Add("@vShortCode", SqlDbType.VarChar).Value = vShortCode;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobileNo;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.VarChar).Value = vMerchantID;
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
                dbConn.Close();
            }
        }


        /// <summary>
        /// Function to User : Package Info for EBOOK 
        /// </summary>
        /// <param name="business">HITECH SMS</param>
        /// <returns>Dataset</returns>
        /// <remarks>This function is to validate user login</remarks> 

        public DataSet EBOOK_GetDetailsByMID(String vMID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("[USP_EBOOK_GetDetailsbyMID]", dbConn);
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
                dbConn.Close();
            }
        }


        public int Insert_TopupPin(String vMobile, String vTopupMobile, String vSMSPinNo)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_topupSMSpin_Online", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.BigInt).Value = vMobile;
                dbCmd.Parameters.Add("@topupMobile", SqlDbType.VarChar).Value = vTopupMobile;
                dbCmd.Parameters.Add("@smsPIN", SqlDbType.VarChar).Value = vSMSPinNo;
                dbCmd.Parameters.Add("@vMyResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                int MyResult = (int)dbCmd.Parameters["@vMyResult"].Value;
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

     

        public int EB_ChangePassword_PreCheck(String vMobileLoginID, String vCurrPassword)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_EB_ChangePwdCheck", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;
                dbCmd.Parameters.Add("@vCurrentPassword", SqlDbType.VarChar).Value = vCurrPassword;
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
                dbConn.Close();
            }

        }


        public int EB_ChangePassword(int vUserID,String vMobileLoginID,  String vCurrPassword, String vNewPassword)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ChangePassword_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;
                dbCmd.Parameters.Add("@CurrPassword", SqlDbType.VarChar).Value = vCurrPassword;
                dbCmd.Parameters.Add("@NewPassword", SqlDbType.VarChar).Value = vNewPassword;
                

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


        public String EBOOK_SendCCalerts(string vMobile, String vMessage,String vMsgID, String vShortcode,String vKeyword, String vBookCode, String vEmail, String vFullName)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Book2Email_SendCCAlerts]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.BigInt).Value = vMobile;
                dbCmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@MsgID", SqlDbType.VarChar).Value = vMsgID;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = vShortcode;
                dbCmd.Parameters.Add("@Keyword", SqlDbType.VarChar).Value = vKeyword;

                dbCmd.Parameters.Add("@EBookCode", SqlDbType.VarChar).Value = vBookCode;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = vFullName;

                dbCmd.Parameters.Add("@returnMessage", SqlDbType.VarChar).Direction = ParameterDirection.Output; 
                dbCmd.Parameters.Add("@ChargeStatus", SqlDbType.TinyInt).Direction = ParameterDirection.Output; 
                dbCmd.Parameters.Add("@rMerID", SqlDbType.BigInt).Direction = ParameterDirection.Output; ;


                int status = dbCmd.ExecuteNonQuery();
                String MyResult = (String)dbCmd.Parameters["@returnMessage"].Value;
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



        public int EB_GetEbookCountForUser(int vMerchantID, int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_EB_GetEbookCount", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = vMerchantID;
                dbCmd.Parameters.Add("@vCount", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                int MyResult = (int)dbCmd.Parameters["@vCount"].Value;
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

        public DataSet Ebook_RetrieveDetails(string vBookID, int vUserId, String @vLoginID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("USP_Retrieve_EbookDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = @vLoginID;

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


        public DataSet PhyBook_GetALL_Ebooks(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Phy_ADM_GetAllPhyEbooks]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public int PhyBook_RequestADD(int vUserID, String vMobileLoginID, string vMerchantID, int vPhyBookID1, String vPhyTemplate1, int vPhyBookID2, String vPhyTemplate2, int vBizCardID, String vPhyNameOnBook, String vPhoto1, String vPhoto2, int vDeliveryMode, String vAddress1, String vAddress2, String vCity, String vState, String vPostalCode, String vCountry)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Phy_ADM_RequestADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.BigInt).Value = vMerchantID;
                
                
                dbCmd.Parameters.Add("@vPhyBookID1", SqlDbType.Int).Value = vPhyBookID1;
                dbCmd.Parameters.Add("@vPhyTemplate1", SqlDbType.VarChar).Value = vPhyTemplate1;
                dbCmd.Parameters.Add("@vPhyBookID2", SqlDbType.Int).Value = vPhyBookID2;
                dbCmd.Parameters.Add("@vPhyTemplate2", SqlDbType.VarChar).Value = vPhyTemplate2;

                dbCmd.Parameters.Add("@vBizCardID", SqlDbType.Int).Value = vBizCardID;

                dbCmd.Parameters.Add("@vPhyNameOnBook", SqlDbType.NVarChar).Value = vPhyNameOnBook;
                dbCmd.Parameters.Add("@vPhoto1", SqlDbType.VarChar).Value = vPhoto1;
                dbCmd.Parameters.Add("@vPhoto2", SqlDbType.VarChar).Value = vPhoto2;

                dbCmd.Parameters.Add("@vDeliveryMode", SqlDbType.Int).Value = vDeliveryMode;

                dbCmd.Parameters.Add("@vAddress1", SqlDbType.NVarChar).Value = vAddress1;
                dbCmd.Parameters.Add("@vAddress2", SqlDbType.NVarChar).Value = vAddress2;
                dbCmd.Parameters.Add("@vCity", SqlDbType.NVarChar).Value = vCity;
                dbCmd.Parameters.Add("@vState", SqlDbType.NVarChar).Value = vState;
                dbCmd.Parameters.Add("@vPostalCode", SqlDbType.NVarChar).Value = vPostalCode;
                dbCmd.Parameters.Add("@vCountry", SqlDbType.NVarChar).Value = vCountry;
                

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


        public DataSet PhyBook_Get_EbookRequestID(int vUserID, int vRequestID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Phy_ADM_GetRequestDetails]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vRequestID", SqlDbType.Int).Value = vRequestID;

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


        public int PhyBook_ValidateBookRequest(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Phy_ADM_ValidateBookRequest]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
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




        public int PhyBook_ConfirmBookRequest(int vUserID, int vPhyBookReqID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Phy_ADM_ConfirmBookRequest]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vPhyBookReqID", SqlDbType.Int).Value = vPhyBookReqID;
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



        public int EBook_RegProcess_GetStatus(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_RegProcess_GetStatus]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
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
                dbConn.Close();
            }



        }


        public DataSet EBook_RegProcess_GetDetails(int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_RegProcess_GetDetails]", dbConn);
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


        public int Insert_UnSubscribedEmail(String vUserID, String vEbookID, String vEmail)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("USP_Insert_UnSubscribedEmail", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = vUserID;
                dbCmd.Parameters.Add("@vEbookID", SqlDbType.VarChar).Value = vEbookID;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@vMyResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                int MyResult = (int)dbCmd.Parameters["@vMyResult"].Value;
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


        public int Update_UnSubscribedEmail(String vUserID, String vSno)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("USP_Update_UnSubscribedEmail", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = vUserID;
                dbCmd.Parameters.Add("@vSno", SqlDbType.BigInt).Value = vSno;
                dbCmd.Parameters.Add("@vMyResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                int MyResult = (int)dbCmd.Parameters["@vMyResult"].Value;
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

        public DataSet Retrieve_UnSubscribedEmail(String vUserID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_UnSubscribedEmail", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
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
                dbConn.Close();
            }
        }

        public DataSet Retrieve_EbookEmailMarketing(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Retrieve_EbookEmailMarketing", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
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
                dbConn.Close();
            }
        }

        public int Check_EmailSystem(String vMobileLoginID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Check_EmailSystem", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.Int).Value = vMobileLoginID;
                dbCmd.Parameters.Add("@vMyResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                int MyResult = (int)dbCmd.Parameters["@vMyResult"].Value;
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




        public long ShoppingCart_PreInsert(int vUserID, String vItemString, int vItemsCount, decimal vTotalAmount)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_ShopCart_PreInsert", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vItemString", SqlDbType.VarChar).Value = vItemString;
                dbCmd.Parameters.Add("@vItemsCount", SqlDbType.Int).Value = vItemsCount;
                dbCmd.Parameters.Add("@vTotalAmount", SqlDbType.Money).Value = vTotalAmount;
                
                dbCmd.Parameters.Add("@vCartID", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                long MyResult = (long)dbCmd.Parameters["@vCartID"].Value;
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





        public DataSet EBook_Get_MainCategories(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_View_MainCategories]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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



        public DataSet EBook_Get_SUBCategories(int vUserID,int vMainCatId, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_View_SubCategories_ByCatMainID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = vMainCatId;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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



        #region ...Bank-In 


        public DataSet BankIn_GetList(string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_Listing]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet BankIn_GetUserBanks(int vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_UserLising]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Bank_Countries(string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_Countries]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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



        public DataSet Bank_GetBankInfoByCountry(int vCountryCode)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_GetBankByCountry]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vCountryCode", SqlDbType.Int).Value = vCountryCode;

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





        public DataSet Bank_GetUserInfo(int vUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_GetUserInfo]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;

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


        public int Bank_User_Add(int vBankID, String vBankActNo, String vFullName, String vRemarks, bool vDisplay, int vUserID, int vMerchantID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_UserAdd]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBankID", SqlDbType.Int).Value = vBankID;
                dbCmd.Parameters.Add("@vBankActNo", SqlDbType.VarChar).Value = vBankActNo;
                dbCmd.Parameters.Add("@vFullName", SqlDbType.NVarChar).Value = vFullName;
                dbCmd.Parameters.Add("@vRemarks", SqlDbType.NVarChar).Value = vRemarks;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = vDisplay;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = vMerchantID;
                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public int Bank_User_Update(int vBank_UID, int vBankID, String vBankActNo, String vFullName, String vRemarks, bool vDisplay, int vUserID, int vMerchantID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_UserUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBank_UID", SqlDbType.Int).Value = vBank_UID;
                dbCmd.Parameters.Add("@vBankID", SqlDbType.Int).Value = vBankID;
                dbCmd.Parameters.Add("@vBankActNo", SqlDbType.VarChar).Value = vBankActNo;
                dbCmd.Parameters.Add("@vFullName", SqlDbType.NVarChar).Value = vFullName;
                dbCmd.Parameters.Add("@vRemarks", SqlDbType.NVarChar).Value = vRemarks;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = vDisplay;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = vMerchantID;
                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        public int Bank_User_Delete(int vUID, int vUserID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_UserDelete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

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





        public int Bank_Client_PreInsert(String vbFullName, String vbMobile, String vbEmail, string vbTotalAmount, String vbCurrency, string vPurchaseItems, int vUserID, string vTranID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BankIn_ClientPreInsert]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vbFullName", SqlDbType.NVarChar).Value = vbFullName;
                dbCmd.Parameters.Add("@vbMobile", SqlDbType.VarChar).Value = vbMobile;
                dbCmd.Parameters.Add("@vbEmail", SqlDbType.VarChar).Value = vbEmail;
                dbCmd.Parameters.Add("@vbCurrency", SqlDbType.VarChar).Value = vbCurrency;
                dbCmd.Parameters.Add("@vbTotalAmount", SqlDbType.VarChar).Value = vbTotalAmount;
                dbCmd.Parameters.Add("@vPurchaseItems", SqlDbType.VarChar).Value = vPurchaseItems;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vTransactionID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
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



        public int Bank_Client_StoreBuyer(String vbFullName, String vbMobile, String vbEmail,int vUserID, string vTranID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BankIn_ClientBuyer]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vbFullName", SqlDbType.NVarChar).Value = vbFullName;
                dbCmd.Parameters.Add("@vbMobile", SqlDbType.VarChar).Value = vbMobile;
                dbCmd.Parameters.Add("@vbEmail", SqlDbType.VarChar).Value = vbEmail;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vTransactionID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
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



        public int Bank_Client_Add(int vBankID, String vBankInBy, string vBankInAmt, String vBankInDate, String vBankInTime, String vBankInSlip, String vBankInRef, String vPurchaseDesc, string vPurchaseItems, String vTranID, int vUserID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BankIn_ClientAdd]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBankID", SqlDbType.Int).Value = vBankID;
                dbCmd.Parameters.Add("@vBankInBy", SqlDbType.NVarChar).Value = vBankInBy;
                dbCmd.Parameters.Add("@vBankInAmt", SqlDbType.VarChar).Value = vBankInAmt;
                dbCmd.Parameters.Add("@vBankInDate", SqlDbType.VarChar).Value = vBankInDate;
                dbCmd.Parameters.Add("@vBankInTime", SqlDbType.VarChar).Value = vBankInTime;
                dbCmd.Parameters.Add("@vBankInSlip", SqlDbType.VarChar).Value = vBankInSlip;
                dbCmd.Parameters.Add("@vBankInRef", SqlDbType.VarChar).Value = vBankInRef;
                dbCmd.Parameters.Add("@vPurchaseDesc", SqlDbType.NVarChar).Value = vPurchaseDesc;
                dbCmd.Parameters.Add("@vPurchaseItems", SqlDbType.VarChar).Value = vPurchaseItems;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
                return MyResult;
               // string inTranID = (string)dbCmd.Parameters["vTranID"].Value;
               // return inTranID;


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


        public int Bank_Transaction_Update(int vUserID, String vTranID, string vRemarks)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BankIn_TransUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.Parameters.Add("@vRemarks", SqlDbType.VarChar).Value = vRemarks;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
                return MyResult;
                // string inTranID = (string)dbCmd.Parameters["vTranID"].Value;
                // return inTranID;


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



        public DataSet Bank_Client_GetBankInsList(int vUserId, String vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BankIn_ByClientList]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


        public DataSet Bank_Client_GetBankIns_ByTranID(String vUID, String vTranID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BankIn_ByTranID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.VarChar).Value = vTranID;

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



        public DataSet BankIn_UserSettings(int vUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_UserSettings]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;
               
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


        public DataSet BankIn_GetBookDetails_ByBooksID(int vUserID,String vTranID, String vBookIdsString)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_GetBookDetails_ByBookIds]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.Parameters.Add("@vBookIDStr", SqlDbType.VarChar).Value = vBookIdsString;


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

        #endregion ...end of BankIn


        #endregion




        #region SMS Payments 

        public int SMSPay_Bank_Add(int vIdentifier, String vBankActNo, String vBankName, String vBankAddress, String vIC, int vBankCountry)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_SMSPay_BankAddEdit]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vIdentifier", SqlDbType.Int).Value = vIdentifier;
                dbCmd.Parameters.Add("@vIC", SqlDbType.VarChar).Value = vIC;
                dbCmd.Parameters.Add("@vBankActNo", SqlDbType.VarChar).Value = vBankActNo;
                dbCmd.Parameters.Add("@vBankName", SqlDbType.VarChar).Value = vBankName;
                dbCmd.Parameters.Add("@vBankAddress", SqlDbType.VarChar).Value = vBankAddress;
                dbCmd.Parameters.Add("@vBankCountry", SqlDbType.Int).Value = vBankCountry;

                dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                //return status;

                int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


        #endregion





    }

       
    
    
    }


