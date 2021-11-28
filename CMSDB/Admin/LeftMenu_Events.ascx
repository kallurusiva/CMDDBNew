<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_Events.ascx.cs" Inherits="Admin_LeftMenu_Events" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Event.png" /><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LangResources, ManageEvents %>"></asp:Literal> </span></li>
<li> <asp:HyperLink ID="HypEventsAdd" CssClass="LiCon add" runat="server" Text="Add Event" NavigateUrl="EventsCreate.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypMyEventsListing" CssClass="LiCon listing" runat="server" Text="My Events" NavigateUrl="EventsListing.aspx?RtType=USER"></asp:HyperLink> </li>
<%--<li> <asp:HyperLink ID="HypAdminEvents" CssClass="LiCon admin" runat="server" Text="Admin Events" NavigateUrl="EventsListing.aspx?RtType=ADMIN"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypShowALL" CssClass="LiCon all" runat="server" Text="Show ALL" NavigateUrl="EventsListing.aspx?RtType=ALL"></asp:HyperLink> </li>--%>

<%--<li>
   <span class="subheader">  
    <asp:Literal ID="ltrWelcomePage" runat="server"></asp:Literal>
    </span>
</li>--%>


</ul>
</div>
