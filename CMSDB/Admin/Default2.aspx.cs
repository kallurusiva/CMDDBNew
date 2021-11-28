using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using System.Configuration;


public partial class Admin_Default2 : System.Web.UI.Page
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL = string.Empty;
    string selectedLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //protected override void InitializeCulture()
    //{
    //    //retrieve culture information from session  
    //    // string culture = Convert.ToString(Session["MyCulture"]);
        


    //    //if (Request.Form["ddlLang"] != null)
    //    //{
    //    //selectedLanguage = Request.Form["ddlLang"];
    //    //selectedLanguage = "ms-MY";
    //    //selectedLanguage = "en-US";
    //    //if(Session["defLanguage"] != null)
    //    //  selectedLanguage = Session["defLanguage"].ToString();
    //    //else
    //    //    selectedLanguage = "en-US";


    //    ////UICulture = selectedLanguage;
    //    ////Culture = selectedLanguage;
    //    //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
    //    //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
    //    ////}

    //    ////call base class  
    //    //base.InitializeCulture();
    //}


    protected void btnSign_Click(object sender, EventArgs e)
    {
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        string mUserName = txtUserName.Text;
        string mPassword = txtPassword.Text;

        try
        {
            strSQL = "Select UserID,LoginID,UserType from tblUsers where UserType = 0 and  LoginID='" + mUserName + "' and LoginPassword='" + mPassword + "'";

            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    Session["UserID"] = dbReader["UserID"].ToString();
                    Session["LoginID"] = dbReader["LoginID"].ToString();
                    Session["defLanguage"] = ddlLang.SelectedValue;
                    //lblErrMessage.Text = "User Sucessfully Logged IN ";
                    selectedLanguage = Session["defLanguage"].ToString();
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

                    string PgtoStart = ConfigurationManager.AppSettings["StartPage"].ToString();
                    if (PgtoStart != "" && PgtoStart != null)
                        Response.Redirect(PgtoStart);
                    else
                        Response.Redirect("Ad_Welcome.aspx");
                }
            }
            else
            {
                lblErrMessage.Text = "Invalid Login..  Retry again..";
            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {

        }
    }
}
