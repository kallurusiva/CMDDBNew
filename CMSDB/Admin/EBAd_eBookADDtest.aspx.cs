using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Admin_EBAd_eBookADDtest : System.Web.UI.Page
{

    #region Global Variables

    long MaxEbookFileSize = 21214400;    // 20MB
    long MaxEbookImageSize = 2097152;   // 2MB

    bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    bool EbookFileUploaded = false;
    String EbookFileName = String.Empty;
    String EbookFileUrl = String.Empty;

    int vReplySmstype = 0;

    //CMSv3.Entities.Ebook objEbEntity = new CMSv3.Entities.Ebook();
    EbookEntities objEbEntity = new EbookEntities();
    newDBS objNewDB = new newDBS();
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    decimal CreditBalance = 0;
    int vCreditBalance = 0;
    int vCheck = 0;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds;

        #region session check
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        //Response.Redirect("TempMaintenance.aspx");
        //Response.End();
        ImgFileUploaded = Getbool();
        EbookFileUploaded = Getbool();

        txtDiscount.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtDiscountedPrice.Attributes.Add("readonly", "readonly");

        if (!IsPostBack)
        {
            getPackageType();
            ViewState["CheckedUniCode"] = vCheck;
            txtPrice.Text = "10";
            txtDiscount.Text = "50";
            txtDiscountedPrice.Text = "5";
            txtPrepaidPrice.Text = "5";
            txtSMSmessage.Text = "Thank you for your purchase. An ebook is being sent to you,Pls check your email Inbox & Bulk folder as sometime it may go the latter.";
            string vEmailMessageText = string.Empty;

            vEmailMessageText += "Dear Customer," + Environment.NewLine + Environment.NewLine;
            vEmailMessageText += "Thank you for your Order." + Environment.NewLine + Environment.NewLine;
            vEmailMessageText += "The Ebook you purchased is attached. Please download it for reading purpose." + Environment.NewLine + Environment.NewLine;
            vEmailMessageText += "Best Regards," + Environment.NewLine;

            txtEmailMessage.Text = vEmailMessageText;

            ViewState["FileImageUrl"] = "";
            ViewState["FileImageName"] = "";
            ViewState["FileImageUploaded"] = false;

            ViewState["FileEbookUrl"] = "";
            ViewState["FileEbookName"] = "";
            ViewState["FileEbookUploaded"] = false;
            ViewState["Currency"] = "";

            newDBS ndbs = new newDBS();
            DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["UserID"]).ToString());
            if (dst.Tables[0].Rows.Count > 0)
            {
                ViewState["Currency"] = dst.Tables[0].Rows[0]["Currency"].ToString();
                urCurrency.Text = ViewState["Currency"].ToString();
            }

            RenderMainCategories();

            if (Session["SmsCreditBalance"] != null)
            {
                CreditBalance = Convert.ToDecimal(Session["SmsCreditBalance"].ToString());
            }
            else
            {
                ds = objBALebook.EbAd_SmsCreditBalance_Retrieve(Convert.ToInt32(Session["MERID"].ToString()));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    CreditBalance = Convert.ToDecimal(dr["BalanceCredit"].ToString());
                }
            }

            vCreditBalance = (int)Math.Ceiling(CreditBalance);

            Session["UserCreditBalance"] = vCreditBalance;

            //..Validation: Associate User (AV) can add max. upto 20 ebooks only. (PV) unlimited. 

            String tmpUserPkgType = Session["EbUserPackageType"].ToString();

            decimal totCount = 0;
            decimal packagetype = 0;
            string packageName = string.Empty;

            newDBS objDBS = new newDBS();
            DataSet cds = objDBS.ebook_getEBookcountTotalUser(Session["UserID"].ToString());
            if (cds.Tables[0].Rows.Count > 0)
            {
                DataRow cdr = cds.Tables[0].Rows[0];
                totCount = Convert.ToDecimal(cdr["uCount"].ToString());
                packagetype = Convert.ToDecimal(cdr["packagetype"].ToString());
                packageName = cdr["packageName"].ToString();
            }

            if (packagetype < 3 && totCount > 20)
            {
                String prevPage = Request.UrlReferrer.ToString();
                String vMessage = "Maximum Allow for Own Ebook upload has been reached. \\nPlease upgrade accordingly \\n1) Corporate – Max 20\\n2) International – Max 50\\n3) Venchise – Unlimited";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + vMessage + "'); window.location='" + Request.ApplicationPath + "Admin/EBAd_DashBoard.aspx';", true);
                btnSave.Enabled = false;
            }
            else if ((packagetype > 2 && packagetype < 5) && totCount > 50)
            {
                String prevPage = Request.UrlReferrer.ToString();
                String vMessage = "Maximum Allow for Own Ebook upload has been reached. \\nPlease upgrade accordingly \\n1) Corporate – Max 20\\n2) International – Max 50\\n3) Venchise – Unlimited";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + vMessage + "'); window.location='" + Request.ApplicationPath + "Admin/EBAd_DashBoard.aspx';", true);
                btnSave.Enabled = false;
            }

            //if (tmpUserPkgType == "1")  // if AV user
            //{
            //    int tmpBookCount = objBALebook.EB_GetEbookCountForUser(Convert.ToInt32(Session["MERID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()));

            //    if (tmpBookCount >= 100)
            //    {
            //        String prevPage = Request.UrlReferrer.ToString();
            //        String vMessage = "As an Associate User, you are entitled to ADD max. upto 20 ebooks only. \\n\\nIn order to ADD ebook delete an existing ebook or Upgrade!.";
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + vMessage + "'); window.location='" + Request.ApplicationPath + "Admin/EBAd_DashBoard.aspx';", true);
            //        btnSave.Enabled = false;
            //    }
            //}
            MaintainScrollPositionOnPostBack = true;
        }
    }

    private static bool Getbool()
    {
        return false;
    }

    protected void RenderMainCategories()
    {
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        DataSet ds = objBALebook.EBook_Get_MainCategories(vUserID, "00");

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlMainCategory.DataSource = ds;
            ddlMainCategory.DataTextField = "ddlCatName";
            ddlMainCategory.DataValueField = "CatMainID";
            ddlMainCategory.DataBind();

            ddlMainCategory.Items.Insert(0, new ListItem("Select Main Category", "0"));
        }
        else
        {
            CommonFunctions.AlertMessageAndRedirect("Please Create MyCategory before adding new book", "EBAd_UserCategoryMain.aspx");
        }
    }

    protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int vMainCatID = Convert.ToInt32(ddlMainCategory.SelectedValue);
        LoadCategories(vMainCatID);
    }

    protected void LoadCategories(int vMainCatID)
    {
        String strSearch = " AND MCAT.CatMainID = " + vMainCatID;

        DataSet ds;

        ds = objBALebook.Category_Load_ByUserID(Convert.ToInt32(Session["UserID"]), strSearch);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCategory.DataSource = ds;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Sub Category", "0"));
        }
        else
        {
            CommonFunctions.AlertMessageAndRedirect("Please Create SubCategory before adding new book", "EBAd_UserCategoryList.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string cRate = "0";
        string currency = "";
        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["UserID"]).ToString());
        if (dst.Tables[0].Rows.Count > 0)
        {
            cRate = dst.Tables[0].Rows[0]["rate"].ToString();
            currency = dst.Tables[0].Rows[0]["Currency"].ToString();
        }

        string cErrorid = "0";
        string cRetMessage = "";
        DataSet cst = ndbs.checkPrice_Addbooks(currency.ToString(), txtDiscountedPrice.Text.ToString(), cRate.ToString());
        if (cst.Tables[0].Rows.Count > 0)
        {
            cErrorid = cst.Tables[0].Rows[0]["errorid"].ToString();
            cRetMessage = cst.Tables[0].Rows[0]["retMessage"].ToString();
        }

        if (cErrorid == "1")
        {
            CommonFunctions.AlertMessage(cRetMessage.ToString());
        }
        else
        {
            int tCreditBalance = Convert.ToInt32(Session["UserCreditBalance"].ToString());
            int vMerchantID = 0;

            if (Session["MERID"] != null)
                vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
            else
                Response.Redirect("~/SessionExpireEbook.aspx");

            HandleFileUploads();
            //Checking for UniCode characters in the Reply SMS 

            String vReplySMS = CommonFunctions.ConvertToPlainText(txtSMSmessage.Text);
            bool isReplyUniCode = CommonFunctions.IsUnicode(vReplySMS);

            if (isReplyUniCode)
            {
                CommonFunctions.AlertMessage("Detected Unicode characters in the Reply SMS. Please confirm and check before saving the book. \\nThe Limit for unicode characters is Max. 50");
                vCheck = Convert.ToInt16(ViewState["CheckedUniCode"].ToString());
                vCheck++;

                if (vCheck > 2)
                    ViewState["CheckedUniCode"] = vCheck;
                else
                {
                    txtSMSmessage.Focus();
                    btnSave.Visible = false;
                    btnSaveCont.Visible = true;
                    return;
                }
            }
            else
            {
                //CommonFunctions.AlertMessage("saving book");
                fneBookSave();
            }
        }
    }

    protected void fneBookSave()
    {
        int tCreditBalance = Convert.ToInt32(Session["UserCreditBalance"].ToString());
        int vMerchantID = 0;

        if (Session["MERID"] != null)
            vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
        else
            Response.Redirect("~/SessionExpireEbook.aspx");


        HandleFileUploads();
        FileUpload_OnserverValidate();

        if (Page.IsValid)
        {
            //Book Details...
            //==================================
            objEbEntity.BookName = txtBookName.Text.Trim();
            objEbEntity.BookTitle = txtBookTitle.Text.Trim();
            objEbEntity.catID = Convert.ToInt32(ddlCategory.SelectedValue);
            objEbEntity.catMainID = Convert.ToInt32(ddlMainCategory.SelectedValue);

            objEbEntity.categoryName = ddlCategory.SelectedItem.Text;
            objEbEntity.BookRefID = "BookByUser";

            objEbEntity.isDisplay = Convert.ToBoolean(rdoDisplayatWebsite.SelectedValue);
            objEbEntity.isBuySMS = Convert.ToBoolean(rdoBuySMS.SelectedValue);
            objEbEntity.isBuyPayPal = Convert.ToBoolean(rdoBuyPayPal.SelectedValue);
            objEbEntity.isPrepaid = false;
            //ebEntity.isFeatured = Convert.ToBoolean(rdoFeatured.SelectedValue);
            objEbEntity.isFeatured = false;
            objEbEntity.isBestSeller = false;
            objEbEntity.LaunchStatus = Convert.ToInt16(rdoLaunchStatus.SelectedValue);

            objEbEntity.Price = Convert.ToDecimal(txtPrice.SelectedItem.Value);
            objEbEntity.Discount = Convert.ToDecimal(txtDiscount.SelectedItem.Value);
            objEbEntity.PrepaidPrice = Convert.ToDecimal(txtPrepaidPrice.Text);

            objEbEntity.Description = txtDescription.Text;

            objEbEntity.CreatedBy = Convert.ToInt32(Session["UserID"]);

            objEbEntity.CCmobile1 = txtCCMobile1.Text.Trim();
            objEbEntity.CCmobile2 = txtCCMobile2.Text.Trim();
            objEbEntity.CCmobile3 = txtCCMobile3.Text.Trim();

            objEbEntity.MerchantID = vMerchantID;

            // Book Image 
            //==================
            if (ViewState["FileImageUploaded"].ToString() == "True")
            {
                objEbEntity.ImgFileName = ViewState["FileImageName"].ToString();
                objEbEntity.ImgFilePath = ViewState["FileImageUrl"].ToString();
            }
            else
            {
                objEbEntity.ImgFileName = ViewState["FileImageName"].ToString();
                objEbEntity.ImgFilePath = ViewState["FileImageUrl"].ToString();
            }

            // Ebook File 
            if (ViewState["FileEbookUploaded"].ToString() == "True")
            {
                objEbEntity.EbookFileName = ViewState["FileEbookName"].ToString();
                objEbEntity.EbookFilePath = ViewState["FileEbookUrl"].ToString();
            }
            else
            {
                //  return;
                objEbEntity.EbookFileName = ViewState["FileEbookName"].ToString();
                objEbEntity.EbookFilePath = ViewState["FileEbookUrl"].ToString();
            }

            // Reply Info 
            objEbEntity.ReplySubject = txtSubject.Text.Trim();
            //objEbEntity.SenderEmailID = txtSenderEmailID.Text.Trim();
            objEbEntity.SenderEmailID = "noreply@ebooksmsdelivery.com";

            String vReplySMStext = CommonFunctions.ConvertToAscii(txtSMSmessage.Text.Trim());
            string videoLink = txtVideoLink.Text.Trim();

            objEbEntity.ReplySMS = txtSMSmessage.Text.Trim();
            objEbEntity.ReplyEmail = txtEmailMessage.Text.Trim();

            objEbEntity.ReplySMStype = vReplySmstype;
            objEbEntity.ReplySMSch = videoLink;

            int aStatus = objNewDB.EBook_AddBook_ByUser(objEbEntity);

            if (aStatus == 2)
            {
                CommonFunctions.AlertMessage("A Book by this name already exists. Please Check.");
            }
            else if (aStatus == 1)
            {
                CommonFunctions.AlertMessage("eBook Added Successfully.");
                Response.Redirect("EBAd_BookListing.aspx?qStatus=1&qType=1");
            }

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string ImgURL = string.Empty;

        UploadImgCtrl.Dispose();
        UploadEbookFile.Dispose();

        //if the user clicks cancel delete the image from the physical folder. 
        if (ViewState["FileImageUploaded"].ToString() != "")
        {

            if (Convert.ToBoolean(ViewState["FileImageUploaded"].ToString()))
            {
                System.IO.File.Delete(ViewState["FileImageUrl"].ToString() + ViewState["FileImageName"].ToString());
            }
        }

        Server.Transfer("EBAd_BookListing.aspx");
    }

    protected void btnSaveCont_Click(object sender, EventArgs e)
    {
        int tCreditBalance = Convert.ToInt32(Session["UserCreditBalance"].ToString());
        int vMerchantID = 0;

        if (Session["MERID"] != null)
            vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
        else
            Response.Redirect("~/SessionExpireEbook.aspx");

        ////Checking for UniCode characters in the Reply SMS 

        String vReplySMS = CommonFunctions.ConvertToPlainText(txtSMSmessage.Text);
        bool isReplyUniCode = CommonFunctions.IsUnicode(vReplySMS);

        if (isReplyUniCode)
            vReplySmstype = 1;

        if (tCreditBalance > 5)
        {
            HandleFileUploads();

            FileUpload_OnserverValidate();

            if (Page.IsValid)
            {
                //Book Details...
                //==================================
                objEbEntity.BookName = txtBookName.Text.Trim();
                objEbEntity.BookTitle = txtBookTitle.Text.Trim();
                objEbEntity.catID = Convert.ToInt32(ddlCategory.SelectedValue);
                objEbEntity.categoryName = ddlCategory.SelectedItem.Text;
                objEbEntity.BookRefID = "BookByUser";

                objEbEntity.isDisplay = Convert.ToBoolean(rdoDisplayatWebsite.SelectedValue);
                objEbEntity.isBuySMS = Convert.ToBoolean(rdoBuySMS.SelectedValue);
                objEbEntity.isBuyPayPal = Convert.ToBoolean(rdoBuyPayPal.SelectedValue);
                //ebEntity.isFeatured = Convert.ToBoolean(rdoFeatured.SelectedValue);
                objEbEntity.isFeatured = false;
                objEbEntity.isBestSeller = false;
                objEbEntity.LaunchStatus = Convert.ToInt16(rdoLaunchStatus.SelectedValue);
                objEbEntity.isPrepaid = Convert.ToBoolean("0");

                objEbEntity.Price = Convert.ToDecimal(txtPrice.SelectedItem.Value);
                objEbEntity.Discount = Convert.ToDecimal(txtDiscount.SelectedItem.Value);

                objEbEntity.Description = txtDescription.Text;

                objEbEntity.CreatedBy = Convert.ToInt32(Session["UserID"]);


                objEbEntity.CCmobile1 = txtCCMobile1.Text.Trim();
                objEbEntity.CCmobile2 = txtCCMobile2.Text.Trim();
                objEbEntity.CCmobile3 = txtCCMobile3.Text.Trim();

                objEbEntity.MerchantID = vMerchantID;

                // Book Image 
                //==================
                if (ViewState["FileImageUploaded"].ToString() == "True")
                {
                    objEbEntity.ImgFileName = ViewState["FileImageName"].ToString();
                    objEbEntity.ImgFilePath = ViewState["FileImageUrl"].ToString();
                }
                else
                {
                    objEbEntity.ImgFileName = ViewState["FileImageName"].ToString();
                    objEbEntity.ImgFilePath = ViewState["FileImageUrl"].ToString();
                }

                // Ebook File 
                if (ViewState["FileEbookUploaded"].ToString() == "True")
                {
                    objEbEntity.EbookFileName = ViewState["FileEbookName"].ToString();
                    objEbEntity.EbookFilePath = ViewState["FileEbookUrl"].ToString();
                }
                else
                {
                    //  return;
                    objEbEntity.EbookFileName = ViewState["FileEbookName"].ToString();
                    objEbEntity.EbookFilePath = ViewState["FileEbookUrl"].ToString();
                }

                // Reply Info 
                objEbEntity.ReplySubject = txtSubject.Text.Trim();
                //objEbEntity.SenderEmailID = txtSenderEmailID.Text.Trim();
                objEbEntity.SenderEmailID = "noreply@ebooksmsdelivery.com";
                objEbEntity.position = 1;

                String vReplySMStext = CommonFunctions.ConvertToAscii(txtSMSmessage.Text.Trim());

                objEbEntity.ReplySMS = txtSMSmessage.Text.Trim();
                objEbEntity.ReplyEmail = txtEmailMessage.Text.Trim();

                objEbEntity.ReplySMStype = vReplySmstype;
                objEbEntity.ReplySMSch = vReplySMStext;

                int aStatus = objNewDB.EBook_AddBook_ByUser(objEbEntity);

                if (aStatus == 2)
                {
                    CommonFunctions.AlertMessage("A Book by this name already exists. Please Check.");
                }
                else if (aStatus == 1)
                {
                    CommonFunctions.AlertMessage("eBook Added Successfully..");
                    int dedStatus = objBALebook.EbAd_SmsCreditBalance_Deduct(Convert.ToInt32(Session["MERID"].ToString()), 5);
                    Response.Redirect("EBAd_BookListing.aspx?qStatus=1&qType=1");
                }
            }
        }
        else
        {
            String vAlertMsg = @"Sorry !!. Minimum of 5 Sms Credits are required to Download an Ebook. " + " \\n\\nYour SMS Credit Balance : " + tCreditBalance.ToString() + "\\n\\nPlease Top Up.";
            CommonFunctions.AlertMessage(vAlertMsg);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
        }
    }

    protected void HandleFileUploads()
    {
        // FOR IMAGE 

        // store the FileUpload object in Session. 
        // "FileUpload1" is the ID of your FileUpload control
        // This condition occurs for first time you upload a file
        if (Session["FileUpload1"] == null && UploadImgCtrl.HasFile)
        {
            Session["FileUpload1"] = UploadImgCtrl;
            lblErrorImg.Text = UploadImgCtrl.FileName; // get the name  
        }
        // This condition will occur on next postbacks        
        else if (Session["FileUpload1"] != null && (!UploadImgCtrl.HasFile))
        {
            UploadImgCtrl = (FileUpload)Session["FileUpload1"];
            lblErrorImg.Text = UploadImgCtrl.FileName;
        }
        //  when Session will have File but user want to change the file 
        // i.e. wants to upload a new file using same FileUpload control
        // so update the session to have the newly uploaded file
        else if (UploadImgCtrl.HasFile)
        {
            Session["FileUpload1"] = UploadImgCtrl;
            lblErrorImg.Text = UploadImgCtrl.FileName;
        }

        // FOR EBOOK document. 

        if (Session["BookUpload1"] == null && UploadEbookFile.HasFile)
        {
            Session["BookUpload1"] = UploadEbookFile;
            lblErrorFile.Text = UploadEbookFile.FileName; // get the name  
        }
        else if (Session["BookUpload1"] != null && (!UploadEbookFile.HasFile))
        {
            UploadEbookFile = (FileUpload)Session["BookUpload1"];
            lblErrorFile.Text = UploadEbookFile.FileName;
        }
        else if (UploadEbookFile.HasFile)
        {
            Session["BookUpload1"] = UploadEbookFile;
            lblErrorFile.Text = UploadEbookFile.FileName;
        }
    }

    protected void FileUpload_OnserverValidate()
    {
        //Image Upload

        Random rnum = new Random();

        String pfile = UploadImgCtrl.PostedFile.ToString();

        if (UploadImgCtrl.HasFile)
        {

            int iImageSize1 = UploadImgCtrl.PostedFile.ContentLength;
            if (iImageSize1 > 0)
            {
                if (iImageSize1 < MaxEbookImageSize)
                {
                    ImgFileUploaded = false;
                    //Get the name of the file
                    string fileName = UploadImgCtrl.FileName;

                    ImgFileName = Convert.ToString(rnum.Next(9999)) + "_" + UploadImgCtrl.FileName;

                    String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
                    //instead of server.mapPath set the path in web.config file and use that path.
                    ImgFileUrl = Server.MapPath("~") + tmpImageFolder;

                    UploadImgCtrl.SaveAs(ImgFileUrl + ImgFileName);
                    //lblUpMessage.Text = "Image uploaded : " + UploadImgCtrl.FileName;

                    ImgFileUploaded = true;
                    ViewState["FileImageUrl"] = ImgFileUrl;
                    ViewState["FileImageName"] = ImgFileName;
                    ViewState["FileImageUploaded"] = true;
                }
                else
                {
                    UploadImgCtrl.Focus();
                    CustomValidator_BookImage.IsValid = false;

                    lblErrorImg.Text = "Ebook Image Size cannot exceed 2MB. Please try again.";
                    CommonFunctions.AlertMessage("Ebook Image Size cannot exceed 2MB. Please try again.");
                    return;
                }
            }
        }
        else
        {
            UploadImgCtrl.Focus();
            CustomValidator_BookImage.IsValid = false;
            lblErrorImg.Text = "Cannot save eBook without a Book Image. Please Upload";
            return;
        }

        // rnum = new Random();

        if (UploadEbookFile.HasFile)
        {
            String ebOrgFileName = UploadEbookFile.FileName;
            int iFileSize1 = UploadEbookFile.PostedFile.ContentLength;
            if (iFileSize1 > 0)
            {
                if (iFileSize1 < MaxEbookFileSize)
                {
                    //Get the name of the file
                    string fileName = UploadEbookFile.FileName;
                    char fileNameC = fileName.Last();
                    string filenamepart = fileName.Substring(fileName.Length - 5);
                    if (fileName.Length > 50)
                    {
                        UploadEbookFile.Focus();
                        CustomVdr_eBookFile.IsValid = false;
                        lblErrorFile.Text = "Ebook File Name Length cannot exceed 50 Characters. Please try again.";
                        CommonFunctions.AlertMessage("Ebook File Name Length cannot exceed 50 Characters. Please try again.");
                        return;
                    }
                    //else if (filenamepart.ToString().ToUpper() == "..PDF")
                    //{
                    //    UploadEbookFile.Focus();
                    //    CustomVdr_eBookFile.IsValid = false;
                    //    lblErrorFile.Text = "Ebook File Name cannot end with DOT. Please try again.";
                    //    CommonFunctions.AlertMessage("Ebook File Name Length cannot end with DOT. Please try again.");
                    //    return;
                    //}
                    else
                    {
                        if (fileName.Length > 50)
                        {
                            UploadEbookFile.Focus();
                            CustomVdr_eBookFile.IsValid = false;
                            lblErrorFile.Text = "Ebook File Name Length cannot exceed 50 Characters. Please try again.";
                            CommonFunctions.AlertMessage("Ebook File Name Length cannot exceed 50 Characters. Please try again.");
                            return;
                        }
                        //else if (filenamepart.ToString().ToUpper() == "..PDF")
                        //{
                        //    UploadEbookFile.Focus();
                        //    CustomVdr_eBookFile.IsValid = false;
                        //    lblErrorFile.Text = "Ebook File Name cannot end with DOT. Please try again.";
                        //    CommonFunctions.AlertMessage("Ebook File Name Length cannot end with DOT. Please try again.");
                        //    return;
                        //}
                        ImgFileUploaded = false;
                        EbookFileName = Convert.ToString(rnum.Next(9999)) + "_" + UploadEbookFile.FileName;
                        String tmpEbfileFolder = @"E:\webs\ebooks\documentrepository\eBooks\";
                        EbookFileUrl = tmpEbfileFolder;
                        UploadEbookFile.SaveAs(EbookFileUrl + EbookFileName);
                        ImgFileUploaded = true;
                        ViewState["FileEbookUrl"] = EbookFileUrl;
                        ViewState["FileEbookName"] = EbookFileName;
                        ViewState["FileEbookUploaded"] = true;
                    }
                }
                else
                {
                    UploadEbookFile.Focus();
                    CustomVdr_eBookFile.IsValid = false;
                    lblErrorFile.Text = "Ebook File Size cannot exceed 20MB. Please try again.";
                    CommonFunctions.AlertMessage("Ebook File Size cannot exceed 20MB. Please try again.");
                    return;
                }
            }
        }
        else
        {
            UploadEbookFile.Focus();
            CustomVdr_eBookFile.IsValid = false;
            lblErrorFile.Text = "Cannot save eBook without a Book File. Please Upload";
            return;
        }
    }

    protected void CustomVdr_eBookFile_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //30720 = 15 KB  ( 1024 * 30 )
        //Get the name of the file
        string fileName = UploadImgCtrl.FileName;
        int fileSize = UploadEbookFile.PostedFile.ContentLength;
        char fileNameC = fileName.Last();

        if (UploadEbookFile.FileBytes.Length > MaxEbookFileSize)
        {
            lblErrorFile.Text = "Filesize of Ebook is too large. Maximum file size permitted is 20MB";
            CommonFunctions.AlertMessage("Ebook File Size cannot be greater then 20MB.");
            args.IsValid = false;
            return;
        }
        else if (fileName.Length > 50)
        {
            lblErrorFile.Text = "File Name Length of Ebook is too large. Maximum file name length size permitted is 50 Characters.";
            CommonFunctions.AlertMessage("Ebook File Name Length cannot be greater then 50 Characters.");
            args.IsValid = false;
            return;
        }
        ////else if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["EbookFileFolder"].ToString() + fileName)))
        ////{  //Does the file already exist?
        ////        lblUpMessage2.Text = "A file with the name <b>" + fileName + "</b> already exists on the server.";
        ////        args.IsValid = false; 
        ////        return;
        //// }
        else
        {
            args.IsValid = true;
        }
    }

    protected void CustomVdr_eBookImage_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //30720 = 15 KB  ( 1024 * 30 )
        //Get the name of the file
        string fileName = UploadImgCtrl.FileName;
        int fileSize = UploadImgCtrl.PostedFile.ContentLength;

        if (UploadImgCtrl.FileBytes.Length > MaxEbookImageSize)
        {
            lblErrorImg.Text = "Filesize of image is too large. Maximum file size permitted is 2MB";
            CommonFunctions.AlertMessage("Ebook Image Size cannot be greater then 2MB.");
            args.IsValid = false;
            return;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        decimal vPrice = 0;
        decimal vDiscount = 0;
        decimal vDisPrice = 0;

        vPrice = Convert.ToDecimal(txtPrice.SelectedItem.Value);
        vDiscount = Convert.ToDecimal(txtDiscount.SelectedItem.Value);

        if ((vPrice != 0) && (vDiscount != 0))
        {
            vDisPrice = vPrice - ((vPrice * vDiscount) / 100);
        }
        txtDiscountedPrice.Text = vDisPrice.ToString();
    }

    protected void txtPrice_TextChanged(object sender, EventArgs e)
    {
        decimal vPrice = 0;
        decimal vDiscount = 0;
        decimal vDisPrice = 0;

        vPrice = Convert.ToDecimal(txtPrice.SelectedItem.Value);
        vDiscount = Convert.ToDecimal(txtDiscount.SelectedItem.Value);
        if ((vPrice != 0) && (vDiscount != 0))
        {
            vDisPrice = vPrice - ((vPrice * vDiscount) / 100);
        }
        txtDiscountedPrice.Text = vDisPrice.ToString();
    }

    protected void AsyncFU_Image_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
    }

    protected void AsyncFU_File_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
    }

    protected void txtBookName_TextChanged(object sender, EventArgs e)
    {
        txtSubject.Text = "Ebook: " + txtBookName.Text.Trim();
    }

    protected void getPackageType()
    {
        if (Session["MobileLoginID"] != null)
        {
            String mUserId = Session["MobileLoginID"].ToString().Replace("EB", "");
            string strSQL = "EXEC eSMS.dbo.uspT_getUserPackageType " + mUserId;
            SqlConnection dbConn;
            SqlCommand dbCmd;
            SqlDataReader dbReader;
            dbConn = new SqlConnection(GlobalVar.GetDbConnString);

            try
            {
                dbConn.Open();
                dbCmd = new SqlCommand(strSQL, dbConn);
                dbReader = dbCmd.ExecuteReader();

                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {
                        string mlmStatusPack = dbReader["mlmStatus"].ToString();
                        if (mlmStatusPack == "0")
                        {
                            CommonFunctions.AlertMessageAndRedirect("Only Basic - Venchise Partners can upload own ebooks to own bookstore.", "EBAd_Dashboard.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                dbConn.Close();
            }
        }
    }

    protected void txtPrice_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal vPrice = 0;
        decimal vDiscount = 0;
        decimal vDisPrice = 0;

        vPrice = Convert.ToDecimal(txtPrice.SelectedItem.Value);
        vDiscount = Convert.ToDecimal(txtDiscount.SelectedItem.Value);
        if ((vPrice != 0) && (vDiscount != 0))
        {
            vDisPrice = vPrice - ((vPrice * vDiscount) / 100);
        }
        txtDiscountedPrice.Text = vDisPrice.ToString();
    }

    protected void txtDiscount_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal vPrice = 0;
        decimal vDiscount = 0;
        decimal vDisPrice = 0;

        vPrice = Convert.ToDecimal(txtPrice.SelectedItem.Value);
        vDiscount = Convert.ToDecimal(txtDiscount.SelectedItem.Value);

        if ((vPrice != 0) && (vDiscount != 0))
        {
            vDisPrice = vPrice - ((vPrice * vDiscount) / 100);
        }
        txtDiscountedPrice.Text = vDisPrice.ToString();
    }

}