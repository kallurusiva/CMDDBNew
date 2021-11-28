<%@ Page Title="" Language="C#" MasterPageFile="~/TmpMaster2.master" AutoEventWireup="true" CodeFile="default_T2.aspx.cs" Inherits="default_T2" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
    <%--<form runat="server" id="frmMain">--%>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr style="height:0px;">
            <td width="200px;">
                &nbsp;</td>
            <td width="80%">
                &nbsp;</td>
            <td width="200px;">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td width="200px;" valign="top" align="left">
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
            <td width="80%" align="center">
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
            <td rowspan="3" align="right" valign="top" class="tmp3_RimgCSS">
                <%--<img alt="rs" src="Images/rsPic1.jpg" style="width: 170px; height: 425px" />--%></td>
        </tr>
        <tr>
         <td>&nbsp;</td> <td>&nbsp;</td> <td>&nbsp;</td>
        </tr>
        <tr>
        <td valign="top">
        
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
        <%--<td align="center" style="background-image:url(Images/tmp3_Bimg3.jpg); background-repeat: no-repeat; background-position: center center;">--%>
        <td align="center" class="tmp3_BimgCSS" >
<%--        <div id="dvBimg" class="tmp3_BimgCSS">
        </div>--%>
                   <%--<div class="sideBox" style="width: 550px;">
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
                  </div>--%>
       <%--    <img alt="bspic" src="Images/bspic1.jpg" style="width: 500px; height: 150px" />--%>
           
           </td>
        </tr>
        
        <tr>
            
            <td colspan="2">
            <div>
             </div>       
                    
             </td>
           <td>&nbsp;</td>
        </tr>
        
         <tr>
            <td colspan="2" style="padding: 0px 20px 0px 0px;">
                 <div class="GreenBoxGrad">
                   <div class="font_12BlueBold"> 
                    <asp:Literal ID="LtrFollowUs" Text="Follow us on" runat="server"></asp:Literal>
                    </div>
                    <div class="CssFollowUs" id="dvFollowUs" runat="server">
                    </div> 
                 </div>
                    <%--<div class="GreenBoxGrad" style="width:550px; height:100px;" >
                         
                            
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                            <td width="5%">&nbsp;</td>
                            <td width="35%" class="font_12BlueBold" align="center"><asp:Literal ID="LtrContactUs" Text="Contact US" runat="server"></asp:Literal> </td>
                            <td width="30%">&nbsp;</td>
                            <td width="30%">&nbsp;</td>
                            </tr>
                            
                            <tr>
                            <td>&nbsp;</td>
                            <td align="center">
                            <asp:Image ID="ImgContact" BorderWidth="2px" BorderColor="#ACA9A9" Width="80" Height="70" runat="server" />
                            </td>
                            <td>
                            <asp:Literal ID="ltrNickName" Text="" runat="server"></asp:Literal> 
                            <asp:Literal ID="ltrCompanyName" Text="" runat="server"></asp:Literal> <br />
                            <asp:Literal ID="ltrContactUs_HomePhone" Text="" runat="server"></asp:Literal> <br />
                            </td>
                            <td>
                            <asp:Literal ID="LtrContactUs_HandPhone" Text="" runat="server"></asp:Literal> <br />
                            <asp:Literal ID="LtrContactUs_Fax" Text="" runat="server"></asp:Literal>    <br />
                            <asp:Literal ID="LtrContactUs_Email" Text="" runat="server"></asp:Literal> <br />
                            </td>
                            </tr>
                            <tr>
                            <td>&nbsp;</td>
                            </tr>
                            </table>
                            
                    </div>--%>
                </td>
            <td>
             <div class="GreenBoxGrad" style="min-height:70px;">
              <a href="UserFreeSMS.aspx" ><img border="0" alt="register" src="Images/client/Register.jpg"/></a>
              </div> 
            </td>
                                  
        </tr>
        
         <%--<tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
            &nbsp;</td>
        </tr>--%>
        
    </table>
<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

