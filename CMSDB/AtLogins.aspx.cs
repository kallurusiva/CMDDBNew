using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class AtLogins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnBizLogin_Click(object sender, EventArgs e)
    {
        
            
        string mUserName = txtBizLoginID.Text;
        string mPassword = txtBizPassword.Text;

        try
        {

            string tmpCountryPrefix = mUserName.Substring(0, 2);

            if ((tmpCountryPrefix == "60") || (tmpCountryPrefix == "65") || (tmpCountryPrefix == "62"))
            {

                //validate the User. 
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(mUserName, mPassword);

                if (tmpMID == "0")
                {
                    // invalid login 
                    LtrErrMessage.Text = "Invalid Password ...";

                }
                else if (tmpMID == "1")
                {
                    LtrErrMessage.Text = "Not Subscribed to SMSBIZ.";

                    StringBuilder sbm = new StringBuilder();

                    sbm.Append(@"\n This M-Commerce Partner Login is strictly for SMS Entrepreneur Only.");
                    sbm.Append(@"\n ");
                    sbm.Append(@"\n Please consult your referral for explaination on ");
                    sbm.Append(@"\n SMS Business Requirement and ask for instructions ");
                    sbm.Append(@"\n on how to set SMS Business Status to YES.  ");
                    sbm.Append(@"\n\n ");
                    sbm.Append(@"\n Thank you.");

                    CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));
                    // CommonFunctions.AlertMessage(Server.HtmlEncode(@"Not Subscribed \n Thank you")); 


                }
                else
                {
                    CommonFunctions.CheckSubDomainByLoginID(tmpCountryPrefix, mUserName, mPassword);
                    CommonFunctions.LogUserWebInfo(tmpMID, mUserName);
                    CommonFunctions.Redirect2Logins(tmpCountryPrefix, mUserName, mPassword);

                }
            }
            else
            {
                //if loggin in by Domain Names...
                Boolean isValidLogin = ValidateLoginByDomain(mUserName, mPassword);


                if (isValidLogin)
                {
                    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

                    int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));
                    CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
                    Response.Redirect("~/Admin/Ad_Welcome.aspx");
                    //Server.Transfer("~/Admin/Welcome.aspx");

                }


            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {

        }

    }


    protected void btnSMSlogin_Click(object sender, EventArgs e)
    {
        
        string mUserName = txtSMSloginID.Text;
        string mPassword = txtSMSpassword.Text;
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
            //IFM_dbCmd.Parameters.Add("@vResult", SqlDbType.VarChar).Size = 20;
            //IFM_dbCmd.Parameters.Add("@vResult", SqlDbType.VarChar).Direction = ParameterDirection.Output;



            //int status = IFM_dbCmd.ExecuteScalar

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


        String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
        strReferringURL = strReferringURL.Replace("http://", "");
        int GetFirstSlashidx = strReferringURL.IndexOf(@":");
        if (GetFirstSlashidx > 0)
            strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx);

        //String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
        //strReferringURL = strReferringURL.Replace("http://", "");
        //int GetFirstSlashidx = strReferringURL.IndexOf(@":");
        //if(GetFirstSlashidx >0)
        //strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx); 

        //string strReferringURL = string.Empty;
        //if(Session["referringURL"] != null) 
        //strReferringURL = Session["referringURL"].ToString(); 

        //Check if the user is from Malaysia or Singapore 
        string strURL = string.Empty;
        //String tmpUser = mUserName.Substring(0, 2);
        if ((UsrCountryCode == 60) || (UsrCountryCode == 0))
        {

            //strURL = "http://64.78.18.147/SMSMLMNEW/Includes/1SmsWebsite_MAS_BizLoginCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E&LoginFrom=SMSLOGIN" + "&ReferringURL=" + strReferringURL;
            strURL = "http://64.78.18.147/SMSMLMNEW/Includes/1SmsWebsite_MAS_BizLoginCheck_NEW.asp";
            //Page.SmartNavigation = false;
            //Response.Redirect(strURL);

        }
        else if (UsrCountryCode == 65)
        {

            //strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E&LoginFrom=SMSLOGIN" + "&ReferringURL=" + strReferringURL;
            strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck_NEW.asp";
            //Page.SmartNavigation = false;
            //Response.Redirect(strURL);


        }
        else if (UsrCountryCode == 62)
        {
            //http://64.78.18.147/SMSindonesia 
            strURL = "http://64.78.18.147/smsIndonesia/Includes/1SMSwebsite_Indo_BizLoginCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E&LoginFrom=SMSLOGIN" + "&ReferringURL=" + strReferringURL;
            //Page.SmartNavigation = false;
            Response.Redirect(strURL);

        }



        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();
        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
        sb.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", mUserName);
        sb.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", mPassword);
        sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
        // Other params go here
        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();



        ////http://www.1malaysiasms.com/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=60123280155&Mpwd=281800&txtLanguage=E

        //string strURL = "http://64.78.18.147/SMSMLMNEW/Includes/CustLogin_BizMemberCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E";

        ////string strURL = "CustTempPage.aspx?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=E";

        //Page.SmartNavigation = false;
        //Response.Redirect(strURL);

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



    protected void btnWebLogin_Click(object sender, EventArgs e)
    {
        
        string mUserName = txtWebLoginID.Text;
        string mPassword = txtWebPassword.Text;

        try
        {

            string tmpCountryPrefix = mUserName.Substring(0, 2);

            if ((tmpCountryPrefix == "60") || (tmpCountryPrefix == "65") || (tmpCountryPrefix == "62"))
            {

                //validate the User. 
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(mUserName, mPassword);

                if (tmpMID == "0")
                {
                    // invalid login 
                    LtrErrMessage3.Text = "Invalid Password ...";

                }
                else if (tmpMID == "1")
                {
                    LtrErrMessage3.Text = "Not Subscribed to SMSBIZ.";

                    StringBuilder sbm = new StringBuilder();

                    sbm.Append(@"\n This M-Commerce Partner Login is strictly for SMS Entrepreneur Only.");
                    sbm.Append(@"\n ");
                    sbm.Append(@"\n Please consult your referral for explaination on ");
                    sbm.Append(@"\n SMS Business Requirement and ask for instructions ");
                    sbm.Append(@"\n on how to set SMS Business Status to YES.  ");
                    sbm.Append(@"\n\n ");
                    sbm.Append(@"\n Thank you.");

                    CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));
                    // CommonFunctions.AlertMessage(Server.HtmlEncode(@"Not Subscribed \n Thank you")); 


                }
                else
                {
                    CommonFunctions.CheckSubDomainByLoginID(tmpCountryPrefix, mUserName, mPassword);
                    CommonFunctions.LogUserWebInfo(tmpMID, mUserName);
                    CommonFunctions.Redirect2Logins(tmpCountryPrefix, mUserName, mPassword);

                }
            }
            else
            {
                //if loggin in by Domain Names...
                Boolean isValidLogin = ValidateLoginByDomain(mUserName, mPassword);


                if (isValidLogin)
                {
                    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

                    int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));
                    CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
                    Response.Redirect("~/Admin/Ad_Welcome.aspx");
                    //Server.Transfer("~/Admin/Welcome.aspx");

                }


            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {

        }
    }
}
