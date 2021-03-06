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
using CMSv3.BAL;
using CMSv3.Entities;
using System.Threading;
using System.Globalization;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Configuration;

public partial class Ad_WelcomeDPE : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
//    SqlDataAdapter dbAdap; 
    string strSQL = string.Empty;
    DateTime tmpCurrDate = DateTime.Now;

    //SqlConnection IFM32_dbConn;
//    SqlCommand IFM32_dbCmd;
//    SqlDataReader IFM32_dbReader;
//    SqlDataAdapter IFM32_dbAdapter;

    DataSet ds;
    string tmpDomainType = string.Empty;
    string tmpSubDomainLink = string.Empty;
    string tmpOwnDomainName = string.Empty;
    string tmpSubDomainName = string.Empty;
    string tmpAnchorDomain = string.Empty;
    String tmpAdminLanguageCode = string.Empty; 

    int cntRows = 0;
    String StrPageFrom = string.Empty; 

    //DataSet ds;

    CMSv3.BAL.User objUser = new CMSv3.BAL.User(); 

//    SqlDataReader dbReader;
 //   DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

    

        HtmlGenericControl myDivLeftBar;
        myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

        myDivLeftBar.Style.Clear();
        myDivLeftBar.Style.Value = "width:0px;";


        HtmlGenericControl myDivRightBar;
        myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

        myDivRightBar.Style.Clear();
        myDivRightBar.Style.Value = " width: 96%; padding-left: 10px;";


        
     //1  ltrThisMonthVisits.Text = "Total Visits in <br/> " + DateTime.Now.ToString("Y");
     //1   ltrMw_thisMonthVisits.Text = "Total Visits in <br/> " + DateTime.Now.ToString("Y");
        
        if (!IsPostBack)
        {
            LoadWelcomePageDetails();
            LoadQuickLinks();
            RenderBarChartNEW("MONTHLY");
           // LoadSubDomainDetails();
          //  LoadMobileWebStats(); 

        }


        //LtrSessionTimeout.Text = Session.Timeout.ToString();

        //ltrActivatePinNo.Text = "Activated Pin No";
        //ltrLastLogin.Text = "Last Login";
       // LtrWelcomePageTitle.Text = "Welcome to the SMS Enterprenuer Business Network Platform";

    }


    protected void LoadQuickLinks()
    {


        DataSet dsImageInfo;
        dsImageInfo = objUser.WelcomePage_QuickLinks(Convert.ToInt32(Session["UserID"]));


        DataTable dtImages = dsImageInfo.Tables[0];


        DLImageGallery.DataSource = dtImages;
        DLImageGallery.DataBind();

    }

    protected void RenderBarChartNEW(string vBarType)
    {




        if (vBarType == "DAILY")
        {

            strSQL = "EXEC [usp_WebSts_DayWise_ByUserID1] " + Convert.ToInt32(Session["UserID"]) + "," + (tmpCurrDate.Month) + "," + tmpCurrDate.Year;
            //MyBarChart_daily.ChartTitle = "<b>Web Statistics for:-   " + DateTime.Now.ToString("Y") + "</b>";
            //MyBarChart_daily.UserWidth = 300;
        }
        else
        {
            strSQL = "EXEC [usp_WebSts_DayWise_ByUserID1] " + Convert.ToInt32(Session["UserID"]) + ",0,0";
            //MyBarChart_Monthly.ChartTitle = "<b> Monthly Web Statistics </b>";
            //MyBarChart_Monthly.UserWidth = 300;
        }



        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        // Declare our variables
        String[] sMonths = new String[31];
        Int32[] iMonthCount = new Int32[31];
//        int iYear;
//        int iMonth;
//        int iCount;
//        int iDay;
//       int i = 0;


        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {

               // Chart1.DataBindTable(dbReader, "LogMonth");

                Chart1.Series["Default"].Points.DataBindXY(dbReader, "LogMonth", dbReader, "LogCount");


                // Set series chart type
                Chart1.Series["Default"].ChartType = SeriesChartType.Column;

                // Set series point width
                Chart1.Series["Default"]["PointWidth"] = "0.6";

                // Show chart with right-angled axes
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = true;

                // Show columns as clustered
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = false;

                // Show X axis end labels
                Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = true;

                // Set rotational angles
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 30;

                // Set series visual attributes
                Chart1.Series["Default"].Color = Color.LightSeaGreen;
                Chart1.Series["Default"].BackSecondaryColor = Color.Green;
                Chart1.Series["Default"].BackGradientStyle = GradientStyle.DiagonalLeft;

                Chart1.Series["Default"].BorderColor = Color.Gray;
                Chart1.Series["Default"].BorderWidth = 1;
                Chart1.Series["Default"].BorderDashStyle = ChartDashStyle.Solid;

                Chart1.Series["Default"].ShadowOffset = 2;


                Chart1.Series["Default"].IsXValueIndexed = true;
                Chart1.Series["Default"].IsVisibleInLegend = false;
                Chart1.Series["Default"].IsValueShownAsLabel = true;
                Chart1.Series["Default"].LabelAngle = 90;
                Chart1.Series["Default"].LabelForeColor = Color.Black;
                

                


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



 

    


    protected void LoadWelcomePageDetails()
    {

        CMSv3.BAL.Gallery objBAL_Gallery = new CMSv3.BAL.Gallery();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        ds = objUser.WelcomePage_Details(Convert.ToInt32(Session["UserID"]));
        DataTable dtUserInfo = ds.Tables[0];

        if (dtUserInfo.Rows.Count > 0)
        {

            DataRow dbReader = dtUserInfo.Rows[0]; 

            //lblUserId.Text = dbReader["UserId"].ToString();
            lblLoginID.Text = dbReader["LoginID"].ToString();
            //DateTime tmpdate = Convert.ToDateTime(dbReader["CreatedDate"].ToString());
            //lblCreatedDate.Text = tmpdate.ToLongDateString().ToString();

            DateTime dtCreatedDate = Convert.ToDateTime(dbReader["CreatedDate"].ToString());
            lblCreatedDate.Text = String.Format("{0:MMM d, yyyy h:mm tt}", dtCreatedDate);

            //lblCreatedDate.Text = dbReader["CreatedDate"].ToString();

            // lblUserType.Text = dbReader["UserType"].ToString();
            lblMobileNo.Text = dbReader["HandPhone"].ToString();
            //lblActivatedPinNo.Text = dbReader["RegisteredPin"].ToString();


            //..rendering Domain Names. 
            tmpOwnDomainName = dbReader["OwnDomain"].ToString();
            tmpSubDomainName = dbReader["SubDomain"].ToString();
            tmpAnchorDomain = dbReader["AnchorDomain"].ToString();

           

            tmpAdminLanguageCode = dbReader["AdminLanguage"].ToString();

            String selectedLanguage = string.Empty;
            String mLangCulture = string.Empty;

            switch (tmpAdminLanguageCode)
            {
                case "1": mLangCulture = GlobalVar.Lang_English; break;
                case "2": mLangCulture = GlobalVar.Lang_BahasaMalay; break;
                case "3": mLangCulture = GlobalVar.Lang_SimplifedChinese; break;

            }


            Session["ADMdefLanguage"] = mLangCulture;
            //lblErrMessage.Text = "User Sucessfully Logged IN ";
            selectedLanguage = Session["ADMdefLanguage"].ToString();
           // Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
          //  Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);



            //...Own Domain 
            //if (tmpOwnDomainName != "")
            //{
            //    dvOwnDomain.Visible = true;
            //    tmpOwnDomainName = "www." + tmpOwnDomainName;
            //    lblOwnDomainName.Text = @"<a target='_blank' class='links_DomainName' href='http://" + tmpOwnDomainName + "'>" + tmpOwnDomainName + "</a>" + " <br />";

            //    DateTime dtExpiryDate = Convert.ToDateTime(dbReader["DomainExpiryDate"].ToString());
            //    lblOwnDomainExpiryDate.Text = String.Format("{0:MMM d, yyyy h:mm tt}", dtExpiryDate);
            //}
            //else
            //{
            //    dvOwnDomain.Visible = false;
            //}


            //.. SubDomain Name 1 
            

            //String UrlSubDomainName1 = string.Empty;

            //if (tmpAnchorDomain != "")
            //{
            //    UrlSubDomainName1 = tmpSubDomainName + "." + tmpAnchorDomain;
            //}
            //else
            //{
            //    UrlSubDomainName1 = tmpSubDomainName + "." + GlobalVar.GetAnchorDomainName;
            //}


            //lblSubDomainName1.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>" + UrlSubDomainName1 + "</a>" + " <br />";

            ImgContact.ImageUrl = dbReader["FullImgPath"].ToString();

            if ((Session["UserDomainType"] == null) || (Session["UserDomainType"].ToString() == ""))
            {
                Session["UserDomainType"] = dbReader["UserDomainType"].ToString();
            }

           // lblLastLogin.Text = "<b>" + dbReader["LastLogin"].ToString() + "</b>";

            DateTime dtLastLoggedIn = Convert.ToDateTime(dbReader["LastLogin"].ToString());
            lblLastLogin.Text = String.Format("{0:d MMM, yyyy h:mm tt}", dtLastLoggedIn);


        }

      //  strSQL = "EXEC Usp_CMS_GetUserDetailsByUserID " + Convert.ToInt32(Session["UserID"]);

      //  dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        

        ltrThisMonthVisits.Text = "Total Visits in " + DateTime.Now.ToString("Y");

        DataTable dtVisits = ds.Tables[1];

        if (dtVisits.Rows.Count > 0)
        {
            DataRow drow = dtVisits.Rows[0];

            lblThisMonthVisits.Text = drow["ThisMonthVisits"].ToString();
            lblTotalVisits.Text = drow["TotalVisits"].ToString();
             
        }

    }


   
    protected void rpFaqList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HiddenField objHidDomainName = (HiddenField)e.Item.FindControl("HidDomainName");
            Literal objLtrDomainName = (Literal)e.Item.FindControl("ltrDomainName");
            HtmlTableRow objtr = (HtmlTableRow)e.Item.FindControl("trDomainRow"); 

            if (cntRows < 20)
            {
                

                String tempLink = string.Empty;
                if (objLtrDomainName != null)
                {
                    tempLink = "http://" + tmpSubDomainName + "." + objLtrDomainName.Text;
                    objLtrDomainName.Text = "<a class='links_AnchorDomains' href='Ad_AnchorDomainsList.aspx'>" + tempLink + "</a>";
                }
            }
            else
            {
                objtr.Visible = false;
                objLtrDomainName.Text = "";
            }
            cntRows += 1; 

        }

        if (e.Item.ItemType == ListItemType.Footer)
        {
            HyperLink objHypMore = (HyperLink)e.Item.FindControl("HypLinkMore");

            if (objHypMore != null)
            {
                if(cntRows < 15)
                objHypMore.Visible = false; 
            }

        }

    }
}
