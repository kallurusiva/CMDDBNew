using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;

namespace CMSv3.BAL
{
    public class Gallery
    {

        CMSv3.DAL.Gallery objGallery = new CMSv3.DAL.Gallery();


        public DataSet Retrieve_GImagesByImageID(int vImageID)
        {
            return objGallery.Retrieve_GImagesByImageID(vImageID); 
        }

        public DataSet Retrieve_GImagesByvideoID(int videoID)
        {
            return objGallery.Retrieve_GImagesByvideoID(videoID); 
        }


        public DataSet RetrieveAll_GImagesByCategory(int vCategoryID, int vPageNo, int vItemsPerPage, String vCalledFrom)
        {
            return objGallery.RetrieveAll_GImagesByCategory(vCategoryID, vPageNo, vItemsPerPage, vCalledFrom); 
        }

        public int Save_VideoLinkInfo(string vVideoLink, string vVideoTitle, int vCategoryID)
        {
            return objGallery.Save_VideoLinkInfo(vVideoLink, vVideoTitle, vCategoryID); 
        }

        public int Update_VideoLinkInfo(int VideoID, string vVideoLink, string vVideoTitle, int vCategoryID, bool vActive)
        {
            return objGallery.Update_VideoLinkInfo(VideoID, vVideoLink, vVideoTitle, vCategoryID, vActive); 
        }

        public DataSet RetrieveAll_GIVideosByCategory(int vCategoryID, int vPageNo, int vItemsPerPage, string vCalledFrom)
        {
            return objGallery.RetrieveAll_GIVideosByCategory(vCategoryID, vPageNo, vItemsPerPage, vCalledFrom); 
        }

        public int DeleteGiImage(int vImageID)
        {
            return objGallery.DeleteGiImage(vImageID); 
        }

        public int DeleteGiVideo(int vVideoID)
        {
            return objGallery.DeleteGiVideo(vVideoID); 
        }

        public int Update_GalleryImageByID(CMSv3.Entities.ObjectImage objImage, bool vActive)
        {
            return objGallery.Update_GalleryImageByID(objImage, vActive); 
        }

        public int UpLoad_AnchorImages(CMSv3.Entities.ObjectImage objImage, int vUserID, int vCategoryID)
        {
            return objGallery.UpLoad_AnchorImages(objImage, vUserID, vCategoryID); 
        }

        public int Update_GalleryImageSettings(CMSv3.Entities.ObjectImage objImage, int vUserID)
        {
            return objGallery.Update_GalleryImageSettings(objImage, vUserID);

        }
    }
}
