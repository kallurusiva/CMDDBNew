<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_User_ForgotPassword.aspx.cs" Inherits="N_User_ForgotPassword" %>
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
           <div class="col-xs-12">

             <div class="row">
                <h3 class="login-h3" style="text-align:center">Premier eBook Platform, Easy & Fast to Implement Cost Effective, Totally Hassle Free</h3>
                <div class="col-xs-6 col-xs-offset-3">
                    <div class="well">
                        <div class="row">
                            <div class="col-xs-4"> <img src="AssetsNew/img/prepaid.png" alt=""></div>
                            <div class="col-xs-8">
                                <h3 class="text-login"> Ebook User Login: Forgot Password</h3>
                            </div>
                        </div>
                        <div class="m-b-30"></div>
                        <form action="#" method="post">
                            <div class="form-group">
                                <label class="control-label" for="input-email">Login ID</label>
                                <asp:TextBox ID="txtPerSecUserID" CssClass="form-control" runat="server" ToolTip="Enter LoginID"></asp:TextBox>
                            </div>                            
                            <a class="float-left" href="N_User_Registration.aspx">New User? Register here </a>
                            <a class="float-right" href="N_User_Login.aspx">Login</a>
                            <div class="clearfix"></div>                            
                            <asp:Button ID="btnLogin" CssClass="button -blue center" runat="server" Text="Send Email" onclick="btnLogin_Click" ValidationGroup="vgCheck" Width="90px" />
                        </form>
                    </div>
                </div>

            </div>


                </div>
</div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>