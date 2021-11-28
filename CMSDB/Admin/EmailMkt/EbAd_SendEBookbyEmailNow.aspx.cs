using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net.Mail;
using System.Net;

public partial class Admin_EmailMkt_EbAd_SendEBookbyEmailNow : System.Web.UI.Page
{
    DataSet ds;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();

    int tmpEmailCount=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region
            if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
            {
                Response.Redirect("~/SessionExpire.aspx");
            }
            #endregion 

            if (this.PreviousPage != null)
            {
                TextBox txtBookID = PreviousPage.Master.FindControl("ContentBody").FindControl("txtBookID") as TextBox;
                DropDownList ddlSignature = PreviousPage.Master.FindControl("ContentBody").FindControl("ddlSignature") as DropDownList;
                TextBox TextBoxYourName = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxYourName") as TextBox;
                TextBox TextBoxRemarks = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxRemarks") as TextBox;

                TextBox TextBoxName1 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName1") as TextBox;
                TextBox TextBoxName2 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName2") as TextBox;
                TextBox TextBoxName3 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName3") as TextBox;
                TextBox TextBoxName4 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName4") as TextBox;
                TextBox TextBoxName5 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName5") as TextBox;

                TextBox TextBoxEmail1 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail1") as TextBox;
                TextBox TextBoxEmail2 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail2") as TextBox;
                TextBox TextBoxEmail3 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail3") as TextBox;
                TextBox TextBoxEmail4 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail4") as TextBox;
                TextBox TextBoxEmail5 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail5") as TextBox;
                TextBox TextBoxSubject = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxSubject") as TextBox;

                ViewState["Remark"] = TextBoxRemarks.Text ;
                ViewState["SignOffMsg"] = ddlSignature.SelectedValue + ",";                
                ViewState["SenderName"] = TextBoxYourName.Text;
                ViewState["Subject"] = TextBoxSubject.Text;

                ViewState["EmailID1"] = "";
                ViewState["EmailID2"] = "";
                ViewState["EmailID3"] = "";
                ViewState["EmailID4"] = "";
                ViewState["EmailID5"] = "";

                ViewState["BookID"] = txtBookID.Text.ToUpper();
                ViewState["HTMLBody"] = "";
                ViewState["EnquiryEmailID"] = "";

                int j;
                String sRecipient = String.Empty;
                String sStatus = String.Empty;

                if(TextBoxEmail1.Text.Trim()!="")
                {
                    hdnEmail1.Value = TextBoxEmail1.Text.Trim();
                    j = CheckEmail(hdnEmail1.Value);

                    if (j == -1)
                    {
                        tmpEmailCount = tmpEmailCount + 1;
                        sStatus = "";
                        ViewState["EmailID1"] = "-1";

                    }
                    else
                    {
                        sStatus = " <font color='red'>[Unsubscribed Email]</font>";
                        ViewState["EmailID1"] = "1";
                    }

                    if (TextBoxName1.Text.Trim() != "")
                    {
                        hdnName1.Value = TextBoxName1.Text.Trim();
                        sRecipient = sRecipient + "&#8226  "  + TextBoxName1.Text + " <font color='blue'>" + TextBoxEmail1.Text + "</font>" + sStatus  + "<br/>";
                    }
                    else
                    {
                        sRecipient = sRecipient + "&#8226  <font color='blue'>" + TextBoxEmail1.Text + "</font>" + sStatus + "<br/>";
                    }
                    
                }
                if (TextBoxEmail2.Text.Trim() != "")
                {
                    hdnEmail2.Value = TextBoxEmail2.Text.Trim();
                    j = CheckEmail(hdnEmail2.Value);
                   
                    if (j == -1)
                    {
                        tmpEmailCount = tmpEmailCount + 1;
                        sStatus = "";
                        ViewState["EmailID2"] = "-1";
                    }
                    else
                    {
                        sStatus = " <font color='red'>[Unsubscribed Email]</font>";
                        ViewState["EmailID2"] = "1";
                    }
                    
                    if (TextBoxName2.Text.Trim() != "")
                    {
                        hdnName2.Value = TextBoxName2.Text.Trim();
                        sRecipient = sRecipient + "&#8226  "  + TextBoxName2.Text + " <font color='blue'>" + TextBoxEmail2.Text + "</font>" + sStatus + "<br/>";
                    }
                    else
                    {
                        sRecipient = sRecipient + "&#8226  <font color='blue'>" + TextBoxEmail2.Text + "</font" + sStatus + "<br/>";
                    }
                    
                }
                if (TextBoxEmail3.Text.Trim() != "")
                {
                    hdnEmail3.Value = TextBoxEmail3.Text.Trim();
                    j = CheckEmail(hdnEmail3.Value);

                    if (j == -1)
                    {
                        tmpEmailCount = tmpEmailCount + 1;
                        sStatus = "";
                        ViewState["EmailID3"] = "-1";
                    }
                    else
                    {
                        sStatus = " <font color='red'>[Unsubscribed Email]</font>";
                        ViewState["EmailID3"] = "1";
                    }

                    if (TextBoxName3.Text.Trim() != "")
                    {
                        hdnName3.Value = TextBoxName3.Text.Trim();
                        sRecipient = sRecipient + "&#8226  " + TextBoxName3.Text + " <font color='blue'>" + TextBoxEmail3.Text + "</font>" + sStatus + "<br/>";
                    }
                    else
                    {
                        sRecipient = sRecipient + "&#8226  <font color='blue'>" + TextBoxEmail3.Text + "</font" + sStatus + "<br/>";
                    }

                }
                if (TextBoxEmail4.Text.Trim() != "")
                {
                    hdnEmail4.Value = TextBoxEmail4.Text.Trim();
                    j = CheckEmail(hdnEmail4.Value);

                    if (j == -1)
                    {
                        tmpEmailCount = tmpEmailCount + 1;
                        sStatus = "";
                        ViewState["EmailID4"] = "-1";
                    }
                    else
                    {
                        sStatus = " <font color='red'>[Unsubscribed Email]</font>";
                        ViewState["EmailID4"] = "1";
                    }

                    if (TextBoxName4.Text.Trim() != "")
                    {
                        hdnName4.Value = TextBoxName4.Text.Trim();
                        sRecipient = sRecipient + "&#8226  " + TextBoxName4.Text + " <font color='blue'>" + TextBoxEmail4.Text + "</font>" + sStatus + "<br/>";
                    }
                    else
                    {
                        sRecipient = sRecipient + "&#8226  <font color='blue'>" + TextBoxEmail4.Text + "</font" + sStatus + "<br/>";
                    }

                }
                if (TextBoxEmail5.Text.Trim() != "")
                {
                    hdnEmail5.Value = TextBoxEmail5.Text.Trim();
                    j = CheckEmail(hdnEmail5.Value);

                    if (j == -1)
                    {
                        tmpEmailCount = tmpEmailCount + 1;
                        sStatus = "";
                        ViewState["EmailID5"] = "-1";
                    }
                    else
                    {
                        sStatus = " <font color='red'>[Unsubscribed Email]</font>";
                        ViewState["EmailID5"] = "1";
                    }

                    if (TextBoxName5.Text.Trim() != "")
                    {
                        hdnName5.Value = TextBoxName5.Text.Trim();
                        sRecipient = sRecipient + "&#8226  " + TextBoxName5.Text + " <font color='blue'>" + TextBoxEmail5.Text + "</font>" + sStatus + "<br/>";
                    }
                    else
                    {
                        sRecipient = sRecipient + "&#8226  <font color='blue'>" + TextBoxEmail5.Text + "</font" + sStatus + "<br/>";
                    }
                }
               
                lblTotalEmailListVal.Text = sRecipient;
                lblTotalEmailCountVal.Text = tmpEmailCount.ToString();
                lblSMSChgVal.Text = String.Format("{0:n2}", Convert.ToDecimal(tmpEmailCount*0.5));

                int iBalanceCreditStatus = Retrieve_UserAccountSMSBalance((tmpEmailCount * 0.5).ToString());
                GetEBookKeywordBookInfo();
            }
        }
    }        
    protected void GetEBookKeywordBookInfo()
    {
        ds = objBALebook.Ebook_RetrieveDetails(ViewState["BookID"].ToString(), Convert.ToInt32(Session["UserID"].ToString()), Session["MobileLoginID"].ToString().Replace("EB", ""));
        String tmpDomainUrl = Session["UserDomainURL"].ToString().Replace("http://", "");

        if (ds.Tables[0].Rows.Count > 0)
        {
            //Label Assignation
            //Response.Write(Session["UserID"].ToString());            

            String tmpHeaderTitle = "The Premier eBook Store";
            //SubHeader_Title.Text = tmpDomainUrl;

            DataRow utRow1 = ds.Tables[0].Rows[0];

            String tmpBFree = utRow1["BFree"].ToString();
            String tmpBSeller = utRow1["BSeller"].ToString();
            String tmpBFeature = utRow1["BFeature"].ToString();
            String tmpBNew = utRow1["BNew"].ToString();
            String tmpBValueBuy = utRow1["BValueBuy"].ToString();
            String tmpLogo = Session["UserDomainURL"].ToString() + utRow1["UserLogo"].ToString();
            String tmpImageFileName = String.Empty;
            String tmpEnquiryEmailID = String.Empty;
            
            DataRow utRow2;
            String tmpEbookID = String.Empty;
            String tmpEbookName = String.Empty;
            String tmpEbookCatName = String.Empty;
            String tmpEbookDateAdded = String.Empty;
            String tmpEbookCoverImg = String.Empty;
            String tmpCurrency = String.Empty;
            String tmpBookPrice = String.Empty;
            String tmpBookDiscountPrice = String.Empty;
            String tmpBookDesc = String.Empty;
            String tmpPurchaseButton = tmpPurchaseButton = "http://www.worlddigitalbiz.com/Images/ebImages/PayPalCreditCardBuyButton.gif";


            //Value Buy Variable
            String tmpEbookCount = String.Empty;
            String tmpBookName1 = String.Empty;
            String tmpBookName2 = String.Empty;
            String tmpBookName3 = String.Empty;
            String tmpBookName4 = String.Empty;
            String tmpBookName5 = String.Empty;
            String tmpBookCover1 = String.Empty;
            String tmpBookCover2 = String.Empty;
            String tmpBookCover3 = String.Empty;
            String tmpBookCover4 = String.Empty;
            String tmpBookCover5 = String.Empty;


            if (ds.Tables[1].Rows.Count > 0)
            {
                utRow2 = ds.Tables[1].Rows[0];

                tmpCurrency = utRow2["Denom"].ToString();
                tmpBookPrice = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookPrice"].ToString()));
                tmpBookDiscountPrice = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookDiscountedPrice"].ToString()));
                tmpBookDesc = utRow2["Description"].ToString();

                tmpEbookID = utRow2["BookID"].ToString();
                tmpEbookName = utRow2["BookName"].ToString();
                tmpEbookCatName = utRow2["CategoryName"].ToString();                
                DateTime dDate = Convert.ToDateTime(utRow2["DateCreated"].ToString());
                tmpEbookDateAdded = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dDate);


                if (tmpBValueBuy != "0")
                {
                    tmpEbookCount = utRow2["BooksCount"].ToString();
                    tmpBookName1 = utRow2["Book1Name"].ToString();
                    tmpBookName2 = utRow2["Book2Name"].ToString();
                    tmpBookName3 = utRow2["Book3Name"].ToString();
                    tmpBookName4 = utRow2["Book4Name"].ToString();
                    tmpBookName5 = utRow2["Book5Name"].ToString();

                    tmpBookCover1 = Session["UserDomainURL"].ToString() + "/" + utRow2["Book1ImageFileFullURL"].ToString();
                    tmpBookCover2 = Session["UserDomainURL"].ToString() + "/" + utRow2["Book2ImageFileFullURL"].ToString();
                    tmpBookCover3 = Session["UserDomainURL"].ToString() + "/" + utRow2["Book3ImageFileFullURL"].ToString();
                    tmpBookCover4 = Session["UserDomainURL"].ToString() + "/" + utRow2["Book4ImageFileFullURL"].ToString();
                    tmpBookCover5 = Session["UserDomainURL"].ToString() + "/" + utRow2["Book5ImageFileFullURL"].ToString();

                }
                else
                {
                    tmpEbookCoverImg = Session["UserDomainURL"].ToString() + "/" + utRow2["ImageFileName"].ToString();
                }

            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                tmpEnquiryEmailID = ds.Tables[2].Rows[0][0].ToString();
            }

            ViewState["EnquiryEmailID"] = tmpEnquiryEmailID;

            String tmpHeader_BookType = String.Empty;
            String tmpSubHeader_BookType = String.Empty;
            String tmpSender_Message = String.Empty;
            String tmpFooter_Message = String.Empty;
            String tmpPurchase_Format = String.Empty;
            String tmpSMS_Format = String.Empty;
            String tmpSend_SCode = String.Empty;
            String tmpPrice_Note = String.Empty;            
            String tmpPayPalStatus = "1";


            if (tmpBFree != "0")
            {
                tmpHeader_BookType = "FREE eBOOK!";
                tmpSubHeader_BookType = "Only at " + tmpDomainUrl + " !!";
                tmpSender_Message = tmpBookDesc;
                tmpPurchaseButton = "http://www.worlddigitalbiz.com/Images/ebImages/FREEebook2.gif";
                tmpBookDiscountPrice = "0.00";
                //tmpFooter_Message = "Experience the trill of shopping for ebooks with only a finger tip, visit our store today to find out why " + tmpDomainUrl + " is the fastest growing eBook Store on earth!";

            }
            else if (tmpBSeller != "0")
            {
                tmpHeader_BookType = "Best Selling Ebooks in Town!";
                tmpSubHeader_BookType = "Only at " + tmpDomainUrl + " !!";
                tmpSender_Message = tmpBookDesc;
                //tmpFooter_Message = "Still can't decide?  don't worry, check out the Best Seller for the most sought after ebooks...you won't go wrong! ";
            }
            else if (tmpBFeature != "0")
            {
                tmpHeader_BookType = "Feature Buy!";
                tmpSubHeader_BookType = "No ideas how to start?  Check out the Feature Buy for a series of good reads specially selected for you...";
                tmpSender_Message = tmpBookDesc;
                //tmpFooter_Message = "No ideas how to start?  Check out the Feature Buy for a series of good reads specially selected for you";

            }
            else if (tmpBNew != "0")
            {
                tmpHeader_BookType = "New Release";
                tmpSubHeader_BookType = "Below is my Latest eBook that I am confident you will like to check out:-";
                //tmpFooter_Message = "This is the Book You Must Read to Know all about WDB eBook Biz World Digital Biz ('WDB') eBook Biz Platform is the World's first eBook Business Platform that enable its owner/operator to instantly start a ebook business right from product activation. Not only that, WDB platform is the ONLY ebook platform, anywhere in the world, to incorporate SMS payment collection system. The best way to experience what we said about WDB ebook platform is to take out your mobile phone, send an SMS according to the SMS Purchase Format given. We assure you will be convinced!!";
            }
            else if (tmpBValueBuy != "0")
            {
                tmpHeader_BookType = "Value-Buy eBooks Promotion!";
                tmpSubHeader_BookType = "Get <font color='red' size='+2'><b>" + tmpEbookCount + "</b></font> eBooks for the Price of 1?? Only at <b> " + tmpDomainUrl + " </b>!!";
                tmpSender_Message = "Do not miss many more interesting ebooks that are on sale at  " + tmpDomainUrl + " , check them out today!Best of all, all ebooks in my store are sold at one <b><font color='red'>Flat Price of " + tmpCurrency + " " + tmpBookDiscountPrice + "</font></b> each for SMS purchase.  ";
                //tmpFooter_Message = "This is the Book You Must Read to Know all about WDB eBook Biz World Digital Biz ('WDB') eBook Biz Platform is the World's first eBook Business Platform that enable its owner/operator to instantly start a ebook business right from product activation. Not only that, WDB platform is the ONLY ebook platform, anywhere in the world, to incorporate SMS payment collection system. The best way to experience what we said about WDB ebook platform is to take out your mobile phone, send an SMS according to the SMS Purchase Format given. We assure you will be convinced!!";               
            }

            DataSet dsBook = objBALebook.Ebook_KeywordDetails_ByUserID(Convert.ToInt32(Session["UserID"].ToString()));

            if (dsBook.Tables[1].Rows.Count > 0)
            {
                DataRow utAccess = dsBook.Tables[1].Rows[0];

                if (utAccess[1].ToString() == "0")
                {
                    tmpPayPalStatus = "0";
                }
            }

            if (dsBook.Tables[0].Rows.Count > 0)
            {
                DataRow utKey = dsBook.Tables[0].Rows[0];
                if (tmpBFree == "0")
                {
                    string vendorCodeVal = utKey["vendorCode"].ToString();
                    string estoreidVal = utKey["eStoreID"].ToString();
                    string vCodeToDisp = string.Empty;
                    if (vendorCodeVal == estoreidVal)
                    {
                        vCodeToDisp = vendorCodeVal;
                    }
                    else
                    {
                        vCodeToDisp = vendorCodeVal + "&nbsp;" + estoreidVal;
                    }
                    //tmpPurchase_Format = utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " YourEmail YourName";
                    tmpPurchase_Format = vCodeToDisp + "&nbsp;" + ViewState["BookID"].ToString() + " YourEmail YourName";
                    tmpSMS_Format = utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " JohnWoo@yahoo.com John Woo ";
                    tmpSend_SCode = "SEND to 32828";
                    tmpPrice_Note = "<b>NOTE:-&nbsp;</b> <font color='#85335C'; font-weight:bold;>RM " + Convert.ToDecimal(utKey["Price"].ToString()) / 100 + "</font> &nbsp;per sms received.";
                }
                else
                {
                    string vendorCodeVal = utKey["vendorCode"].ToString();
                    string estoreidVal = utKey["eStoreID"].ToString();
                    string vCodeToDisp = string.Empty;
                    if (vendorCodeVal == "ZZ")
                    {
                        vCodeToDisp = estoreidVal;
                    }
                    else
                    {
                        vCodeToDisp = vendorCodeVal;
                    }

                    //tmpPurchase_Format = "FREE " + utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " YourEmail YourName";
                    tmpPurchase_Format = "FREE " + vCodeToDisp + "&nbsp;" + ViewState["BookID"].ToString() + " YourEmail YourName";
                    tmpSMS_Format = "FREE " + utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " JohnWoo@yahoo.com John Woo ";
                    tmpSend_SCode = "Send To      1) +60146367111   2) +447860034140   3) +6281297978822";
                    tmpPrice_Note = "";
                    tmpPayPalStatus = "0";
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sb.Append("<head><title></title>");
            sb.Append("<body>");
            sb.Append("<table width='750' cellpadding='0' cellspacing='0' style='border:1px solid #660033' bgcolor='#D63385'>");
            sb.Append("<tr><td width='202' bgcolor='#FFFFFF'>");
            sb.Append("<img src='" + tmpLogo + "' style='max-height:120px;max-width:154px' alt='" + tmpLogo + "'/>");
            sb.Append("</td>");
            sb.Append("<td style='padding:5px'><span><font style='font-family: Arial, sans-serif; font-size: large; font-weight:bold; color: #F5CCE0'>");
            sb.Append(tmpHeaderTitle);
            sb.Append("</font></span><br/>");
            sb.Append("<span><font style='font-family:Tahoma; font-size:medium; font-style:italic;'>");
            sb.Append("<a href='" + Session["UserDomainURL"].ToString() + "' style='color: #FFFFFF;text-decoration:none'>" + tmpDomainUrl + "</a>");
            sb.Append("</font></span>");
            sb.Append("</td></tr>");
            sb.Append("<tr><td colspan='2' bgcolor='#F5CCE0' align='left' style='padding:5px;height:50px'>");
            sb.Append("<font style='font-family: Arial, sans-serif;font-size:12px;'>" + ViewState["Remark"].ToString() + "</font>");
            sb.Append("<br/>");
            sb.Append("<br/><font style='font-family:Arial, sans-serif; font-size:small; font-weight:bold; color: #D63385'>" + ViewState["SignOffMsg"].ToString() + "</font>");
            sb.Append("<br/><b>" + ViewState["SenderName"].ToString() + "<b>");
            sb.Append("<br/>");
            sb.Append("</td></tr>");
            sb.Append("<tr><td colspan='2' align='left' style='padding-left:5px;padding-top:5px;padding-bottom:5px;'>");
            sb.Append("<font style='font-family:Arial, sans-serif; font-size:11px;color:#FFF'>Do you want to receive email updates?</font>");

            String strUnsubscribeURL = Session["UserDomainURL"].ToString() + "/Admin/EmailMkt/EbAd_UnSubscribeEmail.aspx?qID=" + Session["UserID"].ToString() + "&qEBookID=" + tmpEbookID + "&qEmail=@EMAILUNSUBSCRIBE@";
            //String strUnsubscribeURL = "EbAd_UnSubscribeEmail.aspx?qID=" + Session["UserID"].ToString() + "&qEBookID=" + tmpEbookID + "&qEmail=@EMAILUNSUBSCRIBE@";
            sb.Append("<a href='" + strUnsubscribeURL + "' style='font-family:Arial, sans-serif; font-size:11px;color:#000' target='_blank'>Unsubscribe Here</a>");
            sb.Append("<br/>");
            sb.Append("</td></tr>");
            //Header
            sb.Append("<tr><td colspan='2' bgcolor='#F5CCE0' style='padding:5px'");
            sb.Append("<span><font style='font-family:Arial, sans-serif; font-size:large; font-weight:bold; color: #D63385'>");
            sb.Append(tmpHeader_BookType);
            sb.Append("</font></span><br />");
            sb.Append("<span><font style='font-family:Tahoma; font-size:small; font-style:italic; color: #D63385'>");
            sb.Append(tmpSubHeader_BookType);
            sb.Append("</font></span>");
            sb.Append("</td></tr>");
            //sb.Append("<tr><td colspan='2' align='center' style='padding:5px'><font style='font-family:Arial, sans-serif; font-size:12px; color:#FFFFFF;'>");
            //sb.Append(tmpFooter_Message + "</font>");
            //sb.Append("</td></tr>");            

            if (tmpBValueBuy == "0")
            {
                sb.Append("<tr><td colspan='2'>");

                //-------------------------------------------------------
                //Table 1
                sb.Append("<table cellpadding='0' cellspacing='0' width='100%' style='border: solid 1px #A30052; padding:3px; background-color: #EFEFEF;'>");
                sb.Append("<tr><td width='250'>&nbsp;</td>");
                sb.Append("<td>&nbsp;</td></tr>");
                sb.Append("<tr><td align='center' valign='top'><img id='ImageEbooks' class='ebBookDefaultImgCss' src='" + tmpEbookCoverImg + "' style='max-height: 330px;max-width: 230px;' /></td>");
                sb.Append("<td valign='top' >");
                //sb.Append("<td valign='top'><font style='font-family:Arial, sans-serif; font-size:small; font-weight:bold; color: #D63385'>" + lbl_SenderName.Text + "</font><br/>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>" + tmpBookDesc + " </font>");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("<table cellpadding='0' cellspacing='0' width='100%' style='border:1px solid #E680B2;background-color: #F5CCE0;'>");
                sb.Append("<tr><td width='30%' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>eBook ID</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>: " + tmpEbookID + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>eBook Name</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>: " + tmpEbookName + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>Category</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>: " + tmpEbookCatName + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>Date Created</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>: " + tmpEbookDateAdded + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>Original Price</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Verdana; font-size:small; color:Red;'><b>: " + tmpCurrency + "</b></font>&nbsp;<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>" + tmpBookPrice + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>Discounted Price</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Verdana; font-size:small; color:Red;'><b>: " + tmpCurrency + "</b></font>&nbsp;<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>" + tmpBookDiscountPrice + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td colspan='2' bgcolor='#fff' height='30px' align='center' valign='middle'>");

                if (tmpPayPalStatus == "1")
                {
                    String strURL = Session["UserDomainURL"].ToString() + "/eBookShowDetails.aspx?qBookID=" + tmpEbookID;
                    String CallingPageUri = Request.Url.AbsoluteUri;

                    sb.AppendFormat("<form id='form1' name='form1' action='{0}' method='get'>", strURL);
                    sb.Append("<a href='" + strURL + "' target='_blank'> ");
                    sb.AppendFormat("<img src='{0}' alt=''/></a>", tmpPurchaseButton);
                    // Start Collecting Parameters                
                    sb.AppendFormat("<input type='hidden' name='qBookID' value='{0}'>", ViewState["BookID"].ToString());
                    sb.AppendFormat("<input type='hidden' name='qUserID' value='{0}'>", Session["UserID"].ToString());
                    sb.AppendFormat("<input type='hidden' name='qCallingPage' value='{0}'>", CallingPageUri);
                    // End
                    sb.Append("</form>");
                }
                else
                {
                    sb.Append("<img src='" + tmpPurchaseButton + "' alt=''/>");
                }
                sb.Append("</td></tr>");
                sb.Append("</table>");
                //                          
                sb.Append("<br/>");
                //-------------------------------------------------------
                //Table 2
                sb.Append("<table cellpadding='0' cellspacing='0' width='100%' style='border:1px solid #E680B2;background-color:#FFFFFF;padding:5px'>");
                sb.Append("<tr>");
                sb.Append("<td align='left'>");
                sb.Append("<font style='font-family:Arial, sans-serif; font-size:11px; font-weight: bold;color: rgb(146, 46, 197)'>Malaysia Mobile Purchase - SMS Purchase Format</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' style='padding:5px;text-shadow:rgb(170, 170, 170) 1px 0px 1px;letter-spacing: 1px;text-transform: capitalize;'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, sans-serif;font-size:16px;font-weight: bold;line-height: 16px;color: rgb(255, 48, 0);'>");
                sb.Append(tmpPurchase_Format + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' style=' text-align: right;padding: 2px; '>");
                sb.Append("<font style='font-family: Verdana, sans-serif;font-size:11px; color : rgb(233, 29, 235);'>");
                sb.Append("<b>" + tmpSend_SCode + "</b></font>");
                sb.Append("</td></tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' style='border-top : 1px solid rgb(146, 46, 197) ; padding-top: 2px; '>");
                sb.Append("<font style='font-family: Arial, sans-serif, sans-serif;font-size:11px; color:rgb(159, 77, 17);'>");
                sb.Append(tmpPrice_Note + " For e.g " + tmpSMS_Format + "</font>");
                sb.Append("</td></tr>");
                sb.Append("</table>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
                sb.Append("</table>");

                //-------------------------------------------------------
                sb.Append("</td></tr>");
            }
            else
            {
                sb.Append("<tr><td colspan='2' align='center'>");
                sb.Append("<table border='0' cellspacing='2' cellpadding='1' width='90%' style='font-family:Tahoma;font-size:11px;color:#000;'>");
                sb.Append("<tr>");
                if (tmpBookName1 != "")
                {
                    sb.Append("<td id='dvBook1' align='center' valign='top' style='border: 1px dotted #BAC0C7;background-color:#fff;padding: 2px;width: 110px;height: 120px;'>");
                    sb.Append(tmpBookName1);
                    sb.Append("<br/><img id='ImageEbooks1' src='" + tmpBookCover1 + "' style='max-height: 90px;max-width: 100px;' />");
                    sb.Append("</td>");
                }
                if (tmpBookName2 != "")
                {
                    sb.Append("<td id='dvBook2' align='center' valign='top' style='border: 1px dotted #BAC0C7;background-color:#fff;padding: 2px;width: 110px;height: 120px;'>");
                    sb.Append(tmpBookName2);
                    sb.Append("<br/><img id='ImageEbooks2' src='" + tmpBookCover2 + "' style='max-height: 90px;max-width: 100px;' />");
                    sb.Append("</td>");
                }
                if (tmpBookName3 != "")
                {
                    sb.Append("<td id='dvBook3' align='center' valign='top' style='border: 1px dotted #BAC0C7;background-color:#fff;padding: 2px;width: 110px;height: 120px;'>");
                    sb.Append(tmpBookName3);
                    sb.Append("<br/><img id='ImageEbooks3' src='" + tmpBookCover3 + "' style='max-height: 90px;max-width: 100px;' />");
                    sb.Append("</td>");
                }
                if (tmpBookName4 != "")
                {
                    sb.Append("<td id='dvBook4' align='center' valign='top' style='border: 1px dotted #BAC0C7;background-color:#fff;padding: 2px;width: 110px;height: 120px;'>");
                    sb.Append(tmpBookName4);
                    sb.Append("<br/><img id='ImageEbooks4' src='" + tmpBookCover4 + "' style='max-height: 90px;max-width: 100px;' />");
                    sb.Append("</td>");
                }
                if (tmpBookName5 != "")
                {
                    sb.Append("<td id='dvBook5' align='center' valign='top' style='border: 1px dotted #BAC0C7;background-color:#fff;padding: 2px;width: 110px;height: 120px;'>");
                    sb.Append(tmpBookName5);
                    sb.Append("<br/><img id='ImageEbooks5 src='" + tmpBookCover5 + "' style='max-height: 90px;max-width: 100px;' />");
                    sb.Append("</td>");
                }
                sb.Append("</tr></table>");
                sb.Append("</td></tr>");                
                sb.Append("<tr><td colspan='2' align='center' bgColor='#EFEFEF'>");
                sb.Append("<table cellpadding='0' cellspacing='0' width='70%' style='border:1px solid #E680B2;background-color: #F5CCE0;'>");
                sb.Append("<tr><td width='30%' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>eBook ID</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>: " + tmpEbookID + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>eBook Name</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>: " + tmpEbookName + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>Number of Books</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>: " + tmpEbookCount + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>Date Created</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>: " + tmpEbookDateAdded + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>Original Price</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Verdana; font-size:small; color:Red;'><b>: " + tmpCurrency + "</b></font>&nbsp;<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>" + tmpBookPrice + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr><td style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2'><font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'><b>Discounted Price</b></font></td>");
                sb.Append("<td bgcolor='#F0B2D1' style='padding-left:5px;padding-top:7px;border-bottom:1px solid #E680B2;border-left:1px solid #E680B2'>");
                sb.Append("<font style='font-family:Verdana; font-size:small; color:Red;'><b>: " + tmpCurrency + "</b></font>&nbsp;<font style='font-family:Trebuchet MS, Lucida Console, Arial, sans-serif; font-size:small;'>" + tmpBookDiscountPrice + "</font>");
                sb.Append("</td></tr>");

                sb.Append("<tr><td colspan='2' bgcolor='#fff' height='30px' align='center' valign='middle' >");

                String strURL = Session["UserDomainURL"].ToString() + "/eBookShowValueBuyDetails.aspx?qBookID=" + tmpEbookID;
                String CallingPageUri = Request.Url.AbsoluteUri;

                sb.AppendFormat("<form id='form1' name='form1' action='{0}' method='get'>", strURL);
                sb.Append("<a href='" + strURL + "' target='_blank'>");
                sb.AppendFormat("<img src='{0}' alt=''/></a>", tmpPurchaseButton);
                // Start Collecting Parameters

                sb.AppendFormat("<input type='hidden' name='qBookID' value='{0}'>", ViewState["BookID"].ToString());
                sb.AppendFormat("<input type='hidden' name='qUserID' value='{0}'>", Session["UserID"].ToString());
                sb.AppendFormat("<input type='hidden' name='qCallingPage' value='{0}'>", CallingPageUri);

                // End
                sb.Append("</form>");
                sb.Append("</td></tr>");
                sb.Append("</table>");
                sb.Append("</td></tr>");
                //
                sb.Append("<tr><td colspan='2' align='center' bgcolor='#F5CCE0'>");
                sb.Append("<table cellpadding='0' cellspacing='0' width='70%' style='border:1px solid #E680B2;background-color:#FFFFFF;padding:5px'>");
                sb.Append("<tr>");
                sb.Append("<td align='left'>");
                sb.Append("<font style='font-family:Arial, sans-serif; font-size:11px; font-weight: bold;color: rgb(146, 46, 197)'>Malaysia Mobile Purchase - SMS Purchase Format</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' style='padding:5px;text-shadow:rgb(170, 170, 170) 1px 0px 1px;letter-spacing: 1px;text-transform: capitalize;'>");
                sb.Append("<font style='font-family:Trebuchet MS, Lucida Console, sans-serif;font-size:16px;font-weight: bold;line-height: 16px;color: rgb(255, 48, 0);'>");
                sb.Append(tmpPurchase_Format + "</font>");
                sb.Append("</td></tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' style=' text-align: right;padding: 2px; '>");
                sb.Append("<font style='font-family: Verdana, sans-serif;font-size:11px; color : rgb(233, 29, 235);'>");
                sb.Append("<b>" + tmpSend_SCode + "</b></font>");
                sb.Append("</td></tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' style='border-top : 1px solid rgb(146, 46, 197) ; padding-top: 2px; '>");
                sb.Append("<font style='font-family: Arial, sans-serif, sans-serif;font-size:11px; color:rgb(159, 77, 17);'>");
                sb.Append(tmpBookPrice + " For e.g " + tmpSMS_Format + "</font>");
                sb.Append("</td></tr>");
                sb.Append("</table>");
                sb.Append("</td></tr>");
            }      
            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");
            Literal1.Text = sb.ToString();
            ViewState["HTMLBody"] = sb.ToString();            
        }
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
                lblSMSBalVal.Text = String.Format("{0:n2}", Convert.ToDecimal(sBalance));
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        int iBalanceCreditStatus = Retrieve_UserAccountSMSBalance(lblSMSChgVal.Text);
        string sEmailList = string.Empty;
        int i = 0;
        if (iBalanceCreditStatus != 1)
        {
            CommonFunctions.AlertMessageAndRedirect("Sorry Insufficient Balance.Kindly Top your SMS", @"SMS/EbAd_SMSTopup.aspx");
        }
        else
        {
            if (ViewState["EmailID1"].ToString() == "-1")
            {
                i = i +1;
                sEmailList = sEmailList + "," + hdnEmail1.Value;
                SendEmailIndividual(hdnName1.Value, hdnEmail1.Value);
            }
            if (ViewState["EmailID2"].ToString() == "-1")
            {
                i = i + 1;
                sEmailList = sEmailList + "," + hdnEmail2.Value;
                SendEmailIndividual(hdnName2.Value, hdnEmail2.Value);
            }
            if (ViewState["EmailID3"].ToString() == "-1")
            {
                i = i + 1;
                sEmailList = sEmailList + "," + hdnEmail3.Value;
                SendEmailIndividual(hdnName3.Value, hdnEmail3.Value);
            }
            if (ViewState["EmailID4"].ToString() == "-1")
            {
                i = i + 1;
                sEmailList = sEmailList + "," + hdnEmail4.Value;
                SendEmailIndividual(hdnName4.Value, hdnEmail4.Value);
            }
            if (ViewState["EmailID5"].ToString() == "-1")
            {
                i = i + 1;
                sEmailList = sEmailList + "," + hdnEmail5.Value;
                SendEmailIndividual(hdnName5.Value, hdnEmail5.Value);
            }

            if (i > 0)
            {
                sEmailList = sEmailList.Substring(1, sEmailList.Length - 1);
                int tmpStatus = objMalaysia.Insert_EbookEmailMarketing(Session["MERID"].ToString(), ViewState["BookID"].ToString(), "1", "0", i.ToString(), "0", "Ebook ID " + ViewState["BookID"].ToString(), ViewState["Subject"].ToString(), ViewState["HTMLBody"].ToString(), "", sEmailList);

                CommonFunctions.AlertMessageAndRedirect("Email Sent Successfully", @"EbAd_EmailEbookHistory.aspx");
            }
            else
            {
                CommonFunctions.AlertMessageAndRedirect("No Email To Sent Out.Email is under unsubscribed list", @"EbAd_UnsubscribeEmailsHistory.aspx");    
            }
        }
    }
    protected void SendEmailIndividual(String sName,String sEmail)
    {
        #region sending Email using HmailServer.

        //hMailServer.Application objApp_Hmail = new hMailServer.Application();

        //hMailServer.Message objMsg_Hmail = new hMailServer.Message();
        //objMsg_Hmail.From = ViewState["EnquiryEmailID"].ToString();
        //objMsg_Hmail.FromAddress = ViewState["EnquiryEmailID"].ToString();

        //objMsg_Hmail.Subject = ViewState["Subject"].ToString();
        //String sHtmlBody = ViewState["HTMLBody"].ToString().Replace("@EMAILUNSUBSCRIBE@", sEmail);
        //objMsg_Hmail.HTMLBody = sHtmlBody;        
        //objMsg_Hmail.AddRecipient(sName, sEmail);
        //objMsg_Hmail.Save();
        //objMsg_Hmail.ClearRecipients();
        
        #endregion



        #region Sending mail using SmarterMail

        String vEmailToName = sName; 
        String vEmailToAddress = sEmail;

        String vEmailFromName = ViewState["EnquiryEmailID"].ToString(); 
        String VEmailFromAddress = ViewState["EnquiryEmailID"].ToString(); 

        String vEmailSubject = ViewState["Subject"].ToString();
        String sHtmlBody = ViewState["HTMLBody"].ToString().Replace("@EMAILUNSUBSCRIBE@", sEmail);


        SmtpClient smtpClient = new SmtpClient();
        MailMessage objMessage = new MailMessage();
        string m_fromName = string.Empty;
        try
        {


            m_fromName = "EBookAdmin";
            vEmailFromName = "EBookAdmin";
            VEmailFromAddress = "noreply@ebooksmsdelivery.com";

            MailAddress m_fromAddress = new MailAddress(VEmailFromAddress, vEmailFromName);
            smtpClient.Host = "localhost";
            smtpClient.Port = 25;

            objMessage.From = m_fromAddress;

            objMessage.To.Add(vEmailToAddress);
            objMessage.Subject = vEmailSubject;


            objMessage.IsBodyHtml = true;
            objMessage.Body = sHtmlBody;


            //String tmpeBookfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();


            //if (File.Exists(Server.MapPath(tmpeBookfileFolder + "/" + eAttachment)))
            //{
            //    Attachment objAtt = new Attachment(Server.MapPath(tmpeBookfileFolder + "/" + eAttachment));
            //    objMessage.Attachments.Add(objAtt);
            //}



            //NetworkCredential authinfo = new NetworkCredential("help", "gsurf123");
            NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = authinfo;

            // Send SMTP mail
            smtpClient.Send(objMessage);



        }
        catch (Exception ex)
        {
            throw ex;

        }

        #endregion




    }

    protected int CheckEmail(String sEmail)
    {
        ds = objBALebook.Retrieve_UnSubscribedEmail(Session["UserID"].ToString(),"1","1"," and Deleted=0 and Email='" + sEmail + "'");
        
        if(ds.Tables[0].Rows.Count>0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

}

