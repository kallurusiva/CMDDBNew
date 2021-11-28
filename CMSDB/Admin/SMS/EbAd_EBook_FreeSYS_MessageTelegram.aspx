<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_EBook_FreeSYS_MessageTelegram.aspx.cs" Inherits="Admin_SMS_EbAd_EBook_FreeSYS_MessageTelegram" %>
<%@ Register src="~/Admin/EBLeftMenu_Marketing.ascx" tagname="EBLeftMenu_Marketing" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.FontNoteRed               {FONT-SIZE: 11px; COLOR: #EC6D3B; FONT-FAMILY: Arial, Helvetica, sans-serif;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_Marketing ID="EBLeftMenu_Marketing1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
<form id="tForm" runat="server">

<script language="javascript" type="text/javascript">
    
    
</script>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; Send Telegram Message </td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:PlaceHolder ID="tblSendSMS" runat="server">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="20%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="15%">
                            &nbsp;</td>
                    </tr>
                            
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Merchant Code : </td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelMerchantCodeVal" runat="server" CssClass="SearchLabelBold" 
                                Text=""/>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            SMS Balance :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelSMSBalanceVal" runat="server" CssClass="SearchLabelBold" 
                                Text=""/>
                            &nbsp;SMS Credits</td>
                        <td  align="left" class="tblFormText1">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Charges Applied :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="lblCharges" runat="server" CssClass="SearchLabelBold" 
                                Text=""/>
                            &nbsp;SMS Credits</td>
                        <td  align="left" class="tblFormText1">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            <span class="font_12Msg_Error">*</span> Report Name : </td>
                        <td class="tblFormText1" align="left">                              
                              <asp:TextBox ID="txtReportName" runat="server" CssClass="stdTextField1"  MaxLength="25"/>&nbsp;
                              <asp:RequiredFieldValidator ID="rfvReportName" runat="server" ErrorMessage="Enter Report Name " ControlToValidate="txtReportName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="VgCheck"/>
                              <asp:RegularExpressionValidator ID="revReportName" ValidationExpression="[a-zA-Z0-9_ ]{1,25}" runat="server" ErrorMessage="Only alphabet or numeric and space,underscore is allowed"  SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtReportName" ValidationGroup="VgCheck"/>
                              <br />                              
                              <asp:Label ID="LabelReportName" runat="server" CssClass="FontNoteRed" Text="Report Name is a reference name that you can create for each SMS transaction that has been sent out.<br/>Therefore you can use Report Name as key while searching SMS Report"/> 
                          

                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            <span class="font_12Msg_Error">*</span> Send Mobile To : </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="TextBoxMobileList" runat="server" CssClass="stdTextArea1" TextMode="MultiLine" Rows="4" Width="421px" Enabled="false" />
                            <br />
                            <asp:RequiredFieldValidator ID="rfvMobile1" runat="server" ErrorMessage="Enter Mobile Numbers"  ControlToValidate="TextBoxMobileList" Display="Dynamic" SetFocusOnError="true" ValidationGroup="VgCheck"/>                
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" > <span class="font_12Msg_Error">*</span> Message :</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;<asp:TextBox ID="TextBoxReplyMsg" runat="server" CssClass="stdTextArea1" TextMode="MultiLine" Rows="8" MaxLength="150" 
                        Width="421px" Text="" Height="134px"/>    
                        <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Message"  ControlToValidate="TextBoxReplyMsg" Display="Dynamic" SetFocusOnError="true" ValidationGroup="VgCheck"/>                             
                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="BtSendSMS" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Send to Telegram" onclick="btnSave_Click" />
                                <asp:Button ID="BtSaveContinue" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Confirm and Continue" onclick="btnSaveContinue_Click" Visible="false" />
                                </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                     &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="tblConfirmSMS" runat="server" Visible="false">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="25%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="15%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Message </td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelMsgFormatVal" runat="server" Text="Msg" CssClass="SearchLabelBold"/>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>                    
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Total Mobile Count </td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelMobileCountVal" runat="server" Text="1" CssClass=""/>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Credit Charges per Mobile </td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelMsgScheduleChgVal" runat="server" Text="" CssClass=""/>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Total Credit Charges </td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelTotalMessageCdtChgsVal" runat="server" Text="" CssClass=""/>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="Button1" runat="server" CssClass="stdbuttonCRUD" 
                                Text="Send ti Telegram Now" onclick="btnSendNow_Click" />
                                <asp:Button ID="Button2" runat="server" CssClass="stdbuttonCRUD" 
                                Text="Back to Message" onclick="btnBackMsg_Click" />
                                </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                 </table>
                 
                </asp:PlaceHolder>
            </td>
        </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:HiddenField ID="hdn_AlertName" runat="server" value="0"/>
    <asp:HiddenField ID="hdnPRM_ID" runat="server" value=""/>
    <asp:HiddenField ID="hdnMsg_Count" Value="" runat="server" />
    <asp:HiddenField ID="hdnHistID" Value="" runat="server" />
    <asp:HiddenField ID="hdnMobileCount" Value="" runat="server" />
    <asp:HiddenField ID="hdnCharges" Value="" runat="server" />
    <asp:HiddenField ID="hdnBalance" Value="" runat="server" />
    <asp:HiddenField ID="hdnMobiles" Value="" runat="server" />
    <asp:HiddenField ID="hdnReportName" Value="" runat="server" />
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>


