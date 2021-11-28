using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_SMS_EbAd_TopupByPayPalList : System.Web.UI.Page
{
    //double tmpTotal = 0;
    int tmpRowCount = 0;

    DataSet ds;
    //DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();
    CMSv3.BAL.IFMDomains objDomains = new CMSv3.BAL.IFMDomains();

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
            ViewState["PageID"] = "1";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
        }
    }
    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        ds = objMalaysia.Retrieve_GSPayPalHistory("SMSTOPUP", Session["MERID"].ToString(), "");

        DataTable t1 = new DataTable();
        t1 = ds.Tables[0];

        DataColumn column1 = new DataColumn();
        column1.DataType = System.Type.GetType("System.String");
        //column1.AllowDBNull = false;
        column1.Caption = "Status Admin";
        column1.ColumnName = "StatusAd";
        //column1.DefaultValue = Resources.LangResources.StatusPending;
        column1.DefaultValue = "Pending";

        t1.Columns.Add(column1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            string strPayPalId = "";
            DataView dvPayPal = ds.Tables[1].DefaultView;

            foreach (DataRowView drv in dvPayPal)
            {
                strPayPalId = strPayPalId + ",'paypal-" + drv["UID"].ToString() + "'";
            }

            DataSet dsID = objDomains.Retrieve_PayPalHistory(strPayPalId);

            // This is table from Hitech to be Merge with PayPal 
            DataTable t2 = new DataTable();
            t2 = dsID.Tables[0];

            int t = 0;

            if (dsID.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in t1.Rows)
                {
                    String strMsgId = t2.Rows[t]["MsgId"].ToString().Replace("paypal-", "");

                    if (dr["UID"].ToString() == strMsgId)// Check MID as unique identifier from both tables
                    {
                        dr["StatusAd"] = "Complete";
                        //dr["StatusAd"] = Resources.LangResources.StatusComplete;
                    }
                    t = t + 1;
                }
            }

            tmpRowCount = ds.Tables[0].Rows.Count;

            if (vSortExpr != string.Empty)
            {
                t1.DefaultView.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }

            //Retrieve GrandTotalAmount
            DataRow utRow = ds.Tables[2].Rows[0];
            ViewState["tmpGrandTotal"] = utRow["SumAmt"].ToString();

            GridView1.DataSource = t1.DefaultView;
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
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
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
        CommonFunctions.InitialiseGridViewPagerRowWithImages(GridView1.BottomPagerRow, GridView1);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["PageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (GridView1.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < GridView1.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    GridView1.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
                }
            }
        }
    }    
}
