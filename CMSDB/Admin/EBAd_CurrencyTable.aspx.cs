using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net;

public partial class Admin_EBAd_CurrencyTable : System.Web.UI.Page
{
    int tmpRowCount;
    int tmpTotalRecord = 0;

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

        if (!IsPostBack)
        {
            ViewState["SortOrder"] = "";
            ViewState["SortExpr"] = "";
            ViewState["PageID"] = "1";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
        }

        tblMessageBar.Visible = false;
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        String mUserId = string.Empty;
        if (Session["MobileLoginID"] != null)
        {
            mUserId = Session["MobileLoginID"].ToString().Replace("EB", "");
        }

        newDBS ndbs = new newDBS();

        ds = ndbs.user_getCurrencyTable(mUserId.ToString());

        if (ds.Tables[1].Rows.Count > 0)
        {
            DataRow bkRow = ds.Tables[1].Rows[0];
            lblCBal.Text = bkRow["currentBalance"].ToString();
            Label1.Text = bkRow["rate"].ToString();
            Label2.Text = bkRow["rate"].ToString();
            Label3.Text = bkRow["Denomination"].ToString();
            Label4.Text = bkRow["cashout"].ToString();
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            tmpRowCount = ds.Tables[0].Rows.Count;
            tmpTotalRecord = Convert.ToInt32(ds.Tables[2].Rows[0]["TotalRecord"].ToString());
            ViewState["TotalRecord"] = tmpTotalRecord.ToString();

            dv = ds.Tables[0].DefaultView;
            //if (vSortExpr != string.Empty)
            //{
            //    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            //}

            gridEbooks.DataSource = dv;
            gridEbooks.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridEbooks.DataSource = ds;
            gridEbooks.DataBind();

            int ColCount = gridEbooks.Rows[0].Cells.Count;
            gridEbooks.Rows[0].Cells.Clear();
            gridEbooks.Rows[0].Cells.Add(new TableCell());
            gridEbooks.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridEbooks.Rows[0].Cells[0].Text = "No records Found";
            gridEbooks.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
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

    protected void gridEbooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEbooks.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }

    protected void gridEbooks_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(gridEbooks.PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), gridEbooks.BottomPagerRow, gridEbooks);
    }

    protected void gridEbooks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) && (tmpRowCount > 0))
        {
        }
    }

    protected void gridEbooks_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
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
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
                }
            }
        }
    }

    protected void OnCommand_ImageSendSMS(object sender, CommandEventArgs e)
    {
        string TIDval = e.CommandArgument.ToString();
        newDBS nds = new newDBS();
        DataSet dsResend = nds.resendSMS_EBook(TIDval);
        if (dsResend.Tables[0].Rows.Count > 0)
        {
            string retMsg = dsResend.Tables[0].Rows[0]["returnMessage"].ToString();
            CommonFunctions.AlertMessage(retMsg);
        }
    }

    protected void OnCommand_ImageSendEmail(object sender, CommandEventArgs e)
    {
        string strSMSvalue = e.CommandArgument.ToString();
        HttpWebRequest WebReq = null;
        HttpWebResponse WebResp;

        WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

        WebReq.Method = "GET";
        WebResp = (HttpWebResponse)WebReq.GetResponse();
        if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
        {
            Stream _Answer = WebResp.GetResponseStream();
            StreamReader Answer = new StreamReader(_Answer);
            String strTemp = Answer.ReadToEnd();
        }

        CommonFunctions.AlertMessage("Email sent successfully");
    }

    protected void OnCommand_SendEmail(object sender, CommandEventArgs e)
    {
        string emailVal = e.CommandArgument.ToString();
        Server.Transfer(@"EbAd_SendEmailInd.aspx?LID=" + emailVal.Trim());
    }

    protected void OnCommand_SendSMS(object sender, CommandEventArgs e)
    {
        string[] IDs = e.CommandArgument.ToString().Split(',');
        string tMobile = string.Empty;

        foreach (string ID in IDs)
        {
            hdn_IdentifierID.Value = IDs[0];
            hdn_tid.Value = IDs[1];
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
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["SortOrder"].ToString());
    }

}
