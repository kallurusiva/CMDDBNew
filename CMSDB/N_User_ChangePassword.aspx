<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_User_ChangePassword.aspx.cs" Inherits="N_User_ChangePassword" %>
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
                                <h2>Change Password</h2>

                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Enter Current Password</b></td>
                                                <td class="">
                                                    <asp:TextBox ID="txtOLDpwd" runat="server" CssClass="form-control input-sm" MaxLength="12" Text="" Width="339px" ValidationGroup="VgCheck"></asp:TextBox>
                                                                                            <br>                                                                                           
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOLDpwd" CssClass="ValAlert_Error" Display="Dynamic" ErrorMessage="Please enter old Password." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtOLDpwd" Display="Dynamic" ErrorMessage="old Password must be 3 to 12 alphanumeric Chars." SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{3,12}$" ValidationGroup="VgCheck"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Enter New Password</b></td>
                                                <td class="">
                                                    <asp:TextBox  ID="txtNEWpwd" runat="server" CssClass="form-control input-sm" MaxLength="12" Text="" Width="339px" ValidationGroup="VgCheck"></asp:TextBox>
                                                                                            <br>                                                                                            
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNEWpwd" CssClass="ValAlert_Error" Display="Dynamic" ErrorMessage="Please enter new Password." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNEWpwd" Display="Dynamic" ErrorMessage="new Password must be 3 to 12 alphanumeric Chars." SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{3,12}$" ValidationGroup="VgCheck"></asp:RegularExpressionValidator>
                                                                                            
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>ReType New Password</b></td>
                                                <td class="">
                                                    <asp:TextBox  ID="txtNEWpwdC" runat="server" CssClass="form-control input-sm" MaxLength="12" Text="" Width="341px" ValidationGroup="VgCheck"></asp:TextBox>
                                                                                            <br>                                                                                            
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNEWpwdC" CssClass="ValAlert_Error" Display="Dynamic" ErrorMessage="Please enter new Password." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNEWpwdC" Display="Dynamic" ErrorMessage="new Password must be 3 to 12 alphanumeric Chars." SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{3,12}$" ValidationGroup="VgCheck"></asp:RegularExpressionValidator>
                                                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNEWpwdC" ControlToValidate="txtNEWpwd" ErrorMessage="Passwords does not match" Text="Passwords does not match" ValueToCompare="txtNEWpwd"></asp:CompareValidator>
                                                                                            
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
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Change Password Now" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>



                </div>
    </div>
    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>