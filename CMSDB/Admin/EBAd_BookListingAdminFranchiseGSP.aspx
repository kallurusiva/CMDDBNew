<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_BookListingAdminFranchiseGSP.aspx.cs" Inherits="Admin_EBAd_BookListingAdminFranchiseGSP" %>

<%@ Register src="EBLeftMenu_Franchise.ascx" tagname="EBLeftMenu_Franchise" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:EBLeftMenu_Franchise ID="EBLeftMenu_Franchise1" runat="server" />
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

        function downloadConfirmation() {
            if (confirm("Are you sure you want to delete this user?"))
                return true;
            else
                return false;
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
                            &nbsp; Products Listing</td>
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
                            &nbsp;<%--Password for downloaded book :--%><asp:Label ID="lblPassword" runat="server" Visible="false"></asp:Label>
                          

                            <table id="tblSearchSimple" align="center" cellpadding="0" cellspacing="2" class="stdtableBorder_Search">
                                <tr>
                                    <td style="width:10px;">&nbsp;</td>
                                    <td style="width:120px;" class="SearchLabelBold">Search By</td>
                                    <td style="width:3px;">&nbsp;:&nbsp;</td>
                                    <td class="SearchLabel" style="width:150px;" align="left">
                                        <asp:DropDownList ID="ddlSearchParam" CssClass="stdDropDown1" runat="server" OnSelectedIndexChanged="ddlSearchParam_SelectedIndexChanged" AutoPostBack="True"                                             
                                            >
                                            <asp:ListItem Value="BK.BookName">Book Name</asp:ListItem>
                                            <asp:ListItem Value="BK.BookID">Book Code</asp:ListItem>
                                            <asp:ListItem Value="BK.CATID">Category</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:10px;"> &nbsp;</td>
                                    <td style="width:120px;" class="SearchLabelBold">Search Value</td>
                                    <td style="width:3px;">&nbsp;:&nbsp;</td>
                                    <td class="SearchLabel" align="left" style="width:150px;">
                                        <div id="dvSearchTextBox" style="display: block">
                                            <asp:TextBox ID="txtSearchValue" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                            <asp:DropDownList ID="ddlCategoriesSearch" Visible="false" runat="server"></asp:DropDownList>
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
                                    <td style="width:20px;"> </td>
                                </tr>
                                
                            </table>


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
                                CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
                                AlternatingRowStyle-CssClass="rowalt" 
                                AllowPaging="true" PageSize="10" 
                                onpageindexchanging="gridEbooks_PageIndexChanging"
                                AllowSorting="true"  
                                onrowcancelingedit="gridEbooks_RowCancelingEdit" 
                                onrowediting="gridEbooks_RowEditing"   
                                onrowdeleting="gridEbooks_RowDeleting" 
                                ondatabound="gridEbooks_DataBound" 
                                onrowdatabound="gridEbooks_RowDataBound" 
                                OnRowUpdating="gridEbooks_RowUpdating" 
                                OnSorting="gridEbooks_Sorting"
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
                             <%--  <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>--%>
                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("Row") %>'/>
                                   <asp:HiddenField ID="hidBookId" Value='<%#Bind("BookID")%>' runat="server" />
                                  <asp:HiddenField ID="hidBookUID" Value='<%#Bind("UID")%>' runat="server" />
                                  <asp:HiddenField ID="hidCreatedBy" Value='<%#Bind("CreatedBy")%>' runat="server" />
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

                          <%--  <asp:TemplateField HeaderText="Assgined Categories" SortExpression="CategoryName" >
                              <ItemTemplate>
                                  <asp:Label ID="LtrACategoryName" runat="server" Text='<%# Eval("AssignedCategories").ToString().Replace(",","<br/>") %>'></asp:Label>

                              </ItemTemplate>
                              <ItemStyle Width="70px" HorizontalAlign="Left"  />
                             </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Product Image">
                              <ItemTemplate>
                                  <asp:Image ID="lblImageFilePath" ImageUrl='<%# Bind("ImageFileFullURL")%>' Width="100" Height="100" runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="150px" Height="150px" VerticalAlign="Middle" HorizontalAlign="center"  />
                             </asp:TemplateField>


                              <asp:TemplateField HeaderText="Attachment">
                              <ItemTemplate>
                                  <asp:Literal ID="LtreBookFileName" runat="server" Text='<%# Bind("eBookFileName")  %>'></asp:Literal>
                                  <br /><br />
                                   <%--<br /> <br />
                                   <asp:LinkButton ID="linkBtnDownloadFile" 
                                       OnClientClick='<%# Eval("USDDiscountedPrice", "return confirm(\"{0} USD will be deduted for ebook Download. Click OK to continue else click CANCEL. Please Refresh page after download?\");") %>'
                                        CommandArgument='<% #Bind("eBookFileNameStatus") %>' OnCommand="linkBtnDownloadFile_Command" runat="server">
                                              <img alt="downloadbtn" style="border: 0;"  src="../Images/DownloadBtn.jpg" />
                                  </asp:LinkButton>                                  
                                  <br /> <br />
                                  <div class="fontPending">
                                  <asp:Literal ID="LtrDownloaded" runat="server" Text='<%# Bind("downloadStatus") %>'></asp:Literal>
                                      <br />
                                       <asp:Literal ID="LtrPassword" runat="server"></asp:Literal>
                                      </div>--%>
                            <asp:HyperLink ID="hypBuyNow" runat="server" NavigateUrl='<%# Bind("buyURL")%>' Target="_blank" Text='<%# Bind("showURL")%>'></asp:HyperLink>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             

                             <asp:TemplateField HeaderText="Description" SortExpression="Description">
                              <ItemTemplate>
                               <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Replace(Environment.NewLine,"<br />")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="Left"  />
                             </asp:TemplateField>

                                <asp:TemplateField HeaderText="USD Price<br>Discount<br>USD Discounted Price" SortExpression="USDPrice" >
                              <ItemTemplate>
                                  <asp:Label ID="lblPCurrencyUSD" CssClass="fontRed" runat="server"  Text="USD"></asp:Label>&nbsp;
                                  <asp:Label ID="lblPriceUSD" CssClass="fontBlue" runat="server"  Text='<%# Bind("USDPrice", "{0:0.00}")  %>'></asp:Label>
                                  <br />
                                  <asp:Label ID="lblDiscountUSD" CssClass="fontRed" runat="server" Text='<%# Bind("Discount")  %>'></asp:Label>%
                                  <br />
                                  <asp:Label ID="lblDCurrencyUSD" CssClass="fontRed" runat="server"  Text="USD"></asp:Label>&nbsp;
                                  <asp:Label ID="lblDiscountedPriceUSD" CssClass="fontGreen" runat="server" Text='<%# Bind("USDDiscountedPrice", "{0:0.00}")  %>'></asp:Label>&nbsp;
                                 
                              </ItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="Right" CssClass="CellPaddingRight" />
                             </asp:TemplateField>
                            
                               <asp:TemplateField HeaderText="Price<br>Discount<br>Discounted Price" SortExpression="Price" >
                              <ItemTemplate>
                                  <asp:Label ID="lblPCurrency" CssClass="fontRed" runat="server"  Text='<%# Bind("userCurrency")  %>'></asp:Label>&nbsp;
                                  <asp:Label ID="lblPrice" CssClass="fontBlue" runat="server"  Text='<%# Bind("Price2", "{0:0.00}")  %>'></asp:Label>
                                  <br />
                                  <asp:Label ID="lblDiscount" CssClass="fontRed" runat="server" Text='<%# Bind("Discount")  %>'></asp:Label>%
                                  <br />
                                  <asp:Label ID="lblDCurrency" CssClass="fontRed" runat="server"  Text='<%# Bind("userCurrency")  %>'></asp:Label>&nbsp;
                                  <asp:Label ID="lblDiscountedPrice" CssClass="fontGreen" runat="server" Text='<%# Bind("DiscountedPrice2", "{0:0.00}")  %>'></asp:Label>&nbsp;
                                 
                              </ItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="Right" CssClass="CellPaddingRight" />
                             </asp:TemplateField>
                             
                             <%-- <asp:TemplateField HeaderText="Date Created" SortExpression="DateCreated" >
                              <ItemTemplate>
                               <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("DateCreated","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="center"  />
                             </asp:TemplateField>

                                <asp:TemplateField HeaderText="Special Status" SortExpression="SpecialStatus" >
                              <ItemTemplate>
                               <asp:Label ID="lblSpecialStatus" runat="server" Text='<%# Bind("SpecialStatus")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="center"  />
                             </asp:TemplateField>      --%>                       
                             
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


