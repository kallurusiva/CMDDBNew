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

public partial class Admin_EbAd_EISBNupdate : System.Web.UI.Page
{
    long MaxEbookImageSize = 2097152;   // 2MB
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;
    bool ImgFileUploaded = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        ImgFileUploaded = Getbool();
       
    }
    private static bool Getbool()
    {
        return false;
    }

    protected void HandleFileUploads()
    {
        if (Session["FileUpload1"] == null && UploadImgCtrl.HasFile)
        {
            Session["FileUpload1"] = UploadImgCtrl;
            lblErrorImg.Text = UploadImgCtrl.FileName; // get the name  
        }
        else if (Session["FileUpload1"] != null && (!UploadImgCtrl.HasFile))
        {
            UploadImgCtrl = (FileUpload)Session["FileUpload1"];
            lblErrorImg.Text = UploadImgCtrl.FileName;
        }
        else if (UploadImgCtrl.HasFile)
        {
            Session["FileUpload1"] = UploadImgCtrl;
            lblErrorImg.Text = UploadImgCtrl.FileName;
        }
    }

    protected void FileUpload_OnserverValidate()
    {
        String pfile = UploadImgCtrl.PostedFile.ToString();

        if (UploadImgCtrl.HasFile)
        {
            int iImageSize1 = UploadImgCtrl.PostedFile.ContentLength;
            if (iImageSize1 > 0)
            {
                if (iImageSize1 < MaxEbookImageSize)
                {
                    string fileName = UploadImgCtrl.FileName;
                    ImgFileName = Session["UserID"].ToString() + "_" + txtEBookCode.Text.ToString() + "." + System.IO.Path.GetExtension(fileName);
                    String tmpImageFolder = "/DocumentRepository/eisbn/";
                    ImgFileUrl = Server.MapPath("~") + tmpImageFolder;
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
                    lblErrorImg.Text = "Cert Image Size cannot exceed 2MB. Please try again.";
                    CommonFunctions.AlertMessage("Cert Image Size cannot exceed 2MB. Please try again.");
                    return;
                }
            }
        }
    }

    protected void CustomVdr_eBookImage_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string fileName = UploadImgCtrl.FileName;
        int fileSize = UploadImgCtrl.PostedFile.ContentLength;

        if (UploadImgCtrl.FileBytes.Length > MaxEbookImageSize)
        {
            lblErrorImg.Text = "Filesize of image is too large. Maximum file size permitted is 2MB";
            CommonFunctions.AlertMessage("Voucher Image Size cannot be greater then 2MB.");
            args.IsValid = false;
            return;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        HandleFileUploads();
        FileUpload_OnserverValidate();

        string ImgFileName = "";
        string errorcode = "";
        string retMessage = "";

        if (txtEISBNcode.Text.Length<13)
        {
            CommonFunctions.AlertMessage("EISBN Code must be 13 Characters in length.");
        }
        else
        {
            if (Page.IsValid)
            {
                if (UploadImgCtrl.HasFile)
                {
                    string fileName = UploadImgCtrl.FileName;
                    ImgFileName = Session["UserID"].ToString() + "_" + txtEBookCode.Text.ToString() + "." + System.IO.Path.GetExtension(fileName);
                }

                newDBS objNewDB = new newDBS();
                DataSet ds = objNewDB.ebook_EISBNupdate(Session["UserID"].ToString(), txtEBookCode.Text.ToString(), txtEISBNcode.Text.ToString(), ImgFileName.ToString(), txtPRemarks.Text.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    errorcode = dr["errorcode"].ToString();
                    retMessage = dr["retMessage"].ToString();
                }

                if (errorcode == "0")
                {
                    HttpWebRequest WebReq = null;
                    HttpWebResponse WebResp;

                    string strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=49061723&message=New EISBN Submission. Please Approve ";

                    WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

                    //WebReq.ClientCertificates.Add(Cert);
                    WebReq.Method = "GET";
                    WebResp = (HttpWebResponse)WebReq.GetResponse();
                    if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                    {
                        Stream _Answer = WebResp.GetResponseStream();
                        StreamReader Answer = new StreamReader(_Answer);
                        String strTemp = Answer.ReadToEnd();
                    }
                    CommonFunctions.AlertMessageAndRedirect("EISBN Details Added successfully", "EBAd_EISBNupdateHistory.aspx");
                }
                else
                {
                    CommonFunctions.AlertMessage(retMessage.ToString());
                }
            }
        }

       
    }

}