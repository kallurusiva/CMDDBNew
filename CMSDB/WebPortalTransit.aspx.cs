using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPortalTransit : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();

        

        if ((Request.Form["pgFrom"] != null) && (Request.Form["pgFrom"] != ""))
        {
            Session["LoggedInFrom"] = Request.Form["pgfrom"].ToString();

            if ((Request.Form["pgFrom"] == "PG4MBIZ1975") || (Request.Form["pgFrom"] == "SMSSYSTEM") || (Request.Form["pgFrom"] == "SMSSYSTEM_WPY") || (Request.Form["pgFrom"] == "SMSSYSTEM_WPN"))
            {
                Log2AdminforUser(Request.Url.OriginalString);
            }
            else if (Request.Form["pgFrom"] == "PG4MeBook1975")
            {
                Log2Adminfor_eBookUser(Request.Url.OriginalString);
            }
            else if (Request.Form["pgFrom"] == "DPE")
            {
                Log2Adminfor_DPE(Request.Url.OriginalString);
            }

        }
        else
        {
            Response.Write("Error reaching the page.");
        }



    }



    protected void Log2AdminforUser(string inComingURL)
    {

        //inComingURL = "http://60163319165.1mybusiness.com";

        String tmpURL = inComingURL.Replace("http://", "");

        string tmpSubDomainURL = tmpURL;
        string[] MainURLArr = tmpURL.Split('.');
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


        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();



        dsCheck = objBAL_User.CheckUser_ValidateByMobileLogin(userSubDomainName);

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
            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
            Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
            string tmpOwnDomainName = UserRecord_Row["OwnDomain"].ToString();
            string tmpReferringURL = string.Empty;

            if (Request.Form["referringURL"] != null)
                tmpReferringURL = Request.Form["referringURL"].ToString();

            if (tmpReferringURL != "")
                tmpReferringURL = Server.UrlEncode(tmpReferringURL);


            String pPageTO = string.Empty;
            //String RedirectToPage = "NO";
            String RedirectToPage = String.Empty;

            if (Request.Form["PageTO"] != null)
                pPageTO = Request.Form["PageTO"].ToString();

            //if (pPageTO == "MOBILEWEB")
            //    RedirectToPage = "YES";


            String Post2URL = string.Empty;

            if (tmpOwnDomainName != "")
            {
                //   Response.Redirect("http://www." + tmpOwnDomainName + "/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL + "&WebRedirectTO=" + pPageTO + "&LoggedInFrom=" + Request.QueryString["pgFrom"].ToString());
                Post2URL = "http://www." + tmpOwnDomainName + "/pgFromASP.aspx";
            }
            else
            {
                Post2URL = "pgFromASP.aspx";
                // Response.Redirect("~/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL + "&WebRedirectTO=" + pPageTO + "&LoggedInFrom=" + Request.QueryString["pgFrom"].ToString());
            }



            String strLoggedinFrom = Request.Form["pgFrom"].ToString();

            HttpContext.Current.Response.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", Post2URL);
            sb.AppendFormat("<input type='hidden' name='qLoginID' value='{0}'>", Session["LoginID"].ToString());
            sb.AppendFormat("<input type='hidden' name='qMobileLoginID' value='{0}'>", Session["MobileLoginID"].ToString());
            sb.AppendFormat("<input type='hidden' name='WebRedirectTO' value='{0}'>", pPageTO);
            sb.AppendFormat("<input type='hidden' name='qLoginFrom' value='{0}'>", Session["LoggedInFrom"].ToString());
            sb.AppendFormat("<input type='hidden' name='qRefferringURL' value='{0}'>", tmpReferringURL);

            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();



        }
        else
        {
            // RegisterSubDomainPage(userSubDomainName);  
            if ((Request.Form["pgFrom"] == "SMSSYSTEM_WPY") || (Request.Form["pgFrom"] == "SMSSYSTEM_WPN"))
            {
                //..Take the User to SubDomain Registration 
                RegisterSubDomainPage(userSubDomainName);
            }
            else
            {
                RegisterSubDomainPage(userSubDomainName);
                //Response.Redirect("PartnerWebRegistrationNew.aspx");
            }

            //Response.Redirect("InValidDomain.aspx"); 


        }

    }


    protected void Log2Adminfor_eBookUser(string inComingURL)
    {

        String userSubDomainName = string.Empty;

        userSubDomainName = Request.Form["tmpLoginID"].ToString();
        userSubDomainName = "EB" + userSubDomainName; 
        Response.Write(userSubDomainName);
       

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();



        dsCheck = objBAL_User.CheckUser_ValidateByMobileLogin(userSubDomainName);

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
            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
            Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
            Session["MERID"] = Request.Form["tmpMerID"].ToString();

            string tmpOwnDomainName = UserRecord_Row["OwnDomain"].ToString();
            string tmpReferringURL = string.Empty;

            if (Request.Form["referringURL"] != null)
                tmpReferringURL = Request.Form["referringURL"].ToString();

            if (tmpReferringURL != "")
                tmpReferringURL = Server.UrlEncode(tmpReferringURL);


            String pPageTO = string.Empty;
            //String RedirectToPage = "NO";
            String RedirectToPage = String.Empty;

            if (Request.Form["PageTO"] != null)
                pPageTO = Request.Form["PageTO"].ToString();

          

            //if (pPageTO == "MOBILEWEB")
            //    RedirectToPage = "YES";


            String Post2URL = string.Empty;

            if (tmpOwnDomainName != "")
            {
                //   Response.Redirect("http://www." + tmpOwnDomainName + "/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL + "&WebRedirectTO=" + pPageTO + "&LoggedInFrom=" + Request.QueryString["pgFrom"].ToString());
                Post2URL = "http://www." + tmpOwnDomainName + "/pgFromASP.aspx";
            }
            else
            {
                Post2URL = "pgFromASP.aspx";
                // Response.Redirect("~/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL + "&WebRedirectTO=" + pPageTO + "&LoggedInFrom=" + Request.QueryString["pgFrom"].ToString());
            }

            String qMerchantID = Request.Form["tmpMerID"].ToString();
            //Response.Write(" MER ID : " + abc + ":");
            //Response.End(); 

            String strLoggedinFrom = Request.Form["pgFrom"].ToString();

            HttpContext.Current.Response.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", Post2URL);
            sb.AppendFormat("<input type='hidden' name='qLoginID' value='{0}'>", Session["LoginID"].ToString());
            sb.AppendFormat("<input type='hidden' name='qMobileLoginID' value='{0}'>", Session["MobileLoginID"].ToString());
            sb.AppendFormat("<input type='hidden' name='qMerID' value='{0}'>", qMerchantID);
            sb.AppendFormat("<input type='hidden' name='WebRedirectTO' value='{0}'>", pPageTO);
            sb.AppendFormat("<input type='hidden' name='qLoginFrom' value='{0}'>", strLoggedinFrom);
            sb.AppendFormat("<input type='hidden' name='qRefferringURL' value='{0}'>", tmpReferringURL);

            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();



        }
        else
        {
            // RegisterSubDomainPage(userSubDomainName);  
            if ((Request.Form["pgFrom"] == "SMSSYSTEM_WPY") || (Request.Form["pgFrom"] == "SMSSYSTEM_WPN"))
            {
                //..Take the User to SubDomain Registration 
                RegisterSubDomainPage(userSubDomainName);
            }
            else
            {
                RegisterSubDomainPage(userSubDomainName);
                //Response.Redirect("PartnerWebRegistrationNew.aspx");
            }

            //Response.Redirect("InValidDomain.aspx"); 


        }

    }


    protected void Log2Adminfor_DPE(string inComingURL)
    {


        String tmpURL = inComingURL.Replace("http://", "");

        string tmpSubDomainURL = tmpURL;
        string[] MainURLArr = tmpURL.Split('.');
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

        Response.Write(userSubDomainName);


        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();



        dsCheck = objBAL_User.CheckUser_ValidateByMobileLogin(userSubDomainName);

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
            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
            Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
            Session["MERID"] = Request.Form["tmpMerID"].ToString();

            string tmpOwnDomainName = UserRecord_Row["OwnDomain"].ToString();
            string tmpReferringURL = string.Empty;

            if (Request.Form["referringURL"] != null)
                tmpReferringURL = Request.Form["referringURL"].ToString();

            if (tmpReferringURL != "")
                tmpReferringURL = Server.UrlEncode(tmpReferringURL);


            String pPageTO = string.Empty;
            //String RedirectToPage = "NO";
            String RedirectToPage = String.Empty;

            if (Request.Form["PageTO"] != null)
                pPageTO = Request.Form["PageTO"].ToString();



            //if (pPageTO == "MOBILEWEB")
            //    RedirectToPage = "YES";


            String Post2URL = string.Empty;

            if (tmpOwnDomainName != "")
            {
                //   Response.Redirect("http://www." + tmpOwnDomainName + "/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL + "&WebRedirectTO=" + pPageTO + "&LoggedInFrom=" + Request.QueryString["pgFrom"].ToString());
                Post2URL = "http://www." + tmpOwnDomainName + "/pgFromDPE.aspx";
            }
            else
            {
                Post2URL = "pgFromDPE.aspx";
                // Response.Redirect("~/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL + "&WebRedirectTO=" + pPageTO + "&LoggedInFrom=" + Request.QueryString["pgFrom"].ToString());
            }

            String qMerchantID = Request.Form["tmpMerID"].ToString();
            //Response.Write(" MER ID : " + abc + ":");
            //Response.End(); 

            String strLoggedinFrom = Request.Form["pgFrom"].ToString();

            HttpContext.Current.Response.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", Post2URL);
            sb.AppendFormat("<input type='hidden' name='qLoginID' value='{0}'>", Session["LoginID"].ToString());
            sb.AppendFormat("<input type='hidden' name='qMobileLoginID' value='{0}'>", Session["MobileLoginID"].ToString());
            sb.AppendFormat("<input type='hidden' name='qMerID' value='{0}'>", qMerchantID);
            sb.AppendFormat("<input type='hidden' name='WebRedirectTO' value='{0}'>", pPageTO);
            sb.AppendFormat("<input type='hidden' name='qLoginFrom' value='{0}'>", strLoggedinFrom);
            sb.AppendFormat("<input type='hidden' name='qRefferringURL' value='{0}'>", tmpReferringURL);

            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();



        }
        else
        {
            // RegisterSubDomainPage(userSubDomainName);  
            if ((Request.Form["pgFrom"] == "SMSSYSTEM_WPY") || (Request.Form["pgFrom"] == "SMSSYSTEM_WPN"))
            {
                //..Take the User to SubDomain Registration 
                RegisterSubDomainPage(userSubDomainName);
            }
            else
            {
                RegisterSubDomainPage(userSubDomainName);
                //Response.Redirect("PartnerWebRegistrationNew.aspx");
            }

            //Response.Redirect("InValidDomain.aspx"); 


        }

    }


    protected void RegisterSubDomainPage(string vLoginID)
    {

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

        DataTable dtSubDomainStatus = new DataTable();

        DataSet dsSMScheck;
        dsSMScheck = objBAL_User.CheckSUbDomain_ValidateByMobile(vLoginID);

        dtSubDomainStatus = dsSMScheck.Tables[0];

        DataRow sbRow = dtSubDomainStatus.Rows[0];
        string SbStatus = sbRow["userStatus"].ToString();


        if (SbStatus == "NOTEXISTS")
        {
            //get the password, mobileloginid and country prefix; 

            CMSv3.Entities.MasUser objMasUser_SB = new CMSv3.Entities.MasUser();

            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(vLoginID, ref objMasUser_SB);

            string tmpMobileNo = objMasUser_SB.LoginID;
            String CountryCode = tmpMobileNo.Substring(0, 2);

            String sbPassword = objMasUser_SB.Password;
            String sbMobileLoginID = objMasUser_SB.LoginID;
            String sbMobileFullName = objMasUser_SB.MemberName;
            String sbEmail = objMasUser_SB.Email;
            String sbCompany = objMasUser_SB.Company;


            HttpContext.Current.Response.Clear();
            // string Mas1WebRegURL = "Mas1UserWebRegistration.aspx";
            string Mas1WebRegURL = "Mas1SubDomainReg.aspx";

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", Mas1WebRegURL);
            sb.AppendFormat("<input type='hidden' name='MasRegCountryPrefix' value='{0}'>", CountryCode);
            sb.AppendFormat("<input type='hidden' name='MasRegMobileID' value='{0}'>", vLoginID);
            sb.AppendFormat("<input type='hidden' name='MasRegPassword' value='{0}'>", sbPassword);
            sb.AppendFormat("<input type='hidden' name='MasRegPageFrom' value='{0}'>", Request.Form["pgFrom"].ToString());


            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());

            HttpContext.Current.Response.End();



        }


    }
}
