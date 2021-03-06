using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;

public partial class BP_Default : System.Web.UI.Page
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
                    string[] iVal = inputVal.Split(',');                   

                    DataSet ds2;
                    newDBS clsObjNewDbs = new newDBS();

                    ds2 = clsObjNewDbs.getMTebookDownload_BillPlz(iVal[0], iVal[1]);
                    int Status = Convert.ToInt32(ds2.Tables[0].Rows[0]["Status"].ToString());
                    int Validity = Convert.ToInt32(ds2.Tables[0].Rows[0]["Validity"].ToString());
                    String vfileName = ds2.Tables[0].Rows[0]["BookName"].ToString();
                    string bookPassword = ds2.Tables[0].Rows[0]["bookPassword"].ToString();
                    //String EbookfileURL = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
                    //String EbookFilePath = EbookfileURL + vfileName;
                    //if (Status > Validity)
                    //{
                    //    Response.Write("Invalid Request. Request Book does not exists/ Expire.");
                    //}
                    //else
                    //{
                    //    if (File.Exists(Server.MapPath(EbookFilePath)))
                    //    {
                    //        CopyBookGeneratePassword(vfileName, bookPassword);
                    //        //Response.Redirect("http://183.81.165.117/DocumentRepository/DownloadBooks/" + vfileName.ToString());
                    //        Response.Redirect(ConfigurationManager.AppSettings["EbookFileFolderDownload"].ToString() + vfileName.ToString());
                    //    }
                    //    else
                    //    {
                    //        String vAlertMsg = "Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.";
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
                    //    }
                    //}
                    String EbookfileURL = @"C:\inetpub\wwwroot\DocumentRepository\eBooks\";
                    String EbookFilePath = EbookfileURL + vfileName;
                    if (Status > Validity)
                    {
                        Response.Write("Invalid Request. Request Book does not exists/ Expire.");
                    }
                    else
                    {
                        if (File.Exists(EbookFilePath))
                        {
                            CopyBookGeneratePassword(vfileName, bookPassword);
                            //Response.Redirect("http://183.81.165.117/DocumentRepository/DownloadBooks/" + vfileName.ToString());
                            Response.Redirect(ConfigurationManager.AppSettings["EbookFileFolderDownload"].ToString() + vfileName.ToString());
                        }
                        else
                        {
                            String vAlertMsg = "Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
                        }
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
        //string sourcePath = @"C:\HostingSpaces\admin\www.1worldsms.com\wwwroot\DocumentRepository\eBooks\";
        //string targetPath = @"C:\HostingSpaces\admin\www.1worldsms.com\wwwroot\DocumentRepository\DownloadBooks\";
        string sourcePath = @"C:\inetpub\wwwroot\DocumentRepository\eBooks\";
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