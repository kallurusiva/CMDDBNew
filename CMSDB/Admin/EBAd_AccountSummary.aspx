<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_AccountSummary.aspx.cs" Inherits="Admin_EBAd_AccountSummary" %>



<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_PaidSales.ascx" tagname="EBLeftMenu_PaidSales" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            text-decoration: underline;
        }
        .auto-style4 {
            width: 31%;
        }
        .auto-style5 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: left;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        .auto-style7 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: center;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        .auto-style8 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: center;
            font-variant: normal;
            font-style: normal;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
   
        <uc2:EBLeftMenu_PaidSales ID="EBLeftMenu_PaidSales1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="tForm" runat="server" enctype="multipart/form-data" method="post">


        <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tbody><tr class="tblSubHeader">
        <td  style="border-top: none;font-size: 18px;"><asp:Label ID="lblAccountSum" runat="server" Text="Account Summary" ></asp:Label></td>
         <td style="border-top: none;">
            </td>
        <td valign="top" style="width: 5px;"></td>
      </tr>
      <tr>
        <td colspan="3" class="std_padding_FormView1">
                  <table id="std_table01" cellpadding="0" cellspacing="0" style="width:98%; height: 800px;" class="stdtableBorder_Main">
                    <tbody><tr>
                        <td id="headerRow" style="height:25px;width:1%">&nbsp;</td>
                        <td id="headerRow"><span id="ctl00_ContentPlaceHolder3_LabelDescript">Description</span></td>
                        <td id="headerRow"><span id="ctl00_ContentPlaceHolder3_LabelCdt">Credit</span></td>
                        <td id="headerRow"><span id="ctl00_ContentPlaceHolder3_LabelDbt">Debit</span></td>
                        <td id="headerRow"><span id="ctl00_ContentPlaceHolder3_LabelBal">Balance</span></td>                        
                    </tr>
                    <tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalSumTT" class="auto-style5">Amount Added to Wallet</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalSumAmtTT"><asp:Label ID="LabelTotalSumAmtTT" runat="server" Text="LabelTotalSumAmtTT"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalSumCT" class="auto-style5">Inward/Outward Inter-Account Funds Transfer</span></td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalINCAmt">
                            <asp:Label ID="LabelTotalCdtTT" runat="server" Text="LabelTotalCdtTT"></asp:Label></span></td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td id="rowStyle" colspan="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="alternateRowStyle">&nbsp;</td>
                        <td colspan="4" id="alternateRowStyle"><span id="ctl00_ContentPlaceHolder3_LabelIncEarnings" class="auto-style5">Incentive Earnings</span></td>
                    </tr>
                    <tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalINC" class="auto-style5">Royalty Incentive</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalINCAmt"><asp:Label ID="LabelTotalINCAmt" runat="server" Text="LabelTotalINCAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_Label1" class="auto-style5">GlobalQ Incentive</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalGlobalQAmt"><asp:Label ID="LabelTotalGlobalQAmt" runat="server" Text="LabelTotalGlobalQAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelCPIncentive" class="auto-style5">Collaboration Partner CP Incentive</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelCPIncentive"><asp:Label ID="LabelTotalCPIncentive" runat="server" Text="LabelTotalCPIncentive"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <%--<tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalSMSINC">PremiumSMS Incentive</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalSMSINCAmt"><asp:Label ID="LabelTotalSMSINCAmt" runat="server" Text="LabelTotalSMSINCAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                   </tr>--%>
                    <tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalDPINC" class="auto-style5">Total Debit Purchase Incentive</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalDPINCAmt"><asp:Label ID="LabelTotalDPINCAmt" runat="server" Text="LabelTotalDPINCAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    
                   <tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalTopSMSINC" class="auto-style5">Topup SMS Incentive</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalTopSMSINCAmt"><asp:Label ID="LabelTotalTopSMSINCAmt" runat="server" Text="LabelTotalTopSMSINCAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="rowStyle">+</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalTopEbookPayINC" class="auto-style5">EBook Sales Incentive</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalTopEBookPayAmt"><asp:Label ID="LabelTotalTopEBookPayAmt" runat="server" Text="LabelTotalTopEBookPayAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    
                    
                    
                    
                    <tr>
                        <td id="rowStyle"></td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalCDT2"  >Total Incentive Earnings</span></td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalIncCdt"  class="auto-style5"><asp:Label ID="LabelTotalIncCdt" runat="server" Text="Label" ></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td id="rowStyle" colspan="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="alternateRowStyle">&nbsp;</td>
                        <td colspan="4" id="alternateRowStyle"><span id="ctl00_ContentPlaceHolder3_LabelDebit"  class="auto-style5">Debit</span></td>
                    </tr>
                    <tr>
                        <td id="rowStyle">-</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalDP"  class="auto-style5">Total Debit Purchase</span></td>
                        <td id="rowStyle">
                            &nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalDPAmt"><asp:Label ID="LabelTotalDPAmt" runat="server" Text="LabelTotalDPAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="rowStyle">-</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalTopupPurchase" class="auto-style5">Total Topup SMS Purchase</span></td>
                        <td id="rowStyle">
                            &nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalTopupPurchaseAmt"><asp:Label ID="LabelTotalTopupPurchaseAmt" runat="server" Text="LabelTotalTopupPurchaseAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="rowStyle">-</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalRedeem" class="auto-style5">Other Debit Adjustment</span></td>
                        <td id="rowStyle">
                            &nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalRedeemAmt"><asp:Label ID="LabelTotalRedeemAmt" runat="server" Text="LabelTotalRedeemAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td id="rowStyle"></td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalDBT1" class="txtRedTBSmall" class="auto-style5">Total Debit</span></td>
                        <td id="rowStyle">
                            &nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalDecDBT" class="txtRedTBSmall"><asp:Label ID="LabelTotalDecDBT" runat="server" Text="Label" ></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                        <td id="rowStyle">
                            &nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            &nbsp;</td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="rowStyle" colspan="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="alternateRowStyle">&nbsp;</td>
                        <td colspan="4" id="alternateRowStyle"><span id="ctl00_ContentPlaceHolder3_LabelPayment" class="auto-style5">Withdrawal</span></td>
                    </tr>
                    <tr>
                        <td id="rowStyle">-</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalPayPend" class="auto-style5">Pending Withdrawal</span></td>
                        <td id="rowStyle">
                            &nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalPayPendAmt"><asp:Label ID="LabelTotalPayPendAmt" runat="server" Text="LabelTotalPayPendAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="rowStyle">-</td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalAmtPaidDate" class="auto-style5">Total Withdrawal</span></td>
                        <td id="rowStyle">
                            &nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalAmtPaidDateAmt"><asp:Label ID="LabelTotalAmtPaidDateAmt" runat="server" Text="LabelTotalAmtPaidDateAmt"></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                   </tr>
                   <tr>
                        <td id="rowStyle"></td>
                        <td id="rowStyle"><span id="ctl00_ContentPlaceHolder3_LabelTotalDBT2" class="txtRedTBSmall" class="auto-style5">Total Withdrawal</span></td>
                        <td id="rowStyle">
                            &nbsp;</td>
                        <td id="rowStyle" style="text-align:right">
                            <span id="ctl00_ContentPlaceHolder3_LabelTotalPaymentDBT" class="txtRedTBSmall"><asp:Label ID="LabelTotalPaymentDBT" runat="server" Text="Label" ></asp:Label></span>
                        </td>
                        <td id="rowStyle">&nbsp;</td>
                    </tr>
                   
                      <tr>
                        <td id="rowStyle" colspan="5">&nbsp;</td>
                    </tr>
                  
                    <tr>
                        <td id="rowStyle" colspan="5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td id="headerRow" style="height:35px">&nbsp;</td>
                        <td id="headerRow"><span id="ctl00_ContentPlaceHolder3_LabelGrandTotal1" class="txtWhiteMedium" class="auto-style5">Balance Available to Date</span></td>
                        <td id="headerRow" style="text-align:right"><span id="ctl00_ContentPlaceHolder3_LabelGrandCDT1" class="txtWhiteMedium"><asp:Label ID="LabelGrandCDT1" runat="server" Text="" /></span></td>
                        <td id="headerRow" style="text-align:right"><span id="ctl00_ContentPlaceHolder3_LabelGrandDBT1" class="txtWhiteMedium"><asp:Label ID="LabelGrandDBT1" runat="server" Text="" /></span></td>
                        <td id="headerRow" style="text-align:right"><span id="ctl00_ContentPlaceHolder3_LabelNetBalance" class="txtWhiteMedium"><asp:Label ID="LabelNetBalance" runat="server" Text="" /></span></td>
                    </tr>
                    
                    

                  
                    
                    <tr>
                        <td id="rowStyle" style="text-align:right">&nbsp;</td>
                        <td id="rowStyle" style="height:35px">&nbsp;</td>
                        <td id="rowStyle" colspan="3" style="height:35px" align="right">
                           <%-- <br>
                            <span id="ctl00_ContentPlaceHolder3_lblNBalance" class="txtBlackLarge"><asp:Label ID="lblNBalance" runat="server" Text="lblNBalance" /></span>
                            <br>
                            <span id="ctl00_ContentPlaceHolder3_lblCashout" class="txtBlackLarge"><asp:Label ID="lblCashout" runat="server" Text="lblCashout" /></span>
                            <br>&nbsp;--%>
                        </td>
                      
                    </tr>
                  
             </tbody></table>
          </td>
      </tr>
     
    </tbody></table>

            

            

   
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

