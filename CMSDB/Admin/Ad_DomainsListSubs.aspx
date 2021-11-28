<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_DomainsListSubs.aspx.cs" Inherits="Ad_DomainsListSubs" %>

<%@ Register src="SideMenu_MyAccount.ascx" tagname="SideMenu_MyAccount" tagprefix="uc1" %>

<%@ Register src="SideMenu_Domains.ascx" tagname="SideMenu_Domains" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SideMenu_Domains ID="SideMenu_Domains1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


<script language="javascript" type="text/javascript">

    function fnCheckDomain() {


        var tmpURL = "http://www.namecheap.com/domain-name-search.asp";
        window.open(tmpURL, "winDomainCheck", "width=600px,height=550px,resizable=yes, scrollbars=yes,dependent=yes,left=150,top=150");
    
    
    }

</script>
    <form id="form1" runat="server">
    <input type="hidden" value="ipadr" id="hdIpAddress" name="hdIpAddress" />
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
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="1" class="stdtableBorder_Main" width="98%">
                    <tr style="height:30px;">
                        <td width="1%">&nbsp;</td>
                        <td width="98%" align="left" class="FontNote">
                        <font class="loginfont12">NOTE :</font> <font class="">All subdomains are pointing at the same website. Select any subdomain to reflect your business entity.</font></td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                        
                        
                            <%--<table cellpadding="0" cellspacing="2" style="width: 100%;" class="stdtableBorder_Only">
                                                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        
                                        <asp:Repeater ID="rpFaqList" runat="server" 
                                            onitemdatabound="rpFaqList_ItemDataBound">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="cssfaq">
            <tr>
            <td>
            <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="LtrHeader" Text="" runat="server">SubDomains List</asp:Literal>
                </div>
            </div>    
            
            </td>
            </tr>
            
            <tr>
            <td>&nbsp; </td>
            </tr>
         
        </HeaderTemplate>
        
        <ItemTemplate>

            <tr>
            <td>
            
            </td>
            </tr>
            <tr>
            <td  class="cssfaqAnswer" nowrap="nowrap"> 
            <asp:Literal ID="ltrDomainName" Text='<%#Eval("Domain")%>' runat="server"></asp:Literal>
             </td>
             
            </tr>
          
        
        </ItemTemplate>
        <SeparatorTemplate>
            <tr>
            <td class="cssfaqSeparator" height="2px"></td>
            </tr>
        
        </SeparatorTemplate>
        
        <FooterTemplate>
            <tr>
            <td>&nbsp; </td>
            <td>&nbsp; </td>
            </tr>
            </table>
        </FooterTemplate>
        </asp:Repeater>--%>
                            
                            
                            <asp:GridView ID="gridAnchorDomains" runat="server" AutoGenerateColumns="False" DataKeyNames="tid"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="20" onpageindexchanging="gridAnchorDomains_PageIndexChanging"
                               OnSorting ="gridAnchorDomains_Sorting" 
                               AllowSorting="true" OnDataBound="gridAnchorDomains_DataBound" 
                                onrowdatabound="gridAnchorDomains_RowDataBound" onprerender="gridAnchorDomains_PreRender"
                             >
                            <Columns>

                            <asp:TemplateField HeaderText="Sl No">
                              <ItemTemplate>
                               <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                  <asp:Literal ID="hdtid" Visible="false" Text='<%#Bind("tid")%>' runat="server"></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            
                            
                            <asp:TemplateField HeaderText="Industry">
                              <ItemTemplate>
                               <asp:Literal ID="ltrIndustry" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                            
                            <asp:TemplateField HeaderText="AnchorDomain" SortExpression="AnchorDomain">
                              <ItemTemplate>
                               <asp:Label ID="lblAnchorDomain" runat="server" Text='<%# Bind("AnchorDomain")  %>'/>
                               <asp:HiddenField ID="hdAnchorDomain" Value='<%# Bind("AnchorDomain")%>' runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                             
                             
                              <asp:TemplateField HeaderText="SubDomain">
                              <ItemTemplate>
                               <asp:Literal ID="ltrSubDomain" runat="server" Text=''></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="Your SubDomain URL Link">
                              <ItemTemplate>
                               <asp:Literal ID="ltrSubDomainURLlink" runat="server" Text=''></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="200px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                             
                             <asp:TemplateField HeaderText="Sample Website URL">
                              <ItemTemplate>
                               <asp:Literal ID="ltrSampleWebsite" runat="server" Text='<%# Bind("SampleURL") %>'></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="Left"  />
                             </asp:TemplateField>
                             
                             
                             
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
                                         
                                       </td>
                                          
                                 </tr>
                                    </table>
                                </PagerTemplate>
                                
                             <HeaderStyle CssClass="rowheader" />
                                <AlternatingRowStyle CssClass="rowalt" />
                            </asp:GridView>            
                                        
                                        
                                        </td>
                                </tr>
                                
                                </table>
                        </td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            </td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    </form>
</asp:Content>

