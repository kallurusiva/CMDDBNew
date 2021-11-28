<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_EmailLogin.aspx.cs" Inherits="Admin_Ad_EmailLogin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SideMenu_Email.ascx" tagname="SideMenu_Email" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SideMenu_Email ID="SideMenu_Email1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

<form id="form2" runat="server">

   

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
                            &nbsp;<asp:Literal ID="LtrEmailLogin" runat="server"></asp:Literal></td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="98%">
                    <tr style="height:30px;">
                        <td width="3%">&nbsp;</td>
                        <td width="4%">&nbsp;</td>
                        <td width="90%" align="left">
                        <font class="font_12Msg_Error">
                            <asp:Literal ID="LtrEmailNoteId" runat="server"></asp:Literal> 
                             </font>
                          &nbsp;e.g.&nbsp; john@smswebsite.com</td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td align="left">
                        
                        
                            &nbsp;</td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td align="left">
                            <font class="font_Content">
                            <asp:Literal ID="LtrEmailNoteId2" runat="server"></asp:Literal> 
                            </font>
                          </td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
                        </td>
                        <td>
                      <a href="https://webmail.opentransfer.com/horde/imp/login.php" target="_blank">
                            
                            <img border="0" alt="webmail" src="../Images/webMailLogin.jpg" 
                                style="width: 243px; height: 207px" />
                                </a>
                            </td></tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td></tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td></tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
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

