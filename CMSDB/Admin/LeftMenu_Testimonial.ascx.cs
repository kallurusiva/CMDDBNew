using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_LeftMenu_Testimonial : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HypTestimonialAdd.Text = Resources.LangResources.AddTestimonial;
        HypMyTestimonialListing.Text = Resources.LangResources.My + " " + Resources.LangResources.Testimonial;

        //HypAdminTestimonial.Text = "Admin " + Resources.LangResources.Testimonial;
        //HypShowALL.Text = Resources.LangResources.Showall;


        //if ((Session["UserDomainType"].ToString() == "SME") || (Session["UserDomainType"].ToString() == "EBOOK"))
        //{
        //    HypAdminTestimonial.Visible = false;
        //    HypShowALL.Visible = false;

        //}
        //else
        //{
        //    HypAdminTestimonial.Text = "Admin " + Resources.LangResources.Testimonial;
        //    HypShowALL.Text = Resources.LangResources.Showall;

        //}

    }
}
