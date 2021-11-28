<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SA_SideMenu_MobiButtons.ascx.cs" Inherits="SA_SideMenu_MobiButtons" %>

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
                            <asp:Literal ID="Literal2" runat="server" Text="Default Mobile Buttons"></asp:Literal> 
                             </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                           
                            <td  width="250px">
                            
                             <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypDefWebButton1" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_ButtonMobiListing.aspx">
                              <asp:Literal ID="ltrDomainRequest" runat="server" Text="Default Mobile Buttons Listing"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                   
                            <td  width="250px">
                            
                             <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypDefWebButton2" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_ButtonMobiAdd.aspx">
                              <asp:Literal ID="ltrAnchorDomains" runat="server" Text="Add New Default Mobile Button"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>                                 
                            
                            <td  width="5%">&nbsp;</td>
                            
                            </tr>
                            </table>
                        
                        
                        
                        
                        </td>
                            
                    </tr>
                 </table>
            </td>
        </tr>

        </table></td>
        </tr>
    </table>

