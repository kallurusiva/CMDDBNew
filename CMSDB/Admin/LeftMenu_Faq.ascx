<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_Faq.ascx.cs" Inherits="Admin_LeftMenu_Faq" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/faq.png" /><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LangResources, ManageFaq %>"></asp:Literal> </span></li>

<li> <asp:HyperLink ID="HypFaqAdd" CssClass="LiCon add" runat="server" Text="Add FAQ" NavigateUrl="FaqCreate.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypMyFaqListing" CssClass="LiCon listing" runat="server" Text="My Faq" NavigateUrl="FaqListing.aspx?RtType=USER"></asp:HyperLink> </li>
<%--<li> <asp:HyperLink ID="HypAdminFaq" CssClass="LiCon admin" runat="server" Text="Admin Faq" NavigateUrl="FaqListing.aspx?RtType=ADMIN"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypShowALL" CssClass="LiCon all" runat="server" Text="Show ALL" NavigateUrl="FaqListing.aspx?RtType=ALL"></asp:HyperLink> </li>--%>

<%--<li>
   <span class="subheader">  
    <asp:Literal ID="ltrWelcomePage" runat="server"></asp:Literal>
    </span>
</li>--%>


</ul>
</div>
