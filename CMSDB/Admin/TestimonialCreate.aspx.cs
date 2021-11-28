using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Admin_TestimonialCreate : BasePage
{
    bool FileWasUpload = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    CMSv3.BAL.Testimonial objBAL_Testimonial = new CMSv3.BAL.Testimonial();
    CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

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
            ViewState["FileWasUploaded"] = false;
            ViewState["FileImageUrl"] = "";
            LoadCountries();
        }
        FileWasUpload = false;
        ltrLanguage.Text = Resources.LangResources.Language;

        if (Session["UserDomainType"].ToString() == "EBOOK")
        {
            trSelLanguage.Visible = false;
        }

    }

    private static bool GetBool()
    {
        return false;
    }


    protected void Page_Unload(object sender, EventArgs e)
    {

        //ScriptManager.RegisterClientScriptBlock(this, GetType(), "PgUnload", "alert('Unloading...')", true);
        ////if the user clicks cancel delete the image from the physical folder. 
        //if (Convert.ToBoolean(ViewState["FileWasUploaded"].ToString()))
        //{
        //    System.IO.File.Delete(ViewState["FileImageUrl"].ToString());
        //}
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();

        if (UploadImgCtrl.HasFile)
        {
            
            ImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + UploadImgCtrl.FileName;
            
            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

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
        
        //if the user clicks cancel delete the image from the physical folder. 
        if (ViewState["FileWasUploaded"].ToString() != "")
        {
            if (Convert.ToBoolean(ViewState["FileWasUploaded"].ToString()))
            {
                System.IO.File.Delete(ViewState["FileImageUrl"].ToString() + ViewState["FileImageName"].ToString());
            }
        }
        Server.Transfer("TestimonialListing.aspx");
        

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {

        //get the form details.

       
        CMSv3.Entities.MyImage objMyImage = new CMSv3.Entities.MyImage();
        if (ViewState["FileImageName"] != null)
        {

            //string mImageURL = ViewState["FileImageUrl"].ToString();
            //string mImageName = ViewState["FileImageName"].ToString();
            //string mImageActualName = ViewState["ActualFileName"].ToString();

            objMyImage.ImgName = ViewState["FileImageName"].ToString();
            //objMyImage.ImgPath = ViewState["FileImageUrl"].ToString();
            objMyImage.ImgPath = @"\ImageRepository\";
            objMyImage.ImgType = 2;
            objMyImage.ActualImgName = ViewState["ActualFileName"].ToString();
        }
        else
        {
            //ImgUser.ImageUrl = "~/ImageRepository/UserIcon.png";

            objMyImage.ImgName = "Dummy_user.gif" ;
            objMyImage.ImgPath = @"\ImageRepository\" ;
            objMyImage.ImgType = 2;
            objMyImage.ActualImgName = "Dummy_user.gif";
        }



        CMSv3.Entities.Testimonial objTestimonial = new CMSv3.Entities.Testimonial();


        String tmpTestimonialContent = txtTestimonial.Text;
        //tmpTestimonialContent = tmpTestimonialContent.ToString().Replace(Environment.NewLine, "<br/>");
        tmpTestimonialContent = CommonFunctions.HandleNewLines(tmpTestimonialContent, Request.UserAgent);
        objTestimonial.TstContent = tmpTestimonialContent;


        objTestimonial.ByCompany = txtTstCompany.Text;
        objTestimonial.ByDesignation = txtTstDesgination.Text;
        objTestimonial.ByName = txtTstname.Text;
        objTestimonial.CountryCode = Convert.ToInt32(DdlCountry.SelectedValue);
        objTestimonial.Active = chkActive.Checked;


         int mSelLanguage = 0;
         if (Session["UserDomainType"].ToString() == "EBOOK")
         {
             mSelLanguage = 1;
         }
         else
         {
             //-- accessing the Selected Language 
             ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
             UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
             DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
             mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);
         }
        if (mSelLanguage == 0)
            mSelLanguage = 1;
        //-----------------------



        int inStatus = objBAL_Testimonial.InsertTestimonial(objTestimonial, Convert.ToInt32(Session["UserID"]), objMyImage, mSelLanguage);

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Event Item inserted Successfully')", true);
           // Server.Transfer("TestimonialListing.aspx");
            Response.Redirect("TestimonialListing.aspx?LgType=" + mSelLanguage);
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



    protected void LoadCountries()
    {

        DataSet ds = new DataSet();
        ds = objBAL_CommonFunc.GetCountryList();

        DdlCountry.DataSource = ds;
        DdlCountry.DataValueField = "CountryCode";
        DdlCountry.DataTextField = "CountryName";
        DdlCountry.SelectedValue = "60";
        DdlCountry.DataBind();
       


    }
}
