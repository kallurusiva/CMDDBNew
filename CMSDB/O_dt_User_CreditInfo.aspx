<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dt_User_CreditInfo.aspx.cs" Inherits="O_dt_User_CreditInfo" %>
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
                            <uc1:O_LeftBlue runat="server" ID="O_LeftBlue1" />
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