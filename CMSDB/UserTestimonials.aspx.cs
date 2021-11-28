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


public partial class UserTestimonials : UserWeb
{

    CMSv3.BAL.Testimonial objBL_Testimonial = new CMSv3.BAL.Testimonial();
    DataSet ds;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        #region //rendering top left panel 

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
            sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            myDivObject.InnerHtml = sb.ToString();

            //myDivObject.InnerHtml = "<table border='0' class='dvBannerLeftPanel'><tr><td><img alt='imbnLeftimg' src='Images/faq_head.jpg' /> </td></tr></table>";
        }
        #endregion 


        ltrTestimonialLeft.Text = Resources.LangResources.Testimonial;
        ltrTestimonial.Text = Resources.LangResources.Testimonial;


        //Literal LtrNews = (Literal)Page.FindControl("LtrNews");
        //if (LtrNews != null)
            
        //ltrTestimonial.Text = Resources.LangResources.Testimonial;


        if (!IsPostBack)
        {

            LoadTestimonials();

        }


    }

    
    protected void LoadTestimonials()
    {


        ds = objBL_Testimonial.User_GETAll_Testimonials_ByUserID(Convert.ToInt32(Session["ClientID"]));
        //ds = objBL_Testimonial.User_GETAll_Testimonials_ByUserID(Convert.ToInt32(GlobalVar.GetTestLoginUser));
        
        dt = ds.Tables[0];
        
        string tmpstr = string.Empty;

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            tmpstr = "By " + tRows["tstByName"].ToString() + " from " + tRows["tstByCompany"].ToString();

        }
        
        //Literal objLtrTstDetails = (Literal)Page.FindControl("LtrTestimonialDetailsHeader");

        //if (objLtrTstDetails != null)
        //    objLtrTstDetails.Text = tmpstr;

        rpFaqList.DataSource = ds;
        rpFaqList.DataBind();


    }

    protected void rpFaqList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Literal objLtrTestDetails = (Literal)e.Item.FindControl("LtrTestimonialDetailsHeader");

            HiddenField objByName = (HiddenField)e.Item.FindControl("tstByName");
            HiddenField objByDesig = (HiddenField)e.Item.FindControl("tstByDesignation");
            HiddenField objByCompany = (HiddenField)e.Item.FindControl("tstByCompany");

            if (objLtrTestDetails != null)
            {
                objLtrTestDetails.Text = objByName.Value + "," + objByDesig.Value + "," + objByCompany.Value;
            }
            

        }
    }
}




