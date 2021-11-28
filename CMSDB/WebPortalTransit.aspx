<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebPortalTransit.aspx.cs" Inherits="WebPortalTransit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .fontloader {
           FONT-SIZE: 12px; font-weight: bold; height:20px; padding:5px; padding-left:10px; COLOR: #359F07; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div align="center">   
    
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="fontloader">WEB PORTAL</asp:Label>
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/loader.gif" />
    </div>
    </form>
</body>
</html>
