<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SA_SideMenu_Users.ascx.cs" Inherits="SuperAdmin_SA_SideMenu_Users" %>

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
                            <asp:Literal ID="Literal2" runat="server" Text="Users"></asp:Literal> 
                             </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                            <td  width="150px">
                            <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="HypAllUsers" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_AllUsersListing.aspx">
                                <asp:Literal ID="ltrAllUsers" runat="server" Text="All Users Listing"></asp:Literal>&nbsp;   
                                </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            <td  width="180px">
                            
                             <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypDomainRequests" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_DomainRequests.aspx">
                              <asp:Literal ID="ltrDomainRequest" runat="server" Text="Own Domain Requests"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            
                            <td  width="150px">
                            
                             <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypWebStats" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_AllUserWebStatistics.aspx">
                              <asp:Literal ID="ltrWebStats" runat="server" Text="WebStatistics"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            
                             <td>&nbsp;</td>
                                  
                             <td  width="150px">
                            
                             <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypPinRenewals" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_PinRenewals.aspx">
                              <asp:Literal ID="ltrPinRenewals" runat="server" Text="PinRenewals"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            
                             <td>&nbsp;</td>
                                  
                             <td  width="150px">
                            
                             <asp:Image ID="Image5" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypDomain" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_DomainReg_ParamValues.aspx">
                              <asp:Literal ID="ltrDomainDetails" runat="server" Text="Domain Params"></asp:Literal>&nbsp;
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