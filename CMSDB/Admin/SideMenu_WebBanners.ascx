<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideMenu_WebBanners.ascx.cs" Inherits="SideMenu_WebBanners" %>

<link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" 
    type="text/css" />

<table border="0" cellpadding="0" cellspacing="0" width="100%">
        
        <tr>
            <td align="center" height="10px">

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
                            &nbsp;Template Picture Settings</td>
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
                                 <li id="vWebSettings"  runat="server">
                                   <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_BannerSettings.aspx">
                                   <asp:Literal ID="ltrMainBanner" runat="server" Text="TopBox Banner"></asp:Literal>
                                   </a>
                                </li> 
                                                              
                                 <li id="vBanners"  runat="server">
                                   <asp:Image ID="Image7" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_WP_BottomImage.aspx">
                                   <asp:Literal ID="ltrBottomPicture" runat="server" Text="Bottom Picture"></asp:Literal>
                                   </a>
                                </li> 
                            
                                 <li id="vLogo" runat="server">
                                   <asp:Image ID="Image9" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="Ad_WP_SideImage.aspx">
                                   <asp:Literal ID="ltrSidePicture" runat="server" Text="Side Picture"></asp:Literal>
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