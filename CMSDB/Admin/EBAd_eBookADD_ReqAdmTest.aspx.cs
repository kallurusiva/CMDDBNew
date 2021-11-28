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
using System.Net;
using System.Text;
using System.IO;

public partial class Admin_EBAd_eBookADD_ReqAdmTest : System.Web.UI.Page
{
    long MaxEbookFileSize = 26214400;    // 25MB
    long MaxEbookImageSize = 2097152;   // 2MB

    bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    bool EbookFileUploaded = false;
    String EbookFileName = String.Empty;
    String EbookFileUrl = String.Empty;

    //int vReplySmstype = 0;

    EbookEntities objEbEntity = new EbookEntities();
    newDBS objNewDB = new newDBS();
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    decimal CreditBalance = 0;
    int vCreditBalance = 0;
    int vCheck = 0;

    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds;

        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        ImgFileUploaded= Getbool();
        EbookFileUploaded = Getbool();

        //txtPrice.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtDiscount.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");

        txtDiscountedPrice.Attributes.Add("readonly", "readonly");
        ImgFileUploaded = false;
        if (!IsPostBack)
        {
            getPackageType();

            ViewState["CheckedUniCode"] = vCheck;
            txtPrice.Text = "2";
            txtDiscount.Text = "10";
            txtDiscountedPrice.Text = "1.8";
            txtPrepaidPrice.Text = "5";

            ViewState["oldBookCode"] = Request.QueryString["TID"].ToString();

            //txtSenderEmailID.Text = "";

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

            RenderMainCategories();
            // LoadCategories();

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

            if (tmpUserPkgType == "1")  // if AV user
            {
                int tmpBookCount = objBALebook.EB_GetEbookCountForUser(Convert.ToInt32(Session["MERID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()));

                if (tmpBookCount >= 100)
                {
                    //CommonFunctions.AlertMessage("As an Associate User, you are entitled to ADD max. upto 20 ebooks only. \\n\\nIn order to ADD ebook delete an existing ebook or Upgrade!.");
                    String prevPage = Request.UrlReferrer.ToString();
                    //CommonFunctions.AlertMessageAndRedirect("aa", prevPage);

                    String vMessage = "As an Associate User, you are entitled to ADD max. upto 20 ebooks only. \\n\\nIn order to ADD ebook delete an existing ebook or Upgrade!.";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + vMessage + "'); window.location='" + Request.ApplicationPath + "Admin/EBAd_DashBoard.aspx';", true);
                    // Response.Redirect(prevPage); 
                    btnSave.Enabled = false;
                }
            }
            MaintainScrollPositionOnPostBack = true;
        }
    }

    protected void RenderMainCategories()
    {
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        DataSet ds = objBALebook.EBook_Get_MainCategories(vUserID, "00");
    }

    protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void LoadCategories(int vMainCatID)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Decimal chkDPrice = Convert.ToDecimal(txtDiscountedPrice.Text);
        if (chkDPrice < 2)
        {
            CommonFunctions.AlertMessage("Net Price must be Minimum USD 2 and Maximum USD 30");
        }
        else if (chkDPrice > 30)
        {
            CommonFunctions.AlertMessage("Net Price must be Minimum USD 2 and Maximum USD 30");
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
                fneBookSave();
            }
        }
    }

    protected void fneBookSave()
    {
        
    }

    protected void btnSaveCont_Click(object sender, EventArgs e)
    {
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string ImgURL = string.Empty;

        UploadImgCtrl.Dispose();
        UploadEbookFile.Dispose();

        if (ViewState["FileImageUploaded"].ToString() != "")
        {
            if (Convert.ToBoolean(ViewState["FileImageUploaded"].ToString()))
            {
                System.IO.File.Delete(ViewState["FileImageUrl"].ToString() + ViewState["FileImageName"].ToString());
            }
        }
        Server.Transfer("EBAd_BookListing_ReqAdm.aspx");
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
                    string fileName = UploadImgCtrl.FileName;

                    ImgFileName = Convert.ToString(rnum.Next(9999)) + "_" + UploadImgCtrl.FileName;

                    //String tmpEbfileFolder = "/DocumentRepository/ReqImages/";
                    //ImgFileUrl = Server.MapPath("~") + tmpEbfileFolder;

                    String tmpImageFolder = @"E:\webs\EBooks\DocumentRepository\ReqImages\";
                    ImgFileUrl = tmpImageFolder;
                    UploadImgCtrl.SaveAs(ImgFileUrl + ImgFileName);

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

        if (UploadEbookFile.HasFile)
        {
            String ebOrgFileName = UploadEbookFile.FileName;

            int iFileSize1 = UploadEbookFile.PostedFile.ContentLength;
            if (iFileSize1 > 0)
            {
                if (iFileSize1 < MaxEbookFileSize)
                {
                    ImgFileUploaded = false;
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
                        String tmpEbfileFolder = @"E:\webs\EBooks\DocumentRepository\ReqEBooks\";
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
                    lblErrorFile.Text = "Ebook File Size cannot exceed 25MB. Please try again.";
                    CommonFunctions.AlertMessage("Ebook File Size cannot exceed 25MB. Please try again.");
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
        string fileName = UploadImgCtrl.FileName;
        int fileSize = UploadEbookFile.PostedFile.ContentLength;

        if (UploadEbookFile.FileBytes.Length > MaxEbookFileSize)
        {
            lblErrorFile.Text = "Filesize of Ebook is too large. Maximum file size permitted is 25MB";
            CommonFunctions.AlertMessage("Ebook File Size cannot be greater then 25MB.");
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


    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string selectedValue = string.Empty;
        foreach (ListItem item in chkChanges.Items)
        {
            if (item.Selected)
            {
                 selectedValue = item.Value;
            }
        }
        Response.Write(selectedValue);

    }
}