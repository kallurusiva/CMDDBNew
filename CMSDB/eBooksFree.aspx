<%@ Page Title="" Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eBooksFree.aspx.cs" Inherits="eBooksFree" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>
<%@ Register Src="~/ebLeftCategories.ascx" TagPrefix="uc1" TagName="ebLeftCategories" %>


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
        
        <tr>
            <td valign="top">
                <uc1:ebLeftCategories runat="server" ID="ebLeftCategories" />
                <div id="dvLeftContent" class="ribbon" visible="false" style="width: 180px;" runat="server">
                   
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

                                         <asp:Label ID="lblHeader" CssClass="eb_head" runat="server" Text="<%$ Resources:LangResources, Free %>"></asp:Label>
                                         <%-- <asp:Label ID="Label1" CssClass="eb_head" runat="server" Text="<%$ Resources:LangResources, eBook %>"></asp:Label>--%>

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
                                   
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("BookID","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server"> 
                                     <div id="dvBookPurchaseFormat" class="dvBookPurchase_FreeBookCss" runat="server" visible="false">

                                            <table border="0">
                                                 <tr><td align="left" class="Purchase_headerB"><asp:Literal ID="Literal11" Text="<%$ Resources:LangResources, SMSPurchaseFormat %>" runat="server"></asp:Literal> </td></tr>
                                                <tr><td class="Purchase_format">  
                                                        <asp:Label ID="lblPurFormat" runat="server" Text=""></asp:Label>
                                                    </td></tr>
                                                <%--<tr><td align="left" class="font_12BoldGrey">&nbsp;SEND to <br />1) <b>+60146367111</b> <br />2) <b>+447860034140</b> <br />3) <b>+6281297978822</b> </td></tr>--%>
                                                <tr><td align="left" class="font_EventDates11">&nbsp;<asp:Literal ID="Literal12" Text="<%$ Resources:LangResources, SendTo %>" runat="server"></asp:Literal> &nbsp;&nbsp; &nbsp;&nbsp;1) <b>+60146367111</b>&nbsp;&nbsp;2) <b>+6584200138</b>&nbsp;&nbsp;3) <b>+628989111995</b>  &nbsp;&nbsp;3) <b>+447860041399</b> </td></tr>
                                                <tr><td align="left">
                                                    <asp:Label ID="lblPurchaseNote" CssClass="Purchase_Note2" runat="server" Text=""></asp:Label> </td></tr>
                                            </table>

                                          <%-- <table id="tblFreeEbooksPurchase" runat="server" border="0" visible="false">
                                                <tr><td align="left" class="Purchase_header">SMS Purchase Format</td></tr>
                                                <tr><td class="Purchase_format">  
                                                        <asp:Label ID="lblPurFormat" runat="server" Text=""></asp:Label>
                                                    </td></tr>
                                               <tr><td align="left" class="font_EventDates11">&nbsp;<b>SEND</b> to &nbsp;&nbsp; &nbsp;&nbsp;1) <b>+60146367111</b> &nbsp;&nbsp;2) <b>+447860034140</b> &nbsp;&nbsp;3) <b>+6281297978822</b> </td></tr>
                                                <tr><td align="left">
                                                    <asp:Label ID="lblPurchaseNote" CssClass="Purchase_Note" runat="server" Text=""></asp:Label> </td></tr>
                                            </table>--%>


                                        </div>
                                            </asp:HyperLink>
                                         </div>


                                </td>
                                <td> 
                                    <div id="dvEbDetails" class="ebookShowBox ebDetailsBox" runat="server">

                                      <table border="0" cellpadding="0" cellspacing="0">
                                          <tr>
                                             <td width="100px" class="RowFormLabel"> <asp:Literal ID="Literal1" Text="<%$ Resources:LangResources, eBook %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal2" Text="<%$ Resources:LangResources, Code %>" runat="server"></asp:Literal>:</td>
                                              <td width="150px" class="RowFormText"> <asp:Label ID="lblBookID" runat="server" Text='<%# Eval("BookID")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                             <td class="RowFormLabel"><asp:Literal ID="Literal3" Text="<%$ Resources:LangResources, eBook %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal4" Text="<%$ Resources:LangResources, Name %>" runat="server"></asp:Literal>:</td>
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
                                              <td class="RowFormLabel"><asp:Literal ID="Literal6" Text="<%$ Resources:LangResources, OriginalPrice %>" runat="server"></asp:Literal>:</td>
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
                                               <%--    <img width="120px" height="36px" src="Images/ebImages/Buy-Now-Button-small.jpg" />
                                                  <img src="Images/ebImages/master_buyNow.jpg" /> </tr>--%>
                                                  <img src="Images/ebImages/FREEebook2.gif" />
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


      <%--  <tr>
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

