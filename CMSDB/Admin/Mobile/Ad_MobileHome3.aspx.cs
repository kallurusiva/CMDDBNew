using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.Sql; 
using System.Data.SqlClient;
using System.Text;

public partial class Admin_Ad_MobileHome3 : BasePage
{
    DataSet ds;
    DataTable dtButtons;
    DataTable dtBtnSelections;
    DataTable dtBtnTitles;

    int retTemplateID = 0; 

    CMSv3.BAL.MbMain objMb = new CMSv3.BAL.MbMain(); 

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        Page.MaintainScrollPositionOnPostBack = true;

      //  chkFreeSMS.Text = Resources.LangResources.Free + " SMS";

        HtmlGenericControl myDivLeftBar;
        myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

        myDivLeftBar.Style.Clear();
        myDivLeftBar.Style.Value = "width:0px;";


        HtmlGenericControl myDivRightBar;
        myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

        myDivRightBar.Style.Clear();
        myDivRightBar.Style.Value = " width: 96%; padding-left:20px;";



        if (!IsPostBack)
        {

           // LoadPanel(); 

            LoadButtonLinks();

            LoadMyTemplatesAndTitles();

            LoadAllTemplates();

            mobileIframe.Attributes.Add("src", "../../Mb/mb_Preview.aspx?prvUserID=" + Convert.ToInt32(Session["UserID"].ToString()));
            
            //RenderTrialPeriodAlert(Convert.ToInt32(Session["UserID"].ToString())); 
            string tmpLoggedINfrom = string.Empty; 

            if(Session["LoggedInFrom"] != null)
             tmpLoggedINfrom = Session["LoggedInFrom"].ToString();

            if (tmpLoggedINfrom == "DPE")
            {
                dvTrialPeriodAlert.Visible = false;
            }
            else
            {
                dvTrialPeriodAlert.Visible = true;
                lblTrialPeriodText.Text = "Advertisements would appear for the users who have not purchased the Mobile Web.";
            }

        }
        else
        {
          //  LoadButtonLinks();
        }

    }

    protected void LoadPanel()
    {

        CMSv3.BAL.MbMain objMb = new CMSv3.BAL.MbMain();
        int vMobileAccess = objMb.CheckMobileWebAccess(Session["MobileLoginID"].ToString());

        if (vMobileAccess == 0)
        {
            HiddenField1_ModalPopupExtender.Show();
            


            //StringBuilder sb = new StringBuilder();

            //sb.AppendLine("&nbsp;&nbsp;<p class='TPAlert'><font class='TPAlertFont'>&nbsp;&nbsp;&nbsp; MobileWeb Product not purchased Yet.</font></p>&nbsp;&nbsp;");
            //sb.AppendLine("<br/>");

            //sb.AppendLine("To purchase MobileWeb Product ");
            //sb.AppendLine("<br/>");
            //sb.AppendLine("<u style='font-family: Arial, Verdana, Helvetica, sans-serif; font-size: medium;'><span style='color: rgb(178, 34, 34);'><strong>Mobile Business Instruction -&nbsp;SMS Format</strong></span></u><span style='font-family: Arial; color: rgb(0, 0, 0); font-size: 11px; line-height: 18px; background-color: rgb(239, 239, 239);'>&nbsp;</span><br />");
            //sb.AppendLine("<b style='color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-weight: normal;'>");
            //sb.AppendLine("<span style='background-color: transparent; vertical-align: baseline; white-space: pre-wrap;'>1W &nbsp;BuyMobileWeb &nbsp;Password &nbsp;&nbsp;MobileNo &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendTo -- &gt; +447860034140 / +447624811654 &nbsp;/ &nbsp;+447781470708</span></b></p>");


            lblPanelTitle.Visible = false;
            lblPanelContent.Visible = false;

            //lblPanelTitle.Text = "MobileWeb Access restriction";
            //lblPanelContent.Text = sb.ToString(); 
            
        }
       
    }

    protected void LoadAllTemplates()
    {

        ds = objMb.Retrieve_ALLTemplates();


        DataTable dtTemplates;


        dtTemplates = ds.Tables[0];

      //  select3.DataSource = dtTemplates;
      //  select3.DataBind();


        String mTemplateName = string.Empty;
        String mTemplateID = string.Empty;
        String mImage = string.Empty;


        foreach (DataRow dtRow in dtTemplates.Rows)
        {
            mTemplateID     = dtRow["TemplateID"].ToString();
            mTemplateName   = dtRow["TemplateName"].ToString();



            mImage = @"<img src='../../Images/Mobile/ColorSet2/News.png'/>";
            ListItem vListItem = new ListItem(mTemplateName, mTemplateID);

           // vListItem.Attributes.Add("image_src", mImage); 
           // vListItem.Attributes.Add("style", "background-image:url(../../Images/Mobile/forward.png);");
           // vListItem.Attributes.Add("class","ddlimg"); 
            
            
            ddlTemplates.Items.Add(vListItem);

            if (Convert.ToInt32(mTemplateID) == retTemplateID)
                ddlTemplates.SelectedValue = retTemplateID.ToString();
                

            
        }



        //ddlTemplates.DataSource = ds;
        //ddlTemplates.DataTextField = "TemplateName";
        //ddlTemplates.DataValueField ="TemplateID";
        //ddlTemplates.DataBind(); 

        


    }

    protected void LoadMyTemplatesAndTitles()
    {
        DataTable dtMyTemplates; 
        ds = objMb.Retrieve_SelectedTemplate(Convert.ToInt32(Session["UserID"].ToString()));
        dtMyTemplates = ds.Tables[0];


        String TmpID = string.Empty;
        String TmpTitle1 = string.Empty;
        String TmpTitle2 = string.Empty;
        bool vSkipMobileWeb = false;

        foreach (DataRow dtRow in dtMyTemplates.Rows)
        {
            retTemplateID = Convert.ToInt32(dtRow["TemplateID"].ToString());
            TmpTitle1 = dtRow["Title1"].ToString();
            TmpTitle2 = dtRow["Title2"].ToString();
            vSkipMobileWeb = Convert.ToBoolean(dtRow["SkipMobileWeb"].ToString()); 
        }

        txtTitle1.Text = TmpTitle1;
        txtTitle2.Text = TmpTitle2;

        chkMobileDetection.Checked = vSkipMobileWeb; 

        //HtmlTableRow tr1 = (HtmlTableRow)Master.FindControl("MROW1");
        //tr1.Visible = false;


        //HtmlTableRow tr2 = (HtmlTableRow)Master.FindControl("MROW2");
        //tr2.Visible = false;

        //HtmlTableRow tr3 = (HtmlTableRow)Master.FindControl("MROW3");
        //tr3.Visible = false;

        //HtmlContainerControl tmpDivHeader = (HtmlContainerControl)Master.FindControl("headercontent");
        //tmpDivHeader.Attributes.Add("height", "80px"); 

        
    }


    protected void LoadButtonLinks()
    {


        DataTable dtAboutUs;
        DataTable dtOwnMobileBtn1;
        DataTable dtOwnMobileBtn2;
        DataTable dtOwnMobileBtn3;
        DataTable dtOwnMobileBtn4;
        DataTable dtOwnMobileBtn5;
        DataTable dtOwnMobileBtn6;

        DataTable dtNews;
        DataTable dtEvents;
        DataTable dtContactUs;


        //..retrieving the user selected buttons 
        ds = objMb.Retrieve_SelectedButtonsByUserID(Convert.ToInt32(Session["UserID"].ToString()));
        dtBtnSelections = ds.Tables[0];
        dtBtnTitles = ds.Tables[1];
        dtAboutUs = ds.Tables[2];
        dtOwnMobileBtn1 = ds.Tables[3];
        dtOwnMobileBtn2 = ds.Tables[4];
        dtOwnMobileBtn3 = ds.Tables[5];
        dtOwnMobileBtn4 = ds.Tables[6];
        dtOwnMobileBtn5 = ds.Tables[7];
        dtOwnMobileBtn6 = ds.Tables[8];

        dtNews = ds.Tables[9];
        dtEvents = ds.Tables[10];
        dtContactUs = ds.Tables[11];


        //..looping thru table to get the selected buttons CSV string.. 
        String csvSelButtonStr = string.Empty;
        foreach (DataRow dtRow in dtBtnSelections.Rows)
        {
            if (csvSelButtonStr != string.Empty)
                csvSelButtonStr += ",";
            csvSelButtonStr += dtRow["ButtonID"].ToString();

            String tmpButtonID = dtRow["ButtonID"].ToString(); 

            if (tmpButtonID == "1")
                chkAboutUs.Checked = true;
            
            //.Other Buttons
            if (tmpButtonID == "2")
                chkNews.Checked = true;
            
            if (tmpButtonID == "3")
                chkEvents.Checked = true;


            if (tmpButtonID == "4")
                chkContactUs.Checked = true;

            if (tmpButtonID == "5")
                chkLocationMap.Checked = true;

            //if (tmpButtonID == "6")
            //    chkFreeSMS.Checked = true; 
        }

        
        //string testStr = "7";

        //bool vals = csvSelButtonStr.Contains(testStr);
        //.. rendering checkboxes 
        #region Rendering Checkboxes 
        


        //1	About US
        //2	News
        //3	Events
        //4	Contact Us
        //5	Location Map
        //6 FREE SMS
        //41	SMS Login
        //42	Partner Login
        //43	WebPortal Login
        //44	FullWebSite
        
        //51	Mobile Button 1
        //52	Mobile Button 2
        //53	Mobile Button 3
        //54	Mobile Button 4
        //55	Mobile Button 5
        //56	Mobile Button 6

        //61	Facebook
        //62	Twitter
        //63	Yahoo 
        //64	Skype

        //..about Us
        //if(csvSelButtonStr.Contains("1"))
        //chkAboutUs.Checked = true;


        ////.Other Buttons
        //if(csvSelButtonStr.Contains("2"))
        //    chkNews.Checked = true;


        //if(csvSelButtonStr.Contains("3"))
        //    chkEvents.Checked = true;


        //if(csvSelButtonStr.Contains("4"))
        //    chkContactUs.Checked = true;

        //if (csvSelButtonStr.Contains("5"))
        //    chkLocationMap.Checked = true;

        //if (csvSelButtonStr.Contains("6"))
        //    chkFreeSMS.Checked = true; 
        

        //..Down Link Buttons
        //if (csvSelButtonStr.Contains("41"))
        //    chkLoginSMS.Checked = true;

        //if (csvSelButtonStr.Contains("42"))
        //    chkLoginPartner.Checked = true;

        if (csvSelButtonStr.Contains("44"))
            chkFullWebsite.Checked = true;


        //.. Mobile Buttons
        if(csvSelButtonStr.Contains("51"))
            chkOwnMobileBtn1.Checked = true;

        if(csvSelButtonStr.Contains("52"))
            chkOwnMobileBtn2.Checked = true;

        if(csvSelButtonStr.Contains("53"))
            chkOwnMobileBtn3.Checked = true;

        if (csvSelButtonStr.Contains("54"))
            chkOwnMobileBtn4.Checked = true;

        if (csvSelButtonStr.Contains("55"))
            chkOwnMobileBtn5.Checked = true;

        if (csvSelButtonStr.Contains("56"))
            chkOwnMobileBtn6.Checked = true;


        //..Social Media
        if(csvSelButtonStr.Contains("61"))
            chkFacebook.Checked = true;

        if (csvSelButtonStr.Contains("62"))
            chkTwitter.Checked = true;

        #endregion

        //..About Us content

        foreach(DataRow abtRow in dtAboutUs.Rows)
        {
            String Content_AboutUs = abtRow["Description"].ToString();

            dvAbtUs.InnerHtml = FormatToolTip("About Us", Content_AboutUs); 

            
          //  ImgPw_AboutUs.ToolTip = FormatToolTip("About Us", Content_AboutUs); 
        }

        // Own Mobile Buttons 1 
        #region ToolTip Content for Own Mobile Button 
        String mb1Header = string.Empty;
        String mb1Content = string.Empty;

        foreach (DataRow mb1Row in dtOwnMobileBtn1.Rows)
        {
            

            string tmpOwnBtnName = mb1Row["OwnBtnName"].ToString();
            string tmpOwnBtnDesc = mb1Row["OwnBtnDesc"].ToString();
            string tmpOwnBtnIcon = mb1Row["OwnBtnIcon"].ToString();
            string tmpOwnBtnPicture = mb1Row["OwnBtnPicture"].ToString();
            string tmpYouTubeLink = mb1Row["youtubeLink"].ToString();
            tmpOwnBtnDesc = tmpOwnBtnDesc.Replace(Environment.NewLine, "<br/>");

            string tmpImagePath = string.Empty;

            //..ICON
            if (tmpOwnBtnIcon != string.Empty)
            {
                //tmpImagePath = "<img width='42' height='42' src='../../ImageRepository/Mobile/" + tmpOwnBtnIcon + "' /> ";
                //mb1Header = tmpImagePath + tmpOwnBtnName;
                
                mb1Header = tmpOwnBtnName;
            }
            else
            {
                mb1Header = tmpOwnBtnName;
            }

            String TmpDesc = string.Empty;

            //Picture
            if (tmpOwnBtnPicture != string.Empty)
            {
                //String ImgPath = @"..\..\ImageRepository\Mobile\";
                //String ImgStr = "<img src='" + ImgPath + tmpOwnBtnPicture + "' class='floatLeft'>";
                //TmpDesc = ImgStr + "<p> " + tmpOwnBtnDesc + "</p>";
                TmpDesc = tmpOwnBtnDesc;

            }
            else
            {
                TmpDesc = tmpOwnBtnDesc;
            }

            //..YouTubeLink

            //if (tmpYouTubeLink != string.Empty)
            //{
            //    String FormedYouTubeLink = GetFormedYoutubeLink(tmpYouTubeLink);
            //    //http://www.youtube.com/embed/n62M8ckcCWU;
            //    if (FormedYouTubeLink != "")
            //    {

            //        TmpDesc += "<br/>";
            //        TmpDesc += FormedYouTubeLink;
            //        //TmpDesc += "<iframe width='250' height='250' src='" + tmpYouTubeLink + "' frameborder='0' allowfullscreen></iframe>";
            //    }
            //}


            mb1Content = TmpDesc;
           

        }
        dvMb1.InnerHtml = FormatToolTip(mb1Header, mb1Content);
        #endregion


        // Own Mobile Buttons 2 
        #region ToolTip Content for Own Mobile Button 2
        String mb2Header = string.Empty;
        String mb2Content = string.Empty;

        foreach (DataRow mb2Row in dtOwnMobileBtn2.Rows)
        {
          

            string tmpOwnBtnName = mb2Row["OwnBtnName"].ToString();
            string tmpOwnBtnDesc = mb2Row["OwnBtnDesc"].ToString();
            string tmpOwnBtnIcon = mb2Row["OwnBtnIcon"].ToString();
            string tmpOwnBtnPicture = mb2Row["OwnBtnPicture"].ToString();
            string tmpYouTubeLink = mb2Row["youtubeLink"].ToString();
            tmpOwnBtnDesc = tmpOwnBtnDesc.Replace(Environment.NewLine, "<br/>");

            string tmpImagePath = string.Empty;

            //..ICON
            if (tmpOwnBtnIcon != string.Empty)
            {
                //tmpImagePath = "<img width='42' height='42' src='../../ImageRepository/Mobile/" + tmpOwnBtnIcon + "' /> ";
                //mb1Header = tmpImagePath + tmpOwnBtnName;

                mb2Header = tmpOwnBtnName;
            }
            else
            {
                mb2Header = tmpOwnBtnName;
            }

            String TmpDesc = string.Empty;

            //Picture
            if (tmpOwnBtnPicture != string.Empty)
            {
                //String ImgPath = @"..\..\ImageRepository\Mobile\";
                //String ImgStr = "<img src='" + ImgPath + tmpOwnBtnPicture + "' class='floatLeft'>";
                //TmpDesc = ImgStr + "<p> " + tmpOwnBtnDesc + "</p>";
                TmpDesc = tmpOwnBtnDesc;

            }
            else
            {
                TmpDesc = tmpOwnBtnDesc;
            }

            //..YouTubeLink

            //if (tmpYouTubeLink != string.Empty)
            //{
            //    String FormedYouTubeLink = GetFormedYoutubeLink(tmpYouTubeLink);
            //    //http://www.youtube.com/embed/n62M8ckcCWU;
            //    if (FormedYouTubeLink != "")
            //    {

            //        TmpDesc += "<br/>";
            //        TmpDesc += FormedYouTubeLink;
            //        //TmpDesc += "<iframe width='250' height='250' src='" + tmpYouTubeLink + "' frameborder='0' allowfullscreen></iframe>";
            //    }
            //}


            mb2Content = TmpDesc;
           

        }
        dvMb2.InnerHtml = FormatToolTip(mb2Header, mb2Content);
        #endregion

        // Own Mobile Buttons 3 
        #region ToolTip Content for Own Mobile Button 3
        String mb3Header = string.Empty;
        String mb3Content = string.Empty;

        foreach (DataRow mb3Row in dtOwnMobileBtn3.Rows)
        {
            

            string tmpOwnBtnName = mb3Row["OwnBtnName"].ToString();
            string tmpOwnBtnDesc = mb3Row["OwnBtnDesc"].ToString();
            string tmpOwnBtnIcon = mb3Row["OwnBtnIcon"].ToString();
            string tmpOwnBtnPicture = mb3Row["OwnBtnPicture"].ToString();
            string tmpYouTubeLink = mb3Row["youtubeLink"].ToString();
            tmpOwnBtnDesc = tmpOwnBtnDesc.Replace(Environment.NewLine, "<br/>");

            string tmpImagePath = string.Empty;

            //..ICON
            if (tmpOwnBtnIcon != string.Empty)
            {
                //tmpImagePath = "<img width='42' height='42' src='../../ImageRepository/Mobile/" + tmpOwnBtnIcon + "' /> ";
                //mb1Header = tmpImagePath + tmpOwnBtnName;

                mb3Header = tmpOwnBtnName;
            }
            else
            {
                mb3Header = tmpOwnBtnName;
            }

            String TmpDesc = string.Empty;

            //Picture
            if (tmpOwnBtnPicture != string.Empty)
            {
                //String ImgPath = @"..\..\ImageRepository\Mobile\";
                //String ImgStr = "<img src='" + ImgPath + tmpOwnBtnPicture + "' class='floatLeft'>";
                //TmpDesc = ImgStr + "<p> " + tmpOwnBtnDesc + "</p>";
                TmpDesc = tmpOwnBtnDesc;

            }
            else
            {
                TmpDesc = tmpOwnBtnDesc;
            }

            //..YouTubeLink

            //if (tmpYouTubeLink != string.Empty)
            //{
            //    String FormedYouTubeLink = GetFormedYoutubeLink(tmpYouTubeLink);
            //    //http://www.youtube.com/embed/n62M8ckcCWU;
            //    if (FormedYouTubeLink != "")
            //    {

            //        TmpDesc += "<br/>";
            //        TmpDesc += FormedYouTubeLink;
            //        //TmpDesc += "<iframe width='250' height='250' src='" + tmpYouTubeLink + "' frameborder='0' allowfullscreen></iframe>";
            //    }
            //}


            mb3Content = TmpDesc;
           

        }
        dvMb3.InnerHtml = FormatToolTip(mb3Header, mb3Content);
        #endregion


        // Own Mobile Buttons 4 
        #region ToolTip Content for Own Mobile Button 4
        String mb4Header = string.Empty;
        String mb4Content = string.Empty;

        foreach (DataRow mb4Row in dtOwnMobileBtn4.Rows)
        {


            string tmpOwnBtnName = mb4Row["OwnBtnName"].ToString();
            string tmpOwnBtnDesc = mb4Row["OwnBtnDesc"].ToString();
            string tmpOwnBtnIcon = mb4Row["OwnBtnIcon"].ToString();
            string tmpOwnBtnPicture = mb4Row["OwnBtnPicture"].ToString();
            string tmpYouTubeLink = mb4Row["youtubeLink"].ToString();
            tmpOwnBtnDesc = tmpOwnBtnDesc.Replace(Environment.NewLine, "<br/>");

            string tmpImagePath = string.Empty;

            //..ICON
            if (tmpOwnBtnIcon != string.Empty)
            {
                //tmpImagePath = "<img width='42' height='42' src='../../ImageRepository/Mobile/" + tmpOwnBtnIcon + "' /> ";
                //mb1Header = tmpImagePath + tmpOwnBtnName;

                mb4Header = tmpOwnBtnName;
            }
            else
            {
                mb4Header = tmpOwnBtnName;
            }

            String TmpDesc = string.Empty;

            //Picture
            if (tmpOwnBtnPicture != string.Empty)
            {
                //String ImgPath = @"..\..\ImageRepository\Mobile\";
                //String ImgStr = "<img src='" + ImgPath + tmpOwnBtnPicture + "' class='floatLeft'>";
                //TmpDesc = ImgStr + "<p> " + tmpOwnBtnDesc + "</p>";
                TmpDesc = tmpOwnBtnDesc;

            }
            else
            {
                TmpDesc = tmpOwnBtnDesc;
            }

            mb4Content = TmpDesc;


        }
        dvMb4.InnerHtml = FormatToolTip(mb4Header, mb4Content);
        #endregion



        // Own Mobile Buttons 5 
        #region ToolTip Content for Own Mobile Button 5
        String mb5Header = string.Empty;
        String mb5Content = string.Empty;

        foreach (DataRow mb5Row in dtOwnMobileBtn5.Rows)
        {


            string tmpOwnBtnName = mb5Row["OwnBtnName"].ToString();
            string tmpOwnBtnDesc = mb5Row["OwnBtnDesc"].ToString();
            string tmpOwnBtnIcon = mb5Row["OwnBtnIcon"].ToString();
            string tmpOwnBtnPicture = mb5Row["OwnBtnPicture"].ToString();
            string tmpYouTubeLink = mb5Row["youtubeLink"].ToString();
            tmpOwnBtnDesc = tmpOwnBtnDesc.Replace(Environment.NewLine, "<br/>");

            string tmpImagePath = string.Empty;

            //..ICON
            if (tmpOwnBtnIcon != string.Empty)
            {
                //tmpImagePath = "<img width='42' height='42' src='../../ImageRepository/Mobile/" + tmpOwnBtnIcon + "' /> ";
                //mb1Header = tmpImagePath + tmpOwnBtnName;

                mb5Header = tmpOwnBtnName;
            }
            else
            {
                mb5Header = tmpOwnBtnName;
            }

            String TmpDesc = string.Empty;

            //Picture
            if (tmpOwnBtnPicture != string.Empty)
            {
                //String ImgPath = @"..\..\ImageRepository\Mobile\";
                //String ImgStr = "<img src='" + ImgPath + tmpOwnBtnPicture + "' class='floatLeft'>";
                //TmpDesc = ImgStr + "<p> " + tmpOwnBtnDesc + "</p>";
                TmpDesc = tmpOwnBtnDesc;

            }
            else
            {
                TmpDesc = tmpOwnBtnDesc;
            }

            mb5Content = TmpDesc;


        }
        dvMb5.InnerHtml = FormatToolTip(mb5Header, mb5Content);
        #endregion


        // Own Mobile Buttons 6 
        #region ToolTip Content for Own Mobile Button 6
        String mb6Header = string.Empty;
        String mb6Content = string.Empty;

        foreach (DataRow mb6Row in dtOwnMobileBtn6.Rows)
        {


            string tmpOwnBtnName = mb6Row["OwnBtnName"].ToString();
            string tmpOwnBtnDesc = mb6Row["OwnBtnDesc"].ToString();
            string tmpOwnBtnIcon = mb6Row["OwnBtnIcon"].ToString();
            string tmpOwnBtnPicture = mb6Row["OwnBtnPicture"].ToString();
            string tmpYouTubeLink = mb6Row["youtubeLink"].ToString();
            tmpOwnBtnDesc = tmpOwnBtnDesc.Replace(Environment.NewLine, "<br/>");

            string tmpImagePath = string.Empty;

            //..ICON
            if (tmpOwnBtnIcon != string.Empty)
            {
                //tmpImagePath = "<img width='42' height='42' src='../../ImageRepository/Mobile/" + tmpOwnBtnIcon + "' /> ";
                //mb1Header = tmpImagePath + tmpOwnBtnName;

                mb6Header = tmpOwnBtnName;
            }
            else
            {
                mb6Header = tmpOwnBtnName;
            }

            String TmpDesc = string.Empty;

            //Picture
            if (tmpOwnBtnPicture != string.Empty)
            {
                //String ImgPath = @"..\..\ImageRepository\Mobile\";
                //String ImgStr = "<img src='" + ImgPath + tmpOwnBtnPicture + "' class='floatLeft'>";
                //TmpDesc = ImgStr + "<p> " + tmpOwnBtnDesc + "</p>";
                TmpDesc = tmpOwnBtnDesc;

            }
            else
            {
                TmpDesc = tmpOwnBtnDesc;
            }

            mb6Content = TmpDesc;


        }
        dvMb6.InnerHtml = FormatToolTip(mb6Header, mb6Content);
        #endregion



        //.. Tooltip News 
        #region ToolTip content for News 
    
        String NewsHeader = string.Empty;
        String NewsContent = string.Empty;
        String tmpNewsItems = string.Empty;
        int nCounter = 0; 
        foreach (DataRow NewsRow in dtNews.Rows)
        {
            String NewsTitle = string.Empty;
            String NewsPstDate = string.Empty;
            String NewsDesc = string.Empty;


            NewsTitle = NewsRow["NewsTitle"].ToString();
            NewsPstDate = NewsRow["NewsDate"].ToString();
            NewsDesc = NewsRow["NewsContent"].ToString();
            nCounter += 1; 
            tmpNewsItems += "<b>" + nCounter + "." +  NewsTitle + "</b> [Posted on: " + NewsPstDate + "]<br/>";
            tmpNewsItems += NewsDesc + "<br/>";
            tmpNewsItems += "<hr/>";

        }

        dvNews.InnerHtml = FormatToolTip("News", tmpNewsItems); 
        #endregion


        //.. ToolTip Events...
        #region Rendering Tooltip for Events... 
        
        String tmpEventRows = string.Empty;
        int eCounter = 0;
        foreach (DataRow evtRow in dtEvents.Rows)
        {
            String EvtTitle = evtRow["EventTitle"].ToString();
            String EvtContent = evtRow["EventContent"].ToString();
            String EvtFrom = evtRow["EventDate"].ToString();
            String EvtTo = evtRow["EventDateTo"].ToString();

            eCounter += 1;
            tmpEventRows += "<b>" + eCounter + "." + EvtTitle + "</b><br/>[To be held from " + EvtFrom + " To " + EvtTo + "]<br/>";
            tmpEventRows += EvtContent + "<br/>";
            tmpEventRows += "<hr/>";

        }

        dvEvents.InnerHtml = FormatToolTip("Events", tmpEventRows);

        #endregion


        //.. Tooltip ContactUs..
        #region Rendering Contact Us tooltip..
          StringBuilder sbContactUs = new StringBuilder();
        foreach (DataRow ctRow in dtContactUs.Rows)
        {

            String ctCompanName = ctRow["CompanyName"].ToString();
            String ctNickName = string.Empty;
            string ctHandPhone = string.Empty;
            string ctHomePhone = string.Empty;
            string ctFax = string.Empty;
            string ctEmail = string.Empty;
            string ctAddress = string.Empty;
            string ctContactImgPath = string.Empty;



            if (ctRow["NickNamechk"].ToString() == "True")
                ctNickName = ctRow["NickName"].ToString();


            //HandPhone
            if (ctRow["MobileNochk"].ToString() == "True")
            {
                if ((ctRow["HandPhone"].ToString() == null) || (ctRow["HandPhone"].ToString() == ""))
                {

                    ctHandPhone = "";
                    //imgHandPhone.Visible = false;
                }
                else
                {

                    ctHandPhone = "<img title='Handphone' alt='handphne' id='imgHandPhone' runat='server' src='../../Images/icon_handphone.jpg' style='width: 27px; height: 25px' />&nbsp;&nbsp;" + " + " + ctRow["HandPhone"].ToString();
                }
            }

            //HomePhone
            if (ctRow["HomePhonechk"].ToString() == "True")
            {
                if ((ctRow["HomePhone"].ToString() == null) || (ctRow["HomePhone"].ToString() == ""))
                {

                    ctHomePhone = "";
                    //imgHomePhone.Visible = false;
                }
                else
                {
                    ctHomePhone = " <img  title='Homephone' alt='homephone' id='imgHomePhone' runat='server' src='../../Images/icon_homephone.jpg' style='width: 27px; height: 23px' />&nbsp;&nbsp;" + " + " + ctRow["HomePhone"].ToString();
                }
            }

            //FAX
            if (ctRow["FaxNochk"].ToString() == "True")
            {
                if ((ctRow["FaxNo"].ToString() == null) || (ctRow["FaxNo"].ToString() == ""))
                {

                    ctFax = "";
                    //imgFaxPhone.Visible = false;
                }
                else
                {
                    ctFax = @"<img title='Fax' alt='fax' id='imgFaxPhone' runat='server' src='../../Images/icon_fax.jpg' style='width: 27px; height: 25px' />&nbsp;&nbsp;" + " + " + ctRow["FaxNo"].ToString();
                }
            }


            if (ctRow["Emailchk"].ToString() == "True")
            {
                if ((ctRow["Email"].ToString() == null) || (ctRow["Email"].ToString() == ""))
                {
                    ctEmail = ctRow["Email"].ToString();
                    //imgEmail.Visible = false;
                }
                else
                {
                    ctEmail = "<img title='Email' alt='Email' id='imgEmail' runat='server' src='../../Images/icon_email.jpg' style='width: 27px; height: 25px' />&nbsp;&nbsp;&nbsp;&nbsp;" + ctRow["Email"].ToString();
                }
            }

            if (ctRow["Addresschk"].ToString() == "True")
            {
                string tmpAddress = ctRow["Address"].ToString();
                tmpAddress = tmpAddress.Replace("<br/>", Environment.NewLine);
                ctAddress = ctRow["Address"].ToString(); 
            } 

            if (ctRow["UserPhotoChk"].ToString() == "True")
                ctContactImgPath = ctRow["FullImgPath"].ToString();
            else
                ctContactImgPath = @"~\ImageRepository\Dummy_user.gif";

            //"~\ImageRepository\111_8584946_19012011213.jpg"

            String CtImgPath = ctContactImgPath.Replace(@"~\ImageRepository\",""); 
            CtImgPath = "../../ImageRepository/" +  CtImgPath;

            sbContactUs.AppendLine("<img src='" + CtImgPath + "' width='70' height='70' border='0'></img>"); 
            sbContactUs.AppendLine(ctCompanName + "<br/><br/>");
            sbContactUs.AppendLine(ctAddress + "<br/>");
            sbContactUs.AppendLine(ctHomePhone + "<br/>");
            sbContactUs.AppendLine(ctHandPhone + "<br/>");
            sbContactUs.AppendLine(ctFax + "<br/>");
            sbContactUs.AppendLine(ctEmail + "<br/>");
           

        }

        dvContactUs.InnerHtml = FormatToolTip("Contact Us",sbContactUs.ToString());

        #endregion


    }


    
    protected void RenderCheckBoxListWithSelections(DataView dvSource, CheckBoxList chkList, string vSelListStr)
    {



        chkList.DataSource = dvSource;
        chkList.DataTextField = "ButtonName";
        chkList.DataValueField = "ButtonID";
        chkList.DataBind();



        foreach (ListItem ckItem in chkList.Items)
        {
            if (vSelListStr != string.Empty)
            {
                if (vSelListStr.Contains(ckItem.Value))
                {
                    ckItem.Selected = true;
                }
            }
            else
            {
                ckItem.Selected = false;
            }


           // ckItem.Text = ckItem.Text + @"<div style='float:right;'><a href='#' tooltip='edit'><img style='padding-left:100px;  border:none;'  src='..\..\Images\Mobile\edit.png'/></a> <a href='#' tooltip='preview'><img style='padding-left:20px; border:none;'  src='..\..\Images\Mobile\preview.png'/></a></div>";

        }


    }




    protected void LoadHTMLButtonLinks()
    {

        //..retrieving the user selected buttons 
        ds = objMb.Retrieve_SelectedButtonsByUserID(Convert.ToInt32(Session["UserID"].ToString()));
        dtBtnSelections = ds.Tables[0];
        dtBtnTitles = ds.Tables[1];

        //..looping thru table to get the selected buttons CSV string.. 
        String csvSelButtonStr = string.Empty;
        foreach (DataRow dtRow in dtBtnSelections.Rows)
        {
            if (csvSelButtonStr != string.Empty)
                csvSelButtonStr += ",";
            csvSelButtonStr += dtRow["ButtonID"].ToString();
        }

        //string testStr = "7";

        //bool vals = csvSelButtonStr.Contains(testStr);


        StringBuilder sbBtns = new StringBuilder();
        sbBtns.AppendLine("<table id='tblButtons' cellpadding='0' cellspacing='0' width='100%'>");
       // sbBtns.AppendLine("<tr>");


        String tmpBtnID = string.Empty;
        String tmpBtnName = string.Empty;
        String tmpRowCss = string.Empty;
        String tmpisChecked = string.Empty;
        int tmpShownAs = 0;

        int RowAdded_OwnMobile = 0;
        int RowAdded_SocialMedia = 0; 



        ds = objMb.RetrieveAll_MobiButtonsInfo();
        dtButtons = ds.Tables[0];

        DataView dvButtons = ds.Tables[0].DefaultView;


        foreach (DataRowView dvRow in dvButtons) 
        {
            tmpBtnID = dvRow["ButtonID"].ToString(); 
            tmpBtnName = dvRow["ButtonName"].ToString();
            tmpShownAs = Convert.ToInt16(dvRow["ShownAs"].ToString());

            String TmpBtnStr = string.Empty;

            switch (tmpShownAs)
            {
                case 1: tmpRowCss = "FontBRowText1";
                    break;
                case 2: tmpRowCss = "FontBRowText2";
                  
                    break;
                case 3: tmpRowCss = "FontBRowText3";
                    if(RowAdded_OwnMobile == 0)
                        sbBtns.AppendLine("<tr><td class='FontBRowTextBkg' style='padding-left: 40px;'>My Mobile Buttons</td></tr>");
                    RowAdded_OwnMobile = 1;
                    break;

                case 4: tmpRowCss = "FontBRowText4"; 
                    if (RowAdded_SocialMedia == 0)
                        sbBtns.AppendLine("<tr><td class='FontBRowTextBkg' style='padding-left: 40px;'>Social Media Buttons</td></tr>");
                    RowAdded_SocialMedia = 1;
                    break;
            }

            if (csvSelButtonStr.Contains(tmpBtnID))
                tmpisChecked = "checked";
            else
                tmpisChecked = "";
 

             //<input id="ctl00_ContentBody_CheckBox1" type="checkbox" name="ctl00$ContentBody$CheckBox1" />
            //TmpBtnStr = "<td class='"+ tmpRowCss +"'> <asp:CheckBox ID='chkBtnID" + tmpBtnID + "' Text='" + tmpBtnName + "' runat='server' /> </td>";
            TmpBtnStr = "<tr><td class='" + tmpRowCss + "'> <input ID='chkBtnID" + tmpBtnID + "' " + tmpisChecked + " type='checkbox' value='" + tmpBtnID + "' runat='server' /><span class='chkboxText'>" + tmpBtnName + "</span></td></tr>";

            sbBtns.AppendLine(TmpBtnStr); 

        }

       // sbBtns.AppendLine("</tr>");
        sbBtns.AppendLine("</table>");

        divbuttomHTML.InnerHtml = sbBtns.ToString(); 
        



        //foreach (ListItem ckItem in chkButtonLinks.Items)
        //{
        //    if (csvSelButtonStr != string.Empty)
        //    {
        //        if (csvSelButtonStr.Contains(ckItem.Value))
        //        {
        //            ckItem.Selected = true;
        //        }
        //    }
        //    else
        //    {
        //        ckItem.Selected = false;
        //    }

        //}



    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {

        String SelectedChkListStr = string.Empty;


        int tmpTemplateID = Convert.ToInt32(ddlTemplates.SelectedValue); 


        //Logo title Info..
        String tmpTitle1 = txtTitle1.Text.Trim();
        String tmpTitle2 = txtTitle2.Text.Trim();


        //..about Us
        if (chkAboutUs.Checked)
            SelectedChkListStr += "1";

        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";

        //.Other Buttons
        if (chkNews.Checked)
            SelectedChkListStr += "2";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        if (chkEvents.Checked)
            SelectedChkListStr += "3";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        if (chkContactUs.Checked)
            SelectedChkListStr += "4";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        if (chkLocationMap.Checked)
             SelectedChkListStr += "5";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";

        //if (chkFreeSMS.Checked) 
        //    SelectedChkListStr += "6";
        //if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        //..Down Link Buttons
        //if (chkLoginSMS.Checked)
        //    SelectedChkListStr += "41";
        //if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        //if (chkLoginPartner.Checked)
        //   SelectedChkListStr += "42";
        //if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";

        if (chkFullWebsite.Checked)
            SelectedChkListStr += "44";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";



        //.. Mobile Buttons
        if (chkOwnMobileBtn1.Checked)
            SelectedChkListStr += "51";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";

        if (chkOwnMobileBtn2.Checked)
           SelectedChkListStr += "52";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";

        if (chkOwnMobileBtn3.Checked)
           SelectedChkListStr += "53";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        if (chkOwnMobileBtn4.Checked)
            SelectedChkListStr += "54";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        if (chkOwnMobileBtn5.Checked)
            SelectedChkListStr += "55";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        if (chkOwnMobileBtn6.Checked)
            SelectedChkListStr += "56";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";


        //..Social Media
        if (chkFacebook.Checked)
           SelectedChkListStr += "61";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";

        if (chkTwitter.Checked)
           SelectedChkListStr += "62";
        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";





        //..Down Buttons






        ////Default Buttons 
        //foreach (ListItem ckItem in chkAboutBtns.Items)
        //{

        //    if (ckItem.Selected)
        //    {
        //        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
        //        SelectedChkListStr += ckItem.Value;
        //    }
        //}

        

        ////Other Buttons 
        //foreach (ListItem ckItem in chkOtherButtons.Items)
        //{

        //    if (ckItem.Selected)
        //    {
        //        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
        //        SelectedChkListStr += ckItem.Value;
        //    }
        //}


        ////own  Buttons 
        //foreach (ListItem ckItem in chkOwnBtns.Items)
        //{

        //    if (ckItem.Selected)
        //    {
        //        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
        //        SelectedChkListStr += ckItem.Value;
        //    }
        //}


        ////Social  Buttons 
        //foreach (ListItem ckItem in chkSocialBtns.Items)
        //{

        //    if (ckItem.Selected)
        //    {
        //        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
        //        SelectedChkListStr += ckItem.Value;
        //    }
        //}


        ////BottomLinks 
        //foreach (ListItem ckItem in chkBottonBtns.Items)
        //{

        //    if (ckItem.Selected)
        //    {
        //        if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
        //        SelectedChkListStr += ckItem.Value;
        //    }
        //}

        

        int upStatus = objMb.UpdateButtonSelection(Convert.ToInt32(Session["UserID"].ToString()), SelectedChkListStr, tmpTitle1, tmpTitle2, tmpTemplateID, chkMobileDetection.Checked);


        if (upStatus != -1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Button Settings successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the Settings. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }
       // LoadButtonLinks();
      //  Response.Redirect("~/Admin/Mobile/Ad_MobileHome3.aspx");
       // mobileIframe.Attributes.Add("src", "../../Mb/mb_Preview.aspx?prvUserID=" + Convert.ToInt32(Session["UserID"].ToString())); 
        

    }

    public string FormatToolTip(string vTitle, string vContent)
    {

        if (vContent.Trim() == "")
        {
            vContent = "Contents are Empty. <br/>Please use the Edit Button to Add Content.";
        }

        StringBuilder sbHTML = new StringBuilder();

        sbHTML.AppendLine("<div id='dvHeader' class='ToopTipHeader'>");
        sbHTML.AppendLine("<font class='ToopTipHeaderText'> " + vTitle + "<br/></font>");
        sbHTML.AppendLine("</div>");
        sbHTML.AppendLine("<div id='ToopTipContent'>");
        sbHTML.AppendLine("<font class='ToopTipContentText'> " + vContent + "</font>");
        sbHTML.AppendLine("</div>");

        return sbHTML.ToString(); 


    }

    public string GetFormedYoutubeLink(string vYtlink)
    {
        String retString = string.Empty;
        String OrgYTlink = vYtlink;
        //http://youtu.be/xd12hR68sWM
        //<iframe width="420" height="315" src="http://www.youtube.com/embed/xd12hR68sWM" frameborder="0" allowfullscreen></iframe>


        if (vYtlink.Contains("youtu.be"))
        {
            vYtlink = vYtlink.Replace("http://", "");
            vYtlink = vYtlink.Replace("youtu.be/", "");
            vYtlink = vYtlink.Replace("youtu.be.com/", "");
            retString = "<iframe width='250' height='250' src='http://www.youtube.com/embed/" + vYtlink + "' frameborder='0' allowfullscreen></iframe>";

        }
        else if (vYtlink.Contains("<iframe"))
        {
            int tmpStartPointer = vYtlink.IndexOf("src=");
            int tmpEndPointer = vYtlink.IndexOf("frameborder");

            if ((tmpStartPointer != 0) && (tmpEndPointer != 0))
            {
                tmpStartPointer += 5;
                tmpEndPointer -= 2;
                tmpEndPointer = tmpEndPointer - tmpStartPointer;
                vYtlink = vYtlink.Substring(tmpStartPointer, tmpEndPointer);
                vYtlink = vYtlink.Replace("http://", "");
                vYtlink = vYtlink.Replace("youtu.be.com/", "");
                vYtlink = vYtlink.Replace("www.youtube.com/", "");
                vYtlink = vYtlink.Replace("embed/", "");
                retString = "<iframe width='250' height='250' src='http://www.youtube.com/embed/" + vYtlink + "' frameborder='0' allowfullscreen></iframe>";
            }
        }


        return retString;

    }

    protected void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        
    }


    protected void RenderTrialPeriodAlert(int vUserID)
    {

        //..get Trialperiod start date for OLD Users. 

        DateTime dtTP_StartDate = Convert.ToDateTime(ConfigurationManager.AppSettings["TrialPeriodStartDate"].ToString());
        DateTime dtCurrentDateTime = DateTime.Now; 
        TimeSpan diffdt = new TimeSpan();  

        //diffdt = dtCurrentDateTime.Subtract(dtTpStartDate_OLDuser);

        //int TotalDaysPassed = diffdt.Days;

        //if (TotalDaysPassed < 90)
        //{
        //    dvTrialPeriodAlert.Visible = true;

        //    lblTrialPeriodText.Text = "You are using a TRIAL VERSION of Mobile web expiring in " + TotalDaysPassed.ToString() + " days.  Please purchase.";
        //}


        string tmpMobileNo = string.Empty;

        //... GET the trial period start date from Another Database after shiva completes the code... 
        DateTime UserRegDate = new DateTime();
        String UserType = string.Empty;
        ds = objMb.Retrieve_TrialPeriodInfo(vUserID, dtTP_StartDate);
        DataTable dtTrialPeriod = ds.Tables[0];

        foreach (DataRow tpRow in dtTrialPeriod.Rows)
        {
            UserRegDate = Convert.ToDateTime(tpRow["regdate"].ToString());
            UserType = tpRow["Usertype"].ToString();
            tmpMobileNo = tpRow["MobileNo"].ToString(); 
        }


        if (UserType == "OLD")
        {
            //..The Trial Period start from TPDate + 90 days..
            DateTime Dateof_TPExpiry = dtTP_StartDate.AddDays(30);
            diffdt = Dateof_TPExpiry.Subtract(dtCurrentDateTime);

            if (diffdt.Days > 0)
            {
                dvTrialPeriodAlert.Visible = true;
                lblTrialPeriodText.Text = "You are using a TRIAL VERSION of Mobile web expiring in " + diffdt.Days.ToString() + " days. ";
            }


        }
        else
        {
            //.. the Trial Preiod starts from RegDate + 90 days.. 
            DateTime Dateof_TPExpiry = UserRegDate.AddDays(30);
            diffdt = Dateof_TPExpiry.Subtract(dtCurrentDateTime);

            if (diffdt.Days > 0)
            {
                dvTrialPeriodAlert.Visible = true;
                lblTrialPeriodText.Text = "You are using a TRIAL VERSION of Mobile web expiring in " + diffdt.Days.ToString() + " days. ";
            }

        }


        int IsMobilePurchased = objMb.CheckMobileWebPurchase(tmpMobileNo);

        if (IsMobilePurchased == 1)
        {
            dvTrialPeriodAlert.Visible = false;
            lblTrialPeriodText.Text = "";
        }
        



    }
}

