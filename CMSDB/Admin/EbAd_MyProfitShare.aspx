<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_MyProfitShare.aspx.cs" Inherits="Admin_EbAd_MyProfitShare" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="EBLeftMenu_Profit.ascx" tagname="EBLeftMenu_Profit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.bgwhite { background-color:#fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_Profit ID="EBLeftMenu_Profit1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
         </asp:ToolkitScriptManager>
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
                            <asp:Label ID="LabelMyProfitShare" runat="server" Text="Profit Share" /></td>
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
                        <td width="98%" align="left" class="tblFormLabel">
                            <asp:Label ID="LabelAccountInfo" runat="server"  
                                
                                
                                Text="Profit Sharing History Gross Profit = Success Amount - (Operator Share + Failed Amount)" 
                                />
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr style="height:30px;">
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left" class="FontNote">
                            Kindly Take Note :</td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr style="height:30px;">
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left" class="FontBRowTextBkg">
                            1. Profit Sharing depends on Premium SMS Agreement signed.
                            <br />
                            2. Payment will be issue only if Amount Profit Sharing above RM100. Admin 
                            Charges of RM 15 applies.
                            <br />
                            3. Delivery Report on DN to confirm Success/Fail. Sometimes delay upto 1 month 
                            due to Telco Operator.
                            <br />
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr style="height:30px;">
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left">
                            <asp:HyperLink ID="hypGoback" runat="server" Text="&laquo; Back to Listings" 
                                NavigateUrl="javascript:window.history.back()" 
                                CssClass="links_AnchorDomains2" /></td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                  <asp:GridView ID="GridView2" runat="server" AllowSorting="false" 
            AllowPaging="false" AutoGenerateColumns="False" PageSize="50" 
            ondatabound="GridView2_DataBound" DataKeyNames="" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" FooterStyle-CssClass="rowfooter"
            onrowcreated="GridView2_RowCreated" onrowdatabound="GridView2_RowDataBound" ShowFooter="true">
    <Columns>        
    <asp:TemplateField HeaderText="Sno" HeaderStyle-HorizontalAlign="Left">
    <ItemTemplate><%#Eval("Row") + "."%></ItemTemplate>    
    <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField> 
        <asp:TemplateField HeaderText="">            
            <ItemTemplate>
            <asp:Label ID="lblOperator" runat="server" Text='<%# Eval("Operator") %>' />
            </ItemTemplate>     
            <ItemStyle Width="70px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>            
            <asp:HiddenField ID="hdnMonth" runat="server" Value='<%#Bind("rptMonth1")%>'/>  
            <asp:HiddenField ID="hdnYear" runat="server" Value='<%#Bind("rptYear")%>'/> 
            <asp:Label ID="lblShare" runat="server" Text='<%#Bind("ProfitPercent") %>' />         
            </ItemTemplate>     
            <ItemStyle Width="40px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
         <asp:TemplateField>            
            <ItemTemplate>
                  <asp:Label ID="lblCharge" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top"  />
        </asp:TemplateField>        
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPrice" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top"  />
        </asp:TemplateField>  
        
        <asp:TemplateField HeaderText="Zero-Base">            
            <ItemTemplate>
            <asp:Label ID="lblMTZ" runat="server" Text='<%#Bind("MTZ") %>' /> 
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Success">            
            <ItemTemplate>
            <asp:Label ID="lblMTS" runat="server" Text='<%#Bind("MTS") %>' />            
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
        <asp:TemplateField HeaderText="Fail">            
            <ItemTemplate>
            <asp:Label ID="lblMTF" runat="server" Text='<%#Bind("MTF") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
        <asp:TemplateField HeaderText="Total">            
            <ItemTemplate>
            <asp:Label ID="lblTotal" runat="server" Text='<%#Bind("MTT") %>' />            
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom1" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPriceAmtS" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amtS", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField> 
            <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom2" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblOprtShare" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "OprtShare", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>   
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom3" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPriceAmtF" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amtF", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom4" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblGrossProfit" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GrossProfit", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
            <FooterTemplate>
                <asp:Label runat="server" ID="lblFooterZero" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterSuccess" Text=""></asp:Label>                
                <asp:Label runat="server" ID="lblFooterFailure" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterTotalAll" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterAmount1" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterAmount2" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterAmount3" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterAmount4" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>        
    </Columns> 
    <PagerStyle CssClass="cssPager" />    
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
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

