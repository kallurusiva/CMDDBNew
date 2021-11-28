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

public partial class Admin_Ad_CurrencyConvertList : System.Web.UI.Page
{
    DataView dv;
    DataSet ds;
    //DataView DL;
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
            ViewState["SortExpr"] = "currency";
            ViewState["tmpSearchSQL"] = "";
            ViewState["TotalRecord"] = "0";
            ViewState["PageID"] = "1";

            mobileValPS = Session["LoginID"].ToString();
            mobileValPS = mobileValPS.Replace("EB", "");          

            String qPcode = string.Empty;
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

        ds = objPS.CurrencyConvert_List(Session["UserID"].ToString(), "");

        
      

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

            Label lblShortCode = ((Label)e.Row.FindControl("lblShortCode"));

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
        hdnMobile.Value = mobileValPS;

        Server.Transfer(@"Ad_CurrencyConvertEdit.aspx?CCODE=" + hdnSno.Value.ToString());
    }

   
}