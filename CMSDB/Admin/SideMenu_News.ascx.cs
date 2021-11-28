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
        LtrAddNews.Text = Resources.LangResources.AddNews;
        LtrMyNews.Text = Resources.LangResources.My + " " + Resources.LangResources.News;
        
        LtrAdminNews.Text = "Admin " + Resources.LangResources.News;
        LtrShowAll.Text = Resources.LangResources.Showall;

    }
}
