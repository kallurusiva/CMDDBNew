using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using System.IO;
using System.Text;


public partial class Ad_Gallery_Images : BasePage
{

    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //string strSQL;

    DataSet dsCat;
    DataView dvCat;

    DataTable dtImages;
    DataTable dtTotalImages;
    int CurrentPageNo = 1;
    int mCategoryID = 0;
    int TotalImages = 0;
    int PageCount = 1;
    int vItemsPerPage = 6;

    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"] != null) )
        {
            if(Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpire.aspx");
        }
        else
        {
            Response.Redirect("~/SessionExpire.aspx");
        }

        #endregion 

        ltrHeader.Text = Resources.LangResources.Image + " " + Resources.LangResources.Gallery;

        Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            if (ViewState["CurrentPage"] != null)
            {
                this.CurrentPageNo = Convert.ToInt32(ViewState["CurrentPage"]);
            }
            else
            {
                ViewState["CurrentPage"] = 1;
            }


            ViewState["CategoryID"] = mCategoryID;

            LoadCategories(Convert.ToInt32(ViewState["CategoryID"]));
            LoadImageGallery(mCategoryID, CurrentPageNo);
            Prepare_Pager(TotalImages);
            
        }
       
    }



    protected void LoadCategories(int vCategoryID)
    {
        dsCat = objBAL_Domains.Retrieve_AncDomainCategories("");
        dvCat = dsCat.Tables[0].DefaultView;


        ddlCategory.DataSource = dsCat;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataBind();

        ddlCategory.Items.Insert(0, new ListItem("Select Industry", "0"));

        if (vCategoryID != 0)
        {
            ddlCategory.SelectedValue = vCategoryID.ToString();
        }


    }



    protected void LoadImageGallery(int vCategoryId, int vPageNo)
    {

        CMSv3.BAL.Gallery objBAL_Gallery = new CMSv3.BAL.Gallery();

        DataSet dsImageInfo;
        dsImageInfo = objBAL_Gallery.RetrieveAll_GImagesByCategory(vCategoryId, vPageNo, vItemsPerPage,"ADMIN");


        dtImages = dsImageInfo.Tables[0];
        dtTotalImages = dsImageInfo.Tables[1];



        DLImageGallery.DataSource = dtImages;
        DLImageGallery.DataBind();


        foreach (DataRow dtRow in dtTotalImages.Rows)
        {
            TotalImages = Convert.ToInt32(dtRow["TotalImages"].ToString());
        }
        PageCount = CalculateTotalPages(TotalImages);
        ViewState["TotalImages"] = TotalImages;
        ViewState["PageCount"] = PageCount;

        lblTotalImages.Text = TotalImages.ToString();
        PageCountLabel.Text = PageCount.ToString();


    }


    private int CalculateTotalPages(int intTotalRows)
    {

        int intPageCount = 1;

        double dblPageCount = (double)(Convert.ToDecimal(intTotalRows) / Convert.ToDecimal(this.vItemsPerPage));

        intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));

        return intPageCount;

    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList pageNumberDropDownList = sender as DropDownList;
        //ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        //if (pageNumberDropDownList != null)
        //{
        //    if (gridUsers.Rows.Count > 0)
        //    {
        //        if (pageNumberDropDownList.SelectedIndex < gridUsers.PageCount ||
        //          pageNumberDropDownList.SelectedIndex >= 0)
        //        {
        //            gridUsers.PageIndex = pageNumberDropDownList.SelectedIndex;
        //            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchQuery"].ToString());
        //        }
        //    }
        //}

        int dPageNo = Convert.ToInt32(ViewState["CurrentPage"].ToString());
        int dPageCount = Convert.ToInt32(ViewState["PageCount"].ToString());

        int SelPageNo = Convert.ToInt32(PageNumberDropDownList.SelectedValue);

        if (dPageCount > 0)
        {
            if (SelPageNo < dPageCount || SelPageNo >= 1)
            {
                ViewState["CurrentPage"] = SelPageNo;
                LoadImageGallery(Convert.ToInt32(ViewState["CategoryID"]), Convert.ToInt32(ViewState["CurrentPage"].ToString()));
            }
        }


    }

    protected void Prepare_Pager(int vTotalRows)
    {
        int intPageCount = this.CalculateTotalPages(vTotalRows);

        btnFirst.Visible = false;
        btnLast.Visible = false;
        btnPrevious.Visible = false;
        btnNext.Visible = false;

        if (intPageCount > 1)
        {
            btnNext.Visible = true;
            btnLast.Visible = true;
        }
        else if (intPageCount == 1)
        {
            btnFirst.Visible = false;
            btnPrevious.Visible = false;
        }
        else if (intPageCount == PageCount)
        {
            btnLast.Visible = false;
            btnNext.Visible = false;
        }

        //clear all the initial values; 
        PageNumberDropDownList.Items.Clear();

        for (int i = 1; i <= intPageCount; i++)
        {
            PageNumberDropDownList.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        //pageNumberDropDownList.Items.Add(new ListItem(page.ToString(), i.ToString()));


    }
    protected void Paging_Click(object sender, EventArgs e)
    {
        int mPageNo = Convert.ToInt32(ViewState["CurrentPage"].ToString());
        ImageButton PagerButton = (ImageButton)sender;
        int tmpPageCount = Convert.ToInt32(ViewState["PageCount"].ToString());

        switch (PagerButton.CommandName)
        {
            case "FIRST": mPageNo = 1;
                // Disable 'First' and 'Previous' Paging image buttons
                //btnFirst.Visible = false;
                //btnPrevious.Visible = false; 
                break;

            case "PREVIOUS": mPageNo = mPageNo - 1;

                //btnFirst.Visible = true;
                //btnLast.Visible = true;
                //btnPrevious.Visible = true;
                //btnNext.Visible = true; 

                break;

            case "NEXT": mPageNo = mPageNo + 1;


                //btnFirst.Visible = true;
                //btnLast.Visible = true;
                //btnPrevious.Visible = true;
                //btnNext.Visible = true; 

                break;


            case "LAST": mPageNo = tmpPageCount;
                // // Disable 'Last' and 'Next' Paging image buttons
                //btnNext.Visible = false;
                //btnLast.Visible = false; 
                break;
        }

        btnFirst.Visible = true;
        btnPrevious.Visible = true;
        btnLast.Visible = true;
        btnNext.Visible = true;

        if (mPageNo <= 1)
        {
            btnFirst.Visible = false;
            btnPrevious.Visible = false;
        }
        else if (mPageNo == tmpPageCount)
        {
            btnLast.Visible = false;
            btnNext.Visible = false;
        }
        else if (mPageNo < tmpPageCount)
        {
            //btnLast.Visible = false;
            //btnNext.Visible = false;
        }


        PageNumberDropDownList.SelectedValue = mPageNo.ToString();
        ViewState["CurrentPage"] = mPageNo;

        LoadImageGallery(Convert.ToInt32(ViewState["CategoryID"]), mPageNo);

    }


    protected void DLImageGallery_DataBinding(object sender, EventArgs e)
    {



    }
    protected void DLImageGallery_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Label objlblImgTitle = (Label)e.Item.FindControl("lblImgTitle");
            Label objlblImgURL = (Label)e.Item.FindControl("lblImgURL");

            HiddenField objHidImgTitle = (HiddenField)e.Item.FindControl("hidImgTitle");
            HiddenField objHidImgURL = (HiddenField)e.Item.FindControl("hidImgURL");

            if (objlblImgTitle != null)
                objlblImgTitle.Text = objHidImgTitle.Value;

            if (objlblImgURL != null)
                objlblImgURL.Text = "www.domainname.com/" + objHidImgURL.Value;



        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string SrcCategoryId = ddlCategory.SelectedValue;
        ViewState["CategoryID"] = SrcCategoryId;
        LoadImageGallery(Convert.ToInt32(ViewState["CategoryID"]), 1);

        Prepare_Pager(TotalImages);

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ViewState["CategoryID"] = 0;
        LoadImageGallery(Convert.ToInt32(ViewState["CategoryID"]), 1);
        Prepare_Pager(TotalImages);
    }
    


}
