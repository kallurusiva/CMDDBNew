<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_Books.ascx.cs" Inherits="EBLeftMenu_Books" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Manage Ebooks"></asp:Literal> </span></li>

<li id="liEbookCatalog" runat="server" visible="false" > <asp:HyperLink ID="HypEbookCatalog" CssClass="LiCon add" runat="server" Text="Ebook Catalog" NavigateUrl="EBAd_Catalog.aspx"></asp:HyperLink> </li>
<li id="liFeatureBuy" runat="server" visible="false" > <asp:HyperLink ID="HypFeaturedEbooks" CssClass="LiCon listing" runat="server" Text="Feature Buy" NavigateUrl="EBAd_FeatureBuy.aspx"></asp:HyperLink> </li>
<li id="liBestSeller" runat="server" visible="false" > <asp:HyperLink ID="HypBestSeller" CssClass="LiCon listing" runat="server" Text="Best Seller" NavigateUrl="EBAd_BestSeller.aspx"></asp:HyperLink> </li>
<li id="liValueBuy" runat="server" visible="false" > <asp:HyperLink ID="HypValueBuy" CssClass="LiCon listing" runat="server" Text="Value Buy" NavigateUrl="EBAd_ValueBuy.aspx"></asp:HyperLink> </li>




</ul>
</div>
