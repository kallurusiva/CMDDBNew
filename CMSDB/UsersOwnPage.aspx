<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UsersOwnPage.aspx.cs" Inherits="UsersOwnPage" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
  .divGen1LogoCss { max-height: 200px; max-width: 200px; }
        
        /* new clearfix 
    .clearfix 
    {
    	overflow: hidden;
    }
    .clearfix:after {
	visibility: hidden;
	overflow: hidden;
	
	display: block;
	font-size: 0;
	content: " ";
	clear: both;
	height: 0;
	}

   
    * html .clearfix             { zoom: 1; } /* IE6 */
    *:first-child+html .clearfix { zoom: 1; } /* IE7 */*/
    </style>
    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

<script language="javascript" type="text/javascript">



</script>
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
       <%-- <tr>
            <td align="center"> &nbsp;
                 
            </td>
        </tr>--%>
        <tr>
            <td align="center">
            <table cellpadding="0" cellspacing="1" class="" width="100%" style="min-height: 400px;">
                    <tr>
                        <td  align="left" valign="top">
                         <div class="clearfix">
                         <asp:Label ID="lblUserContent" runat="server" Text=""></asp:Label>
                         </div>
                        </td>
                    </tr>
                </table>
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

