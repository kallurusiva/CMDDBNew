using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CMSv3.BAL;
using System.Data.SqlClient;


public partial class SuperAdmin_SA_AncDomainsCategories : System.Web.UI.Page  
{


    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();
    CMSv3.BAL.IFMDomains objBAL_ifmDomains = new CMSv3.BAL.IFMDomains(); 

    DataSet ds;
    DataTable dtTopMenu;

    //SqlConnection dbConn;
    //SqlCommand dbCmd;

    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"] == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 


        ViewState["sortOrder"] = "asc";
        ViewState["SortExpr"] = "UserID desc,LgType, Priority";


        if (!IsPostBack)
        {
            PopulateAncDomainGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }
    }


    protected void PopulateAncDomainGrid(string vSortExpr, string vSortDir)
    {




        ds = objBAL_Domains.Retrieve_AncDomainCategories(""); 
       // ds = objBAL_HomePg.RetrieveAll_TopMenuLinks(104);

        dtTopMenu = ds.Tables[0];              //tbltopMenuLinks
                
        GridAncDomains.DataSource = dtTopMenu;
        GridAncDomains.DataBind();


    }

    protected void GridAncDomains_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridAncDomains.EditIndex = -1;
        PopulateAncDomainGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void GridAncDomains_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridAncDomains.EditIndex = e.NewEditIndex;
        PopulateAncDomainGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    
    protected void AddNewCategory_Click(object sender, EventArgs e)
    {
        TextBox objNewCatName = (TextBox)GridAncDomains.FooterRow.FindControl("txt_NewAncCatName");

        int inStatus = objBAL_Domains.Insert_AncDomainCategory(objNewCatName.Text.Trim());

        if (inStatus == 1)
        {

            //..storing into IFM database. ..
            int ifm_inStatus = objBAL_ifmDomains.Insert_AncDomainCategory(objNewCatName.Text.Trim());

            tblMessageBar.Visible = true;
            lblErrMessage.Text = "New Anchor Domain Category Added Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else if (inStatus == 2)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Entered category already exists. Please enter another category name.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            MessageImage.Src = "~/Images/inf_Error.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the Category Name. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        PopulateAncDomainGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void GridAncDomains_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridAncDomains.Rows[e.RowIndex];

        TextBox objTxtCategoryName = (TextBox)gvRow.FindControl("txtCategoryName");
        Literal objLtrCatID = (Literal)gvRow.FindControl("ltrCatID"); 


        int upStatus;

        upStatus = objBAL_Domains.Update_AncDomainCategory(objTxtCategoryName.Text.Trim(), Convert.ToInt32(objLtrCatID.Text)); 

        if (upStatus == 1)
        {
            //..Storing into the IFM database...
            int ifm_upStatus = objBAL_ifmDomains.Update_AncDomainCategory(objTxtCategoryName.Text.Trim(), Convert.ToInt32(objLtrCatID.Text));


            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Category Name Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else if (upStatus == 2)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Duplicate Category name entered. Please enter another category name.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            MessageImage.Src = "~/Images/inf_Error.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the Category Name. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        GridAncDomains.EditIndex = -1;
        PopulateAncDomainGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());





    }

    protected void GridAncDomains_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

         //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridAncDomains.Rows[e.RowIndex];


        //HiddenField hdLinkID = (HiddenField)gvRow.FindControl("hdLinkID");
        Literal objLtrCatID = (Literal)gvRow.FindControl("ltrCatID");
        

       int delStatus=0;

       //string strSQL = "Update tblTopMenuLinks set Deleted = 1 where LinkID = " + Convert.ToInt32(objLtrCatID.Text);
       delStatus = objBAL_Domains.Delete_AncDomainCategory(Convert.ToInt32(objLtrCatID.Text));

       if (delStatus == 1)
        {
            //..Storing into the IFM database...
            int ifm_delStatus = objBAL_ifmDomains.Delete_AncDomainCategory(Convert.ToInt32(objLtrCatID.Text));


            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Category Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the Category Item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

       PopulateAncDomainGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }


    protected void GridAncDomains_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //if ((e.Row.RowState == DataControlRowState.Alternate) && (e.Row.RowState == DataControlRowState.Edit))
            //{
            //}
            //else if ((e.Row.RowState == DataControlRowState.Normal) && (e.Row.RowState == DataControlRowState.Edit))
            //{

            //}
            //   //If ((e.Row.RowState And (DataControlRowState.Edit Or DataControlRowState.Alternate)) = (DataControlRowState.Edit Or DataControlRowState.Alternate)) Then
            //else if((e.Row.RowState && (DataControlRowState.Edit || DataControlRowState.Alternate)) =  (DataControlRowState.Edit Or DataControlRowState.Alternate))
            //{
                #region  Enabling or disabling Delete button based on AnchorDomain Associations.

                Label objLtrAncDomainCount = (Label)e.Row.FindControl("lblCntAncDomains");

                if (objLtrAncDomainCount != null)
                {
                    int DmCount = Convert.ToInt32(objLtrAncDomainCount.Text);
                    Image objImgDelete = (Image)e.Row.FindControl("ImgDelete");
                    ImageButton objImgBtnDelete = (ImageButton)e.Row.FindControl("ImgDelete");

                    if (objImgBtnDelete != null)
                    {
                        if (DmCount > 0)
                        {
                            objImgBtnDelete.Enabled = false;
                            objImgBtnDelete.ImageUrl = "~/Images/imgDelete_disabled.gif";
                            objImgBtnDelete.ToolTip = "Cannot Delete as the Category is associated to AnchorDomain(s)";
                        }
                        else
                        {
                            objImgBtnDelete.Enabled = true;
                        }
                    }


                    //if (DmCount > 0)
                    //    objImgDelete.Visible = false;
                    //else
                    //    objImgDelete.Visible = true;

                }


                #endregion
           // }

            #region Showing Checkbox ticked image


            //need to find out if the logged users is not a superadmin disable the last cell 

            //============

            //Literal objLtrActive = (Literal)e.Row.FindControl("LtrActive");
            //Image objImgActive = (Image)e.Row.FindControl("ImgActive");

            ////String LtrShowActive = rowView["LtrActive"].ToString();

            //if (objImgActive != null)
            //{

            //    if (objLtrActive.Text != "")
            //    {
            //        if (Convert.ToBoolean(objLtrActive.Text))
            //        {

            //            //objImgActive.ImageUrl = @"~\Images\Active_Show.jpg";
            //            objImgActive.ImageUrl = @"~\Images\checkbox_ticked.jpg";

            //        }
            //        else
            //        {
            //            //objImgActive.ImageUrl = @"~\Images\Active_Hide.jpg";
            //            objImgActive.ImageUrl = @"~\Images\checkbox_empty.jpg";
            //        }
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
        Literal objLtr_CurrLinkId = (Literal)thisRow.FindControl("ltrLinkID");

        string CurrPriority = objLtr_CurrPriority.Text;
        string CurrLinkId = objLtr_CurrLinkId.Text;

        GridView thisGrid = (GridView)thisRow.Parent.Parent;
        int MaxRows = thisGrid.Rows.Count;
        int CurrRowIndex = thisRow.RowIndex;
        int PrevRowIndex = CurrRowIndex - 1;

        if (PrevRowIndex >= 0)
        {

            GridViewRow previousRow = thisGrid.Rows[PrevRowIndex];
            Literal objLtr_PrevPriority = (Literal)previousRow.FindControl("LtrPriority");
            Literal objLtr_PrevLinkId = (Literal)previousRow.FindControl("ltrLinkID");
            string PrevPriority = objLtr_PrevPriority.Text;
            string PrevLinkId = objLtr_PrevLinkId.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblTopMenuLinks", "LinkId", "IX_TopMenu_Priority", CurrPriority, CurrLinkId, PrevPriority, PrevLinkId, Session["saUserID"].ToString());

                
                PopulateAncDomainGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
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
        Literal objLtr_CurrLinkId = (Literal)thisRow.FindControl("ltrLinkID");

        string CurrPriority = objLtr_CurrPriority.Text;
        string CurrLinkId = objLtr_CurrLinkId.Text;

        GridView thisGrid = (GridView)thisRow.Parent.Parent;
        int MaxRows = thisGrid.Rows.Count;
        int CurrRowIndex = thisRow.RowIndex;
        int NextRowIndex = CurrRowIndex + 1;

        if (NextRowIndex < MaxRows)
        {

            GridViewRow NextRow = thisGrid.Rows[NextRowIndex];
            Literal objLtr_NextPriority = (Literal)NextRow.FindControl("LtrPriority");
            Literal objLtr_NextLinkId = (Literal)NextRow.FindControl("ltrLinkID");
            string NextPriority = objLtr_NextPriority.Text;
            string NextLinkId = objLtr_NextLinkId.Text;


            if (objLtr_CurrPriority != null)
            {

                CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

                int upStatus = objBAL_CommonFunc.ChangePriorityOrder("tblTopMenuLinks", "LinkId", "IX_TopMenu_Priority", CurrPriority, CurrLinkId, NextPriority, NextLinkId, Session["saUserID"].ToString());

                PopulateAncDomainGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                //gridFaq.DataBind();
            }

        }

    }
}
