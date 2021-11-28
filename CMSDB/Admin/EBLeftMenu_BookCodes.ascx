<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_BookCodes.ascx.cs" Inherits="Admin_EBLeftMenu_BookCodes" %>
<div id='leftmenu'>
<ul>

<li>&nbsp;</li>
<li id="li_ebookReporting" runat="server"><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal3" runat="server" Text="Product Records"></asp:Literal> </span></li>
<li id="li_EbookSales" runat="server"> <asp:HyperLink ID="HypAddNew" CssClass="LiCon add" runat="server" Text="View PremiumSMS" NavigateUrl="~/Admin/EBAd_BookCodesNew.aspx"></asp:HyperLink> </li>
    <li id="li1" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="View Freee" NavigateUrl="~/Admin/EBAd_BookCodesFree.aspx"></asp:HyperLink> </li>
    <li id="li3" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon add" runat="server" Text="View Bookcode List" NavigateUrl="~/Admin/SMS/EBAd_EBook_CreateList_BookCode.aspx"></asp:HyperLink> </li>


<%--<li>&nbsp;</li>
<li><span class="subheader"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Product Premium<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SMS Reporting"></asp:Literal> </span></li>
<li id="li_2wayCurrent" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="View 2way Current report" NavigateUrl="~/Admin/EbAd_2WayReport.aspx"></asp:HyperLink> </li>--%>
<%--<li id="li_2wayArhived" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="View 2Way Archived report" NavigateUrl="#" ToolTip="Coming Soon"></asp:HyperLink> </li>--%>

    <li>&nbsp;</li>


<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal1" runat="server" Text="Generate List"></asp:Literal> </span></li>
<li id="li_CreateList" runat="server"> <asp:HyperLink ID="HypCreateList" CssClass="LiCon add" runat="server" Text="Create List" NavigateUrl="SMS/EBAd_CreateList.aspx"></asp:HyperLink> </li>
<li id="li_ViewList" runat="server"> <asp:HyperLink ID="HypViewList" CssClass="LiCon add" runat="server" Text="View Created List" NavigateUrl="SMS/EBAd_CrateListView.aspx"></asp:HyperLink> </li>


    <li>&nbsp;</li>


<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal2" runat="server" Text="Web Users"></asp:Literal> </span></li>
<li id="li2" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="User List" NavigateUrl="PrepaidCardRegisteredUsers.aspx"></asp:HyperLink> </li> 
    <%--<li id="li3" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon add" runat="server" Text="Send SMS to Prepaid List" NavigateUrl="PrepaidCardSendSMSList.aspx"></asp:HyperLink> </li> 
    <li id="li4" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon add" runat="server" Text="Send Email to Prepaid List" NavigateUrl="PrepaidCardSendSMSEmail.aspx"></asp:HyperLink> </li> --%>



</ul>
</div>