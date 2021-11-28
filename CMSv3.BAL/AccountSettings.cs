using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;

namespace CMSv3.BAL
{
    public class AccountSettings
    {
        CMSv3.DAL.AccountSettings objDAL_ActSettings = new CMSv3.DAL.AccountSettings();

        public DataSet RetrieveALL_Settings_HomePageData(int vUserId)
        {
            return objDAL_ActSettings.RetrieveALL_Settings_HomePageData(vUserId);
        }

        public int InsertUpdate_Settings_HomePageData(CMSv3.Entities.UserDetails objUser, CMSv3.Entities.CommApps objCommApps, CMSv3.Entities.MyImage objImage)
        {
            return objDAL_ActSettings.InsertUpdate_Settings_HomePageData(objUser, objCommApps, objImage);
        }


        public DataSet RetrieveALL_Settings_HomePage_Defaults(int vUserId)
        {
            return objDAL_ActSettings.RetrieveALL_Settings_HomePage_Defaults(vUserId);
        }

        public int Update_Settings_HomePageDefaults(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {
            return objDAL_ActSettings.Update_Settings_HomePageDefaults(objUser, vUserID);
        }


        public int Update_Settings_HomePageDefaults22(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {
            return objDAL_ActSettings.Update_Settings_HomePageDefaults22(objUser, vUserID);
        }

        public int Update_WebSettings(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {
            return objDAL_ActSettings.Update_WebSettings(objUser, vUserID); 
        }

        public int Update_LogoSettings(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {
            return objDAL_ActSettings.Update_LogoSettings(objUser, vUserID); 

        }

        public int Update_AnchorImageSettings(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {
            return objDAL_ActSettings.Update_AnchorImageSettings(objUser, vUserID);

        }


        public int Settings_DeleteUserImage(int vImageID)
        {
            return objDAL_ActSettings.Settings_DeleteUserImage(vImageID);
        }

        public int DeleteAnchorImage(int vImageID)
        {
            return objDAL_ActSettings.DeleteAnchorImage(vImageID); 
        }

        public int Upload_BannerLogo_BySA(CMSv3.Entities.AdminSettings objUser, int vUserID,int vCategoryID)
        {
            return objDAL_ActSettings.Upload_BannerLogo_BySA(objUser, vUserID,vCategoryID);
        }

        public DataSet Retrieve_Banners(int vUserID, string vCalledBy)
        {
            return objDAL_ActSettings.Retrieve_Banners(vUserID, vCalledBy);
        }

        public DataSet Retrieve_Banners_ByIndustry(int vUserID, string vCategoryID, string vCalledBy)
        {
            return objDAL_ActSettings.Retrieve_Banners_ByIndustry(vUserID, vCategoryID, vCalledBy); 
        }
        public DataSet Retrieve_AnchorImages(int vUserID)
        {
            return objDAL_ActSettings.Retrieve_AnchorImages(vUserID); 
        }

        public DataSet Retrieve_Settings_TopRowLinks(int vUserId)
        {
            return objDAL_ActSettings.Retrieve_Settings_TopRowLinks(vUserId);
        }

        public int Save_NewBanner(CMSv3.Entities.AdminSettings objUser, int vUserID, int vCategoryID, bool vActive)
        {
            return objDAL_ActSettings.Save_NewBanner(objUser, vUserID, vCategoryID, vActive); 
        }

        public int Save_NewLogo(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {
            return objDAL_ActSettings.Save_NewLogo(objUser, vUserID); 
        }


        public DataSet WP_Retrieve_Images(int vUserID, string vWpImageType, string vCalledBy)
        {

            return objDAL_ActSettings.WP_Retrieve_Images(vUserID, vWpImageType, vCalledBy); 
        }

        public DataSet WP_Retrieve_Images_ByIndustry(int vUserID, string vCategoryID, string vWpImageType, string vCalledBy)
        {
            return objDAL_ActSettings.WP_Retrieve_Images_ByIndustry(vUserID, vCategoryID, vWpImageType, vCalledBy); 
        }

        public int WP_Save_Images(CMSv3.Entities.AdminSettings objImageUser, int vUserID, int vCategoryID, string vWpImageType)
        {
            return objDAL_ActSettings.WP_Save_Images(objImageUser, vUserID, vCategoryID, vWpImageType); 
        }


    }
}
