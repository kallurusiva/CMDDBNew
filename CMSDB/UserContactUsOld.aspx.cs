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

public partial class UserContactUs1 : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    //DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region Language Resources

        LtrContactUs.Text = Resources.LangResources.ContactUs;
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
        LtrEnquiry.Text = Resources.LangResources.enquiry;
        #endregion 
                

        #region -- Rendering Top Left Panel --
        HtmlGenericControl myDivObject;
        myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

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
        #endregion


        if (!IsPostBack)
        {
            LoadUserContactDetails();
        }

    }

    protected void LoadUserContactDetails()
    {

        string strSQL = "EXEC usp_USER_ContactUs_GET_ByUserID " + Convert.ToInt32(GlobalVar.GetTestLoginUser);

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
                   
                    if(dbReader["NickNamechk"].ToString() == "True")
                         LtrNickName.Text = dbReader["NickName"].ToString();

                    if (dbReader["MobileNochk"].ToString() == "True")
                    LtrHandPhone.Text = dbReader["HandPhone"].ToString();

                    if (dbReader["HomePhonechk"].ToString() == "True")
                    ltrHomephone.Text = dbReader["HomePhone"].ToString();

                    if (dbReader["FaxNochk"].ToString() == "True")
                    ltrFaxNo.Text = dbReader["FaxNo"].ToString();

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


        int inStatus = objBAL_enquiry.InsertEnquiryData(objEnquiry,Convert.ToInt32(GlobalVar.GetTestLoginUser));

        if (inStatus >=1 )
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Your enquiry has been sent to us. We will contact you at earliest. ";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            btnSubmit.Enabled = false;

        }
        else
        {
            lblErrMessage.Text = "Could not send the Email due to Technical Error. Please try again.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }


        ////-- Send Email -- //
        //MailMessage ObjMsg = new MailMessage();

        //ObjMsg.To = "msri_hari@yahoo.com";
        //ObjMsg.From = "support@1smswebsite.com";

        //ObjMsg.Subject = objEnquiry.Subject;
        //ObjMsg.Body = objEnquiry.Message;
        //ObjMsg.BodyFormat = MailFormat.Text;

        //SmtpMail.SmtpServer = "mail.1argentinasms.com";
        ////SmtpMail.Send(ObjMsg);
        
        

        



    }
}
