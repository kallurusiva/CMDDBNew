using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Net;
using System.Net.Mail;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;

public class EBookEmailCentral
{
	public EBookEmailCentral()
	{
		
	}

    public static void getTransactionDetails(string vEmailTo, string vNameTo, string vKeyword, string vSubject, string vMessage, string vBookIDs, string bPassword)
    {
        string booksNormal = string.Empty;       
        string booksValueBuy = string.Empty;
        string[] books = vBookIDs.Split(','); 
       
        foreach (string book in books)
        {
            if (String.IsNullOrEmpty(book))
            {
            }
            else
            {
                if (book.Substring(0, 3).ToUpper() == "EVB")
                {
                    //booksValueBuy = booksValueBuy + book + ",";
                    sendEBooksValuebuy(book, vEmailTo, vNameTo, vKeyword, vSubject, vMessage);
                }
                else
                {
                    //booksNormal = booksNormal + book + ",";
                    sendEBooks(book, vEmailTo, vNameTo, vKeyword, vSubject, vMessage, bPassword);
                }       
            }
        }   
    }

    public static void sendEBooks(string bookIds, string vEmailTo, string vNameTo, string vKeyword, string vSubject, string vMessage, string bPassword)
    {
        CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
        if (bookIds == "")
        {
        }
        else
        {
            String eSubject = string.Empty;
            String BookImageURL = string.Empty;

            String eAttachment = string.Empty;
            String eAttachment1 = string.Empty;
            String eAttachment2 = string.Empty;
            String eAttachment3 = string.Empty;
            String eAttachment4 = string.Empty;

            eAttachment = "";
            eAttachment1 = "";
            eAttachment2 = "";
            eAttachment3 = "";
            eAttachment4 = "";

            String tmpEbooks = String.Empty;
            String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
            int i = 1;

            DataSet dsBooks = objBALebook.BankIn_GetBookDetails_ByBooksID(0, "", bookIds);
            DataTable dtbooks = dsBooks.Tables[0];
            foreach (DataRow dRow in dtbooks.Rows)
            {
                String eAtt = dRow["eAttachment"].ToString();
                String eBookID = dRow["BookID"].ToString();
                String eBookName = dRow["BookName"].ToString();
                eSubject = dRow["eSubject"].ToString();
                vMessage = dRow["eMessage"].ToString();

                String BookImage = dRow["ImageFileName"].ToString();
                BookImageURL = "http://14.102.146.116/DocumentRepository/eBookImages/" + HttpContext.Current.Server.HtmlEncode(BookImage);
                //BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL + "' />";

                if (File.Exists(HttpContext.Current.Server.MapPath(tmpEbfileFolder + "/" + eAtt)))
                {
                    if (i == 1) { eAttachment = eAtt; }
                    if (i == 2) { eAttachment1 = eAtt; }
                    if (i == 3) { eAttachment2 = eAtt; }
                    if (i == 4) { eAttachment3 = eAtt; }
                    if (i == 5) { eAttachment4 = eAtt; }
                    
                    tmpEbooks += i.ToString() + ") " + eBookID + ": " + eBookName + "<br/>";
                    i++;
                }
            }
            tmpEbooks = Environment.NewLine + Environment.NewLine + "<br/><br/>" + tmpEbooks + "<br/><br/>";
            MgMail.sndMailEbook(vEmailTo, "Admin", vKeyword + "-" + bookIds + "-" + eSubject, vNameTo, "", "", eAttachment, eAttachment1, eAttachment2, eAttachment3, eAttachment4, BookImageURL, vMessage + tmpEbooks, bPassword);
        }
    }

    public static void sendEBooksValuebuy(string vBookId, string vEmailTo, string vNameTo, string vKeyword, string vSubject, string vMessage)
    {
        String tmpEbooks = String.Empty;
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.EBOOK_GetBook2EmailDetails2(vBookId);
        DataTable dt = ds.Tables[0];
        int i = 1;
        if (dt.Rows.Count > 0)
        {
            DataRow drow = dt.Rows[0];

            String eSubject = drow["eSubject"].ToString();
            String eSenderEmailID = drow["esenderEmailID"].ToString();
            String eMessage = drow["eMessage"].ToString();
            String eAttachment1 = drow["eAttachment1"].ToString();
            String eAttachment2 = drow["eAttachment2"].ToString();
            String eAttachment3 = drow["eAttachment3"].ToString();
            String eAttachment4 = drow["eAttachment4"].ToString();
            String eAttachment5 = drow["eAttachment5"].ToString();

            String eBookName1 = drow["eBookName1"].ToString();
            String eBookName2 = drow["eBookName2"].ToString();
            String eBookName3 = drow["eBookName3"].ToString();
            String eBookName4 = drow["eBookName4"].ToString();
            String eBookName5 = drow["eBookName5"].ToString();

            String BookImage1 = drow["ImageFileName1"].ToString();
            String BookImage2 = drow["ImageFileName2"].ToString();
            String BookImage3 = drow["ImageFileName3"].ToString();
            String BookImage4 = drow["ImageFileName4"].ToString();
            String BookImage5 = drow["ImageFileName5"].ToString();

            eMessage = eMessage + Environment.NewLine + Environment.NewLine + "<br/><br/>Purchased Books List :<br/>";

            if (eBookName1 != "") { eMessage = eMessage + "<br/>1) " + eBookName1 + "<br/>"; }
            if (eBookName2 != "") { eMessage = eMessage + "2) " + eBookName2 + "<br/>"; }
            if (eBookName3 != "") { eMessage = eMessage + "3) " + eBookName3 + "<br/>"; }
            if (eBookName4 != "") { eMessage = eMessage + "4) " + eBookName4 + "<br/>"; }
            if (eBookName5 != "") { eMessage = eMessage + "5) " + eBookName5 + "<br/>"; }

            eMessage = eMessage + Environment.NewLine + Environment.NewLine;

            if (BookImage1!= "")
            {
                string BookImageURL1 = "http://14.102.146.116/DocumentRepository/eBookImages/" + BookImage1;
                eMessage = eMessage + " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL1.Replace(" ", "%20") + "' />";
            }
            if (BookImage2 != "")
            {
                string BookImageURL2 = "http://14.102.146.116/DocumentRepository/eBookImages/" + BookImage2;
                eMessage = eMessage + " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL2.Replace(" ", "%20") + "' />";
            }
            if (BookImage3 != "")
            {
                string BookImageURL3 = "http://14.102.146.116/DocumentRepository/eBookImages/" + BookImage3;
                eMessage = eMessage + " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL3.Replace(" ", "%20") + "' />";
            }
            if (BookImage4 != "")
            {
                string BookImageURL4 = "http://14.102.146.116/DocumentRepository/eBookImages/" + BookImage4;
                eMessage = eMessage + " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL4.Replace(" ", "%20") + "' />";
            }
            if (BookImage5 != "")
            {
                string BookImageURL5 = "http://14.102.146.116/DocumentRepository/eBookImages/" + BookImage5;
                eMessage = eMessage + " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL5.Replace(" ", "%20") + "' />";
            }

            i++;
            MgMail.sndMailEbook(vEmailTo, eSenderEmailID, "ValueBuy: " + vKeyword + "-" + vBookId + "-" + eSubject, vNameTo, "", "", eAttachment1, eAttachment2, eAttachment3, eAttachment4,eAttachment5, "", eMessage,"123456");
        }
    }
  
}