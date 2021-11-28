<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_ebButtons.ascx.cs" Inherits="EBLeftMenu_ebButtons" %>
<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Feature-Buy"></asp:Literal> </span></li>
<li id="li_AddNew" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="Add Feature-Buy " NavigateUrl="~/Admin/EBAd_FeatureBuyADD2.aspx"></asp:HyperLink> </li>
<li id="li_Listing" runat="server"> <asp:HyperLink ID="HypListing" CssClass="LiCon listing" runat="server" Text="View Feature-Buy " NavigateUrl="~/Admin/EBAd_FeatureBuy.aspx"></asp:HyperLink> </li>


<li>&nbsp;</li>   
<li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal1" runat="server" Text="Best-Seller"></asp:Literal> </span></li>
<li id="li1" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="Add Best-Seller " NavigateUrl="~/Admin/EBAd_BestSellerADD2.aspx"></asp:HyperLink> </li>
<li id="li2" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon listing" runat="server" Text="View Best-Seller " NavigateUrl="~/Admin/EBAd_BestSeller.aspx"></asp:HyperLink> </li>


    
<li>&nbsp;</li>   
<li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal4" runat="server" Text="New-Releases"></asp:Literal> </span></li>
<li id="li5" runat="server"> <asp:HyperLink ID="HyperLink5" CssClass="LiCon add" runat="server" Text="Add New-Release " NavigateUrl="~/Admin/EBAd_NewReleaseADD.aspx" ></asp:HyperLink> </li>
<li id="li6" runat="server"> <asp:HyperLink ID="HyperLink6" CssClass="LiCon listing" runat="server" Text="View New-Release " NavigateUrl="~/Admin/EBAd_NewReleases.aspx" ></asp:HyperLink> </li>



<%--<li>&nbsp;</li> 
<li><span class="subheader"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal3" runat="server" Text="Value-Buy"></asp:Literal> </span></li>
<li id="li3" runat="server"> <asp:HyperLink ID="HypAddNew" CssClass="LiCon add" runat="server" Text="Add Value-Buy " NavigateUrl="~/Admin/EBAd_ValueBuyADD.aspx"></asp:HyperLink> </li>
<li id="li4" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon listing" runat="server" Text="View Value-Buy " NavigateUrl="~/Admin/EBAd_ValueBuyList.aspx"></asp:HyperLink> </li>--%>
<%--<li id="li_AdminListing" runat="server"> <asp:HyperLink ID="HypAdmListing" CssClass="LiCon listing" runat="server" Text="Admin Value-Buy eBooks" NavigateUrl="~/Admin/EBAd_ValueBuyList.aspx?qUserType=ADMIN"></asp:HyperLink> </li>--%>

<li>&nbsp;</li> 
<li><span class="header"><img src="../Images/WebPortal/Products.png" /><asp:Literal ID="Literal5" runat="server" Text="Free"></asp:Literal> </span></li>
<li id="li7" runat="server"> <asp:HyperLink ID="HypAdd" CssClass="LiCon add" runat="server" Text="Add Product" NavigateUrl="~/Admin/EBAd_FreeEbookADD.aspx"></asp:HyperLink> </li>
<li id="li8" runat="server"> <asp:HyperLink ID="HyperLink7" CssClass="LiCon listing" runat="server" Text="View Products" NavigateUrl="~/Admin/EBAd_FreeEbooks.aspx"></asp:HyperLink> </li>

</ul>
</div>