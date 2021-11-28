using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class EBAd_KeywordRegister : System.Web.UI.Page
{

    DataSet ds; 
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    CMSv3.BAL.SCdb objSC = new CMSv3.BAL.SCdb();
    CMSv3.BAL.MalaysiaSMS objUser = new CMSv3.BAL.MalaysiaSMS(); 

    protected void Page_Load(object sender, EventArgs e)
    {


        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 

        
        

        if (!IsPostBack)
        {

            Render_KeywordRegister_Button(); 
    
        }


    }



    protected void Render_KeywordRegister_Button()
    {

        int vPremiumStatus = 0;
        int vPackageType = 0;
        String vVendorCode = string.Empty;


       

            CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();


            DataSet ds = objEbook.EBOOK_GetDetailsByMID(Session["MERID"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utrow = ds.Tables[0].Rows[0];

                vPackageType = Convert.ToInt16(utrow["PackageType"].ToString());
                vPremiumStatus = Convert.ToInt16(utrow["PremiumStatus"].ToString());
                vVendorCode = utrow["VendorCode"].ToString();

                Session["PackageType"] = vPackageType;
                Session["PremiumStatus"] = vPremiumStatus;
                Session["VendorCode"] = vVendorCode;



                // if PremiumStatus = 1 is PAID,  0 is FREE 
                if (vPremiumStatus == 1)
                {
                    if (vPackageType == 2)
                    {
                        if (vVendorCode == "NONE")
                        {
                            tblRegister.Visible = true;
                        }
                        else
                        {
                            tblVendorCodeExists.Visible = true;
                            lblVendorCode.Text = vVendorCode; 
                            
                            tblRegister.Visible = false;


                        }
                    }
                    else
                    {
                        tblRegister.Visible = false;
                    }
                }
                else
                {
                    tblRegister.Visible = false;
                }

            }


        


    }



    protected void Validate_Keyword()
    {

        String tmpShortCode = lblShortCode.Text;



        ds = objSC.Check_KeywordAvailability(TextBoxKeyword.Text.Trim(), tmpShortCode.Trim());


        if (ds.Tables[0].Rows.Count > 0)
        {
            int tmpStatus = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            ViewState["KeywordV"] = tmpStatus.ToString();

            if (tmpStatus == 0)
            {
                divNoticeBar.Visible = true;
                divNoticeBar.Attributes.Add("class", "divNoticeBarSuccess");
                lblNoticebarMsg.Text = "Keyword : " + TextBoxKeyword.Text + " is Available!";

            }
            else
            {
                divNoticeBar.Visible = true;
                divNoticeBar.Attributes.Add("class", "divNoticeBarError");
                lblNoticebarMsg.Text = "Keyword : " + TextBoxKeyword.Text + " is Already Exists.Please Choose Another Keyword!";

            }

            string keywordStatus = ViewState["KeywordV"].ToString();

            if (keywordStatus == "1")
            {
                trRegisterRow.Visible = false;
            }
            else
            { trRegisterRow.Visible = true; }
        }
    }


    protected void TextBoxKeyword_TextChanged(object sender, EventArgs e)
    {
        CheckLongCodeKeyword_Availability();
    }


    protected void CheckLongCodeKeyword_Availability()
    {
        String tmpShortCode = lblShortCode.Text.Trim();


        ds = objSC.Check_KeywordAvailability(TextBoxKeyword.Text.Trim(), tmpShortCode.Trim());

        if (ds.Tables[0].Rows.Count > 0)
        {
            int tmpStatus = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            ViewState["KeywordV"] = tmpStatus.ToString();

            if (tmpStatus == 0)
            {
                LabelKeywordStatus.Visible = true;
                LabelKeywordStatus.Text = "Keyword : " + TextBoxKeyword.Text + " is Available!";
                ImageKeywordStatus.Visible = true;
                ImageKeywordStatus.ImageUrl = "~/Images/icon_ksuccess.png";

            }
            else
            {
                LabelKeywordStatus.Visible = true;
                LabelKeywordStatus.CssClass = "txtValidateRed";
                LabelKeywordStatus.Text = "Keyword : " + TextBoxKeyword.Text + " is Already Exists.Please Choose Another Keyword!";
                ImageKeywordStatus.Visible = true;
                ImageKeywordStatus.ImageUrl = "~/Images/icon_kcancel.png";

            }

            string keywordStatus = ViewState["KeywordV"].ToString();

            if (keywordStatus == "1")
            {
                trRegisterRow.Visible = false;
            }
            else
            { trRegisterRow.Visible = true; }

        }


    }

    protected void btnCheckKeyWAvail_Click(object sender, EventArgs e)
    {

        String tmpShortCode = lblShortCode.Text.Trim();


        ds = objSC.Check_KeywordAvailability(TextBoxKeyword.Text.Trim(), tmpShortCode.Trim());

        if (ds.Tables[0].Rows.Count > 0)
        {
            int tmpStatus = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            ViewState["KeywordV"] = tmpStatus.ToString();


            if (tmpStatus == 0)
            {
                LabelKeywordStatus.Visible = true;
                LabelKeywordStatus.CssClass = "font_12Msg_Success";
                LabelKeywordStatus.Text = "Keyword : " + TextBoxKeyword.Text + " is Available!";
                ImageKeywordStatus.Visible = true;
                ImageKeywordStatus.ImageUrl = "~/Images/inf_Sucess.gif";

            }
            else
            {
                LabelKeywordStatus.Visible = true;
                LabelKeywordStatus.CssClass = "font_12Msg_Error";
                LabelKeywordStatus.Text = "Keyword : " + TextBoxKeyword.Text + " is Already Exists.Please Choose Another Keyword!";
                ImageKeywordStatus.Visible = true;
                ImageKeywordStatus.ImageUrl = "~/Images/inf_Error.gif";

            }

            string keywordStatus = ViewState["KeywordV"].ToString();

            if (keywordStatus == "0")
            {
                trRegisterRow.Visible = true;
            }
            else
            { trRegisterRow.Visible = false; }
        }
    }

    protected void Send_EmailtoAdministrator(String vKeyword, String vShortCode, String vMobileNo)
    {



        ds = objUser.Validate_HitechSMS_EBOOK(Session["MERID"].ToString());

        //Get user details. 

        String vLoginID = String.Empty;
        String vPassword = String.Empty;
        String vEmail = String.Empty;
        String vName = String.Empty;



        if (ds.Tables[1].Rows.Count > 0)
        {
            DataRow utUser = ds.Tables[1].Rows[0];

            vLoginID = utUser["Login_ID"].ToString();
            vPassword = utUser["MPassword"].ToString();
            vEmail = utUser["Email"].ToString();
            vName = utUser["MName"].ToString();
        }


        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<br/>");
        sb.AppendLine("<br/>");
        sb.AppendLine("New Registration for EVENDOR CODE for EBOOK. The Keyword details<br/> ");
        sb.AppendLine("<br/>====================================================<br/>");
        sb.AppendFormat("<h2>MOBILE NO.     : {0}<br/>", vMobileNo);
        sb.AppendFormat("SHORTCODE      : {0}<br/>", vShortCode);
        sb.AppendFormat("KEYWORD        : {0}<br/>", vKeyword);
        sb.AppendLine("PRICE            : 5.00<br/></h2>");
        sb.AppendLine("<br/>____________________________________________________<br/>");
        sb.AppendFormat("<h2>Member Name  : {0}<br/>", vName);
        sb.AppendFormat("<h2>Login ID     : {0}<br/>", vLoginID);
        sb.AppendFormat("<h2>Password.    : {0}<br/>", vPassword);
        sb.AppendFormat("<h2>Email.       : {0}<br/>", vEmail);
        sb.AppendLine("<br/>====================================================<br/>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<br/>");
        sb.AppendLine("Regards.<br/>");
        sb.AppendLine("Administrator WorldDigitalbiz.com<br/>");

        String tmpSubject = "EVENDOR CODE REGISTRATION :" + vKeyword;

        CommonFunctions.GenericSendEmail("keywordsetup@globalsurf.com.my", "ebookAdmin@WorldDigitalBiz.com", sb.ToString(), tmpSubject, "Fizah", "", ""); 



        //Hitech_MyMail.Send_EmailGeneric("Fizah", "keywordsetup@globalsurf.com.my", "EbookAdmin", "ebookAdmin@WorldDigitalBiz.com", tmpSubject, sb.ToString());
        //  Hitech_MyMail.Send_EmailGeneric("Fizah", "msri_hari@yahoo.com", "EbookAdmin", "ebookAdmin@WorldDigitalBiz.com", "EVENDOR CODE REGISTRATION", sb.ToString());


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        Validate_Keyword();


        String KeywordV = ViewState["KeywordV"].ToString();
        String tmpShortCode = "32828";
        int tmpRegister = 0;
        int inStatus = 0;
        int pStatus = 0;

        if (KeywordV == "0")
        {

            if (tmpRegister == 0)
            {
                CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

                inStatus = objEbook.eBook_eVendorCodeRegister(TextBoxKeyword.Text.Trim(), tmpShortCode, Session["MobileLoginID"].ToString(), Session["MERID"].ToString());

                ////.. insert into SC database for Keyword Request 
                ////.. [USP_Ebook_KeywordRequest]
                pStatus = objSC.ebook_KeywordRequest(TextBoxKeyword.Text.Trim(), tmpShortCode);

            }

            inStatus = 1;

            divNoticeBar.Visible = true;

            if (inStatus == 1)
            {
                divNoticeBar.Attributes.Add("class", "divNoticeBarSuccess");
                lblNoticebarMsg.Text = "Keyword : " + TextBoxKeyword.Text + " Successfully Registered!.  Please allow 3-4 weeks to obtain approvals of your eVendor Code from all Telcos.";
                divNoticeBar.Visible = true;
                //Display a simple message. 
                ClientScriptManager cs = Page.ClientScript;
                Type myType = this.GetType();
                //Check to see if the startup script is already registered.
                // String SessionTimeOutPage = HitechSMS_Functions.get_SessionTimeOutPage(Session["ReferringURL"].ToString(), "www.hitechdigitalbiz.com");
                tmpRegister = 1;

                Session["VendorCode"] = TextBoxKeyword.Text.Trim();
                Send_EmailtoAdministrator(TextBoxKeyword.Text.Trim(), tmpShortCode, Session["MobileLoginID"].ToString());

                //..SEND email to Administrator. 




                if (!cs.IsStartupScriptRegistered(myType, "AlertScript"))
                {

                    String script = "alert('Thank you for registering. Please You will be notified once the Vendor Code has been Approved.";
                    cs.RegisterStartupScript(myType, "AlertScript", script, true);
                }

                //HitechSMS_Functions.AlertMessage1("1. Thank you for registering. You will be notified once the Vendor Code has been approved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "alert('Thank you for registering. You will be notified once the Vendor Code has been approved'); ", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "rdtprofile", "window.location.replace('MyProfile.aspx');", true);
                //Response.Redirect("MyProfile.aspx");
            }
            else
            {
                divNoticeBar.Attributes.Add("class", "divNoticeBarError");
                lblNoticebarMsg.Text = "Technical Error.Please try again later!";
                divNoticeBar.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "alert('Your eVendor Code could not be Registered. Please try again or Contact Administrator');", true);
            }
        }

    }



    protected void btnCancel_Click(object sender, EventArgs e)
    {


        string ImgURL = string.Empty;
        

      


    }





  

}