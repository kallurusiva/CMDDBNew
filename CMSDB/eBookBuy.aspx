<%@ Page Title="" Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eBookBuy.aspx.cs" Inherits="eBookBuy" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />


    <%--<form id="frmTest" runat="server">--%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>

            <td width="150px"></td>
            <td ></td>
        </tr>
        <tr style="height:40px;">
            <td>
               <%-- <asp:Label ID="lblCategoryHeader" CssClass="eb_head2" runat="server" Text="Categories"></asp:Label>--%>
            </td>
        </tr>

        
        <tr>
            <td valign="top">
                 
                <div id="dvLeftContent" class="ribbon" style="width: 180px;" runat="server">
                   
                </div>
            </td>
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">


                    <asp:Repeater ID="RepBooks" runat="server" OnItemDataBound="RepBooks_ItemDataBound">

                        <HeaderTemplate>
                           
                            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="cssfaq">
                            <tr>
                                <td colspan="3" align="center">
                                     <div id="dvEbHeader" class="ebHeaderBox" runat="server">

                                         <asp:Label ID="lblHeader" CssClass="eb_head" runat="server" Text="Featured eBooks"></asp:Label>


                                     </div>

                                </td>
                                
                            </tr>
                           
                        </HeaderTemplate>

                        <ItemTemplate>


                             <tr>
                                <td align="center"> 
                                    <%-- Div to show Book Image--%>
                                    <div id="dvEbImage" class="ebookShowBox ebImageBox"  runat="server">
                                        <asp:HyperLink ID="HypBookShow" NavigateUrl='<%# Eval("BookID","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">  
                                        <asp:Image ID="ImgEbook" CssClass="ebImgCss" ImageUrl='<%# Eval("ImageFileFullURL")%>' runat="server" />
                                        </asp:HyperLink>
                                    </div>

                                </td>
                                <td> 
                                    <div id="dvEbDescription" class="ebookShowBox ebDescriptionBox"  runat="server">
                                        <div id="dvBookInfo" class="dvBookInfoCss" runat="server">
                                        <asp:Label ID="lblTitle" runat="server" CssClass="fontTitle" Text='<%# Eval("Title")%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblDescription" CssClass="fontDescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                                        <br />
                                            </div>
                                   

                                     <div id="dvBookPurchaseFormat" class="dvBookPurchaseCss" runat="server" visible="false">

                                            <table border="0">
                                                <tr><td align="left" class="Purchase_header">Malaysia Mobile Purchase - SMS Purchase Format</td></tr>
                                                <tr><td class="Purchase_format">  
                                                        <asp:Label ID="lblPurFormat" runat="server" Text=""></asp:Label>
                                                    </td></tr>
                                                <tr><td align="right" class="Purchase_send">&nbsp;SEND to 36247</td></tr>
                                                <tr><td align="left">
                                                    <asp:Label ID="lblPurchaseNote" CssClass="Purchase_Note" runat="server" Text=""></asp:Label> </td></tr>
                                            </table>

                                        </div>
                                         </div>


                                </td>
                                <td> 
                                    <div id="dvEbDetails" class="ebookShowBox ebDetailsBox" runat="server">

                                      <table border="0" cellpadding="0" cellspacing="0">
                                          <tr>
                                              <td width="100px" class="RowFormLabel">eBook Code:</td>
                                              <td width="150px" class="RowFormText"> <asp:Label ID="lblBookID" runat="server" Text='<%# Eval("BookID")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">eBook Name:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("BookNAme")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Category:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("CategoryName")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Date Added:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateCreated","{0:MMMM d, yyyy}")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Orginal Price:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblOrgPrice" runat="server" Text='<%# Eval("Price", "{0:0.00}")%>'></asp:Label></td>
                                          </tr>

                                            <tr>
                                              <td class="RowFormLabel">After Discount:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblAfterDiscount" runat="server" Text='<%# Eval("DiscountedPrice", "{0:0.00}")%>'></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td colspan="2" align="center" style="padding: 10px;">
                                                  <asp:ImageButton ID="ImgPayPalBuyBtn" Width="120px" Height="36px" ImageUrl="~/Images/ebImages/Buy-Now-Button-small.jpg" CommandArgument='<%# Eval("BookID") + "," + Eval("Price") %>' OnCommand="ImgPayPalBuyBtn_Click" runat="server" />
                                                <%--  <img width="120px" height="36px" src="Images/ebImages/Buy-Now-Button-small.jpg" />--%>
                                                  <img src="Images/ebImages/master_buyNow.jpg" />
                                                  <img src="Images/ebImages/visa_buyNow.jpg" />
                                              </td>

                                          </tr>


                                      </table>

                                    </div>

                                </td>
                            </tr>


                        </ItemTemplate>

                        <SeparatorTemplate>
                              <tr>
                                <td class="eSeparator" colspan="3">&nbsp; </td>
                              </tr>

                        </SeparatorTemplate>


                        <FooterTemplate>
                            <tr>
                            <td>&nbsp; </td>
                            <td>&nbsp; </td>
                            <td> &nbsp; </td>
                            </tr>
                            </table>

                        </FooterTemplate>

                    </asp:Repeater>


                </div>


            </td>
        </tr>


        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;


   <%--[Required]   Full Name of the Payee User   [Max...128 chars]--%>
   <asp:HiddenField ID="cpFullName" runat="server" Value='' />

   <%--[Required]   Amount to be deducted   [decimal allowed] --%>
   <asp:HiddenField ID="cpAmount" runat="server" Value='' />

   <%--     USD :   American Dollars     
            SGD :   Singaporean Dollars
            MYR :   Malaysian Ringgit
   --%>
   <asp:HiddenField ID="cpCurrencyCode" runat="server" />

   <%--[Required]  Mobile number --%>
   <asp:HiddenField ID="cpMobileNo" runat="server" />

   <%--[Required]    ItemName/ Purpose of Buying / Amount being paid For --%>
   <asp:HiddenField ID="cpItemName" runat="server" />

   <%--[Optional]    Max 128 chars  --%>
   <asp:HiddenField ID="cpCustomText" runat="server" />

   <%--[Optional]    ItemNumber [default UniqueId will be used] --%>
   <asp:HiddenField ID="cpItemNumber" runat="server" />

   <%--[Optional]    UniqueID [default UniqueId will be used]--%>
   <asp:HiddenField ID="cpUniqueID" runat="server" Value="899899899" />

   <%--[Optional]    Max 100 chars.  Pass the webSiteName / Domain Name for reference purpose--%>
   <asp:HiddenField ID="cpWebSiteName" runat="server" /> 

   <%-- [Required]    UserID  --%>
   <asp:HiddenField ID="cpUserID" runat="server" />

   <%-- [Required]    URL Pathname to return after the paypal payment is successfull. --%>
   <asp:HiddenField ID="cpSuccessURL" runat="server" Value="" /> 

   <%-- [Required]    URL Pathname to return If the paypal payment is cancelled in the middle. --%>
   <asp:HiddenField ID="cpCancelURL" runat="server" Value="" />

   <%-- [Required]    URL Pathname to return If the paypal payment is failed. --%>
   <asp:HiddenField ID="cpFailureURL" runat="server" Value="" />

   <%--[Required]  if False=Request for TAG Code ,else true=go to paypal.com directly --%>
   <asp:HiddenField ID="cpSkipTAC" runat="server" Value="true" />
            </td>
        </tr>


    </table>


</td>
</tr>

</table>
<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

