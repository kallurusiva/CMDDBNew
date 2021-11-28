using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SA_SessionExpire : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //ScriptManager.RegisterStartupScript(this, GetType(), "SessionExpired", "alert(' Your Session has expired\nPlease login again.');", true);
    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "SessionExpired", "alert(' Your Session has expired\nPlease login again.');", true);
        //Response.Redirect("~/Template3.aspx?timeout=yes");
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "SessionEx", "ShowPopup();",true);
       // Response.Redirect("~/Template3.aspx");

    }
}
