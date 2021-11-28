using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using CMSv3.BAL;
using System.Net;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class PreviewBook : System.Web.UI.Page
{
    String qBookID = "0";
    String qBookName = "";
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString["qBookID"] != null)
            {
                qBookID = Request.QueryString["qBookID"].ToString();
            }
        }
        ViewState["qBookID"] = qBookID;

        newDBS ndbs = new newDBS();
        DataSet ds = ndbs.getEBookFileName(ViewState["qBookID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            qBookName = dr["ebookfilename"].ToString();
        }

        string fileName = qBookName.ToString();
        //string sourcePath = @"C:\HostingSpaces\admin\www.1worldsms.com\wwwroot\DocumentRepository\eBooks\";
        string sourcePath = @"C:\inetpub\wwwroot\DocumentRepository\eBooks\";
        string targetPath = @"C:\inetpub\wwwroot\DocumentRepository\previewBooks\";

        string pdfFilenameFrom = string.Empty;
        string pdfFilenameTo = string.Empty;
        pdfFilenameFrom = sourcePath + fileName;
        pdfFilenameTo = targetPath + ViewState["qBookID"].ToString() + ".pdf"; 

        PdfReader reader = null;
        Document sourceDocument = null;
        PdfCopy pdfCopyProvider = null;
        PdfImportedPage importedPage = null;

        reader = new PdfReader(pdfFilenameFrom);
        int numberOfPages = reader.NumberOfPages;
        // For simplicity, I am assuming all the pages share the same size
        // and rotation as the first page:
        sourceDocument = new Document(reader.GetPageSizeWithRotation(1));

        // Initialize an instance of the PdfCopyClass with the source 
        // document and an output file stream:
        pdfCopyProvider = new PdfCopy(sourceDocument,
            new System.IO.FileStream(pdfFilenameTo, System.IO.FileMode.Create));

        sourceDocument.Open();

        int lastpage = 1;

        if (numberOfPages > 9)
        {
            lastpage = 10;
        }
        else
        {
            lastpage = numberOfPages;
        }

        for (int i = 1; i <= lastpage; i++)
        {
            importedPage = pdfCopyProvider.GetImportedPage(reader, i);
            pdfCopyProvider.AddPage(importedPage);
        }
        sourceDocument.Close();
        reader.Close();

        Response.Redirect("http://14.102.146.116/DocumentRepository/PreviewBooks/" + qBookID + ".pdf");
    }

}