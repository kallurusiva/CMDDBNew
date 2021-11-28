<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_AncDomainsCategories.aspx.cs" Inherits="SuperAdmin_SA_AncDomainsCategories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SA_SideMenu_PgSettings.ascx" tagname="SA_SideMenu_PgSettings" tagprefix="uc1" %>

<%@ Register src="SA_SideMenu_Domains.ascx" tagname="SA_SideMenu_Domains" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_Domains ID="SA_SideMenu_Domains1" runat="server" />
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
                                Text="Anchor Domains Listing"></asp:Literal>&nbsp;
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
                                    <asp:GridView ID="GridAncDomains" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="CategoryID"
                                    CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
                                        AlternatingRowStyle-CssClass="rowalt" 
                                         FooterStyle-CssClass ="rowfooter"
                                        onrowcancelingedit="GridAncDomains_RowCancelingEdit" 
                                        onrowdatabound="GridAncDomains_RowDataBound" 
                                        onrowdeleting="GridAncDomains_RowDeleting" 
                                        onrowediting="GridAncDomains_RowEditing" onrowupdating="GridAncDomains_RowUpdating" ShowFooter="True" 
                                    >
                                    <Columns>
                                    <asp:TemplateField HeaderText="Sl No">
                                      <ItemTemplate>
                                       <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                          <asp:Literal ID="ltrCatID" Text='<%# Eval("CategoryID")  %>' Visible="false" runat="server"></asp:Literal>
                                      </ItemTemplate>
                                      <FooterTemplate>
                                        Add new Category
                                       
                                     </FooterTemplate>
                                  
                                      <ItemStyle Width="60px" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Category Name" SortExpression="CategoryName" >
                                  <ItemTemplate>
                                   <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("CategoryName")  %>'/>
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                      <asp:TextBox ID="txtCategoryName" Text='<%# Bind("CategoryName")  %>' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vgEditCatItems" runat="server" ErrorMessage="<br>LinkName cannot be empty" ControlToValidate="txtCategoryName"></asp:RequiredFieldValidator>
                                  </EditItemTemplate>
                                   <FooterTemplate>
                                      <asp:TextBox ID="txt_NewAncCatName" Text='' MaxLength="100" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="vgInsertAncItems" runat="server" ErrorMessage="<br>Category Name cannot be Empty." ControlToValidate="txt_NewAncCatName"></asp:RequiredFieldValidator>
                                  </FooterTemplate>
                                  
                                  <ItemStyle Width="150px" HorizontalAlign="Left"  />
                                  <FooterStyle HorizontalAlign ="Left" />
                                 </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Associated AnchorDomains" >
                                  <ItemTemplate>
                                   <asp:Label ID="lblCntAncDomains" runat="server" Text='<%# Bind("CntAncDomains")  %>'/>
                                  </ItemTemplate>
                                  <FooterTemplate>
                                    <%--  <asp:TextBox ID="txt_NewLinkURL" Text='' runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="vgInsertAncItems" runat="server" ErrorMessage="<br>LinkURL cannot be Empty" ControlToValidate="txt_NewLinkURL" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                  </FooterTemplate>
                                  <ItemStyle Width="150px" HorizontalAlign="Left"  />
                                 </asp:TemplateField>
                                 
                                                                                          
                             
                             
                                 <asp:TemplateField HeaderText="Functions">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit Category Name" runat="server" ImageUrl="~/Images/imgEdit2.gif" />
                                      <asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete Category Name" OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                  
                                      <asp:ImageButton ID="ImgUpdate" CommandName="UPDATE"  ValidationGroup="vgEditCatItems" ToolTip="Update Category Name" runat="server" ImageUrl="~/Images/imgUpdate.gif" />
                                      <asp:ImageButton ID="ImgCancel" CommandName="CANCEL" ToolTip="Cancel" runat="server" ImageUrl="~/Images/imgCancel.gif" />
                                      
                                  </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:Button ID="BtnAddNew" CssClass="stdbuttonCRUD" OnClick="AddNewCategory_Click"  ValidationGroup="vgInsertAncItems" runat="server" Text="Add New Category" />
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

