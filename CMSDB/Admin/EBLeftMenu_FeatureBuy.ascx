<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_FeatureBuy.ascx.cs" Inherits="EBLeftMenu_FeatureBuy" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Feature-Buy"></asp:Literal> </span></li>
<li id="li_AddNew" runat="server"> <asp:HyperLink ID="HypAddNew" CssClass="LiCon add" runat="server" Text="Add Feauture-Buy eBook" NavigateUrl="~/Admin/EBAd_FeatureBuyADD2.aspx"></asp:HyperLink> </li>
<li id="li_Listing" runat="server"> <asp:HyperLink ID="HypListing" CssClass="LiCon listing" runat="server" Text="View Feauture-Buy eBooks" NavigateUrl="~/Admin/EBAd_FeatureBuy.aspx"></asp:HyperLink> </li>

</ul>
</div>
