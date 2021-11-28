using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestServerVariables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (string var in Request.ServerVariables)
        {
            Response.Write(var + " " + Request[var] + "<br>");
        }

    }
}
