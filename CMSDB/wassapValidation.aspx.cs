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

public partial class wassapValidation : System.Web.UI.Page
{
    //int tmpStatus = 0;
    DataSet ds;
    //SqlDataAdapter dbAdap;
    //bool isDEPUser = false;
    String strLoginFrom = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Form.Count > 0)
            {
                String tLoginID = Request.Form["txtLoginID"].ToString().Trim();
                String tPwd = Request.Form["txtPwd"].ToString().Trim();

                tLoginID = tLoginID.Replace(",", "");
                tPwd = tPwd.Replace(",", "");

                String LoginMobileNumber = string.Empty;
                String LoginMerID = string.Empty;
                String LoginUserID = string.Empty;

                newDBS objNewDB = new newDBS();
                ds = objNewDB.wassap_validateLogin(tLoginID, tPwd);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        LoginMobileNumber = dr["vGenMobileNo"].ToString();
                        LoginMerID = dr["vMERID"].ToString();
                        LoginUserID = dr["vUSERID"].ToString();
                    }

                    if (LoginMobileNumber.ToString().Trim() == "0")
                    {
                        String vAlertMsg = "Invalid LoginID/Password";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
                        Response.Write("Invalid LoginID/Password");
                    }
                    else
                    {
                        Session["UserID"] = LoginUserID.ToString();
                        Session["LoginID"] = tLoginID.ToString();
                        Session["MobileLoginID"] = LoginMobileNumber.ToString();
                        Session["MERID"] = LoginMerID.ToString();
                        Session["LoggedInFrom"] = tLoginID;
                        Session["menunav"] = "1";
                        Response.Redirect("~/Wassap/W_Dashboard.aspx");
                    }
            }
        }
    }  

}

