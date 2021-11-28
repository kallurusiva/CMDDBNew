<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Template2.aspx.cs" Inherits="Template1" %>

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
         width: 1024px;
         margin: 0 auto;
         border-width: 0 0 0 0;
        }
        
        
 
    </style>
    
    
    <style type="text/css">

/*Credits: Dynamic Drive CSS Library */
/*URL: http://www.dynamicdrive.com/style/ */

.indentmenu{
font: bold 13px Arial;
width: 100%; /*leave this value as is in most cases*/
overflow: hidden;
}

.indentmenu ul{
margin: 0;
padding: 0;
float: left;
width: 100%; /*width of menu*/
 /*border: 1px solid #564c66;dark purple border*/
border-width: 1px 0;
background-color: #03C0C6;
/*background: black url(media/indentbg.gif) center center repeat-x;*/

}

.indentmenu ul li{
display: inline;
}

.indentmenu ul li a{
float: left;
color: white; /*text color*/
padding: 5px 11px;
text-decoration: none;
border-right: 1px solid #564c66; /*dark purple divider between menu items*/
}

.indentmenu ul li a:visited{
color: white;
}

.indentmenu ul li a:hover, .indentmenu ul li .current{
color: white !important; /*text color of selected and active item*/
padding-top: 6px; /*shift text down 1px for selected and active item*/
padding-bottom: 4px; /*shift text down 1px for selected and active item*/
/*background: black url(media/indentbg2.gif) center center repeat-x;*/
filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0,StartColorStr=#03C0C6 ,EndColorStr=#B0DFE0)}
}

        </style>


</head>
<body>
    <form id="form1" runat="server">
    <div id="maincontainer">
    
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="200px" style="height:80px">
                    <img alt="logo img" src="Images/client/LOGO_GS2.jpg" 
                        style="width: 140px; height: 66px" /></td>
                <td align="center" valign="bottom">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td width="20px">&nbsp;</td>
                <td>&nbsp;</td>
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
                <div class="indentmenu">
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
                <td style="height:200px; background-color:#DFE3E3" valign="top" align="left">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
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
                        <asp:TextBox ID="TextBox1"  CssClass="stdTextField" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="TextBox2" CssClass="stdTextField" runat="server" style="margin-bottom: 0px"></asp:TextBox>
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
                        <asp:Button CssClass="stdButtonLogin" ID="Button1" runat="server" Height="26px" Text="Sign In" 
                            Width="56px" />
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
                    
                    </td>
                <td>
                    <img alt="banner image" src="Images/client/Banner1.jpg" 
                        style="width: 824px; height: 200px" /></td>
            </tr>
            <tr class="underBannerBar">
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="height: 400px; overflow:visible;">
                <td valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="100">
                    <tr>
                    <td>
                    </td>
                    <td>
                    
                    &nbsp;
                    
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr style="height:30px;">
                                <td align="left" class="bkgNewsBox_Grad" valign="top" width="10">
                        <img alt="topleftarc" src="Images/table_top_Leftarc.gif" 
                        style="width: 10px; height: 20px" /></td>
                                <td class="bkgNewsBox_Grad bkgNewsHeader" width="180" align="center">
                                    Recent News</td>
                                <td align="right" class="bkgNewsBox_Grad" valign="top" width="10">
                    <img alt="toprightarc" src="Images/table_top_Rightarc.gif" 
                        style="width: 10px; height: 20px" />
                                </td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" class="bkgNewsTable">
                            <tr>
                            <td class="bkgNewsTitle">11 July, 2010</td>
                            </tr>
                            <tr>
                            <td class="bkgNewsContent">With billions of SMS messages sent every month in US alone, it has become the most effective and cost efficient mechanism to communicate and market. ...    </td>
                            </tr>
                            <tr style="background-color: #FFFFFF"><td>&nbsp;</td></tr>
                            <tr>
                            <td class="bkgNewsTitle">05 Aug, 2010</td>
                            </tr>
                            <tr>
                            <td class="bkgNewsContent">With billions of SMS messages sent every month in US alone, it has become the most effective and cost efficient mechanism to communicate and market. ...    </td>
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
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
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
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                    </td>
                    
                    </tr>
                    
                    </table>
                    </td>
                <td valign="top" align="center">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="HomePageContentFont">
                        <tr>
                            <td width="33%">
                                &nbsp;</td>
                            <td  width="33%">
                                &nbsp;</td>
                            <td  width="33%">
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                                <td rowspan="3" align="center">
                                    <img alt="register" src="Images/client/Register.jpg" 
                                        style="width: 200px; height: 50px" /></td>
                        </tr>
                        
                        <tr>
                            <td class="HomePageHeaderFont" align="left">
                                Welcome to 1SMSWebSite</td>
                            <td>&nbsp;</td>
                            <%--<td>bbb</td>--%>
                                
                        </tr>
                        <tr>
                            <td>
                                <div id="separator"> </div></td>
                            <td>
                                <div id="separator"> </div> </td>
                           <%-- <td>cccc</td>--%>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="HomepgContent">
                                Keeping up to date with breaking news while you&#39;re on the move is simple with 
                                the BBC News SMS alerts service. All you need to do is register your mobile 
                                number with us by texting ALERTS START to 82002 and we&#39;ll send you details of 
                                major national and international events as soon as they happen. Each message you 
                                receive will cost between 10p and 12p depending on your mobile network and 
                                tariff. Between the hours of 2300 and 0700, you will only hear from us if there 
                                is an event of major national significance. We estimate that you will receive 
                                about 12 messages per month, depending on events. If you want a more frequent or 
                                daily service, please see below for details of other services in the market. 
                                (Please note this service is for UK users only)<br />
                                <br />
                                Keeping up to date with breaking news while you&#39;re on the move is simple with 
                                the BBC News SMS alerts service. All you need to do is register your mobile 
                                number with us by texting ALERTS START to 82002 and we&#39;ll send you details of 
                                major national and international events as soon as they happen. Each message you 
                                recei<br />
                                </div>
                            </td>
                                <td align="center" rowspan="3">
                                <div id="tblright1">
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                 <tr>
                                 <td>&nbsp;</td>
                                 </tr>
                                 <tr>
                                 <td><img src="Images/client/HomePgCouple.jpg" /></td>
                                 </tr>
                                 <tr>
                                 <td>&nbsp;</td>
                                 </tr>
                                 <tr>
                                 <td>
                                 <div id="tbldownRt">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr style="height:30px;">
                                <td align="left" class="bkgNewsBox_Grad" valign="top" width="10">
                        <img alt="topleftarc" src="Images/table_top_Leftarc.gif" 
                        style="width: 10px; height: 20px" /></td>
                                <td class="bkgNewsBox_Grad bkgNewsHeader" width="180" align="center">
                                    UpComing Events</td>
                                <td align="right" class="bkgNewsBox_Grad" valign="top" width="10">
                    <img alt="toprightarc" src="Images/table_top_Rightarc.gif" 
                        style="width: 10px; height: 20px" />
                                </td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" class="bkgNewsTable">
                            <tr>
                            <td class="bkgTestTitle" align="left">&nbsp; 11 Aug, 2010 at 8pm</td>
                            </tr>
                             <tr>
                            <td class="bkgTestTitle" align="left">&quot;Soft Launching ...&quot;</td>
                            </tr>
                            <tr>
                            <td class="bkgNewsContent">With billions of SMS messages sent every month in US alone, it has become the most effective and cost efficient mechanism to communicate and market. ...    </td>
                            </tr>
                            </table>
                            
                            </td>
                    </tr>
                    <tr>
                        <td class="bkgTestReadmore" align="right">
                            Read more ...</td>
                    </tr>
             
                            <tr style="background-color: #FFFFFF"><td>&nbsp;</td></tr>
                            <tr>
                            <td>
                            <table border="0" cellpadding="0" cellspacing="0" class="bkgNewsTable">
                            <tr>
                            <td class="bkgTestTitle" align="left">&nbsp; 05 Aug, 2010 at 8pm</td>
                            </tr>
                             <tr>
                            <td class="bkgTestTitle" align="left">&quot;Road Show at Sunway&quot;</td>
                            </tr>
                            <tr>
                            <td class="bkgNewsContent">it has become the most effective and cost efficient mechanism to communicate and market. ...    </td>
                            </tr>
                            </table>
                            </td>
                    </tr>
                     <tr>
                        <td class="bkgTestReadmore" align="right"> Read More..
                           </td></tr>
                </table>
                         </div>
                                 
                                 </td>
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
                                 <div id="separator"> </div></td>
                            <td>
                                <div id="separator"> </div></td>
                               <%-- <td>
                                    bbbbb</td>--%>
                        </tr>
                        <tr>
                            <td align="center">
                            
                            <div id="box">
                                <div id="Orboxhead">
                                    <div id="boxTLtarc"> <img src="Images/table_top_Leftarc.gif" /></div>
                                    <div id="boxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div id="boxheadText"> Testimonials </div>
                                </div>
                                <div id="boxsubhead">
                                    By Peter England
                                </div>
                                <div id="boxContent">
                                    The content goes here... The content goes here... The content goes here... The content goes here..1.
                                    The content goes here... The content goes here... The content goes here... The content goes here..2.  
                                    The content goes here... The content goes here... The content goes here... The content goes here..3. 
                                    
                                    
                                </div>

                                <div id="boxFooter">
                                 Footer
                                </div>
                            </div>
                            
                            </td>
                            <td>
                               <div id="box">
                                <div id="Orboxhead">
                                    <div id="boxTLtarc"> <img src="Images/table_top_Leftarc.gif" /></div>
                                    <div id="boxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div id="boxheadText"> Testimonials </div>
                                </div>
                                <div id="boxsubhead">
                                    By Peter England
                                </div>
                                <div id="boxContent">
                                    The content goes here... The content goes here... The content goes here... The content goes here..1.
                                    The content goes here... The content goes here... The content goes here... The content goes here..2.  
                                    The content goes here... The content goes here... The content goes here... The content goes here..3. 
                                    
                                    
                                </div>

                                <div id="boxFooter">
                                 Footer
                                </div>
                            </div>
                            
                            </td>
                             <%--   <td>
                                    cccc</td>--%>
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
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                    <div id="footer">
                    <table border="0" cellpadding="0" cellspacing="0" width="96%">
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                        <div class="indentmenuDown">
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
                    <td>&nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right" class="font_forgotPwd">&nbsp;@Copyrights GlobalSurf Sdh bhd.2010 All Rights Reserved</td>
                    <td>&nbsp;</td>
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
