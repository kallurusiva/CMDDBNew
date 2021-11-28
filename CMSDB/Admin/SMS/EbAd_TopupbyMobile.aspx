<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_TopupbyMobile.aspx.cs" Inherits="Admin_SMS_EbAd_TopupbyMobile" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SMSSystem ID="EBLeftMenu_SMSSystem1" runat="server" />
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
                        <td width="65%" align="left" class="subHeaderFontGrad">
                            &nbsp; SMS System : Topup SMS via SMS Instructions</td>
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
                    <tr style="height:30px;">
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left" style="padding-left:20px">                            
                            <b>1. SMS FORMAT TO BUY SMS</b></td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                     <div id="dvAdminSummary" style="overflow:hidden; width:600px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal1" Text="SMS Format Buy 500 SMS Credit" runat="server"></asp:Literal> </div>
                                    </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="96%" >

                             <tr>
                                <td>&nbsp;</td>
                                <td>  &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="FontBHeader">EB BuySMS500 &lt;YourPassword&gt;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">e.g&nbsp; <b>EB BUYSMS500</b> 123123</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">Once buy, you will receive a Pin Number in order to topup 500 SMS 
                                    into your account or your member account</td>
                            </tr>                           
                             <tr>
                                <td>
                                    &nbsp;</td>
                                <td>  &nbsp;</td>
                            </tr>
                           </table>                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
        </div>
                     <div id="dvMyBooksSummary" style="overflow:hidden; width:600px; "  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadGreen">
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal2" Text="SMS Format Buy 1000 SMS Credit" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="96%" >
                           
                             <tr>
                                <td >&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="FontBHeader">EB BuySMS1000 &lt;YourPassword&gt;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">e.g&nbsp; <b>EB BUYSMS1000</b> 123123</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">Once buy, you will receive a Pin Number in order to topup 1000 SMS 
                                    into your account or your member account</td>
                            </tr>                           
                             <tr>
                                <td>
                                    &nbsp;</td>
                                <td>  &nbsp;</td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
        </div>
                     <div id="dvBuy500SMS" style="overflow:hidden; width:600px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal3" Text="SMS Format Buy 5000 SMS Credit" runat="server"></asp:Literal> </div>
                                    </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="96%" >

                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>


                             <tr>
                                <td colspan="2" class="FontBHeader">EB BuySMS5000 &lt;YourPassword&gt;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">e.g&nbsp; <b>EB BUYSMS5000</b> 123123</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">Once buy, you will receive a Pin Number in order to topup 5000 SMS 
                                    into your account or your member account</td>
                            </tr>                           
                             <tr>
                                <td>
                                    &nbsp;</td>
                                <td>  &nbsp;</td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
        </div>
                     
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left" style="padding-left:20px">                            
                            <b>2. SMS FORMAT TO TOPUP SMS</b></td>
                        <td>&nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <div id="Div1" style="overflow:hidden; width:600px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 112px; width: 100%">
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadGreen">
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal5" Text="SMS Format Topup SMS with PinNo" runat="server"></asp:Literal> </div>
                                    </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="96%" >

                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>


                             <tr>
                                <td colspan="2" class="FontBHeader">EB TopupSMS &lt;MobileNo&gt; &lt;PinNumber&gt;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>                           
                            <tr>
                                <td colspan="2">e.g&nbsp; <b>EB TopupSMS </b>60129988776 EXD112345</td>
                            </tr>                           
                             <tr>
                                <td>
                                    &nbsp;</td>
                                <td>  &nbsp;</td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
        </div></td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
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

