using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class SuperAdmin_SA_TestimonialCreate : System.Web.UI.Page 
{
    bool FileWasUpload;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    CMSv3.BAL.Testimonial objBAL_Testimonial = new CMSv3.BAL.Testimonial();
    CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        FileWasUpload = Getbool();
        ltrDisplayAtWebsite.Text = Resources.LangResources.DisplayatWebsite;

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
            LoadCountries();
        }

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
            
            ImgFileName = Session["saUserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + UploadImgCtrl.FileName;
            
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

        Server.Transfer("SA_TestimonialListing.aspx");
        

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

        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;
        //-----------------------


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


        int inStatus = objBAL_Testimonial.InsertTestimonial(objTestimonial, Convert.ToInt32(Session["saUserID"]), objMyImage, mSelLanguage);

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Tesimonial successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Testimonial Item inserted Successfully')", true);
            Response.Redirect("SA_TestimonialListing.aspx?LgType=" + mSelLanguage);
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
