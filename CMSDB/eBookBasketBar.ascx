<%@ Control Language="C#" AutoEventWireup="true" CodeFile="eBookBasketBar.ascx.cs" Inherits="eBookBasketBar" %>
<div id="dvBasketBar" class="CartBox">
    <asp:Image ID="ImgCart" ImageUrl="~/Images/ebImages/cart/shopping-cart-icon.png" CssClass="imgCart" runat="server" />
     &nbsp;  &nbsp; 
    <asp:Label ID="lblItemCount" CssClass="fontItemCount" runat="server" Text="0"></asp:Label>&nbsp;
    <asp:Label ID="lblItems" CssClass="fontCart" runat="server" Text="Item(s)"></asp:Label>
    &nbsp; | &nbsp;
    <asp:Label ID="lblCurrency" CssClass="fontCart" runat="server" Text=""></asp:Label>&nbsp;
    <asp:Label ID="lblTotalAmount" CssClass="fontItemCount" runat="server" Text="0.00"></asp:Label>
    &nbsp; | &nbsp;
    <asp:HyperLink ID="HypViewCart" CssClass="links_Cart" NavigateUrl="~/eBooksViewCart.aspx" runat="server">View Cart</asp:HyperLink>
    &nbsp; | &nbsp;
    <asp:HyperLink ID="HypCheckOut" CssClass="links_Cart" runat="server">Check Out</asp:HyperLink>
    &nbsp;  &nbsp; 
    <asp:Image ID="Image1" ImageUrl="~/Images/ebImages/cart/paypalcart.png" CssClass="imgPayPal" runat="server" />
     &nbsp;  &nbsp; 

</div>
