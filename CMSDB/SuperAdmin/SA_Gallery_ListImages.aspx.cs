﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

public partial class SA_Gallery_ListImages : System.Web.UI.Page
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
    int vItemsPerPage = 8; 


    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();
    CMSv3.BAL.Gallery objBAL_Gallery = new CMSv3.BAL.Gallery(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"] != null))
        {
            if (Session["saUserID"].ToString() == "")
                Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        else
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }

        #endregion 

        ltrHeader.Text = "Image Gallery ";
        
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


            if (ViewState["ItemsPerPage"] != null)
                this.vItemsPerPage = Convert.ToInt32(ViewState["ItemsPerPage"].ToString());
            else
                ViewState["ItemsPerPage"] = vItemsPerPage; 


            ViewState["CategoryID"] = mCategoryID;


            #region Code to Mark Image for Deletion

            if ((Request.QueryString["ImgToDelete"] != null) && (Request.QueryString["ImgToDelete"] != ""))
            {
                DeleteImage(Request.QueryString["ImgToDelete"]);
            }


            if ((Request.QueryString["ImgToEdit"] != null) && (Request.QueryString["ImgToEdit"] != ""))
            {
                EditImage(Request.QueryString["ImgToEdit"]);
            }

            #endregion





            LoadCategories(Convert.ToInt32(ViewState["CategoryID"]));
            LoadImageGallery(mCategoryID,CurrentPageNo);
            Prepare_Pager(TotalImages); 
        }

     }

    protected void DeleteImage(string vImageID2Delete)
    {

        int tmpImageIDDelete = Convert.ToInt32(vImageID2Delete);
        int delStatus = objBAL_Gallery.DeleteGiImage(tmpImageIDDelete); 
       // int delStatus = objBAL_AccountSettings.Settings_DeleteUserImage(tmpImageIDDelete);

        //alert javascript to show image delete
        CommonFunctions.AlertMessage("Image has been Deleted.");

    }

    protected void EditImage(string vImageID2Edit)
    {

        Response.Redirect("SA_Gallery_EditImage.aspx?ImgToEdit=" + vImageID2Edit);        

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

        

        DataSet dsImageInfo;
        vItemsPerPage = Convert.ToInt32(ViewState["ItemsPerPage"].ToString()); 
        dsImageInfo = objBAL_Gallery.RetrieveAll_GImagesByCategory(vCategoryId, vPageNo, vItemsPerPage, "SA");


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
        int intCurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());

        btnFirst.Visible = false;
        btnLast.Visible = false;
        btnPrevious.Visible = false;
        btnNext.Visible = false;

        if (intPageCount == intCurrentPage)
        {
            btnFirst.Visible = false;
            btnPrevious.Visible = false;
            btnLast.Visible = false;
            btnNext.Visible = false;
        }

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

        if (intPageCount != intCurrentPage)
        {
            PageNumberDropDownList.Visible = true;
            PageStartLabel.Visible = false;
            //clear all the initial values; 
            PageNumberDropDownList.Items.Clear();

            for (int i = 1; i <= intPageCount; i++)
            {
                PageNumberDropDownList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        else
        {
            PageNumberDropDownList.Visible = false;
            PageStartLabel.Visible = true;
            PageStartLabel.Text = intPageCount.ToString();
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

            TextBox objTxtURLlink = (TextBox)e.Item.FindControl("txtURLlink"); 

            

            HiddenField objHidImgTitle = (HiddenField)e.Item.FindControl("hidImgTitle");
            HiddenField objHidImgURL = (HiddenField)e.Item.FindControl("hidImgURL");
            HiddenField objHidVidActive = (HiddenField)e.Item.FindControl("hidVidActive");

            if (objlblImgTitle != null)
                objlblImgTitle.Text = objHidImgTitle.Value;

            if (objTxtURLlink != null)
            {
                //objlblImgURL.Text = "www.domainname.com/" + objHidImgURL.Value;
                //objTxtURLlink.Text = "www.domainname.com/" + objHidImgURL.Value;
                objTxtURLlink.Text = @"http:\\www." + GlobalVar.GetAnchorDomainName + objHidImgURL.Value.Replace("~", "");
               // objTxtURLlink.Text = objHidImgURL.Value.Replace("~", "");
            }

            if (objHidVidActive != null)
            {
                HtmlImage objImgNotActive = (HtmlImage)e.Item.FindControl("imgNotActive");
                if (objImgNotActive != null)
                {
                    if (objHidVidActive.Value == "True")
                        objImgNotActive.Visible = false;
                    else
                        objImgNotActive.Visible = true;
                }

            }


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

    protected void ddlItemPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["ItemsPerPage"] = ddlItemPerPage.SelectedValue;
        LoadImageGallery(Convert.ToInt32(ViewState["CategoryID"]), Convert.ToInt32(ViewState["CurrentPage"].ToString()));
        Prepare_Pager(TotalImages);
    }
}
