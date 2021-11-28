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



public partial class Admin_Ad_Welcome_ORG : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    SqlDataAdapter dbAdap; 
    string strSQL = string.Empty;
    DateTime tmpCurrDate = DateTime.Now;

    SqlConnection IFM32_dbConn;
    //SqlCommand IFM32_dbCmd;
    //SqlDataReader IFM32_dbReader;
    //SqlDataAdapter IFM32_dbAdapter;

    DataSet ds;
    string tmpDomainType = string.Empty;
    string tmpSubDomainLink = string.Empty;
    string tmpOwnDomainName = string.Empty;
    string tmpSubDomainName = string.Empty;
    int cntRows = 0; 

    //DataSet ds;

    CMSv3.BAL.User BALobjUser = new CMSv3.BAL.User();
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

        IFM32_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);

        //string mUserID = Session["UserID"].ToString();

        //CMSv3.Entities.User objUser = new CMSv3.Entities.User();

        //objUser = BALobjUser.GetUserDetailsByID(Convert.ToInt32(mUserID));

        //if (objUser != null)
        //{
        //    lblUserId.Text = Convert.ToString(objUser.UserId);
        //    lblLoginID.Text = objUser.LoginID;
        //    lblUserType.Text = objUser.UserType;
        //    lblCreatedDate.Text = Convert.ToString(objUser.CreatedDateTime);

            
        //}


        ltrThisMonthVisits.Text = "Total Visits in " + DateTime.Now.ToString("Y");
        
        if (!IsPostBack)
        {
            LoadWelcomePageDetails();
            LoadSubDomainDetails(); 

        }


        //LtrSessionTimeout.Text = Session.Timeout.ToString();

        //ltrActivatePinNo.Text = "Activated Pin No";
        //ltrLastLogin.Text = "Last Login";
        LtrWelcomePageTitle.Text = "Welcome to the SMS Enterprenuer Business Network Platform";

    }



    protected void LoadWelcomePageDetails()
    {

        strSQL = "EXEC Usp_CMS_GetUserDetailsByUserID " + Convert.ToInt32(Session["UserID"]);

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


                    //lblUserId.Text = dbReader["UserId"].ToString();
                    lblLoginID.Text = dbReader["LoginID"].ToString();
                    //DateTime tmpdate = Convert.ToDateTime(dbReader["CreatedDate"].ToString());
                    //lblCreatedDate.Text = tmpdate.ToLongDateString().ToString();
                    lblCreatedDate.Text = dbReader["CreatedDate"].ToString();

                    lblUserType.Text = dbReader["UserType"].ToString();
                    lblMobileNo.Text = dbReader["HandPhone"].ToString();
                    lblActivatedPinNo.Text = dbReader["RegisteredPin"].ToString();


                    //..rendering Domain Names. 
                    tmpOwnDomainName = dbReader["OwnDomain"].ToString();
                    tmpSubDomainName = dbReader["SubDomain"].ToString();

                   
                    
                   

                    //...Own Domain 
                    if (tmpOwnDomainName != "")
                    {
                        dvOwnDomain.Visible = true;
                        tmpOwnDomainName = "www." + tmpOwnDomainName;
                        lblOwnDomainName.Text = @"<a target='_blank' class='links_DomainName' href='http://" + tmpOwnDomainName + "'>" + tmpOwnDomainName + "</a>" + " <br />";
                    }
                    else
                    {
                        dvOwnDomain.Visible = false;
                    }

                   
                    //.. SubDomain Name 1 
                    String UrlSubDomainName1 = tmpSubDomainName + "." + GlobalVar.GetAnchorDomainName;
                    lblSubDomainName1.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>" + UrlSubDomainName1 + "</a>" + " <br />";

              

                    ////.. SubDomain Name 2 
                    //if (Session["MobileLoginID"] != null)
                    //{
                    //    string UrlSubDomainName2 = Session["MobileLoginID"].ToString() + "." + GlobalVar.GetAnchorDomainName;
                    //    lblSubDomainName2.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>";
                    //}
                    //else
                    //{
                    //    lblSubDomainName2.Visible = false;
                    //}



                    //lblOwnDomainName.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>" + " <br />";
                    //lblSubDomain1.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>" + UrlSubDomainName1 + "</a>" + " <br />";
                    //lblSubDomain2.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName2 + "'>" + UrlSubDomainName2 + "</a>";
                    
                    //...................................


                    ImgContact.ImageUrl = dbReader["FullImgPath"].ToString();

                    //DateTime tmpLastLogin = Convert.ToDateTime(dbReader["LastLogin"].ToString());
                    //lblLastLogin.Text = "You have last logged in on <b>" + tmpLastLogin.ToLongDateString().ToString() + "</b> at <b>" + tmpLastLogin.ToShortTimeString() + "</b";
                    lblLastLogin.Text = "You have last logged in on <b>" + dbReader["LastLogin"].ToString()  + "</b";

                    if((Session["UserDomainType"] == null) || (Session["UserDomainType"].ToString() == ""))
                    {
                        Session["UserDomainType"] = dbReader["UserDomainType"].ToString();
                    }

                }

            }

            dbReader.Close();

            string Tmp_ThisMonthVisits = string.Empty; ;
            string Tmp_TotalVisits = string.Empty;

            strSQL = "EXEC [usp_WebSts_MonthWise_ByUserID] " + Convert.ToInt32(Session["UserID"]);
            //strSQL = "EXEC [usp_WebSts_MonthWise_ByUserID] " + Convert.ToInt32(Session["UserID"]);
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    Tmp_ThisMonthVisits = dbReader["ThisMonthVisits"].ToString();
                    Tmp_TotalVisits = dbReader["TotalVisits"].ToString();
                    break;
                }

                lblThisMonthVisits.Text = Tmp_ThisMonthVisits;
                lblTotalVisits.Text = Tmp_TotalVisits;
            }


            //for the daily and monthly charts..

            RenderBarChart(MyBarChart_daily, "DAILY");
            RenderBarChart(MyBarChart_Monthly, "MONTHLY");


                       
        }
        catch (Exception ex)
        {
            //throw ex;
            Response.Write(ex.Message);
        }
        finally
        {
            dbConn.Close();
        }


    }


    protected void LoadSubDomainDetails()
    {



        String tmpUserMobileNo = string.Empty;
        String tmpUserAccountType = string.Empty;

        StringBuilder sb = new StringBuilder();


        try
        {
            dbConn.Open();
            //strSQL = "EXEC [usp_Retreive_DomainDetails] " + Convert.ToInt32(Session["UserID"]);

            //dbCmd = new SqlCommand(strSQL, dbConn);
            //dbReader = dbCmd.ExecuteReader();

            //if (dbReader.HasRows)
            //{
            //    while (dbReader.Read())
            //    {

            //        tmpDomainType = dbReader["UserDomainType"].ToString().Trim();
            //        tmpSubDomainLink = dbReader["SubDomain"].ToString();
            //        //tmpSubDomainLink = dbReader["SubDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;
            //    }
            //}



            //IFM32_dbConn.Open();
            //strSQL = "EXEC [USP_Retrieve_AnchorDomains] 1";

            //IFM32_dbCmd = new SqlCommand(strSQL, IFM32_dbConn);


            //IFM32_dbCmd = new SqlCommand("[USP_Retrieve_AnchorDomains]", IFM32_dbConn);
            //IFM32_dbCmd.CommandType = CommandType.StoredProcedure;
            //IFM32_dbCmd.Parameters.Add("@vFlag", SqlDbType.Int).Value = 1;

            //IFM32_dbAdapter = new SqlDataAdapter(IFM32_dbCmd);
            

            //IFM32_dbAdapter.Fill(ds);

            ds = new DataSet();

            dbCmd = new SqlCommand("[USP_Retrieve_AnchorDomains]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vDisplay", SqlDbType.Int).Value = 1;

            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);


            DataView dv = ds.Tables[0].DefaultView; 
            DataTable dt = ds.Tables[0];

            rpFaqList.DataSource = ds;
            rpFaqList.DataBind();

            //int cn = ds.Tables[0].Rows.Count;

            //IFM32_dbConn.Close();
            //IFM32_dbReader.Close(); 

            //..Show  SubDomains with AnchorDomains... 
            StringBuilder sbDomains = new StringBuilder();
            
            int TmpAncCount = 0; 
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TmpAncCount += 1; 

                    if(TmpAncCount < 5) 
                    {
                        String tmpAncDomainStr = tmpSubDomainName + "." + dr["AnchorDomain"].ToString();
                        //sbDomains.AppendLine(dr["AnchorDomain"].ToString());
                        sbDomains.AppendLine(@"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + tmpAncDomainStr + "'>" + tmpAncDomainStr + "</a>");
                    }
                }

                sbDomains.AppendLine(@"<a class='links_FuncLinks' href='Ad_AnchorDomainsList.aspx'> more...</a>");

            }
            lblSubDomainName2.Text = sbDomains.ToString();                 


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

    protected void RenderBarChart(SuperAdmin_MyBarChart vBarChart, string vBarType)
    {
        
    
         if (vBarType == "DAILY")
        {

            strSQL = "EXEC [usp_WebSts_DayWise_ByUserID] " + Convert.ToInt32(Session["UserID"]) + "," + (tmpCurrDate.Month) + "," + tmpCurrDate.Year;
            //strSQL = "EXEC [usp_WebSts_DayWise_ByUserID] " + Convert.ToInt32(Session["UserID"]) + "," + (tmpCurrDate.Month) + "," + tmpCurrDate.Year;
            MyBarChart_daily.ChartTitle = "<b>Web Statistics for:-   " + DateTime.Now.ToString("Y") + "</b>";
            MyBarChart_daily.UserWidth = 400;
        }
        else
        {
            strSQL = "EXEC [usp_WebSts_DayWise_ByUserID] " + Convert.ToInt32(Session["UserID"]) + ",0,0";
            //strSQL = "EXEC [usp_WebSts_DayWise_ByUserID] " + Convert.ToInt32(Session["UserID"]) + ",0,0";
            MyBarChart_Monthly.ChartTitle = "<b> Monthly Web Statistics </b>";
            MyBarChart_Monthly.UserWidth = 400;
        }



         dbConn = new SqlConnection(GlobalVar.GetDbConnString);

         // Declare our variables
         String[] sMonths = new String[31];
         Int32[] iMonthCount = new Int32[31];
         int iYear;
         int iMonth;
         int iCount;
         int iDay;
         int i = 0;


         try
         {
             dbConn.Open();

             dbCmd = new SqlCommand(strSQL, dbConn);
             dbReader = dbCmd.ExecuteReader();

             if (dbReader.HasRows)
             {
                 while (dbReader.Read())
                 {

                     iYear = Convert.ToInt32(dbReader["Year"].ToString());
                     iMonth = Convert.ToInt32(dbReader["Month"].ToString());
                     iCount = Convert.ToInt32(dbReader["LogCount"].ToString());

                     if (vBarType == "DAILY")
                     {
                         
                         iDay = Convert.ToInt32(dbReader["Day"].ToString());
                         sMonths[i] = iDay.ToString() + "," + CommonFunctions.GetMonthName(iMonth, true);
                     }
                     else
                     {
                         sMonths[i] = CommonFunctions.GetMonthName(iMonth, true) + ", " + iYear.ToString();
                     }


                     iMonthCount[i] = iCount;
                     i++;

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

        

         // Set our axis values
         vBarChart.YAxisValues = iMonthCount;

         // Set our axis strings
         vBarChart.YAxisItems = sMonths;

         // Provide a title
         //MyBarChart1.ChartTitle = "<b>Web Statistics for:-   " + DateTime.Now.ToString("Y") + "</b>";

         // Provide an title for the X-Axis
        // vBarChart.XAxisTitle = "(No. of Times Logged in Each Day.)";   


        

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
