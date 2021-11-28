using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class SessionTimedOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void BtnPreIODLogin_Click(object sender, EventArgs e)
    //{
    //    string mUserName = txtLoginID.Text;
    //    string mPassword = txtPassword.Text;

        

    //    string tmpCountryPrefix = mUserName.Substring(0, 2);

    //    if ((tmpCountryPrefix == "60") || (tmpCountryPrefix == "65") || (tmpCountryPrefix == "62"))
    //    {

    //        //validate the User. 
    //        CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
    //        string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(mUserName, mPassword);

    //        if (tmpMID == "0")
    //        {
    //            // invalid login 
    //            LtrErrMessage.Text = "Invalid Password ...";

    //        }
    //        else if (tmpMID == "1")
    //        {
    //            LtrErrMessage.Text = "Not Subscribed to SMSBIZ.";

    //            StringBuilder sbm = new StringBuilder();

    //            sbm.Append(@"\n This M-Commerce Partner Login is strictly for SMS Entrepreneur Only.");
    //            sbm.Append(@"\n ");
    //            sbm.Append(@"\n Please consult your referral for explaination on ");
    //            sbm.Append(@"\n SMS Business Requirement and ask for instructions ");
    //            sbm.Append(@"\n on how to set SMS Business Status to YES.  ");
    //            sbm.Append(@"\n\n ");
    //            sbm.Append(@"\n Thank you.");

    //            CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));
    //            // CommonFunctions.AlertMessage(Server.HtmlEncode(@"Not Subscribed \n Thank you")); 


    //        }
    //        else
    //        {

    //            CommonFunctions.Redirect2Logins(tmpCountryPrefix, mUserName, mPassword);

    //        }
    //    }
    //    else
    //    {
    //        //if loggin in by Domain Names...
    //        Boolean isValidLogin = ValidateLoginByDomain(mUserName, mPassword);


    //        if (isValidLogin)
    //        {
    //            CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

    //            int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));

    //            Response.Redirect("~/Admin/Ad_Welcome.aspx");
    //            //Server.Transfer("~/Admin/Welcome.aspx");

    //        }


    //    }


    //}

    //protected Boolean ValidateLoginByDomain(string vUserID, string vPassword)
    //{


    //    SqlConnection dbConn;
    //    SqlCommand dbCmd;
    //    SqlDataReader dbReader;
    //    SqlDataAdapter dbAdap;
    //    DataSet dsCheck;
    //    string strSQL = string.Empty;
    //    DataTable dtUserRecord = new DataTable();
    //    DataTable dtUserStatus = new DataTable();

    //    CMSv3.BAL.User objUser = new CMSv3.BAL.User();

    //    bool LoginStatus = false;

    //    //string selectedLanguage;

    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);


    //    try
    //    {
    //        //strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";

    //        //strSQL = "Exec [usp_User_CheckLogin] " + "'" + CommonFunctions.SafeSql(mUserName) + "' , '" + CommonFunctions.SafeSql(mPassword) + "'";

    //        dsCheck = objUser.CheckUser_LoginStatus(CommonFunctions.SafeSql(vUserID), CommonFunctions.SafeSql(vPassword));

    //        if (dsCheck.Tables.Count == 2)
    //        {
    //            dtUserStatus = dsCheck.Tables[0];
    //            dtUserRecord = dsCheck.Tables[1];
    //        }
    //        else
    //        {
    //            dtUserStatus = dsCheck.Tables[0];
    //        }

    //        DataRow UserStatus_Row = dtUserStatus.Rows[0];
    //        string UserStatus_Value = UserStatus_Row["userStatus"].ToString();


    //        if (UserStatus_Value == "MATCHED")
    //        {
    //            DataRow UserRecord_Row = dtUserRecord.Rows[0];

    //            Session["UserID"] = UserRecord_Row["UserID"].ToString();
    //            Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
    //            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();

    //            LoginStatus = true;
    //        }
    //        else if (UserStatus_Value == "EXPIRED")
    //        {
    //            LtrErrMessage.Text = "Account Expired ...";
    //            LoginStatus = false;
    //        }
    //        else
    //        {
    //            LtrErrMessage.Text = "Invalid Password ...";
    //            LoginStatus = false;
    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //    finally
    //    {

    //    }

    //    return LoginStatus;

    //}

}
