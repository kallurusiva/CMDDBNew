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

public partial class SuperAdmin_SAlogin : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL = string.Empty;
    //string selectedLanguage;


    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSign_Click(object sender, EventArgs e)
    {

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        string mUserName = txtUserName.Text;
        string mPassword = txtPassword.Text;

        try
        {
            strSQL = "Select UserID,LoginID,UserType from tblUsers where UserType = 2 and  LoginID='" + mUserName + "' and LoginPassword='" + mPassword + "'";

            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    Session["saUserID"] = dbReader["UserID"].ToString();
                    Session["saLoginID"] = dbReader["LoginID"].ToString();
                    //Session["SAdefLanguage"] = ddlLang.SelectedValue;
                    //lblErrMessage.Text = "User Sucessfully Logged IN ";
                    //selectedLanguage = Session["SAdefLanguage"].ToString();
                    //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                    //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

                    //string PgtoStart = ConfigurationManager.AppSettings["StartPage"].ToString();
                    //if (PgtoStart != "" && PgtoStart != null)
                    //    Response.Redirect(PgtoStart);
                    //else
                    Response.Redirect("SA_HomePage.aspx");
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
