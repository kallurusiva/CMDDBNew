<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestLogin123.aspx.cs" Inherits="TestLogin123" %>

<%@ Register src="TopMostMenu.ascx" tagname="TopMostMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  runat="server" id="Template1_Css" name="Template1_Css" href="App_Themes/Common/CommonStyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://download.skype.com/share/skypebuttons/js/skypeCheck.js"></script>
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
  
    
    <script language="javascript" type="text/javascript">
        var vname = "dont know";
        function testquote(vname) {

            var towtruckdist = "<tr><td>" + dist + "</td><td>" + vname + "</td><td><input type='button' name='Map' value='Map' onclick='alert(''" + vname + "'');' /></td></tr>";
            //alert('this is an example - hello O\'Neil');
            
            
            
            
        }

        
        function CheckKeyCode_AlphaNum(e) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 8) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 97 && e.keyCode <= 122)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 0) || (e.charCode >= 65 && e.charCode <= 90) || (e.charCode >= 97 && e.charCode <= 122)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    
    </script>
 


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
              <td  width="200px" style="height:66px"> 
                    <div id="dvLogoImage" runat="server">
                        <img alt="logo img" class="divCssLogoImage"  src="Images/client/LOGO_GS2.jpg" 
                        style="width: 140px; height: 66px" />
               </div>
                <div id="dvLogoText" runat="server">
                        <asp:Literal ID="LtrLogoText" runat="server"></asp:Literal>
                    </div>
               
               </td>
              <td valign="bottom">
              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td width="20px">&nbsp;</td>
                <td align="right">
                    <uc1:TopMostMenu ID="TopMostMenu1" runat="server" />
                    &nbsp;
                   
                </td>
                <td  width="20px">&nbsp;</td>
                </tr>
                <tr>
                <td width="20px">&nbsp;</td>
                <td>&nbsp;</td>
                <td  width="20px">&nbsp;</td>
                </tr>
                <tr style="height: 50px">
                <td align="left" valign="top" class="bkgTopLineMenu">
                    <img alt="topleftarc" src="Images/table_top_Leftarc.gif" 
                        style="width: 10px; height: 20px" /></td>
                <td class="bkgTopLineMenu">
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
                <td align="right" valign="top"  class="bkgTopLineMenu">
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
                        <td class="font_Title1">
                            <asp:Literal ID="ltrLoginTitle" runat="server"></asp:Literal></td>
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
                        <asp:TextBox ID="txtLoginID" MaxLength="20"  CssClass="stdTextField" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtLoginID" runat="server" ErrorMessage="<br/>Enter Login Name." CssClass="font_11Msg_Error"></asp:RequiredFieldValidator>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtPassword" runat="server" ErrorMessage="<br/>Enter Password." CssClass="font_11Msg_Error"></asp:RequiredFieldValidator>
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
                    <td align="right">
                    <a href="UserForgotPassword.aspx" class="links_ForgotPwd">Forgot password?</a>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td class="font_11Msg_Error">
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
                                <%--<textarea id="AreaNewContent" class="sideBoxTextArea" runat="server">
                                   &nbsp;
                                </textarea>--%>
                                <asp:Label ID="lblNewsContent" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="sideBoxFooter">
                                <asp:HyperLink ID="HyperLink6" runat="server" CssClass="links_TopLine" NavigateUrl="UserNews.aspx">Read more..</asp:HyperLink>
                                </div>
                                <div class="Boxblank">
                                 &nbsp;
       <%--                         </div>
                                   <div class="sideBoxsubhead" id="dvRecNewsHead2" runat="server">
                                    05 Aug, 2010
                                </div>--%>
                  <%--              <div class="sideBoxContent" id="dvRecNewsContent2" runat="server">
                                 <textarea id="AreaNewContent2" class="sideBoxTextArea" runat="server">
                                   &nbsp;                                   
                                 </textarea>
                                </div>--%>
                                <%-- <div class="sideBoxFooter">
                                  <asp:HyperLink ID="HyperLink5" runat="server" CssClass="links_TopLine" NavigateUrl="UserNews.aspx">Read more..</asp:HyperLink>
                                 </div>
                                 <div class="Boxblank">&nbsp;</div>--%>
                            </div>
                            
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
                                    <%--<textarea id="AreaEvtContent" class="sideBoxTextArea" runat="server"></textarea>--%>
                                    <asp:Label ID="lblEventContent" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="sideBoxFooter"> 
                                    <asp:HyperLink ID="HyperLink3" CssClass="links_TopLine" runat="server" NavigateUrl="UserEvents.aspx">Read more..</asp:HyperLink>
                                </div>
                                <%--<div class="Boxblank">&nbsp;</div>
                                   <div class="sideBoxsubhead" id="dvEventsHead2" runat="server">
                                    05 Aug, 2010
                                </div>
                                <div class="sideBoxContent" id="dvEventsContent2" runat="server">
                                   <textarea id="AreaEvtContent2" class="sideBoxTextArea" runat="server"></textarea> 
                                </div>
                                <div class="sideBoxFooter"> 
                                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="links_TopLine" NavigateUrl="UserEvents.aspx">Read more..</asp:HyperLink>
                                </div>--%>
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
                <%-- <tr>
                    <td>&nbsp;</td>
                </tr>--%>
   
              <%--   <tr>
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
                </tr>--%>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                    <div class="sideBox">
                                <div class="sideBoxhead">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="LtrFollowUs" Text="Follow us on" runat="server"></asp:Literal> </div>
                                </div>
                                <div class="sideBoxContent">
                                  <div class="CssFollowUs" id="dvFollowUs" runat="server">
                                    
                                  </div> 
                                   <a href="UserFreeSMS.aspx" ><img border="0" alt="register" src="Images/client/Register.jpg"/></a>
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
                        <div class="sideBoxhead">
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
                    
                    
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                </tr>

                
                <tr>
                    <td align="center">
                        <a href="UserFreeSMS.aspx">
                            <img border="0" alt="reg" src="Images/client/Register_old.jpg" 
                            style="width: 200px; height: 50px" /> </a></td>
                </tr>

                </table>
                
                
                
                
                </div>
                
                <div id="ContentMid">
                
                <table border="0" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                <td>&nbsp; </td>
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
                <td  background="Images/Client/1waybkg.jpg">
                
                    <img alt="a" src="Images/1waySMS_framworkbullet.gif" 
                        style="width: 26px; height: 38px" />
                     <img alt="a" src="Images/1waySMS_framworkhead.gif" style="width: 215px; height: 38px" /> &nbsp;
                </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                <td class="font_EventDates11">&nbsp;<asp:Literal ID="ltrOurSmsFramework" runat="server"></asp:Literal>
                    &nbsp;</td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                
                
                <tr>
                <td align="center">
                    <img alt="a" src="Images/1wayframe.jpg" style="width: 450px; height: 202px" /></td>
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
