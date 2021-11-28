using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Admin_ProfitSharingRequestPaymentShow : System.Web.UI.Page
{
    //DataView dv;
    DataSet ds;
    string eligibleStatus = string.Empty;
    string denominationVal = string.Empty;
    string minReqAmt = string.Empty;   
   

    newDBS objPS = new newDBS();
    string mobileValPS = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["StatusUpdate"] = "NO";

        if (!IsPostBack)
        {
            if (PreviousPage != null)
            {
                HiddenField hdnSno = PreviousPage.Master.FindControl("ContentBody").FindControl("hdnSno") as HiddenField;
                ViewState["countryCode"] = hdnSno.Value.Trim();
            }

            //lblMainTitle.Text = Resources.LangResources.Profile;
            //lblNote.Text = Resources.LangResources.ProfileInfo;
            mobileValPS = Session["LoginID"].ToString();
            mobileValPS = mobileValPS.Replace("EB", "");
            ViewState["mobileValPS"] = mobileValPS;
            LoadProfileView();
        }
    }

    protected void LoadProfileView()
    {
        ds = objPS.RequestPayment_Show(mobileValPS, ViewState["countryCode"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow1 = ds.Tables[0].Rows[0];
            eligibleStatus = utRow1["eligiblestatus"].ToString();
            denominationVal = utRow1["denomination"].ToString();
            minReqAmt = utRow1["minimumRequest"].ToString();
            FormView1.DataSource = ds;
            FormView1.DataBind();
        }
    }

    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        Button btEdit = FormView1.FindControl("btEdit") as Button;
        Label lblNoteVal = FormView1.FindControl("lblNoteVal") as Label;

        if (eligibleStatus == "1")
        {
            btEdit.Visible = true;
            lblNoteVal.Visible = false;
        }
        else
        {
            btEdit.Visible = false;
            lblNoteVal.Visible = true;
            lblNoteVal.Text = "Minimum Payment is " + denominationVal + " " + minReqAmt;
        }
    }

    protected void Button_View(object sender, CommandEventArgs e)
    {
        ds = objPS.RequestPayment_Confirm(ViewState["mobileValPS"].ToString(), ViewState["countryCode"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow1 = ds.Tables[0].Rows[0];
            string status = utRow1["status"].ToString();
            if (status == "0")
            {
                CommonFunctions.AlertMessageAndRedirect("Request Confirmed. Please check History for updated Status.", "ProfitSharingRequestPayment.aspx");                
            }
            else
            {
                CommonFunctions.AlertMessageAndRedirect("Request Rejected. Please check your Balance to confirm Request.", "ProfitSharingRequestPayment.aspx");                
            }
        }
    }

   
}
