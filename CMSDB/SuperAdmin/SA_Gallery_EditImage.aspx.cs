using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SA_Gallery_EditImage : System.Web.UI.Page
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
    int tmpImageIDtoEdit = 0;

    String dbImgTitle = string.Empty;
    String dbImgActualName = string.Empty;
    String dbImgPath = string.Empty;
    bool dbImgActive; 
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

        ltrHeader.Text = "Upload Images ";
        
        if (!IsPostBack)
        {
            LoadCategories();

            if ((Request.QueryString["ImgToEdit"] != null) && (Request.QueryString["ImgToEdit"] != ""))
            {
                tmpImageIDtoEdit = Convert.ToInt32(Request.QueryString["ImgToEdit"]);
                ViewState["EditImageId"] = tmpImageIDtoEdit;

                LoadImageDetails(tmpImageIDtoEdit);
            }

        }

     }



    protected void LoadImageDetails(int vImageID)
    {
        dsImage = objBAL_Gallery.Retrieve_GImagesByImageID(vImageID);

        dtImages = dsImage.Tables[0];

        foreach(DataRow drImg in dtImages.Rows)
        {

            dbImgTitle = drImg["ImgTitle"].ToString();
            dbCategoryId = Convert.ToInt32(drImg["ImgCategory"].ToString());
            dbImgActualName = drImg["ImgActualName"].ToString();
            dbImgActive = Convert.ToBoolean(drImg["Active"].ToString());
            dbImgPath = drImg["ImgPath"].ToString(); 
            
            //Rendering
            ImgCurrent.ImageUrl = @"~\ImageRepository\Gallery\Images\" + dbImgActualName;
            txtImageTitle.Text = dbImgTitle;
            ddlCategory.SelectedValue = dbCategoryId.ToString();

            chkActive.Checked = dbImgActive;
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


    protected void btn_FU_Image_Click(object sender, EventArgs e)
    {
        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();


        if (FU_Image.HasFile)
        {

            String tmpImageFullName = FU_Image.FileName + " | " + FU_Image.FileBytes;

            lblUpMessage.Text = "Image selected : " + tmpImageFullName;
        }
    }

    protected void CustomVdr_Image_ServerValidate(object source, ServerValidateEventArgs args)
    {
        String tmpValMessage = string.Empty; 
       
        //checking size   
        double fileSize =(double) FU_Image.FileBytes.Length;  
        double fileinMB = fileSize / (1024 * 1024);  
        double fileSizelimit = 1;  /// limit 1MB


        //30720 = 15 KB  ( 1024 * 30 ) 
        if (FU_Image.HasFile)
        {
            if (fileinMB > fileSizelimit)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
            lblUpMessage.Text = "( selected image: " +  FU_Image.FileName + " [" + fileinMB.ToString("##.##") + "Mb] )";
        }
        else
        {
            CustomVdr_Logo.Text = "Please select an Image to Upload.";
        }


    }

    protected void btnSaveImage_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid)
            return;

        String tmpImgTitle = txtImageTitle.Text.Trim();
        String tmpCategoryId = ddlCategory.SelectedValue;

        bool tmpActive = chkActive.Checked;

        Random rnum = new Random();

        String ImgFileName = string.Empty;
        String ImgFileUrl = string.Empty;

        CMSv3.Entities.ObjectImage objImage = new CMSv3.Entities.ObjectImage();
        CMSv3.BAL.AccountSettings objAccountSettings = new CMSv3.BAL.AccountSettings();

        objImage.objImageID = Convert.ToInt32(ViewState["EditImageId"].ToString()); 


        if (FU_Image.HasFile)
        {
            if(tmpImgTitle == "")
                objImage.ObjImageName = FU_Image.FileName; 
            else
                objImage.ObjImageName = tmpImgTitle;


            ImgFileName = Session["saUserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Image.FileName;
            objImage.ObjImageActualName = ImgFileName;
            
            //instead of server.mapPath set the path in web.config file and use that path.
            objImage.ObjImagePath = Server.MapPath("~") + @"\ImageRepository\Gallery\Images\";

            FU_Image.SaveAs(objImage.ObjImagePath + ImgFileName);
            objImage.ObjImageType = Convert.ToInt32(tmpCategoryId);
            //lblUpMessage.Text = "Image to be uploaded : " + FU_Image.FileName + "<br/>";
        }
        else
        {

            objImage.ObjImageName = tmpImgTitle;
            objImage.ObjImageActualName = dbImgActualName;
            objImage.ObjImagePath = dbImgPath;
            objImage.ObjImageType = Convert.ToInt32(tmpCategoryId);
        }

        
        //..Storing reference in database. 
        //int inStatus = objBAL_AccountSettings.Update_Settings_HomePageDefaults22(objWebSettings, Convert.ToInt32(Session["UserID"]));
        //int inStatus = objAccountSettings.Update_GalleryImageSettings(objImage, Convert.ToInt32(Session["saUserID"]));
        int inStatus = objBAL_Gallery.Update_GalleryImageByID(objImage, tmpActive); 

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Image uploaded successfully.";
            lblErrMessage.CssClass = "font_12Msg_Success";

            // ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Homepage settings saved uccessfully')", true);
           // CommonFunctions.AlertMessage("Image uploaded successfully"); 
            Response.Redirect("SA_Gallery_ListImages.aspx"); 
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
