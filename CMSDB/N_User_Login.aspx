<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_User_Login.aspx.cs" Inherits="N_User_Login" %>
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
                <h3 class="login-h3" style="text-align:center">Premier eBook Platform, Easy & Fast to Implement Cost Effective, Totally Hassle Free</h3>
                <div class="col-xs-6 col-xs-offset-3">
                    <div class="well">
                        <div class="row">
                            <div class="col-xs-4"> <img src="AssetsNew/img/prepaid.png" alt=""></div>
                            <div class="col-xs-8">
                                <h3 class="text-login"> Ebook User Login</h3>
                            </div>
                        </div>
                        <div class="m-b-30"></div>
                        <form action="#" method="post">
                            <div class="form-group">
                                <label class="control-label" for="input-email">Email (Returning Customer)</label>
                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" ToolTip="Enter LoginID"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="input-password">Password</label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"  TextMode="Password" ToolTip="Enter Password"></asp:TextBox>
                            </div>
                            <a class="float-left" id="Nreg" runat="server" href="N_User_Registration.aspx">New User? Register here </a>
                            <a class="float-right" href="N_User_ForgotPassword.aspx">Forgot password?</a>
                            <div class="clearfix"></div>                            
                            <asp:Button ID="btnLogin" CssClass="button -blue center" runat="server" Text="Login" onclick="btnLogin_Click" ValidationGroup="vgCheck" Width="90px" />
                        </form>
                    </div>
                </div>

            </div>


                </div>
</div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>