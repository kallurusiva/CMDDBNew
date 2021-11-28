using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

public partial class EBAd_NewReleases : System.Web.UI.Page 
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;


    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook(); 


    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check 

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


       

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "";
            ViewState["SortExpr"] = "";

            
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }

        tblMessageBar.Visible = false;
        MaintainScrollPositionOnPostBack = true;  
    }

    
    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        //ds = objBAl_Event.Retrieve_AllEventByUserID(101);
        //ds = objEbook.Ebook_Listing(Convert.ToInt32(Session["UserID"]), " AND isNewRelease = 1"); 

        ds = objEbook.Ebook_NewRelease_LIST(Convert.ToInt32(Session["UserID"]), ""); 
        
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
        HiddenField ObjhdNewReleaseUID = (HiddenField)gvRow.FindControl("hdNewReleaseUID");

        int tmpBSuid = Convert.ToInt32(ObjhdNewReleaseUID.Value); 

       // int delStatus = objEbook.EBook_Delete(ObjhdBookId.Value, Convert.ToInt32(ObjhdUID.Value));

        int delStatus = objEbook.EBook_NewRelease_Delete(tmpBSuid); 

        //int delStatus = 1; 
        if (delStatus >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Ebook unMarked as Best Seller Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        }
        else
        {
            lblErrMessage.Text = "Could not unMark the Ebook as Best Seller. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

        }



        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('eBook unMarked as Best-Seller successfully')", true);




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

            //LinkButton linkBtnDownloadFile = (LinkButton)e.Row.FindControl("linkBtnDownloadFile");
            //HiddenField hidDownload = (HiddenField)e.Row.FindControl("hidDownload");

            //if (hidDownload.Value.ToString() == "0")
            //{
            //    linkBtnDownloadFile.OnClientClick = null;
            //}


            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");



            //ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");
         

            //HyLinkEdit.NavigateUrl = "EB_BookEdit.aspx?BookID=" + ltrhdBookId.Text;
            //HyLinkEdit.Visible = true;


            Label Objlblmobile1 = (Label)e.Row.FindControl("lblmobile1");
            Label Objlblmobile2 = (Label)e.Row.FindControl("lblmobile2");
            Label Objlblmobile3 = (Label)e.Row.FindControl("lblmobile3");

            if (Objlblmobile1 != null)
                if (Objlblmobile1.Text == "0") Objlblmobile1.Text = "";

            if (Objlblmobile2 != null)
                if (Objlblmobile2.Text == "0") Objlblmobile2.Text = "";

            if (Objlblmobile3 != null)
                if (Objlblmobile3.Text == "0") Objlblmobile3.Text = "";


            HiddenField objhidCreatedBy = (HiddenField)e.Row.FindControl("hidCreatedBy");

            ImageButton objImgEdit = (ImageButton)e.Row.FindControl("ImgEdit");
            ImageButton objImgDelete = (ImageButton)e.Row.FindControl("ImgDelete");
            ImageButton objImgEditByUser = (ImageButton)e.Row.FindControl("ImgEditByUser");

            if (objhidCreatedBy.Value == "ADMIN")
            {

                if (objImgEdit != null)
                   objImgEdit.Visible = true;
                
                if (objImgDelete != null)
                    objImgDelete.Visible = false;

                //if (objImgEditByUser != null)
                //    objImgEditByUser.Visible = false;

                Label objlblCreatedBy = (Label)e.Row.FindControl("lblCreatedBy");
                if (objlblCreatedBy != null)
                objlblCreatedBy.CssClass = "fontRed";

            }
            else
            {

                Label objlblCreatedBy = (Label)e.Row.FindControl("lblCreatedBy");
                if(objlblCreatedBy != null)
                    objlblCreatedBy.CssClass = "fontGreen";
              //  HyperLink objHypEditByUser = (HyperLink)e.Row.FindControl("HyLinkEditByUser");
                HiddenField objBookUID = (HiddenField)e.Row.FindControl("hidBookUID");
                HiddenField objBookID = (HiddenField)e.Row.FindControl("hidBookID");

                //objHypEditByUser.NavigateUrl = "EBAd_NewReleaseEdit.aspx?qBID=" + objBookUID.Value; 
                //objHypEditByUser.Visible = true;



                //HyperLink HyLinkEdit = (HyperLink)e.Row.FindControl("HyLinkEdit");

                //HyLinkEdit.NavigateUrl = "EBAd_NewReleaseEdit.aspx?qBID=" + Server.UrlEncode(CommonFunctions.Encrypt(objBookID.Value)); 
                //HyLinkEdit.Visible = true;




                //if (objImgEditByUser != null)
                //    objImgEditByUser.Visible = true;

                if (objImgDelete != null)
                    objImgDelete.Visible = true;


                //if (objImgEdit != null)
                //    objImgEdit.Visible = false;

            }


            


            #region Showing Checkbox ticked image


            //need to find out if the logged users is not a superadmin disable the last cell 

            //============

            Literal objLtrActive = (Literal)e.Row.FindControl("LtrActive");
            Image objImgActive = (Image)e.Row.FindControl("ImgActive");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (objImgActive != null)
            {
                if(objLtrActive.Text != "")
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



            //== is item shown at HomePage

            Literal ObjLtrHpShow = (Literal)e.Row.FindControl("LtrHpShow");
            Image ObjImgHpShow = (Image)e.Row.FindControl("ImgHpShow");


            if (ObjImgHpShow != null)
            {
                if (ObjLtrHpShow.Text != "")
                {
                    if (Convert.ToBoolean(ObjLtrHpShow.Text))
                    {
                        ObjImgHpShow.ImageUrl = @"~\Images\checkbox_ticked.jpg";
                    }
                    else
                    {
                        ObjImgHpShow.ImageUrl = @"~\Images\checkbox_empty.jpg";
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

            var scriptManager = ScriptManager.GetCurrent(this.Page);

            if (scriptManager != null)
            {
                //scriptManager.RegisterPostBackControl(linkBtnDownloadFile);
            }

        }
        


    }








    protected void gridEbooks_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow gRow = (GridViewRow)gridEbooks.Rows[e.RowIndex];
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");

        //CheckBox chkHpShow = (CheckBox)gRow.FindControl("chkHpShow");


        HiddenField hdBookId = (HiddenField)gRow.FindControl("hidBookId");
        HiddenField hdBookUID = (HiddenField)gRow.FindControl("hidBookUID");



        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        String vBookID = hdBookId.Value;
        int vBookUID = Convert.ToInt32(hdBookUID.Value);
        int vBookType = Convert.ToInt16(GlobalVar.EbookTypes.NewRelease);


        int upStatus = objEbook.Ebook_ShowHide(vUserID, vBookID, vBookUID, vBookType, chkActive.Checked);

        //int hpStatus = objEbook.Ebook_ShowHide_HpItems(vUserID, vBookID, vBookUID, vBookType,chkHpShow.Checked);

        if (upStatus >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Ebook Display Status Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the Ebook Status. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        gridEbooks.EditIndex = -1;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }


    protected void gridEbooks_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void Button_View(object sender, CommandEventArgs e)
    {
        string s = e.CommandArgument.ToString();

        string[] strInfo = s.Split(',');

        for (int i = 0; i < strInfo.Length; i++)
        {
            HdEditBookUID.Value = strInfo[0];
            HdEditBookID.Value = strInfo[1];

            
        }

       // Response.Redirect(@"EBAd_NewReleaseEdit.aspx"); 

       Server.Transfer(@"EBAd_NewReleaseEdit.aspx");
    }

    protected void gridEbooks_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "EditByUser")
        {
           // grdListUsers.SelectedIndex = Convert.ToInt32(e.CommandArgument);


            string s = e.CommandArgument.ToString();

            string[] strInfo = s.Split(',');

            for (int i = 0; i < strInfo.Length; i++)
            {
                HdEditBookUID.Value = strInfo[0];
                HdEditBookID.Value = strInfo[1];


            }

            Server.Transfer(@"EBAd_NewReleaseEdit.aspx");
        }

    }

    protected void ImgDownloadFile_Click(object sender, CommandEventArgs e)
    {


        String EbookfileURL = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        String vfile = e.CommandArgument.ToString();

        String EbookFilePath = EbookfileURL + vfile; 
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + vfile);
        Response.WriteFile(EbookFilePath);
        Response.End();
    }

    protected void linkBtnDownloadFile_Command(object sender, CommandEventArgs e)
    {
        string info = e.CommandArgument.ToString();
        string[] arg = new string[2];
        char[] splitter = { ';' };
        arg = info.Split(splitter);
        String vfileName = arg[0].ToString();
        String downloadSatus = arg[1].ToString();
        String eBookID = arg[2].ToString();

        decimal CreditBalance = 0;
        ds = objEbook.EbAd_SmsCreditBalance_Retrieve(Convert.ToInt32(Session["MERID"].ToString()));

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            CreditBalance = Convert.ToDecimal(dr["BalanceCredit"].ToString());
        }
        int vCreditBalance = (int)Math.Ceiling(CreditBalance);

        String EbookfileURL = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        String EbookFilePath = EbookfileURL + vfileName;

        if (downloadSatus == "1")
        {
            if (vCreditBalance > 5)
            {
                if (File.Exists(Server.MapPath(EbookFilePath)))
                {
                    // Deduct SMS Credits.
                    newDBS ndbs = new newDBS();
                    //int dedStatus = ndbs.EbAd_SmsCreditBalance_Deduct(Convert.ToInt32(Session["MERID"].ToString()), 5);
                    DataSet dedStatus = ndbs.EbAd_SmsCreditBalance_Deduct_Web(Convert.ToInt32(Session["MERID"].ToString()), 5, eBookID, Session["UserID"].ToString(),"");

                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + vfileName);
                    Response.WriteFile(EbookFilePath);
                }
                else
                {
                    CommonFunctions.AlertMessage("Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.");

                }
            }
            else
            {
                String vAlertMsg = @"Sorry !!. Minimum of 5 Sms Credits are required to Download an Ebook.\\n\\n" + "Your SMS Credit Balance : " + CreditBalance.ToString() + "\\n\\nPlease Top Up.";
                CommonFunctions.AlertMessage(vAlertMsg);
                return;
            }
        }
        else if (downloadSatus == "0")
        {
            if (File.Exists(Server.MapPath(EbookFilePath)))
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + vfileName);
                Response.WriteFile(EbookFilePath);
            }
            else
            {
                CommonFunctions.AlertMessage("Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.");

            }
        }
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 
    }
}
