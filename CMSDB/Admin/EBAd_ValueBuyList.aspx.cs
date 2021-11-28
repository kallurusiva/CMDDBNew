using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EBAd_ValueBuyList : System.Web.UI.Page
{

    DataSet ds;
    DataView dv; 
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

    String qUserType = String.Empty; 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"] == null))
        {
            if (Session["UserID"].ToString() != "")
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


        if (Request.QueryString.Count > 0)
        {

            int prvStatus = Convert.ToInt32(Request.QueryString["qStatus"]);

            if (prvStatus == 1)
                CommonFunctions.AlertMessage("New Value-Buy ebook added successfully");

            if (prvStatus == 2)
                CommonFunctions.AlertMessage("Value-Buy Ebook updated successfully");


            if(Request.QueryString["qUserType"] != null)
                qUserType = Request.QueryString["qUserType"].ToString();
                       
        }




        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "DateCreated";


            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }

        tblMessageBar.Visible = false;




    }



    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {


        //ds = ebDBcode.Ebook_Listing(" AND isBestSeller = 1");

        int vUserId = Convert.ToInt32(Session["UserID"].ToString());

        if (qUserType == "ADMIN")
            vUserId = 7484;

        ds = objEbook.Ebook__ADM_ValueBuyListing_ByUserID(vUserId, ""); 

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            gridEbooks.DataSource = dv;
            gridEbooks.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridEbooks.DataSource = ds;
            gridEbooks.DataBind();

            int ColCount = gridEbooks.Rows[0].Cells.Count;
            gridEbooks.Rows[0].Cells.Clear();
            gridEbooks.Rows[0].Cells.Add(new TableCell());
            gridEbooks.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridEbooks.Rows[0].Cells[0].Text = "No records Found";
            gridEbooks.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void gridEbooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEbooks.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridEbooks.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridEbooks.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridEbooks.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridEbooks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridEbooks.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridEbooks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridEbooks.Rows[e.RowIndex];

        //Getting eventID reference
        Literal ltrhdUID = (Literal)gvRow.FindControl("hdUID");

        // int delStatus = ebDBcode.EBook_Delete(ltrhdBookId.Text, Convert.ToInt32(ltrhdUID.Text));


        Literal ltrhdvalueBuyID = (Literal)gvRow.FindControl("hdvalueBuyUID");
        int delStatus = objEbook.EBook_ValueBuy_Delete(Convert.ToInt32(ltrhdvalueBuyID.Text));


        //int delStatus = 1; 
        if (delStatus >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Value Buy Ebook Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        }
        else
        {
            lblErrMessage.Text = "Could not deleted the Ebook . Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

        }



        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('eBook deleted successfully')", true);

    }


    protected void gridEbooks_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //gridEbooks.EditIndex = e.NewEditIndex;
        //PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //GridViewRow gRow = (GridViewRow)gridEbooks.Rows[e.NewEditIndex];
        //Literal ltrTstID = (Literal)gRow.FindControl("hdTstId");
        gridEbooks.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //Server.Transfer("TestimonialViewEdit.aspx?TestimonialID=" + ltrTstID.Text);
    }



    protected void gridEbooks_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridEbooks.BottomPagerRow, gridEbooks);

        
    }


    protected void gridEbooks_RowDataBound(object sender, GridViewRowEventArgs e)
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
            Literal ltrhdUID = (Literal)e.Row.FindControl("hdUID");
            Literal ltrhdBookId = (Literal)e.Row.FindControl("hdBookId");
            HyperLink HyLinkEdit = (HyperLink)e.Row.FindControl("HyLinkEdit");

            //HyLinkEdit.NavigateUrl = "EBAd_ValueBuyEdit.aspx?BookID=" + ltrhdBookId.Text;
            //HyLinkEdit.Visible = true;

            HiddenField objhidCreatedBy = (HiddenField)e.Row.FindControl("hidCreatedBy");

            ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");
            ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");

            Label Objlblmobile1 = (Label)e.Row.FindControl("lblmobile1");
            Label Objlblmobile2 = (Label)e.Row.FindControl("lblmobile2");
            Label Objlblmobile3 = (Label)e.Row.FindControl("lblmobile3");

            if (Objlblmobile1 != null)
                if (Objlblmobile1.Text == "0") Objlblmobile1.Text = "";

            if (Objlblmobile2 != null)
                if (Objlblmobile2.Text == "0") Objlblmobile2.Text = "";

            if (Objlblmobile3 != null)
                if (Objlblmobile3.Text == "0") Objlblmobile3.Text = "";


            if (objhidCreatedBy.Value == "ADMIN")
            {

                if (objImgEdit != null)
                    objImgEdit.Visible = true;

                if (objImgDelete != null)
                    objImgDelete.Visible = false;

                Label objlblCreatedBy = (Label)e.Row.FindControl("lblCreatedBy");
                if (objlblCreatedBy != null)
                objlblCreatedBy.CssClass = "fontRed";

            }
            else
            {

                Label objlblCreatedBy = (Label)e.Row.FindControl("lblCreatedBy");
                if (objlblCreatedBy != null)
                objlblCreatedBy.CssClass = "fontGreen";

                HyLinkEdit.NavigateUrl = "EBAd_ValueBuyEdit.aspx?BookID=" + Server.UrlEncode(CommonFunctions.Encrypt(ltrhdBookId.Text));
                HyLinkEdit.Visible = true;


                if (objImgDelete != null)
                    objImgDelete.Visible = true;


                if (objImgEdit != null)
                    objImgEdit.Visible = false;
            }


            #region Showing Checkbox ticked image


            //need to find out if the logged users is not a superadmin disable the last cell 

            //============


            Literal objLtrisShowAtHp = (Literal)e.Row.FindControl("LtrisShowAtHp");
            Image objImgHpShow = (Image)e.Row.FindControl("ImgHpShow");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (objImgHpShow != null)
            {
                if (objLtrisShowAtHp.Text != "")
                {
                    if (Convert.ToBoolean(objLtrisShowAtHp.Text))
                    {
                        objImgHpShow.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        objImgHpShow.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
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
                        objImgActive.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        objImgActive.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }


            //== is Featured. 


            Literal objLtrisFeatured = (Literal)e.Row.FindControl("LtrisFeatured");
            Image objImgisFeatured = (Image)e.Row.FindControl("ImgisFeatured");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (objImgisFeatured != null)
            {
                if (objLtrisFeatured.Text != "")
                {
                    if (Convert.ToBoolean(objLtrisFeatured.Text))
                    {
                        objImgisFeatured.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        objImgisFeatured.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }



            //== Allow SMS Buy 

            Literal LtrAllowSMSbuy = (Literal)e.Row.FindControl("LtrAllowSMSbuy");
            Image ImgAllowSMSbuy = (Image)e.Row.FindControl("ImgAllowSMSbuy");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (ImgAllowSMSbuy != null)
            {
                if (LtrAllowSMSbuy.Text != "")
                {
                    if (Convert.ToBoolean(LtrAllowSMSbuy.Text))
                    {
                        ImgAllowSMSbuy.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        ImgAllowSMSbuy.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }



            //== Allow Pay Buy

            Literal LtrAllowPaypalBuy = (Literal)e.Row.FindControl("LtrAllowPaypalBuy");
            Image ImgAllowPaypalBuyy = (Image)e.Row.FindControl("ImgAllowPaypalBuyy");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (ImgAllowPaypalBuyy != null)
            {
                if (LtrAllowPaypalBuy.Text != "")
                {
                    if (Convert.ToBoolean(LtrAllowPaypalBuy.Text))
                    {
                        ImgAllowPaypalBuyy.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        ImgAllowPaypalBuyy.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                }
            }


            #endregion



            //book images 

            HiddenField objBookCount = (HiddenField)e.Row.FindControl("hdBookCount");


            Label lblBK3 = (Label)e.Row.FindControl("lblBookID3");
            if (lblBK3 != null)
            {
                Image imgBK3 = (Image)e.Row.FindControl("ImageBook3");

                if (lblBK3.Text == "")
                {
                    lblBK3.Visible = false;
                    imgBK3.Visible = false;
                }

            }


            Label lblBK4 = (Label)e.Row.FindControl("lblBookID4");
            if (lblBK4 != null)
            {
                Image imgBK4 = (Image)e.Row.FindControl("ImageBook4");

                if (lblBK4.Text == "")
                {
                    lblBK4.Visible = false;
                    imgBK4.Visible = false;
                }

            }



            Label lblBK5 = (Label)e.Row.FindControl("lblBookID5");
            if (lblBK5 != null)
            {
                Image imgBK5 = (Image)e.Row.FindControl("ImageBook5");

                if (lblBK5.Text == "")
                {
                    lblBK5.Visible = false;
                    imgBK5.Visible = false;
                }

            }


        }
    }






    protected void gridEbooks_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {



        GridViewRow gRow = (GridViewRow)gridEbooks.Rows[e.RowIndex];
        //CheckBox chkisShowAtHP = (CheckBox)gRow.FindControl("chkisShowAtHP");

        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");

             Literal hdvalueBuyUID = (Literal)gRow.FindControl("hdvalueBuyUID");

        Literal hdBookId = (Literal)gRow.FindControl("hdBookId");
        Literal hdBookUID = (Literal)gRow.FindControl("hdUID");


        string tmpBookID = hdBookId.Text;
        int tmpBookUID = Convert.ToInt32(hdBookUID.Text);


        //int upStatus = ebDBcode.EBook_Update_BestSeller(tmpUID, chkisShowAtHP.Checked);
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        int vBookType = Convert.ToInt16(GlobalVar.EbookTypes.ValueBuy);

        //int upStatus = objEbook.Ebook_ShowHide_HpItems(vUserID, tmpBookID, tmpBookUID, vBookType, chkisShowAtHP.Checked);

        int upStatus = objEbook.Ebook_ShowHide(vUserID, tmpBookID, tmpBookUID, vBookType, chkActive.Checked);

        //int hpStatus = objEbook.Ebook_ShowHide_HpItems(vUserID, tmpBookID, tmpBookUID, vBookType, chkisShowAtHP.Checked);



        //int delStatus = 1; 
        if (upStatus >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Ebook Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        }
        else
        {
            lblErrMessage.Text = "Could not Update the Ebook . Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

        }


        gridEbooks.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());


    }
}