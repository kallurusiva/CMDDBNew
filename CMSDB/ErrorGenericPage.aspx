<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="ErrorGenericPage.aspx.cs" Inherits="ErrorGenericPage" %>

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
    &nbsp;</td>
</tr>
<tr>
<td align="center" valign="middle">
    <img alt="err1" src="Images/errorface.jpg" 
        style="width: 102px; height: 102px" /></td>
</tr>
<tr>
<td>
    &nbsp;</td>
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


    <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
     <tr>
     <td>&nbsp;</td>
     <td align="left">&nbsp;</td>
     </tr>
     </table>
     
</td>
<td>&nbsp;</td>
</tr>


<tr>
<td>&nbsp;</td>
<td>

<table cellpadding="0" cellspacing="0" width="100%" runat="server" id="tblEntryForm"  style="background-color: #F2F0B2;">
                            
               <tr>
                
                  <td  valign="top">&nbsp;</td>
                  <td  valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td  valign="middle" align="right">
                      <img alt="err" src="Images/ErrorPageImg.gif" 
                          style="width: 61px; height: 56px" /></td>
                  <td  valign="middle" ><font style="font: bold 18px Trebuchet Ms; color:Red">APPLICATION ERROR</font></td>
               
              </tr>
              
               <tr>
                
                  <td  valign="top">&nbsp;</td>
                  <td  valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td  valign="top">&nbsp;</td>
                  <td  valign="top" > <font class="font_12Msg_Error">We&#39;re sorry.&nbsp; But an unhandled or 
                      unknown error has&nbsp; occurred on the server.
                      <br />
&nbsp;&nbsp;The Server Administrator has been notified and the error is logged for further investigation.
                      <br />
&nbsp;</font></td>
               
              </tr>
              
               <tr>
                
                  <td  valign="top">&nbsp;</td>
                  <td  valign="top" > <font class="font_12Msg_Error">
                   
                  </font></td>
               
              </tr>
              
               <tr>
                
                  <td  valign="top">&nbsp;</td>
                  <td  valign="top" > <font class="font_12Msg_Error">
                  Please continue either by clicking the back button and retrying your request or by returning to home page.  
                  </font></td>
               
              </tr>
              
               <tr>
                
                  <td  valign="top">&nbsp;</td>
                  <td  valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td valign="top">&nbsp;</td>
                  <td  valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="font_11Msg_Error" valign="top" align="right">&nbsp;</td>
                  <td  class="font_11Msg_Error" valign="top" >&nbsp;</td>
               
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

