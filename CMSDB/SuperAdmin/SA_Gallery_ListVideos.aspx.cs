using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

public partial class SA_Gallery_ListVideos : System.Web.UI.Page
{
    #region Global Variables    
    DataSet dsCat;
    DataView dvCat;
    DataTable dtVideos;
    DataTable dtTotalVideos; 
    int CurrentPageNo = 1;
    int mCategoryID = 0;
    int TotalImages = 0;
    int PageCount = 1;
    int vItemsPerPage = 8;
    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();
    CMSv3.BAL.Gallery objBAL_Gallery = new CMSv3.BAL.Gallery();
    #endregion

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

        ltrHeader.Text = "Video Gallery ";
        
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

            if ((Request.QueryString["VideoToDelete"] != null) && (Request.QueryString["VideoToDelete"] != ""))
            {
                DeleteVideo(Request.QueryString["VideoToDelete"]);
            }


            if ((Request.QueryString["VideoToEdit"] != null) && (Request.QueryString["VideoToEdit"] != ""))
            {
                EditVideo(Request.QueryString["VideoToEdit"]);
            }

            #endregion

            LoadCategories(Convert.ToInt32(ViewState["CategoryID"]));
            LoadVideoGallery(mCategoryID,CurrentPageNo);
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

    protected void LoadVideoGallery(int vCategoryId, int vPageNo)
    { 
        DataSet dsVideoInfo;
        vItemsPerPage = Convert.ToInt32(ViewState["ItemsPerPage"].ToString()); 
        dsVideoInfo = objBAL_Gallery.RetrieveAll_GIVideosByCategory(vCategoryId, vPageNo, vItemsPerPage,"SA");

        dtVideos = dsVideoInfo.Tables[0];
        dtTotalVideos = dsVideoInfo.Tables[1];
        DLImageGallery.DataSource = dtVideos;
        DLImageGallery.DataBind();

        foreach (DataRow dtRow in dtTotalVideos.Rows)
        {
            TotalImages = Convert.ToInt32(dtRow["TotalVideos"].ToString());
        }
        PageCount = CalculateTotalPages(TotalImages);
        ViewState["TotalVideos"] = TotalImages;
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
        int dPageNo = Convert.ToInt32(ViewState["CurrentPage"].ToString());
        int dPageCount = Convert.ToInt32(ViewState["PageCount"].ToString());
        int SelPageNo = Convert.ToInt32(PageNumberDropDownList.SelectedValue); 
        
        if (dPageCount > 0)
        {
            if (SelPageNo < dPageCount || SelPageNo >= 1)
            {
                ViewState["CurrentPage"] = SelPageNo;
                LoadVideoGallery(Convert.ToInt32(ViewState["CategoryID"]), Convert.ToInt32(ViewState["CurrentPage"].ToString())); 
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
        LoadVideoGallery(Convert.ToInt32(ViewState["CategoryID"]), mPageNo);         
    }

    protected void DLImageGallery_DataBinding(object sender, EventArgs e)
    {
    }

    protected void DLImageGallery_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Label objlblVidTitle = (Label)e.Item.FindControl("lblVidTitle");
            Label objlblVidLink = (Label)e.Item.FindControl("lblVidLink");
            TextBox objTxtVidEmbed = (TextBox)e.Item.FindControl("txtEmbedLink");            

            HiddenField objHidVidTitle = (HiddenField)e.Item.FindControl("hidVidTitle");
            HiddenField objHidVidLink = (HiddenField)e.Item.FindControl("hidVidLink");
            HiddenField objHidVidActive = (HiddenField)e.Item.FindControl("hidVidActive");
            
            Literal objltrYouTube = (Literal)e.Item.FindControl("LtrYouTubeInfo");
            HtmlGenericControl objFrmYT = (HtmlGenericControl)e.Item.FindControl("ifrYouTube");
            //WebControl objFrmYT = (WebControl)e.Item.FindControl("ifrYouTube");

            if ((objltrYouTube != null) && (objHidVidLink != null))
            {
                if (objHidVidLink.Value != "")
                    {
                        String FormedYouTubeLink = GetFormedYoutubeLink(objHidVidLink.Value);
                    ////    if (FormedYouTubeLink != "")
                    ////       objltrYouTube.Text = FormedYouTubeLink;
                        objFrmYT.Attributes.Add("src", FormedYouTubeLink); 
                        objTxtVidEmbed.Text = FormedYouTubeLink;
                    }
            }            

            if (objlblVidTitle != null)
                objlblVidTitle.Text = objHidVidTitle.Value;

            if (objlblVidLink != null)
                objlblVidLink.Text = "<a href='" + GetYoutubeLinkFromEmbedText(objHidVidLink.Value)  + "' target='_blank'>" + GetYoutubeLinkFromEmbedText(objHidVidLink.Value) + "</a>";

            if (objHidVidActive != null)
            {
               // Image objImgNotActive = (Image)e.Item.FindControl("imgNotActive");
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

    public string GetYoutubeLinkFromEmbedText(string vYtlink)
    {
        String retYTLink = string.Empty;
        String OrgYTlink = vYtlink;

        if (vYtlink.Contains("youtu.be"))
        {
            return OrgYTlink;
        }
        else if (vYtlink.Contains("<iframe"))
        {
            int tmpStartPointer = vYtlink.IndexOf("src=");
            int tmpEndPointer = vYtlink.IndexOf("frameborder");

            if ((tmpStartPointer != 0) && (tmpEndPointer != 0))
            {
                tmpStartPointer += 5;
                tmpEndPointer -= 2;
                tmpEndPointer = tmpEndPointer - tmpStartPointer;
                vYtlink = vYtlink.Substring(tmpStartPointer, tmpEndPointer);
                vYtlink = vYtlink.Replace("http://", "");
                vYtlink = vYtlink.Replace("youtu.be.com/", "");
                vYtlink = vYtlink.Replace("www.youtube.com/", "");
                vYtlink = vYtlink.Replace("embed/", "");
                retYTLink = "http://youtu.be/" + vYtlink;
            }
        }
        return retYTLink;
    }

    public string GetFormedYoutubeLink(string vYtlink)
    {
        String retString = string.Empty;
        String OrgYTlink = vYtlink;
        //http://youtu.be/xd12hR68sWM
        //<iframe width="420" height="315" src="http://www.youtube.com/embed/xd12hR68sWM" frameborder="0" allowfullscreen></iframe>

        if (vYtlink.Contains("youtu.be"))
        {
            vYtlink = vYtlink.Replace("http://", "");
            vYtlink = vYtlink.Replace("youtu.be/", "");
            vYtlink = vYtlink.Replace("youtu.be.com/", "");
            //retString = "<iframe width='250' height='250' src='http://www.youtube.com/embed/" + vYtlink + "' frameborder='0' allowfullscreen></iframe>";
            retString = "http://www.youtube.com/embed/" + vYtlink;

        }
        else if (vYtlink.Contains("<iframe"))
        {
            int tmpStartPointer = vYtlink.IndexOf("src=");
            int tmpEndPointer = vYtlink.IndexOf("frameborder");

            if ((tmpStartPointer != 0) && (tmpEndPointer != 0))
            {
                tmpStartPointer += 5;
                tmpEndPointer -= 2;
                tmpEndPointer = tmpEndPointer - tmpStartPointer;
                vYtlink = vYtlink.Substring(tmpStartPointer, tmpEndPointer);
                vYtlink = vYtlink.Replace("http://", "");
                vYtlink = vYtlink.Replace("youtu.be.com/", "");
                vYtlink = vYtlink.Replace("www.youtube.com/", "");
                vYtlink = vYtlink.Replace("embed/", "");
                //retString = "<iframe width='250' height='250' src='http://www.youtube.com/embed/" + vYtlink + "' frameborder='0' allowfullscreen></iframe>";
                retString = "http://www.youtube.com/embed/" + vYtlink;
            }
        }
        return retString;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string SrcCategoryId = ddlCategory.SelectedValue;
        ViewState["CategoryID"] = SrcCategoryId;
        LoadVideoGallery(Convert.ToInt32(ViewState["CategoryID"]), 1);
        Prepare_Pager(TotalImages); 
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ViewState["CategoryID"] = 0;
        LoadVideoGallery(Convert.ToInt32(ViewState["CategoryID"]), 1);
        Prepare_Pager(TotalImages); 
    }

    protected void ddlItemPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["ItemsPerPage"] = ddlItemPerPage.SelectedValue;
        LoadVideoGallery(Convert.ToInt32(ViewState["CategoryID"]), Convert.ToInt32(ViewState["CurrentPage"].ToString()));
        Prepare_Pager(TotalImages);
    }

    protected void DeleteVideo(string vVideoID2Delete)
    {
        int tmpVideoIDDelete = Convert.ToInt32(vVideoID2Delete);
        int delStatus = objBAL_Gallery.DeleteGiVideo(tmpVideoIDDelete);
        CommonFunctions.AlertMessage("Video has been Deleted.");
    }

    protected void EditVideo(string vVideoID2Edit)
    {
        Response.Redirect("SA_Gallery_EditVideo.aspx?VideoToEdit=" + vVideoID2Edit);
    }

}
