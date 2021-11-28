using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CMSv3.BAL;

public partial class SuperAdmin_SA_NewsListing : System.Web.UI.Page 
{
    DataSet ds;
    DataView dv;

    CMSv3.BAL.News objBAl_News = new CMSv3.BAL.News();
    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

    int qLgType = 0; 




    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 


        if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        {
            qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        }

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "";
            //ViewState["SortExpr"] = "UserID desc,LgType, Priority";
            ViewState["SortExpr"] = "";

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
        //if (qLgType != null)
        //    objddlSelLang.SelectedValue = Convert.ToString(qLgType);


        if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        {
            // qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
            if (Request.QueryString["LgType"] == "0")
            {
                //gridFaq.Columns[5].Visible = false;

                int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridNews);
                gridNews.Columns[ColIdx].Visible = false;
            }
        }
        else if (qLgType == 0)
        {
            int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridNews);
            gridNews.Columns[ColIdx].Visible = false;
        }
    }


    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        ds = objBAl_News.Retrieve_AllNewsByUserID(Convert.ToInt32(Session["saUserID"]), ViewState["RtType"].ToString(), qLgType);
        //ds = objBAl_News.Retrieve_AllNewsByUserID(101);

        

            if (ds.Tables[0].Rows.Count > 0)
            {

                dv = ds.Tables[0].DefaultView;
                if (vSortExpr != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }


                // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


                gridNews.DataSource = dv;
                gridNews.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridNews.DataSource = ds;
                gridNews.DataBind();

                int ColCount = gridNews.Rows[0].Cells.Count;
                gridNews.Rows[0].Cells.Clear();
                gridNews.Rows[0].Cells.Add(new TableCell());
                gridNews.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridNews.Rows[0].Cells[0].Text = "No records Found";
                gridNews.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




            }



    }



    protected void gridNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridNews.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridNews.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridNews.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridNews.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    //protected void gridNews_Sorting(object sender, GridViewSortEventArgs e)
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


    //public SortDirection GridViewSortDirection
    //{

    //    get
    //    {

    //        if (ViewState["sortDirection"] == null)

    //            ViewState["sortDirection"] = SortDirection.Ascending;

    //        return (SortDirection)ViewState["sortDirection"];

    //    }

    //    set { ViewState["sortDirection"] = value; }

    //}
    
    protected void gridNews_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridNews.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void gridNews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridNews.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridNews.Rows[e.RowIndex];

        //Get the reference to the TextFields in the grid view row
        TextBox tbNewsTitle = (TextBox)gRow.FindControl("txtNewsTitle");
        TextBox tbNewsContent = (TextBox)gRow.FindControl("txtNewsContent");
        Literal ltrNewsID = (Literal)gRow.FindControl("hdNewsID");

        HiddenField objHidUserType = (HiddenField)gRow.FindControl("hidUsertype");
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");

        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");


        string tmpNewsContent = tbNewsContent.Text;
        //tmpNewsContent = tmpNewsContent.Replace(Environment.NewLine, "<br/>");
        tmpNewsContent = CommonFunctions.HandleNewLines(tmpNewsContent, Request.UserAgent);

        if (qLgType == 0)
            qLgType = 1;


         bool upStatus;

         if (Convert.ToInt16(objHidUserType.Value) == 2)
         {
             CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
             bool tmpStatus = objBAL_CommonFunc.InsertUpdate_ShowAdminItems("tblNews", ltrNewsID.Text, Convert.ToInt32(Session["saUserID"]));

         }


         upStatus = objBAl_News.UpdateNewsData(tbNewsTitle.Text, tmpNewsContent.ToString(), Convert.ToInt32(Session["saUserID"]), Convert.ToInt32(ltrNewsID.Text), chkActive.Checked, qLgType);
  


        if (upStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "News Updated Sucessfully";
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

        gridNews.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void gridNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridNews.Rows[e.RowIndex];

        //Getting newsID reference
        Literal ltrNewsID = (Literal)gvRow.FindControl("hdNewsID");

        int NewsIdToDelte = Convert.ToInt32(ltrNewsID.Text);

        bool delStatus = objBAl_News.DeleteNewsData(Convert.ToInt32(Session["saUserID"]), NewsIdToDelte);
        

        if (delStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "News item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the News item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }


        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void gridNews_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(gridNews.BottomPagerRow, gridNews);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridNews.BottomPagerRow, gridNews);
        
    }


    protected void gridNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {

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


            DataRowView drv = ((DataRowView)e.Row.DataItem);

            TextBox objNewsContent = (TextBox)e.Row.FindControl("txtNewsContent");
            if (objNewsContent != null)
            {
                string tmpstr = drv["NewsContent"].ToString().Replace("<br/>", Environment.NewLine);
                objNewsContent.Text = tmpstr;
            }   

            #region Hiding UP - Down Prioty arrows for ADMIN and ALL listing 
            

            if (ViewState["RtType"] != null)
            {
                if ((ViewState["RtType"].ToString() == "ADMIN") || (ViewState["RtType"].ToString() == "ALL"))
                {
                    ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");
                    if (objImgDelete != null)
                        objImgDelete.Visible = false;

                    //.. disabling Order ability. 
                    ImageButton objImgBtnUP = (ImageButton)e.Row.FindControl("Imgbtn_orderUP");
                    ImageButton objImgBtnDown = (ImageButton)e.Row.FindControl("Imgbtn_orderDown");

                    if (objImgBtnUP != null)
                        objImgBtnUP.Visible = false;

                    if (objImgBtnDown != null)
                        objImgBtnDown.Visible = false;

                }

            }

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


        }


    }


    protected void btnPrt_UP_Click(object sender, EventArgs e)
    {

        //Button objBtn_UP = (Button)sender;
        ImageButton objBtn_UP = (ImageButton)sender;

        GridViewRow thisRow = (GridViewRow)objBtn_UP.Parent.Parent;

        Literal objLtr_CurrPriority = (Literal)thisRow.FindControl("LtrPriority");
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdNewsID");

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
            Literal objLtr_PrevFaqID = (Literal)previousRow.FindControl("hdNewsID");
            string PrevPriority = objLtr_PrevPriority.Text;
            string PrevFaqID = objLtr_PrevFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblNews", "NewsID", "IX_News_Priority", CurrPriority, CurrFaqID, PrevPriority, PrevFaqID, Session["saUserID"].ToString());


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
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdNewsID");

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
            Literal objLtr_NextFaqID = (Literal)NextRow.FindControl("hdNewsID");
            string NextPriority = objLtr_NextPriority.Text;
            string NextFaqID = objLtr_NextFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblNews", "NewsID", "IX_News_Priority", CurrPriority, CurrFaqID, NextPriority, NextFaqID, Session["saUserID"].ToString());

                PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

            }

        }

    }


    protected void btnDeleteMultiple_Click(object sender, EventArgs e)
    {

        string strNewsIDs = string.Empty;
        //Loop thru all the Rows
        foreach (GridViewRow gvRow in gridNews.Rows)
        {
            CheckBox objCb = (CheckBox)gvRow.FindControl("chkSelect");
            if (objCb.Checked)
            {
                //Retrieve the NewsID to Delete
                if (strNewsIDs == string.Empty) 
                    strNewsIDs = Convert.ToString(gridNews.DataKeys[gvRow.RowIndex].Value);
                else
                    strNewsIDs = strNewsIDs + "," + Convert.ToString(gridNews.DataKeys[gvRow.RowIndex].Value);
            }

        }

        string ab = strNewsIDs;

    }


    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        string strNewsIDs = string.Empty;
        //Loop thru all the Rows
        foreach (GridViewRow gvRow in gridNews.Rows)
        {
            CheckBox objCb = (CheckBox)gvRow.FindControl("chkSelect");
            if (objCb.Checked)
            {
                //Retrieve the NewsID to Delete
                if (strNewsIDs == string.Empty)
                    strNewsIDs = Convert.ToString(gridNews.DataKeys[gvRow.RowIndex].Value);
                else
                    strNewsIDs = strNewsIDs + "," + Convert.ToString(gridNews.DataKeys[gvRow.RowIndex].Value);
            }

        }

        if (strNewsIDs != string.Empty)
        {
            bool delMulStatus = objBAl_News.DeleteNewsData_Multiple(Convert.ToInt32(Session["saUserID"]), strNewsIDs);
        
       

                if (delMulStatus)
                {
                    tblMessageBar.Visible = true;
                    lblErrMessage.Text = "News item Deleted Sucessfully";
                    lblErrMessage.CssClass = "font_12Msg_Success";
                    MessageImage.Src = "~/Images/inf_Sucess.gif";

                }
                else
                {
                    lblErrMessage.Text = "Could not deleted the News item. Technical Error";
                    lblErrMessage.CssClass = "font_12Msg_Error";
                    tblMessageBar.Visible = true;
                    MessageImage.Src = "~/Images/inf_Error.gif";
                }
        }
         else
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecNotSelected", "alert('Please select records to Delete.')", true);
            return;
        }

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());


    }

  
}