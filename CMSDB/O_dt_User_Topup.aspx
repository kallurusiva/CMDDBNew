<%@ Page Language="C#"  MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dt_User_Topup.aspx.cs" Inherits="O_dt_User_Topup" %>
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
                <div class="col-md-9 col-md-push-3" runat="server">
                    <div class="top-filter-container clearfix" runat="server" id="dvRepeaterPages">
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
                    </div>
                    <div class="row">
                            <div class="col-xs-12 col-lg-12">

                                <div class="text-right">

                                    <%--<a href="#" class="btn btn-custom min-width">Buy Now</a>--%>
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="btn btn-custom min-width" Text="Topup Now" OnClick="btnSave_Click" />
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