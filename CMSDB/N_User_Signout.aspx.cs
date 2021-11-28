using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_User_Signout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["cLogin"] = null;
        Session.Remove("cLogin");
        Session["navcheckout"] = null;
        Session.Remove("navcheckout");
        Response.Redirect(@"N_List.aspx");
    }
}