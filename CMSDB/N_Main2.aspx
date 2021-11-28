<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_Main2.aspx.cs" Inherits="N_Main2" %>
<%@ Register Src="~/N_Footer.ascx" TagPrefix="uc1" TagName="N_Footer" %>
<%@ Register Src="~/N_LeftMenu.ascx" TagPrefix="uc1" TagName="N_LeftMenu" %>
<%@ Register Src="~/N_TopMenu.ascx" TagPrefix="uc1" TagName="N_TopMenu" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 441px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:N_TopMenu runat="server" ID="N_TopMenu" />
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

    <uc1:N_LeftMenu runat="server" ID="N_LeftMenu" />

<script>
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.0";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));

</script>

    <div class="col-xs-7 content-middle">

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

                    <div class="home-border" runat="server" id="dvHome">                        
                            <h2 class="main-title-home">Welcome</h2>
                            <div class="row" id="dvHomeInner" runat="server">
                                <div class="col-xs-4">
                                    <asp:Image ID="ImgWpPhoto" ImageUrl="~/DocumentRepository/eBookImages/executiveCC.png" runat="server" height="100" width="100" />
                                    
                                </div>
                                <div id="dvW_WelcomePageText" style="float: left; padding-left: 30px;">
                                    <asp:Label ID="lblWp_WelcomePageText" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                    </div>

                    <%--<div class="row" runat="server" id="dvFeatureProduct"  style="border: 2px solid #eeeeee">--%>
                    <div class="home-border" runat="server" id="dvFeatureProduct">
                        <h2 class="main-title-home">Feature Buy</h2>
                        <%--<span class="list-group-item active"><span class="navbar navbar-default">Feature Buy</span></span>--%>
                        <%--<div class="m-b-30"></div>--%>
                        <div class="row" id="dvProduct" runat="server">
                        </div>
                    </div>
                    
                    <div class="home-border" runat="server" id="dvBestSellerProduct">
                         <h2 class="main-title-home">Best Seller</h2>
                        <%--<span class="list-group-item active"><span class="navbar navbar-default">Best Seller</span></span>--%>
                        <%--<div class="m-b-30"></div>--%>
                        <div class="row" id="dvBestSeller" runat="server">
                        </div>
                    </div>

                    <div class="home-border" runat="server" id="dvNewReleaseProduct">
                         <h2 class="main-title-home">New Releases</h2>
                        <%--<span class="list-group-item active"><span class="navbar navbar-default">New Releases</span></span>--%>
                        <%--<div class="m-b-30"></div>--%>
                        <div class="row" id="dvNewRelease" runat="server">
                        </div>
                    </div>

                    <div class="home-border" runat="server" id="dvFreeProduct">
                         <h2 class="main-title-home">Free</h2>
                        <%--<span class="list-group-item active"><span class="navbar navbar-default">Free</span></span>--%>
                        <%--<div class="m-b-30"></div>--%>
                        <div class="row" id="dvFree" runat="server">
                        </div>
                    </div>

                    <div class="home-border" runat="server" id="dvValueBuyProduct">
                         <h2 class="main-title-home">Value Buy</h2>
                        <%--<span class="list-group-item active"><span class="navbar navbar-default">Value Buy</span></span>--%>
                        <div id="hValueBuy" runat="server"></div>
                        <%--<div class="m-b-30"></div>--%>
                        <div class="row" id="dvBalueBuy" runat="server">
                        </div>
                    </div>
    </div>

    <div class="col-xs-2 right-contact">
                    <div class="contact-us home-border" >
                        <h2 class="main-title">Contact Us</h2>
                        <div class="m-b-30"></div>
                        <div class="contact" id="dvContactDetails" runat="server">
                        </div>
                    </div>
                    <div class="promo-image home-border">
                        <img src="Images/ebImages/eBSideBanner.jpg" alt="promo-image">
                    </div>
                </div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>