using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PgFromTestLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string qRefferringURL = string.Empty;
        string qLoginID = String.Empty;
        string qLoginFrom = String.Empty;

        qLoginFrom = "";
        qLoginID = "EB60126583065";
        string qMerchantID = "131558";
        string qPackageType = "2";        

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

            yourSampleURL = "http://cmsdb.gsprocess.com";
            Session["UserDomainURL"] = yourSampleURL;
            CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), qLoginID);
            String vComingFrom = string.Empty;

            Response.Redirect("~/Admin/EBAd_birthdaymonthlist.aspx");
        }
        else
        {
            CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
        }
    }
}
