using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Admin_EmailMkt_EbAd_UnSubscribeEmail : System.Web.UI.Page
{
    CMSv3.DAL.eBook objEbook = new CMSv3.DAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {     
        if (Request.QueryString.Count > 1)
        { 
            if(Request.QueryString["qID"]!=null)
            {
                if (Request.QueryString["qEmail"] != "@EMAILUNSUBSCRIBE@")
                {
                    Insert_UnSubscribedEmail();
                }
            }
        }
    }
    protected void Insert_UnSubscribedEmail()
    {
        String qID = Request.QueryString["qID"].ToString();
        String qEBookID = Request.QueryString["qEBookID"].ToString();
        String qEmail = Request.QueryString["qEmail"].ToString();

        int tmpStatus = objEbook.Insert_UnSubscribedEmail(qID, qEBookID, qEmail);
        StringBuilder sb = new StringBuilder();

        if (tmpStatus == 1)
        {           

            sb.Append("<script language='javascript' type='text/javascript'>");
            sb.Append("if (window.confirm('You will no longer receiving email.Thank you.Close window now?'))");
            sb.Append("{window.close();}");
            sb.Append("</script>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        else if (tmpStatus == -1)
        {

            sb.Append("<script language='javascript' type='text/javascript'>");
            sb.Append("if (window.confirm('Your Email is already unsubscribed.Thank you.Close window now?'))");
            sb.Append("{window.close();}");
            sb.Append("</script>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
    
}
