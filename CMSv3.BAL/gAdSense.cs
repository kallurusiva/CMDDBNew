using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace CMSv3.BAL
{
    public class gAdSense
    {

        CMSv3.DAL.gAdSense objDAL_gAdSense = new CMSv3.DAL.gAdSense();


        public int InsertUpdate_AdSenseContent(string vAdSenseID, string vAdSensePwd, string vAdsCode, int vUserID)
        {
            return objDAL_gAdSense.InsertUpdate_AdSenseContent(vAdSenseID, vAdSensePwd, vAdsCode, vUserID); 
        }


        public bool Update_AdSenseContent(string vAdSenseID, string vAdSensePwd, string vAdsCode, int vUserID)
        {
            return objDAL_gAdSense.Update_AdSenseContent(vAdSenseID, vAdSensePwd, vAdsCode, vUserID); 
        }


        public DataSet Retrieve_AdSenseContent(int vUserID, string vSearchStr)
        {
            return objDAL_gAdSense.Retrieve_AdSenseContent(vUserID, vSearchStr); 
        }

        public int Delete_AdSenseContent(int vAdSenseID)
        {
            return objDAL_gAdSense.Delete_AdSenseContent(vAdSenseID); 
        }



    }
}
