<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMostMenu.ascx.cs" Inherits="TopMostMenu" %>

<table id="tbltopMostMenu" runat="server" border="0" cellpadding="0" cellspacing="0" align="left" width="100%">
<tr>
<td width="20px">&nbsp;</td>
<td align="right" style="white-space:nowrap">&nbsp;
<asp:HyperLink ID="HypFreeSMS" CssClass="links_TopLineRed" runat="server" Visible="false"  
        NavigateUrl="~/UserFreeSMS.aspx">Free SMS Registration</asp:HyperLink>
   &nbsp;
    <img id="imgHome" alt="Clogin" src="Images/CustHome.gif" runat="server"  Visible="false"  />
    <asp:HyperLink ID="HypHome" CssClass="links_TopLine" runat="server"  Visible="false"  
        NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
    <%--&nbsp; | &nbsp; --%>  
    &nbsp; &nbsp;  
    <asp:HyperLink ID="HypContactUs" CssClass="links_TopLine" runat="server"  Visible="false"  
        NavigateUrl="~/UserContactUsPage.aspx">Contact Us</asp:HyperLink>
    <%--&nbsp; | &nbsp;     --%> 
    &nbsp;
    
    <asp:HyperLink ID="HypBankIN" CssClass="links_TopLine" runat="server"  Visible="false"  
        NavigateUrl="~/eBooksBankInTop.aspx"> BanK-In Form </asp:HyperLink>
       &nbsp;  
    
    <%--<img id="imgCustLogin" runat="server" alt="Clogin" src="Images/CustLogin.gif"  Visible="false"  />--%>
    <%--<asp:HyperLink ID="HypCustLogin" CssClass="links_TopLine" runat="server" 
        NavigateUrl="~/CustomerLogins.aspx">Customer Login</asp:HyperLink>--%>
        
        <asp:HyperLink ID="HypSMSlogin" CssClass="links_TopLine"  Visible="false"  runat="server" 
        NavigateUrl="~/SMSlogin.aspx">Customer Login</asp:HyperLink>

    <asp:HyperLink ID="HypEbook" CssClass="links_TopLine"  Visible="false"  runat="server" Target="_blank" 
        NavigateUrl="http://183.81.165.110/WebApps/EBook/ebook.html">eVendor Login</asp:HyperLink>
    &nbsp;
    <asp:HyperLink ID="HypPrepaid" CssClass="links_TopLine"  Visible="false"  runat="server" Target="_blank" 
        NavigateUrl="http://183.81.165.110/webapps/esmsuser/ebookuser.aspx">Prepaid Login</asp:HyperLink>

       
</td>
<td  width="20px">&nbsp;</td>
</tr>
</table>
