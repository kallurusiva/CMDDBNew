<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_DomainSubInfo.aspx.cs" Inherits="Ad_DomainSubInfo" %>

<%@ Register src="SideMenu_MyAccount.ascx" tagname="SideMenu_MyAccount" tagprefix="uc1" %>

<%@ Register src="SideMenu_Domains.ascx" tagname="SideMenu_Domains" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SideMenu_Domains ID="SideMenu_Domains1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

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
                         <font class="loginfont12">SubDomain</font></td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                                        
                            &nbsp;</td>
          </tr>
                                
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                                        
                            <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
              <tr>
                  
                  <td class="tblFormLabel1" width="25%" >&nbsp;</td>
                  <td class="tblFormText1" width="75%" >
                      &nbsp;</td>
                
              </tr>
              <tr>
                  
                  <td class="tblFormLabel1" width="20%" align="right" >Your Current SubDomain : </td>
                  <td class="tblFormText1" width="80%" >
                      <asp:Label ID="lblCurrentSubdomain" CssClass="font_14SuccessBold" runat="server" Text="Label"></asp:Label>
                  </td>
                
              </tr>
               <tr>
                 
                  <td class="tblFormLabel1" align="right">Your Complete Subdomain URL</td>
                  <td  class="tblFormText1">
                      <asp:Label ID="lblCompleteSubDomainURL" CssClass="font_14SuccessBold" runat="server" Text="Label"></asp:Label>
                   </td>
                 
              </tr>
               <tr> 
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td  class="tblFormText1">
                            &nbsp;</td>
                
              </tr>
               <tr> 
                  <td class="tblFormLabel1" align="right">Your Current Anchor Domain</td>
                  <td  class="tblFormText1">
                            <asp:DropDownList ID="ddlAnchorDomains" CssClass="stdDropDown" Width="250px" runat="server">
                            </asp:DropDownList>
                        &nbsp;
                      </td>
                
              </tr>
               <tr>
                 
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td  class="tblFormText1">
                      <asp:Button ID="btnSelection" runat="server" Text="Change and Save Selection" 
                          onclick="btnSubmit_Click" ValidationGroup="VgCheck" />
                   </td>
                 
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLabel1" valign="top">
                      &nbsp;</td>
                  <td  class="tblFormText1" valign="top" >
                            &nbsp;</td>
               
              </tr>
              
               </table></td>
          </tr>
                                
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left" class="FontNote">
                                        
                            <b>Note</b> :&nbsp; Anchor Domain is your preferred Complete SubDomain URL which you 
                            can use to show to your customers or public. </td>
          </tr>
                                
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                                        
                            &nbsp;</td>
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

