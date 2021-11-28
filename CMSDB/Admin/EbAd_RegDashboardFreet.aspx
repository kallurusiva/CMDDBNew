<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master"  AutoEventWireup="true" CodeFile="EbAd_RegDashboardFreet.aspx.cs" Inherits="Admin_EbAd_RegDashboardFreet" %>

<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc3" %>

<%@ Register src="EBLeftMenu_subdomainSTEPS.ascx" tagname="EBLeftMenu_subdomainSTEPS" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_subdomainSTEPS ID="EBLeftMenu_subdomainTEPS1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <style type="text/css">
 .styleRow
 { color: #3C3D3D; font: bold 12px "Trebuchet MS", Verdana, Arial;
    background-color: #78ADD0; height: 24px; padding: 5px 5px 2px 25px; 
    background: -webkit-gradient(linear, left top, left bottom, from(#78ADD0), to(#CDEBFF)); /* for webkit browsers */
    background: -moz-linear-gradient(top,  #78ADD0,  #CDEBFF); /* for firefox 3.6+ */
    filter:progid:DXImageTransform.Microsoft.Gradient(StartColorStr=#78ADD0 ,EndColorStr=#CDEBFF,GradientType=0);
 }

                

    </style>

 <form id="form2" runat="server">

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
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            Registration Dashboard</td>
                       
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
           
             
            </td>
        </tr>
        <tr>
            <td align="center">
                        
                            <div id="dvWelcomeHeader" style="overflow:hidden; width:80%; min-height: 150px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td>
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                        Registrations </div>
                                </div>
                                </td>
                    </tr>

                        <tr>
                            <td class="FontNote" align="left">

                                <strong>NOTE</strong> :  Please complete the 5-step registrations in order to activate your eBook Account.  
                                <br />
                                Associate Vendors can skip Step 5 as Vendor Code registration is applicable to Professional Vendors only
                            </td>

                        </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="100%" style="padding: 10px;" >
                            <tr>
                                <td width="150px" >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>

                            <tr>
                                <td width="250px" class="ebFormLabel1">STEP 1 : <span class="fontStepB">SubDomain</span></td>
                                <td class="ebFormText1"> 
                                    <asp:Label ID="lblStepDomain" CssClass="fontRegPending" Text="" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr><td style="height: 10px;" colspan="2"></td></tr>
                             <tr>
                                <td  class="ebFormLabel1">STEP 2 : <span class="fontStepB">Store ID</span></td>
                                <td class="ebFormText1">
                                    <asp:Label ID="lblStepStoreID" CssClass="fontRegPending" Text="" runat="server"></asp:Label>
                                 </td>
                            </tr>
                        <%-- <tr><td style="height: 10px;" colspan="2"></td></tr>
                             <tr>
                                <td class="ebFormLabel1">STEP 3 : <span class="fontStepB">Profile</span></td>
                                <td  class="ebFormText1">     
                                    <asp:Label ID="lblStepProfile" CssClass="fontRegPending" Text="Pending" runat="server"></asp:Label>
                                 </td>
                            </tr>
                            <tr><td style="height: 10px;" colspan="2"></td></tr>
                        
                             <tr id="trStep4" runat="server">
                                <td class="ebFormLabel1">STEP 4 : <span class="fontStepB">Physical Book </span></td>
                                <td  class="ebFormText1">     
                                    <asp:Label ID="lblStepPhysicalBook" CssClass="fontRegPending" Text="Pending" runat="server"></asp:Label>
                                 </td>
                            </tr>
                         <tr><td style="height: 10px;" colspan="2"></td></tr>
                             <tr id="trStep5" runat="server">
                                <td class="ebFormLabel1">STEP 4 : <span class="fontStepB">Vendor Code</span></td>
                                <td  class="ebFormText1">     
                                    <asp:Label ID="lblStepVendorCode" CssClass="fontRegPending" Text="Pending" runat="server"></asp:Label>
                                 </td>
                            </tr>--%>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
        </div>
                            </td>
            </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td style="color: White;">
                &nbsp;
                <%--<asp:HyperLink ID="HyperLink23" NavigateUrl="~/Admin/MyHomePageSettings_Async.aspx" runat="server">..</asp:HyperLink>--%>
                <asp:Label ID="lblSessionValues" runat="server" Text="tests"></asp:Label>
            </td>
        </tr>
    </table>

    </form>
</asp:Content>

