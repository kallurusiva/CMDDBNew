using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using System.IO;

public partial class Training : System.Web.UI.Page
{
    //int tmpStatus = 0;
    DataSet ds;
    //SqlDataAdapter dbAdap;
    //bool isDEPUser = false;
    String strLoginFrom = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String tLoginID = txtLoginID.Text.ToString();
        String tPwd = txtPwd.Text.ToString();
        //string tLang = txtLanguage.SelectedItem.Value.ToString();
        string tLang = "1";

        tLoginID = tLoginID.Replace(",", "");
        tPwd = tPwd.Replace(",", "");

        String LoginMobileNumber = string.Empty;
        LoginMobileNumber = "";
        String vUserID = string.Empty;
        vUserID = "";
        string vPackage = string.Empty;
        vPackage = "";

        newDBS objNewDB = new newDBS();
        ds = objNewDB.Training_validateLogin(tLoginID, tPwd);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            LoginMobileNumber = dr["validLogin"].ToString();
            vUserID = dr["vUserID"].ToString();
            vPackage = dr["vPackage"].ToString();
        }

        if (LoginMobileNumber.ToString().Trim() == "")
        {
            String vAlertMsg = "Invalid LoginID/Password";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
        }
        else
        {
            Session["UserID"] = vUserID.ToString();
            Session["vPackage"] = vPackage.ToString();
            Session["vLanguage"] = tLang.ToString();
            Session["menunav"] = "1";
            Response.Redirect("~/Training/Dashboard.aspx");
        }
    }
    
}