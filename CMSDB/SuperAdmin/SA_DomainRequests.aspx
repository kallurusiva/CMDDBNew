<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_DomainRequests.aspx.cs" Inherits="SuperAdmin_SA_DomainRequests" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="SA_SideMenu_PgSettings.ascx" tagname="SA_SideMenu_PgSettings" tagprefix="uc1" %>
<%@ Register src="SA_SideMenu_Users.ascx" tagname="SA_SideMenu_Users" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_Users ID="SA_SideMenu_Users1" runat="server" />
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
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                        <asp:Literal ID="ltrDomainRequests" runat="server" 
                                Text="Domain name requests"></asp:Literal></td>
                        <td width="30%">
                           <%-- <uc2:SelectLanguage ID="ucSelectLanguage" runat="server" />--%>
                        </td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="98%">
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
                        
                            <asp:GridView ID="gridDomainList" runat="server" AutoGenerateColumns="False" DataKeyNames="ReqID"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="20" onpageindexchanging="gridDomainList_PageIndexChanging"
                               OnSorting ="gridDomainList_Sorting" onrowcancelingedit="gridDomainList_RowCancelingEdit" 
                                onrowediting="gridDomainList_RowEditing" onrowupdating="gridDomainList_RowUpdating" 
                                onrowdatabound="gridDomainList_RowDataBound"
                               AllowSorting="true" OnDataBound="gridDomainList_DataBound"
                             >
                            <Columns>
                            <%--<asp:TemplateField HeaderText="Sl No">
                              <ItemTemplate>
                                  <asp:CheckBox ID="chkSelect" runat="server" />
                              </ItemTemplate>
                              <HeaderTemplate>
                                  <asp:CheckBox ID="chkSelectAll" runat="server" />
                              </HeaderTemplate>
                              <ItemStyle Width="30px" />
                            </asp:TemplateField>--%>
                            
                            <asp:TemplateField HeaderText="Sl No">
                              <ItemTemplate>
                               <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                  <asp:Literal ID="ltrreqID" Visible="false" Text='<%#Bind("ReqID")%>' runat="server"></asp:Literal>
                                  <asp:HiddenField ID="hidUserID" Value='<%#Bind("UserID")%>' runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Domain Name" SortExpression="DomainName">
                              <ItemTemplate>
                               <asp:Label ID="lblDomainName" runat="server" Text='<%# Bind("DomainName")  %>'/>
                              </ItemTemplate>
                              
                              <EditItemTemplate>
                                  <asp:TextBox ID="txtOwnDomainName" CssClass="stdTextField1" Text='<%# Bind("DomainName") %>' runat="server"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Login ID" SortExpression="LoginID" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrLoginID" Text='<%# Eval("LoginID")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                             
                              <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrCompanyName" Text='<%# Eval("CompanyName")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                             <asp:TemplateField HeaderText="Full Name" SortExpression="FullName" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrFullName" Text='<%# Eval("FullName")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Contact No" SortExpression="HandPhone" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrHandPhone" Text='<%# Eval("HandPhone")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                             
                             
                              <asp:TemplateField HeaderText="Requested Date" SortExpression="RequestDate">
                              <ItemTemplate>
                               <asp:Label ID="lblRequestedDate" runat="server" Text='<%# Bind("RequestDate","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="center"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Approve" SortExpression="RegisteredStatus">
                              <ItemTemplate>
                                  <asp:Image ID="ImgActive" runat="server" />
                                  <asp:Literal ID="LtrActive" runat="server" Text='<%# Bind("RegisteredStatus") %>' Visible="false"></asp:Literal></ItemTemplate>
                              <EditItemTemplate>
                             <%-- <asp:CheckBox ID="chkActive" Enabled="true" Checked='<%# Bind("RegisteredStatus") %>' runat="server" />--%>
            <%--                      <input id="rdoApprove" value="1" name=rdoApproveReject"  type="radio" runat="server" /> Approve &nbsp;
                                  <input id="rdoReject" value="0" name=rdoApproveReject"  type="radio" runat="server" /> Reject --%>
                                  
                                  <asp:RadioButtonList ID="rdolst_ApproveReject" runat="server" CellPadding="3" CellSpacing="3" TextAlign="Right">
                                  <asp:ListItem Value="1" Selected="True" Text="Approve"></asp:ListItem>
                                  <asp:ListItem Value="2" Text="Reject "></asp:ListItem>
                                  </asp:RadioButtonList>
                                  
                              </EditItemTemplate>
                              <ItemStyle Width="80px" HorizontalAlign="center"  />
                              
                             </asp:TemplateField> 
                             
                              <asp:TemplateField HeaderText="Registered Date" SortExpression="RegisteredDate">
                              <ItemTemplate>
                               <asp:Label ID="lblRegisteredDate" runat="server" Text='<%# Bind("RegisteredDate","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="120px" HorizontalAlign="center"  />
                             </asp:TemplateField>
                             
                                                          
                              <asp:TemplateField HeaderText="Functions">
                              <ItemTemplate>
                                  <asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit" runat="server" ImageUrl="~/Images/imgEdit2.gif" />
                                 <%-- <asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete Faq" OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />--%>
                              </ItemTemplate>
                              <EditItemTemplate>
                              
                                  <asp:ImageButton ID="ImgUpdate" CommandName="UPDATE" ValidationGroup="vgEdit" ToolTip="Update" runat="server" ImageUrl="~/Images/imgUpdate.gif" />
                                  <asp:ImageButton ID="ImgCancel" CommandName="CANCEL" ToolTip="Cancel" runat="server" ImageUrl="~/Images/imgCancel.gif" />
                                  
                              </EditItemTemplate>
                              <ItemStyle Width="70px" HorizontalAlign="center"  />
                             </asp:TemplateField>
                            
                             
                             </Columns>
                             <PagerStyle CssClass="cssPager" />
                             
                             <PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
                                         <td width="100px">      
                                            <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" CommandArgument="First" runat="server"  ID="btnFirst" ImageUrl="~/Images/imgPg_First.gif" />
                                            <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" CommandArgument="Prev" runat="server" ID="btnPrevious" ImageUrl="~/Images/imgPg_Prev.gif"/>
                                                    </td>
                                                    
                                            <td width="100px">
                                                Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
                                                    ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td width="100px">
                                            <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" CommandArgument="Next" runat="server" ID="btnNext" ImageUrl="~/Images/imgPg_next.gif"/>
                                            <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" CommandArgument="Last" runat="server" ID="btnLast" ImageUrl="~/Images/imgPg_last.gif" />
                                          </td>
                                       <td width="20px">&nbsp;</td><td width="100px">
                                          <%-- <asp:Button ID="btnDeleteMultiple" runat="server" Text="Delete Selected"/>--%>
                                       </td>
                                          
                                 </tr>
                                    </table>
                                </PagerTemplate>
                                
                             <%--<PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
                              <td>      
                                             <asp:Button CssClass="stdPagerButton" Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                ID="btnFirst" />
                                            <asp:Button CssClass="stdPagerButton" Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                ID="btnPrevious" />
                                                    </td>
                                                    
                                            <td>
                                                Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
                                                    ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td>
                                            <asp:Button CssClass="stdPagerButton" Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                ID="btnNext" />
                                            <asp:Button  CssClass="stdPagerButton" Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                ID="btnLast" />
                                          </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>--%><HeaderStyle CssClass="rowheader" />
                                <AlternatingRowStyle CssClass="rowalt" />
                            </asp:GridView>
                            
                        
                        </td>
                        <td>
                            &nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td align="left">
                          <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td></tr><tr>
                    <td>&nbsp;</td><td>&nbsp;
                        
                    </td>
                    <td>&nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
              &nbsp;
            </td></tr></table></ContentTemplate></asp:UpdatePanel></form></asp:Content>