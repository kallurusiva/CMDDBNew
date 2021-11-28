using System;
using System.Collections.Generic;
using System.Configuration; 
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Switch2PreSmsSystem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();

        String strURL = ConfigurationManager.AppSettings["Switch2PrSMSsystemURL"].ToString(); 
        
       // String strURL = "../../HitechSMS/ValidateUserLogin_FromMyEbook.aspx";

        //Response.Write("testing" + "<br/>");
        //Response.Write(strURL + "<br/>");
        //Response.Write(Session["MERID"].ToString() + "<br/>");
        //Response.End(); 

        string strReferringURL = string.Empty;
        string strReferURLCMS = string.Empty;


        if (Session["referringURL"] != null)
            strReferringURL = Session["referringURL"].ToString();


        if (Session["ReferURLCMS"] != null)
            strReferURLCMS = Session["ReferURLCMS"].ToString(); 


        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[0].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);

        // Start Collecting Parameters
        //Response.Write(Session["Merid"].ToString());
        //Response.End();
        sb.AppendFormat("<input type='hidden' id='tmpMID' name='tmpMID' value='{0}'>", Session["Merid"].ToString());
        sb.AppendFormat("<input type='hidden' id='tmpLoginID' name='tmpLoginID' value='{0}'>", Session["LoginID"].ToString());
        sb.AppendFormat("<input type='hidden' id='tmpAccountType' name='tmpAccountType' value='{0}'>", Session["UserDomainType"].ToString());
        sb.AppendFormat("<input type='hidden' id='tmpURLCMS' name='tmpURLCMS' value='{0}'>", strReferURLCMS);
        sb.AppendFormat("<input type='hidden' id='tmpURL' name='tmpURL' value='{0}'>", strReferringURL);
        sb.AppendFormat("<input type='hidden' id='tmpSubDomain' name='tmpSubDomain' value='{0}'>", "");
        sb.AppendFormat("<input type='hidden' id='tmpPackageType' name='tmpPackageType' value='{0}'>", Session["PackageType"].ToString());

        // End

        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();



    }
}