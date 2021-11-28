<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="MyHomePageSettings_Async.aspx.cs" Inherits="Admin_MyHomePageSettings_Async" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SideMenu_PgSettings.ascx" tagname="SideMenu_PgSettings" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 17px;
        }
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

        function RetrievePicture(imgCtrl, picURL) {
            imgCtrl.onload = null;
            alert("loading...." + picURL);
            // imgCtrl.src = 'ShowImage.ashx?picURL=' + picURL;
            imgCtrl.src = 'ShowImagePage.aspx?picURL=' + picURL;
           // imgCtrl.src = picURL;
            
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
                            &nbsp; <asp:Literal ID="LtrMyActSettings" runat="server" 
                                Text="My Home Page Settings"></asp:Literal>&nbsp;
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
<%--                    <object width="640" height="480">
                    <param name="movie" value="player.swf" />
                    <embed src="player.swf" width="640" height="480" />
                    </embed>
                    </object>--%>
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
                                <tr>
                                <td><font class="Section_headtext">
                                 <asp:Literal ID="LtrWebPageDetails" runat="server" Text="WebPage Details"></asp:Literal>
                                  </font> </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                </tr>
                                
                                 <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrTopMenuLinks" runat="server" Text="Select Top Menu Links "></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                    <asp:CheckBoxList ID="chkList_TopMenuItems" runat="server" RepeatColumns="5" 
                                        RepeatDirection="Horizontal" CellPadding="2" CellSpacing="10" Height="20px">
                                    </asp:CheckBoxList>
                                     </td>
                                </tr>
                                
                                 <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>
                                
                                
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
                                </tr>
                                
                               
                                <tr>
                                <td colspan="3">
                                <asp:Panel ID="PanelLogoBody" runat="server">
                                                          
                                <table width="100%" cellpadding="0" cellspacing="2" border="0">
                                
                                <tr>
                                 <td width="23%"  align="left"><asp:Literal ID="LtrDispWebsite" Text="Display at Website" runat="server"></asp:Literal></td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%" align="left">
                                     <asp:CheckBox ID="chkActive_Logo" runat="server" />
                                     <font class="HelpInputCss" >&nbsp; &nbsp; [if ticked, the uploaded image will be made as your selected logo.] </font> 
                                    </tr>
                                
                                
                                    <tr>
                                        <td align="left">
                                            <asp:Literal ID="Literal2" runat="server" 
                                                Text="Upload Own Company Logo image"></asp:Literal>
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
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg])"></asp:RegularExpressionValidator>
                                                
                                             <asp:CustomValidator ID="CustomVdr_Logo" runat="server" ControlToValidate="FU_Logo"
                                                                    ErrorMessage="Image size should not be greater than 15KB." OnServerValidate="CustomVdr_Logo_ServerValidate"></asp:CustomValidator>
   
                                            
                                        </td>
                                    </tr>
                                
                                
                                  <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td class="HelpInputCss" align="right">&nbsp;
                                 <asp:Literal ID="LtrHelpInput_UploadLogo" runat="server" 
                                 Text="[ For better Page Settings and presentation, &lt;br&gt; please upload logo image with size &lt;= (max-width=180 &amp; max-height=75) image. &lt;br&gt;The Logo image size cannot exceed 15KB ]"></asp:Literal>
                                </td>
                                </tr>
                                
                                
                                <tr>
                                 <td  align="left"><asp:Literal ID="LtrSelectLogos" runat="server" Text="Select LOGO image"></asp:Literal></td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                 
                                     <asp:RadioButtonList ID="rdoLogoImage" runat="server" CellPadding="5" 
                                         CellSpacing="10" RepeatColumns="3">
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
                                <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server" 
                                         TargetControlID="PanelLogoBody" CollapseControlID="PanelLogoHead" 
                                         ExpandControlID="PanelLogoHead" CollapsedImage="~/Images/Expand2.gif" 
                                         ExpandedImage="~/Images/Collapse2.gif" ImageControlID="ImgLogoEc" 
                                         CollapsedSize="0" CollapsedText=" Expand to view available Logo templates ..." ExpandedText="Collapse ..." 
                                         TextLabelID="lblLogo" Collapsed="True">
                                
                                     </asp:CollapsiblePanelExtender>    
                                     
                                </td>
                                </tr>
                                                              
                                
                                <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>
                                
                                <tr>
                                 <td colspan="3">
                                     <asp:Panel ID="PanelBannerHead" runat="server">
                                     <div id="Div1" class="PanelCss" >
                                            <table width="100%">
                                                <tr>
                                                    <td align="left"><font class="PanelCss_Head">
                                                 <asp:Literal ID="LtrBannerDetails" runat="server" Text="Select Banner"></asp:Literal>
                                                  </font>
                                                        
                                                    </td>
                                                    <td align="right" width="450px">
                                                    <asp:Label runat="server" ID="lblBanner" />&nbsp; 
                                                        <asp:Image ID="ImgBannerEC" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                     </asp:Panel>
                                 </td>
                                </tr>
                                
                                <tr>
                                <td colspan="3">
                                
                                 <asp:Panel ID="PanelBannerBody" runat="server">
                                                          
                                <table width="100%" cellpadding="0" cellspacing="2" border="0">
                                    
                                 <tr>
                                 <td width="23%" align="left" valign="top">
                                     <asp:Literal ID="LtrDispWebsite2" runat="server" Text="Display at Website"></asp:Literal>
                                     </td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%" align="left">
                                     <asp:CheckBox ID="chkActive_Banner" runat="server" />
                                     <font class="HelpInputCss" >&nbsp; &nbsp; [if ticked, the uploaded image will be made as your selected Banner.] </font> 
                                     </td>
                                </tr>
                                
                                    <tr>
                                        <td align="left" valign="top" width="23%">
                                            <asp:Literal ID="Literal4" runat="server" 
                                                Text="Upload Own Company Banner image"></asp:Literal>
                                        </td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td align="left" width="75%">
                                            <asp:FileUpload ID="FU_Banner" runat="server" />
                                            &nbsp; &nbsp;
                                            <asp:Button ID="btn_Banner_Logo0" runat="server" CssClass="stdButtonNormal" 
                                               Text="Upload Banner" onclick="btn_Banner_Logo0_Click" />
                                            &nbsp;
                                            <asp:Label ID="lblUpMessageBanner" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>
                                            <asp:RegularExpressionValidator ID="FileUploadValidator2" runat="server" 
                                                ControlToValidate="FU_Banner" Enabled="true" 
                                                ErrorMessage="<br/>Only jpg or gif type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Ss][Ww][Ff])"></asp:RegularExpressionValidator>
   
                                             <asp:CustomValidator ID="CustomVdr_Banner" runat="server" ControlToValidate="FU_Banner"
                                                                 ErrorMessage="Image size should not be greater than 70KB." OnServerValidate="CustomVdr_Banner_ServerValidate"></asp:CustomValidator>
   
   
                                        </td>
                                    </tr>
                                      <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td class="HelpInputCss" align="right">&nbsp;
                                 <asp:Literal ID="Literal5" runat="server" 
                                 Text="[ For better Page Settings and presentation, &lt;br&gt; please upload Banner image with size &lt;= (width=820 &amp; height=200) image. &lt;br&gt;The Banner image size cannot exceed 70KB]"></asp:Literal>
                                </td>
                                </tr>
                                
                                    <tr>
                                        <td align="left" valign="top" width="23%">
                                            <asp:Literal ID="LtrSelectBanner" runat="server" Text="Select Banner image"></asp:Literal>
                                        </td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td align="left" style="white-space: nowrap" width="75%">
                                            <asp:RadioButtonList ID="rdoBannerImage" runat="server" CellPadding="5" 
                                                CellSpacing="5">
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                
                                </table>
                                </asp:Panel>
                                <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" 
                                         TargetControlID="PanelBannerBody" CollapseControlID="PanelBannerHead" 
                                         ExpandControlID="PanelBannerHead" CollapsedImage="~/Images/Expand2.gif" 
                                         ExpandedImage="~/Images/Collapse2.gif" ImageControlID="ImgBannerEC" 
                                         CollapsedSize="0" CollapsedText=" Expand to view available banner templates ..." ExpandedText="Collapse ..." 
                                         TextLabelID="lblBanner" Collapsed="True">
                                     </asp:CollapsiblePanelExtender>      
                                </td>
                                </tr>
                                
                                
                                
                                 <tr>
                                  <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>
                                
                                 <tr>
                                 <td colspan="3">
                                     <asp:Panel ID="Panel_CompanyHead" runat="server">
                                     <div id="dvPanelCompanyHead" class="PanelCss" >
                                            <table width="100%">
                                                <tr>
                                                    <td align="left"><font class="PanelCss_Head">
                                                 <asp:Literal ID="Literal1" runat="server" Text="WebSite Footer"></asp:Literal>
                                                  </font>
                                                        
                                                    </td>
                                                    <td align="right" width="250px">
                                                    <asp:Label runat="server" ID="textLabel" />&nbsp; 
                                                        <asp:Image ID="Image1" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                     </asp:Panel>
                                 </td>
                                </tr>
                                
                                
                                <tr>
                                 <td colspan="3">
                                  <asp:Panel ID="Panel_CompanyBody" runat="server">
                                                          
                                    <table width="100%" cellpadding="0" cellspacing="2" border="0">
                                   <%-- <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrCompanyName" runat="server" Text="Company Name"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtCompanyName" Enabled="false" CssClass="stdTextField2" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox></td>
                                </tr>
                                
                                 <tr>
                                 <td align="left"> 
                                     &nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left"> 
                                     &nbsp;</td>
                                </tr>
                               
                                        <tr>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td align="left"> 
                                                <asp:Literal ID="LtrEnterNew" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Literal ID="LtrCompanyDesc" runat="server" Text="Company Description"></asp:Literal>
                                            </td>
                                            <td>
                                                &nbsp;:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCompanyInfo" runat="server" CssClass="stdTextArea2"  
                                                    Enabled="false" Rows="2" Text='<%# Bind("CompanyInfo") %>' TextMode="MultiLine" 
                                                    Wrap="true"></asp:TextBox>
                                            </td>
                                        </tr>
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>--%>
                                
                                <tr>
                                 <td align="left"><asp:Literal ID="LtrCopyRightsInfo" runat="server" Text="CopyRights Information"></asp:Literal></td>
                                 <td>&nbsp;</td>
                                 <td align="left"> 
                                     Default :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                     <asp:RadioButton ID="rdoCopyRightsDefault" GroupName="grpCopyRights" runat="server" 
                                         Text="" />
                                     </td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left"> 
                                 Enter New :&nbsp; &nbsp;
                                 <asp:RadioButton ID="rdoCopyRightsNewText" GroupName="grpCopyRights" runat="server" 
                                         Text="" />
                                     <asp:TextBox ID="txtNewCopyRightsInfo" CssClass="stdTextField2" runat="server" 
                                         Text='<%# Bind("CopyRightsInfo") %>'></asp:TextBox>
                                         
                                         </td>
                                </tr>
                                 
                                 
                                 </table>
                                  </asp:Panel>   
                                     <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" 
                                         TargetControlID="Panel_CompanyBody" CollapseControlID="Panel_CompanyHead" 
                                         ExpandControlID="Panel_CompanyHead" CollapsedImage="~/Images/Expand2.gif" 
                                         ExpandedImage="~/Images/Collapse2.gif" ImageControlID="Image1" 
                                         CollapsedSize="0" CollapsedText=" Expand to view company details ..." ExpandedText="Collapse ..." 
                                         TextLabelID="textLabel" Collapsed="True">
                                     </asp:CollapsiblePanelExtender>        
                                 </td>
                                </tr>
                                
                                
                                
                                 
                                
                                
                                
                               
                                <tr>
                                 <td class="style2"></td>
                                 <td class="style2"></td>
                                 <td class="style2"></td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                    <%-- <asp:ImageButton ImageUrl='' ID='imgDelete' OnClick='imgDelete_Click' ToolTip='Delete logo' AccessKey='' runat='server'/>--%>
                                     <asp:Button ID="Button1" CssClass="stdbuttonCRUD" runat="server" 
                                         Text="SAVE web page settings" onclick="Button1_Click" />
                                    </td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                     &nbsp;</td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td class="font_stdupdateMsg"><b>NOTE</b> </td>
                                 <td>:</td>
                                 <td align="left" class="font_stdupdateMsg">
                                     For subdomain, Only LogoTemplate1 and BannerTemplate 1 will be Selected.
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

