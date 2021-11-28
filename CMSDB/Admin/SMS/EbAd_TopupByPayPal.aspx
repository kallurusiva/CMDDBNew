<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_TopupByPayPal.aspx.cs" Inherits="Admin_SMS_EbAd_TopupByPayPal" %>
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
                            &nbsp;SMS Profit : SMS Topup Via Pay Pal</td>
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
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal3" Text="Latest Bank Info via SMS Instruction" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
                        &nbsp;</td>
                    </tr>
                 
                  <tr>
                  <td colspan="3">
                    <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="ebFormLabel1" align="left" style="width:250px"><asp:Label ID="Label5" runat="server" Text="Name (Same as your Mykad Full Name)"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblMNameVal" runat="server" Text="Name" CssClass="" /></td>
                            </tr>             
                            <tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="Label6" runat="server" Text="Your Login ID"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblLoginIDVal" runat="server" Text="Login" CssClass="" /></td>
                            </tr>
                            <tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="lblIC" runat="server" Text="Your Mobile"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblMobileVal" runat="server" Text="Mobile" CssClass="" /></td>
                            </tr>
                            <tr>
                                <td class="ebFormLabel1" align="left" >SMS Credit Balance</td>
                                <td class="ebFormText1" align="left">: <asp:Label ID="LabelSMSBalanceVal" runat="server" Text="Mobile" CssClass="" /></td>
                            </tr>
                            <tr>
                                <td class="ebFormLabel1" align="left" >Choose your preffered SMS Volume</td>
                                <td class="ebFormText1" align="left" style="height:40px">
                                    <asp:DropDownList ID="ddlSMSVolume" runat="server" class="stdDropDown" />
                                    &nbsp;<asp:Button ID="BtBuyNow" runat="server" CssClass="stdbuttonAction" 
                                        Text="Buy Now" OnClick="btBuyNow_Click" />
                                </td>
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
<%--[Required]   Full Name of the Payee User   [Max...128 chars]--%>
    <asp:HiddenField ID="cpFullName" runat="server" Value='' />
   <%--[Required]   Amount to be deducted   [decimal allowed] --%>
   <asp:HiddenField ID="cpAmount" runat="server" Value='' />
   <%--     USD :   American Dollars     
            SGD :   Singaporean Dollars
            MYR :   Malaysian Ringgit
   --%>
   <asp:HiddenField ID="cpCurrencyCode" runat="server" />
   <%--[Required]  Mobile number --%>
   <asp:HiddenField ID="cpMobileNo" runat="server" />
   <%--[Required]    ItemName/ Purpose of Buying / Amount being paid For --%>
   <asp:HiddenField ID="cpItemName" runat="server" />
   <%--[Optional]    Max 128 chars  --%>
   <asp:HiddenField ID="cpCustomText" runat="server" />
   <%--[Optional]    ItemNumber [default UniqueId will be used] --%>
   <asp:HiddenField ID="cpItemNumber" runat="server" />
   <%--[Optional]    UniqueID [default UniqueId will be used]--%>
   <asp:HiddenField ID="cpUniqueID" runat="server" Value="899899899" />
   <%--[Optional]    Max 100 chars.  Pass the webSiteName / Domain Name for reference purpose--%>
   <asp:HiddenField ID="cpWebSiteName" runat="server" /> 
   <%-- [Required]    UserID  --%>
   <asp:HiddenField ID="cpUserID" runat="server" />
   <%-- [Required]    URL Pathname to return after the paypal payment is successfull. --%>
   <asp:HiddenField ID="cpSuccessURL" runat="server" Value="" /> 
   <%-- [Required]    URL Pathname to return If the paypal payment is cancelled in the middle. --%>
   <asp:HiddenField ID="cpCancelURL" runat="server" Value="" />
   <%-- [Required]    URL Pathname to return If the paypal payment is failed. --%>
   <asp:HiddenField ID="cpFailureURL" runat="server" Value="" />
   <%--[Required]  if False=Request for TAG Code ,else true=go to paypal.com directly --%>
   <asp:HiddenField ID="cpSkipTAC" runat="server" Value="true" />
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

