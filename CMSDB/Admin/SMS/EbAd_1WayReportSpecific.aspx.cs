using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_SMS_EbAd_1WayReportSpecific : System.Web.UI.Page
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
                    Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
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
    protected void Populate_GridView1(String vSearchSql, String vSortExpr, String vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        ds = objMalaysia.Retrieve_1WayReport_Specific(ViewState["HistID"].ToString(), strPageNo, GridView1.PageSize.ToString(), vSearchSql);
        String tMobile = String.Empty;
        String tMsg = String.Empty;

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];

            tMobile = utRow["Mobile"].ToString();
            String tHistID = utRow["HistID"].ToString();

            String tSender = utRow["Sender"].ToString();
            String tCredits = utRow["Credits"].ToString();
            String tCreditType = utRow["CreditType"].ToString();
            String tRefID = utRow["RefID"].ToString();

            //tMsg = CommonFunctions.ConvertHexBytesToString(utRow["Message"].ToString());
            //LabelCompleteMessage.Text = CommonFunctions.decodeSMSMessage(tMsg);

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


                    GridView1.DataSource = dv;
                    GridView1.DataBind();

                    GridView1.HeaderRow.Cells[3].ColumnSpan = 3;
                    GridView1.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                    GridView1.HeaderRow.Cells[4].Visible = false;
                }
                else
                {
                    DataTable dt = ds.Tables[1];

                    String[] tMobileList = tMobile.Split(',');

                    int i = 1;
                    ViewState["SMSType"] = "0";

                    foreach (string tMobileNo in tMobileList)
                    {
                        DataRow utRow1 = dt.NewRow();
                        if (tMobileNo != "")
                        {
                            utRow1["Row"] = i.ToString();
                            utRow1["Mobile"] = tMobileNo;
                            utRow1["MsgNo"] = "1";
                            utRow1["Dstat"] = "1";
                            utRow1["GCode"] = "1";
                            utRow1["ExecStat"] = "1";
                            utRow1["SMSStatus"] = "Delivered";
                            dt.Rows.InsertAt(utRow1, 0);
                        }

                        i = i + 1;
                    }
                    dt.DefaultView.Sort = "Row asc";
                    GridView1.DataSource = dt.DefaultView;
                    GridView1.DataBind();

                    GridView1.HeaderRow.Cells[3].ColumnSpan = 3;
                    GridView1.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                    GridView1.HeaderRow.Cells[4].Visible = false;
                }
                           
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_sortExpr = e.SortExpression;
        m_sortDir = e.SortDirection;

        ViewState["SortExpr"] = m_sortExpr;

        Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), m_sortExpr, SortOrder);
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(GridView1.PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), GridView1.BottomPagerRow, GridView1);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (tmpRowCount > 0))
        {
            HiddenField hdnExecStat = e.Row.FindControl("hdnExecStat") as HiddenField;
            HiddenField hdnGCode = e.Row.FindControl("hdnGCode") as HiddenField;
            HiddenField hdnDstat = e.Row.FindControl("hdnDstat") as HiddenField;
            Label lblSMSStatus = e.Row.FindControl("lblSMSStatus") as Label;

            if (hdnExecStat.Value == "2")
            {
                lblSMSStatus.Text = "Under Queued";
            }
            else if (hdnGCode.Value == "1")
            {
                lblSMSStatus.Text = hdnDstat.Value;
            }
            else
            {
                lblSMSStatus.Text = "";  
            }
        }
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
                    Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
                }
            }
        }
    }
    protected void BtnPaging(object sender, CommandEventArgs e)
    {
        int strPageNo = Convert.ToInt32(ViewState["PageID"]);
        int PageSize = GridView1.PageSize;

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
