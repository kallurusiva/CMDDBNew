using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CMSv3.BAL;


public partial class UserFaqs : UserWeb
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;

    DataSet ds;
    DataView dv;
    string strSQL = string.Empty;

    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;


    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        ltrSystemNews.Text = Resources.LangResources.SystemNews;

       // Literal objLtrSystemNews2 = (Literal)frmSystemNews.FindControl("ltrSystemNews2");
        //objLtrSystemNews2.Text = ltrSystemNews.Text;

 
        #region top Left panel rendering


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
        sb.Append("<img alt='imbnLeftimg' src='Images/faq_head.jpg' />");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        myDivObject.InnerHtml = sb.ToString();
        #endregion


        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "subject";

            LoadSystemNews(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
           
        }


    }


    protected void LoadSystemNews(string vSortExpr, string vSortDir)
    {


        //ds = objBAl_Event.Retrieve_AllEventByUserID(101);
        //ds = objBAL_Testimonial.RetrieveAllTestimonials_ByUserID(Convert.ToInt32(Session["saUserID"]), ViewState["RtType"].ToString(), qLgType);

        strSQL = "EXEC [usp_USER_SystemNews_GET_ByUserID] " + Convert.ToInt32(Session["ClientID"]);

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);


            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);



            if (ds.Tables[0].Rows.Count > 0)
            {

                dv = ds.Tables[0].DefaultView;
                if (vSortExpr != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }


                // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


                gridSystemNews.DataSource = dv;
                gridSystemNews.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridSystemNews.DataSource = ds;
                gridSystemNews.DataBind();

                int ColCount = gridSystemNews.Rows[0].Cells.Count;
                gridSystemNews.Rows[0].Cells.Clear();
                gridSystemNews.Rows[0].Cells.Add(new TableCell());
                gridSystemNews.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridSystemNews.Rows[0].Cells[0].Text = "No System news Found";
                gridSystemNews.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }



    }


    protected void gridSystemNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridSystemNews.PageIndex = e.NewPageIndex;
        LoadSystemNews(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridSystemNews.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridSystemNews.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridSystemNews.PageIndex = pageNumberDropDownList.SelectedIndex;
                    LoadSystemNews(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridSystemNews_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;
        LoadSystemNews(m_SortExpr, sortOrder);
    }


    public string sortOrder
    {
        get
        {
            if (ViewState["sortOrder"].ToString() == "desc")
            {
                ViewState["sortOrder"] = "asc";

            }
            else
            {
                ViewState["sortOrder"] = "desc";
            }

            return ViewState["sortOrder"].ToString();
        }
        set
        {
            ViewState["sortOrder"] = value;
        }
    }


    protected void gridSystemNews_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridSystemNews.BottomPagerRow, gridSystemNews);
    }

    protected void gridSystemNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {

            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");

            ////To get the up/down image at the sorted column 
            //CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //CheckBox objChkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //objChkSelect.Attributes.Add("onClick", "SelectRow('" + objChkSelect.ClientID + "')");


            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1'; this.style.cursor='hand';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");



           




            DataRowView drv = ((DataRowView)e.Row.DataItem);

            TextBox objNewsContent = (TextBox)e.Row.FindControl("txtContents");
            if (objNewsContent != null)
            {
                string tmpstr = drv["Contents"].ToString().Replace("<br/>", Environment.NewLine);
                objNewsContent.Text = tmpstr;
            }

            Literal oblLtrSysNewsID = (Literal)e.Row.FindControl("hdSnId");


            string alertBox = "ShowSystemNews('";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

               // alertBox += e.Row.RowIndex;

                alertBox += oblLtrSysNewsID.Text;

                alertBox += "')";

                e.Row.Attributes.Add("onclick", alertBox);

            }



        }



    }

    private int findColumnIndex(GridView gridView, string accessibleHeaderText)
    {
        for (int index = 0; index < gridView.Columns.Count; index++)
        {
            if (String.Compare(gridView.Columns[index].AccessibleHeaderText, accessibleHeaderText, true) == 0)
            {
                return index;
            }
        }
        return -1;
    }


}



