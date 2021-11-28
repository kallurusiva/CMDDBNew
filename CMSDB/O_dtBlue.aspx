<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtBlue.aspx.cs" Inherits="O_dtBlue" %>
<%@ Register Src="~/O_FooterBlue.ascx" TagPrefix="uc1" TagName="O_FooterBlue" %>
<%@ Register Src="~/O_LeftBlue.ascx" TagPrefix="uc1" TagName="O_LeftBlue" %>
<%@ Register Src="~/O_topBlue.ascx" TagPrefix="uc1" TagName="O_topBlue" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" Runat="Server">
    <uc1:O_topBlue runat="server" ID="O_topBlue" />
     </asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

        <div class="main">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-9 col-md-push-3">
                        <div class="banner-top-container">
                            <div class="row">
                                <div class="slider-col">
                                    <div class="banner-top-slider swiper-container">
                                        <div class="swiper-wrapper">
                                            <div class="swiper-slide banner v5" runat="server" id="dvSlide1">
                                                <asp:HyperLink ID ="imgSlide1" runat="server" CssClass="banner-bg"></asp:HyperLink>
                                                <%--<asp:Image ID="imgSlide1" runat="server" CssClass="banner-bg" ImageUrl=""  />
                                                <img src="assets/images/homesliders/slide1.jpg" class="banner-bg" alt="Banner">--%>
                                            </div>
                                            <div class="swiper-slide banner v5" runat="server" id="dvSlide2">
                                                <asp:HyperLink ID ="imgSlide2" runat="server" CssClass="banner-bg"></asp:HyperLink>
                                                <%--<asp:Image ID="imgSlide2" runat="server" CssClass="banner-bg" ImageUrl="" />
                                                <img src="assets/images/homesliders/slide2.jpg" class="banner-bg" alt="Banner">--%>
                                                <%--<div class="banner-content right banner-contentbg">
                                                </div>--%>
                                            </div>
                                            <div class="swiper-slide banner v5" runat="server" id="dvSlide3">
                                                <asp:HyperLink ID ="imgSlide3" runat="server" CssClass="banner-bg"></asp:HyperLink>
                                                <%--<asp:Image ID="imgSlide3" runat="server" CssClass="banner-bg" ImageUrl="" />
                                                <img src="assets/images/homesliders/slide3.jpg" class="banner-bg" alt="Banner">--%>
                                            </div>
                                        </div>
                                        <div class="swiper-pagination"></div>
                                    </div>
                                </div>
                                <div class="banner-col">
                                    <div class="banner v5">
                                        <asp:HyperLink ID ="imgBanner1" runat="server" CssClass="banner-bg"></asp:HyperLink>
                                        <%--<a href="#">
                                            <asp:Image ID="imgBanner1" runat="server" CssClass="banner-bg" ImageUrl="assets/images/banners/banner1.jpg"  />
                                            <img src="assets/images/banners/banner1.jpg" alt="Banner">
                                        </a>--%>
                                    </div>
                                    <div class="banner v5">
                                        <asp:HyperLink ID ="imgBanner2" runat="server" CssClass="banner-bg"></asp:HyperLink>
                                        <%--<a href="#">
                                            <asp:Image ID="imgBanner2" runat="server" CssClass="banner-bg" ImageUrl="assets/images/banners/banner2.jpg" />
                                            <%--<img src="assets/images/banners/banner2.jpg" alt="Banner">
                                        </a>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mb50 mb30-sm mb20-xs"></div>

                        <div class="products-tab-container smaller" role="tabpanel" runat="server" id="dvFeatureProduct">
                            <h2>Feature Product</h2>
                            <div class="row product-container-row" >
                                <div class="products-container max-col-4" data-layoutmode="fitRows" id="dvProduct" runat="server">

                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product6.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 2</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$30.00</span></div>
                                            <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a>
                                           </div>
                                        </div>
                                    </div>--%>
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product7.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 7</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$99.00</span></div>
                                            <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a>
                                            </div>
                                        </div>
                                    </div>--%>
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product8.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 7</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$99.00</span></div>
                                            <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a>
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                        <div class="products-tab-container smaller" role="tabpanel" runat="server" id="dvBestSellerProduct">
                            <h2>Best Seller</h2>
                            <div class="row product-container-row">
                                <div class="products-container max-col-4" data-layoutmode="fitRows" id="dvBestSeller" runat="server">
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product1.jpg" height="150" width="100" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 3</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$130.00</span></div>
                                            <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a></div>
                                        </div>
                                    </div>--%>
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product2.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 6</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$70.00</span></div>
                                            <div class="product-action"><a href="#" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a></div>
                                        </div>
                                    </div>--%>
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product3.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 2</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$30.00</span></div>
                                            <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a></div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>


                         <div class="products-tab-container smaller" role="tabpanel" runat="server" id="dvNewReleaseProduct">
                            <h2>New Releases</h2>
                            <div class="row product-container-row">
                                <div class="products-container max-col-4" data-layoutmode="fitRows" id="dvNewRelease" runat="server">
                                </div>
                            </div>
                        </div>

                        <div class="products-tab-container smaller" role="tabpanel" runat="server" id="dvFreeProduct">
                            <h2>Free</h2>
                            <div class="row product-container-row">
                                <div class="products-container max-col-4" data-layoutmode="fitRows" id="dvFree" runat="server">
                                </div>
                            </div>
                        </div>

                        <div class="products-tab-container smaller" role="tabpanel" runat="server" id="dvValueBuyProduct">
                            <h2>Value Buy</h2>
                            <div id="hValueBuy" runat="server"></div>
                            <div class="row product-container-row">
                                <div class="products-container max-col-4" data-layoutmode="fitRows" id="dvBalueBuy" runat="server">
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product1.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 3</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$130.00</span></div>
                                            <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a></div>
                                        </div>
                                    </div>--%>
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product2.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 6</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$70.00</span></div>
                                            <div class="product-action"><a href="#" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a></div>
                                        </div>
                                    </div>--%>
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product3.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 2</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$30.00</span></div>
                                            <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a></div>
                                        </div>
                                    </div>--%>
                                    <%--<div class="product-column">
                                        <div class="product product5">
                                            <div class="product-top">
                                                <figure>
                                                    <a href="product_detail.html"><img src="assets/images/products/index5/product3.jpg" alt="Product Image"></a>
                                                </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                            <div class="product-meta">
                                                <div class="product-brand"><a href="product_list.html">Book 2</a></div>
                                            </div>
                                            <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                            <div class="product-price-container"><span class="product-price">$30.00</span></div>
                                            <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a></div>
                                        </div>
                                    </div>--%>

                                </div>
                            </div>
                        </div>
                        <div class="mb45 visible-lg"></div>


                    </div>
                    <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>
            <div class="mb170 mb50-sm"></div>
        </div>
        </div>
        <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
       
</asp:Content>
        