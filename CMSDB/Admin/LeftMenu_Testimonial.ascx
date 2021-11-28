<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_Testimonial.ascx.cs" Inherits="Admin_LeftMenu_Testimonial" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Testimonial.png" /><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LangResources, ManageTestimonial %>"></asp:Literal> </span></li>
<li> <asp:HyperLink ID="HypTestimonialAdd" CssClass="LiCon add" runat="server" Text="About Us" NavigateUrl="TestimonialCreate.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypMyTestimonialListing" CssClass="LiCon listing" runat="server" Text="My Testimonial" NavigateUrl="TestimonialListing.aspx?RtType=USER"></asp:HyperLink> </li>
<%--<li> <asp:HyperLink ID="HypAdminTestimonial" CssClass="LiCon admin" runat="server" Text="Admin Testimonial" NavigateUrl="TestimonialListing.aspx?RtType=ADMIN"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypShowALL" CssClass="LiCon all" runat="server" Text="Show ALL" NavigateUrl="TestimonialListing.aspx?RtType=ALL"></asp:HyperLink> </li>--%>

<%--<li>
   <span class="subheader">  
    <asp:Literal ID="ltrWelcomePage" runat="server"></asp:Literal>
    </span>
</li>--%>


</ul>
</div>
