using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_EbAd_PaymentList : System.Web.UI.Page
{
    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "";
            ViewState["SortExpr"] = "";
            ViewState["TotalRecord1"] = "0";
            ViewState["tmpSearchSQL"] = "";
            ViewState["tmpSearchSQL1"] = "";
            ViewState["PageID"] = "1";
            ViewState["tmpTotal1"] = "0";
            ViewState["tmpTotal2"] = "0";
            ViewState["tmpTotal3"] = "0";
            ViewState["tmpTotal4"] = "0";
            ViewState["tmpTotalZero"] = "0";
            ViewState["tmpTotalSuccess"] = "0";
            ViewState["tmpTotalFailure"] = "0";
            ViewState["tmpTotalALL"] = "0";
            ViewState["tmpDENOM"] = "";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }

        tblMessageBar.Visible = false;
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();
       
        ds = objMalaysia.Retrieve_PaymentRequest(Session["MERID"].ToString(), strPageNo, gridEbooks.PageSize.ToString(), "");

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }

            gridEbooks.DataSource = dv;
            gridEbooks.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridEbooks.DataSource = ds;
            gridEbooks.DataBind();

            int ColCount = gridEbooks.Rows[0].Cells.Count;
            gridEbooks.Rows[0].Cells.Clear();
            gridEbooks.Rows[0].Cells.Add(new TableCell());
            gridEbooks.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridEbooks.Rows[0].Cells[0].Text = "No records Found";
            gridEbooks.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
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
    protected void gridEbooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEbooks.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }
    protected void gridEbooks_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridEbooks.BottomPagerRow, gridEbooks);
    }
    protected void gridEbooks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false; // Invisibiling Sno Header Cell
            e.Row.Cells[1].Visible = false; // Invisibiling Year Header Cell
            e.Row.Cells[2].Visible = false; // Invisibiling Price By Header Cell
            e.Row.Cells[7].Visible = false; // Invisibiling Sucess Amt By Header Cell
            e.Row.Cells[8].Visible = false; // Invisibiling Operator Share By Header Cell
            e.Row.Cells[9].Visible = false; // Invisibiling Failed Amt By Header Cell
            e.Row.Cells[10].Visible = false; // Invisibiling Gross Profit By Header Cell
            e.Row.Cells[11].Visible = false; // Invisibiling Your Share By Header Cell
            e.Row.Cells[12].Visible = false; // Invisibiling Your Share By Header Cell
            e.Row.Cells[13].Visible = false; // Invisibiling View Report By Header Cell
        }
    }
    protected void gridEbooks_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }
    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["PageID"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridEbooks.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridEbooks.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridEbooks.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }
    protected void gridEbooks_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "Sno";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Month/Year";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Premium Amount";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No. of Transactions";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.Width = 180;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Success Amount";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Operator Share";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Failed Amount";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Gross Profit";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Your Share";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Gross Profit Net";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "View Report";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }

    }
    protected void CheckStatus(object sender, CommandEventArgs e)
    {
        String sMonthYear = e.CommandArgument.ToString().Trim();
        String sMonth = String.Empty;
        String sYear = String.Empty;

        string[] IDs = sMonthYear.Split('#');

        foreach (string part in IDs)
        {

            sMonth = IDs[0].ToString();
            sYear = IDs[1].ToString();
        }

        //DateTime sDate = Convert.ToDateTime("01/" + sMonth + "/" + sYear);
        //LabelIdentifier_CategoryInfo.Text = "My Profit Share Report on " + sDate.ToString("MMMM") + "," + sYear;

        //ViewState["tmpSearchSQL1"] = " and cast(rptYear as int)=" + sYear + " and cast(rptMonth as int)=" + sMonth;
        //Populate_GridView2(ViewState["tmpSearchSQL1"].ToString());
    }
}
