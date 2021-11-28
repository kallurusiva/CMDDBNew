<%@ Page Title="" Language="C#" MasterPageFile="~/TmpMaster1.master" AutoEventWireup="true" CodeFile="dt1.aspx.cs" Inherits="dt1" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
    <%--<form runat="server" id="frmMain">--%>


    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr style="height:0px;">
            <td width="200px;">
                &nbsp;</td>
            <td width="80%">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
            <td width="200px;">
                &nbsp;</td>
        </tr>
        
        <tr style="height:0px;">
            <td width="200px;" colspan="2" class="HomePageHeaderFont">
            <div id="dvCompanyName" runat="server"> Welcome to 1SmsWebsite.com </div>
                </td>
            <td width="200px;" rowspan="2" valign="top">
                 <asp:Calendar ID="Calendar1" runat="server" BackColor="White"  
                                BorderColor="#C9DB85" CellPadding="4" DayNameFormat="Shortest" 
                                Font-Names="Tahoma" Font-Size="7pt" ForeColor="Black" Height="180px" 
                                Width="200px"
                                >
                             
                            <%--  <TitleStyle BackColor="#FF5555" BorderColor="#C9DB85" Font-Bold="True" />--%>
                                
                                <TitleStyle   BackColor="#E2E1DE"  BorderColor="#C9DB85" Font-Bold="True" Font-Size="Small" ForeColor="ControlDarkDark" />
                                <SelectedDayStyle CssClass="calSelectedDay"/>
                                <SelectorStyle CssClass="calSelector"  />
                                <WeekendDayStyle CssClass="calWeekendDay"/>
                                <TodayDayStyle CssClass="calTodayDay" />
                                <OtherMonthDayStyle CssClass="calOtherMonthDay" />
                                <NextPrevStyle CssClass="calNextPrev" />
                                <DayHeaderStyle CssClass="calDayHeader"/>
                             
                                   <%--  <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />--%>   
                                   <%--<SelectorStyle BackColor="#CCCCCC" />--%>                                
                                   <%--<WeekendDayStyle BackColor="#FADBDB" />--%>
                                   <%--   <TitleStyle CssClass="calTitle"/>--%>
                                   <%--<TodayDayStyle BackColor="#FF9999" ForeColor="Black" />--%>
                                   <%--    <DayHeaderStyle BackColor="#FCA7A5" Font-Bold="True" Font-Size="7pt" />--%>
                                
                 </asp:Calendar>
                </td>
        </tr>
        
        <tr>
            
            <td colspan="2">
            <div>
                    <div style="float:left" class="HomePageContentFont" id="dvHomePageContent" runat="server">
                    <asp:Label ID="lblHomePageContent" runat="server" Text=""></asp:Label>
                                
                    </div>
                   <%-- <div style="float:left; margin-left: 30px;">
                        <img src="Images/smcomp.jpg" />
                    </div>--%>
             </div>       
                    
             </td>
           
        </tr>
        <tr style="height: 20px; padding-top: 5px; padding-bottom: 5px; padding-left: 10px;">
            <td>
                 <div class="separator">
                    </div>
                    </td>
            <td>
                &nbsp;</td>
            <td>
            &nbsp;</td>
        </tr>
           <tr>
            <td colspan="2" align="left">
                <table border="0" cellpadding="0" cellspacing="0" width="99%">
                <tr>
                
                <td width="32%">
                <div class="sideBox" style="width: 230px;" id="dvRecNews">
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
                <td width="32%">
                    <div class="sideBox" style="width: 230px;">
                                <div class="sideBoxhead">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                      <asp:Literal ID="LtrUpcomingEvents" Text="UpComing Events" runat="server"></asp:Literal> </div>
                                </div>
                                <div class="sideBoxsubhead" id="dvEventsHead1" runat="server">
                                    11 July, 2010
                                </div>
                                <div class="sideBoxContent" id="dvEventsContent1" runat="server">
                                <asp:Label ID="lblEventContent" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="sideBoxFooter"> 
                                    <asp:HyperLink ID="HyperLink3" CssClass="links_TopLine" runat="server" NavigateUrl="UserEvents.aspx">Read more..</asp:HyperLink>
                                </div>
                                <div class="Boxblank">&nbsp;</div>
                            </div></td>
                <td width="36%">
                
                <div class="sideBox" style="width: 270px;">
                                <div class="sideBoxhead">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                      <asp:Literal ID="ltrTestimonial" Text="Testimonials" runat="server"></asp:Literal> </div>
                                </div>
                                <div class="sideBoxsubhead" id="dvTestimonialHead1" runat="server">
                                    11 July, 2010
                                </div>
                                <div class="sideBoxContent" id="Div3" runat="server">
                                <asp:Label ID="lblTestimonialContent" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="sideBoxFooter"> 
                                    <asp:HyperLink ID="hypTesti" CssClass="links_TopLine" runat="server" NavigateUrl="UserTestimonials.aspx">Read more..</asp:HyperLink>
                                </div>
                                <div class="Boxblank">&nbsp;</div>
                  </div>
                
                
                
                </td>
                </tr>
                
                </table>
            
            </td>
            
            <td align="right" valign="top">
             
             <div class="sideBox" style="width: 200px;">
                        <div class="GreenBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText">
                            <asp:Literal ID="LtrContactUs" Text="Contact US" runat="server"></asp:Literal>  </div>
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
                            
                            </table>
                            
                            
                            

                          </div> 
                    </div>
             </div>
           <%--   <div class="Boxblank"> &nbsp;</div>
           
            <div class="sideBox">
                                <div class="GreenBoxhead">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="LtrFollowUs" Text="Follow us on" runat="server"></asp:Literal> </div>
                                </div>
                                <div class="GreenBoxGrad">
                                  <div class="CssFollowUs" id="dvFollowUs" runat="server">
                                    
                                  </div> 
                                   <a href="UserFreeSMS.aspx" ><img border="0" alt="register" src="Images/client/Register.jpg"/></a>
                    </div>
                    </div>--%>
                    
            </td>
        </tr>
        <tr style="height:20px; padding-top: 5px; padding-bottom:5px; padding-left:10px;">
                <td>
                    <div class="separator">
                    </div>
                    
                </td>
                  <td>
                &nbsp;</td>
            <td>
            &nbsp;</td>
                </tr>
         <tr>
            <td colspan="2">
                 <div class="GreenBoxGrad">
                   <div> 
                  <font style="font: bold italic 102%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif;" > <asp:Literal ID="LtrFollowUs" Text="Follow us on" runat="server"></asp:Literal> </font> 
                  </div>
                  <div class="CssFollowUs" id="dvFollowUs" runat="server">
                    
                  </div> 
                   &nbsp;</div>
                </td>
            <td>
             <div class="GreenBoxGrad" style="min-height:60px;">
              <a href="UserFreeSMS.aspx" ><img border="0" alt="register" src="Images/client/Register.jpg"/></a>
              </div> 
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
        
    </table>

    

<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

