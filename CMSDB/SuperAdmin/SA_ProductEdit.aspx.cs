using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using CMSv3.Entities;


public partial class SuperAdmin_SA_ProductEdit : System.Web.UI.Page 
{
    bool FileWasUpload = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    //SqlDataReader dbreader;
    //DataSet ds;
    DataTable dt;
    int qryProductID = 0;
    int qLgType = 1;
    int prdType = 1;
    
    CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();
    CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        FileWasUpload = Getbool();


        if (Request.QueryString["LgType"].ToString() != null && Request.QueryString["LgType"].ToString() != "")
        {
            qLgType = Convert.ToUInt16(Request.QueryString["LgType"]);
        }

        if (Request.QueryString["Ptype"] != null && Request.QueryString["Ptype"].ToString() != "")
        {
            prdType = Convert.ToUInt16(Request.QueryString["Ptype"]);
        }

        

        if (!IsPostBack)
        {
            ViewState["FileWasUploaded"] = false;
            ViewState["FileImageUrl"] = "";
            ViewState["FileImageName"] = null;
            LoadData();
       }

        //Language Resources. 
        LtrDisplayweb.Text = Resources.LangResources.DisplayatWebsite;


    }


    protected void LoadData()
    {
        //Get Product data from database;



        qryProductID = Convert.ToInt32(Request.QueryString["ProductID"]);


        if (qryProductID != 0)
        {

            ViewState["ProductID"] = qryProductID;
            dt = objBAL_Products.RetrieveAllProducts_ByProductID(Convert.ToInt32(Session["saUserID"]), qryProductID);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow drow in dt.Rows)
                {

                    txtProductName.Text = drow["ProductName"].ToString();
                    txtProductCode.Text = drow["ProductCode"].ToString();
                    txtProductPrice.Text = drow["Price"].ToString();

                    String tmpDescription = drow["Description"].ToString();
                    tmpDescription = tmpDescription.Replace("<br/>", Environment.NewLine);
                    txtProductDescription.Text = tmpDescription;


                    string tmpBenefits =  drow["Benefits"].ToString();
                    tmpBenefits = tmpBenefits.Replace("<br/>", Environment.NewLine);
                    txtProductBenefits.Text = tmpBenefits;

                   
                    chkActive.Checked = Convert.ToBoolean(drow["Active"].ToString());
                   
                    if (drow["FullImgPath"].ToString() == "")
                        ImgProduct.ImageUrl = "~/ImageRepository/Dummy_user.gif";
                    else
                        ImgProduct.ImageUrl = drow["FullImgPath"].ToString();

                    ImgProduct.Visible = true;
                    //ImgProduct.ControlStyle.Reset();
                    //ImgProduct.CssClass = "ImgTestimonialCss";

                    ViewState["ImageID"] = drow["PdImageID"].ToString();
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

            ImgFileName = Convert.ToInt32(Session["saUserID"]) + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + UploadImgCtrl.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") +  @"\ImageRepository\";

            UploadImgCtrl.SaveAs(ImgFileUrl + ImgFileName);
            lblUpMessage.Text = "Image uploaded : " + UploadImgCtrl.FileName;

            ImgProduct.ImageUrl = @"~\ImageRepository\" + ImgFileName;

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
        if(prdType == 1)
        Server.Transfer("SA_ProductListing.aspx?Lgtype=" + qLgType);
        else
            Server.Transfer("SA_EntrePrenuerListing.aspx?Lgtype=" + qLgType);

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

        CMSv3.Entities.Products objProducts = new CMSv3.Entities.Products();

        objProducts.ProductID = Convert.ToInt16(ViewState["ProductID"]);
        objProducts.ProductName = txtProductName.Text;
        objProducts.ProductCode = txtProductCode.Text;
        objProducts.ProductPrice = txtProductPrice.Text;

        string tmpProductsDescription = txtProductDescription.Text;
        //objProducts.ProductDescription = tmpProductsDescription.ToString().Replace(Environment.NewLine, "<br/>");
        tmpProductsDescription = CommonFunctions.HandleNewLines(tmpProductsDescription, Request.UserAgent);
        objProducts.ProductDescription = tmpProductsDescription;

        string tmpProductsBenefits = txtProductBenefits.Text;
        //objProducts.ProductBenefits = tmpProductsBenefits.ToString().Replace(Environment.NewLine, "<br/>");
        tmpProductsBenefits = CommonFunctions.HandleNewLines(tmpProductsBenefits, Request.UserAgent);
        objProducts.ProductBenefits = tmpProductsBenefits;
                     
       // int inStatus = objBAL_Product.InsertProduct(objProduct, Convert.ToInt32(Session["saUserID"]), objMyImage);

        int upStatus = objBAL_Products.UpdateProductsData(objProducts, Convert.ToInt32(Session["saUserID"]), objMyImage, chkActive.Checked);


        if (upStatus >= 1)
        {
            //tblMessageBar.Visible = true;
            //MessageImage.Src = "~/Images/inf_Sucess.gif";
            ////lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            //lblErrMessage.Text = "News successfully added";
            //lblErrMessage.CssClass = "font_12Msg_Success";

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


            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Product updated Successfully')", true);
            if (prdType == 1)
            Response.Redirect("SA_ProductListing.aspx?LgType=" + qLgType);
            else
                Response.Redirect("SA_EntrePrenuerListing.aspx?LgType=" + qLgType);
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
