<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_ContactUs.aspx.cs" Inherits="Admin_Ad_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <form id="form1" runat="server">

<table border="0" cellpadding="0" cellspacing="0" width="100%">
       
       
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="1" class="stdtableBorder_Main" width="98%">
                    <tr style="height:30px;">
                        <td width="1%">&nbsp;</td>
                        <td width="98%" align="left" class="font_12Msg_Error">
                            &nbsp;</td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                        
                        
                            <table cellpadding="0" cellspacing="2" style="width: 100%;" class="stdtableBorder_Only">
                                <tr>
                                    <td width="20%">&nbsp;</td>
                                    <td width="2%">&nbsp;</td>
                                    <td width="50%">&nbsp;</td>
                                </tr>
                                <tr  style="height:25px;">
                                    <td>
                                        <asp:Literal ID="ltrCompanyName" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblCompanyName"  runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        <asp:Literal ID="ltrNickName" runat="server"></asp:Literal></td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblNickName" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr  style="height:25px;">
                                    <td>
                                        <asp:Literal ID="LtrAddress" runat="server"></asp:Literal></td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblAddress"  runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        <asp:Literal ID="LtrTelNo" runat="server"></asp:Literal></td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblTelNo" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        <asp:Literal ID="LtrFaxNo" runat="server"></asp:Literal></td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblFaxNo" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        <asp:Literal ID="LtrMobileNo" runat="server"></asp:Literal></td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                            </table>
                        </td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    </form>
</asp:Content>

