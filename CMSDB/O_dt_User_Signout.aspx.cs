using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class O_dt_User_Signout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("cLogin");
        Session.Remove("navcheckout");
        Response.Redirect(@"O_dtList.aspx");
    }
}