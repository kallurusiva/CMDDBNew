<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="MpTest.aspx.cs" Inherits="Admin_Mobile_MpTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="ClientButton" runat="server" Text="Launch Modal Popup (Client)" />
                
                <asp:Panel ID="ModalPanel" runat="server" Width="500px">
                 ASP.NET AJAX is a free framework for quickly creating a new generation of more 
                 efficient, more interactive and highly-personalized Web experiences that work 
                 across all the most popular browsers.<br />
                 <asp:Button ID="OKButton" runat="server" Text="Close" />
                </asp:Panel>
                
                <asp:ModalPopupExtender ID="ModalPopupExtender1"
                 TargetControlID="ClientButton" PopupControlID="ModalPanel" OkControlID="OKButton"
                  runat="server">
                </asp:ModalPopupExtender>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>


</asp:Content>

