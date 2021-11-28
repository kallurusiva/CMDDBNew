using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.IO;

public partial class TestNew : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        MgMail.sndMailgunLinksRedirect("3621", "2", "kallurusiva@gmail.com");
    }

    


}