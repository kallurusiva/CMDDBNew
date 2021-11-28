using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

public partial class _DefaultOld : System.Web.UI.Page
{
    //string selectedLanguage;
    //string servername;

    protected void Page_Load(object sender, EventArgs e)
    {


        //Session["UserID"] = dbReader["UserID"].ToString();
        //Session["LoginID"] = dbReader["LoginID"].ToString();
        //Session["defLanguage"] = ddlLang.SelectedValue;

        ////Session["UserID"] = "104";
        ////Session["LoginID"] = "demo";
        //////Session["defLanguage"] = "en-US";
        
        ////servername = Request.ServerVariables["SERVER_NAME"];

        ////if (servername.Contains("egypt"))
        ////{
        ////    Session["defLanguage"] = "ms-MY";
        ////}
        ////else
        ////{
        ////    Session["defLanguage"] = "en-US";
        ////}
        

        //////lblErrMessage.Text = "User Sucessfully Logged IN ";
        ////selectedLanguage = Session["defLanguage"].ToString();
        ////Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        ////Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
        ////Response.Redirect("~/Admin/NewsCreate.aspx");

        ////Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        ////Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
        
        //Server.Transfer("~/Admin/Default2.aspx");
        //if (Request.QueryString["timeout"] != null)
        //{
        //    if (Request.QueryString["timeout"] == "yes")
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SessionExpired", "alert(' Your Session has expired\nPlease login again.')", true);
        //    }
        //}
        

        Session.Timeout = 60;
        //Response.Redirect("~/SessionExpire.aspx");
        Response.Redirect("~/Template3.aspx");

        //Server.Transfer("~/Template3.aspx");



    }
}
