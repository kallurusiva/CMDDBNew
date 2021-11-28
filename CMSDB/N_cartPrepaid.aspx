<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_cartPrepaid.aspx.cs" Inherits="N_cartPrepaid" %>
<%@ Register Src="~/N_Footer.ascx" TagPrefix="uc1" TagName="N_Footer" %>
<%@ Register Src="~/N_LeftMenu.ascx" TagPrefix="uc1" TagName="N_LeftMenu" %>
<%@ Register Src="~/N_TopMenu.ascx" TagPrefix="uc1" TagName="N_TopMenu" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:N_TopMenu runat="server" ID="N_TopMenu" />
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

    <uc1:N_LeftMenu runat="server" ID="N_LeftMenu" />

   
    <div class="col-xs-9 content-middle">
                    

        <div class="m-b-20"></div>
                
                    <div class="row">
                        <div class="col-xs12">
                            <div class="row">                                
                                <div runat="server" class="table-responsive">

                            <asp:GridView ID="gridItems" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="False" 
                            CssClass="table-fill-cart"
                            DataKeyNames="id" HeaderStyle-CssClass="quantity-col" 
                            ondatabound="gridItems_DataBound" onpageindexchanging="gridItems_PageIndexChanging" 
                            onrowcancelingedit="gridItems_RowCancelingEdit" onrowdatabound="gridItems_RowDataBound" 
                            onrowdeleting="gridItems_RowDeleting" 
                            onrowediting="gridItems_RowEditing" OnRowUpdating="gridItems_RowUpdating"  OnRowCreated="gridItems_RowCreated" 
                            PageSize="10">

                                <Columns>

                                <asp:TemplateField HeaderText="No" HeaderStyle-CssClass="text-center"> 
                                <ItemTemplate>
                                    <asp:Label ID="lblSlNo" CssClass="text-center" runat="server" Text="<%# Container.DataItemIndex + 1  %>" />
                                    <asp:Literal ID="hdBookId" runat="server" Text='<%#Bind("id")%>' Visible="false"></asp:Literal>
                                    <asp:HiddenField ID="hdItemsCount" Value='<%#Bind("count")%>' runat="server" />
                                    <asp:HiddenField ID="hdTotalAmount" Value='<%#Bind("total")%>' runat="server" />
                                </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product ID / Product Name" SortExpression="BookID" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <div style="vertical-align:bottom; position: relative;">
                                    <div id="dvBookImg" style="float:left; margin-left: 20px;">
                                    <asp:Image ID="ImgEbook" CssClass="text-left" Height="100" Width="60" ImageUrl='<%# Eval("ImageURL")%>' runat="server" />
                                        </div>
                                    <div id="dvBookDetails" style="float:left; margin-left: 30px; margin-top: 10px; padding: 10px; vertical-align:text-bottom;">
                                    <asp:Label ID="lblBookID" runat="server" CssClass="text-center" Text='<%# Bind("id")  %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblBookName" runat="server" CssClass="text-center" Text='<%# Bind("name")  %>'></asp:Label>
                                        </div>
                                        </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign ="Left" />
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Prepaid Price" SortExpression="Price" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrepaidPrice" runat="server" CssClass="fontViewCart" Text=''></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="CellPaddingRight" HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Price" SortExpression="Price" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    
                                     <asp:Label ID="Label1" runat="server" CssClass="fontCart" Text='<%# Bind("currency")  %>'></asp:Label>&nbsp;
                                    <asp:Label ID="lblPrice" runat="server" CssClass="fontViewCart" Text='<%# Bind("price", "{0:0.00}")  %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="CellPaddingRight" HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                           
                         
                            <asp:TemplateField HeaderText="Remove from Cart" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgDelete" runat="server" CommandName="DELETE" Height="80" Width="50" ImageUrl="~/Images/ebImages/cart/shopping_cart_delete.png" CssClass="fa fa-trash" OnClientClick="return confirm('Please click OK to confirm deletion');" ToolTip="Remove from Cart" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="100px" />
                            </asp:TemplateField>

                               </Columns>
         </asp:GridView>
                        </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 col-lg-12">
                            <div class="float-left">
                                <div class="button-action">
                                    <asp:LinkButton ID="LnkPrepaidPurchase" runat="server" Text="Registered Prepaid User?" OnClick="LnkPrepaidPurchase_Click">
                                        Registered Prepaid User?
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="float-right">
                                <div class="button-action">
                                    <asp:LinkButton ID="lnkCheckOut2PayPal" runat="server" Text="New Prepaid User?" OnClick="lnkCheckOut2PayPal_Click">
                                        New Prepaid User?
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
               
    </div>
    

   

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>