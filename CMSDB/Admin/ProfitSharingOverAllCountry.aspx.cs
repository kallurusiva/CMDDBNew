using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;

public partial class Admin_ProfitSharingOverAllCountry : System.Web.UI.Page
{
    DataView dv;
    DataView dvs;
    DataView dvt;
    DataSet ds;

    String m_sortExpr = String.Empty;
    SortDirection m_sortDir = SortDirection.Ascending;

    newDBS objPS = new newDBS();
    string mobileValPS = string.Empty;

    //double tmpTotal = 0;
    int tmpRowCount = 0;
    //int tmpTotalRecord = 0;
    //int PageSize = 50;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "mobile";
            ViewState["tmpSearchSQL"] = "";
            ViewState["TotalRecord"] = "0";
            ViewState["PageID"] = "1";
            ViewState["countryCode"] = "";
            ViewState["TotalGross"] = "0.00";
            ViewState["TotalShare"] = "0.00";
            ViewState["DenominationT"] = "";
            ViewState["country"] = "";

            //lblMainTitle.Text = "Premium ProfitShare" + " :  Overall Profit Summary";
            //lblNotice.Text = "";

            String qPcode = string.Empty;
            ViewState["countryCode"] = Request.QueryString["cCode"];

            //if (PreviousPage != null)
            //{
            //    HiddenField hdnSno = PreviousPage.Master.FindControl("ContentPlaceHolder3").FindControl("hdnSno") as HiddenField;
            //    ViewState["countryCode"] = hdnSno.Value.Trim();
            //}
            mobileValPS = Session["LoginID"].ToString();
            mobileValPS = mobileValPS.Replace("EB", "");
            ViewState["mobileValPS"] = mobileValPS;
            Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }
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
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    protected void Populate_GridView1(String vSearchSql, String vSortExpr, String vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();
      
        ds = objPS.profitShare_OverAllSummaryCountry(mobileValPS, ViewState["countryCode"].ToString());

        DataRow utRow1 = ds.Tables[3].Rows[0];
        ViewState["country"] = utRow1["CountryName"].ToString();
        ViewState["shortcode"] = utRow1["shortcode"].ToString();

        //lblHdeadingDirect.Text = "Your Direct Profit Share - " + ViewState["country"].ToString();
        //lblHeadingDP.Text = "Your Direct Partner Profit Share - " + ViewState["country"].ToString();

        if (ds.Tables[0].Rows.Count > 0)
        {
            tmpRowCount = ds.Tables[0].Rows.Count;
            dv = ds.Tables[0].DefaultView;

            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }

            //Retrieve GrandTotalAmount
            //DataRow utRow = ds.Tables[1].Rows[0];
            //ViewState["tmpGrandTotal"] = utRow["SumPrice"].ToString();

            GridView1.DataSource = dv;
            GridView1.DataBind();

        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            //ViewState["tmpTotal"] = "0.00";

            GridView1.DataSource = ds;
            GridView1.DataBind();

            //tbNoticeBar.Visible = false;
            int ColCount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridView1.Rows[0].Cells[0].Text = "Record not found";
            GridView1.Rows[0].Cells[0].CssClass = "txtRedMedium";
            GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            tmpRowCount = ds.Tables[0].Rows.Count;
            dvs = ds.Tables[1].DefaultView;
            dvt = ds.Tables[2].DefaultView;

            DataRow utRow = ds.Tables[2].Rows[0];
            ViewState["TotalGross"] = utRow["GrossProfit"].ToString();
            ViewState["TotalShare"] = utRow["yourShare"].ToString();
            ViewState["DenominationT"] = utRow["Denomination"].ToString();

            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }

            //Retrieve GrandTotalAmount
            //DataRow utRow = ds.Tables[1].Rows[0];
            //ViewState["tmpGrandTotal"] = utRow["SumPrice"].ToString();

            GridView2.DataSource = dvs;
            GridView2.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[1].Rows.Add(ds.Tables[1].NewRow());
            //ViewState["tmpTotal"] = "0.00";

            GridView2.DataSource = ds;
            GridView2.DataBind();

            //tbNoticeBar.Visible = false;
            int ColCount = GridView1.Rows[0].Cells.Count;
            GridView2.Rows[0].Cells.Clear();
            GridView2.Rows[0].Cells.Add(new TableCell());
            GridView2.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridView2.Rows[0].Cells[0].Text = "No Records Found";
            GridView2.Rows[0].Cells[0].CssClass = "txtRedMedium";
            GridView2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }

    }


    protected void Button_SearchSubmit(object sender, EventArgs e)
    {
        String tmpSearchSQL = "";
        //String selProductCode = ddlProducts.SelectedValue;

        //ViewState["SelProductCode"] = selProductCode; 

        ViewState["PageID"] = "1";

        if (tmpSearchSQL == "") { tmpSearchSQL = " and SendON between '' and '')"; }

        ViewState["tmpSearchSQL"] = tmpSearchSQL;
        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void btnRefine_Click(object sender, EventArgs e)
    {
        ViewState["tmpSearchSQL"] = "";
        //tbInformationTable.Visible = false;
        ViewState["PageID"] = "1";

        //ddlProducts.SelectedIndex = 0;
        ViewState["SelProductCode"] = "0";
        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_sortExpr = e.SortExpression;
        m_sortDir = e.SortDirection;

        ViewState["SortExpr"] = m_sortExpr;

        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), m_sortExpr, sortOrder);
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        //Hitech_Functions.InitialiseGridViewPagerRowWithImages(GridView1.BottomPagerRow, GridView1);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (tmpRowCount > 0))
        {

            Label lblUpgrador = ((Label)e.Row.FindControl("lblUpgrador"));
            Label lblMobile = ((Label)e.Row.FindControl("lblMobile"));

            StringBuilder sbInfo = new StringBuilder();

        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

        }
    }
    protected void pageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedValue;

        if (pageNumberDropDownList != null)
        {
            if (GridView1.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < GridView1.PageCount || pageNumberDropDownList.SelectedIndex >= 0)
                {
                    GridView1.PageIndex = pageNumberDropDownList.SelectedIndex;
                    Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }

    }
    protected void Button_View(object sender, CommandEventArgs e)
    {
        string s = e.CommandArgument.ToString();

        hdnSno.Value = s.Trim();
        hdnMobile.Value = s.Trim();

        string abc = hdnMobile.Value.ToString();
        string abdc = ViewState["mobileValPS"].ToString();

        if (hdnMobile.Value.ToString() == ViewState["mobileValPS"].ToString())
        {
            Server.Transfer(@"ProfitSharingShortCodeWise.aspx?BPID=" + hdnMobile.Value.ToString() + "&sCode=" + ViewState["shortcode"].ToString());
        }
        else
        {
            Server.Transfer(@"ProfitSharingShortCodeWiseBP.aspx?BPID=" + hdnMobile.Value.ToString() + "&sCode=" + ViewState["shortcode"].ToString());
        }

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Footer) && (tmpRowCount > 0))
        {
            Label lblGrossAmount = (Label)e.Row.FindControl("lblGrossAmount");
            lblGrossAmount.Text = ViewState["DenominationT"].ToString() + ' ' + ViewState["TotalGross"].ToString();
            
            Label lblShareAmount = (Label)e.Row.FindControl("lblShareAmount");
            lblShareAmount.Text = ViewState["DenominationT"].ToString() + ' ' + ViewState["TotalShare"].ToString();
        }
    }

    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

        }
    }

    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_sortExpr = e.SortExpression;
        m_sortDir = e.SortDirection;

        ViewState["SortExpr"] = m_sortExpr;

        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), m_sortExpr, sortOrder);
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        //Hitech_Functions.InitialiseGridViewPagerRowWithImages(GridView1.BottomPagerRow, GridView1);
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }
}