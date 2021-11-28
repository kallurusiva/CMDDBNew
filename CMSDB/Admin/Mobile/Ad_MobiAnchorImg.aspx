<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Mobile/AdminMasterDIYMB.master" AutoEventWireup="true" CodeFile="Ad_MobiAnchorImg.aspx.cs" Inherits="Ad_MobiAnchorImg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register src="Ad_Mobi_Menu.ascx" tagname="Ad_Mobi_Menu" tagprefix="uc1" %>


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
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="LtrLogoSettingsHeader" runat="server" 
                                Text="Select Anchor Image"></asp:Literal>&nbsp;
                          </td>
                      
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="2" class="stdtableBorder_MainBold" width="100%">
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
                                
                                <tr>
                                 <td width="23%"  align="left"><asp:Literal ID="LtrDispWebsite" Text="Display at Website" runat="server"></asp:Literal></td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%" align="left">
                                     <asp:CheckBox ID="chkActive_AnchorImg" runat="server" />
                                     <font class="HelpInputCss" >&nbsp; &nbsp; [if ticked, the uploaded image will be made as 
                                     your selected Anchor Image.] </font> 
                                    </tr>
                                
                                
                                    <tr>
                                        <td align="left">
                                            <asp:Literal ID="Literal2" runat="server" 
                                                Text="Upload my Anchor Image"></asp:Literal>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;
                                        
                                            <asp:FileUpload ID="FU_AnchorImg" runat="server" />
                                            &nbsp; &nbsp;
                                            <%--<asp:Button ID="btn_FU_Logo" runat="server" CssClass="stdButtonNormal" 
                                                onclick="btn_FU_Logo_Click" Text="Upload Logo" />--%>
                                            &nbsp;
                                            <asp:Label ID="lblUpMessage" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>
                                                
                                            <asp:RegularExpressionValidator ID="FileUploadValidator" runat="server" 
                                                ControlToValidate="FU_AnchorImg" Enabled="true" Display="Dynamic" 
                                                ErrorMessage="<br/>Only jpg or gif type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                
                                             <asp:CustomValidator ID="CustomVdr_Logo" runat="server" 
                                                ControlToValidate="FU_AnchorImg" CssClass="ValAlert_Error" 
                                                                    
                                                ErrorMessage="Image size should not be greater than 200KB." 
                                                OnServerValidate="CustomVdr_Logo_ServerValidate" Display="Dynamic"></asp:CustomValidator>
   
                                            
                                        </td>
                                    </tr>
                                
                                
                                  <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td class="HelpInputCss3" align="left">
                                     <ul>
                                         <li>For better representation on the Mobile Device, the Uploaded image would be 
                                             restricted to a width= 300px and Height=250px.</li>
                                         <li>In order to load the image faster. Upload an image with size in bytes as less as 
                                             possible, [ cannot exceed 200KB]</li>
                                     </ul>
                                </td>
                                </tr>
                                
                                
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
                                
                                
                                    <tr class="BlankWhiteHorizontalLine">
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left" class="HelpInputCss3">
                                            <asp:Button ID="Button1" runat="server" CssClass="stdbuttonCRUD" 
                                                onclick="Button1_Click" Text="SAVE Anchor Image Settings" />
                                        </td>
                                    </tr>
                                    <tr class="BlankWhiteHorizontalLine">
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left" class="HelpInputCss3">
                                            &nbsp;</td>
                                    </tr>
                                
                                
                                <tr>
                                 <td  align="left"><asp:Literal ID="LtrSelectAnchorImg" runat="server" 
                                         Text="Select Anchor image"></asp:Literal></td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                 
                                     <asp:RadioButtonList ID="rdoAnchorImage" runat="server" CellPadding="5" 
                                         CellSpacing="10" RepeatColumns="3" RepeatDirection="Horizontal">
                                     </asp:RadioButtonList>
                                 
                                    </td>
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

