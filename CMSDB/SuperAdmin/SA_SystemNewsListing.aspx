<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_SystemNewsListing.aspx.cs" Inherits="SuperAdmin_SA_SystemNewsListing" %>


<%@ Register src="SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc1" %>

<%@ Register src="SA_SideMenu_SystemNews.ascx" tagname="SA_SideMenu_SystemNews" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_SystemNews ID="SA_SideMenu_SystemNews1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

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
       var ObjgridViewCtlId = '<%=gridSystemNews.ClientID%>';
       
       //Getting ref. to GridView Row
       // ObjgridViewCtlId.rows
        
        
    }

</script>
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
                            &nbsp;<asp:Literal ID="ltrSystemNewsListing" runat="server"></asp:Literal> </td>
                        <td width="30%" align="right"> 
                            <uc1:SelectLanguage ID="ucSelectLanguage" runat="server" />
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
                    <tr style="height:30px;">
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left">
                            &nbsp; 
                                    
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="500" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/> Processing... Please wait... 
                             </div>
                            </ProgressTemplate>
                            
                            </asp:UpdateProgress>
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <asp:GridView ID="gridSystemNews" runat="server" AutoGenerateColumns="False" DataKeyNames="SnID"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="20" onpageindexchanging="gridSystemNews_PageIndexChanging"
                               AllowSorting="true" OnSorting="gridSystemNews_Sorting"   
                                onrowcancelingedit="gridSystemNews_RowCancelingEdit" 
                                onrowediting="gridSystemNews_RowEditing" onrowupdating="gridSystemNews_RowUpdating" 
                                onrowdeleting="gridSystemNews_RowDeleting" ondatabound="gridSystemNews_DataBound" onrowdatabound="gridSystemNews_RowDataBound"
                             >
                            <Columns>
                        <%--    <asp:TemplateField HeaderText="Sl No">
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
                               <asp:Literal ID="hdSnId" Visible="false" Text='<%#Bind("snId")%>' runat="server"></asp:Literal>
                                   <asp:HiddenField ID="hidUserID" Value='<%#Bind("UserID")%>' runat="server" />
                                   <asp:HiddenField ID="hidLgType" Value='<%#Bind("LgType")%>' runat="server" />
                                   
                              </ItemTemplate>
                              <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                              <ItemTemplate>
                                  <asp:Literal ID="LtrSubject" runat="server" Text='<%# Eval("Subject")  %>'></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                              <EditItemTemplate>
                                  <asp:TextBox CssClass="stdTextField1" ID="txtSubject" Text='<%# Bind("Subject")  %>' runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vgEdit" runat="server" ErrorMessage="Enter News Subject" ControlToValidate="txtSubject" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                             </asp:TemplateField>
                             
                            <asp:TemplateField HeaderText="Contents" SortExpression="Contents">
                             <ItemTemplate>
                               <asp:Label ID="lblContent" runat="server" Text='<%# Eval("Contents").ToString().Replace(Environment.NewLine,"<br/>")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="300px" HorizontalAlign="Left"  />
                               <EditItemTemplate>
                                  <asp:TextBox CssClass="stdTextArea2" TextMode="MultiLine" ID="txtContents" Text='<%# Bind("Contents")  %>' runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgEdit" runat="server" ErrorMessage="Enter News Content" ControlToValidate="txtContents" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                              </EditItemTemplate>
                             </asp:TemplateField>
                             
                             <asp:TemplateField HeaderText="Created By" SortExpression="UserID" >
                              <ItemTemplate>
                                  <asp:Literal ID="LtrLoginID" runat="server" Text='<%# Eval("LoginID")  %>'></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                             
                              <asp:TemplateField HeaderText="Created Date" SortExpression="CreatedDate" >
                              <ItemTemplate>
                               <asp:Label ID="lbltstDate" runat="server" Text='<%# Bind("CreatedDate","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="center"  />
                             </asp:TemplateField>
                             
                             <asp:TemplateField HeaderText="Display to Client">
                              <ItemTemplate>
                                  <asp:Image ID="ImgActive" runat="server" />
                                  <asp:Literal ID="LtrActive" runat="server" Text='<%# Bind("Active") %>' Visible="false"></asp:Literal>
                                    <br />
                                  <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("LangName") %>'></asp:Literal>
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                  <asp:CheckBox ID="chkActive" Enabled="true" Checked='<%# Bind("Active") %>' runat="server" />
                                </EditItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Center"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Functions">
                              <ItemTemplate>
                                  <asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit System News" runat="server" ImageUrl="~/Images/imgEdit2.gif"/>
                                  <asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete System News" OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />
                              </ItemTemplate>
                              <EditItemTemplate>
                              
                                  <asp:ImageButton ID="ImgUpdate" CommandName="UPDATE" ToolTip="Update System News" runat="server" ImageUrl="~/Images/imgUpdate.gif" />
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
                                       <td width="20px">&nbsp;</td>
                                       <td width="100px">
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
                                </PagerTemplate>--%>
                            </asp:GridView>
                            
                        
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                           <%-- <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
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
            &nbsp;
           </td>
        </tr>
    </table>
    
      </ContentTemplate>  
    </asp:UpdatePanel>
    

    </form>
</asp:Content>

