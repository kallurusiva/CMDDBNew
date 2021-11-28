using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SessionExpireEbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //ScriptManager.RegisterStartupScript(this, GetType(), "SessionExpired", "alert(' Your Session has expired\nPlease login again.');", true);
    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "SessionExpired", "alert(' Your Session has expired\nPlease login again.');", true);
        //Response.Redirect("~/Template3.aspx?timeout=yes");

        //string arg1 = string.Empty;
        //string arg2 = string.Empty;
        //string arg3 = string.Empty;
        //arg1 = "arg1Value";
        //arg2 = "arg2Value";
        //arg3 = "arg3Value";

        //if (Session["UserID"] != null)
        //    arg1 = Session["UserID"].ToString(); 

        //Session["UserID"] = "";
        //arg2 = Session["UserID"].ToString(); 

        Session.Abandon();
        Session.Remove("UserID");
        Session.RemoveAll();
        //if (Session["UserID"] != null)
        //{
        //   Response.Write(Session["UserID"].ToString() + "|exists|");
        //    arg3 = Session["UserID"].ToString();
        //}

        //Page.ClientScript.RegisterClientScriptBlock(GetType(), "SessionEx", "ShowPopupWithArgs('" + arg1 + "','" + arg2 + "','" + arg3 + "');", true);
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "SessionEx", "ShowPopup();",true);
       // Response.Redirect("~/Template3.aspx");

    }
}
