using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMSv3.BAL
{
    public class MalaysiaSMS
    {

        CMSv3.DAL.MalaysiaSMS obj1Malaysia = new CMSv3.DAL.MalaysiaSMS();

        public DataSet Get_1MalaysiaUser_AccountDetails(string vMobileNo)
        {
            return obj1Malaysia.Get_1MalaysiaUser_AccountDetails(vMobileNo); 
        }

        public DataSet Get_1MalaysiaUser_SMSBalanceDetails(string vMerchantID)
        {

            return obj1Malaysia.Get_1MalaysiaUser_SMSBalanceDetails(vMerchantID); 
        }

        public string ValidateUserLoing_1MAS_1Sing(string vLoginID, string vPassword)
        {
            return obj1Malaysia.ValidateUserLoing_1MAS_1Sing(vLoginID,vPassword); 
        }

        public string ValidateLogin_WebEmailSMS(string vLoginID, string vPassword)
        {
            return obj1Malaysia.ValidateLogin_WebEmailSMS(vLoginID, vPassword); 
        }

        public DataSet ValidateUserLoing_1MAS_1Sing_ByMobileLoginID(string vMobileLoginID)
        {
            return obj1Malaysia.ValidateUserLoing_1MAS_1Sing_ByMobileLoginID(vMobileLoginID); 
        }

        //public int SubDomain_Reg_atMLMSMS(CMSv3.Entities.webDomain vObjDomain, string vICNO, bool vChkAgreement)
        //{
        //    return obj1Malaysia.SubDomain_Reg_atMLMSMS(vObjDomain, vICNO, vChkAgreement); 
        //}


        public string RetreiveMID_ByMobileLoginID(string vMobileLoginID)
        {

            return RetreiveMID_ByMobileLoginID(vMobileLoginID); 
        }

        public DataSet Get_1MasUser_Details(string vMobileLoginID)
        {
            return obj1Malaysia.Get_1MasUser_Details(vMobileLoginID); 
        }

        public DataSet Get_1MasUser_EMSDetails(string vSearchQuery)
        {
            return obj1Malaysia.Get_1MasUser_EMSDetails(vSearchQuery); 
        }

        public int Check_EMS_Purchase(string vMobileLoginID)
        {
            return obj1Malaysia.Check_EMS_Purchase(vMobileLoginID); 
        }

        public int CheckSME_UserID(string vUserID)
        {
            return obj1Malaysia.CheckSME_UserID(vUserID); 
        }

        public int CheckSME_PinNumber(string vPinNumber)
        {
            return obj1Malaysia.CheckSME_PinNumber(vPinNumber); 
        }

        public int CheckPS_PinNumber(string vPinNumber)
        {
            return obj1Malaysia.CheckPS_PinNumber(vPinNumber); 
        }

        public int Update_EMS_Creation(long vMobileLoginID)
        {
            return obj1Malaysia.Update_EMS_Creation(vMobileLoginID); 
        }

        public int PS_CheckUseridPin_Status(string vUserID, string vPinNumber)
        {
            return obj1Malaysia.PS_CheckUseridPin_Status(vUserID, vPinNumber); 
        }

        public DataSet ShowHide_DomainButton(String vMobileLoginID)
        {
            return obj1Malaysia.ShowHide_DomainButton(vMobileLoginID);
        }

        public DataSet EMS_GetPlatinumUsers(string vSearchQuery)
        {
            return obj1Malaysia.EMS_GetPlatinumUsers(vSearchQuery);
        }

        public DataSet ValidateLoginStatus(string vLoginID, string vPassword, String vType)
        {
            return obj1Malaysia.ValidateLoginStatus(vLoginID, vPassword, vType); 
        }

        public int Insert_SEKEmailInfo(String vMID, String vParam, String vMailType, String vCatID, String iSuccess, String iFailure, String vMessage, String vSubject, String vBodyHTML, String vAttachment, String vEmailAddressList)
        {
            return obj1Malaysia.Insert_SEKEmailInfo(vMID, vParam, vMailType, vCatID, iSuccess, iFailure, vMessage, vSubject, vBodyHTML, vAttachment, vEmailAddressList);
        }

        public DataSet Retrieve_EbookRequestListings(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return obj1Malaysia.Retrieve_EbookRequestListings(vMID, vPageNo, vPageSize, vSearchSQL);
        }

        public DataSet Retrieve_AccountDetails(String vMID)
        {
            return obj1Malaysia.Retrieve_AccountDetails(vMID);
        }

        public int Send_MessageUpdated(String vMID, String vCategory, String vMobileList, String vPrefix, String vPersonalize, String vMessage, String vMessageType, String vSender, String @vSchedule, String vDeductSMSCdt, String vCreditType, String vMsgCHN, String vReportName)
        {
            return obj1Malaysia.Send_MessageUpdated(vMID, vCategory, vMobileList, vPrefix, vPersonalize, vMessage, vMessageType, vSender, vSchedule, vDeductSMSCdt, vCreditType, vMsgCHN, vReportName);
        }

        public DataSet Retrieve_DayLightTimeZoneInfo(String vMID)
        {
            return obj1Malaysia.Retrieve_DayLightTimeZoneInfo(vMID);
        }
        public DataSet Retrieve_ProfitShare(String vMID, String vStatus, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return obj1Malaysia.Retrieve_ProfitShare(vMID, vStatus, vPageNo, vPageSize, vSearchSQL);
        }
        public DataSet Retrieve_PaymentRequest(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return obj1Malaysia.Retrieve_PaymentRequest(vMID, vPageNo, vPageSize, vSearchSQL);
        }

        public DataSet Retrieve_EbookFreeRequestListings(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return obj1Malaysia.Retrieve_EbookFreeRequestListings(vMID, vPageNo, vPageSize, vSearchSQL);
        }

        public DataSet Retrieve_CurrentProfitShare(String vMID, String vMonth, String vYear)
        {
            return obj1Malaysia.Retrieve_CurrentProfitShare(vMID, vMonth, vYear);
        }

        public DataSet Retrieve_1WayReport(String vMID, String vPageNo, String vPageSize, String vTimeDiff, String vSearchSQL)
        {
            return obj1Malaysia.Retrieve_1WayReport(vMID, vPageNo, vPageSize, vTimeDiff, vSearchSQL);
        }

        public DataSet Retrieve_1WayReport_Specific(String vHistID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return obj1Malaysia.Retrieve_1WayReport_Specific(vHistID, vPageNo, vPageSize, vSearchSQL);
        }

        public DataSet Retrieve_2WayReport(String vMID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return obj1Malaysia.Retrieve_2WayReport(vMID, vPageNo, vPageSize, vSearchSQL);
        }

        public DataSet Retrieve_2WayReport_Specific(String vHistID)
        {
            return obj1Malaysia.Retrieve_2WayReport_Specific(vHistID);
        }

        public DataSet Retrieve_NewsInfo(int vTopNews)
        {
            return obj1Malaysia.Retrieve_NewsInfo(vTopNews);
        }

        public DataSet Retrieve_CreditCardCharges()
        {
            return obj1Malaysia.Retrieve_CreditCardCharges();
        }

        public DataSet Retrieve_SMSHistory(String vMID, String vSearchSQL, String vPageNo)
        {
            return obj1Malaysia.Retrieve_SMSHistory(vMID, vSearchSQL, vPageNo);
        }

        public DataSet Retrieve_GSPayPalHistory(String vUType, String vMID, String vSearchSQL)
        {
            return obj1Malaysia.Retrieve_GSPayPalHistory(vUType, vMID, vSearchSQL);
        }

        public DataSet Validate_HitechSMS_EBOOK(String vMID)
        {
            return obj1Malaysia.Validate_HitechSMS_EBOOK(vMID); 
        }

        public DataSet Validate_PaymentRequest(String vMID)
        {
            return obj1Malaysia.Validate_PaymentRequest(vMID);
        }
        public int Insert_PaymentRequest(String vMID, String vReqAmt)
        {
            return obj1Malaysia.Insert_PaymentRequest(vMID, vReqAmt);
        }

        public DataSet Validate_1WayReport_Specific(String vHistID, String vPageNo, String vPageSize, String vSearchSQL)
        {
            return obj1Malaysia.Validate_1WayReport_Specific(vHistID, vPageNo, vPageSize, vSearchSQL);
        }

        public int Insert_EbookEmailMarketing(String vMID, String vParam, String vMailType, String vCatID, String iSuccess, String iFailure, String vMessage, String vSubject, String vBodyHTML, String vAttachment, String vEmailAddressList)
        {
            return obj1Malaysia.Insert_EbookEmailMarketing(vMID, vParam, vMailType, vCatID, iSuccess, iFailure, vMessage, vSubject, vBodyHTML, vAttachment, vEmailAddressList);
        }

    }
}
