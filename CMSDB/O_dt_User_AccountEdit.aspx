<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dt_User_AccountEdit.aspx.cs" Inherits="O_dt_User_AccountEdit" %>
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

    <asp:FormView ID="FormView1" runat="server" Width="95%" Visible="true" ondatabound="FormView1_DataBound" onmodechanging="FormView1_ModeChanging">
        <EditItemTemplate>
    <div class="main" runat="server">     
        <div class="container-fluid" runat="server">
            <div class="row" runat="server">
                <div class="col-md-9 col-md-push-3" runat="server">
                    <div class="top-filter-container clearfix" runat="server" id="dvRepeaterPages">
                        <div class="row">

                            <div class="mb40 visible-xs"></div>
                            <div class="col-sm-12">
                                <h2>Edit Profile</h2>

                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Mobile</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblMobile" runat="server" Text='<% # Bind("Mobile") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Email</b></td>
                                                <td class="">
                                                    <asp:Label ID="Label1" runat="server" Text='<% # Bind("Email") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Full Name (*)</b></td>
                                                <td class="">                                                                                            
                                                 <asp:TextBox runat="server" ID="lblFullName" ValidationGroup="VgCheck" Text='<% # Bind("FullName") %>' Height="17px" Width="254px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lblFullName" CssClass="ValAlert_Error" Display="Dynamic" ErrorMessage="Please enter FullName." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="lblFullName" Display="Dynamic" ErrorMessage="Invalid Full Name. Accepts Alphabets and space only." SetFocusOnError="True" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="VgCheck"></asp:RegularExpressionValidator>
                                                                                           
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Address</b></td>
                                                <td class="">
                                                    <asp:TextBox TextMode="MultiLine" runat="server" ID="lblAddress" Text='<% # Bind("Address") %>' Height="49px" Width="256px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Country (*)</b></td>
                                                <td class="">
                                                    <asp:TextBox runat="server" ID="lblCountry" Text='<% # Bind("Country") %>' Height="16px" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lblCountry" CssClass="ValAlert_Error" Display="Dynamic" ErrorMessage="Please enter Country." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="lblCountry" Display="Dynamic" ErrorMessage="Invalid Country. Accepts Alphabets and space only." SetFocusOnError="True" ValidationExpression="^[a-zA-Z \s]{3,50}$" ValidationGroup="VgCheck"></asp:RegularExpressionValidator>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>State</b></td>
                                                <td class="">
                                                    <asp:TextBox runat="server" ID="lblState" Text='<% # Bind("State") %>' Height="16px" Width="246px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>City</b></td>
                                                <td class="">
                                                    <asp:TextBox runat="server" ID="lblCity" Text='<% # Bind("City") %>' Height="16px" Width="248px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Zip</b></td>
                                                <td class="">
                                                    <asp:TextBox runat="server" ID="lblZip" Text='<% # Bind("Zip") %>' Width="245px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Telephone</b></td>
                                                <td class="">
                                                    <asp:TextBox runat="server" ID="lblTelephone" Text='<% # Bind("Telephone") %>' Height="16px" Width="243px"></asp:TextBox>
                                                </td>
                                            </tr>                                           
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Fax</b></td>
                                                <td class="">
                                                    <asp:TextBox runat="server" ID="lblFax" Text='<% # Bind("Fax") %>' Height="16px" Width="239px"></asp:TextBox>
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
    </EditItemTemplate>
        <ItemTemplate>

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
                                                <td class="bg-custom" style="width: 368px"><b>Verified Email</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Full Name</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>
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
    </ItemTemplate>
        </asp:FormView>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                
</asp:Content>
