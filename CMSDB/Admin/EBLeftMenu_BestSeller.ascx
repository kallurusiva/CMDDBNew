<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_BestSeller.ascx.cs" Inherits="EBLeftMenu_BestSeller" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Best-Seller"></asp:Literal> </span></li>
<%--<li id="li_AddNew" runat="server"> <asp:HyperLink ID="HypAddNew" CssClass="LiCon add" runat="server" Text="Add Best-Seller eBook" NavigateUrl="~/Admin/EBAd_BestSellerADD1.aspx"></asp:HyperLink> </li>--%>

    <li id="li1" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="Add Best-Seller eBook" NavigateUrl="~/Admin/EBAd_BestSellerADD2.aspx"></asp:HyperLink> </li>

<li id="li_Listing" runat="server"> <asp:HyperLink ID="HypListing" CssClass="LiCon listing" runat="server" Text="View Best-Seller eBooks" NavigateUrl="~/Admin/EBAd_BestSeller.aspx"></asp:HyperLink> </li>

</ul>
</div>
