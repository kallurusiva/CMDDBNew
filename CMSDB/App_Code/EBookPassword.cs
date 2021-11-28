using System;
using System.Collections.Generic;
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

/// <summary>
/// Summary description for EBookPassword
/// </summary>
public class EBookPassword
{
	public EBookPassword()
	{

	}

    public static void CopyBookGeneratePassword(string qBookName, string qPassword)
    { 
        //String qBookName = "";
        //CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();


        //DataSet ds;
        //ds = objBALebook.Ebook_GetBookDetails(qBookID, 7484);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    DataTable dt = ds.Tables[0];
        //    DataRow dr = dt.Rows[0];
        //    qBookName = dr["eBookFileName"].ToString();
        //}

        string fileName = qBookName.ToString();
        
        string extFileName = fileName.Substring(fileName.Length - 4);
        string sourcePath = @"C:\HostingSpaces\admin\www.1worldsms.com\wwwroot\DocumentRepository\eBooks\";
        string targetPath = @"E:Webs\PasswordeBooks\";

        //string destFileName = "";
        //if (extFileName.ToUpper() == ".ZIP")
        //{
        //    destFileName = qTranID + ".zip";
        //}
        //if (extFileName.ToUpper() == ".PDF")
        //{
        //    destFileName = qTranID + ".pdf";
        //}        

        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);
       
        if (extFileName.ToUpper() == ".PDF")
        {
            using (Stream input = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Stream output = new FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true, qPassword, "gs88", PdfWriter.ALLOW_SCREENREADERS);
                    reader.Close();
                }
            }
        } 
        else
        {
            fileName = System.IO.Path.GetFileName(sourceFile);
            destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(sourceFile, destFile, true);
        }
       
    }
}