<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Admin_Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="5" class="stdtableBorder_Main" width="96%">
                    <tr>
                        <td width="5%">
                            &nbsp;</td>
                        <td width="20%">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="5%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="FormLabel" align="left">
                            <asp:Literal ID="ltrUser" runat="server" 
                                Text="<%$ Resources:LangResources, User %>"></asp:Literal>
&nbsp;<asp:Literal ID="ltrId" runat="server" Text="<%$ Resources:LangResources, id %>"></asp:Literal>
                        </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblUserId" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="FormLabel" align="left">
                            Login ID</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblLoginID" runat="server" Text="" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="FormLabel" align="left">
                            <asp:Literal ID="ltrCreated" runat="server" 
                                Text="<%$ Resources:LangResources, Created %>"></asp:Literal>
&nbsp;<asp:Literal ID="ltrDate" runat="server" Text="<%$ Resources:LangResources, Date %>"></asp:Literal>
                        </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblCreatedDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="FormLabel" align="left">
                            <asp:Literal ID="ltrUser0" runat="server" 
                                Text="<%$ Resources:LangResources, User %>"></asp:Literal>
&nbsp;<asp:Literal ID="ltrType" runat="server" Text="<%$ Resources:LangResources, Type %>"></asp:Literal>
                        <td class="style3">
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblUserType" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp; 
                            <asp:Literal ID="LtrSessionTimeout" runat="server"></asp:Literal></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</asp:Content>

