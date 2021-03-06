using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using CMSv3.BAL;
using System.Threading;
using System.Configuration;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;

public partial class O_dt_User_Login : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    //SqlDataReader dbReader;
    string buyerMsg;
    string buyerStatus;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        if (!IsPostBack)
        {
            newDBS ndbsL = new newDBS();
            DataSet dstL = ndbsL.buyer_getFreezeLoginStatus("0");
            if (dstL.Tables[0].Rows.Count > 0)
            {
                DataRow dRow = dstL.Tables[0].Rows[0];
                buyerMsg = dRow["Buyer"].ToString();
                buyerStatus = dRow["BuyerLoginReg"].ToString();

                if (buyerStatus.ToString() == "1")
                {
                    CommonFunctions.AlertMessage(buyerMsg.ToString());
                    btnLogin.Visible = false;
                }
            }

            if ((Session["navcheckout"] == null) || (Session["navcheckout"].ToString() == ""))
            {
                Session["navcheckout"] = "0";
            }
            Nreg.HRef = "O_dt_User_Registration.aspx";
        }
    }


    public int GetUserIdfromURL()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;
        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();
        string tmpMainURL = Request.Url.OriginalString.ToString();
        string OrgURL = Request.Url.OriginalString.ToString();

        //tmpMainURL = "www.testhari88.com";
        //tmpMainURL = "eb60123238595.1smsbusiness.com";
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
                CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                //..function get all the details of 1malaysia user into MasUser entity 
                MasFunc.Get_1MalaysiaUser_Details(userSubDomainName, ref objMasUser);

                //if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
                Session["MasUSER"] = objMasUser;
                //.................................................................
                if (objMasUser.MID != "NONE")
                {
                    //Response.Redirect("Mas1UserWebRegistration.aspx");
                }
            }
        }
        else
        {
            //owndomain  or subDomain ??
            //string ownDomain = tmpMainURL;
            string[] OwnURLArr = tmpMainURL.Split('.');
            string userOwnDomainName = string.Empty;
            int DomainType = -1;
            // see if user has typed in www
            if (OwnURLArr[0].ToString() == "www")
            {
                userOwnDomainName = OwnURLArr[1].ToString();
                if (OwnURLArr.Count() > 4)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain
            }
            else
            {
                userOwnDomainName = OwnURLArr[0].ToString();
                if (OwnURLArr.Count() > 3)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain

            }
            //..user comes to his sub domain
            newUserID = objBAL_User.GetUserID_BySubDomainName2(userOwnDomainName, DomainType);
            CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
            CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(userOwnDomainName, ref objMasUser);
            // if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
            Session["MasUSER"] = objMasUser;
            //    //.................................................................

            if (objMasUser.MID != "NONE")
            {
                // Response.Redirect("Mas1UserWebRegistration.aspx");
                //String WebRegURL = "Mas1UserWebRegistration.aspx";
                //StringBuilder sburl = new StringBuilder();
                //sburl.Append("<script>");
                //sburl.Append("window.open('page.html','_blank')");
                //sburl.Append("</script>");
                //Response.Write(sburl.ToString());
                //Response.End();
                //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", WebRegURL));
            }
        }

        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {
            Response.Redirect("PartnerWebRegistrationNew.aspx");
            //Response.Redirect("InValidDomain.aspx");
        }
        return newUserID;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string mUserName = txtUserName.Text;
        string mPassword = txtPassword.Text;
        string mMID = string.Empty;
        string freezeStatus = "0";
        string freezeMessage = "";

        newDBS ndb = new newDBS();
        DataSet ds2 = ndb.ebook_getLoginValidateDetails(mUserName.ToString(), mPassword.ToString(), Session["ClientID"].ToString());
        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            mMID = krow["userid"].ToString();
            freezeStatus = krow["freezeStatus"].ToString();
            freezeMessage = krow["freezeMessage"].ToString();
        }

        if (mMID == "0")
        {
            CommonFunctions.AlertMessage("Invalid Login/IDPassword ...");
        }
        else if (freezeStatus.ToString() == "1")
        {
            CommonFunctions.AlertMessage(freezeMessage.ToString());
        }
        else
        {
            string storeidVal = string.Empty;
            newDBS ndspp = new newDBS();
            storeidVal = ndspp.user_getStoreID(Convert.ToInt32(Session["ClientID"].ToString()));
            Session["navcheckout"] = "1";
            Session["cLogin"] = storeidVal + "-" + mUserName.ToString();
            if (Session["navcheckout"].ToString() == "1")
            {
                Response.Redirect("O_dtCart.aspx");
            }
            else
            {
                Response.Redirect("O_dtList.aspx");
            }
            
        }

    }
}