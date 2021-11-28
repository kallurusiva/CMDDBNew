<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="TestListing.aspx.cs" Inherits="Admin_TestListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <form id="ContactFrmListing" runat="server">

    <table align="center" border="0" cellpadding="0" cellspacing="0" width="96%">
    <tr>
            <td>
                &nbsp; 
       <%--         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" class="UsrsPgBlueGrad" valign="top" width="10">
                            <img height="10" 
                                        src="../Images/table_top_Leftarc_10.gif" width="10" /></td>
                        <td class="UsrsPgBlueGrad">
                                    &nbsp;</td>
                        <td align="right" class="UsrsPgBlueGrad" valign="top" width="10">
                            <img height="10" 
                                        src="../Images/table_top_Rightarc_10.gif" width="10" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="UsrsPgBlue" valign="top">
                                    &nbsp;</td>
                        <td align="left" style="height:20px;" class="UsrsPgBlue subHeaderFontGrad">
                                    News Test List</td>
                        <td align="right" class="UsrsPgBlue" valign="bottom">
                                     &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
   
        <tr><td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            
            
        <table border="0" cellpadding="0" cellspacing="0" class="stdtableBorder_Main" width="100%">
        
         <tr style="height:30px;">
            <td>
            
             <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="3000" runat="server">
                    <ProgressTemplate>
                        Processing ...
                        <img alt="loader" src="../Images/Loader1.gif" 
                            style="width: 16px; height: 16px" /> please wait
                    </ProgressTemplate>
                </asp:UpdateProgress>
             </td>
        </tr>
        
          <tr>
                    
        
            <td align="center">
                            <asp:GridView ID="grdSearchAddrBook" GridLines="Both" 
                                AutoGenerateColumns="False" runat="server" 
                                AllowPaging="true"
                                CssClass="mGrid" DataKeyNames="NewsID"
                                AlternatingRowStyle-CssClass="rowalt" 
                                HeaderStyle-CssClass="rowheader" 
                                onpageindexchanging="grdSearchAddrBook_PageIndexChanging"
                                OnDataBound="grdSearchAddrBook_DataBound" 
                               
                             >
                                <Columns>
                                
                                    <asp:TemplateField HeaderText="Sl No">
                                      <ItemTemplate>
                                       <asp:Label ID="lblNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                      </ItemTemplate>
                                      <ItemStyle Width="40px" />
                                     </asp:TemplateField>
                                     
                                    <asp:TemplateField HeaderText="News ID">
                                      <ItemTemplate>
                                       <asp:Label ID="lblID" runat="server" Text='<%# Bind("NewsID")  %>'/>
                                      </ItemTemplate>
                                      <ItemStyle Width="20px" />
                                     </asp:TemplateField>
                                     
                                     
                                    <asp:TemplateField HeaderText="News Title" SortExpression="NewsTitle">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("NewsTitle") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="News Content" SortExpression="NewsContent">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllastName" runat="server" Text='<%# Bind("NewsContent") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                        
                                    <asp:TemplateField HeaderText="Date" SortExpression="NewsDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDob" runat="server" Text='<%# Bind("NewsDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Functions" >
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="links_FuncLinks" ID="lnkBtnEdit" runat="server">EDIT</asp:LinkButton> | 
                                            <asp:LinkButton CssClass="links_FuncLinks" ID="lnkBtnDelete" runat="server">DELETE</asp:LinkButton>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                </Columns>
                                <%--<HeaderStyle CssClass="rowheader" />--%>
                               <%-- <AlternatingRowStyle CssClass="rowalt"></AlternatingRowStyle>--%>
                               <PagerStyle CssClass="cssPager" />
                               <PagerSettings NextPageText="Next" PreviousPageText="Prev" FirstPageText="Prev" LastPageText="Next" PageButtonCount="5" />
                               <FooterStyle BackColor="#E21A28" Font-Bold="True" ForeColor="White" />
                               <%--<PagerStyle BackColor="#C9E5EA" ForeColor="White" BorderWidth="0" HorizontalAlign="Right" Width="450" BorderStyle="None" />--%>
                                 <PagerStyle HorizontalAlign="Right" />
                                 <PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
          <%--                                      <asp:ImageButton ID="FirstPageImageButton" runat="server" AlternateText="First" CommandName="Page"
                                                    CommandArgument="First" ImageUrl="~/_layouts/images/Axis/images/left.gif"/>
                                                <asp:ImageButton ID="PreviousPageImageButton" runat="server" AlternateText="Previous"
                                                    CommandName="Page" CommandArgument="Prev" ImageUrl="~/_layouts/images/Axis/images/left2.gif" />
                                                    --%>
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
                              <%--              
                                                <asp:ImageButton ID="NextPageImageButton" runat="server" AlternateText="Next" CommandName="Page"
                                                    CommandArgument="Next" ImageUrl="~/_layouts/images/Axis/images/right2.gif" />
                                                <asp:ImageButton ID="LastPageImageButton" runat="server" AlternateText="Last" CommandName="Page"
                                                    CommandArgument="Last" ImageUrl="~/_layouts/images/Axis/images/right.gif" />
                                            </td>--%>
                                            
                                        <td>
                                            <asp:Button CssClass="stdPagerButton" Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                ID="btnNext" />
                                            <asp:Button  CssClass="stdPagerButton" Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                ID="btnLast" />
                                          </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>
                                
                                
                            </asp:GridView>
            </td>
            
            </tr>
                    </table>
         
         </ContentTemplate>
            </asp:UpdatePanel>
                    </td>
        </tr>
        <tr>
            <td>
                            &nbsp;</td>
        </tr>
        <tr>
            <td>
                            
                          
            </td>
        </tr>
    </table>
</form>

</asp:Content>

