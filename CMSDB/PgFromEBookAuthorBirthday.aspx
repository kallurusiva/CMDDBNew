<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PgFromEBookAuthorBirthday.aspx.cs" Inherits="PgFromEBookAuthorBirthday" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
    .std_TitleBlackLarge
    {font-family:Arial;font-size:13px;color:#999999;font-weight:bold;text-decoration:none;
    text-align:center;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">   
    
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="std_TitleBlackLarge">Please wait while we retreive...</asp:Label>
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/loader.gif" />
    </div>
    </form>
</body>
</html>
