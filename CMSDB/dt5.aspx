<%@ Page Title="" Language="C#" MasterPageFile="~/TmpMaster5.master" AutoEventWireup="true" CodeFile="dt5.aspx.cs" Inherits="dt5" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
<div id="dvBody" style="min-height: 550px;">
    <table cellpadding="0" cellspacing="0" border="0"width="101%">
        <tr>
         <td>&nbsp;</td>
        </tr>
        
        <tr >
         <td>
         
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
         <td>&nbsp;</td>
        </tr>
        
    </table>
</div>    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

