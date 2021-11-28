<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideMenu_Faq.ascx.cs" Inherits="Admin_AdminSideMenu" %>

<link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" 
    type="text/css" />

<table border="0" cellpadding="0" cellspacing="0" width="100%">
       
        <tr>
            <td align="center">

<%--<table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubMenuHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:LangResources, Manage %>"></asp:Literal> 
                            FAQ</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_SideMenu" width="96%">
                    <tr>
                        <td width="5">
                            &nbsp;</td>
                        <td width="100">
                            &nbsp;</td>
                        <td width="5">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            </td>
                        <td>
                            <asp:HyperLink ID="lnkAddNews" CssClass="links_SideMenu" runat="server" NavigateUrl="FaqCreate.aspx">
                                <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:LangResources, Add %>"></asp:Literal>&nbsp;
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:LangResources, FAQ %>"></asp:Literal> 
                            </asp:HyperLink>
                            </td>
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="lnkNewsList" CssClass="links_SideMenu" runat="server" NavigateUrl="FaqListing.aspx">
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LangResources, View %>"></asp:Literal>&nbsp;
                            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:LangResources, FAQ%>"></asp:Literal>-
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:LangResources, Listing%>"></asp:Literal>
                            </asp:HyperLink>
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
                    </tr>
                </table>
            </td>
        </tr>
        </table>--%>
 
 </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" >
                  <tr>
                        <td width="3%" align="left" valign="top" class="tblTopBarSub">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="22%" align="left" class="subHeaderMenuFontGrad tblTopBarSub" >
                            &nbsp;
                         <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:LangResources, ManageFaq %>"></asp:Literal> 
                            </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                            <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                            <td  width="180px">
                            <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="HyperLink3" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="FaqCreate.aspx">
                                <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:LangResources, Add %>"></asp:Literal>&nbsp; FAQ 
                                </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            <td  width="180px">
                            
                             <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink1" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="FaqListing.aspx?RtType=USER">
                              <asp:Literal ID="LtrMy" runat="server" Text="My FAQ"></asp:Literal>
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            <td  width="180px">
                            
                             <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink4" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="FaqListing.aspx?RtType=ADMIN">
                              <asp:Literal ID="LtrAdmin" runat="server" Text="Admin FAQ"></asp:Literal>
                             </asp:HyperLink>
                            
                            </td>
                            
                            <td>&nbsp;</td>
                            <td  width="180px">
                            
                             <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink2" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="FaqListing.aspx?RtType=ALL">
                              <asp:Literal ID="LtrShowAll" runat="server" Text="Show ALL"></asp:Literal>
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            <td  width="5%">&nbsp;</td>
                            
                            </tr>
                            </table>
                            
                        
                        <%--<div id="topbarmenu" runat="server" class="Links_TopBarMenu">
                            <ul>
                                <li>
                                    <asp:Image ID="imgMenuitem" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                 <a href="FaqCreate.aspx"><asp:Literal ID="Literal8" runat="server"  
                                        Text="<%$ Resources:LangResources, AddFaq %>"></asp:Literal>
                                 </a>
                                 </li>
                                <li>
                                   <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <a href="FaqListing.aspx"><asp:Literal ID="Literal9" runat="server" 
                                        Text="<%$ Resources:LangResources, ViewFaq %>"></asp:Literal>
                                        </a></li> 
                            </ul>
                            </div>--%>
                        
                        </td>
                            
                    </tr>
                 </table>
            </td>
        </tr>

        </table></td>
        </tr>
    </table>