<%@ Page Language="C#"  MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_ValueBuyshowDetails.aspx.cs" Inherits="N_ValueBuyshowDetails" %>
<%@ Register Src="~/N_Footer.ascx" TagPrefix="uc1" TagName="N_Footer" %>
<%@ Register Src="~/N_LeftMenu.ascx" TagPrefix="uc1" TagName="N_LeftMenu" %>
<%@ Register Src="~/N_TopMenu.ascx" TagPrefix="uc1" TagName="N_TopMenu" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:N_TopMenu runat="server" ID="N_TopMenu" />
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

    <uc1:N_LeftMenu runat="server" ID="N_LeftMenu" />

   

    <div class="col-xs-9 content-middle">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="cart">
                                <div class="itembox">
                                    <div class="itemcart">
                                        <i class="fa fa-shopping-cart" aria-hidden="true"></i> <span id="value-item" class="value-item"><asp:Literal runat="server" ID="cartItems" Text="0"></asp:Literal></span>Item(s)
                                    </div>
                                    <div class="priceitem">
                                        <i class="fa fa-money" aria-hidden="true"></i> <asp:Literal runat="server" ID="cartCurrency" Text="0"></asp:Literal> <span id="priceitemlist" class="value-item"><asp:Literal runat="server" ID="cartPrice" Text="0"></asp:Literal></span>
                                    </div>
                                    <div class="view-cart">
                                        <a href="N_cart.aspx">View Cart</a>
                                    </div>
                                    <div class="checkout">
                                        <a href="N_cart.aspx">Check Out</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>

                    </div>

                    <h2 class="main-title">Value Buy</h2>
                    <div class="m-b-30"></div>

                <div runat="server" id="dvRepeaterPages">                            
                <asp:Repeater ID="RepBooks" runat="server" OnItemDataBound="RepBooks_ItemDataBound" OnItemCommand="RepBooks_ItemCommand">
                    <ItemTemplate>
                <div runat="server" class="value-book-series">
                    
                    <asp:HiddenField ID="hdnBookAllowSmsBuy" Value='<%# Eval("AllowSmsBuy")%>' runat="server" />
                    <asp:HiddenField ID="hdnBookAllowPayPalBuy" Value='<%# Eval("AllowPaypalBuy")%>' runat="server" />

                    <div class="row">


                        <div class="col-xs-12 product-list">
                            <div class="row">
                                <asp:HyperLink ID="HyperLink5" NavigateUrl='<%# Eval("BookID","~/N_ValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                <h3><asp:Label ID="Label4" runat="server" CssClass="VB_headFont2" Text='<%# Eval("BookID")%>'></asp:Label> :
                                            <asp:Label ID="lblHeader" runat="server" CssClass="VB_headFont1" Text='<%# Eval("BookName")%>'></asp:Label></h3>
                                </asp:HyperLink>
                                <div class="row">
                                    <div class="col-xs-4" id="divVB1" runat="server">
                                        <div class="product">
                                            <div class="product-image">
                                                    <asp:HyperLink ID="HyperLink6" NavigateUrl='<%# Eval("BookID","~/N_ValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                    <asp:Image ID="ImgEbook1" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL1")%>' runat="server" />
                                                    </asp:HyperLink>
                                            </div>
                                            <h3 class="product-title text-center">
                                        <asp:Label ID="lblBookName1" runat="server" Text='<%# Eval("BookName1")%>'></asp:Label>
                                    </h3>
                                        </div>
                                    </div>
                                    <div class="col-xs-4" id="divVB2" runat="server">
                                        <div class="product">
                                            <div class="product-image">
                                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("BookID","~/N_ValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                    <asp:Image ID="ImgEbook2" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL2")%>' runat="server" />
                                                    </asp:HyperLink>
                                            </div>
                                            <h3 class="product-title text-center">
                                        <asp:Label ID="lblBookName2" runat="server" Text='<%# Eval("BookName2")%>'></asp:Label>
                                    </h3>
                                        </div>
                                    </div>
                                    <div class="col-xs-4" id="divVB3" runat="server">
                                        <div class="product">
                                            <div class="product-image">
                                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("BookID","~/N_ValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                    <asp:Image ID="ImgEbook3" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL3")%>' runat="server" />
                                                    </asp:HyperLink>
                                            </div>
                                            <h3 class="product-title text-center">
                                        <asp:Label ID="lblBookName3" runat="server" Text='<%# Eval("BookName3")%>'></asp:Label>
                                    </h3>
                                        </div>
                                    </div>
                                    <div class="col-xs-4" id="divVB4" runat="server">
                                        <div class="product">
                                            <div class="product-image">
                                                    <asp:HyperLink ID="HyperLink3" NavigateUrl='<%# Eval("BookID","~/N_ValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                    <asp:Image ID="ImgEbook4" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL4")%>' runat="server" />
                                                    </asp:HyperLink>
                                            </div>
                                            <h3 class="product-title text-center">
                                        <asp:Label ID="lblBookName4" runat="server" Text='<%# Eval("BookName4")%>'></asp:Label>
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="col-xs-4" id="divVB5" runat="server">
                                        <div class="product">
                                            <div class="product-image">
                                                    <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("BookID","~/N_ValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                    <asp:Image ID="ImgEbook5" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL5")%>' runat="server" />
                                                    </asp:HyperLink>
                                            </div>
                                            <h3 class="product-title text-center">
                                            <asp:Label ID="lblBookName5" runat="server" Text='<%# Eval("BookName5")%>'></asp:Label>
                                            </h3>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-xs-8">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div runat="server" id="dvCtryFlags">
                                                        <asp:ImageButton runat="server" ID="flgMalaysia" ImageUrl="~/Images/flag_malaysia.gif" OnClick="flgMalaysia_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgSingapore" ImageUrl="~/Images/flag_singapore.gif" OnClick="flgSingapore_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgIndonesia" ImageUrl="~/Images/flag_indonesia.gif" OnClick="flgIndonesia_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgThailand" ImageUrl="~/Images/flag_thailand.gif" OnClick="flgThailand_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgVietnam" ImageUrl="~/Images/flag_vietnam.gif" OnClick="flgVietnam_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgPhilippines" ImageUrl="~/Images/flag_philippines.gif" OnClick="flgPhilippines_Click" Height="40px" Width="70px" />&nbsp;
                                                    </div>
                                            <div class="smspurchaselist" runat="server" id="DivPurchaseFooter">
                                                <h3><asp:Literal ID="lblPurFormat" runat="server" Text="Malaysia SMS Purchase" ></asp:Literal></h3>
                                                <p><asp:Literal ID="lblPurchaseText" runat="server" Text=""></asp:Literal></p>
                                                <p><asp:Literal ID="Literal12" runat="server" Text="SEND to 36247"></asp:Literal> </p>
                                                <small><asp:Literal ID="lblPurchaseNote" runat="server" Text="SEND to 36247"></asp:Literal></small>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="social-icons colored" runat="server">
                                             <%--<a href="#" id="hfFaceBook" runat="server" class="social-icon icon facebook" title="Facebook" target="_blank"><span class="sr-only">Facebook</span></a>--%>
                                             <asp:HyperLink runat="server" ID="hfFaceBook" ImageUrl="~/Images/Mobile/facebook.png" Target="_blank" ></asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hfTwitter" ImageUrl="~/Images/Mobile/Twitter.png" Target="_blank"></asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hfGooglePlus" ImageUrl="~/Images/Mobile/googleplus.png" Target="_blank"></asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hfLinkedIn" ImageUrl="~/Images/Mobile/linkedin.png" Target="_blank"></asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hfPinterest" ImageUrl="~/Images/Mobile/pinterest.png" Target="_blank"></asp:HyperLink>                                           
                                        </div>
                                </div>
                                <div class="col-xs-4" id="dvEbDetails">
                                    <table class="table-fill">
                                        <thead>
                                            <tr>
                                                <th class="text-left">Product Code</th>
                                                <th class="text-left"><asp:Label ID="lblBookID" runat="server" Text='<%# Eval("BookID")%>'></asp:Label></th>
                                            </tr>
                                        </thead>
                                        <tbody class="table-hover">
                                            <tr>
                                                <td class="text-left">Product Name:</td>
                                                <td class="text-left"><asp:Label ID="lblBookName" runat="server" Text='<%# Eval("BookNAme")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">No. of Books:</td>
                                                <td class="text-left"><asp:Label ID="lblCategory" runat="server" Text='<%# Eval("BooksCount")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">Date Created:</td>
                                                <td class="text-left"><asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateCreated","{0:MMMM d, yyyy}")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">Original Price:</td>
                                                <td class="text-left"><asp:Label ID="Label7" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                  <asp:Label ID="lblOrgPrice" runat="server" Text='<%# Eval("Price", "{0:0.00}")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">After Discount:</td>
                                                <td class="text-left"><asp:Label ID="Label8" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                  <asp:Label ID="lblAfterDiscount" runat="server" Text='<%# Eval("DiscountedPrice", "{0:0.00}")%>'></asp:Label></td>
                                            </tr>
                                            <%--<tr>
                                                <td class="text-left">Prepaid Price:</td>
                                                <td class="text-left"><asp:Label ID="lblPrepaidPrice" runat="server" Text='<%# Eval("PrepaidPrice")%>'></asp:Label></td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                    <div class="button-action">
                                        <%--<a href="cart.html"><button type="button" class="button -blue center"><i class="fa fa-cart-plus" aria-hidden="true"></i> Add to cart</button></a>
                                        <a href="cart.html"><button type="button" class="button -sun center"><i class="fa fa-plus" aria-hidden="true"></i> Buy Now</button></a>--%>
                                        <asp:LinkButton ID="lnkAddtoCart" class="button -blue center" Visible="false" Text="Add To Card" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") %>' runat="server">
                                                <i class="fa fa-cart-plus"></i><span>Add To Cart</span>  
                                                </asp:LinkButton>
                                        <asp:LinkButton ID="LnkPayPalBuy" class="button -sun center" Visible="false" Text="Buy Now" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") %>' runat="server">
                                                <i class="fa fa-plus"></i><span>Buy Now</span> 
                                                </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                   
                </div>
                        </ItemTemplate>
                                </asp:Repeater>                        
                    </div>
    </div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>