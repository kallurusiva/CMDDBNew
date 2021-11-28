<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtList.aspx.cs" Inherits="O_dtList" %>
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
        <%--<div class="page-header" runat="server">
            <div class="container-fluid" runat="server">
                <ol class="breadcrumb">
                    <li><a href="index.html">Home</a></li>
                    <li class="#">Category</li>
                    <li class="active">My Categories</li>
                </ol>
            </div>
        </div>--%>


        <div class="container-fluid" runat="server">
            <div class="row" runat="server">
                <div class="col-md-9 col-md-push-3" runat="server">
                    <div class="top-filter-container clearfix" runat="server" id="dvRepeaterPages">
                        <nav class="filter-right pagination-container clearfix">
                                <ul class="pagination">
                                    <li>
                                    <asp:Repeater ID="rptPages" runat="server" OnItemDataBound="rptPages_ItemDataBound">                                        
                                        <ItemTemplate>                                
                                            <asp:LinkButton ID="btnPage"
                                                         CommandName="Page"
                                                         CommandArgument="<%#
                                                         Container.DataItem %>"
                                                         Text ="<%#
                                                         Container.DataItem %>"
                                                         Runat="server"><%# Container.DataItem %>
                                                         </asp:LinkButton>
                                    
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    </li>
                                  </ul>
                          </nav>
                        <%--<nav class="filter-right pagination-container clearfix">
                            <ul class="pagination">
                                <li class="active"><a href="category-list-left-sidebar.html#">1</a></li>
                                <li><a href="#">2</a></li>
                                <li><a href="#">3</a></li>
                                <li><a href="#">4</a></li>
                                <li><a href="#" aria-label="Next" class="icon next-icon"><span aria-hidden="true"><span class="sr-only">Next</span></span></a></li>
                            </ul>
                            <div class="page-view-filter" runat="server">
                                <select class="custom-select form-control">
                                    <option>Show: 20</option>
                                    <option>Show: 25</option>
                                    <option>Show: 30</option>
                                    <option>Show: 35</option>
                                </select></div>
                        </nav>--%>

                    </div>

                     <asp:Repeater ID="RepBooks" runat="server" OnItemDataBound="RepBooks_ItemDataBound">                          
                            <ItemTemplate>
                                            <%--<asp:HiddenField ID="hdIsFreeBook" Value='<%# Eval("isFreeBook")%>' runat="server" />
                                            <asp:HiddenField ID="hdLaunchStatus" Value='<%# Eval("LaunchStatus")%>' runat="server" />
                                            <asp:HiddenField ID="hdAllowSMsBuy" Value='<%# Eval("AllowSmsBuy")%>' runat="server" />
                                            <asp:HiddenField ID="hdAllowPayPalBuy" Value='<%# Eval("AllowPayPalBuy")%>' runat="server" />--%>

                                <asp:Literal ID="hdIsFreeBook" Text='<%# Eval("isFreeBook")%>' runat="server" Visible="false"></asp:Literal>
                                <asp:Literal ID="hdLaunchStatus" Text='<%# Eval("LaunchStatus")%>' runat="server" Visible="false"></asp:Literal>
                                <asp:Literal ID="hdAllowSMsBuy" Text='<%# Eval("AllowSmsBuy")%>' runat="server" Visible="false"></asp:Literal>
                                <asp:Literal ID="hdAllowPayPalBuy" Text='<%# Eval("AllowPayPalBuy")%>' runat="server" Visible="false"></asp:Literal>

                        <div class="products-list-container clearfix" runat="server">
                        <div class="product product-list row" runat="server">
                            <div class="col-md-8" runat="server">
                                <div class="row" runat="server">
                                    <div class="col-md-5" runat="server">
                                        <%--<span class="product-label discount">-25%</span>--%>
                                        <figure>
                                            <asp:HyperLink ID="HypBookShow" NavigateUrl='<%# Eval("BookID","~/O_dtShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                <asp:Image ID="ImgEbook" CssClass="img-responsive" ImageUrl='<%# Eval("ImageFileFullURL")%>' runat="server" />
                                            </asp:HyperLink>
                                        </figure>
                                        <a href='<%# Eval("BookID","O_dtShowDetails.aspx?qBookID={0}") %>' class="btn-quickview icon" title="Quick View"><span class="sr-only">View</span></a>
                                    </div>
                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("BookID","~/O_dtShowDetails.aspx?qBookID={0}") %>' runat="server">
                                    <div class="col-md-7" runat="server">
                                        <%--<div class="product-brand">
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title")%>'></asp:Label>
                                        </div>--%>
                                        <%--<h3 class="product-title"><a href="product_detail.html">PhytoCellTec™ Solar Vitis 葡萄干细胞 保护表皮干细胞抵抗紫外线侵害 </a></h3>--%>
                                        <h3 class="product-title"><asp:Label ID="lblBName" runat="server" Text='<%# Eval("BookName")%>'></asp:Label></h3>
                                        <p><asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label></p>
                                    </div>
                                        </asp:HyperLink>
                                </div>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("BookID","~/O_dtShowDetails.aspx?qBookID={0}") %>' runat="server">
                                <div class="row" runat="server" id="dvBookPurchaseFormat">
                                    <div>&nbsp;</div>    
                                                 <div runat="server" id="dvCtryFlags">
                                                        <asp:ImageButton runat="server" ID="flgMalaysia" ImageUrl="~/Images/flag_malaysia.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgM" OnCommand="flgMalaysia_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgSingapore" ImageUrl="~/Images/flag_singapore.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgS" OnCommand="flgSingapore_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgIndonesia" ImageUrl="~/Images/flag_indonesia.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgI" OnCommand="flgIndonesia_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgThailand" ImageUrl="~/Images/flag_thailand.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgT" OnCommand="flgThailand_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgVietnam" ImageUrl="~/Images/flag_vietnam.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgV" OnCommand="flgVietnam_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgPhilippines" ImageUrl="~/Images/flag_philippines.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgP" OnCommand="flgPhilippines_Click" Height="30px" Width="50px" />&nbsp;                                                        
                                                </div>
                                    <div class="col-md-12" runat="server">
                                        <div class="mobile-purchase" runat="server" id="tblPurchase">
                                            <h3><asp:Literal ID="Literal10" runat="server" Text="" ></asp:Literal> SMS Purchase Format</h3>
                                            <div class="code-mobile" runat="server">
                                                <p><asp:Literal ID="lblPurFormat" runat="server" Text="" ></asp:Literal></p>
                                                <p><asp:Literal ID="Literal12" Text="" runat="server"></asp:Literal></p>
                                                <small><asp:Literal ID="lblPurchaseNote" runat="server" Text=""></asp:Literal></small>
                                            </div>
                                        </div>
                                        <div class="mobile-purchase" runat="server" id="tblFreeEbooksPurchase" visible="false">
                                            <h3>SMS Purchase Format</h3>
                                            <div class="code-mobile" runat="server">
                                                <p><asp:Literal ID="lblPurFormat2" runat="server" Text="" ></asp:Literal></p>
                                                <p><small><asp:Literal ID="Literal14" Text="" runat="server"></asp:Literal></small></p>
                                                <small><asp:Literal ID="lblPurchaseNote2" runat="server" Text=""></asp:Literal></small>
                                            </div>
                                        </div>
                                        <div class="mobile-purchase" runat="server" id="tblComingSoon" visible="false">
                                            <h3>Coming Soon</h3>
                                        </div>
                                        <div class="product-action-wrapper" runat="server">
                                            <div class="mb20 mb10-sm" runat="server"></div>
                                            <div class="product-action" runat="server">
                                                <asp:LinkButton ID="LnkPayPalBuy" class="btn-add-cart custom2" Visible="false" Text="Buy Now" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") + "#" + Eval("ImageFileFullURL") %>' runat="server">                                                                                                  
                                                <span>Buy Now</span>  
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="lnkAddtoCart" class="btn-add-cart custom4" Visible="false" Text="Add To Card" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") + "#" + Eval("ImageFileFullURL") %>' runat="server">                                                                                                  
                                                <i class="icon icon-cart"></i><span>Add To Cart</span>  
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                   </asp:HyperLink>
                                <div class="social-icons colored" runat="server">
                                             <%--<a href="#" id="hfFaceBook" runat="server" class="social-icon icon facebook" title="Facebook" target="_blank"><span class="sr-only">Facebook</span></a>--%>
                                             <asp:HyperLink runat="server" ID="hfFaceBook" ImageUrl="~/Images/Mobile/facebook.png" Target="_blank" ></asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hfTwitter" ImageUrl="~/Images/Mobile/Twitter.png" Target="_blank"></asp:HyperLink>
                                            <%--<asp:HyperLink runat="server" ID="hfGooglePlus" ImageUrl="~/Images/Mobile/googleplus.png" Target="_blank"></asp:HyperLink>--%>
                                            <asp:HyperLink runat="server" ID="hfLinkedIn" ImageUrl="~/Images/Mobile/linkedin.png" Target="_blank"></asp:HyperLink>
                                            <asp:HyperLink runat="server" ID="hfPinterest" ImageUrl="~/Images/Mobile/pinterest.png" Target="_blank"></asp:HyperLink>                                           
                                        </div>
                            </div>

                            <div class="col-md-4" runat="server">
                                <div class="table-responsive" runat="server">
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
                                                <td><b>Category</b></td>
                                                <td><asp:Label ID="lblCategory" runat="server" Text='<%# Eval("CategoryName")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Date Created</b></td>
                                                <td><asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateCreated","{0:MMMM d, yyyy}")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Original Price</b></td>
                                                <td><span class="text-custom4"><asp:Label ID="Label2" runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                   <asp:Label ID="lblOrgPrice" runat="server" Text='<%# Eval("Price", "{0:0.00}")%>'></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td><b>After Discount</b></td>
                                                <td><span class="text-custom4"><asp:Label ID="Label1" runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
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
                        </div>                     
                    </div>
                                </ItemTemplate>
                           </asp:Repeater>
                    
                    <nav class="filter-right pagination-container clearfix">
                                <ul class="pagination">
                                    <li>
                                    <asp:Repeater ID="rptPages1" runat="server" OnItemDataBound="rptPages1_ItemDataBound">                                        
                                        <ItemTemplate>                                
                                            <asp:LinkButton ID="btnPage1"
                                                         CommandName="Page"
                                                         CommandArgument="<%#
                                                         Container.DataItem %>"
                                                         Text ="<%#
                                                         Container.DataItem %>"
                                                         Runat="server"><%# Container.DataItem %>
                                                         </asp:LinkButton>
                                    
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    </li>
                                  </ul>
                          </nav>
                </div>
                <div class="mb30 visible-sm visible-xs clearfix" runat="server"></div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>
            
        </div>
        <div class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
</asp:Content>
