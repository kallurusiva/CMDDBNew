<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SA_SideMenu_Testimonial.ascx.cs" Inherits="SuperAdmin_SA_SideMenu_Testimonial" %>

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
                            &nbsp; Manage Testimonial</td>
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
                            <asp:HyperLink ID="lnkAddNews" CssClass="links_SideMenu" runat="server" NavigateUrl="TestimonialCreate.aspx">Add Testimonial</asp:HyperLink>
                            
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="lnkNewsList" CssClass="links_SideMenu" runat="server" NavigateUrl="TestimonialListing.aspx">View Testimonial</asp:HyperLink>
                            
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
                 <table cellpadding="0" cellspacing="0" width="96%" >
                  <tr>
                        <td width="3%" align="left" valign="top" class="tblTopBarSub">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="22%" align="left" class="subHeaderMenuFontGrad tblTopBarSub" >
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LangResources, ManageTestimonial %>"></asp:Literal> 
                             </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                            <td  width="180px">
                            <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="HyperLink3" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_TestimonialCreate.aspx">
                                <asp:Literal ID="LtrAddTestimonial" runat="server" Text="Add Testimonial"></asp:Literal>&nbsp;   
                                </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            <td  width="150px">
                            
                             <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink1" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_TestimonialListing.aspx?RtType=USER">
                              <asp:Literal ID="LtrMyTestimonial" runat="server" Text="My Testimonial"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                           <%-- <td  width="150px">
                            
                             <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink4" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="TestimonialListing.aspx?RtType=ADMIN">
                              <asp:Literal ID="LtrAdminTestimonial" runat="server" Text="Admin Testimonial"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            
                            <td  width="150px">
                            
                             <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink2" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="TestimonialListing.aspx?RtType=ALL">
                              <asp:Literal ID="LtrShowAll" runat="server" Text="Show ALL"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>--%>
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