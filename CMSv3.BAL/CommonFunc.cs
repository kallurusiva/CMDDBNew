using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;

namespace CMSv3.BAL
{
    public class CommonFunc
    {
        CMSv3.DAL.CommonFunc objDAL_CommonFunc = new CMSv3.DAL.CommonFunc();

        public DataSet GetCountryList()
        {
            return objDAL_CommonFunc.GetCountryList();
        }


        public int ChangePriorityOrder(string TableName, string ColName, string IXname, string CurrPriority, string CurrID, string PrevPriority, string PrevID, string vUserID)
        {
            return objDAL_CommonFunc.ChangePriorityOrder(TableName, ColName, IXname, CurrPriority, CurrID, PrevPriority, PrevID, vUserID);
        }

        public bool InsertUpdate_ShowAdminItems(string TableName, string ItemIDs, int ForUserID)
        {
            return objDAL_CommonFunc.InsertUpdate_ShowAdminItems(TableName, ItemIDs, ForUserID);
        }

        public bool InsertUpdate_AboutUsPage(string vDescription, int vUserID, int vLanguage, bool vActive)
        {
            return objDAL_CommonFunc.InsertUpdate_AboutUsPage(vDescription, vUserID, vLanguage, vActive);
        }

        public bool Update_DomainNameRegistration(string vDomainName, int vUserId)
        {
            return objDAL_CommonFunc.Update_DomainNameRegistration(vDomainName, vUserId);
        }

        public bool Update_DomainRequestStatus(string vDomainName, int vUserId, int vApproveReject, int vReqID)
        {
            return objDAL_CommonFunc.Update_DomainRequestStatus(vDomainName, vUserId, vApproveReject, vReqID);
        }
    }
}
