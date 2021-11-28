<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_User_Topup.aspx.cs" Inherits="N_User_Topup" %>
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

                            <div class="mb40 visible-xs"></div>
                            <div class="col-sm-12">
                                <h2>Topup with PIN</h2>

                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Registration Date</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblRegDate" Text="" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Last Toup Date</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblTppDate" Text="" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Enter Topup PIN</b></td>
                                                <td class="">
                                                    <asp:TextBox ID="txtPIN" runat="server" CssClass="txtBlackSmall" MaxLength="60" Text="" Width="186px" ValidationGroup="VgCheck"></asp:TextBox></br>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="ValAlert_Error"  ValidationGroup="VgCheck" runat="server" ControlToValidate="txtPIN" ErrorMessage="Please enter Topup PIN." Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ValidationGroup="VgCheck" ValidationExpression="^[0-9]*$" ErrorMessage="Invalid Topup PIN. Numeric only." Display="Dynamic" ControlToValidate="txtPIN" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                        </tbody>

                                    </table>
                                </div>
                            </div>
                        </div>
                   
                  <div class="row">
                            <div class="col-xs-12 col-lg-12">

                                <div class="text-right">

                                    <%--<a href="#" class="btn btn-custom min-width">Buy Now</a>--%>
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Topup Now" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>



                </div>
    </div>
    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>