<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_cartPrepaidNew.aspx.cs" Inherits="N_cartPrepaidNew" %>
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
                                                <td class="bg-custom"><b>Prepaid PIN*</b></td>
                                                <td class="">

                                                    <asp:TextBox ID="txtPIN" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPrepaidLogin" ValidationGroup="VgCheck"  runat="server" CssClass="note-bankinform" ErrorMessage="Prepaid Login cannot be Empty"></asp:RequiredFieldValidator>
                                                   
                                                  &nbsp;&nbsp;
                                                   
                                                  <asp:LinkButton ID="LnkBtnValidatePIN" runat="server" OnClick="LnkBtnValidatePIN_Click" Text="Validate PIN" CssClass="btn btn-custom min-width">
                    
                                                    </asp:LinkButton>
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Enter your prepaid Pin" required>
                                                    <a href="#"><h6 class="note-bankinform"><span class="text-custom">Validate Pin</span></h6></a>--%>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Prepaid LoginID*</b></td>
                                                <td class="">
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Enter your prepaid login ID." required>
                                                    <a href="#"><h6 class="note-bankinform"><span class="text-custom">Validate Login</span></h6></a>--%>

                                                    <asp:TextBox ID="txtPrepaidLogin" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPrepaidLogin" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Prepaid Login cannot be Empty"></asp:RequiredFieldValidator>
                                                    &nbsp;<asp:LinkButton ID="LinkBtnValidateLogin" runat="server" OnClick="LnkBtnValidateLogin_Click" Text="Validate Login" CssClass="note-bankinform">
                    
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Prepaid Password*</b></td>
                                                <td class="">
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Please enter your Prepaid password..." required>--%>
                                                    <asp:TextBox ID="txtPrepaidPassword" TextMode="Password" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPrepaidPassword" ValidationGroup="VgCheck"  runat="server" CssClass="note-bankinform" ErrorMessage="Prepaid Password cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Full Name*</b></td>
                                                <td class="">
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Please enter your Full name..." required>--%>
                                                    <asp:TextBox ID="txtcName" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtcName" ValidationGroup="VgCheck"  runat="server" CssClass="note-bankinform" ErrorMessage="Full Name cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Mobile*</b></td>
                                                <td class="">
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Please enter your mobile number..." required>--%>
                                                    <asp:TextBox ID="txtcMobile" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtcMobile" ValidationGroup="VgCheck"  runat="server" CssClass="note-bankinform" ErrorMessage="Mobile cannot be Empty"></asp:RequiredFieldValidator>

                                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" CssClass="note-bankinform" 
                          runat="server" ValidationExpression="^[1-9]\d*$" ControlToValidate="txtcMobile" ValidationGroup="VgCheck" 
                          ErrorMessage=" <br/>Invalid Mobile No. format. <br/>Cannot start with zero or (+) Plus sign. <br/>Format : Input prefixed with country code e.g. 60169664566"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="bg-custom"><b>Email*</b></td>
                                                <td class="">
                                                    <%--<input class="form-control input-sm" type="text" placeholder="Please enter your email..." required>--%>
                                                    <asp:TextBox ID="txtcEmail" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtcEmail" ValidationGroup="VgCheck"  runat="server" CssClass="note-bankinform" ErrorMessage="Email cannot be Empty"></asp:RequiredFieldValidator>
                                                   <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="VgCheck" SetFocusOnError="true" ControlToValidate="txtcEmail" ErrorMessage="<br/>Enter a Valid Email<br/>Eg:user@domain.com" CssClass="note-bankinform" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"/>
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
                                
                                <%--<asp:HyperLink ID="hypUser"  NavigateUrl="http://14.102.146.116/webapps/esmsuser/ebookuser.aspx" runat="server" Target="_blank" CssClass="button -blue center" Visible="true">Prepaid User Login</asp:HyperLink>--%>
                            </div>
                        </div>
                    </div>




                    <div class="row">
                        <div class="col-xs-12 col-lg-12">
                            <div class="float-left">
                                <div class="text-left">
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Continue to Purchase" OnClick="BtnSubmit_Click" />
                                </div>
                            </div>
                            <div class="float-right">
                                <div class="text-right">
                                    <asp:HyperLink ID="hypUser"  NavigateUrl="http://14.102.146.116/webapps/esmsuser/ebookuser.aspx" runat="server" Target="_blank" CssClass="button -blue center" Visible="true">Prepaid User Login</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>



                </div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>