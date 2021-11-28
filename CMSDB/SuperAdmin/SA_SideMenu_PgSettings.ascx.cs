using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdmin_SA_SideMenu_PgSettings : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        LtrAddTopMenuLinks.Text = Resources.LangResources.AddTopMenuLinks;
        //LtrAddLogoItems.Text = Resources.LangResources.Add + " Logo Templates ";
        LtrAddWelcomePage.Text = Resources.LangResources.Add + " " + Resources.LangResources.Welcome + Resources.LangResources.Page;
        ltrAboutUsPage.Text = Resources.LangResources.Add + " " + Resources.LangResources.AboutUs;

       // LtrBannerItems.Text = Resources.LangResources.Add + " Banner Templates ";


    }
}
