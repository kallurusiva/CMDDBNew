<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_AnchorDomainsListNEW.aspx.cs" Inherits="Ad_AnchorDomainsListNEW" %>

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
                        
                        
                         <%--   <table cellpadding="0" cellspacing="0" style="width: 100%;" class="stdtableBorder_Only">
                                                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>--%>
                                        
         <asp:Repeater ID="rpParent_Industry" runat="server"  onitemdatabound="rpParent_Industry_ItemDataBound">
        <HeaderTemplate>
           <%-- <tr>
            <td>&nbsp; </td>
            </tr>--%>
             <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                                
               <tr>
                <td>
                    &nbsp;</td>
                <td>
                </tr>
        </HeaderTemplate>
        
        <ItemTemplate>

            <tr>
            <td>
            &nbsp; 
            </td>
            </tr>
            <tr>
              <td  class="cssfaqAnswer2" nowrap="nowrap"> 
              Industry : 
              <font class="Section_headtext">
               <asp:Literal ID="ltrCategoryName" Text='<%#Eval("CategoryName")%>' runat="server"></asp:Literal>
               </font>
               <asp:HiddenField ID="hdCategoryID" Value='<%# Bind("CategoryID")%>' runat="server" />
              </td>
            </tr>
            <tr>
            <td>
                <%-- Child Repeater goes here --%>
                
                <asp:Repeater ID="rpChild_Anchordomains" runat="server"   onitemdatabound="rpChild_Anchordomains_ItemDataBound">
                <HeaderTemplate>
                 <table class="mGrid" cellspacing="0" width="100%" rules="all"  id="ctl00_ContentBody_gridAnchorDomains">
                 <tr class="rowheader">
        			<th width="50">Sl No</th>
        			<th width="120">AnchorDomain</th>
        			<th width="150">SubDomain</th>
        			<th width="300">Your SubDomain URL Link</th>
        			<th width="300">Sample Website URL</th>
    		     </tr>
    		    
                </HeaderTemplate>
                <ItemTemplate>
                
            <tr>

			    <td width="50">
                 <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.ItemIndex + 1  %>'/>
                  <asp:Literal ID="hdtid" Visible="false" Text='<%#Bind("tid")%>' runat="server"></asp:Literal>
                  <asp:HiddenField ID="hdAnchorDomain" Value='<%# Bind("AnchorDomain")%>' runat="server" />
                </td>
                <td align="left" width="150">
                    <asp:Label ID="lblAnchorDomain" runat="server" Text='<%# Bind("AnchorDomain")  %>'/>
                 </td>
              
                 <td align="left" width="120">
                      <asp:Literal ID="ltrSubDomain" runat="server" Text=''></asp:Literal>
                  </td>
                   <td align="left" width="300">
                    <asp:Literal ID="ltrSubDomainURLlink" runat="server" Text=''></asp:Literal>
                   </td>
                   <td align="left" width="300">
                     <asp:Literal ID="ltrSampleWebsite" runat="server" Text='<%# Bind("SampleURL") %>'></asp:Literal>  
                    </td>
		</tr>
                </ItemTemplate>
                <FooterTemplate>
                 </table>
                </FooterTemplate>
                </asp:Repeater>
                
                
                
                
            
            </td>
            </tr>
            
          
        
        </ItemTemplate>
        <SeparatorTemplate>
            <tr>
            <td class="cssfaqSeparator" height="0px"></td>
            </tr>
        
        </SeparatorTemplate>
        
        <FooterTemplate>
            <%--<tr>
            <td>&nbsp; </td>
            <td>&nbsp; </td>--%>
            
            </table>
        </FooterTemplate>
        </asp:Repeater>
                            
                            
                                        
                                        
                                        
<%--         </td>
          </tr>
                                
       </table>--%>
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

