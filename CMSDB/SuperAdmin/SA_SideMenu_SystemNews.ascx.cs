using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdmin_SA_SideMenu_SystemNews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LtrAddNews.Text = Resources.LangResources.Add + " " + Resources.LangResources.SystemNews;
        LtrSysNews.Text = Resources.LangResources.SystemNews + " " + Resources.LangResources.Listing;
        

        //LtrAdminNews.Text = "Admin " + Resources.LangResources.News;
        //LtrShowAll.Text = Resources.LangResources.Showall;

    }
}
