<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_TopReferral.aspx.cs" Inherits="Admin_EBAd_TopReferral" %>



<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_EBookSales.ascx" tagname="EBLeftMenu_EBookSales" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            text-decoration: underline;
        }
        .auto-style4 {
            width: 31%;
        }
        .auto-style5 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: left;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        .auto-style7 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: center;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        .auto-style8 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: center;
            font-variant: normal;
            font-style: normal;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
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
                                        &nbsp; Top Referral Summary&nbsp; </td>
                                    <td width="5%"  align="right" valign="top">
                                        &nbsp;</td>
                                </tr>
                             </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                                <tr>
                                    <td width="2%">
                                        &nbsp;</td>
                                    <td class="auto-style4">
                                        &nbsp;</td>
                                    <td width="35%">
                                        &nbsp;</td>
                                    <td width="2%">
                                        &nbsp;</td>
                                </tr>
                   
                               <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style8" colspan="2" >
                                        <strong>Top Referral Summary</strong></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        <asp:Label runat="server" ID="lblTotAdmBooksText"> </asp:Label></td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblTotAdmBooks"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        <asp:Label runat="server" ID="lblTotAdmBooksCMonthText"> </asp:Label></td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblTotAdmBooksCMonth"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        <asp:Label runat="server" ID="lblTotAdmBooksLMonthText"> </asp:Label></td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblTotAdmBooksLMonth"> </asp:Label></td>
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
                </table>

        <asp:Label runat="server" ID="lblCurrentMonthTitle"></asp:Label><br /><span class="auto-style9">Top 5 Partner Referral Upgrade (From FREE) </span> 

        <asp:GridView ID="gridBankInBys" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
            AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="10" AllowSorting="true">
                    <Columns>
                                <asp:TemplateField HeaderText="Sno">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Partner Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblPartnerName" runat="server" Text='<% # Bind("member_name")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Referral Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblRName" runat="server" Text='<% # Bind("ReferralName")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No. of Partners Upgrade" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblcounter" runat="server" Text='<% # Bind("counter")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                    </Columns>
                             <PagerStyle CssClass="cssPager" />                             
                             <PagerTemplate>
                                    
                                </PagerTemplate>
        </asp:GridView>

        <span class="auto-style9">Top 5 Partner Referral Upgrade (From  Any Status) </span> 
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
            AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="10" AllowSorting="true">
                    <Columns>
                                <asp:TemplateField HeaderText="Sno">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Partner Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblPartnerName" runat="server" Text='<% # Bind("member_name")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>   

                                <asp:TemplateField HeaderText="Referral Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblRName" runat="server" Text='<% # Bind("ReferralName")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>                             

                                <asp:TemplateField HeaderText="Sales of Upgrade" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<% # Bind("amount")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                    </Columns>
                             <PagerStyle CssClass="cssPager" />                             
                             <PagerTemplate>
                                    
                                </PagerTemplate>
        </asp:GridView>

        <br /><br />
        <asp:Label runat="server" ID="lblLastMonthTitle"> </asp:Label><br /><span class="auto-style9">Top 5 Partner Referral Upgrade (From FREE)</span> 

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
            AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="10" AllowSorting="true">
                    <Columns>
                                <asp:TemplateField HeaderText="Sno">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Partner Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblPartnerName" runat="server" Text='<% # Bind("member_name")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Referral Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblRName" runat="server" Text='<% # Bind("ReferralName")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No. of Partners Upgrade" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblcounter" runat="server" Text='<% # Bind("counter")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                    </Columns>
                             <PagerStyle CssClass="cssPager" />                             
                             <PagerTemplate>
                                    
                                </PagerTemplate>
        </asp:GridView>

        <span class="auto-style9">Top 5 Partner Referral Upgrade (From  Any Status) </span> 
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
            AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="10" AllowSorting="true">
                    <Columns>
                                <asp:TemplateField HeaderText="Sno">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Partner Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblPartnerName" runat="server" Text='<% # Bind("member_name")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>               

                                <asp:TemplateField HeaderText="Referral Name" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblRName" runat="server" Text='<% # Bind("ReferralName")%>'></asp:Label>
                                    </ItemTemplate>            
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>                 

                                <asp:TemplateField HeaderText="Sales of Upgrade" >        
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<% # Bind("amount")%>'></asp:Label>
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


