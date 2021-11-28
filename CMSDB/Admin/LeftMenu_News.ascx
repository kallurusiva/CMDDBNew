<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_News.ascx.cs" Inherits="Admin_LeftMenu_News" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/news.png" /><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LangResources, ManageNews %>"></asp:Literal> </span></li>

    <li> <asp:HyperLink ID="HypNewsAdd" CssClass="LiCon add" runat="server" Text="Add News" NavigateUrl="NewsCreate.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypMyNewsListing" CssClass="LiCon listing" runat="server" Text="My News" NavigateUrl="NewsListing.aspx?RtType=USER"></asp:HyperLink> </li>
<%--<li> <asp:HyperLink ID="HypAdminNews" CssClass="LiCon listing" runat="server" Text="Admin News" NavigateUrl="NewsListing.aspx?RtType=ADMIN"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypShowALL" CssClass="LiCon all" runat="server" Text="Show ALL" NavigateUrl="NewsListing.aspx?RtType=ALL"></asp:HyperLink> </li>--%>

<%--<li> <asp:HyperLink ID="HypAdminNews" CssClass="LiCon admin" runat="server" Text="Admin News" NavigateUrl="NewsListing.aspx?RtType=ADMIN"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypShowALL" CssClass="LiCon all" runat="server" Text="Show ALL" NavigateUrl="NewsListing.aspx?RtType=ALL"></asp:HyperLink> </li>--%>

<%--<li>
   <span class="subheader">  
    <asp:Literal ID="ltrWelcomePage" runat="server"></asp:Literal>
    </span>
</li>--%>


</ul>
</div>
