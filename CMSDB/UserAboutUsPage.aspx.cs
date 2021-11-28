using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CMSv3.Entities;


public partial class UserAboutUsPage : UserWeb
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    //DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        #region Language Resources

        ltrAboutUs1.Text = Resources.LangResources.AboutUs;
        ltrAboutUsLeft.Text = Resources.LangResources.AboutUs;
        #endregion 

        #region -- Rendering Top Left Panel --

        if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet")) 
        {
            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

            //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
            if (myDivObject != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>");
                sb.Append("<img src='Images/table_top_Leftarc.gif' />");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<img alt='imbnLeftimg' src='Images/AboutUs_head.jpg' />");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                myDivObject.InnerHtml = sb.ToString();
            }
        }
        #endregion

        if (!IsPostBack)
        {
            LoadUserContactDetails();
        }

    }

    protected void LoadUserContactDetails()
    {

        //string strSQL = "EXEC [usp_USER_AboutUs_GET_ByUserID] " + Convert.ToInt32(GlobalVar.GetTestLoginUser);
        string strSQL = "EXEC [usp_USER_AboutUs_GET_ByUserID] " + Convert.ToInt32(Session["ClientID"]);


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
                   
                    string tmpAboutUsDesc = dbReader["Description"].ToString();
                    tmpAboutUsDesc = tmpAboutUsDesc.Replace(Environment.NewLine, "<br/>");
                    ltrAboutUsDescription.Text = tmpAboutUsDesc;
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


    }

   
}
