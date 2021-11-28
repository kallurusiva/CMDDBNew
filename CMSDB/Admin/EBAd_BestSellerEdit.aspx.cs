using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_BestSellerEdit : System.Web.UI.Page
{

    //long MaxEbookFileSize = 5242880;    // 5MB
    long MaxEbookImageSize = 2097152;   // 2MB

    bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    bool EbookFileUploaded = false;
    String EbookFileName = String.Empty;
    String EbookFileUrl = String.Empty;

    CMSv3.Entities.Ebook objEbEntity = new CMSv3.Entities.Ebook();
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    DataSet ds;

    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        ImgFileUploaded = Getbool();
        EbookFileUploaded = Getbool();

        txtPrice.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtDiscount.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");

        txtDiscountedPrice.Attributes.Add("readonly", "readonly");

        //if (PreviousPage != null)
        //{

        //    HiddenField hdnBookUID = PreviousPage.Master.FindControl("ContentBody").FindControl("HdEditBookUID") as HiddenField;
        //    HiddenField hdnBookID = PreviousPage.Master.FindControl("ContentBody").FindControl("HdEditBookID") as HiddenField;

        //    if (hdnBookUID != null)
        //    {
        //        ViewState["qBookUID"] = hdnBookUID.Value;
        //        ViewState["qBookID"] = hdnBookID.Value;
        //    }


        //}

        String qBookID = Server.UrlDecode(Decrypt(Request.QueryString["qBID"].ToString()));


        //String qBookID = Request.QueryString["qBID"].ToString();
        ViewState["qBookID"] = qBookID; 

        if (!IsPostBack)
        {




            //txtPrice.Text = "10";
            //txtDiscount.Text = "50";
            //txtDiscountedPrice.Text = "5";

            //txtSenderEmailID.Text = "";

            //txtSMSmessage.Text = "Thank you for your purchase. An ebook is being sent to you,Pls check your email Inbox & Spam folder as sometime it may go the latter.";

            //string vEmailMessageText = string.Empty;

            //vEmailMessageText += "Dear Customer," + Environment.NewLine + Environment.NewLine;
            //vEmailMessageText += "Thank you for your Order." + Environment.NewLine + Environment.NewLine;
            //vEmailMessageText += "The Ebook you purchased is attached. Please download it for reading purpose." + Environment.NewLine + Environment.NewLine;
            //vEmailMessageText += "Best Regards," + Environment.NewLine;


            //txtEmailMessage.Text = vEmailMessageText;



            ViewState["FileImageUrl"] = "";
            ViewState["FileImageName"] = "";
            ViewState["FileImageUploaded"] = false;

            ViewState["FileEbookUrl"] = "";
            ViewState["FileEbookName"] = "";
            ViewState["FileEbookUploaded"] = false;
            

            LoadBookDetails(ViewState["qBookID"].ToString()); 

           

            MaintainScrollPositionOnPostBack = true;
        }


    }

    private static bool GetBool()
    {
        return false;
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


                txtPrice.Text = bkRow["Price"].ToString();
                txtDiscount.Text = bkRow["Discount"].ToString();

                decimal vPrice = Convert.ToDecimal(txtPrice.Text);
                decimal vDiscount = Convert.ToDecimal(txtDiscount.Text);

                decimal vDiscPrice = (vPrice * vDiscount) / 100;

                txtDiscountedPrice.Text = vDiscPrice.ToString();


                //chkActive.Checked = Convert.ToBoolean(drow["Active"].ToString());
                rdoDisplayatWebsite.SelectedValue = Convert.ToBoolean(bkRow["isDisplay"].ToString()).ToString();
                // rdoFeatured.SelectedValue = Convert.ToBoolean(bkRow["isFeatured"].ToString()).ToString();
                rdoBuySMS.SelectedValue = Convert.ToBoolean(bkRow["AllowSMSbuy"].ToString()).ToString();
                rdoBuyPayPal.SelectedValue = Convert.ToBoolean(bkRow["AllowPaypalBuy"].ToString()).ToString();


                String vCatId = bkRow["catID"].ToString();
                LoadCategories(vCatId);

                ImageBook.ImageUrl = bkRow["ImageFileFullURL"].ToString();

                lblCurrentEbookFile.Text = bkRow["eBookFileName"].ToString();


                ViewState["FileImageUrl"] = bkRow["ImageFilePath"].ToString();
                ViewState["FileImageName"] = bkRow["ImageFileName"].ToString();


                ViewState["FileEbookUrl"] = bkRow["eBookFilePath"].ToString();
                ViewState["FileEbookName"] = bkRow["eBookFileName"].ToString();


                txtSubject.Text = bkRow["eSubject"].ToString();
                txtSenderEmailID.Text = bkRow["eSenderEmailID"].ToString();
                txtSMSmessage.Text = bkRow["ReplySMS"].ToString();

                String vEmailMessage = bkRow["eMessage"].ToString();
                txtEmailMessage.Text = vEmailMessage.Replace("<br/>", Environment.NewLine);



            }


        }



    }




    protected void btnSave_Click(object sender, EventArgs e)
    {

        FileUpload_OnserverValidate();

        if (Page.IsValid)
        {
            //Book Details...
            //==================================
            objEbEntity.BookID = ViewState["qBookID"].ToString(); 
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
            objEbEntity.isBestSeller = true;

            objEbEntity.Price = Convert.ToDecimal(txtPrice.Text);
            objEbEntity.Discount = Convert.ToDecimal(txtDiscount.Text);

            objEbEntity.Description = txtDescription.Text;

            objEbEntity.CreatedBy = Convert.ToInt32(Session["UserID"]);

            // Book Image 
            //==================
            if (ViewState["FileImageUploaded"].ToString() == "true")
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
            if (ViewState["FileEbookUploaded"].ToString() == "true")
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




            int aStatus = objBALebook.EBook_UpdateBook_ByUser(objEbEntity);
            AsyncFU_EbFile.ClearAllFilesFromPersistedStore();
            AsyncFU_Image.ClearAllFilesFromPersistedStore(); 

            if (aStatus == 2)
            {
                CommonFunctions.AlertMessage("A Book by this name already exists. Please Check.");
            }
            else if (aStatus == 1)
            {
                CommonFunctions.AlertMessage("eBook Added Successfully");

                Response.Redirect("EBAd_BestSeller.aspx?qStatus=1");
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

        Server.Transfer("EBAd_BestSeller.aspx"); 


    }


    protected void LoadCategories(string vCatID)
    {

        DataSet ds;

        ds = objBALebook.Category_Load_ByUserID(Convert.ToInt32(Session["UserID"]),""); 

        ddlCategory.DataSource = ds;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CatID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));

        ddlCategory.SelectedValue = vCatID;
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
      


       // rnum = new Random();



        if (AsyncFU_EbFile.HasFile)
        {

            String ebOrgFileName = AsyncFU_EbFile.FileName;

            int iFileSize1 = AsyncFU_EbFile.PostedFile.ContentLength;
            if (iFileSize1 > 0)
            {

                if (iFileSize1 < MaxEbookImageSize)
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
            vDisPrice = (vPrice * vDiscount) / 100;
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
            vDisPrice = (vPrice * vDiscount) / 100;
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