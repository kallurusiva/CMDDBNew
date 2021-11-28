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
        

        LtrAddTestimonial.Text = Resources.LangResources.AddTestimonial;
        LtrMyTestimonial.Text = Resources.LangResources.My + " " + Resources.LangResources.Testimonial;
        LtrAdminTestimonial.Text = "Admin " + Resources.LangResources.Testimonial;
        LtrShowAll.Text = Resources.LangResources.Showall;
    }
}
