<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtValuebuy.aspx.cs" Inherits="O_dtValuebuy" %>
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



    <div runat="server" class="main">
        <%--<div class="page-header" runat="server">
            <div class="container-fluid" runat="server">
                <ol class="breadcrumb">
                    <li><a href="index.html">Home</a></li>
                    <li class="#">Category</li>
                    <li class="active">My Categories</li>
                </ol>
            </div>
        </div>--%>


        <div runat="server" class="container-fluid">
            <div runat="server" class="row" runat="server">
                <div runat="server" class="col-md-9 col-md-push-3" runat="server">
                    <div runat="server" class="top-filter-container clearfix" runat="server" id="dvRepeaterPages">
                        <div runat="server" class="row" runat="server">
                            <div runat="server" class="container-fluid">
                <asp:Repeater ID="RepBooks" runat="server" OnItemDataBound="RepBooks_ItemDataBound" OnItemCommand="RepBooks_ItemCommand">
                    <ItemTemplate>
                <div runat="server" class="value-book-series">
                    <asp:HyperLink ID="HyperLink5" NavigateUrl='<%# Eval("BookID","~/O_dtValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                    <h2><asp:Label ID="Label4" runat="server" CssClass="VB_headFont2" Text='<%# Eval("BookID")%>'></asp:Label> :
                                            <asp:Label ID="lblHeader" runat="server" CssClass="VB_headFont1" Text='<%# Eval("BookName")%>'></asp:Label></h2>
                    </asp:HyperLink>
                    <asp:HiddenField ID="hdnBookAllowSmsBuy" Value='<%# Eval("AllowSmsBuy")%>' runat="server" />
                                               <asp:HiddenField ID="hdnBookAllowPayPalBuy" Value='<%# Eval("AllowPaypalBuy")%>' runat="server" />

                    
                    <div runat="server" class="row">
                        <div id="divVB1" runat="server" class="col-lg-2 col-sm-6">
                            <div runat="server" class="product product3">
                                <div runat="server" class="product-top1">
                                    <figure>
                                        <asp:HyperLink ID="HyperLink6" NavigateUrl='<%# Eval("BookID","~/O_dtValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                        <asp:Image ID="ImgEbook1" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL1")%>' runat="server" />
                                        </asp:HyperLink>
                                    </figure>                                    
                                </div>
                                <h3 class="product-title"><a href="#"><asp:Label ID="lblBookName1" runat="server" Text='<%# Eval("BookName1")%>'></asp:Label></a></h3>
                            </div>
                        </div>
                        <div id="divVB2" runat="server" class="col-lg-2 col-sm-6">
                            <div runat="server" class="product product3">
                                <div runat="server" class="product-top1">
                                    <figure>
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("BookID","~/O_dtValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                        <asp:Image ID="ImgEbook2" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL2")%>' runat="server" />
                                        </asp:HyperLink>
                                    </figure>                                    
                                </div>
                                <h3 class="product-title"><a href="#"><asp:Label ID="lblBookName2" runat="server" Text='<%# Eval("BookName2")%>'></asp:Label></a></h3>
                            </div>
                        </div>
                        <div id="divVB3" runat="server" class="col-lg-2 col-sm-6">
                            <div runat="server" class="product product3">
                                <div runat="server" class="product-top1">
                                    <figure>
                                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("BookID","~/O_dtValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                        <asp:Image ID="ImgEbook3" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL3")%>' runat="server" />
                                        </asp:HyperLink>
                                    </figure>                                    
                                </div>
                                <h3 class="product-title"><a href="#"><asp:Label ID="lblBookName3" runat="server" Text='<%# Eval("BookName3")%>'></asp:Label></a></h3>
                            </div>
                        </div>
                        <div id="divVB4" runat="server" class="col-lg-2 col-sm-6">
                            <div runat="server" class="product product3">
                                <div runat="server" class="product-top1">
                                    <figure>
                                        <asp:HyperLink ID="HyperLink3" NavigateUrl='<%# Eval("BookID","~/O_dtValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                        <asp:Image ID="ImgEbook4" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL4")%>' runat="server" />
                                        </asp:HyperLink>
                                    </figure>                                    
                                </div>
                                <h3 class="product-title"><a href="#"><asp:Label ID="lblBookName4" runat="server" Text='<%# Eval("BookName4")%>'></asp:Label></a></h3>
                            </div>
                        </div>
                        <div id="divVB5" runat="server" class="col-lg-2 col-sm-6">
                            <div runat="server" class="product product3">
                                <div runat="server" class="product-top1">
                                    <figure>
                                        <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("BookID","~/O_dtValueBuyShowDetails.aspx?qBookID={0}") %>' runat="server">
                                        <asp:Image ID="ImgEbook5" class='img-responsive' ImageUrl='<%# Eval("ImageFileURL5")%>' runat="server" />
                                        </asp:HyperLink>
                                    </figure>                                    
                                </div>
                                <h3 class="product-title"><a href="#"><asp:Label ID="lblBookName5" runat="server" Text='<%# Eval("BookName5")%>'></asp:Label></a></h3>
                            </div>
                        </div>
                    </div>
                    
                    <div runat="server" class="row">
                        <div runat="server" class="col-lg-6 col-md-6">
                            <div runat="server" class="table-responsive bg-white" id="dvEbDetails">
                                <table class="table table-bordered product-list-table">
                                    <tbody>
                                        <tr>
                                            <td><b>Product Code</b></td>
                                            <td><asp:Label ID="lblBookID" runat="server" Text='<%# Eval("BookID")%>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td><b>Product Name</b></td>
                                            <td><asp:Label ID="lblBookName" runat="server" Text='<%# Eval("BookNAme")%>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td><b>No. of Books</b></td>
                                            <td><asp:Label ID="lblCategory" runat="server" Text='<%# Eval("BooksCount")%>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td><b>Date Created</b></td>
                                            <td><asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateCreated","{0:MMMM d, yyyy}")%>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td><b>Original Price</b></td>
                                            <td><span class="text-custom4"><asp:Label ID="Label7" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                  <asp:Label ID="lblOrgPrice" runat="server" Text='<%# Eval("Price", "{0:0.00}")%>'></asp:Label></span></td>
                                        </tr>
                                        <tr>
                                            <td><b>After Discount</b></td>
                                            <td><span class="text-custom4"><asp:Label ID="Label8" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                  
                                                  <asp:Label ID="lblAfterDiscount" runat="server" Text='<%# Eval("DiscountedPrice", "{0:0.00}")%>'></asp:Label></span></td>
                                        </tr>
                                        <%--<tr>
                                            <td><b>Prepaid Price</b></td>
                                            <td><asp:Label ID="lblPrepaidPrice" runat="server" Text='<%# Eval("PrepaidPrice")%>'></asp:Label></td>
                                        </tr>--%>
                                    </tbody>

                                </table>
                            </div>
                        </div>
                        <div runat="server" class="col-lg-6 col-md-6" id="DivPurchaseFooter">
                            <div>&nbsp;</div>    
                                                 <div runat="server" id="dvCtryFlags">
                                                        <asp:ImageButton runat="server" ID="flgMalaysia" ImageUrl="~/Images/flag_malaysia.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgM" OnCommand="flgMalaysia_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgSingapore" ImageUrl="~/Images/flag_singapore.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgS" OnCommand="flgSingapore_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgIndonesia" ImageUrl="~/Images/flag_indonesia.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgI" OnCommand="flgIndonesia_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgThailand" ImageUrl="~/Images/flag_thailand.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgT" OnCommand="flgThailand_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgVietnam" ImageUrl="~/Images/flag_vietnam.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgV" OnCommand="flgVietnam_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgPhilippines" ImageUrl="~/Images/flag_philippines.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgP" OnCommand="flgPhilippines_Click" Height="30px" Width="50px" />&nbsp;                                                        
                                                </div>
                            <div runat="server" class="mobile-purchase-detail bg-white">
                                <p><i class="fa fa-mobile" aria-hidden="true"></i><asp:Literal ID="lblPurFormat" runat="server" Text="Malaysia SMS Purchase" ></asp:Literal></p>
                                <div runat="server" class="code-mobile-detail">
                                    <h3><asp:Literal ID="lblPurchaseText" runat="server" Text=""></asp:Literal></h3>
                                    <p><asp:Literal ID="Literal12" runat="server" Text="SEND to 36247"></asp:Literal> </p>
                                    <small><asp:Literal ID="lblPurchaseNote" runat="server" Text="SEND to 36247"></asp:Literal></small>
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
                    </div>                    
                    <div runat="server" class="row">
                        <div runat="server" class="col-md-4 col-sm-4">
                            <div runat="server" class="product-action">                                
                                <asp:LinkButton ID="LnkPayPalBuy"  Visible="false" class="btn-add-cart custom2" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") %>' runat="server">
                                                      <span>Buy Now</span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lnkAddtoCart"  Visible="false" class="btn-add-cart custom4" OnCommand="lnkAddtoCart_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") %>' runat="server">
                                                      <i class="icon icon-cart"></i><span>Add To Cart</span>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div runat="server" class="col-md-8 col-sm-8">
                            <%--<div runat="server" class="social-icons colored mt10 fright"><a href="#" class="social-icon icon facebook" title="Facebook"><span class="sr-only">Facebook</span></a> <a href="#" class="social-icon icon twitter" title="Twitter"><span class="sr-only">Twitter</span></a> <a href="#" class="social-icon icon pinterest" title="Pinterest"><span class="sr-only">Pinterest</span></a> <a href="#" class="social-icon icon instagram" title="Instagram"><span class="sr-only">Instagram</span></a> <a href="#" class="social-icon icon flickr" title="Flickr"><span class="sr-only">Flickr</span></a> <a href="#" class="social-icon icon skype" title="Skype"><span class="sr-only">Skype</span></a> <a href="mailto:#" class="social-icon icon email" title="Email"><span class="sr-only">Email</span></a>

                            </div>--%>
                        </div>
                    </div>
                </div>
                        </ItemTemplate>
                                </asp:Repeater>
                <div class="mb40"></div>
            </div>
                        </div>
                    </div>
                </div>
                <div runat="server" class="mb30 visible-sm visible-xs clearfix" runat="server"></div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>            
        </div>
        <div runat="server" class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                
</asp:Content>