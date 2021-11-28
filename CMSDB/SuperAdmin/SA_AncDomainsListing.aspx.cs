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

public partial class SuperAdmin_SA_AncDomainsListing : System.Web.UI.Page 
{

    DataSet ds;
    DataView dv;

    DataSet dsCat;
    DataView dvCat; 

    //CMSv3.BAL.Faq objBAL_Domains = new CMSv3.BAL.Faq();
    //CMSv3.BAL.FAQ objBAL_Domains = new CMSv3.BAL.FAQ();
    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();
    CMSv3.BAL.IFMDomains objBAL_ifmDomains = new CMSv3.BAL.IFMDomains(); 

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
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "CreatedDate";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

            
        }
        else
        {
           
        }
        tblMessageBar.Visible = false;


    }



    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {


        dsCat = objBAL_Domains.Retrieve_AncDomainCategories("");
        dvCat = dsCat.Tables[0].DefaultView; 

        ds = objBAL_Domains.Retrieve_AnchorDomains("SA"); 



        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            GridAncDomains.DataSource = dv;
            GridAncDomains.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            GridAncDomains.DataSource = ds;
            GridAncDomains.DataBind();

            int ColCount = GridAncDomains.Rows[0].Cells.Count;
            GridAncDomains.Rows[0].Cells.Clear();
            GridAncDomains.Rows[0].Cells.Add(new TableCell());
            GridAncDomains.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridAncDomains.Rows[0].Cells[0].Text = "No records Found";
            GridAncDomains.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void GridAncDomains_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridAncDomains.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (GridAncDomains.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < GridAncDomains.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    GridAncDomains.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void GridAncDomains_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void GridAncDomains_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridAncDomains.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void GridAncDomains_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridAncDomains.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void GridAncDomains_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)GridAncDomains.Rows[e.RowIndex];

        //Get the reference to the TextFields in the grid view row
        TextBox tbAnchorDomain = (TextBox)gRow.FindControl("txtAnchorDomain");
        TextBox tbSampleURL = (TextBox)gRow.FindControl("txtSampleURL");
        Literal ltrAnchorID = (Literal)gRow.FindControl("hdTID");
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");
        DropDownList objDDLcat = (DropDownList)gRow.FindControl("ddlAncCategory");

        int SelCatId = Convert.ToInt32(objDDLcat.SelectedValue);
        int vAnchorID = Convert.ToInt32(ltrAnchorID.Text); 
       //int vActive = Convert.ToInt32(chkActive.Text); 
        String vAnchorDomain = tbAnchorDomain.Text.Trim();
        string vSampleURL = tbSampleURL.Text.Trim();

        int upStatus = objBAL_Domains.Update_AnchorDomains(vAnchorID, vAnchorDomain, SelCatId, vSampleURL, chkActive.Checked); 


        if (upStatus == 1)
        {

            //.. storing data into the IFM database.. 
            int ifm_upStatus = objBAL_ifmDomains.Update_AnchorDomains(vAnchorID, vAnchorDomain, SelCatId, vSampleURL, chkActive.Checked); 

            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Anchor Domain Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
         else if (upStatus == 2)
        {
            lblErrMessage.Text = "Duplicate AnchorDomain Name entered. Please enter again.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        else
        {
            lblErrMessage.Text = "Could not Update the Faq. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        GridAncDomains.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void GridAncDomains_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridAncDomains.Rows[e.RowIndex];

        //Getting FaqID reference
        Literal ltrAnchorID = (Literal)gvRow.FindControl("hdtid");

        //int FaqIdToDelte = Convert.ToInt32(ltrAnchorID.Text);

        int delStatus = objBAL_Domains.Delete_AnchorDomains(Convert.ToInt32(ltrAnchorID.Text));


        if (delStatus == 1)
        {
            //.. storing data into the IFM database.. 
            int ifm_delStatus = objBAL_ifmDomains.Delete_AnchorDomains(Convert.ToInt32(ltrAnchorID.Text));


            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Anchor Domain Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the AnchorDomain. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }


        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void GridAncDomains_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(GridAncDomains.BottomPagerRow, GridAncDomains);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(GridAncDomains.BottomPagerRow, GridAncDomains);

    }


    protected void GridAncDomains_RowDataBound(object sender, GridViewRowEventArgs e)
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
            //if (GridAncDomains.Rows.Count > 0)
            //{

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");

            


                //.. getting reference the gridview row in row databound event. 
                string strLoginName = string.Empty;
                DataRowView rowView = (DataRowView)e.Row.DataItem;

                //need to find out if the logged users is not a superadmin disable the last cell 

                //============
                String SelCatvalue = string.Empty; 
                HiddenField objHdCategory = (HiddenField)e.Row.FindControl("hdDDlCategoryID");
                if (objHdCategory != null)
                {
                    SelCatvalue = objHdCategory.Value;
                }

                DropDownList objDDLcat = (DropDownList)e.Row.FindControl("ddlAncCategory");
                if (objDDLcat != null)
                {
                    
                    objDDLcat.DataSource = dvCat;
                    objDDLcat.DataTextField = "CategoryName";
                    objDDLcat.DataValueField = "CategoryID";
                    objDDLcat.DataBind();
                    objDDLcat.SelectedValue = SelCatvalue; 

                }

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


    //protected void btnPrt_UP_Click(object sender, EventArgs e)
    //{

    //    //Button objBtn_UP = (Button)sender;
    //    ImageButton objBtn_UP = (ImageButton)sender;

    //    GridViewRow thisRow = (GridViewRow)objBtn_UP.Parent.Parent;

    //    Literal objLtr_CurrPriority = (Literal)thisRow.FindControl("LtrPriority");
    //    Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdFaqID");

    //    string CurrPriority = objLtr_CurrPriority.Text;
    //    string CurrFaqID = objLtr_CurrFaqID.Text;

    //    GridView thisGrid = (GridView)thisRow.Parent.Parent;
    //    int MaxRows = thisGrid.Rows.Count;
    //    int CurrRowIndex = thisRow.RowIndex;
    //    int PrevRowIndex = CurrRowIndex - 1;

    //    if (PrevRowIndex >= 0)
    //    {

    //        GridViewRow previousRow = thisGrid.Rows[PrevRowIndex];
    //        Literal objLtr_PrevPriority = (Literal)previousRow.FindControl("LtrPriority");
    //        Literal objLtr_PrevFaqID = (Literal)previousRow.FindControl("hdFaqID");
    //        string PrevPriority = objLtr_PrevPriority.Text;
    //        string PrevFaqID = objLtr_PrevFaqID.Text;


    //        if (objLtr_CurrPriority != null)
    //        {

    //            CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
                
    //            int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblfaq", "faqid", "IX_Users_Priority", CurrPriority, CurrFaqID, PrevPriority, PrevFaqID, Session["saUserID"].ToString());

    //            #region Commented code 

               
    //            //   update data base tables. 

    //             //SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
    //             //dbConn.Open();

    //             //String strSQL = "ALTER INDEX IX_Users_Priority ON tblFAQ DISABLE; Update tblFaq set Priority =" + PrevPriority + " where faqid=" + CurrFaqID + " and UserID = " + Convert.ToInt32(Session["saUserID"]);
    //             //SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
    //             //dbCmd.ExecuteNonQuery();


    //             //strSQL = "Update tblFaq set Priority =" + CurrPriority + " where faqid=" + PrevFaqID + " and UserID = " + Convert.ToInt32(Session["saUserID"]) + "; ALTER INDEX IX_Users_Priority ON tblFAQ REBUILD";
    //             //dbCmd = new SqlCommand(strSQL, dbConn);
    //             //dbCmd.ExecuteNonQuery();

    //                //dbConn.Close();

    //            #endregion

    //            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    //         //GridAncDomains.DataBind();
    //        }

    //    }

    //}


    //protected void btnPrt_DOWN_Click(object sender, EventArgs e)
    //{

    //    //Button objBtn_DOWN = (Button)sender;
    //    ImageButton objBtn_DOWN = (ImageButton)sender;
        
    //    GridViewRow thisRow = (GridViewRow)objBtn_DOWN.Parent.Parent;

    //    Literal objLtr_CurrPriority = (Literal)thisRow.FindControl("LtrPriority");
    //    Literal objLtr_CurrFaqID = (Literal)thisRow.FindControl("hdFaqID");

    //    string CurrPriority = objLtr_CurrPriority.Text;
    //    string CurrFaqID = objLtr_CurrFaqID.Text;

    //    GridView thisGrid = (GridView)thisRow.Parent.Parent;
    //    int MaxRows = thisGrid.Rows.Count;
    //    int CurrRowIndex = thisRow.RowIndex;
    //    int NextRowIndex = CurrRowIndex + 1;

    //    if (NextRowIndex < MaxRows)
    //    {

    //        GridViewRow NextRow = thisGrid.Rows[NextRowIndex];
    //        Literal objLtr_NextPriority = (Literal)NextRow.FindControl("LtrPriority");
    //        Literal objLtr_NextFaqID = (Literal)NextRow.FindControl("hdFaqID");
    //        string NextPriority = objLtr_NextPriority.Text;
    //        string NextFaqID = objLtr_NextFaqID.Text;


    //        if (objLtr_CurrPriority != null)
    //        {

    //            CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

    //            int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblfaq", "faqid", "IX_Users_Priority", CurrPriority, CurrFaqID, NextPriority, NextFaqID, Session["saUserID"].ToString());

    //            #region Commented code


    //            //   update data base tables. 

    //            //SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
    //            //dbConn.Open();

    //            //String strSQL = "ALTER INDEX IX_Users_Priority ON tblFAQ DISABLE; Update tblFaq set Priority =" + PrevPriority + " where faqid=" + CurrFaqID + " and UserID = " + Convert.ToInt32(Session["saUserID"]);
    //            //SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
    //            //dbCmd.ExecuteNonQuery();


    //            //strSQL = "Update tblFaq set Priority =" + CurrPriority + " where faqid=" + PrevFaqID + " and UserID = " + Convert.ToInt32(Session["saUserID"]) + "; ALTER INDEX IX_Users_Priority ON tblFAQ REBUILD";
    //            //dbCmd = new SqlCommand(strSQL, dbConn);
    //            //dbCmd.ExecuteNonQuery();

    //            //dbConn.Close();

    //            #endregion

    //            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    //            //GridAncDomains.DataBind();
    //        }

    //    }

    //}

    //protected void btnDeleteAll_Click(object sender, EventArgs e)
    //{
    //    string strFaqIDs = string.Empty;
    //    //Loop thru all the Rows
    //    foreach (GridViewRow gvRow in GridAncDomains.Rows)
    //    {
    //        CheckBox objCb = (CheckBox)gvRow.FindControl("chkSelect");
    //        if (objCb.Checked)
    //        {
    //            //Retrieve the FaqID to Delete
    //            if (strFaqIDs == string.Empty)
    //                strFaqIDs = Convert.ToString(GridAncDomains.DataKeys[gvRow.RowIndex].Value);
    //            else
    //                strFaqIDs = strFaqIDs + "," + Convert.ToString(GridAncDomains.DataKeys[gvRow.RowIndex].Value);
    //        }

    //    }

    //    if (strFaqIDs != string.Empty)
    //    {
            
    //        bool DelMulstatus = objBAL_Domains.DeleteFaqData_Multiple(Convert.ToInt32(Session["saUserID"]), strFaqIDs);



    //        if (DelMulstatus)
    //        {
    //            tblMessageBar.Visible = true;
    //            lblErrMessage.Text = "Faq item Deleted Sucessfully";
    //            lblErrMessage.CssClass = "font_12Msg_Success";
    //            MessageImage.Src = "~/Images/inf_Sucess.gif";

    //        }
    //        else
    //        {
    //            lblErrMessage.Text = "Could not deleted the Faq item. Technical Error";
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
