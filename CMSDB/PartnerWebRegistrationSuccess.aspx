﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="PartnerWebRegistrationSuccess.aspx.cs" Inherits="PartnerWebRegistration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            background-color: #F2F0B2;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            font-size: 12px;
            font-weight: bold;
            height: 20px;
            width: 38%;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> <asp:Literal ID="ltrContactUs" Text="Contact Us" runat="server"></asp:Literal> </td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/ContactUs_panel.jpg" />
    
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

<script language="javascript" type="text/javascript">

    function CheckKeyCode(e) {
        if (navigator.appName == "Microsoft Internet Explorer") {
            if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 8)) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 0)) {
                return true;
            }
            else {
                return false;
            }
        }
    }


    function CheckKeyCode_AlphaNum(e) {
        if (navigator.appName == "Microsoft Internet Explorer") {
            if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 8) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 97 && e.keyCode <= 122)) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 0)) {
                return true;
            }
            else {
                return false;
            }
        }
    }



   
    

</script>

<%--<form id="form1" runat="server">--%>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </td>
<td width="1%">&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
     <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="ltrPartnerWebReg" Text="Partner Website Registration" runat="server"></asp:Literal>
                </div>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
    <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
     <tr>
     <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
     <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
     </tr>
     </table>
</td>
<td>&nbsp;</td>
</tr>



<tr>
<td>&nbsp;</td>
<td class="cssfaqQuestion font_14BoldGrey"> 
                &nbsp;</td>
<td>&nbsp;</td>
</tr>



<tr>
<td>&nbsp;</td>
<td>
     <table cellpadding="0" cellspacing="0" width="100%" class="stdtableBorder_Main">
         <tr  class="font_12BlueBold">
            <td  width="5%">&nbsp;</td>
             <td width="10%" align="left">
                  &nbsp;</td>
             <td width="80%" align="center">
                 &nbsp;</td>
             <td width="5%">&nbsp;</td>
         </tr>
         <tr  class="font_14SuccessBold">
             <td >&nbsp;</td>
             <td align="center" colspan="2">
                  Congratulations !!!&nbsp; Registration successfully completed. </td>
             <td>&nbsp;</td>
         </tr>
          <tr>
            <td >&nbsp;</td>
             <td colspan="2">
                 &nbsp;</td>
             
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td colspan="2">
                 <b>Your Instant SubDomain :&nbsp; </b></td>
             
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td colspan="2">
                 &nbsp;</td>
             
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td colspan="2" class="font_12BlueBold">
                 Registration Details : - </td>
             
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td colspan="2">
                 
                 <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
              <tr>
                  
                  <td class="style2" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
               <tr>
                  
                  <td class="style2" >&nbsp;<asp:Label ID="Label1" 
                          runat="server" Text="Pin No"></asp:Label></td>
                  <td class="tblFormText" width="80%" >
                      <asp:TextBox ID="txtPinNo" CssClass="stdTextField1" runat="server" 
                          ReadOnly="True"></asp:TextBox>
                  </td>
                
              </tr>
                         
<%--              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">--%>
                <tr>
                    <td class="style2">
                        &nbsp;<asp:Label ID="lblsubDomain" runat="server" Text="Sudomain Name"></asp:Label>
                    &nbsp;/ Admin Login</td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtSubDomainName" runat="server" AutoPostBack="true" 
                            CssClass="stdTextField1" MaxLength="20" 
                            ReadOnly="True"></asp:TextBox>
                        
                                                 
       <%--              </ContentTemplate>
                     <Triggers>            
                        <asp:AsyncPostBackTrigger ControlID="txtSubDomainName" EventName="TextChanged" />            
                    </Triggers>
                     
                        </asp:UpdatePanel> --%>
                    </td>
                </tr>
<%--              </table>
              </ContentTemplate>
                </asp:UpdatePanel>
               --%>
                
               <tr>
                    <td class="style2">
                        &nbsp;<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtloginPassword" MaxLength="15" runat="server" 
                            CssClass="stdTextField1" ReadOnly="True"></asp:TextBox>
                               
                    </td>
                </tr>
                
                
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                        &nbsp;</td>
                </tr>
              
                <tr>
                    <td class="style2">
                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td class="style2" valign="top">
                        &nbsp;<asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                    </td>
                    <td class="tblFormText" valign="top">
                        <asp:TextBox ID="txtCountryName" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
               <tr> 
                  <td class="style2">&nbsp;<asp:Label ID="lblMobileNo" runat="server" 
                          Text="Mobile No."></asp:Label></td>
                  <td  class="tblFormText">
                  <asp:TextBox ID="txtMobileNo" CssClass="stdTextField1" MaxLength="11" Text="60" 
                          runat="server" ReadOnly="True"></asp:TextBox>
                   
                      &nbsp;
                               
                   </td>
                
              </tr>
              
              
              
                <tr>
                    <td class="style2">
                        &nbsp;<asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="tblFormText">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
              
              
               <tr>
                
                  <td class="style2" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="style2" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" ><font class="font_12Msg_Success">Save the Registration Details at a safe 
                      place. </font></td>
               
              </tr>
              
               </table>
                 
                 
                 
                 
                 </td>
                          <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
           
             <td align="center" colspan="2">
        
        <div id="dvAdminLogin" class="loginCss1021">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                    
                    <td colspan="3">
                    
                      <%--  <td style="height:30px;" width="20px" align="left" valign="top">
                        <img alt="topleftarc" src="Images/table_top_Leftarc.gif" 
                        style="width: 10px; height: 20px" />
                        </td>
                        <td class="loginfontTitle">Members Login</td>--%>
                        
                        <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="LtrAdminLogin" Text="Admin Login" runat="server"></asp:Literal></div>
                                </div>   
                      </td> 
                        
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">Login Id</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtLoginID"  CssClass="loginTextBox" runat="server" 
                            ValidationGroup="VgMainLogin"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Please enter LoginID"  CssClass="font_12Msg_Error" 
                            ControlToValidate="txtLoginID" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgMainLogin"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPassword" CssClass="loginTextBox" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgMainLogin"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Please enter password" CssClass="font_12Msg_Error" 
                            ControlToValidate="txtPassword" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgMainLogin"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr style="height:5px;">
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <asp:Button CssClass="stdButtonLogin" ID="btnSignIn" runat="server" 
                            Height="26px" Text="Sign In" 
                            Width="56px" onclick="btnSignIn_Click" ValidationGroup="VgMainLogin" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td class="font_forgotPwd" align="right">forgot password</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td class="font_12Msg_Error">
                        <asp:Literal ID="LtrErrMessage" Text="" runat="server"></asp:Literal>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
         
        </div>
        
        
              </td>
            
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         
        
     </table>
    </td>
<td>&nbsp;</td>
</tr>



<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>



<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>



</table>
   <%-- </form>--%>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

