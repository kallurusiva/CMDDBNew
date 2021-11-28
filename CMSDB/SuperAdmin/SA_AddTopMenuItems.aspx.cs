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


public partial class SuperAdmin_SA_AddTopMenuItems : System.Web.UI.Page  
{

    
    CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();
    DataSet ds;
    DataTable dtTopMenu;

    SqlConnection dbConn;
    SqlCommand dbCmd;


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
            LoadTopMenuGrid();
        }
    }


    protected void LoadTopMenuGrid()
    {

        

        
       ds = objBAL_HomePg.RetrieveAll_TopMenuLinks(Convert.ToInt32(Session["saUserID"]));
       // ds = objBAL_HomePg.RetrieveAll_TopMenuLinks(104);

        dtTopMenu = ds.Tables[0];              //tbltopMenuLinks
                
        GridTopMenu.DataSource = dtTopMenu;
        GridTopMenu.DataBind();


    }

    protected void GridTopMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridTopMenu.EditIndex = -1;
        LoadTopMenuGrid();
    }

    protected void GridTopMenu_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridTopMenu.EditIndex = e.NewEditIndex;
        LoadTopMenuGrid();

    }

    
    protected void AddNewMenuItem_Click(object sender, EventArgs e)
    {
        TextBox objNewLinkName = (TextBox)GridTopMenu.FooterRow.FindControl("txt_NewLinkName");
        TextBox objNewLinkURL = (TextBox)GridTopMenu.FooterRow.FindControl("txt_NewLinkURL");
        CheckBox objNewActive = (CheckBox)GridTopMenu.FooterRow.FindControl("chk_newActive");

        int inStatus = objBAL_HomePg.Insert_TopMenuLinkItem(objNewLinkName.Text, objNewLinkURL.Text, objNewActive.Checked);

        LoadTopMenuGrid();

    }

    protected void GridTopMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridTopMenu.Rows[e.RowIndex];

        TextBox objtxtLinkName = (TextBox)gvRow.FindControl("txtLinkName");
        TextBox objtxtLinkURL = (TextBox)gvRow.FindControl("txtLinkURL");
        CheckBox objNewActive = (CheckBox)gvRow.FindControl("chkActive");
       // HiddenField hdLinkID = (HiddenField)gvRow.FindControl("hdLinkID");
        Literal objLtrLinkId = (Literal)gvRow.FindControl("ltrLinkID");

        bool upStatus;

        string strSQL = "Update tblTopMenuLinks SET LinkName = '" + objtxtLinkName.Text + "' , LinkURL = '" + objtxtLinkURL.Text + "' , Active = " + Convert.ToInt16(objNewActive.Checked) + " where LinkID = " + Convert.ToInt32(objLtrLinkId.Text);

        try
        {
            dbConn = new SqlConnection(GlobalVar.GetDbConnString);
            dbConn.Open();

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.ExecuteNonQuery();

            upStatus = true;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }


        if (upStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Menu Item Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the Menu Item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        GridTopMenu.EditIndex = -1;
        LoadTopMenuGrid();





    }

    protected void GridTopMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

         //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)GridTopMenu.Rows[e.RowIndex];


        //HiddenField hdLinkID = (HiddenField)gvRow.FindControl("hdLinkID");
        Literal objLtrLinkId = (Literal)gvRow.FindControl("ltrLinkID");
        

       bool delStatus= false;

       string strSQL = "Update tblTopMenuLinks set Deleted = 1 where LinkID = " + Convert.ToInt32(objLtrLinkId.Text);
       
        
        try
          {
                 dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                 dbConn.Open();

              dbCmd = new SqlCommand(strSQL, dbConn);
              dbCmd.ExecuteNonQuery();

             delStatus = true;


          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally
          {
              dbConn.Close();
          }


     

       if (delStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Menu Item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the Menu Item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

       LoadTopMenuGrid();

    }


    protected void GridTopMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

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

                
                LoadTopMenuGrid();
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

                LoadTopMenuGrid();
                //gridFaq.DataBind();
            }

        }

    }
}
