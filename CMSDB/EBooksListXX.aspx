<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EBooksListXX.aspx.cs" Inherits="EBooksListXX" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
  
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

    <%--<form id="frmTest" runat="server">--%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>
  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>

            <td width="200px"></td>
            <td align="right">
                
                <uc2:eBookBasketBar ID="eBookBasketBar1" runat="server" />
                
            </td>
        </tr>
      <%--  <tr style="height:40px;">
            <td>
                <asp:Label ID="lblCategoryHeader" CssClass="eb_head2" runat="server" Text="Categories"></asp:Label>
            </td>
        </tr>--%>

        
        <tr>
            <td valign="top">
                <uc1:ebLeftCategories runat="server" ID="ebLeftCategories" />
                <div id="dvLeftContent" class="ribbon" visible="false" style="width: 180px;" runat="server">
                   
                </div>
            </td>
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">

                    <asp:Repeater ID="rptPages" Runat="server" OnItemDataBound="rptPages_ItemDataBound">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" border="0">
                      <tr class="text">
                         <td class="Pag_Header"><b>Pages:</b>&nbsp;</td>
                         <td>
                      </HeaderTemplate>
                      <ItemTemplate>
                         <asp:LinkButton ID="btnPage"
                                         CommandName="Page"
                                         CommandArgument="<%#
                                         Container.DataItem %>"
                                         CssClass="Pag_Item"
                                         Text ="<%#
                                         Container.DataItem %>"
                                         Runat="server"><%# Container.DataItem %>
                                         </asp:LinkButton>
                      </ItemTemplate>
                      <FooterTemplate>
                         </td>
                      </tr>
                      </table>
                      </FooterTemplate>
                      </asp:Repeater>

                    <asp:Repeater ID="RepBooks" runat="server" OnItemDataBound="RepBooks_ItemDataBound">

                        <HeaderTemplate>
                           
                            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="cssfaq">
                            <tr>
                                <td colspan="3" align="center">
                                     <div id="dvEbHeader" class="ebHeaderBox" runat="server">

                                         <asp:Label ID="lblHeader" Visible="false" CssClass="eb_head" runat="server" Text="eBooks Popular way to make money on the Internet."></asp:Label>


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
                                            <asp:HiddenField ID="hdIsFreeBook" Value='<%# Eval("isFreeBook")%>' runat="server" />
                                            <asp:HiddenField ID="hdLaunchStatus" Value='<%# Eval("LaunchStatus")%>' runat="server" />
                                            <asp:HiddenField ID="hdAllowSMsBuy" Value='<%# Eval("AllowSmsBuy")%>' runat="server" />
                                            <asp:HiddenField ID="hdAllowPayPalBuy" Value='<%# Eval("AllowPayPalBuy")%>' runat="server" />
                                        <br />
                                       </div>
                                        <div id="dvBookPurchaseFormat" class="dvBookPurchaseCss" style="margin-left: 170px;" runat="server" visible="false">

                                            <table id="tblPurchase" runat="server" border="0">
                                                <tr><td align="left" class="Purchase_header">
                                                    <asp:Literal ID="Literal10" Text="<%$ Resources:LangResources, MalaysiaMobilePurchase %>" runat="server"></asp:Literal>&nbsp;-&nbsp;
                                                    <asp:Literal ID="Literal11" Text="<%$ Resources:LangResources, SMSPurchaseFormat %>" runat="server"></asp:Literal> </td></tr>
                                                <tr><td class="Purchase_format">  
                                                        <asp:Label ID="lblPurFormat" runat="server" Text=""></asp:Label>
                                                    </td></tr>
                                                <tr><td align="right" class="Purchase_send">&nbsp;<asp:Literal ID="Literal12" Text="<%$ Resources:LangResources, SendTo %>" runat="server"></asp:Literal> </td></tr>
                                                <tr><td align="left">
                                                    <asp:Label ID="lblPurchaseNote" CssClass="Purchase_header" runat="server" Text=""></asp:Label> </td></tr>
                                            </table>

                                              <table id="tblFreeEbooksPurchase" runat="server" border="0" visible="false">
                                                <tr><td align="left" class="Purchase_header"><asp:Literal ID="Literal13" Text="<%$ Resources:LangResources, SMSPurchaseFormat %>" runat="server"></asp:Literal></td></tr>
                                                <tr><td class="Purchase_format">  
                                                        <asp:Label ID="lblPurFormat2" runat="server" Text=""></asp:Label>
                                                    </td></tr>
                                               <tr><td align="left" class="font_EventDates11">&nbsp;<b><asp:Literal ID="Literal14" Text="<%$ Resources:LangResources, SendTo %>" runat="server"></asp:Literal></b>&nbsp;&nbsp; &nbsp;&nbsp;1) <b>+60146367111</b>&nbsp;&nbsp;2) <b>+628989111995</b>  &nbsp;&nbsp;3) <b>+447860041399</b> </td></tr>
                                                <tr><td align="left">
                                                    <asp:Label ID="lblPurchaseNote2" CssClass="Purchase_Note" runat="server" Text=""></asp:Label> </td></tr>
                                            </table>

                                              <table id="tblComingSoon" runat="server" border="0" visible="false">
                                                <tr><td align="left" class="Purchase_header">&nbsp;</td></tr>
                                                <tr><td class="Purchase_format">  
                                                        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:LangResources, ComingSoon %>"></asp:Label>
                                                    </td></tr>
                                                <tr><td align="right" class="Purchase_send">&nbsp;</td></tr>
                                                <tr><td align="left">
                                                
                                                </td></tr>
                                            </table>


                                        </div>
                                    </div>

                                </td>
                                <td> 
                                    <div id="dvEbDetails" class="ebookShowBox ebDetailsBox" runat="server">

                                      <table border="0" cellpadding="0" cellspacing="0">
                                          <tr>
                                              <td width="100px" class="RowFormLabel">
                                                  <asp:Literal ID="Literal1" Text="<%$ Resources:LangResources, eBook %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal2" Text="<%$ Resources:LangResources, Code %>" runat="server"></asp:Literal> :</td>
                                              <td width="150px" class="RowFormText"> <asp:Label ID="lblBookID" runat="server" Text='<%# Eval("BookID")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal3" Text="<%$ Resources:LangResources, eBook %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal4" Text="<%$ Resources:LangResources, Name %>" runat="server"></asp:Literal>: </td>
                                              <td class="RowFormText"> <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("BookNAme")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal5" Text="<%$ Resources:LangResources, Category %>" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("CategoryName")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal8" Text="<%$ Resources:LangResources, Date %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal9" Text="<%$ Resources:LangResources, Created %>" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateCreated","{0:MMMM d, yyyy}")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal6" Text="<%$ Resources:LangResources, OriginalPrice %>" runat="server"></asp:Literal>&nbsp; :</td>
                                              <td class="RowFormText">
                                                    <asp:Label ID="Label2" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                   <asp:Label ID="lblOrgPrice" runat="server" Text='<%# Eval("Price", "{0:0.00}")%>'></asp:Label></td>
                                          </tr>

                                            <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal7" Text="<%$ Resources:LangResources, AfterDiscount %>" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText"> 
                                                    <asp:Label ID="Label1" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                  <asp:Label ID="lblAfterDiscount" runat="server" Text='<%# Eval("DiscountedPrice", "{0:0.00}")%>'></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td colspan="2" align="center" style="padding: 10px;">
                                             
                                                     <asp:LinkButton ID="lnkAddtoCart"  Visible="false" OnClientClick="skm_LockScreen('Please wait while we take you to PayPal Site...')"  OnCommand="lnkAddtoCart_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") + "#" + Eval("ImageFileFullURL") %>' runat="server">                                                  
                                                   <img alt="Add2cart" src="Images/ebImages/Add2Cart.png" />
                                                   </asp:LinkButton>


                                                    <asp:LinkButton ID="LnkPayPalBuy"  Visible="false" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") + "#" + Eval("ImageFileFullURL") %>' runat="server">                                                  
                                                <img src="Images/ebImages/BuyNow.png" />
                                                  </asp:LinkButton>
                                                  <asp:Image ID="ImgFreeBook" Visible="false" ImageUrl="~/Images/ebImages/FREEebook2.gif" runat="server" />
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


     <%--   <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>--%>


    </table>

 <%--       </ContentTemplate>
        <Triggers>
     <asp:AsyncPostBackTrigger ControlID="LnkPayPalBuy"/>  
        </Triggers>
    </asp:UpdatePanel>--%>
</td>
</tr>

</table>
<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>


