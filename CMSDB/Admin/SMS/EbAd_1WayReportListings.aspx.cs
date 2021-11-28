using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Globalization;


public partial class Admin_SMS_EbAd_1WayReportListings : System.Web.UI.Page
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
            ViewState["SortExpr"] = "HistID";
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
                TextBox TextBoxSearchValue = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxSearchValue") as TextBox;
                RadioButtonList RadioButtonList2 = PreviousPage.Master.FindControl("ContentBody").FindControl("RadioButtonList2") as RadioButtonList;
                
                String strDateFrom = tDFrom1.Value;
                String strDateTo = tDTo1.Value;
                String strSearch = ddlSearchItem.SelectedValue;
                String strSearchVal = TextBoxSearchValue.Text;
                String sFieldName = String.Empty;

                if (strSearchVal != "")
                {
                    if ((strSearch == "MB") && (strSearchVal != ""))
                    {
                        sFieldName = "p.Mobile";
                    }
                    else if ((strSearch == "MSG") && (strSearchVal != ""))
                    {
                        sFieldName = "p.Message";
                    }
                    else if ((strSearch == "RPT") && (strSearchVal != ""))
                    {
                        sFieldName = "p.ReportName";
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

                tmpSearchSQL = tmpSearchSQL + ConvertDate(strDateFrom, strDateTo, "0");

                //Response.Write(tmpSearchSQL.ToString());
                //Response.End();

                ViewState["tmpSearchSQL"] = tmpSearchSQL;
                hdnReportTypeSQL.Value = tmpSearchSQL;
                
                Populate_GridView1(ViewState["tmpSearchSQL"].ToString(), ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());

            }
        }
    }

    protected  String ConvertDate(String strDateFrom, String strDateTo, String sTimeDiff)
    {
        //DateTime dtFrom = DateTime.ParseExact(strDateFrom, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
        //DateTime dtTo = DateTime.ParseExact(strDateTo, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);

        //Response.Write(strDateFrom + " , ");
        //Response.Write(strDateTo + " , ");

        DateTime dtFrom = Convert.ToDateTime(strDateFrom);
        DateTime dtTo = Convert.ToDateTime(strDateTo);
        if (dtFrom==dtTo)
        {
            dtFrom = dtFrom.AddDays(-1);
        }
        dtTo = dtTo.AddDays(1);

        //string code = "en-US";
        //DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(CultureInfo.GetCultureInfo(code));
        //string vFromDate = dtFrom.ToString(info.ShortDatePattern, new System.Globalization.CultureInfo(code));
        //String vToDate = dtTo.ToString(info.ShortDatePattern, new System.Globalization.CultureInfo(code));

        //Response.Write(vFromDate + " , ");
        //Response.Write(vToDate + " , ");


        String tDateFrom = dtFrom.ToString("MM/dd/yyyy") + " " + dtFrom.ToShortTimeString();
        String tDateTo = dtTo.ToString("MM/dd/yyyy") + " " + dtTo.ToLongTimeString();

        String tmpSearchSQL = String.Empty;

        tmpSearchSQL = tmpSearchSQL + " and DateAdd(n," + sTimeDiff + ",SendOn) BETWEEN '" + tDateFrom + "' AND '" + tDateTo + "'";

        //Response.Write(dtFrom.ToString() + " , ");
        //Response.Write(dtTo.ToString() + " , ");
        //Response.Write(tmpSearchSQL); 
        

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

        

        ds = objMalaysia.Retrieve_1WayReport(Session["MERID"].ToString(), strPageNo, gridEbooks.PageSize.ToString(),"0", vSearchSql);

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
            Label lblMessage = e.Row.FindControl("lblMessage") as Label;
            HiddenField hdnCreditType = e.Row.FindControl("hdnCreditType") as HiddenField;
            HiddenField hdnRefID = e.Row.FindControl("hdnRefID") as HiddenField;

            ImageButton ImageButtonSMSType = e.Row.FindControl("ImageButtonSMSType") as ImageButton;
            ImageButton ImageButtonR = e.Row.FindControl("ImageButtonR") as ImageButton;
            LinkButton LinkButtonR = e.Row.FindControl("LinkButtonR") as LinkButton;
                       
            lblMessage.Text = CommonFunctions.decodeSMSMessage(lblMessage.Text);

            HiddenField hdnMessage = e.Row.FindControl("hdnMessage") as HiddenField;
            string sMsg = CommonFunctions.ConvertHexBytesToString(hdnMessage.Value);

            lblMessage.Text = sMsg;
            lblMessage.Text = CommonFunctions.decodeSMSMessage(lblMessage.Text);

            String sType = hdnCreditType.Value.Trim();

            if ((sType == "SMSSAP") || (sType == "SMSCHS"))
            {
                ImageButtonSMSType.ImageUrl = "~/Images/icon_type_schedule.png";
                ImageButtonSMSType.ToolTip = "Schedule SMS";
            }
            else
            {
                ImageButtonSMSType.ImageUrl = "~/Images/icon_type_normal.png";
                ImageButtonSMSType.ToolTip = "Normal SMS";
            }

            if ((sType == "SMSEMAIL") || (sType == "SMSEML"))
            {
                ImageButtonR.Visible = false;
                LinkButtonR.Visible = false;
            }

            int j = 0;

            bool isNumeric = Int32.TryParse(hdnRefID.Value, out j);

            if (!isNumeric)
            {
                ImageButtonR.PostBackUrl = "EbAd_1WayReportCheckMobile.aspx";
                LinkButtonR.PostBackUrl = "EbAd_1WayReportCheckMobile.aspx";
            }
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
        hdnHistID.Value = e.CommandArgument.ToString().Trim();        
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
