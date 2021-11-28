<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_Profit.ascx.cs" Inherits="Admin_EBLeftMenu_Profit" %>
<div id='leftmenu'>
<ul>
<li><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Profit Sharing"></asp:Literal> </span></li>
<li id="li_Current" runat="server"> <asp:HyperLink ID="HypCurrentMonth" CssClass="LiCon add" runat="server" Text="Current Month" NavigateUrl="~/Admin/EbAd_CurrentMonthProfit.aspx"></asp:HyperLink> </li>
<li id="li_Profit" runat="server"> <asp:HyperLink ID="HypProfit" CssClass="LiCon add" runat="server" Text="Monthly Statement" NavigateUrl="~/Admin/EbAd_MyProfitShareList.aspx"></asp:HyperLink> </li>

 
<li>&nbsp;</li>
<li><span class="header"><img src="../Images/WebPortal/webTemplate.png" /><asp:Literal ID="Literal1" runat="server" Text="Payment Details" ></asp:Literal> </span></li>

<li id="li_View" runat="server"> <asp:HyperLink ID="HypAddNew" CssClass="LiCon add" runat="server" Text="Bank Details" NavigateUrl="~/Admin/EbAd_BankInfo.aspx"></asp:HyperLink> </li>
<li id="li_Request" runat="server"> <asp:HyperLink ID="HypPayRequest" CssClass="LiCon add" runat="server" Text="Payment Request" NavigateUrl="~/Admin/EbAd_PaymentRequest.aspx"></asp:HyperLink> </li>
<li id="li_Payment" runat="server"> <asp:HyperLink ID="HypPayment" CssClass="LiCon add" runat="server" Text="Profit History" NavigateUrl="~/Admin/EbAd_PaymentList.aspx"></asp:HyperLink> </li>
</ul>
</div>