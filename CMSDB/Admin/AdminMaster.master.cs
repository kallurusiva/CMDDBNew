using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using CMSv3.Entities;
using System.Threading;
using System.Globalization;
using System.IO;



public partial class Admin_AdminMaster : System.Web.UI.MasterPage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    CMSv3.BAL.User BALobjUser = new CMSv3.BAL.User();
    string tmpUserType = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {


        //..Check for SubDomain and Domain URLs on Every Page. 

        //Response.Write(Request.Url.OriginalString); 
        

        string isDemo = ConfigurationManager.AppSettings["isDemo"].ToString();

        //if (isDemo == "true")
        //{
        //    //Session["ClientID"] = Convert.ToInt32(GlobalVar.GetTestLoginUser);
        //}
        //else
        //{
        //    CheckLocationBarURL(Convert.ToInt32(Session["UserID"]));
        //}


        ltrMyBtn1.Text = Resources.LangResources.MyButton + " 1";
        ltrMyBtn2.Text = Resources.LangResources.MyButton + " 2";
        ltrMyBtn3.Text = Resources.LangResources.MyButton + " 3";
        ltrMyBtn4.Text = Resources.LangResources.MyButton + " 4";
        ltrMyBtn5.Text = Resources.LangResources.MyButton + " 5";
        ltrMyBtn6.Text = Resources.LangResources.MyButton + " 6";
        ltrMyBtn7.Text = Resources.LangResources.MyButton + " 7";
        ltrMyBtn8.Text = Resources.LangResources.MyButton + " 8";


        string tmpLoggedINfrom2 = Session["LoggedInFrom"].ToString();
        Response.Write("$" + tmpLoggedINfrom2 + "$");


        if (!IsPostBack)
        {
           
            String tmpAdminLanguageCode = string.Empty;
            

            if (Session["UserDomainType"] == null)
            {
                //get and set  the session details

                string strSQL = "EXEC Usp_CMS_GetUserDetailsByUserID " + Convert.ToInt32(Session["UserID"]);

                dbConn = new SqlConnection(GlobalVar.GetDbConnString);

                try
                {
                    dbConn.Open();
                    dbCmd = new SqlCommand(strSQL, dbConn);
                    dbReader = dbCmd.ExecuteReader();

                    if (dbReader.HasRows)
                    {
                        while (dbReader.Read())
                        {

                            Session["UserDomainType"] = dbReader["UserDomainType"].ToString();
                            tmpUserType = Session["UserDomainType"].ToString();
                            Session["defLanguageCode"] = dbReader["AdminLanguage"].ToString();

                            

                        }

                    }


                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    dbConn.Close();
                }


                //tmpUserType
            }
            else
            {
                tmpUserType = Session["UserDomainType"].ToString();
            }


            



            if (Session["MobileLoginID"] != null)
            {
                RenderDomainsAndLinks(Session["MobileLoginID"].ToString());
                dvSMSBizLink.Visible = true;
                dvSMSsystemLink.Visible = true;

                if (tmpUserType == "SME")
                {
                   // HypLnkAdSense.Visible = false;
                    dvSMSBizLink.Visible = false;
                    dvPremiumSMS.Visible = false; 
                }
           
            }
            else
            {
                dvSMSBizLink.Visible = false;
                dvSMSsystemLink.Visible = false;
                ltrYourWebSiteHeader.Visible = false;
                dvPremiumSMS.Visible = false; 
               // dvYourWebSiteLinks.Visible = false;
            }

            if (Session["LoggedInFrom"] != null)
            {
                string tmpLoggedINfrom = Session["LoggedInFrom"].ToString();
                Response.Write(tmpLoggedINfrom);

                if (tmpLoggedINfrom == "SMSSYSTEM_WPY")
                {
                    dvSMSBizLink.Visible = false;
                    dvPremiumSMS.Visible = false; 
                }
                else if (tmpLoggedINfrom == "WEBPORTAL")
                {
                    dvSMSBizLink.Visible = false;
                    dvPremiumSMS.Visible = false;
                    dvSMSsystemLink.Visible = false;
                }
                else if(tmpLoggedINfrom == "PG4MeBook1975")
                {
                    dvSMSBizLink.Visible = false;

                }

            }

        }

        //Hiding them 
        ltrYourWebSiteHeader.Visible = false;
       // dvYourWebSiteLinks.Visible = false;
        //dvSMSBizLink.Visible = true;
        // dvSMSsystemLink.Visible = true;


        if (tmpUserType == "SME")
        {
           // HypLnkAdSense.Visible = false;
            dvSMSsystemLink.Visible = true;
        }

       

        //... Code commented as.. All the Menu buttons are now available to ALl the Users

        //if (tmpUserType == "WEB10")
        //{
            
        //    HypMenuBtn2.Attributes.Add("onclick", "Javascript: fnShowWEB10Alert()");
        //    HypMenuBtn3.Attributes.Add("onclick", "Javascript: fnShowWEB10Alert()");

        //    HypMenuBtn2.NavigateUrl = "#";
        //    HypMenuBtn3.NavigateUrl = "#";
        //}
      
    }

    protected void RenderDomainsAndLinks(string vMobileLoginID)
    {

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();



        dsCheck = objBAL_User.CheckUser_ValidateByMobileLogin(vMobileLoginID);

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

            string tmpOwnDomainName = UserRecord_Row["OwnDomain"].ToString();
            string tmpSubDomainName = UserRecord_Row["SubDomain"].ToString();
            string tmpAnchorDomain  = UserRecord_Row["AnchorDomain"].ToString();

            String UrlSubDomainName1 = string.Empty;

            if (tmpAnchorDomain != "")
            {
                UrlSubDomainName1 = tmpSubDomainName + "." + tmpAnchorDomain;
            }
            else
            {
                UrlSubDomainName1 = tmpSubDomainName + "." + GlobalVar.GetAnchorDomainName;
            }
            
            
            //string UrlSubDomainName2 = vMobileLoginID + "." + GlobalVar.GetAnchorDomainName;
            String UrlSubDomainName2 = tmpSubDomainName + "." + "1amwaywebsite.com";
            String UrlSubDomainName3 =  tmpSubDomainName + "." + "1financialconsultant.com";
            String UrlAncLinks = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>" +
                                  "<br/>" +
                                  "<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName3 + "'>" + UrlSubDomainName3 + "</a>";


            if (tmpOwnDomainName != "")
            {
                tmpOwnDomainName = "www." + tmpOwnDomainName;

               // lblOwnDomainName.Text = @"<a target='_blank' class='links_DomainName' href='http://" + tmpOwnDomainName + "'>" + tmpOwnDomainName + "</a>" + " <br />";
            }
           // lblOwnDomainName.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>" + " <br />";
            //lblSubDomain1.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>" + UrlSubDomainName1 + "</a>" + " <br />";
            //lblSubDomain2.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>";
            //lblSubDomain2.Text = @"<a target='_blank' class='links_DomainName' alt='Click to view more of your SubDomains List' href='Ad_DomainsListSubs.aspx'>" + UrlSubDomainName2 + "</a>";
          //  HypYourSubDomains.Text = UrlSubDomainName1 + "<br/>" + "...Click to view more SubDomainLinks"; //+ "<br/>" + UrlSubDomainName3;


            if (tmpOwnDomainName != "")
                lblUserURL.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + tmpOwnDomainName + "'>" + tmpOwnDomainName + "</a>" + " <br />";
            else
                lblUserURL.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>" + UrlSubDomainName1 + "</a>" + " <br />";

        }


    }

    protected void lnkSMSBusiness_Click(object sender, EventArgs e)
    {
        string tmpMobileLogin = string.Empty;

        if (Session["MobileLoginID"] != null)
        tmpMobileLogin = Session["MobileLoginID"].ToString();
       



        //get username and password 

        if(tmpMobileLogin != string.Empty)
        {
        CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
        

        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        dsCheck = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing_ByMobileLoginID(tmpMobileLogin);

        if (dsCheck.Tables[0].Rows.Count > 0)
        {

            DataRow UserStatus_Row = dsCheck.Tables[0].Rows[0];

            string tmpMuserName = UserStatus_Row["Login_ID"].ToString();
            string tmpMPassword = UserStatus_Row["Password"].ToString();

            string tmpCountryPrefix = tmpMuserName.Substring(0, 2);

            if (tmpCountryPrefix == "60")
            {
                //redirect to 1malaysia
                string strURL = "http://64.78.18.32/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=" + tmpMuserName + "&Mpwd=" + tmpMPassword;
                Response.Redirect(strURL);
            }
            else
            {
                //redirect to 1singapore 
                string strURL = "http://64.78.18.32/singapore/1SMSWebSite_BizMemberCheckSGD.asp?Muser=" + tmpMuserName + "&Mpwd=" + tmpMPassword;
                Response.Redirect(strURL);
            }


        }



        }







    }


    protected void lnkSMSSystem_Click(object sender, EventArgs e)
    {



        string tmpMobileLogin = string.Empty;

        if (Session["MobileLoginID"] != null)
            tmpMobileLogin = Session["MobileLoginID"].ToString();

        //get username and password 

        if (tmpMobileLogin != string.Empty)
        {
            CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();


            DataSet dsCheck;
            DataTable dtUserRecord = new DataTable();
            DataTable dtUserStatus = new DataTable();

            dsCheck = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing_ByMobileLoginID(tmpMobileLogin);

            if (dsCheck.Tables[0].Rows.Count > 0)
            {

                DataRow UserStatus_Row = dsCheck.Tables[0].Rows[0];

                string tmpMuserName = UserStatus_Row["Login_ID"].ToString();
                string tmpMPassword = UserStatus_Row["Password"].ToString();

                string tmpCountryPrefix = tmpMuserName.Substring(0, 2);

                if (tmpCountryPrefix == "60")
                {
                    //redirect to 1malaysia
                    string strURL = "http://64.78.18.147/SMSMLMNEW/Includes/1SmsWebsite_MAS_BizLoginCheck.asp?Muser=" + tmpMuserName + "&Mpwd=" + tmpMPassword + "&txtLanguage=E";
                    Response.Redirect(strURL);
                }
                else
                {
                    //redirect to 1singapore 
                    string strURL = "http://64.78.18.147/smsSingapore/Includes/1SMSwebsite_Sing_BizLoginCheck.asp?Muser=" + tmpMuserName + "&Mpwd=" + tmpMPassword + "&txtLanguage=E";
                    Response.Redirect(strURL);
                }


            }




        }
    }


    protected void CheckLocationBarURL(int vLoggedInUserID)
    {
        //function Checks the Location BAR URL and determines if the subdomain or domain exists 
        int newUserID = 0;

        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();


        string tmpMainURL = Request.Url.OriginalString;
        string OrgURL = Request.Url.OriginalString;
        //tmpMainURL = "http://60122577907.1smsbusiness.com";
        //tmpMainURL = "http://60123803344.1smsbusiness.com";

        //string tmpMainURL = "http://ringweb30.1smsbusiness.com";
        

        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

        if (tmpMainURL.Contains(OurWebSiteName))
        {
            //subdomain
            string tmpSubDomainURL = tmpMainURL;
            string[] MainURLArr = tmpMainURL.Split('.');
            string userSubDomainName = string.Empty;

            // see if user has typed in www
            if (MainURLArr[0].ToString() == "www")
            {
                userSubDomainName = MainURLArr[1].ToString();
            }
            else
            {
                userSubDomainName = MainURLArr[0].ToString();
            }


            if (userSubDomainName == OurWebSiteName)
            {
                //..user comes to direct website setting the userid to demo as default
                newUserID = 105;
            }
            else
            {

                //..user comes to his sub domain
                newUserID = objBAL_User.GetUserID_BySubDomainName(userSubDomainName);


            }

        }
        else
        {
            //owndomain
            string ownDomain = tmpMainURL;
            string[] OwnURLArr = tmpMainURL.Split('.');
            string userOwnDomainName = string.Empty;


            // see if user has typed in www
            if (OwnURLArr[0].ToString() == "www")
            {
                userOwnDomainName = OwnURLArr[1].ToString();
            }
            else
            {
                userOwnDomainName = OwnURLArr[0].ToString();
            }

            //..user comes to his sub domain
            newUserID = objBAL_User.GetUserID_BySubDomainName(userOwnDomainName);

      

        }
        Response.Write(newUserID + "|" + vLoggedInUserID); 
        if (newUserID == 0)
        {
            //Response.Redirect("PartnerWebRegistrationNew.aspx");
            Response.Redirect("~/InValidDomain.aspx");
        }
        else if (newUserID != vLoggedInUserID)
        {
            Response.Redirect("~/SessionExpire.aspx");
        }

        

    }

    
}
