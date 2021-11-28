using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Default_OLD : System.Web.UI.Page
{

    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    string strSQL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSign_Click(object sender, EventArgs e)
    {
        //dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        //string mUserName = txtUserName.Text;
        //string mPassword = txtPassword.Text;

        //try
        //{
        //    strSQL = "Select UserID,LoginID,UserType from tblUsers where LoginID='" + mUserName + "' and LoginPassword='" + mPassword + "'";

        //    dbConn.Open();
        //    dbCmd = new SqlCommand(strSQL, dbConn);
        //    dbReader = dbCmd.ExecuteReader();

        //    if (dbReader.HasRows)
        //    {
        //        while (dbReader.Read())
        //        {
        //            Session["UserID"] = dbReader["UserID"].ToString();
        //            Session["LoginID"] = dbReader["LoginID"].ToString();
        //            //lblErrMessage.Text = "User Sucessfully Logged IN ";

        //            Response.Redirect("Welcome.aspx");
        //        }
        //    }
        //    else
        //    {
        //        lblErrMessage.Text = "Invalid Login..  Retry again..";
        //    }



        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
        //finally
        //{

        //}
    }
}
