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
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;


public partial class AdminSendBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String vUserName = Request.Form["vname"];
        String vMobileNo = Request.Form["mobile"];
        String vBuyerEmail = Request.Form["email"];
        String vBookID = Request.Form["BookCode"];
        string QKeyword = Request.Form["storeid"];
        string bPassword = vMobileNo + vUserName;
        bPassword = bPassword.Replace(" ", "");
        if (bPassword.Length > 19) { bPassword = bPassword.Substring(0, 20).ToLower(); }
        EBookEmailCentral.getTransactionDetails(vBuyerEmail, "", QKeyword, "", "", vBookID, bPassword);
    }
}