using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_LeftMenu_Faq : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HypFaqAdd.Text = Resources.LangResources.AddFaq;
        HypMyFaqListing.Text = Resources.LangResources.My + " " + Resources.LangResources.Faq;

        //HypAdminFaq.Text = "Admin " + Resources.LangResources.Faq;
        //HypShowALL.Text = Resources.LangResources.Showall;

        //if ((Session["UserDomainType"].ToString() == "SME") || (Session["UserDomainType"].ToString() == "EBOOK"))
        //{
        //    HypAdminFaq.Visible = false;
        //    HypShowALL.Visible = false;

        //}
        //else
        //{
        //    HypAdminFaq.Text = "Admin " + Resources.LangResources.Faq;
        //    HypShowALL.Text = Resources.LangResources.Showall;

        //}


    }
}
