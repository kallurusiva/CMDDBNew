<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_Dashboard.ascx.cs" Inherits="EBLeftMenu_Dashboard" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal3" runat="server" Text="DashBoard"></asp:Literal> </span></li>
    <li id="li1" runat="server"> <asp:HyperLink ID="HypDashboard" CssClass="LiCon add" runat="server" Text="DashBoard" NavigateUrl="~/Admin/EBAd_Dashboard.aspx"></asp:HyperLink> </li>

<li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal4" runat="server" Text="Estore Setup"></asp:Literal> </span></li>
<li id="li5" runat="server"> <asp:HyperLink ID="HypEstoreMgmt" CssClass="LiCon add" runat="server" Text="EStore Setting" NavigateUrl="~/Admin/EBAd_eStoreMgmt.aspx"></asp:HyperLink> </li>

<li>&nbsp;</li>

<li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Admin Books"></asp:Literal> </span></li>
    <li id="li10" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon listing" runat="server" Text="Admin Category" NavigateUrl="~/Admin/EBAd_eStoreAdminCats.aspx"></asp:HyperLink> </li>
    <li id="li11" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon listing" runat="server" Text="Admin SubCategory" NavigateUrl="~/Admin/EBAd_eStoreAdminSubCats.aspx"></asp:HyperLink> </li>
    <li id="li3" runat="server"> <asp:HyperLink ID="HypAdminEbooks" CssClass="LiCon listing" runat="server" Text="Admin EBooks" NavigateUrl="~/Admin/EBAd_BookListingAdmin.aspx"></asp:HyperLink> </li>
    <li id="li14" runat="server"> <asp:HyperLink ID="HypAuthorEbooks" CssClass="LiCon listing" runat="server" Text="Your Admin EBooks" NavigateUrl="~/Admin/EBAd_BookListingAuthorNew.aspx"></asp:HyperLink> </li>
    <li id="li17" runat="server"> <asp:HyperLink ID="HypIntroEbooks" CssClass="LiCon listing" runat="server" Text="Author Intro EBooks" NavigateUrl="~/Admin/EBAd_BookListingIntroducer.aspx"></asp:HyperLink> </li>
   <li id="li2" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon listing" runat="server" Text="Assign Admin EBooks" NavigateUrl="~/Admin/EBAd_AssignAdminBook.aspx"></asp:HyperLink> </li>
    <li id="li4" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon listing" runat="server" Text="Assign Admin List" NavigateUrl="~/Admin/EBAd_AssignAdminBooks.aspx"></asp:HyperLink> </li>
    
<li>&nbsp;</li>
<li id="li101" runat="server"><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal5" runat="server" Text="Request Upload Admin eBooks"></asp:Literal> </span></li>
     <li id="li15" runat="server"> <asp:HyperLink ID="HyperLink7" CssClass="LiCon listing" runat="server" Text="Upload Admin EBook" NavigateUrl="~/Admin/EBAd_eBookADD_ReqAdm_start.aspx"></asp:HyperLink> </li>
    <li id="li16" runat="server"> <asp:HyperLink ID="HyperLink8" CssClass="LiCon listing" runat="server" Text="Admin Ebook History" NavigateUrl="~/Admin/EBAd_BookListing_ReqAdm.aspx"></asp:HyperLink> </li>
    
<li>&nbsp;</li>

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal6" runat="server" Text="EISBN Submission"></asp:Literal> </span></li>
<li id="li18" runat="server"> <asp:HyperLink ID="HyperLink10" CssClass="LiCon add" runat="server" Text="Submission Form" NavigateUrl="EBAd_EISBNupdate.aspx"></asp:HyperLink> </li>
<li id="li19" runat="server"> <asp:HyperLink ID="HyperLink11" CssClass="LiCon add" runat="server" Text="History" NavigateUrl="EBAd_EISBNupdateHistory.aspx"></asp:HyperLink> </li>

<li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal11" runat="server" Text="MyEBook"></asp:Literal> </span></li>   
    <li id="li8" runat="server"> <asp:HyperLink ID="HypAddNewEbooks" CssClass="LiCon add" runat="server" Text="Add MyEBook" NavigateUrl="~/Admin/EBAd_eBookADD2.aspx"></asp:HyperLink> </li>
    <li id="li9" runat="server"> <asp:HyperLink ID="HypMyEbooks" CssClass="LiCon listing" runat="server" Text="MyEBook History" NavigateUrl="~/Admin/EBAd_BookListing.aspx?qType=1"></asp:HyperLink> </li>
 


<li>&nbsp;</li>
 <li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal1" runat="server" Text="My Categories"></asp:Literal> </span></li>
 <li id="li12" runat="server"> <asp:HyperLink ID="HyperLink5" CssClass="LiCon add" runat="server" Text="My Category" NavigateUrl="~/Admin/EBAd_eStoreMyCats.aspx"></asp:HyperLink> </li>
    <li id="li13" runat="server"> <asp:HyperLink ID="HyperLink6" CssClass="LiCon add" runat="server" Text="My SubCategory" NavigateUrl="~/Admin/EBAd_eStoreMySubCats.aspx"></asp:HyperLink> </li>
 <li id="li7" runat="server"> <asp:HyperLink ID="HypMainCategory" CssClass="LiCon add" runat="server" Text="Create Main Category" NavigateUrl="~/Admin/EBAd_UserCategoryMain.aspx"></asp:HyperLink> </li>
 <li id="li6" runat="server"> <asp:HyperLink ID="HypMyCategory" CssClass="LiCon add" runat="server" Text="Create Sub Category" NavigateUrl="~/Admin/EBAd_UserCategoryList.aspx"></asp:HyperLink> </li>




</ul>

</div>
