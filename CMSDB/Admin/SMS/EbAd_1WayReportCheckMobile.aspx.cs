using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_SMS_EbAd_1WayReportCheckMobile : System.Web.UI.Page
{
    int tmpRowCount;
    int tmpTotalRecord = 0;

    String m_sortExpr = String.Empty;
    SortDirection m_sortDir = SortDirection.Ascending;

    DataView dv;
    DataSet ds;

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
            ViewState["HistID"] = "";

            if (PreviousPage != null)
            {
                HiddenField hdnHistID = PreviousPage.Master.FindControl("ContentBody").FindControl("hdnHistID") as HiddenField;
                ViewState["HistID"] = hdnHistID.Value.Trim();

                int i = 0;

                bool isNumeric = Int32.TryParse(ViewState["HistID"].ToString(), out i);

                if (isNumeric)
                {
                    Populate_gridEbooks(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
                }
            }
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
    protected void Populate_gridEbooks(String vSearchSql, String vSortExpr, String vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        ds = objMalaysia.Validate_1WayReport_Specific(ViewState["HistID"].ToString(), strPageNo, gridEbooks.PageSize.ToString(), vSearchSql);
        String tMobile = String.Empty;
        String tMsg = String.Empty;

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];

            if (ds.Tables[1].Rows.Count > 0)
            {

                tmpRowCount = ds.Tables[1].Rows.Count;
                tmpTotalRecord = Convert.ToInt32(ds.Tables[2].Rows[0]["TotalRecord"].ToString());
                ViewState["TotalRecord"] = tmpTotalRecord.ToString();

                dv = ds.Tables[1].DefaultView;

                if (vSortExpr != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }
                gridEbooks.DataSource = dv;
                gridEbooks.DataBind();
            }
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridEbooks.DataSource = ds;
            gridEbooks.DataBind();

            //tbNoticeBar.Visible = false;
            int ColCount = gridEbooks.Rows[0].Cells.Count;
            gridEbooks.Rows[0].Cells.Clear();
            gridEbooks.Rows[0].Cells.Add(new TableCell());
            gridEbooks.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridEbooks.Rows[0].Cells[0].Text = "Sorry Record Not Found.";
            gridEbooks.Rows[0].Cells[0].CssClass = "txtValidateRed";
            gridEbooks.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["SortDirection"] == null)

                ViewState["SortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["SortDirection"];
        }
        set { ViewState["SortDirection"] = value; }
    }
    protected void gridEbooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEbooks.PageIndex = e.NewPageIndex;
        Populate_gridEbooks(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }
    protected void gridEbooks_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_sortExpr = e.SortExpression;
        m_sortDir = e.SortDirection;

        ViewState["SortExpr"] = m_sortExpr;

        Populate_gridEbooks(ViewState["tmpSearchSQL"].ToString(), m_sortExpr, SortOrder);
    }
    protected void gridEbooks_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(gridEbooks.PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), gridEbooks.BottomPagerRow, gridEbooks);
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
                    Populate_gridEbooks(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
                }
            }
        }
    }
    protected void BtnPaging(object sender, CommandEventArgs e)
    {
        int strPageNo = Convert.ToInt32(ViewState["PageID"]);
        int PageSize = gridEbooks.PageSize;

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
        Populate_gridEbooks(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }
}
