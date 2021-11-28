using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;

namespace CMSv3.BAL
{
    public class News
    {

        CMSv3.DAL.News objDAL_News = new CMSv3.DAL.News();

        public int InsertNewsData(string vNewsTitle, string vNewsContent, bool vNewsDisplay, int vUserId, int mSelLanguage)
        {
            return objDAL_News.InsertNewsData(vNewsTitle, vNewsContent, vNewsDisplay, vUserId, mSelLanguage);
            
        }

        public DataSet Retrieve_AllNewsByUserID(int mUserId, string mRetreiveType, int mSelLanguage)
        {
            return objDAL_News.Retrieve_AllNewsByUserID(mUserId, mRetreiveType, mSelLanguage);
        }

        public bool UpdateNewsData(string vTitle, string vContent, int vUserID, int vNewsID, bool vActive, int mSelLanguage)
        {
            return objDAL_News.UpdateNewsData(vTitle, vContent, vUserID, vNewsID, vActive, mSelLanguage);
        }

        public bool DeleteNewsData(int vUserId, int vNewsID)
        {
            return objDAL_News.DeleteNewsData(vUserId, vNewsID);
        }

        public bool DeleteNewsData_Multiple(int vUserId, string vNewsIDs)
        {
            return objDAL_News.DeleteNewsData_Multiple(vUserId, vNewsIDs);
        }


        public DataSet User_GETAll_News_ByUserID(int mUserId)
        {
            return objDAL_News.User_GETAll_News_ByUserID(mUserId);
        }

        public bool Update_SystemNewsData(CMSv3.Entities.News vobjNews, bool vActive, int mSelLanguage)
        {
            return objDAL_News.Update_SystemNewsData(vobjNews, vActive, mSelLanguage);
        }
    }
}
