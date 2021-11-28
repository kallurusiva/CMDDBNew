using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_LeftMenu_Events : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HypEventsAdd.Text = Resources.LangResources.AddEvents;
        HypMyEventsListing.Text = Resources.LangResources.My + " " + Resources.LangResources.Events;

        
        //HypShowALL.Text = Resources.LangResources.Showall;

        //if ((Session["UserDomainType"].ToString() == "SME") || (Session["UserDomainType"].ToString() == "EBOOK"))
        //{
        //    HypAdminEvents.Visible = false;
        //    HypShowALL.Visible = false;

        //}
        //else
        //{
        //    HypAdminEvents.Text = "Admin " + Resources.LangResources.Events;
        //    HypShowALL.Text = Resources.LangResources.Showall;

        //}
    }
}
