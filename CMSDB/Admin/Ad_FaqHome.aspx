<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_FaqHome.aspx.cs" Inherits="Admin_Ad_FaqHome" %>

<%@ Register src="SideMenu_Faq.ascx" tagname="SideMenu_Faq" tagprefix="uc1" %>

<%@ Register src="../SuperAdmin/SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc2" %>

<%@ Register src="LeftMenu_Faq.ascx" tagname="LeftMenu_Faq" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:LeftMenu_Faq ID="LeftMenu_Faq1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="form2" runat="server">



<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>


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
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                      
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrfaqHead" runat="server"></asp:Literal> 
                        </td>
                        <td width="30%">
                            &nbsp;</td>
                      
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%" align="left">
                            &nbsp;
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="50" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/>Processing... Please wait...
                             </div>
                            </ProgressTemplate>
                            
                            </asp:UpdateProgress>
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                          <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                            <table cellpadding="0" cellspacing="0" class="tblForm" width="100%">
                                <tr>
                                    <td width="30%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel">
                                        Current appearance status </td>
                                    <td class="tblFormText">
                                        <asp:RadioButtonList ID="rdoAppearanceStatus"  CellPadding="5" runat="server">
                                        <asp:ListItem Text="Display items created by System Administrator at Website" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Do not Display items created by System Administrator at Website" Value="1"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                         <td  class="tblFormText" align="center">
                                             <asp:Button ID="btnSave" runat="server" Text="SET Status" 
                                                 CssClass="stdButtonNormal" onclick="btnSave_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                         <table cellpadding="0" cellspacing="0" class="tblForm" width="100%">
                                <tr>
                                    <td width="25%">
                                        &nbsp;</td>
                                    <td width="25%">
                                        &nbsp;</td>
                                    <td width="25%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel">&nbsp; FAQ </td>
                                    <td class="tblFormLabel">&nbsp; created by ADMIN </td>
                                    <td class="tblFormLabel">created by ME</td>
                              
                                </tr>
                                
                                  <tr>
                                    <td  class="tblFormLabel" >
                                        &nbsp;</td>
                                    <td class="tblFormText" >
                                        &nbsp;</td>
                                    <td  class="tblFormText" >
                                        &nbsp;</td>
                                    
                                </tr>
                                
                                
                                <tr>
                                    <td class="tblFormLabel">in English</td>
                                    <td class="tblFormText">
                                        <asp:Label ID="lblCnt_AdEng" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="tblFormText">
                                        <asp:Label ID="lblCnt_SfEng" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td  class="tblFormLabel">
                                        in Bahasa Melayu</td>
                                    <td  class="tblFormText">
                                        <asp:Label ID="lblCnt_AdBhM" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td  class="tblFormText">
                                        <asp:Label ID="lblCnt_SfBhM" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="tblFormLabel">
                                        in Chinese</td>
                                    <td  class="tblFormText">
                                        <asp:Label ID="lblCnt_AdChn" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td  class="tblFormText">
                                        <asp:Label ID="lblCnt_SfChn" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="tblFormLabel">
                                        &nbsp;</td>
                                    <td  class="tblFormText">
                                        &nbsp;</td>
                                    <td  class="tblFormText">
                                        &nbsp;</td>
                                </tr>
                                
                                
                           </table>
                                
                        
                        
                        
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
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
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <%--<asp:Repeater ID="RpControl" runat="server" 
                                onitemdatabound="RpControl_ItemDataBound">
                            <HeaderTemplate>
                            
                             <table cellpadding="0" cellspacing="0" class="tblForm" width="100%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="70%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel">&nbsp; Items </td>
                                    <td  class="tblFormLabel">&nbsp; Created By </td>
                                    <td  class="tblFormLabel" align="left">&nbsp; &nbsp; &nbsp; Total No. of Items</td>
                              
                                </tr>
            
                            </HeaderTemplate>
                            
                            
                            <ItemTemplate>
                                <asp:HiddenField ID="hidUSerId" Value='<%# Eval("UserID") %>' runat="server" />
                                <asp:HiddenField ID="hidLanguage" Value='<%# Eval("LgType") %>' runat="server" />
                                <asp:HiddenField ID="hidItemCount" Value='<%# Eval("itemCount") %>' runat="server" />
                                <asp:HiddenField ID="hidUserType" Value='<%# Eval("UserType") %>' runat="server" />
                                <asp:HiddenField ID="hidUserLogin" Value='<%# Eval("LoginName") %>' runat="server" />
                                
                                <tr>
                                    <td  class="tblFormLabel" align="left">
                                      <asp:Literal ID="ltrItemValue" runat="server"></asp:Literal>
                                    </td>
                                    
                                    <td class="tblFormText" align="left">
                                      <asp:Literal ID="ltrCreateBy" Text='<%# Eval("LoginName") %>' runat="server"></asp:Literal>
                                    </td>
                                    <td  class="tblFormText" align="left">
                                      <asp:Literal ID="ltrTotalItems" Text='<%# Eval("itemCount") %>' runat="server"></asp:Literal>
                                    </td>
                                    
                                </tr>
                                
                            </ItemTemplate>
                            <FooterTemplate>
                                    <tr>
                                    <td>&nbsp; </td>
                                    <td>&nbsp; </td>
                                    <td>&nbsp; </td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
        
                            </asp:Repeater>--%>
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
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
      </ContentTemplate>  
    </asp:UpdatePanel>
    

    </form>
</asp:Content>

