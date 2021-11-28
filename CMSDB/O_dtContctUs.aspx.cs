using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CMSv3.Entities;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;

public partial class O_dtContctUs : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    //DataSet ds;
    string tmpCountryName = string.Empty;
    string chatid = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        if (!IsPostBack)
        {
            LoadUserContactDetails();
            LoadCountries();
        }
    }

    protected void LoadCountries()
    {
        CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
        DataSet ds = new DataSet();
        ds = objBAL_CommonFunc.GetCountryList();

        DdlCountry.DataSource = ds;
        DdlCountry.DataValueField = "CountryCode";
        DdlCountry.DataTextField = "CountryName";
        DdlCountry.SelectedValue = "60";
        DdlCountry.DataBind();
    }

    protected void LoadUserContactDetails()
    {
        string strSQL = "EXEC usp_USER_ContactUs_GET_ByUserID " + Convert.ToInt32(Session["ClientID"]);
        // string strSQL = "EXEC usp_USER_ContactUs_GET_ByUserID " + Convert.ToInt32(GlobalVar.GetTestLoginUser);
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
                    //ltrCompanyName.Text = dbReader["CompanyName"].ToString();
                    ltrCompName.Text = dbReader["CompanyName"].ToString();

                    //if (dbReader["NickNamechk"].ToString() == "True")
                    //    LtrNickName.Text = dbReader["NickName"].ToString();
                    //HandPhone
                    if (dbReader["MobileNochk"].ToString() == "True")
                    {
                        if ((dbReader["HandPhone"].ToString() == null) || (dbReader["HandPhone"].ToString() == ""))
                        {
                            LtrHandPhone.Text = "";
                            //imgHandPhone.Visible = false;
                        }
                        else
                        {
                            LtrHandPhone.Text = "<img title='Handphone' alt='handphne' id='imgHandPhone' runat='server' src='Images/icon_handphone.jpg' style='width: 27px; height: 25px' />&nbsp;&nbsp;" + " + " + dbReader["HandPhone"].ToString();
                            ViewState["MerID"] = dbReader["MerID"].ToString();
                            ViewState["tMobile"] = dbReader["HandPhone"].ToString();
                        }
                    }

                    //HomePhone
                    if (dbReader["HomePhonechk"].ToString() == "True")
                    {
                        if ((dbReader["HomePhone"].ToString() == null) || (dbReader["HomePhone"].ToString() == ""))
                        {
                            ltrHomephone.Text = "";
                            //imgHomePhone.Visible = false;
                        }
                        else
                        {
                            ltrHomephone.Text = " <img  title='Homephone' alt='homephone' id='imgHomePhone' runat='server' src='Images/icon_homephone.jpg' style='width: 27px; height: 23px' />&nbsp;&nbsp;" + " + " + dbReader["HomePhone"].ToString();
                        }
                    }

                    //FAX
                    if (dbReader["FaxNochk"].ToString() == "True")
                    {
                        if ((dbReader["FaxNo"].ToString() == null) || (dbReader["FaxNo"].ToString() == ""))
                        {
                            ltrFaxNo.Text = "";
                            //imgFaxPhone.Visible = false;
                        }
                        else
                        {
                            ltrFaxNo.Text = @"<img title='Fax' alt='fax' id='imgFaxPhone' runat='server' src='Images/icon_fax.jpg' style='width: 27px; height: 25px' />&nbsp;&nbsp;" + " + " + dbReader["FaxNo"].ToString();
                        }
                    }


                    if (dbReader["Emailchk"].ToString() == "True")
                    {
                        if ((dbReader["Email"].ToString() == null) || (dbReader["Email"].ToString() == ""))
                        {
                            ltrEmail.Text = dbReader["Email"].ToString();
                            ltrEmail.Text = "";
                            //imgEmail.Visible = false;
                        }
                        else
                        {
                            ltrEmail.Text = "<img title='Email' alt='Email' id='imgEmail' runat='server' src='Images/icon_email.jpg' style='width: 27px; height: 25px' />&nbsp;&nbsp;&nbsp;&nbsp;" + dbReader["Email"].ToString();
                        }
                    }

                    if (dbReader["Addresschk"].ToString() == "True")
                    {
                        string tmpAddress = dbReader["Address"].ToString();
                        tmpAddress = tmpAddress.Replace("<br/>", Environment.NewLine);
                        LtrAddress.Text = dbReader["Address"].ToString();
                    }

                    ViewState["chatid"] = "";
                    if (dbReader["ChatID"].ToString() == "")
                    {
                        ViewState["chatid"] = "";
                    }
                    else
                    {
                        ViewState["chatid"] = dbReader["ChatID"].ToString();
                    }

                    //if (dbReader["UserPhotoChk"].ToString() == "True")
                    //    ImgContact.ImageUrl = dbReader["FullImgPath"].ToString();
                    //else
                    //    ImgContact.ImageUrl = @"~\ImageRepository\Dummy_user.gif";
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
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string securitycodeVal = string.Empty;
        securitycodeVal = txtSecurity.Text;

        if (securitycodeVal=="12341234" || securitycodeVal=="12451245" || securitycodeVal=="12351235")
        {
            CMSv3.Entities.Enquiry objEnquiry = new CMSv3.Entities.Enquiry();
            CMSv3.BAL.enquiry objBAL_enquiry = new CMSv3.BAL.enquiry();

            objEnquiry.Name = txtName.Text;
            objEnquiry.ContactNo = txtContactNo.Text;
            objEnquiry.Email = txtEmail.Text;
            objEnquiry.Subject = txtSubject.Text;
            objEnquiry.enquiryType = Convert.ToInt16(GlobalVar.EnquiryTypes.ContactUs);

            string tmpMessage = txtMessage.Text.ToString();
            tmpMessage = tmpMessage.Replace(Environment.NewLine, "<br/>");
            objEnquiry.Message = tmpMessage;
            objEnquiry.Countrycode = Convert.ToInt16(DdlCountry.SelectedValue);
            tmpCountryName = DdlCountry.SelectedItem.Text;

            //int inStatus = objBAL_enquiry.InsertEnquiryData(objEnquiry, Convert.ToInt32(GlobalVar.GetTestLoginUser));
            int inStatus = objBAL_enquiry.InsertEnquiryData(objEnquiry, Convert.ToInt32(Session["ClientID"]));

            //Response.Write(Session["ClientID"].ToString());
            //Response.Write(txtName.Text.ToString());

            if (inStatus >= 1)
            {
                //tblMessageBar.Visible = true;
                //lblErrMessage.Text = "Your enquiry has been sent to us. We will contact you at earliest. ";
                //lblErrMessage.CssClass = "font_12Msg_Success";
                //MessageImage.Src = "~/Images/inf_Sucess.gif";
                //btnSubmit.Enabled = false;
                //tblEntryForm.Visible = false;
                // Send Email to Admin about the enquiry /////
                //CommonFunctions.GenericSendEmail(objEnquiry);

                if ((ViewState["MerID"].ToString() == null) || (ViewState["MerID"].ToString() == ""))
                {

                }
                else
                {
                    //string smsMessage = "There is an enquiry to your Digital BookStore ContactUs Information. Please login to check.";
                    //string smsSQL = "Exec esms.dbo.USPT_sendSMSForContactUs '" + ViewState["MerID"].ToString() + "','" + ViewState["tMobile"].ToString() + "','" + smsMessage.ToString() + "'";
                    ////Response.Write(smsSQL.ToString());
                    //dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                    //dbConn.Open();
                    //dbCmd = new SqlCommand(smsSQL, dbConn);
                    //dbCmd.ExecuteNonQuery();

                    if (ViewState["chatid"].ToString() != "")
                    {
                        string telegramresponse = "Thre is an Enquiry from Website^^Name: " + txtName.Text.ToString() + "^MobileNo: " + txtContactNo.Text.ToString() + "^Ëmail: ";
                        telegramresponse = telegramresponse + txtEmail.Text.ToString() + "^Country: " + DdlCountry.SelectedIndex.ToString() + "^Subject: " + txtSubject.Text.ToString();
                        telegramresponse = telegramresponse + "^Message: " + txtMessage.Text.ToString();
                        string tURL = "http://gt.evenchise.com/MessageBridge.aspx?botid=4&chatid=" + ViewState["chatid"].ToString() + "&message=" + telegramresponse;
                        //Response.Write(tURL.ToString());
                        //Response.End();
                        string URI = tURL;
                        string myParameters = "";

                        using (WebClient wc = new WebClient())
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            string HtmlResult = wc.UploadString(URI, myParameters);
                        }
                    }
                }

                fn_SendContactUsEmail(objEnquiry);
                CommonFunctions.AlertMessage("Your enquiry has been sent to us. We will contact you at earliest.");
            }
            else
            {
                //lblErrMessage.Text = "Could not send the Email due to Technical Error. Please try again.";
                //lblErrMessage.CssClass = "font_12Msg_Error";
                //tblMessageBar.Visible = true;
                //MessageImage.Src = "~/Images/inf_Error.gif";
                CommonFunctions.AlertMessage("Could not send the Email due to Technical Error. Please try again.");
            }
        }
        else
        {
            CommonFunctions.AlertMessage("Please provide valid Security Code to Proceed.");
        }        
    }

    protected void fn_SendContactUsEmail(CMSv3.Entities.Enquiry vObjEnquiry)
    {
        //forming email variables
        string Contact_EmailAddress = vObjEnquiry.Email;
        string Contact_EmailSubject = vObjEnquiry.Subject;
        string Contact_EmailFullName = vObjEnquiry.Name;
        string Contact_EmailBody = string.Empty;
        string strNote = string.Empty;
        string mSpacer = string.Empty;
        string strSQL = string.Empty;

        string Admin_FullName = string.Empty;
        string Admin_EmailAddress = string.Empty;
        string Admin_WebSiteName = string.Empty;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        try
        {
            dbConn.Open();
            strSQL = "EXEC [usp_Retreive_EmailDetails_ByUserID] " + Convert.ToInt32(Session["ClientID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    Admin_FullName = dbReader["FullName"].ToString();
                    Admin_EmailAddress = dbReader["Email"].ToString();
                    Admin_WebSiteName = dbReader["WEBsiteName"].ToString();
                }
            }

            Contact_EmailBody = "<br><br>" +

                //"----------------------------------------------------------------------<br/>" +
                "<div><table border='0' cellpadding='5' cellspacing='1' width='100%' class='stdtableBorder_Search'>" +
                "<tr><td width='30%'>&nbsp;</td><td width='70%'>&nbsp;</td></tr>" +
                "<tr><td class='SearchLabelBold'><b>Name</b></td><td class='SearchLabel'> : " + vObjEnquiry.Name + "</td></tr>" +
                "<tr><td class='SearchLabelBold'><b>Contact Number</b></td><td class='SearchLabel'> : " + vObjEnquiry.ContactNo + "</td></tr>" +
                "<tr><td class='SearchLabelBold'><b>Country</b></td><td class='SearchLabel'> : " + tmpCountryName + "</td></tr>" +
                "<tr><td class='SearchLabelBold'><b>Email Address</b></td><td class='SearchLabel'> : " + vObjEnquiry.Email + "</td></tr>" +
                "<tr><td><b>Enquiry Message</b></td><td>&nbsp;</td></tr>" +
                "<tr><td>&nbsp;</td><td>&nbsp;</td></tr>" +
                "<tr><td colspan='2' class='SearchLabel' style='padding-left: 20px;'>" + vObjEnquiry.Message + "</td></tr>" +
                "<tr><td>&nbsp;</td><td>&nbsp;</td></tr>" +
                "</table></div>" +
                //"<br/>----------------------------------------------------------------------<br/>" +
                "<br><br>";

            //strNote = "Enquiry Email from sent from " + Admin_WebSiteName;
            strNote = "<tr><td>&nbsp;</td><td>&nbsp;</td> <td>&nbsp;</td></tr>" +
            "<tr> <td> &nbsp;</td><td> " +
            "<font class='font_12BlueBold'>Enquiry </font>  email  : <b>" + Admin_WebSiteName + "</b>" +
            "</td><td> &nbsp;</td> </tr>" +
            "<tr><td>&nbsp;</td><td>&nbsp;</td> <td>&nbsp;</td></tr>";

            //Contact_EmailBody = Contact_EmailBody.Replace(" ", "&nbsp;");
            //CommonFunctions.GenericSendEmail(mEmailAddress, mEmailFrom, mEmailBody, mEmailSubject, mFullName, "", "");
            MyMail.CommonSendEmail(Admin_EmailAddress, Contact_EmailAddress, Contact_EmailBody, Contact_EmailSubject, Admin_FullName, strNote, "");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
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