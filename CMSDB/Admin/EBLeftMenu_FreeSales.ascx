<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_FreeSales.ascx.cs" Inherits="Admin_EBLeftMenu_FreeSales" %>
<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal2" runat="server" Text="Free Sales"></asp:Literal> </span></li>
<li id="li2" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="Free EBook History" NavigateUrl="EBAd_BookCodesFree.aspx"></asp:HyperLink> </li> 
    <%--<li id="li3" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon add" runat="server" Text="Send SMS to Prepaid List" NavigateUrl="PrepaidCardSendSMSList.aspx"></asp:HyperLink> </li> 
    <li id="li4" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon add" runat="server" Text="Send Email to Prepaid List" NavigateUrl="PrepaidCardSendSMSEmail.aspx"></asp:HyperLink> </li> --%>



</ul>
</div>

