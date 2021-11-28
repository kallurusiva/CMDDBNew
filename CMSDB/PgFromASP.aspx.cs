using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PgFromASP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string qRefferringURL = string.Empty;

        
    // http://ringweb30.1argentinasms.com/pgFromASP.aspx?qUserID=111&qLoginID=ringweb30&qUserDomainType=WEB30&qMobileLoginID=60149664566&qRefferringURL=ringweb30.1argentinasms.com&WebRedirectTO=&LoggedInFrom=1MACC
    // http://lohcl.com/pgFromASP.aspx?qUserID=5931&qLoginID=lohchuenleong&qUserDomainType=PLATINUM&qMobileLoginID=6012308262305&qRefferringURL=lohchuenleong.1mybusiness.com&WebRedirectTO=&LoggedInFrom=1MACC

        // Request.Form["Muser"].ToString().Trim();

         //Response.Flush();
        
        //string qUserID = Request.Form["qUserID"].ToString();
        
       // string qUserDomainType = Request.Form["qUserDomainType"].ToString();


         string qLoginID = Request.Form["qLoginID"].ToString();
         string qMobileLoginID = Request.Form["qMobileLoginID"].ToString();
        

        if (Request.Form["qRefferringURL"].ToString() != "")
            qRefferringURL = Request.Form["qRefferringURL"].ToString();

        if (Request.Form["qLoginFrom"] != null)
        {
            if (Request.Form["qLoginFrom"].ToString() != "")
                Session["LoggedInFrom"] = Request.Form["qLoginFrom"].ToString(); 
        }


        //if(Request.Form["qLoginFrom"] != null)
        //{
        //    if(Request.Form["qLoginFrom"].ToString() != "")
        //        Session["LoggedInFrom"] = Request.Form["qLoginFrom"].ToString(); 
        //}

        string RedirectToPage = string.Empty;

        if (Request.Form["WebRedirectTO"].ToString() != "")
            RedirectToPage = Request.Form["WebRedirectTO"].ToString();


      
       

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        DataSet dsCheck;
        string strSQL = string.Empty;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        dsCheck = objUser.CheckUser_ValidateByMobileLogin(CommonFunctions.SafeSql(qLoginID));

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
            Session["referringURL"] = qRefferringURL;
            //Session["MERID"] = qMerchantID; 


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




            //CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
            //Response.Redirect("~/Admin/Ad_Welcome.aspx");

        }
        else
        {
            CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
        }





        //..Find if the user is an WebEmailSMS (SME) user. 




        //if (RedirectToPage == "NO")
        //    Response.Redirect("~/Admin/Ad_Welcome.aspx");
        //else
        //    Response.Redirect("~/Admin/Mobile/Ad_MobileHome3.aspx");
        String vComingFrom = string.Empty;

        if (Request.Form["qLoginFrom"] != null)
        {
            if (Request.Form["qLoginFrom"].ToString() != "")
                vComingFrom = Request.Form["qLoginFrom"].ToString();

            if (vComingFrom == "PG4MeBook1975")
                RedirectToPage = "EBOOK";
        }



        switch (RedirectToPage)
        {
            case "MOBILEWEB": Response.Redirect("~/Admin/Mobile/Ad_MobileHome3.aspx");
                break;
            case "ADSENSE": Response.Redirect("~/Admin/AdSense/Ads_AdSensePage.aspx");
                break;
            case "EMAILSYS": Response.Redirect("~/Admin/AdSense/Ads_EmailPage.aspx");
                break;
            case "PREMIUMSMS": Response.Redirect("~/Admin/PremiumSMS/Ad_Ps_Welcome.aspx");
                break;
            case "EBOOK": Response.Redirect("~/Admin/Ad_WelcomeEbook.aspx");  //Response.Redirect("~/Admin/EbAd_DashBoard.aspx");
                break;
            case "EBOOKSTORE": Response.Redirect("~/Admin/Ad_WelcomeEbook.aspx");  //Response.Redirect("~/Admin/EbAd_DashBoard.aspx");
                break;
            default:
                Response.Redirect("~/Admin/Ad_Welcome.aspx");
                break;
        }


        //Response.Write(qLoginID + "<br>");
        //Response.Write(qMobileLoginID + "<br>");
        //Response.Write(qRefferringURL + "<br>");
        //Response.Write(RedirectToPage + "<br>");
        //Response.End(); 

        //http://sms.1argentinasms.com/pgFromAsp.aspx?qUserID=160&qLoginID=sms&qUserDomainType=DIAMOND&qMobileLoginID=60172196504&qRefferringURL=www.1smsbusiness.com
        //http://sms.1argentinasms.com/pgFromASP.aspx?qUserID=160&qLoginID=sms&qUserDomainType=DIAMOND&qMobileLoginID=60172196504&qRefferringURL=sms.1argentinasms.com

    }
}
