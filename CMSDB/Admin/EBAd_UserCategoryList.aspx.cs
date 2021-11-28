using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_UserCategoryList : System.Web.UI.Page
{

    DataSet ds;
    DataView dv;


    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 

    protected void Page_Load(object sender, EventArgs e)
    {


        #region session check

        if (Session["UserID"] == null) 
        {
            if(Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 



        if (!IsPostBack)
        {

            //if (Session["LoggedInFrom"] != null)
            //    lblPgFrom.Text = Session["LoggedInFrom"].ToString(); 
            

            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "";
            ViewState["SearchStr"] = "";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchStr"].ToString());
            RenderMainCategories(); 
          //  BtnSave.Enabled = false; 
        }


    }



    protected void PopulateGrid(string vSortExpr, string vSortDir, String vSearchStr)
    {

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        ds =  objBALebook.Category_WP_Listing(vUserID, vSearchStr);

        //ds = objBALebook.EBook_Get_MainCategories(vUserID, "");
       
        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {

                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            GridCategory.DataSource = dv;
            GridCategory.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            GridCategory.DataSource = ds;
            GridCategory.DataBind();

            int ColCount = GridCategory.Rows[0].Cells.Count;
            GridCategory.Rows[0].Cells.Clear();
            GridCategory.Rows[0].Cells.Add(new TableCell());
            GridCategory.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridCategory.Rows[0].Cells[0].Text = "No records Found";
            GridCategory.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void RenderMainCategories()
    {

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        //DataSet ds = objBALebook.CatMain_Categories(vUserID, "");
        DataSet ds = objBALebook.EBook_Get_MainCategories(vUserID, "00");


        ddlMainCategory.DataSource = ds;
        ddlMainCategory.DataTextField = "ddlCatName";
        ddlMainCategory.DataValueField = "CatMainID";
        ddlMainCategory.DataBind();

        // ddlMainCategory.Items.Insert(0, new ListItem("Select Category", "0"));

    }


    protected void GridCategory_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(m_SortExpr, sortOrder, ViewState["SearchStr"].ToString());
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


    protected void GridCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridCategory.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchStr"].ToString());

    }

    protected void GridCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridCategory.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchStr"].ToString());
    }

    protected void GridCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)GridCategory.Rows[e.RowIndex];

        //Get the reference to the TextFields in the grid view row
        //TextBox tbCategoryName = (TextBox)gRow.FindControl("txtCategoryName");


        TextBox txtCategoryName = (TextBox)gRow.FindControl("txtCategoryName");
        Literal ltrCategoryID = (Literal)gRow.FindControl("hdCatID");
        //CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");
        //chkActive.Checked


        int mCatId = Convert.ToInt32(ltrCategoryID.Text);
        int vUserID = Convert.ToInt32(Session["UserID"].ToString()); 
        
        int upStatus = objBALebook.Category_WP_Update(vUserID, mCatId, txtCategoryName.Text,true);
        // int upStatus = objBAL_Domains.Update_AnchorDomains(vAnchorID, vAnchorDomain, SelCatId, vSampleURL, chkActive.Checked); 


        if (upStatus == 1)
        {

            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Ebook category Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else if (upStatus == 2)
        {
            lblErrMessage.Text = "Duplicate Category Name entered. Please enter again.";
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

        GridCategory.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchStr"].ToString());

    }

    protected void GridCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        ////Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridCategory.Rows[e.RowIndex];

        //Getting Category ID  reference
        Literal ltrhdCatID = (Literal)gvRow.FindControl("hdCatID");


        int CatIdToDelete = Convert.ToInt32(ltrhdCatID.Text);

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        int delStatus = objBALebook.Category_WP_Delete(CatIdToDelete, vUserID); 
        //int delStatus = ebDBcode.Category_Delete(CatIdToDelete);



        if (delStatus == 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Category Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

        }
        else
        {
            lblErrMessage.Text = "Could not delete the Category.  Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }


        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchStr"].ToString());
    }



    protected void GridCategory_RowDataBound(object sender, GridViewRowEventArgs e)
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
            //if (GridCategory.Rows.Count > 0)
            //{

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");




            //.. getting reference the gridview row in row databound event. 
            string strLoginName = string.Empty;
            DataRowView rowView = (DataRowView)e.Row.DataItem;

            //need to find out if the logged users is not a superadmin disable the last cell 

            //============
            //String SelCatvalue = string.Empty;
            //HiddenField objHdCategory = (HiddenField)e.Row.FindControl("hdDDlCategoryID");
            //if (objHdCategory != null)
            //{
            //    SelCatvalue = objHdCategory.Value;
            //}

            //DropDownList objDDLcat = (DropDownList)e.Row.FindControl("ddlAncCategory");
            //if (objDDLcat != null)
            //{

            //    objDDLcat.DataSource = dvCat;
            //    objDDLcat.DataTextField = "CategoryName";
            //    objDDLcat.DataValueField = "CategoryID";
            //    objDDLcat.DataBind();
            //    objDDLcat.SelectedValue = SelCatvalue;

            //}


            Literal objLtrBooksCount = (Literal)e.Row.FindControl("LtrBooksCount");

            int vBooksCount = 0;

            if (objLtrBooksCount.Text != "")
            vBooksCount = Convert.ToInt16(objLtrBooksCount.Text);

            if (vBooksCount > 0)
            {
                ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");

                if (objImgDelete != null)
                {
                    objImgDelete.Enabled = false;
                    objImgDelete.ImageUrl = "~/Images/imgDelete_disabled.gif";
                }

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



    protected void txtCategoryName_TextChanged(object sender, EventArgs e)
    {
       
   //     int vResult = CheckCategoryName_Availability(txtCategoryName.Text.Trim());

    }

    protected int CheckCategoryName_Availability(String vCategoryName)
    {

        int Result = 0;
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        int chkStatus = objBALebook.Category_Validate(vUserID,vCategoryName);

        if (chkStatus == 0)
        {
           // lblCatNameStatus.Visible = true;
          //  lblCatNameStatus.Text = "Category  : " + vCategoryName + " is Available!";
           // lblCatNameStatus.CssClass = "ValAlert_Success";
          //  ImageKeywordStatus.Visible = true;
           // ImageKeywordStatus.ImageUrl = "~/Images/round_active.gif";
           // BtnSave.Enabled = true; 

            Result = 1;
        }
        else
        {
            lblCatNameStatus.Visible = true;
            lblCatNameStatus.CssClass = "ValAlert_Error";
            lblCatNameStatus.Text = "BookCode : " + vCategoryName + " is Already Exists.Please Choose Another CategoryName!";
            ImageKeywordStatus.Visible = true;
            ImageKeywordStatus.ImageUrl = "~/Images/round_notactive.gif";
          //  BtnSave.Enabled = false; 
            Result = 2;
        }

        return Result;
    }




    protected void BtnSave_Click(object sender, EventArgs e)
    {

        //Get the form values

        int mCatMainID = Convert.ToInt32(ddlMainCategory.SelectedValue); 
        String mCategoryName = txtCategoryName.Text;
        bool mDisplayAtWebSite = true;
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        int vMerchantID=0; 

        if (Session["MERID"] != null)
            vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
        else
            Response.Redirect("~/SessionExpireEbook.aspx");

       

        int vResult = CheckCategoryName_Availability(txtCategoryName.Text.Trim());

        if (vResult == 1)
        {



            int inStatus = objBALebook.Category_WP_Add(mCatMainID,mCategoryName, mDisplayAtWebSite, vUserID, vMerchantID); 
            //int inStatus = ebDBcode.Category_Add(mCategoryName, mDisplayAtWebSite);

            if (inStatus == 1)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
                lblErrMessage.Text = "Category successfully added";
                lblErrMessage.CssClass = "font_12Msg_Success";

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Category Added Successfully')", true);
                //Response.Redirect("EB_CategoryListing.aspx");
                PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchStr"].ToString());
                return;
            }
            else if(inStatus == 3)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";
                lblErrMessage.Text = "As an Associate Vendor you have exceeded the Max No. of Categories you can create. Please delete an existing category or Upgrade.!! ";
                lblErrMessage.CssClass = "font_12Msg_Error";

                CommonFunctions.AlertMessage("As an Associate Vendor you have exceeded the Max No. of Categories you can create.\\n\\nPlease delete an existing category or Upgrade.!!");
               // String vAlertMsg = "You have exceed the Max No. of Categories you can create.\n\nPlease delete an existing category or Upgrade.!!";
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);


            }
            else
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";
                lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
                lblErrMessage.CssClass = "font_12Msg_Error";
            }
        }
        else if (vResult == 2)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Entered Category Name already Exists. Please Try another. ";
            lblErrMessage.CssClass = "font_12Msg_Error";

        }

      

    }



}