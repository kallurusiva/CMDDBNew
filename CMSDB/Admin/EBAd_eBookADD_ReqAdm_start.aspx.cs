using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Admin_EBAd_eBookADD_ReqAdm_start : System.Web.UI.Page
{
    //DataSet ds;
    //DataView dv;
    //String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if (Session["UserID"] == null)
        {
            if (Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "";
            ViewState["SearchStr"] = "";
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        newDBS objNewDB = new newDBS();
        string bookcode = txtBookCode.Text.ToString();
        string bookname = "";
        DataSet ds = objNewDB.getAdminEBookFileName(bookcode.ToString(), Session["LoginID"].ToString());
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            bookname = dr["ebookfilename"].ToString();
        }
        if (bookname.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Admin BookCode does not exists.')", true);
        }
        else
        {
            Response.Redirect("EBAd_eBookADD_ReqAdmUpdate.aspx?TID=" + bookcode.ToString());
        }
    }

    protected void BtnSaveNew_Click(object sender, EventArgs e)
    {
        int Package = 0;
        int aCounter = 0;
        string eMessage = string.Empty;

        eMessage = "";
        newDBS objNewDB = new newDBS();
        DataSet ds = objNewDB.getAdminEBookFileName("", Session["LoginID"].ToString());
        DataTable dt = ds.Tables[1];
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            Package = Convert.ToInt32(dr["packageID"].ToString());
            aCounter = Convert.ToInt32(dr["cnt"].ToString());
        }
        if (Package == 1 && aCounter > 9)
        {
            eMessage = "You have reach Max – 10 for upload for Admin Book for your BASIC Package.Please upgrade to increase your Admin Book upload. Thank you";
            CommonFunctions.AlertMessage(eMessage.ToString());
        }
        else if (Package == 2 && aCounter > 19)
        {
            eMessage = "You have reach Max – 20 for upload for Admin Book for your CORPORATE Package.Please upgrade to increase your Admin Book upload. Thank you";
            CommonFunctions.AlertMessage(eMessage.ToString());
        }
        else if (Package == 3 && aCounter > 49)
        {
            eMessage = "You have reach Max – 50 for upload for Admin Book for your INTERNATIONAL Package.Please upgrade to increase your Admin Book upload. Thank you";
            CommonFunctions.AlertMessage(eMessage.ToString());
        }
        else if (Package == 4 && aCounter > 79)
        {
            eMessage = "You have reach Max – 80 for upload for Admin Book for your PREMIUM Package.Please upgrade to increase your Admin Book upload. Thank you";
            CommonFunctions.AlertMessage(eMessage.ToString());
        }
        else
        {
            Response.Redirect("EBAd_eBookADD_ReqAdm.aspx?TID=0");
        }
    }


}