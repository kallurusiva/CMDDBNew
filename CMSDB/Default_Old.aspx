<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster_FullBottom.master" AutoEventWireup="true" CodeFile="Default_Old.aspx.cs" Inherits="Default_Old" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBottom" Runat="Server">

 <link href="App_Themes/Common/CommonStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        
        #maincontainer{
         width: 1050px;
         margin: 0 auto;
         border-width: 0 0 0 0;
        }
        
        
 
    </style>
    
    
 <form id="form1" runat="server">
 <div id="maincontainer">
    <table cellpadding="0" cellspacing="0" width="100%" border="0"  class="style1">
    <tr>
     <td>
                <div id="ContentLeft">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                           &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="sideBox" id="dvRecNews">
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
                                <textarea id="AreaNewContent" class="sideBoxTextArea" runat="server">
                                    With billions of SMS messages sent every month in US alone,
                                     it has become the most effective and cost efficient mechanism to communicate
                                </textarea>
                                </div>
                                <div class="sideBoxFooter">
                                <asp:HyperLink ID="HyperLink6" runat="server" CssClass="links_TopLine" NavigateUrl="UserNews.aspx">Read more..</asp:HyperLink>
                                </div>
                                <div class="Boxblank">
                                 &nbsp;
                                </div>
                                   <div class="sideBoxsubhead" id="dvRecNewsHead2" runat="server">
                                    05 Aug, 2010
                                </div>
                                <div class="sideBoxContent" id="dvRecNewsContent2" runat="server">
                                 <textarea id="AreaNewContent2" class="sideBoxTextArea" runat="server">
                                    With billions of SMS messages sent every month in US alone, 
                                    it has become the most effective and cost efficient mechanism to communicate
                                   
                                 </textarea>
                                </div>
                                 <div class="sideBoxFooter">
                                  <asp:HyperLink ID="HyperLink5" runat="server" CssClass="links_TopLine" NavigateUrl="UserNews.aspx">Read more..</asp:HyperLink>
                                 </div>
                                 <div class="Boxblank">&nbsp;</div>
                            </div>
                            
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                                Width="200px">
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            </asp:Calendar>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        
                        <div class="sideBox">
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
                                    <%--<asp:Literal ID="LtrEvtContent" runat="server"></asp:Literal>--%>
                                    <textarea id="AreaEvtContent" class="sideBoxTextArea" runat="server"></textarea>
                                </div>
                                <div class="sideBoxFooter"> 
                                    <asp:HyperLink ID="HyperLink3" CssClass="links_TopLine" runat="server" NavigateUrl="UserEvents.aspx">Read more..</asp:HyperLink>
                                </div>
                                <div class="Boxblank">&nbsp;</div>
                                   <div class="sideBoxsubhead" id="dvEventsHead2" runat="server">
                                    05 Aug, 2010
                                </div>
                                <div class="sideBoxContent" id="dvEventsContent2" runat="server">
                                   <textarea id="AreaEvtContent2" class="sideBoxTextArea" runat="server"></textarea> 
                                </div>
                                <div class="sideBoxFooter"> 
                                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="links_TopLine" NavigateUrl="UserEvents.aspx">Read more..</asp:HyperLink>
                                </div>
                                <div class="Boxblank">&nbsp;</div>
                            </div>
                        
                    </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                   
                        
                </div>
                
                <div id="ContentRight">
                
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                 <tr>
                    <td>&nbsp;</td>
                </tr>
   
                <tr>
                <td align="right">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                                BorderColor="#C9DB85" CellPadding="4" DayNameFormat="Shortest" 
                                Font-Names="Tahoma" Font-Size="7pt" ForeColor="Black" Height="180px" 
                                Width="200px" CssClass="CalCss">
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <WeekendDayStyle BackColor="#FAFADB" />
                                <TodayDayStyle BackColor="#C9DB85" ForeColor="Black" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <DayHeaderStyle BackColor="#EEFAC0" Font-Bold="True" Font-Size="7pt" />
                                <TitleStyle BackColor="#C9DB85" BorderColor="#C9DB85" Font-Bold="True" />
                 </asp:Calendar>
                 </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
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
                    </div>
                    </div>
                    
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td align="right">
                     <div class="sideBox">
                        <div class="GreenBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText">
                            <asp:Literal ID="LtrContactUs" Text="Contact US" runat="server"></asp:Literal>  </div>
                        </div>
                        <div class="GreenBoxGrad">
                          <div id="Div1" runat="server">
                            
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                            <tr>
                            <td>&nbsp;<img alt="a" src="Images/contactus1.jpg" style="width: 100px; height: 67px" /></td>
                            </tr>
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                             <tr>
                            <td>&nbsp;<b>Tel </b> :- + <asp:Literal ID="LtrContactUs_HandPhone" Text="" runat="server"></asp:Literal> 
                            </td>
                            </tr>
                            <tr>
                            <td>&nbsp;<b>Fax </b> :- + <asp:Literal ID="LtrContactUs_Fax" Text="" runat="server"></asp:Literal>     </td>
                            </tr>
                            <tr>
                            <td>&nbsp;<b>Email </b> :- <asp:Literal ID="LtrContactUs_Email" Text="" runat="server"></asp:Literal> </td>
                            </tr>
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                            
                            </table>
                            
                            
                            

                          </div> 
                    </div>
                    </div>
                    
                    
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                </tr>

                
                <tr>
                    <td>&nbsp;</td>
                </tr>

                </table>
                
                
                
                
                </div>
                
                <div id="ContentMid">
                
                <table border="0" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                <td>&nbsp; </td>
                </tr>
                <tr>
                <td>&nbsp;</td>
                </tr>
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
                    </div>
                    </td>
                </tr>
                
                <tr>
                <td>&nbsp;</td>
                </tr>
                
                <tr>
                <td>
                <div class="TestIm">
                    <div class="TestimHeader"> 
                     <asp:Literal ID="ltrTestimonials" Text="Testimonials" runat="server"></asp:Literal>  </div>
                    <div class="Testimbox" id="dvTestimContent" runat="server">
                     <textarea id="AreaTestimonialContent" class="sideBoxTextArea_Testim" runat="server">
                     The content goes here... The content goes here... The content goes here... The content goes here..1.
                     The content goes here... The content goes here... The content goes here... The content goes here..2.  
                     </textarea>
                    </div>
                    <div class="Testimfooter" id="dvTestimFooter" runat="server">
                        <img src="Images/testiarrow.gif" alt="arrowimg" /> By Micheal jordan at 10.30pm, 11 Aug 2010.
                    </div>
                </div>
                </td>
                </tr>
                
                <tr>
                <td> <div class="separator">
                    </div></td>
                </tr>
                
                <tr>
                <td>&nbsp;</td>
                </tr>
                
                <tr>
                <td><div class="TestIm">
                    <div class="TestimHeader"> Our Services  </div>
                    <div class="Testimbox">
                     The content goes here... The content goes here... The content goes here... The content goes here..1.
                     The content goes here... The content goes here... The content goes here... The content goes here..2.  
                    </div>
                </div></td>
                </tr>
                
                <tr>
                <td>&nbsp;</td>
                </tr>
                
                </table>
                
                
                </div>
               
     </td>
    </tr>

</table> 

</div>
</form>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

