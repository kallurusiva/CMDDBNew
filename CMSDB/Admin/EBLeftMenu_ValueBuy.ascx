<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_ValueBuy.ascx.cs" Inherits="EBLeftMenu_ValueBuy" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Value-Buy"></asp:Literal> </span></li>
<li id="li_AddNew" runat="server"> <asp:HyperLink ID="HypAddNew" CssClass="LiCon add" runat="server" Text="Add Value-Buy eBook" NavigateUrl="~/Admin/EBAd_ValueBuyADD.aspx"></asp:HyperLink> </li>
<li id="li_Listing" runat="server"> <asp:HyperLink ID="HypListing" CssClass="LiCon listing" runat="server" Text="My Value-Buy eBooks" NavigateUrl="~/Admin/EBAd_ValueBuyList.aspx"></asp:HyperLink> </li>
<li id="li_AdminListing" runat="server"> <asp:HyperLink ID="HypAdmListing" CssClass="LiCon listing" runat="server" Text="Admin Value-Buy eBooks" NavigateUrl="~/Admin/EBAd_ValueBuyList.aspx?qUserType=ADMIN"></asp:HyperLink> </li>

</ul>
</div>
