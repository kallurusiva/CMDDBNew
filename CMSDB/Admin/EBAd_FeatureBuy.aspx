<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_FeatureBuy.aspx.cs" Inherits="EBAd_FeatureBuy" %>
<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>
<%@ Register src="EBLeftMenu_FeatureBuy.ascx" tagname="EBLeftMenu_FeatureBuy" tagprefix="uc2" %>
<%@ Register src="EBLeftMenu_ebButtons.ascx" tagname="EBLeftMenu_ebButtons" tagprefix="uc3" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:EBLeftMenu_ebButtons ID="EBLeftMenu_ebButtons1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    
     <style type="text/css">

         .CellPaddingRight { padding-right: 10px; 
         }


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
       var ObjgridViewCtlId = '<%=gridEbooks.ClientID%>';
       
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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; Feature Buy&nbsp; Listing</td>
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
                <table cellpadding="0" cellspacing="3" style="border: solid 1px red;" class="stdtableBorder_Main" width="100%">
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
                        
                            <asp:GridView ID="gridEbooks" runat="server" AutoGenerateColumns="False" DataKeyNames="BookID"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="10" onpageindexchanging="gridEbooks_PageIndexChanging"
                               AllowSorting="true"  
                                onrowcancelingedit="gridEbooks_RowCancelingEdit" 
                                onrowediting="gridEbooks_RowEditing"  
                                onrowdeleting="gridEbooks_RowDeleting" ondatabound="gridEbooks_DataBound" onrowdatabound="gridEbooks_RowDataBound" OnRowUpdating="gridEbooks_RowUpdating" OnSorting="gridEbooks_Sorting"
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
                                  <asp:HiddenField ID="hidBookId" Value='<%#Bind("BookID")%>' runat="server" />
                                  <asp:HiddenField ID="hidFBuid" Value='<%#Bind("FeatureBuyUID")%>' runat="server" />
                                  <asp:HiddenField ID="hidCreatedBy" Value='<%#Bind("CreatedBy")%>' runat="server" />
                                  <%-- <asp:HiddenField ID="hidUserType" Value='<%#Bind("UserType")%>' runat="server" />--%>
                              </ItemTemplate>
                              <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            

                              <asp:TemplateField HeaderText="Product Code<br>Product Name" SortExpression="BookID" >
                              <ItemTemplate>
                                  <asp:Literal ID="LtrBookID" runat="server" Text='<%# Bind("BookID")  %>'></asp:Literal>
                                  <br />
                                   <asp:Label ID="lblBookName" CssClass="fontBlue12" runat="server" Text='<%# Bind("BookName")  %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>

                             
                             <asp:TemplateField HeaderText="Category" SortExpression="CategoryName" >
                              <ItemTemplate>
                                  <asp:Literal ID="LtrCategoryName" runat="server" Text='<%# Bind("CategoryName")  %>'></asp:Literal>

                              </ItemTemplate>
                              <ItemStyle Width="70px" HorizontalAlign="Left"  />
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="Position" SortExpression="BookID" >
                              <ItemTemplate>
                                  <asp:Literal ID="LtrPosition" runat="server" Text='<%# Bind("position")  %>'></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Image">
                              <ItemTemplate>
                                  <asp:Image ID="lblImageFilePath" ImageUrl='<%# Bind("ImageFileFullURL")%>' Width="100" Height="100" runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="150px" Height="150px" VerticalAlign="Middle" HorizontalAlign="center"  />
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText="Attachment">
                              <ItemTemplate>
                                  <asp:Literal ID="LtreBookFileName" runat="server" Text='<%# Bind("eBookFileName")  %>'></asp:Literal>
                                  <br /> <br />
                                   <%--<asp:LinkButton ID="linkBtnDownloadFile" CommandArgument='<%# Bind("eBookFileName")  %>' OnCommand="linkBtnDownloadFile_Command" runat="server">
                                              <img alt="downloadbtn"  src="../Images/DownloadBtn.jpg" />
                                  </asp:LinkButton>--%>
                                  <%--<asp:LinkButton ID="linkBtnDownloadFile" CommandArgument='<%# Bind("eBookFileNameStatus")  %>' OnClientClick="return confirm('5 SMS credits would be deduted for ebook Download \n\n Please click OK if you want to continue download \nelse click CANCEL.\n\nPlease Refresh page after download.');"  
                                      OnCommand="linkBtnDownloadFile_Command" runat="server">
                                              <img src="../Images/DownloadBtn.jpg" />
                                  </asp:LinkButton>
                                  <br /> <br />
                                  <div class="fontPending">
                                  <asp:Literal ID="LtrDownloaded" runat="server" Text='<%# Bind("downloadStatus") %>'></asp:Literal>
                                      </div>
                                  <asp:HiddenField ID="hidDownload" Value='<%#Bind("downloadValue")%>' runat="server" />--%>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Center"  />
                             </asp:TemplateField>
                             

                            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                              <ItemTemplate>
                               <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Replace(Environment.NewLine,"<br />")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="Left"  />
                             </asp:TemplateField>

                            
                               <asp:TemplateField HeaderText="Price<br>Discount<br>Discounted Price" SortExpression="Price" >
                              <ItemTemplate>
                          
                                  <asp:Label ID="lblPrice" CssClass="fontBlue" runat="server" Text='<%# Bind("Price", "{0:0.00}")  %>'></asp:Label>
                                  <br />
                                  <asp:Label ID="lblDiscount" CssClass="fontRed" runat="server" Text='<%# Bind("Discount")  %>'></asp:Label>%
                                  <br />
                                  <asp:Label ID="lblDiscountedPrice" CssClass="fontGreen" runat="server" Text='<%# Bind("DiscountedPrice", "{0:0.00}")  %>'></asp:Label>&nbsp;
                                 
                              </ItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="Right" CssClass="CellPaddingRight" />
                             </asp:TemplateField>

                           
                             <asp:TemplateField HeaderText="CC Mobiles" Visible="false">
                              <ItemTemplate>
                                  <br />
                               <asp:Label ID="lblmobile1" runat="server" Text='<%# Bind("Mobile1")  %>'/><br />
                                <asp:Label ID="lblmobile2" runat="server" Text='<%# Bind("Mobile2")  %>'/><br />
                                <asp:Label ID="lblmobile3" runat="server" Text='<%# Bind("Mobile3")  %>'/><br />
                              </ItemTemplate>
                              <ItemStyle Width="70px" HorizontalAlign="center"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Date Created" SortExpression="DateCreated" >
                              <ItemTemplate>
                               <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("DateCreated","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="center"  />
                             </asp:TemplateField>


                                <%-- <asp:TemplateField HeaderText="Select for<br>Home Page" SortExpression="isHomePageShow">
                                    <ItemTemplate>
                                  <asp:Image ID="ImgHpShow" runat="server" />
                                  <asp:Literal ID="LtrHpShow" runat="server" Text='<%# Bind("isHomePageShow") %>' Visible="false"></asp:Literal>
                                   </ItemTemplate>

                                  <EditItemTemplate>
                                  <asp:CheckBox ID="chkHpShow" Enabled="true" Checked='<%# Bind("isHomePageShow") %>' runat="server" />
                                  </EditItemTemplate>

                                 <ItemStyle Width="30px" HorizontalAlign="Center"  />
                             </asp:TemplateField>--%>


                             
                             <asp:TemplateField HeaderText="Display at Web"  SortExpression="isDisplay">
                              <ItemTemplate>
                                  <asp:Image ID="ImgActive" runat="server" />
                                  <asp:Literal ID="LtrActive" runat="server" Text='<%# Bind("isDisplay") %>' Visible="false"></asp:Literal>
                                  <br />
                                  <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:Label>
                                  </ItemTemplate>

                                 <EditItemTemplate>
                                  <asp:CheckBox ID="chkActive" Enabled="true" Checked='<%# Bind("isDisplay") %>' runat="server" />
                               </EditItemTemplate>

                                 <ItemStyle Width="30px" HorizontalAlign="Center"  />
                             </asp:TemplateField>

                        <asp:TemplateField HeaderText="Functions">
                              <ItemTemplate>
                                  
                                 <%--  <asp:HyperLink ID="HyLinkEdit" runat="server" Visible="false">
                                      <asp:Image ID="ImgEdit1" ImageUrl="~/Images/imgEdit2.gif" runat="server" />                                  
                                  </asp:HyperLink>  --%>
                                                      
                                   <asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit Ebook" runat="server" ImageUrl="~/Images/imgEdit.gif"/>
                                  <asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete EBook" Visible="false"  OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />
                              </ItemTemplate>
                              <EditItemTemplate>
                              
                                  <asp:ImageButton ID="ImgUpdate" CommandName="UPDATE" ToolTip="Update EBook" runat="server" ImageUrl="~/Images/imgUpdate.gif" />
                                  <asp:ImageButton ID="ImgCancel" CommandName="CANCEL" ToolTip="Cancel" runat="server" ImageUrl="~/Images/imgCancel.gif" />
                                  
                              </EditItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="center"  />
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

