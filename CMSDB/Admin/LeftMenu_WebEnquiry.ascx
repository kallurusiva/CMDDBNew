<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_WebEnquiry.ascx.cs" Inherits="Admin_LeftMenu_WebEnquiry" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Email.png" /><asp:Literal ID="Literal2" runat="server" Text="Web Enquiry" ></asp:Literal> </span></li>

<%--<li> <asp:HyperLink ID="HypWebEnquiryAdd" CssClass="LiCon add" runat="server" Text="About Us" NavigateUrl="WebEnquiryCreate.aspx"></asp:HyperLink> </li>--%>
<li> <asp:HyperLink ID="HypMyWebEnquiryListing" CssClass="LiCon listing" runat="server" Text="My WebEnquiry" NavigateUrl="Ad_EmailListing.aspx?RtType=USER"></asp:HyperLink> </li>



</ul>
</div>
