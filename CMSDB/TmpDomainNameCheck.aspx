<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TmpDomainNameCheck.aspx.cs" Inherits="TmpDomainNameCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtDomainName" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="btnCheck" runat="server" onclick="btnCheck_Click" 
            Text="Button" />
&nbsp;
        <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
