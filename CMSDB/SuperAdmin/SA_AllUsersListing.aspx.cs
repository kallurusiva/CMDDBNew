using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CMSv3.BAL;

public partial class SuperAdmin_SA_AllUsersListing : System.Web.UI.Page 
{
    DataSet ds;
    DataView dv;

    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    //int qLgType = 0;

    //double tmpTotal = 0;
    int tmpRowCount = 0;
    int tmpTotalRecord = 0;
    int PageSize = 20;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        ltrAllUsersListing.Text = Resources.LangResources.All + " " +  Resources.LangResources.User + " " + Resources.LangResources.Listing;


        //if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        //{
        //    qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        //}

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "RegisteredDate";
            ViewState["SearchQuery"] = "";
            ViewState["PageID"] = "1";
            

            #region Setting ViewState for Retrieval Type -- USER , ADMIN or ALL


            if (Request.QueryString["RtType"] != null)
            {

                switch (Request.QueryString["RtType"].ToString())
                {
                    case "USER": ViewState["RtType"] = "USER";
                        break;
                    case "ADMIN": ViewState["RtType"] = "ADMIN";
                        break;
                    case "ALL": ViewState["RtType"] = "ALL";
                        break;
                    default: ViewState["RtType"] = "USER";
                        break;
                }
            }
            else
            {
                ViewState["RtType"] = "USER";
            }


            #endregion

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
        }

        tblMessageBar.Visible = false;
        ddlSearchParam.Attributes.Add("onchange", "ChangeSearchValueBox(this)");


    }

    protected void PopulateGrid(string vSortExpr, string vSortDir, string vSearchQuery)
    {
        String strPageNo = String.Empty;
        strPageNo = ViewState["PageID"].ToString();

        ds = objBAL_User.Retrieve_AllUserData_byPage(vSearchQuery, "", Convert.ToInt32(strPageNo));             

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

                gridUsers.DataSource = dv;
                gridUsers.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridUsers.DataSource = ds;
                gridUsers.DataBind();

                int ColCount = gridUsers.Rows[0].Cells.Count;
                gridUsers.Rows[0].Cells.Clear();
                gridUsers.Rows[0].Cells.Add(new TableCell());
                gridUsers.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridUsers.Rows[0].Cells[0].Text = "No records Found";
                gridUsers.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            }
    }

    protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridUsers.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }
    
    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        int PageCount = tmpTotalRecord / gridUsers.PageSize;
        if (tmpTotalRecord % gridUsers.PageSize > 0)
            PageCount++;


        ViewState["PageID"] = pageNumberDropDownList.SelectedValue; 
        if (pageNumberDropDownList != null)
        {
            if (gridUsers.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridUsers.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridUsers.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
                }
            }
        }
    }

    protected void gridUsers_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;
        PopulateGrid(m_SortExpr, sortOrder, ViewState["SearchQuery"].ToString());
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
    
    protected void gridUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridUsers.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void gridUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridUsers.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void gridUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridUsers.Rows[e.RowIndex];

        //Get the reference to the Fields in the grid view row
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkisActive");
        //TextBox objOwnDomain = (TextBox)gRow.FindControl("txtOwnDomainName");
        TextBox objSubDomain = (TextBox)gRow.FindControl("txtSubDomainName");

        TextBox objOwnDomain = (TextBox)gRow.FindControl("txtOwnDomainName"); 



        int rowCount= 0;

        //upStatus = objBAl_News.UpdateNewsData(tbNewsTitle.Text, tmpNewsContent.ToString(), Convert.ToInt32(Session["saUserID"]), Convert.ToInt32(ltrNewsID.Text), chkActive.Checked, qLgType);
       // rowCount = objBAL_User.Update_User_Status(Convert.ToInt32(objHidUserID.Value), chkActive.Checked,objOwnDomain.Text,objSubDomain.Text);
        rowCount = objBAL_User.Update_User_Status(Convert.ToInt32(objHidUserID.Value), chkActive.Checked, objOwnDomain.Text, objSubDomain.Text);


        if (rowCount >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "User Status Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the News. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        gridUsers.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());

    }

    protected void gridUsers_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerWithRowCountImages(PageSize, tmpTotalRecord, Convert.ToInt32(ViewState["PageID"]), gridUsers.BottomPagerRow, gridUsers);
    }

    protected void gridUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");
            
            DataRowView drv = ((DataRowView)e.Row.DataItem);

            Literal objLtrSubDomainName = (Literal)e.Row.FindControl("ltrSubDomainName");

            if (objLtrSubDomainName != null)
            {
                string tmpSubDomainURL = "http://" + drv["subDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;
                objLtrSubDomainName.Text = "<a class='links_FuncLinks' target='_blank' href='" + tmpSubDomainURL + "'>" + drv["subDomain"].ToString() + "</a>";
            }

            Literal objltrOwnDomainName = (Literal)e.Row.FindControl("ltrOwnDomainName");
            HiddenField hd_OwndomainName = (HiddenField)e.Row.FindControl("hidOwnDomainName");

            if (hd_OwndomainName != null)
            {
                if(hd_OwndomainName.Value != "")
                { 
                string tmpOwnDomainURL = "http://" + drv["OwnDomain"].ToString();
                objltrOwnDomainName.Text = "<a class='links_FuncLinks' target='_blank' href='" + tmpOwnDomainURL + "'>" + drv["OwnDomain"].ToString() + "</a>";
                }
            }

            #region Showing Checkbox ticked image 
            
            //need to find out if the logged users is not a superadmin disable the last cell 

            //============

            Literal objLtrActive = (Literal)e.Row.FindControl("LtrisActive");
            Image objImgActive = (Image)e.Row.FindControl("ImgActive");

            Literal objltrDomainStatus = (Literal)e.Row.FindControl("ltrDomainStatus");
            Image objImgDomainStatus = (Image)e.Row.FindControl("ImgDomainStatus");

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

            if (objImgDomainStatus != null)
            {
                if (objltrDomainStatus.Text != "")
                {
                    if (Convert.ToBoolean(objltrDomainStatus.Text))
                    {
                        objImgDomainStatus.ImageUrl = @"~\Images\round_active.gif";
                    }
                    else
                    {
                        objImgDomainStatus.ImageUrl = @"~\Images\round_notactive.gif";
                    }
                }
            }

            #endregion

            #region Add Domain code

            string AddDomain2UserID = string.Empty;
            HiddenField hd_UserId = (HiddenField)e.Row.FindControl("hidUserID");
            AddDomain2UserID = hd_UserId.Value;

            ImageButton objImgAddDomain = (ImageButton)e.Row.FindControl("ImgAddDomain");
            HiddenField hd_domainType = (HiddenField)e.Row.FindControl("hidDomainType");     

            if (objImgAddDomain != null)
            {
                if((hd_OwndomainName.Value == "") || (hd_OwndomainName.Value == null))
                objImgAddDomain.Attributes.Add("onclick", "fnAddDomain(" + AddDomain2UserID + ")");
      
                if ((hd_domainType.Value == "WEB10") || (hd_OwndomainName.Value != ""))
                {
                    objImgAddDomain.Visible = false;    
                }
            }

            #endregion
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string tmpSearchParam = ddlSearchParam.SelectedValue.Trim();
        string tmpSearchValue = string.Empty;

        if (tmpSearchParam == "isActive")
        {
            tmpSearchValue = ddlStatus.SelectedValue.Trim();
            txtSearchValue.Text = "";
        }
        else
        {
            tmpSearchValue = CommonFunctions.SafeSql(txtSearchValue.Text.Trim());
        }

        //if (tmpSearchValue != "")
        //{

            String tmpSearchQuery = string.Empty;
            tmpSearchQuery = "Where " + tmpSearchParam + " Like '%" + tmpSearchValue + "%'";
            ViewState["SearchQuery"] = tmpSearchQuery;
        //}

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ViewState["SearchQuery"] = "";
        txtSearchValue.Text = "";
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void ddlSearchParam_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {

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

}