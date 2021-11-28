using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMSv3.BAL
{
    public class GemailSystem
    {
        CMSv3.DAL.GemailSystem objDAL_Gems = new CMSv3.DAL.GemailSystem();


        public DataSet Retrieve_EMSContent(string vSearchStr)
        {
            return objDAL_Gems.Retrieve_EMSContent(vSearchStr); 
        }

        public int InsertUpdate_EMSContent(string vAdminID, string vAdminPwd, string vEnquiryID, string vEnquiryPwd, string vHttpUrlLink, long vMobileLoginID)
        {
            return objDAL_Gems.InsertUpdate_EMSContent(vAdminID, vAdminPwd, vEnquiryID, vEnquiryPwd, vHttpUrlLink, vMobileLoginID); 
        }

        public int Check_EMS_Exists(string vMobileLoginID)
        {
            return objDAL_Gems.Check_EMS_Exists(vMobileLoginID); 
        }

    }
}
