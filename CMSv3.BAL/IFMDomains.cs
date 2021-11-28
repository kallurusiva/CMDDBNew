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
    public class IFMDomains
    {

        CMSv3.DAL.IFMDomains objDomains = new CMSv3.DAL.IFMDomains(); 


        public DataSet Retrieve_AnchorDomains(string vSearchQuery)
        {

            return objDomains.Retrieve_AnchorDomains(vSearchQuery); 

        }

        public DataSet Retrieve_AncDomainCategories(string vSearchQuery)
        {

            return objDomains.Retrieve_AncDomainCategories(vSearchQuery); 
        }

        public int Insert_AncDomainCategory(string vCategoryName)
        {
            return objDomains.Insert_AncDomainCategory(vCategoryName); 
        }

        public int Update_AncDomainCategory(string vCategoryName, int vCategoryId)
        {
            return objDomains.Update_AncDomainCategory(vCategoryName, vCategoryId); 
        }

        public int Delete_AncDomainCategory(int vCategoryId)
        {

            return objDomains.Delete_AncDomainCategory(vCategoryId); 
        }


        public int Update_AnchorDomains(int vAnchorID, string vAnchorDomain, int vCategoryId, string vSampleURL, bool vActive)
        {
            return objDomains.Update_AnchorDomains(vAnchorID, vAnchorDomain, vCategoryId, vSampleURL, vActive); 
        }

        public int Delete_AnchorDomains(int vAnchorID)
        {
            return objDomains.Delete_AnchorDomains(vAnchorID); 
        }

        public int Insert_AnchorDomains(string vAnchorDomain, string vSampleURL, int vCategoryID, bool vActive)
        {
            return objDomains.Insert_AnchorDomains(vAnchorDomain, vSampleURL, vCategoryID, vActive); 
        }


        public DataSet Retrieve_CreditCardPurchaseInfo(String vCurrencyCode, String vProductName, String vMobileNo)
        {
            return objDomains.Retrieve_CreditCardPurchaseInfo(vCurrencyCode, vProductName, vMobileNo);
        }
        public DataSet Retrieve_PayPalHistory(String vPayPalID)
        {
            return objDomains.Retrieve_PayPalHistory(vPayPalID);
        }


        public String GetRefMobileNumber(String vUserName)
        {
            return objDomains.GetRefMobileNumber(vUserName); 
        }


    }
}
