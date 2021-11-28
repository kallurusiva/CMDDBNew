using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;


/// <summary>
/// Summary description for newDBS
/// </summary>
 
    public class newDBS
    {
        #region Variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataReader dbReader;
        protected SqlDataAdapter dbAdap;    

        DataSet dsShortCode;
        String dbConnString = String.Empty;
        String strSQL = String.Empty;

        #endregion        

        public DataSet ebook_getProfitShare32828(string vMID, string vPageNo, string vPageSize,string vSCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                if (vSCode == "32828")
                {
                    dbCmd = new SqlCommand("EBook.dbo.usp_getProfitShare32828", dbConn);
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                    dbCmd.Parameters.Add("@vPageNo", SqlDbType.VarChar).Value = vPageNo;
                    dbCmd.Parameters.Add("vPageSize", SqlDbType.VarChar).Value = vPageSize;
                }
                else
                {
                    dbCmd = new SqlCommand("EBook.dbo.usp_getProfitShareFull_EBook", dbConn);
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                    dbCmd.Parameters.Add("@vPageNo", SqlDbType.VarChar).Value = vPageNo;
                    dbCmd.Parameters.Add("vPageSize", SqlDbType.VarChar).Value = vPageSize;
                    dbCmd.Parameters.Add("@vSCode", SqlDbType.BigInt).Value = vSCode;
                }
                

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet ebook_getProfitShare_Fortumo(string vMID, string vSCode, string vMonth, string vYear)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_getProfitShareFull_Fortumo", dbConn);
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                    dbCmd.Parameters.Add("@vSCode", SqlDbType.BigInt).Value = vSCode;
                    dbCmd.Parameters.Add("vMonth", SqlDbType.TinyInt).Value = vMonth;
                    dbCmd.Parameters.Add("@vYear", SqlDbType.Int).Value = vYear;


                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet ebook_getProfitShareShortCode(string vMID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_getProfitSharing_ShortCodes", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet ebook_getLoginValidateDetails(string mUserName, string mPassword, string mUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_User_getLoginValidateDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = mUserName;
                dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = mPassword;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = mUserID.ToString();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet ebook_getKeywordDetails_CountryWise(string vCtryCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBOOK_GetKeywodDetails_CountryBase", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@ctryCode", SqlDbType.VarChar).Value = vCtryCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_KeywordDetails_ByUserIDNew(int vUserID, string ctry)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USP_EBOOK_GetKeywodDetailsNew", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@ctry", SqlDbType.VarChar).Value = ctry;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_getKeywordDetails_AllCountries(string vUserid, string vBookID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBOOK_GetKeywodDetails_AllCountries", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserid;
                dbCmd.Parameters.Add("@bookCode", SqlDbType.VarChar).Value = vBookID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int ebook_Bank_Client_StoreBuyer(String vbFullName, String vbMobile, String vbEmail, int vUserID, string vTranID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_BankIn_ClientBuyer", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@byFullName", SqlDbType.NVarChar).Value = vbFullName;
                dbCmd.Parameters.Add("@byMobile", SqlDbType.VarChar).Value = vbMobile;
                dbCmd.Parameters.Add("@byEmail", SqlDbType.VarChar).Value = vbEmail;
                dbCmd.Parameters.Add("@byPassword", SqlDbType.VarChar).Value = "";
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

        public DataSet user_getCreditInfo(String vMobileNo)
        {
            try
            {

                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_User_CreditInfo_Web", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobileNo;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_getCurrencyTable(String vMobileNo)
        {
            try
            {

                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USP_CurrencyTable", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobileNo;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet profitShare_OverAllSummary(string vMobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_ProfitShare_OverAll", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet profitShare_OverAllSummaryCountry(string vMobile, string vCountryCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_ProfitShare_OverAllCountry", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.Parameters.Add("@countryCode", SqlDbType.VarChar).Value = vCountryCode;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet profitShare_ShortCodeWise(string vMobile, string vshortcode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_ProfitShare_ShortCodeWise", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.Parameters.Add("@shortCode", SqlDbType.VarChar).Value = vshortcode;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet profitShare_TelcoWise(string vUID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_ProfitShare_TelcoWise", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.Parameters.Add("@UID", SqlDbType.VarChar).Value = vUID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet RequestPayment_Display(string vMobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_RequestPayment_Display", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet RequestPayment_Show(string vMobile, string cCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_RequestPayment_Show", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.Parameters.Add("@countryCode", SqlDbType.VarChar).Value = cCode;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet RequestPayment_Confirm(string vMobile, string cCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_RequestPayment_Confirm", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.Parameters.Add("@countryCode", SqlDbType.VarChar).Value = cCode;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet RequestPayment_History(string vMobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_RequestPaymentHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet profitShare_monthWise(string vMobile, string vCountryCode, string vYear, string vMonth)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalApi.dbo.USPT_ProfitShare_MonthWise", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@projectID", SqlDbType.VarChar).Value = "1002";
                dbCmd.Parameters.Add("@countryCode", SqlDbType.VarChar).Value = vCountryCode;
                dbCmd.Parameters.Add("@rptyear", SqlDbType.VarChar).Value = vYear;
                dbCmd.Parameters.Add("@rptMonth", SqlDbType.VarChar).Value = vMonth;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int Ebook_eStore_SaveSettings(int vUserID, int vShowUserCat, int vShowAdminCat, int vAllowSMSBuy, int vAllowPayPalBuy, int vAllowDirectBankIn, string vSelectedCurrency, int vAllowPrepaid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_EB_WP_eStore_SaveSettings", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vShowUserCat", SqlDbType.Int).Value = vShowUserCat;
                dbCmd.Parameters.Add("@vShowAdminCat", SqlDbType.Int).Value = vShowAdminCat;
                dbCmd.Parameters.Add("@vAllowSMSBuy", SqlDbType.Int).Value = vAllowSMSBuy;
                dbCmd.Parameters.Add("@vAllowPayPalBuy", SqlDbType.Int).Value = vAllowPayPalBuy;
                dbCmd.Parameters.Add("@vAllowDirectBankIn", SqlDbType.Int).Value = vAllowDirectBankIn;
                dbCmd.Parameters.Add("@vSelectedCurrency", SqlDbType.VarChar).Value = vSelectedCurrency;
                dbCmd.Parameters.Add("@vAllowPrepaid", SqlDbType.Int).Value = vAllowPrepaid;

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

        public int EBook_AddBook_ByUser(EbookEntities ebEntity)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_BookADD_Chn", dbConn);
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

        public int EBook_AddBook_ReqAdm(EbookEntities ebEntity, string oldCode, string RequestChanges)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_BookADD_ReqAdm", dbConn);
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

                dbCmd.Parameters.Add("@vPrepaid", SqlDbType.Bit).Value = ebEntity.isPrepaid;
                dbCmd.Parameters.Add("@vPrepaidPrice", SqlDbType.Money).Value = ebEntity.PrepaidPrice;

                dbCmd.Parameters.Add("@vOldCode", SqlDbType.VarChar).Value = oldCode;
                dbCmd.Parameters.Add("@vRequestChanges", SqlDbType.VarChar).Value = RequestChanges;

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

        public int EBook_UpdateBook_ByUser(EbookEntities ebEntity)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_EB_BookUpdate_Chn", dbConn);
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

                dbCmd.Parameters.Add("@vPrepaid", SqlDbType.Bit).Value = ebEntity.isPrepaid;
                dbCmd.Parameters.Add("@vPrepaidPrice", SqlDbType.Money).Value = ebEntity.PrepaidPrice;
                dbCmd.Parameters.Add("@vPosition", SqlDbType.SmallInt).Value = ebEntity.position;

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

        public String ip_getCountryCode(string fromIP)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_getCountryCodeIPRamge", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@fromIP", SqlDbType.VarChar).Value = fromIP;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                
                DataRow krow = dsShortCode.Tables[0].Rows[0];
                return krow["returnMessage"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet getPrepaidPrice(string vEBookID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getPrepaidPrice", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vEBookID", SqlDbType.VarChar).Value = vEBookID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getUserCurrency(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getUserCurrency", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_PrepaidTransaction(string vEUserID, string pLogin, string pPassword, string pCredits, string vEBooks, string vEmail)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_Prepaid_validateLogin", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vEUserID;
                dbCmd.Parameters.Add("@pLoginID", SqlDbType.VarChar).Value = pLogin;
                dbCmd.Parameters.Add("@pPassword", SqlDbType.VarChar).Value = pPassword;
                dbCmd.Parameters.Add("@pCredits", SqlDbType.Int).Value = pCredits;
                dbCmd.Parameters.Add("@eBooks", SqlDbType.VarChar).Value = vEBooks;
                dbCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = vEmail;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_sendEBook_PrepaidPurchase(string vBookID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.usp_EB_Book2Email_ByBookId_Multi", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = vBookID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getMTebookDownload(string vTranID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getMTebookDownload", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TranID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getMTebookDownload_BillPlz(string vTranID, string bookid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getMTebookDownload_BillPlz", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TranID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.Parameters.Add("@bookID", SqlDbType.VarChar).Value = bookid;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getMTebookDownload_Paypal(string vTranID, string bookid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getMTebookDownload_Paypal", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TranID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.Parameters.Add("@bookID", SqlDbType.VarChar).Value = bookid;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getMTebookDownload_Free(string vTranID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getMTebookDownload_Free", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TranID", SqlDbType.VarChar).Value = vTranID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EbAd_SmsCreditBalance_Deduct_Web(int vMID, decimal vCredits, string ebookCode, string vUserId, string dPassword)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand("EBook.dbo.USPT_EB_DeductSMSCredits_Web", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vCredits", SqlDbType.VarChar).Value = vCredits;
                dbCmd.Parameters.Add("@eBookCode", SqlDbType.VarChar).Value = ebookCode;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.Parameters.Add("@dPassword", SqlDbType.VarChar).Value = dPassword;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_ListingDownloaded(int vUserId, int vUserType, int vPageNo, string vSearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                // dbCmd = new SqlCommand("[usp_EB_WP_eBooksListing]", dbConn);
                dbCmd = new SqlCommand("ebook.dbo.usp_EB_WP_eBooksListing_downloaded", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = vUserType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList(string Merid, string ECode, string ListName, string fromDate, string toDate)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                // dbCmd = new SqlCommand("[usp_EB_WP_eBooksListing]", dbConn);
                dbCmd = new SqlCommand("Business.dbo.USPT_EBook_CreateList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMerId", SqlDbType.VarChar).Value = Merid;
                dbCmd.Parameters.Add("@vECode", SqlDbType.VarChar).Value = ECode;
                dbCmd.Parameters.Add("@vListName", SqlDbType.VarChar).Value = ListName;
                dbCmd.Parameters.Add("@vFromDate", SqlDbType.VarChar).Value = fromDate;
                dbCmd.Parameters.Add("@vToDate", SqlDbType.VarChar).Value = toDate;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_download(string Merid, string ECode, string fromDate, string toDate)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                // dbCmd = new SqlCommand("[usp_EB_WP_eBooksListing]", dbConn);
                dbCmd = new SqlCommand("Business.dbo.USPT_EBook_CreateList_download", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMerId", SqlDbType.VarChar).Value = Merid;
                dbCmd.Parameters.Add("@vECode", SqlDbType.VarChar).Value = ECode;
                dbCmd.Parameters.Add("@vFromDate", SqlDbType.VarChar).Value = fromDate;
                dbCmd.Parameters.Add("@vToDate", SqlDbType.VarChar).Value = toDate;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_getCount(string Merid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
               
                dbCmd = new SqlCommand("Business.dbo.USPT_EBook_CreateList_getCount", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMerId", SqlDbType.VarChar).Value = Merid;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_getList(string Merid, string ListID, String vPageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USPT_EBook_CreateList_getList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMerId", SqlDbType.VarChar).Value = Merid;
                dbCmd.Parameters.Add("@ListID", SqlDbType.VarChar).Value = ListID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_deleteList(string ListSNO)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USPT_EBook_CreateList_deleteList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@ListSNO", SqlDbType.VarChar).Value = ListSNO;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_deleteListComplete(string ListID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USPT_EBook_CreateList_deleteListComplete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@ListID", SqlDbType.VarChar).Value = ListID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_sendSMS_getList(string MerId, string ListID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USPT_CreateList_SMS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMerId", SqlDbType.VarChar).Value = MerId;
                dbCmd.Parameters.Add("@ListID", SqlDbType.VarChar).Value = ListID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_sendEmail_getList(string MerId, string ListID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USPT_CreateList_email", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMerId", SqlDbType.VarChar).Value = MerId;
                dbCmd.Parameters.Add("@ListID", SqlDbType.VarChar).Value = ListID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Insert_SEKEmailInfo(String vMID, String vParam, String vMailType, String vCatID, String iSuccess, String iFailure, String vMessage, String vSubject, String vBodyHTML, String vAttachment, String vEmailAddressList)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                //vMailType=0 means by SEK CODE,vMailType=1 means by ADCHOC,vMailType=2 means by CATEGORY
                dbCmd = new SqlCommand("Business.dbo.USP_Insert_SEKEmailInfo_EBook", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMID;
                dbCmd.Parameters.Add("@vParam", SqlDbType.VarChar).Value = vParam;
                dbCmd.Parameters.Add("@vMailType", SqlDbType.Int).Value = vMailType;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.BigInt).Value = vCatID;
                dbCmd.Parameters.Add("@vSuccessEntries", SqlDbType.Money).Value = iSuccess;
                dbCmd.Parameters.Add("@vFailureEntries", SqlDbType.BigInt).Value = iFailure;
                dbCmd.Parameters.Add("@vMessage", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@vSubject", SqlDbType.VarChar).Value = vSubject;
                dbCmd.Parameters.Add("@vBodyHTML", SqlDbType.NVarChar).Value = vBodyHTML;
                dbCmd.Parameters.Add("@vAttachment", SqlDbType.NVarChar).Value = vAttachment;
                dbCmd.Parameters.Add("@vEmailAddressList", SqlDbType.VarChar).Value = vEmailAddressList;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
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

                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_BankIn_TransUpdate_success", dbConn);
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

        public DataSet Ebook_getUserEmailID(string vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_getUserEmailID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_getBankersEmailID(string vTranID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_getBankersEmailID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.VarChar).Value = vTranID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_BankIn_ByClientList_NonPaid(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_BankIn_ByClientList_NonPaid", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Prepaid_RegValidatePin(string vUserID, string PIN)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_Prepaid_Reg_ValidatePIN", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@PIN", SqlDbType.VarChar).Value = PIN;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Prepaid_RegValidateLogin(string Login, string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_Prepaid_Reg_ValidateLogin", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Login", SqlDbType.VarChar).Value = Login;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Prepaid_RegisterUser(string Login, string Mobile, string PIN, string Email, string Password, string fullname)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_User_Registration_Web_Prepaid", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserId", SqlDbType.VarChar).Value = Login;
                dbCmd.Parameters.Add("@tMobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.Parameters.Add("@PIN", SqlDbType.VarChar).Value = PIN;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                dbCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Password;
                dbCmd.Parameters.Add("@fullName", SqlDbType.VarChar).Value = fullname;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Prepaid_RegisterWeb_User(string Login, string Mobile, string PIN, string Email, string Password, string fullname,string vClientID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_User_Registration_Web_User", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserId", SqlDbType.VarChar).Value = Login;
                dbCmd.Parameters.Add("@tMobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.Parameters.Add("@PIN", SqlDbType.VarChar).Value = PIN;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                dbCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Password;
                dbCmd.Parameters.Add("@fullName", SqlDbType.VarChar).Value = fullname;
                dbCmd.Parameters.Add("@bpID", SqlDbType.BigInt).Value = vClientID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WebDesign11_GetSettings(int vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.usp_EB_Design11_GetSettings", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int WebDesign11_UpdateSettings(String vMasterPageCSS, int vUserID, string vPicture1, string vPicture2,string vPicture3,string vPicture4,string vPicture5, string vECode1, string vECode2, string vECode3, string vECode4, string vECode5)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.usp_EB_Design11_UpdateSettings", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMasterPageCSS", SqlDbType.VarChar).Value = vMasterPageCSS;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vPicture1", SqlDbType.VarChar).Value = vPicture1;
                dbCmd.Parameters.Add("@vPicture2", SqlDbType.VarChar).Value = vPicture2;
                dbCmd.Parameters.Add("@vPicture3", SqlDbType.VarChar).Value = vPicture3;
                dbCmd.Parameters.Add("@vPicture4", SqlDbType.VarChar).Value = vPicture4;
                dbCmd.Parameters.Add("@vPicture5", SqlDbType.VarChar).Value = vPicture5;
                dbCmd.Parameters.Add("@vEcode1", SqlDbType.VarChar).Value = vECode1;
                dbCmd.Parameters.Add("@vEcode2", SqlDbType.VarChar).Value = vECode2;
                dbCmd.Parameters.Add("@vEcode3", SqlDbType.VarChar).Value = vECode3;
                dbCmd.Parameters.Add("@vEcode4", SqlDbType.VarChar).Value = vECode4;
                dbCmd.Parameters.Add("@vEcode5", SqlDbType.VarChar).Value = vECode5;

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

        public DataSet WebDesign15_GetSettings(int vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.usp_EB_Design15_GetSettings", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int WebDesign15_UpdateSettings(String vMasterPageCSS, int vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.usp_EB_Design15_UpdateSettings", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
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

        public String WebDesign_getCSSnew(int vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.USPT_WebDesign_getCSSnew", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                DataRow krow = dsShortCode.Tables[0].Rows[0];
                return krow["returnMessage"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public String WebDesign_getMasterPagenew(int vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.USPT_WebDesign_getMasterPagenew", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                DataRow krow = dsShortCode.Tables[0].Rows[0];
                return krow["returnMessage"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public String user_getStoreID(int vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.USPT_getStoreID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                DataRow krow = dsShortCode.Tables[0].Rows[0];
                return krow["storeid"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_forgotPasswordSendSMS(String vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_User_ForgotPassword_sendSMS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public String getFaceBookID(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.USPT_getFaceBookID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                DataRow krow = dsShortCode.Tables[0].Rows[0];
                return krow["FaceBookGroupLink"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet design_homePageProducts(int vUserID, int design)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.USPT_Design_HomePageProducts", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vuserid", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@design", SqlDbType.TinyInt).Value = design;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public String design_homePageProducts_update(int vUserID, int design, string FB, string BS, string NR, string VBy, string FREE)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.USPT_Design_HomePageProducts_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@design", SqlDbType.TinyInt).Value = design;
                dbCmd.Parameters.Add("@vfeaturebuy", SqlDbType.TinyInt).Value = FB;
                dbCmd.Parameters.Add("@vBestSeller", SqlDbType.TinyInt).Value = BS;
                dbCmd.Parameters.Add("@vNewReleases", SqlDbType.TinyInt).Value = NR;
                dbCmd.Parameters.Add("@vValueBuy", SqlDbType.TinyInt).Value = VBy;
                dbCmd.Parameters.Add("@vFree", SqlDbType.TinyInt).Value = FREE;
                dbCmd.ExecuteNonQuery();

                return "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int user_changePassword(String vUserID, string oldPassword, string newPassword)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_user_PasswordChange", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserId", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@oldPassword", SqlDbType.VarChar).Value = oldPassword;
                dbCmd.Parameters.Add("@newPassword", SqlDbType.VarChar).Value = newPassword;
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

        public DataSet user_getProfile(String vMobileNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_User_getProile", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vMobileNo;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet User_VeryEmail_Update(String buyerid, string k )
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_User_VeryEmail_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = buyerid;
                dbCmd.Parameters.Add("@k", SqlDbType.VarChar).Value = k;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int user_updateProfile(String vMobile, string Fullname, string Address, string Country, string State, string City, string Zip, string Telephone, string Fax)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_User_updateProfile", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserId", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@fullname", SqlDbType.VarChar).Value = Fullname;
                dbCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
                dbCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;
                dbCmd.Parameters.Add("@State", SqlDbType.VarChar).Value = State;
                dbCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = City;
                dbCmd.Parameters.Add("@Zip", SqlDbType.VarChar).Value = Zip;
                dbCmd.Parameters.Add("@Telephone", SqlDbType.VarChar).Value = Telephone;
                dbCmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = Fax;
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

        public DataSet user_getTopupLastDate(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_User_getTopupLastDate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_Topup(String vUserId, string PIN)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_User_TopupMain", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.Parameters.Add("@PIN", SqlDbType.VarChar).Value = PIN;
                dbCmd.Parameters.Add("@topupUserID", SqlDbType.VarChar).Value = "";

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_getTopupHistory(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_User_TopupHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_getDirectBankinHistory(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_user_DirectBankInHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_getPrepaidPurchaseHistory(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_getPrepaidTransactions", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_getPaypalPurchaseHistory(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_user_paypalHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_getBillPlzPurchaseHistory(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_user_bankingHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_getBookListPurchased(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_user_BooksListPurchased", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_TransctionHistory(String vUserId,string vTranid, string vTranType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_user_TransactionHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.VarChar).Value = vTranid;
                dbCmd.Parameters.Add("@vTranType", SqlDbType.TinyInt).Value = vTranType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_getSendEmailRegInfo(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_user_getSendEmailRegInfo", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet CurrencyConvert_List(string vUserID, string vSearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_EB_ADM_CurrencyConvert_List", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int CurrencyConvert_Update(string vUserID, string vCurrency, double vPoints)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_EB_ADM_CurrencyConvert_Update", dbConn);
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

        public DataSet get_prepaidUserList(string vUserID, string vSearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.uspT_Retrieve_CardRegisterdUsers", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@vStatus", SqlDbType.TinyInt).Value = 1;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet user_BuyerAccount_Zoom(string vID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.USPT_user_BuyerAccount_Zoom", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vId", SqlDbType.VarChar).Value = vID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet get_DomainDetails(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("cmsdb.dbo.usp_Get_DOmainDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = "";

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet resendSMS_EBook(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.uspT_ReSendSMS_EBook", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vTID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);
                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_Report(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PremiumSMS_Report", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.Parameters.Add("@rType", SqlDbType.TinyInt).Value = rType;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_ReportFree(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PremiumSMS_ReportFree", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_ReportFreeSYS(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PremiumSMS_ReportFreeSYS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_ReportOA(string Mobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PremiumSMS_ReportOA", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBookSalesDashboard(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_EBookSales_Dashboard", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBookAccountSummary(string vMobileNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USP_Retrieve_MobileUserAccountSum", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobileNo;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_Summary(string Mobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PremiumSMS_Summary", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getSMSBalance_download(string MerID,string BookID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_GetSMSCreditsBalance", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.VarChar).Value = MerID;
                dbCmd.Parameters.Add("@bookID", SqlDbType.VarChar).Value = BookID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet retrieve_MainPageSettings(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("cmsdb.dbo.USPT_retrieve_MainPageSettings", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet update_MainPageSettings(string vUserID, string domainTitle, string domainDescription, string domainKeywords, string facebookPixel)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("cmsdb.dbo.USPT_update_MainPageSettings", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@title", SqlDbType.VarChar).Value = domainTitle;
                dbCmd.Parameters.Add("@description", SqlDbType.VarChar).Value = domainDescription;
                dbCmd.Parameters.Add("@keywords", SqlDbType.VarChar).Value = domainKeywords;
                dbCmd.Parameters.Add("@facebookPixel", SqlDbType.VarChar).Value = facebookPixel;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getEBookFileName(string BookID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getBookFileName", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = BookID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getAdminEBookFileName(string BookID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getAdminBookFileName", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = BookID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getAdminEBookFileName(string BookID, string aMobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getAdminBookFileNameAuthor", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vBookID", SqlDbType.VarChar).Value = BookID;
                dbCmd.Parameters.Add("@aMobile", SqlDbType.VarChar).Value = aMobile;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet insert_AssignAdminBooks(int vUserID, int subCatID, string bookid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_AssignAdminBooks", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@subCatID", SqlDbType.Int).Value = subCatID;
                dbCmd.Parameters.Add("@bookid", SqlDbType.VarChar).Value = bookid;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet get_AssignAdminBooks(int vUserID, string vSearch)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.usp_EB_ADM_AssignAdminBookList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearch;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet delete_AssignAdminBooks(int vUserID, int vID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_delete_AssignAdminBooks", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vID", SqlDbType.Int).Value = vID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet get_LifeReportLogsPaypal(string vTranid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_getLifeReportLogsPaypal", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.Int).Value = vTranid; 

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet buy_AdminBook(string vUserId, string BookID, string Mobile, string Email, string FullName, string bType, string bMessage)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_EB_BuyAdminBook_Web", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@EBookCode", SqlDbType.VarChar).Value = BookID;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                dbCmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = FullName;
                dbCmd.Parameters.Add("@bType", SqlDbType.TinyInt).Value = bType;
                dbCmd.Parameters.Add("@bMessage", SqlDbType.VarChar).Value = bMessage;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet buy_AdminBook_samValidate(string BookID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_EB_BuyAdminBook_sam_valdate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@bookid", SqlDbType.VarChar).Value = BookID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCodeFree(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCodeFree", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCodeFree_FreeSYS(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_FreeSYS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_BookCodeFree_FreeSYSTelegramMessage(string vMerID, string vMessage, string vMobile, string vCharges,string vReportName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_BulkMain_sendTelegram_Msg", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@MerID", SqlDbType.BigInt).Value = vMerID;
                dbCmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@charges", SqlDbType.Money).Value = vCharges;
                dbCmd.Parameters.Add("@reportName", SqlDbType.VarChar).Value = vReportName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_Specific(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_SpecificFree(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_SpecificFree", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_Specific_FreeSYS(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_Specific_FreeSYS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_Download(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_download", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_delete(string vUserID, string pEmail)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@pEmail", SqlDbType.VarChar).Value = pEmail;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_delete_FreeSYS(string vUserID, string pEmail)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_Delete_FreeSYS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@pEmail", SqlDbType.VarChar).Value = pEmail;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_sendSMS_getList(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_getSMSList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_sendSMS_getListFRee(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_getSMSListFree", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_sendSMS_getList_FreeSYS(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_getSMSList_FreeSYS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_CreateList_BookCode_sendEMAIL_getList(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.USPT_EBook_CreateList_BookCode_getEMAILList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_UploadVoucher(string vUserID, string vName, string vDesc, string vImage, string vInfo, string vQuantity, string fDate, string tDate, string mobile1, string mobile2, string mobile3, string replySMS, string replyType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherCode_Insert", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@vDescription", SqlDbType.VarChar).Value = vDesc;
                dbCmd.Parameters.Add("@vImage", SqlDbType.VarChar).Value = vImage;
                dbCmd.Parameters.Add("@vEmailAddedInfo", SqlDbType.VarChar).Value = vInfo;
                dbCmd.Parameters.Add("@vQuantity", SqlDbType.SmallInt).Value = vQuantity;
                dbCmd.Parameters.Add("@fDate", SqlDbType.VarChar).Value = fDate;
                dbCmd.Parameters.Add("@tDate", SqlDbType.VarChar).Value = tDate;
                dbCmd.Parameters.Add("@mobile1", SqlDbType.VarChar).Value = mobile1;
                dbCmd.Parameters.Add("@mobile2", SqlDbType.VarChar).Value = mobile2;
                dbCmd.Parameters.Add("@mobile3", SqlDbType.VarChar).Value = mobile3;
                dbCmd.Parameters.Add("@replyMessage", SqlDbType.NVarChar).Value = replySMS;
                dbCmd.Parameters.Add("@replyType", SqlDbType.VarChar).Value = replyType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_UpdateVoucher(string vUserID, string vName, string vDesc, string vImage, string vInfo, string vQuantity, string vCode, string fDate, string tDate, string LStatus, string mobile1, string mobile2, string mobile3, string replySMS, string replyType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherCode_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@vDescription", SqlDbType.VarChar).Value = vDesc;
                dbCmd.Parameters.Add("@vImage", SqlDbType.VarChar).Value = vImage;
                dbCmd.Parameters.Add("@vEmailAddedInfo", SqlDbType.VarChar).Value = vInfo;
                dbCmd.Parameters.Add("@vQuantity", SqlDbType.SmallInt).Value = vQuantity;
                dbCmd.Parameters.Add("@vCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@fDate", SqlDbType.VarChar).Value = fDate;
                dbCmd.Parameters.Add("@tDate", SqlDbType.VarChar).Value = tDate;
                dbCmd.Parameters.Add("@LStatus", SqlDbType.TinyInt).Value = LStatus;
                dbCmd.Parameters.Add("@mobile1", SqlDbType.VarChar).Value = mobile1;
                dbCmd.Parameters.Add("@mobile2", SqlDbType.VarChar).Value = mobile2;
                dbCmd.Parameters.Add("@mobile3", SqlDbType.VarChar).Value = mobile3;
                dbCmd.Parameters.Add("@replyMessage", SqlDbType.NVarChar).Value = replySMS;
                dbCmd.Parameters.Add("@replyType", SqlDbType.VarChar).Value = replyType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_VoucherList(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet voucher_getEmailDetails(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_getEmailDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_VoucherSalesList(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_SalesList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet voucher_resendSMS(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_resendSMS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_CreateList_BookCode(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_DataBaseList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_CreateList_BookCode_Specific(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("eSMS.dbo.USPT_Voucher_CreateList_BookCode_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_DeletedList_BookCode_Specific(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("eSMS.dbo.USPT_Voucher_DeletedList_BookCode_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_CreateList_BookCode_delete(string vUserID, string pEmail)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_CreateList_BookCode_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@pEmail", SqlDbType.VarChar).Value = pEmail;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet VoucherTicketEBK_CreateList_BookCode_Restore(string vType, string vUID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_CreateList_BookCode_Restore", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vType", SqlDbType.TinyInt).Value = vType;
                dbCmd.Parameters.Add("@vUID", SqlDbType.VarChar).Value = vUID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_CreateList_BookCode_Download(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_CreateList_BookCode_download", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_CreateList_BookCode_sendEMAIL_getList(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_CreateList_BookCode_getEMAILList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_CreateList_BookCode_sendSMS_getList(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_CreateList_BookCode_getSMSList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet AddressBook_sendEMAIL_getList(string vLoginID, string vCatID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_AddressBook_getEmailList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@catID", SqlDbType.VarChar).Value = vCatID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_getEmailDetails(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_getEmailDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_Upload(string vUserID, string vName, string vDesc, string vImage, string vInfo, string vQuantity, string fDate, string tDate, string mobile1, string mobile2, string mobile3, string replySMS, string replyType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_Insert", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@tName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@tDescription", SqlDbType.VarChar).Value = vDesc;
                dbCmd.Parameters.Add("@tImage", SqlDbType.VarChar).Value = vImage;
                dbCmd.Parameters.Add("@tEmailAddedInfo", SqlDbType.VarChar).Value = vInfo;
                dbCmd.Parameters.Add("@tQuantity", SqlDbType.SmallInt).Value = vQuantity;
                dbCmd.Parameters.Add("@fDate", SqlDbType.VarChar).Value = fDate;
                dbCmd.Parameters.Add("@tDate", SqlDbType.VarChar).Value = tDate;
                dbCmd.Parameters.Add("@mobile1", SqlDbType.VarChar).Value = mobile1;
                dbCmd.Parameters.Add("@mobile2", SqlDbType.VarChar).Value = mobile2;
                dbCmd.Parameters.Add("@mobile3", SqlDbType.VarChar).Value = mobile3;
                dbCmd.Parameters.Add("@replyMessage", SqlDbType.NVarChar).Value = replySMS;
                dbCmd.Parameters.Add("@replyType", SqlDbType.VarChar).Value = replyType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_Update(string vUserID, string vName, string vDesc, string vImage, string vInfo, string vQuantity, string vCode, string fDate, string tDate, string LStatus, string mobile1, string mobile2, string mobile3, string replySMS, string replyType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@tName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@tDescription", SqlDbType.VarChar).Value = vDesc;
                dbCmd.Parameters.Add("@tImage", SqlDbType.VarChar).Value = vImage;
                dbCmd.Parameters.Add("@tEmailAddedInfo", SqlDbType.VarChar).Value = vInfo;
                dbCmd.Parameters.Add("@tQuantity", SqlDbType.SmallInt).Value = vQuantity;
                dbCmd.Parameters.Add("@tCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@fDate", SqlDbType.VarChar).Value = fDate;
                dbCmd.Parameters.Add("@tDate", SqlDbType.VarChar).Value = tDate;
                dbCmd.Parameters.Add("@LStatus", SqlDbType.TinyInt).Value = LStatus;
                dbCmd.Parameters.Add("@mobile1", SqlDbType.VarChar).Value = mobile1;
                dbCmd.Parameters.Add("@mobile2", SqlDbType.VarChar).Value = mobile2;
                dbCmd.Parameters.Add("@mobile3", SqlDbType.VarChar).Value = mobile3;
                dbCmd.Parameters.Add("@replyMessage", SqlDbType.NVarChar).Value = replySMS;
                dbCmd.Parameters.Add("@replyType", SqlDbType.VarChar).Value = replyType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_List(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_TicketList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@tPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@tSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_SalesList(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_SalesList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@tPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@tSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_resendSMS(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_resendSMS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_CreateList_BookCode(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_DataBaseList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_CreateList_BookCode_Specific(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("eSMS.dbo.USPT_Ticket_CreateList_BookCode_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@tPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_DeletedList_BookCode_Specific(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("eSMS.dbo.USPT_Ticket_DeletedList_BookCode_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@tPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_CreateList_BookCode_delete(string vUserID, string pEmail)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_CreateList_BookCode_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@pEmail", SqlDbType.VarChar).Value = pEmail;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_CreateList_BookCode_Download(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_CreateList_BookCode_download", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_CreateList_BookCode_sendEMAIL_getList(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_CreateList_BookCode_getEMAILList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_CreateList_BookCode_sendSMS_getList(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_CreateList_BookCode_getSMSList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_EBK(string vUserID, string vName, string vDesc, string vImage, string vInfo, string eBook, string fDate, string tDate, string mobile1, string mobile2,string mobile3, string replySMS, string replyType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_Insert", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@eName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@eDescription", SqlDbType.VarChar).Value = vDesc;
                dbCmd.Parameters.Add("@eImage", SqlDbType.VarChar).Value = vImage;
                dbCmd.Parameters.Add("@eEmailAddedInfo", SqlDbType.VarChar).Value = vInfo;
                dbCmd.Parameters.Add("@eBook", SqlDbType.VarChar).Value = eBook;
                dbCmd.Parameters.Add("@fDate", SqlDbType.VarChar).Value = fDate;
                dbCmd.Parameters.Add("@tDate", SqlDbType.VarChar).Value = tDate;
                dbCmd.Parameters.Add("@mobile1", SqlDbType.VarChar).Value = mobile1;
                dbCmd.Parameters.Add("@mobile2", SqlDbType.VarChar).Value = mobile2;
                dbCmd.Parameters.Add("@mobile3", SqlDbType.VarChar).Value = mobile3;
                dbCmd.Parameters.Add("@replyMessage", SqlDbType.NVarChar).Value = replySMS;
                dbCmd.Parameters.Add("@replyType", SqlDbType.VarChar).Value = replyType;


                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_EBKInsert(string vUserID, string vName, string vDesc, string vImage, string vInfo, string eBook, string fDate, string tDate, string mobile1, string mobile2, string mobile3, string replySMS, string replyType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_Insert", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@eName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@eDescription", SqlDbType.VarChar).Value = vDesc;
                dbCmd.Parameters.Add("@eImage", SqlDbType.VarChar).Value = vImage;
                dbCmd.Parameters.Add("@eEmailAddedInfo", SqlDbType.VarChar).Value = vInfo;
                dbCmd.Parameters.Add("@eBook", SqlDbType.VarChar).Value = eBook;
                dbCmd.Parameters.Add("@fDate", SqlDbType.VarChar).Value = fDate;
                dbCmd.Parameters.Add("@tDate", SqlDbType.VarChar).Value = tDate;
                dbCmd.Parameters.Add("@mobile1", SqlDbType.VarChar).Value = mobile1;
                dbCmd.Parameters.Add("@mobile2", SqlDbType.VarChar).Value = mobile2;
                dbCmd.Parameters.Add("@mobile3", SqlDbType.VarChar).Value = mobile3;
                dbCmd.Parameters.Add("@replyMessage", SqlDbType.NVarChar).Value = replySMS;
                dbCmd.Parameters.Add("@replyType", SqlDbType.VarChar).Value = replyType;


                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_EBKList(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBKList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@ePageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@eSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Update_EBK(string vUserID, string vName, string vDesc, string vImage, string vInfo, string eBook, string eCode, string fDate, string tDate, string LStatus, string mobile1, string mobile2, string mobile3, string replySMS, string replyType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@eName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@eDescription", SqlDbType.VarChar).Value = vDesc;
                dbCmd.Parameters.Add("@eImage", SqlDbType.VarChar).Value = vImage;
                dbCmd.Parameters.Add("@eEmailAddedInfo", SqlDbType.VarChar).Value = vInfo;
                dbCmd.Parameters.Add("@eBook", SqlDbType.VarChar).Value = eBook;
                dbCmd.Parameters.Add("@eCode", SqlDbType.VarChar).Value = eCode;
                dbCmd.Parameters.Add("@fDate", SqlDbType.VarChar).Value = fDate;
                dbCmd.Parameters.Add("@tDate", SqlDbType.VarChar).Value = tDate;
                dbCmd.Parameters.Add("@LStatus", SqlDbType.TinyInt).Value = LStatus;
                dbCmd.Parameters.Add("@mobile1", SqlDbType.VarChar).Value = mobile1;
                dbCmd.Parameters.Add("@mobile2", SqlDbType.VarChar).Value = mobile2;
                dbCmd.Parameters.Add("@mobile3", SqlDbType.VarChar).Value = mobile3;
                dbCmd.Parameters.Add("@replyMessage", SqlDbType.NVarChar).Value = replySMS;
                dbCmd.Parameters.Add("@replyType", SqlDbType.VarChar).Value = replyType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_getEmailDetails(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_getEmailDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_SalesList(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_SalesList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@ePageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@eSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_resendSMS(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_resendSMS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_CreateList_BookCode(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_DataBaseList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_CreateList_BookCode_Download(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_CreateList_BookCode_download", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_CreateList_BookCode_delete(string vUserID, string pEmail)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_CreateList_BookCode_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@pEmail", SqlDbType.VarChar).Value = pEmail;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_CreateList_BookCode_Specific(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("eSMS.dbo.USPT_EBK_CreateList_BookCode_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@ePageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_DeletedList_BookCode_Specific(string vUserID, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("eSMS.dbo.USPT_EBK_DeletedList_BookCode_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@ePageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_CreateList_BookCode_sendEMAIL_getList(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_CreateList_BookCode_getEMAILList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_CreateList_BookCode_sendSMS_getList(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_CreateList_BookCode_getSMSList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WassapTemplates_getList(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_wassapTemplate_getDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WassapTemplates_Update(string vUserID, string Template1,string Template2,string Template3,string Template4,string Template5,string Template6,string Template7,string Template8,string Template9,string Template10)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_wassapTemplate_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@template1", SqlDbType.NVarChar).Value = Template1;
                dbCmd.Parameters.Add("@template2", SqlDbType.NVarChar).Value = Template2;
                dbCmd.Parameters.Add("@template3", SqlDbType.NVarChar).Value = Template3;
                dbCmd.Parameters.Add("@template4", SqlDbType.NVarChar).Value = Template4;
                dbCmd.Parameters.Add("@template5", SqlDbType.NVarChar).Value = Template5;
                dbCmd.Parameters.Add("@template6", SqlDbType.NVarChar).Value = Template6;
                dbCmd.Parameters.Add("@template7", SqlDbType.NVarChar).Value = Template7;
                dbCmd.Parameters.Add("@template8", SqlDbType.NVarChar).Value = Template8;
                dbCmd.Parameters.Add("@template9", SqlDbType.NVarChar).Value = Template9;
                dbCmd.Parameters.Add("@template10", SqlDbType.NVarChar).Value = Template10;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WassapTemplates_DefaultUpdate(string vUserID, string template, int templateType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_wassapTemplate_DefaultUpdate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@template", SqlDbType.VarChar).Value = template;
                dbCmd.Parameters.Add("@templateType", SqlDbType.TinyInt).Value = templateType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WassapTemplates_unsubscribe(string Email)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_UnSubscribeEmail", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getVoucherTicketImage(string vTranID, string vType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("eSMS.dbo.USPT_getVoucherTicketImage", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tranid", SqlDbType.VarChar).Value = vTranID;
                dbCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = vType;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int Ebook_FeatureBuy_ADDNew(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp, int position)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_eb_ADD_FeatureBuyNew", dbConn);
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

        public int Ebook_BestSeller_ADDNew(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp, int position)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_eb_BestSeller_ADDNew", dbConn);
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

        public int Ebook_NewRelease_ADDNew(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp, int position)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_eb_NewRelease_ADDNew", dbConn);
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

        public int Ebook_FreeEbook_ADDNew(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp, int position)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_eb_ADM_FreeEbook_ADDNew", dbConn);
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

        public DataSet WMDP_mainPageData(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_WMDP_MainPageData", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet get_EBookPaypalReward_Details(string vItemNumber)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GSPaypal.dbo.USPT_getEBookReward_Details", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vItemNumber", SqlDbType.Int).Value = vItemNumber;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet get_EBookPaypalReward_DetailsTest(string vItemNumber)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GSPaypal.dbo.USPT_getEBookReward_DetailsTest", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vItemNumber", SqlDbType.Int).Value = vItemNumber;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBookPayment_Report(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_EBookPayment_Report", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.Parameters.Add("@rType", SqlDbType.TinyInt).Value = rType;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBookPayment_Summary(string Mobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_EBookPayment_Summary", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_Delete(string tCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tCode", SqlDbType.VarChar).Value = tCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_Delete(string vCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vCode", SqlDbType.VarChar).Value = vCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_Delete(string eCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eCode", SqlDbType.VarChar).Value = eCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_ReportFULL(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PaymentReport_Full", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_ReportFULL_Bookstore(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PaymentReport_Full_Bookstore", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_ReportFULL_Sponsor(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PaymentReport_Full_Sponsor", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_ReportFULL_Author(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PaymentReport_Full_Author", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet PremiumSMS_ReportFULL_Introducer(string Mobile, int rType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_PaymentReport_Full_Introducer", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet wassap_validateLogin(string vLogin, string vPassword)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USP_DEP_GetMobileNumberByLoginID_WMDP", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = vPassword;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Merchant_validateLogin(string vLogin, string vPassword)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USP_DEP_GetMobileNumberByLoginID_Merchant", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = vPassword;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet TicketList_Update(string tUID, string tEmail, string tName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_TicketList_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UID", SqlDbType.BigInt).Value = tUID;
                dbCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = tEmail;
                dbCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = tName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet VoucherList_Update(string tUID, string tEmail, string tName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherList_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UID", SqlDbType.BigInt).Value = tUID;
                dbCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = tEmail;
                dbCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = tName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBookList_Update(string tUID, string tEmail, string tName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_EBookList_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UID", SqlDbType.BigInt).Value = tUID;
                dbCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = tEmail;
                dbCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = tName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getNews(string vLogin, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_getNews", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@login", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getNews_Specific(string vSNO)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.getNews_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@sno", SqlDbType.Int).Value = vSNO;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet getAddressBook_Categories(string vLoginID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_AddressBook_getCategories", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@loginID", SqlDbType.VarChar).Value = vLoginID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }       

        public DataSet getAddressBook_Contacts(string vLoginID, string vPageNo,string vCatID, string searchfor)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_getAddressBook", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@loginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vCatID", SqlDbType.BigInt).Value = vCatID;
                dbCmd.Parameters.Add("@searchfor", SqlDbType.VarChar).Value = searchfor;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet AddressBook_createCategory(string vLoginID, string vCategory)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_AddressBook_AddCategory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@category", SqlDbType.VarChar).Value = vCategory;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public void Create_DataTableContacts(String vTableString, String vTableName, DataTable vDataTable)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand(vTableString, dbConn);
                dbCmd.CommandType = CommandType.Text;
                dbCmd.ExecuteNonQuery();

                SqlBulkCopy s = new SqlBulkCopy(dbConn);
                s.DestinationTableName = vTableName;
                s.WriteToServer(vDataTable);
                s.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ImportProcess_Final(string vLoginID, string vCatID, string vTableName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_ImportProcess_Final", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vSelCategoryID", SqlDbType.VarChar).Value = vCatID;
                dbCmd.Parameters.Add("@vTableName", SqlDbType.VarChar).Value = vTableName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ImportProcess_BDay(string vLoginID, string vTableName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_ImportProcess_BDay", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vTableName", SqlDbType.VarChar).Value = vTableName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet AddressBook_sendSMS_getList(string vLoginID, string catID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_AddressBook_getSMSList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@catID", SqlDbType.VarChar).Value = catID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet AddressBook_download(string vLoginID, string catID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_AddressBook_download", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@catID", SqlDbType.VarChar).Value = catID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet AddressBook_deleteListName(string vLoginID, string catID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_AddressBook_DeleteListName", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@catID", SqlDbType.VarChar).Value = catID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet AddressBook_delete(string vLoginID, string catID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_AddressBook_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vUID", SqlDbType.VarChar).Value = catID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet BirthDay_Incoming(string vMobile, string vUniqueID, string dDay, string dMonth, string dYear, string vName, string cName, string vEmail, string vMsg, string vMsgid, string vSCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthDay_Incoming", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@uniqueID", SqlDbType.VarChar).Value = vUniqueID;
                dbCmd.Parameters.Add("@dDay", SqlDbType.VarChar).Value = dDay;
                dbCmd.Parameters.Add("@dMonth", SqlDbType.VarChar).Value = dMonth;
                dbCmd.Parameters.Add("@dYear", SqlDbType.VarChar).Value = dYear;
                dbCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = vMsg;
                dbCmd.Parameters.Add("@msgid", SqlDbType.VarChar).Value = vMsgid;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = vSCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Merchant_Incoming(string vMobile, string vUniqueID, string dDay, string dMonth, string dYear, string vName, string cName, string vEmail, string vMsg, string vMsgid, string vSCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthDay_Merchant_Incoming", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@uniqueID", SqlDbType.VarChar).Value = vUniqueID;
                dbCmd.Parameters.Add("@dDay", SqlDbType.VarChar).Value = dDay;
                dbCmd.Parameters.Add("@dMonth", SqlDbType.VarChar).Value = dMonth;
                dbCmd.Parameters.Add("@dYear", SqlDbType.VarChar).Value = dYear;
                dbCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = vMsg;
                dbCmd.Parameters.Add("@msgid", SqlDbType.VarChar).Value = vMsgid;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = vSCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList(string vLogin)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BrithDayList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@login", SqlDbType.VarChar).Value = vLogin;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList_Specific(string vLogin, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("eSMS.dbo.USPT_BirthdayList_Specific", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vMonth", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList_Deleted(string vLogin, string BookCode, string PageNo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("eSMS.dbo.USPT_BirthdayList_Deleted", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vMonth", SqlDbType.VarChar).Value = BookCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = PageNo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList_Download(string vUserID, string BookCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPTBirthday_download", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vMonth", SqlDbType.VarChar).Value = BookCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList_delete(string vLogin, string pUID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthdayList_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vUID", SqlDbType.VarChar).Value = pUID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList_restore(string vLogin, string pUID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthdayList_Restore", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vUID", SqlDbType.VarChar).Value = pUID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList_Update(string tUID, string tEmail, string tName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_BirthdayList_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UID", SqlDbType.BigInt).Value = tUID;
                dbCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = tEmail;
                dbCmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = tName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList_sendSMS_getList(string vLogin, string vMonth)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthdayList_getSMSList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@cMonth", SqlDbType.VarChar).Value = vMonth;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayList_sendEmail_getList(string vLogin, string vMonth)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthdayList_getEMAILList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@cMonth", SqlDbType.VarChar).Value = vMonth;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_Birthday_Retrieve_2WayReport(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USP_Retrieve_2WayReportBD", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_Birthday_Retrieve_2WayReportMCH(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USP_Retrieve_2WayReportMCH", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_Birthday_AddContact(string vLogin, string vName, string cName, string vMobile, string vEmail, string vDOB)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthDay_ContactAdd", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@vDOB", SqlDbType.VarChar).Value = vDOB;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_EBookList_AddContact(string vLogin, string vName, string cName, string vMobile, string vEmail, string eCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBookList_ContactAdd", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@eCode", SqlDbType.VarChar).Value = eCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_TicketList_AddContact(string vLogin, string vName, string cName, string vMobile, string vEmail, string eCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_TicketList_ContactAdd", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@eCode", SqlDbType.VarChar).Value = eCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_VoucherList_AddContact(string vLogin, string vName, string cName, string vMobile, string vEmail, string eCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherList_ContactAdd", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@eCode", SqlDbType.VarChar).Value = eCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_VoucherList_AddContact_Manual(string vMobile, string vCode, string vEmail, string vName, string cName, string vMessage)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_Purchase_Manual", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@VCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@EMail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = "0";
                dbCmd.Parameters.Add("@msgid", SqlDbType.VarChar).Value = "0";
                dbCmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_TicketList_AddContact_Manual(string vMobile, string vCode, string vEmail, string vName, string cName, string vMessage)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_Purchase_Manual", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@tCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@EMail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = "0";
                dbCmd.Parameters.Add("@msgid", SqlDbType.VarChar).Value = "0";
                dbCmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_EBookList_AddContact_Manual(string vMobile, string vCode, string vEmail, string vName, string cName, string vMessage)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_Purchase_Manual", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@eCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@EMail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = "0";
                dbCmd.Parameters.Add("@msgid", SqlDbType.VarChar).Value = "0";
                dbCmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_VouchercodeList(string vLogin)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherCodeList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_purchaseBCode(string vLogin, string BCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthDay_PurchaseCode", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@bCode", SqlDbType.VarChar).Value = BCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_VoucherURL(string vCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_getImageURL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vCode", SqlDbType.VarChar).Value = vCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdaySettings_Update(string vLogin, string vCode, string vStatus, string RMessage, string RMessageC)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthdaySettings_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@AlertStatus", SqlDbType.TinyInt).Value = vStatus;
                dbCmd.Parameters.Add("@RMessage", SqlDbType.NVarChar).Value = RMessage;
                dbCmd.Parameters.Add("@RMessageC", SqlDbType.NVarChar).Value = RMessageC;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_BirthdayAlertSettings_Update(string vLogin, string vStatus, string AMessage, string AMessageC)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BirthdayAlertSettings_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@AlertStatus", SqlDbType.TinyInt).Value = vStatus;
                dbCmd.Parameters.Add("@AMessage", SqlDbType.NVarChar).Value = AMessage;
                dbCmd.Parameters.Add("@AMessageC", SqlDbType.NVarChar).Value = AMessageC;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_Purchase(string vMobile, string tCode, string vName, string cName, string vEmail, string vMsg, string vMsgid, string vSCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_Purchase", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.BigInt).Value = vMobile;
                dbCmd.Parameters.Add("@tCode", SqlDbType.VarChar).Value = tCode;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@FName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = vSCode;
                dbCmd.Parameters.Add("@msgid", SqlDbType.VarChar).Value = vMsgid;
                dbCmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = vMsg;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_Purchase(string vMobile, string tCode, string vName, string cName, string vEmail, string vMsg, string vMsgid, string vSCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_Purchase", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.BigInt).Value = vMobile;
                dbCmd.Parameters.Add("@eCode", SqlDbType.VarChar).Value = tCode;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@FName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = vSCode;
                dbCmd.Parameters.Add("@msgid", SqlDbType.VarChar).Value = vMsgid;
                dbCmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = vMsg;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_Purchase(string vMobile, string tCode, string vName, string cName, string vEmail, string vMsg, string vMsgid, string vSCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_Purchase", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.BigInt).Value = vMobile;
                dbCmd.Parameters.Add("@VCode", SqlDbType.VarChar).Value = tCode;
                dbCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@FName", SqlDbType.NVarChar).Value = vName;
                dbCmd.Parameters.Add("@SCode", SqlDbType.BigInt).Value = vSCode;
                dbCmd.Parameters.Add("@msgid", SqlDbType.VarChar).Value = vMsgid;
                dbCmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = vMsg;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet BillPlz_getEmailDetails(string vBillID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("GlobalAPI.dbo.USPT_BillPlz_getEmailDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@BillID", SqlDbType.VarChar).Value = vBillID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet BillPlz_getReturnValues(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("GlobalAPI.dbo.USPT_BillPlz_SuccessDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet BillPlzPurchaseHistory_admin(String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_bankingHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.VarChar).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet BillPlz_currencyConvert(String vDenomination, string vAmount)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("GlobalAPI.dbo.USPT_BillPlz_convertMYR", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@denomination", SqlDbType.VarChar).Value = vDenomination;
                dbCmd.Parameters.Add("@amount", SqlDbType.Money).Value = vAmount;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Paypal_getReturnValues(string vTID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("GlobalAPI.dbo.USPT_Paypal_SuccessDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = vTID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_Listing_ReqAdm(int vUserId, int vUserType, int vPageNo, string vSearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.usp_EB_WP_eBooksListing_ReqAdm", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = vUserType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_Listing_ReqAdm_Delete(string bookID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.usp_EB_WP_eBookListinh_ReqAdm_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@bookID", SqlDbType.VarChar).Value = bookID;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getQuestionnaire(string testID, String vUserId, string vType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_getTest", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@testID", SqlDbType.Int).Value = testID;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vType", SqlDbType.Int).Value = vType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getAnswers(string testID, String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_getAnswers", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@testID", SqlDbType.Int).Value = testID;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_updateAnswers(string testID, String vUserId, string questionID, string userAnswerID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@testID", SqlDbType.Int).Value = testID;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@questionID", SqlDbType.Int).Value = questionID;
                dbCmd.Parameters.Add("@userAnswerID", SqlDbType.Int).Value = userAnswerID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_updateTestResult(string testID, String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_UserCompleted", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@testID", SqlDbType.Int).Value = testID;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getTestResult(string testID, String vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_getStatus", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@testID", SqlDbType.Int).Value = testID;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_validateLogin(string vLogin, string vPassword)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Training_Login", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@loginid", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = vPassword;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_LoginFromEbook(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Training_LoginFromEbook", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_validateTelegramLogin(string tLogin)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Training_TelegramLogin", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tLoginId", SqlDbType.VarChar).Value = tLogin;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getCheckList(string tLogin,string testid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("API.dbo.USPT_Test_checkList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = tLogin;
                dbCmd.Parameters.Add("@testID", SqlDbType.Int).Value = testid;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getMenu(String vUserId, string eType, string elanguage, string package)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_Menu", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@eType", SqlDbType.Int).Value = eType;
                dbCmd.Parameters.Add("@language", SqlDbType.Int).Value = elanguage;
                dbCmd.Parameters.Add("@package", SqlDbType.Int).Value = package;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getMenuBK1(String vUserId, string eType, string elanguage, string package)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_Menu_BK1", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@eType", SqlDbType.Int).Value = eType;
                dbCmd.Parameters.Add("@language", SqlDbType.Int).Value = elanguage;
                dbCmd.Parameters.Add("@package", SqlDbType.Int).Value = package;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getMenuBK2(String vUserId, string eType, string elanguage, string package)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_Menu_BK2", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@eType", SqlDbType.Int).Value = eType;
                dbCmd.Parameters.Add("@language", SqlDbType.Int).Value = elanguage;
                dbCmd.Parameters.Add("@package", SqlDbType.Int).Value = package;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getMenuBB(String vUserId, string eType, string elanguage, string package)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_Menu_BB", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@eType", SqlDbType.Int).Value = eType;
                dbCmd.Parameters.Add("@language", SqlDbType.Int).Value = elanguage;
                dbCmd.Parameters.Add("@package", SqlDbType.Int).Value = package;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getMenuAW(String vUserId, string eType, string elanguage, string package)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_MenuAW", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@eType", SqlDbType.Int).Value = eType;
                dbCmd.Parameters.Add("@language", SqlDbType.Int).Value = elanguage;
                dbCmd.Parameters.Add("@package", SqlDbType.Int).Value = package;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getMenuEM(String vUserId, string eType, string elanguage, string package)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_MenuEM", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@eType", SqlDbType.Int).Value = eType;
                dbCmd.Parameters.Add("@language", SqlDbType.Int).Value = elanguage;
                dbCmd.Parameters.Add("@package", SqlDbType.Int).Value = package;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getMenuPE(String vUserId, string eType, string elanguage, string package)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_MenuPE", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@eType", SqlDbType.Int).Value = eType;
                dbCmd.Parameters.Add("@language", SqlDbType.Int).Value = elanguage;
                dbCmd.Parameters.Add("@package", SqlDbType.Int).Value = package;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_getTestID(string NID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_getTestID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@nid", SqlDbType.VarChar).Value = NID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Training_Dashboard(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("API.dbo.USPT_Test_Dashboard", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EmailEbook_getDetails(string vTranID, string pType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.EmailEbook_getDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.Int).Value = vTranID;
                dbCmd.Parameters.Add("@pType", SqlDbType.Int).Value = pType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet SMSEbook_getDetails(string vTranID, string pType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.EmailEbook_sendSMS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vTranID", SqlDbType.Int).Value = vTranID;
                dbCmd.Parameters.Add("@pType", SqlDbType.Int).Value = pType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet BillPlz_getGateway()
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Globalapi.dbo.USPT_BillPlz_getGateway", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Wassap_getEmailPassword(string vLoginID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Wassap_getPasswordEmail", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBK_Restore(string eCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBK_Restore", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eCode", SqlDbType.VarChar).Value = eCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ticket_Restore(string eCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Ticket_Restore", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tCode", SqlDbType.VarChar).Value = eCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Voucher_Restore(string eCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Voucher_Restore", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vCode", SqlDbType.VarChar).Value = eCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_EBKListArchive(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_EBKListArchive", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@ePageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@eSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_TicketListArchive(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_TicketListArchive", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@tPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@tSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_VoucherListArchive(string vUserID, int pageno, string SearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherListArchive", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = pageno;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = SearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet bigdata_getProfile(string vUserID, string vLogin)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_getBigDataProfile", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLogin;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet bigdata_updateProfile(string vUserID, string vLogin, string fullname, string nickname, string email,string handphone, string homephone, string address, string fax, string emailbranding)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_updateBigdataProfile", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLogin;

                dbCmd.Parameters.Add("@fullname", SqlDbType.VarChar).Value = fullname;
                dbCmd.Parameters.Add("@nickname", SqlDbType.VarChar).Value = nickname;
                dbCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                dbCmd.Parameters.Add("@handphone", SqlDbType.VarChar).Value = handphone;
                dbCmd.Parameters.Add("@homephone", SqlDbType.VarChar).Value = homephone;
                dbCmd.Parameters.Add("@faxno", SqlDbType.VarChar).Value = fax;
                dbCmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
                dbCmd.Parameters.Add("@emailbranding", SqlDbType.VarChar).Value = emailbranding;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet bigdata_sendSMS(string vMerID, string vMobile, string vMessage)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_sendSMSForContactUs", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMerID", SqlDbType.VarChar).Value = vMerID;
                dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vMessage", SqlDbType.VarChar).Value = vMessage;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet bigdata_sendEmail(string vMerID, string vCount, string vMessage, string vSubject, string vBodyHTML, string vList)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USP_Insert_SEKEmailInfo_BigData", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.BigInt).Value = vMerID;
                dbCmd.Parameters.Add("@vParam", SqlDbType.VarChar).Value = "EB-CList";
                dbCmd.Parameters.Add("@vMailType", SqlDbType.TinyInt).Value = "1";
                dbCmd.Parameters.Add("@vCatID", SqlDbType.BigInt).Value = "0";
                dbCmd.Parameters.Add("@vSuccessEntries", SqlDbType.Money).Value = vCount;
                dbCmd.Parameters.Add("@vFailureEntries", SqlDbType.Money).Value = "0";
                dbCmd.Parameters.Add("@vMessage", SqlDbType.VarChar).Value = vMessage;
                dbCmd.Parameters.Add("@vSubject", SqlDbType.VarChar).Value = vSubject;
                dbCmd.Parameters.Add("@vBodyHTML", SqlDbType.NVarChar).Value = vBodyHTML;
                dbCmd.Parameters.Add("@vAttachment", SqlDbType.VarChar).Value = vBodyHTML;
                dbCmd.Parameters.Add("@vEmailAddressList", SqlDbType.VarChar).Value = vList;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet bigdata_TelegramLogout(string vLogin)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Globalapi.dbo.USPT_Telegram_GlobalCorp_LogoutALL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet merchant_TelegramLogout(string vLogin)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Globalapi.dbo.USPT_Telegram_Merchant_LogoutALL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet WMDP_AddressBook_AddContact(string vLogin,string vMobile, string catid, string vEmail, string vName, string cName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_AddressBook_ContactAdd", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@vName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@cName", SqlDbType.NVarChar).Value = cName;
                dbCmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@EMail", SqlDbType.VarChar).Value = vEmail;
                dbCmd.Parameters.Add("@catID", SqlDbType.VarChar).Value = catid;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet checkPrice_Addbooks(string vCurrency, string dPrice, string cRate)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_checkPrice_Addbooks", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@currency", SqlDbType.VarChar).Value = vCurrency;
                dbCmd.Parameters.Add("@discountedPrice", SqlDbType.Money).Value = dPrice;
                dbCmd.Parameters.Add("@cRate", SqlDbType.Money).Value = cRate;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet BigData_smsRate()
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_Bigdata_SMSRate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet MMP_smsRate()
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_MMP_SMSRate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Merchant_UploadBirthdayVoucher(string vUserID, string vName, string vImage)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherCode_Birthday_Insert", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
                dbCmd.Parameters.Add("@vName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@vImage", SqlDbType.VarChar).Value = vImage;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet MerchantBirthday_VoucherURL(string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_VoucherBirthday_getImageURL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBook_getPhysicalBookPages()
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_getPhysicalBookPages", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBook_getPhysicalBookDetails(string vLogin, string vCode, string vSize, string vUnits, string vPages)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_getPhysicalBookDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@bookCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@vSize", SqlDbType.TinyInt).Value = vSize;
                dbCmd.Parameters.Add("@vUnits", SqlDbType.Int).Value = vUnits;
                dbCmd.Parameters.Add("@vPages", SqlDbType.Int).Value = vPages;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBook_BuyPhysicalBook(string vLogin, string vCode, string vSize, string vUnits, string vPages, string shippingAddress)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BuyPhysicalBook", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@bookCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@vSize", SqlDbType.TinyInt).Value = vSize;
                dbCmd.Parameters.Add("@vUnits", SqlDbType.Int).Value = vUnits;
                dbCmd.Parameters.Add("@vPages", SqlDbType.Int).Value = vPages;
                dbCmd.Parameters.Add("@shippingAddress", SqlDbType.VarChar).Value = shippingAddress;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBook_BuyPhysicalBookValidate(string vLogin, string vCode, string vSize, string vUnits, string vPages, string shippingAddress)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_BuyPhysicalBookValidate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@bookCode", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@vSize", SqlDbType.TinyInt).Value = vSize;
                dbCmd.Parameters.Add("@vUnits", SqlDbType.Int).Value = vUnits;
                dbCmd.Parameters.Add("@vPages", SqlDbType.Int).Value = vPages;
                dbCmd.Parameters.Add("@shippingAddress", SqlDbType.VarChar).Value = shippingAddress;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBook_BuyPhysicalBookHistory(string vLogin)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_getPhysicalBookOrders", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLogin;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet LoginAdmin_GeniusBrain(string vLogin, string vPassword)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_getAdminLoginDetailsGB", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@adminid", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@adminpwd", SqlDbType.VarChar).Value = vPassword;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_CPIncentiveDetails(string vCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_admin_getCPIncentiveDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pCode", SqlDbType.Int).Value = vCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_Purchases(string vCode, string vMobile, string vType, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_getProductPurchases", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pCode", SqlDbType.Int).Value = vCode;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@pType", SqlDbType.TinyInt).Value = vType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet GeniusBrain_UploadFinal(string vLoginID, string vCatID, string vTableName)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_ImportProcess_GBFinal", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vSelCategoryID", SqlDbType.VarChar).Value = vCatID;
                dbCmd.Parameters.Add("@vTableName", SqlDbType.VarChar).Value = vTableName;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_purchaseStatus(string pMobile, string pCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_ProductPurchasedInfo", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@dMobile", SqlDbType.VarChar).Value = pMobile;
                dbCmd.Parameters.Add("@Pcode", SqlDbType.TinyInt).Value = pCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_CodeList(string vMobile, string vType, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_getGeniusBrainSets", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pSet", SqlDbType.TinyInt).Value = vType;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_UploadHistory(string vMobile, string vType, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_getGeniusBrainUploadHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pSet", SqlDbType.TinyInt).Value = vType;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_UploadHistoryCodeList(string vUploadId, string vCode, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_getGeniusBrainSets_byUploadID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@uploadID", SqlDbType.BigInt).Value = vUploadId;
                dbCmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_DeleteCoupon(string vCouponId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_geniusBrain_DeleteCoupon", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@couponID", SqlDbType.BigInt).Value = vCouponId;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_CouponSummary(string vMobile, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_CouponSummary", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_CouponSearch(string vCode, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_getGeniusBrainSets_byCoupon", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = vCode;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GB_LessonList(string vType, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_LessonList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eType", SqlDbType.TinyInt).Value = vType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GB_TestList(string vType, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_TestList", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eType", SqlDbType.TinyInt).Value = vType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GB_ResultList(string vType, string vMobile, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_Results", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@eType", SqlDbType.TinyInt).Value = vType;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GB_LessonDetails(string vID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_getLessonDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@LessonID", SqlDbType.Int).Value = vID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GB_UpdateLessonDetails(string vID, string vName, string vDesc, string vNewsf)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_updateLessonDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@LessonID", SqlDbType.Int).Value = vID;
                dbCmd.Parameters.Add("@testName", SqlDbType.VarChar).Value = vName;
                dbCmd.Parameters.Add("@testDesc", SqlDbType.VarChar).Value = vDesc;
                dbCmd.Parameters.Add("@newsf", SqlDbType.VarChar).Value = vNewsf;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GB_TestDetails(string vID, string qID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("api.dbo.USPT_getTest_Admin", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@testID", SqlDbType.Int).Value = vID;
                dbCmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = qID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GB_updateQuestion(string questionID, string Question,string actualanswerid, string answer1, string answer2, string answer3, string answer4)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("api.dbo.USPT_Question_Modification", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@questionID", SqlDbType.Int).Value = questionID;
                dbCmd.Parameters.Add("@question", SqlDbType.VarChar).Value = Question;
                dbCmd.Parameters.Add("@Answer1", SqlDbType.VarChar).Value = answer1;
                dbCmd.Parameters.Add("@Answer2", SqlDbType.VarChar).Value = answer2;
                dbCmd.Parameters.Add("@Answer3", SqlDbType.VarChar).Value = answer3;
                dbCmd.Parameters.Add("@Answer4", SqlDbType.VarChar).Value = answer4;
                dbCmd.Parameters.Add("@ActualAnswer", SqlDbType.TinyInt).Value = actualanswerid;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_CourseBalanceHistory(string vCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_CourseIncentiveBalance", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@adminID", SqlDbType.VarChar).Value = vCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_SalesKeyin(string vMobile, string vCoupon, string vSetCode, string vDiscount)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_SalesKeyin", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@pCode", SqlDbType.VarChar).Value = vCoupon;
                dbCmd.Parameters.Add("@pSet", SqlDbType.TinyInt).Value = vSetCode;
                dbCmd.Parameters.Add("@pDiscount", SqlDbType.TinyInt).Value = vDiscount;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GBLoginDetailsKeyin(string vMobile, string vLogin, string vPassword)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_keyinLoginDetails", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@login", SqlDbType.VarChar).Value = vLogin;
                dbCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = vPassword;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_SalesKeyin_Validate(string vMobile, string vCoupon, string vSetCode, string vDiscount)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_SalesKeyin_Validate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@pCode", SqlDbType.VarChar).Value = vCoupon;
                dbCmd.Parameters.Add("@pSet", SqlDbType.TinyInt).Value = vSetCode;
                dbCmd.Parameters.Add("@pDiscount", SqlDbType.TinyInt).Value = vDiscount;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_SalesHistory(string vMobile, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_SalesHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_IncentiveGainList(string vMobile, string vType, string vPageno)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_AdminGeniusBrain_SalesIncentiveHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vMobile;
                dbCmd.Parameters.Add("@IType", SqlDbType.TinyInt).Value = vType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageno;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GB_UpateWebsiteInfo(string vInfo)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrain_WebsiteInfoUpdate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@websiteinfo", SqlDbType.VarChar).Value = vInfo;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Admin_GBDashboard(string vCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Admin_GeniusBrainDashboard", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_User_GBDashboard(string vCode)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_GeniusBrain_Dashboard", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@pMobile", SqlDbType.VarChar).Value = vCode;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Retrieve_DirectAffiliateBGPartnersNew(String vMobileNo, String vSrcMobile, String vSrcName, int vPageNo, int createsms, int WMDP)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USP_Retrieve_DirectNetworkBGPartnersNew", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileNo", SqlDbType.VarChar).Value = vMobileNo;
                dbCmd.Parameters.Add("@vSrcMobile", SqlDbType.VarChar).Value = vSrcMobile;
                dbCmd.Parameters.Add("@vSrcName", SqlDbType.VarChar).Value = vSrcName;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vCreateSMS", SqlDbType.TinyInt).Value = createsms;
                dbCmd.Parameters.Add("@vWMDP", SqlDbType.TinyInt).Value = WMDP;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }


        }

        public DataSet products_Upload_Certificate(string vTID,string vMobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Certificates_Add", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.TinyInt).Value = vTID;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = vMobile;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Upload_CertificateEM(string vTID, string vMobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Certificates_AddEM", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.TinyInt).Value = vTID;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = vMobile;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet products_Upload_CertificatePE(string vTID, string vMobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Certificates_AddPE", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TID", SqlDbType.TinyInt).Value = vTID;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = vMobile;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_RequestDomainChange(string vDomain, string vUserID)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("cmsdb.dbo.Usp_DomainName_RequestChange", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@DomainName", SqlDbType.VarChar).Value = vDomain;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = vUserID;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_bookupdateHistory(string Mobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_EB_EBookUpdateHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_topBestSellerEBooks(string userid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_TopBestSeller", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userID", SqlDbType.Int).Value = userid;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_topBestSellerEBooksMWallet(string userid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_TopBestSeller_MWallet", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userID", SqlDbType.Int).Value = userid;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_topUpgrades(string Mobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_TopUpgrades", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_EISBNupdate(string userid, string bookid, string eisnbnCode, string eisbnImage, string eisbnPRemarks)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("ebook.dbo.USPT_EISBNupdate", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = userid;
                dbCmd.Parameters.Add("@bookid", SqlDbType.VarChar).Value = bookid;
                dbCmd.Parameters.Add("@eisnbnCode", SqlDbType.VarChar).Value = eisnbnCode;
                dbCmd.Parameters.Add("@eisbnImage", SqlDbType.VarChar).Value = eisbnImage;
                dbCmd.Parameters.Add("@eisbnPRemarks", SqlDbType.VarChar).Value = eisbnPRemarks;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_EISBNupdateHistory(string Mobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_EB_EISBNUpdateHistory", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = Mobile;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_ListingNew(int vUserId, int vUserType, int vPageNo, string vSearchStr, string fType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("ebook.dbo.usp_EB_WP_eBooksListing_SearchNew", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = vUserType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@fType", SqlDbType.TinyInt).Value = fType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_getAuthorBirthdayBooks(string Mobile, string rDay)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getAuthorBirthdayBooks", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = Mobile;
                dbCmd.Parameters.Add("@rDay", SqlDbType.TinyInt).Value = rDay;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_getAuthorBirthdayBooks(string rcnt)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getBirthdaysNext20", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@cnt", SqlDbType.TinyInt).Value = rcnt;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_getAuthorBirthdayBooksMonthwise(string Mobile, string rDay)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getAuthorBirthdayBooksMonthwise", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = Mobile;
                dbCmd.Parameters.Add("@rDay", SqlDbType.TinyInt).Value = rDay;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_getAuthorBirthdayMonthCount(string rDay)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_getBirthdaysThisMonth", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@day", SqlDbType.TinyInt).Value = rDay;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_getEBookcountTotalUser(string userid)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.usp_EB_GetEbookCountTotal", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = userid;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Ebook_Listing_ByUserID_Search(int vUserID, string vSearchStr)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_BooksListing_ByUserID_Search", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet EBook_Get_MainCategories_New(int vUserID, string vSearchStr, string fType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_View_MainCategories_New", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@fType", SqlDbType.TinyInt).Value = fType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }


        }

        public DataSet Ebook_Listing_New(int vUserId, int vUserType, int vPageNo, string vSearchStr, string fType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_WP_eBooksListing_Search_New", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = vUserType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@fType", SqlDbType.TinyInt).Value = fType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet Ebook_Listing_FranchiseNew(int vUserId, int vUserType, int vPageNo, string vSearchStr, string fType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_WP_eBooksListing_Search_FranchiseNew", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = vUserType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@fType", SqlDbType.TinyInt).Value = fType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet Category_Load_ByUserID_New(int vUserID, string vSearchStr, string fType)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_CategoryListing4User_New", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@fType", SqlDbType.TinyInt).Value = fType;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet Ebook_Listing_FranchiseNewALL(int vUserId, int vUserType, int vPageNo, string vSearchStr, string fType, string fcat)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_WP_eBooksListing_Search_FranchiseNewALL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = vUserType;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@fType", SqlDbType.TinyInt).Value = fType;
                dbCmd.Parameters.Add("@fcat", SqlDbType.VarChar).Value = fcat;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet Category_Load_ByUserID_NewALL(int vUserID, string vSearchStr, string fType, string fcat)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_CategoryListing4User_NewALL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@fType", SqlDbType.TinyInt).Value = fType;
                dbCmd.Parameters.Add("@fcat", SqlDbType.VarChar).Value = fcat;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }

        public DataSet EBook_Get_MainCategories_NewALL(int vUserID, string vSearchStr, string fType, string fcat)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("EBook.dbo.usp_EB_View_MainCategories_NewALL", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;
                dbCmd.Parameters.Add("@fType", SqlDbType.TinyInt).Value = fType;
                dbCmd.Parameters.Add("@fcat", SqlDbType.VarChar).Value = fcat;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }


        }

        public DataSet user_updateMobile(string Login, string Mobile)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("esms.dbo.USPT_User_UpdateMobile", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tUserId", SqlDbType.VarChar).Value = Login;
                dbCmd.Parameters.Add("@tMobile", SqlDbType.VarChar).Value = Mobile;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet Retrieve_EbookRequestListings_Free(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("Business.dbo.USP_Retrieve_EbookRequestListings_FreeSYS", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMID", SqlDbType.Int).Value = vMID;
                dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@vPageSize", SqlDbType.Int).Value = vPageSize;
                dbCmd.Parameters.Add("@vSearchSQL", SqlDbType.VarChar).Value = vSearchSQL;

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_getStarRating(string thisMonth, string cMonth, string cYear)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_BestSeller_StartRating", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@thisMonth", SqlDbType.TinyInt).Value = thisMonth;
                dbCmd.Parameters.Add("@cMonth", SqlDbType.Int).Value = cMonth;
                dbCmd.Parameters.Add("@cYear", SqlDbType.Int).Value = cYear;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet ebook_getStarRating_yourAdminBooks(int vUserId)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("EBook.dbo.USPT_StarRating_YourAdminBooks", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = vUserId;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataSet buyer_getFreezeLoginStatus(string test)
        {
            try
            {
                dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
                dbConn = new SqlConnection(dbConnString);

                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("esms.dbo.USPT_Buyer_fetFreezeLoginStatus", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@test", SqlDbType.VarChar).Value = test;
                dbCmd.ExecuteNonQuery();

                dbAdap = new SqlDataAdapter(dbCmd);
                dsShortCode = new DataSet();
                dbAdap.Fill(dsShortCode);

                return dsShortCode;
            }
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

