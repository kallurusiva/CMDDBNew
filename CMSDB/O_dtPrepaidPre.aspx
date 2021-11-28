<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtPrepaidPre.aspx.cs" Inherits="O_dtPrepaidPre" %>
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

                            <div class="mb40 visible-xs"></div>
                            <div class="col-sm-12">
                                <h2>Prepaid Purchase Form</h2>

                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Products Selected</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Products Selected</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblTotalItems" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Total Amount</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblAmtCurrency" runat="server"></asp:Label> &nbsp; 
                                                  <asp:Label ID="lbltotalAmount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Prepaid LoginId</b></td>
                                                <td class="">
                                                    <asp:Literal runat="server" ID="txtPrepaidLogin" Text=""></asp:Literal>
                                                     <%--<asp:TextBox ID="txtPrepaidLogin" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPrepaidLogin" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Prepaid Login cannot be Empty"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Your Current Prepaid Points</b></td>
                                                <td class="">
                                                    <asp:Literal runat="server" ID="txtPrepaidPoints" Text=""></asp:Literal>
                                                     <%--<asp:TextBox ID="txtPrepaidLogin" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPrepaidLogin" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Prepaid Login cannot be Empty"></asp:RequiredFieldValidator>--%>
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
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="btn btn-custom min-width" Text="Confirm Purchase" OnClick="BtnSubmit_Click" />
                                    <%--<asp:HyperLink ID="hypUser"  NavigateUrl="http://183.81.165.110/webapps/esmsuser/ebookuser.aspx" runat="server" Target="_blank" CssClass="btn btn-custom min-width" Visible="false">Prepaid User Login</asp:HyperLink>--%>
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
