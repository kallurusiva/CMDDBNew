<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Mobile/AdminMasterDIYMB.master" AutoEventWireup="true" CodeFile="Ad_MobileOwnButtonCreate.aspx.cs" Inherits="Admin_Ad_MobileOwnButtonCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="Ad_Mobi_Menu.ascx" tagname="Ad_Mobi_Menu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script language="javascript" type="text/javascript">

        function fnDeleteImage(imgID) {
            //alert(imgID);
            location.href = 'Ad_MobileOwnButtonCreate.aspx?ImgToDelete=' + imgID;
        
        }
    
    </script>
    
    
    <form id="form2" runat="server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>


<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
       
       
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../../Images/inf_Error.gif" alt="MessageImage"/></td>
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
                      
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;<asp:Literal ID="ltrOwnButtonHeader" runat="server"></asp:Literal></td>
                      
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr style="height:30px;">
                        <td width="2%">&nbsp;</td>
                        <td width="20%">&nbsp;</td>
                        <td width="76%"><%--<div id="dvImgUploadError" class="dvErrorNote" visible="false" runat="server"></div>--%></td>
                        <td width="2%">&nbsp;</td>
                    </tr>
                    
                    
                    <%--<tr>
                        <td>&nbsp;</td>
                        <td class="tblFormLabel1" align="right">Display at Website</td>
                        <td class="tblFormText1" align="left">
                            <asp:CheckBox ID="chkActive" CssClass="HelpInputCss" runat="server" />
                        </td>
                        <td >
                            &nbsp;</td></tr>--%>
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td class="tblFormLabel1" align="right">&nbsp;</td>
                        <td class="tblFormText1" align="left" valign="bottom">
                            <font class="font_disabled8">Please use a shorter button name for better representation on the mobile device. [Max 15 chars]</font></td>
                        <td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            Button Name</td>
                        <td  class="tblFormText1" align="left">
                            <asp:TextBox ID="txtButtonName" runat="server" CssClass="stdTextField1" 
                                MaxLength="15"></asp:TextBox>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtButtonName" ErrorMessage="Button Name cannot be empty" 
                                ValidationGroup="vgCheck"></asp:RequiredFieldValidator>
                        </td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                 
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            Select ICON for the button</td>
                        <td  class="tblFormText1" align="left">
                            
                            <table width="100%" cellpadding="0" cellspacing="2" border="0">
                                
                                <tr>
                                 <td width="23%"  align="left"><asp:Literal ID="LtrDispWebsite" Text="Display at Website" runat="server"></asp:Literal></td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%" align="left">
                                     <asp:CheckBox ID="chkActive_Logo" runat="server" />
                                     <font class="HelpInputCss" >&nbsp; &nbsp; [if ticked, the uploaded icon will be made as your selected icon.] </font> 
                                    </tr>
                                
                                
                                    <tr>
                                        <td align="left">
                                            <asp:Literal ID="Literal2" runat="server" 
                                                Text="Upload My Own Icon"></asp:Literal>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;
                                            <%--<asp:AsyncFileUpload ID="AsyncFup_Logo" runat="server" UploaderStyle="Modern" />--%>
                                            <asp:FileUpload ID="FU_Logo" runat="server" />
                                            &nbsp; &nbsp;
                                            <%--<asp:Button ID="btn_FU_Logo" runat="server" CssClass="stdButtonNormal" 
                                                onclick="btn_FU_Logo_Click" ValidationGroup="vgCheck" Text="Upload Icon" />--%>
                                            &nbsp;
                                            <asp:Label ID="lblUpMessage" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>
                                                
                                            <asp:RegularExpressionValidator ID="FileUploadValidator" runat="server" 
                                                ControlToValidate="FU_Logo" Enabled="true"  ValidationGroup="vgCheck" 
                                                ErrorMessage="<br/>Only jpg, png or gif type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                
                                             <asp:CustomValidator ID="CustomVdr_Logo" runat="server" ControlToValidate="FU_Logo"  ValidationGroup="vgCheck"
                                                                    ErrorMessage="Image size should not be greater than 30KB." OnServerValidate="CustomVdr_Logo_ServerValidate"></asp:CustomValidator>
   
                                            
                                        </td>
                                    </tr>
                                
                                
                                  <tr class="BlankWhiteHorizontalLine">
                                 
                                 <td colspan="3" style="background-color: #F3F5EB;" class="HelpInputCss" align="right">&nbsp;
                                 <asp:Literal ID="LtrHelpInput_UploadLogo" runat="server" 
                                 Text="[ For better Page Settings and presentation, &lt;br&gt; please upload logo image with size &lt;= (max-width=120 &amp; max-height=60) image. &lt;br&gt;The Logo image size cannot exceed 30KB ]"></asp:Literal>
                                </td>
                                </tr>
                                
                                
                                <tr>
                                 <td  align="left">( or )<br />
                                     <asp:Literal ID="LtrSelectLogos" runat="server" Text="Select LOGO image"></asp:Literal></td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                 
                                     <asp:RadioButtonList ID="rdoIconImage" runat="server" CellPadding="5" 
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
                            
                            </td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            &nbsp;</td>
                        <td  class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                       <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            Add Picture to the Content</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;
                             <asp:Image ID="ImgUserPicture" CssClass="dvUserPhotoCss" BorderWidth="1px" ImageUrl="" BorderColor="#ACA9A9" AlternateText="aspimg" runat="server" /> &nbsp;
                             <asp:FileUpload ID="FU_Picture" runat="server" />
                                            &nbsp; &nbsp;
                                            <%--<asp:Button ID="btn_FU_Picture" runat="server" CssClass="stdButtonNormal" 
                                               ValidationGroup="vgCheck" 
                                Text="Upload  Picture" onclick="btn_FU_Picture_Click" />--%>
                                            &nbsp;
                                            <asp:Label ID="lblPIC_UpMessage" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>
                                                
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                ControlToValidate="FU_Picture" Enabled="true"  ValidationGroup="vgCheck" 
                                                ErrorMessage="<br/>Only jpg, png or gif type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                
                                             <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="FU_Picture"  ValidationGroup="vgCheck"
                                                                    ErrorMessage="Image size should not be greater than 100KB." OnServerValidate="CustomVdr_Picture_ServerValidate"></asp:CustomValidator>
   
                                            
                            <br />
                            <asp:Button ID="btnRemoveImage" CssClass="stdbuttonAction" runat="server" 
                                Text="Click here to remove / delete Image" onclick="btnRemoveImage_Click" />
   
                                            
                            </td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            Add Text Content</td>
                        <td  class="tblFormText1" align="left">
                            <asp:TextBox ID="txtBtnContent" runat="server" CssClass="stdTextArea2" Rows="6" 
                                TextMode="MultiLine" ToolTip="Enter the button web content here" 
                                Width="400px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            &nbsp;</td>
                        <td  class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            Youtube video link </td>
                        <td  class="tblFormText1" align="left">
                            <asp:TextBox ID="txtVideoLink" runat="server" CssClass="stdTextField2"></asp:TextBox>
                            </td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                 
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            &nbsp;</td>
                        <td  class="tblFormText1" align="left">
                            <asp:Button ID="btnSave" CssClass="stdbuttonCRUD" runat="server" 
                                Text="Save Button Content and Settings" onclick="btnSave_Click" 
                                ValidationGroup="vgCheck" />
                        </td>
                        <td  >
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="right">
                            &nbsp;</td>
                        <td  class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    
                   </table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    
    


    </form>

</asp:Content>

