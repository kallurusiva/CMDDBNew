<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_EBook_CreateList_BookCode_SMS_FreeSYS.aspx.cs" Inherits="Admin_SMS_EbAd_EBook_CreateList_BookCode_SMS_FreeSYS" %>
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
    function OnKeyStringCount(t) {
        var ddlLanguage = document.getElementById('<%=ddlMessageLang.ClientID%>');
        var Language = ddlLanguage.options[ddlLanguage.selectedIndex].value;

        if (Language == "C") {
            document.getElementById("<%=hdnMsgCharLen.ClientID%>").value = document.getElementById("<%=hdnMsgCharLenChi.ClientID%>").value;
            document.getElementById("<%=hdnMSG_StdMaxLen.ClientID%>").value = document.getElementById("<%=hdnMSG_StdChiMaxLen.ClientID%>").value;
        }

        var Msglen = document.getElementById("<%=hdnMsgCharLen.ClientID%>").value;
        var MsgStdlen = document.getElementById("<%=hdnMSG_StdMaxLen.ClientID%>").value;

        var TextBoxReplyMsg = document.getElementById('<%=TextBoxReplyMsg.ClientID%>').value;
        var iCurrent_Msg_CharLen = parseInt(TextBoxReplyMsg.length);
        var iTotalSMS2Len = parseInt(MsgStdlen) * 2;
        var iTotalSMS3Len = parseInt(MsgStdlen) * 3;

        var TotalSMSCount = 0;

        if ((iCurrent_Msg_CharLen > 0) && (iCurrent_Msg_CharLen <= MsgStdlen)) {
            TotalSMSCount = 1;
        }
        else if ((iCurrent_Msg_CharLen > MsgStdlen) && (iCurrent_Msg_CharLen <= parseInt(iTotalSMS2Len))) {
            TotalSMSCount = 2;
        }
        else if ((iCurrent_Msg_CharLen > parseInt(iTotalSMS2Len)) && (iCurrent_Msg_CharLen <= parseInt(iTotalSMS3Len))) {
            TotalSMSCount = 3;
        }
        else if ((iCurrent_Msg_CharLen > parseInt(iTotalSMS3Len)) && (iCurrent_Msg_CharLen <= Msglen)) {
            TotalSMSCount = 4;
        }
        else {
            document.getElementById('<%=TextBoxReplyMsg.ClientID%>').value = document.getElementById('<%=TextBoxReplyMsg.ClientID%>').value.substr(0, parseInt(Msglen));
        }

    document.getElementById("<%=TextBoxTotalLen.ClientID%>").value = iCurrent_Msg_CharLen;
        document.getElementById("<%=TextBoxReplyMsgCount1.ClientID%>").value = TotalSMSCount;
        document.getElementById("<%=hdnMsg_Count.ClientID%>").value = TotalSMSCount;

    }
    function OnChangeLanguage(v) {
        OnKeyStringCount(document.getElementById('<%=TextBoxReplyMsg.ClientID%>').value);
    }
    function SetCursorToTextEnd(textControlID) {
        var text = document.getElementById(textControlID);
        if (text != null && text.value.length > 0) {
            if (text.createTextRange) {
                var FieldRange = text.createTextRange();
                FieldRange.moveStart('character', text.value.length);
                FieldRange.collapse();
                FieldRange.select();
            }
        }
    }
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
                            &nbsp; Send SMS </td>
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
                            Sender Mobile ID : </td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelSenderIDVal" runat="server" CssClass="SearchLabelBold" 
                                Text=''/>&nbsp;
                <asp:Label ID="LabelSenderIDMsg" runat="server" CssClass="FontNoteRed" Text="Note: will always take latest sender id on the schedule date."/>
                </td>
                        <td align="left" class="tblFormText1">
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
                            <%--<asp:RegularExpressionValidator ID="revMobile1" runat="server" ErrorMessage="Multiple Mobile Numbers Separated by Comma ','" ControlToValidate="TextBoxMobileList" ValidationExpression="^([1-9]{1}[0-9]{6,12})(,[1-9]{1}[0-9]{6,14})*" SetFocusOnError="true" Display="Dynamic" ValidationGroup="VgCheck"/>--%>                        
                            <asp:CustomValidator ID="ctvMobile1" runat="server" ErrorMessage="Only 5000 Mobile Numbers Allowed" ControlToValidate="TextBoxMobileList" Display="Dynamic" SetFocusOnError="true" onservervalidate="ctvMobile1_ServerValidate" ValidationGroup="VgCheck"/>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            <span class="font_12Msg_Error">*</span> Message Language : </td>
                        <td class="tblFormText1" align="left">
                            <asp:DropDownList ID="ddlMessageLang" runat="server" CssClass="stdDropDown" 
                                onselectedindexchanged="ddlMessageLang_SelectedIndexChanged" 
                                AutoPostBack="true" ValidationGroup="VgCheck">
                    <asp:ListItem Text="(Text) English" Value="E" />
                    <asp:ListItem Text="(Unicode) Chinese" Value="C"/>
                    </asp:DropDownList></td>
                        <td class="tblFormText1" align="left">
                            <%--<asp:RadioButtonList ID="rdoFeatured" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="30">
                                <asp:ListItem Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False" Selected="True">NO</asp:ListItem>
                            </asp:RadioButtonList>--%>
                         </td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" > <span class="font_12Msg_Error">*</span> Message :</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;<asp:TextBox ID="TextBoxReplyMsg" runat="server" CssClass="stdTextArea1" TextMode="MultiLine" Rows="8" MaxLength="150" 
                        Width="421px" Text="" Height="134px"/>
                        <br />
                    <asp:RequiredFieldValidator ID="refReplyMsg" runat="server" ErrorMessage="Enter Message" ControlToValidate="TextBoxReplyMsg" SetFocusOnError="true" Display="Dynamic" ValidationGroup="VgCheck" />
                    <asp:RegularExpressionValidator ID="revReplyMsg" Display="Dynamic" SetFocusOnError="true" ControlToValidate="TextBoxReplyMsg" ValidationExpression = "^[\s\S]" runat="server" ErrorMessage="Maximum 97 characters allowed." ValidationGroup="VgCheck"/> 
                    <br />
                    <asp:TextBox ID="TextBoxTotalLen" runat="server" CssClass="stdTextField1" Width="40px" 
                                Enabled="false"/>
                    &nbsp;<asp:Label ID="LabelCharMsglength" Text="Chars" runat="server" CssClass="" />                       
                    &nbsp;<asp:TextBox ID="TextBoxReplyMsgCount1" runat="server" CssClass="stdTextField1" 
                                Width="30px" Enabled="false"/>
                    &nbsp;&nbsp;<asp:Label ID="LabelMsgCount1" Text="SMS" runat="server" CssClass="" /> 
                    <asp:HiddenField ID="TextBoxReplyMsgLength" runat="server"/>     
                    <br />
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
                                Text="Send SMS" onclick="btnSave_Click" />
                                <asp:Button ID="BtSaveContinue" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Confirm and Continue" onclick="btnSaveContinue_Click" Visible="false" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD" 
                                Text="Cancel" onclick="btnCancel_Click" />
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
                            Total Message Count </td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelTotalCountVal" runat="server" Text="MsgCount" CssClass=""/>
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
                            Message Type</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelMsgLanguageVal" runat="server" Text="English" CssClass=""/>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Sender ID</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelMsgSenderIDVal" runat="server" Text="" CssClass=""/>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Message Type</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="Label1" runat="server" Text="English" CssClass=""/>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Normal SMS Credit Charges </td>
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
                            Total SMS Credit Charges </td>
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
                                Text="Send SMS Now" onclick="btnSendNow_Click" />
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
    <asp:HiddenField ID="hdnPersonaliseCharlen" Value="" runat="server" />  
      
    <asp:HiddenField ID="hdnMsgCharLen" Value="" runat="server" />
    <asp:HiddenField ID="hdnMsgCharLenChi" Value="" runat="server" />
    <asp:HiddenField ID="hdnMsgCharLenEng" Value="" runat="server" />
  
    
    <asp:HiddenField ID="hdnMSG_StdMaxLen" Value="" runat="server" />
    <asp:HiddenField ID="hdnMSG_StdEngMaxLen" Value="" runat="server" />
    <asp:HiddenField ID="hdnMSG_StdChiMaxLen" Value="" runat="server" />
  
    <asp:HiddenField ID="hdnMsg_Count" Value="" runat="server" />
    <asp:HiddenField ID="hdnHistID" Value="" runat="server" />
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>


