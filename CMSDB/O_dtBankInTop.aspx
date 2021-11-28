<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtBankInTop.aspx.cs" Inherits="O_dtBankInTop" %>
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
            <div class="row" runat="server" >
                <div class="col-md-9 col-md-push-3" runat="server">
                    <div runat="server" class="row" id="dvBookDetails">
                            <div class="mb40 visible-xs"></div>
                            <div class="col-sm-12">
                                <h2>Bank-In Details Submission Form</h2>
                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Vendor EmailID</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblVendorEmail" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Vendor Mobile</b></td>
                                                <td class="">
                                                    <asp:Label ID="lblVendorMobile" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"></td>
                                                <td class="">
                                                    <span class="text-custom">Note:- Any enquires / difficulties pertaining to purchase, please contact the vendor by mobile or email.</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"></td>
                                                <td class="">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"></td>
                                                <td class="">
                                                    <h6 class="note-bankinform"><span class="text-custom">Please Key In the Transaction Reference Number for easier Tracking, Please fill up the form below :-</span></h6>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px">Transaction Reference ID</td>
                                                <td class="">
                                                    <asp:TextBox ID="txtTransactionID" runat="server" CssClass="form-control input-sm"></asp:TextBox>                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Select Bank</b></td>
                                                <td class="">
                                                    <asp:DropDownList ID="ddlBanks" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBanks_SelectedIndexChanged" ValidationGroup="VgCheck">
                                                   </asp:DropDownList>
                                                   &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlBanks" ValidationGroup="VgCheck" InitialValue="0"  runat="server" CssClass="text-custom"
                                                        ErrorMessage="Please Select a Bank"></asp:RequiredFieldValidator>
                                                  <br />
                                                   <div id="dvSelBankDetails" runat="server" visible="false">
                                                      <asp:Image ID="ImgBank" Height="50" runat="server" />
                                                      <br />
                                                       <asp:Label ID="lblBankActName" CssClass="text-custom" runat="server" Text=""></asp:Label>
                                                      <br />
                                                       <asp:Label ID="lblBankActNo" CssClass="text-custom" runat="server" Text=""></asp:Label>
                                                      <br />
                                                      <asp:Label ID="lblCountry" CssClass="text-custom" runat="server" Text=""></asp:Label>&nbsp; <asp:Image ID="ImgCountryFlag" runat="server" />
                                                      <br />
                                                      <asp:Label ID="lblSwiftCode" CssClass="text-custom" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Full Name</b></td>
                                                <td>
                                                    <asp:TextBox ID="txtBankinBy" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtBankinBy" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Full Name cannot be Empty"></asp:RequiredFieldValidator>                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px">Amount Banked In</td>
                                                <td class="">
                                                    <asp:TextBox ID="txtBankInAmount" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtBankInAmount" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Amount cannot be Empty"></asp:RequiredFieldValidator>                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px">Banked In Date</td>
                                                <td class="">
                                                    <asp:TextBox ID="txtBankInDate" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   <asp:CalendarExtender ID="txtBankInDate_CalendarExtender" runat="server" Enabled="True" PopupPosition="TopRight" TargetControlID="txtBankInDate" TodaysDateFormat="MM/dd/yyyy">
                                                   </asp:CalendarExtender>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtBankInDate" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="BankIn Date cannot be Empty"></asp:RequiredFieldValidator>                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px">Banked In Time</td>
                                                <td class="">
                                                    <asp:TextBox ID="txtBankInTime" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtBankInTime" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="BankIn Time cannot be Empty"></asp:RequiredFieldValidator>                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom" style="width: 368px">Banked In Reference</td>
                                                <td class="">
                                                    <asp:TextBox ID="txtBankInRef" runat="server" CssClass="form-control input-sm"></asp:TextBox>                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom"><b>Upload Bank-in Slip*</b></td>
                                                <td>
                                                    <asp:FileUpload ID="UploadImgCtrl" CssClass="btn btn-custom min-width" runat="server" />
                                                   &nbsp;
                            <asp:Label ID="lblErrorImg" CssClass="font_12Msg_Error" runat="server" Text=""></asp:Label>
                                                   <br />
                            <asp:RegularExpressionValidator ID="FileUploadValidator"  runat="server"  ValidationGroup="VgCheck" Display="Dynamic"
                                ControlToValidate="UploadImgCtrl" ErrorMessage="Only jpg, gif or Png type images are allowed.<br> Please select another image." 
                                ValidationExpression="^.*\.(jpg|JPG|gif|GIF|png|PNG)$" Enabled="true" CssClass="font_11Msg_Error"></asp:RegularExpressionValidator>
                           
                             &nbsp;<asp:CustomValidator ID="CustomValidator_BookImage" runat="server" ControlToValidate="UploadImgCtrl" Display="Dynamic" ValidationGroup="VgCheck"
                                                                    ErrorMessage="" OnServerValidate="CustomVdr_eBookImage_ServerValidate" CssClass="font_11Msg_Error"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg-custom"><b>Purchase Description</b></td>
                                                <td>
                                                    <asp:TextBox ID="txtBankInDesc" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine" ValidationGroup="VgCheck" Width="420px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                              <td>&nbsp;</td>
                                              <td align="right">
                                                  
                                                   <asp:LinkButton ID="lnkPrintForm0" OnClientClick="window.print();"  runat="server">[ Print Form ]</asp:LinkButton>
                                               </td>
                                          </tr>
                                        </tbody>

                                    </table>
                                </div>
                                <div class="mb30 visible-sm visible-xs clearfix" runat="server"></div>                
                            </div>
                    </div>
                    <div class="row">
                            <div class="col-xs-12 col-lg-12">
                                <div class="text-right">
                                    <asp:LinkButton ID="BtnSubmit" runat="server" CssClass="btn btn-custom min-width" ValidationGroup="VgCheck" OnClick="BtnSubmit_Click"  >
                                                       Submit Bank-In Details</asp:LinkButton>
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
                                <td class="BkFontBHeader" colspan="2">&nbsp;Direct Bank-In Invoice </td>
                               
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
                                <td colspan="2">
                                    <asp:Label ID="lblInvoiceHeader2" CssClass="font_12BlueBold" runat="server"></asp:Label>
                                </td>
                                
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                             <tr>
                                <td colspan="2" class="fontDescription">
                                   
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
                                <td colspan="2">




                                    <table class="gridtable" width="80%">
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

                            </table>

                                       

                                     

                    </div>

                </div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>                
            </div>
        <div class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                
</asp:Content>
