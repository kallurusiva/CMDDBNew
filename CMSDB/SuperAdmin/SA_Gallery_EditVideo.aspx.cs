using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SA_Gallery_EditVideo : System.Web.UI.Page
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //string strSQL;

    DataSet dsCat;
    DataView dvCat;

    DataSet dsImage; 

    DataTable dtImages;
    //DataTable dtTotalImages; 
    
    //int CurrentPageNo = 1;
    //int mCategoryID = 0;
    //int TotalImages = 0;
    //int PageCount = 1;
    //int ItemsPerPage = 8;
    int tmpVideoIDtoEdit = 0;

    String dbVideoTitle = string.Empty;
    String dbVideoLilnk = string.Empty;
    bool dbVideoActive;
    int dbCategoryId = 0;


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

        ltrHeader.Text = "Upload Video ";
        
        if (!IsPostBack)
        {
            LoadCategories();

            if ((Request.QueryString["VideoToEdit"] != null) && (Request.QueryString["VideoToEdit"] != ""))
            {
                tmpVideoIDtoEdit = Convert.ToInt32(Request.QueryString["VideoToEdit"]);
                ViewState["EditVideoID"] = tmpVideoIDtoEdit;

                LoadVideoDetails(tmpVideoIDtoEdit);
            }

        }

     }



    protected void LoadVideoDetails(int vVideoID)
    {
        dsImage = objBAL_Gallery.Retrieve_GImagesByvideoID(vVideoID); 
        dtImages = dsImage.Tables[0];

        foreach(DataRow drImg in dtImages.Rows)
        {

            dbVideoTitle = drImg["VideoTitle"].ToString();
            dbCategoryId = Convert.ToInt32(drImg["CategoryID"].ToString());
            dbVideoLilnk = drImg["VideoLink"].ToString();
            dbVideoActive = Convert.ToBoolean(drImg["Active"].ToString());
            ViewState["vwVideoLink"] = dbVideoLilnk;
            String FormedYouTubeLink = GetFormedYoutubeLink(dbVideoLilnk);
            ltrVideoFrame.Text = FormedYouTubeLink;
            //Rendering
            txtVideoTitle.Text = dbVideoTitle;
            ddlCategory.SelectedValue = dbCategoryId.ToString();

            chkActive.Checked = dbVideoActive;
        }


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
            retString = "<iframe width='250' height='250' src='http://www.youtube.com/embed/" + vYtlink + "' frameborder='0' allowfullscreen></iframe>";

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
                retString = "<iframe width='250' height='250' src='http://www.youtube.com/embed/" + vYtlink + "' frameborder='0' allowfullscreen></iframe>";
            }
        }


        return retString;

    }

    protected void LoadCategories()
    {
        dsCat = objBAL_Domains.Retrieve_AncDomainCategories("");
        dvCat = dsCat.Tables[0].DefaultView;


        ddlCategory.DataSource = dsCat;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataBind();


    }


    protected void btnSaveImage_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid)
            return;

        String tmpVideoLink = txtVideoLink.Text.Trim();
        String tmpVideoTitle = txtVideoTitle.Text.Trim();
        int tmpCategoryId = Convert.ToInt32(ddlCategory.SelectedValue);

        bool tmpActive = chkActive.Checked;

        if (tmpVideoLink == "")
            tmpVideoLink = ViewState["vwVideoLink"].ToString(); 

      

        CMSv3.Entities.ObjectImage objImage = new CMSv3.Entities.ObjectImage();
        CMSv3.BAL.AccountSettings objAccountSettings = new CMSv3.BAL.AccountSettings();

        int mVideoId = Convert.ToInt32(ViewState["EditVideoID"].ToString());


        int inStatus = objBAL_Gallery.Update_VideoLinkInfo(mVideoId, tmpVideoLink, tmpVideoTitle, tmpCategoryId, tmpActive); 
       

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "video info updated successfully.";
            lblErrMessage.CssClass = "font_12Msg_Success";

            // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
            CommonFunctions.AlertMessage("Video updated successfully"); 
            Response.Redirect("SA_Gallery_ListVideos.aspx"); 
            return;

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }


    }

 
}
