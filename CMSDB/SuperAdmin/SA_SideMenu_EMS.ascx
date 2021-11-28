<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SA_SideMenu_EMS.ascx.cs" Inherits="SA_SideMenu_EMS" %>

<link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" 
    type="text/css" />

<table border="0" cellpadding="0" cellspacing="0" width="100%">
        
        <tr>
            <td align="center">
 
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
                            <asp:Literal ID="Literal2" runat="server" Text="Email System "></asp:Literal> 
                             </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                            <td  width="250px">
                            <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="HypEMSUsers" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_EMSUserListing.aspx">
                                <asp:Literal ID="ltrEMSUsers" runat="server" Text="EmailSytem UserListing"></asp:Literal>&nbsp;   
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
                                 <a href="EventsCreate.aspx"><asp:Literal ID="Literal8" runat="server"  
                                        Text="<%$ Resources:LangResources, AddEvents %>"></asp:Literal>
                                 </a>
                                 </li>
                                <li>
                                   <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <a href="EventsListing.aspx"><asp:Literal ID="Literal9" runat="server" 
                                        Text="<%$ Resources:LangResources, ViewEvents %>"></asp:Literal>
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