<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_WelcomePageListing.aspx.cs" Inherits="Admin_WelcomePageListing" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SideMenu_Events.ascx" tagname="SideMenu_Events" tagprefix="uc2" %>

<%@ Register src="../SuperAdmin/SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc1" %>

<%@ Register src="SideMenu_Email.ascx" tagname="SideMenu_Email" tagprefix="uc3" %>
<%@ Register src="SideMenu_PgSettings.ascx" tagname="SideMenu_PgSettings" tagprefix="uc4" %>

<%@ Register src="LeftMenu_Profile.ascx" tagname="LeftMenu_Profile" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

    <uc5:LeftMenu_Profile ID="LeftMenu_Profile1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    <script src="../OtherUtils/datetimepicker_css.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">

    function SelectAll(chkdbox_id) {

        var objChkbox = document.getElementById(chkdbox_id);
        //alert(objChkbox.checked);
         
        var frm = document.forms[0];

        for (var i = 0; i < frm.elements.length; i++) {
            if (frm.elements[i].type == "checkbox") {
                frm.elements[i].checked = objChkbox.checked;
            }
        }
    }

    function SelectRow(cb_ID) {

       //Getting the ref. to GridView Control 
       var ObjgridViewCtlId = '<%=gridWelcomePage.ClientID%>';
       
       //Getting ref. to GridView Row
       // ObjgridViewCtlId.rows
        
        
    }

</script>

<form id="form2" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
    
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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                       
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp;<asp:Literal ID="ltrWelComePagelist" Text="evet" runat="server"></asp:Literal>                            
                             </td>
                        <td width="30%"> 
                            <uc1:SelectLanguage ID="ucSelectLanguage" runat="server" />
                        </td>    
                     
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr style="height:30px;">
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%" align="left">
                            &nbsp; 
                                    
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="50" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img src="~/Images/Loader1.gif" runat="server"/> Processing... Please wait...
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
                        
                            <asp:GridView ID="gridWelcomePage" runat="server" AutoGenerateColumns="False" DataKeyNames="Wid"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="20" onpageindexchanging="gridWelcomePage_PageIndexChanging"
                               AllowSorting="true" 
                                onrowcancelingedit="gridWelcomePage_RowCancelingEdit" 
                                onrowediting="gridWelcomePage_RowEditing" onrowupdating="gridWelcomePage_RowUpdating" 
                                onrowdeleting="gridWelcomePage_RowDeleting" ondatabound="gridWelcomePage_DataBound" 
                                onrowdatabound="gridWelcomePage_RowDataBound"
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
                                  <asp:Literal ID="hdWelcomeID" Visible="false" Text='<%#Bind("Wid")%>' runat="server"></asp:Literal>
                                  <asp:HiddenField ID="hidUserID" Value='<%#Bind("UserID")%>' runat="server" />
                                  <asp:HiddenField ID="hidUserType" Value='<%#Bind("UserType")%>' runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="User" SortExpression="LoginID" >
                              <%--<HeaderTemplate>
                                  Event Title
                                  <asp:Image ID="ImgEventTitle_SortDir" runat="server" ToolTip="Sort" ImageUrl="~/Images/imgSortDown.gif" />

                              </HeaderTemplate>--%>
                              <ItemTemplate>
                               <asp:Label ID="lblLoginID" runat="server" Text='<%# Bind("LoginID")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Language" SortExpression="Language">
                              <ItemTemplate>
                              <%-- <asp:Label ID="lblLanguage" runat="server" Text='<%# Eval("EventContent").ToString().Replace(Environment.NewLine,"<br />")  %>'/>--%>
                              <asp:Label ID="lblLanguage" runat="server" Text='<%# Eval("LangName")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Description" SortExpression="Description">
                              <ItemTemplate>
                              <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Replace(Environment.NewLine,"<br/>")   %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="350px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                             
                              <asp:TemplateField HeaderText="Created Date" SortExpression="CreatedDate" >
                              <ItemTemplate>
                               <asp:Label ID="lblEventDate" runat="server" Text='<%# Bind("CreatedDate","{0:dd-MMM-yyyy hh:mm tt}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="120px" HorizontalAlign="center"  />
                             </asp:TemplateField>
                                                          
                              <asp:TemplateField HeaderText="Display at Website">
                              <ItemTemplate>
                                  <asp:Image ID="ImgActive" runat="server" />
                                  <asp:Literal ID="LtrActive" runat="server" Text='<%# Bind("Active") %>' Visible="false"></asp:Literal>
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                  <asp:CheckBox ID="chkActive" Enabled="true" Checked='<%# Bind("Active") %>' runat="server" />
                              </EditItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="Center"  />
                             </asp:TemplateField>
                             
                             
                              <asp:TemplateField HeaderText="Functions">
                              <ItemTemplate>
                                  <asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit Event" runat="server" ImageUrl="~/Images/imgEdit2.gif" />
                                  <%--<asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete Event" OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />--%>
                              </ItemTemplate>
                              <EditItemTemplate>
                              
                                  <asp:ImageButton ID="ImgUpdate" CommandName="UPDATE" ValidationGroup="vgEdit" ToolTip="Update Event" runat="server" ImageUrl="~/Images/imgUpdate.gif" />
                                  <asp:ImageButton ID="ImgCancel" CommandName="CANCEL" ToolTip="Cancel" runat="server" ImageUrl="~/Images/imgCancel.gif" />
                                  
                              </EditItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="center"  />
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
                                </PagerTemplate>--%></asp:GridView></td><td>
                            &nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td align="left">
                            <%--<asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    
      </ContentTemplate>  
    </asp:UpdatePanel>
    

    </form>
</asp:Content>

