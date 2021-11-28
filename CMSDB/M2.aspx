<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M2.aspx.cs" Inherits="M2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .stdButtonLogin             {background-color:#97DFD7; display:block; border:1px solid #dedede; font-size:8pt; font-family:Verdana, Tahoma, Arial, Helvetica, Trebuchet Ms;
                              border-top:1px solid #999999; border-left:1px solid #999999;}        
        .stdButtonLogin:hover       {background-color:#B0F0E5; border:1px solid #c2e1ef; color:#336699; border-bottom:1px solid #999999; border-right:1px solid #999999;}

    
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
        <asp:Label ID="LabelManufacturer" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LabelModel" runat="server" Text="Label"></asp:Label>
        
        <br />
        <asp:Label ID="LabelScreen" runat="server" Text="Label"></asp:Label>
         <br />
        <asp:Label ID="lblUserAgent" runat="server" Text="Label"></asp:Label>
        
        <br />
        <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button1" CssClass="stdButtonLogin" PostBackUrl="~/Mb/Index.aspx" runat="server" Text="Button" />
        <br />
        <asp:LinkButton ID="LinkButton1" CssClass="stdButtonLogin" PostBackUrl="~/Mb/Index.aspx" runat="server">LinkButton</asp:LinkButton>
    </div>
    <br />
    <asp:HyperLink ID="HyperLink1" CssClass="stdButtonLogin" NavigateUrl="~/Mb/Index.aspx" runat="server">HyperLink</asp:HyperLink>
    </form>
</body>
</html>
