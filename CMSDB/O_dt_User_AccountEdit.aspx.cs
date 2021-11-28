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

public partial class O_dt_User_AccountEdit : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }

        if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
        {
            CommonFunctions.AlertMessageAndRedirect("Please Login to check Credit Info", "O_dt_User_Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                ViewState["FormViewMode"] = "";
                LoadProfileView();
            }
        }
    }

    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FormView1.ChangeMode(e.NewMode);
        LoadProfileView();
    }


    protected void LoadProfileView()
    {
        newDBS ndbsR = new newDBS();
        ds = ndbsR.user_getProfile(Session["cLogin"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow1 = ds.Tables[0].Rows[0];

            string fullname = utRow1["fullname"].ToString();
            string Address = utRow1["Address"].ToString();
            string country = utRow1["country"].ToString();
            string state = utRow1["state"].ToString();
            string city = utRow1["city"].ToString();
            string zip = utRow1["zip"].ToString();
            string Telephone = utRow1["Telephone"].ToString();
            string Fax = utRow1["Fax"].ToString();
            string Email = utRow1["Email"].ToString();

            if (ViewState["FormViewMode"].ToString() == "")
            {
                FormView1.ChangeMode(FormViewMode.Edit);
            }
            else
            {
                FormView1.ChangeMode(FormViewMode.ReadOnly);
                FormView1.Visible = false;
            }
        }

        FormView1.DataSource = ds;
        FormView1.DataBind();
    }

    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (FormView1.CurrentMode == FormViewMode.Edit)
        {

        }
    }


    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        TextBox lblFullName = (TextBox)FormView1.FindControl("lblFullName");
        TextBox lblCountry = (TextBox)FormView1.FindControl("lblCountry");
        TextBox lblAddress = (TextBox)FormView1.FindControl("lblAddress");
        TextBox lblState = (TextBox)FormView1.FindControl("lblState");
        TextBox lblCity = (TextBox)FormView1.FindControl("lblCity");
        TextBox lblZip = (TextBox)FormView1.FindControl("lblZip");
        TextBox lblTelephone = (TextBox)FormView1.FindControl("lblTelephone");
        TextBox lblFax = (TextBox)FormView1.FindControl("lblFax");



        if (lblFullName.Text.ToString() == "")
        {
            CommonFunctions.AlertMessage("Required FullName.");
        }
        else if (lblCountry.Text.ToString() == "")
        {
            CommonFunctions.AlertMessage("Required Country.");
        }
        else
        {
            newDBS ndbs = new newDBS();
            int result = ndbs.user_updateProfile(Session["cLogin"].ToString(), lblFullName.Text, lblAddress.Text, lblCountry.Text, lblState.Text, lblCity.Text, lblZip.Text, lblTelephone.Text, lblFax.Text);
            //CommonFunctions.AlertMessage("Profile updated successfully.");
            CommonFunctions.AlertMessageAndRedirect("Profile updated successfully.", "O_dt_User_Account.aspx");
        }

    }   

    protected void StoreBuyerDetails(String vbFullName, String vbMobile, String vbEmail, int vClientId, String vTranID)
    {
        //...Create new user if not exists (check against emailid as unique) 
        //...
        newDBS clsObjNewDbs = new newDBS();
        int inStatus = clsObjNewDbs.ebook_Bank_Client_StoreBuyer(vbFullName, vbMobile, vbEmail, vClientId, vTranID);
        // int inStatus = objBALebook.Bank_Client_StoreBuyer(vbFullName, vbMobile, vbEmail, vClientId, vTranID); 
    }

    protected void GetVendorInfo(ref string vVendorEmailID)
    {
        //...Get Estore ID and Email Address of the User
        int vUserID = Convert.ToInt32(Session["ClientID"].ToString());

        DataSet ds = objBALebook.Bank_GetUserInfo(vUserID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dRow = ds.Tables[0].Rows[0];
            String vVendorMobile = dRow["userMobile"].ToString();
            vVendorEmailID = dRow["eMailID"].ToString();
        }
    }

    public int GetUserIdfromURL()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;
        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();
        string tmpMainURL = Request.Url.OriginalString;
        string OrgURL = Request.Url.OriginalString;
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


}