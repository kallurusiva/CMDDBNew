<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_User_Paypal_History.aspx.cs" Inherits="N_User_Paypal_History" %>
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
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="cart">
                                <div class="itembox">
                                    <div class="itemcart">
                                        <i class="fa fa-shopping-cart" aria-hidden="true"></i> <span id="value-item" class="value-item"><asp:Literal runat="server" ID="cartItems" Text="0"></asp:Literal></span>Item(s)
                                    </div>
                                    <div class="priceitem">
                                        <i class="fa fa-money" aria-hidden="true"></i> <asp:Literal runat="server" ID="cartCurrency" Text="0"></asp:Literal> <span id="priceitemlist" class="value-item"><asp:Literal runat="server" ID="cartPrice" Text="0"></asp:Literal></span>
                                    </div>
                                    <div class="view-cart">
                                        <a href="N_cart.aspx">View Cart</a>
                                    </div>
                                    <div class="checkout">
                                        <a href="N_cart.aspx">Check Out</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>

        <div class="m-b-20"></div>
                
                    <div class="row">
                        <div class="col-xs12">
                            <h2>CreditCard Purchase History</h2>
                            <div class="row">                                
                                <div runat="server" class="table-responsive">

                            <asp:GridView ID="GridView1" CssClass="table-fill-cart" runat="server" AllowPaging="True"  AllowSorting="True" 
                                                                        AutoGenerateColumns="False" ondatabound="GridView1_DataBound" onpageindexchanging="GridView1_PageIndexChanging" 
                                                                        OnRowCreated="GridView1_RowCreated" onrowdatabound="GridView1_RowDataBound" onsorting="GridView1_Sorting" 
                                                                        PageSize="50" ShowFooter="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="1" 
                                                                        EnableModelValidation="True" GridLines="None" BorderWidth="1px">

                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sno">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1 + "."%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="TransctionID/Date" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTranID" runat="server" Text='<% # Bind("ItemNumber")%>'></asp:Label><br />
                                                                                    <asp:Label ID="lblPDate" runat="server" Text='<% # Bind("TacCreated")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="25px" />
                                                                            </asp:TemplateField>
                                                                           <%-- <asp:TemplateField HeaderText="Buyer Details" SortExpression="TACuid">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblBName" runat="server" Text='<% # Bind("username")%>'></asp:Label><br />
                                                                                    <asp:Label ID="lblBMobile" runat="server" Text='<% # Bind("mobileno")%>'></asp:Label><br />
                                                                                    <asp:Label ID="lblBEmail" runat="server" Text='<% # Bind("buyeremail")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>--%>
                                                                            
                                                                             <asp:TemplateField HeaderText="Purchased Items" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPItems" runat="server" Text='<% # Bind("itemname")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>  
                                                                            <asp:TemplateField HeaderText="Amount" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCurrency" runat="server" Text='<% # Bind("currencycode")%>'></asp:Label>&nbsp;
                                                                                    <asp:Label ID="lblAmount" runat="server" Text='<% # Bind("Amount")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>                                                                              
                                                                            
                                                                            <asp:TemplateField HeaderText="Purchase Details" >
                                                                              <ItemTemplate>
                                                                                    <asp:Label ID="lblPurchaseDetails" runat="server" Text='Testing'/>                                 
                                                                                  <asp:HiddenField ID="hdTXid" value='<%# Eval("PytTxID")  %>' runat="server" />                                 
                                                                                  <asp:HiddenField ID="hdPytStatus" value='<%# Eval("PytStatus")  %>' runat="server" />
                                                                                  <asp:HiddenField ID="hdPytGrossAmt" value='<%# Eval("PytAmt")  %>' runat="server" />                                  
                                                                                  <asp:HiddenField ID="hdPytCurrencyCode" value='<%# Eval("PytCurrency")  %>' runat="server" />
                                                                                  <asp:HiddenField ID="hdPytCustomMsg" value='<%# Eval("PytCustomMsg")  %>' runat="server" />
                                                                              </ItemTemplate>
                                                                             </asp:TemplateField>
                                                                            <%--<asp:TemplateField HeaderText="Book Password" >
                                                                              <ItemTemplate>
                                                                                   <asp:Label ID="lblBookPassword" CssClass="fontBlue12" runat="server" Text='<%# Bind("bookpassword")  %>'></asp:Label>
                                                                              </ItemTemplate>
                                                                              <ItemStyle Width="100px" HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                                                                             </asp:TemplateField>--%>

                                                                            <asp:TemplateField HeaderText="Book Password/Download Link" >
                                                                              <ItemTemplate>
                                                                                  <asp:Label ID="lblBookPassword" CssClass="fontBlue12" runat="server" Text='<%# Bind("bookpassword")  %>'></asp:Label><br /><br />
                                                                                  <%--<asp:HyperLink ID="hypBookLink" runat="server" NavigateUrl='<%# Bind("booklink") %>' Target="_blank">--%>
                                                                                   <asp:Label ID="lblDownload" CssClass="fontBlue12" runat="server" Text='<%# Bind("booklink")  %>'></asp:Label>
                                                                                      <%--</asp:HyperLink>--%>
                                                                              </ItemTemplate>
                                                                              <ItemStyle Width="100px" HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                                                                             </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Re-Send Email" HeaderStyle-HorizontalAlign="Center">    
                                                                            <ItemTemplate>
                                                                            <asp:TextBox ID="txtBuyerEmail" runat="server" Text='<%# Eval("buyeremail")  %>' Visible="false"/><br />
                                                                            <asp:LinkButton ID="LinkSendEmail" runat="server" CssClass="links_FuncLinks" Text='<%# Eval("remail")  %>' CommandArgument='<%# Eval("ItemNumber")%>' OnCommand="OnCommand_ImageSendEmailNew" ToolTip='<%# "Send Email to : " + Eval("buyeremail")%>' />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px"/>
                                                                            </asp:TemplateField>
                                                                            <%--<asp:TemplateField HeaderText="Transaction Date" SortExpression="TACuid">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPDate" runat="server" Text='<% # Bind("TacCreated")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>--%>
                                                                            <asp:TemplateField HeaderText="Purchase Status" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPytStatus" runat="server" Text='<% # Bind("pytStatus")%>'></asp:Label>
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
                            </div>
                        </div>
                    </div>
                    
                   
               
    </div>
    

   

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>