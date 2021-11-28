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

public partial class Admin_EBAd_PartnerDetaills : System.Web.UI.Page
{
    DataView dv;
    DataSet ds;

    String m_sortExpr = String.Empty;
    SortDirection m_sortDir = SortDirection.Ascending;

    //double tmpTotal = 0;
    int tmpRowCount = 0;
    int tmpTotalRecord = 0;
    int PageSize = 500;

    newDBS objHitech = new newDBS();
    string mobileValPS = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        if (!IsPostBack)
        {
            ViewState["SortOrder"] = "";
            ViewState["SortExpr"] = ""; //MID
            ViewState["tmpSearchSQL"] = "";
            ViewState["tmpMobile"] = "";
            ViewState["tmpName"] = "";
            ViewState["TotalRecord"] = "0";
            ViewState["PageID"] = "1";

            Populate_DirectAffiliatePartners(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
        }
    }


    protected void Populate_DirectAffiliatePartners(String vSearchSql, String vSortExpr, String vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        ds = objHitech.Retrieve_DirectAffiliateBGPartnersNew(Session["LoginID"].ToString().Replace("EB", ""), ViewState["tmpMobile"].ToString(), ViewState["tmpName"].ToString(), Convert.ToInt32(strPageNo), 0, 0);

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
            GridView1.Rows[0].Cells[0].Text = "RecordNotFound";
            GridView1.Rows[0].Cells[0].CssClass = "txtRedMedium";
            GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_sortExpr = e.SortExpression;
        m_sortDir = e.SortDirection;

        ViewState["SortExpr"] = m_sortExpr;

        Populate_DirectAffiliatePartners(ViewState["tmpSearchSQL"].ToString(), m_sortExpr, SortOrder);
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

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), GridView1.BottomPagerRow, GridView1);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Populate_DirectAffiliatePartners(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (tmpTotalRecord > 0))
        {
            HiddenField hdnMID = ((HiddenField)e.Row.FindControl("hdnMID"));
            HiddenField hdnCtryCode = ((HiddenField)e.Row.FindControl("hdnCtryCode"));
            HiddenField hdnEmailStatus = ((HiddenField)e.Row.FindControl("hdnEmailStatus"));

            Image ImageCtry = ((Image)e.Row.FindControl("ImageCtry"));
            Label lblSMSbal = ((Label)e.Row.FindControl("lblSMSbal"));

            Label lblLoginId = ((Label)e.Row.FindControl("lblLoginId"));
            Label lblMemberName = ((Label)e.Row.FindControl("lblMemberName"));
            LinkButton hypBonus = ((LinkButton)e.Row.FindControl("hypBonus"));
            LinkButton hypGlobal = ((LinkButton)e.Row.FindControl("hypGlobal"));

            ImageCtry.ImageUrl = "../Images/" + hdnCtryCode.Value + "_flag.gif";

            String strEmailS = hdnEmailStatus.Value.Trim();
            String strMobileNo = lblLoginId.Text.Trim();

            if ((strMobileNo.Length > 0) && (strMobileNo.Length < 14))
            {
            }

            if ((strMobileNo.Length > 0) && (strMobileNo.Length <= 14))
            {
            }

            if (strMobileNo.Substring(0, 2) == "62")
            {
            }
        }
    }

    protected void pageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
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
                    Populate_DirectAffiliatePartners(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
                }
            }
        }
    }

    protected void Button_SearchSubmit(object sender, EventArgs e)
    {
        String tmpSearchSQL = "";
        ViewState["PageID"] = "1";

        ViewState["tmpSearchSQL"] = tmpSearchSQL;
        Populate_DirectAffiliatePartners(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }

    protected void btnRefine_Click(object sender, EventArgs e)
    {
        ViewState["PageID"] = "1";
        Populate_DirectAffiliatePartners("", ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }    

    protected void BtnPaging(object sender, CommandEventArgs e)
    {
        int strPageNo = Convert.ToInt32(ViewState["PageID"]);
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

        ViewState["PageID"] = strPageNo.ToString();
        Populate_DirectAffiliatePartners(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }

    protected void btnSMSnow(object sender, CommandEventArgs e)
    {
    }

    protected void btnSendSMS_Click(object sender, EventArgs e)
    {
    }

}