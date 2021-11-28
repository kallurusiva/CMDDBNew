<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_SMSSystem.ascx.cs" Inherits="Admin_SMS_EBLeftMenu_SMSSystem" %>
<div id='leftmenu'>
<ul>
<li><span class="header"><img src="../../Images/WebPortal/Info.png" /><asp:Literal ID="Literal1" runat="server" Text="My Info"></asp:Literal> </span></li>
<li id="li_MyAccount" runat="server"> <asp:HyperLink ID="HypMyAccount" CssClass="LiCon add" runat="server" Text="SMS Account" NavigateUrl="EBAd_MySMSAccount.aspx"></asp:HyperLink> </li>
<li id="li1" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="SMS Topup Rate" NavigateUrl="EBAd_SMSRate.aspx"></asp:HyperLink> </li>
<%--<li id="li_AdhocSMS" runat="server"> <asp:HyperLink ID="HypAdhocSMS" CssClass="LiCon add" runat="server" Text="Send Adhoc SMS" NavigateUrl="EBAd_SendAdhocSMS.aspx"></asp:HyperLink> </li>
<li id="li_CreditChgs" runat="server"> <asp:HyperLink ID="HypCreditChgs" CssClass="LiCon add" runat="server" Text="SMS Credit Charges" NavigateUrl="EBAd_CreditCharges.aspx"></asp:HyperLink> </li>
<li>&nbsp;</li>
<li><span class="header"><img src="../../Images/WebPortal/Topup.png" /><asp:Literal ID="Literal2" runat="server" Text="SMS Topup"></asp:Literal> </span></li>
<li id="li_SMSTopup" runat="server"> <asp:HyperLink ID="HypSMSTopup" CssClass="LiCon add" runat="server" Text="SMS Topup" NavigateUrl="EBAd_SMSTopup.aspx"></asp:HyperLink> </li>--%>
<%--<li id="li_SMSTopupPIN" runat="server"> <asp:HyperLink ID="HypSMSTopupPin" CssClass="LiCon add" runat="server" Text="SMS Topup with PIN No" NavigateUrl="EBAd_SMSTopupPIN.aspx"></asp:HyperLink> </li>--%>
<li id="li_SMSTopupList" runat="server"> <asp:HyperLink ID="HypSMSTopupList" CssClass="LiCon add" runat="server" Text="SMS Topup History" NavigateUrl="EBAd_TopupByMobileList.aspx"></asp:HyperLink> </li>

<%--<li id="li_SMSTopupPayPal" runat="server"> <asp:HyperLink ID="HypSMSPayPal" CssClass="LiCon add" runat="server" Text="SMS Topup PayPal" NavigateUrl="EBAd_TopupByPayPal.aspx"></asp:HyperLink> </li>
<li id="li_SMSTopupPayPalList" runat="server"> <asp:HyperLink ID="HypSMSPayPalList" CssClass="LiCon add" runat="server" Text="PayPal History" NavigateUrl="EBAd_TopupByPayPalList.aspx"></asp:HyperLink> </li>--%>

<li>&nbsp;</li>
<li><span class="header"><img src="../../Images/WebPortal/Statistics.png" /><asp:Literal ID="Literal3" runat="server" Text="SMS Report"></asp:Literal> </span></li>
<li id="li_1WayReport" runat="server"> <asp:HyperLink ID="Hyp1WayReport" CssClass="LiCon add" runat="server" Text="1Way Report" NavigateUrl="EBAd_1WayReport.aspx"></asp:HyperLink> </li>
<%--<li>&nbsp;</li>
<li><span class="header"><img src="../../Images/WebPortal/Statistics.png" /><asp:Literal ID="Literal4" runat="server" Text="2 Way Report"></asp:Literal> </span></li>--%>
<li id="li_2WayReport" runat="server"> <asp:HyperLink ID="Hyp2WayReport" CssClass="LiCon add" runat="server" Text="Incoming SMS" NavigateUrl="EBAd_PremiumReport.aspx"></asp:HyperLink> </li>

</ul>
</div>