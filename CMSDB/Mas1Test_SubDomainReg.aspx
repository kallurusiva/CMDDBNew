<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mas1Test_SubDomainReg.aspx.cs" Inherits="Mas1Test_SubDomainReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" action="Mas1SubDomainReg.aspx" method="post" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    CountryCode</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    MobileNo</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Page From</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Register Test" 
                        PostBackUrl="~/Mas1SubDomainReg.aspx" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
