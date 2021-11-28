using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;

namespace CMSv3.BAL
{

    public class Events
    {
        CMSv3.DAL.Events objDAL_Events = new CMSv3.DAL.Events();


        public int InsertEventData(CMSv3.Entities.Events objEvents, bool vActive, int vSelLanguage)
        {
            return objDAL_Events.InsertEventData(objEvents, vActive, vSelLanguage);
        }


        public DataSet RetrieveAllEvents_ByUserID(int vUserId, string mRetreiveType, int mSelectLanguage)
        {
            return objDAL_Events.RetrieveAllEvents_ByUserID(vUserId, mRetreiveType, mSelectLanguage);
        }

        public bool UpdateEventsData(CMSv3.Entities.Events objEvt, bool vActive, int vSelLanguage)
        {
            return objDAL_Events.UpdateEventsData(objEvt,vActive, vSelLanguage);
        }

        public bool DeleteEventsData(int vUserId, int vEventID)
        {
            return objDAL_Events.DeleteEventsData(vUserId, vEventID);
        }

        public bool DeleteEventsData_Multiple(int vUserId, string vEventIdsStr)
        {
            return objDAL_Events.DeleteEventsData_Multiple(vUserId, vEventIdsStr);
        }


        public DataSet User_GETAll_Events_ByUserID(int mUserId)
        {
            return objDAL_Events.User_GETAll_Events_ByUserID(mUserId);
        }



    }
}
