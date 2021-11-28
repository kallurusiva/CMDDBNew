using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;

namespace CMSv3.BAL
{
    public class DPE
    {

        CMSv3.DAL.DPE objDAL_DPE = new CMSv3.DAL.DPE();



        public DataSet DPE_ValidateLoginStatus(string vMobileLoginID)
        {
            return objDAL_DPE.DPE_ValidateLoginStatus(vMobileLoginID); 
        }

        public DataSet DPE_GetDetails(string vMobileLoginID)
        {
            return objDAL_DPE.DPE_GetDetails(vMobileLoginID); 
        }

        public DataSet DPE_Retrieve_EMSContent(String vUserID, string vSearchStr)
        {
            return objDAL_DPE.DPE_Retrieve_EMSContent(vUserID, vSearchStr); 
        }

        public DataSet DPE_GetUserForEMS(string vSearchQuery)
        {
            return objDAL_DPE.DPE_GetUserForEMS(vSearchQuery); 
        }

        public int DPE_InsertUpdate_EMSContent(string vAdminID, string vAdminPwd, string vEnquiryID, string vEnquiryPwd, string vHttpUrlLink, long vMobileLoginID)
        {
            return objDAL_DPE.DPE_InsertUpdate_EMSContent(vAdminID, vAdminPwd, vEnquiryID, vEnquiryPwd, vHttpUrlLink, vMobileLoginID); 
        }
    }
}
