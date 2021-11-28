<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_LanguageViewEdit.aspx.cs" Inherits="SuperAdmin_SA_LanguageViewEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SA_SideMenu_Settings.ascx" tagname="SA_SideMenu_Settings" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SA_SideMenu_Settings ID="SA_SideMenu_Settings1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

<form id="LgForm" runat="server">
    
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
                            &nbsp; <asp:Literal ID="LtrLangAdd" runat="server" 
                                Text="Language List"></asp:Literal>&nbsp;
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
                                 <td width="2%">&nbsp;</td>
                                 <td width="98%">&nbsp;</td>
                                 <td width="2%">&nbsp;</td>
                                </tr>
                                <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:GridView ID="GridLanguage" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="LangID"
                                    CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
                                        AlternatingRowStyle-CssClass="rowalt" 
                                         FooterStyle-CssClass ="rowfooter"
                                        onrowcancelingedit="GridLanguage_RowCancelingEdit" 
                                        ShowFooter="True" onrowdeleting="GridLanguage_RowDeleting" 
                                        onrowupdating="GridLanguage_RowUpdating" onrowediting="GridLanguage_RowEditing" 
                                    >
                                    <Columns>
                                    <asp:TemplateField HeaderText="Sl No">
                                      <ItemTemplate>
                                       <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                          <asp:HiddenField ID="hdLangID" Value='<%# Eval("LangID")  %>' runat="server" />
                                      </ItemTemplate>
                                      <ItemStyle Width="60px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Language Code" >
                                  <ItemTemplate>
                                   <asp:Label ID="lblLangCode" runat="server" Text='<%# Bind("LangCode")  %>'/>
                                  </ItemTemplate>
                                   <FooterTemplate>
                                      <asp:TextBox ID="txt_NewLangCode" Text='' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="vgInsertMenuItems" runat="server" ErrorMessage="<br>Language Code cannot be empty" ControlToValidate="txt_NewLangCode"></asp:RequiredFieldValidator>
                                  </FooterTemplate>
                                  
                                  <ItemStyle Width="100px" HorizontalAlign="Left"  />
                                  <FooterStyle HorizontalAlign="Left" />
                                  
                                 </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Language Name" >
                                  <ItemTemplate>
                                   <asp:Label ID="lblLangName" runat="server" Text='<%# Bind("LangName")  %>'/>
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                      <asp:TextBox ID="txtLangName" Text='<%# Bind("LangName")  %>' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="vgEditMenuItems" runat="server" ErrorMessage="<br>Language Name cannot be empty" ControlToValidate="txtLangName"></asp:RequiredFieldValidator>
                                  </EditItemTemplate>
                                  <FooterTemplate>
                                      <asp:TextBox ID="txt_NewLangName" Text='' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="vgInsertMenuItems" runat="server" ErrorMessage="<br>Language Name cannot be Empty" ControlToValidate="txt_NewLangName" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                  </FooterTemplate>
                                  <ItemStyle Width="150px" HorizontalAlign="Left"  />
                                   <FooterStyle HorizontalAlign="Left" />
                                 </asp:TemplateField>
                                                                  
                             
                                 <asp:TemplateField HeaderText="Functions">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit News" runat="server" ImageUrl="~/Images/imgEdit2.gif" />
                                      <%--<asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete News" OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />--%>
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                  
                                      <asp:ImageButton ID="ImgUpdate" CommandName="UPDATE"  ValidationGroup="vgEditMenuItems" ToolTip="Update News" runat="server" ImageUrl="~/Images/imgUpdate.gif" />
                                      <asp:ImageButton ID="ImgCancel" CommandName="CANCEL" ToolTip="Cancel" runat="server" ImageUrl="~/Images/imgCancel.gif" />
                                      
                                  </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:Button ID="BtnAddNew" CssClass="stdbuttonCRUD" OnClick="AddNewMenuItem_Click"  ValidationGroup="vgInsertMenuItems" runat="server" Text="Add New Language" />
                                  </FooterTemplate>
                                  <ItemStyle Width="150px" HorizontalAlign="center"  />
                                 </asp:TemplateField>
                                
                             
                             
                             </Columns>
                             
<HeaderStyle CssClass="rowheader"></HeaderStyle>

<AlternatingRowStyle CssClass="rowalt"></AlternatingRowStyle>
                             
                                    </asp:GridView>
                                
                                </td>
                                <td>&nbsp;</td>
                                </tr>
                                <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                </tr>
                                
                                
                               
                                </table>
                            
                            
                            </td>
                        <td>&nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td>
                            &nbsp;</td><td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr></table></form>
</asp:Content>

