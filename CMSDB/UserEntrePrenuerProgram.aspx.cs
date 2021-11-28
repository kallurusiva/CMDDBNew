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


public partial class UserEntrePrenuerProgram : UserWeb
{

    CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();
    DataSet ds;
    //DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        if (Session["MasterPageFile"].ToString() != "TmpMaster2.master")
        {

            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

            //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
            if (myDivObject != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>");
                sb.Append("<img src='Images/table_top_Leftarc.gif' />");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<img alt='imbnLeftimg' src='Images/Product_head.jpg' />");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                myDivObject.InnerHtml = sb.ToString();
            }
        }
        //myDivObject.InnerHtml = "<table border='0' class='dvBannerLeftPanel'><tr><td><img alt='imbnLeftimg' src='Images/faq_head.jpg' /> </td></tr></table>";


       
        
        if (!IsPostBack)
        {

            LoadProducts();

        }


    }


    protected void LoadProducts()
    {

        ds = objBAL_Products.User_GETAll_Products_ByUserID(Convert.ToInt32(Session["ClientID"]),Convert.ToInt16(GlobalVar.ProductTypes.Entrepreneur));
        //ds = objBL_faq.User_GETAllFaq_ByUserID(Convert.ToInt32(Session["UserID"]));

        rpProductList.DataSource = ds;
        rpProductList.DataBind();


    }

    protected void rpProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Literal objLtrTestDetails = (Literal)e.Item.FindControl("LtrProductDetailsHeader");

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




