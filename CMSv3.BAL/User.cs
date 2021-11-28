using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CMSv3.DAL;
using CMSv3.Entities;

namespace CMSv3.BAL
{
    public class User
    {

        CMSv3.DAL.User objUser = new CMSv3.DAL.User();

        public CMSv3.Entities.User GetUserDetailsByID(int vUserID)
        {
            objUser = new CMSv3.DAL.User();
            return objUser.GetUserDetailsByID(vUserID);
        }

        public bool CheckSubDomainExists(string vSubDomainName)
        {
            return objUser.CheckSubDomainExists(vSubDomainName);
        }

        public int CheckSubDomainExists_MobileLoginID(string vSubDomainName, string vMobileNumber)
        {
            return objUser.CheckSubDomainExists_MobileLoginID(vSubDomainName,vMobileNumber);
        }

        public int CheckUseridPinSbd_Status(string vUserID, string vPinNumber, string vSubDomainName)
        {
            return objUser.CheckUseridPinSbd_Status(vUserID, vPinNumber, vSubDomainName); 
        }

        public int InsertUpdate_SubDomain_Registration(CMSv3.Entities.webDomain vObjDomain)
        {
            return objUser.InsertUpdate_SubDomain_Registration(vObjDomain);
        }

        public int SubDomain_Reg_WithAnchorDomain(CMSv3.Entities.webDomain vObjDomain, int vAnchorDomainID)
        {
            return objUser.SubDomain_Reg_WithAnchorDomain(vObjDomain, vAnchorDomainID); 
        }

        public int SubDomain_Reg_WithAnchorDomain_SME(CMSv3.Entities.webDomain vObjDomain, int vAnchorDomainID, long vSMEGenMobile, string vSMEPinNumber)
        {
            return objUser.SubDomain_Reg_WithAnchorDomain_SME(vObjDomain, vAnchorDomainID, vSMEGenMobile, vSMEPinNumber); 
        }

        public int Update_SubDomain_ActivationDetails(int vUserId)
        {
            return objUser.Update_SubDomain_ActivationDetails(vUserId);
        }


        public int GetUserID_BySubDomainName(string vSubDomainName)
        {
            return objUser.GetUserID_BySubDomainName(vSubDomainName);
        }

        public int GetUserID_BySubDomainName2(string vSubDomainName, int vDomaintype)
        {
            return objUser.GetUserID_BySubDomainName2(vSubDomainName, vDomaintype);
        }

     
        public long GetMobileLoginID_ByDomainName(string vSubDomainName, int vDomainType)
        {
            return objUser.GetMobileLoginID_ByDomainName(vSubDomainName,vDomainType);
        }


        public int Update_User_LastLoginDetails(int vUserId)
        {
            return objUser.Update_User_LastLoginDetails(vUserId);
        }

        public DataSet Retrieve_AllUserData(string vSearchQuery, string vSortQuery)
        {
            return objUser.Retrieve_AllUserData(vSearchQuery, vSortQuery);
        }

        public DataSet Retrieve_AllUserData_byPage(string vSearchQuery, string vSortQuery, int vPageNo)
        {
            return objUser.Retrieve_AllUserData_byPage(vSearchQuery, vSortQuery, vPageNo); 
        }

        public int Update_User_Status(int vUserId, bool vStatus,string vOwnDomainName, string vSubDomainName)
        {
            return objUser.Update_User_Status(vUserId, vStatus, vOwnDomainName,vSubDomainName);
        }

        public int Update_AdminLanguage(int vLanguageCode, int vUserId)
        {
            return objUser.Update_AdminLanguage(vLanguageCode, vUserId); 
        }

        public DataSet Retrieve_AllUser_Summary()
        {
            return objUser.Retrieve_AllUser_Summary();
        }

        public DataSet CheckUser_LoginStatus(string vLoginID, string vPassword)
        {
            return objUser.CheckUser_LoginStatus(vLoginID, vPassword);
        }

        public DataSet CheckUser_MobileLoginID(string vLoginID, string vPassword)
        {
            return objUser.CheckUser_LoginStatus(vLoginID, vPassword);
        }

        public DataSet Get_UserDetails_ByDomainName(string vDomainName)
        {
            return objUser.Get_UserDetails_ByDomainName(vDomainName); 

        }
        public DataSet CheckUser_ValidateByMobileLogin(string vMobileLogin)
        {
            return objUser.CheckUser_ValidateByMobileLogin(vMobileLogin); 
        }

        public DataSet CheckSUbDomain_ValidateByMobile(string vMobileLogin)
        {
            return objUser.CheckSUbDomain_ValidateByMobile(vMobileLogin);
        }

        public int Check_SMEWEB_Purchase(string vMobileLoginID)
        {

            return objUser.Check_SMEWEB_Purchase(vMobileLoginID); 

        }

        public int Update_User_ExpiryDate(int vUserId, string vRenewBy, string vRenewalPinNo)
        {
            return objUser.Update_User_ExpiryDate(vUserId,vRenewBy,vRenewalPinNo);
        }


        public bool InsertUpdate_WelcomePage(string vDescription, int vUserID, int vLanguage, bool vActive)
        {
            return objUser.InsertUpdate_WelcomePage(vDescription, vUserID, vLanguage, vActive);
        }


        public DataSet WelcomePage_Details(int vUserID)
        {
            return objUser.WelcomePage_Details(vUserID);
        }

        public DataSet WelcomePage_QuickLinks(int vUserID)
        {
            return objUser.WelcomePage_QuickLinks(vUserID);
        }

        public DataSet HomePage_ContactUs_ByUserID(int vUserID)
        {
            return objUser.HomePage_ContactUs_ByUserID(vUserID); 
        }

        public DataSet EB_WebDesign2_GetSettings(int vUserID)
        {
            return objUser.EB_WebDesign2_GetSettings(vUserID); 
        }

        public int EB_WebDesign2_UpdateSettings(string vFBpageURL, string vWelcomePageText, String vPhotoGraph1, String vMasterPageName, String vMasterPageCSS, int vUserID)
        {
            return objUser.EB_WebDesign2_UpdateSettings(vFBpageURL, vWelcomePageText, vPhotoGraph1, vMasterPageName, vMasterPageCSS, vUserID); 
        }



        public DataSet EB_WebDesign3_GetSettings(int vUserID)
        {
            return objUser.EB_WebDesign3_GetSettings(vUserID);
        }

        public int EB_WebDesign3_UpdateSettings(string vFBpageURL, string vWelcomePageText, String vPhotoGraph1, String vMasterPageName, String vMasterPageCSS, int vUserID)
        {
            return objUser.EB_WebDesign3_UpdateSettings(vFBpageURL, vWelcomePageText, vPhotoGraph1, vMasterPageName, vMasterPageCSS, vUserID);
        }


        public DataSet GetSavedTemplateDetails(int vUserID)
        {
            return objUser.GetSavedTemplateDetails(vUserID); 
        }
    }
}
