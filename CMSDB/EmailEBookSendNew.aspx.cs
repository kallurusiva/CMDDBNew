using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.IO;
using CMSv3.BAL;
using System.Net;
using System.Net.Mail;

public partial class EmailEBookSendNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString["TID"] != null)
            {
                MgMail.sndMailgunLinks(Request.QueryString["TID"].ToString(), "0", "");
            }
        }
    }
}