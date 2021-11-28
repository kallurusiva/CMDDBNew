using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using CMSv3.BAL;
using System.Threading;
using System.Configuration;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;

public partial class verifyBuyerEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string buyerid = string.Empty;
        string k = string.Empty;

        if (Request.QueryString.Count > 0)
        {
            buyerid = "";

            if (Request.QueryString["id"] != null)
            {
                buyerid = Request.QueryString["id"].ToString();
                k = Request.QueryString["k"].ToString();
            }
        }

        newDBS ndbsR = new newDBS();
        DataSet ds = ndbsR.User_VeryEmail_Update(buyerid.ToString(),k.ToString());
        DataRow utRow1 = ds.Tables[0].Rows[0];

        string domain = utRow1["domain"].ToString();

        Response.Write("Email Verified Successfully.<br>");
        Response.Write("<a href='" + domain.ToString() + "'>Click here to go for Login</a>");

    }
}