using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Xml;

public partial class InValidDomain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

 
        #region -- Rendering Top Left Panel --
        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
        sb.Append("<tr>");
        sb.Append("<td align='left' valign='top'>");
        sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        dvBannerLeftPanel.InnerHtml = sb.ToString();
        #endregion


        //txtMobileNo.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        //txtSubDomainName.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");
        //DdlCountry.Attributes.Add("onchange", "javascript:return ChangeMobileText(event)");

        Page.MaintainScrollPositionOnPostBack = true;

    }

    
    







    


}

