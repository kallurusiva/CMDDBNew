using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_SMS_EbAd_EBook_CreateList_BookCode_Specific_FreeSYS : System.Web.UI.Page
{
    int tmpRowCount;
    int tmpTotalRecord = 0;
    string LID = string.Empty;

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
        LID = Request.QueryString["LID"].ToString();
        if (!IsPostBack)
        {
            ViewState["SortOrder"] = "";
            ViewState["SortExpr"] = "";
            ViewState["PageID"] = "1";
            ViewState["LID"] = LID;
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
        }
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();
        newDBS ndbs = new newDBS();
        ds = ndbs.Ebook_CreateList_BookCode_Specific_FreeSYS(Session["UserID"].ToString(), ViewState["LID"].ToString(), strPageNo);

        if (ds.Tables[0].Rows.Count > 0)
        {
            tmpRowCount = ds.Tables[0].Rows.Count;
            tmpTotalRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRecord"].ToString());
            //tmpTotalRecord = tmpRowCount;
            ViewState["TotalRecord"] = tmpTotalRecord.ToString();

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }

            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            GridView1.DataSource = ds;
            GridView1.DataBind();

            int ColCount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridView1.Rows[0].Cells[0].Text = "No records Found";
            GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(GridView1.PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), GridView1.BottomPagerRow, GridView1);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        int PageCount = tmpTotalRecord / GridView1.PageSize;
        if (tmpTotalRecord % GridView1.PageSize > 0)
            PageCount++;

        ViewState["PageID"] = pageNumberDropDownList.SelectedValue;

        if (pageNumberDropDownList != null)
        {
            if (GridView1.Rows.Count > 0)
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
        int PageSize = Convert.ToInt32(GridView1.PageSize);

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

    protected void Button_View(object sender, CommandEventArgs e)
    {
        string s = e.CommandArgument.ToString();
        hdnSno.Value = s.Trim();
        Server.Transfer(@"EbAd_CreateListView_Complete.aspx?LID=" + s.Trim());
    }

    protected void Button_Delete(object sender, CommandEventArgs e)
    {
        string s = e.CommandArgument.ToString();
        newDBS ndbs = new newDBS();
        ds = ndbs.Ebook_CreateList_BookCode_delete_FreeSYS(Session["UserID"].ToString(), s.Trim());
        CommonFunctions.AlertMessage("Deletion Done");
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }

}
