using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMSv3.DAL;
using System.Data;

namespace CMSv3.BAL
{
     
    

    public class OwnButton
    {
        CMSv3.DAL.OwnButton objDAL_OwnButton = new CMSv3.DAL.OwnButton();


        public int Insert_OwnButtonData(string vLinkName, string vContent, int vUserID, bool vActive, int vSelLanguage, int vButtonNo)
        {
            return objDAL_OwnButton.Insert_OwnButtonData(vLinkName, vContent, vUserID, vActive, vSelLanguage,vButtonNo);
        }

        public bool Update_OwnButtonData(string vLinkName, string vContent, int vUserID, bool vActive, int vSelLanguage, int vButtonNo)
        {

            return objDAL_OwnButton.Update_OwnButtonData(vLinkName, vContent, vUserID, vActive, vSelLanguage, vButtonNo);
        }

        public DataSet Retrieve_ButtonInfoBYSA(int vUserID, int vButtonNo)
        {
            return objDAL_OwnButton.Retrieve_ButtonInfoBYSA(vUserID, vButtonNo); 

        }

        public int Delete_DefWebButtonsBYSA(int vButtonUID)
        {
            return objDAL_OwnButton.Delete_DefWebButtonsBYSA(vButtonUID); 

        }
        public DataSet Retrieve_DefWebButtonsBYSA(string vSearchTxt, int vButtonType)
        {
            return objDAL_OwnButton.Retrieve_DefWebButtonsBYSA(vSearchTxt, vButtonType); 
        }

        public DataSet Retrieve_DefWebButtonInfoBYSA(int vButtonNo, int vAnchorDomainID, int vButtonType)
        {
            return objDAL_OwnButton.Retrieve_DefWebButtonInfoBYSA(vButtonNo, vAnchorDomainID,vButtonType); 
        }

        public int Insert_DefWebButtonBySA(int vButtonNo, string vButtonName, string vContent, int vAnchorDomainID, int vButtonType)
        {
            return objDAL_OwnButton.Insert_DefWebButtonBySA(vButtonNo, vButtonName, vContent, vAnchorDomainID,vButtonType); 
        }


        public DataSet Retrieve_DefWebButtonsByAnchorDomainID(int vAnchorDomainID, int vButtonType)
        {
            return objDAL_OwnButton.Retrieve_DefWebButtonsByAnchorDomainID(vAnchorDomainID,vButtonType); 
        }

        public DataSet Retrieve_ExtraButtonInfoBYSA()
        {
            return objDAL_OwnButton.Retrieve_ExtraButtonInfoBYSA(); 

        }

        public int Insert_ExtraButtonBySA(string vButtonName, string vContent, bool vActive, int vButtonType, int vGadsPosition)
        {
            return objDAL_OwnButton.Insert_ExtraButtonBySA(vButtonName, vContent, vActive, vButtonType, vGadsPosition); 
        }
    }
}
