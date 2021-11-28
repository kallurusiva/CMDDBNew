using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Text;
using CMSv3.Entities;

public partial class ViewUserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Hashtable ht = (Hashtable)Application["SESSION_LIST"];
        IDictionaryEnumerator en = ht.GetEnumerator();
        StringBuilder sb = new StringBuilder();

        sb.Append("<table width=\"100%\" align=\"center\" border=\"1\"");
        sb.Append(" bordercolor=\"silver\"");
        sb.Append("cellpadding=\"2\"><tr style=\"background-color:#CCDDEE;\"><td>");
        sb.Append("Current Sessions</td><td>Total Sessions Since Reboot</td>");
        sb.Append("<td>Application Reboot Time</td></tr>");
        sb.Append("<tr><td>").Append(ht.Count).Append("</td><td>");
        sb.Append(Application["TOTAL_SESSIONS"]).Append("</td><td>");
        sb.Append(Application["APP_START_TIME"].ToString().Replace('/', '-'));
        sb.Append("</td></tr>");
        sb.Append("</table>");

        sb.Append("<p align=\"center\">Active Sessions</p>");

        while (en.MoveNext())
        {
            HttpSessionState session = (HttpSessionState)en.Value;
            if (session != null)
            {

                LoggedUserInfo user = (LoggedUserInfo)session["USER_INFO_MAP"];
                string urlReferrer = user.urlReferrer;
                string hostAddress = user.hostAddress;
                string hostName = user.hostName;
                string userAgent = user.userAgent;

                if (urlReferrer == null)
                {
                    urlReferrer = "Bookmark";
                }

                if (hostAddress == null)
                {
                    hostAddress = " ";
                }

                if (hostName == null)
                {
                    hostName = " ";
                }

                if (userAgent == null)
                {
                    userAgent = " ";
                }

                sb.Append("<table width=\"100%\" align=\"center\" border=\"1\"");
                sb.Append(" bordercolor=\"silver\"");
                sb.Append("cellpadding=\"2\"><tr style=\"background-color:#CCDDEE;\"><td>");
                sb.Append("SessionID</td>");
                sb.Append("<td>Host Address</td><td>Host Name</td>");
                sb.Append("<td>Page View Count</td></tr>");
                sb.Append("<tr><td>").Append(session.SessionID.ToUpper());
                sb.Append("</td><td>");
                sb.Append(hostAddress).Append("</td><td>");
                sb.Append(hostName).Append("</td><td>");
                sb.Append(user.urlViews.Count).Append("</td></tr>");

                sb.Append("<tr style=\"background-color:#CCDDEE;\"><td colspan=\"2\">");
                sb.Append("URL Referrer</td>");
                sb.Append("<td colspan=\"2\">User Browser</td></tr><tr><td colspan=\"2\">");
                sb.Append(urlReferrer).Append("</td><td colspan=\"2\">").Append(userAgent);
                sb.Append("</td></tr>");

                sb.Append("<tr style=\"background-color:#CCDDEE;\"><td colspan=\"4\">");
                sb.Append("Pages Viewed</td></tr><tr><td colspan=\"4\">");

                if (user.urlViews.Count > 0)
                {
                    int i = 1;
                    foreach (string url in user.urlViews)
                    {
                        sb.Append(i).Append(". ");
                        sb.Append(url).Append("<br>");
                        i++;
                    }
                }
                else
                {
                    sb.Append(" ");
                }

                sb.Append("</td></tr>");
                sb.Append("<tr><td>LoggedIn UserID</td>");
                sb.Append("<td>").Append(user.LoginUserID);
                sb.Append("</td></tr>");
                sb.Append("</td></tr></table><br>");

            }
        }
        
        this.Label.Text = sb.ToString();
    }
}
