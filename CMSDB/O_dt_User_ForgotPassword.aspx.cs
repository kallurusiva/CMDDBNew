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
using RestSharp;
using RestSharp.Authenticators;

public partial class O_dt_User_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        if (!IsPostBack)
        {
            //if (Request.QueryString["CpUri"] != null)
            //    ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString();
            //else
            //    ViewState["CallingPage"] = "";
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

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        string tmpUserID = txtPerSecUserID.Text;
        SendEMAIL_Registration(tmpUserID);
    }

    protected void SendEMAIL_Registration(string vuserid)
    {
        newDBS clsObjNewDbs = new newDBS();
        DataSet ds;

        string storeidVal = string.Empty;
        newDBS ndspp = new newDBS();
        storeidVal = ndspp.user_getStoreID(Convert.ToInt32(Session["ClientID"].ToString()));
        ds = clsObjNewDbs.user_getSendEmailRegInfo(storeidVal + "-" + vuserid.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow1 = ds.Tables[0].Rows[0];

            String userid = utRow1["userid"].ToString();
            String password = utRow1["password"].ToString();
            String Email = utRow1["Email"].ToString();
            String fullname = utRow1["fullname"].ToString();
            String mobile = utRow1["mobile"].ToString();
            String domain = utRow1["domain"].ToString();

            if (userid == "")
            {
                CommonFunctions.AlertMessage("Invalid LoginId. Please provide LoginID");
            }
            else
            {
                clsObjNewDbs.user_forgotPasswordSendSMS(storeidVal + "-" + vuserid.ToString());

                String strMsg1 = "Hi " + fullname + ",";
                strMsg1 = strMsg1 + "<br><br>";
                strMsg1 = strMsg1 + "Your Login Information is as below:";
                strMsg1 = strMsg1 + "<br><br>";
                strMsg1 = strMsg1 + "Website: " + domain.ToString();
                strMsg1 = strMsg1 + "<br>";
                strMsg1 = strMsg1 + "LoginID: " + vuserid.ToString();
                strMsg1 = strMsg1 + "<br>";
                strMsg1 = strMsg1 + "Password: " + password;
                strMsg1 = strMsg1 + "<br>";
                strMsg1 = strMsg1 + "Mobile No: " + mobile;
                strMsg1 = strMsg1 + "<br><br><br>";
                strMsg1 = strMsg1 + "Thank You";
                strMsg1 = strMsg1 + "<br>";
                strMsg1 = strMsg1 + "Evenchise Team";

                String Contact_EmailBody = strMsg1;

                sendMail(Email, "noreply@ebooksmsdelivery.com", Contact_EmailBody, domain + " - Forget Password", fullname, "", "");
            }
        }
        else
        {
            CommonFunctions.AlertMessage("Invalid LoginId. Please provide LoginID");
        }
    }

    protected void sendMail(string VEmailTO, string VEmailFrom, string vEmailBody, string vEmailSubject, string vEmailToFullName, string vField1, string vField2)
    {
        string tmpHtmlBody = @"
    <html xmlns='http://www.w3.org/1999/xhtml'>
    <head>
    <title></title>
    <style type='text/css'>
    .style2        {            height: 18px;        }
    .font_12BlueBold	{ FONT-SIZE: 12px;  font-weight:bold; COLOR: #2291A1; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
    .font_12Normal		{ FONT-SIZE: 12px; COLOR: #03C0C6; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
    .stdtableBorder_Main		{ background-color:#FAFCFA; border: #CDF2D6 1px solid; FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
    .stdtableBorder_Search		{ background-color:#F7F9E5; BORDER-BOTTOM: #b8e0fb 1px solid; BORDER-TOP: #b8e0fb 1px solid; width:98%;
                      		       FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
    .SearchLabelBold        {height:25px; FONT-SIZE: 12px; COLOR: #221F0B; padding-left:10px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif; font-weight:bold;}
    .SearchLabel            {height:25px; text-align:left; FONT-SIZE: 12px; COLOR: #44412F; padding-left:5px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif;}

    .bkgFooter		    {background-color:#D0EBBF;}

    .std_table_Email{border:1px solid #D4E594;background-color:#fff;padding-left:10px;padding-right:10px;line-height:23px;}
    .std_table_Email_Row{border-bottom:1px solid #D4E594;font-family:Arial;font-weight:bold;font-size:11px;line-height:18px;background-color:#f1f0f0}
    .txtBlueMedium{font-family:Arial;font-size:12px;color:#0066FF;text-decoration:none;}

    </style>
</head>
<body>
    <div>
     <table cellpadding='0' cellspacing='0' width='600px' class='stdtableBorder_Main'>
        <tr height='0px'>
            <td width='3%'>
                </td>
            <td width='94%'>
                </td>
            <td width='3%'>
                </td>
        </tr>
        <tr>
            <td colspan='3' style='background-image: url(http://14.102.146.116/Images/ebImages/bookimgbanner.jpg); background-repeat: no-repeat; height: 100px;'>            
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>" + vEmailBody + @"</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr height='50px'>
        <td class='bkgFooter'>
                &nbsp;</td>
            <td align='right'class='bkgFooter'  valign='middle'>
                &nbsp; 
                </td>
                <td class='bkgFooter'>
                &nbsp;</td>
        </tr>
    </table>
    </div>
</body>
</html>";

        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-0ad485da45bb169cabfea074c9e87e2d");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "EBook - Forget Password Request <me@maildly.ebdvy.com>");
        request.AddParameter("to", VEmailTO);
        request.AddParameter("subject", vEmailSubject);
        request.AddParameter("html", tmpHtmlBody);
        request.Method = Method.POST;
        client.Execute(request); 

        CommonFunctions.AlertMessageAndRedirect("Password sent to you Email", "O_dt_User_Login.aspx");
    }

}