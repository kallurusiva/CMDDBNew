using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class CustTempPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Body.Attributes.Add("onload", "SetTarget()");

        //HtmlGenericControl body =(HtmlGenericControl).FindControl("Body");
        //body.Attributes.Add("onload", "SetTarget()");



        string strLoginID = Request.QueryString["Muser"];
        string strPassword = Request.QueryString["Mpwd"];

        //http://www.1malaysiasms.com/MLMSMS/1SmsWebSite_BizMemberCheck.asp?Muser=60123280155&Mpwd=281800&txtLanguage=E

        string strURL = "http://www.1Singaporesms.com/singapore/1SMSWebSite_BizMemberCheckSGD.asp?Muser=" + strLoginID + "&Mpwd=" + strPassword;

        //ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin_Temp('" + strURL + "')</script>");



        Response.Redirect(strURL);


    }
}
