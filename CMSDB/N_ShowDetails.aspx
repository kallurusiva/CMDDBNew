<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_ShowDetails.aspx.cs" Inherits="N_ShowDetails" %>
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
                        <h2 class="main-product-name"><asp:Literal ID="lblBookName" runat="server" Text=""></asp:Literal></h2>
                        <div class="m-b-30"></div>
                        <div class="row">
                            <div class="col-xs-5">
                                <div class="productimage">
                                    <div class="product-detail-image">
                                        <a href="#"><asp:Image ID="pBookImage" CssClass="img-responsive" ImageUrl="" runat="server" /></a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-7">
                                <table class="table-fill">
                                    <thead>
                                        <tr>
                                            <th class="text-left">Product Code</th>
                                            <th class="text-left"><asp:Literal ID="pBookID" runat="server" Text=""></asp:Literal></th>
                                        </tr>
                                    </thead>
                                    <tbody class="table-hover">
                                        <tr>
                                            <td class="text-left">Product Name:</td>
                                            <td class="text-left"><asp:Literal ID="pBookName" runat="server" Text=""></asp:Literal></td>
                                        </tr>
                                        <tr>
                                            <td class="text-left">Category:</td>
                                            <td class="text-left"><asp:Literal ID="pBookCategory" runat="server" Text=""></asp:Literal></td>
                                        </tr>
                                        <tr>
                                            <td class="text-left">Star Rating:</td>
                                            <td class="text-left"><asp:Literal ID="pStarRating" runat="server" Text=""></asp:Literal></td>
                                        </tr>
                                        <tr>
                                            <td class="text-left">Date Created:</td>
                                            <td class="text-left"><asp:Literal ID="pBookDate" runat="server" Text=""></asp:Literal></td>
                                        </tr>
                                        <div id="dvPriceDetails" runat="server">                                 
                                        <tr>
                                            <td class="text-left"><asp:Literal ID="Literal2" runat="server" Text="Original Price:"></asp:Literal></td>
                                            <td class="text-left"><asp:Literal ID="pBookOrgPrice" runat="server" Text=""></asp:Literal></td>
                                        </tr>                                        
                                        <tr>
                                            <td class="text-left"><asp:Literal ID="Literal3" runat="server" Text="After Discount:"></asp:Literal></td>
                                            <td class="text-left"><asp:Literal ID="pBookDiscountPrice" runat="server" Text=""></asp:Literal></td>
                                        </tr>
                                        <%--<tr>
                                            <td class="text-left"><asp:Literal ID="Literal4" runat="server" Text="Prepaid Price:"></asp:Literal></td>
                                            <td class="text-left"><asp:Literal ID="pBookPrepaidPrice" runat="server" Text=""></asp:Literal></td>
                                        </tr>--%>
                                        </div>
                                    </tbody>
                                </table>
                                <div class="button-action">
                                    
                                    <asp:LinkButton ID="lnkAddtoCart" class="button -blue center" Visible="false" Text="Add To Card" OnCommand="lnkAddtoCart_Command" CommandArgument="" runat="server">
                                                    <i class="icon icon-cart"></i><span>Add To Cart</span>  
                                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LnkPayPalBuy" class="button -sun center" Visible="false" Text="Buy Now" OnCommand="LnkPayPalBuy_Command" CommandArgument="" runat="server">
                                                    <span>Buy Now</span>  
                                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LnkPreview" class="button -green center" Visible="true" Text="Preview" OnCommand="LnkPreview_Command" CommandArgument="" runat="server" OnClientClick="document.forms[0].target ='_blank';">
                                                    <i class="icon icon-cart"></i><span>Preview</span>  
                                                    </asp:LinkButton>
                                    <%--<a href="cart.html"><button type="button" class="button -blue center"><i class="fa fa-cart-plus" aria-hidden="true"></i> Add to cart</button></a>                                    
                                    <a href="cart.html"><a href="cart.html"><button type="button" class="button -sun center"><i class="fa fa-plus" aria-hidden="true"></i> Buy Now</button></a></a>--%>
                                </div>
                                <div class="smspurchase">
                                    <%--h3>SMS Purchase Format</h3>
                                    <p>HS EP1058 (space) Your Email (space) Your Name</p>
                                    <p>send to</p>
                                    <ul>
                                        <li>+60146367111</li>
                                        <li>+6584200138</li>
                                        <li>+628989111995</li>
                                        <li>+447860041399</li>
                                    </ul>
                                    <small>Eg. FREE HS EE1539 JohnWoo@yahoo.com John Woo</small>--%>
                                    <div runat="server" id="dvBookPurchaseFormat">
                                                    <div runat="server" id="dvCtryFlags">
                                                        <asp:ImageButton runat="server" ID="flgMalaysia" ImageUrl="~/Images/flag_malaysia.gif" OnClick="flgMalaysia_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgSingapore" ImageUrl="~/Images/flag_singapore.gif" OnClick="flgSingapore_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgIndonesia" ImageUrl="~/Images/flag_indonesia.gif" OnClick="flgIndonesia_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgThailand" ImageUrl="~/Images/flag_thailand.gif" OnClick="flgThailand_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgVietnam" ImageUrl="~/Images/flag_vietnam.gif" OnClick="flgVietnam_Click" Height="40px" Width="70px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgPhilippines" ImageUrl="~/Images/flag_philippines.gif" OnClick="flgPhilippines_Click" Height="40px" Width="70px" />&nbsp;
                                                    </div>
                                                    <div runat="server" id="tblPurchase">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> <asp:Literal ID="lblCountryName" runat="server" Text="Malaysia SMS Purchase"></asp:Literal></h3>
                                                            <p><asp:Literal ID="lblPurFormat" runat="server" Text=""></asp:Literal></p>
                                                            <p><asp:Literal ID="Literal12" runat="server" Text=""></asp:Literal></p>
                                                            <small><asp:Literal ID="lblPurchaseNote" runat="server" Text=""></asp:Literal></small>
                                                        </div>
                                                    </div>
                                                    
                                                    <div runat="server" id="Div1">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> <asp:Literal ID="Literal4" runat="server" Text="" ></asp:Literal> Request via Telegram</h3>
                                                            <p><asp:Literal ID="Literal5" runat="server" Text="Step 1 – Register Telegram Apps<br>Step 2 – Register FREE-Ebook Bot – Link Below"></asp:Literal></p>
                                                            <asp:HyperLink ID="hypTelFree" runat="server" NavigateUrl="https://telegram.me/ebookfreesys_bot" Target="_blank">
                                                            <small><asp:Literal ID="Literal7" runat="server" Text="https://telegram.me/ebookfreesys_bot"></asp:Literal></small>
                                                            </asp:HyperLink>
                                                            <p><asp:Literal ID="Literal13" runat="server" Text="Step 1 – Register Telegram Apps<br>Step 2 – Register FREE-Ebook Bot – Link Below"></asp:Literal></p>
                                                        </div>
                                                    </div>

                                                    <div visible="false" runat="server" id="tblFreeEbooksPurchase">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> <asp:Literal ID="Literal10" runat="server" Text="" ></asp:Literal> Request via SMS</h3>
                                                            <p><asp:Literal ID="lblPurFormat2" runat="server" Text=""></asp:Literal></p>
                                                            <p><asp:Literal ID="Literal14" runat="server" Text=""></asp:Literal></p>
                                                            <small><asp:Literal ID="lblPurchaseNote2" runat="server" Text=""></asp:Literal></small>
                                                        </div>
                                                    </div>

                                                </div>
                                                    <div visible="false" runat="server" id="tblComingSoon">
                                                        <div class="smspurchase">
                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> <asp:Literal ID="Literal1" runat="server" Text="" ></asp:Literal> SMS Purchase</p>
                                                            <h3>Coming Soon</h3>
                                                        </div>
                                                    </div>
                                        </div>
                                    
                                        
                                        <div class="social-icons colored" runat="server">
                                             <%--<a href="#" id="hfFaceBook" runat="server" class="social-icon icon facebook" title="Facebook" target="_blank"><span class="sr-only">Facebook</span></a>--%>
                                             <asp:HyperLink runat="server" ID="hfFaceBook" ImageUrl="~/Images/Mobile/facebook.png" Target="_blank" ></asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hfTwitter" ImageUrl="~/Images/Mobile/Twitter.png" Target="_blank"></asp:HyperLink>
                                            <%--<asp:HyperLink runat="server" ID="hfGooglePlus" ImageUrl="~/Images/Mobile/googleplus.png" Target="_blank"></asp:HyperLink>--%>
                                            <asp:HyperLink runat="server" ID="hfLinkedIn" ImageUrl="~/Images/Mobile/linkedin.png" Target="_blank"></asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hfPinterest" ImageUrl="~/Images/Mobile/pinterest.png" Target="_blank"></asp:HyperLink>                                           
                                        </div>
                                        <div class="global-sms" runat="server" id="dvglobalpurchaseLink">
                                            <%--<div class="demo-btns">
                                            <a href="" data-modal="#modal2" class="modal__trigger ">Global SMS Purchase</a>
                                            </div>--%>
                                            <div class="m-b-30"></div>
                                        <!-- Modal -->
                                        <div id="modal2" class="modal modal--align-top modal__bg" role="dialog" aria-hidden="true">
                                            <div class="modal__dialog" >
                                                <div class="modal__content">
                                                    <div runat="server" id="dvPBookFormat">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> INDONESIA Mobile Purchase Format</h3>
                                                            <%--<p>HS EP1058 (space) Your Email (space) Your Name</p>
                                                            <p>send to <b>33288</b></p>
                                                            <p>Note: RM5 per SMS received.</p>

                                                            <small>Eg. FREE HS EE1539 JohnWoo@yahoo.com John Woo</small>--%>

                                                            <p><asp:Literal ID="pPFormat" runat="server" Text=""></asp:Literal></p>
                                                            <p><asp:Literal ID="pBookSendTo" runat="server" Text=""></asp:Literal></p>
                                                            <small><asp:Literal ID="pBookDFormat" runat="server" Text=""></asp:Literal></small>
                                                        </div>
                                                    </div>
                                                    <div runat="server" id="dvPBookFormat1">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> SINGAPORE SMS Purchase</h3>
                                                            <%--<p>HS EP1058 (space) Your Email (space) Your Name</p>
                                                            <p>send to <b>33288</b></p>
                                                            <p>Kini Kamu Bisa Membayar Dengan Ponsel! Harga Rp.16500 (termasuk PPN). Kanduangan Laporan ini dalam Bahasa Inggris Laporan dikirim terusan ke Email kamu selepas pembayarannya.Hanya Telco XL dan Telkomsel Sahaja diterima.</p>

                                                            <small>Eg. FREE HS EE1539 JohnWoo@yahoo.com John Woo</small>--%>
                                                            <p><asp:Literal ID="pPFormat1" runat="server" Text=""></asp:Literal></p>
                                                            <p><asp:Literal ID="pBookSendTo1" runat="server" Text=""></asp:Literal></p>
                                                            <small><asp:Literal ID="pBookDFormat1" runat="server" Text=""></asp:Literal></small>
                                                        </div>
                                                    </div>
                                                    <div runat="server" id="dvPBookFormat2">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> Malaysia SMS Purchase</h3>
                                                            <%--<p>HS EP1058 (space) Your Email (space) Your Name</p>
                                                            <p>send to <b>33288</b></p>
                                                            <p>SGD 5 (Excl. GST) per SMS received.Only Accept M1 and StarHub.</p>

                                                            <small>Eg. FREE HS EE1539 JohnWoo@yahoo.com John Woo</small>--%>
                                                            <p><asp:Literal ID="pPFormat2" runat="server" Text=""></asp:Literal></p>
                                                            <p><asp:Literal ID="pBookSendTo2" runat="server" Text=""></asp:Literal></p>
                                                            <small><asp:Literal ID="pBookDFormat2" runat="server" Text=""></asp:Literal></small>
                                                        </div>
                                                    </div>

                                                    <div runat="server" id="dvPBookFormat3">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> Thailand SMS Purchase</h3>
                                                            <%--<p>HS EP1058 (space) Your Email (space) Your Name</p>
                                                            <p>send to <b>33288</b></p>
                                                            <p>SGD 5 (Excl. GST) per SMS received.Only Accept M1 and StarHub.</p>

                                                            <small>Eg. FREE HS EE1539 JohnWoo@yahoo.com John Woo</small>--%>
                                                            <p><asp:Literal ID="pPFormat3" runat="server" Text=""></asp:Literal></p>
                                                            <p><asp:Literal ID="pBookSendTo3" runat="server" Text=""></asp:Literal></p>
                                                            <small><asp:Literal ID="pBookDFormat3" runat="server" Text=""></asp:Literal></small>
                                                        </div>
                                                    </div>
                                                    <div runat="server" id="dvPBookFormat4">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> Philippines SMS Purchase</h3>
                                                            <%--<p>HS EP1058 (space) Your Email (space) Your Name</p>
                                                            <p>send to <b>33288</b></p>
                                                            <p>SGD 5 (Excl. GST) per SMS received.Only Accept M1 and StarHub.</p>

                                                            <small>Eg. FREE HS EE1539 JohnWoo@yahoo.com John Woo</small>--%>
                                                            <p><asp:Literal ID="pPFormat4" runat="server" Text=""></asp:Literal></p>
                                                            <p><asp:Literal ID="pBookSendTo4" runat="server" Text=""></asp:Literal></p>
                                                            <small><asp:Literal ID="pBookDFormat4" runat="server" Text=""></asp:Literal></small>
                                                        </div>
                                                    </div>
                                                    <div runat="server" id="dvPBookFormat5">
                                                        <div class="smspurchase">
                                                            <h3><i class="fa fa-mobile" aria-hidden="true"></i> Vietnam SMS Purchase</h3>
                                                            <%--<p>HS EP1058 (space) Your Email (space) Your Name</p>
                                                            <p>send to <b>33288</b></p>
                                                            <p>SGD 5 (Excl. GST) per SMS received.Only Accept M1 and StarHub.</p>

                                                            <small>Eg. FREE HS EE1539 JohnWoo@yahoo.com John Woo</small>--%>
                                                            <p><asp:Literal ID="pPFormat5" runat="server" Text=""></asp:Literal></p>
                                                            <p><asp:Literal ID="pBookSendTo5" runat="server" Text=""></asp:Literal></p>
                                                            <small><asp:Literal ID="pBookDFormat5" runat="server" Text=""></asp:Literal></small>
                                                        </div>
                                                    </div>
                                                    <!-- modal close button -->
                                                    <a href="" class="modal__close demo-close">
                                                        <svg class="" viewBox="0 0 24 24"><path d="M19 6.41l-1.41-1.41-5.59 5.59-5.59-5.59-1.41 1.41 5.59 5.59-5.59 5.59 1.41 1.41 5.59-5.59 5.59 5.59 1.41-1.41-5.59-5.59z"/><path d="M0 0h24v24h-24z" fill="none"/></svg>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="product-desc">
                                    <h2><asp:Literal ID="lblBookName1" runat="server" Text=""></asp:Literal></h2>
                                    <p><asp:Literal ID="lblBookDescription" runat="server" Text=""></asp:Literal></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

    <uc1:N_Footer runat="server" ID="N_Footer" />
</asp:Content>