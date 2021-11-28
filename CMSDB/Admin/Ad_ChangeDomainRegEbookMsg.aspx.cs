using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Ad_ChangeDomainRegEbookMsg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["t"].ToString() == "1")
        {
            lblMsg.Text="Deducted USD 40. Thank you for registering your domain. We will notify you once you domain name request is authenticated.";
        }
        if (Request.QueryString["t"].ToString() == "2")
        {
            lblMsg.Text = "You cannot Request Domain. Your latest Domain Request is still under pending. Please contact Admin for further support.";
        }
    }
}