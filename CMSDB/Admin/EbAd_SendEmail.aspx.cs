using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.IO;
using CMSv3.BAL;
using System.Net;
using System.Net.Mail;

public partial class Admin_EbAd_SendEmail : System.Web.UI.Page
{

    DataSet ds;
    DataTable dt; 
    //DataView dv;

    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    //String qBookID = "0";
    String QKeyword = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion
        
        String TmpTopMenuControl = String.Empty;
        String myTopMenuUserControlID = "EBLeftMenu_BookCodes1";
        TmpTopMenuControl = "EBLeftMenu_BookCodes.ascx";
        ViewState["PageURL"] = "EbAd_BookCodes.aspx";

        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString["Status"] != null)
            {
                if (Request.QueryString["Status"].ToString().ToUpper() == "F")
                {
                    myTopMenuUserControlID = "EBLeftMenu_FreeEbook1";
                    TmpTopMenuControl = "EBLeftMenu_FreeEbook.ascx";
                    ViewState["PageURL"] = "EbAd_FreeBookCodes.aspx";
                }
            }
        }

        divLeftMenu.ID = myTopMenuUserControlID;
        Control myTopMenuUserControl = (Control)Page.LoadControl(TmpTopMenuControl);
        divLeftMenu.Controls.Add(myTopMenuUserControl);


        if (!IsPostBack)
        {
            if (PreviousPage != null)
            {
                HiddenField hdn_EmailID = PreviousPage.Master.FindControl("ContentBody").FindControl("hdn_EmailID") as HiddenField;
                HiddenField hdnPRMCode_ID = PreviousPage.Master.FindControl("ContentBody").FindControl("hdnPRMCode_ID") as HiddenField;                


                ViewState["qEmailID"] = hdn_EmailID.Value;
                ViewState["qBookID"] = hdnPRMCode_ID.Value;

                //Response.Write(ViewState["qBookID"].ToString() + "<br>" + ViewState["qEmailID"].ToString());
                //Response.End();

                LabelEmailIdVal.Text = ViewState["qEmailID"].ToString();
                int vUserId = Convert.ToInt32(Session["UserID"]);
                LoadCategories(vUserId);
                LoadEbook(ViewState["qBookID"].ToString(), vUserId);
                

                //ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    DataRow utRow = ds.Tables[0].Rows[0];

                    
                //    //LabelSenderIDVal.Text = utRow["SenderId"].ToString();
                //    //LabelMerchantCodeVal.Text = utRow["Mcode"].ToString();
                //    //LabelSMSBalanceVal.Text = String.Format("{0:0.00}", utRow["BalanceCredit"]);
                //}

                
                //int iBalanceCreditStatus = Retrieve_UserAccountSMSBalance("0.5");

                //if (iBalanceCreditStatus != 1)
                //{
                   //CommonFunctions.AlertMessageAndRedirect("Sorry Insufficient Balance.Kindly Top your SMS", @"EbAd_BookCodes.aspx");
                //}
                //else
                //{
                //}
            }
        }
    }
    protected void LoadCategories(int vUserID)
    {
        ds = objBALebook.Category_Listing_ByUserID(vUserID, "");
        dt = ds.Tables[0];

        string tmpstr = string.Empty;

        StringBuilder sbCats = new StringBuilder();

        sbCats.AppendLine("<h2>Categories</h2>");
        sbCats.AppendLine("<div class='menu_simple'>");
        //sbCats.AppendLine("<span class='eb_head2'>Categories</span>");

        sbCats.AppendLine("<br/>");
        sbCats.AppendLine("<ul>");

        string tmpCatItem = string.Empty;
        int tmpCatID = 0;

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            foreach (DataRow cRow in dt.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                tmpCatItem = "<li><a href='eBooksList.aspx?qBookID=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";

                sbCats.AppendLine(tmpCatItem);
            }
        }
        sbCats.AppendLine("</ul>");
        sbCats.AppendLine("</div>");

    }
    protected void LoadEbook(String vEbookID, int vUserID)
    {
        string tmpKeyword = string.Empty;
        int tmpPKGtype = 0;
        String tmpUserType = string.Empty;

        DataSet ds2;
        ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserID);

        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            tmpKeyword = krow["VendorCode"].ToString();
            tmpPKGtype = Convert.ToInt32(krow["PackageType"].ToString());
            tmpUserType = krow["ebUserType"].ToString();
        }
        string tmpstr = string.Empty;
       
        DataSet ds;
        ds = objBALebook.Ebook_GetBookDetails(vEbookID, vUserID);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];

            DataRow dr = dt.Rows[0];

            lblBookID.Text = dr["BookID"].ToString();
            lblBookName.Text = dr["BookNAme"].ToString();
            lblCategory.Text = dr["CategoryName"].ToString();

            DateTime dNewDate = Convert.ToDateTime(dr["DateCreated"].ToString());
            String strNewDate = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dNewDate);
            lblDateAdded.Text = strNewDate;

            ImgEbook.ImageUrl = "~/" + dr["ImageFileFullURL"].ToString();

            String tmpTitle = dr["Title"].ToString();
            String tmpDescription = dr["Description"].ToString();

            tmpDescription = tmpDescription.Replace(Environment.NewLine, "<br/>");
            tmpDescription = "<p class='BkfontDescription'>" + tmpDescription + "</p>";

            if (tmpTitle == "")
                tmpTitle = "";
            else
                tmpTitle = "<p class='BkfontTitle'>" + tmpTitle + "</p>";

            lblHeader.Text = lblBookName.Text;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int vUserId1 = Convert.ToInt32(Session["UserID"]);
        DataSet ds3 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserId1);        
        if (ds3.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds3.Tables[0].Rows[0];
            QKeyword = krow["VendorCode"].ToString();
        }

        DataSet ds = objBALebook.EBOOK_GetBook2EmailDetails(ViewState["qBookID"].ToString());
        String tmpEmail = ViewState["qEmailID"].ToString();
        DataTable dt = ds.Tables[0];

        //Send Email
        if (dt.Rows.Count > 0)
        {
            DataRow drow = dt.Rows[0];

            String eBookTitle = drow["Title"].ToString();
            String eBookName = drow["BookName"].ToString();
            String eSubject = drow["eSubject"].ToString();
            String eSenderEmailID = drow["esenderEmailID"].ToString();
            String eMessage = drow["eMessage"].ToString();
            String eAttachment = drow["eAttachment"].ToString();
            String BookImage = drow["ImageFileName"].ToString();
            String BookImageURL = "http://14.102.146.116/DocumentRepository/eBookImages/" + BookImage;
            String BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL + "' />";

            eMessage = eMessage.Replace(Environment.NewLine, "<br/>");
            //MgMail.sndMailEbook(tmpEmail, eSenderEmailID, QKeyword + "-" + qBookID + "-" + eSubject, "" , "", "", eAttachment, "", "", "", "", BookImageURL, eMessage);
            //EBookEmailCentral.getTransactionDetails(tmpEmail, "", QKeyword, "", "", ViewState["qBookID"].ToString());

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
//                                    "
//                       + eMessage +

//                       @"
//                                </div>
//                            <div id='dvBookImage'>"

//                       + BookImageHtml +

//                            @"</div>
//
//
//                                </div>
//   
//                            </body>
//                            </html>
//                            ";

            #region Sending mail using SmarterMail

            //String vEmailToName = tmpEmail;
            //String vEmailToAddress = tmpEmail;
            //String vEmailFromName = eSenderEmailID;
            //String VEmailFromAddress = eSenderEmailID;
            //VEmailFromAddress = "noreply@ebooksmsdelivery.com";
            //vEmailFromName = "EBookAdmin";
            //String vEmailSubject = eSubject;
            //String sHtmlBody = tmpHtmlBody;
            //SmtpClient smtpClient = new SmtpClient();
            //MailMessage objMessage = new MailMessage();
            //string m_fromName = string.Empty;
            //try
            //{
            //    m_fromName = "EBookAdmin";
            //    MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, "EBookAdmin");
            //    smtpClient.Host = "localhost";
            //    smtpClient.Port = 25;
            //    objMessage.From = m_fromAddress;
            //    objMessage.To.Add(vEmailToAddress);
            //    objMessage.Subject = vEmailSubject;
            //    objMessage.IsBodyHtml = true;
            //    objMessage.Body = sHtmlBody;
            //    String tmpeBookfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

            //    if (File.Exists(Server.MapPath(tmpeBookfileFolder + "/" + eAttachment)))                {
            //        Attachment objAtt = new Attachment(Server.MapPath(tmpeBookfileFolder + "/" + eAttachment));
            //        objMessage.Attachments.Add(objAtt);
            //    }
            //    //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
            //    NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
            //    smtpClient.UseDefaultCredentials = false;
            //    smtpClient.Credentials = authinfo;

            //    // Send SMTP mail
            //    smtpClient.Send(objMessage);
            //}
            //catch (Exception ex)
            //{

            //}

            #endregion



            ////End
            ////int tmpStatus = objMalaysia.Insert_SEKEmailInfo(Session["MERID"].ToString(), ViewState["qBookID"].ToString(), "1", "0", "1", "0", "Ebook Name " + eBookName, eSubject, eMessage, eAttachment, ViewState["qEmailID"].ToString());


            CommonFunctions.AlertMessageAndRedirect("Email has been Sent", ViewState["PageURL"].ToString());

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected int Retrieve_UserAccountSMSBalance(String iDeductSMSCredits)
    {
        Double iCreditStatus = 0;
        Double BalanceCredit = -1;
        int tStatus = 1;

        ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

        bool bCredit = double.TryParse(iDeductSMSCredits, out iCreditStatus);

        if (bCredit)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];
                String sBalance = utRow["BalanceCredit"].ToString();
                BalanceCredit = Convert.ToDouble(sBalance);
            }
            if (BalanceCredit > 0)
            {
                tStatus = Check_UserSMSBalanceSufficient(Convert.ToDouble(iDeductSMSCredits), BalanceCredit);
            }
            else
            {
                tStatus = -1;
            }
        }
        else
        {
            tStatus = -1;
        }

        return tStatus;
    }
    public static int Check_UserSMSBalanceSufficient(Double iDeductSMSCredits, Double iBalanceCredit)
    {
        int iStatus;

        if (iBalanceCredit > iDeductSMSCredits)
        {
            iStatus = 1;
        }
        else if (iBalanceCredit <= 0)
        {
            iStatus = -1;
        }
        else
        {
            iStatus = -1;
        }
        return iStatus;
    }
}
