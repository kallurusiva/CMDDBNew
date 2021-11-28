<%@ Page Title="" Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eBooksValueBuy.aspx.cs" Inherits="eBooksValueBuy" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<%@ Register src="eBookBasketBar.ascx" tagname="eBookBasketBar" tagprefix="uc2" %>
<%@ Register Src="~/ebLeftCategories.ascx" TagPrefix="uc1" TagName="ebLeftCategories" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />

    <style type="text/css"> 

          .FontWaiting { color: indianred; font: bold 150%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif; 
                         background-color:#FFFFFF; line-height: 150px; padding: 20px;

                        -webkit-border-radius: 6px;                         
						 -moz-border-radius: 6px;						 
						 border-radius: 6px;

         }

          .VB_ebookShowBox_Main1
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    height: 400px;
    margin: 2px;
       
    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;

}

      .LockOff { 
         display: none; 
         visibility: hidden; 
      } 

      .LockOn { 
         display: block; 
         visibility: visible; 
         position: fixed; 
         z-index: 999; 
        top: 50%;
        left: 50%;
       -webkit-transform: translate(-50%, -50%);
    transform: translate(-50%, -50%);


     padding-top: 50%; 

         width: 105%; 
         height: 105%; 
         background-color: #ccc; 
         text-align: center; 
        
         filter: alpha(opacity=75); 
         opacity: 0.75; 

      } 
   </style>
      <script type="text/javascript">
          function skm_LockScreen(str, vCurrendID) {
              //alert('showing');
              var lock = document.getElementById('skm_LockPane');
              if (lock)
                  lock.className = 'LockOn';

              // lock.innerHTML = str;
          }
   </script> 
 <div id="skm_LockPane" class="LockOff">

       <img id="imgLoader" src="Images/Loader1.gif" />
       <span class="FontWaiting">Please wait while we add your selected Book to Cart... </span>

   </div>

    <%--<form id="frmTest" runat="server">--%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>

            <td width="150px"></td>
            <td align="right" >
                <uc2:eBookBasketBar ID="eBookBasketBar1" runat="server" />
            </td>
        </tr>
              
        <tr>
            <td valign="top">
                <uc1:ebLeftCategories runat="server" ID="ebLeftCategories" />
                <div id="dvLeftContent" class="ribbon" visible="false" style="width: 180px;" runat="server">
                   
                </div>
            </td>
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">


                    <asp:Repeater ID="RepBooks" runat="server" OnItemDataBound="RepBooks_ItemDataBound" OnItemCommand="RepBooks_ItemCommand">

                        <HeaderTemplate>
                           
                            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="cssfaq">
                            <tr>
                                <td colspan="3" align="center">
                                     <div id="dvEbHeader" class="ebHeaderBox" runat="server">

                                         <asp:Label ID="lblHeader" CssClass="eb_head" runat="server" Text="<%$ Resources:LangResources, ValueBuy %>"></asp:Label>&nbsp;
                                          <asp:Label ID="Label1" CssClass="eb_head" runat="server" Text="<%$ Resources:LangResources, eBook %>"></asp:Label>

                                     </div>

                                </td>
                                
                            </tr>
                           
                        </HeaderTemplate>

                        <ItemTemplate>


                             <tr>
                                <td align="center" colspan="2"> 
                                    <%-- Div to show Book Images--%>
                                     <asp:HyperLink ID="HyperLink6" NavigateUrl='<%# Eval("BookID","~/eBookShowValueBuyDetails.aspx?qBookID={0}") %>' runat="server">
                                    <div id="dvValueBuyBOOK" class="VB_ebookShowBox_Main1 ebValueBuyBOXCss" runat="server">
                                        <div id="dvHeaderVB" class="VB_BookHeader" runat="server">
                                            <asp:Label ID="Label4" runat="server" CssClass="VB_headFont2" Text='<%# Eval("BookID")%>'></asp:Label> :
                                            <asp:Label ID="lblHeader" runat="server" CssClass="VB_headFont1" Text='<%# Eval("BookName")%>'></asp:Label>

                                               <asp:HiddenField ID="hdnBookAllowSmsBuy" Value='<%# Eval("AllowSmsBuy")%>' runat="server" />
                                               <asp:HiddenField ID="hdnBookAllowPayPalBuy" Value='<%# Eval("AllowPaypalBuy")%>' runat="server" />

                                        </div>
                                        
                                            <div id="divVB1" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                           <%-- <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("BookID1","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">--%>
                                                <asp:Image ID="ImgEbook1" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL1")%>' runat="server" />
                                            <%-- </asp:HyperLink>--%>
                                                <br /><asp:Label ID="lblBookName1" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName1")%>'></asp:Label>
                                            
                                        </div>

                                        <div id="divVB2" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                            <%--<asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("BookID2","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">--%>
                                            <asp:Image ID="ImgEbook2" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL2")%>' runat="server" />
                                               <%-- </asp:HyperLink>--%>
                                            <br /><asp:Label ID="lblBookName2" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName2")%>'></asp:Label>
                                                 
                                        </div>

                                        <div id="divVB3" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                            <%--<asp:HyperLink ID="HyperLink3" NavigateUrl='<%# Eval("BookID3","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">--%>
                                            <asp:Image ID="ImgEbook3" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL3")%>' runat="server" />
                                               <%-- </asp:HyperLink>--%>
                                            <br /><asp:Label ID="Label1" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName3")%>'></asp:Label>
                                               
                                        </div>

                                        <div id="divVB4" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                           <%-- <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("BookID4","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">--%>
                                            <asp:Image ID="ImgEbook4" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL4")%>' runat="server" />
                                               <%-- </asp:HyperLink>--%>
                                            <br /><asp:Label ID="Label2" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName4")%>'></asp:Label>
                                                
                                        </div>

                                        <div id="divVB5" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                           <%-- <asp:HyperLink ID="HyperLink5" NavigateUrl='<%# Eval("BookID5","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">--%>
                                           <asp:Image ID="ImgEbook5" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL5")%>' runat="server" />
                                                <%--</asp:HyperLink>--%>
                                            <br /><asp:Label ID="Label3" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName5")%>'></asp:Label>
                                               
                                        </div>

                                        <%--<div id="DivPurchaseFooter" class="VB_BookPurchaseCss" visible="false" runat="server">
                                            <asp:Label ID="Label6" runat="server" CssClass="VB_Purchase_header" Text="<%$ Resources:LangResources, MalaysiaMobilePurchase %>"></asp:Label> &nbsp;
                                            <asp:Label ID="Label9" runat="server" CssClass="VB_Purchase_header" Text="<%$ Resources:LangResources, SMSPurchaseFormat %>"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblPurchaseText" runat="server" CssClass="VB_Purchase_format" Text=""></asp:Label> 
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="Label10" runat="server" CssClass="VB_Purchase_send" Text="<%$ Resources:LangResources, SendTo %>"></asp:Label> &nbsp;
                                            <asp:Label ID="Label5" runat="server" CssClass="VB_Purchase_send" Text="36247"></asp:Label> 
                                        </div>--%>

                                        <%--<div id="DivPurchaseFooter" class="dvBookPurchaseCss" runat="server" visible="true">
                                            <table border="0">
                                                 <tr><td align="left" class="Purchase_headerB"><asp:Literal ID="Literal10" Text="<%$ Resources:LangResources, MalaysiaMobilePurchase %>" runat="server"></asp:Literal>&nbsp;-&nbsp;
                                                    <asp:Literal ID="Literal11" Text="<%$ Resources:LangResources, SMSPurchaseFormat %>" runat="server"></asp:Literal> </td></tr>
                                                <tr><td class="Purchase_format">  
                                                        <asp:Label ID="lblPurchaseText" runat="server" CssClass="VB_Purchase_format" Text=""></asp:Label> 
                                                    </td></tr>
                                               <tr><td align="right" class="Purchase_send">&nbsp;<asp:Literal ID="Literal12" Text="<%$ Resources:LangResources, SendTo %>" runat="server"></asp:Literal>
                                                   <asp:Label ID="Label5" runat="server" CssClass="VB_Purchase_send" Text="36247"></asp:Label>
                                                   </td></tr>
                                                <tr><td align="left">
                                                    <asp:Label ID="lblPurchaseNote" CssClass="Purchase_Note" runat="server" Text=""></asp:Label> </td></tr>
                                            </table>
                                        </div>--%>

                                        <div id="DivPurchaseFooter" class="dvBookPurchaseCss" visible="false" runat="server">
                                            <table id="tblPurchase" runat="server" border="0">
                                                <tr>
                                                    <td align="left">                                                    
                                            <asp:Label ID="lblPurFormat" runat="server" CssClass="VB_Purchase_header" Text="Malaysia Mobile Purchase - SMS Purchase Format: " ></asp:Label> 
                                            &nbsp;&nbsp;&nbsp;<br />
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">  
                                            <asp:Label ID="lblPurchaseText" runat="server" CssClass="VB_Purchase_format" Text=""></asp:Label> 
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                            <asp:Label ID="lblPurchaseNote" runat="server" CssClass="Purchase_header" Text="SEND to 36247"></asp:Label> 
                                                </td>
                                                </tr>
                            </table>
                                        </div>


                                    </div>
                                   </asp:HyperLink>

                                </td>
                                <td> 
                                    <div id="dvEbDetails" class="VB_ebookShowBox_Main ebDetailsBox" runat="server">

                                      <table border="0" cellpadding="0" cellspacing="0">
                                          <tr>
                                             <td width="100px" class="RowFormLabel"> <asp:Literal ID="Literal1" Text="<%$ Resources:LangResources, eBook %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal2" Text="<%$ Resources:LangResources, Code %>" runat="server"></asp:Literal>:</td>
                                              <td width="150px" class="RowFormText"> <asp:Label ID="lblBookID" runat="server" Text='<%# Eval("BookID")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal4" Text="<%$ Resources:LangResources, PackageName %>" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("BookNAme")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                                <td class="RowFormLabel"><asp:Literal ID="Literal3" Text="<%$ Resources:LangResources, NumberofBooks %>" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("BooksCount")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal8" Text="<%$ Resources:LangResources, Date %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal9" Text="<%$ Resources:LangResources, Created %>" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateCreated","{0:MMMM d, yyyy}")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                               <td class="RowFormLabel"><asp:Literal ID="Literal6" Text="<%$ Resources:LangResources, OriginalPrice %>" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText"> 
                                                    <asp:Label ID="Label7" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                  <asp:Label ID="lblOrgPrice" runat="server" Text='<%# Eval("Price", "{0:0.00}")%>'></asp:Label></td>
                                          </tr>

                                            <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal7" Text="<%$ Resources:LangResources, AfterDiscount %>" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText"> 
                                                    <asp:Label ID="Label8" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                  
                                                  <asp:Label ID="lblAfterDiscount" runat="server" Text='<%# Eval("DiscountedPrice", "{0:0.00}")%>'></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal15" Text="Prepaid Price" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText">
                                                  <asp:Label ID="lblPrepaidPrice" runat="server" Text='<%# Eval("PrepaidPrice")%>'></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td colspan="2" align="center" style="padding: 10px;">
                                                
                                                   <asp:LinkButton ID="lnkAddtoCart"  Visible="false" OnClientClick="skm_LockScreen('Please wait while we take you to PayPal Site...')"  OnCommand="lnkAddtoCart_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") %>' runat="server">                                                  
                                                   <img alt="Add2cart" src="Images/ebImages/Add2Cart.png" />
                                                   </asp:LinkButton>

                                                  <asp:LinkButton ID="LnkPayPalBuy"  Visible="false" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") %>' runat="server">                                                  
                                                <img src="Images/ebImages/BuyNow.png" />
                                                  </asp:LinkButton>
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


   <%--     <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>--%>


    </table>


</td>
</tr>

</table>
<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

