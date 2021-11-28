using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;

public partial class SuperAdmin_SA_EmailListing : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;

    DataSet ds;
    DataView dv;

    string strSQL;

    //CMSv3.BAL.Faq objBAl_Faq = new CMSv3.BAL.Faq();
    CMSv3.BAL.FAQ objBAL_Faq = new CMSv3.BAL.FAQ();
    //int qLgType = 0;

    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "CreatedDate, UserID";

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
    }

    


    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        //ds = objBAL_Faq.Retrieve_AllFaqByUserID(Convert.ToInt32(Session["UserID"]));



        //strSQL = "Select enqID, Name,ContactNo, Email, Subject, Body, enqType,CreatedDate,UserID, " +
        //        "Case When enqType = 1 Then 'ContactUs' ELSE 'Free Registration' END as 'enqTypeText' " +
        //            " from tblEnquiry where UserId = " + Convert.ToInt32(Session["UserID"]) +
        //            " and deleted = 0 order By CreatedDate desc";
        strSQL = "select EmId, EmailAddress,EmPassword,CreatedDate,Convert(bit,Status) as Status, ApprovedDate,UserID, " +
                " Case When Status = 0 Then 'Pending' Else 'Approved' END as StatusTEXT from tblUserEmails  " +
                " order by CreatedDate, UserID";

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


                gridEmailList.DataSource = dv;
                gridEmailList.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridEmailList.DataSource = ds;
                gridEmailList.DataBind();

                int ColCount = gridEmailList.Rows[0].Cells.Count;
                gridEmailList.Rows[0].Cells.Clear();
                gridEmailList.Rows[0].Cells.Add(new TableCell());
                gridEmailList.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridEmailList.Rows[0].Cells[0].Text = "No records Found";
                gridEmailList.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




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


    protected void gridEmailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEmailList.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridEmailList.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridEmailList.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridEmailList.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridEmailList_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void gridEmailList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridEmailList.EditIndex = e.NewEditIndex;



        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void gridEmailList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridEmailList.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridEmailList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int rowCount;
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridEmailList.Rows[e.RowIndex];

    //    //Get the reference to the TextFields in the grid view row
    //    TextBox tbFaqQuestion = (TextBox)gRow.FindControl("txtFaqQuestion");
    //    TextBox tbFaqAnswer = (TextBox)gRow.FindControl("txtFaqAnswer");
    //    Literal ltrFaqID = (Literal)gRow.FindControl("hdFaqID");
    //    HiddenField objHidUserType = (HiddenField)gRow.FindControl("hidUsertype");

        Literal ltrEmID = (Literal)gRow.FindControl("hdEMID");
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");


        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();


        strSQL = "Update tblUserEmails Set Status = " + Convert.ToInt16(chkActive.Checked) + " where UserId =" + objHidUserID.Value + " and EmID =" + ltrEmID.Text;
        dbCmd = new SqlCommand(strSQL, dbConn);
        rowCount = dbCmd.ExecuteNonQuery();

        bool upStatus;
        if (rowCount >= 1)
            upStatus = true;
        else
            upStatus = false;

    //    string tmpFaqAnswer = tbFaqAnswer.Text;
    //    tmpFaqAnswer = tmpFaqAnswer.ToString().Replace(Environment.NewLine, "<br/>");

    //    bool upStatus;
    //    if (Convert.ToInt16(objHidUserType.Value) == 2)
    //    {
    //        ////..if exists update else insert 
    //        //SqlConnection dbconn = new SqlConnection(GlobalVar.GetDbConnString.ToString());
    //        //dbconn.Open();

    //        //string strSQL = "Insert tblShowAdminItems (ItemTable, ItemIds, ForUserID) values ('tblFAQ'," + Convert.ToInt32(ltrFaqID.Text) + "," + Convert.ToInt32(Session["UserID"]) + ")";

    //        //SqlCommand dbCmd = new SqlCommand(strSQL,dbconn);
    //        //dbCmd.ExecuteNonQuery();
    //        //dbconn.Close();

    //        CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
    //        upStatus = objBAL_CommonFunc.InsertUpdate_ShowAdminItems("tblFAQ",ltrFaqID.Text, Convert.ToInt32(Session["UserID"]));
                        
    //    }
    //    else
    //    {
    //        upStatus = objBAL_Faq.UpdateFaqData(tbFaqQuestion.Text, tmpFaqAnswer, Convert.ToInt32(objHidUserID.Value), Convert.ToInt32(ltrFaqID.Text), chkActive.Checked,1);
    //    }


        if (upStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Status Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the status. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        gridEmailList.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

}

    

    protected void gridEmailList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowcount = 0;
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridEmailList.Rows[e.RowIndex];

        //Getting EnquiryID reference
        Literal ltrenqID = (Literal)gvRow.FindControl("hdenqID");

        int EnqIdToDelte = Convert.ToInt32(ltrenqID.Text);

       // bool delStatus = objBAL_Faq.DeleteFaqData(Convert.ToInt32(Session["UserID"]), FaqIdToDelte);
        strSQL = "Update tblEnquiry set Deleted = 1 where enqId = " + EnqIdToDelte + " and UserID = " + Convert.ToInt32(Session["UserID"]);
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);

            rowcount = dbCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }


        if (rowcount >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

        }
        else
        {
            lblErrMessage.Text = "Could not delete the item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }


        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void gridEmailList_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(gridEmailList.BottomPagerRow, gridEmailList);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridEmailList.BottomPagerRow, gridEmailList);

    }

    protected void gridEmailList_RowDataBound(object sender, GridViewRowEventArgs e)
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
            //if (gridEmailList.Rows.Count > 0)
            //{

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");



            ////..Getting reference to the lblModifiedBy control 
            //Label objModByLabel = (Label)e.Row.FindControl("lblModifiedBy");
            //string strModifiedBy = objModByLabel.Text;


            //DataRowView drv = ((DataRowView)e.Row.DataItem);

            //TextBox objfaqAnswer = (TextBox)e.Row.FindControl("txtFaqAnswer");
            //if (objfaqAnswer != null)
            //{
            //    string tmpstr = drv["FaqAnswer"].ToString().Replace("<br/>", Environment.NewLine);
            //    objfaqAnswer.Text = tmpstr;
            //}

           

            //.. getting reference the gridview row in row databound event. 
            string strLoginName = string.Empty;
            DataRowView rowView = (DataRowView)e.Row.DataItem;

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
}
