using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class CertificateAddEM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Mobile"] = Request.QueryString["m"].ToString();
        ViewState["TID"] = Request.QueryString["t"].ToString();
    }

    protected void btnSaveCont_Click(object sender, EventArgs e)
    {
        FileUpload_OnserverValidate();
    }

    protected void CustomVdr_eBookImage_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }

    protected void FileUpload_OnserverValidate()
    {
        String pfile = UploadImgCtrl.PostedFile.ToString();

        string fileName = UploadImgCtrl.FileName;
        string ImgFileName = ViewState["Mobile"].ToString() + ".pdf"; ;
        String tmpImageFolder = "/DocumentRepository/Certificates/EM/";
        string ImgFileUrl = Server.MapPath("~") + tmpImageFolder;

        UploadImgCtrl.SaveAs(ImgFileUrl + ImgFileName);

        newDBS objNewDB = new newDBS();
        DataSet ds = objNewDB.products_Upload_CertificateEM(ViewState["TID"].ToString(), ViewState["Mobile"].ToString());

        CommonFunctions.AlertMessage("Uploaded");

    }

}