using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Xml;
using CMSv3.Entities;
using System.Text.RegularExpressions;
using System.Linq;

/// <summary>
/// Summary description for CommonFunctions
/// </summary>
public class CommonFunctions
{
    public CommonFunctions()
    {
        //
        // TODO: Add constructor logic here
        //

        
    }

    
   
    public static void InitialiseGridViewPagerRowWithImages(GridViewRow gridViewRow, GridView objGridView)
    {
        if (gridViewRow != null)
        {
            // Check the page index so that we can :
            //  1. Disable the 'First' and 'Previous' paging image buttons if paging index is at 0
            //  2. Disable the 'Last' and 'Next' paging image buttons if paging index is at the end
            //  3. Enable all image buttons if the conditions of 1 and 2 are not satisfied
            //Button firstbutton = gridViewRow.FindControl("btnFirst") as Button;
            //Button Prevbutton = gridViewRow.FindControl("btnPrevious") as Button;
            //Button Nextbutton = gridViewRow.FindControl("btnNext") as Button;
            //Button Lastbutton = gridViewRow.FindControl("btnLast") as Button;
            
            ImageButton firstbutton = gridViewRow.FindControl("btnFirst") as ImageButton;
            ImageButton Prevbutton = gridViewRow.FindControl("btnPrevious") as ImageButton;
            ImageButton Nextbutton = gridViewRow.FindControl("btnNext") as ImageButton;
            ImageButton Lastbutton = gridViewRow.FindControl("btnLast") as ImageButton;
            



            if (objGridView.PageIndex == 0)
            {
                // Disable 'First' and 'Previous' Paging image buttons

                if (firstbutton != null && Prevbutton != null)
                {
                    firstbutton.Enabled = false;
                    Prevbutton.Enabled = false;
                    firstbutton.Visible = false;
                    Prevbutton.Visible = false;
                }
            }
            else if ((objGridView.PageIndex + 1) == objGridView.PageCount)
            {
                // Disable 'Last' and 'Next' Paging image buttons

                if (Lastbutton != null && Nextbutton != null)
                {
                    Lastbutton.Enabled = false;
                    Nextbutton.Enabled = false;
                    Lastbutton.Visible = false;
                    Nextbutton.Visible = false;
                }
            }
            else
            {
                // Enable the Paging image buttons

                if (firstbutton != null && Lastbutton != null &&
                     Prevbutton != null && Nextbutton != null)
                {
                    firstbutton.Enabled = true;
                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Prevbutton.Enabled = true;

                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Lastbutton.Visible = true;
                    Nextbutton.Visible = true;

                }
            }

            // Get the DropDownList found as part of the Pager Row. 
            // One can then initialise the DropDownList to contain
            // the appropriate page settings. Eg. Page Number and number of Pages

            DropDownList pageNumberDropDownList = gridViewRow.FindControl("PageNumberDropDownList") as DropDownList;
            Label pageCountLabel = gridViewRow.FindControl("PageCountLabel") as Label;
            if (pageNumberDropDownList != null && pageCountLabel != null)
            {
                for (int i = 0; i < objGridView.PageCount; i++)
                {
                    int page = i + 1;
                    pageNumberDropDownList.Items.Add(new ListItem(page.ToString(), i.ToString()));
                }
                pageNumberDropDownList.SelectedIndex = objGridView.PageIndex;
                pageCountLabel.Text = objGridView.PageCount.ToString();
            }
        }
    }


    public static void InitialiseGridViewPagerWithRowCountImages(int PageSize, int TotalRecord, int PageIndex, GridViewRow gridViewRow, GridView objGridView)
    {
        int PageCount = TotalRecord / PageSize;
        if (TotalRecord > PageSize)
        {
            if (TotalRecord % PageSize > 0)
                PageCount++;
        }

        if (PageCount > 1)
        {
            // Check the page index so that we can :
            //  1. Disable the 'First' and 'Previous' paging image buttons if paging index is at 0
            //  2. Disable the 'Last' and 'Next' paging image buttons if paging index is at the end
            //  3. Enable all image buttons if the conditions of 1 and 2 are not satisfied
            //Button firstbutton = gridViewRow.FindControl("btnFirst") as Button;
            //Button Prevbutton = gridViewRow.FindControl("btnPrevious") as Button;
            //Button Nextbutton = gridViewRow.FindControl("btnNext") as Button;
            //Button Lastbutton = gridViewRow.FindControl("btnLast") as Button;
            objGridView.BottomPagerRow.Visible = true;


            ImageButton firstbutton = gridViewRow.FindControl("btnFirst") as ImageButton;
            ImageButton Prevbutton = gridViewRow.FindControl("btnPrevious") as ImageButton;
            ImageButton Nextbutton = gridViewRow.FindControl("btnNext") as ImageButton;
            ImageButton Lastbutton = gridViewRow.FindControl("btnLast") as ImageButton;

            if (PageIndex == 1)
            {
                // Disable 'First' and 'Previous' Paging image buttons

                if (firstbutton != null && Prevbutton != null)
                {
                    firstbutton.Enabled = false;
                    Prevbutton.Enabled = false;
                    firstbutton.Visible = false;
                    Prevbutton.Visible = false;
                }
            }
            else if (PageIndex == PageCount)
            {
                // Disable 'Last' and 'Next' Paging image buttons

                if (Lastbutton != null && Nextbutton != null)
                {
                    Lastbutton.Enabled = false;
                    Nextbutton.Enabled = false;
                    Lastbutton.Visible = false;
                    Nextbutton.Visible = false;
                }
            }
            else
            {
                // Enable the Paging image buttons

                if (firstbutton != null && Lastbutton != null &&
                     Prevbutton != null && Nextbutton != null)
                {
                    firstbutton.Enabled = true;
                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Prevbutton.Enabled = true;

                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Lastbutton.Visible = true;
                    Nextbutton.Visible = true;

                }
            }
            // Get the DropDownList found as part of the Pager Row. 
            // One can then initialise the DropDownList to contain
            // the appropriate page settings. Eg. Page Number and number of Pages


            DropDownList pageNumberDropDownList = gridViewRow.FindControl("PageNumberDropDownList") as DropDownList;
            Label pageCountLabel = gridViewRow.FindControl("PageCountLabel") as Label;
            if (pageNumberDropDownList != null && pageCountLabel != null)
            {
                for (int i = 1; i <= PageCount; i++)
                {
                    pageNumberDropDownList.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                pageNumberDropDownList.SelectedValue = PageIndex.ToString();
                pageCountLabel.Text = PageCount.ToString();
            }
        }
    }


    public static void InitialiseGridViewPagerRow(GridViewRow gridViewRow, GridView objGridView)
    {
        if (gridViewRow != null)
        {
            // Check the page index so that we can :
            //  1. Disable the 'First' and 'Previous' paging image buttons if paging index is at 0
            //  2. Disable the 'Last' and 'Next' paging image buttons if paging index is at the end
            //  3. Enable all image buttons if the conditions of 1 and 2 are not satisfied
            Button firstbutton = gridViewRow.FindControl("btnFirst") as Button;
            Button Prevbutton = gridViewRow.FindControl("btnPrevious") as Button;
            Button Nextbutton = gridViewRow.FindControl("btnNext") as Button;
            Button Lastbutton = gridViewRow.FindControl("btnLast") as Button;



            if (objGridView.PageIndex == 0)
            {
                // Disable 'First' and 'Previous' Paging image buttons

                if (firstbutton != null && Prevbutton != null)
                {
                    firstbutton.Enabled = false;
                    Prevbutton.Enabled = false;
                }
            }
            else if ((objGridView.PageIndex + 1) == objGridView.PageCount)
            {
                // Disable 'Last' and 'Next' Paging image buttons

                if (Lastbutton != null && Nextbutton != null)
                {
                    Lastbutton.Enabled = false;
                    Nextbutton.Enabled = false;
                }
            }
            else
            {
                // Enable the Paging image buttons

                if (firstbutton != null && Lastbutton != null &&
                     Prevbutton != null && Nextbutton != null)
                {
                    firstbutton.Enabled = true;
                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Prevbutton.Enabled = true;
                }
            }

            // Get the DropDownList found as part of the Pager Row. 
            // One can then initialise the DropDownList to contain
            // the appropriate page settings. Eg. Page Number and number of Pages

            DropDownList pageNumberDropDownList = gridViewRow.FindControl("PageNumberDropDownList") as DropDownList;
            Label pageCountLabel = gridViewRow.FindControl("PageCountLabel") as Label;
            if (pageNumberDropDownList != null && pageCountLabel != null)
            {
                for (int i = 0; i < objGridView.PageCount; i++)
                {
                    int page = i + 1;
                    pageNumberDropDownList.Items.Add(new ListItem(page.ToString(), i.ToString()));
                }
                pageNumberDropDownList.SelectedIndex = objGridView.PageIndex;
                pageCountLabel.Text = objGridView.PageCount.ToString();
            }
        }
    }


    public static void GetSortedImage(GridViewRow gvRow, string vSortExpr, string vSortDir)
    {

        
        //--- To show up/down image for the sorted column 
        foreach (TableCell cell in gvRow.Cells)
        {
            if (cell.HasControls())
            {
                LinkButton button = cell.Controls[0] as LinkButton;
                System.Drawing.Color ActualBackColor = cell.BackColor;

                //LinkButton button = (LinkButton)cell.Controls[0];

                if (button != null)
                {
                    Literal BlankLtr = new Literal();
                    BlankLtr.Text = " ";
                    Image image = new Image();
                    //image.ImageUrl = "~/Images/imgDown.gif";

                    if (vSortExpr == button.CommandArgument)
                    {
                        cell.BackColor = System.Drawing.Color.Wheat;

                        if (vSortDir == "asc")
                            image.ImageUrl = "~/Images/imgDown.gif";
                        else
                            image.ImageUrl = "~/Images/imgUp.gif";
                        cell.Controls.Add(BlankLtr);
                        cell.Controls.Add(image);
                    }
                    else
                    {
                        cell.BackColor = ActualBackColor;
                    }

                    
                   
                }
            }
        }
        //----------------------- x --------------------------

    }


    public static string TitleCase(string value)
    {

        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);

    }


    public static int GetGridViewColIndex_HeaderText(string ColName, GridView GV)
    {
        int tmpIdx = -1;

        foreach (DataControlField col in GV.Columns)
        {
            if (col.HeaderText == ColName)
            {
                tmpIdx = GV.Columns.IndexOf(col);
                // return tmpIdx;
                break;
            }
        }
        return tmpIdx;

    }


    public static string SafeSql(string inputSQL)
    {
        return inputSQL.Replace("'", "''");
    }


    public static string GetMonthName(int vMonth, bool abbrev)
    {
        DateTime date = new DateTime(1900, vMonth, 1);
        if (abbrev) return date.ToString("MMM");
        return date.ToString("MMMM");
    }




    /// <summary> 
    /// Shows a client-side JavaScript alert in the browser. 
    /// </summary> 
    /// <param name="message">The message to appear in the alert.</param> 
    public static void AlertMessage(string message) 
{ 
   // Cleans the message to allow single quotation marks 
   string cleanMessage = message.Replace("'", "\'");
   
   string script = "<script type='text/javascript'>alert('" + cleanMessage + "');</script>"; 

   // Gets the executing web page 
   Page page = HttpContext.Current.CurrentHandler as Page; 

   // Checks if the handler is a Page and that the script isn't allready on the Page 
   if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert")) 
   {
       page.ClientScript.RegisterClientScriptBlock(typeof(CommonFunctions), "alert", script); 
   } 
}


    /// <summary> 
    /// Shows a client-side JavaScript alert in the browser and redirects to the give page. 
    /// </summary> 
    /// <param name="message">The message to appear in the alert.</param> 
    public static void AlertMessageAndRedirect(string message, string PageURL)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\'");
        string script = "<script type='text/javascript'>alert('" + cleanMessage + "');window.location.href='" + PageURL + "';</script>";

        // Gets the executing web page 
        Page page = HttpContext.Current.CurrentHandler as Page;

        // Checks if the handler is a Page and that the script isn't allready on the Page 
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            page.ClientScript.RegisterClientScriptBlock(typeof(CommonFunctions), "alert", script);
        }
    }

       /// <summary> 
    /// Handles the newline for all environments.
    /// </summary> 
    /// <param name="strContent">The content to handle</param> 
    public static string HandleNewLines(string strContent,string strUserAgent)
    {

        if ((strUserAgent.Contains("Chrome")) || (strUserAgent.Contains("Firefox")))
        {
            strContent = strContent.Trim().Replace("\n",Environment.NewLine);
            strContent = strContent.Replace(Environment.NewLine, "<br/>");
        }
        else{
            strContent = strContent.Trim().Replace(Environment.NewLine,"<br/>");
        }
        return strContent;

    }



    /// <summary> 
    /// Opens a window on client browser 
    /// </summary> 
    /// <param name="message">The message to appear in the alert.</param> 
    public static void OpenWindow(Uri strURi)
    {

       // window.open(tmpURL, "winDomainCheck", "width=600px,height=550px,resizable=yes, scrollbars=yes,dependent=yes,left=150,top=150");

        string script = "<script  language='javascript' type='text/javascript'>window.ShowModalDialog('" + strURi + "','winOpen','width=800px,height=600px,resizable=yes, scrollbars=yes,dependent=yes,left=150,top=150');</script>";

        // Gets the executing web page 
        Page page = HttpContext.Current.CurrentHandler as Page;

        // Checks if the handler is a Page and that the script isn't allready on the Page 
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("custloginwindow"))
        {
            page.ClientScript.RegisterClientScriptBlock(typeof(CommonFunctions), "custloginwindow", script);
        }
    }


    public static void Redirect2Logins(string tmpCountryPrefix, string mUserName, string mPassword)
    {
        String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
        strReferringURL = strReferringURL.Replace("http://", ""); 
        int GetFirstSlashidx = strReferringURL.IndexOf(@":");
        if (GetFirstSlashidx > 0)
        strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx);
        string strURL = string.Empty;


        //switch (tmpCountryPrefix)
        //{
            //case "60": /* Malaysia  */ strURL = "http://64.78.18.32/Hitech/1SmsWebSite_BizMemberCheck_Hitech.asp"; break;
            //case "60":  /* Malaysia  */ strURL = "http://210.5.45.47/Hitech/1SmsWebSite_BizMemberCheck.aspx"; break;
            //case "60":  /* Malaysia  */ strURL = "http://210.5.45.47/hitechdigitalbiz/1SmsWebSite_BizMemberCheck.aspx"; break;

            //case "62": /* Indonesia */ strURL = "http://64.78.18.32/Indonesia/1SMSWebSite_BizMemberCheckIndo_NEW.asp"; break;
            //case "65": /* Singapore */ strURL = "http://64.78.18.32/singapore/1SMSWebSite_BizMemberCheckSGD_NEW.asp"; break;
            //case "673":/* Brunei    */ strURL = "http://64.78.18.32/Hitech/PartnerLogin_Brunei.asp"; break;
                
            //case "62": /* Indonesia */ strURL = "http://64.78.18.32/Indonesia/1SMSWebSite_BizMemberCheckIndo_NEW.asp"; break;
            //case "65": /* Singapore */ strURL = "http://64.78.18.32/singapore/1SMSWebSite_BizMemberCheckSGD_NEW.asp"; break;
            //case "673":/* Brunei    */ strURL = "http://64.78.18.32/Hitech/PartnerLogin_Brunei.asp"; break;
        //}


        //if (tmpCountryPrefix == "60")
        //{
        //    //redirect to 1malaysia  
        //    //strURL = "http://64.78.18.32/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&ReferringURL=" + strReferringURL;
        //    //strURL = "http://64.78.18.32/MLMSMS/1SmsWebSite_BizMemberCheck_NEW.asp";
        //    strURL = "http://64.78.18.32/Hitech/1SmsWebSite_BizMemberCheck_Hitech.asp";
        //    //HttpContext.Current.Response.Redirect(strURL);
        //}
        //else if (tmpCountryPrefix == "65")
        //{
        //    //redirect to 1singapore 
        //    //strURL = "http://64.78.18.32/singapore/1SMSWebSite_BizMemberCheckSGD_NEW.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&ReferringURL=" + strReferringURL;
        //    strURL = "http://64.78.18.32/singapore/1SMSWebSite_BizMemberCheckSGD_NEW.asp";
        //   // HttpContext.Current.Response.Redirect(strURL);
        //}
        //else if (tmpCountryPrefix == "62")
        //{
        //    //redirect to Indonesia 
        //    //strURL = "http://64.78.18.32/Indonesia/1SMSWebSite_BizMemberCheckIndo.asp?Muser=" + mUserName + "&Mpwd=" + mPassword + "&ReferringURL=" + strReferringURL;
        //    strURL = "http://64.78.18.32/Indonesia/1SMSWebSite_BizMemberCheckIndo_NEW.asp";
        //   // HttpContext.Current.Response.Redirect(strURL);

        //}
        strURL = ConfigurationManager.AppSettings["BizLoginCheckURL"].ToString(); 
       // strURL = "http://210.5.45.47/hitechdigitalbiz/1SmsWebSite_BizMemberCheck.aspx";

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


    public static void TestCheckSubDomainByLoginID(string tmpCountryPrefix, string vLoginID, string vPassword)
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

            //LtrErrMessage.Text = "Register SubDomain";

            StringBuilder sbm = new StringBuilder();

            sbm.Append(@"\n You have not registered your SubDomain yet.");
            sbm.Append(@"\n ");
            sbm.Append(@"\n Please register your suddomain to continue ");
            sbm.Append(@"\n\n ");
            sbm.Append(@"\n Thank you.");

            //CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));

            HttpContext.Current.Response.Clear();
            string Mas1WebRegURL = "TestMasWebReg.aspx";

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", Mas1WebRegURL);
            sb.AppendFormat("<input type='hidden' name='MasRegCountryPrefix' value='{0}'>", tmpCountryPrefix);
            sb.AppendFormat("<input type='hidden' name='MasRegMobileID' value='{0}'>", vLoginID);
            sb.AppendFormat("<input type='hidden' name='MasRegPassword' value='{0}'>", vPassword);
            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());

            HttpContext.Current.Response.End();


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


    public static void CheckSubDomainByLoginID(string tmpCountryPrefix,string vLoginID,string vPassword)
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

            //LtrErrMessage.Text = "Register SubDomain";

            StringBuilder sbm = new StringBuilder();

            sbm.Append(@"\n You have not registered your SubDomain yet.");
            sbm.Append(@"\n ");
            sbm.Append(@"\n Please register your suddomain to continue ");
            sbm.Append(@"\n\n ");
            sbm.Append(@"\n Thank you.");

            //CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));

            HttpContext.Current.Response.Clear();
           // string Mas1WebRegURL = "Mas1UserWebRegistration.aspx";
            string Mas1WebRegURL = "Mas1SubDomainReg.aspx";

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", Mas1WebRegURL);
            sb.AppendFormat("<input type='hidden' name='MasRegCountryPrefix' value='{0}'>", tmpCountryPrefix);
            sb.AppendFormat("<input type='hidden' name='MasRegMobileID' value='{0}'>", vLoginID);
            sb.AppendFormat("<input type='hidden' name='MasRegPassword' value='{0}'>", vPassword);
            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());
            
            HttpContext.Current.Response.End();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();

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


    public static void LogUserLoginData(string vLoginId, string vPassword, int vLoginFrom, int vLoginStatus)
    {

        try
        {
            SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
            SqlCommand dbCmd;

            dbConn.Open();

            dbCmd = new SqlCommand("[usp_LogUserLoginData]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vLoginId;
            dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = vPassword;
            dbCmd.Parameters.Add("@vLoginFrom", SqlDbType.TinyInt).Value = vLoginFrom;
            dbCmd.Parameters.Add("@vLoginStatus", SqlDbType.TinyInt).Value = vLoginStatus;
            
            dbCmd.ExecuteNonQuery();

            dbConn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public static void LogUserWebInfo(string vMID,string vUserName)
    {

            LoggedUserInfo ui = new LoggedUserInfo();

           // ui.LoginUserID = Convert.ToInt32(Session["UserID"]);
            ui.SessionStartTime = DateTime.Now;
            if (ui != null)
            {
                try
                {
                    if (HttpContext.Current.Request.UrlReferrer != null)
                    {
                        ui.urlReferrer = HttpContext.Current.Request.UrlReferrer.ToString();
                    }


                    ui.userAgent = HttpContext.Current.Request.UserAgent;
                    ui.hostAddress = HttpContext.Current.Request.UserHostAddress;
                    ui.hostName = HttpContext.Current.Request.UserHostName;

                    ui.urlViews.Add( HttpContext.Current.Request.RawUrl);

                    if (ui.userAgent == null)
                    {
                        if ( HttpContext.Current.Request.UserAgent == null)
                            ui.userAgent = DBNull.Value.ToString();
                        else
                            ui.userAgent =  HttpContext.Current.Request.UserAgent;
                    }

                    if (ui.hostAddress == null)
                        ui.hostAddress =  HttpContext.Current.Request.UserHostAddress;

                    if (ui.hostName == null)
                        ui.hostName =  HttpContext.Current.Request.UserHostName;

                    
                    if (ui.LoginUserID == 0 )
                    {
                        if (HttpContext.Current.Session["UserID"] != null)
                        {
                            ui.LoginUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                        }
                        else if (HttpContext.Current.Session["ClientID"] != null)
                        {
                            ui.LoginUserID = Convert.ToInt32(HttpContext.Current.Session["ClientID"]);
                        }
                        else if (HttpContext.Current.Session["saUserID"] != null)
                        {
                            ui.LoginUserID = Convert.ToInt32(HttpContext.Current.Session["saUserID"]);
                        }
                    }

                    ui.MobileLoginID = vUserName; 
                    
                    ///HttpContext.Current.Session["USER_LOG_INFO"] = ui;
                    /// storing into database
                    /// 

                    SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                    SqlCommand dbCmd;

                    dbConn.Open();

                    dbCmd = new SqlCommand("[usp_LogUserWebInfo]", dbConn);
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@LoginID", SqlDbType.VarChar).Value = ui.MobileLoginID;
                    dbCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = ui.LoginUserID;
                    dbCmd.Parameters.Add("@SessionID", SqlDbType.VarChar).Value = HttpContext.Current.Session.SessionID.ToUpper();
                    dbCmd.Parameters.Add("@URL", SqlDbType.VarChar).Value =  HttpContext.Current.Request.Url.AbsoluteUri;
                    dbCmd.Parameters.Add("@BrowserInfo", SqlDbType.VarChar).Value = ui.userAgent;
                    dbCmd.Parameters.Add("@BrowserType", SqlDbType.VarChar).Value =  HttpContext.Current.Request.Browser.Type;
                    dbCmd.Parameters.Add("@HostName", SqlDbType.VarChar).Value = ui.hostName;
                    dbCmd.Parameters.Add("@HostAddress", SqlDbType.VarChar).Value = ui.hostAddress;
                    dbCmd.Parameters.Add("@SessionStartTime", SqlDbType.DateTime).Value = ui.SessionStartTime;
                    dbCmd.Parameters.Add("@Pages", SqlDbType.VarChar).Value =  HttpContext.Current.Request.RawUrl;

                    dbCmd.ExecuteNonQuery();

                    dbConn.Close();

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
    }

    public static void LogMobileWebInfo(string vUserID)
    {

        LoggedUserInfo ui = new LoggedUserInfo();

        // ui.LoginUserID = Convert.ToInt32(Session["UserID"]);
        ui.SessionStartTime = DateTime.Now;
        if (ui != null)
        {
            try
            {
                if (HttpContext.Current.Request.UrlReferrer != null)
                {
                    ui.urlReferrer = HttpContext.Current.Request.UrlReferrer.ToString();
                }


                ui.userAgent = HttpContext.Current.Request.UserAgent;
                ui.hostAddress = HttpContext.Current.Request.UserHostAddress;
                ui.hostName = HttpContext.Current.Request.UserHostName;

                ui.urlViews.Add(HttpContext.Current.Request.RawUrl);

                if (ui.userAgent == null)
                {
                    if (HttpContext.Current.Request.UserAgent == null)
                        ui.userAgent = DBNull.Value.ToString();
                    else
                        ui.userAgent = HttpContext.Current.Request.UserAgent;
                }

                if (ui.hostAddress == null)
                    ui.hostAddress = HttpContext.Current.Request.UserHostAddress;

                if (ui.hostName == null)
                    ui.hostName = HttpContext.Current.Request.UserHostName;


                if (ui.LoginUserID == 0 )
                {
                    if (HttpContext.Current.Session["UserID"] != null)
                    {
                        ui.LoginUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                    }
                    else if (HttpContext.Current.Session["ClientID"] != null)
                    {
                        ui.LoginUserID = Convert.ToInt32(HttpContext.Current.Session["ClientID"]);
                    }
                    else if (HttpContext.Current.Session["saUserID"] != null)
                    {
                        ui.LoginUserID = Convert.ToInt32(HttpContext.Current.Session["saUserID"]);
                    }
                }

                #region Retreiving Mobile Info .......
                
                

                String mbMobile = string.Empty;
                String mbManufacturer  = HttpContext.Current.Request.Browser.MobileDeviceManufacturer;
                String mbModel = HttpContext.Current.Request.Browser.MobileDeviceModel;
                String mbScreen = HttpContext.Current.Request.Browser.ScreenPixelsWidth.ToString() + " x " + HttpContext.Current.Request.Browser.ScreenPixelsHeight.ToString();

                //String tmpUserAgent = Request.UserAgent;
                // String tmpUserAgent = "Mozilla/5.0 avantgo (X11; U; Linux i686; en-US; rv:1.9.2.24; ips-agent) Gecko/20111107 Ubuntu/10.04 (lucid) Firefox/3.6.24";

                if(ui.userAgent != null)
                {
                    string tmpUserAgent = ui.userAgent; 

                    Regex b = new Regex(@"android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);

                    if ((b.IsMatch(tmpUserAgent)))
                    {
                        MatchCollection mbMatch = b.Matches(tmpUserAgent);

                        foreach (Match mc in mbMatch)
                        {
                            mbMobile = mc.Groups[0].Value.ToString();
                        }

                    }
                }
            
                #endregion
                
                
                //    ui.MobileLoginID = vUserName;

                ///HttpContext.Current.Session["USER_LOG_INFO"] = ui;
                /// storing into database
                /// 

                SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                SqlCommand dbCmd;

                dbConn.Open();

                dbCmd = new SqlCommand("[usp_LogMobileWebInfo]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                //dbCmd.Parameters.Add("@LoginID", SqlDbType.VarChar).Value = ui.MobileLoginID;
                dbCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = ui.LoginUserID;
                dbCmd.Parameters.Add("@SessionID", SqlDbType.VarChar).Value = HttpContext.Current.Session.SessionID.ToUpper();
                dbCmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = HttpContext.Current.Request.Url.AbsoluteUri;
                dbCmd.Parameters.Add("@BrowserInfo", SqlDbType.VarChar).Value = ui.userAgent;
                dbCmd.Parameters.Add("@BrowserType", SqlDbType.VarChar).Value = HttpContext.Current.Request.Browser.Type;
                dbCmd.Parameters.Add("@HostName", SqlDbType.VarChar).Value = ui.hostName;
                dbCmd.Parameters.Add("@HostAddress", SqlDbType.VarChar).Value = ui.hostAddress;
                dbCmd.Parameters.Add("@SessionStartTime", SqlDbType.DateTime).Value = ui.SessionStartTime;
                dbCmd.Parameters.Add("@Pages", SqlDbType.VarChar).Value = HttpContext.Current.Request.RawUrl;
                dbCmd.Parameters.Add("@mbMobile", SqlDbType.VarChar).Value = mbMobile;
                dbCmd.Parameters.Add("@mbManufacturer", SqlDbType.VarChar).Value = mbManufacturer;
                dbCmd.Parameters.Add("@mbModel", SqlDbType.VarChar).Value = mbModel;
                dbCmd.Parameters.Add("@mbScreen", SqlDbType.VarChar).Value = mbScreen;
                dbCmd.ExecuteNonQuery();

                dbConn.Close();

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public static void fnSendEmailHTML(string vEmail, string VmobileNo, string vFullName, string vDomainName, string vDomainPassword)
    {
        string tmpWebsitecom = GlobalVar.GetAnchorDomainName;
        string DomainURL = vDomainName + "." + tmpWebsitecom;
        string tmpPartnerWebRegistration = "Partner Website Registration";

        string tmpHtmlBody = @"
     <html xmlns='http://www.w3.org/1999/xhtml'>
<head >
    <title></title>
    <style type='text/css'>
        .style2        {            height: 18px;        }
        .SearchLabelBold        {height:25px; FONT-SIZE: 12px; COLOR: #221F0B; padding-left:10px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif; font-weight:bold;}
        .SearchLabel            {height:25px; FONT-SIZE: 12px; COLOR: #44412F; padding-left:2px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif;}
        .stdtableBorder_Search		{ background-color:#F7F9E5; BORDER-BOTTOM: #b8e0fb 1px solid; BORDER-TOP: #b8e0fb 1px solid; width:98%;
                              		   FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: 'Lucida Console', Arial,Verdana, Helvetica, sans-serif;}
        .font_12BlueBold	{ FONT-SIZE: 12px;  font-weight:bold; COLOR: #2291A1; height:25px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .subHeaderFontGrad  	{font: bold 120%/100% 'Trebuchet MS','Lucida Console', Arial, sans-serif;	position: relative;	margin: 30px 0 50px; vertical-align:middle;	color: #687367; font-style:italic;}
        .stdtableBorder_Main	{ background-color:#F6F7F6; padding: 5px 10px 10px 10px; border: #CDF2D6 1px solid; FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
        .bkgNewsBoxOren		    {background-color:#F3D651;}
        .font_12Normal		{ FONT-SIZE: 12px; COLOR: #03C0C6; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
    </style>
</head>
<body>
    <div>
        <table cellpadding='0' cellspacing='0' align='center' width='80%' class='stdtableBorder_Main'>
            <tr class='bkgNewsBoxOren subHeaderFontGrad'>
                <td class='style2' style='height: 40px;' align='center'>" + tmpWebsitecom + @"</td>
            </tr>
        <tr class='bkgNewsBoxOren FontSubHeader'>
                <td class='style2' style='height: 40px;' align='center'>" + tmpPartnerWebRegistration + @"</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style='white-space:nowrap; width: 200px;'>
                    Dear <font class='font_12BlueBold'>" + vFullName + @" </font>,</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Greetings from " + tmpWebsitecom + @"</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    You have recently registered <b> " + DomainURL + @"</b> using this email address.<br />
&nbsp;we are delighted to have 
                    you as a registered user. </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class='font_12Normal'>
                    Please find your login information below.</td>
            </tr>
            <tr>
                <td align='center'>
                    <table cellpadding='0' cellspacing='0' width='80%' class='stdtableBorder_Search' >
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width='40%' class='SearchLabelBold'>
                                Your SubDomain Link :</td>
                            <td width='60%' align='left' class='SearchLabel'>
                                " + DomainURL + @"</td>
                        </tr>
                         <tr>
                            <td width='40%' class='SearchLabelBold'>
                                Admin Login</td>
                            <td width='60%' align='left' class='SearchLabel'>
                                " + vDomainName + @"</td>
                        </tr>
                        <tr>
                            <td  class='SearchLabelBold'>
                                Admin Password</td>
                            <td align='left' class='SearchLabel'>
                                " + vDomainPassword + @"</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td  class='SearchLabelBold'>
                                Registered Mobile</td>
                            <td align='left' class='SearchLabel'>
                                " + VmobileNo + @"</td>
                        </tr>
                        <tr>
                            <td class='SearchLabelBold'>
                                Registered Name
                            </td>
                            <td align='left' class='SearchLabel'>
                                " + vFullName + @"</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Click here to open your registered website :&nbsp; <a href='" + DomainURL + @"'  target=_blank'>" + DomainURL + @"</a></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class='font_12Msg_Success'>
                <b>NOTE:</b> For Those who purchase Web30, please login to register your own domain
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Regards,</td>
            </tr>

            <tr>
                <td>
                    Support Team, </td>
            </tr>
            <tr>
                <td>
                    " + tmpWebsitecom + @"</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>NOTE</b>:&nbsp; This is a system generated email. Please do not reply this email.</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
</body>
</html>";

        string tmpFormAddress = "SupportTeam@" + tmpWebsitecom;

        SmtpClient smtpClient = new SmtpClient();
        MailMessage objMessage = new MailMessage();

        try
        {

            MailAddress m_fromAddress = new MailAddress(tmpFormAddress, "EBookAdmin");
            // You can specify the host name or ipaddress of your server

            // Default in IIS will be localhost 
            //smtpClient.Host = "localhost";
            smtpClient.Host = "127.0.0.1";

            //Default port will be 25
            smtpClient.Port = 25;

            //From address will be given as a MailAddress Object
            objMessage.From = m_fromAddress;

            // To address collection of MailAddress

            objMessage.To.Add(vEmail);
            objMessage.Subject = tmpWebsitecom + ": " + tmpPartnerWebRegistration;

            // CC and BCC optional

            // MailAddressCollection class is used to send the email to various users

            // You can specify Address as new MailAddress("admin1@yoursite.com")

            //objMessage.CC.Add("admin1@yoursite.com");
            //objMessage.CC.Add("admin2@yoursite.com");

            // You can specify Address directly as string

            //objMessage.Bcc.Add(new MailAddress("admin3@yoursite.com"));
            //objMessage.Bcc.Add(new MailAddress("admin4@yoursite.com"));

            objMessage.Bcc.Add("srihari@globalsurf.com.my");
            objMessage.Bcc.Add(GlobalVar.GetEmailRecipientList2);
            objMessage.Bcc.Add(GlobalVar.GetEmailRecipientList1);

            //Body can be Html or text format

            //Specify true if it  is html message

            objMessage.IsBodyHtml = true;
            // Message body content
            //string m_MessageBody = "Your Registration at SMSentreprenuer.com is successful";
            objMessage.Body = tmpHtmlBody;

            // Send SMTP mail
            smtpClient.Send(objMessage);

            // lblStatus.Text = "Email successfully sent.";




        }
        catch
        {

        }



    }

    public static void GenericSendEmail(string VEmailTO, string VEmailFrom, string vEmailBody, string vEmailSubject, string vEmailToFullName, string vField1, string vField2)
    {

        string tmpWebSiteName = GlobalVar.GetAnchorDomainName;

        string tmpHtmlBody = @"
     <html xmlns='http://www.w3.org/1999/xhtml'>
<head >
    <title></title>
    <style type='text/css'>
        .style2        {            height: 18px;        }
        .font_12BlueBold	{ FONT-SIZE: 12px;  font-weight:bold; COLOR: #2291A1; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .font_12Normal		{ FONT-SIZE: 12px; COLOR: #03C0C6; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .stdtableBorder_Main		{ background-color:#FAFCFA; border: #CDF2D6 1px solid; FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
        .bkgFooter		    {background-color:#FAFCFA;
                  		     filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FAFCFA', endColorstr='#FFFFFF'); /* for IE */
                            background: -webkit-gradient(linear, left top, left bottom, from(#FAFCFA), to(#FFFFFF)); /* for webkit browsers */
                            background: -moz-linear-gradient(top,  #FAFCFA,  #FFFFFF); /* for firefox 3.6+ */ 
                  		     }
    </style>
</head>
<body>
    <div>
     <table cellpadding='0' cellspacing='0' width='600px' class='stdtableBorder_Main'>
        <tr height='0px'>
            <td width='3%'>
                </td>
            <td width='94%'>
                </td>
            <td width='3%'>
                </td>
        </tr>
        <tr>
            <td colspan='3' style='background-image: url(http://www.1smsbusiness.com/Images/Mail/header1_green.jpg); background-repeat: no-repeat; height: 100px;'>
            
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Hi <font class='font_12BlueBold'>" + vEmailToFullName + @" </font>,</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Greetings from " + tmpWebSiteName + @"</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>" + vEmailBody +
            @"</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Thank you,<br />
                SupportTeam@"+ tmpWebSiteName + @"</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class='bkgFooter' height='50px'>
        <td>
                &nbsp;</td>
            <td align='right'  valign='middle'>
                &nbsp; All Copyrights Reserved @2010
                </td>
                <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
</body>
</html>";


        String dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
        if (dbConnString.Contains("IXCMSdb"))
        {
            #region Commented code for OLDER smtp mail

            SmtpClient smtpClient = new SmtpClient();
            MailMessage objMessage = new MailMessage();

            try
            {

                MailAddress m_fromAddress = new MailAddress("support@" + GlobalVar.GetAnchorDomainName, "EBookAdmin");
                // You can specify the host name or ipaddress of your server

                // Default in IIS will be localhost 
                //smtpClient.Host = "localhost";
                smtpClient.Host = "127.0.0.1";

                //Default port will be 25
                smtpClient.Port = 25;

                //From address will be given as a MailAddress Object
                objMessage.From = m_fromAddress;

                // To address collection of MailAddress

                objMessage.To.Add(VEmailTO);
                objMessage.Subject = vEmailSubject;

                // CC and BCC optional

                // MailAddressCollection class is used to send the email to various users

                // You can specify Address as new MailAddress("admin1@yoursite.com")

                //objMessage.CC.Add("admin1@yoursite.com");
                //objMessage.CC.Add("admin2@yoursite.com");

                // You can specify Address directly as string

                //objMessage.Bcc.Add(new MailAddress("admin3@yoursite.com"));
                //objMessage.Bcc.Add(new MailAddress("admin4@yoursite.com"));

                objMessage.Bcc.Add("srihari@globalsurf.com.my");
                //objMessage.Bcc.Add("msri_hari@hotmail.com");

                //Body can be Html or text format

                //Specify true if it  is html message

                objMessage.IsBodyHtml = true;
                // Message body content
                //string m_MessageBody = "Your Registration at SMSentreprenuer.com is successful";
                objMessage.Body = tmpHtmlBody;

                // Send SMTP mail
                smtpClient.Send(objMessage);

                // lblStatus.Text = "Email successfully sent.";




            }
            catch
            {

            }

            #endregion
        }
        else
        {
            #region Sending Mail using Hmailserver on Local Server

            //hMailServer.Application objApp_Hmail = new hMailServer.Application();

            //objApp_Hmail.Authenticate("Administrator", "X943!8j2");
            //objApp_Hmail.Connect();


            //hMailServer.Message objMsg_Hmail = new hMailServer.Message();


            //objMsg_Hmail.AddRecipient(vEmailToFullName, VEmailTO);
            ////objMsg_Hmail.From = "info@1smsbusiness.com";
            //objMsg_Hmail.From = "info@" + GlobalVar.GetAnchorDomainName;
            //objMsg_Hmail.FromAddress = "mail@globauser.small-dns.net";

            //objMsg_Hmail.Subject = vEmailSubject;
            //objMsg_Hmail.HTMLBody = tmpHtmlBody;

            //objMsg_Hmail.Save();


            #endregion



            #region Sending mail using SmarterMail


            SmtpClient smtpClient = new SmtpClient();
            MailMessage objMessage = new MailMessage();
            string m_fromName = string.Empty;
            try
            {


                //m_fromName = "Administrator";

                m_fromName = "info@" + GlobalVar.GetEbookDomainName;
                String vEmailFrom = "noreply@ebooksmsdelivery.com";



                MailAddress m_fromAddress = new MailAddress(vEmailFrom, "EBookAdmin");
                smtpClient.Host = "localhost";
                smtpClient.Port = 25;

                objMessage.From = m_fromAddress;

                objMessage.To.Add(VEmailTO);
                objMessage.Subject = vEmailSubject;

                //objMessage.Bcc.Add("srihari@globalsurf.com.my");


                objMessage.IsBodyHtml = true;
                objMessage.Body = tmpHtmlBody;


                //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
                NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = authinfo;

                // Send SMTP mail
                smtpClient.Send(objMessage);



            }
            catch (Exception ex)
            {
                throw ex;

            }

            #endregion


        }

        





        



    }


    public static void Ebook_GenericSendEmail(string VEmailTO, string VEmailFrom, string vEmailBody, string vEmailSubject, string vEmailToFullName, string vField1, string vField2)
    {

        string tmpWebSiteName = GlobalVar.GetEbookDomainName;

        string tmpHtmlBody = @"
     <html xmlns='http://www.w3.org/1999/xhtml'>
<head >
    <title></title>
    <style type='text/css'>
        .style2        {            height: 18px;        }
        .font_12BlueBold	{ FONT-SIZE: 12px;  font-weight:bold; COLOR: #2291A1; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .font_12Normal		{ FONT-SIZE: 12px; COLOR: #03C0C6; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .stdtableBorder_Main		{ background-color:#FAFCFA; border: #CDF2D6 1px solid; FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
        .bkgFooter		    {background-color:#FAFCFA;
                  		     filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FAFCFA', endColorstr='#FFFFFF'); /* for IE */
                            background: -webkit-gradient(linear, left top, left bottom, from(#FAFCFA), to(#FFFFFF)); /* for webkit browsers */
                            background: -moz-linear-gradient(top,  #FAFCFA,  #FFFFFF); /* for firefox 3.6+ */ 
                  		     }
    </style>
</head>
<body>
    <div>
     <table cellpadding='0' cellspacing='0' width='600px' class='stdtableBorder_Main'>
        <tr height='0px'>
            <td width='3%'>
                </td>
            <td width='94%'>
                </td>
            <td width='3%'>
                </td>
        </tr>
        <tr>
            <td colspan='3' style='background-image: url(http://www.1smsbusiness.com/Images/Mail/header1_green.jpg); background-repeat: no-repeat; height: 100px;'>
            
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Hi <font class='font_12BlueBold'>" + vEmailToFullName + @" </font>,</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Greetings from " + tmpWebSiteName + @"</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>" + vEmailBody +
            @"</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Thank you,<br />
                SupportTeam@" + tmpWebSiteName + @"</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class='bkgFooter' height='50px'>
        <td>
                &nbsp;</td>
            <td align='right'  valign='middle'>
                &nbsp; All Copyrights Reserved @2010
                </td>
                <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
</body>
</html>";


        String dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
        if (dbConnString.Contains("IXCMSdb"))
        {
            #region Commented code for OLDER smtp mail

            SmtpClient smtpClient = new SmtpClient();
            MailMessage objMessage = new MailMessage();

            try
            {

                MailAddress m_fromAddress = new MailAddress("support@" + GlobalVar.GetEbookDomainName, "EBookAdmin");
                // You can specify the host name or ipaddress of your server

                // Default in IIS will be localhost 
                //smtpClient.Host = "localhost";
                smtpClient.Host = "127.0.0.1";

                //Default port will be 25
                smtpClient.Port = 25;

                //From address will be given as a MailAddress Object
                objMessage.From = m_fromAddress;

                // To address collection of MailAddress

                objMessage.To.Add(VEmailTO);
                objMessage.Subject = vEmailSubject;

                // CC and BCC optional

                // MailAddressCollection class is used to send the email to various users

                // You can specify Address as new MailAddress("admin1@yoursite.com")

                //objMessage.CC.Add("admin1@yoursite.com");
                //objMessage.CC.Add("admin2@yoursite.com");

                // You can specify Address directly as string

                //objMessage.Bcc.Add(new MailAddress("admin3@yoursite.com"));
                //objMessage.Bcc.Add(new MailAddress("admin4@yoursite.com"));

                objMessage.Bcc.Add("srihari@globalsurf.com.my");
                //objMessage.Bcc.Add("msri_hari@hotmail.com");

                //Body can be Html or text format

                //Specify true if it  is html message

                objMessage.IsBodyHtml = true;
                // Message body content
                //string m_MessageBody = "Your Registration at SMSentreprenuer.com is successful";
                objMessage.Body = tmpHtmlBody;

                // Send SMTP mail
                smtpClient.Send(objMessage);

                // lblStatus.Text = "Email successfully sent.";




            }
            catch
            {

            }

            #endregion
        }
        else
        {
            #region Sending Mail using Hmailserver on Local Server

            //hMailServer.Application objApp_Hmail = new hMailServer.Application();

            //objApp_Hmail.Authenticate("Administrator", "X943!8j2");
            //objApp_Hmail.Connect();


            //hMailServer.Message objMsg_Hmail = new hMailServer.Message();


            //objMsg_Hmail.AddRecipient(vEmailToFullName, VEmailTO);
            ////objMsg_Hmail.From = "info@1smsbusiness.com";
            //objMsg_Hmail.From = "info@" + GlobalVar.GetEbookDomainName;
            //objMsg_Hmail.FromAddress = "mail@globauser.small-dns.net";

            //objMsg_Hmail.Subject = vEmailSubject;
            //objMsg_Hmail.HTMLBody = tmpHtmlBody;

            //objMsg_Hmail.Save();






            #endregion



            #region Sending mail using SmarterMail


            SmtpClient smtpClient = new SmtpClient();
            MailMessage objMessage = new MailMessage();
            string m_fromName = string.Empty;
            try
            {


               // m_fromName = "Administrator";

                m_fromName = "info@" + GlobalVar.GetEbookDomainName;
                String vEmailFrom = "noreply@ebooksmsdelivery.com";
                MailAddress m_fromAddress = new MailAddress(vEmailFrom, "EBookAdmin");
                smtpClient.Host = "localhost";
                smtpClient.Port = 25;

                objMessage.From = m_fromAddress;

                objMessage.To.Add(VEmailTO);
                objMessage.Subject = vEmailSubject;

                //objMessage.Bcc.Add("srihari@globalsurf.com.my");


                objMessage.IsBodyHtml = true;
                objMessage.Body = tmpHtmlBody;


                //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
                NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = authinfo;

                // Send SMTP mail
                smtpClient.Send(objMessage);



            }
            catch (Exception ex)
            {
                throw ex;

            }

            #endregion


        }











    }


    public static void MySendSMS(string vMessage,String vSendTo, string vSendFrom)
    {

        StringBuilder sbSMS = new StringBuilder();

        
        sbSMS.Append("User=1MADMIN");
        sbSMS.Append("&Password=HARI2010");
        sbSMS.Append("&Mobile=" + vSendTo);
        sbSMS.Append("&Sender=" + vSendFrom);
        //sbSMS.Append("&Schedule=0");
        sbSMS.Append("&Unicode=0");
        //sbSMS.Append("&Personal=" + vMsgTOName);
        //sbSMS.Append("&Prefix=" + vMsgPrefix);
        sbSMS.Append("&Message=" + HttpUtility.UrlEncode(vMessage));


        ASCIIEncoding encoding = new ASCIIEncoding();
        string postData = sbSMS.ToString();
        byte[] data = encoding.GetBytes(postData);

        // Prepare web request...

        String BulkReceiveMainURL = ConfigurationManager.AppSettings["BulkReceiveMainUrl"].ToString();

       // HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://183.81.165.110/GS/Receivers/API/BulkReceiveMain.asp");
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(BulkReceiveMainURL);
        myRequest.Method = "POST";
        myRequest.ContentType = "application/x-www-form-urlencoded";
        myRequest.ContentLength = data.Length;
        Stream newStream = myRequest.GetRequestStream();
        // Send the data.
        newStream.Write(data, 0, data.Length);
        newStream.Close();



    }



    public static int fnGetUserIdfromURL()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;

        //string OurWebSiteName = "1argentinasms";
       // string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();


        string tmpMainURL = HttpContext.Current.Request.Url.OriginalString;

       // tmpMainURL = "eb60123238595.1smsbusiness.com";
        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

            //owndomain
            string ownDomain = tmpMainURL;
            string[] OwnURLArr = tmpMainURL.Split('.');
            string userOwnDomainName = string.Empty;
            int DomainType = -1;

            // see if user has typed in www
            if (OwnURLArr[0].ToString() == "www")
            {
                userOwnDomainName = OwnURLArr[1].ToString();
                if (OwnURLArr.Count() == 5)
                    DomainType = 1; //subdomain
                //else if (OwnURLArr.Count() == 4)
                //    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain
            }
            else
            {
                userOwnDomainName = OwnURLArr[0].ToString();
                if (OwnURLArr.Count() == 4)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain
            }

            //..user comes to his sub domain
            //newUserID = objBAL_User.GetUserID_BySubDomainName(userOwnDomainName);
            newUserID = objBAL_User.GetUserID_BySubDomainName2(userOwnDomainName, DomainType);



        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {

            HttpContext.Current.Response.Redirect("PartnerWebRegistrationNew.aspx");
        }

        return newUserID;

    }


    public static void fnGetUserIdfromURL_TEST()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;

        //string OurWebSiteName = "1argentinasms";
        // string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();


        string tmpMainURL = HttpContext.Current.Request.Url.OriginalString;
        HttpContext.Current.Response.Write("<br/>tmpMainURL : " + tmpMainURL); 

        //tmpMainURL = "http://www.scoreawebsite.com/default_T1.aspx";
        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://

        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

        //owndomain
        string ownDomain = tmpMainURL;
        string[] OwnURLArr = tmpMainURL.Split('.');
        string userOwnDomainName = string.Empty;
        int DomainType = -1;

        // see if user has typed in www
        if (OwnURLArr[0].ToString() == "www")
        {
            userOwnDomainName = OwnURLArr[1].ToString();


            if (OwnURLArr.Count() == 5)
                DomainType = 1; //subdomain
            //else if (OwnURLArr.Count() == 4)
            //    DomainType = 1; //subdomain
            else
                DomainType = 2; //Owndomain or Anchordomain

            HttpContext.Current.Response.Write("<br/>OwnURLArr.Count() : " + OwnURLArr.Count().ToString()); 
            HttpContext.Current.Response.Write("<br/>DomainType : " + DomainType); 
        }
        else
        {
            userOwnDomainName = OwnURLArr[0].ToString();
            if (OwnURLArr.Count() == 4)
                DomainType = 1; //subdomain
            else
                DomainType = 2; //Owndomain or Anchordomain

            HttpContext.Current.Response.Write("<br/>OwnURLArr.Count() : " + OwnURLArr.Count().ToString());
            HttpContext.Current.Response.Write("<br/>DomainType : " + DomainType); 
        }

        //..user comes to his sub domain
        //newUserID = objBAL_User.GetUserID_BySubDomainName(userOwnDomainName);
        newUserID = objBAL_User.GetUserID_BySubDomainName2(userOwnDomainName, DomainType);


        HttpContext.Current.Response.Write("<br/>UserID : " + newUserID);
        HttpContext.Current.Response.End(); 
        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        //if (newUserID == 0)
        //{

        //    HttpContext.Current.Response.Redirect("PartnerWebRegistrationNew.aspx");
        //}

        //return newUserID;

    }




    public static int GetUserIdfromURL2()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;

        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();


        string tmpMainURL = HttpContext.Current.Request.Url.OriginalString;
        string OrgURL = HttpContext.Current.Request.Url.OriginalString;
        //tmpMainURL = "http://1mybusiness.com";


        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://

        String tmpReferringURL;
        tmpReferringURL = tmpMainURL;
        int tmpidxCom = tmpReferringURL.IndexOf(".com");
        int tmplen = tmpidxCom + 4;
        String mReferringURL = String.Empty;
        mReferringURL = tmpReferringURL.Substring(0, tmplen);
        mReferringURL = mReferringURL.Replace("www.", "");


        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

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



        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {
            HttpContext.Current.Response.Redirect("~/PartnerWebRegistrationNew.aspx");
            //Response.Redirect("InValidDomain.aspx");

        }

        return newUserID;

    }




    /// <summary> 
    /// Detects and returns TRUE,  if the request is coming from a mobile Device  
    /// </summary> 
    
    /// 

    //public static bool IsMobile()
    //{
    //    try
    //    {
    //        string myUserAgent = string.Empty;            
    //        //HttpContext.Current.Request.UserAgent.ToLower();
    //        if (HttpContext.Current.Request != null)
    //        {
    //            myUserAgent = HttpContext.Current.Request.UserAgent.ToLower();
    //            //string u = Request.ServerVariables["HTTP_USER_AGENT"];
    //            Regex b = new Regex(@"android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    //            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|e\-|e\/|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|xda(\-|2|g)|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);

    //            if (myUserAgent != "")
    //            {
    //                if (b.IsMatch(myUserAgent))
    //                {
    //                    //Response.Redirect("http://detectmobilebrowser.com/mobile");
    //                    return true;
    //                }
    //                if (myUserAgent.Length >= 4)
    //                {
    //                    if (v.IsMatch(myUserAgent.Substring(0, 4)))
    //                    {
    //                        return true;
    //                    }
    //                }
    //            }
    //            return false;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {

    //    }
    //}

    public static bool IsMobile()
    {
        return false;
    }

    public static Boolean IsNumeric(string stringToTest)
    {
        int result;
        return int.TryParse(stringToTest, out result);
    }



    public static void ftpfileupload(String vImgFilePath, string vImgFtpFileName)
    {
        //string ftpBaseAddress = @"ftp://210.5.45.8/ImageRepository";
        string ftpBaseAddress = @"ftp://192.168.29.29/ImageRepository";
        string username = "1worldimgftp";
        string password = "global88";

        FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftpBaseAddress + "/" + vImgFtpFileName);

        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(username, password);
        request.UsePassive = true;
        request.UseBinary = true;
        request.KeepAlive = false;

        //using (Stream destination = request.GetRequestStream())
        //{
        //   vFileUploadImg.PostedFile.InputStream.CopyTo(destination);
        //    destination.Flush();
        //}

        FileStream stream = File.OpenRead(vImgFilePath + vImgFtpFileName);

        byte[] buffer = new byte[stream.Length];


        stream.Read(buffer, 0, buffer.Length);
        stream.Close();

        Stream reqStream = request.GetRequestStream();
        reqStream.Write(buffer, 0, buffer.Length);
        reqStream.Close();

    }




    public static string ValidateLoginStatus_DPE(string vMobileLoginID, ref int ReturnStatus)
    {

        int retStatus = 0;
        String retStatusTEXT = "VALID";

        //validate the Logins . 

        CMSv3.BAL.DPE objDPE = new CMSv3.BAL.DPE(); 
        DataSet ds;

        vMobileLoginID = vMobileLoginID.Replace("DPE", ""); 

        ds = objDPE.DPE_ValidateLoginStatus(vMobileLoginID); 


        DataTable dtFreeze = ds.Tables[0];
        DataTable dtExpiry = ds.Tables[1];



        if (dtFreeze.Rows.Count > 0)
        {

            DataRow dtRow = dtFreeze.Rows[0];

            String FreezeStatusTxt = dtRow["FrzStatus"].ToString();

            int FreezeStatus = 0;


            if (FreezeStatusTxt.ToUpper() == "TRUE")
                FreezeStatus = 1;

            String FreezeMessage = dtRow["FrzMessage"].ToString();

            if (FreezeStatus == 1)
            {
                //LblNotice.Text = FreezeMessage;
                // ModalPopUpExtender1.Show();
                retStatusTEXT = FreezeMessage;
                retStatus = 1;
            }

        }


        if (dtExpiry.Rows.Count > 0)
        {

            DataRow dtRow = dtExpiry.Rows[0];

            int MonthsLeft = Convert.ToInt16(dtRow["NoOfMonthsLEFT"].ToString());
            DateTime vExpiryDate = Convert.ToDateTime(dtRow["ExpiryDate"].ToString());


            if (MonthsLeft < 1)
            {
                // LblNotice.Text = @"Your Account has already expired on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately. <br> Expired account will be removed from the system after 90 days";
                // ModalPopUpExtender1.Show();
                retStatusTEXT = @"Your Account has already expired on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". \\nPlease renew immediately."; ;
                retStatus = 2;

            }
            else if (MonthsLeft < 3)
            {
                // LblNotice.Text = @"Your Account will expire on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately. <br> Expired account will be removed from the system after 90 days";
                // ModalPopUpExtender1.Show();

                retStatusTEXT = @"Your Account will expire on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately.";
                retStatus = 3;

            }


        }


        ReturnStatus = retStatus;
        return retStatusTEXT;


    }
  



    public static string ValidateLoginStatusNEW(string vLoginID, String vPassword, String vType, ref int ReturnStatus)
    {

        int retStatus = 0;
        String retStatusTEXT = "VALID";

        //validate the Logins . 

        CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
        DataSet ds;

        ds = objBAL_MalaysiaSMS.ValidateLoginStatus(vLoginID, vPassword, vType);


        DataTable dtFreeze = ds.Tables[0];
        DataTable dtExpiry = ds.Tables[1];



        if (dtFreeze.Rows.Count > 0)
        {

            DataRow dtRow = dtFreeze.Rows[0];

            String FreezeStatusTxt = dtRow["FrzStatus"].ToString();

            int FreezeStatus = 0;


            if (FreezeStatusTxt.ToUpper() == "TRUE")
                FreezeStatus = 1;

            String FreezeMessage = dtRow["FrzMessage"].ToString();

            if (FreezeStatus == 1)
            {
                //LblNotice.Text = FreezeMessage;
                // ModalPopUpExtender1.Show();
                retStatusTEXT = FreezeMessage;
                retStatus = 1;
            }

        }


        if (dtExpiry.Rows.Count > 0)
        {

            DataRow dtRow = dtExpiry.Rows[0];

            int MonthsLeft = Convert.ToInt16(dtRow["NoOfMonthsLEFT"].ToString());
            DateTime vExpiryDate = Convert.ToDateTime(dtRow["ExpiryDate"].ToString());


            if (MonthsLeft < 1)
            {
                // LblNotice.Text = @"Your Account has already expired on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately. <br> Expired account will be removed from the system after 90 days";
                // ModalPopUpExtender1.Show();
                retStatusTEXT = @"Your Account has already expired on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". \\nPlease renew immediately."; ;
                retStatus = 2;

            }
            else if (MonthsLeft < 3)
            {
                // LblNotice.Text = @"Your Account will expire on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately. <br> Expired account will be removed from the system after 90 days";
                // ModalPopUpExtender1.Show();

                retStatusTEXT = @"Your Account will expire on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately.";
                retStatus = 3;

            }


        }


        ReturnStatus = retStatus;
        return retStatusTEXT;


    }
  


    public static string ValidateLoginStatusTEXT(string vLoginID, String vPassword, String vType)
    {
        String retStatusTEXT = "VALID"; 

        //validate the Logins . 

        CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
        DataSet ds; 

        ds = objBAL_MalaysiaSMS.ValidateLoginStatus(vLoginID, vPassword, vType);

       
        DataTable dtFreeze = ds.Tables[0];
        DataTable dtExpiry = ds.Tables[1];


        if (dtFreeze.Rows.Count > 0)
        {
            DataRow dtRow = dtFreeze.Rows[0];
            String FreezeStatusTxt =dtRow["FrzStatus"].ToString();
            int FreezeStatus = 0 ;

            if (FreezeStatusTxt.ToUpper() == "TRUE")
                FreezeStatus = 1;

            String FreezeMessage = dtRow["FrzMessage"].ToString();

            if (FreezeStatus == 1)
            {
                retStatusTEXT = FreezeMessage; 
            }
        }
        
            if (dtExpiry.Rows.Count > 0)
            {
                DataRow dtRow = dtExpiry.Rows[0];

                int MonthsLeft = Convert.ToInt16(dtRow["NoOfMonthsLEFT"].ToString());
                DateTime vExpiryDate = Convert.ToDateTime(dtRow["ExpiryDate"].ToString());


                if (MonthsLeft < 1)
                {
                    // LblNotice.Text = @"Your Account has already expired on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately. <br> Expired account will be removed from the system after 90 days";
                    // ModalPopUpExtender1.Show();
                    retStatusTEXT = @"Your Account has already expired on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". \\nPlease renew immediately."; ;

                }
                else if (MonthsLeft < 3)
                {
                    // LblNotice.Text = @"Your Account will expire on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately. <br> Expired account will be removed from the system after 90 days";
                    // ModalPopUpExtender1.Show();

                    retStatusTEXT = @"Your Account will expire on " + vExpiryDate.ToString("dddd, dd MMMM yyyy HH:mm tt") + ". Please renew immediately.";

                }


            }


        return retStatusTEXT;


    }

    public static string Encrypt(string val)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(val);
        var encBytes = System.Security.Cryptography.ProtectedData.Protect(bytes, new byte[0], System.Security.Cryptography.DataProtectionScope.LocalMachine);
        return Convert.ToBase64String(encBytes);
    }


    public static string Decrypt(string val)
    {
        var bytes = Convert.FromBase64String(val);
        var encBytes = System.Security.Cryptography.ProtectedData.Unprotect(bytes, new byte[0], System.Security.Cryptography.DataProtectionScope.LocalMachine);
        return System.Text.Encoding.UTF8.GetString(encBytes);
    }

    public static void ProceedToPalBuy(string cpFullName, string cpAmount, string cpCurrencyCode, string cpMobileNo, string cpItemName, string cpItemNumber, string cpCustomText, String cpUniqueID, string cpWebSiteName, string cpUserID, String cpCallingPageUri)
    {
        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();

        String cpSkipTAC = "TRUE";
        String tmp_cpSuccessURLTOP = cpCallingPageUri;
        String tmp_cpCancelURLTOP = cpCallingPageUri; 
        String tmp_cpFailureURLTOP = cpCallingPageUri;

        String strURL = "http://183.81.165.110/WebApps/GsPayPal/Wsp_PayPalCall.aspx";
        //String strURL = "http://gspaypal.evenchise.biz/Wsp_PayPalCall.aspx";

        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[0].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);

        // Start Collecting Parameters

        sb.AppendFormat("<input type='hidden' name='cpFullName' value='{0}'>", cpFullName);
        sb.AppendFormat("<input type='hidden' name='cpAmount' value='{0}'>", cpAmount);
        sb.AppendFormat("<input type='hidden' name='cpCurrencyCode' value='{0}'>", cpCurrencyCode);
        sb.AppendFormat("<input type='hidden' name='cpMobileNo' value='{0}'>", cpMobileNo);
        sb.AppendFormat("<input type='hidden' name='cpItemName' value='{0}'>", cpItemName);
        sb.AppendFormat("<input type='hidden' name='cpCustomText' value='{0}'>", cpCustomText);
        sb.AppendFormat("<input type='hidden' name='cpItemNumber' value='{0}'>", cpItemNumber);
        sb.AppendFormat("<input type='hidden' name='cpUniqueID' value='{0}'>", cpUniqueID);
        sb.AppendFormat("<input type='hidden' name='cpWebSiteName' value='{0}'>", cpWebSiteName);
        sb.AppendFormat("<input type='hidden' name='cpUserID' value='{0}'>", cpUserID);
        sb.AppendFormat("<input type='hidden' name='cpSuccessURL' value='{0}'>", tmp_cpSuccessURLTOP);
        sb.AppendFormat("<input type='hidden' name='cpCancelURL' value='{0}'>", tmp_cpCancelURLTOP);
        sb.AppendFormat("<input type='hidden' name='cpFailureURL' value='{0}'>", tmp_cpFailureURLTOP);
        sb.AppendFormat("<input type='hidden' name='cpSkipTAC' value='{0}'>", cpSkipTAC);

        // End

        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }


    public static void ProceedToPalBuyMerchant(String cpBusinessEmail, string cpFullName, string cpMobileNo, string cpBuyerEmail, string cpAmount, string cpCurrencyCode, string cpItemName, string cpItemNumber, string cpCustomText, string cpWebSiteName, string cpUserID, String cpCallingPageUri)
    {
        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();

        String cpSkipTAC = "TRUE";
        //String tmpSourceUrl = "http://183.81.165.110/WebApps/GsPayPal";
        //String tmpSourceUrl = "http://www." + cpWebSiteName; 
        String tmpSourceUrl = cpWebSiteName;

        //String tmp_cpSuccessURLTOP = "http://210.5.45.8/eBooksBuyPPsuccess.aspx";
        String tmp_cpSuccessURLTOP = tmpSourceUrl + "/eBooksBuyPPsuccess.aspx";


        String tmp_cpCancelURLTOP = cpCallingPageUri;
        //String tmp_cpFailureURLTOP = "http://210.5.45.8/eBooksBuyPPFailed.aspx";
        String tmp_cpFailureURLTOP = tmpSourceUrl + "/eBooksBuyPPFailed.aspx";

        Random rand = new Random((int)DateTime.Now.Ticks);
        int vUnique = 0;
        vUnique = rand.Next(1, 500000);

        String cpUniqueID = cpUserID + vUnique.ToString();

       // cpBusinessEmail = "lohchuenleong@gmail.com";
       // cpAmount = "1.50"; 

        //String strURL = "http://183.81.165.110/WebApps/GsPayPal/Eb_PayPalCall.aspx";
        String strURL = "http://gspaypal.evenchise.biz/Eb_PayPalCall.aspx";

        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[0].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);

        // Start Collecting Parameters

        sb.AppendFormat("<input type='hidden' name='cpFullName' value='{0}'>", cpFullName);
        sb.AppendFormat("<input type='hidden' name='cpMobileNo' value='{0}'>", cpMobileNo);
        sb.AppendFormat("<input type='hidden' name='cpBuyerEmail' value='{0}'>", cpBuyerEmail);

        sb.AppendFormat("<input type='hidden' name='cpAmount' value='{0}'>", cpAmount);
        sb.AppendFormat("<input type='hidden' name='cpCurrencyCode' value='{0}'>", cpCurrencyCode);

        sb.AppendFormat("<input type='hidden' name='cpItemName' value='{0}'>", cpItemName);
        sb.AppendFormat("<input type='hidden' name='cpItemNumber' value='{0}'>", cpItemNumber);

        sb.AppendFormat("<input type='hidden' name='cpUniqueID' value='{0}'>", cpUniqueID);
        
        sb.AppendFormat("<input type='hidden' name='cpWebSiteName' value='{0}'>", cpWebSiteName);
        sb.AppendFormat("<input type='hidden' name='cpUserID' value='{0}'>", cpUserID);
        sb.AppendFormat("<input type='hidden' name='cpCustomText' value='{0}'>", cpCustomText);

        sb.AppendFormat("<input type='hidden' name='cpSuccessURL' value='{0}'>", tmp_cpSuccessURLTOP);
        sb.AppendFormat("<input type='hidden' name='cpCancelURL' value='{0}'>", tmp_cpCancelURLTOP);
        sb.AppendFormat("<input type='hidden' name='cpFailureURL' value='{0}'>", tmp_cpFailureURLTOP);

        sb.AppendFormat("<input type='hidden' name='cpBusinessEmail' value='{0}'>", cpBusinessEmail);
        sb.AppendFormat("<input type='hidden' name='cpSkipTAC' value='{0}'>", cpSkipTAC);

        // End

        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }


  
    public static void ConfirmPayPalBuy(String cpBookID, string cpUserID, String cpCallingPageUri)
    {

        //String strURL = "eBooksBuyPP.aspx";
        //String sURL = String.Empty;

        //sURL = strURL + "?qBookID=" + cpBookID + "&qUserID=" + cpUserID + "&qCallingPage=" + HttpContext.Current.Server.UrlEncode(cpCallingPageUri);
     
       // HttpContext.Current.Response.Redirect(HttpContext.Current.Server.UrlEncode(sURL)); 


        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();


        String strURL = "eBooksBuyPP.aspx";

        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[0].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);

        // Start Collecting Parameters

        sb.AppendFormat("<input type='hidden' name='qBookID' value='{0}'>", cpBookID);
        sb.AppendFormat("<input type='hidden' name='qUserID' value='{0}'>", cpUserID);
        sb.AppendFormat("<input type='hidden' name='qCallingPage' value='{0}'>", cpCallingPageUri);

        // End

        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }


    /// <summary> 
    /// This function is to assemble SQL Syntax for starts with String Search
    /// </summary> 

    public static string StartsWithSearchString(String strSearchItem, String strSearchVal)
    {
        string strSQL = string.Empty;
        try
        {
            strSQL = " and " + strSearchItem + " LIKE '" + strSearchVal.Replace("'", "''") + "%'";
        }
        catch (FormatException e)
        {
            strSQL = e.Message;
        }
        return strSQL;
    }

    /// <summary> 
    /// This function is to assemble SQL Syntax for exact String Search
    /// </summary> 

    public static string ExactSearchString(String strSearchItem, String strSearchVal)
    {
        string strSQL = string.Empty;
        try
        {
            strSQL = " and " + strSearchItem + " LIKE '" + strSearchVal.Replace("'", "''") + "'";
        }
        catch (FormatException e)
        {
            strSQL = e.Message;
        }
        return strSQL;
    }

    /// <summary> 
    /// This function is to assemble SQL Syntax for exact String Search
    /// </summary> 

    public static string AnySearchString(String strSearchItem, String strSearchVal)
    {
        string strSQL = string.Empty;
        try
        {
            strSQL = " and (" + strSearchItem + " LIKE '%" + strSearchVal.Replace("'", "''") + "%'";
            strSQL = strSQL + " OR " + strSearchItem + " LIKE '%" + strSearchVal.Replace("'", "''") + "'";
            strSQL = strSQL + " OR " + strSearchItem + " LIKE '" + strSearchVal.Replace("'", "''") + "%') ";
        }
        catch (FormatException e)
        {
            strSQL = e.Message;
        }
        return strSQL;
    }

    /// <summary> 
    /// This function is to validate Date.
    /// </summary> 

    public static bool isValidDate(object strDate)
    {
        bool Success;
        try
        {
            DateTime dtParse = DateTime.Parse(strDate.ToString());
            Success = true; // If this line is reached, no exception was thrown
        }
        catch (FormatException e)
        {
            string s = e.Message;
            Success = false; // If this line is reached, an exception was thrown
        }
        return Success;
    }

    /// <summary> 
    /// This function is to decode SMS message
    /// </summary> 

    public static string decodeSMSMessage(String strMsg)
    {
        string strNewMsg = string.Empty;
        try
        {
            strMsg = strMsg.Replace("^*^", "'");
            strMsg = strMsg.Replace("&amp;", "&");
            strMsg = strMsg.Replace("???", "+");
            strMsg = strMsg.Replace("\r\n", "<br>");
            //strMsg = strMsg.Replace("\r\n", "<br/>");
            strNewMsg = strMsg;
            // vbCr = "\r"  //vbLf = "\n" //vbCrLf = "\r\n"
        }
        catch (FormatException e)
        {
            strNewMsg = e.Message;
        }
        return strNewMsg;
    }

    /// <summary> 
    /// This function is to validate hexadecimal bytes, if true convert to string
    /// </summary>

    public static string ConvertHexBytesToString(String strMsg)
    {
        Regex r = new Regex(@"^[0-9A-F\r\n]+$");
        String strNewMsg = strMsg;
        bool success = r.Match(strNewMsg).Success;

        try
        {
            if (success)
            {
                int numberChars = strMsg.Length;
                byte[] bytes = new byte[numberChars / 2];
                for (int i = 0; i < numberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(strMsg.Substring(i, 2), 16);
                }
                strNewMsg = Encoding.Unicode.GetString(bytes);
            }
        }
        catch (FormatException e)
        {
            strNewMsg = e.Message;
        }
        return strNewMsg;
    }

    public static string GetClientIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }


    /// <summary> 
    /// This function is to format string to Response Code Savings
    /// </summary> 

    public static string ConvertToPlainText(string str)
    {
        char[] charArr = str.ToCharArray();
        String strUniCode = String.Empty;

        try
        {
            foreach (char ch in charArr)
            {
                const int MaxAnsiCode = 255;
                int charAnsii = Convert.ToInt32(ch);

                if (charAnsii > MaxAnsiCode)
                {
                    if ((charAnsii == 8216) || (charAnsii == 8217))
                    {
                        strUniCode = strUniCode + "'";
                    }
                    else if ((charAnsii == 8220) || (charAnsii == 8221))
                    {
                        strUniCode = strUniCode + "''";
                    }
                    else
                    {
                        strUniCode = strUniCode + ch;
                    }
                }
                else if (charAnsii == 34)
                {
                    strUniCode = strUniCode + "''";
                }
                else if (charAnsii == 39)
                {
                    strUniCode = strUniCode + "'";
                }
                else
                {
                    strUniCode = strUniCode + ch;
                }
            }
        }
        catch (FormatException e)
        {
            strUniCode = e.Message;
        }
        return strUniCode;
    }



    /// <summary> 
    /// This function is to detect uniCode message
    /// </summary> 

    public static bool IsUnicode(string strMsg)
    {
        const int MaxAnsiCode = 255;
        string strNewMsg = string.Empty;
        bool Success;

        try
        {
            Success = strMsg.ToCharArray().Any(c => c > MaxAnsiCode); // If this line is reached, no exception was thrown
        }
        catch (FormatException e)
        {
            string s = e.Message;
            Success = false; // If this line is reached, an exception was thrown
        }
        return Success;
    }



    /// <summary> 
    /// This function is to format string to ASCII HTML .
    /// </summary> 

    public static string ConvertToAscii(string str)
    {
        char[] charArr = str.ToCharArray();
        String strUniCode = String.Empty;

        try
        {
            foreach (char ch in charArr)
            {
                const int MaxAnsiCode = 255;
                int charAnsii = Convert.ToInt32(ch);

                if (charAnsii > MaxAnsiCode)
                {
                    strUniCode = strUniCode + "&#" + charAnsii + ";";
                }
                else
                {
                    strUniCode = strUniCode + ch;
                }
            }
        }
        catch (FormatException e)
        {
            strUniCode = e.Message;
        }
        return strUniCode;
    }


    
    /// <summary> 
    /// This function is to display message in TextBox
    /// </summary> 

    public static string TextBoxSMSMessage(String strMsg)
    {
        string strNewMsg = string.Empty;
        try
        {
            strMsg = strMsg.Replace("^*^", "'");
            strMsg = strMsg.Replace("&amp;", "&");
            strMsg = strMsg.Replace("???", "+");
            strNewMsg = strMsg;
            // vbCr = "\r"  //vbLf = "\n" //vbCrLf = "\r\n"
        }
        catch (FormatException e)
        {
            strNewMsg = e.Message;
        }
        return strNewMsg;
    }



    public static void AddItemtoCart(string vCustomStr, string vCallingUri)
    {
        string[] BookInfo = vCustomStr.Split('#');

        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String vImageURL = string.Empty;
        String CallingPageUri = vCallingUri;

        CMSv3.Entities.CartItems objItems = new CMSv3.Entities.CartItems();

        foreach (string part in BookInfo)
        {
            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
            vImageURL = BookInfo[3].ToString();

            objItems.BookID = vBookID;
            objItems.BookName = vBookName;
            objItems.Price = Convert.ToDecimal(vBookPrice);
            objItems.ImageURL = vImageURL;


            ShoppingCart.AddCartItem(objItems);
            System.Threading.Thread.Sleep(500);
            // UpdatePanel1.Update(); 
            HttpContext.Current.Response.Redirect("eBooksViewCart.aspx?CpUri=" + vCallingUri);
        }
    }

    public static void AddItemtoCartNew(string vCustomStr, string vCallingUri)
    {
        string[] BookInfo = vCustomStr.Split('#');

        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String vImageURL = string.Empty;
        String CallingPageUri = vCallingUri;

        CMSv3.Entities.CartItems objItems = new CMSv3.Entities.CartItems();

        foreach (string part in BookInfo)
        {
            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
            vImageURL = BookInfo[3].ToString();

            objItems.BookID = vBookID;
            objItems.BookName = vBookName;
            objItems.Price = Convert.ToDecimal(vBookPrice);
            objItems.ImageURL = vImageURL;


            ShoppingCart.AddCartItem(objItems);
            System.Threading.Thread.Sleep(500);
            // UpdatePanel1.Update(); 
            HttpContext.Current.Response.Redirect("O_dtCart.aspx?CpUri=" + vCallingUri);

        }
    }

    public static void AddItemtoCartNewOne(string vCustomStr, string vCallingUri)
    {
        string[] BookInfo = vCustomStr.Split('#');

        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String vImageURL = string.Empty;
        String CallingPageUri = vCallingUri;

        CMSv3.Entities.CartItems objItems = new CMSv3.Entities.CartItems();

        foreach (string part in BookInfo)
        {
            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
            vImageURL = BookInfo[3].ToString();

            objItems.BookID = vBookID;
            objItems.BookName = vBookName;
            objItems.Price = Convert.ToDecimal(vBookPrice);
            objItems.ImageURL = vImageURL;


            ShoppingCart.AddCartItem(objItems);
            System.Threading.Thread.Sleep(500);
            // UpdatePanel1.Update(); 
            HttpContext.Current.Response.Redirect("N_Cart.aspx?CpUri=" + vCallingUri);

        }
    }


 }
