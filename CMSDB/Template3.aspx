<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Template3.aspx.cs" Inherits="Template1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Common/CommonStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        
        #maincontainer{
         width: 1020px;
         margin: 0 auto;
         border-width: 0 0 0 0;
        }
        
        
 
    </style>
    
    
 


</head>
<body>
    <form id="form1" runat="server">
    <div id="maincontainer">
    
    
    
        <table border="0" cellpadding="0" cellspacing="0" class="style1">
            
                       
            <tr>
             <td>
             <div id="ContentHeader">
              <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr>
              <td  width="200px" style="height:80px"> 
                    <div id="dvLogoImage" runat="server">
                        <img alt="logo img" class="divCssLogoImage"  src="Images/client/LOGO_GS2.jpg" 
                        style="width: 140px; height: 66px" />
               </div>
               </td>
              <td valign="bottom">
              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td width="20px">&nbsp;</td>
                <td align="right">&nbsp;
                   <asp:HyperLink ID="HyperLink1" CssClass="links_TopLineRed" runat="server" 
                        NavigateUrl="~/UserFreeSMS.aspx">Free SMS Registration</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img alt="Clogin" src="Images/CustHome.gif" />
                    <asp:HyperLink ID="HyperLink2" CssClass="links_TopLine" runat="server" 
                        NavigateUrl="~/Template3.aspx">Home</asp:HyperLink>
                    &nbsp; | &nbsp;     
                    <asp:HyperLink ID="HyperLink12" CssClass="links_TopLine" runat="server" 
                        NavigateUrl="~/UserContactUsPage.aspx">Contact Us</asp:HyperLink>
                    &nbsp; | &nbsp;     
                    <img alt="Clogin" src="Images/CustLogin.gif" />
                    <asp:HyperLink ID="HyperLink7" CssClass="links_TopLine" runat="server" 
                        NavigateUrl="~/CustomerLogins.aspx">Customer Login</asp:HyperLink>
                </td>
                <td  width="20px">&nbsp;</td>
                </tr>
                <tr>
                <td width="20px">&nbsp;</td>
                <td>&nbsp;</td>
                <td  width="20px">&nbsp;</td>
                </tr>
                <tr style="height: 50px">
                <td align="left" valign="top" style="background-color:#03C0C6">
                    <img alt="topleftarc" src="Images/table_top_Leftarc.gif" 
                        style="width: 10px; height: 20px" /></td>
                <td style="background-color:#03C0C6">
                <div class="indentmenu" id="dvTopMenu" runat="server">
                    <ul>
                    <li><a href="#">Home</a></li>
                    <li><a href="#" class="current">About Us</a></li>
                    <li><a href="#">Corporate Info</a></li>
                    <li><a href="#">Incentive Plan</a></li>
                    <li><a href="#">Products</a></li>
                    <li><a href="#">Presentation</a></li>
                    <li><a href="#">Testimonials</a></li>
                    <li><a href="#">Download</a></li>
                    </ul>
                </div>
                </td>
                <td align="right" valign="top"  style="background-color:#03C0C6">
                    <img alt="toprightarc" src="Images/table_top_Rightarc.gif" 
                        style="width: 10px; height: 20px" /></td>
                </tr>
                </table>
              
              </td>
              </tr>
              <tr>
              <td>
              <table border="0" cellpadding="0" cellspacing="0" width="100%" class="bkgMemLogin">
                    <tr>
                        <td style="height:30px;" width="20px" align="left" valign="top">
                        <img alt="topleftarc" src="Images/table_top_Leftarc.gif" 
                        style="width: 10px; height: 20px" />
                        </td>
                        <td class="font_Title1">Members Login</td>
                        <td  width="20px">&nbsp;</td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="font_12Normal">Login Id</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtLoginID"  CssClass="stdTextField" runat="server"></asp:TextBox>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="font_12Normal">Password</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPassword" CssClass="stdTextField" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password"></asp:TextBox>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr style="height:5px;">
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <asp:Button CssClass="stdButtonLogin" ID="btnSignIn" runat="server" 
                            Height="26px" Text="Sign In" 
                            Width="56px" onclick="btnSignIn_Click" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td class="font_forgotPwd" align="right">forgot password</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td class="font_12Msg_Error">
                        <asp:Literal ID="LtrErrMessage" Text="" runat="server"></asp:Literal>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table></td>
              <td>
              <div id="dvBannerImg" runat="server">
              <img alt="banner image"  class="divCssBannerImg" src="ImageRepository/Banner1.jpg" />
              </div>
              
              </td>
              </tr>
              <tr class="underBannerBar">
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              </tr>
              </table>
             
             
             </div>
             
             </td>
            </tr>
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
                    <td>
                        <a href="PartnerWebRegistration.aspx">
                            <img border="0" alt="register" src="Images/client/Register.jpg" style="width: 200px; height: 50px" />
                        </a>
                   </td>
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
            <tr>
             <td>
            <div id="footer">
                    <table border="0" cellpadding="0" cellspacing="0" width="96%">
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--<div class="indentmenuDown" id="DownMenu" runat="server">
                        <ul>
                        <li><a href="#">Home</a></li>
                        <li><a href="#" class="current">About Us</a></li>
                        <li><a href="#">Corporate Info</a></li>
                        <li><a href="#">Incentive Plan</a></li>
                        <li><a href="#">Products</a></li>
                        <li><a href="#">Presentation</a></li>
                        <li><a href="#">Testimonials</a></li>
                        <li><a href="#">Download</a></li>
                        </ul>
                        </div>--%>
                    <div id="dvCopyRights" class="fontCopyRight" runat="server">GlobalSurf Sdh bhd.2010 All Rights Reserved </div>    
                    </td>
                    </tr>
                    </table>
                    
                    </div>
             </td>
            </tr>
            
        </table>
    
    </div>
    </form>
</body>
</html>
