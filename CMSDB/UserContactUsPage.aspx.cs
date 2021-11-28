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


public partial class UserContactUsPage : UserWeb
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    //DataSet ds;
    string tmpCountryName = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 


        #region Language Resources

        ltrContactUs.Text = Resources.LangResources.ContactUs;
        //LblCompanyName.Text = Resources.LangResources.Company;
        //lblNickName.Text = Resources.LangResources.Nickname;
        //lblHomephone.Text = Resources.LangResources.Home + Resources.LangResources.Phone;
        //lblHandPhone.Text = Resources.LangResources.Phone;
        //lblAddress.Text = Resources.LangResources.Address;

        lblName.Text = Resources.LangResources.Name;
        lblContactNo.Text = Resources.LangResources.contact + " " + Resources.LangResources.number;
        lblEmail.Text = "Email";
        lblSubject.Text = Resources.LangResources.subject;
        lblMessage.Text = Resources.LangResources.message;
        LtrContactus2.Text = ltrContactUs.Text;
        ltrContactUs3.Text = ltrContactUs.Text;
        //LtrEnquiry.Text = Resources.LangResources.enquiry;
        #endregion 

        #region -- Rendering Top Left Panel --
        if (Session["MasterPageCss"] != null)
        {
            if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet"))
            {
                HtmlGenericControl myDivObject;
                myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

                //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

                if (myDivObject != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
                    sb.Append("<tr>");
                    sb.Append("<td align='left' valign='top'>");
                    sb.Append("<img src='Images/table_top_Leftarc.gif' />");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");

                    myDivObject.InnerHtml = sb.ToString();
                }
            }
        }
        #endregion

        if (!IsPostBack)
        {

           


            LoadUserContactDetails();
            LoadCountries();
        }

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
                    ltrCompanyName.Text = dbReader["CompanyName"].ToString();

                    if (dbReader["NickNamechk"].ToString() == "True")
                      LtrNickName.Text = dbReader["NickName"].ToString();


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

                    if (dbReader["UserPhotoChk"].ToString() == "True")
                        ImgContact.ImageUrl = dbReader["FullImgPath"].ToString();
                    else
                        ImgContact.ImageUrl = @"~\ImageRepository\Dummy_user.gif";

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
        //getting User entered values
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

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Your enquiry has been sent to us. We will contact you at earliest. ";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            btnSubmit.Enabled = false;
            tblEntryForm.Visible = false;


            // Send Email to Admin about the enquiry /////
            //CommonFunctions.GenericSendEmail(objEnquiry);
            fn_SendContactUsEmail(objEnquiry);



        }
        else
        {
            lblErrMessage.Text = "Could not send the Email due to Technical Error. Please try again.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
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
}
