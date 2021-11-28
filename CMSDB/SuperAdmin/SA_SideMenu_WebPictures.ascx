<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SA_SideMenu_WebPictures.ascx.cs" Inherits="SA_SideMenu_WebPictures" %>

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
                            &nbsp;<asp:Literal ID="Literal7" runat="server" Text="WebBanner Settings"></asp:Literal> </td>
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
                                 
                                
                                 <li id="vBanners"  runat="server">
                                   <asp:Image ID="Image7" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="SA_WP_BottomImage.aspx">
                                   <asp:Literal ID="ltrBottomPicture" runat="server" Text="Bottom Banner"></asp:Literal>
                                   </a>
                                </li> 
                            
                                 <li id="vLogo" runat="server">
                                   <asp:Image ID="Image9" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                   <a href="SA_WP_SideImage.aspx">
                                   <asp:Literal ID="ltrSidePicture" runat="server" Text="Side Banner"></asp:Literal>
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