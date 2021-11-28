using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class SuperAdmin_SA_EntrePrenuerCreate : System.Web.UI.Page 
{
    bool FileWasUpload = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();
    CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrDisplayAtwebsite.Text = Resources.LangResources.DisplayatWebsite;
        FileWasUpload = Getbool();

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        if (!IsPostBack)
        {
            ViewState["FileWasUploaded"] = false;
            ViewState["FileImageUrl"] = "";

            //btnSave.Attributes.Add("OnClientClick", "return IsImageUploaded();");
            btnSave.OnClientClick = "return IsImageUploaded();";
        }




    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();

        if (UploadImgCtrl.HasFile)
        {
            FileWasUpload = false;
            ImgFileName = Session["saUserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + UploadImgCtrl.FileName;
            
            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + GlobalVar.GetImgStoreFolder;

            
            ImgProduct.ImageUrl = "~" + GlobalVar.GetImgStoreFolder + ImgFileName;
            //ImgProduct.ImageUrl = @"~\ImageRepository\" + ImgFileName;
            ImgProduct.Visible = true;
           // ImgUser.ImageUrl = @"~\ImageRepository\" + ImgFileName;

            UploadImgCtrl.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessage.Text = "Image uploaded : " + UploadImgCtrl.FileName;
            FileWasUpload = true;
            ViewState["FileImageUrl"] = ImgFileUrl;
            ViewState["FileImageName"] = ImgFileName;
            ViewState["ActualFileName"] = UploadImgCtrl.FileName;
            ViewState["FileWasUploaded"] = true;
        }
        

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string ImgURL = string.Empty;
        UploadImgCtrl.Dispose();
        FileWasUpload = false;
        //if the user clicks cancel delete the image from the physical folder. 
        if (ViewState["FileWasUploaded"].ToString() != "")
        {
            if (Convert.ToBoolean(ViewState["FileWasUploaded"].ToString()))
            {
                System.IO.File.Delete(ViewState["FileImageUrl"].ToString() + ViewState["FileImageName"].ToString());
            }

        }
        Server.Transfer("SA_EntrePrenuerListing.aspx");
        

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {

        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;
        //-----------------------


        //get the form details.
        CMSv3.Entities.MyImage objMyImage = new CMSv3.Entities.MyImage();
        if (ViewState["FileImageName"] != null)
        {

            string mImageURL = ViewState["FileImageUrl"].ToString();
            string mImageName = ViewState["FileImageName"].ToString();
            string mImageActualName = ViewState["ActualFileName"].ToString();

            objMyImage.ImgName = ViewState["FileImageName"].ToString();
            objMyImage.ImgPath = ViewState["FileImageUrl"].ToString();
            objMyImage.ImgPath = @"\ImageRepository\";
            objMyImage.ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.ProductImage);
            objMyImage.ActualImgName = ViewState["ActualFileName"].ToString();
        }
        else
        {
            //ImgProduct.ImageUrl = "~/ImageRepository/UserIcon.png";

            objMyImage.ImgName = "Dummy_Product.gif";
            objMyImage.ImgPath = @"\ImageRepository\";
            objMyImage.ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.ProductImage); 
            objMyImage.ActualImgName = "Dummy_Product.gif";
        }
        
                
        CMSv3.Entities.Products objProducts = new CMSv3.Entities.Products();

        objProducts.ProductName = txtProductName.Text;
        objProducts.ProductCode = txtProductCode.Text;
        objProducts.ProductPrice = txtProductPrice.Text;
        objProducts.Active = chkActive.Checked;
        objProducts.ProductType = Convert.ToInt16(GlobalVar.ProductTypes.Entrepreneur);

        string tmpProductsDescription = txtProductDescription.Text;
        objProducts.ProductDescription = tmpProductsDescription.ToString().Replace(Environment.NewLine, "<br/>");

        string tmpProductsBenefits = txtProductBenefits.Text;
        objProducts.ProductBenefits = tmpProductsBenefits.ToString().Replace(Environment.NewLine, "<br/>");



        int inStatus = objBAL_Products.InsertProduct(objProducts, Convert.ToInt32(Session["saUserID"]), objMyImage, mSelLanguage);
        
        
        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Product successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Prouct Item inserted Successfully')", true);
            Response.Redirect("SA_EntrePrenuerListing.aspx?LgType=" + mSelLanguage);
            //Response.Redirect("EventsListing.aspx");
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
