<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionTimedOut_SmsLogin.aspx.cs" Inherits="SessionTimedOut_SmsLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Common/CommonStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
    <table border="0" cellpadding="0" cellspacing="0" width="80%" class="loginBkg">
                    <tr>
                        <%--</form>--%>
                        <td colspan="3">
                        <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Ltr1MalaysiaSMS" Text="Session Expired or Timed Out" 
                                            runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr>
                    <td width="5%">&nbsp;</td>
                    <td width="90%">&nbsp;</td>
                    <td width="5%">&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left">Your session timeout limit has reached.&nbsp; </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left" class="font_Title1">In order to continue please login again. </td>
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
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                        <td>&nbsp;<div id="divPremiumSMS_IOD"  class="loginCss2">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: solid 1px #D2CBCB;" class="loginCss1">
                    <tr>
                        <td colspan="3">
                         <div class="LogoBoxheadOren">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        Login</div>
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
                    <asp:TextBox ID="txtLoginID"  CssClass="loginTextBox100" MaxLength="13" 
                            runat="server" ValidationGroup="VgIODLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="txtLoginID" 
                            Display="Dynamic" ControlToValidate="txtLoginID" CssClass="font_12Msg_Error" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                              
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtPassword" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgIODLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                        <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="VgIODLogin" 
                            ControlToValidate="txtPassword" CssClass="font_12Msg_Error" Display="Dynamic" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                        <asp:Button CssClass="stdButtonLogin" ID="BtnPreIODLogin" runat="server"  
                            Height="26px" Text="Sign In" 
                            Width="56px" 
                            ValidationGroup="VgIODLogin" onclick="BtnPreIODLogin_Click" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right" class="font_11Msg_Error">
                 
                      
                        <asp:Literal ID="LtrErrMessage" runat="server"></asp:Literal>
                 
                      
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    

                    
                      </table>
         
        </div></td>
                        <td>
                            <img alt="login_sidehead" src="Images/login_sidehead.jpg" 
                                style="width: 180px; height: 176px" /></td>
                        <td>&nbsp;</td>
                        
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
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                      </table>
    
    
    </div>
    </form>
</body>
</html>
