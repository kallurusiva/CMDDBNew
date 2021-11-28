<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_WPInfo.aspx.cs" Inherits="EBAd_WPInfo" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_ValueBuy.ascx" tagname="EBLeftMenu_ValueBuy" tagprefix="uc2" %>

<%@ Register src="EBLeftMenu_WPinfo.ascx" tagname="EBLeftMenu_WPinfo" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <form id="form1" runat="server">
        <uc3:EBLeftMenu_WPinfo ID="EBLeftMenu_WPinfo1" runat="server" />
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="font_12Normal">
            <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>

        </td>
    </tr>
    
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

