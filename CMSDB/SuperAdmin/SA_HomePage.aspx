<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_HomePage.aspx.cs" Inherits="SuperAdmin_SA_HomePage" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>


<%@ Register src="SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrHomeSummary" runat="server" 
                                Text=""></asp:Literal></td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="98%" runat="server">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" width="100%" class="stdtableBorder_SideMenu">
                                <tr>
                                    <td width="33%">
                                        &nbsp;</td>
                                    <td width="33%">
                                        &nbsp;</td>
                                         <td width="34%">
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
                                    <td align="center"  valign="top">
                                    
                                    <div id="dvUsers"  class="SummaryBoxCss">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        <td colspan="3">
                        <div class="SummaryBoxheadGreen">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="ltrWEB" Text="Users" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowContent">&nbsp;</td>
                    <td class="RowContent"> &nbsp; </td>
                    <td width="50%" align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowHead">WEB30</td>
                    <td class="RowContent"> : </td>
                    <td width="50%" align="center" class="RowContent">
                        <asp:Label ID="lblWeb30" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td class="RowHead">WEB10</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="center">
                        <asp:Label ID="lblWEB10" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    
                   
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td class="RowHead">&nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td class="RowContent" align="center">
                      <%--  <asp:LinkButton ID="lnkGOTO" Text="" CssClass="links_SideMenu"  runat="server" 
                            PostBackUrl="~/SuperAdmin/SA_AllUsersListing.aspx"></asp:LinkButton>--%>
                        <asp:HyperLink ID="HypUsers" CssClass="links_Navigate" NavigateUrl="~/SuperAdmin/SA_AllUsersListing.aspx" runat="server"> ..UserListing</asp:HyperLink>
                        </td>
                    </tr>
                    
                   
                    
                      </table>
         
        </div>
        
                                   </td>
                                   <td align="center" valign="top">
                                        <div id="dvEmail"  class="SummaryBoxCss">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        <td colspan="3">
                        <div class="SummaryBoxheadGreen">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal1" Text="Visits" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowContent">&nbsp;</td>
                    <td class="RowContent"> &nbsp; </td>
                    <td width="50%" align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowHead"> 
                        <asp:Label ID="lblCurrMonth" runat="server" Text=""></asp:Label></td>
                    <td class="RowContent"> : </td>
                    <td width="50%" align="center" class="RowContent">
                        <asp:Label ID="lblCurrMonthVisits" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td class="RowHead">Total Visits till date</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="center">
                        <asp:Label ID="lblTotalVisits" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                   
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td class="RowHead">&nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td class="RowContent" align="center">
                        &nbsp;</td>
                    </tr>
                    
                   
                    
                      </table>
         
        </div></td>
                                   <td  align="center">
                                        </td>
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
                                        &nbsp;</td>
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
                                        &nbsp;</td>
                                         <td>
                                             &nbsp;</td>
                                </tr>

                                <tr>
                                    <td align="center" valign="top">
                                    <div id="dvDomain"  class="SummaryBoxCss">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal3" Text="Requests" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowContent">&nbsp;</td>
                    <td class="RowContent"> &nbsp; </td>
                    <td width="50%" align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowHead"> Domain Requests
                       </td>
                    <td class="RowContent"> : </td>
                    <td width="50%" align="center" class="RowContent">
                        <asp:Label ID="lblDomainRq" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                    
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowHead"> &nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td width="50%" align="center" class="RowContent">
                            <asp:HyperLink ID="HypDomains" CssClass="links_Navigate" NavigateUrl="~/SuperAdmin/SA_DomainRequests.aspx" runat="server"> ..DomainRequests</asp:HyperLink>
                            </td>
                    </tr>
                    
                    
                    
                      </table>
         
        </div>
                                    </td>
                                    <td align="center"  valign="top">
                                        <div id="dvVisits"  class="SummaryBoxCss">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal2" Text="Enquiries" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowContent">&nbsp;</td>
                    <td class="RowContent"> &nbsp; </td>
                    <td width="50%" align="center" class="RowContent">
                        &nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="50%" class="RowHead">Email enquiry</td>
                    <td class="RowContent"> : </td>
                    <td width="50%" align="center" class="RowContent">
                        <asp:Label ID="lblContactUs" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td class="RowHead">Free SMS enquiry</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="center">
                        <asp:Label ID="lblFreeSMS" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    
                   
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td class="RowHead">&nbsp;</td>
                    <td class="RowContent"> &nbsp;</td>
                    <td class="RowContent" align="center">
                            <%--<asp:HyperLink ID="HyperLink1" CssClass="links_SideMenu" NavigateUrl="~/SuperAdmin/SA_EmailListing.aspx" runat="server"> ..EmailListing</asp:HyperLink>--%>
                            </td>
                    </tr>
                    
                   
                    
                      </table>
         
        </div></td>
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
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left" valign="top">
                        
                               &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                          <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left">
                        
                            <asp:Label ID="lblContactUsCount" runat="server"></asp:Label>
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left">
                            <asp:Label ID="lblFreeSmsCount" runat="server"></asp:Label>
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
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

