<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtPrepaidPreNew.aspx.cs" Inherits="O_dtPrepaidPreNew" %>
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
                                                <td class="bg-custom" style="width: 368px"><b>Prepaid PIN</b></td>
                                                <td class="">                                                   
                                                     <asp:TextBox ID="txtPIN" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPrepaidLogin" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Prepaid Login cannot be Empty"></asp:RequiredFieldValidator>
                                                   
                                                  &nbsp;&nbsp;
                                                   
                                                  <asp:LinkButton ID="LnkBtnValidatePIN" runat="server" OnClick="LnkBtnValidatePIN_Click" Text="Validate PIN" CssClass="btn btn-custom min-width">
                    
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Prepaid LoginId</b></td>
                                                <td class="">                                                   
                                                     <asp:TextBox ID="txtPrepaidLogin" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPrepaidLogin" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Prepaid Login cannot be Empty"></asp:RequiredFieldValidator>
                                                    &nbsp;<asp:LinkButton ID="LinkBtnValidateLogin" runat="server" OnClick="LnkBtnValidateLogin_Click" Text="Validate Login" CssClass="btn btn-custom min-width">
                    
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Password</b></td>
                                                <td class="">
                                                     <asp:TextBox ID="txtPrepaidPassword" TextMode="Password" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPrepaidPassword" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Prepaid Password cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                             <tr>
                                                <td class="bg-custom" style="width: 368px"><b>FullName</b></td>
                                                <td class="">
                                                     <asp:TextBox ID="txtcName" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtcName" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Full Name cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                             <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Mobile</b></td>
                                                <td class="">
                                                     <asp:TextBox ID="txtcMobile" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtcMobile" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Mobile cannot be Empty"></asp:RequiredFieldValidator>

                                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" CssClass="text-custom" 
                          runat="server" ValidationExpression="^[1-9]\d*$" ControlToValidate="txtcMobile" ValidationGroup="VgCheck" 
                          ErrorMessage=" <br/>Invalid Mobile No. format. <br/>Cannot start with zero or (+) Plus sign. <br/>Format : Input prefixed with country code e.g. 60169664566"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>

                                             <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Email</b></td>
                                                <td class="">
                                                      <asp:TextBox ID="txtcEmail" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtcEmail" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Email cannot be Empty"></asp:RequiredFieldValidator>
                                                   <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="VgCheck" SetFocusOnError="true" ControlToValidate="txtcEmail" ErrorMessage="<br/>Enter a Valid Email<br/>Eg:user@domain.com" CssClass="font_11Msg_Error" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"/>
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
                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="btn btn-custom min-width" Text="Continue to Purchase" OnClick="BtnSubmit_Click" />
                                    <asp:HyperLink ID="hypUser"  NavigateUrl="http://183.81.165.110/webapps/esmsuser/ebookuser.aspx" runat="server" Target="_blank" CssClass="btn btn-custom min-width" Visible="false">Prepaid User Login</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                </div>

                <div id="dvInVoice" class="CssdvBookDetails" runat="server" visible="false">    
                        <table class="style1">
                            <tr>
                                <td width="35%">&nbsp;</td>
                                <td  width="65%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="BkFontBHeader">&nbsp;Direct Bank-In Invoice </td>
                                <td class="BkFontBHeader">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDateTime" CssClass="font_12BoldGrey" runat="server"></asp:Label>
                                </td>
                                <td>Transaction ID :
                                    <asp:Label ID="lblTransactionID" CssClass="font_12BlueBold" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;<hr />&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                           <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblInvoiceHeader2" CssClass="font_12BlueBold" runat="server"></asp:Label>
                                </td>
                                
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                             <tr>
                                <td colspan="2" class="HomePageContentFont">
                                   
                                    Thank you for your purchase!.&nbsp; The following is an invoice detailing your transaction details.&nbsp;
                                    <br />
                                    Please print or save a copy of this invoice for your records.
                                    <br />
                                    <br />
                                    For any further queries , please let us know.
                                   
                                </td>
                                
                            </tr>

                             <tr>
                                <td colspan="2">&nbsp;<hr />&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                             <tr>
                                <td colspan="2">




                                    <table class="gridtable">
                                        <tr>
                                            <th width="70%">Description</th>
                                            <th width="30%">Price</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblItemsDesc" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblItemsPrice" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Total : </td>
                                            <td>
                                                <asp:Label ID="lblItemsPriceTotal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>




                                </td>
                                
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>

                                       

                                     

                    </div>

                <div class="mb30 visible-sm visible-xs clearfix" runat="server"></div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>            
        </div>
        <div class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                
</asp:Content>

