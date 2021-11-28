﻿<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtPaypalConfirm.aspx.cs" Inherits="O_dtPaypalConfirm" %>
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

        <span style="color: #CC0000"><strong>Please wait, we are redirecting you to Credit Card Payment.

    </strong></span>

    <div class="main" runat="server">
        <div class="container-fluid" runat="server" visible="false">
            <div class="row" runat="server">
                <div class="col-md-9 col-md-push-3" >
                    <div class="row">

                            <div class="mb40 visible-xs"></div>
                            <div class="col-sm-12">
                                <h2>Checkout Submission Form</h2>

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
                                                <td class="bg-custom" style="width: 368px"><b>Enter Name</b></td>
                                                <td class="">
                                                    <asp:TextBox ID="txtBuyerName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="VgCheck" ControlToValidate="txtBuyerName" CssClass="text-custom" ErrorMessage="Name cannot be Empty"></asp:RequiredFieldValidator>
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Please enter your vendor email ID...">--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Enter Email Address*</b></td>
                                                <td class="">
                                                    <asp:TextBox ID="txtBuyerEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="reqValImage" ControlToValidate="txtBuyerEmail" runat="server" ErrorMessage="Enter Email ID." ValidationGroup="VgCheck" Display="Dynamic" CssClass="text-custom"></asp:RequiredFieldValidator>

                                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                  ControlToValidate="txtBuyerEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                  Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Email" ValidationGroup="VgCheck" 
                                                  SetFocusOnError="True" CssClass="text-custom"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Enter Mobile Number</b></td>
                                                <td>
                                                    <asp:TextBox ID="txtBuyerMobile" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                   &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtBuyerMobile" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Mobile No. cannot be Empty"></asp:RequiredFieldValidator>
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

                                    <asp:LinkButton ID="lnkBuyNow" runat="server" CssClass="btn btn-custom min-width" ValidationGroup="VgCheck" OnClick="lnkBuyNow_Click"  OnClientClick="skm_LockScreen('Please wait while we take you to PayPal Site...');"  Visible="false">
                                                       Checkout</asp:LinkButton>
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
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" Visible="false" />
                                                
</asp:Content>
