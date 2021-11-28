<%@ Page Title="" Language="C#" MasterPageFile="~/TmpMaster6.master" AutoEventWireup="true" CodeFile="dt6.aspx.cs" Inherits="dt6" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
<div id="dvBody" style="min-height: 300px;">
    <table cellpadding="0" cellspacing="0" border="0"width="101%">
        <tr>
         <td>&nbsp;</td>
        </tr>
        
        <tr >
         <td>
         
         <table border="0" bordercolor="red" cellpadding="0" cellspacing="1" width="100%" style="min-height: 100px;">
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

