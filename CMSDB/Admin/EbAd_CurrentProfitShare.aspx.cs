using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_EbAd_CurrentProfitShare : System.Web.UI.Page
{

    DataSet ds;
    DataView dv;

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
            ViewState["tmpSearchSQL"] = "";
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

            Populate_GridView2(ViewState["tmpSearchSQL"].ToString());                
        }
    }

    protected void Populate_GridView2(String vSearchSql)
    {
        String strPageNo = String.Empty;
        //ds = objMalaysia.Retrieve_CurrentProfitShare("13826", DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString());
        ds = objMalaysia.Retrieve_CurrentProfitShare(Session["MERID"].ToString(),DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            dv = ds.Tables[0].DefaultView;

            if (ds.Tables[1].Rows.Count == 1)
            {
                DataRow utRow = ds.Tables[1].Rows[0];

                ViewState["tmpTotal1"] = utRow["SuccessAmt"].ToString();
                ViewState["tmpTotal2"] = utRow["OperatorShareAmt"].ToString();
                ViewState["tmpTotal3"] = utRow["FailedAmt"].ToString();
                ViewState["tmpTotal4"] = utRow["GrossProfitAmt"].ToString();

                ViewState["tmpTotalZero"] = utRow["TotalZ"].ToString();
                ViewState["tmpTotalSuccess"] = utRow["TotalS"].ToString();
                ViewState["tmpTotalFailure"] = utRow["TotalF"].ToString();
                ViewState["tmpTotalALL"] = utRow["TotalAll"].ToString();

                ViewState["tmpDENOM"] = utRow["Denomination"].ToString();

                lblTitleHeader.Text = "My Profit Sharing for Current Month : " + utRow["tMonth"].ToString() + " , " + DateTime.Today.Year.ToString();

            }

            GridView2.DataSource = dv;
            GridView2.DataBind();

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
        
    }
}
