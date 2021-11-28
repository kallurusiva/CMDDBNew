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

public partial class Admin_EBAd_BookCodes_FreeSys : System.Web.UI.Page
{

    #region Variables

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;
    newDBS objPS = new newDBS();
    string mobileValPS = string.Empty;

    #endregion    

    protected void Page_Load(object sender, EventArgs e)
    {
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

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
        int vUserID = Convert.ToInt32(Session["UserID"]);
        ds = objPS.PremiumSMS_ReportFreeSYS(ViewState["mobileValPS"].ToString(), 0);

        //if (ds.Tables[2].Rows.Count > 0)
        //{
        //    DataView dv2 = ds.Tables[2].DefaultView;
        //    DataRow utRow2 = ds.Tables[2].Rows[0];
        //    string smsBalance = utRow2["smsBalance"].ToString();

        //    if (Convert.ToDouble(smsBalance) < -20)
        //    {
        //        CommonFunctions.AlertMessageAndRedirect("InSufficient SMS Balance. Please Topup SMS to view Sales Record. Your SMS Balance: " + smsBalance.ToString(), "SMS/EBAd_TopupByPayPal.aspx");
        //    }
        //}

        if (ds.Tables[0].Rows.Count > 0)
        {
            dv = ds.Tables[0].DefaultView;
            //DataRow utRow = ds.Tables[1].Rows[0];
            //ViewState["totalGained"] = utRow["SumPrice"].ToString();
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
        if (strSMSvalue.Length < 10)
        {
            MgMail.sndMailgunLinks(strSMSvalue.ToString(), "0", "");
        }
        else
        {
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
        }

        CommonFunctions.AlertMessage("Email sent successfully");
    }

    protected void OnCommand_SendEmail(object sender, CommandEventArgs e)
    {
        string emailVal = e.CommandArgument.ToString();
        Server.Transfer(@"EbAd_SendEmailInd.aspx?LID=" + emailVal.Trim());
    }

    protected void OnCommand_ImageSendTelegram(object sender, CommandEventArgs e)
    {
        String strSMSvalue = e.CommandArgument.ToString();
        string[] telegramList = strSMSvalue.Split('^');
        string chatid = telegramList[0].ToString();
        string tMessage = telegramList[1].ToString();

        strSMSvalue = "http://gt.evenchise.com/MessageTestAdmin.aspx?botID=21&chatid=" + chatid.ToString();
        strSMSvalue = strSMSvalue + "&message=" + Server.UrlEncode(tMessage.ToString());

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

        CommonFunctions.AlertMessage("Telegram Message sent successfully");
    }

}
