using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Admin_EbAd_SendEBookbyEmailNow : System.Web.UI.Page
{
    DataSet ds;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 

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

                lbl_SenderName.Text = "<b>Hi " + TextBoxName1.Text + "</b>,";
                lbl_EmailCompliment.Text = ddlSignature.SelectedValue + ",";
                lbl_EmailSenderName.Text = "<b>" + TextBoxYourName.Text + "</b>";
                lblRemark.Text = TextBoxRemarks.Text;

                ViewState["BookID"] = txtBookID.Text.ToUpper();

                GetEBookKeywordBookInfo();
            }
        }
    }        
    protected void GetEBookKeywordBookInfo()
    {
        ds = objBALebook.Ebook_RetrieveDetails(ViewState["BookID"].ToString(), Convert.ToInt32(Session["UserID"].ToString()), Session["MobileLoginID"].ToString().Replace("EB", ""));

        if (ds.Tables[0].Rows.Count > 0)
        {
            //Label Assignation
            //Response.Write(Session["UserID"].ToString());
            
            String tmpDomainUrl = Session["UserDomainURL"].ToString().Replace("http://", "");
            Header_Title.Text = "The Premier eBook Store";
            SubHeader_Title.Text = tmpDomainUrl;

            DataRow utRow1 = ds.Tables[0].Rows[0];

            String tmpBFree = utRow1["BFree"].ToString();
            String tmpBSeller = utRow1["BSeller"].ToString();
            String tmpBFeature = utRow1["BFeature"].ToString();
            String tmpBNew = utRow1["BNew"].ToString();
            String tmpBValueBuy = utRow1["BValueBuy"].ToString();

            DataRow utRow2;

            String tmpBookCount = String.Empty;
            String tmpCurrency = String.Empty;
            String tmpBookPrice = String.Empty;
            String tmpBookDiscountPrice = String.Empty;
            String tmpBookDesc = String.Empty;

            if (ds.Tables[1].Rows.Count > 0)
            { 
                utRow2 = ds.Tables[1].Rows[0];

                tmpCurrency = utRow2["Denom"].ToString();
                tmpBookPrice = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookPrice"].ToString()));
                tmpBookDiscountPrice = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookDiscountedPrice"].ToString()));
                tmpBookDesc = utRow2["Description"].ToString();

                lblBookID.Text  = utRow2["BookID"].ToString();
                lblBookName.Text = utRow2["BookName"].ToString();
                lblCategory.Text = utRow2["CategoryName"].ToString();

                DateTime dDate = Convert.ToDateTime(utRow2["DateCreated"].ToString());
                lblDateAdded.Text = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dDate);
                lblNCurrencyPrice.Text = lblNDiscountPrice.Text = tmpCurrency;

                lblOrgPrice.Text = tmpBookPrice;
                lblAfterDiscount.Text = tmpBookDiscountPrice;
                ImageEbooks.ImageUrl = Session["UserDomainURL"].ToString()+ "/" +utRow2["ImageFileFullURL"].ToString();

            }

            String tmpHeader_BookType = String.Empty;
            String tmpSubHeader_BookType = String.Empty;
            String tmpSender_Message = String.Empty;           


            if (tmpBFree != "0")
            {
                tmpHeader_BookType = "FREE eBOOK!";
                tmpSubHeader_BookType = "Only at " + tmpDomainUrl + " !!";
                tmpSender_Message = tmpBookDesc;
                ImageButton2.ImageUrl = "http://www.worlddigitalbiz.com/Images/ebImages/FREEebook2.gif";
                lblAfterDiscount.Text = "0.00";
                lblMessageFooter.Text = "Experience the trill of shopping for ebooks with only a finger tip, visit our store today to find out why " + tmpDomainUrl + " is the fastest growing eBook Store on earth!";
            }
            else if (tmpBSeller != "0")
            {
                tmpHeader_BookType = "Best Selling Ebooks in Town!";
                tmpSubHeader_BookType = "Only at " + tmpDomainUrl + " !!";
                tmpSender_Message = tmpBookDesc;
                lblMessageFooter.Text = "Still can't decide?  don't worry, check out the Best Seller for the most sought after ebooks...you won't go wrong! ";
            }
            else if (tmpBFeature != "0")
            {
                tmpHeader_BookType = "Feature Buy!";
                tmpSubHeader_BookType = "No ideas how to start?  Check out the Feature Buy for a series of good reads specially selected for you...";
                tmpSender_Message = tmpBookDesc;
                lblMessageFooter.Text = "No ideas how to start?  Check out the Feature Buy for a series of good reads specially selected for you";
            
            }
            else if (tmpBNew != "0")
            {
                tmpHeader_BookType = "New Release";
                tmpSubHeader_BookType = "Below is my Latest eBook that I am confident you will like to check out:-";
                tmpSender_Message = "This is the Book You Must Read to Know all about WDB eBook Biz World Digital Biz ('WDB') eBook Biz Platform is the World's first eBook Business Platform that enable its owner/operator to instantly start a ebook business right from product activation. Not only that, WDB platform is the ONLY ebook platform, anywhere in the world, to incorporate SMS payment collection system. The best way to experience what we said about WDB ebook platform is to take out your mobile phone, send an SMS according to the SMS Purchase Format given. We assure you will be convinced!!";
            }
            else if (tmpBValueBuy != "0")
            {
                tmpHeader_BookType = "Value-Buy eBooks Promotion!";
                tmpSubHeader_BookType = "Get <font color='red'><b>" + tmpBookCount + "</b></font> eBooks for the Price of 1?? Only at <b>" + tmpDomainUrl + "</b>!!";
                tmpSender_Message = "Do not miss many more interesting ebooks that are on sale at " + tmpDomainUrl+ ", check them out today!Best of all, all ebooks in my store are sold at one <b><font color='red'>Flat Price of " + tmpCurrency + " " + tmpBookDiscountPrice + "</font></b> each for SMS purchase.  ";
            }
            lblHeader_BookType.Text = tmpHeader_BookType;
            lblSubHeader_BookType.Text = tmpSubHeader_BookType;
            lbl_SenderMessage.Text = tmpSender_Message;

            DataSet dsBook = objBALebook.Ebook_KeywordDetails_ByUserID(Convert.ToInt32(Session["UserID"].ToString()));

            if (dsBook.Tables[0].Rows.Count > 0)
            {
                DataRow utKey = dsBook.Tables[0].Rows[0];
                if (tmpBFree == "0")
                {
                    lblBookPurchase_Format.Text = utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " YourEmail YourName";
                    lblSMS_Format.Text = utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " JohnWoo@yahoo.com John Woo ";
                    lblSend_SCode.Text = "SEND to 32828";
                    lblBookPurchase_Price.Text = "<b>NOTE:-&nbsp;</b> <font color='#85335C'>RM " + Convert.ToDecimal(utKey["Price"].ToString()) / 100 + "</font> &nbsp;per sms received.";
                }
                else
                {
                    lblBookPurchase_Format.Text = "FREE " + utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " YourEmail YourName";
                    lblSMS_Format.Text = "FREE " +  utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " JohnWoo@yahoo.com John Woo ";
                    lblSend_SCode.Text = "Send To      1) +60146367111   2) +447860034140   3) +6281297978822";
                    lblBookPurchase_Price.Text = "";
                }
                

                if (dsBook.Tables[1].Rows.Count > 0)
                {
                    DataRow utAccess = dsBook.Tables[1].Rows[0];

                    if (utAccess[0].ToString() == "0") 
                    {
                        divSMSCode.Visible = false;
                    }

                    if (utAccess[1].ToString() == "0") 
                    {
                        tr_PurchasePaypal.Visible = false;
                    }
                }

            }
        }

        String tmpHtmlBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml>
                                <head><title></title>
                                <style type='text/css'>
                                @import url(http://fonts.googleapis.com/css?family=Lobster);
                                @import url(http://fonts.googleapis.com/css?family=Roboto+Slab);
                                @import url(http://fonts.googleapis.com/css?family=Bree+Serif);
                                .tbEmail
                                {
                                    -webkit-border-radius: 10px;
                                    -moz-border-radius: 10px;
                                    border-radius: 10px;  
                                    border:1px dotted #CCC; background-color:#fff;
                                    padding: 10px;    
                                }
                                .ebMailHeader
                                {
                                    border:1px solid #CCC;background-color:#EFB4B4;     
                                    font-family:Tahoma;font-size:18px;color:#5E4040;
                                }
                                .ebMailBook
                                {
                                    -webkit-border-radius: 10px;
                                    -moz-border-radius: 10px;
                                    border-radius: 10px;     
                                    padding:3px 3px 3px 3px;
                                    border-color:#CCC;background-color:#EFB4B4;       
                                    font-family: 'Roboto Slab', serif;font-size:13px;
                                }
                                .divSMSCode
                                {
                                    width:480px;
                                    -webkit-border-radius: 10px;
                                    -moz-border-radius: 10px;
                                    border-radius: 10px;   
                                    border :1px solid #B29292;  
                                    padding:3px 3px 3px 3px;
                                    background-color:#FFFFFF;padding:10px;
                                    position:relative;                                    
                                }
                                .FontLobster
                                {
                                    font-family: 'Lobster'; 
                                    font-size:23px; 
                                    color:#5E4040;  
                                }
                                .FontSubLobster
                                {
                                    font-family: 'Lobster', cursive;
                                    font-size:20px; 
                                    color:#85335C;  
                                }
                                .FontBreeSerif
                                {
                                    font-family: 'Bree Serif', serif;font-size:15px;  
                                    font-size:16px; 
                                    color:#85335C;  
                                }
                                .divEmailSignature
                                {
                                    -webkit-border-radius: 5px;
                                    -moz-border-radius: 5px;
                                    border-radius: 5px;   
                                    background-color:#fff;padding:10px    
                                }
                                .divEbCss
                                {
                                    width:350px;
                                }
                                .ebBookDefaultImgCss
                                {   
                                    max-width: 250px;
                                    max-height: 350px;
                                }
                                .ebBookImgCss
                                {
                                    width: 50px; height: 80px; 
                                }
                                .divebBookCss
                                {
                                    border: 1px dotted #BAC0C7;
                                    padding: 5px;
                                    width: 60px;  
                                    height: 90px;
                                    margin: 2px;
                                    float: left;
                                    -moz-border-radius: 5px;
                                    -webkit-border-radius: 5px;
                                    border-radius: 5px;
                                }
                                .HtmlRowFormLabel
                                {    
                                    border-bottom:1px solid #E6B8B8;border-right:1px solid #E6B8B8;
                                    background-color:#F5D2D2;
                                    font-family: 'Bree Serif', serif;font-size:15px;    
                                    padding-left:10px;    
                                    height:24px;
                                }
                                .HtmlRowFormText
                                {   border-bottom:1px solid #E6B8B8;background-color:#F7DBDB;
                                    font-family: 'Bree Serif', serif;font-size:14px;
                                    padding-left:10px;height:22px;
                                }
                                .BookPurchase_Header
                                {    
                                    font-family: Arial, sans-serif; font-size: 11px;font-weight: bold; 
                                    color: rgb(146, 46, 197);    
                                }
                                .BookPurchase_Format
                                {
                                    font-family: 'Trebuchet MS', 'Lucida Console', Arial, sans-serif;
                                    font-weight: bold; font-size: 16px; 
                                    line-height: 16px;  color: rgb(255, 48, 0);
                                    text-shadow: rgb(170, 170, 170) 1px 0px 1px;
                                    letter-spacing: 1px;
                                    text-transform: capitalize;
                                    padding: 2px 5px;    
                                }
                                .BookPurchase_Note
                                {
                                    border-top : 1px solid rgb(146, 46, 197) ; 
                                    font-family: Arial, sans-serif;
                                    font-size: 11px;  
                                    color: rgb(159, 77, 17); 
                                    padding-top: 2px; 
                                       
                                }
                                .BookPurchase_Send
                                {
                                    font-family: verdana, 'Trebuchet MS', 'Lucida Console', Arial, sans-serif; 
                                    color: rgb(233, 29, 235);
                                    font-size: 11px;
                                    font-weight: bold;
                                    text-align: right;
                                    padding: 2px;
                                }
                                .BookPrice_Font
                                {
                                    font-family: 'Trebuchet MS', 'Lucida Console', Arial, sans-serif;
                                    font-weight: bold; font-size: 11px; color: rgb(171, 69, 250);
                                    padding: 2px;   
                                } 
                                .fontCurrency
                                {
                                    color : Red;
                                    word-spacing :2px;    
                                }   
                                </style>
                                </head>
                                <body>
                                <table width='50%' cellpadding='0' cellspacing='0' class='tbEmail'>
                                <tr>
                                <td width='2%'>&nbsp;</td>
                                <td>
                                <div id='divEMailHeader' class='ebMailHeader' runat='server'>
		                            <table cellpadding='0' cellspacing='0' width='100%'>
                                       <tr>
                                       <td style='width:240px; background-color:#FFFFFF'>
                                        <input type='image' name='ImageButton1' id='ImageButton1' src='http://worlddigitalbiz.com/ImageRepository/7484_8843772_WDB%20Logo.jpg' style='height:109px;width:184px;border-width:0px;' />                                        
                                       </td>
                                       <td style='padding:10px'> 
                                       <span id='Header_Title' class='FontLobster'>" + Header_Title.Text + @"</span><br />
                                       <span id='SubHeader_Title' class='FontSubLobster'>" + SubHeader_Title.Text + @"</span> 
                                       </td>
                                       </tr>
                                    </table>
	                            </div>
                             </td>
                                <td width='2%'>&nbsp;</td>
                             </tr>
                             <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                             </tr>
                             <tr>
                            <td>&nbsp;</td>
                            <td style='text-align: left'>
                               <span id='lblHeader_BookType' class='FontLobster'>" + lblHeader_BookType.Text + @"</span>  
                               <br />
                               <span id='lblSubHeader_BookType' class='FontBreeSerif'>" + lblSubHeader_BookType.Text + @"</span>                                                                                                                                                       
                            </td>
                            <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                            <td>&nbsp;</td>
                            <td>
                            <div id='divMailBook' class='ebMailBook' runat='server'>
                                         <table cellpadding='0' cellspacing='0' width='100%'>
                                         <tr>
                                         <td style='width:200px;height:100px;padding:10px' valign='top'>
                                             <img id='ImageEbooks' class='ebBookDefaultImgCss' src='" + ImageEbooks.ImageUrl + @"' style='border-width:0px;' />                                                         
                                         </td>
                                         <td style='padding:10px' valign='top'>
                                            <span id='lbl_SenderName'><b>Hi " + lbl_SenderName.Text + @" </b>,</span>
                                            <br />
                                            <span id='lbl_SenderMessage'>" + lbl_SenderMessage.Text+ @"</span>
                                            <div>
                                            <table border='0' cellpadding='0' cellspacing='0' width='500px;' style='border: solid 1px #808080; padding: 5px; background-color: #FFFFFF;'>
                                                          <tr>
                                                              <td width='100px' class='HtmlRowFormLabel'>Book ID :</td>
                                                              <td width='150px' class='HtmlRowFormText'> <span id='lblBookID'>" + lblBookID .Text + @"</span></asp:Label></td>
                                                          </tr>
                                                          <tr>
                                                              <td class='HtmlRowFormLabel'>Book Name:</td>
                                                              <td class='HtmlRowFormText'> <span id='lblBookName'>" +lblBookName.Text + @"</span></td>
                                                          </tr>

                                                           <tr>
                                                              <td class='HtmlRowFormLabel'>Category:</td>
                                                              <td class='HtmlRowFormText'> <span id='lblCategory'>" + lblCategory.Text + @"</span></td>
                                                          </tr>

                                                           <tr>
                                                              <td class='HtmlRowFormLabel'>Date Added:</td>
                                                              <td class='HtmlRowFormText'> <span id='lblDateAdded'>" + lblDateAdded.Text + @"</span></td>
                                                          </tr>

                                                           <tr>
                                                              <td class='HtmlRowFormLabel'>Orginal Price:</td>
                                                              <td class='HtmlRowFormText'> <span id='lblNCurrencyPrice' class='fontCurrency'>" + lblNCurrencyPrice.Text + @"</span>&nbsp;<span id='lblOrgPrice'>10.00</span></td>
                                                          </tr>

                                                            <tr>
                                                              <td class='HtmlRowFormLabel'>After Discount:</td>
                                                              <td class='HtmlRowFormText'> <span id='lblNDiscountPrice' class='fontCurrency'>" + lblNDiscountPrice.Text + @"</span>&nbsp;<span id='lblAfterDiscount'>" + lblAfterDiscount.Text + @"</span></asp:Label></td>
                                                          </tr>

                                                            <tr id='tr_PurchasePaypal' runat='server'>
                                                              <td colspan='2' style='padding:10px' align='center'>
                                                                    <asp:ImageButton ID='ImageButton2' runat='server' ImageUrl='" + ImageButton2.ImageUrl + @"' />                                                    
                                                                </td>
                                                          </tr>
                                                </table>
                                                </div>
		                                </td>
                                        </tr>
                                        <tr>
                                        <td>&nbsp;</td>
                                        <td style='height:40px;padding:10px;'>
                                        <div id='divSMSCode' class='divSMSCode' runat='server'>
                                            <table border='0'>
                                                <tr>
                                                 <td align='left' class='BookPurchase_Header'>Malaysia Mobile Purchase - SMS Purchase Format</td>
                                                </tr>
                                                <tr>
                                                    <td class='BookPurchase_Format'>
                                                    <span id='lblBookPurchase_Format'>" + lblBookPurchase_Format.Text + @"</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td align='right' class='BookPurchase_Send'><span id='lblSend_SCode'>SEND to 32828</span></td></tr><tr>
                                                <td align='left' class='BookPurchase_Note'>
                                                 <span id='lblBookPurchase_Price'><font color='#85335C'>" + lblBookPurchase_Price.Text + @"</font></span>Eg. <span id='lblSMS_Format'> " + lblSMS_Format.Text + @"</span>
                                                </td></tr></table></div></td></tr><tr>
                                                <td style='height:50px;padding:10px;' colspan='2'>
                                                <div class='divEmailSignature'>
                                                <b><span id='lblMessageFooter'>" + lblMessageFooter.Text + @"</span>
                                                </b><br />
                                                <span id='lblRemark'>" + lblRemark.Text + @"</span>
                                                <br />
                                                <span id='lbl_EmailCompliment'>" + lbl_EmailCompliment.Text + @"</span>
                                                <br />
                                                <span id='lbl_EmailSenderName' CssClass='FontBreeSerif'>" + lbl_EmailSenderName.Text + @"</span>
                                                </div>
                                                </td>
                                                </tr>
                                                <tr>
                                                <td style='height:50px;padding:10px;' colspan='2' align='center'>Do you want to receive email updates?
                                                <a id='hypUnsubscribe' href=" + tblMessageBar.ID + @"><b>Unsubscribe Here</b></a>
                                                </td></tr></table></div></td>
                                                <td>&nbsp;</td></tr></table>
                                            </td>
                                                <td width='2%'>&nbsp;</td>
                                            </tr>                  
                                            </table>
                                            </body>
                                    </html>";

                                #region sending Email using HmailServer.

                                hMailServer.Application objApp_Hmail = new hMailServer.Application();

                                hMailServer.Message objMsg_Hmail = new hMailServer.Message();

                                objMsg_Hmail.AddRecipient("", "samvoon@yahoo.com");

                                objMsg_Hmail.From = "noreply@ebooksmsdelivery.com";
                                objMsg_Hmail.FromAddress = "noreply@ebooksmsdelivery.com";

                                objMsg_Hmail.Subject = "Email Marketing";
                                objMsg_Hmail.HTMLBody = tmpHtmlBody;
                              

                                objMsg_Hmail.Save();

                                #endregion
    }    
}

