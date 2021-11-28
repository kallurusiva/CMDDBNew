using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;

public partial class shiroEBookDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String inputVal = string.Empty;
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0] != null)
                {
                    inputVal = Request.QueryString[0].ToString();

                    String EbookfileURL = @"C:\inetpub\wwwroot\DocumentRepository\ReqeBooks\";
                    String EbookFilePath = EbookfileURL + inputVal;

                    if (File.Exists(EbookFilePath))
                    {
                        CopyBookGeneratePassword(inputVal, "601122288888MSGA");
                        Response.Redirect("http://14.102.146.116/DocumentRepository/DownloadBooks/" + inputVal.ToString());
                    }
                    else
                    {
                        String vAlertMsg = "Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
                    }
                }
            }
            else
            {
                inputVal = "0";
                Response.Write("Invalid Request. Request Book does not exists/ Expire.");
            }
        }
    }

    public static void CopyBookGeneratePassword(string qBookName, string qPassword)
    {
        string fileName = qBookName.ToString();

        string extFileName = fileName.Substring(fileName.Length - 4);
        string sourcePath = @"C:\inetpub\wwwroot\DocumentRepository\ReqeBooks\";
        string targetPath = @"C:\inetpub\wwwroot\DocumentRepository\DownloadBooks\";
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);

        if (extFileName.ToUpper() == ".ZIP")
        {
            fileName = System.IO.Path.GetFileName(sourceFile);
            destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(sourceFile, destFile, true);
        }
        if (extFileName.ToUpper() == ".PDF")
        {
            using (Stream input = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Stream output = new FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(input);
                    iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, output, true, qPassword, "gs88", iTextSharp.text.pdf.PdfWriter.ALLOW_SCREENREADERS);
                    reader.Close();
                }
            }
        }

    }

}