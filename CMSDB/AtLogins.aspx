<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AtLogins.aspx.cs" Inherits="AtLogins" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="background-image: url('Images/loginbox/misc142.jpg');">
<head runat="server">
    <title>Central Logins - 1SmsBusiness</title>
    <link href="App_Themes/Common/LoginStyles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">

        function SetTarget() {
            document.forms[0].target = "_blank";
        }
    </script>
    
    </head>
<body >
    <form id="form1" runat="server">
    <div>
    
        <table width="100%" cellpadding="0" cellspacing="0" >
            <tr>
                <td width="5%">
                    &nbsp;</td>
                <td width="90%">
                    &nbsp;</td>
                <td width="5%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <div id="topWrapper" style="padding-left:50px; float:left;">
                    <div id="logo">
                        <img src="ImageRepository/LogoTemplate2.jpg" />
                    </div>
                    <div id="HeaderName" style="float:left;">
                    
                    </div>
                    </div>
                    &nbsp;&nbsp; <font class="HeaderMainFont">1</font><font class="HeaderMainFont1">SMS</font><font class="HeaderMainFont">Business</font>                   
                                &nbsp;&nbsp; <font class="HeaderSubFont" style="vertical-align:bottom;">Central Login</font></td>
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
                <td>
                    &nbsp;</td>
                <td>
        <div id="dv1Malaysia"  class="loginCss2">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--</form>--%>
                        <td colspan="3">
                        <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Ltr1MalaysiaSMS" Text="SMS Business Login" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">Login&nbsp;ID&nbsp;&nbsp;
                    <asp:TextBox ID="txtBizLoginID"  CssClass="loginTextBox100" MaxLength="11" 
                            runat="server" ValidationGroup="vgBizLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="vgBizLogin" 
                            Display="Dynamic" ControlToValidate="txtBizLoginID" CssClass="font_12Msg_Error" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                               
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtBizPassword" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="vgBizLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                      <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="vgBizLogin" 
                            ControlToValidate="txtBizPassword" CssClass="font_12Msg_Error" Display="Dynamic" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
      <%--              <tr style="height:5px;">
                    <td>&nbsp;</td>
                     <td  class="loginfont12">Language
                        <asp:DropDownList ID="ddlLanguage" CssClass="stdDropDown1" Width="120px" runat="server">
                            <asp:ListItem Value="E">English</asp:ListItem>
                            <asp:ListItem Value="M">Bahasa Melayu</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    <td>&nbsp;</td>
                    </tr>--%>
                    
                    <tr style="height:5px;">
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <asp:Button CssClass="stdButtonLogin" ID="btnBizLogin" runat="server"  
                            Height="26px" Text="Sign In" 
                            
                            Width="56px" 
                            ValidationGroup="vgBizLogin" onclick="btnBizLogin_Click" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:5px;">
                    <td></td>
                    <td class="font_11Msg_Error"><asp:Literal ID="LtrErrMessage" Text="" runat="server"></asp:Literal></td>
                    <td></td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                       <%-- <asp:Literal ID="LtrErrMsg_Malaysia" runat="server"></asp:Literal>--%>
                        <%--<asp:HyperLink ID="HypFgtPwd_Malaysia" CssClass="links_ForgotPwd" 
                            runat="server"  NavigateUrl="~/ForgotPwd_1MalaysiaSMS.htm" Target="_blank">[Forgot Password]</asp:HyperLink>--%>
                         <%--<a id="fp" href='javascript: return fnOpenFPwindow("ForgotPwd_1MalaysiaSMS.htm");' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>   --%>
                         <a href="#" onclick='javascript: return fnOpenFPwindow("ForgotPwd_1MalaysiaSMS.htm",492,480);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>   
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
         
        </div>
        
        
        <div id="dv1SingaPore"  class="loginCss3">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <td colspan="3">
                         <div class="LogoBoxheadBlue">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Ltr1Singapore" Text="SMS Login" runat="server"></asp:Literal></div>
                          </div>   
                        </td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">Login&nbsp;ID&nbsp;&nbsp;
                    <asp:TextBox ID="txtSMSloginID" MaxLength="15"  CssClass="loginTextBox100" 
                            runat="server" ValidationGroup="vgSmsLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="vgSmsLogin" 
                            ControlToValidate="txtSMSloginID" CssClass="font_12Msg_Error" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                               
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtSMSpassword" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="vgSmsLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="vgSmsLogin" 
                            Display="Dynamic" ControlToValidate="txtSMSpassword" 
                            CssClass="font_12Msg_Error" SetFocusOnError="True"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr style="height:5px;">
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <asp:Button CssClass="stdButtonLogin" ID="btnSMSlogin" runat="server" 
                            Height="26px" Text="Sign In" 
                            Width="56px" OnClientClick="form1.target ='_blank';"  
                            ValidationGroup="vgSmsLogin" onclick="btnSMSlogin_Click" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td class="font_11Msg_Error"><asp:Literal ID="Literal2" Text="" runat="server"></asp:Literal></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--<asp:Literal ID="LtrMsg_Singapore" runat="server"></asp:Literal>--%>
                        <%--<asp:HyperLink ID="HyperLink1" CssClass="links_ForgotPwd" runat="server">[Forgot Password]</asp:HyperLink>--%>
                        <a href="#" onclick='javascript: return fnOpenFPwindow("ForgotPwd_1SingaporeSMS.htm",570,460);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>   
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    
                    
                      </table>
         
        </div>
        
        
        <div id="dv1Indonesia"  class="loginCss1">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <td colspan="3">
                         <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal1" Text="Web Portal Login" runat="server"></asp:Literal></div>
                          </div>   
                        </td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">Login&nbsp;ID&nbsp;&nbsp;
                    <asp:TextBox ID="txtWebLoginID" MaxLength="20"  CssClass="loginTextBox100" 
                            runat="server" ValidationGroup="vgWebLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="vgWebLogin" 
                            ControlToValidate="txtWebLoginID" CssClass="font_12Msg_Error" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                               
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtWebPassword" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="vgWebLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="vgWebLogin" 
                            Display="Dynamic" ControlToValidate="txtWebPassword" 
                            CssClass="font_12Msg_Error" SetFocusOnError="True"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr style="height:5px;">
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <asp:Button CssClass="stdButtonLogin" ID="btnWebLogin" runat="server" 
                            Height="26px" Text="Sign In" 
                            Width="56px" 
                            ValidationGroup="vgWebLogin" onclick="btnWebLogin_Click" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    
                    <%--</form>--%>
                    
                                          
                <tr>
                    <td>&nbsp;</td>
                    <td class="font_11Msg_Error"><asp:Literal ID="LtrErrMessage3" Text="" runat="server"></asp:Literal></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    
              <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--<asp:Literal ID="LtrMsg_Singapore" runat="server"></asp:Literal>--%>
                        <%--<asp:HyperLink ID="HyperLink1" CssClass="links_ForgotPwd" runat="server">[Forgot Password]</asp:HyperLink>--%>
                        <a href="#" onclick='javascript: return fnOpenFPwindow("ForgotPwd_1SingaporeSMS.htm",570,460);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>   
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    
              <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
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
            <tr>
                <td>
                    &nbsp;</td>
                <td>
        
        <div id="Div1"  class="loginCss2">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--</form>--%>
                        <td colspan="3">
                        <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                    1SMSBusiness 
                                    </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">Login&nbsp;ID&nbsp;&nbsp;
                        <input id="txtBizLoginID" type="text" class="loginTextBox100"/></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                        <input id="txtBizPassword" type="password" class="loginTextBox100" /></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                      <td>&nbsp;</td>
                    <td>
                        
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:5px;">
                    <td></td>
                    <td>&nbsp;</td>
                    <td></td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                          <input id="BtnBizSMSLogin" type="button" value="Login In" class="stdButtonLogin" /></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:5px;">
                    <td></td>
                    <td class="font_11Msg_Error">&nbsp;</td>
                    <td></td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                         <a href="#" onclick='javascript: return fnOpenFPwindow("ForgotPwd_1MalaysiaSMS.htm",492,480);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>   
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
         </div>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
