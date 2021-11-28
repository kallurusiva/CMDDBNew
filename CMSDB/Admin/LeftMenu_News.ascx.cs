using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_LeftMenu_News : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HypNewsAdd.Text = Resources.LangResources.AddNews;
        HypMyNewsListing.Text = Resources.LangResources.My + " " + Resources.LangResources.News;

       
        //if ((Session["UserDomainType"].ToString() == "SME") || (Session["UserDomainType"].ToString() == "EBOOK"))
        //{
        //    HypAdminNews.Visible = false;
        //    HypShowALL.Visible = false;

        //}
        //else
        //{
        //    HypAdminNews.Text = "Admin " + Resources.LangResources.News;
        //    HypShowALL.Text = Resources.LangResources.Showall;

        //}
    
    }
}
