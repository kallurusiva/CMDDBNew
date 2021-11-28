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


public partial class UserEvents : UserWeb
{

    CMSv3.BAL.Events objBL_Events = new CMSv3.BAL.Events();
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

       

        #region // rendering top left panel 
        //HtmlGenericControl myDivObject;
        //myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        ////myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
        //myDivObject.InnerHtml = "<img alt='imbnLeftimg' src='Images/faq_head.jpg' />";


        if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet")) 
        {

            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

            //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
            sb.Append("<tr>");
            sb.Append("<td align='left' valign='top'>");
            sb.Append("<img src='Images/table_top_Leftarc.gif' />");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<img alt='imbnLeftimg' src='Images/event_head.jpg' />");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            myDivObject.InnerHtml = sb.ToString();
        }
        #endregion


        //Literal LtrEvents = (Literal)Page.FindControl("LtrEvents");
        //if (LtrEvents != null)
        //    LtrEvents.Text = Resources.LangResources.Events;

        

        ltrEvents.Text = Resources.LangResources.Events;
        LtrEventH.Text = Resources.LangResources.Events;

        if (!IsPostBack)
        {

            LoadEvents();
            
        }


    }


    protected void LoadEvents()
    {

        ds = objBL_Events.User_GETAll_Events_ByUserID(Convert.ToInt32(Session["ClientID"]));
        //ds = objBL_faq.User_GETAllFaq_ByUserID(Convert.ToInt32(Session["ClientID"]));
        
        rpFaqList.DataSource = ds;
        rpFaqList.DataBind();


    }

}



