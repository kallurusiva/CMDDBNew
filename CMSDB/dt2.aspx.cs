using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.Threading;
using CMSv3.Entities;
using CMSv3.BAL;
using System.Data;
using System.Data.SqlClient;

public partial class dt2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        #region // rendering top left panel
        //HtmlGenericControl myDivObject;
        //myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        ////myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
        //myDivObject.InnerHtml = "<img alt='imbnLeftimg' src='Images/faq_head.jpg' />";

        HtmlGenericControl myDivObject;
        myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
        sb.Append("<tr>");
        //sb.Append("<td align='left' valign='top'>");
        //sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        //sb.Append("</td>");
        sb.Append("<td>");
        sb.Append("<img alt='imbnLeftimg' src='Images/event_head.jpg' />");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");



        #endregion



        DataSet MainDS;
        DataTable tbMenu;
        DataTable tbNews;
        DataTable tbHomePgContent;
        DataTable tbEvents;
        DataTable tbTestimonials;
        DataTable tbFollowus;
        DataTable tbWelComepage;
        DataTable tbContactUs;


        HtmlGenericControl dvLogoImage = (HtmlGenericControl)Master.FindControl("dvLogoImage");
        HtmlGenericControl dvBannerImg = (HtmlGenericControl)Master.FindControl("dvBannerImg");
        HtmlGenericControl dvCopyRights = (HtmlGenericControl)Master.FindControl("dvCopyRights");
        HtmlGenericControl dvTopMenu = (HtmlGenericControl)Master.FindControl("dvTopMenu");
        
        Label lblLogoText = (Label)Master.FindControl("lblLogoText");

       

        string tmpUserDomainType = string.Empty;


        if (!IsPostBack)
        {

           // txtLoginID.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");

            CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();

            //MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["UserID"]));

            // Create the Client ID session Based on the Domain Entered in the URL 
            // Session["ClientID"] = Convert.ToInt32(GlobalVar.GetTestLoginUser);

            string isDemo = ConfigurationManager.AppSettings["isDemo"].ToString();
            if (isDemo == "true")
            {
                Session["ClientID"] = Convert.ToInt32(GlobalVar.GetTestLoginUser);
            }
            else
            {
                //Session["ClientID"] = GetUserIdfromURL();
                Session["ClientID"] = CommonFunctions.fnGetUserIdfromURL(); 
            }


            if (Convert.ToInt32(Session["ClientID"]) == 0)
            {
                Response.Redirect("PartnerWebRegistrationNew.aspx");
            }

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

                
                    string selectedLanguage = string.Empty;
                    string tmpDefLang = HpgRow["LangCulture"].ToString();


                    if (tmpDefLang.Trim() == "")
                        selectedLanguage = GlobalVar.Lang_English;
                    else
                        selectedLanguage = tmpDefLang.Trim();


                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

                    Session["defLanguage"] = selectedLanguage;
                

                //Companyinfo
                //string strCompanyName = "<font class='HomePageHeaderFont'>" + (string)GetGlobalResourceObject("LangResources", "Welcometo") + " " + HpgRow["CompanyName"].ToString() + "</font>";
               dvCompanyName.InnerText = (string)GetGlobalResourceObject("LangResources", "Welcometo") + " " + HpgRow["CompanyName"].ToString();
                //dvCompanyName.InnerText = strCompanyName;


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
                        lblLogoText.Text = "<font class='LogoText3'>" + tmpCompanyName + "</font>";
                        //dvLogoText.InnerHtml = "<font class='LogoText3'>" + tmpCompanyName + "</font>";
                    }
                    else if (tmpCompanyName.Length > 20)
                    {
                        lblLogoText.Text = "<font class='LogoText2'>" + tmpCompanyName + "</font>";
                        //dvLogoText.InnerHtml = "<font class='LogoText2'>" + tmpCompanyName + "</font>";
                    }
                    else
                    {
                        lblLogoText.Text = "<font class='LogoText'>" + tmpCompanyName + "</font>";
                        //dvLogoText.InnerHtml = "<font class='LogoText'>" + tmpCompanyName + "</font>";
                    }

                }
                else
                {
                    dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                }

                dvBannerImg.InnerHtml = "<img alt='banner image'  class='divCssBannerImg' src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' />";

                //.. WebPicture - Bottom Image 
                dvWP_Bottomimg.InnerHtml = "<img alt='WebPicute Bottom image'  style='height:150px; width:550px;' src='" + @"ImageRepository/" + HpgRow["Wp_BottomImg"].ToString() + "' />";

                //.. WebPicture - Bottom Image 
                dvWP_Sideimg.InnerHtml = "<img alt='WebPicute Side image'  style='height:425px; width:175px;' src='" + @"ImageRepository/" + HpgRow["Wp_SideImg"].ToString() + "' />";


                //dvCopyRights.InnerText = HpgRow["CopyRightsInfo"].ToString();
                Session["CopyRightsInfo"] = HpgRow["CopyRightsInfo"].ToString();
                //objClientData.CopyRightsInfo = HpgRow["CopyRightsInfo"].ToString();


                //... Company Name...
                //if (HpgRow["CompanyName"].ToString().Trim() != "")
                //    ltrCompanyName.Text = "&nbsp;<b>" + HpgRow["CompanyName"].ToString() + "</b>";


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

                //if (i < 10)
                //{
                sbMenu.Append("<li>");
                sbMenu.Append("<a class='links_MainMenuBar' href='" + mRow["LinkURL"].ToString() + "'>");

                tmpMenuName = mRow["LinkName"].ToString().Trim();
                tmpCultureMenuName = (string)GetGlobalResourceObject("LangResources", tmpMenuName.ToLower());
                if (tmpCultureMenuName != null)
                {
                    sbMenu.Append(tmpCultureMenuName);
                    strMenuBarChars += tmpCultureMenuName;
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

            //dvTopMenu.InnerHtml = "";
            //dvTopMenu.InnerHtml = sbMenu.ToString();


            // DownMenu.InnerHtml = sbMenu.ToString();


            #endregion

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
                    tmpNewsContent = tmpNewsContent.Replace(Environment.NewLine, "<br/>");
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


            //for (i = 0; i <= tbEvents.Rows.Count - 1; i++)
            //{
            //    DataRow mEventsRow = tbEvents.Rows[i];
            //    if (i == 0)
            //    {
            //        DateTime dtn = Convert.ToDateTime(mEventsRow["EventDate"].ToString());
            //        dvEventsHead1.InnerText = dtn.ToString("MMM dd, yyyy");
            //        //dvEventsHead1.InnerText = dtn.ToString("D");
            //        String tmpEventContent = mEventsRow["EventContent"].ToString();
            //        //tmpEventContent = tmpEventContent.Replace("<br/>", "\r\n");

            //        tmpEventContent = tmpEventContent.Replace(Environment.NewLine, "<br/>");
            //        //AreaEvtContent.Value = tmpEventContent.ToString();
            //        lblEventContent.Text = tmpEventContent.ToString();
            //        //dvEventsContent1.InnerHtml = "<pre> " + tmpEventContent.ToString() + "</pre>";
            //        //dvEventsContent1.InnerText = "<pre> " + tmpEventContent.ToString() + "</pre>";
            //        //LtrEvtContent.Text = tmpEventContent;


            //    }
            //    //else if (i == 1)
            //    //{
            //    //    DateTime dtn = Convert.ToDateTime(mEventsRow["EventDate"].ToString());
            //    //    dvEventsHead2.InnerText = dtn.ToString("MMM dd, yyyy");
            //    //    //dvEventsContent2.InnerText = mEventsRow["EventContent"].ToString();

            //    //    string tmpEventContent2 = mEventsRow["EventContent"].ToString();
            //    //    tmpEventContent2 = tmpEventContent2.Replace("<br/>", Environment.NewLine);
            //    //    AreaEvtContent2.Value = tmpEventContent2.ToString();

            //    //}
            //}


            #endregion


            //--- Load Tesimonial Items  --//
            #region Retrieve Testimonial data

            for (i = 0; i <= tbTestimonials.Rows.Count - 1; i++)
            {
                DataRow mTestimonialsRow = tbTestimonials.Rows[i];

                DateTime dtn = Convert.ToDateTime(mTestimonialsRow["tstCreatedDate"].ToString());
                string tFooter = "By " + mTestimonialsRow["tstByName"].ToString() + " - " + dtn.ToString("MMM dd, yyyy");

               // dvTestimonialHead1.InnerText = dtn.ToString("MMM dd, yyyy");
                string tmpTestimonialContent = mTestimonialsRow["tstContent"].ToString().ToString().Replace(Environment.NewLine,"<br/>");
                //AreaTestimonialContent.Value = tmpTestimonialContent;
                //lblTestimonialContent.Text = tmpTestimonialContent;

                // dvTestimContent.InnerText = mTestimonialsRow["tstContent"].ToString().Replace("<br/>",Environment.NewLine);
                //dvTestimFooter.InnerHtml = "<img src='Images/testiarrow.gif' alt='arrowimg' />" + tFooter;
                //dvTestimContent.InnerText


            }

            #endregion



            // -- Load Contact Us Details -- ///
            #region Retreive Contact us Details

            //foreach (DataRow CntRow in tbContactUs.Rows)
            //{

            //    tmpUserDomainType = CntRow["UserDomaintype"].ToString().Trim();

            //    // lblHomePageContent.Text = CntRow["Description"].ToString().Replace(Environment.NewLine, "<br/>");
            //    if ((CntRow["Email"].ToString().Trim() != "") && (CntRow["EmailChk"].ToString() == "True"))
            //        LtrContactUs_Email.Text = @"&nbsp;<img title='Email'  src='Images\icon_email_sml.jpg' /> : <b>" + CntRow["Email"].ToString() + "</b>";

            //    if ((CntRow["FaxNo"].ToString().Trim() != "") && (CntRow["FaxNoChk"].ToString() == "True"))
            //        LtrContactUs_Fax.Text = @"&nbsp;<img title='FaxNo'  src='Images\icon_fax_sml.jpg' /> : + <b>" + CntRow["FaxNo"].ToString() + "</b>";


            //    if ((CntRow["Homephone"].ToString().Trim() != "") && (CntRow["HomephoneChk"].ToString() == "True"))
            //        ltrContactUs_HomePhone.Text = @"&nbsp;<img title='HomePhone' src='Images\icon_homephone_sml.jpg' /> : + <b>" + CntRow["Homephone"].ToString() + "</b>";


            //    if ((CntRow["Handphone"].ToString().Trim() != "") && (CntRow["HandphoneChk"].ToString() == "True"))
            //        LtrContactUs_HandPhone.Text = @"&nbsp;<img title='Handphone'  src='Images\icon_handphone_sml.jpg' /> : + <b>" + CntRow["Handphone"].ToString() + "</b>";

            //    if (CntRow["NickName"].ToString().Trim() != "")
            //        ltrNickName.Text = @"&nbsp;<b>" + CntRow["NickName"].ToString() + "</b>";

            //    if (CntRow["FullImgPath"].ToString() != "")
            //    {
            //        ImgContact.ImageUrl = CntRow["FullImgPath"].ToString();
            //    }
            //    else
            //    {
            //        ImgContact.Visible = false;
            //    }
            //    //description for ComapnyName can be found above in the homepage section.
            //}


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
                    if (i == 8)
                        mFollowImgHtml = mFollowImgHtml + "</tr><tr>";

                    if ((mFollowusRow["SkypeChecked"].ToString() == "True") && (mFollowusRow["SkypeID"].ToString() != "") && (mFollowusRow["SkypeID"].ToString() != null))
                    {
                        mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='skype:" + mFollowusRow["SkypeID"].ToString() + "'><img border='0'style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\skypelogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='Skype'/></a></td>";
                        // mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='skype:" + mFollowusRow["SkypeID"].ToString() + "'><img border='0'style='border: none; width:182px height:44px '   src='http://mystatus.skype.com/bigclassic/" + mFollowusRow["SkypeID"].ToString()  + "' alt='Skype'/></a></td>";
                        i += 1;
                    }
                    if (i == 8)
                        mFollowImgHtml = mFollowImgHtml + "</tr><tr>";


                    if ((mFollowusRow["TwitterChecked"].ToString() == "True") && (mFollowusRow["TwitterID"].ToString() != "") && (mFollowusRow["TwitterID"].ToString() != null))
                    {
                        mFollowImgHtml = mFollowImgHtml + "<td><a target='_new'  href='http://www.twitter.com/" + mFollowusRow["TwitterID"].ToString() + "'><img border='0'   src='" + @"Images\client\logos\twitter.jpg' style='margin-right:10px; margin-bottom:5px;' alt='twitter'/></a></td>";
                        i += 1;
                    }

                    if (i == 8)
                        mFollowImgHtml = mFollowImgHtml + "</tr><tr>";

                    if ((mFollowusRow["BlogSpotChecked"].ToString() == "True") && (mFollowusRow["BlogSpotID"].ToString() != "") && (mFollowusRow["BlogSpotID"].ToString() != null))
                    {
                        mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='http://" + mFollowusRow["BlogSpotID"].ToString() + ".blogspot.com'><img border='0'style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\buzzlogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='facebook'/></a></td>";
                        i += 1;
                    }

                    if (i == 8)
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

                        mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='http://www.facebook.com/" + FBLink + "'><img border='0' style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\facebookLogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='facebook'/></a></td>";
                        //mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='" + FBLink + "'><img border='0'style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\facebookLogo.jpg' style='margin-right:10px; margin-bottom:5px;' alt='facebook'/></a></td>";
                        i += 1;
                    }

                    if (i == 8)
                        mFollowImgHtml = mFollowImgHtml + "</tr><tr>";


                    if ((mFollowusRow["FaceBookGroupLinkChecked"].ToString() == "True") && (mFollowusRow["FaceBookGroupLink"].ToString() != "") && (mFollowusRow["FaceBookGroupLink"].ToString() != null))
                    {
                        string FBGLLink = mFollowusRow["FaceBookGroupLink"].ToString();
                        if (FBGLLink != "")
                        {
                            if(!FBGLLink.Contains("http:"))
                            {
                                FBGLLink = "http://" + FBGLLink; 
                            }
                        }
                        mFollowImgHtml = mFollowImgHtml + "<td><a target='_new' href='" + FBGLLink + "'><img border='0'style='border: none; width:182px height:44px '   src='" + @"Images\client\logos\facebookGroup.jpg' style='margin-right:10px; margin-bottom:5px;' alt='facebook' title='facebook Group link'/></a></td>";
                        i += 1;
                    }


                //}


                sbFlw.Append(mFollowImgHtml);
            }



            dvFollowUs.InnerHtml = "<table border='0'>" + sbFlw.ToString() + "</table>";



            #endregion



            //// -- Load Contact Us Details -- ///
            #region Commented Retreive Contact us Details

            //foreach (DataRow CntRow in tbContactUs.Rows)
            //{

            //    tmpUserDomainType = CntRow["UserDomaintype"].ToString().Trim();

            //    // lblHomePageContent.Text = CntRow["Description"].ToString().Replace(Environment.NewLine, "<br/>");
            //    if (CntRow["Email"].ToString().Trim() != "")
            //        LtrContactUs_Email.Text = @"&nbsp;<img src='Images\icon_email_sml.jpg' /> : <b>" + CntRow["Email"].ToString() + "</b>";

            //    if (CntRow["FaxNo"].ToString().Trim() != "")
            //        LtrContactUs_Fax.Text = @"&nbsp;<img src='Images\icon_fax_sml.jpg' /> : <b>" + CntRow["FaxNo"].ToString() + "</b>";

            //    if (CntRow["Homephone"].ToString().Trim() != "")
            //        ltrContactUs_HomePhone.Text = @"&nbsp;<img src='Images\icon_homephone_sml.jpg' /> : <b>" + CntRow["Homephone"].ToString() + "</b>";

            //    if (CntRow["Handphone"].ToString().Trim() != "")
            //        LtrContactUs_HandPhone.Text = @"&nbsp;<img src='Images\icon_handphone_sml.jpg' /> : <b>" + CntRow["Handphone"].ToString() + "</b>";

            //    if (CntRow["NickName"].ToString().Trim() != "")
            //        ltrNickName.Text = @"&nbsp;<b>" + CntRow["NickName"].ToString() + "</b>";

            //    if (CntRow["FullImgPath"].ToString() != "")
            //    {
            //        ImgContact.ImageUrl = CntRow["FullImgPath"].ToString();
            //    }
            //    else
            //    {
            //        ImgContact.Visible = false;
            //    }
            //    //description for ComapnyName can be found above in the homepage section.
            //}


            #endregion

            RenderLangResourceControls();

        }
    }



    public void RenderLangResourceControls()
    {
        
        //ltrTestimonial.Text = (string)GetGlobalResourceObject("LangResources", "Testimonial");
        //LtrUpcomingEvents.Text = (string)GetGlobalResourceObject("LangResources", "upcomingevents");
        LtrRecentNews.Text = (string)GetGlobalResourceObject("LangResources", "recentnews");
        //LtrFollowUs.Text = (string)GetGlobalResourceObject("LangResources", "FollowUson");
        LtrFollowUs.Text = Resources.LangResources.FollowUson;
       // LtrContactUs.Text = (string)GetGlobalResourceObject("LangResources", "ContactUs");
      //  ltrOurSmsFramework.Text = "Our SMS framework can be used for products promotions, announcements, news & events or special offers.";

    }



    //protected void btnSignIn_Click(object sender, EventArgs e)
    //{

    //    SqlConnection dbConn;
    //    SqlCommand dbCmd;
    //    SqlDataReader dbReader;
    //    string strSQL = string.Empty;

    //    bool LoginStatus = false;

    //    //string selectedLanguage;

    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);

    //    string mUserName = txtLoginID.Text;
    //    string mPassword = txtPassword.Text;

    //    try
    //    {
    //        strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";


    //        dbConn.Open();
    //        dbCmd = new SqlCommand(strSQL, dbConn);
    //        dbReader = dbCmd.ExecuteReader();

    //        if (dbReader.HasRows)
    //        {
    //            while (dbReader.Read())
    //            {
    //                bool tmpActive = Convert.ToBoolean(dbReader["isActive"].ToString());
    //                if (tmpActive)
    //                {

    //                    Session["UserID"] = dbReader["UserID"].ToString();
    //                    Session["LoginID"] = dbReader["LoginID"].ToString();
    //                    Session["UserDomainType"] = dbReader["UserDomainType"].ToString();
    //                    //Session["defLanguage"] = ddlLang.SelectedValue;
    //                    //lblErrMessage.Text = "User Sucessfully Logged IN ";
    //                    //selectedLanguage = Session["defLanguage"].ToString();
    //                    //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
    //                    //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
    //                    LoginStatus = true;
    //                }
    //                else
    //                {
    //                    LtrErrMessage.Text = "Account Suspended ..";
    //                    LoginStatus = false;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            LtrErrMessage.Text = "Invalid Password ..";
    //            LoginStatus = false;
    //        }



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
            }

        }
        else
        {
            //owndomain
            string ownDomain = tmpMainURL;
            string[] OwnURLArr = tmpMainURL.Split('.');
            string userOwnDomainName = string.Empty;


            // see if user has typed in www
            if (OwnURLArr[0].ToString() == "www")
            {
                userOwnDomainName = OwnURLArr[1].ToString();
            }
            else
            {
                userOwnDomainName = OwnURLArr[0].ToString();
            }

            //..user comes to his sub domain
            newUserID = objBAL_User.GetUserID_BySubDomainName(userOwnDomainName);


        }

        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {
            Response.Redirect("PartnerWebRegistrationNew.aspx");
        }

        return newUserID;

    }

    //protected void btnSignIn_Click(object sender, EventArgs e)
    //{

    //    SqlConnection dbConn;
    //    SqlCommand dbCmd;
    //    SqlDataReader dbReader;
    //    string strSQL = string.Empty;
    //    DataSet dsCheck;
    //    DataTable dtUserRecord = new DataTable();
    //    DataTable dtUserStatus = new DataTable();

    //    CMSv3.BAL.User objUser = new CMSv3.BAL.User();

    //    TextBox objtxtLoginID = (TextBox)this.Master.FindControl("txtLoginID");
    //    TextBox objtxtPassword = (TextBox)this.Master.FindControl("txtPassword");
    //    Literal objLtrErrMessage = (Literal)this.Master.FindControl("LtrErrMessage");

    //    bool LoginStatus = false;

    //    //string selectedLanguage;

    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);

    //    string mUserName = objtxtLoginID.Text;
    //    string mPassword = objtxtPassword.Text;

    //    try
    //    {
    //        //strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";

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
    //            objLtrErrMessage.Text = "Account Expired ...";
    //            LoginStatus = false;
    //        }
    //        else
    //        {
    //            objLtrErrMessage.Text = "Invalid Password ...";
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
    //        //            objLtrErrMessage.Text = "Account Suspended ..";
    //        //            LoginStatus = false;
    //        //        }
    //        //    }
    //        //}
    //        //else
    //        //{
    //        //    objLtrErrMessage.Text = "Invalid Password ..";
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


}
