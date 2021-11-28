using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using CMSv3.BAL;

public partial class SuperAdmin_SA_FaqListing : System.Web.UI.Page 
{

    DataSet ds;
    DataView dv;

    //CMSv3.BAL.Faq objBAl_Faq = new CMSv3.BAL.Faq();
    CMSv3.BAL.FAQ objBAL_Faq = new CMSv3.BAL.FAQ();

    int qLgType = 0;
    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

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
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "UserID desc,LgType, Priority";

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
        else
        {
           
        }
        tblMessageBar.Visible = false;

        #region  // rendering Language links // commented code 

        //string selectedLanguage= string.Empty;

        //  string QryLanguage = Request.QueryString["Lang"];
        //    if (QryLanguage == null || QryLanguage.ToString() == "")
        //    {
        //        selectedLanguage = "en-US";
        //    }
        //    else
        //    {
        //        selectedLanguage = QryLanguage;

        //    }
     
        
        //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);



  

        //string CurrentPgName = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);

        //ContentPlaceHolder cph = Page.Master.FindControl("ContentLeftMenu") as ContentPlaceHolder;
        //UserControl uc = (UserControl)cph.FindControl("SA_SideMenu_Faq1");

        //HyperLink HyFaqCreate = (HyperLink)uc.FindControl("Hyp_faqCreate");
        //HyFaqCreate.NavigateUrl = HyFaqCreate.NavigateUrl + "?Lang=" + selectedLanguage;

        //HyperLink HyFaqListing = (HyperLink)uc.FindControl("Hyp_faqListing");
        //HyFaqListing.NavigateUrl = HyFaqListing.NavigateUrl + "?Lang=" + selectedLanguage;

     
        //HyperLink HyEnglish = (HyperLink)uc.FindControl("Hyp_LgType_Eng");
        //HyEnglish.NavigateUrl = CurrentPgName + "?Lang=en-US";

        //HyperLink HyBahasa = (HyperLink)uc.FindControl("Hyp_LgType_Bms");
        //HyBahasa.NavigateUrl = CurrentPgName + "?Lang=ms-MY";

        //HyperLink HyChinese = (HyperLink)uc.FindControl("Hyp_LgType_Chi");
        //HyChinese.NavigateUrl = CurrentPgName + "?Lang=zh-CN"; 

        #endregion


    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        //PreSelecting the Language DropDown --
        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        //if(qLgType != null)
        //objddlSelLang.SelectedValue = Convert.ToString(qLgType);


        if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        {
            // qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
            if (Request.QueryString["LgType"] == "0")
            {
                //gridFaq.Columns[5].Visible = false;

                int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridFaq);
                gridFaq.Columns[ColIdx].Visible = false;
            }
        }
        else if (qLgType == 0)
        {
            int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridFaq);
            gridFaq.Columns[ColIdx].Visible = false;
        }
    }




    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        ds = objBAL_Faq.Retrieve_AllFaqByUserID(Convert.ToInt32(Session["saUserID"]), ViewState["RtType"].ToString(), qLgType);


        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            gridFaq.DataSource = dv;
            gridFaq.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridFaq.DataSource = ds;
            gridFaq.DataBind();

            int ColCount = gridFaq.Rows[0].Cells.Count;
            gridFaq.Rows[0].Cells.Clear();
            gridFaq.Rows[0].Cells.Add(new TableCell());
            gridFaq.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridFaq.Rows[0].Cells[0].Text = "No records Found";
            gridFaq.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void gridFaq_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridFaq.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridFaq.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridFaq.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridFaq.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    //protected void gridFaq_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void gridFaq_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridFaq.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void gridFaq_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridFaq.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridFaq_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridFaq.Rows[e.RowIndex];

        //Get the reference to the TextFields in the grid view row
        TextBox tbFaqQuestion = (TextBox)gRow.FindControl("txtFaqQuestion");
        
        TextBox tbFaqAnswer = (TextBox)gRow.FindControl("txtFaqAnswer");
        string tmpFaqAnswer = tbFaqAnswer.Text;
        //tmpFaqAnswer = tmpFaqAnswer.ToString().Replace(Environment.NewLine, "<br/>");
        tmpFaqAnswer = CommonFunctions.HandleNewLines(tmpFaqAnswer, Request.UserAgent);


        Literal ltrFaqID = (Literal)gRow.FindControl("hdFaqID");
        HiddenField objHidUserType = (HiddenField)gRow.FindControl("hidUsertype");
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");

        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");




        bool upStatus;
        if (Convert.ToInt16(objHidUserType.Value) == 2)
        {
            ////..if exists update else insert 
            //SqlConnection dbconn = new SqlConnection(GlobalVar.GetDbConnString.ToString());
            //dbconn.Open();

            //string strSQL = "Insert tblShowAdminItems (ItemTable, ItemIds, ForUserID) values ('tblFAQ'," + Convert.ToInt32(ltrFaqID.Text) + "," + Convert.ToInt32(Session["saUserID"]) + ")";

            //SqlCommand dbCmd = new SqlCommand(strSQL,dbconn);
            //dbCmd.ExecuteNonQuery();
            //dbconn.Close();

            CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
            bool tmpStatus = objBAL_CommonFunc.InsertUpdate_ShowAdminItems("tblFAQ",ltrFaqID.Text, Convert.ToInt32(Session["saUserID"]));
                        
        }

        string vFaqAnwer = tmpFaqAnswer.Replace("'", "''");
        string vFaqQuestion = tbFaqQuestion.Text.Replace("'", "''");

        upStatus = objBAL_Faq.UpdateFaqData(vFaqQuestion, vFaqAnwer, Convert.ToInt32(objHidUserID.Value), Convert.ToInt32(ltrFaqID.Text), chkActive.Checked, qLgType);
     

        if (upStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Faq Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the Faq. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        gridFaq.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void gridFaq_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridFaq.Rows[e.RowIndex];

        //Getting FaqID reference
        Literal ltrFaqID = (Literal)gvRow.FindControl("hdFaqID");

        int FaqIdToDelte = Convert.ToInt32(ltrFaqID.Text);

        bool delStatus = objBAL_Faq.DeleteFaqData(Convert.ToInt32(Session["saUserID"]), FaqIdToDelte);


        if (delStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Faq item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the Faq item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }


        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void gridFaq_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(gridFaq.BottomPagerRow, gridFaq);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridFaq.BottomPagerRow, gridFaq);

    }


    protected void gridFaq_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.Header)
        {

            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");

            //To get the up/down image at the sorted column 
            //CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //CheckBox objChkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //objChkSelect.Attributes.Add("onClick", "SelectRow('" + objChkSelect.ClientID + "')");
            //if (gridFaq.Rows.Count > 0)
            //{

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");

            

                //..Getting reference to the lblModifiedBy control 
                Label objModByLabel = (Label)e.Row.FindControl("lblModifiedBy");
                string strModifiedBy = objModByLabel.Text;


                DataRowView drv = ((DataRowView)e.Row.DataItem);

                TextBox objfaqAnswer = (TextBox)e.Row.FindControl("txtFaqAnswer");
                if (objfaqAnswer != null)
                {
                    string tmpstr = drv["FaqAnswer"].ToString().Replace("<br/>", Environment.NewLine);
                    objfaqAnswer.Text = tmpstr;
                }   



                // --- Disable or hide the Update/Delete functionality for the SuperAdmin Rows

                if (ViewState["RtType"] != null)
                {
                    //if (ViewState["RtType"].ToString() == "ALL")
                    //{
                        ////.. disabling Order ability. 
                        //ImageButton objImgBtnUP = (ImageButton)e.Row.FindControl("Imgbtn_orderUP");
                        //ImageButton objImgBtnDown = (ImageButton)e.Row.FindControl("Imgbtn_orderDown");

                        //if (objImgBtnUP != null)
                        //    objImgBtnUP.Visible = false;

                        //if (objImgBtnDown != null)
                        //    objImgBtnDown.Visible = false;

                       
                        
                        //Label objModifiedBy = (Label)e.Row.FindControl("lblModifiedBy");

                        //HiddenField objUserType = (HiddenField)e.Row.FindControl("hidUserType");


                        //if (objUserType != null)
                        //{
                        //    if (Convert.ToInt32(objUserType.Value) == Convert.ToInt16(GlobalVar.ListingUserTypesEnums.ADMIN))
                        //    {
                        //        //ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");
                        //        ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");

                        //        //if (objImgEdit != null)
                        //        //    objImgEdit.Visible = false;

                        //        if (objImgDelete != null)
                        //            objImgDelete.Visible = false;

                        //        e.Row.CssClass = "SAgridviewrow";
                        //    }
                        //}

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

                //.. getting reference the gridview row in row databound event. 
                string strLoginName = string.Empty;
                DataRowView rowView = (DataRowView)e.Row.DataItem;

                strLoginName = rowView["LoginID"].ToString();
                objModByLabel.Text = strLoginName;

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


        }

    }


    protected void btnPrt_UP_Click(object sender, EventArgs e)
    {

        //Button objBtn_UP = (Button)sender;
        ImageButton objBtn_UP = (ImageButton)sender;

        GridViewRow thisRow = (GridViewRow)objBtn_UP.Parent.Parent;

        Literal objLtr_CurrPriority = (Literal)thisRow.FindControl("LtrPriority");
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdFaqID");

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
            Literal objLtr_PrevFaqID = (Literal)previousRow.FindControl("hdFaqID");
            string PrevPriority = objLtr_PrevPriority.Text;
            string PrevFaqID = objLtr_PrevFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
                
                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblfaq", "faqid", "IX_Users_Priority", CurrPriority, CurrFaqID, PrevPriority, PrevFaqID, Session["saUserID"].ToString());

                #region Commented code 

               
                //   update data base tables. 

                 //SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                 //dbConn.Open();

                 //String strSQL = "ALTER INDEX IX_Users_Priority ON tblFAQ DISABLE; Update tblFaq set Priority =" + PrevPriority + " where faqid=" + CurrFaqID + " and UserID = " + Convert.ToInt32(Session["saUserID"]);
                 //SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
                 //dbCmd.ExecuteNonQuery();


                 //strSQL = "Update tblFaq set Priority =" + CurrPriority + " where faqid=" + PrevFaqID + " and UserID = " + Convert.ToInt32(Session["saUserID"]) + "; ALTER INDEX IX_Users_Priority ON tblFAQ REBUILD";
                 //dbCmd = new SqlCommand(strSQL, dbConn);
                 //dbCmd.ExecuteNonQuery();

                    //dbConn.Close();

                #endregion

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
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdFaqID");

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
            Literal objLtr_NextFaqID = (Literal)NextRow.FindControl("hdFaqID");
            string NextPriority = objLtr_NextPriority.Text;
            string NextFaqID = objLtr_NextFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblfaq", "faqid", "IX_Users_Priority", CurrPriority, CurrFaqID, NextPriority, NextFaqID, Session["saUserID"].ToString());

                #region Commented code


                //   update data base tables. 

                //SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                //dbConn.Open();

                //String strSQL = "ALTER INDEX IX_Users_Priority ON tblFAQ DISABLE; Update tblFaq set Priority =" + PrevPriority + " where faqid=" + CurrFaqID + " and UserID = " + Convert.ToInt32(Session["saUserID"]);
                //SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
                //dbCmd.ExecuteNonQuery();


                //strSQL = "Update tblFaq set Priority =" + CurrPriority + " where faqid=" + PrevFaqID + " and UserID = " + Convert.ToInt32(Session["saUserID"]) + "; ALTER INDEX IX_Users_Priority ON tblFAQ REBUILD";
                //dbCmd = new SqlCommand(strSQL, dbConn);
                //dbCmd.ExecuteNonQuery();

                //dbConn.Close();

                #endregion

                PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                //gridFaq.DataBind();
            }

        }

    }

    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        string strFaqIDs = string.Empty;
        //Loop thru all the Rows
        foreach (GridViewRow gvRow in gridFaq.Rows)
        {
            CheckBox objCb = (CheckBox)gvRow.FindControl("chkSelect");
            if (objCb.Checked)
            {
                //Retrieve the FaqID to Delete
                if (strFaqIDs == string.Empty)
                    strFaqIDs = Convert.ToString(gridFaq.DataKeys[gvRow.RowIndex].Value);
                else
                    strFaqIDs = strFaqIDs + "," + Convert.ToString(gridFaq.DataKeys[gvRow.RowIndex].Value);
            }

        }

        if (strFaqIDs != string.Empty)
        {
            
            bool DelMulstatus = objBAL_Faq.DeleteFaqData_Multiple(Convert.ToInt32(Session["saUserID"]), strFaqIDs);



            if (DelMulstatus)
            {
                tblMessageBar.Visible = true;
                lblErrMessage.Text = "Faq item Deleted Sucessfully";
                lblErrMessage.CssClass = "font_12Msg_Success";
                MessageImage.Src = "~/Images/inf_Sucess.gif";

            }
            else
            {
                lblErrMessage.Text = "Could not deleted the Faq item. Technical Error";
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
