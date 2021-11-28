<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_List.aspx.cs" Inherits="N_List" %>
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

         <asp:Repeater ID="RepBooks" runat="server" OnItemDataBound="RepBooks_ItemDataBound">                          
                            <ItemTemplate>

                                <asp:Literal ID="hdIsFreeBook" Text='<%# Eval("isFreeBook")%>' runat="server" Visible="false"></asp:Literal>
                                <asp:Literal ID="hdLaunchStatus" Text='<%# Eval("LaunchStatus")%>' runat="server" Visible="false"></asp:Literal>
                                <asp:Literal ID="hdAllowSMsBuy" Text='<%# Eval("AllowSmsBuy")%>' runat="server" Visible="false"></asp:Literal>
                                <asp:Literal ID="hdAllowPayPalBuy" Text='<%# Eval("AllowPayPalBuy")%>' runat="server" Visible="false"></asp:Literal>

                    <div class="row">
                        <div class="col-xs-12 product-list">
                            <div class="row">
                                <div class="col-xs-8">
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <asp:HyperLink ID="HypBookShow" NavigateUrl='<%# Eval("BookID","~/N_ShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                <asp:Image ID="ImgEbook" CssClass="img-responsive" ImageUrl='<%# Eval("ImageFileFullURL")%>' runat="server" />
                                            </asp:HyperLink>
                                        </div>
                                        <div class="col-xs-8" >
                                            <%--<h2 class="list-book-name">
                                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("BookID","~/N_ShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title")%>'></asp:Label>
                                                </asp:HyperLink>
                                            </h2>--%>
                                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("BookID","~/N_ShowDetails.aspx?qBookID={0}") %>' runat="server">
                                            <p class="text-login"><asp:Label ID="lblBName" runat="server" Text='<%# Eval("BookName")%>'></asp:Label></p> 
                                            <p><asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label> </p>
                                            </asp:HyperLink>
                                            <div runat="server" id="dvBookPurchaseFormat">
                                            <div>&nbsp;</div>    
                                                 <div runat="server" id="dvCtryFlags">
                                                        <asp:ImageButton runat="server" ID="flgMalaysia" ImageUrl="~/Images/flag_malaysia.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgM" OnCommand="flgMalaysia_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgSingapore" ImageUrl="~/Images/flag_singapore.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgS" OnCommand="flgSingapore_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgIndonesia" ImageUrl="~/Images/flag_indonesia.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgI" OnCommand="flgIndonesia_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgThailand" ImageUrl="~/Images/flag_thailand.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgT" OnCommand="flgThailand_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgVietnam" ImageUrl="~/Images/flag_vietnam.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgV" OnCommand="flgVietnam_Click" Height="30px" Width="50px" />&nbsp;
                                                        <asp:ImageButton runat="server" ID="flgPhilippines" ImageUrl="~/Images/flag_philippines.gif" CommandArgument='<%# Eval("BookID")%>' CommandName="flgP" OnCommand="flgPhilippines_Click" Height="30px" Width="50px" />&nbsp;                                                        
                                                </div>
                                            <div class="smspurchaselist" runat="server" id="tblPurchase">
                                                <h3><asp:Literal ID="Literal10" runat="server" Text="" ></asp:Literal> SMS Purchase Format</h3>
                                                <p><asp:Literal ID="lblPurFormat" runat="server" Text="" ></asp:Literal></p>
                                                <p><asp:Literal ID="Literal12" Text="" runat="server"></asp:Literal></p>
                                                <small><asp:Literal ID="lblPurchaseNote" runat="server" Text=""></asp:Literal></small>
                                            </div>

                                            <div class="smspurchaselist" runat="server" id="tblFreeEbooksPurchase" visible="false">
                                                <h3>SMS Purchase Format</h3>
                                                <p><asp:Literal ID="lblPurFormat2" runat="server" Text="" ></asp:Literal></p>
                                                <p><small><asp:Literal ID="Literal14" Text="" runat="server"></asp:Literal></small></p>
                                                <small><asp:Literal ID="lblPurchaseNote2" runat="server" Text=""></asp:Literal></small>
                                            </div>

                                            <div class="smspurchaselist" runat="server" id="tblComingSoon" visible="false">
                                                <h3>Coming Soon</h3>
                                            </div>
                                            
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
                                </div>
                                <div class="col-xs-4">
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
                                                <td class="text-left">Category:</td>
                                                <td class="text-left"><asp:Label ID="lblCategory" runat="server" Text='<%# Eval("CategoryName")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">Date Created:</td>
                                                <td class="text-left"><asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateCreated","{0:MMMM d, yyyy}")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">Original Price:</td>
                                                <td class="text-left"><asp:Label ID="Label2" runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                     <asp:Label ID="lblOrgPrice" runat="server" Text='<%# Eval("Price", "{0:0.00}")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">After Discount:</td>
                                                <td class="text-left"><asp:Label ID="Label1" runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                     <asp:Label ID="lblAfterDiscount" runat="server" Text='<%# Eval("DiscountedPrice", "{0:0.00}")%>'></asp:Label></td>
                                            </tr>
                                            <%--<tr>
                                                <td class="text-left">Prepaid Price:</td>
                                                <td class="text-left"><asp:Label ID="lblPrepaidPrice" runat="server" Text='<%# Eval("PrepaidPrice")%>'></asp:Label></td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                    <div class="button-action">
                                        <asp:LinkButton ID="lnkAddtoCart" class="button -blue center" Visible="false" Text="Add To Card" OnCommand="lnkAddtoCart_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") + "#" + Eval("ImageFileFullURL") %>' runat="server">                                                                                                  
                                                <i class="fa fa-cart-plus"></i><span>Add To Cart</span>  
                                                </asp:LinkButton>
                                        <asp:LinkButton ID="LnkPayPalBuy" class="button -sun center" Visible="false" Text="Buy Now" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") + "#" + Eval("ImageFileFullURL") %>' runat="server">                                                                                                  
                                                <i class="fa fa-plus"></i><span>Buy Now</span> 
                                                </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                   
                   </ItemTemplate>
                           </asp:Repeater>

                    <div class="pagination">
                        <nav aria-label="Page navigation">                            
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
                    </div>
                </div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>