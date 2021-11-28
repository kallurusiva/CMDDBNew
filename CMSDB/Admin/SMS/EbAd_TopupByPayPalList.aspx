<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_TopupByPayPalList.aspx.cs" Inherits="Admin_SMS_EbAd_TopupByPayPalList" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SMSSystem ID="EBLeftMenu_SMSSystem1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
      
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../../Images/inf_Error.gif" alt="MessageImage"/></td>
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
                            &nbsp; SMS System : SMS Topup By Pay Pal History</td>
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
                        
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="50" onpageindexchanging="GridView1_PageIndexChanging"
    AllowSorting="true" ondatabound="GridView1_DataBound" onrowdatabound="GridView1_RowDataBound" OnSorting="GridView1_Sorting">
    <Columns>        
      <asp:TemplateField HeaderText="Sno">
           <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
           <ItemStyle Width="10px" HorizontalAlign="Left" VerticalAlign="Top"/>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Mobile" SortExpression="Mobile" HeaderStyle-HorizontalAlign="Left" >        
            <ItemTemplate>
                <asp:Label ID="lblMobile" runat="server" Text='<% # Bind("Mobile")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField> 
      <asp:TemplateField HeaderText="Name" SortExpression="MName" HeaderStyle-HorizontalAlign="Left">        
            <ItemTemplate>
                <asp:Label ID="lblMName" runat="server" Text='<% # Bind("MName")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Volume" SortExpression="Info" HeaderStyle-HorizontalAlign="Left">        
            <ItemTemplate>                
                <asp:Label ID="lblInfo" runat="server" Text='<% # Bind("INFO") %>'/>
            </ItemTemplate>            
            <ItemStyle Width="50px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="PytDate" HeaderStyle-HorizontalAlign="Left">        
            <ItemTemplate>
                <asp:Label ID="lblPDate" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "PytDate", "{0:MMMM d, yyyy h:mm tt}")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Status" HeaderStyle-HorizontalAlign="Left">        
            <ItemTemplate>
                <asp:Label ID="lblPytStatus" runat="server" Text='<% # Bind("PytStatus")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="60px" />
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Admin Approval" HeaderStyle-HorizontalAlign="Left">        
            <ItemTemplate>
                <asp:Label ID="lblStatus" runat="server" Text='<% # Bind("StatusAd")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="60px" />
        </asp:TemplateField>        
        <asp:TemplateField HeaderText="Currency" HeaderStyle-HorizontalAlign="Right">        
            <ItemTemplate>                
                <asp:Label ID="lblPytCurrencyCode" runat="server" Text='<% # Bind("PytCurrencyCode") %>'/>
            </ItemTemplate>            
            <ItemStyle Width="40px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Reward">        
            <ItemTemplate>
                <asp:Label ID="lblReward" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "RewardAmt", "{0:0.00}")%>' />
            </ItemTemplate> 
            <ItemStyle Width="20px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>        
        <%--<asp:TemplateField HeaderText="Payment" SortExpression="PytGrossAmt">        
            <ItemTemplate>
                <asp:Label ID="lblIamount" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "PytGrossAmt", "{0:0.00}")%>'/>
            </ItemTemplate> 
            <FooterTemplate>
                <asp:Label runat="server" ID="lblFooterAmount" Text=""></asp:Label>
            </FooterTemplate>            
            <ItemStyle Width="20px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>--%>     
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
<br />
<asp:HiddenField ID="hdnPRMCode_ID" runat="server" />
<asp:HiddenField ID="hdnPRM_ID" runat="server" />
<asp:HiddenField ID="hdn_tid" runat="server" />
<asp:HiddenField ID="hdn_IdentifierID" runat="server" />
<asp:HiddenField ID="hdn_EmailID" runat="server" />
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

