using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.Entities;
using CMSv3.BAL;


public partial class Admin_Ad_SystemNewsListing : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;


    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;
    CMSv3.Entities.News objNews = new CMSv3.Entities.News();
    CMSv3.BAL.News objBAL_News = new CMSv3.BAL.News();
    
    int qLgType = 0;

    string strSQL = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 


        if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        {
            qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        }


        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "LgType, CreatedDate";

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
        ltrSystemNewsListing.Text = Resources.LangResources.SystemNews + " " + Resources.LangResources.Listing;
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

        //        //gridSystemNews.Columns[9].Visible = false;
        //        int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridSystemNews);
        //        gridSystemNews.Columns[ColIdx].Visible = false;
        //    }
        //}
        //else if (qLgType == 0)
        //{
        //    int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridSystemNews);
        //    gridSystemNews.Columns[ColIdx].Visible = false;
        //}


    }



    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        //ds = objBAl_Event.Retrieve_AllEventByUserID(101);
        //ds = objBAL_Testimonial.RetrieveAllTestimonials_ByUserID(Convert.ToInt32(Session["UserID"]), ViewState["RtType"].ToString(), qLgType);

        strSQL = "EXEC usp_SystemNews_Retrieve_ByUserID " + Convert.ToInt32(Session["UserID"]) + "," + qLgType;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);


            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);



            if (ds.Tables[0].Rows.Count > 0)
            {

                dv = ds.Tables[0].DefaultView;
                if (vSortExpr != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }


                // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


                gridSystemNews.DataSource = dv;
                gridSystemNews.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridSystemNews.DataSource = ds;
                gridSystemNews.DataBind();

                int ColCount = gridSystemNews.Rows[0].Cells.Count;
                gridSystemNews.Rows[0].Cells.Clear();
                gridSystemNews.Rows[0].Cells.Add(new TableCell());
                gridSystemNews.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridSystemNews.Rows[0].Cells[0].Text = "No records Found";
                gridSystemNews.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }


    }


    protected void gridSystemNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridSystemNews.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridSystemNews.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridSystemNews.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridSystemNews.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridSystemNews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridSystemNews.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridSystemNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridSystemNews.Rows[e.RowIndex];

        //Getting eventID reference
        Literal ltrTestimonialID = (Literal)gvRow.FindControl("hdtstID");

        int TestimonialIdToDelte = Convert.ToInt32(ltrTestimonialID.Text);

       // bool delStatus = objBAL_Testimonial.DeleteTestimonialsData(Convert.ToInt32(Session["UserID"]), TestimonialIdToDelte);
        bool delStatus= false;
        
        

        if (delStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "System News item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the Testimonial item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

    }


    protected void gridSystemNews_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //gridSystemNews.EditIndex = e.NewEditIndex;
        //PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //GridViewRow gRow = (GridViewRow)gridSystemNews.Rows[e.NewEditIndex];
        //Literal ltrTstID = (Literal)gRow.FindControl("hdTstId");
        gridSystemNews.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //Server.Transfer("TestimonialViewEdit.aspx?TestimonialID=" + ltrTstID.Text);
    }


    protected void gridSystemNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridSystemNews.Rows[e.RowIndex];
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");
        HiddenField objHidLgType = (HiddenField)gRow.FindControl("hidLgType");
        Literal ltrSnID = (Literal)gRow.FindControl("hdSnId");
        TextBox tbSysSubject = (TextBox)gRow.FindControl("txtSubject");
        TextBox tbSysContent = (TextBox)gRow.FindControl("txtContents");

        objNews.NewsID = Convert.ToInt32(ltrSnID.Text);
        objNews.NewsTitle = tbSysSubject.Text;
        objNews.NewsUserID = Convert.ToInt32(Session["UserID"]);
        
        string tmpSysContent = tbSysContent.Text;
        tmpSysContent = tmpSysContent.ToString().Replace(Environment.NewLine, "<br/>");
        objNews.NewsContent = tmpSysContent;

                
        bool upStatus = false;

        upStatus = objBAL_News.Update_SystemNewsData(objNews, chkActive.Checked, Convert.ToInt16(objHidLgType.Value)); 
        ////strSQL = "EXEC [usp_SystemNews_Update_ByUserID] '" + tbSysSubject.Text + "','" + tmpSysContent + "'," + Convert.ToInt32(Session["UserID"]) + "," + Convert.ToInt16(chkActive.Checked) + "," + objHidLgType.Value + "," + ltrSnID.Text;
        //dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        //try
        //{
        //    dbConn.Open();
        //    dbCmd = new SqlCommand(strSQL, dbConn);

        //    rowCount = dbCmd.ExecuteNonQuery();

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //    dbConn.Close();
        //}


       // if (Convert.ToInt16(objHidUserType.Value) == 2)
       // {
       //     CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
       //     upStatus = objBAL_CommonFunc.InsertUpdate_ShowAdminItems("tblTestimonial", ltrTstID.Text, Convert.ToInt32(Session["UserID"]));

       //   }
       //else
       // {
       //     upStatus = objBAL_Testimonial.UpdateTestimonialsActiveStatus(Convert.ToInt32(ltrTstID.Text), Convert.ToInt32(Session["UserID"]), chkActive.Checked);
       // }




        if (upStatus)
                {
                    tblMessageBar.Visible = true;
                    lblErrMessage.Text = "System News Item Updated Sucessfully";
                    lblErrMessage.CssClass = "font_12Msg_Success";
                    MessageImage.Src = "~/Images/inf_Sucess.gif";
                }
                else
                {
                    lblErrMessage.Text = "Could not Update the System News Item. Technical Error";
                    lblErrMessage.CssClass = "font_12Msg_Error";
                    tblMessageBar.Visible = true;
                    MessageImage.Src = "~/Images/inf_Error.gif";
                }

      

        //Get the reference to the TextFields in the grid view row
        ////TextBox tbTstTitle = (TextBox)gRow.FindControl("txtTstTitle");
        ////TextBox tbTstContent = (TextBox)gRow.FindControl("txtTstContent");

        gridSystemNews.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        


    }


    protected void gridSystemNews_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;
        PopulateGrid(m_SortExpr, sortOrder);
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


    protected void gridSystemNews_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridSystemNews.BottomPagerRow, gridSystemNews);
    }


    protected void gridSystemNews_RowDataBound(object sender, GridViewRowEventArgs e)
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


           // e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
           // e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");


            DataRowView drv = ((DataRowView)e.Row.DataItem);

            TextBox objNewsContent = (TextBox)e.Row.FindControl("txtContents");
            if (objNewsContent != null)
            {
                string tmpstr = drv["Contents"].ToString().Replace("<br/>", Environment.NewLine);
                objNewsContent.Text = tmpstr;
            }



            e.Row.Cells[1].Attributes.Add("onmouseover", "this.style.backgroundColor='#F3EECA';this.style.cursor='hand';this.style.textDecoration='underline';");
            e.Row.Cells[1].Attributes.Add("onmouseout", "this.style.backgroundColor='';this.style.textDecoration='none';");

            e.Row.Cells[2].Attributes.Add("onmouseover", "this.style.backgroundColor='#F3EECA';this.style.cursor='hand';this.style.textDecoration='underline';");
            e.Row.Cells[2].Attributes.Add("onmouseout", "this.style.backgroundColor='';this.style.textDecoration='none';");


            e.Row.Cells[1].Attributes.Add("title", "Click here to see more details...");
            e.Row.Cells[2].Attributes.Add("title", "Click here to see more details...");

          // ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");


            // Javascrip Function to open New Window showing System News 

            Literal oblLtrSysNewsID = (Literal)e.Row.FindControl("hdSnId");
            string alertBox = "ShowSystemNews('";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                // alertBox += e.Row.RowIndex;
                alertBox += oblLtrSysNewsID.Text;
                alertBox += "')";
                e.Row.Attributes.Add("onclick", alertBox);

            }



            #region //Commented // Hiding UP - Down Prioty arrows for ADMIN and ALL listing


            //if (ViewState["RtType"] != null)
            //{
            //    if ((ViewState["RtType"].ToString() == "ADMIN") || (ViewState["RtType"].ToString() == "ALL"))
            //    {
                    
            //        gridSystemNews.Columns[9].Visible = false;

            //        ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");
            //        if (objImgDelete != null)
            //            objImgDelete.Visible = false;

            //        ////.. disabling Order ability. 
            //        //ImageButton objImgBtnUP = (ImageButton)e.Row.FindControl("Imgbtn_orderUP");
            //        //ImageButton objImgBtnDown = (ImageButton)e.Row.FindControl("Imgbtn_orderDown");

            //        //if (objImgBtnUP != null)
            //        //    objImgBtnUP.Visible = false;

            //        //if (objImgBtnDown != null)
            //        //    objImgBtnDown.Visible = false;


            //        if (objImgEdit != null)
            //            objImgEdit.Visible = true;




            //        TextBox txtestimonial = (TextBox)e.Row.FindControl("txtestimonial");
            //        TextBox txtByName = (TextBox)e.Row.FindControl("txtByName");
            //        TextBox txtByDesignation = (TextBox)e.Row.FindControl("txtByName");
            //        TextBox txtByCompany = (TextBox)e.Row.FindControl("txtByName");


            //        if (txtestimonial != null)
            //        {
            //            txtestimonial.ReadOnly = true;
            //            //txtestimonial.CssClass = "stdTextField1_disabled";
            //            txtestimonial.CssClass = "stdTextArea2_disabled";
            //        }

            //        if (txtByName != null)
            //        {
            //            txtByName.ReadOnly = true;
            //            txtByName.CssClass = "stdTextField1_disabled";
            //        }

            //        if (txtByDesignation != null)
            //        {
            //            txtByDesignation.ReadOnly = true;
            //            txtByDesignation.CssClass = "stdTextField1_disabled";
            //        }

            //        if (txtByCompany != null)
            //        {
            //            txtByCompany.ReadOnly = true;
            //            txtByCompany.CssClass = "stdTextField1_disabled";
            //        }

            //    }
            //    else
            //    {
            //        //..Forming the Hyperlink to Navigate for Update Functionality
            //        Literal ltrTstID = (Literal)e.Row.FindControl("hdTstId");
            //        HyperLink HyLinkEdit = (HyperLink)e.Row.FindControl("HyLinkEdit");

            //        HyLinkEdit.NavigateUrl = "SA_TestimonialEdit.aspx?TstID=" + ltrTstID.Text + "&Lgtype=" + qLgType;
            //        HyLinkEdit.Visible = true;

            //        if (objImgEdit != null)
            //            objImgEdit.Visible = false;


            //    }

            //}

            #endregion


            #region // Commented // Showing Checkbox ticked image


            ////need to find out if the logged users is not a superadmin disable the last cell 

            ////============

            //Literal objLtrActive = (Literal)e.Row.FindControl("LtrActive");
            //Image objImgActive = (Image)e.Row.FindControl("ImgActive");

            ////String LtrShowActive = rowView["LtrActive"].ToString();

            //if (objImgActive != null)
            //{
            //    if(objLtrActive.Text != "")
            //    {
            //    if (Convert.ToBoolean(objLtrActive.Text))
            //    {

            //        //objImgActive.ImageUrl = @"~\Images\Active_Show.jpg";
            //        objImgActive.ImageUrl = @"~\Images\checkbox_ticked.jpg";

            //    }
            //    else
            //    {
            //        //objImgActive.ImageUrl = @"~\Images\Active_Hide.jpg";
            //        objImgActive.ImageUrl = @"~\Images\checkbox_empty.jpg";
            //    }
            //    }
            //}

            #endregion


        }
        


    }


    protected void btnPrt_UP_Click(object sender, EventArgs e)
    {

        //Button objBtn_UP = (Button)sender;
        ImageButton objBtn_UP = (ImageButton)sender;

        GridViewRow thisRow = (GridViewRow)objBtn_UP.Parent.Parent;

        Literal objLtr_CurrPriority = (Literal)thisRow.FindControl("LtrPriority");
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdTstId");

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
            Literal objLtr_PrevFaqID = (Literal)previousRow.FindControl("hdTstId");
            string PrevPriority = objLtr_PrevPriority.Text;
            string PrevFaqID = objLtr_PrevFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblTestimonial", "TstId", "IX_Testimonial_Priority", CurrPriority, CurrFaqID, PrevPriority, PrevFaqID, Session["UserID"].ToString());


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
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdTstId");

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
            Literal objLtr_NextFaqID = (Literal)NextRow.FindControl("hdTstId");
            string NextPriority = objLtr_NextPriority.Text;
            string NextFaqID = objLtr_NextFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblTestimonial", "TstId", "IX_Testimonial_Priority", CurrPriority, CurrFaqID, NextPriority, NextFaqID, Session["UserID"].ToString());

                PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

            }

        }

    }

    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        string strTestIds = string.Empty;
        //Loop thru all the Rows
        foreach (GridViewRow gvRow in gridSystemNews.Rows)
        {
            CheckBox objCb = (CheckBox)gvRow.FindControl("chkSelect");
            if (objCb.Checked)
            {
                //Retrieve the NewsID to Delete
                if (strTestIds == string.Empty)
                    strTestIds = Convert.ToString(gridSystemNews.DataKeys[gvRow.RowIndex].Value);
                else
                    strTestIds = strTestIds + "," + Convert.ToString(gridSystemNews.DataKeys[gvRow.RowIndex].Value);
            }

        }

        if (strTestIds != string.Empty)
        {
            //bool delMulStatus = objBAL_Testimonial.DeleteTestimonialsData_Multiple(Convert.ToInt32(Session["UserID"]), strTestIds);
            bool delMulStatus = false;


            if (delMulStatus)
            {
                tblMessageBar.Visible = true;
                lblErrMessage.Text = "Testimonial items Deleted Sucessfully";
                lblErrMessage.CssClass = "font_12Msg_Success";
                MessageImage.Src = "~/Images/inf_Sucess.gif";

            }
            else
            {
                lblErrMessage.Text = "Could not deleted the Testimonial item. Technical Error";
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
