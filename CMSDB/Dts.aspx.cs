using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.Threading;
using CMSv3.Entities;
using CMSv3.BAL;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

public partial class Dts : System.Web.UI.Page 
{

    //CMSv3.Entities.ClientData objClientData = new CMSv3.Entities.ClientData();

    protected void Page_Load(object sender, EventArgs e)
    {


        DataSet MainDS;
        DataTable tbMenu;
        DataTable tbNews;
        DataTable tbHomePgContent;
        DataTable tbEvents;
        DataTable tbTestimonials;
        DataTable tbFollowus;
        DataTable tbWelComepage;
        DataTable tbContactUs;
        DataTable tbTopRowLinks;

        string tmpUserDomainType = string.Empty;

        CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();

        
        ltrLoginTitle.Text = ConfigurationManager.AppSettings["LoginTitle"].ToString();


        

        if (!IsPostBack)
        {


            #region Mobile Detection and Redirection to WebPortal

            if ((Request.QueryString["pgFrom"] != null) && (Request.QueryString["pgFrom"] != ""))
            {
                if ((Request.QueryString["pgFrom"] == "1MACC") || (Request.QueryString["pgFrom"] == "SMSSYSTEM") || (Request.QueryString["pgFrom"] == "SMSSYSTEM_WPY") || (Request.QueryString["pgFrom"] == "SMSSYSTEM_WPN"))
                { Log2AdminforUser(Request.Url.OriginalString);
                }
            }
            else
            {
                if (Request.Url != null)
                {
                    if (CommonFunctions.IsMobile())
                    {
                        if (Session["FWmode"] != null)
                        {
                            if (Session["FWmode"].ToString() == "ON")
                            {

                            }
                        }
                        else
                        {
                            Response.Redirect("~/Mb/Index.aspx");
                        }
                    }
                }
            }
            #endregion 


            txtLoginID.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");

            //Log2AdminforUser("60178486078.1smsbusiness.com");
            //MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["UserID"]));

            // Create the Client ID session Based on the Domain Entered in the URL 
           // Session["ClientID"] = Convert.ToInt32(GlobalVar.GetTestLoginUser);

            //Log2AdminforUser("www.krissh.1argentinasms.com");
           
            //...if Coming from Loggedin Session at 1Malaysia or SMSsystem. 
            
            //if((Request.QueryString["pgFrom"] != null) || (Request.QueryString["pgFrom"] != ""))
            //{
            //    if ((Request.QueryString["pgFrom"] == "1MACC") || (Request.QueryString["pgFrom"] == "SMSSYSTEM") || (Request.QueryString["pgFrom"] == "SMSSYSTEM_WPY") || (Request.QueryString["pgFrom"] == "SMSSYSTEM_WPN"))
            //    {
            //        Log2AdminforUser(Request.Url.OriginalString);
            //    }
            //}

            string isDemo = ConfigurationManager.AppSettings["isDemo"].ToString();
            
            if (isDemo == "true")
            {
                Session["ClientID"] = Convert.ToInt32(GlobalVar.GetTestLoginUser);
            }
            else
            {
               Session["ClientID"] = GetUserIdfromURL();
               // Session["ClientID"] = CommonFunctions.fnGetUserIdfromURL(); 
            }
            
            
            if (Convert.ToInt32(Session["ClientID"]) == 0)
            {
                Response.Redirect("PartnerWebRegistrationNew.aspx");
               // Response.Redirect("InValidDomain.aspx");
                
            }



            #region // find out the Users MasterPage settings 
            //if (Session["MasterPageFile"] == null)
            string tmpMasterfile = string.Empty;
            string tmpMasterCss = string.Empty;

            //{
                //string strSQL = "Select MasterPageName, Case WHEN MasterCSS is NULL Then 'CommonStyleSheet.css' Else MasterCSS END as MasterCss" + 
                //                "from tblUserMasterPage = " + Convert.ToInt32(Session["ClientID"]);


                string strSQL = "Select UserID, MasterPageName, " +
                            "Case WHEN MasterPageName = 'UserMaster.master' and MasterCSS is NULL Then 'CommonStyleSheet.css' " +
                            "WHEN MasterPageName = 'TmpMaster1.master' and MasterCSS is NULL Then 'TmpStyleSheet2.css' " + 
                            "Else MasterCSS END as MasterCss from tblUserMasterPage where UserId = " + Convert.ToInt32(Session["ClientID"]);

                
            
                
                SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                dbConn.Open();
                SqlCommand dbCmd = new SqlCommand("usp_Retreive_UserMasterPageAndCss", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = Convert.ToInt32(Session["ClientID"]);
                SqlDataReader dbReader;
                dbReader = dbCmd.ExecuteReader();

                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {
                        tmpMasterfile = dbReader["MasterPageName"].ToString();
                        tmpMasterCss = dbReader["MasterCSS"].ToString();
                    }
                }
    
                dbConn.Close();

                if (!tmpMasterfile.Equals(string.Empty))
                {
                    Session["MasterPageFile"] = tmpMasterfile;
                    Session["MasterPageCss"] = tmpMasterCss;


                    Template1_Css.Href = "App_Themes/Common/" + tmpMasterCss;
                    //Template1_Css.Href = "App_Themes/Common/UserMaster_Green.css";

                    Response.Redirect("dtx.aspx");
                    //switch (tmpMasterfile)
                    //{
                    //    case "TmpMaster1.master": Response.Redirect("dt1.aspx");
                    //        break;

                    //    case "TmpMaster2.master": Response.Redirect("dt2.aspx");
                    //        break;

                    //    case "TmpMaster3.master": Response.Redirect("dt3.aspx");
                    //        break;

                    //    case "TmpMaster4.master": Response.Redirect("dt4.aspx");
                    //        break;

                    //    case "TmpMaster5.master": Response.Redirect("dt5.aspx");
                    //        break;

                    //    case "TmpMaster5AA.master": Response.Redirect("dt5A.aspx");
                    //        break;

                    //    case "TmpMaster6.master": Response.Redirect("dt6.aspx");
                    //        break;


                    //}

                 
                    
                }

            //}
            //else
            //{
            //    if (Session["MasterPageFile"].ToString() == "TmpMaster1.master")
            //    {
            //        Response.Redirect("default_T1.aspx");
            //    }
            //}
           
            #endregion



            //objClientData.UserID = Convert.ToInt32(Session["ClientID"]);


            MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));

            tbMenu = MainDS.Tables[0];              //tbltopMenuLinks
            tbHomePgContent = MainDS.Tables[1];     //tblHomePgSettings
            tbNews = MainDS.Tables[2];              //tblNews
            tbEvents = MainDS.Tables[3];            //tblEvents
            tbTestimonials = MainDS.Tables[4];      //tblTestimonials
            tbFollowus = MainDS.Tables[5];          //tblCommAppLinks
            tbWelComepage = MainDS.Tables[6];       //tblWelcomePage
            tbContactUs = MainDS.Tables[7];         //tblUserDetails (contact us details)
            tbTopRowLinks = MainDS.Tables[8];      //tblRow Links
            
            int i = 1;
            //for (i = 0; i <= tbMenu.Rows.Count - 1; i++)
            //{   //Response.Write(tbMenu.Rows[i].ItemArray[0] + " -- " + tbMenu.Rows[i].ItemArray[1]);
            // }


            //--- Load other Homepage Content and Title  --//
            #region Retrieve HomePageContent


            for (i = 0; i <= tbHomePgContent.Rows.Count - 1; i++)
            {
                DataRow HpgRow = tbHomePgContent.Rows[i];

                //DateTime dtn = Convert.ToDateTime(HpgRow["tstCreatedDate"].ToString());
                //string tFooter = "By " + HpgRow["tstByName"].ToString() + " - " + dtn.ToString("MMM dd, yyyy");

                //.Default Language 


                if (Session["defLanguage"] == null)
                {
                    string selectedLanguage = string.Empty;
                    string tmpDefLang = HpgRow["LangCulture"].ToString();

                    if (tmpDefLang.Trim() == "")
                        selectedLanguage = GlobalVar.Lang_English;
                    else
                        selectedLanguage = tmpDefLang.Trim();

                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

                    Session["defLanguage"] = selectedLanguage;
                }
                else
                {
                    string selectedLanguage = string.Empty;
                    selectedLanguage = Session["defLanguage"].ToString();

                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
                }




                //Companyinfo
                dvCompanyName.InnerText = (string)GetGlobalResourceObject("LangResources", "Welcometo") + " " + HpgRow["CompanyName"].ToString();


                //Images
                string tmpLogoImage = HpgRow["LogoImg"].ToString();
                if (tmpLogoImage.Substring(0, 8) == "LogoTemp")
                {
                    string tmpCompanyName = HpgRow["CompanyName"].ToString();
                    string tmpLogoHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                    //tmpLogoHtml = tmpLogoHtml + "&nbsp; <font class='LogoText'>" + tmpCompanyName + "</font>";
                    dvLogoImage.InnerHtml = tmpLogoHtml;
                    if (tmpCompanyName.Length > 25)
                    {
                        dvLogoText.InnerHtml = "<font class='LogoText3'>" + tmpCompanyName + "</font>";
                    }
                    else if (tmpCompanyName.Length > 20)
                    {
                        dvLogoText.InnerHtml = "<font class='LogoText2'>" + tmpCompanyName + "</font>";
                    }
                    else 
                    {
                        dvLogoText.InnerHtml = "<font class='LogoText'>" + tmpCompanyName + "</font>";
                    }

                }
                else
                {
                    dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                }



                // if Banner is a flash file (.swf) then 

                if (HpgRow["BannerImg"].ToString().Contains(".swf"))
                {
                    // rdoBannerImage.Items.Add(new ListItem(String.Format("<object width='800' height='200'><param name='movie' value='{0}'><embed src='{0}' width='800' height='200'></embed></object>", ImageFolder + Brow["ImgName"].ToString()), Brow["ImageID"].ToString())); ;
                    dvBannerImg.InnerHtml = "<object width='800' height='200'><param name='movie' value='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "'><embed src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' width='800' height='200'></embed></object>";
                }
                else
                {
                    dvBannerImg.InnerHtml = "<img alt='banner image'  class='divCssBannerImg' src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' />";
                }


               // dvBannerImg.InnerHtml = "<img alt='banner image'  class='divCssBannerImg' src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' />";


                dvCopyRights.InnerText = HpgRow["CopyRightsInfo"].ToString();
                Session["CopyRightsInfo"] = HpgRow["CopyRightsInfo"].ToString();
                //objClientData.CopyRightsInfo = HpgRow["CopyRightsInfo"].ToString();


                //... Company Name...
                if (HpgRow["CompanyName"].ToString().Trim() != "")
                 ltrCompanyName.Text = "&nbsp;<b>" + HpgRow["CompanyName"].ToString() + "</b>";


            }

            #endregion

           // Session["ClientData"] = objClientData;


            // -- load welcome page data

            //lblHomePageContent.Text = HpgRow["CompanyInfo"].ToString().Replace(Environment.NewLine, "<br/>");

            foreach (DataRow wpRow in tbWelComepage.Rows)
            {
                lblHomePageContent.Text = wpRow["Description"].ToString().Replace(Environment.NewLine, "<br/>");
            }


            //retrieve Menu table data 
            #region Retrieve Menu Links 

            string tmpCultureMenuName = string.Empty;
            string tmpMenuName = string.Empty;
            string strMenuBarChars = string.Empty;

                StringBuilder sbMenu = new StringBuilder();
                StringBuilder SbMenuMore = new StringBuilder();

                sbMenu.Append("<ul>");

                //if (tbMenu.Rows.Count > 8)
                //    strMenuClassName = "links_MainMenuBar70";

                foreach (DataRow mRow in tbMenu.Rows)
                {

                    //String TmpMenuEncodedName = "UsersOwnPage.aspx?BN=" + HttpUtility.UrlEncode(mRow["LinkName"].ToString());
                    String TmpMenuEncodedName = "UsersOwnPage.aspx?Bt=" + mRow["ButtonNo"].ToString() + "&BN=" + HttpUtility.UrlEncode(mRow["LinkName"].ToString());
                    //if (i < 10)
                    //{
                    sbMenu.Append("<li>");
                    if (mRow["LinkURL"].ToString().Contains("UsersOwnPage"))
                        sbMenu.Append("<a class='links_MainMenuBar' href='" + TmpMenuEncodedName + "'>");
                    else
                        sbMenu.Append("<a class='links_MainMenuBar' href='" + mRow["LinkURL"].ToString() + "'>");

                        tmpMenuName = mRow["LinkName"].ToString().Trim();
                        tmpCultureMenuName = (string)GetGlobalResourceObject("LangResources", tmpMenuName.ToLower());
                        if (tmpCultureMenuName != null)
                        {
                            sbMenu.Append(tmpCultureMenuName);
                            strMenuBarChars +=  tmpCultureMenuName;
                        }
                        else
                        {
                            sbMenu.Append(mRow["LinkName"].ToString());
                            strMenuBarChars += mRow["LinkName"].ToString();
                        }

                        sbMenu.Append("</a></li>");
                    //}
                    //else
                    //{
                    //    //SbMenuMore.Append("<li>");
                    //    //SbMenuMore.Append("<a class='indentmenuDropDown' href='" + mRow["LinkURL"].ToString() + "'>");
                    //    //SbMenuMore.Append(mRow["LinkName"].ToString());
                    //    //SbMenuMore.Append("</a></li>");
                    //}
                    

                    i++;


                    //Response.Write(mRow["LinkID"].ToString() + "|" + mRow["LinkName"].ToString() + "-");
                }

                //sbMenu.Append("<li>");
                //sbMenu.Append("<a href='#'> MORE </a>");
                //sbMenu.Append(SbMenuMore.ToString());
                //sbMenu.Append("</li>");

                sbMenu.Append("</ul>");

                if (strMenuBarChars.Length > 81)
                {
                    sbMenu.Replace("links_MainMenuBar", "links_MainMenuBar70");
                }

                dvTopMenu.InnerHtml = "";
                dvTopMenu.InnerHtml = sbMenu.ToString();
            

               // DownMenu.InnerHtml = sbMenu.ToString();


            #endregion


            //retrieve Top Most Menu Links 
            #region Code Section : TopMost Row Links

                //retrieve and Render TopMenu Menu 
                StringBuilder topRowMenu = new StringBuilder();
                String tmpTopRowLinkName = string.Empty;

                foreach (DataRow mRow in tbTopRowLinks.Rows)
                {
                    tmpTopRowLinkName = mRow["LinkName"].ToString().Trim();

                    //UserControl ucTopMenu = (UserControl)Page.Master.FindControl("TopMostMenu1");
                    UserControl ucTopMenu = (UserControl)Page.FindControl("TopMostMenu1"); 
                    if (ucTopMenu != null)
                    {

                        if (tmpTopRowLinkName.ToUpper().Contains("HOME"))
                        {
                            HyperLink objHypHome = (HyperLink)ucTopMenu.FindControl("HypHome");
                            if (objHypHome != null) objHypHome.Visible = true;

                            HtmlImage objImgHome = (HtmlImage)ucTopMenu.FindControl("imgHome");
                            if (objImgHome != null) objImgHome.Visible = true;
                        }
                        else if (tmpTopRowLinkName.ToUpper().Contains("FREE"))
                        {
                            HyperLink objHypFreeSMS = (HyperLink)ucTopMenu.FindControl("HypFreeSMS");
                            if (objHypFreeSMS != null) objHypFreeSMS.Visible = true;
                        }
                        else if (tmpTopRowLinkName.ToUpper().Contains("CONTACT"))
                        {
                            HyperLink objHypContactUs = (HyperLink)ucTopMenu.FindControl("HypContactUs");
                            if (objHypContactUs != null) objHypContactUs.Visible = true;
                        }
                        else if (tmpTopRowLinkName.ToUpper().Contains("CUSTOMER"))
                        {
                            HyperLink objHypSMSlogin = (HyperLink)ucTopMenu.FindControl("HypSMSlogin");
                            if (objHypSMSlogin != null) objHypSMSlogin.Visible = true;

                            HtmlImage ObjimgCustLogin = (HtmlImage)ucTopMenu.FindControl("imgCustLogin");
                            if (ObjimgCustLogin != null) ObjimgCustLogin.Visible = true;
                        }
                        else if (tmpTopRowLinkName.ToUpper().Contains("LANGUAGE"))
                        {

                            //... the language dropdown is outside of the Top Menu 
                            HtmlGenericControl objDvLangDpd = (HtmlGenericControl)Page.FindControl("dvLangdropDown");
                            if (objDvLangDpd != null) objDvLangDpd.Visible = true;

                        }




                    }



                }

                #endregion  //... end of Topmost Row Links 

            //--- Load News Items  --//
            #region Retrieve News Items


                for (i = 0; i <= tbNews.Rows.Count - 1; i++)
                {
                    DataRow mNewsRow = tbNews.Rows[i];
                    if (i == 0)
                    {
                        DateTime dtn = Convert.ToDateTime(mNewsRow["NewsDate"].ToString());
                        dvRecNewsHead1.InnerText = dtn.ToString("MMM dd, yyyy");
                       // dvRecNewsContent1.InnerText = mNewsRow["NewsContent"].ToString();
                        string tmpNewsContent = mNewsRow["NewsContent"].ToString();
                       // tmpNewsContent = tmpNewsContent.Replace("<br/>", Environment.NewLine);
                       // AreaNewContent.Value = tmpNewsContent;
                        tmpNewsContent = tmpNewsContent.Replace(Environment.NewLine,"<br/>");
                        lblNewsContent.Text = tmpNewsContent;

                    }
                    //else if (i == 1)
                    //{
                    //    DateTime dtn = Convert.ToDateTime(mNewsRow["NewsDate"].ToString());
                    //    dvRecNewsHead2.InnerText = dtn.ToString("MMM dd, yyyy");
                    //    //dvRecNewsContent2.InnerText = mNewsRow["NewsContent"].ToString();
                    //    string tmpNewsContent = mNewsRow["NewsContent"].ToString();
                    //    tmpNewsContent = tmpNewsContent.Replace("<br/>", Environment.NewLine);
                    //    AreaNewContent2.Value = tmpNewsContent;
                    //}
                }
            
            
            #endregion


                //--- Load Events Items  --//
            #region Retrieve Events Items


                for (i = 0; i <= tbEvents.Rows.Count - 1; i++)
                {
                    DataRow mEventsRow = tbEvents.Rows[i];
                    if (i == 0)
                    {
                        DateTime dtn = Convert.ToDateTime(mEventsRow["EventDate"].ToString());
                       dvEventsHead1.InnerText = dtn.ToString("MMM dd, yyyy");
                        //dvEventsHead1.InnerText = dtn.ToString("D");
                       String tmpEventContent = mEventsRow["EventContent"].ToString();
                       //tmpEventContent = tmpEventContent.Replace("<br/>", "\r\n");
                       
                       tmpEventContent = tmpEventContent.Replace(Environment.NewLine,"<br/>");
                       //AreaEvtContent.Value = tmpEventContent.ToString();
                       lblEventContent.Text = tmpEventContent.ToString();
                        //dvEventsContent1.InnerHtml = "<pre> " + tmpEventContent.ToString() + "</pre>";
                       //dvEventsContent1.InnerText = "<pre> " + tmpEventContent.ToString() + "</pre>";
                       //LtrEvtContent.Text = tmpEventContent;
                        

                    }
                    //else if (i == 1)
                    //{
                    //    DateTime dtn = Convert.ToDateTime(mEventsRow["EventDate"].ToString());
                    //    dvEventsHead2.InnerText = dtn.ToString("MMM dd, yyyy");
                    //    //dvEventsContent2.InnerText = mEventsRow["EventContent"].ToString();

                    //    string tmpEventContent2 = mEventsRow["EventContent"].ToString();
                    //    tmpEventContent2 = tmpEventContent2.Replace("<br/>", Environment.NewLine);
                    //    AreaEvtContent2.Value = tmpEventContent2.ToString();

                    //}
                }


            #endregion


            //--- Load Tesimonial Items  --//
            #region Retrieve Testimonial data 

                //for (i = 0; i <= tbTestimonials.Rows.Count - 1; i++)
                //{
                //    DataRow mTestimonialsRow = tbTestimonials.Rows[i];
                    
                //        DateTime dtn = Convert.ToDateTime(mTestimonialsRow["tstCreatedDate"].ToString());
                //        string tFooter = "By " + mTestimonialsRow["tstByName"].ToString() + " - " + dtn.ToString("MMM dd, yyyy");

                //    string tmpTestimonialContent = mTestimonialsRow["tstContent"].ToString().ToString().Replace("<br/>",Environment.NewLine);
                //    AreaTestimonialContent.Value = tmpTestimonialContent;
                        
                //       // dvTestimContent.InnerText = mTestimonialsRow["tstContent"].ToString().Replace("<br/>",Environment.NewLine);
                //        dvTestimFooter.InnerHtml = "<img src='Images/testiarrow.gif' alt='arrowimg' />" + tFooter;
                //        //dvTestimContent.InnerText
                    
                    
                //}

            #endregion



            // -- Load Contact Us Details -- ///
            #region Retreive Contact us Details

                foreach (DataRow CntRow in tbContactUs.Rows)
                {

                    tmpUserDomainType = CntRow["UserDomaintype"].ToString().Trim();

                    // lblHomePageContent.Text = CntRow["Description"].ToString().Replace(Environment.NewLine, "<br/>");
                    if ((CntRow["Email"].ToString().Trim() != "") && (CntRow["EmailChk"].ToString()  == "True"))
                        LtrContactUs_Email.Text = @"&nbsp;<img title='Email'  src='Images\icon_email_sml.jpg' /> : <b>" + CntRow["Email"].ToString() + "</b>";

                    if ((CntRow["FaxNo"].ToString().Trim() != "") && (CntRow["FaxNoChk"].ToString() == "True"))
                        LtrContactUs_Fax.Text = @"&nbsp;<img title='FaxNo'  src='Images\icon_fax_sml.jpg' /> : + <b>" + CntRow["FaxNo"].ToString() + "</b>";

                    if ((CntRow["Homephone"].ToString().Trim() != "") && (CntRow["HomephoneChk"].ToString() == "True"))
                        ltrContactUs_HomePhone.Text = @"&nbsp;<img title='HomePhone' src='Images\icon_homephone_sml.jpg' /> : + <b>" + CntRow["Homephone"].ToString()  + "</b>";

                    if ((CntRow["Handphone"].ToString().Trim() != "") && (CntRow["HandphoneChk"].ToString() == "True"))
                        LtrContactUs_HandPhone.Text = @"&nbsp;<img title='Handphone'  src='Images\icon_handphone_sml.jpg' /> : + <b>" + CntRow["Handphone"].ToString() + "</b>";

                    if (CntRow["NickName"].ToString().Trim() != "")
                        ltrNickName.Text = @"&nbsp;<b>" + CntRow["NickName"].ToString() + "</b>";

                    if (CntRow["FullImgPath"].ToString() != "")
                    {
                        ImgContact.ImageUrl = CntRow["FullImgPath"].ToString();
                    }
                    else
                    {
                        ImgContact.Visible = false;
                    }
                    //description for ComapnyName can be found above in the homepage section.
                }


                #endregion


            //--- Load Follow Us Items  --//
            #region Retreive Follow us links and images 
                StringBuilder sbFlw = new StringBuilder();
                string mFollowImgHtml = string.Empty; 
                for (i = 0; i <= tbFollowus.Rows.Count - 1; i++)    
                    {
                        if (i == 0)
                            mFollowImgHtml = "<tr>";
                        else
                            mFollowImgHtml = string.Empty;
                                

                        DataRow mFollowusRow = tbFollowus.Rows[i];
                       
                     //if (mFollowusRow["Selected"].ToString() == "1")
                     //   {
                     //       //mFollowImgHtml = "<div style='float:left;'><img  href='" + mFollowusRow["ComAppURL"].ToString() + "' src='" + @"Images\client\logos\" + mFollowusRow["ComAppImg"].ToString() + "' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/> </div>";
                     //       mFollowImgHtml = mFollowImgHtml + "<td><a href='#'><img border='0'  href='" + mFollowusRow["ComAppURL"].ToString() + "' src='" + @"Images\client\logos\" + mFollowusRow["ComAppImg"].ToString() + "' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/></a></td>";
                     //   }
                     //   else
                     //   {
                     //       //mFollowImgHtml = "<div style='float:left;' class='opacityit'> <img  href='" + mFollowusRow["ComAppURL"].ToString() + "' src='" + @"Images\client\logos\" + mFollowusRow["ComAppImg"].ToString() + "' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/></div>";
                     //       mFollowImgHtml = mFollowImgHtml + "<td><a href='#' class='opacityit'><img  border='0' href='" + mFollowusRow["ComAppURL"].ToString() + "' src='" + @"Images\client\logos\" + mFollowusRow["ComAppImg"].ToString() + "' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/></a></td>";
                     //   }
                     //     //string mFollowImgHtml = "<a href='ymsgr:sendim?msri_hari&m=hi+this+is+hari+from+globalsurf'><img src='" + @"Images\client\logos\" + mFollowusRow["ComAppImg"].ToString() + "' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/></a>";
                     //    // string mFollowImgHtml = "<a href='ymsgr:sendim?msri_hari&m=hi+this+is+hari+from+globalsurf'><img src='http://opi.yahoo.com/online?u=msri_hari&m=g&t=2' border='0' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/></a>";    
                        //mFollowImgHtml = "<div>" + mFollowImgHtml  + "</div>";  

                    
                        if ((mFollowusRow["YahooChecked"].ToString() == "True") && (mFollowusRow["YahooID"].ToString() != "") && (mFollowusRow["YahooID"].ToString() != null))
                        {
                            mFollowImgHtml = mFollowImgHtml + "<td><a target='_new'  href='ymsgr:sendIM?" + mFollowusRow["YahooID"].ToString() + "'><img border='0'   src='" + @"Images\client\logos\yahooLogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='yahoo'/></a></td>";
                                i += 1;
                        }

                        //if (tmpUserDomainType == "WEB30")
                        //{
                            if ((mFollowusRow["HotmailChecked"].ToString() == "True") && (mFollowusRow["HotmailID"].ToString() != "") && (mFollowusRow["HotmailID"].ToString() != null))
                            {
                               // mFollowImgHtml = mFollowImgHtml + "<td><a target='_new'  href='msnim:chat?contact=" + mFollowusRow["HotmailID"].ToString() + "'><img border='0'   src='" + @"Images\client\logos\MsnLogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='MSN'/></a></td>";
                                mFollowImgHtml = mFollowImgHtml + "<td><a target='_blank' href='http://settings.messenger.live.com/Conversation/IMMe.aspx?invitee=" + mFollowusRow["HotmailID"].ToString() + "&mkt=en-in'>" +
                                                            "<img style='border-style: none;' src='" + @"Images\client\logos\MsnLogo.jpg'/></a></td>";
                                i += 1;
                            }
                            if ((mFollowusRow["GoogleChecked"].ToString() == "True") && (mFollowusRow["GoogleID"].ToString() != "") && (mFollowusRow["GoogleID"].ToString() != null))
                            {
                                //mFollowImgHtml = mFollowImgHtml + "<td><a href='#'><img border='0'  href='" + mFollowusRow["ComAppURL"].ToString() + "' src='" + @"Images\client\logos\" + mFollowusRow["ComAppImg"].ToString() + "' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/></a></td>";

                                //   mFollowImgHtml = mFollowImgHtml + @"<script src='http://www.gmodules.com/ig/ifr?url=http://www.google.com/ig/modules/googletalk.xml&amp;synd=open&amp;w=320&amp;h=451&amp;title=Google+Talk&amp;border=%23ffffff%7C0px%2C1px+solid+%2399BB66%7C0px%2C2px+solid+%23AACC66%7C0px%2C2px+solid+%23BBDD66&amp;output=js'></script>";

                                i += 1;
                            }
                            if (i == 3)
                                mFollowImgHtml = mFollowImgHtml + "</tr><tr>";

                            if ((mFollowusRow["SkypeChecked"].ToString() == "True") && (mFollowusRow["SkypeID"].ToString() != "") && (mFollowusRow["SkypeID"].ToString() != null))
                            {
                                mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='skype:" + mFollowusRow["SkypeID"].ToString() + "'><img border='0'style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\skypelogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='Skype'/></a></td>";
                                // mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='skype:" + mFollowusRow["SkypeID"].ToString() + "'><img border='0'style='border: none; width:182px height:44px '   src='http://mystatus.skype.com/bigclassic/" + mFollowusRow["SkypeID"].ToString()  + "' alt='Skype'/></a></td>";
                                i += 1;
                            }
                            if (i == 3)
                                mFollowImgHtml = mFollowImgHtml + "</tr><tr>";


                            if ((mFollowusRow["TwitterChecked"].ToString() == "True") && (mFollowusRow["TwitterID"].ToString() != "") && (mFollowusRow["TwitterID"].ToString() != null))
                            {
                                mFollowImgHtml = mFollowImgHtml + "<td><a target='_new'  href='http://www.twitter.com/" + mFollowusRow["TwitterID"].ToString() + "'><img border='0'   src='" + @"Images\client\logos\twitter.jpg' style='margin-right:10px; margin-bottom:5px;' alt='twitter'/></a></td>";
                                i += 1;
                            }

                            if (i == 3)
                                mFollowImgHtml = mFollowImgHtml + "</tr><tr>";

                            if ((mFollowusRow["BlogSpotChecked"].ToString() == "True") && (mFollowusRow["BlogSpotID"].ToString() != "") && (mFollowusRow["BlogSpotID"].ToString() != null))
                            {
                                mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='http://" + mFollowusRow["BlogSpotID"].ToString() + ".blogspot.com'><img border='0'style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\buzzlogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='facebook'/></a></td>";
                                i += 1;
                            }

                            if (i == 3)
                                mFollowImgHtml = mFollowImgHtml + "</tr><tr>";


                            if ((mFollowusRow["FaceBookChecked"].ToString() == "True") && (mFollowusRow["FaceBookID"].ToString() != "") && (mFollowusRow["FaceBookID"].ToString() != null))
                            {
                                //  mFollowImgHtml = mFollowImgHtml + "<td><a href='#'><img border='0'  href='" + mFollowusRow["ComAppURL"].ToString() + "' src='" + @"Images\client\logos\" + mFollowusRow["ComAppImg"].ToString() + "' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/></a></td>";
                                string FBLink = mFollowusRow["FaceBookID"].ToString();
                                if (FBLink != "")
                                {
                                    //if (!FBLink.Contains("http:"))
                                    //{
                                    //    FBLink = "http://" + FBLink;
                                    //}

                                    if (FBLink.Contains("www."))
                                        FBLink = FBLink.Replace("www.", "");

                                    if (FBLink.Contains("facebook.com/"))
                                        FBLink = FBLink.Replace("facebook.com/", "");
                                }
                                mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='http://www.facebook.com/" + FBLink + "'><img border='0'style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\facebookLogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='facebook'/></a></td>";
                                i += 1;
                            }

                            if (i == 3)
                                mFollowImgHtml = mFollowImgHtml + "</tr><tr>";


                            if ((mFollowusRow["FaceBookGroupLinkChecked"].ToString() == "True") && (mFollowusRow["FaceBookGroupLink"].ToString() != "") && (mFollowusRow["FaceBookGroupLink"].ToString() != null))
                            {
                                mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='" + mFollowusRow["FaceBookGroupLink"].ToString() + "'><img border='0'style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\facebookGroup.jpg' style='margin-right:10px; margin-bottom:5px;' alt='facebook' title='facebook Group link'/></a></td>";
                                i += 1;
                            }


                       // }   
                 

                    sbFlw.Append(mFollowImgHtml);
                    }

              

                dvFollowUs.InnerHtml = "<table border='0'>" + sbFlw.ToString() + "</table>";

           
            
            #endregion



            // -- Load Contact Us Details -- ///
            #region  Commented Code Retreive Contact us Details 

            //    foreach (DataRow CntRow in tbContactUs.Rows)
            //    {

            //        tmpUserDomainType = CntRow["UserDomaintype"].ToString().Trim();
 
            //       // lblHomePageContent.Text = CntRow["Description"].ToString().Replace(Environment.NewLine, "<br/>");
            //        if( CntRow["Email"].ToString().Trim() != "")
            //        LtrContactUs_Email.Text = @"&nbsp;<img src='Images\icon_email_sml.jpg' /> : <b>" +  CntRow["Email"].ToString() + "</b>";

            //        if (CntRow["FaxNo"].ToString().Trim() != "")
            //            LtrContactUs_Fax.Text = @"&nbsp;<img src='Images\icon_fax_sml.jpg' /> : <b>" + CntRow["FaxNo"].ToString() + "</b>";

            //        if (CntRow["Homephone"].ToString().Trim() != "")
            //            ltrContactUs_HomePhone.Text = @"&nbsp;<img src='Images\icon_homephone_sml.jpg' /> : <b>" + CntRow["Homephone"].ToString() + "</b>";

            //        if (CntRow["Handphone"].ToString().Trim() != "")
            //            LtrContactUs_HandPhone.Text = @"&nbsp;<img src='Images\icon_handphone_sml.jpg' /> : <b>" + CntRow["Handphone"].ToString() + "</b>";

            //        if (CntRow["NickName"].ToString().Trim() != "")
            //            ltrNickName.Text = @"&nbsp;<b>" + CntRow["NickName"].ToString() + "</b>";

            //        if (CntRow["FullImgPath"].ToString() != "")
            //        {
            //            ImgContact.ImageUrl = CntRow["FullImgPath"].ToString();
            //        }
            //        else
            //        {
            //            ImgContact.Visible = false;
            //        }
            //        //description for ComapnyName can be found above in the homepage section.
            //    }


            #endregion

                RenderLangResourceControls();

       }



    }

   

    public void RenderLangResourceControls()
    {

        //ltrTestimonials.Text = (string)GetGlobalResourceObject("LangResources", "Testimonial");
        LtrUpcomingEvents.Text = (string)GetGlobalResourceObject("LangResources", "upcomingevents");
        LtrRecentNews.Text = (string)GetGlobalResourceObject("LangResources", "recentnews");
        //LtrFollowUs.Text = (string)GetGlobalResourceObject("LangResources", "FollowUson");
        LtrFollowUs.Text = Resources.LangResources.FollowUson;
        LtrContactUs.Text = (string)GetGlobalResourceObject("LangResources", "ContactUs");
        ltrOurSmsFramework.Text = "Our SMS framework can be used for products promotions, announcements, news & events or special offers.";
                
    }


    //protected void btnSignIn_Click(object sender, EventArgs e)
    //{
                    
    //    SqlConnection dbConn;
    //    SqlCommand dbCmd;
    //    SqlDataReader dbReader;
    //    SqlDataAdapter dbAdap;
    //    DataSet dsCheck;
    //    string strSQL = string.Empty;
    //    DataTable dtUserRecord = new DataTable();
    //    DataTable dtUserStatus = new DataTable();

    //    CMSv3.BAL.User objUser = new CMSv3.BAL.User();

    //    bool LoginStatus = false;

    //    //string selectedLanguage;

    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);

    //    string mUserName = txtLoginID.Text;
    //    string mPassword = txtPassword.Text;

    //    try
    //    {
    //        //strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";

    //        //strSQL = "Exec [usp_User_CheckLogin] " + "'" + CommonFunctions.SafeSql(mUserName) + "' , '" + CommonFunctions.SafeSql(mPassword) + "'";

    //        dsCheck = objUser.CheckUser_LoginStatus(CommonFunctions.SafeSql(mUserName), CommonFunctions.SafeSql(mPassword));

    //        if (dsCheck.Tables.Count == 2)
    //        {
    //            dtUserStatus = dsCheck.Tables[0];
    //            dtUserRecord = dsCheck.Tables[1];
    //        }
    //        else
    //        {
    //            dtUserStatus = dsCheck.Tables[0];
    //        }

    //        DataRow UserStatus_Row = dtUserStatus.Rows[0];
    //        string UserStatus_Value = UserStatus_Row["userStatus"].ToString();


    //        if (UserStatus_Value == "MATCHED")
    //        {
    //            DataRow UserRecord_Row = dtUserRecord.Rows[0];

    //            Session["UserID"] = UserRecord_Row["UserID"].ToString();
    //            Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
    //            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();

    //            LoginStatus = true;
    //        }
    //        else if (UserStatus_Value == "EXPIRED")
    //        {
    //            LtrErrMessage.Text = "Account Expired ...";
    //            LoginStatus = false;
    //        }
    //        else
    //        {
    //            LtrErrMessage.Text = "Invalid Password ...";
    //            LoginStatus = false;
    //        }


    //        //dbConn.Open();
    //        //dbCmd = new SqlCommand(strSQL, dbConn);
    //        //dbReader = dbCmd.ExecuteReader();

    //        //if (dbReader.HasRows)
    //        //{
    //        //    while (dbReader.Read())
    //        //    {
    //        //        bool tmpActive = Convert.ToBoolean(dbReader["isActive"].ToString());
    //        //        if (tmpActive)
    //        //        {

    //        //            Session["UserID"] = dbReader["UserID"].ToString();
    //        //            Session["LoginID"] = dbReader["LoginID"].ToString();
    //        //            Session["UserDomainType"] = dbReader["UserDomainType"].ToString();
    //        //            //Session["defLanguage"] = ddlLang.SelectedValue;
    //        //            //lblErrMessage.Text = "User Sucessfully Logged IN ";
    //        //            //selectedLanguage = Session["defLanguage"].ToString();
    //        //            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
    //        //            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
    //        //            LoginStatus = true;
    //        //        }
    //        //        else
    //        //        {
    //        //            LtrErrMessage.Text = "Account Suspended ..";
    //        //            LoginStatus = false;
    //        //        }
    //        //    }
    //        //}
    //        //else
    //        //{
    //        //    LtrErrMessage.Text = "Invalid Password ..";
    //        //    LoginStatus = false;
    //        //}



    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //    finally
    //    {

    //    }

    //    if (LoginStatus)
    //    {
    //        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

    //        int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));

    //        Response.Redirect("~/Admin/Ad_Welcome.aspx");
    //        //Server.Transfer("~/Admin/Welcome.aspx");

    //    }

    //}


    public int GetUserIdfromURL()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;
              
        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();


        string tmpMainURL = Request.Url.OriginalString;


        string OrgURL = Request.Url.OriginalString;
       // tmpMainURL = "1worldsms.1mybusiness.com";
        //tmpMainURL = "60178486078.1smsbusiness.com";
        
        //tmpMainURL = "http://ringweb30.1argentinasms.com";
        

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

                //if (newUserID == 0)
                //{

                //check if the User is from/a 1MalaysiaSMS user. 
                CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();

                //..function get all the details of 1malaysia user into MasUser entity 
                MasFunc.Get_1MalaysiaUser_Details(userSubDomainName, ref objMasUser);


                if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
                Session["MasUSER"] = objMasUser;


                //.................................................................

                if (objMasUser.MID != "NONE")
                {
                    //Response.Redirect("Mas1UserWebRegistration.aspx");
                    
                }


                //}

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

            //if (newUserID == 0)
            //{

            //check if the User is from/a 1MalaysiaSMS user. 
            CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
            CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();

            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(userOwnDomainName, ref objMasUser);

                if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
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


            //}

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


    public static bool CheckIsNumeric(string input)
    {
        if (input != null)
        {
            double output;
            return Double.TryParse(Convert.ToString(input), out output);
        }
        else
        {
            return false;
        }
    }


    protected void btnSignIn_Click(object sender, EventArgs e)
    {


        string mUserName = txtLoginID.Text;
        string mPassword = txtPassword.Text;

        //string ChkUserName = "BK" + mUserName; 


        //////validate the User. 
        ////CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
        ////string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(mUserName, mPassword);

        ////if (tmpMID == "0")
        ////{
        ////    // invalid login 
        ////    LtrErrMessage.Text = "Invalid Password ...";
       
        ////}
        ////else
        ////{
           ////valid login 

            //...Session["Login_ID"] = mUserName;

            //.. based on the Moblie Phone... redirect the user to appropriate Login.  (1malaysia or 1singapore .etc)

            string tmpCountryPrefix = mUserName.Substring(0, 2);
            string tmpForBruneiPrefix = mUserName.Substring(0, 3); 
            
            if(tmpForBruneiPrefix == "673")
                tmpCountryPrefix = "673";
            //OnlyForBrunei using Sam number 
            //String TestingMobileNumber = ConfigurationManager.AppSettings["testMobileNumber"].ToString();
            //if (mUserName == TestingMobileNumber)
            //    tmpCountryPrefix = "673";



            if ((tmpCountryPrefix == "60") || (tmpCountryPrefix == "65") || (tmpCountryPrefix == "62") || (tmpCountryPrefix == "673"))
            {

                //validate the User. 
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(mUserName, mPassword);

                if (tmpMID == "0")
                {
                    // invalid login 
                    LtrErrMessage.Text = "Invalid Password ...";

                }
                else if (tmpMID == "1")
                {
                    LtrErrMessage.Text = "Not Subscribed to SMSBIZ.";

                    StringBuilder sbm = new StringBuilder();

                    sbm.Append(@"\n This M-Commerce Partner Login is strictly for SMS Entrepreneur Only.");
                    sbm.Append(@"\n ");
                    sbm.Append(@"\n Please consult your referral for explaination on ");
                    sbm.Append(@"\n SMS Business Requirement and ask for instructions ");
                    sbm.Append(@"\n on how to set SMS Business Status to YES.  ");
                    sbm.Append(@"\n\n ");
                    sbm.Append(@"\n Thank you.");

                    CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));
                    // CommonFunctions.AlertMessage(Server.HtmlEncode(@"Not Subscribed \n Thank you")); 


                }
                else
                {

                    //.. Before Redirecting Check if the User has registered a SubDomain. if NOT prompt message. 

                    CommonFunctions.CheckSubDomainByLoginID(tmpCountryPrefix, mUserName, mPassword);
                    CommonFunctions.LogUserWebInfo(tmpMID, mUserName); 
                   // CommonFunctions.Redirect2Logins(tmpCountryPrefix, mUserName, mPassword); 

                    String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
                    strReferringURL = strReferringURL.Replace("http://", "");
                    int GetFirstSlashidx = strReferringURL.IndexOf(@":");
                    if (GetFirstSlashidx > 0)
                        strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx);
                    string strURL = string.Empty;


                    strURL = "http://210.5.45.47/MalaysiaSMSBiz/1SmsWebSite_BizMemberCheck.aspx";

                    HttpContext.Current.Response.Clear();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html>");
                    sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                    sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
                    sb.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", mUserName);
                    sb.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", mPassword);
                    sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
                    // Other params go here
                    sb.Append("</form>");
                    sb.Append("</body>");
                    sb.Append("</html>");

                    HttpContext.Current.Response.Write(sb.ToString());
                    //HttpContext.Current.Response.End();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
        

                    
                }
            }
            else
            {
                //if loggin in by Domain Names...
                Boolean isValidLogin = ValidateLoginByDomain(mUserName, mPassword);


                if (isValidLogin)
                {
                    //CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

                   // int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));
                    CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName); 
                    Response.Redirect("~/Admin/Ad_Welcome.aspx");
                    //Server.Transfer("~/Admin/Welcome.aspx");

                }


            }

            //http://64.78.18.32/Indonesia/  ..0062

           // string strURL = "http://64.78.18.32/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword;
            //Page.SmartNavigation = false;

        
    }


    protected Boolean ValidateLoginByDomain(string vUserID, string vPassword)
    {


        //SqlConnection dbConn;
        //SqlCommand dbCmd;
        //SqlDataReader dbReader;
        //SqlDataAdapter dbAdap;
        DataSet dsCheck;
        string strSQL = string.Empty;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        bool LoginStatus = false;

        //string selectedLanguage;

        //dbConn = new SqlConnection(GlobalVar.GetDbConnString);

      
        try
        {
            //strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";

            //strSQL = "Exec [usp_User_CheckLogin] " + "'" + CommonFunctions.SafeSql(mUserName) + "' , '" + CommonFunctions.SafeSql(mPassword) + "'";

            dsCheck = objUser.CheckUser_LoginStatus(CommonFunctions.SafeSql(vUserID), CommonFunctions.SafeSql(vPassword));

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


            if (UserStatus_Value == "MATCHED")
            {
                DataRow UserRecord_Row = dtUserRecord.Rows[0];

                Session["UserID"] = UserRecord_Row["UserID"].ToString();
                Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
                Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();

                LoginStatus = true;
            }
            else if (UserStatus_Value == "EXPIRED")
            {
                LtrErrMessage.Text = "Account Expired ...";
                LoginStatus = false;
            }
            else
            {
                LtrErrMessage.Text = "Invalid Password ...";
                LoginStatus = false;
            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {

        }

        return LoginStatus;
       
    }

    protected void Log2AdminforUser(string inComingURL)
    {

        //inComingURL = "http://60166362863.1smsbusiness.com";
       
        String tmpURL = inComingURL.Replace("http://", "");

        string tmpSubDomainURL = tmpURL;
        string[] MainURLArr = tmpURL.Split('.');
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


        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        

        dsCheck = objBAL_User.CheckUser_ValidateByMobileLogin(userSubDomainName);

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


        if ((UserStatus_Value == "MATCHED") || (UserStatus_Value == "SUBDOMAIN_FOUND"))
        {
            DataRow UserRecord_Row = dtUserRecord.Rows[0];

            Session["UserID"] = UserRecord_Row["UserID"].ToString();
            Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
            Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
            string tmpOwnDomainName = UserRecord_Row["OwnDomain"].ToString();
            string tmpReferringURL = string.Empty;

            if (Request.QueryString["referringURL"] != null)
                tmpReferringURL = Request.QueryString["referringURL"].ToString();

            if (tmpReferringURL != "")
                tmpReferringURL = Server.UrlEncode(tmpReferringURL);


            String pPageTO = string.Empty;
            //String RedirectToPage = "NO";
            String RedirectToPage = String.Empty;

            if (Request.QueryString["PageTO"] != null)
                pPageTO = Request.QueryString["PageTO"].ToString();

            //if (pPageTO == "MOBILEWEB")
            //    RedirectToPage = "YES";

           

            if (tmpOwnDomainName != "")
                // Response.Redirect("http://" + tmpOwnDomainName + "/Admin/Ad_Welcome.aspx");
                Response.Redirect("http://" + tmpOwnDomainName + "/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL + "&WebRedirectTO=" + pPageTO + "&LoggedInFrom=" + Request.QueryString["pgFrom"].ToString());
            //Response.Redirect("~/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL);
            else
                Response.Redirect("~/pgFromASP.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + Session["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferringURL + "&WebRedirectTO=" + pPageTO + "&LoggedInFrom=" + Request.QueryString["pgFrom"].ToString());
            //Response.Redirect("~/Admin/Ad_Welcome.aspx");

        }
        else
        {
           // RegisterSubDomainPage(userSubDomainName);  
            if ((Request.QueryString["pgFrom"] == "SMSSYSTEM_WPY") || (Request.QueryString["pgFrom"] == "SMSSYSTEM_WPN"))
            {
                //..Take the User to SubDomain Registration 
                RegisterSubDomainPage(userSubDomainName); 
            }
            else
            {
                Response.Redirect("PartnerWebRegistrationNew.aspx");
            }
            
            //Response.Redirect("InValidDomain.aspx"); 


           // //..check if the user is from 1mas user 

           // //check if the User is from/a 1MalaysiaSMS user. 
           // CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
           //// CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();

           // //..function get all the details of 1malaysia user into MasUser entity 
           // MasFunc.Get_1MalaysiaUser_Details(userSubDomainName, ref objMasUser);


           // if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
           //     Session["MasUSER"] = objMasUser;

           // if (objMasUser.MID != "NONE")
           // {
           //     Response.Redirect("Mas1UserWebRegistration.aspx");

           // }



        }

    }

    protected void CheckSubDomainByLoginID22(string vLoginID)
    {
        //function Checks the Location BAR URL and determines if the subdomain or domain exists 
        

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();



        dsCheck = objBAL_User.CheckUser_ValidateByMobileLogin(vLoginID);

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


        if (UserStatus_Value == "NOTMATCHED")
        {

            LtrErrMessage.Text = "Register SubDomain";

            StringBuilder sbm = new StringBuilder();

            sbm.Append(@"\n You have not registered your SubDomain yet.");
            sbm.Append(@"\n ");
            sbm.Append(@"\n Please register your suddomain to continue ");
            sbm.Append(@"\n\n ");
            sbm.Append(@"\n Thank you.");

            CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));

            Response.Clear();
            string Mas1WebRegURL = "Mas1UserWebRegistration.aspx";

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", Mas1WebRegURL);
            sb.AppendFormat("<input type='hidden' name='MobWebCheck' value='{0}'>", vLoginID);
            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            Response.Write(sb.ToString());

            Response.End();


            //Response.Redirect("~/Mas1UserWebRegistration.aspx");
            //Response.End(); 
        }

        //if (newUserID == 0)
        //{
        //    //Response.Redirect("PartnerWebRegistrationNew.aspx");
        //    Response.Redirect("~/InValidDomain.aspx");
        //}
        //else if (newUserID != vLoggedInUserID)
        //{
        //    Response.Redirect("~/SessionExpire.aspx");
        //}



    }

    protected void RegisterSubDomainPage(string vLoginID)
    {

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        
        DataTable dtSubDomainStatus = new DataTable();

        DataSet dsSMScheck;
        dsSMScheck = objBAL_User.CheckSUbDomain_ValidateByMobile(vLoginID);

        dtSubDomainStatus = dsSMScheck.Tables[0];

        DataRow sbRow = dtSubDomainStatus.Rows[0];
        string SbStatus = sbRow["userStatus"].ToString();


        if (SbStatus == "NOTEXISTS")
        {
            //get the password, mobileloginid and country prefix; 

            CMSv3.Entities.MasUser objMasUser_SB = new CMSv3.Entities.MasUser();

            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(vLoginID, ref objMasUser_SB);

            string tmpMobileNo = objMasUser_SB.LoginID;
            String CountryCode = tmpMobileNo.Substring(0, 2);
            
            String sbPassword = objMasUser_SB.Password;
            String sbMobileLoginID = objMasUser_SB.LoginID;
            String sbMobileFullName = objMasUser_SB.MemberName;
            String sbEmail  = objMasUser_SB.Email;
            String sbCompany = objMasUser_SB.Company;


            HttpContext.Current.Response.Clear();
            // string Mas1WebRegURL = "Mas1UserWebRegistration.aspx";
            string Mas1WebRegURL = "Mas1SubDomainReg.aspx";

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", Mas1WebRegURL);
            sb.AppendFormat("<input type='hidden' name='MasRegCountryPrefix' value='{0}'>", CountryCode);
            sb.AppendFormat("<input type='hidden' name='MasRegMobileID' value='{0}'>", vLoginID);
            sb.AppendFormat("<input type='hidden' name='MasRegPassword' value='{0}'>", sbPassword);
            sb.AppendFormat("<input type='hidden' name='MasRegPageFrom' value='{0}'>", Request.QueryString["pgFrom"].ToString());
            

            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());

            HttpContext.Current.Response.End();



        }


    }

  
}
