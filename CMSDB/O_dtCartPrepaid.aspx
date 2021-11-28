<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtCartPrepaid.aspx.cs" Inherits="O_dtCartPrepaid" %>
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
                <div runat="server" class="col-md-9 col-md-push-3">
                        <div runat="server" class="table-responsive">

                            <asp:GridView ID="gridItems" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="False" 
                            CssClass="table table-bordered cart-table"
                            DataKeyNames="id" HeaderStyle-CssClass="quantity-col" 
                            ondatabound="gridItems_DataBound" onpageindexchanging="gridItems_PageIndexChanging" 
                            onrowcancelingedit="gridItems_RowCancelingEdit" onrowdatabound="gridItems_RowDataBound" 
                            onrowdeleting="gridItems_RowDeleting" 
                            onrowediting="gridItems_RowEditing" OnRowUpdating="gridItems_RowUpdating"  OnRowCreated="gridItems_RowCreated" 
                            PageSize="10">

                                <Columns>

                                <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <asp:Label ID="lblSlNo" runat="server" Text="<%# Container.DataItemIndex + 1  %>" />
                                    <asp:Literal ID="hdBookId" runat="server" Text='<%#Bind("id")%>' Visible="false"></asp:Literal>
                                    <asp:HiddenField ID="hdItemsCount" Value='<%#Bind("count")%>' runat="server" />
                                    <asp:HiddenField ID="hdTotalAmount" Value='<%#Bind("total")%>' runat="server" />
                                </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product ID / Product Name" SortExpression="BookID">
                                <ItemTemplate>
                                    <div style="vertical-align:bottom; position: relative;">
                                    <div id="dvBookImg" style="float:left; margin-left: 20px;">
                                    <asp:Image ID="ImgEbook" CssClass="product-top" Height="150" Width="80" ImageUrl='<%# Eval("ImageURL")%>' runat="server" />
                                        </div>
                                    <div id="dvBookDetails" style="float:left; margin-left: 30px; margin-top: 10px; padding: 10px; vertical-align:text-bottom;">
                                    <asp:Label ID="lblBookID" runat="server" CssClass="fontCart" Text='<%# Bind("id")  %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblBookName" runat="server" CssClass="fontCart2" Text='<%# Bind("name")  %>'></asp:Label>
                                        </div>
                                        </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign ="Left" />
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Prepaid Price" SortExpression="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrepaidPrice" runat="server" CssClass="fontViewCart" Text=''></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="CellPaddingRight" HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                                <ItemTemplate>
                                    
                                     <asp:Label ID="Label1" runat="server" CssClass="fontCart" Text='<%# Bind("currency")  %>'></asp:Label>&nbsp;
                                    <asp:Label ID="lblPrice" runat="server" CssClass="fontViewCart" Text='<%# Bind("price", "{0:0.00}")  %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="CellPaddingRight" HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                           
                         
                            <asp:TemplateField HeaderText="Remove from Cart">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgDelete" runat="server" CommandName="DELETE" ImageUrl="~/Images/ebImages/cart/shopping_cart_delete.png" CssClass="imgDelCart" OnClientClick="return confirm('Please click OK to confirm deletion');" ToolTip="Remove from Cart" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="100px" />
                            </asp:TemplateField>

                               </Columns>
         </asp:GridView>

                            <%--<table class="table table-bordered cart-table">
                                <thead>
                                    <tr>
                                        <th class="quantity-col">Quantity</th>
                                        <th class="product-col">Product Name</th>
                                        <th class="prepaid-col">Prepaid Price</th>
                                        <th class="price-col">Unit Price</th>
                                        <th class="delete-col"><i class="icon delete-btn"></i></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="quantity-col">1</td>
                                        <td class="product-col">
                                            <div class="product">
                                                <div class="product-top">
                                                    <figure>
                                                        <a href="cart.html#"><img src="assets/images/products/index5/product1.jpg" alt="Product Image"></a>
                                                    </figure>
                                                </div>
                                                <div class="product-content-wrapper">
                                                    <h3 class="product-title"><a href="#"><span class="highlight custom">EEE111</span> Email Marketing Made Easy</a></h3>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="prepaid-col">Not Available</td>
                                        <td class="price-col">
                                            <div class="product-price-container"><span class="product-price">$1200.00</span></div>
                                        </td>
                                        <td class="delete-col">
                                            <a href="cart.html#" class="icon delete-btn lighter"></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="quantity-col"></td>
                                        <td class="product-col text-right">
                                            Total Item:
                                        </td>
                                        <td class="prepaid-col">Not Available</td>
                                        <td class="price-col">
                                            <div class="product-price-container"><span class="product-price">$2400.00</span></div>
                                        </td>
                                        <td class="delete-col">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>--%>
                        </div>
                        <div runat="server" class="row">
                            <div runat="server" class="col-xs-12 col-lg-12">
                                <div runat="server" class="text-right">                                   
                                    <asp:LinkButton ID="LnkPrepaidPurchase" class="btn btn-lightgreen min-width" runat="server" Text="Registered Prepaid User?" OnClick="LnkPrepaidPurchase_Click">
                                        Registered Prepaid User?
                                    </asp:LinkButton>                                    
                                    <asp:LinkButton ID="lnkCheckOut2PayPal" class="btn btn-blue min-width" runat="server" Text="New Prepaid User?" OnClick="lnkCheckOut2PayPal_Click">
                                        New Prepaid User?
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div runat="server" class="mb130 mb100-sm mb80-xs"></div>
                    </div>
                <div class="mb30 visible-sm visible-xs clearfix" runat="server"></div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>            
        </div>
        <div class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                
</asp:Content>
