<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SAlogin.aspx.cs" Inherits="SuperAdmin_SAlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" 
</head>
<body>
<div>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
    <tr class="SATopFrameBkg">
    <td>&nbsp;</td>    
    <td>&nbsp;</td>  
    <td>&nbsp;</td>  
    </tr>
    <tr class="SATopFrameBkg" style="height:50px;">
    <td>&nbsp;</td>    
    <td><font class="SAAdminFont">Super Admin Panel</font></td>  
    <td>&nbsp;</td>  
    </tr>
    <tr  class="SATopFrameBkg">
    <td>&nbsp;</td>    
    <td>&nbsp;</td>  
    <td>&nbsp;</td>  
    </tr>
    
    </table>
    </div>
    
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
                        <td width="5%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="5%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
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
                            <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                        </td>
                        <td>
                            &nbsp;:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="stdTextField1" 
                                Height="20px" ValidationGroup="vgUserCheck"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtUserName" Display="Dynamic" 
                                ErrorMessage="Enter User Name" SetFocusOnError="True" 
                                ValidationGroup="vgUserCheck"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                            &nbsp;:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="stdTextField1" 
                                TextMode="Password" ValidationGroup="vgUserCheck"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Password" 
                                ValidationGroup="vgUserCheck"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            Language</td>
                        <td>
                            :</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlLang" runat="server">
                                <asp:ListItem Value="en-US">English</asp:ListItem>
                                <asp:ListItem Value="ms-MY">Bahasa Malay</asp:ListItem>
                                <asp:ListItem Value="th-TH">Thai</asp:ListItem>
                                <asp:ListItem Value="zh-CN">Chinese Simplified</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    <tr>
                        <td class="style1">
                            </td>
                        <td class="style1">
                            </td>
                        <td class="style1">
                            </td>
                        <td class="style1">
                            </td>
                        <td class="style1">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="btnSign" runat="server" CssClass="stdbuttonAction" 
                                onclick="btnSign_Click" Text="Login In" ValidationGroup="vgUserCheck" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
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
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblErrMessage" runat="server" CssClass="font_12Msg_Error"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
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


</body>
</html>
