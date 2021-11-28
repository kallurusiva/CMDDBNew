using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using CMSv3.BAL;
using System.Configuration;
using System.IO;


public partial class eBooksBuyPPsuccess2 : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    //DataTable dt;
    int qCatID = 0;
    string vCurrency = string.Empty;

    String vBookID = String.Empty;
    String vCallingPage = String.Empty;

    
    String vBookName = string.Empty;

    String qTransactionId = string.Empty;
    String qTransactionType = string.Empty;
    String qPytFee = string.Empty;
    String qPytAmount = String.Empty;
    String qPytStatus = String.Empty; 
    String qCurrencyCode = String.Empty;
    String qCustomText = String.Empty;

    String qUniqueID = string.Empty;
    String qitemNumber = String.Empty;



    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = "~/UserEbookMaster.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       

        #region //rendering top left panel 

        //if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet")) 
        //{

        //    HtmlGenericControl myDivObject;
        //    myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        //    //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
        //    sb.Append("<tr>");
        //    sb.Append("<td align='left' valign='top'>");
        //    sb.Append("<img src='Images/table_top_Leftarc.gif' />");
        //    sb.Append("</td>");
        //    sb.Append("<td>");
        //    sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
        //    sb.Append("</td>");
        //    sb.Append("</tr>");
        //    sb.Append("</table>");

        //    myDivObject.InnerHtml = sb.ToString();

        //    //myDivObject.InnerHtml = "<table border='0' class='dvBannerLeftPanel'><tr><td><img alt='imbnLeftimg' src='Images/faq_head.jpg' /> </td></tr></table>";
        //}
        #endregion 


        String ctMobileNo = string.Empty;
        String ctUserID = string.Empty;
        String ctUniqueID = string.Empty;
        String ctWebSite = string.Empty; 

        if (!IsPostBack)
        {

            ViewState["BookId"] = "";
            ViewState["ClientID"] = "";
            ViewState["CallingPageURi"] = ""; 

             

            if (Request.QueryString.Count > 0)
            {

                //foreach (String key in Request.QueryString.AllKeys)
                //{
                //    Response.Write(key + " : " + Request.QueryString[key] + "<br/>");
                //}


                //TransactionID=6GB22756T5193811L
                //&PytAmount=1.00
                //&PytStatus=Completed
                //&CurrencyCode=USD
                //&itemNumber=EC1213
                //&UniqueID=7729473507
                //&CustomText=60149664566_7729_7729473507_WorldDigitalBiz.com_0%23EC1213%231.00%23USD%23WDB%23lohchuenleong%40gmail.com%2360149664566


                qTransactionId = Request.QueryString["TransactionID"].ToString();
                qPytStatus = Request.QueryString["PytStatus"].ToString();
                qPytAmount = Request.QueryString["PytAmount"].ToString();
                qCurrencyCode = Request.QueryString["CurrencyCode"].ToString();
                qUniqueID = Request.QueryString["UniqueID"].ToString();
                qitemNumber = Request.QueryString["itemNumber"].ToString();
                qCustomText = Request.QueryString["CustomText"].ToString();


                StoreReturnedValues(qTransactionId, qPytStatus, qPytAmount, qCurrencyCode, qUniqueID,qitemNumber, qCustomText);
                
                


                lblTxDetails.Text = qTransactionId;
                
                decimal vPytAmount = Convert.ToDecimal(qPytAmount);
                lblPytMade.Text = qCurrencyCode + " " + String.Format("{0:n2}", vPytAmount); //  tmpBookPrice = tmpBookCurrency + " " + String.Format("{0:n2}", qPytAmount);

                lblPytStatus.Text = qPytStatus;
                vBookID = qitemNumber;

               

                // 60149664566_7550_7550378922_smsbizsolution.com_0 #EE1516 #5.00 #USD #EBS #hari_Biz@globalsurf.com.my #60149664566
                // vClientID + "#" + vBookID + "#" + vBookPrice + "#" + vBookCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;
                // 60149664566_7550_7550104455_smsbizsolution.com_0
                // Response.Write(vCustomText + "#" + vBookID + "#" + vBookPrice + "#" + vBookCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile);

   
          



            }
            

           
          
            

        }


    }


    protected void StoreReturnedValues(String qTransactionId, String qPytStatus, String qPytAmount, String qCurrencyCode, String qUniqueID, String qitemNumber, String qCustomText)
    {


        //Custom Message
        String[] StringArray = qCustomText.Split('_');

        String tmpMobileNo = StringArray[0];
        String tmpUserID = StringArray[1];
        String tmpUniqueID = StringArray[2];
        String tmpWebsite = StringArray[3];
        String tmpCustomMsg = StringArray[4];

        String[] CmArray = tmpCustomMsg.Split('#');

        Session["ClientID"] = tmpUserID;


        //vUserID + "#" + vBookID + "#" + vBookPrice + "#" + vBookCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;

        String tmpUserID2 = CmArray[0];
        String tmpBookID = CmArray[1];
        String tmpBookPrice = CmArray[2];
        String tmpCurrency = CmArray[3];
        String tmpeStoreID = CmArray[4];
        String tmpBusiness = CmArray[5];
        String tmpBuyerMobile = CmArray[6];


        CMSv3.BAL.PayPal objPayPal = new CMSv3.BAL.PayPal();

        objPayPal.EB_PostPaymentDetails_Update(qTransactionId, qPytStatus, qPytAmount, qCurrencyCode, qUniqueID, qitemNumber, qCustomText);

        SendBookByMail(qUniqueID, qitemNumber, tmpUserID);

        LoadCategories(Convert.ToInt32(tmpUserID));
        LoadBookDetails(qitemNumber, Convert.ToInt32(tmpUserID)); 
             

    }

    protected void SendBookByMail(String vUniqueId, String vItemNumber, String vUserId)
    {

        CMSv3.BAL.PayPal objPayPal = new CMSv3.BAL.PayPal();

        ds = objPayPal.EB_PayPal_RetrieveDetailsByUniqueID(vUniqueId, vItemNumber, Convert.ToInt32(vUserId));
        DataTable dtTx = ds.Tables[0];

        if (dtTx.Rows.Count > 0)
        {

            DataRow Drow = dtTx.Rows[0];


           String vUserName = Drow["UserName"].ToString();
           String vMobileNo = Drow["MobileNo"].ToString();
           String vBuyerEmail = Drow["BuyerEmail"].ToString();
           String vBookID = Drow["ItemNumber"].ToString();


           if (vBookID.Substring(0, 3).ToUpper() == "EVB")
           {
              Send_ValueBuy_Ebook(vBookID, vUserName, vBuyerEmail);

           }

           else
           {
               Send_Ebook(vBookID,vUserName, vBuyerEmail);
           }
            
        }



    }

    protected void LoadBookDetails(String vBookID, int vUserID)
    {
        ds = objBALebook.Eb_WEB_BuyBook(vBookID, vUserID);
        DataTable dtBook = ds.Tables[0];



        if (dtBook.Rows.Count > 0)
        {
            DataRow krow = dtBook.Rows[0];


            lblBookID.Text = krow["BookID"].ToString();
            lblBookName.Text = krow["BookName"].ToString();

            String tmpBookPrice = krow["NetPrice"].ToString();
            String tmpBookCurrency = krow["UserCurrency"].ToString();

            ImgEbook.ImageUrl = krow["ImageFileFullURL"].ToString();


            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice);
                tmpBookPrice = tmpBookCurrency + " " + String.Format("{0:n2}", vPrice);

            }

            //
            //String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));
           // lblTxDetails.Text = tmpBookPrice;


        }
    }
 
    protected void LoadCategories(int vUserId)
    {


        ds = objBALebook.Category_Listing_ByUserID(vUserId, "");
        DataTable dtUserCats = ds.Tables[0];
        DataTable dtAdminCats = ds.Tables[1];


        string tmpstr = string.Empty;

        StringBuilder sbCats = new StringBuilder();




        string tmpCatItem = string.Empty;
        int tmpCatID = 0;

        if (dtUserCats.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dtUserCats.Rows[0];

            sbCats.AppendLine("<h2>My Categories</h2>");
            sbCats.AppendLine("<div class='menu_simple'>");
            sbCats.AppendLine("<br/>");
            sbCats.AppendLine("<ul>");


            foreach (DataRow cRow in dtUserCats.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                if (tmpCatID == qCatID)
                {
                    tmpCatItem = "<li><a class='current' href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                else
                {
                    tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                sbCats.AppendLine(tmpCatItem);
            }

            sbCats.AppendLine("</ul>");
            sbCats.AppendLine("</div>");


        }
        else
        {


        }


        if (dtAdminCats.Rows.Count > 0)
        {

            sbCats.AppendLine("<div class='menu_simple'>");
            // sbCats.AppendLine("<span class='eb_head2'>Categories</span>");
            sbCats.AppendLine("<h2>Categories</h2>");
            sbCats.AppendLine("<br/>");
            sbCats.AppendLine("<ul>");

            DataRow tRows = (DataRow)dtAdminCats.Rows[0];

            foreach (DataRow cRow in dtAdminCats.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                if (tmpCatID == qCatID)
                {
                    tmpCatItem = "<li><a class='current' href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                else
                {
                    tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                sbCats.AppendLine(tmpCatItem);
            }

            sbCats.AppendLine("</ul>");
            sbCats.AppendLine("</div>");

        }






        dvLeftContent.InnerHtml = sbCats.ToString();


    }


    protected void Send_Ebook(String vBookID, string vFullName, String vEmailID)
    {

        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.EBOOK_GetBook2EmailDetails(vBookID);
        DataTable dt = ds.Tables[0];


        if (dt.Rows.Count > 0)
        {

            DataRow drow = dt.Rows[0];


            String eSubject = drow["eSubject"].ToString();
            String eSenderEmailID = drow["esenderEmailID"].ToString();
            String eMessage = drow["eMessage"].ToString();
            String eAttachment = drow["eAttachment"].ToString();
            String BookImage = drow["ImageFileName"].ToString();
            String BookImageURL = "http://210.5.45.8/DocumentRepository/eBookImages/" + BookImage;
            String BookImageHtml = " <img style='max-height: 205px; max-width: 165px;'  src='" + BookImageURL + "' />";

            eMessage = eMessage.Replace(Environment.NewLine, "<br/>");



            string tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head >
                                <title></title>
                                <style type='text/css'>
                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
                                </style>
                                </head>
                                <body>
                                    <div id='dvEmail' class='dvemailBox'> 
                                    <div id='dvHeader' style='align-content: center;'>
                                            <img src='http://210.5.45.8/Images/ebImages/bookimgbanner.jpg' />
                                                    <br />
                                     </div>
                                    <div id='dvContent' style='font: bold 12px Verdana'>
                                    "
                       + eMessage +

                       @"
                                </div>
                            <div id='dvBookImage'>"

                       + BookImageHtml +

                            @"</div>


                                </div>
   
                            </body>
                            </html>
                            ";




            #region sending Email using HmailServer.

            hMailServer.Application objApp_Hmail = new hMailServer.Application();

            hMailServer.Message objMsg_Hmail = new hMailServer.Message();

            objMsg_Hmail.AddRecipient(vFullName, vEmailID);

            objMsg_Hmail.From = eSenderEmailID;
            objMsg_Hmail.FromAddress = eSenderEmailID;

            objMsg_Hmail.Subject = eSubject;

            objMsg_Hmail.HTMLBody = tmpHtmlBody;

            String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();


            if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment)))
            {
                objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment)));
            }

            objMsg_Hmail.Save();

            //Response.Write(eSubject + "<br>");
            //Response.Write(vEmailID + "<br>");
            //Response.Write(Server.MapPath((tmpEbfileFolder + "/" + eAttachment)) + "<br>");
            //Response.Write(tmpHtmlBody + "<br>");



            //CommonFunctions.AlertMessage("Email has been Sent");



            #endregion

        }

    }


    protected void Send_ValueBuy_Ebook(String vBookID, string vFullName, String vEmailID)
    {

        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.EBOOK_GetBook2EmailDetails2(vBookID);
        DataTable dt = ds.Tables[0];

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




            eMessage = eMessage.Replace(Environment.NewLine, "<br/>");

            string tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml'>
                                <head >
                                <title></title>
                                <style type='text/css'>
                                    .dvemailBox {border: 5px solid #BAC0C7;  padding: 15px; }
                                </style>
                                </head>
                                <body>
                                    <div id='dvEmail' class='dvemailBox'> 
                                    <div id='dvHeader' style='align-content: center;'>
                                            <img src='http://210.5.45.8/Images/ebImages/bookimgbanner.jpg' />
                                                    <br />
                                     </div>
                                    <div id='dvContent' style='font: bold 12px Verdana'>
                                    "
                       + eMessage +

                       @"
                                </div>
                                </div>
   
                            </body>
                            </html>
                            ";


            #region sending Email using HmailServer.

            hMailServer.Application objApp_Hmail = new hMailServer.Application();

            hMailServer.Message objMsg_Hmail = new hMailServer.Message();

            objMsg_Hmail.AddRecipient(vFullName, vEmailID);

            objMsg_Hmail.From = eSenderEmailID;
            objMsg_Hmail.FromAddress = eSenderEmailID;

            objMsg_Hmail.Subject = eSubject;

            objMsg_Hmail.HTMLBody = tmpHtmlBody;

            String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();

            // == ATTACHEMENT    1   ===

            if (eAttachment1 != "")
            {
                if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment1)))
                {
                    objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment1)));
                }
            }

            // == ATTACHEMENT    2   ===
            if (eAttachment2 != "")
            {
                if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment2)))
                {
                    objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment2)));
                }
            }

            // == ATTACHEMENT    3   ===
            if (eAttachment3 != "")
            {
                if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment3)))
                {
                    objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment3)));
                }
            }

            // == ATTACHEMENT    4   ===
            if (eAttachment4 != "")
            {
                if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment4)))
                {
                    objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment4)));
                }
            }

            // == ATTACHEMENT    5   ===
            if (eAttachment5 != "")
            {
                if (File.Exists(Server.MapPath(tmpEbfileFolder + "/" + eAttachment5)))
                {
                    objMsg_Hmail.Attachments.Add(Server.MapPath((tmpEbfileFolder + "/" + eAttachment5)));
                }
            }

            objMsg_Hmail.Save();



           // CommonFunctions.AlertMessage("Email has been Sent");



            #endregion



        }

    }

}




