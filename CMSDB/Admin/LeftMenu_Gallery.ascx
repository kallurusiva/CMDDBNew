<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_Gallery.ascx.cs" Inherits="Admin_LeftMenu_Events" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/webGallery.png" /><asp:Literal ID="Literal2" runat="server" Text="Web Template"></asp:Literal> </span></li>

 <li> <asp:HyperLink ID="HypTemplates" CssClass="LiCon paint" runat="server" Text="Web Templates" NavigateUrl="~/Admin/Ad_TemplateSet.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypImagesGallery" CssClass="LiCon paint" runat="server" Text="Images Gallery " NavigateUrl="~/Admin/Ad_Gallery_Images2.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypVideoGallery" CssClass="LiCon paint" runat="server" Text="Videos Gallery " NavigateUrl="~/Admin/Ad_Gallery_Videos.aspx"></asp:HyperLink> </li>
<li> </li>
<li> <asp:HyperLink ID="HypSampleWebsites" CssClass="LiCon paint" runat="server" Text="Sample Websites" NavigateUrl="~/Admin/Ad_AncSampleWebs.aspx"></asp:HyperLink> </li>


<%--<li> <asp:HyperLink ID="HypAdminEvents" CssClass="LiCon admin" runat="server" Text="Admin Events" NavigateUrl="EventsListing.aspx?RtType=ADMIN"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypShowALL" CssClass="LiCon all" runat="server" Text="Show ALL" NavigateUrl="EventsListing.aspx?RtType=ALL"></asp:HyperLink> </li>--%>

<%--<li>
   <span class="subheader">  
    <asp:Literal ID="ltrWelcomePage" runat="server"></asp:Literal>
    </span>
</li>--%>


</ul>
</div>
