using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using CMSv3.DAL;
using CMSv3.Entities;

/// <summary>
/// Summary description for MasFunc
/// </summary>
public class MasFunc
{
   


    


    public MasFunc()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static void Get_1MalaysiaUser_Details(string vMobileLogin,ref CMSv3.Entities.MasUser objMasUser)
    {

       
        CMSv3.BAL.MalaysiaSMS objMalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
        //CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser(); 
    
        //Login_ID,[Password],MID,Acc_Type as AccountType,Member_Name,Phone,Email  
       
       // CMSv3.BAL.MalaysiaSMS objMalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();

        DataSet ds = objMalaysiaSMS.Get_1MalaysiaUser_AccountDetails(vMobileLogin);
  
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {

            DataRow dr = dt.Rows[0];

            objMasUser.AccountType = dr["AccountType"].ToString();
            objMasUser.MID = dr["MID"].ToString();
            objMasUser.LoginID = dr["Login_ID"].ToString();
            objMasUser.Password = dr["Password"].ToString();
            objMasUser.MemberName = dr["Member_Name"].ToString();
            objMasUser.Phone = dr["Phone"].ToString();
            objMasUser.Email = dr["Email"].ToString();
            objMasUser.Company = dr["Company"].ToString(); 
            
            
            //objMasUser.SMSBalance = dr["MID"].ToString();

            DataSet dsCreditBal = objMalaysiaSMS.Get_1MalaysiaUser_SMSBalanceDetails(objMasUser.MID);
            DataTable dtCreditBal = dsCreditBal.Tables[0];

            if (dtCreditBal.Rows.Count > 0)
            {
                DataRow drCredit = dtCreditBal.Rows[0];


                objMasUser.SMSBalance = Convert.ToDouble(drCredit["BalanceCredit"].ToString());

            }
            dsCreditBal.Dispose();

        }

        ds.Dispose(); 





    }
}
