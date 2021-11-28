<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_Profile.ascx.cs" Inherits="Admin_LeftMenu_Profile" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>
<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Profile.png" />Profile</span></li>
<li> <asp:HyperLink ID="HypContactUs" runat="server"  CssClass="LiCon contact" Text="Contact Us" NavigateUrl="MyAccount.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypChangePassword" runat="server" Visible="false"  CssClass="LiCon contact" Text="Change Password" NavigateUrl="~/Admin/Ad_ChangePassword.aspx"></asp:HyperLink> </li>


<li id="hrdAboutUs" runat="server">
   <span class="subheader">  
    <asp:Literal ID="ltrAboutUs" runat="server"></asp:Literal>
    </span>
</li>
<li> <asp:HyperLink ID="HypAboutUsAdd" CssClass="LiCon add" runat="server" Text="About Us" NavigateUrl="Ad_AboutUsPageCreate.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypAboutUsAddListing" CssClass="LiCon listing" runat="server" Text="AboutUs Listing" NavigateUrl="Ad_AboutUsPageListing.aspx"></asp:HyperLink> </li>

     <li>&nbsp;</li>
<li>
   <span class="subheader">  
    <asp:Literal ID="ltrWelcomePage" runat="server"></asp:Literal>
    </span>
</li>

<li> <asp:HyperLink ID="HypWelcomePageAdd" runat="server" CssClass="LiCon add" Text="Welcome Page" NavigateUrl="Ad_WelComePageSettings.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypWelcomePageListing" CssClass="LiCon listing" runat="server" Text="Welcome Page Listing" NavigateUrl="Ad_WelcomePageListing.aspx"></asp:HyperLink> </li>

</ul>
</div>
