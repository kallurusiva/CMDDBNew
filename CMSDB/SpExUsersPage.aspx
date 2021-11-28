<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster_FullBottom.master" AutoEventWireup="true" CodeFile="SpExUsersPage.aspx.cs" Inherits="SpExUsersPage" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">&nbsp;</td>
<td width="1%">&nbsp;</td>
</tr>

<tr>
<td>&nbsp;</td>
<td>

  
  <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center"> &nbsp;
                 
            </td>
        </tr>
         <tr>
            <td align="center">
            <div id="dvTopGads" runat="server">
            </div>
                 
            </td>
        </tr>
        <tr>
            <td align="center">
            <table cellpadding="0" cellspacing="1" class="stdtableBorder_Only" width="100%" style="min-height: 400px;">
                    <tr>
                        <td  align="left" valign="top">
                         <asp:Label ID="lblUserContent" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
         <tr>
            <td align="center"> 
                  <div id="dvBottomGads" runat="server">
                  
                  </div>
            </td>
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


</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

