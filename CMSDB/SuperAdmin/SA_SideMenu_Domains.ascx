<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SA_SideMenu_Domains.ascx.cs" Inherits="SuperAdmin_SA_SideMenu_Domains" %>

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
                            <asp:Literal ID="Literal2" runat="server" Text="Manage Domains"></asp:Literal> 
                             </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                           
                            <td  width="150px">
                            
                             <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypDomainRequests" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_AncDomainsCreate.aspx">
                              <asp:Literal ID="ltrDomainRequest" runat="server" Text="Add AnchorDomains"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                   
                            <td  width="150px">
                            
                             <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypAncDomains" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_AncDomainsListing.aspx">
                              <asp:Literal ID="ltrAnchorDomains" runat="server" Text="AnchorDomains List"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>                                 
                             <td  width="150px">
                            
                             <asp:Image ID="Image5" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypAncCategories" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_AncDomainsCategories.aspx">
                              <asp:Literal ID="ltrDomainCats" runat="server" Text="Anchor Categories"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            
                            <td>&nbsp;</td>                                 
                             <td  width="150px">
                            
                             <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink1" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_AncImages_Upload.aspx">
                              <asp:Literal ID="Literal1" runat="server" Text="Add Anchor Images"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            
                            <td>&nbsp;</td>                                 
                             <td  width="150px">
                            
                             <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink2" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_AncImageList.aspx">
                              <asp:Literal ID="Literal3" runat="server" Text="AnchorImages List"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            
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