<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_PayPalCC.ascx.cs" Inherits="EBLeftMenu_PayPalCC" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Payment"></asp:Literal> </span></li>
<%--<li id="li_AddNew" runat="server"> <asp:HyperLink ID="HypAddNew" CssClass="LiCon add" runat="server" Text="PayPal Credit Card" NavigateUrl="~/Admin/EBAd_PayPalCC.aspx"></asp:HyperLink> </li>--%>


<li id="li1" runat="server"> <asp:HyperLink ID="HypSummary" CssClass="LiCon add" runat="server" Text="Summary" NavigateUrl="~/Admin/EBookPaymentReport_Summary.aspx"></asp:HyperLink> </li>
<li id="li_Purchases" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="PayPal Purchases" NavigateUrl="~/Admin/EBAd_PayPalTXs.aspx"></asp:HyperLink> </li>
<li id="li_View" runat="server"> <asp:HyperLink ID="HypDirect" CssClass="LiCon add" runat="server" Text="Credit Card Incentive" NavigateUrl="~/Admin/EBookPaymentReport_Own.aspx"></asp:HyperLink> </li>
<li id="li_Request" runat="server"> <asp:HyperLink ID="HypSponsor" CssClass="LiCon add" runat="server" Text="Direct Partner" NavigateUrl="~/Admin/EBookPaymentReport_Sponsor.aspx"></asp:HyperLink> </li>
<li id="li2" runat="server"> <asp:HyperLink ID="HypAuthor" CssClass="LiCon add" runat="server" Text="EBook Author" NavigateUrl="~/Admin/EBookPaymentReport_Author.aspx"></asp:HyperLink> </li>
<li id="li3" runat="server"> <asp:HyperLink ID="HypIntroducer" CssClass="LiCon add" runat="server" Text="Author Introducer" NavigateUrl="~/Admin/EBookPaymentReport_Introducer.aspx"></asp:HyperLink> </li>

</ul>
</div>
