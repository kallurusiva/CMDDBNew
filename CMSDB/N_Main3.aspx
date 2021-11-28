<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_Main3.aspx.cs" Inherits="N_Main3" %>
<%@ Register Src="~/N_Footer.ascx" TagPrefix="uc1" TagName="N_Footer" %>
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
    
            <div class="col-xs-3 sidebar">
                      <div id="dvEbookCatalog" class="" style="width: 200px;margin-top : 20px;" runat="server">
                        <div class="home-border" runat="server" id="Div1">
                             <h2 class="main-title-home">eBook Catalog</h2><br /> 
                            <asp:Label ID="Label1" CssClass="h1font" runat="server" Text="Our Library"></asp:Label>                   
                                <div class="row" id="Div2" runat="server">                                    
                                    <img alt="FreeBooks" class="upImage" src="Images/ebImages/Design3/ebc.jpg" />                                    
                                </div>
                        </div>
                      </div>

                      <div id="Div3" class="" style="width: 200px;margin-top : 20px;" runat="server">
                        <div class="home-border" runat="server" id="Div4">
                             <h2 class="main-title-home">New Releases</h2><br /> 
                            <asp:Label ID="Label2" CssClass="h1font" runat="server" Text="find new books here"></asp:Label>                   
                                <div class="row" id="Div5" runat="server">                                    
                                    <img alt="FreeBooks" class="upImage" src="Images/ebImages/Design3/Nr.jpg" />                                    
                                </div>
                        </div>
                      </div>
                      
                      <div id="Div6" class="" style="width: 200px;margin-top : 20px;" runat="server">
                        <div class="home-border" runat="server" id="Div7">
                             <h2 class="main-title-home">Feature Buy</h2><br /> 
                            <asp:Label ID="Label3" CssClass="h1font" runat="server" Text="our Recommendations"></asp:Label>                   
                                <div class="row" id="Div8" runat="server">                                    
                                    <img alt="FreeBooks" class="upImage" src="Images/ebImages/Design3/fsb.jpg" />                                    
                                </div>
                        </div>
                      </div>
                </div>
    
    <div class="m-b-20"></div>
    <div class="col-xs-7 content-middle">
                    <div class="m-b-20"></div>
                    <div class="home-border" runat="server" id="dvBestSellerProduct">
                         <h2 class="main-title-home">Best Seller</h2>
                        <%--<span class="list-group-item active"><span class="navbar navbar-default">Best Seller</span></span>--%>
                        <%--<div class="m-b-30"></div>--%>
                        <div class="row" id="dvBestSeller" runat="server">
                        </div>
                    </div>
                        <div class="m-b-20"></div>
                    <div class="home-border" runat="server" id="dvHome">
                            <div class="row" id="dvHomeInner" runat="server">
                                <div id="dvW_WelcomePageText" style="float: left; padding-left: 30px;">
                                    <asp:Label ID="lblWp_WelcomePageText" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                    </div>
                  
    </div>

                <div class="col-xs-2 right-contact">
                    <div class="col-xs-3 sidebar">
                      <div id="Div9" class="" style="width: 200px;margin-top : 20px;" runat="server">
                        <div class="home-border" runat="server" id="Div10">
                             <h2 class="main-title-home">Best Seller</h2><br /> 
                            <asp:Label ID="Label4" CssClass="h1font" runat="server" Text="EBooks at Great Value"></asp:Label>                   
                                <div class="row" id="Div11" runat="server">                                    
                                    <img alt="FreeBooks" class="upImage" src="Images/ebImages/Design3/bs1.jpg" />                                    
                                </div>
                        </div>
                      </div>

                      <%--<div id="Div12" class="" style="width: 200px;margin-top : 20px;" runat="server">
                        <div class="home-border" runat="server" id="Div13">
                             <h2 class="main-title-home">Value Buy</h2><br /> 
                            <asp:Label ID="Label5" CssClass="h1font" runat="server" Text="Bundled Deals"></asp:Label>                   
                                <div class="row" id="Div14" runat="server">                                    
                                    <img alt="FreeBooks" class="upImage" src="Images/ebImages/Design3/vb.jpg" />                                    
                                </div>
                        </div>
                      </div>--%>
                      
                      <div id="Div15" class="" style="width: 200px;margin-top : 20px;" runat="server">
                        <div class="home-border" runat="server" id="Div16">
                             <h2 class="main-title-home">Free</h2><br /> 
                            <asp:Label ID="Label6" CssClass="h1font" runat="server" Text="We are not joking"></asp:Label>                   
                                <div class="row" id="Div17" runat="server">                                    
                                    <img alt="FreeBooks" class="upImage" src="Images/ebImages/Design3/fr.gif" />                                    
                                </div>
                        </div>
                      </div>
                </div>
              </div>
    <div class="m-b-20"></div>
    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>