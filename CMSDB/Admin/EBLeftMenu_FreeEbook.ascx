<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_FreeEbook.ascx.cs" Inherits="EBLeftMenu_BestSeller" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Free"></asp:Literal> </span></li>

<li id="li1" runat="server"> <asp:HyperLink ID="HypAdd" CssClass="LiCon add" runat="server" Text="Add Product" NavigateUrl="~/Admin/EBAd_FreeEbookADD.aspx"></asp:HyperLink> </li>

<li id="li_Listing" runat="server"> <asp:HyperLink ID="HypListing" CssClass="LiCon listing" runat="server" Text="View Products" NavigateUrl="~/Admin/EBAd_FreeEbooks.aspx"></asp:HyperLink> </li>



<li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/webTemplate.png" /><asp:Literal ID="Literal4" runat="server" Text="Product Records" ></asp:Literal> </span></li>
<li id="li_FreeSales" runat="server"> <asp:HyperLink ID="HypFree" CssClass="LiCon add" runat="server" Text="View Product Records" NavigateUrl="~/Admin/EbAd_FreeBookCodes.aspx"></asp:HyperLink> </li>





</ul>
</div>
