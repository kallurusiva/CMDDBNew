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

public partial class Admin_Ad_BannerSettings : BasePage
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    //SqlDataAdapter dbAdap;

    DataSet ds;
    DataView dv;
    DataTable dt_Banners;
    DataTable dt_CurrBannerID;

    string strSQL;
    string Curr_BannerID = "10";
    bool FileWasUpload;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;


    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();
    //int qLgType = 0;

    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    String tmpUserType = string.Empty; 

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        FileWasUpload = GetBool();
        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "CreatedDate";

            ViewState["BannerWasUploaded"] = "false";
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
                CommonFunctions.AlertMessage("Banner successfully uploaded and saved");
            }
            else if (Request.QueryString["qBannerUp"] == "CHANGED")
            {
                CommonFunctions.AlertMessage("Banner successfully updated");
            }

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());

            
            if (Session["UserDomainType"] != null)
            {
                tmpUserType = Session["UserDomainType"].ToString();
            }

            if (tmpUserType == "EBOOK")
            {
                trCategoryDropdown.Visible = false;
            }
            else
            {
                LoadCategories();
            }
        }
        else
        {
           
        }

        tblMessageBar.Visible = false;
    }

    private static bool GetBool()
    {
        return false;
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
            ds = objBAL_AccountSettings.Retrieve_Banners(Convert.ToInt32(Session["UserID"]),"ADM");
        }
        else
        {
            ds = objBAL_AccountSettings.Retrieve_Banners_ByIndustry(Convert.ToInt32(Session["UserID"]), vFilterByIndustryID,"ADM");
        }


        dt_Banners = ds.Tables[0];
        dt_CurrBannerID = ds.Tables[1];


        if (dt_CurrBannerID.Rows.Count > 0)
        {
            if(dt_CurrBannerID.Rows[0][0].ToString() == "")
             Session["CurrSel_BannerID"] = Curr_BannerID;
            else
             Session["CurrSel_BannerID"] = dt_CurrBannerID.Rows[0][0].ToString();
            
        }
        else
        {
            Session["CurrSel_BannerID"] = Curr_BannerID;
        }

       
        if(dt_Banners.Rows.Count > 0 )
        {
                //dv = ds.Tables[0].DefaultView;
                dv = dt_Banners.DefaultView;
                gridBanner.DataSource = dv;
                gridBanner.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridBanner.DataSource = ds;
                gridBanner.DataBind();

                int ColCount = gridBanner.Rows[0].Cells.Count;
                gridBanner.Rows[0].Cells.Clear();
                gridBanner.Rows[0].Cells.Add(new TableCell());
                gridBanner.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridBanner.Rows[0].Cells[0].Text = "No records Found";
                gridBanner.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;

            }

        

       
        

    }

    protected void gridBanner_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridBanner.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridBanner.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridBanner.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridBanner.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());
                }
            }
        }
    }

    protected void gridBanner_Sorting(object sender, GridViewSortEventArgs e)
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

    protected void gridBanner_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //int rowcount = 0;
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridBanner.Rows[e.RowIndex];

        //Getting ImageID reference
        HiddenField objhdImageID = (HiddenField)gvRow.FindControl("hidImageID");

        int delStatus = objBAL_AccountSettings.Settings_DeleteUserImage(Convert.ToInt32(objhdImageID.Value));

       

       //// bool delStatus = objBAL_Faq.DeleteFaqData(Convert.ToInt32(Session["UserID"]), FaqIdToDelte);
       // strSQL = "Update tblEnquiry set Deleted = 1 where enqId = " + EnqIdToDelte + " and UserID = " + Convert.ToInt32(Session["UserID"]);
       // dbConn = new SqlConnection(GlobalVar.GetDbConnString);

       // try
       // {
       //     dbConn.Open();
       //     dbCmd = new SqlCommand(strSQL, dbConn);

       //     rowcount = dbCmd.ExecuteNonQuery();

       // }
       // catch (Exception ex)
       // {
       //     throw ex;
       // }
       // finally
       // {
       //     dbConn.Close();
       // }


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

    protected void gridBanner_DataBound(object sender, EventArgs e)
    {
        //CommonFunctions.InitialiseGridViewPagerRow(gridBanner.BottomPagerRow, gridBanner);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridBanner.BottomPagerRow, gridBanner);
    }   

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void gridBanner_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string tmpBannerSelect = string.Empty;

        string ImageFolder = @".." + GlobalVar.GetImgStoreFolder.ToString();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal objLtrBannerImg = (Literal)e.Row.FindControl("ltrBannerImage");
            Literal objLtrBannerImgID = (Literal)e.Row.FindControl("ltrBannerImgId");
            HiddenField row_imageID = (HiddenField)e.Row.FindControl("hidImageID");
            HiddenField row_userId = (HiddenField)e.Row.FindControl("hidUserId");
            HiddenField objImageName = (HiddenField)e.Row.FindControl("hidImageName");
            HiddenField objImageActualName = (HiddenField)e.Row.FindControl("hidImageActualName");
            HiddenField objFullImagePath = (HiddenField)e.Row.FindControl("hidFullImgPath");
            HiddenField objCategoryName = (HiddenField)e.Row.FindControl("hidCategoryName");
            HiddenField objVDisp = (HiddenField)e.Row.FindControl("HiddenVDisp");
            
            //HiddenField objCurrSel_BannerID = (HiddenField)e.Row.FindControl("hidCurrSel_BannerID");

            Literal objRDO_BannerID = (Literal)e.Row.FindControl("ltrRDO_Banner");
            ImageButton objDelImage = (ImageButton)e.Row.FindControl("ImgDelete");

            if (objVDisp.Value.ToString() == "1")
            {
                objDelImage.Visible = true;
            }
            else
            {
                objDelImage.Visible = false;
            }

            if ((objLtrBannerImg != null) && (objImageName.Value != ""))
            {
                string tmpBannerImageName = objImageName.Value;
                string Alt_BannerImgName = objImageActualName.Value;
                objLtrBannerImgID.Text = Alt_BannerImgName.Substring(0, Alt_BannerImgName.IndexOf("."));
                objLtrBannerImgID.Text = objLtrBannerImgID.Text + "<br/>" + "<font class='FontNote'>(" + objCategoryName.Value + ")</font>";
                if (Session["CurrSel_BannerID"].ToString() == row_imageID.Value)
                {
                    objRDO_BannerID.Text = string.Format("<input id='rdoBannerID' name='Grp_BannerID' checked value='{0}' type='radio'/>", row_imageID.Value);
                }
                else{
                    objRDO_BannerID.Text = string.Format("<input id='rdoBannerID' name='Grp_BannerID' value='{0}' type='radio'/>", row_imageID.Value);
                }

                
                if (row_userId.Value == "101")
                {
                    if (tmpBannerImageName.ToString().Contains(".swf"))
                    {

                        objLtrBannerImg.Text = String.Format("<object width='800' height='200'><param name='movie' value='{0}'><embed src='{0}' width='800' height='200'></embed></object>", ImageFolder + objImageName.Value);
                    }
                    else
                    {

                        objLtrBannerImg.Text = String.Format("<img class='SelBannerCss' src='{0}'>", ImageFolder + objImageName.Value);
                    }
                }
                else
                {
                    if (tmpBannerImageName.ToString().Contains(".swf"))
                    {

                        objLtrBannerImg.Text = String.Format("<object width='800' height='200'><param name='movie' value='{0}'><embed src='{0}' width='800' height='200'></embed></object>", ImageFolder + objImageName.Value); 
                    }
                    else
                    {

                        objLtrBannerImg.Text = String.Format("<img class='SelBannerCss' src='{0}'>", ImageFolder + objImageName.Value);
                    }                  
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {        
        string strBannerImgFileName = string.Empty;
        string strBanner_ImgActual_FileName = string.Empty;
        string strBannerImgFileURL = string.Empty;

        int Banner_ImgType;
        string Banner_ImgPath = string.Empty;
        string Banner_ImgName = string.Empty;
        string Banner_ImgActualName = string.Empty;
        bool User_BannerTicked;

        string selBannerImg = string.Empty;

        Random rnum = new Random();

        //Check to see if the user has ticked Display at Website for Banner
           User_BannerTicked = chkActive_Banner.Checked;


        if (ViewState["BannerWasUploaded"].ToString() == "true")
        {
            Banner_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.BannerImage);
            Banner_ImgPath = @"\ImageRepository\";
            Banner_ImgName = ViewState["Bnr_FileImageName"].ToString();
            Banner_ImgActualName = ViewState["Bnr_ActualFileName"].ToString();

            selBannerImg = "0";

        }
        else
        {

            Banner_ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.LogoImage);
            Banner_ImgPath = @"\ImageRepository\";
            Banner_ImgName = strBannerImgFileName;
            Banner_ImgActualName = strBanner_ImgActual_FileName;

            selBannerImg = Request.Form["Grp_BannerID"];
        }

        


        strSQL = "EXEC [usp_Settings_Update_Banner] " + Convert.ToInt32(Session["UserID"]) + "," + Convert.ToInt32(selBannerImg) + "," + 
                    Banner_ImgType + ",'" + Banner_ImgPath + "','" + Banner_ImgName + "','" + Banner_ImgActualName + "'," + User_BannerTicked;

       

        //strSQL = "Update tblHomePageSettings Set ImageID_Banner = " + selBannerImg +
        //         ", ModifiedBy = " + Convert.ToInt32(Session["UserID"]) + "Where userId = " + Convert.ToInt32(Session["UserID"]);


        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally{
            dbConn.Close();
        }

        Response.Redirect("Ad_BannerSettings.aspx?qBannerUp=CHANGED");


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
            FileWasUpload = false;
            ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Banner.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

            FU_Banner.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessageBanner.Text = "Image uploaded : " + FU_Banner.FileName + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>"; ;
            FileWasUpload = true;
            ViewState["Bnr_FileImageUrl"] = ImgFileUrl;
            ViewState["Bnr_FileImageName"] = ImgFileName;
            ViewState["Bnr_ActualFileName"] = FU_Banner.FileName;
            ViewState["BannerWasUploaded"] = "true";




            strSQL = "EXEC [usp_Settings_Update_Banner] " + Convert.ToInt32(Session["UserID"]) + "," + Convert.ToInt32(Session["CurrSel_BannerID"]) + "," +
                   Convert.ToInt16(GlobalVar.ImageTypeEnums.BannerImage) + ",'" + @"\ImageRepository\" + "','" + ImgFileName + "','" + FU_Banner.FileName + "'," + chkActive_Banner.Checked;


            dbConn = new SqlConnection(GlobalVar.GetDbConnString);

            try
            {
                dbConn.Open();
                dbCmd = new SqlCommand(strSQL, dbConn);
                dbCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally{
                dbConn.Close();
            }

            Response.Redirect("Ad_BannerSettings.aspx?qBannerUp=TRUE");

        }


    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int SelIndustryID = Convert.ToInt16(ddlCategory.SelectedValue);
        ViewState["FilterIndustryID"] = SelIndustryID;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["FilterIndustryID"].ToString());

    }

}
