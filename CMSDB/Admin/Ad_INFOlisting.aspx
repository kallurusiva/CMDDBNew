<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_INFOlisting.aspx.cs" Inherits="Admin_Ad_INFOlisting" %>

<%@ Register src="SideMenu_MyAccount.ascx" tagname="SideMenu_MyAccount" tagprefix="uc1" %>

<%@ Register src="LeftMenu_Profile.ascx" tagname="LeftMenu_Profile" tagprefix="uc2" %>

<%@ Register src="LeftMenu_INFO.ascx" tagname="LeftMenu_INFO" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:LeftMenu_INFO ID="LeftMenu_INFO1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

<form id="form1" runat="server">

<table border="0" cellpadding="0" cellspacing="0" width="100%">
       
       
        <tr style="height:20px">
            <td align="center">

           </td>
        </tr>
        <tr>
            <td align="center">
            
                <asp:Label ID="lblInfoContent" runat="server" Text=""></asp:Label> 
            </td>

        </tr>
    
    <tr>
            <td>
                &nbsp;</td></tr>
    </table>
    </form>
</asp:Content>

