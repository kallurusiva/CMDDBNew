using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class waRd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string t = Request.QueryString["t"].ToString();
        string m = Request.QueryString["m"].ToString();
        string n = Request.QueryString["n"].ToString();
        string msg = "";

        if (t == "1") msg = "Thank You " + n.ToString() + ". You have been subscribe to our FREE Yearly Birthday Offer.";
        if (t == "2") msg = "Happy Birthday " + n.ToString() + ". Have a Great Day.";
        string url = "https://api.whatsapp.com/send?phone=" + m.ToString() + "&text=" + msg.ToString();

        Response.Redirect(url.ToString());
    }
}