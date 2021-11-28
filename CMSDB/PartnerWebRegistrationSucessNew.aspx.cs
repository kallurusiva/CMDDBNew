using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using CMSv3.Entities;

public partial class PartnerWebRegistrationSucessNew : System.Web.UI.Page
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {


        #region -- Rendering Top Left Panel --
        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
        sb.Append("<tr>");
        sb.Append("<td align='left' valign='top'>");
        sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        dvBannerLeftPanel.InnerHtml = sb.ToString();
        #endregion


       Page.MaintainScrollPositionOnPostBack = true;


        if (!IsPostBack)
        {
            string vDomainName = string.Empty;

            if ((Request.QueryString["regDomainName"] != null) && (Request.QueryString["regDomainName"] != ""))
            {
                vDomainName = Request.QueryString["regDomainName"].ToString();

            }
            else
            {
         //       Response.Redirect("PartnerWebRegistrationNew.aspx");
            }


            LoadDomainRegDetails(vDomainName);



        }

    }

    protected void LoadDomainRegDetails(string vDomainName)
    {
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);


        strSQL = "Select RegisteredPin,LoginID,LoginPassword, SubDomain, FullName,Country,HandPhone, Email,CountryName " +
                 "From tblUsers U " +
                 "INNER JOIN tblUserDetails UD on U.UserId = UD.UserID " +
                 "INNER JOIN tblCountry C on C.CountryCode = UD.Country " +
                 " Where LoginID  ='" + vDomainName + "'";

        dbConn.Open();
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                txtPinNo.Text = dbReader["RegisteredPin"].ToString();
                txtSubDomainName.Text = dbReader["SubDomain"].ToString();
                txtloginPassword.Text = dbReader["LoginPassword"].ToString();
                txtName.Text = dbReader["Fullname"].ToString();
                txtEmail.Text = dbReader["Email"].ToString();
                txtCountryName.Text = dbReader["CountryName"].ToString();
                string tmpURLSudDomain = dbReader["SubDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;

                lblInstantSubdomainName.Text = @"<a target='_blank' class='links_DomainName' href='http://" + tmpURLSudDomain + "'>" + tmpURLSudDomain + "</a>";
                

            }
        }
        else
        {

        }





    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {

        bool LoginStatus = false;

        //string selectedLanguage;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        string mUserName = txtLoginID.Text;
        string mPassword = txtPassword.Text;

        //try
        //{
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



        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
        //finally
        //{

        //}

        if (LoginStatus)
            Response.Redirect("~/Admin/Ad_Welcome.aspx");
        //Server.Transfer("~/Admin/Welcome.aspx");


    }

}

