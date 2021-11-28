<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_SMSTopup.aspx.cs" Inherits="Admin_SMS_EbAd_SMSTopup" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            FONT-SIZE: 12px;
            COLOR: #333333;
            FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;
            height: 16px;
        }
    </style>
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
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; SMS System : SMS Topup</td>
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
                        <td width="98%" align="left">
                            
                            There are 2 ways of topup SMS Credit Balance into your account.</td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                     <%--<div id="dvAdminSummary" style="overflow:hidden; width:400px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                        <asp:Image ID="Image1" ImageAlign="TextTop" runat="server" ImageUrl="~/Images/icon_MobileSMS.png" /><asp:Literal ID="Literal1" Text="Topup SMS via SMS Instructions" runat="server"></asp:Literal> </div>
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
                                <td class="style1" colspan="2">      You can always use your mobile (registered 
                                    mobile no.)&nbsp; to 
                                    buy and topup SMS into your account or member account</td>
                            </tr>

                           
                             <tr>
                                <td>
                                    &nbsp;</td>
                                <td>  &nbsp;</td>
                            </tr>
                        
                           
                             <tr>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="stdbuttonAction" 
                                        PostBackUrl="~/Admin/SMS/EbAd_TopupbyMobile.aspx">CLICK HERE TO TOPUP</asp:LinkButton>
                                 </td>
                                <td>  &nbsp;</td>
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
         
        </div>--%>


                            <div id="dvMyBooksSummary" style="overflow:hidden; width:400px; "  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                        <asp:Image ID="Image2" ImageAlign="TextTop" runat="server" ImageUrl="~/Images/icon_PayPal.png" /><asp:Literal ID="Literal2" Text="Topup SMS Via Pay Pal" runat="server"></asp:Literal> </div>
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
                                <td class="font_12Normal">     Apart from your mobile, you also can 
                                    topup your sms credit balance using your Pay Pal Account.</td>
                            </tr>

                             <tr>
                                <td >&nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td >
                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="stdbuttonAction" 
                                        PostBackUrl="~/Admin/SMS/EbAd_TopupByPayPal.aspx">CLICK HERE TO TOPUP</asp:LinkButton>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
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

