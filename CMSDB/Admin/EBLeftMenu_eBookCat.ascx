<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_eBookCat.ascx.cs" Inherits="EBLeftMenu_eBookCat" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="eBooks Catalog"></asp:Literal> </span></li>
<li id="li_AddNew" runat="server"> <asp:HyperLink ID="HypAddNew" CssClass="LiCon add" runat="server" Text="Add New eBook" NavigateUrl="~/Admin/EBAd_eBookADD.aspx"></asp:HyperLink> </li>
<li id="li_Listing" runat="server"> <asp:HyperLink ID="HypListing" CssClass="LiCon listing" runat="server" Text="View eBooks Catalog" NavigateUrl="~/Admin/EBAd_Catalog.aspx"></asp:HyperLink> </li>

</ul>
</div>
