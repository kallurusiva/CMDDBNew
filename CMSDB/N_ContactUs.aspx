<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_ContactUs.aspx.cs" Inherits="N_ContactUs" %>
<%@ Register Src="~/N_Footer.ascx" TagPrefix="uc1" TagName="N_Footer" %>
<%--<%@ Register Src="~/N_LeftMenu.ascx" TagPrefix="uc1" TagName="N_LeftMenu" %>--%>
<%@ Register Src="~/N_TopMenu.ascx" TagPrefix="uc1" TagName="N_TopMenu" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 447px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:N_TopMenu runat="server" ID="N_TopMenu" />
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

   <%-- <uc1:N_LeftMenu runat="server" ID="N_LeftMenu" />--%>

   

                <div class="col-xs-12">
                            <h2 class="main-title">Contact Us</h2>
                            <div class="row contact-info">
                                <div class="col-xs-6 col-xs-offset-2">
                                    <div id ="dvName" class="name" runat="server">
                                        <strong><i class="fa fa-user" aria-hidden="true"></i> Name</strong>
                                        <address>
                                            <asp:Literal ID="LtrCompanyName" Text="" runat="server"></asp:Literal>
                                      </address>
                                        <address>
                                            <asp:Literal ID="LtrNickName" Text="" runat="server"></asp:Literal>
                                      </address>
                                    </div>
                                    <div id="dvAddress" class="address-detail" runat="server"><strong><i class="fa fa-home" aria-hidden="true"></i> Address</strong>
                                        <address>
                                        <asp:Literal ID="LtrAddress" Text="" runat="server"></asp:Literal>
                                      </address>
                                    </div>
                                    <div class="telephone" id="dvTelephone" runat="server">
                                        <strong><i class="fa fa-phone" aria-hidden="true"></i> Telephone</strong>
                                        <address><asp:Literal ID="ltrHomephone" Text="" runat="server"></asp:Literal></address>
                                    </div>
                                    <div class="telephone" id="dvMobile" runat="server">
                                        <strong><i class="fa fa-phone" aria-hidden="true"></i> Moblie</strong>
                                        <address><asp:Literal ID="LtrHandPhone" Text="" runat="server"></asp:Literal></address>
                                    </div>
                                    <div class="telephone" id="dvFax" runat="server">
                                        <strong><i class="fa fa-phone" aria-hidden="true"></i> Fax</strong>
                                        <address><asp:Literal ID="ltrFaxNo" Text="" runat="server"></asp:Literal></address>
                                    </div>
                                    <div class="fax"  runat="server" id="dvEmail">
                                        <strong><i class="fa fa-envelope" aria-hidden="true"></i> Email</strong>
                                        <address><asp:Literal ID="ltrEmail" Text="" runat="server"></asp:Literal></address>
                                    </div>
                                </div>
                                <div class="col-xs-4">
                                    <%--<img src="img/logo.jpg" alt="">--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="table-responsive">
                                        <table class="table table-bordered bankinform-table">
                                            <tbody>
                                                <tr>
                                                    <td class="auto-style1"><b>Name</b></td>
                                                    <td class="">
                                                        <%--<input class="form-control input-sm" type="text" placeholder="Please enter your vendor name">--%>
                                                        <asp:TextBox ID="txtName" CssClass="form-control input-sm" runat="server" Text=""></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  CssClass="fa fa-user"
                                                          ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Please enter name" 
                                                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1"><b>Mobile No.</b></td>
                                                    <td class="">
                                                        <%--<input class="form-control input-sm required" type="text" placeholder="Please enter your mobile no ...">--%>
                                                        <asp:TextBox ID="txtContactNo" CssClass="form-control input-sm required" runat="server"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                              ControlToValidate="txtContactNo" Display="Dynamic" 
                                                              ErrorMessage="Please enter ContactNo" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1"><b>Email</b></td>
                                                    <td>
                                                        <%--<input class="form-control input-sm required" type="email" placeholder="Please enter your email...">--%>
                                                        <asp:TextBox ID="txtEmail" CssClass="form-control input-sm required" runat="server"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                              ControlToValidate="txtEmail" Display="Dynamic" 
                                                              ErrorMessage="Please enter email." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                          ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                          Display="Dynamic" runat="server" ErrorMessage="*  Enter a Valid Email" ValidationGroup="VgCheck" 
                                                          SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1"><b>Country</b></td>
                                                    <td>
                                                        <asp:DropDownList ID="DdlCountry" CssClass="form-control input-sm" runat="server"></asp:DropDownList>

                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1"><b>Subject</b></td>
                                                    <td>
                                                        <%--<input class="form-control input-sm" type="text" placeholder="Subject...">--%>
                                                        <asp:TextBox ID="txtSubject" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                              ControlToValidate="txtSubject" Display="Dynamic" 
                                                              ErrorMessage="Please enter Subject" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1"><b>Message</b></td>
                                                    <td>
                                                        <%--<textarea class="form-control" rows="6" placeholder="Description..."></textarea>--%>
                                                        <asp:TextBox ID="txtMessage" 
                                                              CssClass="form-control" runat="server" TextMode="MultiLine" Height="115px" Width="781px"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                              ControlToValidate="txtMessage" Display="Dynamic" 
                                                              ErrorMessage="Please enter Message." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1"><b>Security code (Enter 12341234  or  12451245  or  12351235)</b></td>
                                                    <td>
                                                        <%--<textarea class="form-control" rows="6" placeholder="Description..."></textarea>--%>
                                                        <asp:TextBox ID="txtSecurity" 
                                                              CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                              ControlToValidate="txtSecurity" Display="Dynamic" 
                                                              ErrorMessage="Please enter Security code" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </tbody>

                                        </table>
                                    </div>

                                    <div class="row">
                                        <div class="col-xs-12 col-lg-12">

                                            <div class="text-right">

                                                <%--<a href="#" class="button -blue center">Send</a>--%>
                                                <asp:Button ID="btnSubmit"  CssClass="button -blue center" runat="server" Text="SEND" OnClick="btnSubmit_Click"  ValidationGroup="VgCheck" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>