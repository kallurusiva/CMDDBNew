using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SuperAdmin_SA_INFOListing : System.Web.UI.Page 
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;
    //int qLgType = 0; 

    CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();
    CMSv3.Entities.Products objProducts = new CMSv3.Entities.Products();


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        tblMessageBar.Visible = false;

        

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "DateCreated";
            

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }
        
  
    }


    
    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        //ds = objBAl_Event.Retrieve_AllEventByUserID(101);
        //ds = objBAL_Testimonial.RetrieveAllProducts_ByUserID(Convert.ToInt32(Session["saUserID"]), ViewState["RtType"].ToString());
       // ds = objBAL_Products.RetrieveAllProducts_ByUserID(Convert.ToInt32(Session["saUserID"]), ViewState["RtType"].ToString(), qLgType, Convert.ToInt16(GlobalVar.ProductTypes.Product));

        ds = objBAL_Products.INFO_RetrieveAll(Convert.ToInt32(Session["saUserID"]),"ALL");


        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            gridINFO.DataSource = dv;
            gridINFO.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridINFO.DataSource = ds;
            gridINFO.DataBind();

            int ColCount = gridINFO.Rows[0].Cells.Count;
            gridINFO.Rows[0].Cells.Clear();
            gridINFO.Rows[0].Cells.Add(new TableCell());
            gridINFO.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridINFO.Rows[0].Cells[0].Text = "No records Found";
            gridINFO.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;

        }






    }


    protected void gridINFO_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridINFO.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridINFO.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridINFO.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridINFO.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridINFO_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridINFO.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridINFO_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridINFO.Rows[e.RowIndex];

        //Getting eventID reference
        Literal ltrINFOID = (Literal)gvRow.FindControl("hdINFOId");

        int INFOIdToDelete = Convert.ToInt32(ltrINFOID.Text);

        int delStatus = objBAL_Products.INFO_Delete(Convert.ToInt32(Session["saUserID"]), INFOIdToDelete);


        
        if (delStatus > 0)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "INFO item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the INFO item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

    }


    protected void gridINFO_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //gridINFO.EditIndex = e.NewEditIndex;
        //PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //GridViewRow gRow = (GridViewRow)gridINFO.Rows[e.NewEditIndex];
        //Literal tblProductID = (Literal)gRow.FindControl("hdProductId");
        gridINFO.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //Server.Transfer("ProductViewEdit.aspx?ProductID=" + tblProductID.Text);
    }


    //protected void gridINFO_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void gridINFO_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridINFO.BottomPagerRow, gridINFO);
    }


    protected void gridINFO_RowDataBound(object sender, GridViewRowEventArgs e)
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



            //ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");


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



            //..Forming the Hyperlink to Navigate for Update Functionality
            Literal ltrhdINFOId = (Literal)e.Row.FindControl("hdINFOId");
            HyperLink HyLinkEdit = (HyperLink)e.Row.FindControl("HyLinkEdit");

            HyLinkEdit.NavigateUrl = "SA_INFOEdit.aspx?qInfoID=" + ltrhdINFOId.Text;
            HyLinkEdit.Visible = true;

        }
        


    }


  

 }
