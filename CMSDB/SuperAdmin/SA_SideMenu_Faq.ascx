<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SA_SideMenu_Faq.ascx.cs" Inherits="SuperAdmin_SA_SideMenu_Faq" %>

<link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" 
    type="text/css" />

<table border="0" cellpadding="0" cellspacing="0" width="100%">
       
        <tr>
            <td align="center">
<%--
<table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubMenuHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:LangResources, Manage %>"></asp:Literal> 
                            FAQ</td>
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
                            <asp:HyperLink ID="lnkAddNews" CssClass="links_SideMenu" runat="server" NavigateUrl="SA_FaqCreate.aspx">
                                <asp:Literal ID="LtrAddFAQ" runat="server" Text=""></asp:Literal>&nbsp;
                            </asp:HyperLink>
                            </td>
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="lnkNewsList" CssClass="links_SideMenu" runat="server" NavigateUrl="SA_FaqListing.aspx">
                            <asp:Literal ID="LtrFaqListing" runat="server" Text="Faq Listing"></asp:Literal>&nbsp;
                            </asp:HyperLink>
                            </td>
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
                            &nbsp;
                         <asp:Literal ID="ltrManageFAQ" runat="server" Text=""></asp:Literal> 
                                </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="left" class="tblTopBarBkg">
                        
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                            <td width="2%">&nbsp;</td>
                          <%--  <td  width="180px" style=" white-space:nowrap">
                            <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="Hyp_LgType_Eng" Text="1" ToolTip=" English " CssClass="Links_TopBarMenu" runat="server" NavigateUrl="#" />
                                <asp:HyperLink ID="Hyp_LgType_Bms" Text="2" ToolTip=" Bahasa Malay " CssClass="Links_TopBarMenu" runat="server" NavigateUrl="#" />
                                <asp:HyperLink ID="Hyp_LgType_Chi" Text="3" ToolTip=" Chinese " CssClass="Links_TopBarMenu" runat="server" NavigateUrl="#" />
                                                  
                            </td>--%>
                            <td width="20%">&nbsp;</td>
                             <td width="20%">&nbsp;</td>
                            <td  width="120px">
                            <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="Hyp_faqCreate" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_FaqCreate.aspx"> <asp:Literal ID="LtrAddFAQ" runat="server" Text="Add FAq"></asp:Literal>&nbsp; </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                            <td  width="120px">
                            
                             <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="Hyp_faqListing" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="SA_FaqListing.aspx"> <asp:Literal ID="LtrFaqListing" runat="server" Text="FAQ Listing"></asp:Literal></asp:HyperLink>
                            
                            </td>
<%--                            <td>&nbsp;</td>
                            <td  width="180px">
                            
                             <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink4" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="FaqListing.aspx?RtType=ADMIN">
                              <asp:Literal ID="LtrAdmin" runat="server" Text="Admin FAQ"></asp:Literal>
                             </asp:HyperLink>
                            
                            </td>
                            
                            <td>&nbsp;</td>
                            <td  width="180px">
                            
                             <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink2" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="FaqListing.aspx?RtType=ALL">
                              <asp:Literal ID="LtrShowAll" runat="server" Text="Show ALL"></asp:Literal>
                             </asp:HyperLink>
                            
                            </td>--%>
                            <td>&nbsp;</td>
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