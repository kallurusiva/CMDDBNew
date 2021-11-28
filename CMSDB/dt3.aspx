<%@ Page Title="" Language="C#" MasterPageFile="~/TmpMaster3.master" AutoEventWireup="true" CodeFile="dt3.aspx.cs" Inherits="dt3" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
    
    <table cellpadding="0" cellspacing="0"  border="0" width="100%">
        <tr style="height:0px;">
            <td width="200px;">
                &nbsp;</td>
            <td width="60%">
                &nbsp;</td>
            <td width="200px;">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td width="200px;" valign="top" align="left">
                <div class="sideBox" style="width: 200px;">
                        <div class="sideBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText">
                            <asp:Literal ID="ltrProfile" Text="Profile" runat="server"></asp:Literal>  </div>
                        </div>
                        <div class="GreenBoxGrad" >
                          <div id="Div1" runat="server">
                            
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                           <%-- <tr>
                            <td>&nbsp;<img alt="a" src="Images/contactus1.jpg" style="width: 100px; height: 67px" /></td>
                            </tr>--%>
                            <tr>
                            <td  align="center">&nbsp;<asp:Image ID="ImgContact" BorderWidth="2px" BorderColor="#ACA9A9" Width="80" Height="70" runat="server" /></td>
                            </tr>
                            
                            <tr>
                            <td  align="center" class='font_12Normal'><asp:Literal ID="ltrNickName" Text="" runat="server"></asp:Literal> 
                            </td>
                            </tr>
                            
                            <tr>
                            <td align="center" class='bkgNewsHeader'><asp:Literal ID="ltrCompanyName" Text="" runat="server"></asp:Literal> 
                            </td>
                            </tr>
                    
                            <tr>
                            <td><asp:Literal ID="ltrContactUs_HomePhone" Text="" runat="server"></asp:Literal> 
                            </td>
                            </tr>
                            <tr>
                            <td><asp:Literal ID="LtrContactUs_HandPhone" Text="" runat="server"></asp:Literal> 
                            </td>
                            </tr>
                            <tr>
                            <td><asp:Literal ID="LtrContactUs_Fax" Text="" runat="server"></asp:Literal>     </td>
                            </tr>
                            <tr>
                            <td><asp:Literal ID="LtrContactUs_Email" Text="" runat="server"></asp:Literal> </td>
                            </tr>
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                            
                            <tr>
                            <td><div class="CssFollowUs" id="dvFollowUs" runat="server">  </div> </td>
                            </tr>
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                            
                             
                            </table>
                            
                            
                            

                          </div> 
                    </div>
             </div>
             
             </td>
            <td width="60%" align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="86%">
                 <tr>
                <td class="HomePageHeaderFont">&nbsp; &nbsp;<div id="dvCompanyName" runat="server"> 1SmsWebsite </div>
                 </td>
                </tr>
                <tr>
                <td>
                    <div class="separator">
                    </div>
                    </td>
                </tr>
                
                <tr>
                <td>&nbsp; </td>
                </tr>
                
                <tr>
                <td >
                <div class="HomePageContentFont" id="dvHomePageContent" runat="server">
                    <asp:Label ID="lblHomePageContent" runat="server" Text=""></asp:Label>
                                
                    </div> 
                    
                 </td>
                </tr>
                
                <tr>
                <td>
                <div class="separator">
                    </div></td></tr>
                
                </table>
            </td>
            <td  width="200px;" align="right" valign="top" rowspan="3">
            <div id="dvWP_Sideimg" runat="server">
            
            
            </div>
                <%--<img alt="rs" src="Images/rsPic1.jpg" style="width: 170px; height: 425px" />--%>
                </td>
        </tr>
        <tr>
         <td>&nbsp;</td> 
         <td>&nbsp;</td> 
        </tr>
        
        <tr>
        <td valign="top">
        
        <div class="sideBox" style="width: 200px;" id="dvRecNews">
                                <div class="sideBoxhead">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="LtrRecentNews" Text="Recent News" runat="server"></asp:Literal></div>
                                </div>
                                <div class="sideBoxsubhead" id="dvRecNewsHead1" runat="server">
                                    11 July, 2010
                                </div>
                                <div class="sideBoxContent" id="dvRecNewsContent1" runat="server">
                                <asp:Label ID="lblNewsContent" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="sideBoxFooter">
                                <asp:HyperLink ID="HyperLink6" runat="server" CssClass="links_TopLine" NavigateUrl="UserNews.aspx">Read more..</asp:HyperLink>
                                </div>
                                <div class="Boxblank">
                                 &nbsp;
                            </div>
                     </div>
        
        
         </td>
        <%--<td align="center" style="background-image:url(Images/tmp3_Bimg3.jpg); background-repeat: no-repeat; background-position: center center;">--%>
        <td align="center" >
        
        <div id="dvWP_Bottomimg" runat="server">
        
        </div>
                   
       <%--    <img alt="bspic" src="Images/bspic1.jpg" style="width: 500px; height: 150px" />--%>
           &nbsp;
        </td>
        </tr>
        
          </table>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

