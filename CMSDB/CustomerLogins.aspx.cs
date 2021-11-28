using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class CustomerLogins : UserWeb
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    //DataSet ds;
    string strSQL;


    protected void Page_Load(object sender, EventArgs e)
    {

        //MasterPage objMaster = (MasterPage)this.Master;
        //Literal ltrTest = (Literal) objMaster.FindControl("LtrTest");
        //ltrTest.Text = "Testing";


        HtmlGenericControl myDivObject;
        myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
        myDivObject.InnerHtml = "<img alt='imbnLeftimg' src='Images/login_sidehead.jpg' />";


        Muser.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        //txtLogin_SMS.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        //txtSing_Login.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");


    }





    protected void btnSignIn_SMS_Click(object sender, EventArgs e)
    {

        string mUserName = txtLogin_SMS.Text;
        string mPassword = txtPassword_SMS.Text;
      
 
        //Check if the user is from Malaysia or Singapore 

        int UsrCountryCode = Convert.ToInt32(mUserName.Substring(0, 2));
        if (UsrCountryCode == 60)
        {

            string strURL = "http://64.78.18.147/SMSMLMNEW/Includes/1SmsWebsite_MAS_BizLoginCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E";
            //Page.SmartNavigation = false;
            Response.Redirect(strURL);

        }
        else if (UsrCountryCode == 65)
        {

            string strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E";
           // Page.SmartNavigation = false;
            Page.MaintainScrollPositionOnPostBack = false; 
            Response.Redirect(strURL);

        }
        else
        {
            LtrErrMessage.Text = "Invalid Login ..";
        }




        ////http://www.1malaysiasms.com/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=60123280155&Mpwd=281800&txtLanguage=E

        //string strURL = "http://64.78.18.147/SMSMLMNEW/Includes/CustLogin_BizMemberCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&txtLanguage=E";

        ////string strURL = "CustTempPage.aspx?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=E";

        //Page.SmartNavigation = false;
        //Response.Redirect(strURL);



    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {

        bool LoginStatus = false;

        //string selectedLanguage;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        string mUserName = txtLoginID.Text;
        string mPassword = txtPassword.Text;

        //try
        //{
        strSQL = "Select UserID,LoginID,UserType from tblUsers where LoginID='" + mUserName + "' and LoginPassword='" + mPassword + "'";

        dbConn.Open();
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                Session["UserID"] = dbReader["UserID"].ToString();
                Session["LoginID"] = dbReader["LoginID"].ToString();
                //Session["defLanguage"] = ddlLang.SelectedValue;
                //lblErrMessage.Text = "User Sucessfully Logged IN ";
                //selectedLanguage = Session["defLanguage"].ToString();
                //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
                LoginStatus = true;

            }
        }
        else
        {
            LtrErrMessage.Text = "Invalid Password ..";
            LoginStatus = false;
        }



        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
        //finally
        //{

        //}
       
        if (LoginStatus)
            Response.Redirect("~/Admin/Ad_WelcomeDPE.aspx");
        //Server.Transfer("~/Admin/Welcome.aspx");


    }

    protected void btnSignIn_1Malaysia_Click(object sender, EventArgs e)
    {

        string strLoginID = Muser.Text;
        string strPassword = Mpwd.Text;
        //string strLanguage = ddlLanguage.SelectedValue;
        

        
        //Check users validatity 

        //string ret_StatusMessage = fnChecknLogin("malaysia", strLoginID, strPassword);

        //if (ret_StatusMessage != "SUCCESS")
        //{
        //    CommonFunctions.AlertMessage(ret_StatusMessage);
        //}

        //string strURL = "http://www.1malaysiasms.com/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=E";
        //string strURL = "http://64.78.18.32/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=" + strLanguage;
        string strURL = "http://64.78.18.32/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword;
        //Page.SmartNavigation = false;
        Response.Redirect(strURL);


    }


    protected void btnSignIn_1Singapore_Click(object sender, EventArgs e)
    {

        string strLoginID = txtSing_Login.Text;
        string strPassword = txtSing_Password.Text;

        //http://www.1malaysiasms.com/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=60123280155&Mpwd=281800&txtLanguage=E

       // string strURL = "http://www.1Singaporesms.com/singapore/1SMSWebSite_BizMemberCheckSGD.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword;
        string strURL = "http://64.78.18.32/singapore/1SMSWebSite_BizMemberCheckSGD.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword;
        //Page.SmartNavigation = false;
        Page.MaintainScrollPositionOnPostBack = false; 
        Response.Redirect(strURL);



    }



    protected string fnCheck_IsValidUser(string vCountry, string vUserName, string vPassword)
    {

        SqlConnection abest_dbConn;
        SqlCommand abest_dbCmd;

        SqlConnection mlm_dbConn;
        SqlCommand mlm_dbCmd;

        string StatusMessage = string.Empty;
        string vBKUserName = "BK" + vUserName;

        string sLoginID = string.Empty;
        string sMName = string.Empty;
        string sPType = string.Empty;
        string sLostID = string.Empty;



        abest_dbConn = new SqlConnection(ConfigurationManager.AppSettings["ABESTdb"].ToString());
        mlm_dbConn = new SqlConnection(ConfigurationManager.AppSettings["IFMdb"].ToString());

        if (vCountry.ToLower() == "malaysia")
        {



            try
            {
                abest_dbConn.Open();
                mlm_dbConn.Open();

                // check if the site is Freezed
                strSQL = "Select Freeze from T017_FreezeWeb";
                mlm_dbCmd = new SqlCommand(strSQL, mlm_dbConn);
                string chrFreeze = Convert.ToString(mlm_dbCmd.ExecuteScalar());

                if (chrFreeze == "Y")
                {
                    StatusMessage = "Site Freezed !!";
                    return StatusMessage;
                }
                else
                {
                    strSQL = "Select MID from TMerchant_Details where Login='" + vBKUserName + "' and rtrim(ltrim(MPassword))='" + vPassword + "'";
                    abest_dbCmd = new SqlCommand(strSQL, abest_dbConn);
                    string strMID = Convert.ToString(abest_dbCmd.ExecuteScalar());

                    if (strMID == "")
                    {
                        StatusMessage = "Invalid LoginID or Password";
                        return StatusMessage;
                    }
                    else
                    {

                        strSQL = "Select p.Login_ID,p.Freeze_Status,p.Member_Name,p.Acc_Type,t.SNo as LostID,q.Mobile as Subscriber from T001_AccountDetails p " +
                                 " inner join T002_LevelTracker t on t.Mobile=p.Login_ID " +
                                 " left outer join T002_Subscription q on q.Mobile=p.Login_ID " +
                                 " where  p.Login_ID='" + vUserName + "' and  rtrim(ltrim(p.Password))='" + vPassword + "'";

                        mlm_dbCmd = new SqlCommand(strSQL, mlm_dbConn);

                        SqlDataReader dbReader;
                        dbReader = mlm_dbCmd.ExecuteReader();

                        if (dbReader.HasRows)
                        {
                            while (dbReader.Read())
                            {

                                if (dbReader["Freeze_Status"].ToString().ToUpper() == "Y")
                                {
                                    StatusMessage = "Your Account Subscription has been freezed.";
                                }

                                //   check with SIVA OR SHYAMALA 
                                //if (dbReader["Subscriber"].ToString() == "")
                                //{
                                //    StatusMessage = "Your Account Subscription has been freezed.";
                                //}



                                //create the following session in the asp popu up page. 
                                /* session("Login_ID") = rs("Login_ID")
                                 session("MName") = rs("Member_Name")
                                 session("PType") = rs("Acc_type")
                                 session("Lost_ID")  = rs("LostID") */

                                sLoginID = dbReader["Login_ID"].ToString();
                                sMName = dbReader["Member_Name"].ToString();
                                sPType = dbReader["Acc_type"].ToString();
                                sLostID = dbReader["LostID"].ToString();


                            }

                        }
                        else
                        {
                            StatusMessage = "Invalid LoginID or Password";
                            return StatusMessage;

                        }




                    }

                }

                if (StatusMessage == string.Empty)
                {

                    strSQL = "select top 1 FrzStatus from T4000_Freeze where FrzType='MERLogin'";
                    abest_dbCmd = new SqlCommand(strSQL, abest_dbConn);
                    string strMERfreeze = Convert.ToString(abest_dbCmd.ExecuteScalar());

                    if (strMERfreeze == "FREEZED")
                    {
                        StatusMessage = "Account Freezed";
                        return StatusMessage;
                    }
                    else
                    {
                        strSQL = "select MID from TMerchant_Details where Login='" + vBKUserName + "' and MPassword='" + vPassword + "'";
                        abest_dbCmd = new SqlCommand(strSQL, abest_dbConn);

                        string tmpMID = Convert.ToString(abest_dbCmd.ExecuteScalar());

                        if (tmpMID == "")
                        {
                            StatusMessage = "Invalid LoginID or Password";
                            return StatusMessage;
                        }
                        else
                        {
                            /* session("Login_ID") = rs("Login_ID")
                             session("MName") = rs("Member_Name")
                                session("PType") = rs("Acc_type")
                                session("Lost_ID")  = rs("LostID") */

                            //session("merchant")=rs_Merchant("MID")
                            //session("CustoLogin") = "YES"
                            //response.redirect("../MemberNew/ProfileWelcome.asp")

                            string strURL = "http://www.1malaysiasms.com/MLMSMS/1SmsBusiness_LoginCheck.asp?LoginID=" + sLoginID + "&MName=" + sMName + "&Ptype=" + sPType + "&LostID=" + sLostID + "&MID=" + tmpMID;
                            //Page.SmartNavigation = false;
                            Page.MaintainScrollPositionOnPostBack = false; 
                            Response.Redirect(strURL);
                        }

                    }

                }
                else
                {

                    StatusMessage = "Technical Error!!!";
                    return StatusMessage;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                abest_dbConn.Close();
                mlm_dbConn.Close();
            }


        }
        else if (vCountry.ToLower() == "singapore")
        {


        }

        return "SUCESS";

    }

    protected string fnChecknLogin(string vCountry, string vUserName, string vPassword)
    {


        SqlConnection abest_dbConn;
        SqlCommand abest_dbCmd;

        SqlConnection mlm_dbConn;
        SqlCommand mlm_dbCmd;

        string StatusMessage = string.Empty;
        string vBKUserName = "BK" + vUserName;

        string sLoginID = string.Empty;
        string sMName = string.Empty;
        string sPType = string.Empty;
        string sLostID = string.Empty;



        abest_dbConn = new SqlConnection(ConfigurationManager.AppSettings["ABESTdb"].ToString());
        mlm_dbConn = new SqlConnection(ConfigurationManager.AppSettings["IFMdb"].ToString());


        if (vCountry.ToLower() == "malaysia")
        {
            // check if the site is Freezed
            strSQL = "Select Freeze from T017_FreezeWeb";

            try
            {

                abest_dbConn.Open();
                mlm_dbConn.Open();

                // check if the site is Freezed
                strSQL = "Select Freeze from T017_FreezeWeb";
                mlm_dbCmd = new SqlCommand(strSQL, mlm_dbConn);
                string chrFreeze = Convert.ToString(mlm_dbCmd.ExecuteScalar());

                if (chrFreeze == "Y")
                {
                    StatusMessage = "Site Freezed !!";
                    return StatusMessage;
                }
                else
                {
                    strSQL = "Select MID from TMerchant_Details where Login='" + vBKUserName + "' and rtrim(ltrim(MPassword))='" + vPassword + "'";
                    abest_dbCmd = new SqlCommand(strSQL, abest_dbConn);
                    string strMID = Convert.ToString(abest_dbCmd.ExecuteScalar());

                    if (strMID == "")
                    {
                        StatusMessage = "Invalid LoginID or Password";
                        return StatusMessage;
                    }
                    else
                    {
                        strSQL = "Select p.Login_ID,p.Freeze_Status,p.Member_Name,p.Acc_Type,t.SNo as LostID,q.Mobile as Subscriber from T001_AccountDetails p " +
                                 " inner join T002_LevelTracker t on t.Mobile=p.Login_ID " +
                                 " left outer join T002_Subscription q on q.Mobile=p.Login_ID " +
                                 " where  p.Login_ID='" + vUserName + "' and  rtrim(ltrim(p.Password))='" + vPassword + "'";

                        mlm_dbCmd = new SqlCommand(strSQL, mlm_dbConn);

                        SqlDataReader dbReader;
                        dbReader = mlm_dbCmd.ExecuteReader();


                        if (dbReader.HasRows)
                        {
                            while (dbReader.Read())
                            {

                                if (dbReader["Freeze_Status"].ToString().ToUpper() == "Y")
                                {
                                    StatusMessage = "Your Account Subscription has been freezed.";
                                    return StatusMessage;
                                }

                                  // check with SIVA OR SHYAMALA 
                                if (dbReader["Subscriber"].ToString() == "")
                                {
                                    StatusMessage = "Moble registration imcomplete.";
                                    return StatusMessage;
                                }



                                sLoginID = dbReader["Login_ID"].ToString();
                                sMName = dbReader["Member_Name"].ToString();
                                sPType = dbReader["Acc_type"].ToString();
                                sLostID = dbReader["LostID"].ToString();


                                string strURL = "http://www.1malaysiasms.com/MLMSMS/1SmsBusiness_LoginCheck.asp?LoginID=" + sLoginID + "&MName=" + sMName + "&Ptype=" + sPType + "&LostID=" + sLostID;
                                //Page.SmartNavigation = false;
                                Uri strURi = new Uri(strURL);

                                CommonFunctions.OpenWindow(strURi);
                                //Response.Redirect(strURL);

                               // return StatusMessage;

						
                            }

                        }
                        else
                        {
                            StatusMessage = "Invalid LoginID or Password";
                            return StatusMessage;

                        }


                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (abest_dbConn.State == ConnectionState.Open)
                    abest_dbConn.Close();

                if (mlm_dbConn.State == ConnectionState.Open)
                    mlm_dbConn.Close();
            }


           
        }
 return "SUCCESS";
    }


    protected void BtnPreIODLogin_Click(object sender, EventArgs e)
    {

        string strLoginID = txtPre_IODlogin.Text;
        string strPassword = txtPre_IODPwd.Text;

        string strURL = "http://www.1premiumsmsiod.com/smsiod/includes/BIZ_LoginCheck_1SmsWebSite.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=E";
        //Page.SmartNavigation = false;
        Page.MaintainScrollPositionOnPostBack = false; 
        Response.Redirect(strURL);


    }
    protected void BtnPreSMSSubLogin_Click(object sender, EventArgs e)
    {

        string strLoginID = txtPre_SmsSubLogin.Text;
        string strPassword = txtPre_SmsSubPwd.Text;

        string strURL = "http://www.1premiumsmssubscription.com/premiumsmssubscription/SMSSUB_LoginCheck_1SmsWebSite.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=E";
        //Page.SmartNavigation = false;
        Page.MaintainScrollPositionOnPostBack = true; 
        Response.Redirect(strURL);

    }
    protected void Btn3WayLogin_Click(object sender, EventArgs e)
    {

        string strLoginID = txtPre_3wayLogin.Text;
        string strPassword = txtPre_3wayPwd.Text;

        string strURL = "http://www.1premiumsms3way.com/premiumsms3way/includes/3Way_BIZ_LoginCheck_1SmsWebSite.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=E";
        //Page.SmartNavigation = false;
        Page.MaintainScrollPositionOnPostBack = false; 
        Response.Redirect(strURL);

    }
}

