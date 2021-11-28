using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_EbAd_MyProfitShareList : System.Web.UI.Page 
{
    int tmpRowCount;
    int tmpTotalRecord = 0;

    DataSet ds;
    DataSet dsCodes;
    DataView dv;    
    DataView DL;
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
            ViewState["PageID"] = "1";
            ViewState["Shortcode"] = "32828";
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());            
        }

        tblMessageBar.Visible = false;
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        string strTmpShortcode = string.Empty;

        if (ViewState["Shortcode"] == null) 
        { 
            ViewState["Shortcode"] = "32828";
            strTmpShortcode = "32828";
        }
        else
        {
            strTmpShortcode = ViewState["Shortcode"].ToString();
        }
        //newDBS objnewDBS = new newDBS();
        newDBS objnewDBS = new newDBS();
        dsCodes = objnewDBS.ebook_getProfitShareShortCode(Session["MERID"].ToString());     
        
        DL = dsCodes.Tables[0].DefaultView;
        //string strTmpShortcode = ViewState["ShortCode"].ToString();
        dShortcode.DataSource = DL;
        dShortcode.DataTextField = "scode";
        dShortcode.DataValueField = "scode";
        dShortcode.SelectedIndex = dShortcode.Items.IndexOf(dShortcode.Items.FindByValue(strTmpShortcode));
        dShortcode.DataBind();


        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        //ds = objMalaysia.Retrieve_ProfitShare("13826", "1", strPageNo, gridEbooks.PageSize.ToString(), "");
        //ds = objMalaysia.Retrieve_ProfitShare(Session["MERID"].ToString(), "1", strPageNo ,gridEbooks.PageSize.ToString(), "");
        ds = objnewDBS.ebook_getProfitShare32828(Session["MERID"].ToString(), strPageNo, gridEbooks.PageSize.ToString(), strTmpShortcode);
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
            hdnMonth.Value = IDs[0].ToString();
            hdnYear.Value = IDs[1].ToString();
        }
        hdnSCode.Value = ViewState["Shortcode"].ToString();
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
    protected void dShortcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["Shortcode"] = dShortcode.SelectedValue.ToString();
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());  

    }
}
