using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SideMenu_Email : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        //ltrEmail.Text =  Resources.LangResources.Add + " Own Email";
        ltrEmailList.Text =  "Email Capture" + Resources.LangResources.Listing;
        //ltrEmailMarketing.Text = "Email Marketing";

        //HypEmailLogin.NavigateUrl = "https://webmail.opentransfer.com/horde/imp/login.php?imapuser=support@smswebsite.com";
        

    }
}
