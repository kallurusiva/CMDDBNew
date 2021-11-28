<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_MobileHome2.aspx.cs" Inherits="Admin_Ad_MobileHome2" %>

<%@ Register src="Ad_Mobi_Menu.ascx" tagname="Ad_Mobi_Menu" tagprefix="uc1" %>

<%@ Register TagPrefix="cc1" Namespace="ComboImg" Assembly="ComboImg" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style> 
    <link href="dd.css" rel="stylesheet" type="text/css" />

<style type="text/css">
.modalBackground { 
background-color:#fff; 
filter:alpha(opacity=70); 
opacity:0.7px; 
} 

</style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:Ad_Mobi_Menu ID="Ad_Mobi_Menu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form2" runat="server">

       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
       
       
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../../Images/inf_Error.gif" 
                     alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td align="center">
            
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
             
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;<asp:Literal ID="ltrMobileSettings" runat="server"></asp:Literal></td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../../Images/table_top_Rightarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="98%">
                    <tr style="height:20px;">
                        <td width="5%">&nbsp;</td>
                        <td width="35%">&nbsp;</td>
                        <td width="5%">&nbsp;</td>
                        <td width="45%">&nbsp;</td>
                        <td width="5%">&nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td valign="top">
                        <table id="tblSettings" cellpadding="0" cellspacing="0" width="100%" class="stdtable_BdrBlue_BkgGrey">
                        <tr>
                            <td align="left" class="FontBHeader">Templates</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg" >
                                &nbsp;Select Templates for the Mobile Website.</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowText" >
                                <asp:DropDownList ID="ddlTemplates" CssClass="stdDropDown2" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg ddlimg"  >
                                &nbsp;</td>
                        </tr>
                       
                        
                        <tr>
                            <td align="left" class="FontBHeader">Title Rows</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg">Enter Title Row 1</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1  FontBRowText">
                                <asp:TextBox ID="txtTitle1" runat="server" CssClass="stdTextField" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg">Enter Title Row2</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowText">
                                <asp:TextBox ID="txtTitle2" CssClass="stdTextField" Width="400px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg">
                                &nbsp;</td>
                        </tr>
                       
                        
                        <tr>
                            <td align="left" class="FontBHeader">Buttons</td>
                        </tr>
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg" >
                                &nbsp;Select buttons to show/Hide.</td>
                        </tr>
                        <tr>
                        <td class="style1">
                                <div id="divbuttomHTML" runat="server">
                                
                                </div>
                            
                        </td>
                        </tr>
                       
                
                        <tr>
                        <td class="style1 FontBRowText ChkBoxStyle">
                            <asp:CheckBoxList ID="chkAboutBtns"  CssClass="chkboxBottom" runat="server">
                            </asp:CheckBoxList></td>
                        </tr>
                       
                        
                        <tr>
                        <td class="style1 FontBRowTextBkg" style='padding-left: 40px;' >
                                My Mobile Buttons</td>
                        </tr>
                       
                        
                      
                        
                        <tr>
                        <td class="style1 FontBRowText FontBRowText3 ChkBoxStyle">
                            <asp:CheckBoxList ID="chkOwnBtns"  CssClass="chkboxBottom" runat="server">
                            </asp:CheckBoxList></td>
                        </tr>
      
       
                        
                        <tr>
                        <td class="style1 FontBRowText ChkBoxStyle">
                            <asp:CheckBoxList ID="chkOtherButtons" CssClass="chkboxBottom" runat="server">
                            </asp:CheckBoxList></td>
                        </tr>
                       
                        
                      
                        
                        <tr>
                        <td class="style1 FontBRowTextBkg" style='padding-left: 40px;'>
                                Social Media Buttons</td>
                        </tr>
                       
                        
                      
                        
                        <tr>
                        <td class="style1 FontBRowText FontBRowText3 ChkBoxStyle">
                            <asp:CheckBoxList ID="chkSocialBtns"  CssClass="chkboxBottom" runat="server">
                            </asp:CheckBoxList></td>
                        </tr>
                       
                        
               
                        
                        <tr>
                        <td class="style1 FontBRowText ChkBoxStyle">
                            <asp:CheckBoxList ID="chkBottonBtns"  CssClass="chkboxBottom" runat="server">
                            </asp:CheckBoxList></td>
                        </tr>
                       
                        
                      
                        
                            <tr>
                                <td class="style1 FontBRowText ChkBoxStyle">
                                    &nbsp;</td>
                            </tr>
                       
                        
                      
                        
                        </table>
                        
                        </td>
                        <td>
                            &nbsp;</td>
                        <td valign="top" align="center" style="background-image: url(../../Images/Mobile/Templates/mbPreview.png); background-repeat: no-repeat;">
                             <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="50">
                                <ProgressTemplate>
                                    <div ID="progress" runat="server" visible="true">
                                        <img ID="Img1" runat="server" src="~/Images/Loader1.gif" />Loading Mobile Website Preview...
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        <div id="dvFrame" style="padding-top: 90px; padding-left:34px; min-height: 660px;" align="left">
                         <iframe id="mobileIframe" width="320px" height="570px" frameborder="0" runat="server"></iframe>
                         </div>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                           <asp:Button ID="btnSave" CssClass="stdbuttonCRUD" runat="server" Text="SAVE Mobile Page Settings and Preview" 
                                onclick="btnSave_Click1" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td align="left" class="FontNote">
                            NOTE:&nbsp; Preview shown above may differ slightly based on the mobile being used.</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                   </table>
                 
            </td></tr></table>
            
               
                </ContentTemplate>
                </asp:UpdatePanel>
                
            </td></tr><tr>
            <td>
                &nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                <asp:ModalPopupExtender ID="ModalPopupExtender1" 
                BackgroundCssClass="modalBackground" 
                DropShadow="true" 
               
                PopupControlID="Panel1" TargetControlID="HyperLink1" 
                
                runat="server">
                </asp:ModalPopupExtender>
                
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none;"> 
                This is basic modal popup. 
                <br /><br /> 
                <%--<asp:Button ID="btnOk" runat="server" Text="Ok" /> 
                <asp:Button ID="btnClose" runat="server" Text="Close Me" /> --%>
                </asp:Panel> 
                
                
                </td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    


    </form>

</asp:Content>

