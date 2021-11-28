using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_LeftMenu_WebEnquiry : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //HypWebEnquiryAdd.Text = "Web Enquiry";
        HypMyWebEnquiryListing.Text = "Web Enquiry Listing" ;

        //HypAdminWebEnquiry.Text = "Admin " + Resources.LangResources.WebEnquiry;
        //HypShowALL.Text = Resources.LangResources.Showall;
    
    }
}
