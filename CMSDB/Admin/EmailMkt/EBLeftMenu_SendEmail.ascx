<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_SendEmail.ascx.cs" Inherits="Admin_EBLeftMenu_SendEmail" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>
<li><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Email Marketing"></asp:Literal> </span></li>
<li id="liEbookEmail" runat="server"> <asp:HyperLink ID="HypEbookEmail" CssClass="LiCon add" runat="server" Text="Email a Product" NavigateUrl="EbAd_EmailEbook.aspx"></asp:HyperLink> </li>
<li id="liEbookReport" runat="server"> <asp:HyperLink ID="HypEbookReport" CssClass="LiCon listing" runat="server" Text="Email History" NavigateUrl="EbAd_EmailEbookHistory.aspx"></asp:HyperLink> </li>
<li id="liEmailUnsubscribe" runat="server"> <asp:HyperLink ID="HypUnsubscribe" CssClass="LiCon listing" runat="server" Text="Unsubscribe Email" NavigateUrl="EbAd_UnsubscribeEmailsHistory.aspx"></asp:HyperLink> </li>
</ul>
</div>
