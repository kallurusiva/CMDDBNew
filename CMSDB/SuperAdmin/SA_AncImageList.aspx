<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_AncImageList.aspx.cs" Inherits="SA_AncImageList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>




<%@ Register src="SA_SideMenu_Domains.ascx" tagname="SA_SideMenu_Domains" tagprefix="uc2" %>


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
            location.href = 'Ad_MobiAnchorImg.aspx?ImgToDelete=' + imgID;
        
        }
    
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_Domains ID="SA_SideMenu_Domains1" runat="server" />
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
                            <asp:Literal ID="LtrLogoSettingsHeader" runat="server" 
                                Text="Anchor Images"></asp:Literal>&nbsp;
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
                            <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                <tr>
                                 <td width="23%">&nbsp;</td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%">&nbsp;</td>
                                </tr>
                       
                             <%--     <tr>
                                 <td colspan="3">
                                 
                           <asp:Panel ID="PanelLogoHead" runat="server">
                                     <div id="dvLogoPanelHead" class="PanelCss" >
                                            <table width="100%">
                                                <tr>
                                                    <td align="left"><font class="PanelCss_Head">
                                                 <asp:Literal ID="Literal3" runat="server" Text="Select Logo Template"></asp:Literal>
                                                  </font>
                                                        
                                                    </td>
                                                    <td align="right" width="450px">
                                                    <asp:Label runat="server" ID="lblLogo" />&nbsp; 
                                                        <asp:Image ID="ImgLogoEc" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                     </asp:Panel>
                                 </td>
                                </tr>--%>
                                
                               
                                <tr>
                                <td colspan="3">
                                <asp:Panel ID="PanelLogoBody" runat="server">
                                                          
                                <table width="100%" cellpadding="0" cellspacing="2" border="0">
                                
                                
                                <%--    <tr class="BlankWhiteHorizontalLine">
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left" class="HelpInputCss3">
                                            &nbsp;
                                            <asp:Literal ID="LtrHelpInput_UploadLogo" runat="server" 
                                                Text="[ For better presentation and faster loading, &lt;br&gt; please upload Anchor image with size  as minimum as possible. &lt;br&gt;The anchor image size cannot exceed 200KB ]"></asp:Literal>
                                        </td>
                                    </tr>--%>
                                
                                
                                <tr>
                                 <td  align="left">&nbsp;</td>
                                 <td align="left">
                                 
                                     <asp:RadioButtonList ID="rdoAnchorImage" runat="server" CellPadding="5" 
                                         CellSpacing="10" RepeatColumns="4" RepeatDirection="Horizontal">
                                     </asp:RadioButtonList>
                                 
                                    </td>
                                </tr>
                                
                                
                                                              
                                
                                    <tr>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                
                                
                                                              
                                
                                </table>
                                </asp:Panel>
                               
                                </td>
                                </tr>
                                                              
                 
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                 
                                     &nbsp;</td>
                                </tr>
                                
                       
                               
                                </table>
                            
                            
                            </td>
                        <td>&nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td>
                            &nbsp;</td><td>
                            &nbsp;</td></tr></table></td></tr></table></td><tr>
            <td>
                &nbsp;</td></tr></table></form>
                
                
</asp:Content>

