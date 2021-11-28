<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_Marketing.ascx.cs" Inherits="Admin_EBLeftMenu_Marketing" %>

<div id='leftmenu'>
<ul>

<li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="EBook Marketing"></asp:Literal> </span></li>
    <li id="li10" runat="server"> <asp:HyperLink ID="HyperLink10" CssClass="LiCon listing" runat="server" Text="Information" NavigateUrl="~/Admin/EBAd_EBookMarketingInfo.aspx"></asp:HyperLink> </li>
    <li id="li4" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon add" runat="server" Text="Database List" NavigateUrl="~/Admin/SMS/EBAd_EBook_CreateList_BookCode.aspx"></asp:HyperLink> </li>
    <li id="li1" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="Free EBook - SMS" NavigateUrl="~/Admin/SMS/EbAd_EBook_CreateList_BookCodeFree.aspx"></asp:HyperLink> </li>
    <li id="li2" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="Free EBook - Telegram" NavigateUrl="~/Admin/SMS/EbAd_EBook_CreateList_BookCode_FreeSYS.aspx"></asp:HyperLink> </li>

</ul>

</div>

