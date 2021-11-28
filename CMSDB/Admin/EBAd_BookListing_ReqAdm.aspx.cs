﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net;

public partial class Admin_EBAd_BookListing_ReqAdm : System.Web.UI.Page
{
    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
    newDBS objNewDB = new newDBS();

    int qUserType = 0;
    int tmpRowCount = 0;
    int tmpTotalRecord = 0;
    int PageSize = 25;

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
            ViewState["SearchQuery"] = "";

            ViewState["TotalRecord"] = "0";
            ViewState["PageID"] = "1";
            ViewState["UserType"] = "0";

            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qType"] != null)
                    qUserType = Convert.ToInt32(Request.QueryString["qType"].ToString());

                ViewState["UserType"] = qUserType;

                if (Request.QueryString["qStatus"] != null)
                    CommonFunctions.AlertMessage("eBook Added/Updated successfully.");
            }

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
        }
            tblMessageBar.Visible = false;
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir, string vSearchQuery)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        int tmpUserType = Convert.ToInt16(ViewState["UserType"].ToString());
        ds = objNewDB.Ebook_Listing_ReqAdm(Convert.ToInt32(Session["UserID"]), 0, Convert.ToInt32(strPageNo), "");

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
                if (pageNumberDropDownList.SelectedIndex < gridEbooks.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridEbooks.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
                }
            }
        }
    }

    protected void gridEbooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEbooks.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void gridEbooks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridEbooks.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void gridEbooks_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
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

    protected void gridEbooks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridEbooks.Rows[e.RowIndex];

        //Getting eventID reference
        HiddenField ObjhdUID = (HiddenField)gvRow.FindControl("hidBookUID");
        HiddenField ObjhdBookId = (HiddenField)gvRow.FindControl("hidBookId");

        DataSet dst = objNewDB.Ebook_Listing_ReqAdm_Delete(ObjhdBookId.Value.ToString());

            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Ebook Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());

        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + ObjhdBookId.Value + ": eBook deleted successfully')", true);
    }

    protected void gridEbooks_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridEbooks.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void gridEbooks_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), gridEbooks.BottomPagerRow, gridEbooks);
    }

    protected void gridEbooks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");

            HyperLink HyLinkEdit = (HyperLink)e.Row.FindControl("HyLinkEdit");

            HiddenField objBookUID = (HiddenField)e.Row.FindControl("hidBookUID");
            HiddenField objBookID = (HiddenField)e.Row.FindControl("hidBookID");

            HiddenField objhidCreatedBy = (HiddenField)e.Row.FindControl("hidCreatedBy");
            HiddenField objhidStatus = (HiddenField)e.Row.FindControl("hidStatus");

            ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");
            ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");

            Label Objlblmobile1 = (Label)e.Row.FindControl("lblmobile1");
            Label Objlblmobile2 = (Label)e.Row.FindControl("lblmobile2");
            Label Objlblmobile3 = (Label)e.Row.FindControl("lblmobile3");

            if (objhidStatus.Value.ToString() == "Pending")
            {
                objImgDelete.Visible = true;
            }

            if (Objlblmobile1 != null)
                if (Objlblmobile1.Text == "0") Objlblmobile1.Text = "";

            if (Objlblmobile2 != null)
                if (Objlblmobile2.Text == "0") Objlblmobile2.Text = "";

            if (Objlblmobile3 != null)
                if (Objlblmobile3.Text == "0") Objlblmobile3.Text = "";

            Label objlblCreatedBy = (Label)e.Row.FindControl("lblCreatedBy");

            if (objImgEdit != null)
                objImgEdit.Visible = true;

            if (objlblCreatedBy != null)
                objlblCreatedBy.CssClass = "fontRed";

            #region Showing Checkbox ticked image
            //============

            Literal objLtrActive = (Literal)e.Row.FindControl("LtrActive");
            Image objImgActive = (Image)e.Row.FindControl("ImgActive");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (objImgActive != null)
            {
                if (objLtrActive.Text != "")
                {
                    if (Convert.ToBoolean(objLtrActive.Text))
                    {
                        objImgActive.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        objImgActive.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }
            //== is Featured. 

            Literal objLtrisFeatured = (Literal)e.Row.FindControl("LtrisFeatured");
            Image objImgisFeatured = (Image)e.Row.FindControl("ImgisFeatured");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (objImgisFeatured != null)
            {
                if (objLtrisFeatured.Text != "")
                {
                    if (Convert.ToBoolean(objLtrisFeatured.Text))
                    {
                        objImgisFeatured.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        objImgisFeatured.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }

            //== Allow SMS Buy 

            Literal LtrAllowSMSbuy = (Literal)e.Row.FindControl("LtrAllowSMSbuy");
            Image ImgAllowSMSbuy = (Image)e.Row.FindControl("ImgAllowSMSbuy");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (ImgAllowSMSbuy != null)
            {
                if (LtrAllowSMSbuy.Text != "")
                {
                    if (Convert.ToBoolean(LtrAllowSMSbuy.Text))
                    {
                        ImgAllowSMSbuy.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        ImgAllowSMSbuy.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }

            //== Allow Pay Buy

            Literal LtrAllowPaypalBuy = (Literal)e.Row.FindControl("LtrAllowPaypalBuy");
            Image ImgAllowPaypalBuyy = (Image)e.Row.FindControl("ImgAllowPaypalBuyy");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (ImgAllowPaypalBuyy != null)
            {
                if (LtrAllowPaypalBuy.Text != "")
                {
                    if (Convert.ToBoolean(LtrAllowPaypalBuy.Text))
                    {
                        ImgAllowPaypalBuyy.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        ImgAllowPaypalBuyy.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }

            #endregion

            LinkButton linkBtnDownloadFile = (LinkButton)e.Row.FindControl("linkBtnDownloadFile");

            var scriptManager = ScriptManager.GetCurrent(this.Page);
            if (scriptManager != null)
            {
                scriptManager.RegisterPostBackControl(linkBtnDownloadFile);
            }
        }
    }

    protected void gridEbooks_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow gRow = (GridViewRow)gridEbooks.Rows[e.RowIndex];
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");

        HiddenField hdBookId = (HiddenField)gRow.FindControl("hidBookId");
        HiddenField hdBookUID = (HiddenField)gRow.FindControl("hidBookUID");

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        String vBookID = hdBookId.Value;
        int vBookUID = Convert.ToInt32(hdBookUID.Value);
        int vBookType = Convert.ToInt16(GlobalVar.EbookTypes.eBook);

        int upStatus = objEbook.Ebook_ShowHide(vUserID, vBookID, vBookUID, vBookType, chkActive.Checked);

        if (upStatus >= 1)
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
        gridEbooks.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void linkBtnDownloadFile_Command(object sender, CommandEventArgs e)
    {
        //String EbookfileURL = "/DocumentRepository/ReqEBooks/";
        //String vfileName = e.CommandArgument.ToString();
        //String EbookFilePath = EbookfileURL + vfileName;
        //if (File.Exists(Server.MapPath(EbookFilePath)))
        //{
        //    Response.ContentType = ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + vfileName);
        //    Response.WriteFile(EbookFilePath);
        //    Response.End();
        //}
        //else
        //{
        //    String vAlertMsg = "Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
        //}

        String EbookfileURL = @"C:\inetpub\wwwroot\documentrepository\ReqEBooks\";
        String vfileName = e.CommandArgument.ToString();
        String EbookFilePath = EbookfileURL + vfileName;

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + EbookFilePath.ToString() + "')", true);

        if (File.Exists(EbookFilePath))
        {
            string type = "Application/pdf";
            Response.AppendHeader("content-disposition", "attachment; filename=" + vfileName);

            if (type != "")
                Response.ContentType = type;
            Response.WriteFile(EbookFilePath);
            Response.End();
        }
        else
        {
            String vAlertMsg = "Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
        }
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
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
    }

    protected void LoadCategories()
    {
        DataSet ds;
        String tmpUserType = ViewState["UserType"].ToString();
        ds = objEbook.Category_Load_ByUserID(Convert.ToInt32(Session["UserID"]), tmpUserType);
    }

    protected void ddlSearchParam_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

}
