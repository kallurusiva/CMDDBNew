using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace CMSv3.BAL
{
    public class PremiumSMS
    {

        CMSv3.DAL.PremiumSMS objDAL_PremiumSMS = new CMSv3.DAL.PremiumSMS();


        public DataSet Retrieve_PS_Keyword(string vMobile, string vSearchSql)
        {
            return objDAL_PremiumSMS.Retrieve_PS_Keyword(vMobile, vSearchSql); 
        }

        public DataSet Retrieve_PS_ByKeywordScode(string vKeyword, string vShortcode)
        {
            return objDAL_PremiumSMS.Retrieve_PS_ByKeywordScode(vKeyword, vShortcode);
        }


        public DataSet Retrieve_PS_ByOperator(string vMonth, string vYear, string vKeyword, string vShortcode)
        {
            return objDAL_PremiumSMS.Retrieve_PS_ByOperator(vMonth, vYear, vKeyword, vShortcode); 
        }


        public DataSet Retrieve_PS_Monthly(string vMobile)
        {
            return objDAL_PremiumSMS.Retrieve_PS_Monthly(vMobile); 
        }


        public DataSet Retrieve_PS_MonthlyDetails(string vMobile, String vKeyword, String vShortCode, int vMonth, int vYear)
        {
            return objDAL_PremiumSMS.Retrieve_PS_MonthlyDetails(vMobile, vKeyword, vShortCode, vMonth, vYear); 
        }

        public DataSet Retrieve_PS_PurchasesMy(string vMobile)
        {
            return objDAL_PremiumSMS.Retrieve_PS_PurchasesMy(vMobile); 
        }

        public DataSet Retrieve_PS_KeywordsList(string vMobile)
        {
            return objDAL_PremiumSMS.Retrieve_PS_KeywordsList(vMobile); 
        }

        public DataSet Retrieve_PS_PurchasesALL(string vMobile)
        {
            return objDAL_PremiumSMS.Retrieve_PS_PurchasesALL(vMobile); 
        }

        public DataSet Retrieve_PS_GetUserDetails(string vMobile)
        {
            return objDAL_PremiumSMS.Retrieve_PS_GetUserDetails(vMobile); 
        }

        public DataSet Retrieve_PS_ShowPremiumInfo()
        {
            return objDAL_PremiumSMS.Retrieve_PS_ShowPremiumInfo(); 
        }

        public DataSet Retrieve_PS_ShowFAQList()
        {
            return objDAL_PremiumSMS.Retrieve_PS_ShowFAQList(); 
        }

        public DataSet Retrieve_PS_ShowNewsList(string vSearchSql)
        {
            return objDAL_PremiumSMS.Retrieve_PS_ShowNewsList(vSearchSql); 
        }

        public int Retrieve_PS_CheckAccess(string vMobile)
        {
            return objDAL_PremiumSMS.Retrieve_PS_CheckAccess(vMobile); 
        }


    }
}
