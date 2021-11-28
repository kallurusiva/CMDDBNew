<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminSideMenu.ascx.cs" Inherits="Admin_AdminSideMenu" %>

<link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" 
    type="text/css" />

<style type="text/css">
    .style1
    {
        height: 18px;
    }
</style>

<table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubMenuHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; Sub Header Goes Here</td>
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
                        <td width="5%">
                            &nbsp;</td>
                        <td width="20%">
                            &nbsp;</td>
                        <td width="5%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            </td>
                        <td class="style1">
                            <asp:LinkButton ID="LinkButton1" CssClass="links_SideMenu" runat="server">LinkButton1</asp:LinkButton></td>
                        <td class="style1">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            <asp:LinkButton ID="LinkButton2" CssClass="links_SideMenu" runat="server">LinkButton2</asp:LinkButton></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            <asp:LinkButton ID="LinkButton3"  CssClass="links_SideMenu" runat="server">LinkButton3</asp:LinkButton></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>