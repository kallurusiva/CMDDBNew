<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtShowDetailsTest.aspx.cs" Inherits="O_dtShowDetailsTest" %>
<%@ Register Src="~/O_FooterBlue.ascx" TagPrefix="uc1" TagName="O_FooterBlue" %>
<%@ Register Src="~/O_LeftBlue.ascx" TagPrefix="uc1" TagName="O_LeftBlue" %>
<%@ Register Src="~/O_topBlue.ascx" TagPrefix="uc1" TagName="O_topBlue" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:O_topBlue runat="server" ID="O_topBlue" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

    <div class="main" runat="server">
        <div class="container-fluid" runat="server">
            <div class="row" runat="server">
                <div class="col-md-9 col-md-push-3" runat="server">
                    <div class="top-filter-container clearfix" runat="server" id="dvRepeaterPages">
                        <div class="row" runat="server">
                    <div class="col-lg-12 col-md-12" runat="server">
                        <div class="product-single" runat="server">
                            <div class="row" runat="server">
                                <div class="col-sm-5" runat="server">
                                    <div class="product-gallery-container" runat="server">
                                        <div class="product-zoom-wrapper" runat="server"><%--<span class="product-label discount">-25%</span>--%>
                                            <div class="product-zoom-container" runat="server"><asp:Image ID="ImgEbook" CssClass="img-responsive" Height="550" Width="400" ImageUrl="" runat="server" /></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-7" runat="server">
                                    <div class="product-details">
                                        <div class="product-brand" runat="server"><asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></div>
                                        <h2 class="product-title"><asp:Label ID="lblBookName" runat="server" Text=""></asp:Label></h2>
                                        <ul class="product-meta-list">
                                            <li><span>Availability: </span><span class="text-custom">In Stock</span></li>
                                            <li><span>Date Created: </span><asp:Label ID="lblDateAdded" runat="server" Text=""></asp:Label></li>
                                            <li><span>Product Code: </span><asp:Label ID="lblBookID" runat="server" Text=""></asp:Label></li>
                                        </ul>
                                        <div class="product-details-list" runat="server">
                                            <p><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></p>
                                        </div>


                                        <div class="product-details-box" runat="server" id="dvPriceDetails">
                                            <div class="product-price-container" runat="server"><label>You Pay:</label><span class="product-old-price"><asp:Label ID="lblOrgPrice" runat="server" Text=""></asp:Label></span> <span class="product-price"><asp:Label ID="lblAfterDiscount" runat="server" Text=""></asp:Label></span></div>

                                            <div class="product-action-wrapper" runat="server">
                                                <div class="product-action" runat="server">
                                                    <asp:LinkButton ID="LnkPayPalBuy" class="btn-add-cart custom2" Visible="false" Text="Buy Now" OnCommand="LnkPayPalBuy_Command" CommandArgument="" runat="server"> <span>Buy Now</span> </asp:LinkButton>
                                                    <asp:LinkButton ID="lnkAddtoCart" class="btn-add-cart custom4" Visible="false" Text="Add To Card" OnCommand="lnkAddtoCart_Command" CommandArgument="" runat="server"> <i class="icon icon-cart"></i><span>Add To Cart</span> </asp:LinkButton>
                                                    <asp:LinkButton ID="LnkPreview" class="btn-add-cart custom2" Visible="true" Text="Preview" OnCommand="LnkPreview_Command" CommandArgument="" runat="server" OnClientClick="document.forms[0].target ='_blank';"> <span>Preview</span> </asp:LinkButton>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="social-icons colored" runat="server">
                                             <a href="#" id="hfFaceBook" runat="server" class="social-icon icon facebook" title="Facebook" target="_blank"><span class="sr-only">Facebook</span></a>
                                             <a href="#" id="hfTwitter" runat="server" class="social-icon icon twitter" title="Twitter" target="_blank"><span class="sr-only">Twitter</span></a>
                                             <%--<a href="#" id="hfGooglePlus" runat="server" class="social-icon icon googleplus" title="GooglePlus" target="_blank"><span class="sr-only">GooglePlus</span></a>--%>
                                             <a href="#" id="hfLinkedIn" runat="server" class="social-icon icon linkedin" title="LinkedIn" target="_blank"><span class="sr-only">LinkedIn</span></a>
                                             <a href="#" id="hfPinterest" runat="server" class="social-icon icon pinterest" title="Pinterest" target="_blank"><span class="sr-only">Pinterest</span></a>
                                             <%--<a href="#" id="hfInstagram" runat="server" class="social-icon icon instagram" title="Instagram" target="_blank"><span class="sr-only">Instagram</span></a>--%>
                                             <%--<a href="#" id="hfReddit" runat="server" class="social-icon icon reddit" title="Reddit" target="_blank"><span class="sr-only">Reddit</span></a> --%>
                                             <%--<a href="#" id="htFlickr" runat="server" class="social-icon icon flickr" title="Flickr" target="_blank"><span class="sr-only">Flickr</span></a>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mb40" runat="server"></div>
                        <div class="tab-carousel-container" role="tabpanel" runat="server">
                            <%--<ul class="nav nav-pills nav-justified text-uppercase" role="tablist" runat="server">
                                <li role="presentation" class="active"><a href="product.html#tab-description" aria-controls="tab-description" role="tab" data-toggle="tab">Description</a></li>
                                <li role="presentation" ><a href="product.html#tab-details" aria-controls="tab-details" role="tab" data-toggle="tab">SMS Purchase</a></li>
                            </ul>--%>
                            <div class="tab-content" runat="server">
                                <div role="tabpanel" class="tab-pane active" id="tab-description" >
                                    <div class="product-description-section" id="dvBookDescription" runat="server">
                                        <p>Description</p>
                                    </div>
                                </div>
                                <div role="tabpanel" class="tab-pane active" id="tab-details" >
                                    <div class="product-details-section" runat="server">
                                        <div class="row row-lg" runat="server">
                                            <div class="col-md-12 text-left" runat="server">
                                                <div runat="server" id="dvglobalpurchaseLink">
                                                <%--<a href="elements-buttons.html#" class="btn btn-lg no-radius btn-border btn-custom btn-block" data-toggle="modal" data-target="#global-purchase">Global SMS Purchase  </a>--%>
                                                <%--<a href="O_dtShowCountryFormat.aspx" class="btn btn-lg no-radius btn-border btn-custom btn-block" target="_blank">Global SMS Purchase  </a>--%>
                                                    <%--<asp:HyperLink id="hyperlink1" class="btn btn-lg no-radius btn-border btn-custom btn-block" NavigateUrl="" Text="Global SMS Purchase" Target="_new" runat="server" />--%>
                                                    </div>
                                                <div runat="server" id="dvGlobalPurchase">
                                                <div id="global-purchase" class="modal fade no-padding" tabindex="-1" role="dialog" aria-labelledby="gridSystemModalLabel">
                                                    <div class="modal-dialog-lg" role="document" runat="server">
                                                        <div class="modal-content" runat="server">
                                                            <div class="modal-header" runat="server">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="gridSystemModalLabel">Global SMS Purchase </h4>
                                                            </div>
                                                            <div class="modal-body" runat="server">
                                                                <div class="row" runat="server">
                                                                    <div class="col-md-3" runat="server">
                                                                        <%--<img class="img-responsive" src="assets/images/products/index5/product2.jpg">--%>
                                                                        <asp:Image ID="pBookImage" CssClass="img-responsive" ImageUrl="" runat="server" />
                                                                    </div>
                                                                    <div class="col-md-9" runat="server">
                                                                        <div class="table-responsive" runat="server" id="dvProductAllCountries">
                                                                            <table class="table table-bordered product-list-table">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td><b>Product Code</b></td>
                                                                                        <td><asp:Literal ID="pBookID" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Product Name</b></td>
                                                                                        <td><asp:Literal ID="pBookName" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Category</b></td>
                                                                                        <td><asp:Literal ID="pBookCategory" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Date Created</b></td>
                                                                                        <td><asp:Literal ID="pBookDate" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Original Price</b></td>
                                                                                        <td><span class="text-custom4"><asp:Literal ID="pBookOrgPrice" runat="server" Text=""></asp:Literal></span></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>After Discount</b></td>
                                                                                        <td><span class="text-custom4"><asp:Literal ID="pBookDiscountPrice" runat="server" Text=""></asp:Literal></span></td>
                                                                                    </tr>
                                                                                   <%-- <tr>
                                                                                        <td><b>Prepaid Price</b></td>
                                                                                        <td><asp:Literal ID="pBookPrepaidPrice" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>--%>
                                                                                </tbody>

                                                                            </table>
                                                                        </div>
                                                                        <div class="mobile-purchase-global" runat="server">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> INDONESIA Mobile Purchase Format</p>
                                                                            <div class="code-mobile-detail" runat="server" id="dvPBookFormat">

                                                                                <h3><asp:Literal ID="pPFormat" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>
                                                                        <div class="mobile-purchase-global" runat="server" id="dvPBookFormat1">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> SINGAPORE SMS Purchase</p>
                                                                            <div class="code-mobile-detail" runat="server">

                                                                                <h3><asp:Literal ID="pPFormat1" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo1" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat1" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>
                                                                        <div class="mobile-purchase-global" runat="server" id="dvPBookFormat2">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> Malaysia SMS Purchase</p>
                                                                            <div class="code-mobile-detail" runat="server">

                                                                                <h3><asp:Literal ID="pPFormat2" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo2" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat2" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                                <div class="mb20 mb10-sm" runat="server"></div>
                                                <div runat="server" id="dvBookPurchaseFormat"> 

                                                    <div runat="server" id="dvCtryFlags" style="text-align: center">
                                                        <asp:ImageButton runat="server" ID="flgMalaysia" ImageUrl="~/Images/flag_malaysia.gif" OnClick="flgMalaysia_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgSingapore" ImageUrl="~/Images/flag_singapore.gif" OnClick="flgSingapore_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgIndonesia" ImageUrl="~/Images/flag_indonesia.gif" OnClick="flgIndonesia_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgThailand" ImageUrl="~/Images/flag_thailand.gif" OnClick="flgThailand_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgVietnam" ImageUrl="~/Images/flag_vietnam.gif" OnClick="flgVietnam_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgPhilippines" ImageUrl="~/Images/flag_philippines.gif" OnClick="flgPhilippines_Click" Height="40px" Width="70px" />&nbsp;
                                                    </div>


                                                <div class="mobile-purchase-detail" runat="server" id="tblPurchase">
                                                    <p><i class="fa fa-mobile" aria-hidden="true"></i> <asp:Literal ID="Literal10" runat="server" Text="" ></asp:Literal> SMS Purchase</p>
                                                    <div class="code-mobile-detail" runat="server">
                                                        <h3><asp:Literal ID="lblPurFormat" runat="server" Text=""></asp:Literal></h3>
                                                        <p><asp:Literal ID="Literal12" runat="server" Text=""></asp:Literal></p>
                                                        <small><asp:Literal ID="lblPurchaseNote" runat="server" Text=""></asp:Literal></small>
                                                    </div>
                                                </div>

                                                <div class="mobile-purchase-detail" visible="false" runat="server" id="tblFreeEbooksPurchase">
                                                    <p><i class="fa fa-mobile" aria-hidden="true"></i> Request via SMS</p>
                                                    <div class="code-mobile-detail" runat="server">
                                                        <h3><asp:Literal ID="lblPurFormat2" runat="server" Text=""></asp:Literal></h3>
                                                        <p><asp:Literal ID="Literal14" runat="server" Text=""></asp:Literal></p>
                                                        <small><asp:Literal ID="lblPurchaseNote2" runat="server" Text=""></asp:Literal></small>
                                                    </div>
                                                </div>

                                                <div class="mobile-purchase-detail" runat="server" id="tblTelegramFree">
                                                    <p><i class="fa fa-mobile" aria-hidden="true"></i> Request via Telegram</p>
                                                    <div class="code-mobile-detail" runat="server">
                                                        <h3><asp:Literal ID="Literal2" runat="server" Text="1. Step 1 – Register Telegram Apps"></asp:Literal></h3>
                                                        <p><asp:Literal ID="Literal3" runat="server" Text="Step 2 – Register FREE-Ebook Bot – Link Below"></asp:Literal></p>
                                                        <asp:HyperLink ID="hypTelFree" runat="server" NavigateUrl="https://telegram.me/ebookfreesys_bot" Target="_blank">
                                                        <small><asp:Literal ID="Literal4" runat="server" Text="https://telegram.me/ebookfreesys_bot"></asp:Literal></small>
                                                        </asp:HyperLink>
                                                    </div>
                                                </div>

                                                <div class="mobile-purchase-detail" visible="false" runat="server" id="tblComingSoon">
                                                    <p><i class="fa fa-mobile" aria-hidden="true"></i> <asp:Literal ID="Literal1" runat="server" Text="" ></asp:Literal> SMS Purchase</p>
                                                    <div class="code-mobile-detail" runat="server">
                                                        <h3>Coming Soon</h3>
                                                    </div>
                                                </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mb90 mb60-sm" runat="server"></div>
                        <%--<div class="carousel-overflow-container row" runat="server">
                            <div class="col-xs-12" runat="server">
                                <div class="swiper-container product-small-carousel" runat="server">
                                    <div class="carousel-header">
                                        <h2 class="carousel-title text-center">RELATED PRODUCTS</h2>
                                        <div class="swiper-nav-wrapper" runat="server">
                                            <div class="swiper-button-prev icon"></div>
                                            <div class="swiper-button-next icon"></div>
                                        </div>
                                    </div>
                                    <div class="swiper-wrapper" runat="server">
                                        <div class="swiper-slide" runat="server">
                                            <div class="product product1" runat="server">
                                                <div class="product-top" runat="server">
                                                    <figure>
                                                        <a href="product_detail.html"><img src="assets/images/products/index5/product1.jpg" alt="Product Image"></a>
                                                    </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a>
                                                </div>
                                                <div class="product-meta" runat="server">
                                                    <div class="product-brand" runat="server"><a href="product_detail.html">Samsung</a></div>
                                                    <div class="ratings-container" runat="server">
                                                        <div class="ratings" style="width:60%" runat="server"></div>
                                                    </div>
                                                </div>
                                                <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                                <div class="product-price-container" runat="server"><span class="product-old-price">$120.00</span> <span class="product-price">$60.00</span></div>
                                                <div class="product-action" runat="server"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a></div>
                                            </div>
                                        </div>
                                        <div class="swiper-slide" runat="server">
                                            <div class="product product1" runat="server">
                                                <div class="product-top" runat="server">
                                                    <figure>
                                                        <a href="product_detail.html"><img src="assets/images/products/index5/product3.jpg" alt="Product Image"></a>
                                                    </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                                <div class="product-meta" runat="server">
                                                    <div class="product-brand" runat="server"><a href="product_list.html">HP PAVILION</a></div>
                                                    <div class="ratings-container" runat="server">
                                                        <div class="ratings" style="width:80%"></div>
                                                    </div>
                                                </div>
                                                <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                                <div class="product-price-container"><span class="product-old-price">$80.00</span> <span class="product-price">$40.00</span></div>
                                                <div class="product-action"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a> </div>
                                            </div>
                                        </div>
                                        <div class="swiper-slide" runat="server">
                                            <div class="product product1" runat="server">
                                                <div class="product-top" runat="server">
                                                    <figure>
                                                        <a href="product_detail.html"><img src="assets/images/products/index5/product5.jpg" alt="Product Image"></a>
                                                    </figure><a href="product_detail.html" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                                <div class="product-meta" runat="server">
                                                    <div class="product-brand" runat="server"><a href="product_list.html">Dell Latitude</a></div>
                                                    <div class="ratings-container" runat="server">
                                                        <div class="ratings" style="width:0"></div>
                                                    </div>
                                                </div>
                                                <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                                <div class="product-price-container"><span class="product-price">$130.00</span></div>

                                                <div class="product-action" runat="server"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a> </div>
                                            </div>
                                        </div>

                                        <div class="swiper-slide" runat="server">
                                            <div class="product product1" runat="server">
                                                <div class="product-top" runat="server">
                                                    <figure>
                                                        <a href="product_detail.html"><img src="assets/images/products/index5/product6.jpg" alt="Product Image"></a>
                                                    </figure><a href="product.html#" class="btn-quickview icon" title="View"><span class="sr-only">View</span></a></div>
                                                <div class="product-meta" runat="server">
                                                    <div class="product-brand" runat="server"><a href="product_list.html">Whynter</a></div>
                                                    <div class="ratings-container" runat="server">
                                                        <div class="ratings" style="width:100%"></div>
                                                    </div>
                                                </div>
                                                <h3 class="product-title"><a href="product_detail.html">Thanks in everything - Book from U.S</a></h3>
                                                <div class="product-price-container" runat="server"><span class="product-old-price">$30.00</span> <span class="product-price">$20.00</span></div>

                                                <div class="product-action" runat="server"><a href="cart.html" class="btn-add-cart" title="Add to Cart"><i class="icon icon-cart"></i> <span>Add To Cart</span></a> </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                        <div class="mb50 mb30-sm mb20-xs" runat="server"></div>
                    </div>

                </div>
                    </div>
                </div>
                <div class="mb30 visible-sm visible-xs clearfix" runat="server"></div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>            
        </div>
        <div class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                </span>
</asp:Content>
