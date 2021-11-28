<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Settings_HomePage.aspx.cs" Inherits="Admin_Settings_HomePage" %>

<%@ Register src="SideMenu_PgSettings.ascx" tagname="SideMenu_PgSettings" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 17px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SideMenu_PgSettings ID="SideMenu_PgSettings1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

<form id="SetPgForm" runat="server" enctype="multipart/form-data">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

<ContentTemplate>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
                 </td>
        </tr>
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
                            &nbsp; Home Page Settings</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" class="stdtableBorder_Main" width="96%">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="20%">
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="40%">
                            &nbsp;</td>
                        <td width="30%">
                            &nbsp;</td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left" colspan="4" class="font_stdupdateMsg">
                            [ Shown below are the various items which would be showed on the Home page.&nbsp;
                            Please check / uncheck for the items you want to show/Hide ]</td>
                        
                       
                        <td>&nbsp;</td>
                    </tr>
                    <tr  class="BlankWhiteHorizontalLine"> 
                        <td>
                            </td>
                        <td align="left">
                            </td>
                        <td >
                            </td>
                        <td style="text-align: left" >
                            </td>
                        <td >
                            </td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr style="height: 50px;">
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Literal ID="LtrSelectTopMenuLinks" Text="Select Top menu Links" runat="server"></asp:Literal>
                            </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:CheckBoxList ID="chkList_TopMenuItems" runat="server" RepeatColumns="3" 
                                RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:Button ID="BtnMyOwnPage" runat="server" Text="Create my Own Menu Link" />
                        </td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr  class="BlankWhiteHorizontalLine">
                        <td>
                            &nbsp;</td>
                        <td >
                               
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                    </tr>
                    <%--<tr >
                        <td>
                            &nbsp;</td>
                        <td >
                               
                            Show the following </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:CheckBox ID="chkNews" runat="server" Text="Recent News" />
&nbsp;&nbsp;
                            <asp:CheckBox ID="chkEvents" runat="server" Text="Upcoming Events" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    
                    
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Upload Logo Image</td>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:AsyncFileUpload ID="AsyncFup_Logo" runat="server" UploaderStyle="Modern" />
                        </td>
                        <td class="HelpInputCss2">
                              <asp:Literal ID="LtrHelpInput_UploadLogo" runat="server" 
                                Text="[ For better Page Settings and presentation, &lt;br&gt; please upload logo image with size &lt;= (max-width=180 &amp; max-height=75) image. &lt;br&gt;The Logo image size cannot exceed 1MB ]"></asp:Literal>
                        
                        </td>
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
                        <td align="left" >
                          &nbsp; </td>
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
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            Upload Banner Image</td>
                        <td>
                        </td>
                        <td style="text-align: left">
                            <asp:AsyncFileUpload ID="AsyncFup_Banner" runat="server" 
                                UploaderStyle="Modern" />
                        </td>
                        <td class="HelpInputCss2">
                            <asp:Literal ID="LtrHelpInput_UploadLogo0" runat="server" 
                                Text="[ For better Page Settings and presentation, &lt;br&gt; please upload logo image with size &lt;= (width=820 &amp; height=200) image. &lt;br&gt;The Logo image size cannot exceed 1MB ]"></asp:Literal></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="left" >
                         &nbsp;
                            </td>
                        <td >
                           &nbsp;  
                       </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                        </td>
                        <td class="style2">
                        </td>
                        <td class="style2">
                        </td>
                        <td class="style2" style="text-align: left">
                        </td>
                        <td class="style2">
                        </td>
                        <td class="style2">
                        </td>
                    </tr>
                    
                    
                    
                    
                    <tr  class="BlankWhiteHorizontalLine">
                        <td>
                            &nbsp;</td>
                        <td >
                               
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                    </tr>
                                        
                    <tr >
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Literal ID="LtrCompanyName" Text="Company Name" runat="server"></asp:Literal>  
                            </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtCompanyName" CssClass="stdTextField2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <div id="dv22" class="HelpInputCss2" runat="server">
                            Select default if your company name is same as your domain.com or else enter company name. <br />
                            Please note the entered Company name will be automatically saved to your Account profile as well. 
                            </div>
                            </td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="LtrCompanyInfo" Text="Company Information" runat="server"></asp:Literal>
                            </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtCompanyInfo" CssClass="stdTextArea2" runat="server" 
                                Rows="3" TextMode="MultiLine" ToolTip="Enter an Anwer for FAQ question" 
                                ValidationGroup="vgFaqCheck"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            Enter Copy Right information</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtCopyRightInfo" CssClass="stdTextField2" runat="server" 
                                ToolTip="Enter a FAQ Question"  ValidationGroup="vgFaqCheck" ></asp:TextBox>
                            </td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr  class="BlankWhiteHorizontalLine">
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td colspan="3" style="text-align: left" >
                        
                        </td>
                       <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Literal ID="LtrSelectCommApps" Text="Selected Follows Us links" runat="server"></asp:Literal>
                            </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:CheckBoxList ID="chkLst_CommLinks" runat="server" RepeatColumns="4" 
                                RepeatDirection="Horizontal">
                                
                            </asp:CheckBoxList>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr  class="BlankWhiteHorizontalLine">
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td >
                            </td>
                        <td  >
                            </td>
                        <td  >
                            </td>
                        <td style="text-align: left" >
                            <asp:Button ID="btnSave" runat="server" CssClass="stdbuttonAction" 
                                Text="Save" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonAction" 
                                Text="Cancel" onclick="btnCancel_Click" />
                                <%--&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>" />--%>
                        </td>
                        <td>&nbsp;</td>
                        <td >
                            </td>
                    </tr>
                    <tr>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td align="left" >
                            </td>
                        <td >
                            </td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                     &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
 </ContentTemplate>
 
 </asp:UpdatePanel>
</form>
</asp:Content>

