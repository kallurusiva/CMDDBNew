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


public partial class Admin_ProfitSharingOverAll : System.Web.UI.Page
{
    DataView dv;
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
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "countryname";
            ViewState["tmpSearchSQL"] = "";
            ViewState["TotalRecord"] = "0";
            ViewState["PageID"] = "1";

            //lblMainTitle.Text = "Premium ProfitShare" + " :  Overall Profit Summary";
            //lblNotice.Text = "";


            String qPcode = string.Empty;

            if ((Request.QueryString["ShPc"] != null) && (Request.QueryString["ShPc"].ToString() != ""))
            {
                qPcode = Request.QueryString["ShPc"].ToString();

                if (qPcode != "")
                {
                    String vPcode = qPcode;

                    if (vPcode != "")
                    {
                        ViewState["tmpSearchSQL"] = " and DP.Pcode = " + vPcode;
                        ViewState["SelProductCode"] = vPcode;
                    }
                }
            }
            mobileValPS = Session["LoginID"].ToString();
            mobileValPS = mobileValPS.Replace("EB", "");
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
        ds = objPS.profitShare_OverAllSummary(mobileValPS);

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
            GridView1.Rows[0].Cells[0].Text = "RecordNotFound";
            GridView1.Rows[0].Cells[0].CssClass = "txtRedMedium";
            GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
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
        ////tbInformationTable.Visible = false;
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

            Image ImageCtry = ((Image)e.Row.FindControl("ImageCtry"));
            HiddenField hdnCtryName = ((HiddenField)e.Row.FindControl("hdnCtryName"));
            ImageCtry.ImageUrl = "../Images/f_" + hdnCtryName.Value + ".gif";

            StringBuilder sbInfo = new StringBuilder();

        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "Sno";
            //HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Country Name";
            //HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Your own Profit";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //HeaderCell.Width = 200;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Your Direct Partner Profit";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            //HeaderCell.Width = 200;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total ProfitShare";
            HeaderCell.HorizontalAlign = HorizontalAlign.Right;
            //HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "View Details";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
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
        hdnMobile.Value = mobileValPS;

        //Server.Transfer(@"rpt_SMS1WaySpecific.aspx");
        Server.Transfer(@"ProfitSharingOverAllCountry.aspx?cCode=" + hdnSno.Value.ToString());
    }

    protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}