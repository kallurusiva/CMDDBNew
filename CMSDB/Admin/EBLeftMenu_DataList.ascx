<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_DataList.ascx.cs" Inherits="Admin_EBLeftMenu_DataList" %>
<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal2" runat="server" Text="Data-List"></asp:Literal> </span></li>
<li id="li2" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="EBookCode List" NavigateUrl="~/Admin/SMS/EBAd_EBook_CreateList_BookCode.aspx"></asp:HyperLink> </li> 


</ul>

<%--<ul>

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal1" runat="server" Text="Generate List"></asp:Literal> </span></li>
<li id="li1" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="Create List" NavigateUrl="~/Admin/SMS/EBAd_CreateList.aspx"></asp:HyperLink> </li> 
<li id="li3" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon add" runat="server" Text="View Created List" NavigateUrl="~/Admin/SMS/EBAd_CrateListView.aspx"></asp:HyperLink> </li> 

</ul>--%>
</div>

