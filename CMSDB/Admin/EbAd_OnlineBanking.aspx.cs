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

public partial class Admin_EbAd_OnlineBanking : System.Web.UI.Page
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;


    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
    CMSv3.BAL.PayPal objPayPal = new CMSv3.BAL.PayPal();

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
            ViewState["sortOrder"] = "";
            ViewState["SortExpr"] = "";
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }

        tblMessageBar.Visible = false;
        MaintainScrollPositionOnPostBack = true;
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        newDBS objNewDB = new newDBS();
        ds = objNewDB.BillPlzPurchaseHistory_admin(Session["UserID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }

            gridPayPalTx.DataSource = dv;
            gridPayPalTx.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridPayPalTx.DataSource = ds;
            gridPayPalTx.DataBind();

            int ColCount = gridPayPalTx.Rows[0].Cells.Count;
            gridPayPalTx.Rows[0].Cells.Clear();
            gridPayPalTx.Rows[0].Cells.Add(new TableCell());
            gridPayPalTx.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridPayPalTx.Rows[0].Cells[0].Text = "No records Found";
            gridPayPalTx.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }

    protected void gridPayPalTx_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridPayPalTx.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridPayPalTx.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridPayPalTx.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridPayPalTx.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }

    protected void gridPayPalTx_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridPayPalTx.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridPayPalTx_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridPayPalTx.Rows[e.RowIndex];

        //Getting eventID reference
        HiddenField ObjhdFreeEbookUID = (HiddenField)gvRow.FindControl("hdFreeEbookUID");

        int tmpBSuid = Convert.ToInt32(ObjhdFreeEbookUID.Value);

        // int delStatus = objEbook.EBook_Delete(ObjhdBookId.Value, Convert.ToInt32(ObjhdUID.Value));

        int delStatus = objEbook.EBook_FreeEbook_Delete(tmpBSuid);

        //int delStatus = 1; 
        if (delStatus >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Ebook unMarked as Best Seller Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }
        else
        {
            lblErrMessage.Text = "Could not unMark the Ebook as Best Seller. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('eBook unMarked as Best-Seller successfully')", true);
    }

    protected void gridPayPalTx_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridPayPalTx.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridPayPalTx_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridPayPalTx.BottomPagerRow, gridPayPalTx);
    }

    protected void gridPayPalTx_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");

            ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");
            ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");
            ImageButton objImgEditByUser = (ImageButton)e.Row.FindControl("ImgEditByUser");

            Label objlblPytStatus = (Label)e.Row.FindControl("lblPytStatus");

            if (objlblPytStatus != null)
            {
                if (objlblPytStatus.Text.ToLower() == "success")
                {
                    objlblPytStatus.CssClass = "fontGreen";

                    //HiddenField hdTXid = (HiddenField)e.Row.FindControl("hdTXid");
                    //HiddenField hdPytGrossAmt = (HiddenField)e.Row.FindControl("hdPytGrossAmt");
                    //HiddenField hdPytCurrencyCode = (HiddenField)e.Row.FindControl("hdPytCurrencyCode");

                    //Label lblPurchaseDetails = (Label)e.Row.FindControl("lblPurchaseDetails");

                    //decimal vGrossAmt = Convert.ToDecimal(hdPytGrossAmt.Value);
                    //String vPayment = hdPytCurrencyCode.Value + " " + String.Format("{0:n2}", vGrossAmt);

                    //StringBuilder sb = new StringBuilder();
                    //sb.AppendLine("<b>TransactionID: </b>" + hdTXid.Value + "<br/>");
                    //sb.AppendLine("<b>Payment Amount: </b>" + vPayment + "<br/>");

                    //lblPurchaseDetails.Text = sb.ToString();

                    LinkButton objLnkResendEmail = (LinkButton)e.Row.FindControl("LinkSendEmail");
                    TextBox objBuyerEmail = (TextBox)e.Row.FindControl("txtBuyerEmail");
                    LinkButton objLnkSendSMS = (LinkButton)e.Row.FindControl("LinkSendSMS");


                    HiddenField hdTXid = (HiddenField)e.Row.FindControl("hdTXid");
                    HiddenField hdRMPrice = (HiddenField)e.Row.FindControl("hdRMPrice");
                    Label lblPurchaseDetails = (Label)e.Row.FindControl("lblPurchaseDetails");

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<b>TransactionID:</b>" + hdTXid.Value + "<br/>");
                    sb.AppendLine("<b>Amount:</b>" + hdRMPrice.Value + "<br/>");

                    lblPurchaseDetails.Text = sb.ToString();

                    if (objLnkResendEmail != null)
                    {
                        objLnkResendEmail.Visible = true;
                        objBuyerEmail.Visible = true;
                        objLnkSendSMS.Visible = true;
                    }

                }
                else if (objlblPytStatus.Text.ToLower() == "failed")
                {
                    objlblPytStatus.CssClass = "fontBlue";
                    Label lblPurchaseDetails = (Label)e.Row.FindControl("lblPurchaseDetails");
                    lblPurchaseDetails.Text = "The user navigated to the Payment Gateway, but did not proceed further.";
                }
            }
        }
    }

    protected void OnCommand_ImageSendEmail(object sender, CommandEventArgs e)
    {
        string billid = e.CommandArgument.ToString();

        CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
        CMSv3.BAL.PayPal objPayPal = new CMSv3.BAL.PayPal();
        newDBS objDBS = new newDBS();
        ds = objDBS.BillPlz_getEmailDetails(billid.ToString());
        DataTable dtTx = ds.Tables[0];

        if (dtTx.Rows.Count > 0)
        {
            DataRow Drow = dtTx.Rows[0];

            String vUserName = Drow["UserName"].ToString();
            String vMobileNo = Drow["MobileNo"].ToString();
            String vBuyerEmail = Drow["BuyerEmail"].ToString();
            String vBookID = Drow["ItemName"].ToString();
            string vUserId1 = Drow["UserId"].ToString();

            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            TextBox TextBox1 = row.FindControl("txtBuyerEmail") as TextBox;
            vBuyerEmail = TextBox1.Text.ToString();

            string bPassword = vMobileNo + vUserName;
            bPassword = bPassword.Replace(" ", "");
            if (bPassword.Length > 19) { bPassword = bPassword.Substring(0, 20).ToLower(); }

            string QKeyword = string.Empty;
            DataSet ds3 = objBALebook.Ebook_KeywordDetails_ByUserID(Convert.ToInt32(vUserId1));
            if (ds3.Tables[0].Rows.Count > 0)
            {
                DataRow krow = ds3.Tables[0].Rows[0];
                QKeyword = krow["VendorCode"].ToString();
            }

            EBookEmailCentral.getTransactionDetails(vBuyerEmail, "", QKeyword, "", "", vBookID, bPassword);
        }

        CommonFunctions.AlertMessageAndRedirect("EBOOKS ReSend by Email Successfully", "EBAd_OnlineBanking.aspx");
    }

    protected void OnCommand_ImageSendEmailNew(object sender, CommandEventArgs e)
    {
        string vID = e.CommandArgument.ToString();
        GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
        TextBox TextBox1 = row.FindControl("txtBuyerEmail") as TextBox;
        string vBuyerEmail = TextBox1.Text.ToString();
        MgMail.sndMailgunLinks(vID.ToString(), "2", vBuyerEmail.ToString());

        CommonFunctions.AlertMessageAndRedirect("EBOOKS ReSend by Email Successfully....", "EBAd_OnlineBanking.aspx");
    }

    protected void OnCommand_ImageSendSMSNew(object sender, CommandEventArgs e)
    {
        string vID = e.CommandArgument.ToString();
        newDBS objDBS = new newDBS();
        objDBS.SMSEbook_getDetails(vID.ToString(), "2");

        CommonFunctions.AlertMessageAndRedirect("SMS ReSend successfully....", "EBAd_OnlineBanking.aspx");
    }

    protected void gridPayPalTx_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow gRow = (GridViewRow)gridPayPalTx.Rows[e.RowIndex];
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");

        CheckBox chkHpShow = (CheckBox)gRow.FindControl("chkHpShow");

        HiddenField hdBookId = (HiddenField)gRow.FindControl("hidBookId");
        HiddenField hdBookUID = (HiddenField)gRow.FindControl("hidBookUID");

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        String vBookID = hdBookId.Value;
        int vBookUID = Convert.ToInt32(hdBookUID.Value);
        int vBookType = Convert.ToInt16(GlobalVar.EbookTypes.FreeEbook);

        int upStatus = objEbook.Ebook_ShowHide(vUserID, vBookID, vBookUID, vBookType, chkActive.Checked);
        int hpStatus = objEbook.Ebook_ShowHide_HpItems(vUserID, vBookID, vBookUID, vBookType, chkHpShow.Checked);

        if ((upStatus >= 1) || (hpStatus >= 1))
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Ebook Display Status Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the Ebook Status. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }
        gridPayPalTx.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridPayPalTx_Sorting(object sender, GridViewSortEventArgs e)
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

    protected void Button_View(object sender, CommandEventArgs e)
    {
        string s = e.CommandArgument.ToString();
        string[] strInfo = s.Split(',');

        for (int i = 0; i < strInfo.Length; i++)
        {
            HdEditBookUID.Value = strInfo[0];
            HdEditBookID.Value = strInfo[1];
        }
        Server.Transfer(@"EBAd_FreeEbookEdit.aspx");
    }

    protected void gridPayPalTx_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditByUser")
        {
            string s = e.CommandArgument.ToString();

            string[] strInfo = s.Split(',');

            for (int i = 0; i < strInfo.Length; i++)
            {
                HdEditBookUID.Value = strInfo[0];
                HdEditBookID.Value = strInfo[1];
            }
            Server.Transfer(@"EBAd_FreeEbookEdit.aspx");
        }
    }

    protected void ImgDownloadFile_Click(object sender, CommandEventArgs e)
    {
        String EbookfileURL = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        String vfile = e.CommandArgument.ToString();

        String EbookFilePath = EbookfileURL + vfile;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + vfile);
        Response.WriteFile(EbookFilePath);
        Response.End();
    }

    protected void linkBtnDownloadFile_Command(object sender, CommandEventArgs e)
    {
        String EbookfileURL = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        String vfileName = e.CommandArgument.ToString();

        String EbookFilePath = EbookfileURL + vfileName;

        if (File.Exists(Server.MapPath(EbookFilePath)))
        {
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + vfileName);
            Response.WriteFile(EbookFilePath);
            Response.End();
        }
        else
        {
            CommonFunctions.AlertMessage("Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.");

        }
    }

}
