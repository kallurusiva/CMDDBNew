using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Merchantlogout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string returnURL = string.Empty;

        //if (Session["referringURL"] != null)
        //{
        //    returnURL = "http://" + Session["referringURL"].ToString();
        //    if (returnURL != "")
        //    {
        //        Session.Abandon();
        //        Session.RemoveAll();
        //        Session.Clear();
        //        Response.Redirect(returnURL); 
        //    }
        //}



        Session.Abandon();
        Session.RemoveAll();
        Session.Clear();



        Session["UserID"] = string.Empty;
        Session["LoginID"] = string.Empty;
        Session["MobileLoginID"] = string.Empty;
        Session["UserDomainType"] = string.Empty;
        Session["LoggedInFrom"] = string.Empty;

        //Server.Transfer("Default2.aspx");        

        //Page.SmartNavigation = false;


        if (Session["referringURL"] != null)
        {

            Response.Write(Session["referringURL"].ToString());
        }
        else
        {
            Response.Redirect("http://www.merchantlogin.club");
        }

        //Server.Transfer("~/Default.aspx");
    }
}
