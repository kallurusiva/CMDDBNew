using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Ad_Mobi_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {



        HyperLink vHypWebPortal = (HyperLink)Page.Master.FindControl("HypWebPortal");
        vHypWebPortal.Visible = true;

    }
}
