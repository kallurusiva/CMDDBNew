using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;

namespace CMSv3.BAL
{
    public class HomePage
    {
        
        CMSv3.DAL.HomePage objDAL_Homepg = new CMSv3.DAL.HomePage();

        public DataSet RetrieveAll_HomePageContent(int vUserId)
        {
            return objDAL_Homepg.RetrieveAll_HomePageContent(vUserId);
        }

        public DataSet RetrieveAll_TopMenuLinks(int vUserId)
        {
            return objDAL_Homepg.RetrieveAll_TopMenuLinks(vUserId);
        }

        public int Insert_TopMenuLinkItem(string vLinkName, string vLinkURL, bool vActive)
        {
            return objDAL_Homepg.Insert_TopMenuLinkItem(vLinkName, vLinkURL, vActive);
        }

        public int Insert_LanguageItem(string vLangCode, string vLangName)
        {
            return objDAL_Homepg.Insert_LanguageItem(vLangCode, vLangName);
        }

        public string GetMasterCSS(int vUserId)
        {
            return objDAL_Homepg.GetMasterCSS(vUserId);
        }

    }
}
