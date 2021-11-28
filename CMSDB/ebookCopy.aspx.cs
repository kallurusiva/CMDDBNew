using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using PdfSharp;
//using PdfSharp.Drawing;
//using PdfSharp.Pdf;
//using PdfSharp.Pdf.IO;
//using PdfSharp.Pdf.Content;
//using PdfSharp.Charting;
//using PdfSharp.Pdf.Printing;
//using PdfSharp.Pdf.Security;
using System.Configuration;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using CMSv3.BAL;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class ebookCopy : System.Web.UI.Page
{
    //String qBookID = "0";
    //String qBookName = "";
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString.Count > 0)
        //{
        //    if (Request.QueryString["qBookID"] != null)
        //    {
        //        qBookID = Request.QueryString["qBookID"].ToString();
        //    }
        //}
        //ViewState["qBookID"] = qBookID;

        EBookPassword.CopyBookGeneratePassword("5003_test cigars.pdf","123456");

        //DataSet ds;
        //ds = objBALebook.Ebook_GetBookDetails(qBookID, 7484);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    DataTable dt = ds.Tables[0];
        //    DataRow dr = dt.Rows[0];
        //    qBookName = dr["eBookFileName"].ToString();
        //}

        //string fileName = qBookName.ToString();
        //string sourcePath = @"C:\HostingSpaces\admin\www.1worldsms.com\wwwroot\DocumentRepository\eBooks";
        //string targetPath = @"E:Webs\PasswordeBooks";

        ////string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        ////string destFile = System.IO.Path.Combine(targetPath, fileName);

        ////fileName = System.IO.Path.GetFileName(sourceFile);
        ////destFile = System.IO.Path.Combine(targetPath, fileName);
        ////System.IO.File.Copy(sourceFile, destFile, true);

        //string pdfFilename = string.Empty;
        //string OutputFile = string.Empty;
        //pdfFilename = @"E:Webs\PasswordeBooks/" + fileName;
        //OutputFile =  @"E:Webs\PasswordeBooks/123456.pdf";

        //using (Stream input = new FileStream(pdfFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
        //    {
        //        using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
        //        {
        //            PdfReader reader = new PdfReader(input);
        //            PdfEncryptor.Encrypt(reader, output, true, "123456","123456", PdfWriter.ALLOW_SCREENREADERS);
        //        }
        //    }

        //string pdfFilename = string.Empty;
        //pdfFilename = @"E:Webs\PasswordeBooks/" + fileName;
        //PdfDocument document = PdfReader.Open(pdfFilename, PdfDocumentOpenMode.Modify);

        //PdfSecuritySettings securitySettings = document.SecuritySettings;

        //// Setting one of the passwords automatically sets the security level to 
        //// PdfDocumentSecurityLevel.Encrypted128Bit.
        //securitySettings.UserPassword = "123456";
        //securitySettings.OwnerPassword = "123456";

        //// Don't use 40 bit encryption unless needed for compatibility reasons
        ////securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

        //// Restrict some rights.
        //securitySettings.PermitAccessibilityExtractContent = false;
        //securitySettings.PermitAnnotations = false;
        //securitySettings.PermitAssembleDocument = false;
        //securitySettings.PermitExtractContent = false;
        //securitySettings.PermitFormsFill = true;
        //securitySettings.PermitFullQualityPrint = false;
        //securitySettings.PermitModifyDocument = true;
        //securitySettings.PermitPrint = false;

        //// Save the document...
        //document.Save(pdfFilename);
    }
}