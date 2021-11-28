<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserAboutUsPage.aspx.cs" Inherits="UserAboutUsPage" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> <asp:Literal ID="ltrAboutUsLeft" Text="About Us" runat="server"></asp:Literal> </td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/AboutUs_panel.jpg" />
    
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
<%--<form id="form1" runat="server">--%>
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
                <asp:Literal ID="ltrAboutUs1" Text="About Us" runat="server"></asp:Literal>
                </div>
   </div>     </td>
<td>&nbsp;</td>
</tr>

<tr>
<td>&nbsp;</td>
<td>
&nbsp;
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td align="center">
     <table cellpadding="0" cellspacing="0" width="100%" class="stdtableBorder_Main">
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="80%" align="left" class="font_14BoldGrey">
                 &nbsp;</td>
             <td width="10%">&nbsp;</td>
         </tr>
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="80%" align="left">
                 <asp:Literal ID="ltrAboutUsDescription" Text="" runat="server"></asp:Literal>
              </td>
             <td width="10%">&nbsp;</td>
         </tr>
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="80%" align="left" class="font_14BoldGrey">
                 &nbsp;</td>
             <td width="10%">&nbsp;</td>
         </tr>
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="80%" align="left" class="font_14BoldGrey">
                 &nbsp;</td>
             <td width="10%">&nbsp;</td>
         </tr>
     </table>
    </td>
<td>&nbsp;</td>
</tr>




</table>
<%--    </form>--%>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

