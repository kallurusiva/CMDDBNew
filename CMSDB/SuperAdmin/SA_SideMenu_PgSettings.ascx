<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SA_SideMenu_PgSettings.ascx.cs" Inherits="SuperAdmin_SA_SideMenu_PgSettings" %>

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
                        <td width="90%" align="left" class="subHeaderMenuFontGrad">
                            &nbsp; Manage Settings</td>
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
                            <asp:HyperLink ID="lnkAddNews" CssClass="links_SideMenu" runat="server" NavigateUrl="#">HomePage Settings</asp:HyperLink>
                            
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="lnkNewsList" CssClass="links_SideMenu" runat="server" NavigateUrl="#">ProductPage Settings</asp:HyperLink>
                            
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
                 <table cellpadding="0" cellspacing="0" width="98%" >
                  <tr>
                        <td width="3%" align="left" valign="top" class="tblTopBarSub">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="22%" align="left" class="subHeaderMenuFontGrad tblTopBarSub" >
                            &nbsp;<asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:LangResources, ManageSettings %>"></asp:Literal> </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="left" class="tblTopBarBkg">
                        
                        <div id="topbarmenu" runat="server" class="Links_TopBarMenu">
                            <ul>
                                <li>
                                    <asp:Image ID="imgMenuitem" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                 <a href="SA_AddTopMenuItems.aspx">
                                 <asp:Literal ID="LtrAddTopMenuLinks" runat="server" Text="Add TopMenu Items"></asp:Literal>
                                 
                                 </a>
                                 </li>
                                 
                                  <li>
                                   <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="SA_UpLogos.aspx">
                                   <asp:Literal ID="Literal2" runat="server" Text="Add Logo"></asp:Literal>
                                   </a>
                                </li> 
                                
                                <li>
                                   <asp:Image ID="Image5" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="SA_UpBanners.aspx">
                                   <asp:Literal ID="Literal3" runat="server" Text="Add Banner"></asp:Literal>
                                   </a>
                                </li> 
                                <li>
                                   <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="SA_WelComePageSettings.aspx">
                                   <asp:Literal ID="LtrAddWelcomePage" runat="server" Text="Add WelcomePage"></asp:Literal>
                                   </a>
                                </li> 
                                
                                <li>
                                   <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="SA_AboutUsPage.aspx">
                                   <asp:Literal ID="ltrAboutUsPage" runat="server" Text="Add AboutUsPage"></asp:Literal>
                                   </a>
                                </li> 
                                
                                 <li>
                                   <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="SA_EmailListing.aspx">
                                   <asp:Literal ID="Literal1" runat="server" Text="Email List"></asp:Literal>
                                   </a>
                                </li> 
                                
                           <%--      <li>
                                   <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="SA_AddTopMenuItems.aspx">
                                   <asp:Literal ID="LtrBannerItems" runat="server" Text="Add Banner Items"></asp:Literal>
                                   </a>
                                </li> --%>
                            </ul>
                            </div>
                        
                        </td>
                            
                    </tr>
                 </table>
            </td>
        </tr>

        </table></td>
        </tr>
    </table>