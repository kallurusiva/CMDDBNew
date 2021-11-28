<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_PremiumSMS.ascx.cs" Inherits="Admin_EBLeftMenu_PremiumSMS" %>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/webTemplate.png" /><asp:Literal ID="Literal1" runat="server" Text="PremiumSMS" ></asp:Literal> </span></li>

<li id="li1" runat="server"> <asp:HyperLink ID="HypSummary" CssClass="LiCon add" runat="server" Text="Summary" NavigateUrl="~/Admin/PremiumSMSReport_Summary.aspx"></asp:HyperLink> </li>
<li id="li_View" runat="server"> <asp:HyperLink ID="HypDirect" CssClass="LiCon add" runat="server" Text="PremiumSMS" NavigateUrl="~/Admin/PremiumSMSReport_Own.aspx"></asp:HyperLink> </li>
<li id="li_Request" runat="server"> <asp:HyperLink ID="HypSponsor" CssClass="LiCon add" runat="server" Text="Direct Partner" NavigateUrl="~/Admin/PremiumSMSReport_Sponsor.aspx"></asp:HyperLink> </li>
<li id="li2" runat="server"> <asp:HyperLink ID="HypAuthor" CssClass="LiCon add" runat="server" Text="EBook Author" NavigateUrl="~/Admin/PremiumSMSReport_Author.aspx"></asp:HyperLink> </li>
<li id="li3" runat="server"> <asp:HyperLink ID="HypIntroducer" CssClass="LiCon add" runat="server" Text="Author Introducer" NavigateUrl="~/Admin/PremiumSMSReport_Introducer.aspx"></asp:HyperLink> </li>
</ul>
</div>
