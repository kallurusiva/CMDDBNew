<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="SA_UpLogos.aspx.cs" Inherits="SA_UpLogos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register src="SA_SideMenu_PgSettings.ascx" tagname="SA_SideMenu_PgSettings" tagprefix="uc1" %>


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
            location.href = 'SA_UpLogos.aspx?ImgToDelete=' + imgID;
        
        }
    
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SA_SideMenu_PgSettings ID="SA_SideMenu_PgSettings1" runat="server" />
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
                
           <table cellpadding="0" cellspacing="0" border="0" width="98%">
                
               
                <tr>
                    <td align="center">
                         <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                          <tr>
                                <td width="5%" align="left" valign="top">
                                    <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                        style="width: 10px; height: 20px" /></td>
                                <td width="90%" align="left" class="subHeaderFontGrad">
                                    &nbsp; <asp:Literal ID="LtrMyActSettings" runat="server" 
                                        Text="Upload Banner / Logo"></asp:Literal>&nbsp;
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
                                                                
                                
                               <%-- <tr>
                                 <td  align="left">Select Default Languague</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                     <asp:RadioButtonList ID="rdoDefLanguague" runat="server" CellSpacing="10" CellPadding="5" RepeatDirection="Horizontal">
                                         <asp:ListItem Value="en-US">English</asp:ListItem>
                                         <asp:ListItem Value="ms-MY">Bahasa Malay</asp:ListItem>
                                    
                                     
                                     </asp:RadioButtonList>
                                 
                                 </td>
                                </tr>
                                
                                
                                <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>--%>
                                
                                
                                  <tr>
                                 <td colspan="3">
                                 
                           <asp:Panel ID="PanelLogoHead" runat="server">
                                     <div id="dvLogoPanelHead" class="PanelCss" >
                                            <table width="100%">
                                                <tr>
                                                    <td align="left"><font class="PanelCss_Head">
                                                 <asp:Literal ID="Literal3" runat="server" Text="Upload Logo Template"></asp:Literal>
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
                                </tr>
                                
                               
                                <tr>
                                <td colspan="3">
                                <asp:Panel ID="PanelLogoBody" runat="server">
                                                          
                                <table width="100%" cellpadding="0" cellspacing="2" border="0">
                                
                              <%--  <tr>
                                 <td width="23%"  align="left">
                                <asp:Literal ID="LtrDispWebsite" Text="Display at Website" runat="server"></asp:Literal>
                                 </td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%" align="left">
                                     <asp:CheckBox ID="chkActive_Logo" runat="server" />
                                     <font class="HelpInputCss" >&nbsp; &nbsp; [if ticked, the uploaded image will be made as your selected logo.] </font> 
                                    </tr>--%>
                                
                                <tr>
                                 <td width="23%"  align="left">
                                     &nbsp; </td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%" align="left">
                                     &nbsp;
                                     </td>
                                    </tr>
                                
                                    <tr>
                                        <td align="left">
                                            <asp:Literal ID="Literal2" runat="server" 
                                                Text="Upload Company Logo image"></asp:Literal>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;
                                            <%--<asp:AsyncFileUpload ID="AsyncFup_Logo" runat="server" UploaderStyle="Modern" />--%>
                                            <asp:FileUpload ID="FU_Logo" runat="server" />
                                            &nbsp; &nbsp;
                                            <asp:Button ID="btn_FU_Logo" runat="server" CssClass="stdButtonNormal" 
                                                onclick="btn_FU_Logo_Click" Text="Upload Logo" />
                                            &nbsp;
                                            <asp:Label ID="lblUpMessage" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>
                                            <asp:RegularExpressionValidator ID="FileUploadValidator" runat="server" 
                                                ControlToValidate="FU_Logo" Enabled="true" 
                                                ErrorMessage="<br/>Only jpg or gif type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                
                                             <asp:CustomValidator ID="CustomVdr_Logo" runat="server" ControlToValidate="FU_Logo"
                                                                    ErrorMessage="Image size should not be greater than 15KB." OnServerValidate="CustomVdr_Logo_ServerValidate"></asp:CustomValidator>
   
                                            
                                        </td>
                                    </tr>
                                
                                
                                  <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td class="HelpInputCss" align="left">
                                 <asp:Literal ID="LtrHelpInput_UploadLogo" runat="server" 
                                 Text="[ For better Page Settings and presentation, &lt;br&gt; please upload logo image with size &lt;= (max-width=180 &amp; max-height=75) image. &lt;br&gt;The Logo image size cannot exceed 15KB ]"></asp:Literal>
                                </td>
                                </tr>
                                
                                
                                <tr>
                                 <td  align="left"><asp:Literal ID="LtrSelectLogos" runat="server" Text="Select LOGO image"></asp:Literal></td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                     <asp:RadioButtonList ID="rdoLogoImage" runat="server" CellPadding="5" 
                                         CellSpacing="5" RepeatColumns="3">
                                     </asp:RadioButtonList>
                                    </td>
                                </tr>
                                
                                
                                                              
                                
                                <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>
                                
                                </table>
                                </asp:Panel>
                                    
                                     
                                </td>
                                </tr>
                                                              
                                
                                <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>
                                
                                
                                
                                 <tr>
                                  <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                    <%-- <asp:ImageButton ImageUrl='' ID='imgDelete' OnClick='imgDelete_Click' ToolTip='Delete logo' AccessKey='' runat='server'/>--%>
                                     <asp:Button ID="Button1" Visible="false" CssClass="stdbuttonCRUD" runat="server" 
                                         Text="SAVE Settings" onclick="Button1_Click" />
                                    </td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                     &nbsp;</td>
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
                            &nbsp;</td></tr>
                            
             </table>
            </td>
            
        </tr>
            
       </table>
         </td>
           </tr>       
         <tr>
            <td>
                &nbsp;</td></tr>
        </table>
                
                
                </form>
                
                
</asp:Content>

