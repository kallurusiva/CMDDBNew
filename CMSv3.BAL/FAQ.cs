using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;

namespace CMSv3.BAL
{
    public class FAQ
    {

        CMSv3.DAL.FAQ objDAL_Faq = new CMSv3.DAL.FAQ();

        public int InsertFaqData(string vFaqQuestion, string vFaqAnswer, int vUserId, bool vActive, int vSelLanguage)
        {
            return objDAL_Faq.InsertFaqData(vFaqQuestion, vFaqAnswer, vUserId, vActive, vSelLanguage);

        }

        public DataSet Retrieve_AllFaqByUserID(int mUserId, string RetreiveType, int vSelLanguage)
        {
            return objDAL_Faq.Retrieve_AllFaqByUserID(mUserId, RetreiveType, vSelLanguage);
        }

        public bool UpdateFaqData(string vQuestion, string vAnswer, int vUserID, int vFaqID, bool vActive, int vSelLanguage)
        {
            return objDAL_Faq.UpdateFaqData(vQuestion, vAnswer, vUserID, vFaqID, vActive, vSelLanguage);
        }

        public bool DeleteFaqData(int vUserId, int vFaqID)
        {
            return objDAL_Faq.DeleteFaqData(vUserId, vFaqID);
        }

        public bool DeleteFaqData_Multiple(int vUserId, string vFaqIDs)
        {
            return objDAL_Faq.DeleteFaqData_Multiple(vUserId, vFaqIDs);
        }

        public DataSet Retrieve_FaqSUmmary_ByUserID(int mUserId)
        {
            return objDAL_Faq.Retrieve_FaqSUmmary_ByUserID(mUserId);
        }

        #region User related functions 

        public DataSet User_GETAllFaq_ByUserID(int mUserId)
        {
            return objDAL_Faq.User_GETAllFaq_ByUserID(mUserId);
        }


        #endregion


    }
}
