<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_Welcome_ORG.aspx.cs" Inherits="Admin_Ad_Welcome_ORG" %>

<%@ Register src="../SuperAdmin/MyBarChart.ascx" tagname="MyBarChart" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            text-decoration: underline;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

<script language="javascript" type="text/javascript">

    function fnOpenFPwindow(url, width, height) {
        //var width = "400";
        //var height = "300";

        var parameters = "width=" + width + ",height=" + height;
        //alert(parameters);
        parameters = parameters + "resizable=no,titlebar=no,locationbar=no,dependent=yes,left=150,top=150";
        window.open(url, "winFP", parameters);


    }
    
</script>
    <form id="form1" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
              
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="2%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="96%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            </td>
                        <td width="2%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
           <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtable_BdrBlue_BkgGrey" width="98%" runat="server">
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
                        <td width="30%" valign="top" align="left">
                            
                            &nbsp;</td>
                        <td width="1%">
                            &nbsp;</td>
                        <td width="40%" valign="top">
                            &nbsp;</td>
                        <td width="1%" valign="top">
                            &nbsp;</td>
                        <td width="20%" valign="top">
                            &nbsp;</td>
                    </tr>

                    
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td valign="top" align="left">
                            
                            <div id="dvProfile"  style="width:350px;" class="SummaryBoxCssWidth">
        
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
                    
                   
                    
                    <tr>
                    <td class="RowHead" align="left">User Type</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblUserType" runat="server"></asp:Label>
                        </td>
                    </tr>
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
                        <td  valign="top" align="left">
                            
                            <div id="dvStatistics" style="width:500px;"  class="SummaryBoxCssWidth">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal3" Text="Log Statistics" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="35%" class="RowContent">&nbsp;</td>
                    <td class="RowContent"> &nbsp; </td>
                    <td width="65%" align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td class="RowHead" align="left">Last Logged in</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblLastLogin" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td  class="RowHead"> &nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td  align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    
                    
                    <tr>
                    <td class="RowHead" align="left">Total visits till date</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblTotalVisits" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="3" class="RowContent" align="center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                    <%--<td class="RowHead" align="left">&nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>--%>
                    <td colspan="3" class="RowContent" align="center">
                            <uc1:MyBarChart ID="MyBarChart_Monthly" UserWidth="400" runat="server" />
                        </td>
                    </tr>
                    <tr>
                    <td class="RowHead" align="left">&nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td class="RowContent" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                    <td class="RowHead" align="left">&nbsp;<asp:Literal ID="ltrThisMonthVisits" Text="" runat="server"></asp:Literal></td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblThisMonthVisits" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                    <td colspan="3" align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    
                    
                    <tr>
                    <%--<td class="RowHead"> &nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>--%>
                    <td colspan="3" align="center" class="RowContent">
                        <uc1:MyBarChart ID="MyBarChart_daily" UserWidth="400" runat="server" />
                        </td>
                    </tr>
                    
                    
                    
                    <tr style="vertical-align:baseline;">
                    <td class="RowHead"> &nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    
                    
<%--                    <tr style="vertical-align:baseline;">
                    <td class="RowHead"> &nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td align="center" class="RowContent">
                            <asp:HyperLink ID="HypDomains" CssClass="links_Navigate" NavigateUrl="~/SuperAdmin/SA_DomainRequests.aspx" runat="server"> ..DomainRequests</asp:HyperLink>
                            </td>
                    </tr>--%>
                    
                    
                    
                      </table>
         
        </div>
                            
                            
                            </td>
                        <td  valign="top" align="left">
                            
                            &nbsp;</td>
                        <td  valign="top" align="left">
                            
                             <div id="dvSubDomains"  style="width:250px;" class="SummaryBoxCssWidth">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        <td colspan="3">
                        <div class="SummaryBoxheadGreen">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal1" Text="Your SubDomains" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="1%">&nbsp;</td>
                    <td width="99%" align="center">
                        &nbsp;</td>
                        <td > &nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td > &nbsp;</td>
                    <td align="left">
                       <asp:Repeater ID="rpFaqList" runat="server" 
                                            onitemdatabound="rpFaqList_ItemDataBound">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="cssfaq">
            <tr>
            <td>
            <%--<div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="LtrHeader" Text="" runat="server">SubDomains List</asp:Literal>
                </div>
            </div>   --%> 
            
            </td>
            </tr>
            
           <%-- <tr>
            <td>&nbsp; </td>
            </tr>--%>
         
        </HeaderTemplate>
        
        <ItemTemplate>

       <%--     <tr>
            <td>
            
            </td>
            </tr>--%>
            <tr id="trDomainRow" runat="server" visible="true">
            <td  class="cssfaqAnswer" nowrap="nowrap"> 
             <asp:Literal ID="ltrDomainName" Text='<%#Eval("AnchorDomain")%>' runat="server"></asp:Literal>
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
            <td>&nbsp; 
                <asp:HyperLink ID="HypLinkMore" CssClass="links_FuncLinks" NavigateUrl="~/Admin/Ad_DomainsListSubs.aspx" runat="server">more ...</asp:HyperLink></td>
            </tr>
            </table>
        </FooterTemplate>
        </asp:Repeater>
        
                    </td>
                    <td > &nbsp;</td>
                    </tr>
                    
                                       
                    
                      </table>
         
        </div></td>
                    </tr>

                    
<%--                    <tr style="height:30px;">
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <font class="FontSubHeader">Login Details</font></td>
                        <td >
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="FormLabel" align="left">
                            <asp:Literal ID="ltrLastLogin" runat="server" 
                                Text="Last Login"></asp:Literal></td>
                        <td >
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="FormLabel" align="left">
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp; <a href="#" onclick='javascript: return fnOpenFPwindow("Ad_PopUpViewWebStats.aspx?Type=0",550,450);' target="_blank" class="links_FuncLinks"> [Click here to View the Chart]</a></td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="FormLabel" align="left">
                            Total visits till date</td>
                        <td >
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp; <a href="#" onclick='javascript: return fnOpenFPwindow("Ad_PopUpViewWebStats.aspx?Type=1",550,450);' target="_blank" class="links_FuncLinks"> [Click here to View the Chart]</a>
                        </td>
                    </tr>--%>
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
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
    
    
    
    </form>
</asp:Content>

