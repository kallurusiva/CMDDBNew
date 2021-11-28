using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class waRedirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string t = Request.QueryString["t"].ToString();
        string m = Request.QueryString["m"].ToString();
        string msg = "";

        if (t == "1") msg = "Thank You for Purchasing EBook. My Name is ";
        if (t == "0") msg = "Thank You for Requesting FREE EBook. My Name is ";
        if (t == "2") msg = "Congratulations. You are now a Proud Owner of Digital BookStore c/w Quality EBooks. PM me for Details.";
        if (t == "4") msg = "Hi, I am keen on Numerology. Can you help me?.. Thanks. ";
        if (t == "5") msg = "Hi, Thank You for signup.";
        if (t == "6") msg = "Hi, Thank You for Numerology Telegram Bot Signup. PM me if you keen to Purchase Life Report using direct Bank In. My Name is.";
        if (t == "3") msg = "Hi ";
        if (t == "11") msg = "Hi, Jom Viral.";
        if (t == "12") msg = "Hi, Thank You for your Enquiry.";
        if (t == "13") msg = "Hi there!";
        if (t == "21") msg = "I want to Topup My MWallet to Purchase either Numerology Report or Upgrade my BookStore Package. Please provide Bank-In Details. Thanks.";
        if (t == "22") msg = "Hi Sam, I would llke to renew my account. Can u help me?.. Thank You.";
        if (t == "31") msg = "Hi " + Request.QueryString["msg"].ToString();
        if (t == "32") msg = Request.QueryString["msg"].ToString();
        string url = "https://api.whatsapp.com/send?phone=" + m.ToString() + "&text=" + msg.ToString();

        Response.Redirect(url.ToString());
    }
}