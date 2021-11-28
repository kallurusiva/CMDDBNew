<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_MobileHome.aspx.cs" Inherits="Admin_Ad_MobileHome" %>

<%@ Register src="Ad_Mobi_Menu.ascx" tagname="Ad_Mobi_Menu" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                    <tr style="height:30px;">
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
                        <table id="tblButtons" cellpadding="0" cellspacing="2" width="100%">
                            <tr>
                    <td>&nbsp;</td>
                                 <td align="left" class="tblFormLabel"> 
                                     Select Button / Links&nbsp; to appear at Mobile Website</td>
                            
                                </tr>
                                
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                            </tr>
                            
                            
                   <tr>
                        <td>&nbsp;</td>
                        <td>
                        <table id="tblINfo" cellpadding="0" cellspacing="2" width="100%">
                        <tr>
                        <td align="left" class="FontSubHeader">Enter Title </td>
                        <td>&nbsp;</td>
                        </tr>
                        <tr>
                        <td class="tblFormLabel">&nbsp;</td>
                        <td align="left"  class="tblFormText">
                            &nbsp;</td>
                        </tr>
                        <tr>
                        <td class="tblFormLabel">Title Line 1</td>
                        <td align="left"  class="tblFormText">
                            <asp:TextBox ID="txtTitle1" runat="server" CssClass="stdTextField1" 
                                MaxLength="30"></asp:TextBox>
                            &nbsp;</td>
                        </tr>
                        <tr>
                        <td  class="tblFormLabel">Title LIne 2</td>
                        <td align="left"  class="tblFormText">
                            <asp:TextBox ID="txtTitle2" runat="server" CssClass="stdTextField1" 
                                MaxLength="30"></asp:TextBox>
                            &nbsp;</td>
                        </tr>
                        
                        <tr>
                        <td  class="tblFormLabel">&nbsp;</td>
                        <td align="left"  class="tblFormText">
                            &nbsp;</td>
                        </tr>
                        
                        </table>
                        
                        </td>
                     </tr>
                    
                      <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                            </tr>
                            
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left" class="FontSubHeader">Default Buttons </td>
                        </tr>
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                            
                            <asp:CheckBoxList ID="chkDefaultBtns" CssClass="ChkBoxStyle ChkBoxStyle2" runat="server">
                            </asp:CheckBoxList>
                        </td>
                        </tr>
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">&nbsp;</td>
                        </tr>
                    
                    
                     <tr>
                        <td>&nbsp;</td>
                        <td align="left" class="FontSubHeader">Own Mobile Buttons</td>
                        </tr>
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                            <asp:CheckBoxList ID="chkBottonBtns"  CssClass="ChkBoxStyle ChkBoxStyle2" runat="server">
                            </asp:CheckBoxList>
                        </td>
                        </tr>
                    
                    
                   
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">&nbsp;</td>
                        </tr>
                     
                     
                       <tr>
                        <td>&nbsp;</td>
                        <td align="left" class="FontSubHeader">Social Media Buttons</td>
                        </tr>
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                            <asp:CheckBoxList ID="chkSocialBtns" CssClass="ChkBoxStyle ChkBoxStyle2" runat="server">
                            </asp:CheckBoxList>
                        </td>
                        </tr>
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                            </tr>
                    
                    
                   
                      
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left" class="FontSubHeader">Bottom Link Buttons</td>
                        </tr>
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left" align="left">
                            <asp:CheckBoxList ID="chkOwnBtns" CssClass="ChkBoxStyle ChkBoxStyle2" runat="server">
                            </asp:CheckBoxList>
                        </td>
                        </tr>
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">&nbsp;</td>
                        </tr>
                    
                    
                    
                    
                    
                   
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">&nbsp;</td>
                        </tr>
                    
 
                   
                    
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">&nbsp;</td>
                        </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">&nbsp;&nbsp;
                            <asp:Button ID="btnSave" CssClass="stdbuttonCRUD" runat="server" Text="SAVE Mobile Page Settings" 
                                onclick="btnSave_Click1" />
                        </td>
                            </tr>
                        
                        </table>
                        
                        </td>
                        <td>
                            &nbsp;</td>
                        <td valign="top">
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
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                   </table>
                 
            </td></tr></table>
            
            </td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    


    </form>

</asp:Content>

