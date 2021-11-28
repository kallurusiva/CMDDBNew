using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;


namespace CMSv3.BAL
{

    public class Buyer
    {

        CMSv3.DAL.Buyer objBuyer = new CMSv3.DAL.Buyer(); 

        public DataSet Validate_UserLogin(String vLoginID, String vPwd)
        {
            return objBuyer.Validate_UserLogin(vLoginID, vPwd); 
        }


        public int ChangePassword_PreCheck(String vMobileLoginID, String vCurrPassword)
        {
            return objBuyer.ChangePassword_PreCheck(vMobileLoginID, vCurrPassword); 
        }

        public int ChangePassword(int vUserID, String vMobileLoginID, String vCurrPassword, String vNewPassword)
        {
            return objBuyer.ChangePassword(vUserID, vMobileLoginID, vCurrPassword, vNewPassword); 
        }
      

    }
}
