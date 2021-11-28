using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CMSv3.BAL;

public partial class SuperAdmin_SA_SA_PinRenewals : System.Web.UI.Page 
{
    DataSet ds;
    DataView dv;

    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    //int qLgType = 0; 




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
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "LoginID";
            ViewState["SearchQuery"] = "";
            

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

    //protected void Page_PreRender(object sender, EventArgs e)
    //{
    //    //PreSelecting the Language DropDown --
    //    //-- accessing the Selected Language 
    //    ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
    //    UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
    //    DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
    //    if (qLgType != null)
    //        objddlSelLang.SelectedValue = Convert.ToString(qLgType);


    //    if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
    //    {
    //        // qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
    //        if (Request.QueryString["LgType"] == "0")
    //        {
    //            //gridFaq.Columns[5].Visible = false;

    //            int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridNews);
    //            gridNews.Columns[ColIdx].Visible = false;
    //        }
    //    }
    //    else if (qLgType == 0)
    //    {
    //        int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridNews);
    //        gridNews.Columns[ColIdx].Visible = false;
    //    }
    //}


    protected void PopulateGrid(string vSortExpr, string vSortDir, string vSearchQuery)
    {


        ds = objBAL_User.Retrieve_AllUserData(vSearchQuery,"");

             

            if (ds.Tables[0].Rows.Count > 0)
            {

                dv = ds.Tables[0].DefaultView;
                if (vSortExpr != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }


                // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


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
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
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


        RadioButtonList rdoRenewPin = (RadioButtonList)gRow.FindControl("rdolstRenewpin");
        TextBox txtRenewPinNo = (TextBox)gRow.FindControl("txtRenewPin");


        //string aa = rdoRenewPin.SelectedValue;
        //string bb = txtRenewPinNo.Text;
        //string cc = objHidUserID.Value;
        int rowCount= 0;

        //upStatus = objBAl_News.UpdateNewsData(tbNewsTitle.Text, tmpNewsContent.ToString(), Convert.ToInt32(Session["saUserID"]), Convert.ToInt32(ltrNewsID.Text), chkActive.Checked, qLgType);
       // rowCount = objBAL_User.Update_User_Status(Convert.ToInt32(objHidUserID.Value), chkActive.Checked,objOwnDomain.Text,objSubDomain.Text);


        rowCount = objBAL_User.Update_User_ExpiryDate(Convert.ToInt32(objHidUserID.Value), rdoRenewPin.SelectedValue, txtRenewPinNo.Text);

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

        //CommonFunctions.InitialiseGridViewPagerRow(gridUsers.BottomPagerRow, gridUsers);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridUsers.BottomPagerRow, gridUsers);
        
    }


    protected void gridUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {

            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");


            ////To get the up/down image at the sorted column 
            CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //CheckBox objChkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //objChkSelect.Attributes.Add("onClick", "SelectRow('" + objChkSelect.ClientID + "')");


            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");


            DataRowView drv = ((DataRowView)e.Row.DataItem);


            Literal objLtrSubDomainName = (Literal)e.Row.FindControl("ltrSubDomainName");

            if (objLtrSubDomainName != null)
            {
                string tmpSubDomainURL = "http://" + drv["subDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;
                objLtrSubDomainName.Text = "<a class='links_FuncLinks' target='_blank' href='" + tmpSubDomainURL + "'>" + tmpSubDomainURL + "</a>";
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



        }


    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {


        string tmpSearchParam = ddlSearchParam.SelectedValue;
        string tmpSearchValue = string.Empty;

        if (tmpSearchParam == "isActive")
        {
            tmpSearchValue = ddlStatus.SelectedValue;
            txtSearchValue.Text = "";
        }
        else
        {
            tmpSearchValue = CommonFunctions.SafeSql(txtSearchValue.Text);
        }


        //if (tmpSearchValue != "")
        //{

            String tmpSearchQuery = string.Empty;
            tmpSearchQuery = "Where " + tmpSearchParam + " Like '" + tmpSearchValue + "%'";
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

        //if (ddlSearchParam.SelectedValue == "isActive")
        //{
        //    dvSearchTextBox.Visible = false;
        //    dvStatusDropDown.Visible = true;

        //}
        //else
        //{
        //    dvSearchTextBox.Visible = true;
        //    dvStatusDropDown.Visible = false;
        //}

    }


    protected void RenewAccount_Click(object sender, EventArgs e)
    {


        //int upStatus =  objBAL_User.Update_User_ExpiryDate(Convert.ToInt32(Session["UserID"]));

        //if (upStatus > 0)
        //{
        //    CommonFunctions.AlertMessage("User Account membership has been extended by One year.");
        //}
        //else
        //{
        //    CommonFunctions.AlertMessage("Unable to Update the expiry date");
        //}


    }



    protected void rdolstRenewpin_SelectedIndexChanged(object sender, EventArgs e)
    {




        RadioButtonList rBtnList = (RadioButtonList)sender;
        GridViewRow gvr = (GridViewRow)rBtnList.Parent.Parent;

        RequiredFieldValidator RfVd1 = (RequiredFieldValidator)gvr.FindControl("RfdV_RenewPin");

        if (rBtnList.SelectedIndex == 0)
        {
            RfVd1.Enabled = false;
        }
        else
        {
            RfVd1.Enabled = true;
        }

        //if (rdoRenewPin.SelectedIndex == 0)
        //{
        //    RfVd_RenewPinText.Enabled = false;
        //}
        //else
        //{
        //    RfVd_RenewPinText.Enabled = true;
        //}

    }
}