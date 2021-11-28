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
    
    public class MbMain
    {
     

        CMSv3.DAL.MbMain objMbMain = new CMSv3.DAL.MbMain();

        public DataSet RetrieveAll_MobiPageContent(int vUserId)
        {
            return objMbMain.RetrieveAll_MobiPageContent(vUserId); 
        }

        public DataSet RetrieveAll_MobiButtonsInfo()
        {
            return objMbMain.RetrieveAll_MobiButtonsInfo(); 
        }

        public DataSet Retrieve_SelectedButtonsByUserID(int vUserId)
        {
            return objMbMain.Retrieve_SelectedButtonsByUserID(vUserId); 

        }


        public int UpdateButtonSelection(int vUserId, string SelitemString, string vTitle1, string vTitle2, int vTemplateID, bool vMwDetection)
        {
            return objMbMain.UpdateButtonSelection(vUserId, SelitemString, vTitle1, vTitle2, vTemplateID, vMwDetection); 
        }

        public DataSet Retrieve_SelectedTemplate(int vUserId)
        {
            return objMbMain.Retrieve_SelectedTemplate(vUserId); 
        }

        public int UpdateTemplateSelection(int vUserId, string vTemplateCSS, string vTitle1, string vTitle2)
        {
            return objMbMain.UpdateTemplateSelection(vUserId, vTemplateCSS,vTitle1,vTitle2); 
        }

        public DataSet Retrieve_ALLTemplates()
        {
            return objMbMain.Retrieve_ALLTemplates(); 
        }

        public DataSet Retrieve_TrialPeriodInfo(int vUserID, DateTime vOLDtpStartDate)
        {
            return objMbMain.Retrieve_TrialPeriodInfo(vUserID,vOLDtpStartDate);
        }

        public int CheckMobileWebPurchase(string vMobileNo)
        {
            return objMbMain.CheckMobileWebPurchase(vMobileNo); 
        }

        public int CheckMobileWebAccess(string vMobileNo)
        {
            return objMbMain.CheckMobileWebAccess(vMobileNo); 
        }
    }
}
