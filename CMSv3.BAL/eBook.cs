using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;


namespace CMSv3.BAL
{

    public class eBook
    {
       
        CMSv3.DAL.eBook objEbook = new CMSv3.DAL.eBook(); 

        public DataSet Validate_UserLogin(String vLoginID, String vPwd)
        {
            return objEbook.Validate_UserLogin(vLoginID, vPwd); 
        }


        public DataSet EBOOK_GetDetailsbyMID(String vMID)
        {
            return objEbook.EBOOK_GetDetailsbyMID(vMID);
        }


        public DataSet EMS_GetEbookUsers(string vSearchQuery)
        {
            return objEbook.EMS_GetEbookUsers(vSearchQuery);
        }


        public int InsertUpdate_Ebook_EMSContent(string vAdminID, string vAdminPwd, string vEnquiryID, string vEnquiryPwd, string vHttpUrlLink, long vMobileLoginID)
        {
            return objEbook.InsertUpdate_Ebook_EMSContent(vAdminID, vAdminPwd, vEnquiryID, vEnquiryPwd, vHttpUrlLink, vMobileLoginID); 
        }


        public DataSet Retrieve_EMSContent(String vMobileId, string vSearchStr)
        {
            return objEbook.Retrieve_EMSContent(vMobileId, vSearchStr); 
        }

        public DataSet Retrieve_EMSContent_ByUserID(int vUserID)
        {
            return objEbook.Retrieve_EMSContent_ByUserID(vUserID);
        }


        public int PayPalSettings(int vUserID, int vEmailType, String vEmailID)
        {
            return objEbook.PayPalSettings(vUserID, vEmailType, vEmailID); 
        }

        public DataSet Ebook_Listing_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_Listing_ByUserID(vUserID, vSearchStr); 
        }


        public DataSet Ebook_FeatureBuyListing_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_FeatureBuyListing_ByUserID(vUserID, vSearchStr);
        }

        public DataSet Ebook_BestSellerListing_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_BestSellerListing_ByUserID(vUserID, vSearchStr);
        }

        public DataSet Ebook_NewReleaseListing_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_NewReleaseListing_ByUserID(vUserID, vSearchStr); 
        }

        public DataSet Ebook__ADM_ValueBuyListing_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook__ADM_ValueBuyListing_ByUserID(vUserID, vSearchStr); 
        }

        public DataSet Ebook_ValueBuyListing_ByUserID(int vUserID, string vSearchStr)
        {

            return objEbook.Ebook_ValueBuyListing_ByUserID(vUserID, vSearchStr); 
        }

        public DataSet Ebook_ValueBuyListing_ByBookID(int vUserID, string vBookID)
        {
            return objEbook.Ebook_ValueBuyListing_ByBookID(vUserID, vBookID); 
        }

        public DataSet Ebook_KeywordDetails_ByUserID(int vUserID)
        {
            return objEbook.Ebook_KeywordDetails_ByUserID(vUserID); 
        }


        public DataSet Ebook_Listing(int vUserId, int vUserType,int vPageNo, string vSearchStr)
        {
            return objEbook.Ebook_Listing(vUserId,vUserType,vPageNo , vSearchStr); 
        }


        public DataSet Category_Listing_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Category_Listing_ByUserID(vUserID, vSearchStr); 
        }

        public DataSet Category_HP_Listing_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Category_HP_Listing_ByUserID(vUserID, vSearchStr);
        }

        public DataSet Category_HP_Listing_ByAdminID(int vUserID, string vSearchStr)
        {
            return objEbook.Category_HP_Listing_ByAdminID(vUserID, vSearchStr); 
        }


        public DataSet Category_WP_Listing(int vUserID, string vSearchStr)
        {

            return objEbook.Category_WP_Listing(vUserID, vSearchStr); 
        }

        public int Category_WP_Add(int vCatMainId,string vCategoryName, bool vDisplay, int vUserID, int vMerchantID)
        {
            return objEbook.Category_WP_Add(vCatMainId,vCategoryName, vDisplay, vUserID, vMerchantID); 
        }


        public int Category_WP_Delete(int vCatId, int vUserID)
        {
            return objEbook.Category_WP_Delete(vCatId, vUserID); 
        }

        public int Category_WP_Update(int vUserID, int vCatId, string vCategoryName, bool vDisplay)
        {
            return objEbook.Category_WP_Update(vUserID, vCatId, vCategoryName, vDisplay); 
        }

        public int Category_Validate(int vUserId, string vCategoryName)
        {
            return objEbook.Category_Validate(vUserId, vCategoryName); 
        }
                
        public int CatMain_Add(string vCategoryName, bool vDisplay, int vUserID, int vMerchantID)
        {
            return objEbook.CatMain_Add(vCategoryName, vDisplay, vUserID, vMerchantID); 
        }


        public int CatMain_Update(int vUserID, int vCatId, string vCategoryName, bool vDisplay)
        {
            return objEbook.CatMain_Update(vUserID, vCatId, vCategoryName, vDisplay); 
        }

        public int CatMain_Delete(int vCatId, int vUserID)
        {
            return objEbook.CatMain_Delete(vCatId, vUserID); 
        }

        public int CatMain_Validate(int vUserID, string vCategoryName)
        {
            return objEbook.CatMain_Validate(vUserID, vCategoryName); 
        }

        public DataSet CatMain_Listing(int vUserID, string vSearchStr)
        {
            return objEbook.CatMain_Listing(vUserID, vSearchStr); 
        }

        public DataSet CatMain_Categories(int vUserID, string vSearchStr)
        {
            return objEbook.CatMain_Categories(vUserID, vSearchStr); 
        }

        public DataSet Ebook_AdminSpPage(int vUserID)
        {
            return objEbook.Ebook_AdminSpPage(vUserID); 
        }


        public int Ebook_ShowHide(int vUserID, string vBookID, int vBookUID, int vBookType, bool vChkDisplay)
        {
            return objEbook.Ebook_ShowHide(vUserID, vBookID, vBookUID, vBookType, vChkDisplay); 
        }


        public int Ebook_ShowHide_HpItems(int vUserID, string vBookID, int vBookUID, int vBookType, bool vChkHpShow)
        {
            return objEbook.Ebook_ShowHide_HpItems(vUserID, vBookID, vBookUID, vBookType, vChkHpShow); 
        }

        public DataSet HomePageItems_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.HomePageItems_ByUserID(vUserID, vSearchStr); 
        }

        public DataSet HomePageItems_Design3(int vUserID, string vSearchStr)
        {
            return objEbook.HomePageItems_Design3(vUserID, vSearchStr); 
        }

        public int EBook_AddBook_ByUser(CMSv3.Entities.Ebook ebEntity)
        {
            return objEbook.EBook_AddBook_ByUser(ebEntity); 
        }


        public int EBook_AddBook_ValueBuy_ByUser(int vUserID, CMSv3.Entities.Ebook ebEntity, String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5, int vBooksCount, bool vShowAtHp)
        {
            return objEbook.EBook_AddBook_ValueBuy_ByUser(vUserID, ebEntity, vBookID1, vBookID2, vBookID3, vBookID4, vBookID5, vBooksCount, vShowAtHp);
        
        }

        public DataSet Ebook_ValueBuy_Listing(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_ValueBuy_Listing(vUserID, vSearchStr); 
        }

        public int EBook_ValueBuy_Delete(int vValueBuyUID)
        {
            return objEbook.EBook_ValueBuy_Delete(vValueBuyUID); 
        }

        public DataSet Ebook_ValueBuy_Edit(string vBookID, int vUserID)
        {
            return objEbook.Ebook_ValueBuy_Edit(vBookID, vUserID); 
        }

        public int EBook_ValueBuy_Update(int vUserID, CMSv3.Entities.Ebook ebEntity, String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5, int vBooksCount, bool vShowAthp)
        {
            return objEbook.EBook_ValueBuy_Update(vUserID, ebEntity, vBookID1, vBookID2, vBookID3, vBookID4, vBookID5, vBooksCount, vShowAthp); 
        }

        public DataSet Ebook_CheckValueBuyBookIDs(int vBookCount, String vBookID1, String vBookID2, String vBookID3, String vBookID4, String vBookID5)
        {
            return objEbook.Ebook_CheckValueBuyBookIDs(vBookCount, vBookID1, vBookID2, vBookID3, vBookID4, vBookID5); 
        }


        public DataSet Category_Load_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Category_Load_ByUserID(vUserID, vSearchStr); 
        }


        public DataSet Ebook_Edit(string vBookID)
        {
            return objEbook.Ebook_Edit(vBookID);
        }


        public int EBook_Delete(string vBookID, int vUID)
        {
            return objEbook.EBook_Delete(vBookID, vUID); 
        }

        public int EBook_UpdateBook_ByUser(CMSv3.Entities.Ebook ebEntity)
        {
            return objEbook.EBook_UpdateBook_ByUser(ebEntity); 
        }

        public DataSet EBOOK_GetBook2EmailDetails(string vBookID)
        {
            return objEbook.EBOOK_GetBook2EmailDetails(vBookID); 
        }

        public DataSet EBOOK_GetBook2EmailDetails2(string vBookID)
        {
            return objEbook.EBOOK_GetBook2EmailDetails2(vBookID); 
        }

        public DataSet Ebook_GetBookDetails(string vBookID, int vUserID)
        {
            return objEbook.Ebook_GetBookDetails(vBookID, vUserID); 
        }

        //..Best SELLER 
        //======================= ======================================== =============================

        public int Ebook_BestSeller_ADD(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp)
        {
            return objEbook.Ebook_BestSeller_ADD(vBookUID, vBookID, vUserID, vShowAtHp); 
        }


        public DataSet Ebook_BestSeller_LIST(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_BestSeller_LIST(vUserID, vSearchStr); 
        }

        public int EBook_BestSeller_Delete(int vBestSellerUID)
        {
            return objEbook.EBook_BestSeller_Delete(vBestSellerUID); 
        }


        public int EBook_BestSeller_Update(int vBestSellerUID, bool vShowatHP)
        {
            return objEbook.EBook_BestSeller_Update(vBestSellerUID, vShowatHP); 
        }

        public DataSet GET_BookIDs(String vPrefix)
        {
            return objEbook.GET_BookIDs(vPrefix); 
        }


        //..Feature Buy 
        //======================= ======================================== =============================
        
        public int Ebook_FeatureBuy_ADD(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp)
        {
            return objEbook.Ebook_FeatureBuy_ADD(vBookUID, vBookID, vUserID, vShowAtHp);
        }


        public DataSet Ebook_FeatureBuy_LIST(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_FeatureBuy_LIST(vUserID, vSearchStr);
        }

        public int EBook_FeatureBuy_Delete(int vFeatureBuyUID)
        {
            return objEbook.EBook_FeatureBuy_Delete(vFeatureBuyUID);
        }


        public int EBook_FeatureBuy_Update(int vFeatureBuyUID, bool vShowatHP)
        {
            return objEbook.EBook_FeatureBuy_Update(vFeatureBuyUID, vShowatHP);
        }

       // =========== ============================
        // Free EBOOK 


        public int Ebook_FreeEbook_ADD(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp)
        {
            return objEbook.Ebook_FreeEbook_ADD(vBookUID, vBookID, vUserID, vShowAtHp); 
        
        }

        public DataSet Ebook_FreeEbook_LIST(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_FreeEbook_LIST(vUserID, vSearchStr); 
        }

        public int EBook_FreeEbook_Delete(int vFreeBookUID)
        {
            return objEbook.EBook_FreeEbook_Delete(vFreeBookUID); 
        }


        public int EBook_FreeEbook_Update(int vFreeBookUID, bool vShowatHP)
        {
            return objEbook.EBook_FreeEbook_Update(vFreeBookUID, vShowatHP); 
        }


        // =========== ============================
        // New Release EBOOK 


        public DataSet Ebook_NewRelease_LIST(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_NewRelease_LIST(vUserID, vSearchStr); 
        }


        public int Ebook_NewRelease_ADD(int vBookUID, string vBookID, int vUserID, Boolean vShowAtHp)
        {
            return objEbook.Ebook_NewRelease_ADD(vBookUID, vBookID, vUserID, vShowAtHp); 
        }

        public int EBook_NewRelease_Delete(int vFreeBookUID)
        {
            return objEbook.EBook_NewRelease_Delete(vFreeBookUID);
        }


        public int EBook_NewRelease_Update(int vFreeBookUID, bool vShowatHP)
        {
            return objEbook.EBook_NewRelease_Update(vFreeBookUID, vShowatHP);
        }


        // ====================================================


        public DataSet Ebook_DashBoard(int vUserID, int vMerchantID, string vMobileLoginID)
        {
            return objEbook.Ebook_DashBoard(vUserID, vMerchantID, vMobileLoginID); 
        }

        public DataSet Ebook_eStore_ManagementView(int vUserID)
        {
            return objEbook.Ebook_eStore_ManagementView(vUserID); 
        }

        public DataSet Ebook_GeteStoreID(int vUserID)
        {
            return objEbook.Ebook_GeteStoreID(vUserID); 
        }

        public int Ebook_eStoreID_Validity(string vStoreID)
        {
            return objEbook.Ebook_eStoreID_Validity(vStoreID); 

        }

        public int Ebook_eStoreID_Create(string vStoreID, int vUserID, int vMerchantID)
        {
            return objEbook.Ebook_eStoreID_Create(vStoreID, vUserID, vMerchantID); 

        }

        public int Ebook_HomePage_HideCatIds(int vUserID, string vCatIDList,int vSelMainCatId,  int vCatType)
        {
            return objEbook.Ebook_HomePage_HideCatIds(vUserID, vCatIDList ,vSelMainCatId,  vCatType); 
        }

        public int Ebook_HomePage_Hide_MainCatIds(int vUserID, string vCatIDList, int vCatType)
        {
            return objEbook.Ebook_HomePage_Hide_MainCatIds(vUserID, vCatIDList, vCatType); 

        }
        public int Ebook_eStore_SaveSettings(int vUserID, int vShowUserCat, int vShowAdminCat, int vAllowSMSBuy, int vAllowPayPalBuy,int vAllowDirectBankIn, String vSelectedCurrency)
        {
            return objEbook.Ebook_eStore_SaveSettings(vUserID, vShowUserCat, vShowAdminCat, vAllowSMSBuy, vAllowPayPalBuy,vAllowDirectBankIn, vSelectedCurrency);
        }

        public int Ebook_eStore_SaveAdminBookDisplaySettings(int vUserID, int vEbooks, int vfeaturebuy, int vBestSeller, int vNewReleases, int vValueBuy, int vFree)
        {
            return objEbook.Ebook_eStore_SaveAdminBookDisplaySettings(vUserID, vEbooks, vfeaturebuy, vBestSeller, vNewReleases, vValueBuy, vFree); 
        }

        public int Ebook_eStore_SaveNotifications(int vUserID,int vMerchantID,  int vNotifyUsers, int vNotifyAdmin, String vMobile1, String vMobile2, String vMobile3, String vMobile4, String vMobile5)
        {
            return objEbook.Ebook_eStore_SaveNotifications(vUserID, vMerchantID, vNotifyUsers, vNotifyAdmin, vMobile1, vMobile2, vMobile3, vMobile4, vMobile5); 
        }
        public DataSet Ebook_FreeListing_ByUserID(int vUserID, string vSearchStr)
        {
            return objEbook.Ebook_FreeListing_ByUserID(vUserID, vSearchStr); 

        }

        public DataSet AdminSpecialPage_View(int vPageID, int vPageType)
        {
            return objEbook.AdminSpecialPage_View(vPageID, vPageType); 
        }

        public DataSet WpInfo_LeftMenu()
        {
            return objEbook.WpInfo_LeftMenu(); 
        }

        public DataSet WpNews_LeftMenu()
        {
            return objEbook.WpNews_LeftMenu(); 
        }

        public DataSet WpTraining_LeftMenu()
        {
            return objEbook.WpTraining_LeftMenu(); 
        }

        public DataSet WpInfo_ListByUID(int vUID, string vType)
        {
            return objEbook.WpInfo_ListByUID(vUID, vType); 
        }

        public DataSet WpTraining_ListByUID(int vUID, string vType)
        {
            return objEbook.WpTraining_ListByUID(vUID, vType); 
        }
        public DataSet WpNews_ListByUID(int vUID, string vType)
        {
            return objEbook.WpNews_ListByUID(vUID, vType); 
        }


        public DataSet EbAd_SmsCreditBalance_Retrieve(int vMerID)
        {
            return objEbook.EbAd_SmsCreditBalance_Retrieve(vMerID); 
        }

        public int EbAd_SmsCreditBalance_Deduct(int vMID, decimal vCredits)
        {
            return objEbook.EbAd_SmsCreditBalance_Deduct(vMID, vCredits); 
        }


        public DataSet Retrieve_2WayEbookCodes(String vUserID, String vMID, String vSearchSql)
        {
            return objEbook.Retrieve_2WayEbookCodes(vUserID, vMID, vSearchSql);
        }


        public DataSet Retrieve_UserBankInfo(String vUserID)
        {
            return objEbook.Retrieve_UserBankInfo(vUserID);
        }

        public DataSet Retrieve_UserProfileInfo_ByUserID(int vUserID)
        {
            return objEbook.Retrieve_UserProfileInfo_ByUserID(vUserID); 
        }


        public DataSet Eb_WEB_BuyBook(String vBookID, int vUserID)
        {
            return objEbook.Eb_WEB_BuyBook(vBookID, vUserID); 
        }

        public DataSet Eb_WEB_BuyBookMerchantInfo(String vBookID, int vUserID)
        {

            return objEbook.Eb_WEB_BuyBookMerchantInfo(vBookID, vUserID); 

        }

        public DataSet Eb_WEB_GetMerchantInfo(int vUserID)
        {
            return objEbook.Eb_WEB_GetMerchantInfo(vUserID); 
        }
        //======================= ======================================== =============================

        //08-09-2014
        public DataSet Retrieve_UserProfileInfo(String vUserID)
        {
            return objEbook.Retrieve_UserProfileInfo(vUserID);
        }

        public DataSet Retrieve_UserEmailInfo(String vIdentifier)
        {
            return objEbook.Retrieve_UserEmailInfo(vIdentifier);
        }
        public int InsertUpdate_UserEmailInfo(String vIdentifier, String vEmail)
        {
            return objEbook.InsertUpdate_UserEmailInfo(vIdentifier, vEmail);
        }


        public int eBook_eVendorCodeRegister(String vKeyword, String vShortCode, String vMobileNo, String vMerchantID)
        {
            return objEbook.eBook_eVendorCodeRegister(vKeyword, vShortCode, vMobileNo, vMerchantID);
        }

        public DataSet EBOOK_GetDetailsByMID(String vMID)
        {
            return objEbook.EBOOK_GetDetailsByMID(vMID);
        }

        public int Insert_TopupPin(String vMobile, String vTopupMobile, String vSMSPinNo)
        {
            return objEbook.Insert_TopupPin(vMobile, vTopupMobile, vSMSPinNo);
        }


        public int EB_ChangePassword(int vUserID, String vMobileLoginID, String vCurrPassword, String vNewPassword)
        {
            return objEbook.EB_ChangePassword(vUserID, vMobileLoginID, vCurrPassword, vNewPassword); 
        }

        public int EB_ChangePassword_PreCheck(String vMobileLoginID, String vCurrPassword)
        {
            return objEbook.EB_ChangePassword_PreCheck(vMobileLoginID, vCurrPassword); 
        }

        public String EBOOK_SendCCalerts(string vMobile, String vMessage, String vMsgID, String vShortcode, String vKeyword, String vBookCode, String vEmail, String vFullName)
        {
            return objEbook.EBOOK_SendCCalerts(vMobile, vMessage, vMsgID, vShortcode, vKeyword, vBookCode, vEmail, vFullName); 
        }

        public int EB_GetEbookCountForUser(int vMerchantID, int vUserID)
        {
            return objEbook.EB_GetEbookCountForUser(vMerchantID, vUserID); 
        }

        public DataSet Ebook_RetrieveDetails(string vBookID, int vUserId, String @vLoginID)
        {
            return objEbook.Ebook_RetrieveDetails(vBookID, vUserId, @vLoginID);
        }

        //======== Physical Ebooks 

        public DataSet PhyBook_GetALL_Ebooks(int vUserID, string vSearchStr)
        {
            return objEbook.PhyBook_GetALL_Ebooks(vUserID, vSearchStr);
        }

        public int PhyBook_RequestADD(int vUserID, String vMobileLoginID, string vMerchantID, int vPhyBookID1, String vPhyTemplate1, int vPhyBookID2, String vPhyTemplate2, int vBizCardID, String vPhyNameOnBook, String vPhoto1, String vPhoto2, int vDeliveryMode, String vAddress1, String vAddress2, String vCity, String vState, String vPostalCode, String vCountry)
        {
            return objEbook.PhyBook_RequestADD(vUserID,vMobileLoginID,vMerchantID, vPhyBookID1, vPhyTemplate1, vPhyBookID2, vPhyTemplate2,vBizCardID, vPhyNameOnBook, vPhoto1, vPhoto2, vDeliveryMode, vAddress1, vAddress2, vCity, vState, vPostalCode, vCountry); 
        }

        public DataSet PhyBook_Get_EbookRequestID(int vUserID, int vRequestID)
        {
            return objEbook.PhyBook_Get_EbookRequestID(vUserID, vRequestID); 
        }

        public int PhyBook_ValidateBookRequest(int vUserID)
        {
            return objEbook.PhyBook_ValidateBookRequest(vUserID); 
        }

        public int PhyBook_ConfirmBookRequest(int vUserID, int vPhyBookReqID)
        {
            return objEbook.PhyBook_ConfirmBookRequest(vUserID, vPhyBookReqID); 
        }

        public int EBook_RegProcess_GetStatus(int vUserID)
        {
            return objEbook.EBook_RegProcess_GetStatus(vUserID); 
        }

        public DataSet EBook_RegProcess_GetDetails(int vUserID)
        {
            return objEbook.EBook_RegProcess_GetDetails(vUserID); 
        }


        public int Insert_UnSubscribedEmail(String vUserID, String vEbookID, String vEmail)
        {
            return objEbook.Insert_UnSubscribedEmail(vUserID, vEbookID, vEmail);
        }

        public int Update_UnSubscribedEmail(String vUserID, String vSno)
        {
            return objEbook.Update_UnSubscribedEmail(vUserID, vSno);
        }

        public DataSet Retrieve_UnSubscribedEmail(String vUserID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return objEbook.Retrieve_UnSubscribedEmail(vUserID, vPageNo, vPageSize, vSearchSQL);
        }

        public DataSet Retrieve_EbookEmailMarketing(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return objEbook.Retrieve_EbookEmailMarketing(vMID, vPageNo, vPageSize, vSearchSQL);
        }

        public int Check_EmailSystem(String vMobileLoginID)
        {
            return objEbook.Check_EmailSystem(vMobileLoginID);
        }

        public long ShoppingCart_PreInsert(int vUserID, String vItemString, int vItemsCount, decimal vTotalAmount)
        {
            return objEbook.ShoppingCart_PreInsert(vUserID, vItemString, vItemsCount, vTotalAmount); 
        }

        
        public DataSet EBook_Get_MainCategories(int vUserID, string vSearchStr)
        {
            return objEbook.EBook_Get_MainCategories(vUserID, vSearchStr); 
        }

        public DataSet EBook_Get_SUBCategories(int vUserID, int vMainCatId, string vSearchStr)
        {
            return objEbook.EBook_Get_SUBCategories(vUserID, vMainCatId, vSearchStr); 
        }


        #region ... Bank In

        public DataSet BankIn_GetList(string vSearchStr)
        {
            return objEbook.BankIn_GetList(vSearchStr);
        }

        public DataSet Bank_Countries(string vSearchStr)
        {
            return objEbook.Bank_Countries(vSearchStr); 
        }

        public DataSet Bank_GetBankInfoByCountry(int vCountryCode)
        {
            return objEbook.Bank_GetBankInfoByCountry(vCountryCode); 
        }

        public DataSet BankIn_GetUserBanks(int vUserID, string vSearchStr)
        {
            return objEbook.BankIn_GetUserBanks(vUserID, vSearchStr); 
        }

        public DataSet Bank_GetUserInfo(int vUserID)
        {
            return objEbook.Bank_GetUserInfo(vUserID);
        }

        public int Bank_User_Add(int vBankID, String vBankActNo, String vFullName, String vRemarks, bool vDisplay, int vUserID, int vMerchantID)
        {
            return objEbook.Bank_User_Add(vBankID, vBankActNo , vFullName, vRemarks, vDisplay, vUserID, vMerchantID); 
        }

        public int Bank_User_Update(int vBank_UID, int vBankID, String vBankActNo, String vFullName, String vRemarks, bool vDisplay, int vUserID, int vMerchantID)
        {
            return objEbook.Bank_User_Update(vBank_UID, vBankID, vBankActNo, vFullName, vRemarks, vDisplay, vUserID, vMerchantID); 
        }

        public int Bank_User_Delete(int vUID, int vUserID)
        {
            return objEbook.Bank_User_Delete(vUID, vUserID); 
        }

        public int Bank_Client_Add(int vBankID, String vBankInBy, string vBankInAmt, String vBankInDate, String vBankInTime, String vBankInSlip, String vBankInRef, String vPurchaseDesc, String vPurchaseItems,String vTranID, int vUserID)
        {
            return objEbook.Bank_Client_Add(vBankID, vBankInBy, vBankInAmt, vBankInDate, vBankInTime, vBankInSlip, vBankInRef, vPurchaseDesc,vPurchaseItems,vTranID, vUserID); 
        }

        public int Bank_Transaction_Update(int vUserID, String vTranID, string vRemarks)
        {
            return objEbook.Bank_Transaction_Update(vUserID, vTranID, vRemarks); 
        }

        public int Bank_Client_PreInsert(String vbFullName, String vbMobile, String vbEmail, string vbTotalAmount, String vbCurrency, string vPurchaseItems, int vUserID, string vTranID)
        {
            return objEbook.Bank_Client_PreInsert(vbFullName, vbMobile, vbEmail, vbTotalAmount, vbCurrency, vPurchaseItems, vUserID, vTranID); 
        }

        public int Bank_Client_StoreBuyer(String vbFullName, String vbMobile, String vbEmail, int vUserID, string vTranID)
        {
            return objEbook.Bank_Client_StoreBuyer(vbFullName, vbMobile, vbEmail, vUserID, vTranID); 
        }

        public DataSet Bank_Client_GetBankInsList(int vUserId, String vSearchStr)
        {
            return objEbook.Bank_Client_GetBankInsList(vUserId, vSearchStr); 
        }

        public DataSet BankIn_UserSettings(int vUserID)
        {
            return objEbook.BankIn_UserSettings(vUserID);
        }


        public DataSet BankIn_GetBookDetails_ByBooksID(int vUserID, String vBookIdsString, String vTranID)
        {
            return objEbook.BankIn_GetBookDetails_ByBooksID(vUserID, vBookIdsString, vTranID); 
        }


        public DataSet Bank_Client_GetBankIns_ByTranID(String vUID, String vTranID)
        {
            return objEbook.Bank_Client_GetBankIns_ByTranID(vUID, vTranID); 
        }

        #endregion


        public int SMSPay_Bank_Add(int vIdentifier, String vBankActNo, String vBankName, String vBankAddress, String vIC, int vBankCountry)
        {
            return objEbook.SMSPay_Bank_Add(vIdentifier, vBankActNo, vBankName, vBankAddress, vIC, vBankCountry); 
        }

    }
}
