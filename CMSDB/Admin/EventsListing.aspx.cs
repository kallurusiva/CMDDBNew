using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using MKB.TimePicker;


public partial class Admin_EventsListing : BasePage
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;
    CMSv3.BAL.Events objBAL_Events = new CMSv3.BAL.Events();
    CMSv3.Entities.Events objEvents = new CMSv3.Entities.Events();
    bool boolHasRows = false;
    int qLgType = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        ltrEventsListing.Text = Resources.LangResources.Events + " " + Resources.LangResources.Listing;
        boolHasRows = GetBool();

        if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        {
            qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        }

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "UserID desc, Priority";

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

    private static bool GetBool()
    {
        return false;

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //PreSelecting the Language DropDown --
        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
       
        objddlSelLang.SelectedValue = Convert.ToString(qLgType);

        ltrEventsListing.Text = Resources.LangResources.Events + " " + Resources.LangResources.Listing;

     
        if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        {
            // qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
            if (Request.QueryString["LgType"] == "0")
            {
                //gridFaq.Columns[5].Visible = false;

                int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridEvents);
                gridEvents.Columns[ColIdx].Visible = false;
            }
        }
        else if (qLgType == 0)
        {
            int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridEvents);
            gridEvents.Columns[ColIdx].Visible = false;
        }


    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        boolHasRows = false;
        ds = objBAL_Events.RetrieveAllEvents_ByUserID(Convert.ToInt32(Session["UserID"]), ViewState["RtType"].ToString(), qLgType);
        //ds = objBAl_Event.Retrieve_AllEventByUserID(101);

        

            if (ds.Tables[0].Rows.Count > 0)
            {

                dv = ds.Tables[0].DefaultView;
                if (vSortExpr != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }


                // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


                gridEvents.DataSource = dv;
                gridEvents.DataBind();
                boolHasRows = true;
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridEvents.DataSource = ds;
                gridEvents.DataBind();

                int ColCount = gridEvents.Rows[0].Cells.Count;
                gridEvents.Rows[0].Cells.Clear();
                gridEvents.Rows[0].Cells.Add(new TableCell());
                gridEvents.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridEvents.Rows[0].Cells[0].Text = "No records Found";
                gridEvents.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




            }



    }


    protected void gridEvents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEvents.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridEvents.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridEvents.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridEvents.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridEvents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridEvents.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridEvents_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridEvents.Rows[e.RowIndex];

        //Getting eventID reference
        Literal ltrEventID = (Literal)gvRow.FindControl("hdEventID");

        int EventIdToDelte = Convert.ToInt32(ltrEventID.Text);

        bool delStatus = objBAL_Events.DeleteEventsData(Convert.ToInt32(Session["UserID"]), EventIdToDelte);


        if (delStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Event item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the Event item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

    }
    
    
    protected void gridEvents_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridEvents.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }


    protected void gridEvents_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridEvents.Rows[e.RowIndex];

        //Get the reference to the TextFields in the grid view row
        TextBox tbEventTitle = (TextBox)gRow.FindControl("txtEventTitle");
        TextBox tbEventContent = (TextBox)gRow.FindControl("txtEventContent");
        Literal ltrEventID = (Literal)gRow.FindControl("hdEventID");
        HiddenField objHidUserType = (HiddenField)gRow.FindControl("hidUsertype");
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");

        //--From and TO dates

        TextBox tbFromDateTime = (TextBox)gRow.FindControl("txtEvtFROMdate");
        TextBox tbToDateTime = (TextBox)gRow.FindControl("txtEvtTOdate");



        //TextBox tbEvtFromDate = (TextBox)gRow.FindControl("txtdateFROM");
        //TextBox tbEvtTODate = (TextBox)gRow.FindControl("txtdateTO");

        //TimeSelector tbEvtFromTime = (TimeSelector)gRow.FindControl("TimeSelector_From");
        //TimeSelector tbEvtTOTime = (TimeSelector)gRow.FindControl("TimeSelector_TO");

        //string selFromDate = tbEvtFromDate.Text;
        //string selToDate = tbEvtTODate.Text;
        //string selFromTime = tbEvtFromTime.Date.ToShortTimeString();
        //string selToTime = tbEvtTOTime.Date.ToShortTimeString();

        //string FullFromDateTime = selFromDate + " " + selFromTime;
        //string FullToDateTime = selToDate + " " + selToTime;

        //objEvents.EventDateFROM = Convert.ToDateTime(FullFromDateTime);
        //objEvents.EventDateTO = Convert.ToDateTime(FullToDateTime);

        
     
        //----------------------------------------------------------------



        objEvents = new CMSv3.Entities.Events();
        objEvents.EventTitle = tbEventTitle.Text;

        //-- Replacing line breaks;
        String tmpEvtContent = tbEventContent.Text;
        //tmpEvtContent = tmpEvtContent.ToString().Replace(Environment.NewLine, "<br/>");
        tmpEvtContent = CommonFunctions.HandleNewLines(tmpEvtContent, Request.UserAgent);
        objEvents.EventContent = tmpEvtContent;

        objEvents.EventID = Convert.ToInt32(ltrEventID.Text);
        objEvents.UserID = Convert.ToInt32(Session["UserID"]);
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");

        objEvents.EventDateFROM = FormatDate(tbFromDateTime.Text);
        objEvents.EventDateTO = FormatDate(tbToDateTime.Text);


        ///-- Working Model 
            //TextBox tbEvtFromDate = (TextBox)gRow.FindControl("txtdateFROM");
            //TextBox tbEvtTODate = (TextBox)gRow.FindControl("txtdateTO");
            //objEvents.EventDateFROM = FormatDate(tbEvtFromDate.Text);
            //objEvents.EventDateTO = FormatDate(tbEvtTODate.Text);
        //----


        bool upStatus;

        if (Convert.ToInt16(objHidUserType.Value) == 2)
        {
            CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
            upStatus = objBAL_CommonFunc.InsertUpdate_ShowAdminItems("tblEvents",ltrEventID.Text, Convert.ToInt32(Session["UserID"]));
          
        }
        else
        {

            upStatus = objBAL_Events.UpdateEventsData(objEvents, chkActive.Checked,1);
        }

        if (upStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Event Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the Event. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        gridEvents.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());


    }

    public static DateTime FormatDate(string date)
    {
        char sept = '/';
        if (date.Contains("-"))
        {
            sept = '-';
        }

        string[] arr = date.Split(sept);
        return Convert.ToDateTime(arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString());
    }


    //protected void gridEvents_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void gridEvents_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridEvents.BottomPagerRow, gridEvents);
    }


    protected void gridEvents_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {

            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");


            ////GetSortedImage(GridViewRow gvRow, string vSortExpr, string vSortDir);
            ////To get the up/down image at the sorted column 
            //CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 
            

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //CheckBox objChkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //objChkSelect.Attributes.Add("onClick", "SelectRow('" + objChkSelect.ClientID + "')");

          //  if(boolHasRows){

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");


            DataRowView drv = ((DataRowView)e.Row.DataItem);

            TextBox objNewsContent = (TextBox)e.Row.FindControl("txtEventContent");
            if (objNewsContent != null)
            {
                string tmpstr = drv["EventContent"].ToString().Replace("<br/>", Environment.NewLine);
                objNewsContent.Text = tmpstr;
            }


            TextBox tbFromDateTime = (TextBox)e.Row.FindControl("txtEvtFROMdate");
            TextBox tbToDateTime = (TextBox)e.Row.FindControl("txtEvtTOdate");

            if (tbFromDateTime != null)
                tbFromDateTime.Attributes.Add("readonly", "readonly");

            if (tbToDateTime != null)
                tbToDateTime.Attributes.Add("readonly", "readonly");

            HtmlImage objImgFrom = (HtmlImage)e.Row.FindControl("ImgFrom");
            HtmlImage objImgTO = (HtmlImage)e.Row.FindControl("ImgTO");

            if (objImgFrom != null)
                objImgFrom.Attributes.Add("onclick", "NewCssCal('" + tbFromDateTime.ClientID + "','ddmmyyyy','ARROW',true);");

            if (objImgTO != null)
                objImgTO.Attributes.Add("onclick", "NewCssCal('" + tbToDateTime.ClientID + "','ddmmyyyy','ARROW',true);");



           
            if (ViewState["RtType"] != null)
            {

                //if ((ViewState["RtType"].ToString() == "USER"))
                //{
                //    if (ViewState["RtType"].ToString() == "ALL")
                //        gridEvents.Columns[7].Visible = false;
                //}
                if ((ViewState["RtType"].ToString() == "ADMIN") || (ViewState["RtType"].ToString() == "ALL"))
                {


                    gridEvents.Columns[7].Visible = false;

                    ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");
                    if (objImgDelete != null)
                        objImgDelete.Visible = false;

                    ////.. disabling Order ability. 
                    //ImageButton objImgBtnUP = (ImageButton)e.Row.FindControl("Imgbtn_orderUP");
                    //ImageButton objImgBtnDown = (ImageButton)e.Row.FindControl("Imgbtn_orderDown");

                    //if (objImgBtnUP != null)
                    //    objImgBtnUP.Visible = false;

                    //if (objImgBtnDown != null)
                    //    objImgBtnDown.Visible = false;


                    TextBox txtEventTitle = (TextBox)e.Row.FindControl("txtEventTitle");
                    TextBox txtEventContent = (TextBox)e.Row.FindControl("txtEventContent");


                    if (txtEventTitle != null)
                    {

                        txtEventTitle.ReadOnly = true;
                        txtEventTitle.CssClass = "stdTextField1_disabled";
                    }


                    if (txtEventContent != null)
                    {
                        txtEventContent.ReadOnly = true;
                        txtEventContent.CssClass = "stdTextArea2_disabled";
                    }







                }
              }

            



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



           // }
        }


    }

    protected void btnPrt_UP_Click(object sender, EventArgs e)
    {

        //Button objBtn_UP = (Button)sender;
        ImageButton objBtn_UP = (ImageButton)sender;

        GridViewRow thisRow = (GridViewRow)objBtn_UP.Parent.Parent;

        Literal objLtr_CurrPriority = (Literal)thisRow.FindControl("LtrPriority");
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdEventID");

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
            Literal objLtr_PrevFaqID = (Literal)previousRow.FindControl("hdEventID");
            string PrevPriority = objLtr_PrevPriority.Text;
            string PrevFaqID = objLtr_PrevFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblEvents", "EventID", "IX_Events_Priority", CurrPriority, CurrFaqID, PrevPriority, PrevFaqID, Session["UserID"].ToString());

               
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
        Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdEventID");

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
            Literal objLtr_NextFaqID = (Literal)NextRow.FindControl("hdEventID");
            string NextPriority = objLtr_NextPriority.Text;
            string NextFaqID = objLtr_NextFaqID.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblEvents", "EventID", "IX_Events_Priority", CurrPriority, CurrFaqID, NextPriority, NextFaqID, Session["UserID"].ToString());

                PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
               
            }

        }

    }

    //protected void btnDeleteAll_Click(object sender, EventArgs e)
    //{
    //    string strEventIDs = string.Empty;
    //    //Loop thru all the Rows
    //    foreach (GridViewRow gvRow in gridEvents.Rows)
    //    {
    //        CheckBox objCb = (CheckBox)gvRow.FindControl("chkSelect");
    //        if (objCb.Checked)
    //        {
    //            //Retrieve the NewsID to Delete
    //            if (strEventIDs == string.Empty)
    //                strEventIDs = Convert.ToString(gridEvents.DataKeys[gvRow.RowIndex].Value);
    //            else
    //                strEventIDs = strEventIDs + "," + Convert.ToString(gridEvents.DataKeys[gvRow.RowIndex].Value);
    //        }

    //    }

    //    if (strEventIDs != string.Empty)
    //    {
    //        bool delMulStatus = objBAL_Events.DeleteEventsData_Multiple(Convert.ToInt32(Session["UserID"]), strEventIDs);



    //        if (delMulStatus)
    //        {
    //            tblMessageBar.Visible = true;
    //            lblErrMessage.Text = "News item Deleted Sucessfully";
    //            lblErrMessage.CssClass = "font_12Msg_Success";
    //            MessageImage.Src = "~/Images/inf_Sucess.gif";

    //        }
    //        else
    //        {
    //            lblErrMessage.Text = "Could not deleted the News item. Technical Error";
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
