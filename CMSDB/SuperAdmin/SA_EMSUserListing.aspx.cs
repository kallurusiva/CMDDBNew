using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security;
using System.Security.Cryptography;
using CMSv3.BAL;

public partial class SuperAdmin_SA_EMSUserListing : System.Web.UI.Page 
{
    DataSet ds;
    DataView dv;

    
    CMSv3.BAL.MalaysiaSMS objBAL_MasUser = new CMSv3.BAL.MalaysiaSMS();
    CMSv3.BAL.GemailSystem objBAL_Gems = new CMSv3.BAL.GemailSystem(); 

    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    //int qLgType = 0; 




    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        //ltrAllUsersListing.Text = Resources.LangResources.All + " " +  Resources.LangResources.User + " " + Resources.LangResources.Listing;


        //if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
        //{
        //    qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        //}

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "Active";
            ViewState["SearchQuery"] = "";
            //ViewState["SearchQuery"] = " and Upgrador Not in (Select MobileLoginID from tblEMSinfo where Active=1)";
            

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

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
        }

        tblMessageBar.Visible = false;
        ddlSearchParam.Attributes.Add("onchange", "ChangeSearchValueBox(this)");


    }

    //protected void Page_PreRender(object sender, EventArgs e)
    //{
    //    //PreSelecting the Language DropDown --
    //    //-- accessing the Selected Language 
    //    ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
    //    UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
    //    DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
    //    if (qLgType != null)
    //        objddlSelLang.SelectedValue = Convert.ToString(qLgType);


    //    if (Request.QueryString["LgType"] != null && Request.QueryString["LgType"].ToString() != "")
    //    {
    //        // qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
    //        if (Request.QueryString["LgType"] == "0")
    //        {
    //            //gridFaq.Columns[5].Visible = false;

    //            int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridNews);
    //            gridNews.Columns[ColIdx].Visible = false;
    //        }
    //    }
    //    else if (qLgType == 0)
    //    {
    //        int ColIdx = CommonFunctions.GetGridViewColIndex_HeaderText("Priority", gridNews);
    //        gridNews.Columns[ColIdx].Visible = false;
    //    }
    //}


    protected void PopulateGrid(string vSortExpr, string vSortDir, string vSearchQuery)
    {


        ds = objBAL_MasUser.Get_1MasUser_EMSDetails(vSearchQuery); 

             

            if (ds.Tables[0].Rows.Count > 0)
            {

                dv = ds.Tables[0].DefaultView;
                if (vSortExpr != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }


                // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


                gridUsers.DataSource = dv;
                gridUsers.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridUsers.DataSource = ds;
                gridUsers.DataBind();

                int ColCount = gridUsers.Rows[0].Cells.Count;
                gridUsers.Rows[0].Cells.Clear();
                gridUsers.Rows[0].Cells.Add(new TableCell());
                gridUsers.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridUsers.Rows[0].Cells[0].Text = "No records Found";
                gridUsers.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




            }



    }



    protected void gridUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridUsers.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridUsers.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridUsers.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridUsers.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
                }
            }
        }
    }


    protected void gridUsers_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;
        PopulateGrid(m_SortExpr, sortOrder, ViewState["SearchQuery"].ToString());
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


    public SortDirection GridViewSortDirection
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }
    
    protected void gridUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridUsers.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());

    }

    protected void gridUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridUsers.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }

    protected void gridUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridUsers.Rows[e.RowIndex];

        //Get the reference to the Fields in the grid view row
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkisActive");
        //TextBox objOwnDomain = (TextBox)gRow.FindControl("txtOwnDomainName");
        //TextBox objSubDomain = (TextBox)gRow.FindControl("txtSubDomainName");



        int rowCount= 0;

       //// rowCount = objBAL_User.Update_User_Status(Convert.ToInt32(objHidUserID.Value), chkActive.Checked, "", objSubDomain.Text);


        if (rowCount >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "User Status Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the News. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        gridUsers.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());

    }

    //protected void gridUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{

    //    //Get the reference to the gridview row
    //    GridViewRow gvRow = (GridViewRow)gridUsers.Rows[e.RowIndex];

    //    //Getting newsID reference
    //    Literal ltrNewsID = (Literal)gvRow.FindControl("hdNewsID");

    //    int NewsIdToDelte = Convert.ToInt32(ltrNewsID.Text);

    //    bool delStatus = objBAl_News.DeleteNewsData(Convert.ToInt32(Session["saUserID"]), NewsIdToDelte);
        

    //    if (delStatus)
    //    {
    //        tblMessageBar.Visible = true;
    //        lblErrMessage.Text = "News item Deleted Sucessfully";
    //        lblErrMessage.CssClass = "font_12Msg_Success";
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";

    //    }
    //    else
    //    {
    //        lblErrMessage.Text = "Could not deleted the News item. Technical Error";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //    }


    //    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    //}



    protected void gridUsers_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(gridUsers.BottomPagerRow, gridUsers);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridUsers.BottomPagerRow, gridUsers);
        
    }


    protected void gridUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {

            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");


            ////To get the up/down image at the sorted column 
            CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //CheckBox objChkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //objChkSelect.Attributes.Add("onClick", "SelectRow('" + objChkSelect.ClientID + "')");


            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");



            DataRowView drv = ((DataRowView)e.Row.DataItem);
            
            Literal objLtrSubDomainName = (Literal)e.Row.FindControl("ltrSubDomainName");

            if (objLtrSubDomainName != null)
            {
                string tmpSubDomainURL = "http://" + drv["subDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;
                objLtrSubDomainName.Text = "<a class='links_FuncLinks' target='_blank' href='" + tmpSubDomainURL + "'>" + tmpSubDomainURL + "</a>";
            }


            Literal objLtrMobileLoginID = (Literal)e.Row.FindControl("ltrMobileLoginID");
            //EXEC [usp_EmailSystem_ChkPurchase] '601620103326',0

            HiddenField objHidActive = (HiddenField)e.Row.FindControl("hidActive");

            if (objHidActive != null)
            {

                ImageButton objEditButton = (ImageButton)e.Row.FindControl("ImgEditEMS");
                ImageButton objEmailButton = (ImageButton)e.Row.FindControl("ImgAddEMS"); 

                if (objHidActive.Value == "False")
                {
                    objEmailButton.Visible = true;
                    objEditButton.Visible = false;

                    #region Add Domain code

                    string AddDomain2UserID = string.Empty;
                    //HiddenField hd_UserId = (HiddenField)e.Row.FindControl("hidUserID");
                    //AddDomain2UserID = hd_UserId.Value;

                    ImageButton objImgAddDomain = (ImageButton)e.Row.FindControl("ImgAddDomain");
                    HiddenField hd_domainType = (HiddenField)e.Row.FindControl("hidDomainType");
                    HiddenField hd_OwndomainName = (HiddenField)e.Row.FindControl("hidOwnDomainName");


                    ImageButton objImgAddEMS = (ImageButton)e.Row.FindControl("ImgAddEMS");
                    Literal objLtrFullName = (Literal)e.Row.FindControl("ltrFullName");

                    if (objImgAddEMS != null)
                    {
                        //Literal objLtrMobileLoginID = (Literal)e.Row.FindControl("ltrMobileLoginID");
                        
                        objImgAddEMS.CommandArgument = "qMobileLoginID=" + objLtrMobileLoginID.Text + "&qFullName=" + objLtrFullName.Text;
                    }


                    ImageButton objImgAddHtml = (ImageButton)e.Row.FindControl("ImgAddHtml");
                    if (objImgAddHtml != null)
                    {
                        objImgAddHtml.CommandArgument = "qMobileLoginID=" + objLtrMobileLoginID.Text + "&qFullName=" + objLtrFullName.Text;
                    }

                    



                    #endregion
                }
                else
                {
                    objEditButton.Visible = true;
                    objEmailButton.Visible = false;

                    ImageButton objImgEditEMS = (ImageButton)e.Row.FindControl("ImgEditEMS");

                    if (objImgEditEMS != null)
                    {
                        objImgEditEMS.CommandArgument = "qMobileLoginID=" + objLtrMobileLoginID.Text + "&vAction=EDIT";

                    }
                }


            }

 
        }


    }


    protected void AddEMS_Click(object sender, CommandEventArgs e)
    {
        Response.Redirect(@"SA_EMSContentAdd.aspx?" + e.CommandArgument.ToString());
    }


    protected void EditEMS_Click(object sender, CommandEventArgs e)
    {
        Response.Redirect(@"SA_EMSContentAdd.aspx?" + e.CommandArgument.ToString());
    }


    protected void UploadHTML_Click(object sender, CommandEventArgs e)
    {
        Response.Redirect(@"SA_EMSUploadGhtml.aspx?" + e.CommandArgument.ToString());
    }

    

    


    protected void btnSearch_Click(object sender, EventArgs e)
    {

        String tmpSearchQuery = string.Empty;

        string tmpSearchParam = ddlSearchParam.SelectedValue;
        string tmpSearchValue = string.Empty;

        if (tmpSearchParam == "SHOWALL")
        {
            tmpSearchQuery = "";
            ViewState["SearchQuery"] = tmpSearchQuery;
        }
        else if (tmpSearchParam == "SHOW2")
        {
            tmpSearchQuery = " and Active = 1";
            ViewState["SearchQuery"] = tmpSearchQuery;
        }
        else
        {
            tmpSearchValue = CommonFunctions.SafeSql(txtSearchValue.Text);
            tmpSearchQuery = "and " + tmpSearchParam + " Like '%" + tmpSearchValue + "%'";
            ViewState["SearchQuery"] = tmpSearchQuery;
        }


        //if (tmpSearchValue != "")
        //{

          
            
        //}

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());


    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        ViewState["SearchQuery"] = "";
        txtSearchValue.Text = "";
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
    }


    protected void ddlSearchParam_SelectedIndexChanged(object sender, EventArgs e)
    {

        //if (ddlSearchParam.SelectedValue == "isActive")
        //{
        //    dvSearchTextBox.Visible = false;
        //    dvStatusDropDown.Visible = true;

        //}
        //else
        //{
        //    dvSearchTextBox.Visible = true;
        //    dvStatusDropDown.Visible = false;
        //}

    }

    protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}