<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dt_User_PrepaidPurchase_History.aspx.cs" Inherits="O_dt_User_PrepaidPurchase_History" %>
<%@ Register Src="~/O_FooterBlue.ascx" TagPrefix="uc1" TagName="O_FooterBlue" %>
<%@ Register Src="~/O_LeftBlue.ascx" TagPrefix="uc1" TagName="O_LeftBlue" %>
<%@ Register Src="~/O_topBlue.ascx" TagPrefix="uc1" TagName="O_topBlue" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:O_topBlue runat="server" ID="O_topBlue" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

    <div class="main" runat="server">
        <%--<div class="page-header" runat="server">
            <div class="container-fluid" runat="server">
                <ol class="breadcrumb">
                    <li><a href="index.html">Home</a></li>
                    <li class="#">Category</li>
                    <li class="active">My Categories</li>
                </ol>
            </div>
        </div>--%>

        

        <div class="container-fluid" runat="server">
            <div class="row" runat="server">
                <div runat="server" class="col-md-9 col-md-push-3">
                        <div runat="server" class="table-responsive">
                            <h2>Prepaid Purchase History</h2>
                            <asp:GridView ID="GridView1" CssClass="table table-bordered cart-table" runat="server" AllowPaging="True"  AllowSorting="True" AutoGenerateColumns="False" ondatabound="GridView1_DataBound" 

onpageindexchanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated" onrowdatabound="GridView1_RowDataBound" onsorting="GridView1_Sorting" PageSize="50" ShowFooter="True" 

OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" EnableModelValidation="True" GridLines="None" BorderWidth="1px">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="sno">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1 + "."%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="TransctionID" SortExpression="uid">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTranID" runat="server" Text='<% # Bind("uid")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="25px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Credits Charges" SortExpression="uid">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblBName" runat="server" Text='<% # Bind("creditsCharged")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Purchase Date" SortExpression="uid">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPDate" runat="server" Text='<% # Bind("tdate")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>
                                                                             <asp:TemplateField HeaderText="Purchased Items" SortExpression="uid">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPItems" runat="server" Text='<% # Bind("ebooks")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>  
                                                                            <asp:TemplateField HeaderText="sendTo" SortExpression="uid">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblBankActNo" runat="server" Text='<% # Bind("email")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>
                                                                                                                           
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="header header-top-text" HorizontalAlign="Left" />
                                                                        <AlternatingRowStyle CssClass="alternateRowStyle" Font-Size="Small" BackColor="White" HorizontalAlign="Left" />
                                                                        <EditRowStyle BackColor="#7C6F57" />
                                                                        <FooterStyle CssClass="footerRowStyle" BackColor="White" ForeColor="White" Font-Bold="True" />
                                                                        <RowStyle cssClass="innertdgrey2" Font-Size="Small" HorizontalAlign="Left" />
                                                                        <PagerStyle cssClass="innertdgrey2" HorizontalAlign="Center" />
                                                                        <PagerTemplate>
                                                                            <table border="0" width="100%">
                                                                                <tr>
                                                                                    <td style="width:100px">
                                                                                        <asp:ImageButton ID="btnFirst" runat="server" CommandArgument="First" CommandName="Page" ImageUrl="~/Images/arrow_left2.png" Text="First" 

ToolTip="FIRST" />
                                                                                        <asp:ImageButton ID="btnPrevious" runat="server" CommandArgument="Prev" CommandName="Page" ImageUrl="~/Images/arrow_up2.png" Text="Previous" 

ToolTip="PREVIOUS" />
                                                                                        <asp:ImageButton ID="btnNext" runat="server" CommandArgument="Next" CommandName="Page" ImageUrl="~/Images/arrow_down2.png" Text="Next" 

ToolTip="NEXT" />
                                                                                        <asp:ImageButton ID="btnLast" runat="server" CommandArgument="Last" CommandName="Page" ImageUrl="~/Images/arrow_right2.png" Text="Last" 

ToolTip="LAST" />
                                                                                    </td>
                                                                                    <td align="right" class="txtBlackSmall">Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" runat="server" AutoPostBack="true" 

CssClass="txtBlackSmall" OnSelectedIndexChanged="pageNumberDropDownList_OnSelectedIndexChanged" />
                                                                                        &nbsp;of&nbsp;<asp:Label ID="PageCountLabel" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </PagerTemplate>
                                                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                                    </asp:GridView>

                            
                        </div>
                        
                        <div runat="server" class="mb130 mb100-sm mb80-xs"></div>
                    </div>
                <div class="mb30 visible-sm visible-xs clearfix" runat="server"></div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>            
        </div>
        <div class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                
</asp:Content>