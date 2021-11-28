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

public partial class dt5A : System.Web.UI.Page
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    String strSQL = string.Empty;
    string FirstButtonURL = string.Empty;
    

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


//       

        #endregion



        DataSet MainDS;
        DataTable tbMenu;
        //DataTable tbNews;
        //DataTable tbHomePgContent;
        //DataTable tbEvents;
        //DataTable tbTestimonials;
        //DataTable tbFollowus;
        //DataTable tbWelComepage;
        //DataTable tbContactUs;


        HtmlGenericControl dvLogoImage = (HtmlGenericControl)Master.FindControl("dvLogoImage");
        HtmlGenericControl dvBannerImg = (HtmlGenericControl)Master.FindControl("dvBannerImg");
        HtmlGenericControl dvCopyRights = (HtmlGenericControl)Master.FindControl("dvCopyRights");
        HtmlGenericControl dvTopMenu = (HtmlGenericControl)Master.FindControl("dvTopMenu");
        //HtmlTableRow trLogin = (HtmlTableRow)Master.FindControl("trLoginRow");

        //HtmlTable tbl_Login = (HtmlTable)Master.FindControl("tblLoginArea");
        
      

        //trLogin.Visible = false;
       
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
           

           


            int qButtonNo = 1; 
            int vLangType = 1;

            if (Request.QueryString["LgType"] != null)
            {
                vLangType = Convert.ToUInt16(Request.QueryString["LgType"]);
            }
            if (Request.QueryString["ButtonNo"] != null)
            {
                qButtonNo = Convert.ToInt16(Request.QueryString["ButtonNo"]);
            }



            MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));
            tbMenu = MainDS.Tables[0];     

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

            int MenuButtonCount = tbMenu.Rows.Count;
            int FirstButtonIndex = 999;



            foreach (DataRow mRow in tbMenu.Rows)
            {

                int tmpPriority = Convert.ToInt16(mRow["Priority"].ToString());

                if (FirstButtonIndex > tmpPriority)
                {
                    FirstButtonIndex = tmpPriority;
                    FirstButtonURL = mRow["LinkURL"].ToString();
                    ViewState["FirstButtonURL"] = FirstButtonURL;
                }

            }


            #endregion

            LoadData(vLangType, qButtonNo);
             
           

        }
    }




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

    protected void btnSignIn_Click(object sender, EventArgs e)
    {

        SqlConnection dbConn;
        //SqlCommand dbCmd;
        //SqlDataReader dbReader;
        string strSQL = string.Empty;
        DataSet dsCheck;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        TextBox objtxtLoginID = (TextBox)this.Master.FindControl("txtLoginID");
        TextBox objtxtPassword = (TextBox)this.Master.FindControl("txtPassword");
        Literal objLtrErrMessage = (Literal)this.Master.FindControl("LtrErrMessage");

        bool LoginStatus = false;

        //string selectedLanguage;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        string mUserName = objtxtLoginID.Text;
        string mPassword = objtxtPassword.Text;

        try
        {
            //strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";

            dsCheck = objUser.CheckUser_LoginStatus(CommonFunctions.SafeSql(mUserName), CommonFunctions.SafeSql(mPassword));

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
                objLtrErrMessage.Text = "Account Expired ...";
                LoginStatus = false;
            }
            else
            {
                objLtrErrMessage.Text = "Invalid Password ...";
                CommonFunctions.AlertMessageAndRedirect("Invalid Password...", "Default.aspx");
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

        if (LoginStatus)
        {
            CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

            int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));

            Response.Redirect("~/Admin/Ad_Welcome.aspx");
            //Server.Transfer("~/Admin/Welcome.aspx");

        }
        else
        {

        }

    }


    protected void LoadData(int vLangType, int vButtonNo)
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        String tmpUserContent = string.Empty;

        // strSQL = "Select top 1 PlanID, PlanData,UserID from tblIncentivePlan where UserID = " + Convert.ToInt32(Session["UserID"]) + " and LgType = " + vLangType + " order by CreatedDate desc";
        // strSQL = "select userLinkID,UserLinkName,UserPageContent,Active,UserID,LgType from tblTopMenuLinkByUser where LgType = " + vLangType +
        // " and deleted = 0 and UserId = " + Convert.ToInt32(Session["ClientID"]) +  " and ButtonNo =" + vButtonNo + " order by CreatedDate desc";

        //EXEC [usp_UserOwnPage_Retrieve_ByUserID] 115 , 1  

        strSQL = "EXEC [usp_UserOwnPage_Retrieve_ByUserID] " + Convert.ToInt32(Session["ClientID"]) + "," + vButtonNo;

        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpUserContent = dbReader["UserPageContent"].ToString();
                //hidIncPlanID.Value = dbReader["PlanID"].ToString();
            }

        }
        else
        {

            if (FirstButtonURL != "")
                Response.Redirect(FirstButtonURL); 

            tmpUserContent = "<br> No Content has been added yet. To Create, click on the Add the content";
        }

        dbConn.Close();

        // txtIncPlanContent.Value = tmpUserContent;
        lblUserContent.Text = tmpUserContent;



    }

}
