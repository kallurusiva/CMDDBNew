<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_TopBestSellerBooks_Mwallet.aspx.cs" Inherits="Admin_EBAd_TopBestSellerBooks_Mwallet" %>
<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>
<%@ Register src="EBLeftMenu_EBookSales.ascx" tagname="EBLeftMenu_EBookSales" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style9 {
            color: #FF0000;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
   
        <uc2:EBLeftMenu_EBookSales ID="EBLeftMenu_EBookSales1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="tForm" runat="server" enctype="multipart/form-data" method="post">


        

            

            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
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
                            <table cellpadding="0" cellspacing="0" border="0" width="96%">
                    <tr>
                        <td align="center">
                             <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                              <tr>
                                    <td width="5%" align="left" valign="top">
                                        &nbsp;</td>
                                    <td width="90%" align="left" class="subHeaderFontGrad">
                                        &nbsp; EBook Sales Summary&nbsp;- (MWallet)
                                    </td>
                                    <td width="5%"  align="right" valign="top">
                                        &nbsp;</td>
                                </tr>
                             </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            
                        </td>
                    </tr>
                    </table>
                
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

        <asp:Label runat="server" ID="lblCurrentMonthTitle"></asp:Label><br /><span class="auto-style9">Top 5 MWallet Purchases </span> 

        <asp:GridView ID="gridBankInBys" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
            AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="10" AllowSorting="true">
                    <Columns>
                                <asp:TemplateField HeaderText="Sno">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Author Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblAuthorName" runat="server" Text='<% # Bind("Name")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Referral Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblRName" runat="server" Text='<% # Bind("ReferralName")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No. of EBooks" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblcounter" runat="server" Text='<% # Bind("cnt")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                    </Columns>
                             <PagerStyle CssClass="cssPager" />                             
                             <PagerTemplate>
                                    
                                </PagerTemplate>
        </asp:GridView>

        
        

        <br /><br />
        <asp:Label runat="server" ID="lblLastMonthTitle"> </asp:Label><br /><span class="auto-style9">Top 5 Best MWallet Purchases </span> 

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
            AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="10" AllowSorting="true">
                    <Columns>
                                <asp:TemplateField HeaderText="Sno">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Author Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<% # Bind("Name")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Referral Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<% # Bind("ReferralName")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No. of EBooks" >        
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<% # Bind("cnt")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                    </Columns>
                             <PagerStyle CssClass="cssPager" />                             
                             <PagerTemplate>
                                    
                                </PagerTemplate>
        </asp:GridView>

</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

