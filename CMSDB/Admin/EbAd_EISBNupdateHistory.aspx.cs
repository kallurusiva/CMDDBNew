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
using System.Net;

public partial class Admin_EbAd_EISBNupdateHistory : System.Web.UI.Page
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
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "UID";
            ViewState["totalGained"] = "0.00";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        int vUserID = Convert.ToInt32(Session["UserID"]);
        ds = objPS.ebook_EISBNupdateHistory(Session["UserID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }

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
            Image lblImageFilePath = (Image)e.Row.FindControl("lblImageFilePath");
            if (lblImageFilePath.ImageUrl == "")
            {
                lblImageFilePath.Visible = false;
            }
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
           
        }
    }

    protected void OnCommand_ImageSendSMS(object sender, CommandEventArgs e)
    {
        
    }

    protected void OnCommand_ImageSendEmail(object sender, CommandEventArgs e)
    {
        

    }

    protected void OnCommand_SendEmail(object sender, CommandEventArgs e)
    {
        
    }

}
