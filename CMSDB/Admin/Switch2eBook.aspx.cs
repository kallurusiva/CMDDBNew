using System;
using System.Collections.Generic;
using System.Configuration; 
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Switch2eBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();

        String strURL = ConfigurationManager.AppSettings["Switch2ebookURL"].ToString(); 
        //String strURL = "../../Ebook/MyPremiumLoginValidation.aspx";

        //Response.Write("testing" + "<br/>");
        //Response.Write(strURL + "<br/>");
        //Response.Write(Session["MERID"].ToString() + "<br/>");
        //Response.End(); 




        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[0].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
        //Start Collecting Parameters
        sb.AppendFormat("<input type='hidden' name='tmpMID' value='{0}'>", Session["MERID"].ToString());
        sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", Session["referringURL"].ToString());
        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.ApplicationInstance.CompleteRequest();



    }
}