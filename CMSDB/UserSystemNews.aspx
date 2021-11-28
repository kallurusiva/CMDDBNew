<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserSystemNews.aspx.cs" Inherits="UserFaqs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">

<script language="javascript" type="text/javascript">

    function ShowSystemNews(vSysID) {

        alert(vSysID);
    }

</script>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> 
    <asp:Literal ID="ltrSystemNews" runat="server"></asp:Literal></td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/faq_panel.jpg" />
    
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

<form id="frmSystemNews" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </td>
<td width="1%">&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>


<tr>

<td>&nbsp;</td>
<td>

        <%--<asp:Repeater ID="rpFaqList" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="cssfaq">
            <tr>
            <td>
            <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="ltrSystemNews2" Text="System News" runat="server"></asp:Literal>
                </div>
            </div>    
            
            </td>
            </tr>
            
            <tr>
            <td>&nbsp; </td>
            </tr>
         
        </HeaderTemplate>
        
        <ItemTemplate>
        
            <tr>
            <td> 
                <div class="cssfaqQuestion">
                    <div class="cssfaq_TLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                    <div class="cssfaq_QuestionText"> 
                    <asp:Literal ID="ltrSlNo" runat="server" Text='Q<%# Container.ItemIndex + 1  %>'></asp:Literal>.&nbsp; 
                    <asp:Literal ID="LtrFaqQuestion" Text='<%# Eval("FaqQuestion")%>' runat="server"></asp:Literal>  
                    </div>
                </div>    
            
                </td>
            </tr>
            <tr>
            <td  class="cssfaqAnswer"> 
                <asp:Literal ID="LtrFaqAnswer" Text='<%# Eval("FaqAnswer")%>' runat="server"></asp:Literal>
             </td>
            </tr>
          
        
        </ItemTemplate>
        <SeparatorTemplate>
            <tr>
            <td class="cssfaqSeparator">&nbsp; </td>
            </tr>
        
        </SeparatorTemplate>
        
        <FooterTemplate>
            <tr>
            <td>&nbsp; </td>
            <td>&nbsp; </td>
            </tr>
            </table>
        </FooterTemplate>
        </asp:Repeater>--%>
        


  <table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
  <td>&nbsp;</td>
  </tr>
</table>



</td>
<td>&nbsp;</td>
</tr>

<tr>
<td>&nbsp;</td>
<td>
                    
        <asp:GridView ID="gridSystemNews" runat="server" 
                            AutoGenerateColumns="False" DataKeyNames="SnID"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="20" onpageindexchanging="gridSystemNews_PageIndexChanging"
                               AllowSorting="true" OnSorting="gridSystemNews_Sorting"   
                                ondatabound="gridSystemNews_DataBound" 
                                onrowdatabound="gridSystemNews_RowDataBound"
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
                             </asp:TemplateField>
                             
                            <asp:TemplateField HeaderText="Contents" SortExpression="Contents">
                             <ItemTemplate>
                               <asp:Label ID="lblContent" runat="server" 
                                     Text='<%# Eval("Contents").ToString().Replace(Environment.NewLine,"<br/>")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="300px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Created Date" SortExpression="CreatedDate" >
                              <ItemTemplate>
                               <asp:Label ID="lbltstDate" runat="server" 
                                      Text='<%# Bind("CreatedDate","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="center"  />
                             </asp:TemplateField>
                             
                             </Columns>
                             <PagerStyle CssClass="cssPager" />
                             
                             <PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
                                         <td width="100px">      
                                            <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" 
                                                 CommandArgument="First" runat="server"  ID="btnFirst" 
                                                 ImageUrl="~/Images/imgPg_First.gif" />
                                            <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" 
                                                 CommandArgument="Prev" runat="server" ID="btnPrevious" 
                                                 ImageUrl="~/Images/imgPg_Prev.gif"/>
                                                    </td>
                                                    
                                            <td width="100px">
                                                Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" 
                                                    OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  
                                                    runat="server"/>&nbsp;of&nbsp;<asp:Label
                                                    ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td width="100px">
                                            <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" 
                                                CommandArgument="Next" runat="server" ID="btnNext" 
                                                ImageUrl="~/Images/imgPg_next.gif"/>
                                            <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" 
                                                CommandArgument="Last" runat="server" ID="btnLast" 
                                                ImageUrl="~/Images/imgPg_last.gif" />
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
<td>&nbsp;</td>
</tr>


<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>


<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>


</table>
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

