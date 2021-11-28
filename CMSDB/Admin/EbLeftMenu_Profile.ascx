<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EbLeftMenu_Profile.ascx.cs" Inherits="EbLeftMenu_Profile" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>
<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Profile.png" />Profile</span></li>
<li> <asp:HyperLink ID="HypProfile" runat="server" CssClass="LiCon contact" Text="Web Profile" NavigateUrl="~/Admin/Ebook_ProfilePage.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypPassword" runat="server" CssClass="LiCon contact" Text="Change Password" NavigateUrl="~/Admin/Ad_ChangePassword.aspx"></asp:HyperLink> </li>
</ul>

<ul>

<li><span class="header"><img src="../Images/WebPortal/Email.png" />Web Enquiry</span></li>
<li> <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LiCon contact" Text="Enquiry List" NavigateUrl="Ad_EmailListing.aspx?RtType=USER"></asp:HyperLink> </li>
    </ul>

<ul>
<li><span class="header"><img src="../Images/WebPortal/Email.png" />Feedback</span></li>
<li> <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LiCon contact" Text="Feedback Listing" NavigateUrl="Ad_FeedBackListing.aspx"></asp:HyperLink> </li>

</ul>
</div>
