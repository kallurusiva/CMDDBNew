using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdmin_SA_SideMenu_Faq : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrManageFAQ.Text = Resources.LangResources.ManageFaq;
        LtrAddFAQ.Text = Resources.LangResources.AddFaq;
        LtrFaqListing.Text = Resources.LangResources.Faq + " " + Resources.LangResources.Listing;

    }
}
