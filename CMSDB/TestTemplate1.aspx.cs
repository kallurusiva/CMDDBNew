using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.Data;
using System.Xml;

public partial class TestTemplate1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        #region // rendering top left panel
        //HtmlGenericControl myDivObject;
        //myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        ////myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
        //myDivObject.InnerHtml = "<img alt='imbnLeftimg' src='Images/faq_head.jpg' />";

        HtmlGenericControl myDivObject;
        myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
        sb.Append("<tr>");
        //sb.Append("<td align='left' valign='top'>");
        //sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        //sb.Append("</td>");
        sb.Append("<td>");
        sb.Append("<img alt='imbnLeftimg' src='Images/event_head.jpg' />");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        myDivObject.InnerHtml = sb.ToString();

        #endregion



       

        string IP1 = Request.ServerVariables["REMOTE_HOST"].ToString();
        Response.Write("1: " + IP1 + "<br/>");
        string IP2 = Request.UserHostName;
        Response.Write("2: " + IP2 + "<br/>");


        //String IP3 = GetUserIP();
        //Response.Write("3: " + IP3 + "<br/>");


        //DataTable dt = GetLocation(IP3);


        //foreach(DataRow dr in dt.Rows)
        //{

        //   foreach(DataColumn dc in dt.Columns)
        //   {
        //       if (dr[dc] != null)
        //       {
        //           Response.Write(dr[dc].ToString() + "<br/>"); 

        //       }


        //   }
        //}


    }


    private DataTable GetLocation(string ipaddress)
    {
        //Create a WebRequest
        WebRequest rssReq = WebRequest.Create("http://freegeoip.appspot.com/xml/" + ipaddress);
        //Create a Proxy
        WebProxy px = new WebProxy("http://freegeoip.appspot.com/xml/" + ipaddress, true);
        //Assign the proxy to the WebRequest
        rssReq.Proxy = px;
        //Set the timeout in Seconds for the WebRequest
        rssReq.Timeout = 2000;
        try
        {
            //Get the WebResponse
            WebResponse rep = rssReq.GetResponse();
            //Read the Response in a XMLTextReader
            XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());
            //Create a new DataSet
            DataSet ds = new DataSet();
            //Read the Response into the DataSet
            ds.ReadXml(xtr);
            return ds.Tables[0];
        }
        catch
        {
            return null;
        }
    }



    private string GetUserIP()
    {
        string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipList))
        {
            return ipList.Split(',')[0];
        }

        return Request.ServerVariables["REMOTE_ADDR"];
    }



}
