<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_BankIn_MasterList.aspx.cs" Inherits="EBAd_BankIn_MasterList" %>



<%@ Register src="EBLeftMenu_PayPalCC.ascx" tagname="EBLeftMenu_PayPalCC" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_PayPalCC ID="EBLeftMenu_PayPalCC1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    
     <style type="text/css">

         .CellPaddingRight { padding-right: 10px; 
         }

          .CellPaddingLeft { padding-left: 10px;
         }

          .sRowPadding { padding: 50px;}

     </style>

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
       var ObjgridViewCtlId = '<%=GridBanks.ClientID%>';
       
       //Getting ref. to GridView Row
       // ObjgridViewCtlId.rows
        
        
    }

</script>
<form id="form2" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
<ContentTemplate>--%>


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
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; Banks List</td>
                        <td width="30%" align="right"> 
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
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
                        
                            <asp:GridView ID="GridBanks" runat="server" AutoGenerateColumns="False"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="10" onpageindexchanging="GridBanks_PageIndexChanging"
                               AllowSorting="true"  
                               ondatabound="GridBanks_DataBound" onrowdatabound="GridBanks_RowDataBound"  OnSorting="GridBanks_Sorting" 
                             >
                            <Columns>
                            
                               <asp:TemplateField HeaderText="Sl No">
                              <ItemTemplate>
                               <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                  <asp:Literal ID="hdBankID" Visible="false" Text='<%#Bind("BankID")%>' runat="server"></asp:Literal>
                                  <asp:Literal ID="LtrBankLogo" Visible="false" Text='<%#Bind("BankLogo")%>' runat="server"></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="20px" CssClass="sRowPadding"  />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Bank Name" SortExpression="BankName">
                              <ItemTemplate>
                               <asp:Label ID="lblBankName" runat="server" Text='<%# Bind("BankName")  %>'/>
                                  <br />
                                  <asp:Image ID="ImgBankLogo" CssClass="ebTempImgCss" runat="server" />
                              </ItemTemplate>
                              <EditItemTemplate>

                                  <asp:TextBox ID="txtBankName" runat="server" Text='<%# Bind("BankName")  %>'></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBankName" runat="server" CssClass="ValAlert_Error" ErrorMessage="Bank Name cannot be Empty."></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="regexBankName" runat="server" ControlToValidate="txtBankName" Display="None" ErrorMessage="&lt;b&gt;Invalid Format&lt;/b&gt;&lt;br/&gt;Category Name supports Alphanumeric only" ValidationExpression="[a-zA-Z0-9]{1,15}" />
                              </EditItemTemplate>
                              
                              <ItemStyle Width="150px" HorizontalAlign="Left"   CssClass="sRowPadding" />
                             </asp:TemplateField>
                             

                              <asp:TemplateField HeaderText="Country">
                              <ItemTemplate>
                                  <asp:Literal ID="LtrCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Literal> 
                                  <br />
                                  <asp:Image ID="ImgCountry" runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="Center"  />
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="SwiftCode">
                              <ItemTemplate>
                                  <asp:Literal ID="LtrSwiftCode" runat="server" Text='<%# Bind("SwiftCode") %>'></asp:Literal> 
                              </ItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="Center"  />
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
    
<%--      </ContentTemplate>  


    </asp:UpdatePanel>--%>
    
    <asp:HiddenField ID="HdEditBookUID" runat="server" />

    <asp:HiddenField ID="HdEditBookID" runat="server" />

<asp:HiddenField ID="hdnPRMCode_ID" runat="server" />
<asp:HiddenField ID="hdn_EmailID" runat="server" />


    </form>
</asp:Content>

