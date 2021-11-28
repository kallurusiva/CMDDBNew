<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_PaymentRequest.aspx.cs" Inherits="Admin_EbAd_PaymentRequest" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="EBLeftMenu_Profit.ascx" tagname="EBLeftMenu_Profit" tagprefix="uc1" %>
<%@ Register src="EBLeftMenu_SMSPayment.ascx" tagname="EBLeftMenu_SMSPayment" tagprefix="uc2" %>
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
    <uc2:EBLeftMenu_SMSPayment ID="EBLeftMenu_SMSPayment1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form2" runat="server"> 
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
                <table cellpadding="0" cellspacing="0" border="0" width="96%">
                <tr>
                <td align="center">
                     <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                      <tr>
                            <td width="5%" align="left" valign="top">
                                &nbsp;</td>
                            <td width="60%" align="left" class="subHeaderFontGrad">
                                &nbsp; My Payment Request</td>
                            <td width="30%" align="right"> 
                                &nbsp;</td>
                            <td width="5%"  align="right" valign="top">
                                &nbsp;</td>
                        </tr>
                     </table>
                </td>
                </tr>
                <asp:PlaceHolder ID="plholder1" runat="server" Visible="false">
                <tr>                
                <td align="center">
                    <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr style="height:30px;">
                    <td width="1%">&nbsp;</td>
                    <td width="98%" align="left"></td>
                    <td width="1%">&nbsp;</td>
                    </tr>                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>                        
                      <div id="dvWelcomeHeader" style="overflow:hidden; width:820px; min-height: 150px;"  class="ebSummaryBox">        
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <tr>       
                                    <td colspan="3">
                                    <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal2" Text="Payment Request Not Available" runat="server"></asp:Literal>
                                    </div>
                                    </div>
                                    </td>
                                    </tr>                    
                                    <tr style="vertical-align:baseline;">
                                         <td colspan="3" align="center">
                                            <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                                            <tr>
                                                <td width="37%">&nbsp;</td>
                                                <td>  &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="ebFormLabel1">Payment Request Date : </td>
                                                <td class="ebFormText1">  &nbsp;   
                                                    <asp:Label ID="lblPaymentInfo" CssClass="FontDbCount" runat="server" Text="1st - 5th of a month"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  class="ebFormLabel1">Last Payment On : </td>
                                                <td class="ebFormText1">  &nbsp;  
                                                    <asp:Label ID="lblLastPayment" CssClass="FontDbCount" runat="server" Text=""></asp:Label>
                                                 </td>
                                            </tr>
                                             <tr>
                                                <td  class="ebFormLabel1">Balance for Request Payment : </td>
                                                <td class="ebFormText1">  &nbsp;  
                                                    <asp:Label ID="lblBalPaymentAmt" CssClass="FontDbCount" runat="server" Text=""></asp:Label>
                                                 </td>
                                            </tr>
                                            <tr>
                                            <td>&nbsp;</td>
                                            <td>  &nbsp;</td>
                                            </tr>
                                            </table>                    
                                         </td>
                                    </tr>
                                </table>
                            </div>                                                    
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    </table>                   
                    </td>
                    </tr>
                    </asp:PlaceHolder>
                    <tr><td>
                        <asp:PlaceHolder ID="plholder2" runat="server">
                            <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                                <tr>
                                <td width="35%">&nbsp;</td>
                                <td width="2%">&nbsp;</td>
                                <td>&nbsp;</td>
                                </tr>
                                <tr style="height:25px;" >
                                <td class="auto-style7"><asp:Literal ID="ltrProfitDate" runat="server" Text="Total Profit Until"></asp:Literal>
                                </td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="lblRpDate" runat="server" Text="Jan,2011" /> </td>
                                </tr>
                                <tr>
                                <td class="auto-style7">
                                <asp:Literal ID="Literal1" runat="server" Text="Total Payout"></asp:Literal>
                                </td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="lblPayOut" runat="server" Text="RM 0.00"></asp:Label>
                                </td>
                                </tr>
                                <tr>
                                <td class="auto-style7">
                                <asp:Literal ID="ltrNewEmail" runat="server" Text="Balance for Request Payment"></asp:Literal>
                                </td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="lblBalance" runat="server" Text="RM 0.00"></asp:Label>
                                </td>
                                </tr>
                                <tr>
                                <td class="auto-style7">
                                <asp:Literal ID="ltrNewEmailStatus" runat="server" Text="Request Payment less Admin Charges"></asp:Literal>
                                </td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">
                                &nbsp;<asp:Label ID="Label4" runat="server"  Text="RM "/>
                                <asp:TextBox ID="TextBoxPayAmt" runat="server" CssClass="stdTextField1" MaxLength="6"  Width="63px"/>
                                <br />                            
                                <asp:RequiredFieldValidator ID="rfvPayAmt" runat="server" SetFocusOnError="true" Display="Dynamic" ControlToValidate="TextBoxPayAmt" ErrorMessage="Enter Amount" />
                                <asp:RegularExpressionValidator ID="revPayAmt" ValidationExpression="^\$?[0-9]{1,3}(\.[0-9]{2})?$" runat="server" ErrorMessage="Enter a valid Amount."  SetFocusOnError="true" Display="Dynamic" ControlToValidate="TextBoxPayAmt"/>
                                <asp:RangeValidator ID="rvPayAmt" Type="Double"  ControlToValidate="TextBoxPayAmt" MinimumValue="200" MaximumValue="5000"  runat="server" ErrorMessage="Minimum Amount is RM 200.00,Maximum Amount is RM 5000.00" Display="Dynamic" SetFocusOnError="true"/>                            
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" onservervalidate="CustomValidator1_ServerValidate" ControlToValidate="TextBoxPayAmt"/>
                                </td>
                                </tr>
                                <tr>
                                <td class="auto-style7"><asp:Literal ID="ltrChangeEmail" runat="server" Text="Admin Charges"></asp:Literal></td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="Label11" runat="server"  Text="RM 25.00"></asp:Label></td>
                                </tr>
                                <tr>
                                <td class="auto-style7">
                                <asp:Literal ID="ltrTotalRequest" runat="server" Text="Total Request"/></td>
                                <td class="tblFormText1" align="left">:</td>
                                <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="Label14" runat="server"  Text="RM "/>
                                <asp:TextBox ID="TextBoxTotalPayAmt" runat="server" Enabled="false" CssClass="stdTextField1" MaxLength="6" Width="63px"></asp:TextBox>                            
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
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="plholder3" runat="server" Visible="false">
                        <table cellpadding="0" cellspacing="2" style="width: 100%;" class="stdtableBorder_Main">
                        <tr>
                        <td width="35%">&nbsp;</td>
                        <td width="2%">&nbsp;</td>
                        <td>&nbsp;</td>
                        </tr>                
                        <tr>
                        <td class="auto-style7">
                        <asp:Literal ID="ltrBalancePayOut" runat="server" Text="Balance for Request Payment"></asp:Literal>
                        </td>
                        <td class="tblFormText1" align="left">:</td>
                        <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="ltrBalancePayOutVal" runat="server"  
                            Text="RM 0.00"></asp:Label></td>
                        </tr>
                        <tr>
                        <td class="auto-style7">
                        <asp:Literal ID="Literal4" runat="server" Text="Requested Amount"></asp:Literal>
                        </td>
                        <td class="tblFormText1" align="left">:</td>
                        <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="lblRequestedAmt"  runat="server"  Text="RM 25.00"/>                                    
                        </td>
                        </tr>
                        
                        <tr>
                        <td class="auto-style7">
                        <asp:Literal ID="ltrAdminChgs" runat="server" Text="Admin Charges"></asp:Literal>
                        </td>
                        <td class="tblFormText1" align="left">:</td>
                        <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="ltrAdminChgsVal"  runat="server"  Text="RM 25.00"/>                                    
                        </td>
                        </tr>
                        <tr>
                        <td class="auto-style7">
                        <asp:Literal ID="Literal3" runat="server" Text="Total Request"/></td>
                        <td class="tblFormText1" align="left">:</td>
                        <td class="tblFormText1" align="left">&nbsp;<asp:Label ID="ltrTotalRequestAmtVal" runat="server"  Text="RM "/>
                        </td>
                        </tr>
                        <tr>
                        <td class="auto-style7" style="height:30px">&nbsp;</td>
                        <td class="tblFormText1" align="left">&nbsp;</td>
                        <td class="tblFormText1" align="left">
                        <asp:Button ID="btnConfirm" runat="server" CssClass="stdbuttonAction" 
                        Text="Confirm and Continue" onclick="btnConfirm_Click" /> &nbsp; 
                        <asp:Button ID="btnExit" runat="server" CssClass="stdbuttonAction" 
                        Text="Cancel Request" onclick="btnExit_Click" />
                        </td>
                        </tr>
                        </table>
                        </asp:PlaceHolder>
                    </td></tr>
                    </table>              
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        </table>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

