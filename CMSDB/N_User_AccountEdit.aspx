<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_User_AccountEdit.aspx.cs" Inherits="N_User_AccountEdit" %>
<%@ Register Src="~/N_Footer.ascx" TagPrefix="uc1" TagName="N_Footer" %>
<%@ Register Src="~/N_LeftMenu.ascx" TagPrefix="uc1" TagName="N_LeftMenu" %>
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

    <uc1:N_LeftMenu runat="server" ID="N_LeftMenu" />



        
   <div class="col-xs-9 content-middle">
            <div class="row">
                        <div class="col-xs-12">
                            <div class="cart">
                                <div class="itembox">
                                    <div class="itemcart">
                                        <i class="fa fa-shopping-cart" aria-hidden="true"></i> <span id="value-item" class="value-item"><asp:Literal runat="server" ID="cartItems" Text="0"></asp:Literal></span>Item(s)
                                    </div>
                                    <div class="priceitem">
                                        <i class="fa fa-money" aria-hidden="true"></i> <asp:Literal runat="server" ID="cartCurrency" Text="0"></asp:Literal> <span id="priceitemlist" class="value-item"><asp:Literal runat="server" ID="cartPrice" Text="0"></asp:Literal></span>
                                    </div>
                                    <div class="view-cart">
                                        <a href="N_cart.aspx">View Cart</a>
                                    </div>
                                    <div class="checkout">
                                        <a href="N_cart.aspx">Check Out</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>

            <div class="col-xs-12">
            <asp:FormView ID="FormView1" runat="server" Width="95%" Visible="true" ondatabound="FormView1_DataBound" onmodechanging="FormView1_ModeChanging">

            <EditItemTemplate> 
                        <div class="row">
                            <div class="mb40 visible-xs"></div>
                            <div class="col-xs-12">
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
                  
                        <div class="row">
                            <div class="col-xs-12 col-lg-12">

                                <div class="text-right">

                                    <%--<a href="#" class="btn btn-custom min-width">Buy Now</a>--%>
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Edit Profile" OnClick="btnSave_Click" />
                                </div>
                            </div>
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
                                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
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
                                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Address</b></td>
                                                <td class="">
                                                    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Country</b></td>
                                                <td class="">
                                                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>State</b></td>
                                                <td class="">
                                                    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>City</b></td>
                                                <td class="">
                                                    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Zip</b></td>
                                                <td class="">
                                                    <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Telephone</b></td>
                                                <td class="">
                                                    <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Fax</b></td>
                                                <td class="">
                                                    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>

                                    </table>
                                </div>
    </ItemTemplate>
            </asp:FormView>
           </div>
    </div>

        
        
    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>