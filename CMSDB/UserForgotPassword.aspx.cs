using System;
using System.Configuration; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CMSv3.BAL;


public partial class UserForgotPassword : UserWeb 
{

    CMSv3.BAL.FAQ objBL_faq = new CMSv3.BAL.FAQ();
    //DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        #region // rendergin top left panel 
        //HtmlGenericControl myDivObject;
        //myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        ////myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
        //myDivObject.InnerHtml = "<img alt='imbnLeftimg' src='Images/faq_head.jpg' />";


            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

            if (myDivObject != null)
            {
                //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>");
                sb.Append("<img src='Images/table_top_Leftarc.gif' />");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<img alt='imbnLeftimg' src='Images/faq_head.jpg' />");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                myDivObject.InnerHtml = sb.ToString();
            }
        
        #endregion 

        // Page coming from 

            if(Request.QueryString["fp"] != null)
                ViewState["fpFrom"] = Request.QueryString["fp"].ToString(); 
            else
                ViewState["fpFrom"] = string.Empty;
        
            ltrforgotPassword.Text = Resources.LangResources.ForgotPassword;
        LtrPasswordRetreival.Text = "Retreive your password";
        
  
    }


   

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        SqlConnection dbConn;
        SqlCommand dbCmd;
        SqlDataReader dbReader;

        string User_EmailAddress= string.Empty;
        string User_FullName = string.Empty;
        string User_LoginID = string.Empty;
        string User_MobileLoginID = string.Empty;
        string User_LoginPassword = string.Empty;
        string UserMainPassword = string.Empty;
        string UserMainEmailAddress = string.Empty;



        string tmpEmailFrom = string.Empty;
        string tmpEmailBody = string.Empty;
        string tmpEmailSubject = string.Empty;
        

        string strSQL = string.Empty;
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);


        

        try
        {
            //strSQL = "Select UserID from tblUsers where LoginID = '" + txtLoginID.Text + "'";

            strSQL = "EXEC [usp_Password_Retrieve_byLoginID] '" + txtLoginID.Text.Trim() + "'";
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            //string tmpUserID = Convert.ToString(dbCmd.ExecuteScalar());

            //if (tmpUserID != "")
            if (dbReader.HasRows)
            {
                //if exists then retrieve Email Address and FullName

                //strSQL = "select LoginId,LoginPassword, Email, FullName from tblUserDetails UD " +
                //          " inner join tblUsers U ON U.UserId = UD.UserID " +
                //          " where UD.UserID = " + Convert.ToInt32(tmpUserID);

                //dbCmd = new SqlCommand(strSQL, dbConn);
                //dbReader = dbCmd.ExecuteReader();

                //if (dbReader.HasRows)
                //{
                    while (dbReader.Read())
                    {
                        User_EmailAddress = dbReader["Email"].ToString();
                        User_FullName = dbReader["FullName"].ToString();
                        User_LoginID = dbReader["LoginID"].ToString();
                        User_MobileLoginID = dbReader["MobileLoginId"].ToString();
                        User_LoginPassword = dbReader["LoginPassword"].ToString();
                        //UserMainPassword = fnGetPassword(User_MobileLoginID);
                        if (ViewState["fpFrom"].ToString() == "SMS")
                        {
                            fnGetPassword_SMSsystem(User_MobileLoginID, ref UserMainPassword, ref UserMainEmailAddress);
                        }
                        else
                        {
                            fnGetPassword_BIZLogin(User_MobileLoginID, ref UserMainPassword, ref UserMainEmailAddress);
                        }
 
                    }


                    if ((UserMainEmailAddress != "") && (UserMainPassword != ""))
                    {

                        //Send email
                        tmpEmailSubject = "Password details : " + GlobalVar.GetAnchorDomainName;
                        tmpEmailFrom = "Support@" + GlobalVar.GetAnchorDomainName;
                        tmpEmailBody = "Your login password details as follows" +
                                       "<br/><br/>" +
                                       "-------------------------------------<br/>" +
                                       "Login ID : <b>" + User_MobileLoginID + "</b> <br/>" +
                                       "Password : <b>" + UserMainPassword + "</b> <br/>" +
                                       "-------------------------------------<br/>" +
                                       "<br/><br/>";


                        CommonFunctions.GenericSendEmail(UserMainEmailAddress, tmpEmailFrom, tmpEmailBody, tmpEmailSubject, User_FullName, "", "");

                        tblMessageBar.Visible = true;
                        lblErrMessage.Text = "Your password details have been mailed to you";
                        lblErrMessage.CssClass = "font_12Msg_Success";
                        MessageImage.Src = "~/Images/inf_Sucess.gif";
                    }
                    else
                    {
                        lblErrMessage.Text = "No Registered Email Address exists for this LoginID. Please contact Administrator.";
                        lblErrMessage.CssClass = "font_12Msg_Error";
                        tblMessageBar.Visible = true;
                        tblMessageBar.Attributes.Add("style", "margin: 5px; padding: 5px; display:block; background-color:#FEFFDE; border: solid 3px #FF4800; width:99%;"); 
                        MessageImage.Src = "~/Images/inf_Error.gif";
                    }

               // }

            }
            else
            {
                //entered login id does not exist.

                lblErrMessage.Text = "Entered Login ID does not exists. Please Check";
                lblErrMessage.CssClass = "font_12Msg_Error";
                tblMessageBar.Visible = true;
                tblMessageBar.Attributes.Add("style", "margin: 5px; padding: 5px; display:block; background-color:#FEFFDE; border: solid 3px #FF4800; width:99%;"); 
                MessageImage.Src = "~/Images/inf_Error.gif";

            }


        }
        catch (Exception ex)
        {
            throw ex;
            // Response.Redirect("ErrorGenericPage.aspx");
        }
        finally
        {
            dbConn.Close();
        }



    }


    public void fnGetPassword_BIZLogin(string vMobileLoginId, ref string vUserPassword, ref string vUserEmailAddress)
    {

        CMSv3.BAL.MalaysiaSMS objMAS = new CMSv3.BAL.MalaysiaSMS();

        DataSet dsCheck;
        dsCheck = objMAS.ValidateUserLoing_1MAS_1Sing_ByMobileLoginID(vMobileLoginId);

        if (dsCheck.Tables[0].Rows.Count > 0)
        {

            DataRow UserStatus_Row = dsCheck.Tables[0].Rows[0];

            string tmpMuserName = UserStatus_Row["Login_ID"].ToString();
            string tmpMPassword = UserStatus_Row["Password"].ToString();
            string tmpMemail = UserStatus_Row["Email"].ToString();

            vUserPassword = tmpMPassword;
            vUserEmailAddress = tmpMemail; 
        }
        else
        {
            vUserPassword = "";
            vUserEmailAddress = ""; 
        }



    }

    public void fnGetPassword_SMSsystem(string vMobileLoginId, ref string vUserPassword, ref string vUserEmailAddress)
    {

        SqlConnection ABEST_dbConn;
        SqlCommand ABEST_dbCmd;

        string ABEST_dbString = ConfigurationManager.AppSettings["ABESTdb"].ToString();
        ABEST_dbConn = new SqlConnection(ABEST_dbString);


        try
        {
            if (ABEST_dbConn.State == ConnectionState.Closed)
                ABEST_dbConn.Open();

            ABEST_dbCmd = new SqlCommand("[USP_RetreivePwd_ByMobileLoginID]", ABEST_dbConn);
            ABEST_dbCmd.CommandType = CommandType.StoredProcedure;
            ABEST_dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = "BK" + vMobileLoginId;

            DataSet dsCheck;
            SqlDataAdapter dbAdap; 

            dbAdap = new SqlDataAdapter(ABEST_dbCmd);
            dsCheck = new DataSet();
            dbAdap.Fill(dsCheck);


            //dsCheck = objMAS.ValidateUserLoing_1MAS_1Sing_ByMobileLoginID(vMobileLoginId);

            if (dsCheck.Tables[0].Rows.Count > 0)
            {

                DataRow UserStatus_Row = dsCheck.Tables[0].Rows[0];

                string tmpMuserName = UserStatus_Row["Login"].ToString();
                string tmpMPassword = UserStatus_Row["MPassword"].ToString();
                string tmpMemail = UserStatus_Row["Email"].ToString();

                vUserPassword = tmpMPassword;
                vUserEmailAddress = tmpMemail;
            }
            else
            {
                vUserPassword = "";
                vUserEmailAddress = "";
            }

          


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ABEST_dbConn.Close();
        }


       



    }
}



