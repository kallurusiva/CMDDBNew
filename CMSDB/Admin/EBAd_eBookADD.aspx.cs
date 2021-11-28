using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_eBookADD : System.Web.UI.Page
{

    long MaxEbookFileSize = 5242880;    // 5MB
    long MaxEbookImageSize = 2097152;   // 2MB
    bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;
    bool EbookFileUploaded = false;
    String EbookFileName = String.Empty;
    String EbookFileUrl = String.Empty;
    CMSv3.Entities.Ebook objEbEntity = new CMSv3.Entities.Ebook();
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

        ImgFileUploaded= Getbool();
        EbookFileUploaded = Getbool();

        txtPrice.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtDiscount.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");

        txtDiscountedPrice.Attributes.Add("readonly", "readonly");

        if (!IsPostBack)
        {
            ImgFileUploaded = GetBool();
            txtPrice.Text = "10";
            txtDiscount.Text = "50";
            txtDiscountedPrice.Text = "5";

            txtSenderEmailID.Text = "";

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

            LoadCategories();

            MaintainScrollPositionOnPostBack = true;
        }


    }

    private static bool GetBool()
    {
        return false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

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

            objEbEntity.Price = Convert.ToDecimal(txtPrice.Text);
            objEbEntity.Discount = Convert.ToDecimal(txtDiscount.Text);

            objEbEntity.Description = txtDescription.Text;

            objEbEntity.CreatedBy = Convert.ToInt32(Session["UserID"]);

            // Book Image 
            //==================
            if (ViewState["FileImageUploaded"].ToString() == "True")
            {
                objEbEntity.ImgFileName = ViewState["FileImageName"].ToString();
                objEbEntity.ImgFilePath = ViewState["FileImageUrl"].ToString();
            }
            else
            {
                // return; 

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
            objEbEntity.SenderEmailID = txtSenderEmailID.Text.Trim();
            objEbEntity.ReplySMS = txtSMSmessage.Text.Trim();
            objEbEntity.ReplyEmail = txtEmailMessage.Text.Trim();


            int aStatus = objBALebook.EBook_AddBook_ByUser(objEbEntity);
            AsyncFU_EbFile.ClearAllFilesFromPersistedStore();
            AsyncFU_Image.ClearAllFilesFromPersistedStore(); 

            if (aStatus == 2)
            {
                CommonFunctions.AlertMessage("A Book by this name already exists. Please Check.");
            }
            else if (aStatus == 1)
            {
                CommonFunctions.AlertMessage("eBook Added Successfully");

                Response.Redirect("EBAd_BookListing.aspx?qStatus=1");
            }

        }





    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {


        string ImgURL = string.Empty;
        

        AsyncFU_EbFile.Dispose();
        AsyncFU_Image.Dispose(); 

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



    protected void LoadCategories()
    {

        DataSet ds;

        ds = objBALebook.Category_Load_ByUserID(Convert.ToInt32(Session["UserID"]),""); 

        ddlCategory.DataSource = ds;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CatID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
    }


    protected void FileUpload_OnserverValidate()
    {

        //Image Upload

        Random rnum = new Random();


        if (AsyncFU_Image.HasFile)
        {

            int iImageSize1 = AsyncFU_Image.PostedFile.ContentLength;
            if (iImageSize1 > 0)
            {
                if (iImageSize1 < MaxEbookImageSize)
                {
                    //Get the name of the file
                    string fileName = AsyncFU_Image.FileName;

                    ImgFileName = Convert.ToString(rnum.Next(9999)) + "_" + AsyncFU_Image.FileName;

                    String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
                    //instead of server.mapPath set the path in web.config file and use that path.
                    ImgFileUrl = Server.MapPath("~") + tmpImageFolder;

                    AsyncFU_Image.SaveAs(ImgFileUrl + ImgFileName);
                    //lblUpMessage.Text = "Image uploaded : " + AsyncFU_Image.FileName;

                    ImgFileUploaded = true;
                    ViewState["FileImageUrl"] = ImgFileUrl;
                    ViewState["FileImageName"] = ImgFileName;
                    ViewState["FileImageUploaded"] = true;
                }
                else
                {

                    CustomValidatorImageX.IsValid = false;
                    AsyncFU_Image.Focus();
                    AsyncFU_EbFile.ClearFileFromPersistedStore();
                    AsyncFU_Image.ClearFileFromPersistedStore(); 

                    lblErrorImg.Text = "Ebook Image Size cannot exceed 2MB. Please try again.";
                    CommonFunctions.AlertMessage( "Ebook Image Size cannot exceed 2MB. Please try again.");
                    return;
                }
            }
        }
        else
        {
            CustomValidatorImageX.IsValid = false;
            AsyncFU_Image.Focus();
            AsyncFU_EbFile.ClearFileFromPersistedStore();
            AsyncFU_Image.ClearFileFromPersistedStore(); 

            lblErrorImg.Text = "Cannot save eBook without a Book Image. Please Upload";
            return; 
        }


       // rnum = new Random();



        if (AsyncFU_EbFile.HasFile)
        {

            String ebOrgFileName = AsyncFU_EbFile.FileName;

            int iFileSize1 = AsyncFU_EbFile.PostedFile.ContentLength;
            if (iFileSize1 > 0)
            {

                if (iFileSize1 < MaxEbookFileSize)
                {
                    //Get the name of the file
                    string fileName = AsyncFU_EbFile.FileName;


                    EbookFileName = Convert.ToString(rnum.Next(9999)) + "_" + AsyncFU_EbFile.FileName;

                    String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
                    //instead of server.mapPath set the path in web.config file and use that path.
                    EbookFileUrl = Server.MapPath("~") + tmpEbfileFolder;

                    AsyncFU_EbFile.SaveAs(EbookFileUrl + EbookFileName);
                    //lblUpMessage.Text = "Image uploaded : " + AsyncFU_Image.FileName;

                    ImgFileUploaded = true;
                    ViewState["FileEbookUrl"] = EbookFileUrl;
                    ViewState["FileEbookName"] = EbookFileName;
                    ViewState["FileEbookUploaded"] = true;

                }
                else
                {
                    CustomValidatorFileX.IsValid = false;
                    AsyncFU_EbFile.Focus();
                    AsyncFU_EbFile.ClearFileFromPersistedStore();
                    AsyncFU_Image.ClearFileFromPersistedStore(); 

                    lblErrorFile.Text = "Ebook File Size cannot exceed 5MB. Please try again.";
                    CommonFunctions.AlertMessage("Ebook File Size cannot exceed 5MB. Please try again.");
                    return;
                }

            }
        }
        else
        {
            CustomValidatorFileX.IsValid = false;
            AsyncFU_EbFile.Focus();
            AsyncFU_EbFile.ClearFileFromPersistedStore();
            AsyncFU_Image.ClearFileFromPersistedStore(); 

            lblErrorFile.Text = "Cannot save eBook without a Book File. Please Upload";
            return;
        }








 }

    

    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {

        decimal vPrice = 0;
        decimal vDiscount = 0;
        decimal vDisPrice = 0;

        vPrice = Convert.ToDecimal(txtPrice.Text);
        vDiscount = Convert.ToDecimal(txtDiscount.Text);


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

        vPrice = Convert.ToDecimal(txtPrice.Text);
        vDiscount = Convert.ToDecimal(txtDiscount.Text);
        if ((vPrice != 0) && (vDiscount != 0))
        {
            vDisPrice = vPrice - ((vPrice * vDiscount) / 100);
        }

        txtDiscountedPrice.Text = vDisPrice.ToString();


    }

    protected void AsyncFU_Image_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {


        //Random rnum = new Random();


        //if (AsyncFU_Image.HasFile)
        //{



        //    if (AsyncFU_Image.FileBytes.Length < MaxEbookImageSize)
        //    {
        //        //Get the name of the file
        //        string fileName = AsyncFU_Image.FileName;

        //        ImgFileName = Convert.ToString(rnum.Next(9999)) + "_" + AsyncFU_Image.FileName;

        //        String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
        //        //instead of server.mapPath set the path in web.config file and use that path.
        //        ImgFileUrl = Server.MapPath("~") + tmpImageFolder;

        //       // AsyncFU_Image.SaveAs(ImgFileUrl + ImgFileName);
        //        //lblUpMessage.Text = "Image uploaded : " + AsyncFU_Image.FileName;

        //        ImgFileUploaded = true;
        //        ViewState["FileImageUrl"] = ImgFileUrl;
        //        ViewState["FileImageName"] = ImgFileName;
        //        ViewState["FileImageUploaded"] = true; 
        //    }
        //}




    }




    protected void AsyncFU_File_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {


        //Random rnum = new Random();
       


        //if (AsyncFU_EbFile.HasFile)
        //{

        //    String ebOrgFileName = AsyncFU_EbFile.FileName;

        //    if (AsyncFU_EbFile.FileBytes.Length < MaxEbookImageSize)
        //    {
        //        //Get the name of the file
        //        string fileName = AsyncFU_EbFile.FileName;

                
        //        EbookFileName = Convert.ToString(rnum.Next(9999)) + "_" + AsyncFU_EbFile.FileName;

        //        String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        //        //instead of server.mapPath set the path in web.config file and use that path.
        //        EbookFileUrl = Server.MapPath("~") + tmpEbfileFolder;

        //       // AsyncFU_EbFile.SaveAs(EbookFileUrl + EbookFileName);
        //        //lblUpMessage.Text = "Image uploaded : " + AsyncFU_Image.FileName;

        //        ImgFileUploaded = true;
        //        ViewState["FileEbookUrl"] = EbookFileUrl;
        //        ViewState["FileEbookName"] = ebOrgFileName;
        //        ViewState["FileEbookUploaded"] = true;

        //    }
        //}




    }






    protected void txtBookName_TextChanged(object sender, EventArgs e)
    {
        txtSubject.Text = "Ebook: " + txtBookName.Text.Trim(); 
    }
}