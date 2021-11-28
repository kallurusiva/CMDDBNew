<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectLanguage.ascx.cs" Inherits="SuperAdmin_SelectLanguage" %>
<asp:Label ID="lblSelectLanguage" runat="server" CssClass="font_Content" Text="Select Language"></asp:Label>
 <asp:DropDownList ID="ddlLanguage" CssClass="stdDropDownContent" runat="server" AutoPostBack="true"
    onselectedindexchanged="ddlLanguage_SelectedIndexChanged">
    <asp:ListItem Value="0">ALL</asp:ListItem>
    <asp:ListItem Value="1">English</asp:ListItem>
    <asp:ListItem Value="2">Bahasa Malay</asp:ListItem>
    <asp:ListItem Value="3">Chinese Simplified</asp:ListItem>
</asp:DropDownList> 
