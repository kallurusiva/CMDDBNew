<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_SMSTopupPIN.aspx.cs" Inherits="Admin_SMS_EbAd_SMSTopupPIN" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

       .auto-style7 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-left: 20px;
            padding-right: 20px;
            text-align: left;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
<uc1:ebleftmenu_smssystem ID="EBLeftMenu_SMSSystem1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
<form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
      
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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; SMS System : SMS Topup with PIN Number</td>
                        <td width="30%" align="right"> 
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                                <tr>
                                <td width="45%">&nbsp;</td>
                                <td width="2%">&nbsp;</td>
                                <td>&nbsp;</td>
                                </tr>
                                <tr style="height:25px;" >
                                <td class="auto-style7"><asp:Literal ID="ltrTotalCreditSMS" runat="server" Text="Total SMS Credit"></asp:Literal>
                                </td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="lblTotalCreditSMS" runat="server" Text="Jan,2011" /> </td>
                                </tr>
                                <tr style="height:25px;" >
                                <td class="auto-style7"><asp:Literal ID="ltrTotalSMSCdtUsed" runat="server" Text="SMS Credit Used"></asp:Literal>
                                </td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="lblTotalSMSCdtUsed" runat="server" Text="Jan,2011" /> </td>
                                </tr>
                                <tr style="height:25px;" >
                                <td class="auto-style7"><asp:Literal ID="ltrSMSBal" runat="server" Text="SMS Credit Balance"></asp:Literal>
                                </td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="lblSMSCreditUsed" runat="server" Text="Jan,2011" /> </td>
                                </tr>
                                <tr>
                                <td class="auto-style7">
                                <asp:Literal ID="ltrSMSPIN" runat="server" Text="Enter Your Topup SMS Pin Number"></asp:Literal>
                                </td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">
                                &nbsp;<asp:TextBox ID="TextBoxSMSPinNo" runat="server" CssClass="stdTextField1" MaxLength="23"  Width="130px"/>
                                <br />                            
                                <asp:RequiredFieldValidator ID="rfvSMSPinNo" runat="server" SetFocusOnError="true" Display="Dynamic" ControlToValidate="TextBoxSMSPinNo" ErrorMessage="Enter PIN number" />
                                </td>
                                </tr>
                                <tr>
                                <td class="auto-style7" style="height:30px">
                                &nbsp;</td>
                                <td class="tblFormText1" align="left">
                                &nbsp;</td>
                                <td class="tblFormText1" align="left">
                                <asp:Button ID="btnSave" runat="server" CssClass="stdbuttonAction" 
                                Text="Save" onclick="btnSave_Click" /> &nbsp; 
                                <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonAction" 
                                Text="Cancel" onclick="btnCancel_Click" />
                                <%--&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>" />--%>
                                </td>
                                </tr>
                            </table>
            </td>
        </tr>

        </table>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

