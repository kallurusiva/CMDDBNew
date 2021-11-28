<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dt_User_Login.aspx.cs" Inherits="O_dt_User_Login" %>
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
        <div class="container-fluid" runat="server">
            <div class="row" runat="server">
                <div class="col-md-9 col-md-push-3" runat="server">
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
                                <asp:TextBox ID="txtUserName"  CssClass="form-control" runat="server" ToolTip="Enter LoginID"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="input-password">Password</label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"  TextMode="Password" ToolTip="Enter Password"></asp:TextBox>
                            </div>
                            <a class="float-left" id="Nreg" runat="server" href="O_dt_User_Registration.aspx">New User? Register here </a>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                            
                            <a class="float-right" href="O_dt_User_ForgotPassword.aspx">Forgot password?</a>
                            <div class="clearfix"></div>                            
                            <asp:Button ID="btnLogin" CssClass="button -blue center" runat="server" Text="Login" onclick="btnLogin_Click" ValidationGroup="vgCheck" Width="90px" />
                        </form>
                    </div>
                </div>       
        </div>
                </div>

                

                <div class="mb30 visible-sm visible-xs clearfix" runat="server"></div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>            
        </div>
        <div class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                
</asp:Content>

