<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_ShowHideButtons_TopRow.aspx.cs" Inherits="Admin_Ad_ShowHideButtons_TopRow" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SideMenu_PgSettings.ascx" tagname="SideMenu_PgSettings" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .stylehand
        {
            cursor: hand;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function fnDeleteImage(imgID) {
            //alert(imgID);
            location.href = 'MyHomePageSettings.aspx?ImgToDelete=' + imgID;
        
        }
    
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SideMenu_PgSettings ID="SideMenu_PgSettings1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="MyHomePageForm" runat="server" enctype="multipart/form-data">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr style="height:20px" id="tblMessageBar" visible="false" runat="server">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" >
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td>
                </td>
                <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrShowButtonsTopRow" runat="server" 
                                Text="Manage Top Row Buttons"></asp:Literal>&nbsp;
                          </td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="2" class="stdtableBorder_MainBold" width="96%">
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="96%">
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                        </td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="border: dashed 1px red;">
                            <tr>
                            <td width="35%">&nbsp;</td>
                            <td width="5%">&nbsp;</td>
                            <td width="60%">&nbsp;</td>
                            </tr>
                                
                            
                            
                            <tr>
                            <td width="35%">&nbsp;</td>
                            <td width="5%">&nbsp;</td>
                            <td width="60%" align="left"><font class="HelpInputCss" >&nbsp; &nbsp; [Tick the check box for the buttons you want to show 
                                on the top most row of your website.] </font></td>
                            </tr>
                                
                            
                            
                            <tr>
                            <td width="35%"><font class="Section_headtext">Top Row Buttons </font></td>
                            <td width="5%">:</td>
                            <td width="60%" align="left">&nbsp;
                            <asp:CheckBoxList ID="chkList_TopRowButtons" runat="server" RepeatColumns="5" 
                                        RepeatDirection="Horizontal" CellPadding="2" CellSpacing="10" Height="20px">
                                    </asp:CheckBoxList>
                            </td>
                            </tr>
                                
                            
                            
                            <tr>
                            <td width="35%">&nbsp;</td>
                            <td width="5%">&nbsp;</td>
                            <td width="60%">&nbsp;</td>
                            </tr>
                                
                            
                            
                            <tr>
                            <td width="35%">&nbsp;</td>
                            <td width="5%">&nbsp;</td>
                            <td width="60%" align="left">
                                <asp:Button ID="btnSave" runat="server" Text="Save Top Row Buttons Selection" 
                                    onclick="btnSave_Click" />
                                </td>
                            </tr>
                                
                            
                            
                            <tr>
                            <td width="35%">&nbsp;</td>
                            <td width="5%">&nbsp;</td>
                            <td width="60%">&nbsp;</td>
                            </tr>
                                
                            
                            
                            </table>
                            
                            
                            </td><td>
                            &nbsp;</td></tr></table></td></tr></table></td><tr>
            <td>
                &nbsp;</td></tr></table></form>
                
                
</asp:Content>

