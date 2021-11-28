using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SA_Gallery_UploadVideos : System.Web.UI.Page
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //string strSQL;

    DataSet dsCat;
    DataView dvCat;

    //DataTable dtImages;
    //DataTable dtTotalImages; 
    //int CurrentPageNo = 1;
    //int mCategoryID = 0;
    //int TotalImages = 0;
    //int PageCount = 1;
    //int ItemsPerPage = 8; 


    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();

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

        ltrHeader.Text = "Upload Videos ";
        
        if (!IsPostBack)
        {
            LoadCategories();
        }

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


   
    protected void btnSaveVideo_Click(object sender, EventArgs e)
    {
        

        if (!Page.IsValid)
            return;

        
        String tmpVideoLink = txtVideoLink.Text.Trim();
        String tmpVideoTitle = txtVideoTitle.Text.Trim(); 
        int tmpCategoryId = Convert.ToInt32(ddlCategory.SelectedValue);


        CMSv3.BAL.Gallery objBAL_Gallery = new CMSv3.BAL.Gallery(); 

        
        //..Storing reference in database. 
        //int inStatus = objBAL_AccountSettings.Update_Settings_HomePageDefaults22(objWebSettings, Convert.ToInt32(Session["UserID"]));
        int inStatus = objBAL_Gallery.Save_VideoLinkInfo(tmpVideoLink, tmpVideoTitle, tmpCategoryId); 


        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Video uploaded successfully.";
            lblErrMessage.CssClass = "font_12Msg_Success";

            // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
            CommonFunctions.AlertMessage("Video uploaded successfully"); 
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
