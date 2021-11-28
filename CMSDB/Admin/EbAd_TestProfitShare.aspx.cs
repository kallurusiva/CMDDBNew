using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_EbAd_TestProfitShare : System.Web.UI.Page
{
    int tmpRowCount;
    int tmpTotalRecord = 0;

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
            ViewState["SortOrder"] = "";
            ViewState["SortExpr"] = "";
            ViewState["TotalRecord"] = "0";
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

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
        }

        tblMessageBar.Visible = false;
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        //ds = objMalaysia.Retrieve_ProfitShare("13826", "1", strPageNo, gridEbooks.PageSize.ToString(), "");
        ds = objMalaysia.Retrieve_ProfitShare(Session["MERID"].ToString(), "1", strPageNo, gridEbooks.PageSize.ToString(), "");
        if (ds.Tables[0].Rows.Count > 0)
        {

            tmpRowCount = ds.Tables[0].Rows.Count;
            tmpTotalRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRecord"].ToString());
            ViewState["TotalRecord"] = tmpTotalRecord.ToString();

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
    public string SortOrder
    {
        get
        {
            if (ViewState["SortOrder"].ToString() == "desc")
            {
                ViewState["SortOrder"] = "asc";

            }
            else
            {
                ViewState["SortOrder"] = "desc";
            }

            return ViewState["SortOrder"].ToString();
        }
        set
        {
            ViewState["SortOrder"] = value;
        }
    }
    protected void gridEbooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEbooks.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }
    protected void gridEbooks_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(gridEbooks.PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), gridEbooks.BottomPagerRow, gridEbooks);
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

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
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

        DateTime sDate = Convert.ToDateTime("01/" + sMonth + "/" + sYear);
        LabelIdentifier_CategoryInfo.Text = "My Profit Share Report on " + sDate.ToString("MMMM") + "," + sYear;

        ViewState["tmpSearchSQL1"] = " and cast(rptYear as int)=" + sYear + " and cast(rptMonth as int)=" + sMonth;
        Populate_GridView2(ViewState["tmpSearchSQL1"].ToString());
    }
    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        int PageCount = tmpTotalRecord / gridEbooks.PageSize;
        if (tmpTotalRecord % gridEbooks.PageSize > 0)
            PageCount++;

        ViewState["PageID"] = pageNumberDropDownList.SelectedValue;

        if (pageNumberDropDownList != null)
        {
            if (gridEbooks.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < PageCount || pageNumberDropDownList.SelectedIndex >= 0)
                {
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
                }
            }
        }
    }
    protected void BtnPaging(object sender, CommandEventArgs e)
    {
        int strPageNo = Convert.ToInt32(ViewState["PageID"]);
        int PageSize = Convert.ToInt32(gridEbooks.PageSize);

        string strButtonType = e.CommandArgument.ToString();
        int strLastPageNo = Convert.ToInt32(ViewState["TotalRecord"]) / PageSize;

        if (Convert.ToInt32(ViewState["TotalRecord"]) % PageSize > 0)
            strLastPageNo++;

        switch (strButtonType)
        {
            case "F":
                strPageNo = 1;
                break;
            case "P":
                strPageNo = strPageNo - 1;
                break;
            case "N":
                strPageNo = strPageNo + 1;
                break;
            case "L":
                strPageNo = strLastPageNo;
                break;
        }

        ViewState["PageID"] = strPageNo;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }
    protected void Populate_GridView2(String vSearchSql)
    {
        String strPageNo = String.Empty;

        //ds = objMalaysia.Retrieve_ProfitShare("13826", "0", "1", "5", vSearchSql);
        ds = objMalaysia.Retrieve_ProfitShare(Session["MERID"].ToString(), "0", "1", "5", vSearchSql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dv = ds.Tables[0].DefaultView;

            if (ds.Tables[1].Rows.Count == 1)
            {
                DataRow utRow = ds.Tables[1].Rows[0];

                ViewState["tmpTotal1"] = utRow["amtS"].ToString();
                ViewState["tmpTotal2"] = utRow["oprtShare"].ToString();
                ViewState["tmpTotal3"] = utRow["amtF"].ToString();
                ViewState["tmpTotal4"] = utRow["grossprofit"].ToString();

                ViewState["tmpTotalZero"] = utRow["MTZ"].ToString();
                ViewState["tmpTotalSuccess"] = utRow["MTS"].ToString();
                ViewState["tmpTotalFailure"] = utRow["MTF"].ToString();
                ViewState["tmpTotalALL"] = utRow["MTT"].ToString();

                ViewState["tmpDENOM"] = utRow["Denomination"].ToString();
            }

            GridView2.DataSource = dv;
            GridView2.DataBind();

            ModalPopUpExtender1.Show();

        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            GridView2.DataSource = ds;
            GridView2.DataBind();

            //tbNoticeBar.Visible = false;
            int ColCount = GridView2.Rows[0].Cells.Count;
            GridView2.Rows[0].Cells.Clear();
            GridView2.Rows[0].Cells.Add(new TableCell());
            GridView2.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridView2.Rows[0].Cells[0].Text = "Record Not Found";
            GridView2.Rows[0].Cells[0].CssClass = "txtValidateRed";
            GridView2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
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
            HeaderCell.Text = "Operator";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Percentage";
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);


            HeaderCell = new TableCell();
            HeaderCell.Text = "MT Charge";
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

            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int intNoOfMergeCol = e.Row.Cells.Count - 8; /*except last column */

            GridViewRow footerRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);

            //Adding Footer Total Text Column
            TableCell cell = new TableCell();
            Label lbX = new Label();
            cell.Text = "Total";
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.ColumnSpan = intNoOfMergeCol;

            footerRow.Cells.Add(cell);

            cell = new TableCell();
            lbX = new Label();
            lbX.ID = "lblFooterZero";
            lbX.Text = ViewState["tmpTotalZero"].ToString();
            cell.Controls.Add(lbX);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);

            cell = new TableCell();
            lbX = new Label();
            lbX.ID = "lblFooterSuccess";
            lbX.Text = ViewState["tmpTotalSuccess"].ToString();
            cell.Controls.Add(lbX);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);

            cell = new TableCell();
            lbX = new Label();
            lbX.ID = "lblFooterFailure";
            lbX.Text = ViewState["tmpTotalFailure"].ToString();
            cell.Controls.Add(lbX);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);

            cell = new TableCell();
            lbX = new Label();
            lbX.ID = "lblFooterTotalAll";
            lbX.Text = ViewState["tmpTotalALL"].ToString();
            cell.Controls.Add(lbX);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);

            //Adding Footer Total Amount Column
            cell = new TableCell();
            Label lb1 = new Label();
            lb1.ID = "lblFooterAmount1";
            lb1.Text = ViewState["tmpDENOM"].ToString() + " " + Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(ViewState["tmpTotal1"]))).ToString(); //String.Format("{0:0.00}", ViewState["tmpTotal"].ToString());
            cell.Controls.Add(lb1);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);


            //Adding Footer Total Amount Column
            cell = new TableCell();
            Label lb2 = new Label();
            lb2.ID = "lblFooterAmount2";
            lb2.Text = ViewState["tmpDENOM"].ToString() + " " + Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(ViewState["tmpTotal2"]))).ToString(); //String.Format("{0:0.00}", ViewState["tmpTotal"].ToString());
            cell.Controls.Add(lb2);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);

            //Adding Footer Total Amount Column
            cell = new TableCell();
            Label lb3 = new Label();
            lb3.ID = "lblFooterAmount2";
            lb3.Text = ViewState["tmpDENOM"].ToString() + " " + Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(ViewState["tmpTotal3"]))).ToString(); //String.Format("{0:0.00}", ViewState["tmpTotal"].ToString());
            cell.Controls.Add(lb3);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);


            //Adding Footer Total Amount Column
            cell = new TableCell();
            Label lb4 = new Label();
            lb4.ID = "lblFooterAmount4";
            lb4.Text = ViewState["tmpDENOM"].ToString() + " " + Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(ViewState["tmpTotal4"]))).ToString(); //String.Format("{0:0.00}", ViewState["tmpTotal"].ToString());
            cell.Controls.Add(lb4);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);

            //if(GridView1.PageCount >1)
            GridView2.Controls[0].Controls.Add(footerRow);

            // First cell is used for specifying the Total text
            for (int intCellCol = 0; intCellCol < GridView2.Columns.Count; intCellCol++)
                e.Row.Cells.RemoveAt(0);

        }
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false; // Invisibiling Sno Header Cell
            e.Row.Cells[1].Visible = false; // Invisibiling Year Header Cell
            e.Row.Cells[2].Visible = false; // Invisibiling Price By Header Cell
            e.Row.Cells[3].Visible = false; // Invisibiling MT Charges By Header Cell
            e.Row.Cells[4].Visible = false; // Invisibiling MT Charges By Header Cell
            e.Row.Cells[9].Visible = false; // Invisibiling Sucess Amt By Header Cell
            e.Row.Cells[10].Visible = false; // Invisibiling Operator Share By Header Cell
            e.Row.Cells[11].Visible = false; // Invisibiling Your Share By Header Cell
            e.Row.Cells[12].Visible = false; // Invisibiling Your Share By Header Cell           
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnMonth = e.Row.FindControl("hdnMonth") as HiddenField;
            HiddenField hdnYear = e.Row.FindControl("hdnYear") as HiddenField;
            Label lblOperator = e.Row.FindControl("lblOperator") as Label;
            Label lblCharge = e.Row.FindControl("lblCharge") as Label;

            String sOperator = lblOperator.Text.Trim().ToUpper();
            int tYear = Convert.ToInt32(hdnYear.Value);
            int tMonth = Convert.ToInt32(hdnMonth.Value);

            if (sOperator == "MAXIS")
            {
                lblCharge.Text = "0.10";

                if (tYear > 2010)
                {
                    lblCharge.Text = "0.05";
                }
                else if (tYear == 2010)
                {
                    if (tMonth > 6)
                    {
                        lblCharge.Text = "0.05";
                    }
                }
            }
            else if (sOperator == "DIGI")
            {
                lblCharge.Text = "0.07";

                if (tYear > 2010)
                {
                    lblCharge.Text = "0.05";
                }
                else if (tYear == 2010)
                {
                    if (tMonth > 6)
                    {
                        lblCharge.Text = "0.05";
                    }
                }
            }
            else if (sOperator == "CELCOM")
            {
                lblCharge.Text = "0.11";

                if (tYear > 2010)
                {
                    lblCharge.Text = "0.05";
                }
                else if (tYear == 2010)
                {
                    if (tMonth > 6)
                    {
                        lblCharge.Text = "0.05";
                    }
                }
            }

        }
    }
}
