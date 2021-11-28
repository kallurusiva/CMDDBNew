<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_User_Account.aspx.cs" Inherits="N_User_Account" %>
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
                                <h2>My Account</h2>

                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>UserID</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblUserID" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Mobile</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label> &nbsp; 
                                                    <asp:Button ID="btnMobile" runat="server" Text="Edit Mobile" CssClass="button -blue center" OnClick="btnMobile_Click"/>
                                                </td> 
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Email</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>&nbsp;
                                                    <asp:Label ID="lblVEStatus" runat="server" ForeColor="Red"></asp:Label><br />
                                                    <asp:LinkButton runat="server" ID="lnkEmailVerification" OnClick="lnkEmailVerification_Click" >Click here to resend Email Vertification</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Full Name</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Address</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Country</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblCountry" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>State</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>City</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Zip</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblZip" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Telephone</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Fax</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblFax" runat="server" Text=""></asp:Label>
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
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Edit Profile" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>



                </div>
    </div>
    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>