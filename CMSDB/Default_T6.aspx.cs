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

public partial class default_T6 : System.Web.UI.Page
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    String strSQL = string.Empty;
    

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


//        string MemLoginTable = @"
//
//        <table border='0' cellpadding='0' cellspacing='0' width='100%' class='bkgMemLogin'>
//                    <tr>
//                        <td style='height:30px;' width='20px' align='left' valign='top'>
//                        <img alt='topleftarc' src='Images/table_top_Leftarc.gif' 
//                        style='width: 10px; height: 20px' />
//                        </td>
//                        <td class='font_Title1'>Members Login</td>
//                        <td  width='20px'>&nbsp;</td>
//                    </tr>
//                    
//                    <tr style='height:20px; vertical-align:baseline;'>
//                    <td>&nbsp;</td>
//                    <td class='font_12Normal'>Login Id</td>
//                    <td>&nbsp;</td>
//                    </tr>
//                    
//                      <tr>
//                    <td>&nbsp;</td>
//                    <td>
//                        <asp:TextBox ID='txtLoginID' MaxLength='20'  CssClass='stdTextField' runat='server'></asp:TextBox>
//                        <asp:RequiredFieldValidator ID='RequiredFieldValidator1' Display='Dynamic' ControlToValidate='txtLoginID' runat='server' ErrorMessage='<br/>Enter Login Name.' CssClass='font_11Msg_Error'></asp:RequiredFieldValidator>
//                          </td>
//                    <td>&nbsp;</td>
//                    </tr>
//                    
//                      <tr  style='height:20px; vertical-align:baseline;'>
//                    <td>&nbsp;</td>
//                    <td  class='font_12Normal'>Password</td>
//                    <td>&nbsp;</td>
//                    </tr>
//                    
//                      <tr>
//                    <td>&nbsp;</td>
//                    <td>
//                        <asp:TextBox ID='txtPassword' CssClass='stdTextField' runat='server' 
//                            style='margin-bottom: 0px' TextMode='Password'></asp:TextBox>
//                            <asp:RequiredFieldValidator ID='RequiredFieldValidator2' Display='Dynamic' ControlToValidate='txtPassword' runat='server' ErrorMessage='<br/>Enter Password.' CssClass='font_11Msg_Error'></asp:RequiredFieldValidator>
//                          </td>
//                    <td>&nbsp;</td>
//                    </tr>
//                    <tr style='height:5px;'>
//                    <td></td>
//                    <td></td>
//                    <td></td>
//                    </tr>
//                    
//                      <tr>
//                    <td>&nbsp;</td>
//                    <td align='center'>
//                        <asp:Button CssClass='stdButtonLogin' ID='btnSignIn' runat='server' 
//                            Height='26px' Text='Sign In' 
//                            Width='56px' onclick='btnSignIn_Click' />
//                          </td>
//                    <td>&nbsp;</td>
//                    </tr>
//                    
//                      <tr>
//                    <td>&nbsp;</td>
//                    <td align='right'>
//                    <a href='UserForgotPassword.aspx' class='links_ForgotPwd'>Forgot password?</a>
//                        </td>
//                    <td>&nbsp;</td>
//                    </tr>
//                    
//                    <tr>
//                    <td>&nbsp;</td>
//                    <td class='font_11Msg_Error'>
//                        <asp:Literal ID='LtrErrMessage' Text='' runat='server'></asp:Literal>
//                        </td>
//                    <td>&nbsp;</td>
//                    </tr>
//                    
//                      </table>";



        //myDivObject.InnerHtml = MemLoginTable;

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
               // Session["ClientID"] = GetUserIdfromURL();
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
                //string strCompanyName = "<font class='HomePageHeaderFont'>" + (string)GetGlobalResourceObject("LangResources", "Welcometo") + " " + HpgRow["CompanyName"].ToString() + "</font>";
              // dvCompanyName.InnerText = (string)GetGlobalResourceObject("LangResources", "Welcometo") + " " + HpgRow["CompanyName"].ToString();
                //dvCompanyName.InnerText = strCompanyName;


                //dvCopyRights.InnerText = HpgRow["CopyRightsInfo"].ToString();
                Session["CopyRightsInfo"] = HpgRow["CopyRightsInfo"].ToString();
                //objClientData.CopyRightsInfo = HpgRow["CopyRightsInfo"].ToString();


                //... Company Name...
                //if (HpgRow["CompanyName"].ToString().Trim() != "")
                //    ltrCompanyName.Text = "&nbsp;<b>" + HpgRow["CompanyName"].ToString() + "</b>";


            }

            #endregion

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

            LoadData(vLangType, qButtonNo);
             
           //if((Session["PasswordStatus"] == null) || (Session["PasswordStatus"] != "EXPIRED") || (Session["PasswordStatus"] != "NOTMATCHED"))
           // Response.Redirect("UsersOwnPage.aspx?ButtonNo=1");
            

            // Session["ClientData"] = objClientData;


            // -- load welcome page data

            //lblHomePageContent.Text = HpgRow["CompanyInfo"].ToString().Replace(Environment.NewLine, "<br/>");

            //foreach (DataRow wpRow in tbWelComepage.Rows)
            //{
            //    lblHomePageContent.Text = wpRow["Description"].ToString().Replace(Environment.NewLine, "<br/>");
            //}


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
                sbMenu.Replace("links_MainMenuBar", "links_MainMenuBar3");
            }

            //dvTopMenu.InnerHtml = "";
            //dvTopMenu.InnerHtml = sbMenu.ToString();


            // DownMenu.InnerHtml = sbMenu.ToString();


            #endregion

          

           

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



            //dbConn.Open();
            //dbCmd = new SqlCommand(strSQL, dbConn);
            //dbReader = dbCmd.ExecuteReader();

            //if (dbReader.HasRows)
            //{
            //    while (dbReader.Read())
            //    {
            //        bool tmpActive = Convert.ToBoolean(dbReader["isActive"].ToString());
            //        if (tmpActive)
            //        {

            //            Session["UserID"] = dbReader["UserID"].ToString();
            //            Session["LoginID"] = dbReader["LoginID"].ToString();
            //            Session["UserDomainType"] = dbReader["UserDomainType"].ToString();
            //            //Session["defLanguage"] = ddlLang.SelectedValue;
            //            //lblErrMessage.Text = "User Sucessfully Logged IN ";
            //            //selectedLanguage = Session["defLanguage"].ToString();
            //            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            //            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
            //            LoginStatus = true;
            //        }
            //        else
            //        {
            //            objLtrErrMessage.Text = "Account Suspended ..";
            //            LoginStatus = false;
            //        }
            //    }
            //}
            //else
            //{
            //    objLtrErrMessage.Text = "Invalid Password ..";
            //    LoginStatus = false;
            //}



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
            tmpUserContent = "<br> No Content has been added yet. To Create, click on the Add the content";
        }

        dbConn.Close();

        // txtIncPlanContent.Value = tmpUserContent;
        lblUserContent.Text = tmpUserContent;



    }

}
