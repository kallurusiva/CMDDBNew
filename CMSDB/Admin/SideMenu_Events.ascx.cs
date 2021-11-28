using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminSideMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        LtrAddEvents.Text = Resources.LangResources.AddEvents;
        LtrMyEvents.Text = Resources.LangResources.My + " " + Resources.LangResources.Events;
        LtrAdminEvents.Text = "Admin " + Resources.LangResources.Events;
        LtrShowAll.Text = Resources.LangResources.Showall;

    }
}
