using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;

public partial class Admin_EbAd_BanKInConfirmationResend : System.Web.UI.Page
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending; 


    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        if (!IsPostBack)
        {
            if (PreviousPage != null)
            {
                HiddenField hdn_UId = PreviousPage.Master.FindControl("ContentBody").FindControl("hdn_UId") as HiddenField;
                HiddenField hdn_TranID = PreviousPage.Master.FindControl("ContentBody").FindControl("hdn_TranID") as HiddenField;

                ViewState["qUID"] = hdn_UId.Value;
                ViewState["qTranID"] = hdn_TranID.Value;
                int vUserId = Convert.ToInt32(Session["UserID"]);

                LoadTransactionDetails(ViewState["qUID"].ToString(), ViewState["qTranID"].ToString());
            }
        }
        tblMessageBar.Visible = false;
        MaintainScrollPositionOnPostBack = true;
    }


    protected void LoadTransactionDetails(string vUID, String vTranID)
    {

        //  ds = objPayPal.EB_PayPal_RetrieveTX(Convert.ToInt32(Session["UserID"]), ""); 

        int vUserID = Convert.ToInt32(Session["UserID"]);

        ds = objBALebook.Bank_Client_GetBankIns_ByTranID(vUID, vTranID);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dv = ds.Tables[0].DefaultView;

            DataRow dRow = ds.Tables[0].Rows[0];

            lblTranId.Text = dRow["TransactionID"].ToString();
            lblAmountDue.Text = dRow["DueAmount"].ToString() + "  " + dRow["DueAmtCurrency"].ToString();
            lblAmtPaid.Text = dRow["BankInAmt"].ToString();

            lblFullName.Text = dRow["BankersName"].ToString();
            lblMobileNo.Text = dRow["BankersMobile"].ToString();
            lblEmailId.Text = dRow["BankersEmail"].ToString();

            lblBankActNo.Text = dRow["BankActNo"].ToString();
            lblBankName.Text = dRow["BankName"].ToString();
            lblCountry.Text = dRow["CountryName"].ToString();
            lblDateTime.Text = dRow["BankInDateTime"].ToString();

            lblBankInSlip.Text = dRow["BankInSlip"].ToString();
            lblPurDescription.Text = dRow["BankInDescription"].ToString();

            String tmpPurchaseItems = dRow["PurchasedItems"].ToString();

            LoadPurchasetems(vUserID, vTranID, tmpPurchaseItems);

            ReSendEmail();
        }
    }



    protected void LoadPurchasetems(int vUserId, String vTranID, String vPurcItems)
    {
        ViewState["ItemsString"] = vPurcItems;
        string[] tmpPurchaseItems = vPurcItems.Split(',');
        String RetBookString = string.Empty;

        foreach (String BookID in tmpPurchaseItems)
        {
            if (RetBookString != string.Empty)
            {
                if (BookID != "")
                    RetBookString += ",";
            }
            if (BookID != "")
                RetBookString += "''" + BookID + "''";
        }

        String FinalString = vPurcItems;
        int tmpRowCount = 0;
        //String FinalString = "'" + RetBookString + "'";

        DataSet dsBooks = objBALebook.BankIn_GetBookDetails_ByBooksID(vUserId, vTranID, FinalString);

        String tmpCurrency = String.Empty;

        String vBookSelstr = string.Empty;

        if (dsBooks.Tables[0].Rows.Count > 0)
        {
            DataTable dtBooks = dsBooks.Tables[0];

            if (dtBooks.Rows.Count > 0)
            {
                tmpRowCount = dtBooks.Rows.Count;
                ViewState["ItemsCount"] = tmpRowCount;

                String vBookIds = string.Empty;
                String vBookIds2Show = string.Empty;
                String VbookImgs = String.Empty;

                decimal vTotalAmt = 0;

                foreach (DataRow cRow in dtBooks.Rows)
                {
                    vBookIds += cRow["BookID"].ToString() + ",";
                    vBookIds2Show += cRow["BookID"].ToString() + ";&nbsp;&nbsp;&nbsp;";
                    vTotalAmt += Convert.ToDecimal(cRow["Price"].ToString());
                    String tmpID = cRow["BookID"].ToString();
                    String tmpImgUrl = cRow["ImageFileFullURL"].ToString();
                    String tmpPrice = cRow["price"].ToString();
                    String tmpTitle = cRow["BookName"].ToString() + "\n" + tmpCurrency + ' ' + tmpPrice;
                    tmpImgUrl = tmpImgUrl.Substring(1);
                    VbookImgs += "<div style='float: left; margin-left: 6px; padding: 2px;'> " + tmpID + "<br/>" + "<img alt='bkimg' class='BookBox BookImgCss' src='" + tmpImgUrl + "' title='" + tmpTitle + "'> </div>";

                }
                lblItems.Text = "<div>" + VbookImgs + "</div>";
                // lblTotalItems.Text = tmpRowCount.ToString();
                ViewState["ItemsString"] = vBookIds;
            }
        }
    }    

    protected void BtnSendEmail_Click(object sender, EventArgs e)
    {
        String SendToFullName = lblFullName.Text;
        String SendToEmailId = lblEmailId.Text;
        String vTranID = lblTranId.Text;

        //String eMessage = "Thank you for your ebooks Purchase. Please find the following Ebooks as attachment. ";
        String eSubject = "Delivery for your Purchase : " + vTranID;
        String eSenderEmailID = "noreply@ebooksmsdelivery.com";
        String vPurchasedBooks = ViewState["ItemsString"].ToString();
        string[] tmpPurchaseItems = vPurchasedBooks.Split(',');
        String RetBookString = string.Empty;
        foreach (String BookID in tmpPurchaseItems)
        {
            if (RetBookString != string.Empty)
            {
                if (BookID != "")
                    RetBookString += ",";
            }
            if (BookID != "")
                RetBookString += "''" + BookID + "''";
        }

        String FinalString = vPurchasedBooks;
        //int tmpRowCount = 0;
        //String FinalString = "'" + RetBookString + "'";
        int vUserID = Convert.ToInt32(Session["UserID"]);

        DataSet dsBooks = objBALebook.BankIn_GetBookDetails_ByBooksID(vUserID, vTranID, FinalString);
        DataTable dtbooks = dsBooks.Tables[0];

        String vEmailToName = string.Empty;
        String vEmailToAddress = string.Empty;

        //String vEmailFromName = "Admin";
        //String VEmailFromAddress = "enquiry@HappySameBooks.com"; //"mail@globauser.small-dns.net"; 
        String VEmailFromAddress = eSenderEmailID;
        String vEmailSubject = eSubject;

        //String eAttachment = string.Empty;
        //String eAttachment1 = string.Empty;
        //String eAttachment2 = string.Empty;
        //String eAttachment3 = string.Empty;
        //String eAttachment4 = string.Empty;

        //eAttachment = "";
        //eAttachment1 = "";
        //eAttachment2 = "";
        //eAttachment3 = "";
        //eAttachment4 = "";

        //String tmpEbooks = String.Empty;
        //String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        //int i = 1;
        //foreach (DataRow dRow in dtbooks.Rows)
        //{
        //    String eAtt = dRow["eAttachment"].ToString();
        //    String eBookID = dRow["BookID"].ToString();
        //    String eBookName = dRow["BookName"].ToString();

        //    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAtt)))
        //    {
        //        if (i == 1) { eAttachment = eAtt; }
        //        if (i == 2) { eAttachment1 = eAtt; }
        //        if (i == 3) { eAttachment2 = eAtt; }
        //        if (i == 4) { eAttachment3 = eAtt; }
        //        if (i == 5) { eAttachment4 = eAtt; }

        //        tmpEbooks += i.ToString() + ") " + eBookID + ": " + eBookName + "<br/>";
        //        i++;
        //    }
        //}
        //tmpEbooks = "<br/><br/>" + tmpEbooks + "<br/><br/>";


        //MgMail.sndMailEbook(SendToEmailId, eSenderEmailID, vEmailSubject, vEmailFromName, "", "", eAttachment, eAttachment1, eAttachment2, eAttachment3, eAttachment4, "", eMessage);

        string QKeyword = string.Empty;
        DataSet ds3 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserID);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds3.Tables[0].Rows[0];
            QKeyword = krow["VendorCode"].ToString();
        }
        //EBookEmailCentral.getTransactionDetails(SendToEmailId, "", QKeyword, "", "", FinalString);

//        SmtpClient smtpClient = new SmtpClient();
//        MailMessage objMessage = new MailMessage();
//        string m_fromName = string.Empty;
//        try
//        {
//            m_fromName = "EBookAdmin";
//            VEmailFromAddress = "noreply@ebooksmsdelivery.com";

//            MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EBookAdmin");
//            smtpClient.Host = "localhost";
//            smtpClient.Port = 25;
//            objMessage.From = m_fromAddress;
//            objMessage.To.Add(SendToEmailId);
//            objMessage.Subject = vEmailSubject;
//            objMessage.IsBodyHtml = true;
//            String tmpEbooks = String.Empty;
//            String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
//            //... Get the List of Books to be Attached. 
//            // == ATTACHEMENT    1   ===

//            int i = 1;
//            foreach (DataRow dRow in dtbooks.Rows)
//            {
//                String eAttachment = dRow["eAttachment"].ToString();
//                String eBookID = dRow["BookID"].ToString();
//                String eBookName = dRow["BookName"].ToString();

//                if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment)))
//                {
//                    Attachment objAtt1 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment));
//                    objMessage.Attachments.Add(objAtt1);
//                    tmpEbooks += i.ToString() + ") " + eBookID + ": " + eBookName + "<br/>";
//                    i++;
//                }
//            }
//            tmpEbooks = "<br/><br/>" + tmpEbooks + "<br/><br/>";

//            string tmpHtmlBody = @"
//                                <html xmlns='http://www.w3.org/1999/xhtml'>
//                                <head >
//                                <title></title>
//                                <style type='text/css'>
//                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
//                                </style>
//                                </head>
//                                <body>
//                                    <div id='dvEmail' class='dvemailBox'> 
//                                    <div id='dvHeader' style='align-content: center;'>
//                                            <img src='http://183.81.165.117/Images/ebImages/bookimgbanner.jpg' />
//                                                    <br />
//                                     </div>
//                                    <div id='dvContent' style='font: bold 12px Verdana'>
//                            <br /> <br />
//                                    "
//                      + eMessage + tmpEbooks +

//                      @"
//                                </div>
//                                </div>
//   
//                            </body>
//                            </html>
//                            ";
//            String sHtmlBody = tmpHtmlBody;
//            objMessage.Body = sHtmlBody;
//            //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
//            NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
//            smtpClient.UseDefaultCredentials = false;
//            smtpClient.Credentials = authinfo;
//            // Send SMTP mail
//            smtpClient.Send(objMessage);
//        }
//        catch (Exception ex)
//        {
//            CommonFunctions.AlertMessage("Email Could not be Sent");
//            Response.Write(ex.Message);
//        }
//        finally
//        {
//            CommonFunctions.AlertMessageAndRedirect("EBOOKS ReSend by Email Successfully", "Ebad_BankInByList.aspx");
//        }
        
        String vTranID1 = lblTranId.Text;
        int vUserID1 = Convert.ToInt32(Session["UserID"]);
    }


    public void ReSendEmail()
    {
        String SendToFullName = lblFullName.Text;
        String SendToEmailId = lblEmailId.Text;
        String vTranID = lblTranId.Text;

        //String eMessage = "Thank you for your ebooks Purchase. Please find the following Ebooks as attachment. ";
        String eSubject = "Delivery for your Purchase : " + vTranID;
        String eSenderEmailID = "noreply@ebooksmsdelivery.com";
        String vPurchasedBooks = ViewState["ItemsString"].ToString();
        string[] tmpPurchaseItems = vPurchasedBooks.Split(',');
        String RetBookString = string.Empty;
        foreach (String BookID in tmpPurchaseItems)
        {
            if (RetBookString != string.Empty)
            {
                if (BookID != "")
                    RetBookString += ",";
            }
            if (BookID != "")
                RetBookString += "''" + BookID + "''";

        }

        String FinalString = vPurchasedBooks;
        //int tmpRowCount = 0;
        //String FinalString = "'" + RetBookString + "'";
        int vUserID = Convert.ToInt32(Session["UserID"]);

        DataSet dsBooks = objBALebook.BankIn_GetBookDetails_ByBooksID(vUserID, vTranID, FinalString);
        DataTable dtbooks = dsBooks.Tables[0];

        String vEmailToName = string.Empty;
        String vEmailToAddress = string.Empty;

        //String vEmailFromName = "Admin";
        //String VEmailFromAddress = "enquiry@HappySameBooks.com"; //"mail@globauser.small-dns.net"; 
        String VEmailFromAddress = eSenderEmailID;
        String vEmailSubject = eSubject;

        //String eAttachment = string.Empty;
        //String eAttachment1 = string.Empty;
        //String eAttachment2 = string.Empty;
        //String eAttachment3 = string.Empty;
        //String eAttachment4 = string.Empty;

        //eAttachment = "";
        //eAttachment1 = "";
        //eAttachment2 = "";
        //eAttachment3 = "";
        //eAttachment4 = "";

        //String tmpEbooks = String.Empty;
        //String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
        //int i = 1;
        //foreach (DataRow dRow in dtbooks.Rows)
        //{
        //    String eAtt = dRow["eAttachment"].ToString();
        //    String eBookID = dRow["BookID"].ToString();
        //    String eBookName = dRow["BookName"].ToString();

        //    if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAtt)))
        //    {
        //        if (i == 1) { eAttachment = eAtt; }
        //        if (i == 2) { eAttachment1 = eAtt; }
        //        if (i == 3) { eAttachment2 = eAtt; }
        //        if (i == 4) { eAttachment3 = eAtt; }
        //        if (i == 5) { eAttachment4 = eAtt; }

        //        tmpEbooks += i.ToString() + ") " + eBookID + ": " + eBookName + "<br/>";
        //        i++;
        //    }
        //}
        //tmpEbooks = "<br/><br/>" + tmpEbooks + "<br/><br/>";


        //MgMail.sndMailEbook(SendToEmailId, eSenderEmailID, vEmailSubject, vEmailFromName, "", "", eAttachment, eAttachment1, eAttachment2, eAttachment3, eAttachment4, "", eMessage);


        string QKeyword = string.Empty;
        DataSet ds3 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserID);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds3.Tables[0].Rows[0];
            QKeyword = krow["VendorCode"].ToString();
        }

        //EBookEmailCentral.getTransactionDetails(SendToEmailId, "", QKeyword, "", "", FinalString);
        CommonFunctions.AlertMessageAndRedirect("EBOOKS ReSend by Email Successfully", "Ebad_BankInByList.aspx");

//        SmtpClient smtpClient = new SmtpClient();
//        MailMessage objMessage = new MailMessage();
//        string m_fromName = string.Empty;
//        try
//        {
//            m_fromName = "EBookAdmin";
//            VEmailFromAddress = "noreply@ebooksmsdelivery.com";

//            MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EBookAdmin");
//            smtpClient.Host = "localhost";
//            smtpClient.Port = 25;
//            objMessage.From = m_fromAddress;
//            objMessage.To.Add(SendToEmailId);
//            objMessage.Subject = vEmailSubject;
//            objMessage.IsBodyHtml = true;
//            String tmpEbooks = String.Empty;
//            String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
//            //... Get the List of Books to be Attached. 
//            // == ATTACHEMENT    1   ===

//            int i = 1;
//            foreach (DataRow dRow in dtbooks.Rows)
//            {
//                String eAttachment = dRow["eAttachment"].ToString();
//                String eBookID = dRow["BookID"].ToString();
//                String eBookName = dRow["BookName"].ToString();

//                if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment)))
//                {
//                    Attachment objAtt1 = new Attachment(Server.MapPath(tmpEbfileFolder + "/" + eAttachment));
//                    objMessage.Attachments.Add(objAtt1);
//                    tmpEbooks += i.ToString() + ") " + eBookID + ": " + eBookName + "<br/>";
//                    i++;
//                }
//            }
//            tmpEbooks = "<br/><br/>" + tmpEbooks + "<br/><br/>";

//            string tmpHtmlBody = @"
//                                <html xmlns='http://www.w3.org/1999/xhtml'>
//                                <head >
//                                <title></title>
//                                <style type='text/css'>
//                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
//                                </style>
//                                </head>
//                                <body>
//                                    <div id='dvEmail' class='dvemailBox'> 
//                                    <div id='dvHeader' style='align-content: center;'>
//                                            <img src='http://183.81.165.117/Images/ebImages/bookimgbanner.jpg' />
//                                                    <br />
//                                     </div>
//                                    <div id='dvContent' style='font: bold 12px Verdana'>
//                            <br /> <br />
//                                    "
//                      + eMessage + tmpEbooks +

//                      @"
//                                </div>
//                                </div>
//   
//                            </body>
//                            </html>
//                            ";
//            String sHtmlBody = tmpHtmlBody;
//            objMessage.Body = sHtmlBody;
//            //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
//            NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
//            smtpClient.UseDefaultCredentials = false;
//            smtpClient.Credentials = authinfo;
//            // Send SMTP mail
//            smtpClient.Send(objMessage);
//        }
//        catch (Exception ex)
//        {
//            CommonFunctions.AlertMessage("Email Could not be Sent");
//            Response.Write(ex.Message);
//        }
//        finally
//        {
//            CommonFunctions.AlertMessageAndRedirect("EBOOKS ReSend by Email Successfully", "Ebad_BankInByList.aspx");
//        }
    }
    

}
