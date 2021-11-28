<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_CreateList.ascx.cs" Inherits="Admin_SMS_EBLeftMenu_CreateList" %>
<div id='leftmenu'>
<ul>
<li><span class="header"><img src="../../Images/WebPortal/Info.png" /><asp:Literal ID="Literal1" runat="server" Text="My Info"></asp:Literal> </span></li>
<li id="li_CreateList" runat="server"> <asp:HyperLink ID="HypCreateList" CssClass="LiCon add" runat="server" Text="Create List" NavigateUrl="EBAd_CreateList.aspx"></asp:HyperLink> </li>
<li id="li_ViewList" runat="server"> <asp:HyperLink ID="HypViewList" CssClass="LiCon add" runat="server" Text="View List" NavigateUrl="EBAd_CrateListView.aspx"></asp:HyperLink> </li>

</ul>
</div>
