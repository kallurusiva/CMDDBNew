using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Admin_Ads_EmailPage : System.Web.UI.Page
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //string strSQL;
    DataSet ds; 


    string tmpWpDescription = string.Empty;
    //int qLgType = 1;
    //int mLanguage = 1;
    String mAccountType = "";
    int isPurchased = 0;
    int isSMEPurchased = 0; 

    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
    CMSv3.BAL.GemailSystem objBAL_Gems = new CMSv3.BAL.GemailSystem();
    CMSv3.BAL.MalaysiaSMS objBAL_MasUser = new CMSv3.BAL.MalaysiaSMS(); 

    protected void Page_Load(object sender, EventArgs e)
    {


        #region

        if (Session["UserID"] == null)
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        else
        {
            if(Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 





        if (!IsPostBack)
        {

            ViewState["vMobileLoginID"] = "";


            LoadUserDetails((Session["UserID"].ToString()));





            #region Code to Hide Left ContentHolder

            //HtmlGenericControl myDivLeftBar;
            //myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

            //myDivLeftBar.Style.Clear();
            //myDivLeftBar.Style.Value = "width:0px;";


            //HtmlGenericControl myDivRightBar;
            //myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

            //myDivRightBar.Style.Clear();
            //myDivRightBar.Style.Value = " width: 96%; padding-left:20px;";

            #endregion



            #region Code to hide buttons


           // HtmlAnchor AncWelcome = (HtmlAnchor)Page.Master.FindControl("aWelcome"); AncWelcome.Visible = false;
           // HtmlAnchor aAccount = (HtmlAnchor)Page.Master.FindControl("aAccount"); aAccount.Visible = false;
           // HtmlAnchor aNews = (HtmlAnchor)Page.Master.FindControl("aNews"); aNews.Visible = false;
           // HtmlAnchor aEvents = (HtmlAnchor)Page.Master.FindControl("aEvents"); aEvents.Visible = false;
           // HtmlAnchor aFaq = (HtmlAnchor)Page.Master.FindControl("aFaq"); aFaq.Visible = false;

           // HtmlAnchor aTestimonial = (HtmlAnchor)Page.Master.FindControl("aTestimonial"); aTestimonial.Visible = false;
           // HtmlAnchor aEmail = (HtmlAnchor)Page.Master.FindControl("aEmail"); aEmail.Visible = false;
           // HtmlAnchor aWebSettings = (HtmlAnchor)Page.Master.FindControl("aWebSettings"); aWebSettings.Visible = false;
           //// HtmlAnchor aWebTemplate = (HtmlAnchor)Page.Master.FindControl("aWebTemplate"); aWebTemplate.Visible = false;
           //// HtmlAnchor aGallery = (HtmlAnchor)Page.Master.FindControl("aGallery"); aGallery.Visible = false;

           // HtmlAnchor aButton1 = (HtmlAnchor)Page.Master.FindControl("aButton1"); aButton1.Visible = false;
           // HtmlAnchor aButton2 = (HtmlAnchor)Page.Master.FindControl("aButton2"); aButton2.Visible = false;
           // HtmlAnchor aButton3 = (HtmlAnchor)Page.Master.FindControl("aButton3"); aButton3.Visible = false;
           // HtmlAnchor aButton4 = (HtmlAnchor)Page.Master.FindControl("aButton4"); aButton4.Visible = false;
           // HtmlAnchor aButton5 = (HtmlAnchor)Page.Master.FindControl("aButton5"); aButton5.Visible = false;
           // HtmlAnchor aButton6 = (HtmlAnchor)Page.Master.FindControl("aButton6"); aButton6.Visible = false;
           // HtmlAnchor aButton7 = (HtmlAnchor)Page.Master.FindControl("aButton7"); aButton7.Visible = false;
           // HtmlAnchor aButton8 = (HtmlAnchor)Page.Master.FindControl("aButton8"); aButton8.Visible = false;

           // HyperLink HypRegDomain = (HyperLink)Page.Master.FindControl("HypRegDomain"); HypRegDomain.Visible = false;


           // HyperLink vHypEmail = (HyperLink)Page.Master.FindControl("HypEmail"); vHypEmail.Visible = false;
           // HyperLink vHypMobileWeb = (HyperLink)Page.Master.FindControl("HypMobileWeb");
           // HyperLink vHypWebPortal = (HyperLink)Page.Master.FindControl("HypWebPortal"); vHypWebPortal.Visible = true;
           // HyperLink vHypSmsSystem = (HyperLink)Page.Master.FindControl("HypSmsSystem"); vHypSmsSystem.Visible = true;


            #endregion





            ds = objBAL_MasUser.Get_1MasUser_Details(ViewState["vMobileLoginID"].ToString());

               DataTable dtMasUser = ds.Tables[0];

               foreach (DataRow mRow in dtMasUser.Rows)
               {
                   mAccountType = mRow["Acc_Type"].ToString(); 

               }


           
                String vtrMessage = string.Empty;

                  if ((mAccountType == "PLATINUM") || (mAccountType == "TITANIUM"))
                   {
                       trPlatinum.Visible = true;
                       trUnPlatinum.Visible = false;

                       if (ViewState["vOwnDomain"] != null)
                       {
                           if ((ViewState["vOwnDomain"].ToString() == null) || (ViewState["vOwnDomain"].ToString() == ""))
                           {
                               vtrMessage = "Email system cannot be registered because you have not registered your Own domain yet. </br>";
                               vtrMessage = vtrMessage + "</br>";
                               vtrMessage = vtrMessage + "<a href='Ad_DomainsList.aspx' class='links_Navigate'>Click here to Register your domain </a>";
                               
                           }
                           else
                           {
                               vtrMessage = "Email system creation for your account is under progress. </br>";
                               vtrMessage = vtrMessage + "</br>";
                               vtrMessage = vtrMessage + "It will take 10 working days from the date of your purchase to verify and activate your email system.";

                           }

                       }
                       ltrNotPurchasedMsg.Text = vtrMessage;


                       //..Check if the User has purchased eMailSystem 
                       isPurchased = objBAL_MasUser.Check_EMS_Purchase(ViewState["vMobileLoginID"].ToString());


                      //..Additionally check if the user has purchased SME Web
                       
                       //if (isPurchased == 0)
                       //{
                       //    //Find if the user purchased SME WEB 
                       //    isSMEPurchased = objBAL_User.Check_SMEWEB_Purchase(ViewState["vMobileLoginID"].ToString());  
                           
                       //    isPurchased = isSMEPurchased;

                       //}


                       if (isPurchased == 0) 
                       {
                           trNotPurchased.Visible = true;

                       }
                       else
                       {
                           LoadEMSDetails(ViewState["vMobileLoginID"].ToString());
                            trNotPurchased.Visible = false;
                       }
                       
                       
                   }
                   else
                   {
                       trPlatinum.Visible = false;
                       trUnPlatinum.Visible = true;
                   }


                   //Find if the user purchased SME WEB 
                   isSMEPurchased = objBAL_User.Check_SMEWEB_Purchase(ViewState["vMobileLoginID"].ToString());

                   if (isSMEPurchased == 0)
                   {
                     //  trNotPurchased.Visible = true;

                   }
                   else
                   {

                       vtrMessage = "Email system creation for your account is under progress. </br>";
                       vtrMessage = vtrMessage + "</br>";
                       vtrMessage = vtrMessage + "It will take 10 working days from the date of your purchase to verify and activate your email system.";
                       ltrNotPurchasedMsg.Text = vtrMessage;

                       LoadEMSDetails(ViewState["vMobileLoginID"].ToString());
                       trPlatinum.Visible = true;
                       trUnPlatinum.Visible = false;
                       trNotPurchased.Visible = false;
                       //trAlertEmailSystem.Visible = false;
                   }


                   if ((mAccountType == "PLATINUM") || (mAccountType == "TITANIUM"))
                   {
                       LoadEMSDetails(ViewState["vMobileLoginID"].ToString());
                       trNotPurchased.Visible = false;
                   }

        }

     }

    protected void LoadUserDetails(string vUserID)
    {

        string SearchStr = "Where U.UserID = " + vUserID;
        ds = objBAL_User.Retrieve_AllUserData(SearchStr, "");

        DataTable dtUserDetails;
        dtUserDetails = ds.Tables[0];

        foreach (DataRow URow in dtUserDetails.Rows)
        {
            ViewState["vMobileLoginID"] = URow["MobileLoginID"].ToString();
            ViewState["vOwnDomain"] = URow["OwnDomain"].ToString();
            ViewState["vDomainType"] = URow["UserDomainType"].ToString();


            //if (ViewState["vDomainType"].ToString() == "SME")
            //{
            //    ImgEmailLogo.ImageUrl = @"~/Images/zoho-mail.png";
            //    ltrPoweredBy.Text = " Zoho ";
            //}
            //else
            //{
            //    ImgEmailLogo.ImageUrl = @"~/Images/gmail-logo.png";
            //    ltrPoweredBy.Text = " Google ";
            //}
        }



    }

    protected void LoadEMSDetails(string vMobileLoginID)
    {
        string SearchStr = string.Empty;

        //SearchStr = " MobileLoginID = (Select MobileLoginID from tblUsers where UserID = " + vUserID + ")";
        SearchStr = " and MobileLoginID = '" + vMobileLoginID + "'";
        ds = objBAL_Gems.Retrieve_EMSContent(SearchStr); 

        DataTable dtUserDetails;
        dtUserDetails = ds.Tables[0];

        if (dtUserDetails.Rows.Count > 0)
        {

            foreach (DataRow URow in dtUserDetails.Rows)
            {
                txtAdEmailID.Text = URow["AdminID"].ToString();
                txtEmailPwd.Text = URow["AdminPwd"].ToString();

                txtEnquiryID.Text = URow["EnquiryID"].ToString();
                txtEnquiryPwd.Text = URow["EnquiryPwd"].ToString();
                //txtHttpUrlLink.Text = URow["HttpURLLink"].ToString();
                HypGmailLink.Text = URow["HttpURLLink"].ToString();
                HypGmailLink.NavigateUrl = URow["HttpURLLink"].ToString();

               // HypAdminLoginID.Text = txtAdEmailID.Text;
                
            }
        }
        else
        {
            trPlatinum.Visible = false;
            trAlertEmailSystem.Visible = true;
        }
        


    }



}
