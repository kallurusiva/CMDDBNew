using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class SessionTimedOut_SmsLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnPreIODLogin_Click(object sender, EventArgs e)
    {
        //string mUserName = txtLoginID.Text;
        //string mPassword = txtPassword.Text;




        string mUserName = txtLoginID.Text;
        string mPassword = txtPassword.Text;

        string mReturnedMobileNo = string.Empty;


        String tmpUserPrefix = mUserName.Substring(0, 2);
        int UsrCountryCode = 0;

        if ((tmpUserPrefix == "60") || (tmpUserPrefix == "65") || (tmpUserPrefix == "62"))
        {
            UsrCountryCode = Convert.ToInt32(tmpUserPrefix);
        }
        else
        {
            //..Check if the Login is Valid in the SpecialLogin Table. 

            SqlConnection IFM_dbConn;
            SqlCommand IFM_dbCmd;


            IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);
            IFM_dbConn.Open();

            IFM_dbCmd = new SqlCommand("[USP_Verify_SpecialLoginNameCMS]", IFM_dbConn);
            IFM_dbCmd.CommandType = CommandType.StoredProcedure;
            IFM_dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = mUserName;
         

            //mReturnedMobileNo = (string)IFM_dbCmd.Parameters["@Result"].Value;

            mReturnedMobileNo = IFM_dbCmd.ExecuteScalar().ToString();

            if (mReturnedMobileNo == "00")
            {
                UsrCountryCode = 0;
            }
            else
            {
                UsrCountryCode = Convert.ToInt32(mReturnedMobileNo.Substring(0, 2));
                mUserName = mReturnedMobileNo;
            }
        }




        //Check if the user is from Malaysia or Singapore 

        //String tmpUser = mUserName.Substring(0, 2);
        if ((UsrCountryCode == 60) || (UsrCountryCode == 0))
        {

            string strURL = "http://64.78.18.147/SMSMLMNEW/Includes/1SmsWebsite_MAS_BizLoginCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E&LoginFrom=SMSLOGIN";
            //Page.SmartNavigation = false;
            Response.Redirect(strURL);

        }
        else if (UsrCountryCode == 65)
        {

            string strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E&LoginFrom=SMSLOGIN";
            //Page.SmartNavigation = false;
            Response.Redirect(strURL);


        }
        else if (UsrCountryCode == 62)
        {
            //http://64.78.18.147/SMSindonesia 
            string strURL = "http://64.78.18.147/smsIndonesia/Includes/1SMSwebsite_Indo_BizLoginCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E&LoginFrom=SMSLOGIN";
            //Page.SmartNavigation = false;
            Response.Redirect(strURL);

        }





    }

    protected Boolean ValidateLoginByDomain(string vUserID, string vPassword)
    {


        SqlConnection dbConn;
        //SqlCommand dbCmd;
        //SqlDataReader dbReader;
        //SqlDataAdapter dbAdap;
        DataSet dsCheck;
        string strSQL = string.Empty;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        bool LoginStatus = false;

        //string selectedLanguage;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);


        try
        {
            //strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";

            //strSQL = "Exec [usp_User_CheckLogin] " + "'" + CommonFunctions.SafeSql(mUserName) + "' , '" + CommonFunctions.SafeSql(mPassword) + "'";

            dsCheck = objUser.CheckUser_LoginStatus(CommonFunctions.SafeSql(vUserID), CommonFunctions.SafeSql(vPassword));

            if (dsCheck.Tables.Count == 2)
            {
                dtUserStatus = dsCheck.Tables[0];
                dtUserRecord = dsCheck.Tables[1];
            }
            else
            {
                dtUserStatus = dsCheck.Tables[0];
            }

            DataRow UserStatus_Row = dtUserStatus.Rows[0];
            string UserStatus_Value = UserStatus_Row["userStatus"].ToString();


            if (UserStatus_Value == "MATCHED")
            {
                DataRow UserRecord_Row = dtUserRecord.Rows[0];

                Session["UserID"] = UserRecord_Row["UserID"].ToString();
                Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
                Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();

                LoginStatus = true;
            }
            else if (UserStatus_Value == "EXPIRED")
            {
                LtrErrMessage.Text = "Account Expired ...";
                LoginStatus = false;
            }
            else
            {
                LtrErrMessage.Text = "Invalid Password ...";
                LoginStatus = false;
            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {

        }

        return LoginStatus;

    }

}
