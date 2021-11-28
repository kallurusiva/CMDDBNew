using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_SMS_EbAd_PremiumReportListings : System.Web.UI.Page
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
            ViewState["SortOrder"] = "desc";
            ViewState["SortExpr"] = "TID";
            ViewState["TotalRecord"] = "0";
            ViewState["tmpSearchSQL"] = "";
            ViewState["TimeDiff"] = "0";
            ViewState["PageID"] = "1";

            String tmpSearchSQL = String.Empty;

            if (this.PreviousPage != null)
            {
                HiddenField tDFrom1 = PreviousPage.Master.FindControl("ContentBody").FindControl("hdnDFrom") as HiddenField;
                HiddenField tDTo1 = PreviousPage.Master.FindControl("ContentBody").FindControl("hdnDTo") as HiddenField;
                DropDownList ddlSearchItem = PreviousPage.Master.FindControl("ContentBody").FindControl("ddlSearchItem") as DropDownList;
                DropDownList DropDownSearchString = PreviousPage.Master.FindControl("ContentBody").FindControl("DropDownSearchString") as DropDownList;
                RadioButtonList RadioButtonList2 = PreviousPage.Master.FindControl("ContentBody").FindControl("RadioButtonList2") as RadioButtonList;
                TextBox TextBoxSearchValue = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxSearchValue") as TextBox;

                String strDateFrom = tDFrom1.Value;
                String strDateTo = tDTo1.Value;
                String strSearch = ddlSearchItem.SelectedValue;
                String strSearchTtype = DropDownSearchString.SelectedValue;
                String strSearchVal = TextBoxSearchValue.Text;
                String sFieldName = String.Empty;

                if (strSearchVal != "")
                {
                    if ((strSearchTtype == "MB") && (strSearchVal != ""))
                    {
                        sFieldName = "t.Mobile";
                    }
                    else if ((strSearchTtype == "MSG") && (strSearchVal != ""))
                    {
                        sFieldName = "p.Message";
                    }

                    if (RadioButtonList2.SelectedValue == "S")
                    {
                        tmpSearchSQL = tmpSearchSQL + CommonFunctions.StartsWithSearchString(sFieldName, strSearchVal);
                    }
                    else if (RadioButtonList2.SelectedValue == "E")
                    {
                        tmpSearchSQL = tmpSearchSQL + CommonFunctions.ExactSearchString(sFieldName, strSearchVal);
                    }
                    else if (RadioButtonList2.SelectedValue == "A")
                    {
                        tmpSearchSQL = tmpSearchSQL + CommonFunctions.AnySearchString(sFieldName, strSearchVal);
                    }
                }

                if (strSearch != "0")
                {
                    tmpSearchSQL = tmpSearchSQL + " and Code='" + strSearch + "'";
                }

                lblSubHeader.Text = "2 Way Ebook Reports";
                tmpSearchSQL = tmpSearchSQL + ConvertDate(strDateFrom, strDateTo, "0");
            }
            else
            {
                lblSubHeader.Text = "My Profit Sharing for Current Month : " + DateTime.Today.ToString("MMMM yyyy");
                tmpSearchSQL = " and (Month(Tdate)=" + DateTime.Today.Month.ToString() + " and Year(TDate)=" + DateTime.Today.Year.ToString() + ")";
            }

            ViewState["tmpSearchSQL"] = tmpSearchSQL;
            hdnReportTypeSQL.Value = tmpSearchSQL;
            Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
        }
    }
    protected static String ConvertDate(String strDateFrom, String strDateTo, String sTimeDiff)
    {

        DateTime dtFrom = Convert.ToDateTime(strDateFrom).AddMinutes(Convert.ToInt32(sTimeDiff));
        DateTime dtTo = Convert.ToDateTime(strDateTo).AddDays(1).AddMinutes(Convert.ToInt32(sTimeDiff));

        String tDateFrom = dtFrom.ToString("MM/dd/yyyy") + " " + dtFrom.ToLongTimeString();
        String tDateTo = dtTo.ToString("MM/dd/yyyy") + " " + dtTo.ToLongTimeString();

        String tmpSearchSQL = String.Empty;

        tmpSearchSQL = tmpSearchSQL + " and TDate BETWEEN '" + tDateFrom + "' AND '" + tDateTo + "'";


        return tmpSearchSQL;
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

        ds = objMalaysia.Retrieve_2WayReport(Session["MERID"].ToString(), strPageNo, gridEbooks.PageSize.ToString(), vSearchSql);

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
            Label lblSendOn = e.Row.FindControl("lblSendOn") as Label;
            Label lblMessage = e.Row.FindControl("lblMessage") as Label;
            Label lblRMessage = e.Row.FindControl("lblRMessage") as Label;
            //HiddenField hdnHistID = e.Row.FindControl("hdnHistID") as HiddenField;
            HiddenField hdnRMessage = e.Row.FindControl("hdnRMessage") as HiddenField;
            //LinkButton LinkButtonR = e.Row.FindControl("LinkButtonR") as LinkButton;
            //ImageButton ImageButtonR = e.Row.FindControl("ImageButtonR") as ImageButton;

            if (CommonFunctions.isValidDate(lblSendOn.Text))
            {
                DateTime dt = Convert.ToDateTime(lblSendOn.Text);
                lblSendOn.Text = dt.ToString("dd-MMM-yyyy hh:mm tt");
            }
            lblMessage.Text = CommonFunctions.decodeSMSMessage(lblMessage.Text);

            if (hdnRMessage.Value.Trim().Length > 0)
            {
                lblRMessage.Text = CommonFunctions.ConvertHexBytesToString(hdnRMessage.Value);
                lblRMessage.Text = CommonFunctions.decodeSMSMessage(lblRMessage.Text);
            }

            //if (hdnHistID.Value.Trim() != "0")
            //{
            //    LinkButtonR.Visible = true;
            //    ImageButtonR.Visible = true;
            //}
            //else
            //{
            //    LinkButtonR.Visible = false;
            //    ImageButtonR.Visible = false;
            //}
        }
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
    protected void CheckStatus(object sender, CommandEventArgs e)
    {
        String HistID = e.CommandArgument.ToString().Trim();
        hdnHistID.Value = HistID;
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
}
