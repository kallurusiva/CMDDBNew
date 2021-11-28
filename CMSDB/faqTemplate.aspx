<%@ Page Language="C#" AutoEventWireup="true" CodeFile="faqTemplate.aspx.cs" Inherits="faqTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Repeater ID="rpFaqList" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="90%">
        <tr>
        <td width="20%">&nsbp; </td>
        <td width="80%" align="left">Faq Listing </td>
        </tr>
        
        <tr>
        <td>&nbsp; </td>
        <td>&nbsp; </td>
        </tr>
         
        </HeaderTemplate>
        
        <ItemTemplate>
        
        <tr>
        <td> Question: </td>
        <td> 
            <asp:Literal ID="LtrFaqQuestion" Text='<%# Eval("FaqQuestion")%>' runat="server"></asp:Literal>  </td>
        </tr>
        <tr>
        <td> Answer: </td>
        <td> 
            <asp:Literal ID="LtrFaqAnswer" Text='<%# Eval("FaqAnswer")%>' runat="server"></asp:Literal>
         </td>
        </tr>
        <tr>
        <td> -----------------  </td>
        <td>&nbsp; </td>
        </tr>
        
        </ItemTemplate>
        
        <FooterTemplate>
        <tr>
        <td>&nbsp; </td>
        <td>&nbsp; </td>
        </tr>
        </table>
        </FooterTemplate>
        </asp:Repeater>
    
        
    
    </div>
    </form>
</body>
</html>
