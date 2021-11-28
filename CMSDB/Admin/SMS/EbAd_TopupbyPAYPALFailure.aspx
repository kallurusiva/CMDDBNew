<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_TopupbyPAYPALFailure.aspx.cs" Inherits="Admin_SMS_EbAd_TopupbyPAYPALFailure" %>
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
             <td><img runat="server" id="MessageImage" src="../../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp;EBook : SMS Topup Via Pay Pal</td>
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
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="center">
                        
                            <div id="dvWelcomeHeader" style="overflow:hidden; width:700px;  min-height: 50px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td colspan="3">
                       
                                    <div class="sideBoxheadText"> 
                                        <asp:Label ID="lblNote1" runat="server" Text="Your SMS Topup Transaction with PayPal is failed due to some technical.
<br/>Please verify your information during Pay Pal transaction." CssClass="headingFont11"/>
                                        <br />
                                        <br />
                                        <br />
                                        <div class="sideBoxheadText">

                                        <asp:Label ID="lblNoticebarMsg" runat="server" Text="PayPal Transaction Failure!"/></div>
                                
                                </td>
                    </tr>
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
                        &nbsp;</td>
                    </tr>
                 
                  <tr>
                  <td colspan="3">
                    
                      </td>
                  </tr>               
                                        
                      </table>
         
        </div>
                            </td>
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
            &nbsp;
           </td>
        </tr>
      
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>


