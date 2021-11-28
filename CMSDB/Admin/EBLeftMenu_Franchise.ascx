<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_Franchise.ascx.cs" Inherits="Admin_EBLeftMenu_Franchise" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>

<div id='leftmenu'>
<ul>

<li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Prestasi DFranchise"></asp:Literal> </span></li>
    <li id="li10" runat="server"> <asp:HyperLink ID="HyperLink10" CssClass="LiCon listing" runat="server" Text="Agreement" NavigateUrl="~/Admin/EBAd_AgreementPrestasi.aspx"></asp:HyperLink> </li>
    <li id="li2" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon listing" runat="server" Text="Dashboard" NavigateUrl="~/Admin/EBAd_DashboardFranchise.aspx"></asp:HyperLink> </li>
    <li id="li1" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon listing" runat="server" Text="Info" NavigateUrl="~/Admin/EBAd_InfoFranchise.aspx"></asp:HyperLink> </li>
    <li id="li3" runat="server"> <asp:HyperLink ID="HypAdminEbooks" CssClass="LiCon listing" runat="server" Text="EBooks" NavigateUrl="~/Admin/EBAd_BookListingAdminFranchise.aspx"></asp:HyperLink> </li>
    <li id="li4" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon listing" runat="server" Text="Category" NavigateUrl="~/Admin/EBAd_eStoreAdminCatsFranchise.aspx"></asp:HyperLink> </li>
    <li id="li11" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon listing" runat="server" Text="SubCategory" NavigateUrl="~/Admin/EBAd_eStoreAdminSubCatsFranchise.aspx"></asp:HyperLink> </li>
    

    <li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal1" runat="server" Text="GS DFranchise"></asp:Literal> </span></li>
    <li id="li12" runat="server"> <asp:HyperLink ID="HyperLink11" CssClass="LiCon listing" runat="server" Text="Agreement" NavigateUrl="~/Admin/EBAd_AgreementGS.aspx"></asp:HyperLink> </li>
    <li id="li5" runat="server"> <asp:HyperLink ID="HyperLink5" CssClass="LiCon listing" runat="server" Text="Dashboard" NavigateUrl="~/Admin/EBAd_DashboardGSP.aspx"></asp:HyperLink> </li>
    <li id="li6" runat="server"> <asp:HyperLink ID="HyperLink6" CssClass="LiCon listing" runat="server" Text="Info" NavigateUrl="~/Admin/EBAd_InfoFranchiseGSP.aspx"></asp:HyperLink> </li>
    <li id="li7" runat="server"> <asp:HyperLink ID="HyperLink7" CssClass="LiCon listing" runat="server" Text="EBooks" NavigateUrl="~/Admin/EBAd_BookListingAdminFranchiseGSP.aspx"></asp:HyperLink> </li>
    <li id="li8" runat="server"> <asp:HyperLink ID="HyperLink8" CssClass="LiCon listing" runat="server" Text="Category" NavigateUrl="~/Admin/EBAd_eStoreAdminCatsFranchiseGSP.aspx"></asp:HyperLink> </li>
    <li id="li9" runat="server"> <asp:HyperLink ID="HyperLink9" CssClass="LiCon listing" runat="server" Text="SubCategory" NavigateUrl="~/Admin/EBAd_eStoreAdminSubCatsFranchiseALL.aspx"></asp:HyperLink> </li>
    


</ul>

</div>

