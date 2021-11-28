using System;
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


public partial class ErrorGenericPage : UserWeb 
{

    CMSv3.BAL.FAQ objBL_faq = new CMSv3.BAL.FAQ();
    //DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {

      
        #region // rendergin top left panel 
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
        sb.Append("<td align='left' valign='top'>");
        sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append("<img alt='imbnLeftimg' src='Images/faq_head.jpg' />");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        if(myDivObject != null)
        myDivObject.InnerHtml = sb.ToString();


        #endregion 

       



        string User_EmailAddress= string.Empty;
        string User_FullName = string.Empty;
        string User_LoginID = string.Empty;
        string User_LoginPassword = string.Empty;


        string tmpEmailFrom = string.Empty;
        string tmpEmailBody = string.Empty;
        string tmpEmailSubject = string.Empty;


        

        //Exception CurrentException = Server.GetLastError();
        //string ErrorDetails = CurrentException.ToString();
        //// Response.Write(ErrorDetails);

        //MyMail.CommonSendEmail("msri_hari@hotmail.com", "ErrorLog@1SmsBusiness.com", ErrorDetails, "Error At 1SmsWebSite.com - " + DateTime.Now, "Administrator", "", "");
             


        

        //try
        //{
        //    strSQL = "Select UserID from tblUsers where LoginID = '" + txtLoginID.Text + "'";
        //    dbConn.Open();
        //    dbCmd = new SqlCommand(strSQL, dbConn);

        //    string tmpUserID = Convert.ToString(dbCmd.ExecuteScalar());

        //    if (tmpUserID != "")
        //    {
        //        //if exists then retrieve Email Address and FullName

        //        strSQL = "select LoginId,LoginPassword, Email, FullName from tblUserDetails UD " +
        //                  " inner join tblUsers U ON U.UserId = UD.UserID " +
        //                  " where UD.UserID = " + Convert.ToInt32(tmpUserID);

        //        dbCmd = new SqlCommand(strSQL, dbConn);
        //        dbReader = dbCmd.ExecuteReader();

        //        if (dbReader.HasRows)
        //        {
        //            while (dbReader.Read())
        //            {
        //                User_EmailAddress = dbReader["Email"].ToString();
        //                User_FullName = dbReader["FullName"].ToString();
        //                User_LoginID = dbReader["LoginID"].ToString();
        //                User_LoginPassword = dbReader["LoginPassword"].ToString();
        //            }

        //            //Send email
        //            tmpEmailSubject = "Password details : " + GlobalVar.GetAnchorDomainName;
        //            tmpEmailFrom = "Support@" + GlobalVar.GetAnchorDomainName;
        //            tmpEmailBody = "Your login password details as follows" +
        //                           "<br/><br/>" +
        //                           "-------------------------------------<br/>" +
        //                           "Login ID : <b>" + User_LoginID + "</b> <br/>" +
        //                           "Password : <b>" + User_LoginPassword + "</b> <br/>" +
        //                           "-------------------------------------<br/>" +
        //                           "<br/><br/>";

        //            CommonFunctions.GenericSendEmail(User_EmailAddress, tmpEmailFrom, tmpEmailBody, tmpEmailSubject, User_FullName, "", "");

                   


        //        }

        //    }
        //    else
        //    {
        //        //entered login id does not exist.

               

        //    }


        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //    dbConn.Close();
        //}



    }
}



