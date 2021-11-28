<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_ValueBuyList.aspx.cs" Inherits="EBAd_ValueBuyList" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_ValueBuy.ascx" tagname="EBLeftMenu_ValueBuy" tagprefix="uc2" %>

<%@ Register src="EBLeftMenu_ebButtons.ascx" tagname="EBLeftMenu_ebButtons" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc3:EBLeftMenu_ebButtons ID="EBLeftMenu_ebButtons1" runat="server" />

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
            <table cellpadding="0" cellspacing="0" class="MessagerBarCssERROR" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="~/Images/inf_Error.gif" alt="MessageImage"/></td>
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
                            &nbsp; &#39;Value-Buy&#39; Listing</td>
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
                        
                            <asp:GridView ID="gridEbooks" runat="server" AutoGenerateColumns="False" DataKeyNames="ValueBuyUID"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="20" onpageindexchanging="gridEbooks_PageIndexChanging"
                               AllowSorting="true"  
                                onrowcancelingedit="gridEbooks_RowCancelingEdit" 
                                onrowediting="gridEbooks_RowEditing"  
                                onrowdeleting="gridEbooks_RowDeleting" ondatabound="gridEbooks_DataBound" onrowdatabound="gridEbooks_RowDataBound" OnRowUpdating="gridEbooks_RowUpdating"
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
                                  <asp:Literal ID="hdBookId" Visible="false" Text='<%#Bind("BookID")%>' runat="server"></asp:Literal>
                                  <asp:Literal ID="hdUID" Visible="false" Text='<%#Bind("UID")%>' runat="server"></asp:Literal>
                                  
                                  <asp:HiddenField ID="hidCreatedBy" Value='<%#Bind("CreatedBy")%>' runat="server" />

                                  <asp:Literal ID="hdvalueBuyUID" Visible="false" Text='<%#Bind("ValueBuyUID")%>' runat="server"></asp:Literal>
                                  <%-- <asp:HiddenField ID="hidUserID" Value='<%#Bind("UserID")%>' runat="server" />
                                  <asp:HiddenField ID="hidUserType" Value='<%#Bind("UserType")%>' runat="server" />--%>
                              </ItemTemplate>
                              <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            

                              <asp:TemplateField HeaderText="Product ID<br>Package Name" SortExpression="BookID" >
                              <ItemTemplate>
                                  <asp:Label ID="lblBookID" CssClass="font_12Green" runat="server" Text='<%# Bind("BookID")  %>'></asp:Label>
                                  <%--<asp:Label ID="lblBookCount" CssClass='font_12Msg_Error" runat="server" Text='<%# Bind("BooksCount")  %>'></asp:Label>--%>
                                  <br />
                                  <asp:Label ID="lblBookName" CssClass="fontBlue12" runat="server" Text='<%# Bind("BookName")  %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle Width="90px" HorizontalAlign="Left"  />
                             </asp:TemplateField>


                              <asp:TemplateField HeaderText="Product Count<br/>ProductIDs">
                              <ItemTemplate>
                                 
                                  <asp:Label ID="lblBooks" CssClass="font_12Normal" runat="server" Text=''></asp:Label>

                                  <asp:HiddenField ID="hdBookCount" Value='<%# Bind("BooksCount")  %>' runat="server" />
                                  <div id="dvBook1" class="dvBookCss">
                                   <asp:Label ID="lblBookID1" CssClass="FontNote" runat="server" Text='<%# Bind("BookID1")  %>' ></asp:Label><br />
                                   <asp:Image ID="ImageBook1" CssClass="ebookImgCss" ImageUrl= '<%# Bind("ImageFileURL1")  %>' runat="server" />
                                  </div>

                                  <div id="dvBook2" class="dvBookCss">
                                   <asp:Label ID="lblBookID2" CssClass="FontNote" runat="server" Text='<%# Bind("BookID2")  %>' ></asp:Label><br />
                                   <asp:Image ID="ImageBook2" CssClass="ebookImgCss" ImageUrl= '<%# Bind("ImageFileURL2")  %>' runat="server" />
                                  </div>
                                  
                                  <div id="dvBook3" class="dvBookCss">
                                   <asp:Label ID="lblBookID3" CssClass="FontNote" runat="server" Text='<%# Bind("BookID3")  %>' ></asp:Label><br />
                                   <asp:Image ID="ImageBook3" CssClass="ebookImgCss" ImageUrl= '<%# Bind("ImageFileURL3")  %>' runat="server" />
                                  </div>

                                  <div id="dvBook4" class="dvBookCss">
                                   <asp:Label ID="lblBookID4" CssClass="FontNote" runat="server" Text='<%# Bind("BookID4")  %>' ></asp:Label><br />
                                   <asp:Image ID="ImageBook4" CssClass="ebookImgCss" ImageUrl= '<%# Bind("ImageFileURL4")  %>' runat="server" />
                                  </div>

                                  <div id="dvBook5" class="dvBookCss">
                                   <asp:Label ID="lblBookID5" CssClass="FontNote" runat="server" Text='<%# Bind("BookID5")  %>' ></asp:Label><br />
                                   <asp:Image ID="ImageBook5" CssClass="ebookImgCss" ImageUrl= '<%# Bind("ImageFileURL5")  %>' runat="server" />
                                  </div>
                              </ItemTemplate>
                              <ItemStyle Width="300px" Height="150px" VerticalAlign="Middle" HorizontalAlign="center"  />
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

                               <asp:TemplateField HeaderText="CC Mobiles">
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
                              <ItemStyle Width="70px" HorizontalAlign="center"  />
                             </asp:TemplateField>


                                <%-- <asp:TemplateField HeaderText="Show on<br>HomePage">
                              <ItemTemplate>
                                  <asp:Image ID="ImgHpShow" runat="server" />
                                  <asp:Literal ID="LtrisShowAtHp" runat="server" Text='<%# Bind("isShowAtHp") %>' Visible="false"></asp:Literal>
                                  </ItemTemplate>
                                
                                 <EditItemTemplate>
                                  <asp:CheckBox ID="chkisShowAtHP" Enabled="true" Checked='<%# Bind("isShowAtHp") %>' runat="server" />
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
                             
                          
                             
                           <%-- <asp:TemplateField HeaderText="Allow<br>Buy PayPal">
                              <ItemTemplate>
                                  <asp:Image ID="ImgAllowPaypalBuyy" runat="server" />
                                  <asp:Literal ID="LtrAllowPaypalBuy" runat="server" Text='<%# Bind("AllowPaypalBuy") %>' Visible="false"></asp:Literal>
                                  </ItemTemplate>
                                 <ItemStyle Width="30px" HorizontalAlign="Center"  />
                             </asp:TemplateField>


                                <asp:TemplateField HeaderText="Allow<br>Buy SMS">
                              <ItemTemplate>
                                  <asp:Image ID="ImgAllowSMSbuy" runat="server" />
                                  <asp:Literal ID="LtrAllowSMSbuy" runat="server" Text='<%# Bind("AllowSMSbuy") %>' Visible="false"></asp:Literal>
                                  </ItemTemplate>
                                 <ItemStyle Width="30px" HorizontalAlign="Center"  />
                             </asp:TemplateField>--%>


                             
                             
                             
                              <asp:TemplateField HeaderText="Functions">
                              <ItemTemplate>
                                  <asp:HyperLink ID="HyLinkEdit" runat="server" Visible="false">
                                      <asp:Image ID="ImgEdit1" ImageUrl="~/Images/imgEdit2.gif" runat="server" />                                  
                                  </asp:HyperLink>              
                                  <asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit EBook" Visible="false" runat="server" ImageUrl="~/Images/imgEdit.gif"/>
                                  <asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete EBook" OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />
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
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

