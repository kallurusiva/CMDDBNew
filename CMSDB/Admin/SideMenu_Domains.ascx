<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideMenu_Domains.ascx.cs" Inherits="Admin_SideMenu_Domains" %>

<link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" 
    type="text/css" />

<table border="0" cellpadding="0" cellspacing="0" width="100%">
        


<table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" >
                  <tr>
                        <td width="3%" align="left" valign="top" class="tblTopBarSub">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="22%" align="left" class="subHeaderMenuFontGrad tblTopBarSub" >
                            Domain Details 
                             </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                           
                            <td  width="200px">
                            
                             <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink2" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_DomainSubInfo.aspx">
                              SubDomain
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            <td  width="200px">
                            
                             <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink1" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_DomainsList.aspx">
                              Own Domain Registration
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            
                             <%--<td  width="200px">
                            <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="HyperLink3" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_AnchorDomainsList.aspx">
                                Sample Websites 
                                </asp:HyperLink>
                            
                            </td>--%>
                            <td>&nbsp;</td>
                            <td  width="5%">&nbsp;</td>
                            
                            </tr>
                            </table>
                        
   
                        
                        </td>
                            
                    </tr>
                 </table>
            </td>
        </tr>

        </table>
 
            </td>
        </tr>
       
    </table>