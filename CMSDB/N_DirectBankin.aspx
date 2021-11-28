<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_DirectBankin.aspx.cs" Inherits="N_DirectBankin" %>
<%@ Register Src="~/N_Footer.ascx" TagPrefix="uc1" TagName="N_Footer" %>
<%--<%@ Register Src="~/N_LeftMenu.ascx" TagPrefix="uc1" TagName="N_LeftMenu" %>--%>
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

   <%-- <uc1:N_LeftMenu runat="server" ID="N_LeftMenu" />--%>

   

                <div class="col-xs-12">

                    <div class="row">
                        <div class="col-xs-12">
                            <h2 class="main-title">Please key in the following details</h2>
                            <div class="m-b-30"></div>
                            <div class="col-xs-12">
                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody>
                                            <tr>
                                                <td class="bg-custom"><b>Enter Name*</b></td>
                                                <td class="">
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Enter your prepaid login ID." required>
                                                    <a href="#"><h6 class="note-bankinform"><span class="text-custom">Validate Login</span></h6></a>--%>

                                                    <asp:TextBox ID="txtcName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="VgCheck" ControlToValidate="txtcName" CssClass="text-custom" ErrorMessage="Name cannot be Empty"></asp:RequiredFieldValidator>
                                                    
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Enter Email*</b></td>
                                                <td class="">
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Please enter your Prepaid password..." required>--%>
                                                    <asp:TextBox ID="txtcEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="reqValImage" ControlToValidate="txtcEmail" runat="server" ErrorMessage="Enter Email ID." ValidationGroup="VgCheck" Display="Dynamic" CssClass="text-custom"></asp:RequiredFieldValidator>

                                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                  ControlToValidate="txtcEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                  Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Email" ValidationGroup="VgCheck" 
                                                  SetFocusOnError="True" CssClass="text-custom"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Enter Mobile Number</b></td>
                                                <td>
                                                    <asp:TextBox ID="txtcMobile" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                   &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtcMobile" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Mobile No. cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom"><b>Selected Items</b></td>
                                                <td class="">
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <div class="book-detail-bankin">
                                                                <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom"><b>Total Items</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblTotalItems" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom"><b>Total Amount</b></td>
                                                <td class="">
                                                    <span class="text-custom4">
                                                    <asp:Label ID="lblAmtCurrency" runat="server"></asp:Label> &nbsp; 
                                                   <asp:Label ID="lbltotalAmount" runat="server"></asp:Label></span>
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
                            <div class="text-left">
                                <%--<asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Continue to Purchase" OnClick="BtnSubmit_Click" />--%>
                                </div>
                            <div class="text-right">
                                <%--<a href="#" class="button -blue center">Continue to Purchase</a>--%>
                                
                                <%--<asp:HyperLink ID="hypUser"  NavigateUrl="http://183.81.165.110/webapps/esmsuser/ebookuser.aspx" runat="server" Target="_blank" CssClass="button -blue center" Visible="true">Prepaid User Login</asp:HyperLink>--%>
                            </div>
                        </div>
                    </div>




                    <div class="row">
                        <div class="col-xs-12 col-lg-12">
                            <div class="float-left">
                                <div class="text-left">
                                    <%--<asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Continue to Purchase" OnClick="BtnSubmit_Click" />--%>
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Continue to Direct Bank-In" OnClick="BtnSubmit_Click" />
                                </div>
                            </div>
                            
                        </div>
                    </div>



                </div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>