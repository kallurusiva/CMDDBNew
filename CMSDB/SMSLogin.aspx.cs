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
using System.Text;
using System.Globalization;
using System.Threading;


public partial class SMSLogin : UserWeb
{
//    SqlConnection dbConn;
//    SqlCommand dbCmd;
//    SqlDataReader dbReader;
    DataSet ds;
 //   string strSQL;

    CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();


    protected void Page_Load(object sender, EventArgs e)
    {

        //MasterPage objMaster = (MasterPage)this.Master;
        //Literal ltrTest = (Literal) objMaster.FindControl("LtrTest");
        //ltrTest.Text = "Testing";
        
        CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

        if (ci.ToString() == "en-US")
        {
            ltrBIZ_Login.Text = Resources.LangResources.Login + " " + Resources.LangResources.id;
            ltrSMS_Login.Text = Resources.LangResources.Login + " " + Resources.LangResources.id;
            ltrWeb_Login.Text = Resources.LangResources.Login + " " + Resources.LangResources.id; 
            
        }
        else
        {
            ltrBIZ_Login.Text = Resources.LangResources.Login;
            ltrSMS_Login.Text = Resources.LangResources.Login;
            ltrWeb_Login.Text = Resources.LangResources.Login;
        }

        
        ltrBIZ_Password.Text = Resources.LangResources.Password;
        ltrSMS_Password.Text = Resources.LangResources.Password;
        ltrWEB_Password.Text = Resources.LangResources.Password;

        btnSignIn_SMS.Text = Resources.LangResources.SignIn;
        btnWebPlogin.Text = Resources.LangResources.SignIn;
        BtnBizLogin.Text = Resources.LangResources.SignIn;

        HypBIZ_fp.Text = Resources.LangResources.ForgotPassword;
        HypSMS_fp.Text = Resources.LangResources.ForgotPassword;
        HypWEB_fp.Text = Resources.LangResources.ForgotPassword; 





        HtmlGenericControl myDivObject;
        myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
        if(myDivObject != null)
        myDivObject.InnerHtml = "<img alt='imbnLeftimg' src='Images/login_sidehead.jpg' />";


        ContentPlaceHolder cphLEFT = Page.Master.FindControl("ContentPlaceHolderLEFT") as ContentPlaceHolder;
        cphLEFT.Visible = false;

        ContentPlaceHolder cphRIGHT = Page.Master.FindControl("ContentPlaceHolderRight") as ContentPlaceHolder;
        






     
        //txtLogin_SMS.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");

        RenderLogins(); 

    }



    protected void RenderLogins()
    {
        DataSet MainDS;

        DataTable tbMenu;
        DataTable tbHomePgContent;
    
        CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();

        MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));

        tbMenu = MainDS.Tables[0];              //tbltopMenuLinks
        tbHomePgContent = MainDS.Tables[1];     //tblHomePgSettings


        if(tbHomePgContent.Rows.Count > 0)
        {

            DataRow HpgRow = tbHomePgContent.Rows[0];
            string tmpLogins2Show = HpgRow["LoginsToshow"].ToString();

            string[] LoginsArray = tmpLogins2Show.Split(',');

            foreach(String lgID in LoginsArray)
            {
                switch(lgID)
                {

                    case "1": dvSMSLogin.Visible = true;
                        break;

                    case "2": dvWebPortal.Visible = true;
                        break;

                    case "3": dvPartnerLogin.Visible = true;
                        break;

                    case "4": dvDIYlogin.Visible = true;
                        break;

                    case "5": dvCorporateLogin.Visible = true;
                        break; 

                }
                


            }


        }

    }




    protected void btnSignIn_SMS_Click(object sender, EventArgs e)
    {

        string mUserName = txtLogin_SMS.Text;
        string mPassword = txtPassword_SMS.Text;
        string mMID = string.Empty;
        string mReturnedMobileNo = string.Empty;


        


        #region


        String tmpUserPrefix = mUserName.Substring(0, 2);
        string tmpForBruneiPrefix = mUserName.Substring(0, 3);
        if (tmpForBruneiPrefix == "673")
            tmpUserPrefix = "673";

        int UsrCountryCode = 0;

        #region commented code 
        //////OnlyForBrunei using Sam number 
        //////String TestingMobileNumber = ConfigurationManager.AppSettings["testMobileNumber"].ToString();
        //////if (mUserName == TestingMobileNumber)
        //////    tmpUserPrefix = "673";



        //////if ((tmpUserPrefix == "60") || (tmpUserPrefix == "65") || (tmpUserPrefix == "62") || (tmpUserPrefix == "673"))
        ////if (IsNumeric(tmpUserPrefix))
        ////{
        ////    UsrCountryCode = Convert.ToInt32(tmpUserPrefix);
        ////}
        ////else
        ////{
        ////    //..Check if the Login is Valid in the SpecialLogin Table. 

        ////    SqlConnection IFM_dbConn;
        ////    SqlCommand IFM_dbCmd;
        ////    IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);

        ////    try
        ////    {
        ////        IFM_dbConn.Open();

        ////        IFM_dbCmd = new SqlCommand("[USP_Verify_SpecialLoginName_4SMSSystem]", IFM_dbConn);
        ////        IFM_dbCmd.CommandType = CommandType.StoredProcedure;
        ////        IFM_dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = mUserName;

        ////        mReturnedMobileNo = IFM_dbCmd.ExecuteScalar().ToString();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        throw new Exception(ex.Message);
        ////    }
        ////    finally
        ////    {
        ////        IFM_dbConn.Close();
        ////    }


            

        ////    if (mReturnedMobileNo == "00")
        ////    {
        ////        UsrCountryCode = 0;
        ////        lblErrMsg_SmsSystem.Visible = true;
        ////    }
        ////    else
        ////    {
        ////        lblErrMsg_SmsSystem.Visible = false;
        ////        UsrCountryCode = Convert.ToInt32(mReturnedMobileNo.Substring(0, 2));
        ////        string tmpForBruneiPrefix2 = mReturnedMobileNo.Substring(0, 3);
        ////        if (tmpForBruneiPrefix2 == "673")
        ////            UsrCountryCode = 673;
        ////    }

        ////        mUserName = mReturnedMobileNo;


        #endregion


        //int ValidStatus = ValidateLoginStatus(mUserName, mPassword, "SMSSYSTEM");
        int ValidStatus = 0; 
        String ValidStatusText = CommonFunctions.ValidateLoginStatusNEW(mUserName, mPassword, "SMSSYSTEM", ref ValidStatus);

        if ((ValidStatus == 0) || (ValidStatus == 3))
        {
            if (ValidStatus == 3)
            {
              //  CommonFunctions.AlertMessage(ValidStatusText);
                
            }


            if (IsNumeric(tmpUserPrefix))
            {
                UsrCountryCode = Convert.ToInt32(tmpUserPrefix);
            }
            else
            {
                //..Check if the Login is Valid in the SpecialLogin Table. 

                SqlConnection IFM_dbConn;
                SqlCommand IFM_dbCmd;
                IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);

                try
                {
                    IFM_dbConn.Open();

                    IFM_dbCmd = new SqlCommand("[USP_Verify_SpecialLoginName_4SMSSystem]", IFM_dbConn);
                    IFM_dbCmd.CommandType = CommandType.StoredProcedure;
                    IFM_dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = mUserName;

                    mReturnedMobileNo = IFM_dbCmd.ExecuteScalar().ToString();
                    mUserName = mReturnedMobileNo;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    IFM_dbConn.Close();
                }
            }



            String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
            strReferringURL = strReferringURL.Replace("http://", "");
            int GetFirstSlashidx = strReferringURL.IndexOf(@":");
            if (GetFirstSlashidx > 0)
                strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx);


            ////        string strURL = string.Empty;

            ////        if (UsrCountryCode == 66)
            ////            UsrCountryCode = 60;


            ////        switch (UsrCountryCode.ToString())
            ////        {

            ////            case "60":  /* Malaysia  */ strURL = "http://64.78.18.147/Hitech/Includes/1SmsWebsite_MAS_BizLoginCheck_Hitech.asp"; break;
            ////            case "62":  /* Indonesia  */ strURL = "http://64.78.18.147/smsIndonesia/Includes/1SmsWebsite_Indo_BizLoginCheck.asp"; break;
            ////            case "65":  /* Singapore */ strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck_NEW.asp"; break;
            ////            case "673": /* Brunei    */ strURL = "http://64.78.18.147/Hitech/Includes/SmsSystemLogin_Brunei.asp"; break;

            ////        }
            ////        Page.SmartNavigation = false;


            String strURL = ConfigurationManager.AppSettings["HitechSMSTransitURL"].ToString();

            // String strURL = "http://www.GsurfStaging.com/hitechsms/SMSloginTransit.aspx";

            HttpContext.Current.Response.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
            sb.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", mUserName);
            sb.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", mPassword);
            sb.AppendFormat("<input type='hidden' name='MLoginFrom' value='{0}'>", "SMSLOGIN");
            sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());
            //HttpContext.Current.Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();



            // }
            // }



        #endregion



            #region New Code Commented

            //SqlConnection IFM_dbConn;
            //SqlCommand IFM_dbCmd;


            //IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);
            //IFM_dbConn.Open();

            //IFM_dbCmd = new SqlCommand("[USP_ValidateLogin_SMSSystem]", IFM_dbConn);
            //IFM_dbCmd.CommandType = CommandType.StoredProcedure;
            //IFM_dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = mUserName;
            //IFM_dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = mPassword;
            //IFM_dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = 0;

            //mMID = IFM_dbCmd.ExecuteScalar().ToString();


            //if (mMID == "0")
            //{
            //    // invalid login 
            //    LtrErrMessage.Text = "Invalid Password ...";

            //}
            //else
            //{

            //    string strURL = "http://210.5.45.47/hitechsms/ValidateUserLogin_FromMyHitech.aspx";

            //    HttpContext.Current.Response.Clear();
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("<html>");
            //    sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            //    sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
            //    sb.AppendFormat("<input type='hidden' name='tmpMID' value='{0}'>", mMID);
            //    sb.AppendFormat("<input type='hidden' name='tmpUsrType' value='{0}'>", 0);
            //    sb.AppendFormat("<input type='hidden' name='tmpLoginFrom' value='{0}'>", "SMSLOGIN");
            //    //sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
            //    // Other params go here
            //    sb.Append("</form>");
            //    sb.Append("</body>");
            //    sb.Append("</html>");

            //    HttpContext.Current.Response.Write(sb.ToString());
            //    //HttpContext.Current.Response.End();
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();


            //}

            #endregion

        }
        else
        {
            CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustSMSlogin), 1);
            ValidStatusText = ValidStatusText.Replace("\\n", "<br>"); 
            LblNotice.Text = ValidStatusText;
            ModalPopUpExtender1.Show(); 

        }

    }


    protected int ValidateLoginStatus(string vLoginID, String vPassword,String vType)
    {

        int retStatus = 0; 

        //validate the Logins . 

        ds = objBAL_MalaysiaSMS.ValidateLoginStatus(vLoginID, vPassword,vType);

        DataTable dtFreeze = ds.Tables[0];
        DataTable dtExpiry = ds.Tables[1];


        if(dtFreeze.Rows.Count > 0)
        {
        
            DataRow dtRow = dtFreeze.Rows[0];

            int FreezeStatus = Convert.ToInt16(dtRow["FrzStatus"].ToString());
            String FreezeMessage = dtRow["FrzMessage"].ToString();
           // CommonFunctions.AlertMessage(FreezeStatus.ToString()); 
            if (FreezeStatus == 1)
            {
                LblNotice.Text = FreezeMessage;
                ModalPopUpExtender1.Show();
                retStatus = 1; 
                //Response.Redirect("smslogin.aspx");
            }

        }

        if (dtExpiry.Rows.Count > 0)
        {

            DataRow dtRow = dtExpiry.Rows[0];

            int MonthsLeft = Convert.ToInt16(dtRow["NoOfMonthsLEFT"].ToString());
            DateTime vExpiryDate = Convert.ToDateTime(dtRow["ExpiryDate"].ToString());

           
            if (MonthsLeft < 1)
            {
                LblNotice.Text = @"Your Account has already expired on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately. <br> Expired account will be removed from the system after 90 days";
                ModalPopUpExtender1.Show();
                retStatus = 2; 
                //Response.Redirect("smslogin.aspx"); 
            }
            else if(MonthsLeft < 3)
            {
                LblNotice.Text = @"Your Account will expire on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately. <br> Expired account will be removed from the system after 90 days";
                retStatus = 3; 
                ModalPopUpExtender1.Show();
               // Response.Redirect("smslogin.aspx"); 
            }


        }

        return retStatus; 


    }


    protected void btnWebPlogin_Click(object sender, EventArgs e)
    {
        
        string mUserName = txtLoginID.Text;
        string mPassword = txtPassword.Text;


        //int ValidStatus = ValidateLoginStatus(mUserName, mPassword, "WEBPORTAL");

        int ValidStatus= 0; 
        String ValidStatusTxt = CommonFunctions.ValidateLoginStatusNEW(mUserName, mPassword, "WEBPORTAL", ref ValidStatus); 

        string tmpCountryPrefix = mUserName.Substring(0, 2);
        string tmpForBruneiPrefix = mUserName.Substring(0, 3);

        if (tmpForBruneiPrefix == "673")
            tmpCountryPrefix = "673";

       // CommonFunctions.AlertMessage(ValidStatus.ToString());

       // if (ValidStatus == 0)
        if ((ValidStatus == 0) || (ValidStatus == 3))
        {

            if(ValidStatus == 3)
            {
                CommonFunctions.AlertMessage(ValidStatusTxt); 
                //ValidStatusTxt = ValidStatusTxt.Replace("\\n", "<br>");
                //LblNotice.Text = ValidStatusTxt;
                //ModalPopUpExtender1.Show();
                
            }


            //if ((tmpCountryPrefix == "60") || (tmpCountryPrefix == "65") || (tmpCountryPrefix == "62") || (tmpCountryPrefix == "673"))
            if (IsNumeric(tmpCountryPrefix))
            {

                //validate the User. 
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(mUserName, mPassword);

                if (tmpMID == "0")
                {
                    // invalid login 
                    LtrErrMessage.Text = "Invalid Password ...";
                    CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustWeblogin), 0);

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

                    //.. Before Redirecting Check if the User has registered a SubDomain. if NOT prompt message. 


                    CommonFunctions.CheckSubDomainByLoginID(tmpCountryPrefix, mUserName, mPassword);
                    CMSv3.BAL.User objUser = new CMSv3.BAL.User();

                    DataSet dsCheck;
                    string strSQL = string.Empty;
                    DataTable dtUserRecord = new DataTable();
                    DataTable dtUserStatus = new DataTable();

                    dsCheck = objUser.CheckUser_ValidateByMobileLogin(CommonFunctions.SafeSql(mUserName));

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
                        Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
                        Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
                        
                        Session["LoggedInFrom"] = "WEBPORTAL";

                        //Session["LoggedInFrom"] = "PG4MeBook1975";


                        String usrSubDomain = UserRecord_Row["SubDomain"].ToString();
                        String usrOwnDomain = UserRecord_Row["OwnDomain"].ToString();
                        String yourSampleURL = string.Empty;

                        if ((usrOwnDomain != null) && (usrOwnDomain != ""))
                        {
                            yourSampleURL = "http://www." + usrOwnDomain;
                        }
                        else
                        {
                            yourSampleURL = "http://" + usrSubDomain + ".1mybusiness.com";
                        }

                        Session["UserDomainURL"] = yourSampleURL;




                        CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
                        CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustWeblogin), 1);
                        Response.Redirect("~/Admin/Ad_Welcome.aspx");

                       // Response.Redirect("~/Admin/EbAd_DashBoard.aspx");
                        


                    }
                    else
                    {
                        CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
                    }




                    //CommonFunctions.Redirect2Logins(tmpCountryPrefix, mUserName, mPassword);

                }
            }

            else
            {


                //Allowing  Alphanumeric login for SMS users 
                CMSv3.BAL.IFMDomains objBal_IFMdomains = new CMSv3.BAL.IFMDomains();

                string vRefDomain = objBal_IFMdomains.GetRefMobileNumber(mUserName); 

                if(vRefDomain != "")
                {
                    mUserName = vRefDomain; 

                }
                


                //if loggin in by Domain Names...
                Boolean isValidLogin = ValidateLoginByDomain(mUserName, mPassword);


                if (isValidLogin)
                {
                    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();


                    DataSet dsCheck;
                    string strSQL = string.Empty;
                    DataTable dtUserRecord = new DataTable();
                    DataTable dtUserStatus = new DataTable();

                    dsCheck = objBAL_User.CheckUser_ValidateByMobileLogin(CommonFunctions.SafeSql(mUserName));

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


                    if ((UserStatus_Value == "MATCHED") || (UserStatus_Value == "SUBDOMAIN_FOUND"))
                    {
                        DataRow UserRecord_Row = dtUserRecord.Rows[0];

                        Session["UserID"] = UserRecord_Row["UserID"].ToString();
                        Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
                        Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
                        Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
                        Session["LoggedInFrom"] = "WEBPORTAL";


                        String usrSubDomain = UserRecord_Row["SubDomain"].ToString();
                        String usrOwnDomain = UserRecord_Row["OwnDomain"].ToString();
                        String yourSampleURL = string.Empty;

                        if ((usrOwnDomain != null) && (usrOwnDomain != ""))
                        {
                            yourSampleURL = "http://www." + usrOwnDomain;
                        }
                        else
                        {
                            yourSampleURL = "http://" + usrSubDomain + ".1mybusiness.com";
                        }

                        Session["UserDomainURL"] = yourSampleURL;


                        int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));

                        CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
                        CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustWeblogin), 1);
                        Response.Redirect("~/Admin/Ad_Welcome.aspx");

                    }
                    //else
                    //{
                    //    CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
                    //}






                    //CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
                    //CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustWeblogin), 1);
                    //Response.Redirect("~/Admin/Ad_Welcome.aspx");


                }

            }

        }
        else
        {
           // CommonFunctions.AlertMessage(ValidStatus.ToString()); 
            CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustWeblogin), 3);
            ValidStatusTxt = ValidStatusTxt.Replace("\\n", "<br>"); 
            LblNotice.Text = ValidStatusTxt; 
            ModalPopUpExtender1.Show();
        }


    }


    protected void BtnBizLogin_Click(object sender, EventArgs e)
    {
        
        string mUserName = txtBizLogin.Text;
        string mPassword = txtBizPassword.Text;

       


        string tmpCountryPrefix = mUserName.Substring(0, 2);
        string tmpForBruneiPrefix = mUserName.Substring(0, 3);

        if (tmpForBruneiPrefix == "673")
            tmpCountryPrefix = "673";

        String ValidStatusText = string.Empty;
        int ValidStatus = 0;
        ValidStatusText = CommonFunctions.ValidateLoginStatusNEW(mUserName, mPassword, "PARTNER", ref ValidStatus);


        if ((ValidStatus == 0) || (ValidStatus == 3))
        {
            if (ValidStatus == 3)
            {
               // CommonFunctions.AlertMessage(ValidStatusText);
               
            }
            //if ((tmpCountryPrefix == "60") || (tmpCountryPrefix == "65") || (tmpCountryPrefix == "62") || (tmpCountryPrefix == "673"))
            if (IsNumeric(tmpCountryPrefix))
            {

                //validate the User. 
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(mUserName, mPassword);

                if (tmpMID == "0")
                {
                    // invalid login 
                    LtrErrMessage.Text = "Invalid Password ...";
                    CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustBizlogin), 0);

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

                    //.. Before Redirecting Check if the User has registered a SubDomain. if NOT prompt message. 

                    //CommonFunctions.CheckSubDomainByLoginID(tmpCountryPrefix, mUserName, mPassword);
                    CommonFunctions.LogUserWebInfo(tmpMID, mUserName);
                    CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustBizlogin), 1);
                    CommonFunctions.Redirect2Logins(tmpCountryPrefix, mUserName, mPassword);

                }
            }
        }
        else
        {
            CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustBizlogin), 3);
            ValidStatusText = ValidStatusText.Replace("\\n", "<br>"); 
            LblNotice.Text = ValidStatusText;
            ModalPopUpExtender1.Show(); 

        }
       

    }


    public static Boolean IsNumeric(string stringToTest)
    {
        int result;
        return int.TryParse(stringToTest, out result);
    }


    protected Boolean ValidateLoginByDomain(string vUserID, string vPassword)
    {


        SqlConnection dbConn;
 //       SqlCommand dbCmd;
 //       SqlDataReader dbReader;
//        SqlDataAdapter dbAdap;
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

    protected void btnSME_FTRegister_Click(object sender, EventArgs e)
    {

        
        //string vSME_LoginID = txtSme_LoginID.Text;
        //string vSME_Password = txtSme_Password.Text; 
        //string vSME_PinNumber = txtSme_PinNo.Text;
        
        
        
        //.. Registration Flow
        /* 
         1. Check and Validate the PinNumber.   
         2. If inValid response with ErrorCode
         3. If VALID proceed to
         4.  -->  Create SMSsystem User
         5.  -->  Create CMS User
         */


    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {




    }

    protected void btnSignIn_SMSWEB_Click(object sender, EventArgs e)
    {
       // string mUserName = txtLogin_SMEWEB.Text;
       // string mPassword = txtPassword_SMSWEB.Text; 
       // string mReturnedMobileNo = string.Empty;

       // int UsrCountryCode = 0;
       // String tmpUserPrefix = mUserName.Substring(0, 2);
       // string tmpForBruneiPrefix = mUserName.Substring(0, 3);
       // if (tmpForBruneiPrefix == "673")
       //     tmpUserPrefix = "673";


       
       //     //..Check if the Login is Valid in the SpecialLogin Table. 

       //     SqlConnection IFM_dbConn;
       //     SqlCommand IFM_dbCmd;


       //     IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);
       //     IFM_dbConn.Open();

       //     IFM_dbCmd = new SqlCommand("[USP_Verify_SpecialLoginNameCMS]", IFM_dbConn);
       //     IFM_dbCmd.CommandType = CommandType.StoredProcedure;
       //     IFM_dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = mUserName;
       //     //IFM_dbCmd.Parameters.Add("@vResult", SqlDbType.VarChar).Size = 20;
       //     //IFM_dbCmd.Parameters.Add("@vResult", SqlDbType.VarChar).Direction = ParameterDirection.Output;



       //     //int status = IFM_dbCmd.ExecuteScalar

       //     //mReturnedMobileNo = (string)IFM_dbCmd.Parameters["@Result"].Value;

       //     mReturnedMobileNo = IFM_dbCmd.ExecuteScalar().ToString();

       //     mUserName = mReturnedMobileNo;

       //     if (mReturnedMobileNo == "00")
       //     {
       //         UsrCountryCode = 0;
       //     }
       //     else
       //     {
       //         UsrCountryCode = Convert.ToInt32(mReturnedMobileNo.Substring(0, 2));
       //         string tmpForBruneiPrefix2 = mReturnedMobileNo.Substring(0, 3);
       //         if (tmpForBruneiPrefix2 == "673")
       //             UsrCountryCode = 673;
    
       //     }
       //// }



       // if (UsrCountryCode == 66)
       //     UsrCountryCode = 60;


       // //validate the User. 
       // CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
       // string tmpMID = objBAL_MalaysiaSMS.ValidateLogin_WebEmailSMS(mUserName, mPassword);

       // if (tmpMID == "0")
       // {
       //     // invalid login 
       //     ltrWebEmailSMSError.Text = "Invalid Password ...";
       //     CommonFunctions.AlertMessage("Invalid Password !"); 

       // }
       // else
       // {


       //     //.. Before Redirecting Check if the User has registered a SubDomain. if NOT prompt message. 

       //     CMSv3.BAL.User objUser = new CMSv3.BAL.User();

       //     DataSet dsCheck;
       //     string strSQL = string.Empty;
       //     DataTable dtUserRecord = new DataTable();
       //     DataTable dtUserStatus = new DataTable();

       //     dsCheck = objUser.CheckUser_ValidateByMobileLogin(CommonFunctions.SafeSql(mUserName));

       //     if (dsCheck.Tables.Count == 2)
       //     {
       //         dtUserStatus = dsCheck.Tables[0];
       //         dtUserRecord = dsCheck.Tables[1];
       //     }
       //     else
       //     {
       //         dtUserStatus = dsCheck.Tables[0];
       //     }

       //     DataRow UserStatus_Row = dtUserStatus.Rows[0];
       //     string UserStatus_Value = UserStatus_Row["userStatus"].ToString();


       //     if (UserStatus_Value == "MATCHED")
       //     {
       //         DataRow UserRecord_Row = dtUserRecord.Rows[0];

       //         Session["UserID"] = UserRecord_Row["UserID"].ToString();
       //         Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
       //         Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
       //         Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
       //         Session["LoggedInFrom"] = "SMSSYSTEM_WPY";
       //         CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
       //         Response.Redirect("~/Admin/Ad_Welcome.aspx");
       //     }
       //     else
       //     {
       //         CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
       //     }

       // }


    }



    //protected void BtnPreSMSSubLogin_Click(object sender, EventArgs e)
    //{

    //    string strLoginID = txtPre_SmsSubLogin.Text;
    //    string strPassword = txtPre_SmsSubPwd.Text;

    //    string strURL = "http://www.1premiumsmssubscription.com/premiumsmssubscription/SMSSUB_LoginCheck_1SmsWebSite.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=E";
    //    Page.SmartNavigation = false;
    //    Response.Redirect(strURL);

    //}
    //protected void Btn3WayLogin_Click(object sender, EventArgs e)
    //{

    //    //string strLoginID = txtPre_3wayLogin.Text;
    //    //string strPassword = txtPre_3wayPwd.Text;

    //    //string strURL = "http://www.1premiumsms3way.com/premiumsms3way/includes/3Way_BIZ_LoginCheck_1SmsWebSite.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword + "&txtLanguage=E";
    //    //Page.SmartNavigation = false;
    //    //Response.Redirect(strURL);


    //    string strLoginID = txtPre_3wayLogin.Text;
    //    string strPassword = txtPre_3wayPwd.Text;

    //    String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
    //    strReferringURL = strReferringURL.Replace("http://", "");
    //    int GetFirstSlashidx = strReferringURL.IndexOf(@":");
    //    if (GetFirstSlashidx > 0)
    //        strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx);

    //    String strURL = ConfigurationManager.AppSettings["PREMIUM3WAYSMSURL"].ToString();

    //    HttpContext.Current.Response.Clear();
    //    StringBuilder sb = new StringBuilder();
    //    sb.Append("<html>");
    //    sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
    //    sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
    //    sb.AppendFormat("<input type='hidden' name='txtPre_3wayLogin' value='{0}'>", strLoginID);
    //    sb.AppendFormat("<input type='hidden' name='txtPre_3wayPwd' value='{0}'>", strPassword);
    //    sb.AppendFormat("<input type='hidden' name='tmpURL' value='{0}'>", strReferringURL);
    //    // Other params go here
    //    sb.Append("</form>");
    //    sb.Append("</body>");
    //    sb.Append("</html>");

    //    HttpContext.Current.Response.Write(sb.ToString());
    //    //HttpContext.Current.Response.End();
    //    HttpContext.Current.ApplicationInstance.CompleteRequest();

    //}



    //protected void Btn_PerSec_Login_Click(object sender, EventArgs e)
    //{

    //    string mUserName = txtPerSec_Login.Text;
    //    string mPassword = txtPerSec_Password.Text;
    //    string mMID = string.Empty;



    //    SqlConnection IFM_dbConn;
    //    SqlCommand IFM_dbCmd;
    //    IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);

    //    try
    //    {


    //        IFM_dbConn.Open();

    //        IFM_dbCmd = new SqlCommand("[USP_ValidateLogin_SMSSystem]", IFM_dbConn);
    //        IFM_dbCmd.CommandType = CommandType.StoredProcedure;
    //        IFM_dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = mUserName;
    //        IFM_dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = mPassword;
    //        //IFM_dbCmd.Parameters.Add("@vUserType", SqlDbType.Int).Value = 1;

    //        mMID = IFM_dbCmd.ExecuteScalar().ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //    finally
    //    {
    //        IFM_dbConn.Close();
    //    }


    //    if (mMID == "0")
    //    {
    //        // invalid login 
    //        ltrPerSec.Text = "Invalid Password ...";

    //    }
    //    else
    //    {

    //        string strURL = "http://210.5.45.47/hitechsms/ValidateUserLogin_FromMyHitech.aspx";

    //        HttpContext.Current.Response.Clear();
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<html>");
    //        sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
    //        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
    //        sb.AppendFormat("<input type='hidden' name='tmpMID' value='{0}'>", mMID);
    //        sb.AppendFormat("<input type='hidden' name='tmpUsrType' value='{0}'>", 1);
    //        sb.AppendFormat("<input type='hidden' name='tmpLoginFrom' value='{0}'>", "PSLOGIN");
    //        //sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
    //        // Other params go here
    //        sb.Append("</form>");
    //        sb.Append("</body>");
    //        sb.Append("</html>");

    //        HttpContext.Current.Response.Write(sb.ToString());
    //        //HttpContext.Current.Response.End();
    //        HttpContext.Current.ApplicationInstance.CompleteRequest();


    //    }



    //    #region --- Old Code Commented


    //    //String tmpUserPrefix = mUserName.Substring(0, 2);
    //    //string tmpForBruneiPrefix = mUserName.Substring(0, 3);
    //    //if (tmpForBruneiPrefix == "673")
    //    //    tmpUserPrefix = "673";

    //    //int UsrCountryCode = 0;


    //    ////if ((tmpUserPrefix == "60") || (tmpUserPrefix == "65") || (tmpUserPrefix == "62") || (tmpUserPrefix == "673"))
    //    //if (IsNumeric(tmpUserPrefix))
    //    //{
    //    //    UsrCountryCode = Convert.ToInt32(tmpUserPrefix);
    //    //}
    //    //else
    //    //{
    //    //    //..Check if the Login is Valid in the SpecialLogin Table. 

    //    //    SqlConnection IFM_dbConn;
    //    //    SqlCommand IFM_dbCmd;


    //    //    IFM_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);
    //    //    IFM_dbConn.Open();

    //    //    IFM_dbCmd = new SqlCommand("[USP_Verify_SpecialLoginNameCMS]", IFM_dbConn);
    //    //    IFM_dbCmd.CommandType = CommandType.StoredProcedure;
    //    //    IFM_dbCmd.Parameters.Add("@vLogin", SqlDbType.VarChar).Value = mUserName;


    //    //    mReturnedMobileNo = IFM_dbCmd.ExecuteScalar().ToString();

    //    //    if (mReturnedMobileNo == "00")
    //    //    {
    //    //        UsrCountryCode = 0;
    //    //    }
    //    //    else
    //    //    {
    //    //        UsrCountryCode = Convert.ToInt32(mReturnedMobileNo.Substring(0, 2));
    //    //        string tmpForBruneiPrefix2 = mReturnedMobileNo.Substring(0, 3);
    //    //        if (tmpForBruneiPrefix2 == "673")
    //    //            UsrCountryCode = 673;

    //    //        mUserName = mReturnedMobileNo;
    //    //    }
    //    //}


    //    //String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
    //    //strReferringURL = strReferringURL.Replace("http://", "");
    //    //int GetFirstSlashidx = strReferringURL.IndexOf(@":");
    //    //if (GetFirstSlashidx > 0)
    //    //    strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx);

    //    //string strURL = string.Empty;

    //    //if (UsrCountryCode == 66)
    //    //    UsrCountryCode = 60;


    //    //switch (UsrCountryCode.ToString())
    //    //{

    //    //    case "60":  /* Malaysia  */ strURL = "http://64.78.18.147/Hitech/Includes/1SmsWebsite_MAS_BizLoginCheck_Hitech.asp"; break;
    //    //    case "62":  /* Indonesia */ strURL = "http://64.78.18.147/smsIndonesia/Includes/1SmsWebsite_Indo_BizLoginCheck.asp"; break;
    //    //    case "65":  /* Singapore */ strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck_NEW.asp"; break;
    //    //    case "673": /* Brunei    */ strURL = "http://64.78.18.147/Hitech/Includes/SmsSystemLogin_Brunei.asp"; break;

    //    //}
    //    //Page.SmartNavigation = false;



    //    //HttpContext.Current.Response.Clear();
    //    //StringBuilder sb = new StringBuilder();
    //    //sb.Append("<html>");
    //    //sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
    //    //sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
    //    //sb.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", mUserName);
    //    //sb.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", mPassword);
    //    //sb.AppendFormat("<input type='hidden' name='MLoginFrom' value='{0}'>", "PSLOGIN");
    //    //sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
    //    //// Other params go here
    //    //sb.Append("</form>");
    //    //sb.Append("</body>");
    //    //sb.Append("</html>");

    //    //HttpContext.Current.Response.Write(sb.ToString());
    //    ////HttpContext.Current.Response.End();
    //    //HttpContext.Current.ApplicationInstance.CompleteRequest();
    //    #endregion





    //}
}

