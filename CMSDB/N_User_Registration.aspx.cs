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
using RestSharp;
using RestSharp.Authenticators;

public partial class N_User_Registration : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    //DataSet ds;
    //DataTable dt;
    //DataSet dpt;
    //int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0;
    int vClientId = 0;
    //decimal tmpPrepaidTotal = 0;
    //int tmpTotalItemsCount = 0;

    //long MaxEbookImageSize = 2097152;   // 2MB
    string buyerMsg;
    string buyerStatus;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        //if ((Session["cLogin"] == null) || (Session["cLogin"] == ""))
        //{            
        //}
        //else if (Session["cLogin"] != "")
        //{
        //    Response.Redirect("N_Main.aspx");
        //}
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
                    BtnSubmit.Visible = false;
                }
            }

            newDBS ndbs = new newDBS();
            DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["ClientID"]).ToString());
            string userCurrency = string.Empty;
            userCurrency = "$";
            if (dst.Tables[0].Rows.Count > 0)
            {
                userCurrency = dst.Tables[0].Rows[0]["Currency"].ToString();
            }
            DataTable CartDataTable = null;
            int tmpRowCount = 0;
            decimal tmpPrice = 0;
            StringBuilder sbP = new StringBuilder();
            if (HttpContext.Current.Session["basket"] != null)
            {
                CartDataTable = (DataTable)HttpContext.Current.Session["basket"];
            }
            if (CartDataTable != null)
            {
                if (CartDataTable.Rows.Count > 0)
                {
                    tmpRowCount = CartDataTable.Rows.Count;
                    ViewState["ItemsCount"] = tmpRowCount;
                    for (int i = 0; i < CartDataTable.Rows.Count; i++)
                    {
                        tmpPrice = tmpPrice + Convert.ToDecimal(String.Format("{0:0.00}", CartDataTable.Rows[i][2].ToString()));
                    }
                    cartItems.Text = ViewState["ItemsCount"].ToString();
                    cartPrice.Text = tmpPrice.ToString();
                    cartCurrency.Text = userCurrency.ToString();
                }
            }
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        vClientId = Convert.ToInt32(Session["ClientID"].ToString());

        //String vPrepaidPin = txtPIN.Text.Trim();
        String vPrepaidPin = "";
        String vPrepaidLogin = txtcEmail.Text.Trim();
        String vPrepaidPassword = txtPrepaidPassword.Text.Trim();
        String vBankersFullName = txtcName.Text.Trim();
        String vBankdersMobile = txtcMobile.Text.Trim();
        String vBankdersEmail = txtcEmail.Text.Trim();

        //if (vBankdersMobile.Substring(0, 1) == "0")
        //{
        //    vBankdersMobile = vBankdersMobile.Remove(0, 1);
        //}

        String tempErrorCode1 = string.Empty;
        String tempretMessage1 = string.Empty;
        tempErrorCode1 = "0";

        if (vBankdersMobile.Substring(0, ctryCode.SelectedValue.Length).ToString() == ctryCode.SelectedValue.ToString())
        {
            CommonFunctions.AlertMessage("Invalid Mobile Entered. Cannot have Leading ZERO or COUNTRY CODE as Prefix for entered mobile.");
        }
        else if (txtPrepaidPassword.Text.ToString() != txtRPrepaidPassword.Text.ToString())
        {
            CommonFunctions.AlertMessage("Invalid Password. Passwords does not match.");
        }
        else
        {
            vBankdersMobile = ctryCode.SelectedValue.ToString() + vBankdersMobile.ToString();
            if (vPrepaidPin.ToString() != "")
            {
                newDBS ndbsP = new newDBS();
                DataSet dstP = ndbsP.Prepaid_RegValidatePin(vClientId.ToString(), vPrepaidPin.ToString());
                tempErrorCode1 = dstP.Tables[0].Rows[0]["errorcode"].ToString();
                tempretMessage1 = dstP.Tables[0].Rows[0]["retMessage"].ToString();
            }
            newDBS ndbsL = new newDBS();
            DataSet dstL = ndbsL.Prepaid_RegValidateLogin(vPrepaidLogin.ToString(), Session["ClientID"].ToString());
            String tempErrorCode2 = dstL.Tables[0].Rows[0]["errorCode"].ToString();
            String tempretMessage2 = dstL.Tables[0].Rows[0]["retMessage"].ToString();

            int tempErCode1 = Convert.ToInt32(tempErrorCode1);
            int tempErCode2 = Convert.ToInt32(tempErrorCode2);

            if (tempErCode1 > 0)
            {
                CommonFunctions.AlertMessage(tempretMessage1.ToString());
            }
            else
            {
                if (tempErCode2 > 0)
                {
                    CommonFunctions.AlertMessage(tempretMessage2.ToString());
                }
                else
                {
                    newDBS ndbsR = new newDBS();
                    String tempErrorCodeR = string.Empty;
                    String tempretMessageR = string.Empty;
                    String buyerUserID = string.Empty;
                    if (vPrepaidPin.ToString() == "")
                    {
                        DataSet dstR = ndbsR.Prepaid_RegisterWeb_User(vPrepaidLogin.ToString(), vBankdersMobile.ToString(), vPrepaidPin.ToString(), vBankdersEmail.ToString(), vPrepaidPassword.ToString(), vBankersFullName.ToString(), vClientId.ToString());
                        tempErrorCodeR = dstR.Tables[0].Rows[0]["errorCode"].ToString();
                        tempretMessageR = dstR.Tables[0].Rows[0]["returnMessage"].ToString();
                        buyerUserID = dstR.Tables[0].Rows[0]["userid"].ToString();
                    }
                    else
                    {
                        DataSet dstR = ndbsR.Prepaid_RegisterUser(vPrepaidLogin.ToString(), vBankdersMobile.ToString(), vPrepaidPin.ToString(), vBankdersEmail.ToString(), vPrepaidPassword.ToString(), vBankersFullName.ToString());
                        tempErrorCodeR = dstR.Tables[0].Rows[0]["errorCode"].ToString();
                        tempretMessageR = dstR.Tables[0].Rows[0]["returnMessage"].ToString();
                        buyerUserID = dstR.Tables[0].Rows[0]["userid"].ToString();
                    }

                    int tempErCode3 = Convert.ToInt32(tempErrorCodeR);

                    if (tempErCode3 > 0)
                    {
                        //CommonFunctions.AlertMessage(tempretMessageR.ToString());
                        CommonFunctions.AlertMessageAndRedirect(tempretMessageR.ToString(), "N_User_Login.aspx");
                    }
                    else
                    {
                        string storeidVal = string.Empty;
                        newDBS ndspp = new newDBS();
                        storeidVal = ndspp.user_getStoreID(Convert.ToInt32(Session["ClientID"].ToString()));
                        Session["navcheckout"] = "1";
                        Session["cLogin"] = storeidVal + "-" + vPrepaidLogin.ToString();
                        Send_EmailReg(vBankersFullName.ToString(), vBankdersEmail.ToString(), vPrepaidLogin.ToString(), vPrepaidPassword.ToString(), buyerUserID.ToString());
                        //CommonFunctions.AlertMessageAndRedirect(tempretMessageR.ToString(), ViewState["CallingPage"].ToString());
                        //Response.Redirect(ViewState["CallingPage"].ToString());
                        if (Session["navcheckout"].ToString() == "1")
                        {
                            CommonFunctions.AlertMessageAndRedirect(tempretMessageR.ToString(), "N_Cart.aspx");
                        }
                    }
                }
            }
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

    protected void LnkBtnValidateLogin_Click(object sender, EventArgs e)
    {
        string newLogin = txtcEmail.Text.Trim();
        if (newLogin.ToString() != "")
        {
            newDBS ndbsL = new newDBS();
            DataSet dstL = ndbsL.Prepaid_RegValidateLogin(newLogin.ToString(), Session["ClientID"].ToString());
            String tempErrorCode1 = dstL.Tables[0].Rows[0]["errorCode"].ToString();
            String tempretMessage1 = dstL.Tables[0].Rows[0]["retMessage"].ToString();
            //CommonFunctions.AlertMessage(tempretMessage1.ToString());
            lblLoginV.Visible = true;
            
            if (tempErrorCode1=="0")
            {
                lblLoginV.Text = "<font color='green'>" + tempretMessage1.ToString() + "</font>";
            }
            else
            {
                lblLoginV.Text = "<font color='red'>" + tempretMessage1.ToString() + "</font>";
            }
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

    protected void Send_EmailReg(String vbFullName, string vEmail, string vLogin, string vPassword, string buserid)
    {
        string domainName = Request.Url.OriginalString;
        string domainName1 = domainName.Replace("http://", "");  // removing the http://
        string domainName2 = domainName1.Replace(":80/", "");
        string domainName3 = domainName2.Replace("N_User_Registration.aspx", "");
        string domainName4 = domainName3.Replace("O_dt_User_Registration.aspx", "");
        string[] dsn = domainName4.Split('?');
        string domainName5 = dsn[0];
        StringBuilder sHtml = new StringBuilder();
        string eMessage = "Thank You for registering at http://" + domainName5.ToString() + "<br> Following is your login details.<br><br>LoginID: " + vLogin + "<br>password:" + vPassword + "<br><br>" + "<a href='http://www.ebdvy.com/verifyBuyerEmail.aspx?k=2&id=" + buserid.ToString() + "' target='_blank'>[Please click here to verify  your email]</a>" + "<br><br>Thank You<br>Evenchise Team";
        string tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head >
                                <title></title>
                                <style type='text/css'>
                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
                                </style>
                                </head>
                                <body>
                                    <div id='dvEmail' class='dvemailBox'> 
                                    <div id='dvHeader' style='align-content: center;'>
                                            <img src='http://14.102.146.116/Images/ebImages/bookimgbanner.jpg' />
                                                    <br />
                                     </div>
                                    <div id='dvContent' style='font: 12px Verdana'>
                                    "
                       + eMessage +

                       @"
                                </div>
                                </div>
   
                            </body>
                            </html>
                            ";

        //.. Get Vendor Details. 

        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "key-0ad485da45bb169cabfea074c9e87e2d");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "EBook - Registration <me@maildly.ebdvy.com>");
        request.AddParameter("to", vEmail);
        request.AddParameter("subject", domainName5.ToString() + " Registration");
        request.AddParameter("html", tmpHtmlBody);
        request.Method = Method.POST;
        client.Execute(request);

        //String vVendorMobileID = string.Empty;
        //String vVendorEmailID = String.Empty;

        //SmtpClient smtpClient = new SmtpClient();
        //MailMessage objMessage = new MailMessage();
        //string m_fromName = string.Empty;
        //try
        //{
        //    m_fromName = "EBookAdmin";
        //    MailAddress m_fromAddress = new MailAddress("noreply@ebooksmsdelivery.com", "EBookAdmin");
        //    smtpClient.Host = "127.0.0.1";
        //    smtpClient.Port = 25;
        //    objMessage.From = m_fromAddress;

        //    objMessage.To.Add(vEmail);
        //    objMessage.Subject = domainName5.ToString() + " Registration"; 

        //    //objMessage.Bcc.Add("srihari@globalsurf.com.my");

        //    objMessage.IsBodyHtml = true;
        //    objMessage.Body = tmpHtmlBody;

        //    NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.Credentials = authinfo;

        //    smtpClient.Send(objMessage);
        //}
        //catch
        //{
        //}
    }

}