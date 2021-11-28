<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_EMSeBookUserListing.aspx.cs" Inherits="SuperAdmin_SA_EMSeBookUserListing" %>


<%@ Register src="SA_SideMenu_EMS.ascx" tagname="SA_SideMenu_EMS" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    
    <uc1:SA_SideMenu_EMS ID="SA_SideMenu_EMS1" runat="server" />
    
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script language="javascript" type="text/javascript">


        function ChangeSearchValueBox(ddlId) {
            var ControlName = document.getElementById(ddlId.id);

            if (ControlName.value == 'isActive') {

                document.getElementById('dvSearchTextBox').style.display = 'none';
                document.getElementById('dvStatusDropDown').style.display = 'block';
            
            }
            else {
                document.getElementById('dvSearchTextBox').style.display = 'block';
                document.getElementById('dvStatusDropDown').style.display = 'none';
            }




        }


        function fnAddDomain(ad2userid) {

            //alert("User ID : " + ad2userid);
            document.location.href = "SA_AddDomain2User.aspx?uid=" + ad2userid;
        }
        
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
       var ObjgridViewCtlId = '<%=gridUsers.ClientID%>';
       
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
    <table cellpadding="0" cellspacing="0" border="0" width="99%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrAllUsersListing" runat="server" 
                                Text="Email System Requests : EBOOK Users"></asp:Literal></td>
                            <td width="30%" align="right">&nbsp;</td>
                      </tr></table></td></tr><tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="1%">&nbsp;</td>
                        <td width="98%">&nbsp;</td>
                        <td width="1%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                        
                        <table id="tblSearchSimple" align="center" cellpadding="0" cellspacing="2" class="stdtableBorder_Search">
                                <tr>
                                    <td style="width:10px;">&nbsp;</td>
                                    <td style="width:120px;" class="SearchLabelBold">Search Parameter</td>
                                    <td style="width:3px;">&nbsp;:&nbsp;</td>
                                    <td class="SearchLabel" style="width:150px;" align="left">
                                        <asp:DropDownList ID="ddlSearchParam" CssClass="stdDropDown1" runat="server"                                             
                                            >
                                           <%-- <asp:ListItem Value="LoginID">LoginName</asp:ListItem>--%>
                                            <asp:ListItem Value="Company">CompanyName</asp:ListItem>
                                            <asp:ListItem Value="Member_Name">Name</asp:ListItem>
                                            <asp:ListItem Value="Email">Email</asp:ListItem>
                                            <asp:ListItem Value="MobileID">Mobile No.</asp:ListItem>
                                            <asp:ListItem Value="OwnDomain">Own Domain</asp:ListItem>
                                            
                                            
                                            <%--<asp:ListItem Value="isActive">Activated</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:10px;"> &nbsp;</td>
                                    <td style="width:120px;" class="SearchLabelBold">Search Value</td>
                                    <td style="width:3px;">&nbsp;:&nbsp;</td>
                                    <td class="SearchLabel" align="left" style="width:150px;">
                                        <div id="dvSearchTextBox" style="display: block">
                                           
                                            <asp:TextBox ID="txtSearchValue" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtSearchValue" Display="Dynamic" runat="server" ValidationGroup="VgCheck" ErrorMessage="<br/>Plese enter some value to search"></asp:RequiredFieldValidator>--%>
                                            
                                        </div>
                                        <div id="dvStatusDropDown" style="display: none">
                                            <asp:DropDownList ID="ddlStatus" CssClass="stdDropDown1" runat="server">
                                            <asp:ListItem Value="0">Activated</asp:ListItem>
                                            <asp:ListItem Value="1">Suspended</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                        </div>
                                   </td>
                                    
                                    <td style="width:5px;"> &nbsp;</td>
                                    <td align="left">
                                    <asp:Button ID="btnSearch" CssClass="stdbuttonAction" runat="server" Text="Search" onclick="btnSearch_Click" />
                                    &nbsp; 
                                        <asp:Button ID="btnReset" CssClass="stdbuttonAction" runat="server" 
                                            Text="Reset" onclick="btnReset_Click" />
                                    </td>
                                    <td style="width:5px;"> &nbsp;</td>
                                    <td style="width:20px;"> </td>
                                </tr>
                                
                            </table>
                        
                        
                        
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    
                    
                     <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    
                    <%--<tr>
                        <td>&nbsp;</td>
                        <td>
                        
                        <table id="Table1" align="center" cellpadding="0" cellspacing="2" class="stdtableBorder_Search">
                                <tr>
                                    <td style="width:10px;">&nbsp;</td>
                                    <td style="width:120px;" class="SearchLabelBold">Select Columns<br />
                                        &nbsp;to Hide</td>
                                    <td style="width:5px;"> &nbsp;</td>
                                    <td style="width:650px;" align="left"> 
                                        <asp:CheckBoxList ID="cklist_HideColumns" runat="server" CellPadding="2" 
                                            CellSpacing="2" RepeatColumns="5" RepeatDirection="Horizontal">
                                       
                                            <asp:ListItem>CompanyName</asp:ListItem>
                                            <asp:ListItem Value="FullName">Name</asp:ListItem>
                                            <asp:ListItem>Email</asp:ListItem>
                                            <asp:ListItem Value="HandPhone">MobileNo</asp:ListItem>
                                            <asp:ListItem>RegisteredDate</asp:ListItem>
                                            <asp:ListItem>ExpiryDate</asp:ListItem>
                                            <asp:ListItem Value="PurchasedBy">Debtor Mobile</asp:ListItem>
                                            <asp:ListItem Value="PurchaserTo">Purchaser Mobile</asp:ListItem>
                                            <asp:ListItem Value="isActive">Activated</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                    <td align="left">
                                    <asp:Button ID="btnHideColumns" CssClass="stdbuttonAction" 
                                            ValidationGroup="VgCheck" runat="server" Text="Search" 
                                            onclick="btnSearch_Click" />
                                    &nbsp; 
                                        </td>
                                    <td style="width:5px;"> &nbsp;</td>
                                    <td style="width:20px;"> </td>
                                </tr>
                                
                            </table>
                        
                        
                        
                        </td>
                        <td>&nbsp;</td>
                    </tr>--%>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="5">
                                <ProgressTemplate>
                                    <div ID="progress" runat="server" visible="true">
                                        <img ID="Img1" runat="server" src="~/Images/Loader1.gif" />Processing... Please 
                                        wait...
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td><td>
                        
                            <asp:GridView ID="gridUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="Identifier"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="20" onpageindexchanging="gridUsers_PageIndexChanging"
                               AllowSorting="true" OnSorting="gridUsers_Sorting"  
                                onrowcancelingedit="gridUsers_RowCancelingEdit" 
                                onrowediting="gridUsers_RowEditing" onrowupdating="gridUsers_RowUpdating" 
                                ondatabound="gridUsers_DataBound" 
                                onrowdatabound="gridUsers_RowDataBound" onrowcommand="gridUsers_RowCommand" 
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
                               <asp:HiddenField ID="hidMobileID" Value='<%#Bind("Mobile")%>' runat="server" />
                               <asp:HiddenField ID="hidEMSsetup" Value='<%#Eval("EMSsetup")%>' runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="40px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Mobile No." SortExpression="Mobile" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrMobileLoginID" Text='<%# Eval("Mobile")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="70px" HorizontalAlign="Left"  />
                              <HeaderStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Member Name<br>Email" SortExpression="Member_Name" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrFullName" Text='<%# Eval("MemberName")  %>' runat="server"></asp:Literal>
                                  <br />
                                  <asp:Label ID="lblEMAIL" CssClass="FontNote" runat="server" Text='<%# Eval("Email")  %>'></asp:Label>
                              </ItemTemplate>
                             <ItemStyle Width="120px" HorizontalAlign="Left"  />
                                  <HeaderStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                             
                                                 
                           <asp:TemplateField HeaderText="Own Domain" SortExpression="OwnDomain" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrOwnDomain" Text='<%# Eval("OwnDomain")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="60px" HorizontalAlign="Left"  />
                               <HeaderStyle HorizontalAlign="Left" />
                             </asp:TemplateField>

                                <asp:TemplateField HeaderText="Email Setup<br>Status" SortExpression="EMSsetup" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrEmailSetupDone" Text='<%# Eval("EMSsetup")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="50px" HorizontalAlign="Center"  />
                             <HeaderStyle HorizontalAlign="Center" />
                             </asp:TemplateField>

                             
                              <asp:TemplateField HeaderText="Account<br>Registered Date" SortExpression="RegisterDate" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrRegisterDate" Text='<%# Bind("RegisterDate","{0:dd-MMM-yyyy hh:mm tt}")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="80px" HorizontalAlign="Center"  />
                             </asp:TemplateField>


                                <asp:TemplateField HeaderText="Domain<br>Registered Date" SortExpression="DomainRegDate" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrDomainRegDate" Text='<%# Bind("DomainRegDate","{0:dd-MMM-yyyy hh:mm tt}")  %>' runat="server"></asp:Literal>
                              </ItemTemplate>
                             <ItemStyle Width="80px" HorizontalAlign="Center"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Functions">
                              <ItemTemplate>
                                  <asp:ImageButton id="ImgAddEMS" ToolTip="Add Email Details" runat="server" ImageUrl="~/Images/AddGemsSystem.png" OnCommand="AddEMS_Click"/>
                                  <asp:ImageButton ID="ImgEditEMS" Visible="false" ToolTip="Edit Email Details" runat="server" ImageUrl="~/Images/imgEdit2.gif" OnCommand="EditEMS_Click" />
                                  
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Justify" Wrap="false" />
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
                           <%-- <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
                &nbsp;</td></tr></table></ContentTemplate></asp:UpdatePanel></form>
 
 </asp:Content>