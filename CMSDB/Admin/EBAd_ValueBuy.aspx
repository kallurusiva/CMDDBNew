<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_ValueBuy.aspx.cs" Inherits="Admin_EBAdmin_EBAd_ValueBuy" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_ValueBuy.ascx" tagname="EBLeftMenu_ValueBuy" tagprefix="uc2" %>

<%@ Register src="EBLeftMenu_ebButtons.ascx" tagname="EBLeftMenu_ebButtons" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 1000px;
        height: 600px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <form id="form1" runat="server">
        <uc3:EBLeftMenu_ebButtons ID="EBLeftMenu_ebButtons1" runat="server" />
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <img alt="Coming Soon" class="auto-style2" src="../../Images/ComingSoon.jpg" /></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

