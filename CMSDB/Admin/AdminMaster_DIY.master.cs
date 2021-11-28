using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMaster_DIY : System.Web.UI.MasterPage
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    CMSv3.BAL.User BALobjUser = new CMSv3.BAL.User();
    string tmpUserType = string.Empty;
    string mlmStatusPack = string.Empty;
    string mlmCompleteStatus = string.Empty;
    string smsBalance = string.Empty;
    string subdomainstatus = string.Empty;
    string subdomainstoreidstatus = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

       // Response.Write(Session["referringURL"].ToString()); 

        if (!IsPostBack)
        {

            String tmpAdminLanguageCode = string.Empty;

            if (Session["MobileLoginID"] != null)
            {
                //get and set  the session details
                String mUserId = Session["MobileLoginID"].ToString().Replace("EB", "");
                string strSQL = "EXEC eSMS.dbo.uspT_getUserPackageType " + mUserId;

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
                             mlmStatusPack = dbReader["mlmStatus"].ToString();
                             mlmCompleteStatus = dbReader["completeStatus"].ToString();
                             smsBalance = dbReader["smsBalance"].ToString();
                             subdomainstatus = dbReader["subdomainStatus"].ToString();
                             subdomainstoreidstatus = dbReader["storeidStatus"].ToString();
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

            if (Session["UserDomainType"] == null)
            {
                //get and set  the session details

                string strSQL = "EXEC Usp_CMS_GetUserDetailsByUserID " + Convert.ToInt32(Session["UserID"]);

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
                            Session["UserDomainType"] = dbReader["UserDomainType"].ToString();
                            tmpUserType = Session["UserDomainType"].ToString();
                            Session["defLanguageCode"] = dbReader["AdminLanguage"].ToString();
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

                //tmpUserType
            }
            else
            {
                tmpUserType = Session["UserDomainType"].ToString();
            }
         
           if(Session["BannerURL"] != null)
        {
            ImgBanner.ImageUrl = Session["BannerURL"].ToString(); 
        }
           ltrMyBtn1.Text = Resources.LangResources.MyButton + " 1";
           ltrMyBtn2.Text = Resources.LangResources.MyButton + " 2";
           ltrMyBtn3.Text = Resources.LangResources.MyButton + " 3";
           ltrMyBtn4.Text = Resources.LangResources.MyButton + " 4";
           ltrMyBtn5.Text = Resources.LangResources.MyButton + " 5";
           ltrMyBtn6.Text = Resources.LangResources.MyButton + " 6";
           ltrMyBtn7.Text = Resources.LangResources.MyButton + " 7";
           ltrMyBtn8.Text = Resources.LangResources.MyButton + " 8";

            if (tmpUserType == "SME")
            {
                // HypLnkAdSense.Visible = false;
                dvSMSBizLink.Visible = false;
                dvPremiumSMS.Visible = false;
                dvMobileWeb.Visible = false;
                dvEmail.Visible = false;

                dvSMSsystemLink.Visible = true;
                dvMobileWeb.Visible = true;

                aNews.HRef = "NewsListing.aspx?RtType=USER";
                aFaq.HRef = "FaqListing.aspx?Rttype=USER";
                aEvents.HRef = "EventsListing.aspx?Rttype=USER";
                aTestimonial.HRef = "testimonialListing.aspx?Rttype=USER";


                LinkDiyCss.Href = "../App_Themes/Default/DIY1_styles.css";
                LinkButtonCss.Href = "../App_Themes/Default/DefaultStyleSheet.css";
                LinkDefaultCss.Href = "../App_Themes/Default/NewButtons.css";



            }
            else if (tmpUserType == "EBOOK")
            {
                dvSMSBizLink.Visible = false;
                dvSMSsystemLink.Visible = false;
                dvMobileWeb.Visible = false;
                dvEmail.Visible = false;
                dvPremiumSMS.Visible = false;
                dvRegDomainLink.Visible = false;               

                LinkDiyCss.Href = "../App_Themes/Default/EbookStyles.css";
                LinkButtonCss.Href = "../App_Themes/Default/EbookStyles.css";
                LinkDefaultCss.Href = "../App_Themes/Default/EbookStyles.css";

                aNews.HRef = "NewsListing.aspx?RtType=USER";
                aFaq.HRef = "FaqListing.aspx?Rttype=USER";
                aEvents.HRef = "EventsListing.aspx?Rttype=USER";
                aTestimonial.HRef = "testimonialListing.aspx?Rttype=USER";

                aWelcome.HRef = "Ad_WelcomeEbook.aspx";

                aAccount.HRef = "Ebook_ProfilePage.aspx";

                HypWebPortal.Text = "eBook Store";

                HypWebPortal.Visible = false; 
                HypEbook.Visible = false;
                HypPreSmsSystem.Visible = false;
               // hypKeywordRegister.Visible = true; 

                
                //liEbookFree.Visible = true; 
                //liSmsSystem.Visible = true;
                liEbookSalesRecord.Visible = true;
                //lblGenrateList.Visible = true;
                lblSMSInfo.Visible = true;
                lblFreeBooks.Visible = true;
                lblWebUser.Visible = true;
                lblDFranchise.Visible = true;
                lblMarketing.Visible = true;
                //liEmailMarkting.Visible = true;
                //liEBookcodeSMS.Visible = true;

                String packPercent = string.Empty;

                if (mlmStatusPack == "0") { packPercent = "Free (20%) "; }
                if (mlmStatusPack == "1") { packPercent = "Basic (40%) "; }
                if (mlmStatusPack == "2") { packPercent = "Corporte (50%) " ; }
                if (mlmStatusPack == "3") { packPercent = "International (60%) " ; }
                if (mlmStatusPack == "4") { packPercent = "Premium (70%) " ; }
                if (mlmStatusPack == "5") { packPercent = "Venchise (80%) "; }

                lblStatus.Text = packPercent + "SMS Credit Bal: " + smsBalance.ToString();
                
              //  liEbookProfitShare.Visible = false;

                //mlmStatusPack = "0";
                if (mlmStatusPack == "0")
                {
                    if (mlmCompleteStatus == "0")
                    {
                        dvEditSubDomain.Visible = true;
                        //dvRegistration.Visible = true;
                    }
                    else
                    {
                        dvEditSubDomainC.Visible = true;
                        //dvRegistrationC.Visible = true;
                    }
                }
                else
                {
                    if (mlmCompleteStatus == "0")
                    {
                        dvRegistration.Visible = true;
                    }
                    else
                    {
                        dvRegistrationC.Visible = true;
                    }
                }                

                Render_KeywordRegister_Button();
                Render_RegistrationProcess_Button(); 


                //...language resouces...

             //   liEbookFree.InnerText = Resources.LangResources.FreeEbooks; 


              


                if (Session["EbUserPackageType"] != null)
                {
                    //if ((Session["EbUserPackageType"].ToString() == "2") && (Session["EbUserType"].ToString() == "PAID"))
                       // if (Session["EbUserKeyword"].ToString() != "")
                      //  liEbookProfitShare.Visible = true; 
                }
                else
                {
                    DataSet ds2;
                    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

                    ds2 = objEbook.Ebook_KeywordDetails_ByUserID(Convert.ToInt32(Session["UserID"]));

                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        DataRow krow = ds2.Tables[0].Rows[0];

                        Session["EbUserKeyword"] = krow["VendorCode"].ToString();
                        Session["EbUserPackageType"] = Convert.ToInt32(krow["PackageType"].ToString());
                        Session["EbUserType"] = krow["ebUserType"].ToString();
                        Session["EbookPrice"] = krow["Price"].ToString();
                        Session["vUserCurrency"] = krow["UserCurrency"].ToString();
                        Session["ShowPhyBookRequestButton"] = krow["ShowPhyBookRequestButton"].ToString();

                       // if ((Session["EbUserPackageType"].ToString() == "2") && (Session["EbUserType"].ToString() == "PAID"))
                        //if (Session["EbUserKeyword"].ToString() != "")
                        //    liEbookProfitShare.Visible = true; 
                    }

                }


                



                liINFO.Visible = true;
                //liTRAINING.Visible = true;
                //liNews.Visible = true;

                //dvEbWPNews.Visible = true;

                liButton1.Visible = true;
                aButton1.HRef = "Ad_OwnButtonCreatesEB.aspx?MyButtonNo=1"; 

                if (Session["EbUserPackageType"].ToString() == "2")
                {

                    liButton2.Visible = true;
                    liButton3.Visible = true;
                    liButton4.Visible = true;
                    liButton5.Visible = true;

                    aButton2.HRef = "Ad_OwnButtonCreatesEB.aspx?MyButtonNo=2";
                    aButton3.HRef = "Ad_OwnButtonCreatesEB.aspx?MyButtonNo=3";
                    aButton4.HRef = "Ad_OwnButtonCreatesEB.aspx?MyButtonNo=4";
                    aButton5.HRef = "Ad_OwnButtonCreatesEB.aspx?MyButtonNo=5"; 
                    

                }
                else
                {
                    liButton2.Visible = false;
                    liButton3.Visible = false;
                    liButton4.Visible = false;
                    liButton5.Visible = false;

                }



                liButton4.Visible = false;
                liButton5.Visible = false;
                liButton6.Visible = false;
                liButton7.Visible = false;
                liButton8.Visible = false;

                liBtnFaq.Visible = false;
                liBtnEvent.Visible = false;
                liBtnTestimonial.Visible = false;
                liBtnNews.Visible = false;

                liEbookCatalog.Visible = true;

                liEbookButtons.Visible = true; 
                //liEbookFeatureBuy.Visible = true;
                //liEbookValueBuy.Visible = true;
                //liEbookBestSeller.Visible = true;

                //liEbookPurchase.Visible = true;
                //liSMSPayment.Visible = true;

            }
            else
            {

                LinkDiyCss.Href = "../App_Themes/Default/DIY1_styles.css";
                LinkButtonCss.Href = "../App_Themes/Default/DefaultStyleSheet.css";
                LinkDefaultCss.Href = "../App_Themes/Default/NewButtons.css";
            }
           
          

            RenderDomainURL(Session["MobileLoginID"].ToString());

            #region -- Commented Code 

            //if (Session["MobileLoginID"] != null)
            //{
            //    //RenderDomainsAndLinks(Session["MobileLoginID"].ToString());


            //    dvSMSBizLink.Visible = true;
            //    dvSMSsystemLink.Visible = true;
            //    dvWebPortal.Visible = true; 
            //}
            //else
            //{
            //    dvSMSBizLink.Visible = false;
            //    dvSMSsystemLink.Visible = false;
            //    //ltrYourWebSiteHeader.Visible = false;
            //    dvPremiumSMS.Visible = false;
            //    dvPreSmsSystem.Visible = false;
            //    dvEbook.Visible = false;
            //    // dvYourWebSiteLinks.Visible = false;
            //}


            #endregion  


            if (Session["LoggedInFrom"] != null)
            {
                string tmpLoggedINfrom = Session["LoggedInFrom"].ToString();
                lblDebug.ToolTip = tmpLoggedINfrom; 
                //Response.Write(tmpLoggedINfrom);
                if (tmpLoggedINfrom == "SMSSYSTEM_WPY")
                {
                    dvSMSBizLink.Visible = false;
                    dvPremiumSMS.Visible = false;
                    dvEbook.Visible = false; 
                }
                else if (tmpLoggedINfrom == "WEBPORTAL")
                {
                    dvSMSBizLink.Visible = false;
                    dvPremiumSMS.Visible = false;
                    dvSMSsystemLink.Visible = false;
                    dvEbook.Visible = false; 
                }
                else if (tmpLoggedINfrom == "WESP")
                {
                    dvSMSBizLink.Visible = false;
                    dvPremiumSMS.Visible = false;
                    dvEbook.Visible = false;
                    dvPreSmsSystem.Visible = false;
                    

                }

                else if (tmpLoggedINfrom == "DPE")
                {
                    dvSMSBizLink.Visible = false;
                    dvPremiumSMS.Visible = false;
                    dvEbook.Visible = false;
                    dvPreSmsSystem.Visible = false;

                    HypSmsSystem.NavigateUrl = "~/Admin/Ad_Navigate4WebDPE.aspx";
                    HypRegDomain.NavigateUrl = "Ad_DomainRegDPE.aspx";

                    HypWebPortal.NavigateUrl = "~/Admin/Ad_WelcomeDPE.aspx";

                    aWelcome.HRef = "Ad_WelcomeDPE.aspx";


                }


                else if (tmpLoggedINfrom == "PG4MeBook1975")
                {
                    dvSMSBizLink.Visible = false;
                    dvSMSsystemLink.Visible = false;
                    dvMobileWeb.Visible = false;
                    dvEmail.Visible = false; 
                    dvPremiumSMS.Visible = false;

                    dvPreSmsSystem.Visible = true;
                    dvEbook.Visible = false; 
                    //dvINFObtn.Visible = false;

                    dvEmail.Visible = false;
                    //aEmailSystem.HRef = "Ads_EmailPageEbook.aspx";
                    HypRegDomain.NavigateUrl = "Ad_DomainRegEbook.aspx";
                   // aEmailSystem.HRef = "Ads_EmailPageEbook.aspx";
                   

                    HypEbook.CssClass = "button_GreenG";
                    HypWebPortal.CssClass = "button_GreenG";
                    HypPreSmsSystem.CssClass = "button_GreenG";

                    LinkDiyCss.Href = "../App_Themes/Default/EbookStyles.css";
                    LinkButtonCss.Href = "../App_Themes/Default/EbookStyles.css";
                    LinkDefaultCss.Href = "../App_Themes/Default/EbookStyles.css";

                    trTopRow1.Style.Add(HtmlTextWriterStyle.Height, "45px");

                    tdTopRowA.Style.Add(HtmlTextWriterStyle.PaddingLeft, "10px");
                    tdTopRowA.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#EB6E44");
                    tdTopRowB.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#EB6E44");
                    tdTopRowC.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#EB6E44");

                }

                else
                {
                    dvPreSmsSystem.Visible = false;
                    dvEbook.Visible = false;

                    LinkDiyCss.Href = "../App_Themes/Default/DIY1_styles.css";
                    LinkButtonCss.Href = "../App_Themes/Default/DefaultStyleSheet.css";
                    LinkDefaultCss.Href = "../App_Themes/Default/NewButtons.css";

                }
            }

        }

        //Hiding them 
       // ltrYourWebSiteHeader.Visible = false;
        // dvYourWebSiteLinks.Visible = false;
        //dvSMSBizLink.Visible = true;
        // dvSMSsystemLink.Visible = true;

      
        #region commented code

        if (tmpUserType == "EBOOK")
        {
           
            //aNews.HRef = "NewsListing.aspx?RtType=USER";
            //aFaq.HRef = "FaqListing.aspx?Rttype=USER";
            //aEvents.HRef = "EventsListing.aspx?Rttype=USER";
            //aTestimonial.HRef = "testimonialListing.aspx?Rttype=USER";

            
            //dvSMSBizLink.Visible = false;
            //dvSMSsystemLink.Visible = false;
            //dvMobileWeb.Visible = false;
            //dvEmail.Visible = false;
            //dvPremiumSMS.Visible = false;
 

        }

        if (tmpUserType == "SME")
        {
           
            //dvSMSsystemLink.Visible = true;
            //dvMobileWeb.Visible = true; 

            //aNews.HRef = "NewsListing.aspx?RtType=USER";
            //aFaq.HRef = "FaqListing.aspx?Rttype=USER";
            //aEvents.HRef = "EventsListing.aspx?Rttype=USER";
            //aTestimonial.HRef = "testimonialListing.aspx?Rttype=USER";


            //dvSMSBizLink.Visible = false;
            //dvMobileWeb.Visible = false;
            //dvEmail.Visible = false;
            //dvPremiumSMS.Visible = false;


            //LinkDiyCss.Href = "../App_Themes/Default/DIY1_styles.css";
            //LinkButtonCss.Href = "../App_Themes/Default/DefaultStyleSheet.css";
            //LinkDefaultCss.Href = "../App_Themes/Default/NewButtons.css";
        }


#endregion 


        if (tmpUserType == "EBOOK")
        {
            if (Session["ShowRegDomain"] == null)
            {
                RenderDomainButtonEBOOK();
            }
            else
            {
                if (Session["ShowRegDomain"].ToString() == "FALSE")
                {
                    dvRegDomainLink.Visible = false;
                }

            }
        }


        #region Own Button Show Hide 
        String Cpage = Request.RawUrl.ToLower();

        if (Cpage.Contains("account")) aAccount.Attributes.Add("class", "liActive");
        if (Cpage.Contains("event")) aEvents.Attributes.Add("class", "liActive");
        if (Cpage.Contains("faq")) aFaq.Attributes.Add("class", "liActive");
        if (Cpage.Contains("news")) aNews.Attributes.Add("class", "liActive");
        if (Cpage.Contains("event")) aEvents.Attributes.Add("class", "liActive");
        if (Cpage.Contains("testimonial")) aTestimonial.Attributes.Add("class", "liActive");
        if (Cpage.Contains("settings")) aWebSettings.Attributes.Add("class", "liActive");
       // if (Cpage.Contains("email")) aEmailSystem.Attributes.Add("class", "liActive");
        // if (Cpage.Contains("templateset")) aWebTemplate.Attributes.Add("class", "liActive");

        // if (Cpage.Contains("gallery")) aGallery.Attributes.Add("class", "liActive");
        if (Cpage.Contains("mybuttonno=1")) aButton1.Attributes.Add("class", "liActive");
        if (Cpage.Contains("mybuttonno=2")) aButton2.Attributes.Add("class", "liActive");
        if (Cpage.Contains("mybuttonno=3")) aButton3.Attributes.Add("class", "liActive");

        if (tmpUserType != "EBOOK")
        {
            if (Cpage.Contains("mybuttonno=4")) aButton4.Attributes.Add("class", "liActive");
            if (Cpage.Contains("mybuttonno=5")) aButton5.Attributes.Add("class", "liActive");
            if (Cpage.Contains("mybuttonno=6")) aButton6.Attributes.Add("class", "liActive");
            if (Cpage.Contains("mybuttonno=7")) aButton7.Attributes.Add("class", "liActive");
            if (Cpage.Contains("mybuttonno=8")) aButton8.Attributes.Add("class", "liActive");

          

        }


        if (tmpUserType == "EBOOK")
        {
            //if (Cpage.Contains("feature")) aEBFeatureBuy.Attributes.Add("class", "liActive");
            //if (Cpage.Contains("bestseller")) aEBBestSeller.Attributes.Add("class", "liActive");
            //if (Cpage.Contains("valuebuy")) aEBValueBuy.Attributes.Add("class", "liActive");

            if (Cpage.Contains("feature")) aEbButtons.Attributes.Add("class", "liActive");
            if (Cpage.Contains("bestseller")) aEbButtons.Attributes.Add("class", "liActive");
            if (Cpage.Contains("valuebuy")) aEbButtons.Attributes.Add("class", "liActive");

            if (Cpage.Contains("catalog")) aEbCatalog.Attributes.Add("class", "liActive");
        }


        #endregion 

    }

    protected void RenderDomainURL (string vMobileLoginId)
    {
        if (Session["UserDomainURL"] != null)
        {

            HypSampleURL.Text = Session["UserDomainURL"].ToString();
            HypSampleURL.NavigateUrl = Session["UserDomainURL"].ToString();
            HypSampleURL.Target = "_blank";
        }
        else
        {
            RenderDomainsAndLinks(vMobileLoginId);
        }
    }

    protected void RenderDomainsAndLinks(string vMobileLoginID)
    {
        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();
       
        dsCheck = objBAL_User.CheckUser_ValidateByMobileLogin(vMobileLoginID);

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
        String URLSubDomainEbook = string.Empty; 

        if ((UserStatus_Value == "MATCHED") || (UserStatus_Value == "SUBDOMAIN_FOUND"))
        {
            DataRow UserRecord_Row = dtUserRecord.Rows[0];

            string tmpOwnDomainName = UserRecord_Row["OwnDomain"].ToString();
            string tmpSubDomainName = UserRecord_Row["SubDomain"].ToString();
            string tmpAnchorDomain = UserRecord_Row["AnchorDomain"].ToString();
            string tmpADomain =  UserRecord_Row["ADomain"].ToString();

            String UrlSubDomainName1 = string.Empty;

            if (tmpAnchorDomain != "")
            {                
                UrlSubDomainName1 = tmpSubDomainName + "." + tmpAnchorDomain;
            }
            else
            {
                UrlSubDomainName1 = tmpSubDomainName + "." + GlobalVar.GetAnchorDomainName;
               
            }


            //string UrlSubDomainName2 = vMobileLoginID + "." + GlobalVar.GetAnchorDomainName;
            String UrlSubDomainName2 = tmpSubDomainName + "." + "1amwaywebsite.com";
            String UrlSubDomainName3 = tmpSubDomainName + "." + "1financialconsultant.com";
            String UrlAncLinks = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>" +
                                  "<br/>" +
                                  "<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName3 + "'>" + UrlSubDomainName3 + "</a>";

            if (tmpADomain != "")
            {
                URLSubDomainEbook = tmpSubDomainName + "." + tmpADomain;
            }
            else
            {
                URLSubDomainEbook = tmpSubDomainName + "." + "eVenchise.com";
            }
            

            if (tmpOwnDomainName != "")
            {
                tmpOwnDomainName = "www." + tmpOwnDomainName;

                // lblOwnDomainName.Text = @"<a target='_blank' class='links_DomainName' href='http://" + tmpOwnDomainName + "'>" + tmpOwnDomainName + "</a>" + " <br />";
            }
            // lblOwnDomainName.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>" + " <br />";
            //lblSubDomain1.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>" + UrlSubDomainName1 + "</a>" + " <br />";
            //lblSubDomain2.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>";
            //lblSubDomain2.Text = @"<a target='_blank' class='links_DomainName' alt='Click to view more of your SubDomains List' href='Ad_DomainsListSubs.aspx'>" + UrlSubDomainName2 + "</a>";
            //  HypYourSubDomains.Text = UrlSubDomainName1 + "<br/>" + "...Click to view more SubDomainLinks"; //+ "<br/>" + UrlSubDomainName3;

            //Response.Write(tmpUserType + "<br>");
            //Response.End();


            if (tmpOwnDomainName != "")
            {
                HypSampleURL.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + tmpOwnDomainName + "'>" + tmpOwnDomainName + "</a>" + " <br />";
            }
            else
            {
                if (tmpUserType == "SME")
                    HypSampleURL.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>Your SampleURL </a>" + " <br />";

                else if (tmpUserType == "EBOOK")
                    HypSampleURL.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + URLSubDomainEbook + "'>" + URLSubDomainEbook + "</a>" + " <br />";

                else
                    HypSampleURL.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>" + UrlSubDomainName1 + "</a>" + " <br />";
            }

        }


    }

    protected void Render_RegistrationProcess_Button()
    {
        if (Session["isRegCompleted"] == null)
        {

            CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();


            int isRegCompleted = objEbook.EBook_RegProcess_GetStatus(Convert.ToInt32(Session["UserID"].ToString()));
            Session["isRegCompleted"] = isRegCompleted;

            if (isRegCompleted == 1)
            {
                lblRegProcessStatus.Text = "";
                lblRegProcessStatus.CssClass = "fontCompleted";

            }

        }
        else
        {

                CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();


                int isRegCompleted = Convert.ToInt32(Session["isRegCompleted"].ToString()); 

                if (isRegCompleted == 1)
                {
                    lblRegProcessStatus.Text = "";
                    lblRegProcessStatus.CssClass = "fontCompleted";
                    
                }
        }
     }

    protected void Render_KeywordRegister_Button()
     {
         int vPremiumStatus = 0;
         int vPackageType = 0;
         String vVendorCode = string.Empty;


         if (Session["VendorCode"] == null)
         {

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



                 //// if PremiumStatus = 1 is PAID,  0 is FREE 
                 //if (vPremiumStatus == 1)
                 //{
                 //    if (vPackageType == 2)
                 //    {
                 //        if (vVendorCode == "NONE")
                 //            hypKeywordRegister.Visible = true;
                 //        else
                 //            hypKeywordRegister.Visible = false;
                 //    }
                 //    else
                 //    {
                 //        hypKeywordRegister.Visible = false;
                 //    }
                 //}
                 //else
                 //{
                 //    hypKeywordRegister.Visible = false;
                 //}

             }


         }
         else
         {

             vPackageType = Convert.ToInt16(Session["PackageType"].ToString());
             vPremiumStatus = Convert.ToInt16(Session["PremiumStatus"].ToString());
             vVendorCode = Session["VendorCode"].ToString();



             // if PremiumStatus = 1 is PAID,  0 is FREE 
             //if (vPremiumStatus == 1)
             //{
             //    if (vPackageType == 2)
             //    {
             //        if ((vVendorCode == "NONE") || (vVendorCode == ""))
             //            hypKeywordRegister.Visible = true;
             //        else
             //            hypKeywordRegister.Visible = false;
             //    }
             //    else
             //    {
             //        hypKeywordRegister.Visible = false;
             //    }
             //}
             //else
             //{
             //    hypKeywordRegister.Visible = false;
             //}
         }


     }

    protected void RenderDomainButtonEBOOK()
    {
        SqlConnection EBdbConn;
        SqlCommand EBdbCmd;
        SqlDataReader EBdbReader;

        String dbcString = ConfigurationManager.AppSettings["eBookDB"].ToString();

        EBdbConn = new SqlConnection(dbcString);

        EBdbConn.Open();
        String strSQL = "EXEC [USP_EBOOK_GetDetailsbyMID] " + Convert.ToInt32(Session["MERID"]);

        EBdbCmd = new SqlCommand(strSQL, EBdbConn);
        EBdbReader = EBdbCmd.ExecuteReader();

        String tmpPackageType = String.Empty;
        String tmpPremiumStatus = String.Empty;
        String tmpebUserType = String.Empty;


        if (EBdbReader.HasRows)
        {
            while (EBdbReader.Read())
            {
                //.... Handphone is reffered to mobileloginID... 
                tmpPackageType = EBdbReader["PackageType"].ToString();
                tmpPremiumStatus = EBdbReader["PremiumStatus"].ToString();
                tmpebUserType = EBdbReader["ebUserType"].ToString();
            }
        }

        EBdbConn.Close();
        EBdbReader.Close();


        if (tmpebUserType != string.Empty)
        {

            if (tmpebUserType == "FREE")
            {
                if (tmpPremiumStatus == "0")
                {
                    //HtmlGenericControl dvRegDomainLink;
                    //dvRegDomainLink = (HtmlGenericControl)Page.Master.FindControl("dvRegDomainLink");

                    dvRegDomainLink.Visible = false;
                    Session["ShowRegDomain"] = "FALSE";
                }
            }
        }




    }

}
