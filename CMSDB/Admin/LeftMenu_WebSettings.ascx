<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_WebSettings.ascx.cs" Inherits="Admin_LeftMenu_WebSettings" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Settings.png" /><asp:Literal ID="Literal2" runat="server" Text="Web Settings" ></asp:Literal> </span></li>

<li> <asp:HyperLink ID="HypWebSettings" CssClass="LiCon tools" runat="server" Text="Web Settings" NavigateUrl="Ad_WebSettings.aspx"></asp:HyperLink> </li>
<%--<li> <asp:HyperLink ID="HypMainPageSettings" CssClass="LiCon tools" runat="server" Text="Main Page Settings" NavigateUrl="Ad_MainPageSetting.aspx"></asp:HyperLink> </li>--%>
<%--<li> <asp:HyperLink ID="HypWebEnquiry" CssClass="LiCon tools" runat="server" Text="My WebEnquiry" NavigateUrl="Ad_EmailListing.aspx?RtType=USER"></asp:HyperLink> </li>--%>
<li> <asp:HyperLink ID="HypLogo" CssClass="LiCon paint" runat="server" Text="Logo Selection" NavigateUrl="Ad_LogoSettings.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypTempPicture" CssClass="LiCon camera" runat="server" Text="Banner Selection" NavigateUrl="Ad_BannerSettings.aspx"></asp:HyperLink> </li>


<li> <asp:HyperLink ID="HypSideBanner" CssClass="LiCon camera" runat="server" Text="Side Banner Selection" NavigateUrl="Ad_WP_SideImage.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypBottomBanner" CssClass="LiCon camera" runat="server" Text="Bottom Banner Selection" NavigateUrl="Ad_WP_BottomImage.aspx"></asp:HyperLink> </li>

 <li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/webTemplate.png" /><asp:Literal ID="Literal1" runat="server" Text="Web Templates" ></asp:Literal> </span></li>

<li> <asp:HyperLink ID="HypCurrentDesign" CssClass="LiCon paint" Visible="false" runat="server" Text="Current Design" NavigateUrl="EbAd_CurrentDesign.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypWebTemplate" CssClass="LiCon camera" runat="server" Text="Web Templates" NavigateUrl="Ad_TemplateSet.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="hypWebDesign4" CssClass="LiCon camera" runat="server" Text="Web Design 2" NavigateUrl="~/Admin/EbAd_SetDesign11.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="hypWebDesign5" CssClass="LiCon camera" runat="server" Text="Web Design 3" NavigateUrl="~/Admin/EbAd_SetDesign15.aspx"></asp:HyperLink> </li>

<li> <asp:HyperLink ID="HypImagesGallery" CssClass="LiCon paint" runat="server" Text="Images Gallery " NavigateUrl="~/Admin/Ad_Gallery_Images2.aspx"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypVideoGallery" CssClass="LiCon paint" runat="server" Text="Videos Gallery " NavigateUrl="~/Admin/Ad_Gallery_Videos.aspx"></asp:HyperLink> </li>




<%--<li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/email.png" /><asp:Literal ID="Literal4" runat="server" Text="EMAIL System" ></asp:Literal> </span></li>
<li> <asp:HyperLink ID="HypEmailSystem" CssClass="LiCon tools" runat="server" Text="Email Details" NavigateUrl="~/Admin/Ads_EmailPageEbook.aspx"></asp:HyperLink> </li>--%>

<%--<li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/email.png" /><asp:Literal ID="Literal3" runat="server" Text="EMAIL System" ></asp:Literal> </span></li>
<li> <asp:HyperLink ID="HypEmailSystem" CssClass="LiCon tools" runat="server" Text="Email Details" NavigateUrl="~/Admin/Ads_EmailPage.aspx"></asp:HyperLink> </li>


    
<li>&nbsp;</li>
<li id="liPhyBookHeader" runat="server" visible="false"><span class="subheader"><img src="../Images/WebPortal/application_add.png" /><asp:Literal ID="Literal4" runat="server" Text="Physical Book" ></asp:Literal> </span></li>
<li id="liPhyBookLink1" runat="server" visible="false"> <asp:HyperLink ID="HypBookRequest" CssClass="LiCon tools" runat="server" Text="Physical Book Request" NavigateUrl="~/Admin/EbAd_PhyEBookRequest.aspx"></asp:HyperLink> </li>
--%>


</ul>
</div>
