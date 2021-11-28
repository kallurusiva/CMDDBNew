<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_User_CreditInfo.aspx.cs" Inherits="N_User_CreditInfo" %>
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


                <div class="col-xs-12">

                    <div class="row">
                        <div class="col-xs-12">
                            <h2 class="main-title">Prepaid Credits Info</h2>
                            <div class="m-b-30"></div>
                            <div class="col-xs-12">
                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody>
                                            <tr>
                                                <td class="bg-custom"><b>Registerd On</b></td>
                                                <td class="">
                                                    <asp:Literal runat="server" ID="lblRegDate" Text=""></asp:Literal></td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Credits Left</b></td>
                                                <td class="">
                                                    <asp:Literal runat="server" ID="lblCreditLeft" Text=""></asp:Literal></td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Credits Used</b></td>
                                                <td class="">
                                                   <asp:Literal runat="server" ID="lblCreditUsed" Text=""></asp:Literal>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Topup Contact</b></td>
                                                <td class="">
                                                   <asp:Literal runat="server" ID="lblTopupContact" Text=""></asp:Literal>
                                                    <br />
                                                    <asp:Literal runat="server" ID="lblTopupName" Text=""></asp:Literal>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom">&nbsp;</td>
                                                <td class="">
                                                    &nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom">&nbsp;</td>
                                                <td class="">
                                                    &nbsp;</td>
                                            </tr>                                            
                                        </tbody>

                                    </table>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>
    </div>
    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>