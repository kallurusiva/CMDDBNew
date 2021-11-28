<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideMenu_Email.ascx.cs" Inherits="Admin_SideMenu_Email" %>

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
                            &nbsp;
                         <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:LangResources, Manage %>"></asp:Literal> 
                            Email    </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                            <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                           <%-- <td  width="180px">
                            <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="HypEmail" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_EmailList.aspx">
                                <asp:Literal ID="ltrEmail" runat="server" Text="Email Create"></asp:Literal>&nbsp;  
                                </asp:HyperLink>
                            
                            </td>--%>
                            <td>&nbsp;</td>
                            <td  width="180px">
                            
                             <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypEmailList" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_EmailListing.aspx?RtType=USER">
                              <asp:Literal ID="ltrEmailList" runat="server" Text="Email Listing"></asp:Literal>
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            <%--<td  width="180px">
                            
                             <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypEmailMkting" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_EmailMarketing.aspx">
                              <asp:Literal ID="ltrEmailMarketing" runat="server" Text="Email Marketing"></asp:Literal>
                             </asp:HyperLink>
                            
                            </td>
                            
                            <td>&nbsp;</td>--%>
             <%--               <td  width="180px">
                             <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <%--<asp:HyperLink ID="HypEmailLogin" Target="_blank" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_EmailLogin.aspx">--%>
                             <%-- <asp:Literal ID="LtrEmailLogin" runat="server" Text="Email Login"></asp:Literal>--%>
                            <%-- </asp:HyperLink>
                             <asp:HyperLink ID="HyperLink1" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_EmailLogin.aspx">
                              <asp:Literal ID="LtrEmailLogin" runat="server" Text="Email Login"></asp:Literal>
                             </asp:HyperLink>
                            
                            
                            
                            </td>--%>
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