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

    public class MbOwnButtons
    {


        CMSv3.DAL.MbOwnButtons objMbOwnBtns = new CMSv3.DAL.MbOwnButtons();

        public DataSet Retrieve_OwnButtonContent(int vButtonNo, int vUserId)
        {
            return objMbOwnBtns.Retrieve_OwnButtonContent(vButtonNo, vUserId); 
        }

        public int Save_OwnButtonContent(int vUserBtnNo, int vUserId,  string vBtnName, string vBtnContent, int vBtnIconImgID, string vBtnVideoLink, CMSv3.Entities.AdminSettings objImageData)
        {
            return objMbOwnBtns.Save_OwnButtonContent(vUserBtnNo, vUserId,  vBtnName, vBtnContent, vBtnIconImgID, vBtnVideoLink, objImageData); 
        }

        public DataSet Retrieve_OwnButtonIcons(int vUserId)
        {
            return objMbOwnBtns.Retrieve_OwnButtonIcons(vUserId); 
        }

        public int Delete_UserIcon(int vImageID)
        {
            return objMbOwnBtns.Delete_UserIcon(vImageID); 
        }

        public int Delete_UserImage(int vUserId,int vButtonNo)
        {
            return objMbOwnBtns.Delete_UserImage(vUserId, vButtonNo);
        }

    }
}
