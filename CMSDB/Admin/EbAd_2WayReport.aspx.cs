using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

public partial class Admin_EbAd_2WayReport : System.Web.UI.Page
{
    int iStartYear = 2013;

    DataSet ds;
     
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
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
            Populate_DateList();
            Populate_EbookCodes();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Server.Transfer(@"EbAd_2WayReportListings.aspx");
        }
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String strDateFrom = hdnDFrom.Value;
            String strDateTo = hdnDTo.Value;
            String strSearch = ddlSearchItem.SelectedValue;
            String strSearchTtype = DropDownSearchString.SelectedValue;
            String strSearchVal = TextBoxSearchValue.Text.Trim();
            String sFieldName = String.Empty;
            String tmpSearchSQL = String.Empty;

          
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

                tmpSearchSQL = tmpSearchSQL + ConvertDate(strDateFrom, strDateTo, "0");
                Response.Write(tmpSearchSQL);

                ds = objMalaysia.Retrieve_2WayReport(Session["MERID"].ToString(), "1", "1000", tmpSearchSQL);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    GridView gv = new GridView();
                    gv.AllowPaging = false;
                    gv.DataSource = ds;
                    gv.DataBind();

                    gv.HeaderRow.Attributes.Add("font", "bold");
                    gv.HeaderRow.HorizontalAlign = HorizontalAlign.Left;

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=2WayReport_Report_Excel.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/text";

                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gv.RenderControl(hw);
                    Response.Output.Write(Server.HtmlDecode(sw.ToString()));
                    Response.Flush();
                    Response.End();
                }               
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"EbAd_2WayReport.aspx");
    }
    protected void Populate_CheckDate()
    {
        String strFrom = ddlDateFromDay.SelectedValue + "/" + ddlDateFromMonth.SelectedValue + "/" + ddlDateFromYear.SelectedValue;
        String strTo = ddlDateToDay.SelectedValue + "/" + ddlDateToMonth.SelectedValue + "/" + ddlDateToYear.SelectedValue;
    }
    protected void Populate_DateList()
    {
        int i;
        
        for (i = 1; i <= 12; i++)
        {
            DateTime date = new DateTime(iStartYear, i, 1);
            ddlDateFromMonth.Items.Add(new ListItem(date.ToString("MMMM"), i.ToString()));
            ddlDateToMonth.Items.Add(new ListItem(date.ToString("MMMM"), i.ToString()));
        }
        for (i = 1; i <= 31; i++)
        {
            ddlDateFromDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlDateToDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        for (i = DateTime.Today.Year; i >= iStartYear; i--)
        {
            ddlDateFromYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlDateToYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        ddlDateFromMonth.SelectedValue = ddlDateToMonth.SelectedValue = DateTime.Now.Month.ToString();
        ddlDateFromDay.SelectedValue = ddlDateToDay.SelectedValue = DateTime.Now.Day.ToString();
        ddlDateFromYear.SelectedValue = ddlDateToYear.SelectedValue = DateTime.Now.Year.ToString();

        Populate_DateToDayinMonthYear(Convert.ToInt32(ddlDateToYear.SelectedValue), Convert.ToInt16(ddlDateToMonth.SelectedValue));
        Populate_DateFromDayinMonthYear(Convert.ToInt32(ddlDateFromYear.SelectedValue), Convert.ToInt16(ddlDateFromMonth.SelectedValue));
    }
    protected void Populate_EbookCodes()
    {
        ds = objEbook.Retrieve_2WayEbookCodes(Session["UserID"].ToString(), Session["MERID"].ToString(), "");

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlSearchItem.DataSource = ds;
            ddlSearchItem.DataTextField = "JUSTBOOKNAME";
            ddlSearchItem.DataValueField = "BOOKID";
            ddlSearchItem.DataBind();
            ddlSearchItem.Items.Insert(0, new ListItem("Select All EBook Codes", "0"));
        }
    }
    protected void ddlDateFromMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateFromYear.SelectedValue != "" && ddlDateFromMonth.SelectedValue != "")
        { Populate_DateFromDayinMonthYear(Convert.ToInt32(ddlDateFromYear.SelectedValue), Convert.ToInt16(ddlDateFromMonth.SelectedValue)); }
    }
    protected void ddlDateFromDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateFromYear.SelectedValue != "" && ddlDateFromMonth.SelectedValue != "")
        { Populate_DateFromDayinMonthYear(Convert.ToInt32(ddlDateFromYear.SelectedValue), Convert.ToInt16(ddlDateFromMonth.SelectedValue)); }
    }
    protected void ddlDateFromYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateFromYear.SelectedValue != "" && ddlDateFromMonth.SelectedValue != "")
        { Populate_DateFromDayinMonthYear(Convert.ToInt32(ddlDateFromYear.SelectedValue), Convert.ToInt16(ddlDateFromMonth.SelectedValue)); }
    }
    protected void ddlDateToMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateToYear.SelectedValue != "" && ddlDateToMonth.SelectedValue != "")
        { Populate_DateToDayinMonthYear(Convert.ToInt32(ddlDateToYear.SelectedValue), Convert.ToInt16(ddlDateToMonth.SelectedValue)); }
    }
    protected void ddlDateToDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateToYear.SelectedValue != "" && ddlDateToMonth.SelectedValue != "")
        { Populate_DateToDayinMonthYear(Convert.ToInt32(ddlDateToYear.SelectedValue), Convert.ToInt16(ddlDateToMonth.SelectedValue)); }
    }
    protected void ddlDateToYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateToYear.SelectedValue != "" && ddlDateToMonth.SelectedValue != "")
        { Populate_DateToDayinMonthYear(Convert.ToInt32(ddlDateToYear.SelectedValue), Convert.ToInt16(ddlDateToMonth.SelectedValue)); }
    }
    protected void Populate_DateFromDayinMonthYear(int vYear, int vMonth)
    {
        int j = DateTime.DaysInMonth(vYear, vMonth);
        int i;
        String tDay = ddlDateFromDay.SelectedValue;

        ddlDateFromDay.Items.Clear();

        for (i = 1; i <= j; i++)
        {
            ddlDateFromDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            if (tDay == i.ToString())
            {
                ddlDateFromDay.SelectedValue = tDay;
            }
        }
    }
    protected void Populate_DateToDayinMonthYear(int vYear, int vMonth)
    {
        int j = DateTime.DaysInMonth(vYear, vMonth);
        int i;
        String tDay = ddlDateToDay.SelectedValue;

        ddlDateToDay.Items.Clear();

        for (i = 1; i <= j; i++)
        {
            ddlDateToDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            if (tDay == i.ToString())
            {
                ddlDateToDay.SelectedValue = tDay;
            }
        }
    }
    protected void ctvDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        TimeSpan ts;

        String tf = ddlDateFromMonth.SelectedValue + "/" + ddlDateFromDay.SelectedValue + "/" + ddlDateFromYear.SelectedValue;
        String tt = ddlDateToMonth.SelectedValue + "/" + ddlDateToDay.SelectedValue + "/" + ddlDateToYear.SelectedValue;


        //String tf = ddlDateFromDay.SelectedValue + "/" + ddlDateFromMonth.SelectedValue + "/" + ddlDateFromYear.SelectedValue;
        //String tt = ddlDateToDay.SelectedValue + "/" + ddlDateToMonth.SelectedValue + "/" + ddlDateToYear.SelectedValue;

        DateTime df = Convert.ToDateTime(tf);
        DateTime dt = Convert.ToDateTime(tt);

        ts = df - dt;

        if (ts.TotalMinutes > 0)
        {
            args.IsValid = false;
            ctvDate.ErrorMessage = "Date From must be a earlier date than Date To ";
        }
        else
        {
            hdnDFrom.Value = tf;
            hdnDTo.Value = tt;
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
}
