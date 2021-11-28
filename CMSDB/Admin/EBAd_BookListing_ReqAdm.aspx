<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_BookListing_ReqAdm.aspx.cs" Inherits="Admin_EBAd_BookListing_ReqAdm" %>



<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:EBLeftMenu_Dashboard ID="EBLeftMenu_Dashboard1" runat="server" />
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

    function confirmdownload() {



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
                            &nbsp; Request Upload Admin eBooks Listing</td>
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
                        
                            <asp:GridView ID="gridEbooks" runat="server" AutoGenerateColumns="False" DataKeyNames="BookID"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="25" onpageindexchanging="gridEbooks_PageIndexChanging"
                               AllowSorting="true"  
                                onrowcancelingedit="gridEbooks_RowCancelingEdit" 
                                onrowediting="gridEbooks_RowEditing"  
                                onrowdeleting="gridEbooks_RowDeleting" ondatabound="gridEbooks_DataBound" onrowdatabound="gridEbooks_RowDataBound" OnRowUpdating="gridEbooks_RowUpdating" OnSorting="gridEbooks_Sorting"
                             >
                            <Columns>

                             
                       
                            
                            <asp:TemplateField HeaderText="Sl No">
                              <ItemTemplate>
                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("Row") %>'/>
                                   <asp:HiddenField ID="hidBookId" Value='<%#Bind("BookID")%>' runat="server" />
                                  <asp:HiddenField ID="hidBookUID" Value='<%#Bind("UID")%>' runat="server" />
                                  <asp:HiddenField ID="hidCreatedBy" Value='<%#Bind("CreatedBy")%>' runat="server" />
                                  <asp:HiddenField ID="hidStatus" Value='<%#Bind("ApproveStatus")%>' runat="server" />
                              </ItemTemplate>
                              <ItemStyle />
                            </asp:TemplateField>
                            
                                <asp:TemplateField HeaderText="Reference Code" SortExpression="oldECode" >
                              <ItemTemplate>
                               <asp:Label ID="lbloldECode" runat="server" Text='<%# Bind("oldECode")  %>'/>
                              </ItemTemplate>
                              <ItemStyle  HorizontalAlign="center"  />
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText="Reference Code<br>Product Name" SortExpression="BookID" >
                              <ItemTemplate>
                                  <asp:Literal ID="ltrBookcode" runat="server" Text='<%# Bind("bookcode")  %>'></asp:Literal>
                                  <br />
                                  <asp:Literal ID="LtrBookID" runat="server" Text='<%# Bind("ZBookID")  %>'></asp:Literal>
                                  <br />
                                  <asp:Label ID="lblBookName" CssClass="fontBlue12" runat="server" Text='<%# Bind("BookName")  %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle  HorizontalAlign="Left"  />
                             </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Image">
                              <ItemTemplate>
                                  <asp:Image ID="lblImageFilePath" ImageUrl='<%# Bind("ImageFileFullURLnew")%>' Width="100" Height="100" runat="server" /><br />
                                  <asp:Literal ID="LtreBookFileName" runat="server" Text='<%# Bind("eBookFileName")  %>'></asp:Literal>
                                   <br /> <br />
                                   <asp:LinkButton ID="linkBtnDownloadFile" CommandArgument='<%# Bind("eBookFileName")  %>' OnCommand="linkBtnDownloadFile_Command" runat="server">
                                              <img alt="downloadbtn"  src="../Images/DownloadBtn.jpg" />
                                  </asp:LinkButton>
                              </ItemTemplate>
                              <ItemStyle  Height="150px" VerticalAlign="Middle" HorizontalAlign="center"  />
                             </asp:TemplateField>                             

                            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                              <ItemTemplate>
                               <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Replace(Environment.NewLine,"<br />")  %>'/>
                              </ItemTemplate>
                              <ItemStyle HorizontalAlign="Left"  />
                             </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Price<br>Discount<br>Discounted Price<br>Date Created" SortExpression="Price" >
                              <ItemTemplate>
                                  <asp:Label ID="lblPCurrency" CssClass="fontRed" runat="server"  Text="USD"></asp:Label>&nbsp;
                                  <asp:Label ID="lblPrice" CssClass="fontBlue" runat="server"  Text='<%# Bind("Price2", "{0:0.00}")  %>'></asp:Label>
                                  <br />
                                  <asp:Label ID="lblDiscount" CssClass="fontRed" runat="server" Text='<%# Bind("Discount")  %>'></asp:Label>%
                                  <br />
                                  <asp:Label ID="lblDCurrency" CssClass="fontRed" runat="server"  Text="USD"></asp:Label>&nbsp;
                                  <asp:Label ID="lblDiscountedPrice" CssClass="fontGreen" runat="server" Text='<%# Bind("DiscountedPrice2", "{0:0.00}")  %>'></asp:Label>&nbsp;<br /><br />
                                 <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("DateCreated","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle  HorizontalAlign="Right" CssClass="CellPaddingRight" />
                             </asp:TemplateField> 

                             <asp:TemplateField HeaderText="Uploader Remarks" SortExpression="DateCreated" >
                              <ItemTemplate>
                               <asp:Label ID="lblURemarks" runat="server" Text='<%# Bind("UserRemarks")  %>'/>
                              </ItemTemplate>
                              <ItemStyle  HorizontalAlign="center"  />
                             </asp:TemplateField>
                                
                             <asp:TemplateField HeaderText="Status" SortExpression="DateCreated" >
                              <ItemTemplate>
                               <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("ApproveStatus")  %>'/>
                              </ItemTemplate>
                              <ItemStyle  HorizontalAlign="center"  />
                             </asp:TemplateField> 
                                
                             <asp:TemplateField HeaderText="Admin Remarks" SortExpression="DateCreated" >
                              <ItemTemplate>
                               <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks")  %>'/>
                              </ItemTemplate>
                              <ItemStyle  HorizontalAlign="center"  />
                             </asp:TemplateField>  
                                
                             <asp:TemplateField HeaderText="Cancel">
                              <ItemTemplate>                                                    
                                   
                                  <asp:ImageButton ID="ImgDelete" Visible="false" CommandName="DELETE" ToolTip="Cancel EBook" OnClientClick="return confirm('Please click OK to confirm Cancel');" runat="server" ImageUrl="~/Images/imgDelete.gif" />
                              </ItemTemplate>
                              
                              <ItemStyle  HorizontalAlign="center"  />
                             </asp:TemplateField>               
                             
                             </Columns>
                             <PagerStyle CssClass="cssPager" />
                             
                             <PagerTemplate>
                                    <table border="0">
                                        <tr>                           
                                             <td style="width:100px">      
                                                <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" runat="server"  ID="ImageButton1" ImageUrl="~/Images/imgPg_First.gif" OnCommand="BtnPaging" CommandArgument="F" />
                                                <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" runat="server" ID="ImageButton2" ImageUrl="~/Images/imgPg_Prev.gif" OnCommand="BtnPaging" CommandArgument="P"/>
                                                <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" runat="server" ID="ImageButton3" ImageUrl="~/Images/imgPg_next.gif" OnCommand="BtnPaging" CommandArgument="N"/>            
                                                <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" runat="server" ID="ImageButton4" ImageUrl="~/Images/imgPg_last.gif" OnCommand="BtnPaging" CommandArgument="L" /> 
                                              </td>
                                            <td class="txtBlackSmall" align="right">Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList"  AutoPostBack="true" runat="server" CssClass="txtBlackSmall" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged" />&nbsp;of&nbsp;
                                                <asp:Label ID="PageCountLabel" runat="server" />
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

