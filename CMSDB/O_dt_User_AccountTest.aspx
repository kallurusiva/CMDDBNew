<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dt_User_AccountTest.aspx.cs" Inherits="O_dt_User_AccountTest" %>
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
                    <div class="top-filter-container clearfix" runat="server" id="dvRepeaterPages">
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
                                                    <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Email</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>&nbsp;
                                                    <asp:Label ID="lblVEStatus" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Full Name</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>&nbsp;
                                                    <asp:LinkButton runat="server" ID="lnkEmailVerification" OnClick="lnkEmailVerification_Click" >Click here to resend Email Vertification</asp:LinkButton>

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
                    </div>
                    <div class="row">
                            <div class="col-xs-12 col-lg-12">

                                <div class="text-right">

                                    <%--<a href="#" class="btn btn-custom min-width">Buy Now</a>--%>
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="btn btn-custom min-width" Text="Edit Profile" OnClick="btnSave_Click" />
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
