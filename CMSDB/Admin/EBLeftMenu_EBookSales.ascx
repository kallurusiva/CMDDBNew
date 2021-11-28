<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_EBookSales.ascx.cs" Inherits="Admin_EBLeftMenu_EBookSales" %>
<div id='leftmenu'>
<ul>

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal2" runat="server" Text="Sales Transaction"></asp:Literal> </span></li>

<li id="li6" runat="server"> <asp:HyperLink ID="HyperLink6" CssClass="LiCon add" runat="server" Text="EBook Sales Dashboard" NavigateUrl="EbAd_EBookSales_Dashboard.aspx"></asp:HyperLink> </li> 
<li id="li1" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="MWallet Sales" NavigateUrl="EBAd_BookCodesNew.aspx"></asp:HyperLink> </li>  
<li id="li3" runat="server"> <asp:HyperLink ID="HyperLink3" CssClass="LiCon add" runat="server" Text="Credit Card Sales" NavigateUrl="EBAd_PayPalTXs.aspx"></asp:HyperLink> </li>
<li id="li5" runat="server"> <asp:HyperLink ID="HyperLink5" CssClass="LiCon add" runat="server" Text="Online Banking Sales" NavigateUrl="EBAd_onlinebanking.aspx"></asp:HyperLink> </li>
<li id="li2" runat="server"> <asp:HyperLink ID="HyperLink1" CssClass="LiCon add" runat="server" Text="Free Sales - SMS" NavigateUrl="EBAd_BookCodesFree.aspx"></asp:HyperLink> </li> 
<li id="li17" runat="server"> <asp:HyperLink ID="HyperLink17" CssClass="LiCon add" runat="server" Text="Free Sales - Telegram" NavigateUrl="EBAd_BookCodes_FreeSys.aspx"></asp:HyperLink> </li> 
<li id="li19" runat="server"> <asp:HyperLink ID="HyperLink19" CssClass="LiCon add" runat="server" Text="Last 30 Days OA" NavigateUrl="EBAd_BookCodesOA.aspx"></asp:HyperLink> </li> 

<br />

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal5" runat="server" Text="Author Birthday"></asp:Literal> </span></li>
<li id="li10" runat="server"> <asp:HyperLink ID="HyperLink10" CssClass="LiCon add" runat="server" Text="Birthday List - Today" NavigateUrl="EBAd_birthdaybookslist.aspx"></asp:HyperLink> </li>
<%--<li id="li11" runat="server"> <asp:HyperLink ID="HyperLink11" CssClass="LiCon add" runat="server" Text="Birthday List - Tomorrow" NavigateUrl="EBAd_birthdaybookslistTomaro.aspx"></asp:HyperLink> </li>--%>
    <li id="li13" runat="server"> <asp:HyperLink ID="HyperLink13" CssClass="LiCon add" runat="server" Text="Birthday List - Next 50" NavigateUrl="EBAd_birthdaybookslistNext.aspx"></asp:HyperLink> </li>
<%--<li id="li13" runat="server"> <asp:HyperLink ID="HyperLink13" CssClass="LiCon add" runat="server" Text="Birthday List - Yesterday" NavigateUrl="EBAd_birthdaybookslistYesterday.aspx"></asp:HyperLink> </li>--%>
    <li id="li18" runat="server"> <asp:HyperLink ID="HyperLink18" CssClass="LiCon add" runat="server" Text="Birthday List - This Month" NavigateUrl="EBAd_birthdaymonthlist.aspx"></asp:HyperLink> </li>
<li id="li15" runat="server"> <asp:HyperLink ID="HyperLink15" CssClass="LiCon add" runat="server" Text="Birthday Purchase History" NavigateUrl="EBAd_BookCodesGiftPurchases.aspx"></asp:HyperLink> </li>    
<li id="li14" runat="server"> <asp:HyperLink ID="HyperLink14" CssClass="LiCon add" runat="server" Text="Your Birthday Gift List" NavigateUrl="EBAd_BookCodesGift.aspx"></asp:HyperLink> </li>

<br />

<%--<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal6" runat="server" Text="Top Sales Referral"></asp:Literal> </span></li>
<li id="li16" runat="server"> <asp:HyperLink ID="HyperLink16" CssClass="LiCon add" runat="server" Text="Best Seller EBook" NavigateUrl="~/Admin/EbAd_topbestsellerbooks.aspx"></asp:HyperLink> </li>
<li id="li17" runat="server"> <asp:HyperLink ID="HyperLink17" CssClass="LiCon add" runat="server" Text="Top Referral" NavigateUrl="~/Admin/EbAd_topReferral.aspx"></asp:HyperLink> </li>
    <li id="li11" runat="server"> <asp:HyperLink ID="HyperLink11" CssClass="LiCon add" runat="server" Text="Top MWallet Purchase" NavigateUrl="~/Admin/EbAd_topbestsellerbooks_Mwallet.aspx"></asp:HyperLink> </li>--%>

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal6" runat="server" Text="Star Rating"></asp:Literal> </span></li>
<li id="li16" runat="server"> <asp:HyperLink ID="HyperLink16" CssClass="LiCon add" runat="server" Text="Star Rating - Current" NavigateUrl="~/Admin/EBAd_StarRating_CurrentMonth.aspx"></asp:HyperLink> </li>
<%--<li id="li4" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon add" runat="server" Text="Top Referral" NavigateUrl="~/Admin/EBAd_StarRating_previousMonth.aspx"></asp:HyperLink> </li>--%>
<li id="li11" runat="server"> <asp:HyperLink ID="HyperLink11" CssClass="LiCon add" runat="server" Text="Accumulated Star Rating" NavigateUrl="~/Admin/EBAd_StarRating_Accumulated.aspx"></asp:HyperLink> </li>
    <li id="li4" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon add" runat="server" Text="Your AdminBooks" NavigateUrl="~/Admin/EBAd_StarRating_YourAdminBooks.aspx"></asp:HyperLink> </li>

<br />

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal4" runat="server" Text="Admin EBook"></asp:Literal> </span></li>
<li id="li12" runat="server"> <asp:HyperLink ID="HyperLink12" CssClass="LiCon add" runat="server" Text="New Admin EBook" NavigateUrl="EBAd_BookListingAdminNew.aspx"></asp:HyperLink> </li>
<li id="li9" runat="server"> <asp:HyperLink ID="HyperLink9" CssClass="LiCon add" runat="server" Text="Admin EBook Updates" NavigateUrl="EBAd_BookUpdateHistory.aspx"></asp:HyperLink> </li>



  <%--  <br />

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal1" runat="server" Text="EBook Database"></asp:Literal> </span></li>
<li id="li4" runat="server"> <asp:HyperLink ID="HyperLink4" CssClass="LiCon add" runat="server" Text="Database List" NavigateUrl="~/Admin/SMS/EBAd_EBook_CreateList_BookCode.aspx"></asp:HyperLink> </li>
--%>

    <br />

<li><span class="header"><img src="../Images/WebPortal/Info.png" /><asp:Literal ID="Literal3" runat="server" Text="Physical Books"></asp:Literal> </span></li>
<li id="li7" runat="server"> <asp:HyperLink ID="HyperLink7" CssClass="LiCon add" runat="server" Text="Order here" NavigateUrl="EBAd_PhysicalBookPurchase.aspx"></asp:HyperLink> </li>
<li id="li8" runat="server"> <asp:HyperLink ID="HyperLink8" CssClass="LiCon add" runat="server" Text="History" NavigateUrl="EBAd_PhysicalBooksHistory.aspx"></asp:HyperLink> </li>


</ul>
</div>


