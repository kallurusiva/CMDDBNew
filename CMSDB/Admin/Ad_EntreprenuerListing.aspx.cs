using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_EntreprenuerListing : BasePage
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

    CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();
    CMSv3.Entities.Products objProducts = new CMSv3.Entities.Products();
    int qLgType = 0; 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        ltrProductListing.Text = "Entreprenuer Program " + Resources.LangResources.Listing;

        if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        {
            qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        }

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "UserID desc, LgType, Priority";

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

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }

        tblMessageBar.Visible = false;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //PreSelecting the Language DropDown --
        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        objddlSelLang.SelectedValue = Convert.ToString(qLgType);


        //if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        //{
        //    // qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        //    if (Request.QueryString["LgType"] == "0")
        //    {
        //        gridProducts.Columns[10].Visible = false;
        //    }
        //}

    }



    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        //ds = objBAl_Event.Retrieve_AllEventByUserID(101);
        //ds = objBAL_Testimonial.RetrieveAllProducts_ByUserID(Convert.ToInt32(Session["UserID"]), ViewState["RtType"].ToString());
        ds = objBAL_Products.RetrieveAllProducts_ByUserID(Convert.ToInt32(Session["UserID"]), ViewState["RtType"].ToString(), qLgType,Convert.ToInt16(GlobalVar.ProductTypes.Entrepreneur));

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            gridProducts.DataSource = dv;
            gridProducts.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridProducts.DataSource = ds;
            gridProducts.DataBind();

            int ColCount = gridProducts.Rows[0].Cells.Count;
            gridProducts.Rows[0].Cells.Clear();
            gridProducts.Rows[0].Cells.Add(new TableCell());
            gridProducts.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridProducts.Rows[0].Cells[0].Text = "No records Found";
            gridProducts.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void gridProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridProducts.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridProducts.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridProducts.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridProducts.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridProducts.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    //protected void gridProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    //Get the reference to the gridview row
    //    GridViewRow gvRow = (GridViewRow)gridProducts.Rows[e.RowIndex];

    //    //Getting eventID reference
    //    Literal ltrProductID = (Literal)gvRow.FindControl("hdProductId");

    //    int ProductIdToDelte = Convert.ToInt32(ltrProductID.Text);

    //    bool delStatus = objBAL_Products.DeleteProductsData(Convert.ToInt32(Session["UserID"]), ProductIdToDelte);
        
    //    if (delStatus)
    //    {
    //        tblMessageBar.Visible = true;
    //        lblErrMessage.Text = "Product item Deleted Sucessfully";
    //        lblErrMessage.CssClass = "font_12Msg_Success";
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";
    //        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    //    }
    //    else
    //    {
    //        lblErrMessage.Text = "Could not deleted the Product item. Technical Error";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //    }

    //}


    protected void gridProducts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //gridProducts.EditIndex = e.NewEditIndex;
        //PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //GridViewRow gRow = (GridViewRow)gridProducts.Rows[e.NewEditIndex];
        //Literal tblProductID = (Literal)gRow.FindControl("hdProductId");
        gridProducts.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //Server.Transfer("ProductViewEdit.aspx?ProductID=" + tblProductID.Text);
    }


    protected void gridProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridProducts.Rows[e.RowIndex];
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");
        HiddenField objHidUserType = (HiddenField)gRow.FindControl("hidUsertype");
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");
        Literal tblProductID = (Literal)gRow.FindControl("hdProductId");

             


        bool upStatus = false;

  
            CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
            upStatus = objBAL_CommonFunc.InsertUpdate_ShowAdminItems("tblProductDetails", tblProductID.Text, Convert.ToInt32(Session["UserID"]));

            bool inStatus = false; 
            inStatus = objBAL_Products.InsertUpdate_ProductPriority(Convert.ToInt32(Session["UserID"]), Convert.ToInt32(tblProductID.Text), chkActive.Checked);

        if (upStatus && inStatus)
                {
                    tblMessageBar.Visible = true;
                    lblErrMessage.Text = "Product Updated Sucessfully";
                    lblErrMessage.CssClass = "font_12Msg_Success";
                    MessageImage.Src = "~/Images/inf_Sucess.gif";
                }
                else
                {
                    lblErrMessage.Text = "Could not Update the Product. Technical Error";
                    lblErrMessage.CssClass = "font_12Msg_Error";
                    tblMessageBar.Visible = true;
                    MessageImage.Src = "~/Images/inf_Error.gif";
                }

      

        //Get the reference to the TextFields in the grid view row
        ////TextBox tbTstTitle = (TextBox)gRow.FindControl("txtTstTitle");
        ////TextBox tbTstContent = (TextBox)gRow.FindControl("txtTstContent");

        gridProducts.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        


    }


    //protected void gridProducts_Sorting(object sender, GridViewSortEventArgs e)
    //{
    //    m_SortExpr = e.SortExpression;
    //    m_SortDir = e.SortDirection;

    //    ViewState["SortExpr"] = m_SortExpr;
    //    PopulateGrid(m_SortExpr, sortOrder);
    //}


    //public string sortOrder
    //{
    //    get
    //    {
    //        if (ViewState["sortOrder"].ToString() == "desc")
    //        {
    //            ViewState["sortOrder"] = "asc";

    //        }
    //        else
    //        {
    //            ViewState["sortOrder"] = "desc";
    //        }

    //        return ViewState["sortOrder"].ToString();
    //    }
    //    set
    //    {
    //        ViewState["sortOrder"] = value;
    //    }
    //}


    protected void gridProducts_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridProducts.BottomPagerRow, gridProducts);
    }


    private int findColumnIndex(GridView gridView, string accessibleHeaderText)
    {
        for (int index = 0; index < gridView.Columns.Count; index++)
        {
            if (String.Compare(gridView.Columns[index].AccessibleHeaderText, accessibleHeaderText, true) == 0)
            {
                return index;
            }
        }
        return -1;
    }

    protected void gridProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowState == DataControlRowState.Edit)
        //{
        //    int PriorityColumnIndex = findColumnIndex(gridProducts, "Priority");
        //    if (PriorityColumnIndex != -1)
        //    {
        //        gridProducts.Columns[PriorityColumnIndex].Visible = false;
        //    }
        //}

        if (e.Row.RowType == DataControlRowType.Header)
        {

            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");

            ////To get the up/down image at the sorted column 
            //CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //CheckBox objChkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //objChkSelect.Attributes.Add("onClick", "SelectRow('" + objChkSelect.ClientID + "')");


            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");

            HiddenField objHidCreatedBy = (HiddenField)e.Row.FindControl("HidCreatedBy");

            if (objHidCreatedBy != null)
            {
                if (objHidCreatedBy.Value.ToUpper() == "SUPERADMIN")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#FDF1E2");
                    e.Row.BorderColor = System.Drawing.Color.FromName("#A8A6A3");
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FDF1E2';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");
                }
            }
            


            ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");



            #region //Commented code // Hiding UP - Down Prioty arrows for ADMIN and ALL listing


            //if (ViewState["RtType"] != null)
            //{
            //    if ((ViewState["RtType"].ToString() == "ADMIN") || (ViewState["RtType"].ToString() == "ALL"))
            //    {
                    
            //        gridProducts.Columns[9].Visible = false;

            //        ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");
            //        if (objImgDelete != null)
            //            objImgDelete.Visible = false;



            //        if (objImgEdit != null)
            //            objImgEdit.Visible = true;



            //    }
            //    else
            //    {
            //        ////..Forming the Hyperlink to Navigate for Update Functionality
            //        //Literal tblProductID = (Literal)e.Row.FindControl("hdProductId");
            //        //HyperLink HyLinkEdit = (HyperLink)e.Row.FindControl("HyLinkEdit");

            //        //HyLinkEdit.NavigateUrl = "SA_ProductEdit.aspx?ProductID=" + tblProductID.Text;
            //        //HyLinkEdit.Visible = true;

            //        //if (objImgEdit != null)
            //        //    objImgEdit.Visible = false;


            //    }

            //}

            #endregion


            #region Showing Checkbox ticked image


            //need to find out if the logged users is not a superadmin disable the last cell 

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

                        //objImgActive.ImageUrl = @"~\Images\Active_Show.jpg";
                        objImgActive.ImageUrl = @"~\Images\checkbox_ticked.jpg";

                    }
                    else
                    {
                        //objImgActive.ImageUrl = @"~\Images\Active_Hide.jpg";
                        objImgActive.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }

            #endregion

            ////..Getting reference to the lblModifiedBy control 
            //Label objModByLabel = (Label)e.Row.FindControl("lblModifiedBy");
            //string strModifiedBy = objModByLabel.Text;


            //// --- Disable or hide the Update/Delete functionality for the SuperAdmin Rows

            ////.. getting reference the gridview row in row databound event. 
            //string strLoginName = string.Empty;
            //DataRowView rowView = (DataRowView)e.Row.DataItem;

            //strLoginName = rowView["LoginID"].ToString();

            //objModByLabel.Text = strLoginName;

            //if (strLoginName.ToUpper() == "SUPERADMIN")
            //{
            //    e.Row.CssClass = "SAgridviewrow";
            //    //e.Row.Cells[6].Controls.Clear();
            //    e.Row.Cells[6].Enabled = false;

            //}

            //============

        }
        


    }


    protected void btnPrt_UP_Click(object sender, EventArgs e)
    {

        //Button objBtn_UP = (Button)sender;
        ImageButton objBtn_UP = (ImageButton)sender;

        GridViewRow thisRow = (GridViewRow)objBtn_UP.Parent.Parent;

        Literal objLtr_CurrPriority = (Literal)thisRow.FindControl("LtrPriority");
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdProductId");

        string CurrPriority = objLtr_CurrPriority.Text;
        string CurrFaqID = objLtr_CurrFaqID.Text;

        GridView thisGrid = (GridView)thisRow.Parent.Parent;
        int MaxRows = thisGrid.Rows.Count;
        int CurrRowIndex = thisRow.RowIndex;
        int PrevRowIndex = CurrRowIndex - 1;

        if (PrevRowIndex >= 0)
        {

            GridViewRow previousRow = thisGrid.Rows[PrevRowIndex];
            Literal objLtr_PrevPriority = (Literal)previousRow.FindControl("LtrPriority");
            Literal objLtr_PrevFaqID = (Literal)previousRow.FindControl("hdProductId");
            string PrevPriority = objLtr_PrevPriority.Text;
            string PrevFaqID = objLtr_PrevFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblUserProducts", "ProductID", "IX_UserProducts_Priority", CurrPriority, CurrFaqID, PrevPriority, PrevFaqID, Session["UserID"].ToString());


                PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                //gridFaq.DataBind();
            }

        }

    }


    protected void btnPrt_DOWN_Click(object sender, EventArgs e)
    {

        //Button objBtn_DOWN = (Button)sender;
        ImageButton objBtn_DOWN = (ImageButton)sender;

        GridViewRow thisRow = (GridViewRow)objBtn_DOWN.Parent.Parent;

        Literal objLtr_CurrPriority = (Literal)thisRow.FindControl("LtrPriority");
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdProductId");

        string CurrPriority = objLtr_CurrPriority.Text;
        string CurrFaqID = objLtr_CurrFaqID.Text;

        GridView thisGrid = (GridView)thisRow.Parent.Parent;
        int MaxRows = thisGrid.Rows.Count;
        int CurrRowIndex = thisRow.RowIndex;
        int NextRowIndex = CurrRowIndex + 1;

        if (NextRowIndex < MaxRows)
        {

            GridViewRow NextRow = thisGrid.Rows[NextRowIndex];
            Literal objLtr_NextPriority = (Literal)NextRow.FindControl("LtrPriority");
            Literal objLtr_NextFaqID = (Literal)NextRow.FindControl("hdProductId");
            string NextPriority = objLtr_NextPriority.Text;
            string NextFaqID = objLtr_NextFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblUserProducts", "ProductID", "IX_UserProducts_Priority", CurrPriority, CurrFaqID, NextPriority, NextFaqID, Session["UserID"].ToString());

                PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

            }

        }

    }

    //protected void btnDeleteAll_Click(object sender, EventArgs e)
    //{
    //    string strTestIds = string.Empty;
    //    //Loop thru all the Rows
    //    foreach (GridViewRow gvRow in gridProducts.Rows)
    //    {
    //        CheckBox objCb = (CheckBox)gvRow.FindControl("chkSelect");
    //        if (objCb.Checked)
    //        {
    //            //Retrieve the NewsID to Delete
    //            if (strTestIds == string.Empty)
    //                strTestIds = Convert.ToString(gridProducts.DataKeys[gvRow.RowIndex].Value);
    //            else
    //                strTestIds = strTestIds + "," + Convert.ToString(gridProducts.DataKeys[gvRow.RowIndex].Value);
    //        }

    //    }

    //    if (strTestIds != string.Empty)
    //    {
    //        bool delMulStatus = objBAL_Testimonial.DeleteProductsData_Multiple(Convert.ToInt32(Session["UserID"]), strTestIds);



    //        if (delMulStatus)
    //        {
    //            tblMessageBar.Visible = true;
    //            lblErrMessage.Text = "Testimonial items Deleted Sucessfully";
    //            lblErrMessage.CssClass = "font_12Msg_Success";
    //            MessageImage.Src = "~/Images/inf_Sucess.gif";

    //        }
    //        else
    //        {
    //            lblErrMessage.Text = "Could not deleted the Testimonial item. Technical Error";
    //            lblErrMessage.CssClass = "font_12Msg_Error";
    //            tblMessageBar.Visible = true;
    //            MessageImage.Src = "~/Images/inf_Error.gif";
    //        }
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecNotSelected", "alert('Please select records to Delete.')", true);
    //        return;
    //    }

    //    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());


    //}


 }
