<%@ Page Language="C#" MasterPageFile="~/N_MasterDummy.master" AutoEventWireup="true" CodeFile="N_MainDummy.aspx.cs" Inherits="N_MainDummy" %>
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
                    <%--<div class="contact-us home-border" >--%>
                    <div class="contact-us home-border" >
                        <%--<h2 class="main-title-home">Contact Us</h2>--%>
                        <h2 class="main-title">Contact Us</h2>
                        <%--<span class="list-group-item active"><span class="navbar navbar-default">Contact Us</span></span>--%>
                        <div class="m-b-30"></div>
                        <div class="contact">
                            <div class="contact-image" runat="server" id="dvSideContactImg">
                                <img src="AssetsNew/img/contact-image.jpg" alt="contact-image" id="ImgContact" runat="server" name="ImgContact" height="200" width="200" >
                                 
                            </div>
                            <div class="detail-person text-center" runat="server" id="dvContactDetails">
                                <%--<p class="name-person"> <i class="fa fa-user" aria-hidden="true"></i> <asp:Literal ID="ltrNickName" Text="" runat="server"></asp:Literal></p>
                                <p> <i class="fa fa-envelope" aria-hidden="true"></i> <asp:Literal ID="LtrContactUs_Email" Text="" runat="server"></asp:Literal></p>
                                <p> <i class="fa fa-user" aria-hidden="true"></i> <asp:Literal ID="LtrContactUs_HandPhone" Text="" runat="server"></asp:Literal></p>
                                <p> <i class="fa fa-user" aria-hidden="true"></i> <asp:Literal ID="LtrContactUs_Fax" Text="" runat="server"></asp:Literal></p>
                                <p> <i class="fa fa-user" aria-hidden="true"></i> <asp:Literal ID="ltrCompanyName" Text="" runat="server"></asp:Literal></p>--%>
                                <asp:Literal ID="ltrCompanyName" Text="" runat="server"></asp:Literal>
                                <asp:Literal ID="LtrContactUs_Email" Text="" runat="server"></asp:Literal>
                                <asp:Literal ID="LtrContactUs_HandPhone" Text="" runat="server"></asp:Literal>
                                <%--<asp:Literal ID="LtrContactUs_Fax" Text="" runat="server"></asp:Literal>--%>
                                <%--<br /><asp:Literal ID="ltrCompanyName" Text="" runat="server"></asp:Literal>--%>
                            </div>
                        </div>
                    </div>
                    <div class="promo-image home-border">
                        <img src="Images/ebImages/eBSideBanner.jpg" alt="promo-image">
                    </div>
                </div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>