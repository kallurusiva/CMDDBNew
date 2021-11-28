<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_AddTopMenuItems.aspx.cs" Inherits="SuperAdmin_SA_AddTopMenuItems" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SA_SideMenu_PgSettings.ascx" tagname="SA_SideMenu_PgSettings" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SA_SideMenu_PgSettings ID="SA_SideMenu_PgSettings1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="MyHomePageForm" runat="server">
    
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
                            &nbsp; <asp:Literal ID="LtrLogoItems" runat="server" 
                                Text="Available Top Menu Items"></asp:Literal>&nbsp;
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
                                    <asp:GridView ID="GridTopMenu" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="LinkID"
                                    CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
                                        AlternatingRowStyle-CssClass="rowalt" 
                                         FooterStyle-CssClass ="rowfooter"
                                        onrowcancelingedit="GridTopMenu_RowCancelingEdit" 
                                        onrowdatabound="GridTopMenu_RowDataBound" 
                                        onrowdeleting="GridTopMenu_RowDeleting" 
                                        onrowediting="GridTopMenu_RowEditing" onrowupdating="GridTopMenu_RowUpdating" ShowFooter="True" 
                                    >
                                    <Columns>
                                    <asp:TemplateField HeaderText="Sl No">
                                      <ItemTemplate>
                                       <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                          <asp:Literal ID="ltrLinkID" Text='<%# Eval("LinkID")  %>' Visible="false" runat="server"></asp:Literal>
                                      </ItemTemplate>
                                      <ItemStyle Width="60px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Link Name" >
                                  <ItemTemplate>
                                   <asp:Label ID="lblLinkName" runat="server" Text='<%# Bind("LinkName")  %>'/>
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                      <asp:TextBox ID="txtLinkName" Text='<%# Bind("LinkName")  %>' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vgEditMenuItems" runat="server" ErrorMessage="<br>LinkName cannot be empty" ControlToValidate="txtLinkName"></asp:RequiredFieldValidator>
                                  </EditItemTemplate>
                                   <FooterTemplate>
                                      <asp:TextBox ID="txt_NewLinkName" Text='' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="vgInsertMenuItems" runat="server" ErrorMessage="<br>LinkName cannot be empty" ControlToValidate="txt_NewLinkName"></asp:RequiredFieldValidator>
                                  </FooterTemplate>
                                  
                                  <ItemStyle Width="150px" HorizontalAlign="Left"  />
                                 </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Link URL" >
                                  <ItemTemplate>
                                   <asp:Label ID="lblLinkURL" runat="server" Text='<%# Bind("LinkURL")  %>'/>
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                      <asp:TextBox ID="txtLinkURL" Text='<%# Bind("LinkURL")  %>' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="vgEditMenuItems" runat="server" ErrorMessage="<br>LinkURL cannot be empty" ControlToValidate="txtLinkURL"></asp:RequiredFieldValidator>
                                  </EditItemTemplate>
                                  <FooterTemplate>
                                      <asp:TextBox ID="txt_NewLinkURL" Text='' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="vgInsertMenuItems" runat="server" ErrorMessage="<br>LinkURL cannot be Empty" ControlToValidate="txt_NewLinkURL" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                  </FooterTemplate>
                                  <ItemStyle Width="150px" HorizontalAlign="Left"  />
                                 </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="Active">
                                  <ItemTemplate>
                                      <asp:Image ID="ImgActive" runat="server" />
                                      <asp:Literal ID="LtrActive" runat="server" Text='<%# Bind("Active") %>' Visible="false"></asp:Literal></ItemTemplate><EditItemTemplate>
                                      <asp:CheckBox ID="chkActive" Enabled="true" Checked='<%# Bind("Active") %>' runat="server" />
                                  </EditItemTemplate>
                                   <FooterTemplate>
                                     <asp:CheckBox ID="chk_newActive" Checked="true" runat="server" />
                                  </FooterTemplate>
                                  <ItemStyle Width="50px" HorizontalAlign="Center"  />
                                 </asp:TemplateField>
                                 
                              <asp:TemplateField HeaderText="Priority">
                              <ItemTemplate>
                               <asp:Literal ID="LtrPriority" runat="server" Text='<%# Bind("Priority") %>' Visible="false"></asp:Literal>   
                                  &nbsp;&nbsp;
                                  <asp:ImageButton ID="Imgbtn_orderUP" OnClick="btnPrt_UP_Click" ImageUrl="~/Images/order_up.gif" runat="server" />
                                  &nbsp;&nbsp;
                                  <asp:ImageButton ID="Imgbtn_orderDown" OnClick="btnPrt_DOWN_Click" ImageUrl="~/Images/Order_down.gif" runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Center"  />
                             </asp:TemplateField>
                             
                             
                             
                                 <asp:TemplateField HeaderText="Functions">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit News" runat="server" ImageUrl="~/Images/imgEdit2.gif" />
                                      <asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete News" OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                  
                                      <asp:ImageButton ID="ImgUpdate" CommandName="UPDATE"  ValidationGroup="vgEditMenuItems" ToolTip="Update News" runat="server" ImageUrl="~/Images/imgUpdate.gif" />
                                      <asp:ImageButton ID="ImgCancel" CommandName="CANCEL" ToolTip="Cancel" runat="server" ImageUrl="~/Images/imgCancel.gif" />
                                      
                                  </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:Button ID="BtnAddNew" CssClass="stdbuttonCRUD" OnClick="AddNewMenuItem_Click"  ValidationGroup="vgInsertMenuItems" runat="server" Text="Add New Menu Item" />
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

