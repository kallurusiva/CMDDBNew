using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

public partial class Admin_PremiumSMSReport_Introducer : System.Web.UI.Page
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;


    newDBS objPS = new newDBS();
    string mobileValPS = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        mobileValPS = Session["LoginID"].ToString();
        mobileValPS = mobileValPS.Replace("EB", "");
        ViewState["mobileValPS"] = mobileValPS;


        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "RowID";
            ViewState["totalGained"] = "0.00";


            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }


    }


    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        //  ds = objPayPal.EB_PayPal_RetrieveTX(Convert.ToInt32(Session["UserID"]), ""); 

        int vUserID = Convert.ToInt32(Session["UserID"]);

        ds = objPS.PremiumSMS_Report(ViewState["mobileValPS"].ToString(), 3);

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            DataRow utRow = ds.Tables[1].Rows[0];
            ViewState["totalGained"] = utRow["SumPrice"].ToString();
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            gridBankInBys.DataSource = dv;
            gridBankInBys.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridBankInBys.DataSource = ds;
            gridBankInBys.DataBind();

            int ColCount = gridBankInBys.Rows[0].Cells.Count;
            gridBankInBys.Rows[0].Cells.Clear();
            gridBankInBys.Rows[0].Cells.Add(new TableCell());
            gridBankInBys.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridBankInBys.Rows[0].Cells[0].Text = "No records Found";
            gridBankInBys.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void gridBankInBys_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridBankInBys.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridBankInBys.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridBankInBys.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridBankInBys.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridBankInBys_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
    }

    protected void gridBankInBys_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    protected void gridBankInBys_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }



    protected void gridBankInBys_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridBankInBys.BottomPagerRow, gridBankInBys);
    }


    protected void gridBankInBys_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {


        }
    }




    protected void gridBankInBys_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
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



    protected void gridBankInBys_RowCommand(object sender, GridViewCommandEventArgs e)
    {




    }


    protected void OnCommand_ConfirmPayment(object sender, CommandEventArgs e)
    {

    }


    protected void gridBankInBys_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int intNoOfMergeCol = e.Row.Cells.Count - 2; /*except last column */

            GridViewRow footerRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);

            //Adding Footer Total Text Column
            TableCell cell = new TableCell();

            footerRow.Cells.Add(cell);

            //if(GridView1.PageCount >1)
            gridBankInBys.Controls[0].Controls.Add(footerRow);

            // First cell is used for specifying the Total text
            for (int intCellCol = 1; intCellCol < intNoOfMergeCol; intCellCol++)
                e.Row.Cells.RemoveAt(1);
            e.Row.Cells[0].ColumnSpan = intNoOfMergeCol;
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[1].Text = "";
            e.Row.Cells[2].Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(ViewState["totalGained"]))).ToString();
            //e.Row.Cells[3].Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(ViewState["totalLost"]))).ToString();            
        }
    }
}
