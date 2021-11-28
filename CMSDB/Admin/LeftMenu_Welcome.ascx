<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu_Welcome.ascx.cs" Inherits="Admin_LeftMenu_Welcome" %>

<%--<link href="../App_Themes/Default/DIY1_styles.css" rel="stylesheet" type="text/css" />--%>


<link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" type="text/css" />
<div id="leftDiv" runat="server">

<table border="0" cellpadding="0" cellspacing="0" width="200px">
              
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="80%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        
                        <td width="96%" align="left" class="subHeaderFontGrad">
                            &nbsp; My Details 
                            </td>
                        
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
           <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="90%" runat="server">
            <tr>
            <td width="2%">&nbsp;</td>
            <td width="96%">&nbsp;</td>
            <td width="2%">&nbsp;</td>
            </tr> 
            <tr>
            <td width="2%">&nbsp;</td>
            <td width="96%" class="subHeaderFontGrad">
                <asp:Literal ID="LtrWelcomePageTitle" runat="server" Text=""></asp:Literal> </td>
            <td width="2%">&nbsp;</td>
            </tr> 
            <tr>
                <td>&nbsp;</td>
             <td>
                <table cellpadding="1" cellspacing="1" class="stdtable_BdrBlue_BkgGrey" width="100%">
      
                    <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td class="FormLabel" align="left">
                            <asp:Literal ID="ltrUser" runat="server" 
                                Text="<%$ Resources:LangResources, User %>"></asp:Literal>
&nbsp;<asp:Literal ID="ltrId" runat="server" Text="<%$ Resources:LangResources, id %>"></asp:Literal>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblUserId" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    
                    <tr>
                        <td width="1%">
                            &nbsp;</td>
                        <td width="32%" valign="top" align="left">
                           &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>

                    
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td valign="top" align="left">
                            
                            <div id="dvProfile" style="overflow:hidden; min-width:300px;"  class="SummaryBoxCssWidth">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        <td colspan="3">
                        <div class="SummaryBoxheadGreen">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="ltrWEB" Text="Profile" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="40%" class="RowContent">&nbsp;</td>
                    <td class="RowContent"> &nbsp; </td>
                    <td width="60%" align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" class="RowContent">
                             <asp:Image ID="ImgContact" BorderWidth="1px" BorderColor="#ACA9A9" Width="200" Height="200" runat="server" /> 
                         </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td class="RowContent">&nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td align="left" class="RowHead">Login ID</td>
                    <td class="RowContent"> : </td>
                    <td align="left" class="RowContent">
                            <asp:Label ID="lblLoginID" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td class="RowHead" align="left">Created Date</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblCreatedDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                   
                    
                 <%--   <tr>
                    <td class="RowHead" align="left">User Type</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblUserType" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    
                    
                    <tr>
                    <td class="RowHead" align="left">Mobile Number</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="RowHead" align="left">Domains</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <div id="dvOwnDomain" runat="server">
                            <span class="font_12Normal">OwnDomain :&nbsp;&nbsp;&nbsp; </span>
                            <br class="style2" />
                            <asp:Label ID="lblOwnDomainName" runat="server"></asp:Label>
                            <br />
                            <span class="font_12Normal">Domain Expiry Date :&nbsp;&nbsp;&nbsp; </span>
                            <br class="style2" />
                            <asp:Label ID="lblOwnDomainExpiryDate" CssClass="links_DomainName" runat="server"></asp:Label>
                            <br />
                            <br />
                            </div>
                            
                            <span class="font_12Normal">SubDomains:-</span><br />
                            <asp:Label ID="lblSubDomainName1" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblSubDomainName2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="RowHead" align="left">Activated Pin No</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblActivatedPinNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td class="RowHead" align="left">&nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td class="RowContent" align="left">
                        &nbsp;</td>
                    </tr>
                    
                   
                    
                      </table>
         
        </div>
                            
                            
                           </td>
                        <td >
                            &nbsp;</td>
                    </tr>

                    

                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                 
                    
                </table>
             </td>
             <td>&nbsp;</td>
             </tr>
            <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            </tr>
             </table>
             
             
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            </tr>
        </table>
                
        </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

</div>



<%--

<div id='leftmenu'>
<ul>




<li><span class="header"><img src="../Images/WebPortal/Event.png" /><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LangResources, ManageEvents %>"></asp:Literal> </span></li>
<li> <asp:HyperLink ID="HypMyEventsListing" CssClass="LiCon listing" runat="server" Text="My Events" NavigateUrl="EventsListing.aspx?RtType=USER"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypEventsAdd" CssClass="LiCon add" runat="server" Text="About Us" NavigateUrl="EventsCreate.aspx"></asp:HyperLink> </li>


<li> <asp:HyperLink ID="HypAdminEvents" CssClass="LiCon admin" runat="server" Text="Admin Events" NavigateUrl="EventsListing.aspx?RtType=ADMIN"></asp:HyperLink> </li>
<li> <asp:HyperLink ID="HypShowALL" CssClass="LiCon all" runat="server" Text="Show ALL" NavigateUrl="EventsListing.aspx?RtType=ALL"></asp:HyperLink> </li>--%>

<%--<li>
   <span class="subheader">  
    <asp:Literal ID="ltrWelcomePage" runat="server"></asp:Literal>
    </span>
</li>


</ul>
</div>--%>