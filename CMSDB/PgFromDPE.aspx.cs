using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PgFromDPE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string qRefferringURL = string.Empty;

        
    // http://ringweb30.1argentinasms.com/pgFromASP.aspx?qUserID=111&qLoginID=ringweb30&qUserDomainType=WEB30&qMobileLoginID=60149664566&qRefferringURL=ringweb30.1argentinasms.com&WebRedirectTO=&LoggedInFrom=1MACC
    // http://lohcl.com/pgFromASP.aspx?qUserID=5931&qLoginID=lohchuenleong&qUserDomainType=PLATINUM&qMobileLoginID=6012308262305&qRefferringURL=lohchuenleong.1mybusiness.com&WebRedirectTO=&LoggedInFrom=1MACC

        
        string qLoginID = Request.Form["qMobileLoginID"].ToString();

       //  string qLoginID = Request.QueryString["qLoginID"].ToString();

        string qLoginFrom = Request.Form["qLoginFrom"].ToString(); 



        if (Request.Form["qRefferringURL"].ToString() != "")
            qRefferringURL = Request.Form["qRefferringURL"].ToString();


        Response.Write(qLoginID + "<br/>");
        Response.Write(qLoginFrom + "<br/>");
        Response.Write(qRefferringURL + "<br/>");
       // Response.End();

        //.. Before Redirecting Check if the User has registered a SubDomain. if NOT prompt message. 
        DataSet dsCheck;
        string strSQL = string.Empty;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        if(!qLoginID.Contains("DPE"))
            qLoginID = "DPE" + qLoginID; 

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


        if (UserStatus_Value == "MATCHED")
        {
            DataRow UserRecord_Row = dtUserRecord.Rows[0];

            Session["UserID"] = UserRecord_Row["UserID"].ToString();
            Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
            Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
            Session["defLanguage"] = UserRecord_Row["LanguageCode"].ToString();
            Session["LoggedInFrom"] = qLoginFrom;
            Session["referringURL"] = qRefferringURL;
            

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


            CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), qLoginID);
            Response.Redirect("~/Admin/Ad_WelcomeDPE.aspx");
        }
        else
        {
            CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
        }


        //http://sms.1argentinasms.com/pgFromAsp.aspx?qUserID=160&qLoginID=sms&qUserDomainType=DIAMOND&qMobileLoginID=60172196504&qRefferringURL=www.1smsbusiness.com
        //http://sms.1argentinasms.com/pgFromASP.aspx?qUserID=160&qLoginID=sms&qUserDomainType=DIAMOND&qMobileLoginID=60172196504&qRefferringURL=sms.1argentinasms.com

    }
}
