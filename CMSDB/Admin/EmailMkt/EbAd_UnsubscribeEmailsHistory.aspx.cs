using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_EmailMkt_EbAd_UnsubscribeEmailsHistory : System.Web.UI.Page
{
    int tmpRowCount;
    int tmpTotalRecord = 0;

    String m_sortExpr = String.Empty;
    SortDirection m_sortDir = SortDirection.Ascending;

    DataView dv;
    DataSet ds;

    CMSv3.BAL.eBook objeBook = new CMSv3.BAL.eBook();

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
            ViewState["SortOrder"] = "desc";
            ViewState["SortExpr"] = "";
            ViewState["TotalRecord"] = "0";
            ViewState["tmpSearchSQL"] = "";
            ViewState["PageID"] = "1";

            String tmpSearchSQL = String.Empty;

            Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
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

        ds = objeBook.Retrieve_UnSubscribedEmail(Session["UserID"].ToString(), strPageNo, gridEbooks.PageSize.ToString(), vSearchSql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //divNoticeBar.Visible = false;
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

            //tbNoticeBar.Visible = false;
            int ColCount = gridEbooks.Rows[0].Cells.Count;
            gridEbooks.Rows[0].Cells.Clear();
            gridEbooks.Rows[0].Cells.Add(new TableCell());
            gridEbooks.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridEbooks.Rows[0].Cells[0].Text = "Record not found";
            gridEbooks.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    protected void gridEbooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEbooks.PageIndex = e.NewPageIndex;
        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }
    protected void gridEbooks_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(gridEbooks.PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), gridEbooks.BottomPagerRow, gridEbooks);
    }
    protected void gridEbooks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (tmpRowCount > 0))
        {
            HiddenField hdnDeleted = e.Row.FindControl("hdnDeleted") as HiddenField;
            LinkButton LinkButton1 = e.Row.FindControl("LinkButton1") as LinkButton;
            ImageButton ImageButton1 = e.Row.FindControl("ImageButton1") as ImageButton;

            if (hdnDeleted.Value.Trim() == "1")
            {
                LinkButton1.Visible = false;
                ImageButton1.Visible = false;
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
        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
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
                    Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
                }
            }
        }
    }
    protected void gridEbooks_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_sortExpr = e.SortExpression;
        m_sortDir = e.SortDirection;

        ViewState["SortExpr"] = m_sortExpr;

        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), m_sortExpr, SortOrder);
    }    
    protected void Subscribe_Email(object sender, CommandEventArgs e)
    {
        String Sno = String.Empty;
        String Email = String.Empty;

        string[] IDs = e.CommandArgument.ToString().Split(',');
        foreach (string ID in IDs)
        {
            Sno = IDs[0];
            Email = IDs[1];
        }

        int tmpStatus = objeBook.Update_UnSubscribedEmail(Session["UserID"].ToString(), Sno);

        CommonFunctions.AlertMessage(Email + " is subscribed in list now.");
        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }    
}

