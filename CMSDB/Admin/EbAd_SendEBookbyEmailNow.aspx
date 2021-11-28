<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_SendEBookbyEmailNow.aspx.cs" Inherits="Admin_EbAd_SendEBookbyEmailNow" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
@import url(http://fonts.googleapis.com/css?family=Lobster);
@import url(http://fonts.googleapis.com/css?family=Roboto+Slab);
@import url(http://fonts.googleapis.com/css?family=Bree+Serif);
.tbEmail
{
    -webkit-border-radius: 10px;
    -moz-border-radius: 10px;
    border-radius: 10px;  
    border:2px dotted #85335C; background-color:#fff;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
<form id="tForm" runat="server" method="post"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </td>
        </tr>
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; Add new Feature Buy&nbsp; Ebook&nbsp; </td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="2%">&nbsp;</td>
                        <td>
                        <table width="100%" cellpadding="0" cellspacing="0" class="tbEmail">
                        <tr>
                        <td width="2%">&nbsp;</td>
                        <td>
                        <div id="divEMailHeader" class="ebMailHeader" runat="server">
		                    <table cellpadding="0" cellspacing="0" width="100%">
                                         <tr>
                                         <td style="width:240px; background-color:#FFFFFF">
                                             <asp:ImageButton ID="ImageButton1" runat="server" 
                                                 ImageUrl="http://worlddigitalbiz.com/ImageRepository/7484_8843772_WDB%20Logo.jpg" Height="109px" 
                                                 Width="184px" />
                                             </td>
                                         <td style="padding:10px">
                                          <asp:Label ID="Header_Title" runat="server" Text="The Premier eBook Store" CssClass="FontLobster"/>
                                         <br />
                                          <asp:Label ID="SubHeader_Title" runat="server" Text="www.worlddigitalbiz.com" class="FontSubLobster"/>  
                                         
                                         </td>
                                         </tr>
                                </table>
	                    </div>
                     </td>
                        <td width="2%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
	                <tr>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                               <asp:Label runat="server" ID="lblHeader_BookType" CssClass="FontLobster" Text="New Release!" />  
                               <br />
                               <asp:Label runat="server" ID="lblSubHeader_BookType" CssClass="FontBreeSerif" Text="Below is my Latest eBook that I am confident you will like to check out:-" />                                                                
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
                        <div id="divMailBook" class="ebMailBook" runat="server">
                                         <table cellpadding="0" cellspacing="0" width="100%">
                                         <tr>
                                         <td style="width:200px;height:100px;padding:10px" valign="top">
                                             <asp:Image ID="ImageEbooks" runat="server" ImageUrl="~/DocumentRepository/eBookImages/6978_amway.jpg" CssClass="ebBookDefaultImgCss"/>                                             
                                             </td>
                                         <td style="padding:10px" valign="top">
                                            <asp:Label ID="lbl_SenderName" runat="server" Text="Hi syamala" />
                                            <br />
                                            <asp:Label ID="lbl_SenderMessage" runat="server"> This is the Book You Must Read to Know all about WDB eBook Biz
                                            World Digital Biz ("WDB") eBook Biz Platform is the World's first eBook Business Platform that enable its owner/operator to instantly start a ebook business right from product activation. Not only that, WDB platform is the ONLY ebook platform, anywhere in the world, to incorporate SMS payment collection system.
                                            The best way to experience what we said about WDB ebook platform is to take out your mobile phone, send an SMS according to the SMS Purchase Format given. We assure you will be convinced!! </asp:Label>
		<div>
		<table border="0" cellpadding="0" cellspacing="0" width="500px;" style="border: solid 1px #808080; padding: 5px; background-color: #FFFFFF;">
                                          <tr>
                                              <td width="100px" class="HtmlRowFormLabel">Book ID :</td>
                                              <td width="150px" class="HtmlRowFormText"> <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td class="HtmlRowFormLabel">Book Name:</td>
                                              <td class="HtmlRowFormText"> <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="HtmlRowFormLabel">Category:</td>
                                              <td class="HtmlRowFormText"> <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="HtmlRowFormLabel">Date Added:</td>
                                              <td class="HtmlRowFormText"> <asp:Label ID="lblDateAdded" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="HtmlRowFormLabel">Orginal Price:</td>
                                              <td class="HtmlRowFormText"> <asp:Label ID="lblNCurrencyPrice" runat="server" CssClass="fontCurrency" Text=""/>&nbsp;<asp:Label ID="lblOrgPrice" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                            <tr>
                                              <td class="HtmlRowFormLabel">After Discount:</td>
                                              <td class="HtmlRowFormText"> <asp:Label ID="lblNDiscountPrice" runat="server" CssClass="fontCurrency" Text=""/>&nbsp;<asp:Label ID="lblAfterDiscount" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                            <tr id="tr_PurchasePaypal" runat="server">
                                              <td colspan="2" style="padding:10px" align="center">
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="http://www.worlddigitalbiz.com/Images/ebImages/PayPalCreditCardBuyButton.gif" />                                                    
                                                </td>
                                          </tr>
                                      </table>
		</div>
		</td>
                                 </tr>
                                         <tr>
                                         <td>&nbsp;</td>
                                         <td style="height:40px;padding:10px;">
                                         <div id="divSMSCode" class="divSMSCode" runat="server">
                                             <table border="0">
                                                 <tr>
                                                     <td align="left" class="BookPurchase_Header">
                                                         Malaysia Mobile Purchase - SMS Purchase Format</td>
                                                 </tr>
                                                 <tr>
                                                     <td class="BookPurchase_Format">
                                                         <asp:Label ID="lblBookPurchase_Format" runat="server">WDB EE1488 YourEmail YourName</asp:Label></td></tr><tr>
                                                     <td align="right" class="BookPurchase_Send">
                                                         <asp:Label ID="lblSend_SCode" runat="server" Text="SEND to 32828" /></td></tr><tr>
                                                     <td align="left" class="BookPurchase_Note">
                                                         <asp:Label ID="lblBookPurchase_Price"  runat="server">RM 5&nbsp;</asp:Label>Eg. <asp:Label ID="lblSMS_Format" runat="server" Text="WDB EE1488"/></td></tr></table></div></td></tr><tr>
                                         <td style="height:50px;padding:10px;" colspan="2">
                                         <div class="divEmailSignature">
                                             <b><asp:Label ID="lblMessageFooter" runat="server">There are thousands more ebooks in my store and all sold sold at one Unbelievable Low Flat Price of RM5.00 each for SMS purchase.  Check them out today and I assure you will find what you like!  </asp:Label>
                                             </b><br />
                                             <asp:Label ID="lblRemark" runat="server" CssClass="" />
                                             <br />
                                             <asp:Label ID="lbl_EmailCompliment" runat="server"  Text="Best Regards" />
                                             <br />
                                             <asp:Label ID="lbl_EmailSenderName" runat="server" CssClass="FontBreeSerif" Text="Happy Sam" />
                                         </div>
                                             </td>
                                         </tr>
                                         <tr>
                                         <td style="height:50px;padding:10px;" colspan="2" align="center">Do you want to receive email updates?
                                             <asp:HyperLink ID="hypUnsubscribe" runat="server" Text="<b>Unsubscribe Here</b>" NavigateUrl="#"/></td></tr></table></div></td>
                        <td>&nbsp;</td></tr></table>                        
                        </td>
                        <td width="2%">&nbsp;</td>
                    </tr>                  
                </table>
            </td></tr></table>                 
            </td></tr><tr>
            <td>&nbsp;</td></tr>
        </table></form>
</asp:Content><asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server"></asp:Content>

