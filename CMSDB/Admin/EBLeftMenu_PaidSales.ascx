<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_PaidSales.ascx.cs" Inherits="Admin_EBLeftMenu_PaidSales" %>
<div id='leftmenu'>
<ul>
<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal1" runat="server" Text="Incentive Details"></asp:Literal> </span></li>

<li id="li2" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="Summary" NavigateUrl="PremiumSMSReport_Summary.aspx"></asp:HyperLink> </li> 
<li id="li1" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="All Incentive History" NavigateUrl="PremiumSMSReport_FULL.aspx"></asp:HyperLink> </li>
<li id="li3" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon add" runat="server" Text="EBookStore$$" NavigateUrl="PremiumSMSReport_FULL_Bookstore.aspx"></asp:HyperLink> </li>
<li id="li4" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon add" runat="server" Text="Direct Partner$$" NavigateUrl="PremiumSMSReport_FULL_Sponsor.aspx"></asp:HyperLink> </li>
<li id="li5" runat="server"> <asp:HyperLink ID="HyperLink5" CssClass="LiCon add" runat="server" Text="Author$$" NavigateUrl="PremiumSMSReport_FULL_Author.aspx"></asp:HyperLink> </li>
<li id="li6" runat="server"> <asp:HyperLink ID="HyperLink6" CssClass="LiCon add" runat="server" Text="Author Intro$$" NavigateUrl="PremiumSMSReport_FULL_Introducer.aspx"></asp:HyperLink> </li>

    

    <br />

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal4" runat="server" Text="Account Details"></asp:Literal> </span></li>
<li id="li9" runat="server"> <asp:HyperLink ID="HyperLink9" CssClass="LiCon add" runat="server" Text="Account Summary" NavigateUrl="~/Admin/EBAd_AccountSummary.aspx"></asp:HyperLink> </li>
<li id="li10" runat="server"> <asp:HyperLink ID="HyperLink10" CssClass="LiCon add" runat="server" Text="Partner Details" NavigateUrl="~/Admin/EBAd_PartnerDetaills.aspx"></asp:HyperLink> </li>
<li id="li7" runat="server"> <asp:HyperLink ID="HyperLink7" CssClass="LiCon add" runat="server" Text="Exchange Rate" NavigateUrl="~/Admin/EBAd_CurrencyTableNew.aspx"></asp:HyperLink> </li>

<br />

</ul>
</div>
