using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TmpLogout : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        Session.Clear();
        //Server.Transfer("Default2.aspx");        
        Server.Transfer("~/Default.aspx");
    }
}
