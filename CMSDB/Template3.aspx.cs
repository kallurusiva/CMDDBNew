using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Threading;
using CMSv3.BAL;
using System.Data.SqlClient;

public partial class Template1 : System.Web.UI.Page 
{
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


        if (!IsPostBack)
        {

            CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();

            //MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["UserID"]));

            // Create the Client ID session Based on the Domain Entered in the URL 
           // Session["ClientID"] = Convert.ToInt32(GlobalVar.GetTestLoginUser);
            Session["ClientID"] = GetUserIdfromURL();

            if (Convert.ToInt32(Session["ClientID"]) == 0)
            {
                Response.Redirect("PartnerWebRegistration.aspx");
            }

            
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
                //dvHomePageContent.InnerText = HpgRow["CompanyInfo"].ToString().Replace("<br/>","\r\n");
                //lblHomePageContent.Text = HpgRow["CompanyInfo"].ToString().Replace("<br/>", Environment.NewLine);
                //lblHomePageContent.Text = HpgRow["CompanyInfo"].ToString().Replace(Environment.NewLine, "<br/>");
                //dvCompanyName.InnerText = "Welcome to " + HpgRow["CompanyName"].ToString();
                dvCompanyName.InnerText = (string)GetGlobalResourceObject("LangResources", "Welcometo") + " " + HpgRow["CompanyName"].ToString();




                //Images
                string tmpLogoImage = HpgRow["LogoImg"].ToString();
                if (tmpLogoImage.Substring(0, 8) == "LogoTemp")
                {
                    string tmpCompanyName = HpgRow["CompanyName"].ToString();
                    string tmpLogoHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                    tmpLogoHtml = tmpLogoHtml + "&nbsp; <font class='LogoText'>" + tmpCompanyName + "</font>";
                    dvLogoImage.InnerHtml = tmpLogoHtml;

                    //dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                }
                else
                {
                    dvLogoImage.InnerHtml = "<img alt='logo img' class='divCssLogoImage' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                }

                dvBannerImg.InnerHtml = "<img alt='banner image'  class='divCssBannerImg' src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' />";





                dvCopyRights.InnerText = HpgRow["CopyRightsInfo"].ToString();


            }

            #endregion


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

                StringBuilder sbMenu = new StringBuilder();
                StringBuilder SbMenuMore = new StringBuilder();

                sbMenu.Append("<ul>");

                foreach (DataRow mRow in tbMenu.Rows)
                {

                    if (i < 10)
                    {
                        sbMenu.Append("<li>");
                        sbMenu.Append("<a href='" + mRow["LinkURL"].ToString() + "'>");

                        tmpMenuName = mRow["LinkName"].ToString().Trim();
                        tmpCultureMenuName = (string)GetGlobalResourceObject("LangResources", tmpMenuName.ToLower());
                        if (tmpCultureMenuName != null)
                        {
                            sbMenu.Append(tmpCultureMenuName);
                        }
                        else
                        {
                            sbMenu.Append(mRow["LinkName"].ToString());
                        }

                        sbMenu.Append("</a></li>");
                    }
                    else
                    {
                        //SbMenuMore.Append("<li>");
                        //SbMenuMore.Append("<a class='indentmenuDropDown' href='" + mRow["LinkURL"].ToString() + "'>");
                        //SbMenuMore.Append(mRow["LinkName"].ToString());
                        //SbMenuMore.Append("</a></li>");
                    }


                    i++;


                    //Response.Write(mRow["LinkID"].ToString() + "|" + mRow["LinkName"].ToString() + "-");
                }

                //sbMenu.Append("<li>");
                //sbMenu.Append("<a href='#'> MORE </a>");
                //sbMenu.Append(SbMenuMore.ToString());
                //sbMenu.Append("</li>");

                sbMenu.Append("</ul>");

                dvTopMenu.InnerHtml = "";
                dvTopMenu.InnerHtml = sbMenu.ToString();

               // DownMenu.InnerHtml = sbMenu.ToString();


            #endregion

            #region commented code 
            //foreach (DataRow row in tbMenu.Rows)
            //{
            //    foreach (DataColumn col in tbMenu.Columns)
            //    {
            //        object cellData = row[col];
            //        Response.Write(cellData.ToString() + "|");
            //    }
            //}
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
                        tmpNewsContent = tmpNewsContent.Replace("<br/>", Environment.NewLine);
                        AreaNewContent.Value = tmpNewsContent;
                    }
                    else if (i == 1)
                    {
                        DateTime dtn = Convert.ToDateTime(mNewsRow["NewsDate"].ToString());
                        dvRecNewsHead2.InnerText = dtn.ToString("MMM dd, yyyy");
                        //dvRecNewsContent2.InnerText = mNewsRow["NewsContent"].ToString();
                        string tmpNewsContent = mNewsRow["NewsContent"].ToString();
                        tmpNewsContent = tmpNewsContent.Replace("<br/>", Environment.NewLine);
                        AreaNewContent2.Value = tmpNewsContent;
                    }
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
                       
                       tmpEventContent = tmpEventContent.Replace("<br/>", Environment.NewLine);
                       AreaEvtContent.Value = tmpEventContent.ToString();
                        //dvEventsContent1.InnerHtml = "<pre> " + tmpEventContent.ToString() + "</pre>";
                       //dvEventsContent1.InnerText = "<pre> " + tmpEventContent.ToString() + "</pre>";
                       //LtrEvtContent.Text = tmpEventContent;
                        

                    }
                    else if (i == 1)
                    {
                        DateTime dtn = Convert.ToDateTime(mEventsRow["EventDate"].ToString());
                        dvEventsHead2.InnerText = dtn.ToString("MMM dd, yyyy");
                        //dvEventsContent2.InnerText = mEventsRow["EventContent"].ToString();
                        AreaEvtContent2.Value = mEventsRow["EventContent"].ToString();
                    }
                }


            #endregion


            //--- Load Tesimonial Items  --//
            #region Retrieve Testimonial data 

                for (i = 0; i <= tbTestimonials.Rows.Count - 1; i++)
                {
                    DataRow mTestimonialsRow = tbTestimonials.Rows[i];
                    
                        DateTime dtn = Convert.ToDateTime(mTestimonialsRow["tstCreatedDate"].ToString());
                        string tFooter = "By " + mTestimonialsRow["tstByName"].ToString() + " - " + dtn.ToString("MMM dd, yyyy");

                    string tmpTestimonialContent = mTestimonialsRow["tstContent"].ToString().ToString().Replace("<br/>",Environment.NewLine);
                    AreaTestimonialContent.Value = tmpTestimonialContent;
                        
                       // dvTestimContent.InnerText = mTestimonialsRow["tstContent"].ToString().Replace("<br/>",Environment.NewLine);
                        dvTestimFooter.InnerHtml = "<img src='Images/testiarrow.gif' alt='arrowimg' />" + tFooter;
                        //dvTestimContent.InnerText
                    
                    
                }

            #endregion


            //--- Load Follow Us Items  --//
            #region Retreive Follow us links and images 
                StringBuilder sbFlw = new StringBuilder();
                for (i = 0; i <= tbFollowus.Rows.Count - 1; i++)    
                    {
                        DataRow mFollowusRow = tbFollowus.Rows[i];

                        string mFollowImgHtml = "<img href='" + mFollowusRow["ComAppURL"].ToString() + "' src='" + @"Images\client\logos\" + mFollowusRow["ComAppImg"].ToString() + "' style='margin-right:10px; margin-bottom:5px;' alt='" + mFollowusRow["ComAppName"].ToString() + "'/>";    
                        sbFlw.Append(mFollowImgHtml);
                    }

                dvFollowUs.InnerHtml = sbFlw.ToString();

           
            
            #endregion



            // -- Load Contact Us Details -- ///
            #region Retreive Contact us Details 

                foreach (DataRow CntRow in tbContactUs.Rows)
                {
                   // lblHomePageContent.Text = CntRow["Description"].ToString().Replace(Environment.NewLine, "<br/>");
                    LtrContactUs_Email.Text = CntRow["Email"].ToString();
                    LtrContactUs_Fax.Text = CntRow["FaxNo"].ToString();
                    LtrContactUs_HandPhone.Text = CntRow["Handphone"].ToString();

                }


            #endregion

                RenderLangResourceControls();

       }



    }

   

    public void RenderLangResourceControls()
    {

        ltrTestimonials.Text = (string)GetGlobalResourceObject("LangResources", "Testimonial");
        LtrUpcomingEvents.Text = (string)GetGlobalResourceObject("LangResources", "upcomingevents");
        LtrRecentNews.Text = (string)GetGlobalResourceObject("LangResources", "recentnews");
        //LtrFollowUs.Text = (string)GetGlobalResourceObject("LangResources", "FollowUson");
        LtrFollowUs.Text = Resources.LangResources.FollowUson;
        LtrContactUs.Text = (string)GetGlobalResourceObject("LangResources", "ContactUs");
                
    }


    protected void btnSignIn_Click(object sender, EventArgs e)
    {
                    
        SqlConnection dbConn;
        SqlCommand dbCmd;
        SqlDataReader dbReader;
        string strSQL = string.Empty;

        bool LoginStatus = false;

        //string selectedLanguage;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        string mUserName = txtLoginID.Text;
        string mPassword = txtPassword.Text;

        try
        {
            strSQL = "Select UserID,LoginID,UserType from tblUsers where LoginID='" + mUserName + "' and LoginPassword='" + mPassword + "'";

            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    Session["UserID"] = dbReader["UserID"].ToString();
                    Session["LoginID"] = dbReader["LoginID"].ToString();
                    //Session["defLanguage"] = ddlLang.SelectedValue;
                    //lblErrMessage.Text = "User Sucessfully Logged IN ";
                    //selectedLanguage = Session["defLanguage"].ToString();
                    //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                    //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
                    LoginStatus = true;
                    
                }
            }
            else
            {
                LtrErrMessage.Text = "Invalid Password ..";
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

        if(LoginStatus)
            Response.Redirect("~/Admin/Ad_Welcome.aspx");
          //Server.Transfer("~/Admin/Welcome.aspx");



    }


    public int GetUserIdfromURL()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;

        string OurWebSiteName = "1argentinasms";

        string tmpMainURL = Request.Url.OriginalString;
        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

        if (tmpMainURL.Contains(OurWebSiteName))
        {
            //subdomain
            string tmpSubDomainURL = tmpMainURL;
            string[] MainURLArr = tmpMainURL.Split('.');

            string userSubDomainName = MainURLArr[1].ToString();
            newUserID = objBAL_User.GetUserID_BySubDomainName(userSubDomainName);



        }
        else
        {
            //owndomain
            string ownDomain = tmpMainURL;
            tmpMainURL = tmpMainURL.Replace("http://", "");

        }



        string tmpDname = "pencil";
        newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {
            Response.Redirect("PartnerWebRegistration.aspx");
        }


        return newUserID;


    }
}
