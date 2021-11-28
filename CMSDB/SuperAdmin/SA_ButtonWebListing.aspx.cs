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

public partial class SA_ButtonWebListing : System.Web.UI.Page 
{

    DataSet ds;
    DataView dv;

    //DataSet dsCat;
    //DataView dvCat; 

    //CMSv3.BAL.Faq objBAL_Domains = new CMSv3.BAL.Faq();
    //CMSv3.BAL.FAQ objBAL_Domains = new CMSv3.BAL.FAQ();
    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();

    CMSv3.BAL.OwnButton objBAL_Buttons = new CMSv3.BAL.OwnButton();

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
            ViewState["SortExpr"] = "AnchorDomainID";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

            
        }
        else
        {
           
        }
        tblMessageBar.Visible = false;


    }



    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        ds = objBAL_Buttons.Retrieve_DefWebButtonsBYSA("",1); 

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            GridDefButtons.DataSource = dv;
            GridDefButtons.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            GridDefButtons.DataSource = ds;
            GridDefButtons.DataBind();

            int ColCount = GridDefButtons.Rows[0].Cells.Count;
            GridDefButtons.Rows[0].Cells.Clear();
            GridDefButtons.Rows[0].Cells.Add(new TableCell());
            GridDefButtons.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridDefButtons.Rows[0].Cells[0].Text = "No records Found";
            GridDefButtons.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void GridDefButtons_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridDefButtons.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (GridDefButtons.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < GridDefButtons.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    GridDefButtons.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void GridDefButtons_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void GridDefButtons_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //GridDefButtons.EditIndex = e.NewEditIndex;
        //PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        
    }

    protected void GridDefButtons_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridDefButtons.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void GridDefButtons_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridDefButtons.Rows[e.RowIndex];

        //Getting FaqID reference
        Literal ltrButtonUID = (Literal)gvRow.FindControl("hdUID");

        //int FaqIdToDelte = Convert.ToInt32(ltrAnchorID.Text);

        //int delStatus = objBAL_Domains.Delete_AnchorDomains(Convert.ToInt32(ltrButtonUID.Text));
        int delStatus = objBAL_Buttons.Delete_DefWebButtonsBYSA(Convert.ToInt32(ltrButtonUID.Text)); 


        if (delStatus == 1)
        {
          
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Default Button for Anchor Domain Deleted Sucessfully";
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



    protected void GridDefButtons_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(GridDefButtons.BottomPagerRow, GridDefButtons);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(GridDefButtons.BottomPagerRow, GridDefButtons);

    }


    protected void GridDefButtons_RowDataBound(object sender, GridViewRowEventArgs e)
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
            //if (GridDefButtons.Rows.Count > 0)
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
                    
                    //objDDLcat.DataSource = dvCat;
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





    protected void GridDefButtons_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EDIT")
        {
 
            GridViewRow Grow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            //GridViewRow Grow = GridDefButtons.Rows[index];

            // Get value of the DataKey
          //  string dk = this.GridDefButtons.DataKeys[index].Value.ToString();

            
                HiddenField objHid_ButtonNo = (HiddenField)Grow.FindControl("hdButtonNo");
                HiddenField objHid_AnchorDomainID = (HiddenField)Grow.FindControl("hdAnchorDomainID");

                Response.Redirect(@"SA_ButtonWebAdd.aspx?btID=" + objHid_ButtonNo.Value + "&Aid=" + objHid_AnchorDomainID.Value);
            }
        

    }
}
