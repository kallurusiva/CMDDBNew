using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ebDBcode
/// </summary>
public class ebDBcode
{


    #region variables

    protected static SqlConnection dbConn;
    protected static SqlCommand dbCmd;
    protected static SqlDataAdapter dbAdap;
    protected static SqlDataReader dbReader;
    static DataSet ds;
    //DataTable dt;

    static string eBookdbConnString = ConfigurationManager.AppSettings["eBookDB"].ToString(); 



    #endregion



	static ebDBcode()
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




    #region Functionality


    
        /// Function to User : Validate User Login
        /// </summary>
        /// <param name="ebook">EBook</param>
        /// <returns>Int</returns>
        /// <remarks>Validate user login</remarks> 

        public static DataSet Validate_UserLogin(String vLoginID, String vPwd)
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

        public static DataSet EBOOK_GetDetailsbyMID(String vMID)
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




        public static DataSet EMS_GetEbookUsers(string vSearchQuery)
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



        public static int InsertUpdate_Ebook_EMSContent(string vAdminID, string vAdminPwd, string vEnquiryID, string vEnquiryPwd, string vHttpUrlLink, long vMobileLoginID)
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



        public static DataSet Retrieve_EMSContent(String vMobileId, string vSearchStr)
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



        public static DataSet Category_Listing(int vUserID, string vSearchStr)
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


        public static int Category_Add(int vCatMainId, string vCategoryName, bool vDisplay, int vUserID, int vMerchantID)
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


        public static int Category_Delete(int vCatId, int vUserID)
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


        public static int Category_Update(int vUserID, int vCatId, string vCategoryName, bool vDisplay)
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


        public static int Category_Validate(int vUserID, string vCategoryName)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CategoryNameValidate]", dbConn);
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



        


        public static int EBook_Add()
        {

            
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = ebEntity.catID;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.VarChar).Value = ebEntity.categoryName;

                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = ebEntity.catMainID;

                dbCmd.Parameters.Add("@vPrice", SqlDbType.Money).Value = ebEntity.Price;
                dbCmd.Parameters.Add("@vDiscount", SqlDbType.TinyInt).Value = ebEntity.Discount;

                dbCmd.Parameters.Add("@vDescription", SqlDbType.NVarChar).Value = ebEntity.Description;

                dbCmd.Parameters.Add("@vSubject", SqlDbType.NVarChar).Value = ebEntity.ReplySubject;
                dbCmd.Parameters.Add("@vSenderEmailID", SqlDbType.VarChar).Value = ebEntity.SenderEmailID;
                dbCmd.Parameters.Add("@vSmsReply", SqlDbType.NVarChar).Value = ebEntity.ReplySMS;
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

                 dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = 7484;
                 dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = 0;

                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3;

                dbCmd.Parameters.Add("@vPrepaid", SqlDbType.Bit).Value = ebEntity.isPrepaid;
                dbCmd.Parameters.Add("@vPrepaidPrice", SqlDbType.Money).Value = ebEntity.PrepaidPrice;

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

        public static int EBook_AddNew(string BookName, string BookTitle, string BookRefID, int catID, string categoryName, int catMainID, decimal Price, decimal Discount, string Description, string ReplySubject, string SenderEmailID, string ReplySMS, string ReplyEmail, int LaunchStatus, Boolean isDisplay, Boolean isFeatured, Boolean isBestSeller, Boolean isBuySMS, Boolean isBuyPayPal, string ImgFileName, string ImgFilePath, string EbookFileName, string EbookFilePath, string CCmobile1, string CCmobile2, string CCmobile3, Boolean isPrepaid, decimal PrepaidPrice, string AuthorName, string AuthorMobile, string IntroducerMobile, int AuthorPercent, int ownerPercent, int IntroducerPercent, int GSPercent, string AssignStatus)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookADDNew]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = BookRefID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = catID;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.VarChar).Value = categoryName;

                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = catMainID;

                dbCmd.Parameters.Add("@vPrice", SqlDbType.Money).Value = Price;
                dbCmd.Parameters.Add("@vDiscount", SqlDbType.TinyInt).Value = Discount;

                dbCmd.Parameters.Add("@vDescription", SqlDbType.NVarChar).Value = Description;

                dbCmd.Parameters.Add("@vSubject", SqlDbType.NVarChar).Value = ReplySubject;
                dbCmd.Parameters.Add("@vSenderEmailID", SqlDbType.VarChar).Value = SenderEmailID;
                dbCmd.Parameters.Add("@vSmsReply", SqlDbType.NVarChar).Value = ReplySMS;
                dbCmd.Parameters.Add("@vEmailReply", SqlDbType.NVarChar).Value = ReplyEmail;

                dbCmd.Parameters.Add("@vLaunchStatus", SqlDbType.TinyInt).Value = LaunchStatus;

                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = isDisplay;
                dbCmd.Parameters.Add("@vFeatured", SqlDbType.Bit).Value = isFeatured;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Bit).Value = isBestSeller;
                dbCmd.Parameters.Add("@vBuySMS", SqlDbType.Bit).Value = isBuySMS;
                dbCmd.Parameters.Add("@vBuyPayPal", SqlDbType.Bit).Value = isBuyPayPal;


                dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = ImgFileName;
                dbCmd.Parameters.Add("@vImageFileURL", SqlDbType.NVarChar).Value = ImgFilePath;
                dbCmd.Parameters.Add("@vEbookFileName", SqlDbType.NVarChar).Value = EbookFileName;
                dbCmd.Parameters.Add("@vEbookFileURL", SqlDbType.NVarChar).Value = EbookFilePath;

                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = 7484;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = 0;

                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = CCmobile3;

                dbCmd.Parameters.Add("@vPrepaid", SqlDbType.Bit).Value = isPrepaid;
                dbCmd.Parameters.Add("@vPrepaidPrice", SqlDbType.Money).Value = PrepaidPrice;

                dbCmd.Parameters.Add("@vAuthorName", SqlDbType.VarChar).Value = AuthorName;
                dbCmd.Parameters.Add("@vAuthorMobile", SqlDbType.VarChar).Value = AuthorMobile;
                dbCmd.Parameters.Add("@vIntroducerMobile", SqlDbType.VarChar).Value = IntroducerMobile;

                dbCmd.Parameters.Add("@vAuthorPercent", SqlDbType.VarChar).Value = AuthorPercent;
                dbCmd.Parameters.Add("@vOwnerPercent", SqlDbType.VarChar).Value = ownerPercent;
                dbCmd.Parameters.Add("@vIntroducerPercent", SqlDbType.VarChar).Value = IntroducerPercent;
                dbCmd.Parameters.Add("@vGSPercent", SqlDbType.VarChar).Value = GSPercent;
                dbCmd.Parameters.Add("@AssignStatus", SqlDbType.VarChar).Value = AssignStatus;

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


        public static int EBook_AddFranchise()
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = ebEntity.catID;
                dbCmd.Parameters.Add("@vCategoryName", SqlDbType.VarChar).Value = ebEntity.categoryName;

                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = ebEntity.catMainID;

                dbCmd.Parameters.Add("@vPrice", SqlDbType.Money).Value = ebEntity.Price;
                dbCmd.Parameters.Add("@vDiscount", SqlDbType.TinyInt).Value = ebEntity.Discount;

                dbCmd.Parameters.Add("@vDescription", SqlDbType.NVarChar).Value = ebEntity.Description;

                dbCmd.Parameters.Add("@vSubject", SqlDbType.NVarChar).Value = ebEntity.ReplySubject;
                dbCmd.Parameters.Add("@vSenderEmailID", SqlDbType.VarChar).Value = ebEntity.SenderEmailID;
                dbCmd.Parameters.Add("@vSmsReply", SqlDbType.NVarChar).Value = ebEntity.ReplySMS;
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

                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = 2222;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = 0;

                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3;

                dbCmd.Parameters.Add("@vPrepaid", SqlDbType.Bit).Value = ebEntity.isPrepaid;
                dbCmd.Parameters.Add("@vPrepaidPrice", SqlDbType.Money).Value = ebEntity.PrepaidPrice;

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

        public static int EBook_Update()
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.NVarChar).Value = ebEntity.BookID;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;
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
                dbCmd.Parameters.Add("@vFeatured", SqlDbType.Bit).Value = ebEntity.isFeatured;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Bit).Value = ebEntity.isBestSeller;
                dbCmd.Parameters.Add("@vBuySMS", SqlDbType.Bit).Value = ebEntity.isBuySMS;
                dbCmd.Parameters.Add("@vBuyPayPal", SqlDbType.Bit).Value = ebEntity.isBuyPayPal;


                dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = ebEntity.ImgFileName;
                dbCmd.Parameters.Add("@vImageFileURL", SqlDbType.NVarChar).Value = ebEntity.ImgFilePath;
                dbCmd.Parameters.Add("@vEbookFileName", SqlDbType.NVarChar).Value = ebEntity.EbookFileName;
                dbCmd.Parameters.Add("@vEbookFileURL", SqlDbType.NVarChar).Value = ebEntity.EbookFilePath;
                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = 7484;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = ebEntity.MerchantID;


                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3;

                dbCmd.Parameters.Add("@vPrepaid", SqlDbType.Bit).Value = ebEntity.isPrepaid;
                dbCmd.Parameters.Add("@vPrepaidPrice", SqlDbType.Money).Value = ebEntity.PrepaidPrice;

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

        public static int EBook_UpdateNew(string AuthorName, string AuthorMobile, string IntroducerMobile, int AuthorPercent, int ownerPercent, int IntroducerPercent, int GSPercent, int position, string AssignStatus)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookUpdateNew]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.NVarChar).Value = ebEntity.BookID;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;
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
                dbCmd.Parameters.Add("@vFeatured", SqlDbType.Bit).Value = ebEntity.isFeatured;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Bit).Value = ebEntity.isBestSeller;
                dbCmd.Parameters.Add("@vBuySMS", SqlDbType.Bit).Value = ebEntity.isBuySMS;
                dbCmd.Parameters.Add("@vBuyPayPal", SqlDbType.Bit).Value = ebEntity.isBuyPayPal;


                dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = ebEntity.ImgFileName;
                dbCmd.Parameters.Add("@vImageFileURL", SqlDbType.NVarChar).Value = ebEntity.ImgFilePath;
                dbCmd.Parameters.Add("@vEbookFileName", SqlDbType.NVarChar).Value = ebEntity.EbookFileName;
                dbCmd.Parameters.Add("@vEbookFileURL", SqlDbType.NVarChar).Value = ebEntity.EbookFilePath;
                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = 7484;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = ebEntity.MerchantID;


                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3;

                dbCmd.Parameters.Add("@vPrepaid", SqlDbType.Bit).Value = ebEntity.isPrepaid;
                dbCmd.Parameters.Add("@vPrepaidPrice", SqlDbType.Money).Value = ebEntity.PrepaidPrice;

                dbCmd.Parameters.Add("@vAuthorName", SqlDbType.VarChar).Value = AuthorName;
                dbCmd.Parameters.Add("@vAuthorMobile", SqlDbType.VarChar).Value = AuthorMobile;
                dbCmd.Parameters.Add("@vIntroducerMobile", SqlDbType.VarChar).Value = IntroducerMobile;

                dbCmd.Parameters.Add("@vAuthorPercent", SqlDbType.VarChar).Value = AuthorPercent;
                dbCmd.Parameters.Add("@vOwnerPercent", SqlDbType.VarChar).Value = ownerPercent;
                dbCmd.Parameters.Add("@vIntroducerPercent", SqlDbType.VarChar).Value = IntroducerPercent;
                dbCmd.Parameters.Add("@vGSPercent", SqlDbType.VarChar).Value = GSPercent;
                dbCmd.Parameters.Add("@vPosition", SqlDbType.SmallInt).Value = position;
                dbCmd.Parameters.Add("@AssignStatus", SqlDbType.VarChar).Value = AssignStatus;

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

        public static int EBook_UpdateFranchise()
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BookUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.NVarChar).Value = ebEntity.BookID;
                dbCmd.Parameters.Add("@vBookName", SqlDbType.NVarChar).Value = ebEntity.BookName;
                dbCmd.Parameters.Add("@vBookTitle", SqlDbType.NVarChar).Value = ebEntity.BookTitle;
                dbCmd.Parameters.Add("@vBookRefID", SqlDbType.VarChar).Value = ebEntity.BookRefID;
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
                dbCmd.Parameters.Add("@vFeatured", SqlDbType.Bit).Value = ebEntity.isFeatured;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.Bit).Value = ebEntity.isBestSeller;
                dbCmd.Parameters.Add("@vBuySMS", SqlDbType.Bit).Value = ebEntity.isBuySMS;
                dbCmd.Parameters.Add("@vBuyPayPal", SqlDbType.Bit).Value = ebEntity.isBuyPayPal;


                dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = ebEntity.ImgFileName;
                dbCmd.Parameters.Add("@vImageFileURL", SqlDbType.NVarChar).Value = ebEntity.ImgFilePath;
                dbCmd.Parameters.Add("@vEbookFileName", SqlDbType.NVarChar).Value = ebEntity.EbookFileName;
                dbCmd.Parameters.Add("@vEbookFileURL", SqlDbType.NVarChar).Value = ebEntity.EbookFilePath;
                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = 2222;
                dbCmd.Parameters.Add("@vMerchantID", SqlDbType.Int).Value = ebEntity.MerchantID;


                dbCmd.Parameters.Add("@vMobile1", SqlDbType.VarChar).Value = ebEntity.CCmobile1;
                dbCmd.Parameters.Add("@vMobile2", SqlDbType.VarChar).Value = ebEntity.CCmobile2;
                dbCmd.Parameters.Add("@vMobile3", SqlDbType.VarChar).Value = ebEntity.CCmobile3;

                dbCmd.Parameters.Add("@vPrepaid", SqlDbType.Bit).Value = ebEntity.isPrepaid;
                dbCmd.Parameters.Add("@vPrepaidPrice", SqlDbType.Money).Value = ebEntity.PrepaidPrice;

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




        public static int EBook_Add_ValueBuy(String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5, int vBooksCount, bool vShowAtHp)
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



                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = 7484;
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


        public static int EBook_Update_ValueBuy(String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5, int vBooksCount, bool vShowAthp)
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
                dbCmd.Parameters.Add("@vCatID", SqlDbType.Int).Value = ebEntity.catID;
                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = ebEntity.catMainID;
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

               


                dbCmd.Parameters.Add("@vCreatedBy", SqlDbType.Int).Value = 7484;
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



        public static DataSet Ebook_Edit_ValueBuy(string vBookID, int vUserID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ValueBuy_EditByBookID]", dbConn);
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



        public static DataSet Ebook_CheckValueBuyBookIDs(int vBookCount, String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5)
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

        public static DataSet Ebook_Listing(int vPageNo, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_BooksListingPaging]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
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

        public static DataSet Ebook_Listing_Search(int vPageNo, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_BooksListingPaging_Search]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
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

        public static DataSet Ebook_Listing_SearchNew(int vPageNo, string vSearchStr, string vSearchType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_BooksListingPaging_SearchNew]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchType", SqlDbType.VarChar).Value = vSearchType;
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

        public static DataSet Ebook_Listing_UsersSearchNew(int vPageNo, string vSearchStr, string vSearchType)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_BooksListingPaging_UserSearchNew]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchType", SqlDbType.VarChar).Value = vSearchType;
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

        public static DataSet Ebook_ListingUser(int vPageNo, string vMobile)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_BooksListingUsers]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;

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

        public static DataSet Ebook_ListingFranchise(int vPageNo, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_BooksListingPagingFranchise]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
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



        public static DataSet Ebook_Edit(string vBookID)
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


        public static int EBook_Delete(string vBookID, int vUID)
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



        public static int AdminSpecialPage_AddEdit(int vPageID, string vPageTitle, String vPageContent,int vPageType, bool vDisplay)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_AdmPage_Create]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vPageID", SqlDbType.Int).Value = vPageID;
                dbCmd.Parameters.Add("@vPageTitle", SqlDbType.NVarChar).Value = vPageTitle;
                dbCmd.Parameters.Add("@vPageContent", SqlDbType.NVarChar).Value = vPageContent;
                dbCmd.Parameters.Add("@vPageType", SqlDbType.TinyInt).Value = vPageType;
                dbCmd.Parameters.Add("@isDisplay", SqlDbType.Bit).Value = vDisplay;

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




        public static DataSet AdminSpecialPage_ViewEdit(int vPageID, int vPageType)
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


        public static int WpInfo_AddEdit(int vUID, string vPageTitle, String vPageContent, int vPageType, bool vDisplay)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpInfo_CreateUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
                dbCmd.Parameters.Add("@vTitle", SqlDbType.NVarChar).Value = vPageTitle;
                dbCmd.Parameters.Add("@vContent", SqlDbType.NVarChar).Value = vPageContent;
                dbCmd.Parameters.Add("@vType", SqlDbType.Int).Value = vPageType;
                dbCmd.Parameters.Add("@isDisplay", SqlDbType.Bit).Value = vDisplay;

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


        public static DataSet WpInfo_ListByUID(int vUID, string vType)
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

        public static int WpInfo_Delete(int vUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WPinfoDelete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUID", SqlDbType.NVarChar).Value = vUID;
                
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


        public static DataSet WpFreeze_Details()
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpFreeze_Details]", dbConn);
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


        public static int WpTraining_AddEdit(int vUID, string vPageTitle, String vPageContent, int vPageType, bool vDisplay)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpTraining_CreateUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
                dbCmd.Parameters.Add("@vTitle", SqlDbType.NVarChar).Value = vPageTitle;
                dbCmd.Parameters.Add("@vContent", SqlDbType.NVarChar).Value = vPageContent;
                dbCmd.Parameters.Add("@vType", SqlDbType.Int).Value = vPageType;
                dbCmd.Parameters.Add("@isDisplay", SqlDbType.Bit).Value = vDisplay;

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


        public static DataSet WpTraining_ListByUID(int vUID, string vType)
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

        public static int WpTraining_Delete(int vUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WPTrainingDelete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUID", SqlDbType.NVarChar).Value = vUID;

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



        public static int WpNews_AddEdit(int vUID, string vPageTitle, String vPageContent, int vPageType, bool vDisplay)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("[usp_WpNews_CreateUpdate]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUID", SqlDbType.Int).Value = vUID;
                dbCmd.Parameters.Add("@vTitle", SqlDbType.NVarChar).Value = vPageTitle;
                dbCmd.Parameters.Add("@vContent", SqlDbType.NVarChar).Value = vPageContent;
                dbCmd.Parameters.Add("@vType", SqlDbType.Int).Value = vPageType;
                dbCmd.Parameters.Add("@isDisplay", SqlDbType.Bit).Value = vDisplay;

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


        public static DataSet WpNews_ListByUID(int vUID, string vType)
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

        public static int WpNews_Delete(int vUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_WPNewsDelete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUID", SqlDbType.NVarChar).Value = vUID;

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

        public static int Insert_WEB_ErrorLog(string vURL, string vSource, string vMessage, string vStackTrace, string vBaseException)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("USP_ERROR_Insert_ErrorLog", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vURL", SqlDbType.VarChar).Value = vURL;
                dbCmd.Parameters.Add("@vSource", SqlDbType.VarChar).Value = vSource;
                dbCmd.Parameters.Add("@vMessage", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@vStackTrace", SqlDbType.VarChar).Value = vStackTrace;
                dbCmd.Parameters.Add("@vBaseException", SqlDbType.VarChar).Value = vBaseException;

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


        public static DataSet GET_BookIDs(String vPrefix)
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


        public static DataSet Ebook_GetBookDetails(string vBookID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_ebAD_GetDetails_byBookID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = 7484;

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



        public static int EBook_ADD_FeatureBuy(int vBookUID, string vBookID, int vUserID, bool vShowAtHp)
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

        public static int EBook_ADD_FeatureBuyNew(int vBookUID, string vBookID, int vUserID, bool vShowAtHp,int position)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_ADD_FeatureBuyNew]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@isShowatHP", SqlDbType.Bit).Value = vShowAtHp;
                dbCmd.Parameters.Add("@position", SqlDbType.SmallInt).Value = position;
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


        public static DataSet Ebook_Listing_FeatureBuy(string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Listing_FeatureBuy]", dbConn);
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


        public static int EBook_Delete_FeatureBuy(int vFeatureBuyUID)
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




        public static int EBook_Update_FeatureBuy(int vFeatureBuyUID, bool vShowatHP)
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



        //Best Seller 
    

        public static int EBook_ADD_BestSeller(int vBookUID, string vBookID, int vUserID, bool vShowAtHp)
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

        public static int EBook_ADD_BestSellerNew(int vBookUID, string vBookID, int vUserID, bool vShowAtHp, int position)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_BestSeller_ADDNew]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@isShowatHP", SqlDbType.Bit).Value = vShowAtHp;
                dbCmd.Parameters.Add("@position", SqlDbType.SmallInt).Value = position;
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


        public static DataSet Ebook_Listing_BestSeller(string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_BestSeller_Listing]", dbConn);
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

        public static DataSet Ebook_Listing_Free(string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Free_Listing]", dbConn);
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


    //... New Releases 

        public static int EBook_ADD_NewRelease(int vBookUID, string vBookID, int vUserID, bool vShowAtHp)
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

        public static int EBook_ADD_NewReleaseNew(int vBookUID, string vBookID, int vUserID, bool vShowAtHp, int position)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_NewRelease_ADDNew]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@isShowatHP", SqlDbType.Bit).Value = vShowAtHp;
                dbCmd.Parameters.Add("@position", SqlDbType.SmallInt).Value = position;
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

        public static int EBook_ADD_Free(int vBookUID, string vBookID, int vUserID, bool vShowAtHp)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_Free_ADD]", dbConn);
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

        public static int EBook_ADD_FreeNew(int vBookUID, string vBookID, int vUserID, bool vShowAtHp, int position)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_eb_Free_ADDNew]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookUID", SqlDbType.Int).Value = vBookUID;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@isShowatHP", SqlDbType.Bit).Value = vShowAtHp;
                dbCmd.Parameters.Add("@position", SqlDbType.SmallInt).Value = position;
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


        public static DataSet Ebook_Listing_NewRelease(string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_NewRelease_Listing]", dbConn);
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

        public static int EBook_Delete_NewRelease(int vBestSellerUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Delete_NewRelease]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vNewReleaseUID", SqlDbType.Int).Value = vBestSellerUID;


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




        public static int EBook_Update_BestSeller(int vBestSellerUID, bool vShowatHP)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_NewRelease_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vNewSellerUID", SqlDbType.Int).Value = vBestSellerUID;
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




        public static DataSet Ebook_Listing_ValueBuy(int vUserID, string vSearchStr)
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



        public static int EBook_Delete_BestSeller(int vBestSellerUID)
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


        public static int EBook_Delete_Free(int vFreeUID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Delete_Free]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vFreeUID", SqlDbType.Int).Value = vFreeUID;


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

      


        public static int EBook_Delete_ValueBuy(int vValueBuyUID)
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


       


        public static int Ebook_ShowHide_HpItems(int vUserID, string vBookID, int vBookUID, int vBookType, bool vChkHpShow)
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


        public static DataSet EBOOK_GetBook2EmailDetails2(string vBookID)
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



        public static int CatMain_Add(string vCategoryName, bool vDisplay, int vUserID, int vMerchantID)
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


        public static int CatMain_Update(int vUserID, int vCatId, string vCategoryName, bool vDisplay)
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

        public static int Attach_Franchise(string vMobile, int vCatId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[USPT_Franchise_Attach]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vCatMainID", SqlDbType.Int).Value = vCatId;
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


        public static int CatMain_Delete(int vCatId, int vUserID)
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


        public static int CatMain_Validate(int vUserID, string vCategoryName)
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



        public static DataSet CatMain_Listing(int vUserID, string vSearchStr)
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

        public static DataSet CatMain_ListingFranchise(string vMobile)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_CatMain_ListingFranchise]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;

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

        public static DataSet CatMain_Categories(int vUserID, string vSearchStr)
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

        public static DataSet CurrencyConvert_List(string vUserID, string vSearchStr)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_CurrencyConvert_List]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserID;
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

        public static int CurrencyConvert_Update(string vUserID, string vCurrency, double vPoints)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_ADM_CurrencyConvert_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vCurrency", SqlDbType.VarChar).Value = vCurrency;
                dbCmd.Parameters.Add("@vPoints", SqlDbType.Money).Value = vPoints;
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



        public static DataSet Bank_Countries(string vSearchStr)
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



        public static int Bank_Add(string vBankName, String vBankLogo, String vSwiftCode, String vCountryName, String vCountryCode, String vRemarks, bool vDisplay)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_ADD]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBankName", SqlDbType.NVarChar).Value = vBankName;
                dbCmd.Parameters.Add("@vBankLogo", SqlDbType.VarChar).Value = vBankLogo;
                dbCmd.Parameters.Add("@vSwiftCode", SqlDbType.VarChar).Value = vSwiftCode;
                dbCmd.Parameters.Add("@vCountryName", SqlDbType.VarChar).Value = vCountryName;
                dbCmd.Parameters.Add("@vCountryCode", SqlDbType.Int).Value = vCountryCode;
                dbCmd.Parameters.Add("@vRemarks", SqlDbType.NVarChar).Value = vRemarks;
                dbCmd.Parameters.Add("@vDisplay", SqlDbType.Bit).Value = vDisplay;
                dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

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



        public static DataSet Bank_Listing(string vSearchStr)
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


        public static int Bank_Delete(int vBankID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_Delete]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBankID", SqlDbType.Int).Value = vBankID;

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


        public static int Bank_Update(int vBankId, string vBankName, bool vDisplay)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_EB_Bank_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBankId", SqlDbType.Int).Value = vBankId;
                dbCmd.Parameters.Add("@vBankName", SqlDbType.NVarChar).Value = vBankName;
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


        public static DataSet Ebook_getMobileExists(string vMobile)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_getMobileExists", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;

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