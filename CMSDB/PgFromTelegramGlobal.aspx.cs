using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PgFromTelegramGlobal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string qRefferringURL = string.Empty;
        string qLoginFrom = Request.Form["qLoginFrom"].ToString();
        string qLoginID = String.Empty;
        string pg = Request.Form["pg"].ToString();

        if (qLoginFrom == "PG4MDPE1975")
        {
            qLoginID = Request.Form["qMobileLoginID"].ToString();
        }
        else
        {
            qLoginID = Request.Form["tmpLoginID"].ToString();

            if (!qLoginID.Contains("EB"))
                qLoginID = "EB" + qLoginID;
        }

        string qMerchantID = Request.Form["tmpMerID"].ToString();
        string qPackageType = Request.Form["tmpPackageType"].ToString();

        if (Request.Form["qRefferringURL"].ToString() != "")
            qRefferringURL = Request.Form["qRefferringURL"].ToString();

        //.. Before Redirecting Check if the User has registered a SubDomain. if NOT prompt message. 
        DataSet dsCheck;
        string strSQL = string.Empty;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

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
        //Response.Write(UserStatus_Value + "<br/>");


        if (UserStatus_Value == "MATCHED")
        {
            DataRow UserRecord_Row = dtUserRecord.Rows[0];

            Session["UserID"] = UserRecord_Row["UserID"].ToString();
            Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
            Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
            Session["defLanguage"] = "en-US";
            Session["LoggedInFrom"] = qLoginFrom;
            Session["referringURL"] = qRefferringURL;
            Session["MERID"] = qMerchantID;
            Session["PackageType"] = qPackageType;

            string ADomain = UserRecord_Row["ADomain"].ToString();



            String usrSubDomain = UserRecord_Row["SubDomain"].ToString();
            String usrOwnDomain = UserRecord_Row["OwnDomain"].ToString();
            String yourSampleURL = string.Empty;

            if ((usrOwnDomain != null) && (usrOwnDomain != ""))
            {
                yourSampleURL = "http://www." + usrOwnDomain;
            }
            else
            {
                if (ADomain != "")
                {
                    yourSampleURL = "http://" + usrSubDomain + "." + ADomain.ToString();
                }
                else
                {
                    yourSampleURL = "http://" + usrSubDomain + ".eVenchise.com";
                }
            }

            Session["UserDomainURL"] = yourSampleURL;


            CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), qLoginID);


            String vComingFrom = string.Empty;

            if (qLoginFrom == "PG4MeBook1975")
            {
                Response.Redirect("~/Admin/" + pg.ToString());
            }
            else
            {
                Response.Redirect("~/Admin/" + pg.ToString());
            }


        }
        else
        {
            CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
        }


        //http://sms.1argentinasms.com/pgFromAsp.aspx?qUserID=160&qLoginID=sms&qUserDomainType=DIAMOND&qMobileLoginID=60172196504&qRefferringURL=www.1smsbusiness.com
        //http://sms.1argentinasms.com/pgFromASP.aspx?qUserID=160&qLoginID=sms&qUserDomainType=DIAMOND&qMobileLoginID=60172196504&qRefferringURL=sms.1argentinasms.com

    }
}
