using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_TestimonialEdit: BasePage
{
    bool FileWasUpload = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    //SqlDataReader dbreader;
    //DataSet ds;
    DataTable dt;
    int qryTestimonialID = 0;

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
            ViewState["FileImageName"] = null;
            LoadData();
       }   
    }

    private static bool GetBool()
    {
        return false;
    }

    protected void LoadData()
    {
        //Get Testimonial data from database;
        


         qryTestimonialID = Convert.ToInt32(Request.QueryString["TstID"]);


        if (qryTestimonialID != 0)
        {

            ViewState["TestimonialID"] = qryTestimonialID;
            dt = objBAL_Testimonial.RetrieveAllTestimonials_ByTestimonialID(Convert.ToInt32(Session["UserID"]), qryTestimonialID);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow drow in dt.Rows)
                {

                    string tmpTestimonailContent = drow["tstContent"].ToString();
                    //tmpTestimonailContent = tmpTestimonailContent.Replace("<br/>", Environment.NewLine);
                    tmpTestimonailContent = CommonFunctions.HandleNewLines(tmpTestimonailContent, Request.UserAgent);
                    txtTestimonial.Text = tmpTestimonailContent;
                                    

                    txtTstCompany.Text = drow["tstByCompany"].ToString();
                    txtTstDesgination.Text = drow["tstByDesignation"].ToString();
                    txtTstname.Text = drow["tstByName"].ToString();
                                       
                    chkActive.Checked = Convert.ToBoolean(drow["Active"].ToString());
                   
                    int mCountryCode = 0;

                    if (Convert.ToInt16(drow["tstCountryCode"].ToString()) > 0)
                        mCountryCode = Convert.ToInt16(drow["tstCountryCode"].ToString());

                    LoadCountries(mCountryCode);
                   
                    if (drow["FullImgPath"].ToString() == "")
                        ImgUser.ImageUrl = "~/ImageRepository/Dummy_user.gif";
                    else
                        ImgUser.ImageUrl = drow["FullImgPath"].ToString();

                    ViewState["ImageID"] = drow["ImageID"].ToString();
                    ViewState["FileImageName"] = drow["ImgName"].ToString();
                    ViewState["FileImageUrl"] = @"\ImageRepository\";
                    ViewState["ActualFileName"] = drow["ImgActualName"].ToString();


                    ViewState["OldImageURL"] = ViewState["FileImageUrl"].ToString() + ViewState["FileImageName"].ToString();


                  

                }


            }

            

        }





    }



    protected void btnUpload_Click(object sender, EventArgs e)
    {

        //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();
        
        if (UploadImgCtrl.HasFile)
        {
            FileWasUpload = false;
            ImgFileName = Convert.ToInt32(Session["UserID"]) + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + UploadImgCtrl.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") +  @"\ImageRepository\";

            UploadImgCtrl.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessage.Text = "Image uploaded : " + UploadImgCtrl.FileName;

            ImgUser.ImageUrl = @"~\ImageRepository\" + ImgFileName;

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
        FileWasUpload = false;

        //if the user clicks cancel delete the image from the physical folder. 
        if(ViewState["FileWasUploaded"] != null)
        {
            if (ViewState["FileWasUploaded"].ToString() != "")
            {
                if (Convert.ToBoolean(ViewState["FileWasUploaded"].ToString()))
                {
                    System.IO.File.Delete(ViewState["FileImageUrl"].ToString() + ViewState["FileImageName"].ToString());
                }
            }

        }
        Server.Transfer("TestimonialListing.aspx");

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {

        //get the form details.
        CMSv3.Entities.MyImage objMyImage = new CMSv3.Entities.MyImage();

        //if (UploadImgCtrl.HasFile)
        if(ViewState["FileWasUploaded"].ToString().ToLower() == "true")
        {
            if (ViewState["FileImageName"] != null)
            {
                //objMyImage.ImgID = Convert.ToInt32(ViewState["ImageID"].ToString());
                objMyImage.ImgID = 0;  // NEW IMAGE
                objMyImage.ImgName = ViewState["FileImageName"].ToString();
                objMyImage.ImgPath = ViewState["FileImageUrl"].ToString();
                objMyImage.ImgType = 2;
                objMyImage.ActualImgName = ViewState["ActualFileName"].ToString();
            }
        }
        else
        {
            //objMyImage.ImgID = Convert.ToInt32(ViewState["ImageID"].ToString());
            //objMyImage.ImgName = ViewState["FileImageName"].ToString();
            //objMyImage.ImgPath = ViewState["FileImageUrl"].ToString();
            //objMyImage.ImgType = 2;
            //objMyImage.ActualImgName = ViewState["ActualFileName"].ToString();
            
            //..User made no changes to the Image.. handle this at the update store procedure.
            objMyImage.ImgID = 0;
            objMyImage.ImgName = "";
            objMyImage.ImgPath = "";
            objMyImage.ImgType = 0;
            objMyImage.ActualImgName = "";

        }
            //else
            //{
            //    objMyImage.ImgID = 0;
            //    objMyImage.ImgName = "";
            //    objMyImage.ImgPath = "";
            //    objMyImage.ImgType = 2;
            //    objMyImage.ActualImgName = "";
            //}

        CMSv3.Entities.Testimonial objTestimonial = new CMSv3.Entities.Testimonial();


        objTestimonial.TstID = Convert.ToInt32(ViewState["TestimonialID"]);
        objTestimonial.TstContent = txtTestimonial.Text;
        objTestimonial.ByCompany = txtTstCompany.Text;
        objTestimonial.ByDesignation = txtTstDesgination.Text;
        objTestimonial.ByName = txtTstname.Text;
        objTestimonial.CountryCode = Convert.ToInt32(DdlCountry.SelectedValue);
        
           

        int upStatus = objBAL_Testimonial.UpdateTestimonialsData(objTestimonial, Convert.ToInt32(Session["UserID"]), objMyImage, chkActive.Checked);


        if (upStatus >= 1)
        {
            //tblMessageBar.Visible = true;
            //MessageImage.Src = "~/Images/inf_Sucess.gif";
            ////lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            //lblErrMessage.Text = "News successfully added";
            //lblErrMessage.CssClass = "font_12Msg_Success";
            FileWasUpload = false;
            //--- Delete the Old Image
            if (ViewState["FileWasUploaded"] != null)
            {
                if (ViewState["FileWasUploaded"].ToString() != "")
                {
                    if (Convert.ToBoolean(ViewState["FileWasUploaded"].ToString()))
                    {
                        // System.IO.File.Delete(ViewState["OldImageURL"].ToString());
                        System.IO.File.Delete(Server.MapPath("~") + ViewState["OldImageURL"].ToString());
                    }
                }
            }
            //-----------------------


            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Testimonial updated Successfully')", true);
            Response.Redirect("TestimonialListing.aspx");
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



    protected void LoadCountries(int vCode)
    {

        DataSet ds = new DataSet();
        ds = objBAL_CommonFunc.GetCountryList();

        DdlCountry.DataSource = ds;
        DdlCountry.DataValueField = "CountryCode";
        DdlCountry.DataTextField = "CountryName";

        if (vCode == 0)
            vCode = 60;

        DdlCountry.SelectedValue = Convert.ToString(vCode);
        DdlCountry.DataBind();


    }
}
