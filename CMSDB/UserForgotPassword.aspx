<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserForgotPassword.aspx.cs" Inherits="UserForgotPassword" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">


<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> 
    <asp:Literal ID="ltrforgotPassword" runat="server"></asp:Literal></td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/login_sidehead.jpg" />
    
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
<%--<form id="frmFaq" runat="server">--%>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">&nbsp;</td>
<td width="1%">&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
     <div class="cssfaq_head">
    <div class="cssfaq_headText"> 
    <asp:Literal ID="LtrPasswordRetreival" Text="Retreive your Password" runat="server"></asp:Literal>
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
<td>

<table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;
                  <asp:Label ID="lblName" runat="server" Text="Enter your Login ID"></asp:Label></td>
                  <td class="tblFormText" width="80%" >
                      <asp:TextBox ID="txtLoginID" CssClass="stdTextField1" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="txtLoginID" Display="Dynamic" ErrorMessage="Please enter LoginID" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                  </td>
                
              </tr>
               <tr> 
                  <td class="tblFormLabel">&nbsp;</td>
                  <td  class="tblFormText">&nbsp;</td>
                
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >
                      <asp:Button ID="btnSubmit" runat="server" Text="Get Password" 
                          onclick="btnSubmit_Click" ValidationGroup="VgCheck" />
                   </td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel font_11Msg_Error" valign="top" align="right">NOTE :</td>
                  <td  class="tblFormText font_11Msg_Error" valign="top" >Your login Password details 
                      will sent to your registered email address. </td>
               
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

<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

