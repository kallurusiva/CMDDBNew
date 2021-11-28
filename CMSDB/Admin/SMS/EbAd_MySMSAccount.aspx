<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_MySMSAccount.aspx.cs" Inherits="Admin_SMS_EbAd_MySMSAccount" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            text-align: left;
        }
    </style>
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
                            &nbsp; SMS System : My Account</td>
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
                                    <asp:Literal ID="Literal3" Text="Welcome Back !!" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td width="150px" >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>

                            <%--<tr>
                                <td width="150px" class="ebFormLabel1">Your Keyword</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblBusinessCode" CssClass="FontDbCount" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                             <tr>
                                <td  class="ebFormLabel1">Your Login ID</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="LabelLoginIDVal" CssClass="FontDbCount" runat="server" Text=""/>
                                 </td>
                            </tr>--%>
                        
                             <%--<tr>
                                <td class="ebFormLabel1">Destination Code</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblLongCode" CssClass="FontDbCount" runat="server" Text="" />
                                 </td>
                            </tr>--%>
                            <%--<tr>
                                <td class="ebFormLabel1">Time Zone Settings</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblTimeZone" CssClass="FontDbCount" runat="server" Text="" />
                                 </td>
                            </tr>--%>
                             <tr>
                                <td class="ebFormLabel1">Register Date</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblRegisterDate" runat="server" CssClass="FontDbCount" Text=""/>
                                 </td>
                            </tr>
                        
                             <%--<tr>
                                <td class="ebFormLabel1">Subscription Date</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblSubscriptionDate" runat="server" CssClass="FontDbCount" Text=""/>
                                 </td>
                            </tr>--%>
                        
                             <tr>
                                <td class="ebFormLabel1">Total SMS Credit</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblTotalCreditSMS" runat="server" CssClass="FontDbCount" Text=""/>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">SMS Credit Used</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblTotalSMSCdtUsed" runat="server" CssClass="FontDbCount" Text=""/>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Balance Credit</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblSMSCreditUsed" runat="server" CssClass="FontDbCount" Text=""/>
                                 </td>
                            </tr>
                        
                             <%--<tr>
                                <td class="ebFormLabel1">Package</td>
                                <td class="style2">&nbsp; : &nbsp;<asp:Label ID="lblAccountType" runat="server" CssClass="FontDbCount" Text="EBOOK"/>
                                 </td>
                            </tr>--%>
                        
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
                        
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                     <div id="dvAdminSummary" style="overflow:hidden; width:100%"  class="ebSummaryBox">
        
                    <%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal1" Text="Latest News" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="96%" >

                             <tr>
                                <td><asp:GridView ID="GridViewNews" runat="server" AllowSorting="true" AutoGenerateColumns="False" 
                                CssClass="mGrid" HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="5" >
                <Columns>
                <asp:TemplateField HeaderText="No">
                   <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
                   <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Title" HeaderStyle-HorizontalAlign="Left">        
                <ItemTemplate>
                    <asp:Label ID="lblNews" runat="server" Text='<% # Bind("Title")%>' CssClass="GridView1TitleRow101"/><br />                     
                    <asp:Label ID="lblNewsFull" runat="server" Text='<% # Bind("NewsFull")%>' /><br />
                    <asp:Label ID="lblPost" runat="server" Text="posted on " /><asp:Label ID="lblNewsDate" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "NewsDate", "{0:MMMM d, yyyy h:mm tt}")%>' CssClass="GridView1HyperLink"/>
                </ItemTemplate>            
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>                
                </Columns>
               </asp:GridView></td>
                                
                            </tr>


                            </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>--%>
         
        </div>


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

