using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_eBookEdit2 : System.Web.UI.Page
{
    long MaxEbookFileSize = 21214400;    // 20MB
    long MaxEbookImageSize = 2097152;   // 2MB

    bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    bool EbookFileUploaded = false;
    String EbookFileName = String.Empty;
    String EbookFileUrl = String.Empty;

    DataSet ds; 

    //CMSv3.Entities.Ebook objEbEntity = new CMSv3.Entities.Ebook();
    EbookEntities objEbEntity = new EbookEntities();
    newDBS objNewDB = new newDBS();
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion         

        ImgFileUploaded = Getbool();
        EbookFileUploaded = Getbool();

        //Response.Redirect("TempMaintenance.aspx");
        //Response.End();

        //txtPrice.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtDiscount.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtDiscountedPrice.Attributes.Add("readonly", "readonly");
        MaxEbookFileSize = 21214400;    // 20MB
        MaxEbookImageSize = 2097152;   // 2MB
        ImgFileUploaded = false;

        if (!IsPostBack)
        {
            String qBookID = Server.UrlDecode(Decrypt(Request.QueryString["qBID"].ToString()));
            
            ViewState["qBookID"] = qBookID;

            String qUserType = Request.QueryString["qUserType"].ToString();
            ViewState["UserType"] = qUserType; 

            ViewState["FileImageUrl"] = "";
            ViewState["FileImageName"] = "";
            ViewState["FileImageUploaded"] = false;

            ViewState["FileEbookUrl"] = "";
            ViewState["FileEbookName"] = "";
            ViewState["FileEbookUploaded"] = false;
            ViewState["Currency"] = "";
            ViewState["userRate"] = "";

            newDBS ndbs = new newDBS();
            DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["UserID"]).ToString());
            if (dst.Tables[0].Rows.Count > 0)
            {
                ViewState["Currency"] = dst.Tables[0].Rows[0]["Currency"].ToString();
                urCurrency.Text = ViewState["Currency"].ToString();
                ViewState["userRate"] = dst.Tables[0].Rows[0]["rate"].ToString();
            }

            LoadBookDetails(ViewState["qBookID"].ToString()); 
            MaintainScrollPositionOnPostBack = true;
            urPrice.Text = (Convert.ToDecimal(txtDiscountedPrice.Text) * Convert.ToDecimal(ViewState["userRate"].ToString())).ToString();
            urPrice.Text = Math.Round(Convert.ToDecimal(urPrice.Text.ToString()), 2).ToString();
        }
    }

    protected void LoadBookDetails(string vBookId)
    {
        if (vBookId != "")
        {
            ds = objBALebook.Ebook_Edit(vBookId);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow bkRow = ds.Tables[0].Rows[0];

                txtBookName.Text = bkRow["BookName"].ToString();
                txtBookTitle.Text = bkRow["Title"].ToString();

                String vDescription = bkRow["Description"].ToString();
                txtDescription.Text = vDescription.Replace("<br/>", Environment.NewLine);

                txtPrice.Text = bkRow["Price"].ToString().Replace(".00", "");
                txtDiscount.Text = bkRow["Discount"].ToString();

                decimal vPrice = Convert.ToDecimal(txtPrice.Text);
                decimal vDiscount = Convert.ToDecimal(txtDiscount.Text);

                decimal vDiscPrice = (vPrice - ((vPrice * vDiscount) / 100));

                txtDiscountedPrice.Text = vDiscPrice.ToString();
                txtPrepaidPrice.Text = bkRow["PrepaidPrice"].ToString();
                txtVideoLink.Text = bkRow["videolink"].ToString();

                //chkActive.Checked = Convert.ToBoolean(drow["Active"].ToString());
                rdoDisplayatWebsite.SelectedValue = Convert.ToBoolean(bkRow["isDisplay"].ToString()).ToString();
                // rdoFeatured.SelectedValue = Convert.ToBoolean(bkRow["isFeatured"].ToString()).ToString();
                rdoBuySMS.SelectedValue = Convert.ToBoolean(bkRow["AllowSMSbuy"].ToString()).ToString();
                rdoBuyPayPal.SelectedValue = Convert.ToBoolean(bkRow["AllowPaypalBuy"].ToString()).ToString();
                //rdoBuyPrepaid.SelectedValue = Convert.ToBoolean(bkRow["IsPrepaid"].ToString()).ToString();

                rdoLaunchStatus.SelectedValue = bkRow["LaunchStatus"].ToString(); 

                String vCatId = bkRow["catID"].ToString();
                String vCatMainId = bkRow["CatMainID"].ToString();

                ViewState["CatMainID"] = vCatMainId;
                ViewState["CatID"] = vCatId;

                RenderMainCategories(vCatMainId);
                LoadCategories(vCatMainId, vCatId);

                //LoadCategories(vCatId);

                ImageBook.ImageUrl = bkRow["ImageFileFullURL"].ToString();
                lblCurrentEbookFile.Text = bkRow["eBookFileName"].ToString();

                ViewState["FileImageUrl"] = bkRow["ImageFilePath"].ToString();
                ViewState["FileImageName"] = bkRow["ImageFileName"].ToString();


                ViewState["FileEbookUrl"] = bkRow["eBookFilePath"].ToString();
                ViewState["FileEbookName"] = bkRow["eBookFileName"].ToString();


                txtSubject.Text = bkRow["eSubject"].ToString();
                //txtSenderEmailID.Text = bkRow["eSenderEmailID"].ToString();
                objEbEntity.SenderEmailID = "noreply@ebooksmsdelivery.com";                

                String vReplyMsg = bkRow["ReplySMS"].ToString();
                //vReplyMsg = CommonFunctions.ConvertHexBytesToString(vReplyMsg);
                //vReplyMsg = CommonFunctions.decodeSMSMessage(vReplyMsg); 
                
                txtSMSmessage.Text = vReplyMsg;
                txtPosition.Text = bkRow["position"].ToString();
                String vEmailMessage = bkRow["eMessage"].ToString();
                txtEmailMessage.Text = vEmailMessage.Replace("<br/>", Environment.NewLine);

                txtCCMobile1.Text = bkRow["Mobile1"].ToString();
                txtCCMobile2.Text = bkRow["Mobile2"].ToString();
                txtCCMobile3.Text = bkRow["Mobile3"].ToString();

                if (txtCCMobile1.Text == "0") txtCCMobile1.Text = "";
                if (txtCCMobile2.Text == "0") txtCCMobile2.Text = "";
                if (txtCCMobile3.Text == "0") txtCCMobile3.Text = "";
            }
        }
    }

    public static string Encrypt(string val)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(val);
        var encBytes = System.Security.Cryptography.ProtectedData.Protect(bytes, new byte[0], System.Security.Cryptography.DataProtectionScope.LocalMachine);
        return Convert.ToBase64String(encBytes);
    }

    public static string Decrypt(string val)
    {
        var bytes = Convert.FromBase64String(val);
        var encBytes = System.Security.Cryptography.ProtectedData.Unprotect(bytes, new byte[0], System.Security.Cryptography.DataProtectionScope.LocalMachine);
        return System.Text.Encoding.UTF8.GetString(encBytes);
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
            FileUpload_OnserverValidate();

            int vMerchantID = 0;

            if (Session["MERID"] != null)
                vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
            else
                Response.Redirect("~/SessionExpireEbook.aspx");


            if (Page.IsValid)
            {
                //Book Details...
                //==================================
                objEbEntity.BookID = ViewState["qBookID"].ToString();
                objEbEntity.BookName = txtBookName.Text.Trim();
                objEbEntity.BookTitle = txtBookTitle.Text.Trim();
                objEbEntity.catMainID = Convert.ToInt32(ddlMainCategory.SelectedValue);
                objEbEntity.catID = Convert.ToInt32(ddlCategory.SelectedValue);
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

                objEbEntity.Description = txtDescription.Text;

                objEbEntity.CreatedBy = Convert.ToInt32(Session["UserID"]);

                objEbEntity.MerchantID = vMerchantID;
                objEbEntity.PrepaidPrice = Convert.ToDecimal(txtPrepaidPrice.Text);

                objEbEntity.CCmobile1 = txtCCMobile1.Text.Trim();
                objEbEntity.CCmobile2 = txtCCMobile2.Text.Trim();
                objEbEntity.CCmobile3 = txtCCMobile3.Text.Trim();

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

                ////Checking for UniCode characters in the Reply SMS 

                String vReplySMS = CommonFunctions.ConvertToPlainText(txtSMSmessage.Text);
                bool isReplyUniCode = CommonFunctions.IsUnicode(vReplySMS);

                int vReplySmstype = 0;
                String vReplySMStext = CommonFunctions.ConvertToAscii(txtSMSmessage.Text.Trim());

                if (isReplyUniCode)
                    vReplySmstype = 1;

                objEbEntity.ReplySMStype = vReplySmstype;
                objEbEntity.ReplySMS = txtSMSmessage.Text.Trim();
                objEbEntity.ReplyEmail = txtEmailMessage.Text.Trim();

                string videoLink = txtVideoLink.Text.Trim();
                objEbEntity.ReplySMSch = videoLink;

                double Num;
                bool isNum = double.TryParse(txtPosition.Text.ToString(), out Num);

                if (isNum)
                {
                    objEbEntity.position = Convert.ToInt32(txtPosition.Text.ToString());
                    int aStatus = objNewDB.EBook_UpdateBook_ByUser(objEbEntity);

                    if (aStatus == 2)
                    {
                        CommonFunctions.AlertMessage("A Book by this name already exists. Please Check.");
                    }
                    else if (aStatus == 1)
                    {
                        CommonFunctions.AlertMessage("eBook Added Successfully");
                        Response.Redirect("EBAd_BookListing.aspx?qStatus=1&qType=" + ViewState["UserType"].ToString());
                    }
                }
                else
                {
                    CommonFunctions.AlertMessage("Position must be Numeric");
                }
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

    protected void RenderMainCategories(string vCatMainID)
    {
        //String strSearch = " AND MCAT.CatMainID = " + vCatMainID;
        DataSet ds;
        String strSearch = "";
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        //DataSet ds = objBALebook.CatMain_Categories(Convert.ToInt32(Session["UserID"]), strSearch);
        if (strSearch=="")
        {
            ds = objBALebook.EBook_Get_MainCategories(vUserID, "0");
        }
        else
        {
            ds = objBALebook.EBook_Get_MainCategories(vUserID, strSearch);
        }        

        ddlMainCategory.DataSource = ds;
        ddlMainCategory.DataTextField = "ddlCatName";
        ddlMainCategory.DataValueField = "CatMainID";
        ddlMainCategory.DataBind();

        ddlMainCategory.Items.Insert(0, new ListItem("Select Main Category", "0"));
        ddlMainCategory.SelectedValue = vCatMainID;
    }

    protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        //...get selected category

        String vMainCatID = ddlMainCategory.SelectedValue;
        LoadCategories(vMainCatID, ViewState["CatID"].ToString());
    }

    protected void LoadCategories(string vCatMainID, string vCatID)
    {
        String strSearch = " AND MCAT.CatMainID = " + vCatMainID;  

        DataSet ds;
        ds = objBALebook.Category_Load_ByUserID(Convert.ToInt32(Session["UserID"]), strSearch);

        ddlCategory.DataSource = ds;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CatID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("Select Sub Category", "0"));        
        
        if (ddlCategory.Items.FindByValue(vCatID) != null)
            ddlCategory.SelectedValue = vCatID;        
    }

    protected void FileUpload_OnserverValidate()
    {
        //Image Upload

        Random rnum = new Random();        
    
        if (UploadImgCtrl.HasFile)
        {
            int iImageSize1 = UploadImgCtrl.PostedFile.ContentLength;
            if (iImageSize1 > 0)
            {
                if (iImageSize1 < MaxEbookImageSize)
                {
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
                    CommonFunctions.AlertMessage( "Ebook Image Size cannot exceed 2MB. Please try again.");
                    return;
                }
            }
        }

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
                        EbookFileName = Convert.ToString(rnum.Next(9999)) + "_" + UploadEbookFile.FileName;
                        String tmpEbfileFolder = @"C:\inetpub\wwwroot\documentrepository\eBooks\";
                        EbookFileUrl = tmpEbfileFolder;
                        UploadEbookFile.SaveAs(EbookFileUrl + EbookFileName);
                        //lblUpMessage.Text = "Image uploaded : " + UploadImgCtrl.FileName;
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
 }

    protected void CustomVdr_eBookFile_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //30720 = 15 KB  ( 1024 * 30 )
        //Get the name of the file
        string fileName = UploadImgCtrl.FileName;
        int fileSize = UploadEbookFile.PostedFile.ContentLength;

        if (UploadEbookFile.FileBytes.Length > MaxEbookFileSize)
        {
            lblErrorFile.Text = "Filesize of Ebook is too large. Maximum file size permitted is 20MB";
            CommonFunctions.AlertMessage("Ebook File Size cannot be greater then 20MB."); 
            args.IsValid = false;
            return;
        }       
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
        urPrice.Text = Convert.ToDecimal(string.Format("{0:0.00}", (vDisPrice * Convert.ToDecimal(ViewState["userRate"].ToString())).ToString())).ToString();
        urPrice.Text = Math.Round(Convert.ToDecimal(urPrice.Text.ToString()), 2).ToString();
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
        urPrice.Text = Convert.ToDecimal(string.Format("{0:0.00}", (vDisPrice * Convert.ToDecimal(ViewState["userRate"].ToString())).ToString())).ToString();
        urPrice.Text = Math.Round(Convert.ToDecimal(urPrice.Text.ToString()), 2).ToString();
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
        urPrice.Text = Convert.ToDecimal(string.Format("{0:0.00}", (vDisPrice * Convert.ToDecimal(ViewState["userRate"].ToString())).ToString())).ToString();
        urPrice.Text = Math.Round(Convert.ToDecimal(urPrice.Text.ToString()), 2).ToString();
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
        urPrice.Text = Convert.ToDecimal(string.Format("{0:0.00}", (vDisPrice * Convert.ToDecimal(ViewState["userRate"].ToString())).ToString())).ToString();
        urPrice.Text = Math.Round(Convert.ToDecimal(urPrice.Text.ToString()), 2).ToString();
    }

}