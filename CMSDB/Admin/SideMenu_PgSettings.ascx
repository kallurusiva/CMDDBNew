<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideMenu_PgSettings.ascx.cs" Inherits="Admin_AdminSideMenu_PgSettings" %>

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
        <tr id="trHrMenu" runat="server">
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
                            &nbsp;<asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:LangResources, ManageSettings %>"></asp:Literal> </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="left" class="tblTopBarBkg">
                        
                        <div id="topbarmenu" runat="server" class="Links_TopBarMenu9">
                            <ul>
                               <%-- <li>
                                    <asp:Image ID="imgMenuitem" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                 <a href="Settings_HomePage.aspx"><asp:Literal ID="Literal8" runat="server"  
                                        Text="<%$ Resources:LangResources, HomePageSettings %>"></asp:Literal>
                                 </a>
                                 </li>--%>
                                 <li id="vWebSettings" visible="false" runat="server">
                                   <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="MyHomePageSettings.aspx">
                                   <asp:Literal ID="ltrWebSetting" runat="server" Text="WebSettings"></asp:Literal>
                                   </a>
                                </li> 
                                
                                 <li id="vWebTemplate" visible="false" runat="server">
                                   <asp:Image ID="Image6" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_TemplateSet.aspx">
                                   <asp:Literal ID="Literal1" runat="server" Text="WebTemplate"></asp:Literal>
                                   </a>
                                </li> 
                                
                                 <li id="vBanners" visible="false" runat="server">
                                   <asp:Image ID="Image7" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_BannerSettings.aspx">
                                   <asp:Literal ID="ltrBannerLogo" runat="server" Text="Banners"></asp:Literal>
                                   </a>
                                </li> 
                            <%--     <li>
                                   <asp:Image ID="Image8" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_ShowHideButtons_TopRow.aspx">
                                   <asp:Literal ID="ltrShowHideButtons" runat="server" Text="Top Row Buttons"></asp:Literal>
                                   </a>
                                </li> --%>
                                 <li id="vLogo" visible="false" runat="server">
                                   <asp:Image ID="Image9" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_LogoSettings.aspx">
                                   <asp:Literal ID="ltrLogo" runat="server" Text="Logo"></asp:Literal>
                                   </a>
                                </li> 
                                
                                
                                
                                
                                
                            </ul>
                            </div>
                            
                             <div id="dvtopbarenu2" runat="server" class="Links_TopBarMenu9">
                                <ul>
                                 <li id="vWelcomePageAdd" visible="false" runat="server">
                                   <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_WelComePageSettings.aspx">
                                   <asp:Literal ID="ltrAddWelComepage" runat="server" Text="Add WelcomePage"></asp:Literal>
                                   </a>
                                </li> 
                                
                                 <li id="vWelcomePageList" visible="false" runat="server">
                                   <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_WelComePageListing.aspx">
                                   <asp:Literal ID="ltrWelcomepageList" runat="server" Text="WelcomePage List"></asp:Literal>
                                   </a>
                                </li> 
                                
                                <li id="vAboutUsPageAdd" visible="false" runat="server">
                                   <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_AboutUsPageCreate.aspx">
                                   <asp:Literal ID="ltrAddAboutUsPage" runat="server" Text="Add AboutUsPage"></asp:Literal>
                                   </a>
                                </li> 
                                
                                 <li id="vAboutUsPageList" visible="false" runat="server">
                                   <asp:Image ID="Image5" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_AboutUsPageListing.aspx">
                                   <asp:Literal ID="ltrAboutusList" runat="server" Text="AboutUsPage List"></asp:Literal>
                                   </a>
                                </li> 
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