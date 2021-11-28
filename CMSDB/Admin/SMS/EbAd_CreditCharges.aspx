<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_CreditCharges.aspx.cs" Inherits="Admin_SMS_EbAd_CreditCharges" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SMSSystem ID="EBLeftMenu_SMSSystem1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
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
                            &nbsp; SMS System : Credit Charges Listings</td>
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
                            
                            <asp:Label ID="lblNote1" runat="server" CssClass="Section_headtext2" 
                                
                                Text="This table will show respective SMS Credit Charges with additional charges if there is Base Charge in the countries listed below.&lt;br/&gt;Country not listed below will have no charges" />
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <div id="dvWelcomeHeader" style="overflow:hidden; width:820px; min-height: 150px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal3" Text="Normal Credit Charges Table" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="ebFormLabel1" align="left"><asp:Label ID="Label5" runat="server" Text="SMS Credit Charges = Base Charges + Normal Charges"/></td>
                            </tr>

                             <tr>
                                <td  class="ebFormText1" align="left">
                                    <asp:Label ID="LabelNoteSMS1" runat="server" 
                                        Text="Eg : Australia SMS Charges for Normal SMS is 1+1 = 2 SMS Credits" 
                                        CssClass="" />
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
                        </div>
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <asp:GridView ID="GridViewCreditCharges" runat="server" AllowSorting="false" 
            AllowPaging="false" AutoGenerateColumns="False" PageSize="50" CssClass="mGrid"  HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" FooterStyle-CssClass="rowfooter">
                                <Columns>
                                    <asp:TemplateField HeaderText="No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 + "."%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Credit Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCdtType" runat="server" Text='<% # Bind("Credit_Type")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCdtPrice" runat="server" Text='<% # Bind("UnitPrice")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Credit Desc">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCdtDesc" runat="server" Text='<% # Bind("Credit_Desc")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                         </asp:GridView>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="3">
                                        <div class="SummaryBoxheadGreen">
                                            <div class="sideBoxheadText">
                                                <asp:Literal ID="Literal4" runat="server" Text="List of Countries with Base Charge"></asp:Literal>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="vertical-align:baseline;">
                                    <td align="center" colspan="3">
                                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" 
                                            width="90%">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="ebFormLabel1">
                                                    <asp:Label ID="Label6" runat="server" 
                                                        Text="SMS Credit Charges = Base Charges + Normal Charges" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <asp:GridView ID="GridViewCreditBaseCharges" runat="server" AllowSorting="false" 
            AllowPaging="false" AutoGenerateColumns="False" PageSize="50" CssClass="mGrid"  HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" FooterStyle-CssClass="rowfooter">
                                <Columns>
                                    <asp:TemplateField HeaderText="No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 + "."%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Country">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountry" runat="server" Text='<% # Bind("Country")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Mobile Prefix">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMPrefix" runat="server" Text='<% # Bind("MobilePrefix")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Charges">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCharges" runat="server" Text='<% # Bind("Charges")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>                                
                            </asp:GridView>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            &nbsp;</td>
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

