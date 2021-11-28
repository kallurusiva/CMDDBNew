using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using System.IO;
using System.Text;


public partial class Ad_WP_BottomImage : BasePage
{

    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataAdapter dbAdap;

    DataSet ds;
    DataView dv;
    DataTable dt_Banners;
    DataTable dt_CurrBannerID;

    //string strSQL;
    string Curr_BannerID = "7173";
    bool FileWasUpload = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    String tpWp_ImageType = "WP_BOTTOM";


    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();
    //int qLgType = 0;

    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        FileWasUpload = Getbool();
        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "ImgDate";

            ViewState["ImageWasUploaded"] = "false";
            ViewState["FileImageUrl"] = "";
            ViewState["FilterIndustryID"] = "0";

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


            if (Request.QueryString["qBannerUp"] == "TRUE")
            {
                CommonFunctions.AlertMessage("Bottom Banner successfully uploaded and saved");
            }
            else if (Request.QueryString["qBannerUp"] == "CHANGED")
            {
                CommonFunctions.AlertMessage("Bottom Banner  successfully updated");
            }

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());
            LoadCategories();
            
        }
        else
        {
           
        }

        tblMessageBar.Visible = false;
    }


    protected void LoadCategories()
    {
        CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();

        DataSet dsCat;
        DataView dvCat;
        dsCat = objBAL_Domains.Retrieve_AncDomainCategories("");
        dvCat = dsCat.Tables[0].DefaultView;


        ddlCategory.DataSource = dsCat;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataBind();

        ddlCategory.Items.Insert(0, new ListItem("Show ALL", "0"));

        //if (vCategoryID != 0)
        //{
        //    ddlCategory.SelectedValue = vCategoryID.ToString();
        //}

        


    }

    protected void PopulateGrid(string vSortExpr, string vSortDir, string vFilterByIndustryID)
    {

        
        if (vFilterByIndustryID == "0")
        {
            ds = objBAL_AccountSettings.WP_Retrieve_Images(Convert.ToInt32(Session["UserID"]),tpWp_ImageType,"ADM");
        }
        else
        {
            ds = objBAL_AccountSettings.WP_Retrieve_Images_ByIndustry(Convert.ToInt32(Session["UserID"]), vFilterByIndustryID,tpWp_ImageType, "ADM");
        }


        dt_Banners = ds.Tables[0];
        dt_CurrBannerID = ds.Tables[1];


        if (dt_CurrBannerID.Rows.Count > 0)
        {
            if(dt_CurrBannerID.Rows[0][0].ToString() == "") 
             Session["CurrSel_ImageID"] = Curr_BannerID;
            else
             Session["CurrSel_ImageID"] = dt_CurrBannerID.Rows[0][0].ToString();
            
        }
        else
        {
            Session["CurrSel_ImageID"] = Curr_BannerID;
        }

       
        if(dt_Banners.Rows.Count > 0 )
        {
                //dv = ds.Tables[0].DefaultView;
                dv = dt_Banners.DefaultView;
                gridWpImages.DataSource = dv;
                gridWpImages.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridWpImages.DataSource = ds;
                gridWpImages.DataBind();

                int ColCount = gridWpImages.Rows[0].Cells.Count;
                gridWpImages.Rows[0].Cells.Clear();
                gridWpImages.Rows[0].Cells.Add(new TableCell());
                gridWpImages.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridWpImages.Rows[0].Cells[0].Text = "No records Found";
                gridWpImages.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;

            }

        

       
        

    }


    protected void gridWpImages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridWpImages.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridWpImages.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridWpImages.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridWpImages.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());
                }
            }
        }
    }


    protected void gridWpImages_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());
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


       

    protected void gridWpImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //int rowcount = 0;
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridWpImages.Rows[e.RowIndex];

        //Getting ImageID reference
        HiddenField objhdImageID = (HiddenField)gvRow.FindControl("hidImageID");

        int delStatus = objBAL_AccountSettings.Settings_DeleteUserImage(Convert.ToInt32(objhdImageID.Value));

       

      


        if (delStatus >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //alert javascript to show image delete
            CommonFunctions.AlertMessage("Image has been Deleted.");

        }
        else
        {
            lblErrMessage.Text = "Could not delete the item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }


        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());
    }



    protected void gridWpImages_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(gridWpImages.BottomPagerRow, gridWpImages);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridWpImages.BottomPagerRow, gridWpImages);

    }


   

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }




    protected void gridWpImages_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string tmpBannerSelect = string.Empty;

        string ImageFolder = @".." + GlobalVar.GetImgStoreFolder.ToString();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Literal objLtrWpImg = (Literal)e.Row.FindControl("ltrWpImage");
            Literal objLtrWpImgID = (Literal)e.Row.FindControl("ltrImageImgID");


            HiddenField row_imageID = (HiddenField)e.Row.FindControl("hidImageID");
            HiddenField row_userId = (HiddenField)e.Row.FindControl("hidUserId");
            HiddenField objImageName = (HiddenField)e.Row.FindControl("hidImageName");
            HiddenField objImageActualName = (HiddenField)e.Row.FindControl("hidImageActualName");
            HiddenField objFullImagePath = (HiddenField)e.Row.FindControl("hidFullImgPath");
            HiddenField objCategoryName = (HiddenField)e.Row.FindControl("hidCategoryName");
            
            //HiddenField objCurrSel_BannerID = (HiddenField)e.Row.FindControl("hidCurrSel_BannerID");


            Literal objRDO_WpImage = (Literal)e.Row.FindControl("ltrRDO_WpImage");
            
            
            Image objDelImage = (Image)e.Row.FindControl("ImgDelete");


            if ((objLtrWpImg != null) && (objImageName.Value != ""))
            {

                string tmpBannerImageName = objImageName.Value;
                string Alt_BannerImgName = objImageActualName.Value;
                objLtrWpImgID.Text = Alt_BannerImgName.Substring(0, Alt_BannerImgName.IndexOf("."));

                if (row_userId.Value == Session["UserID"].ToString())
                {
                    objLtrWpImgID.Text = objLtrWpImgID.Text + "<br/>" + "<font class='FontNote'>(Uploaded by Myself)</font>";
                }
                else
                {
                    objLtrWpImgID.Text = objLtrWpImgID.Text + "<br/>" + "<font class='FontNote'>(" + objCategoryName.Value + ")</font>";
                }


                if (Session["CurrSel_ImageID"].ToString() == row_imageID.Value)
                {
                    objRDO_WpImage.Text = string.Format("<input id='rdoBannerID' name='rdoGrp_ImageID' checked value='{0}' type='radio'/>", row_imageID.Value);
                }
                else{
                    objRDO_WpImage.Text = string.Format("<input id='rdoBannerID' name='rdoGrp_ImageID' value='{0}' type='radio'/>", row_imageID.Value);
                }



                
                if (row_userId.Value == "101")
                {
                    if (tmpBannerImageName.ToString().Contains(".swf"))
                    {

                        objLtrWpImg.Text = String.Format("<object width='550' height='150'><param name='movie' value='{0}'><embed src='{0}' width='550' height='150'></embed></object>", ImageFolder + objImageName.Value);
                    }
                    else
                    {

                        objLtrWpImg.Text = String.Format("<img class='SelWp_BotImgCss' src='{0}'>", ImageFolder + objImageName.Value);
                    }
                    objDelImage.Visible = false;
                    
                    

                }
                else
                {

                    if (tmpBannerImageName.ToString().Contains(".swf"))
                    {

                        objLtrWpImg.Text = String.Format("<object width='550' height='150'><param name='movie' value='{0}'><embed src='{0}' width='550' height='150'></embed></object>", ImageFolder + objImageName.Value); 
                    }
                    else
                    {

                        objLtrWpImg.Text = String.Format("<img class='SelWp_BotImgCss' src='{0}'>", ImageFolder + objImageName.Value);
                    }
                  
                }


            }


        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {


        
        string strImgFileName = string.Empty;
        string strWpImage_ImgActual_FileName = string.Empty;
        string strBannerImgFileURL = string.Empty;

        int WpImage_ImgType;
        string WpImage_ImgPath = string.Empty;
        string WpImage_ImgName = string.Empty;
        string WpImage_ImgActualName = string.Empty;
        bool User_ImgSelected;

        string selBannerImg = string.Empty;

        Random rnum = new Random();

        //Check to see if the user has ticked Display at Website for Banner
           User_ImgSelected = chkActive_WpImage.Checked;


        if (ViewState["ImageWasUploaded"].ToString() == "true")
        {
            WpImage_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.BannerImage);
            WpImage_ImgPath = @"\ImageRepository\";
            WpImage_ImgName = ViewState["Wp_FileImageName"].ToString();
            WpImage_ImgActualName = ViewState["Wp_ActualFileName"].ToString();

            selBannerImg = "0";

        }
        else
        {

            WpImage_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
            WpImage_ImgPath = @"\ImageRepository\";
            WpImage_ImgName = strImgFileName;
            WpImage_ImgActualName = strWpImage_ImgActual_FileName;

            selBannerImg = Request.Form["rdoGrp_ImageID"];
        }


        //... denote banner as wpImage

        CMSv3.Entities.AdminSettings objImageUser = new CMSv3.Entities.AdminSettings();

        objImageUser.Banner_ImgID = Convert.ToInt32(selBannerImg);
        objImageUser.Banner_ImgType = WpImage_ImgType;
        objImageUser.Banner_ImgPath = WpImage_ImgPath;
        objImageUser.Banner_ImgName = WpImage_ImgName;
        objImageUser.Banner_ImgActualName = WpImage_ImgActualName;
        objImageUser.User_BannerTicked = User_ImgSelected;


        objBAL_AccountSettings.WP_Save_Images(objImageUser, Convert.ToInt32(Session["UserID"]), 0, "WP_BOTTOM");

        //strSQL = "EXEC [usp_Settings_Update_Banner] " + Convert.ToInt32(Session["UserID"]) + "," + Convert.ToInt32(selBannerImg) + "," + 
        //            WpImage_ImgType + ",'" + WpImage_ImgPath + "','" + WpImage_ImgName + "','" + WpImage_ImgActualName + "'," + User_ImgSelected;

        
        Response.Redirect("Ad_WP_BottomImage.aspx?qBannerUp=CHANGED");


    }

    //protected void CustomVdr_Banner_ServerValidate(object source, ServerValidateEventArgs args)
    //{
    //    //71680 = 70 KB  ( 1024 * 70 )
    //    //102400 = 70 KB  ( 1024 * 100 )
    //    //512000 = 500 KB


    //    //For flash files max size limit is 500 KB and for Jpg Banners is 100KB


    //    Boolean tmpValid = false;


    //    if (FU_Banner.FileName.Contains(".swf"))
    //    {
    //        //flash
    //        if (FU_Banner.FileBytes.Length > 204800)
    //            tmpValid = false;
    //        else
    //            tmpValid = true;

    //        CustomVdr_Banner.ErrorMessage = "Flash file should not be greater than 500KB.";
    //    }
    //    else
    //    {
    //        //others
    //        if (FU_Banner.FileBytes.Length > 102400)
    //            tmpValid = false;
    //        else
    //            tmpValid = false;
    //        CustomVdr_Banner.ErrorMessage = "Image size should not be greater than 100KB.";

    //    }

    //    args.IsValid = tmpValid;

    //    ////if (FU_Banner.FileBytes.Length > 71680)
    //    ////{
    //    ////    args.IsValid = false;
    //    ////}
    //    ////else
    //    ////{
    //    ////    args.IsValid = true;
    //    ////}
    //}

    protected void btn_Banner_Logo0_Click(object sender, EventArgs e)
    {
        

        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();


        if (FU_Banner.HasFile)
        {

            ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Banner.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

            FU_Banner.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessage.Text = "Image uploaded : " + FU_Banner.FileName + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>"; ;
            FileWasUpload = true;
            ViewState["Wp_FileImageUrl"] = ImgFileUrl;
            ViewState["Wp_FileImageName"] = ImgFileName;
            ViewState["Wp_ActualFileName"] = FU_Banner.FileName;
            ViewState["ImageWasUploaded"] = "true";



            CMSv3.Entities.AdminSettings objImageUser = new CMSv3.Entities.AdminSettings();

            objImageUser.Banner_ImgID = Convert.ToInt32(Session["CurrSel_ImageID"]);
            objImageUser.Banner_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.WP_BottomImage);
            objImageUser.Banner_ImgPath = @"\ImageRepository\";
            objImageUser.Banner_ImgName = ImgFileName;
            objImageUser.Banner_ImgActualName = FU_Banner.FileName;
            objImageUser.User_BannerTicked = chkActive_WpImage.Checked;


            objBAL_AccountSettings.WP_Save_Images(objImageUser, Convert.ToInt32(Session["UserID"]), 0, "WP_BOTTOM");




            //strSQL = "EXEC [usp_Settings_Update_Banner] " + Convert.ToInt32(Session["UserID"]) + "," + Convert.ToInt32(Session["CurrSel_ImageID"]) + "," +
            //       Convert.ToInt16(GlobalVar.ImageTypeEnums.BannerImage) + ",'" + @"\ImageRepository\" + "','" + ImgFileName + "','" + FU_Banner.FileName + "'," + chkActive_WpImage.Checked;


            Response.Redirect("Ad_WP_BottomImage.aspx?qBannerUp=TRUE");

        }


    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int SelIndustryID = Convert.ToInt16(ddlCategory.SelectedValue);
        ViewState["FilterIndustryID"] = SelIndustryID;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());

    }
}
