using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;

namespace CMSv3.BAL
{
    public class AdminSettings
    {

        CMSv3.DAL.AdminSettings ObjDAL_AdminSettings = new CMSv3.DAL.AdminSettings();

        public DataSet GetAll_TopmenuLinks()
        {
            return ObjDAL_AdminSettings.GetAll_TopmenuLinks();
        }

        public DataSet GetAll_CommApps()
        {
            return ObjDAL_AdminSettings.GetAll_CommApps();
        }

        public int Insert_AdminSettings(CMSv3.Entities.AdminSettings vObjAdminSettings)
        {
            return ObjDAL_AdminSettings.Insert_AdminSettings(vObjAdminSettings);
        }


        public int Insert_MainMenuLInks(string vMenuLinkName, string vMenuLinkURL, int vUserId)
        {
            return ObjDAL_AdminSettings.Insert_MainMenuLInks(vMenuLinkName, vMenuLinkURL, vUserId);
        }

        public int IsExists_MainMenuLink(string vMenuLinkName, int vUserId)
        {
            return ObjDAL_AdminSettings.IsExists_MainMenuLink(vMenuLinkName, vUserId);
        }

        public int Insert_WEB_ErrorLog(string vURL, string vSource, string vMessage, string vStackTrace, string vBaseException)
        {
            return ObjDAL_AdminSettings.Insert_WEB_ErrorLog(vURL, vSource, vMessage, vStackTrace, vBaseException);
        }

        public DataSet GetSummary_ByTable(int vUserID, string vTable, string vColumn)
        {
            return ObjDAL_AdminSettings.GetSummary_ByTable(vUserID, vTable, vColumn);
        }


    }
}
