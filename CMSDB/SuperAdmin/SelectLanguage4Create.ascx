<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectLanguage4Create.ascx.cs" Inherits="SuperAdmin_SelectLanguage4Create" %>
 <asp:DropDownList ID="ddlLanguage" CssClass="stdDropDownContent" runat="server" >
    <asp:ListItem Value="0">-- Select Language -- </asp:ListItem>
    <asp:ListItem Value="1">English</asp:ListItem>
    <asp:ListItem Value="2">Bahasa Malay</asp:ListItem>
    <asp:ListItem Value="3">Chinese Simplified</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLanguage"
 InitialValue="0" Display="Dynamic" ValidationGroup="VgCheck" ErrorMessage="Please select the Language"></asp:RequiredFieldValidator> 
