<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="CustomerLogins.aspx.cs" Inherits="CustomerLogins" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">

<script language="javascript" type="text/javascript">


    function fnOpenFPwindow(url,width,height) {
        //var width = "400";
        //var height = "300";
        
        
        var parameters = "width=" + width + ",height=" + height;
        //alert(parameters);
        parameters = parameters + "resizable=no,titlebar=no,locationbar=no, scrollbars=no,dependent=yes,left=150,top=150";
        window.open(url, "winFP", parameters);
    
    
    }

        function openNewWin(url) {

            var oWin = window.open(url, 'mynewwin','_blank','width=600,height=600,toolbar=1');

            if (oWin == null || typeof (oWin) == "undefined") {
                alert('you have a pop blocker enabled.  Please allows pop ups for this site.');
                oWin.focus();
                return true;
            } else {
                alert('NO NO popup blocked');
                oWin.close();
                return false;

            }

        }

        function SetTarget() {
            document.forms[0].target = "_blank";
        }


        function CheckKeyCode(e) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 8)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 0)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }


        function CheckMAS_Login(source, arguments) {
            // even number?

            //alert(arguments.Value);


            var tmpValue = arguments.Value;
            tmpValue = tmpValue.substring(0, 2);
            //alert(tmpValue);
            
            if (tmpValue == 60)
                arguments.IsValid = true;
            else
                arguments.IsValid = false;
        }





        function CheckSING_Login(source, arguments) {
            // even number?

            //alert(arguments.Value);

            var tmpValue = arguments.Value;
            tmpValue = tmpValue.substring(0, 2);
            //alert(tmpValue);

            if (tmpValue == 65)
                arguments.IsValid = true;
            else
                arguments.IsValid = false;
        }
        
</script>




    <table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> Customer </td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> Login </td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/login_sidepanel.jpg" />
    
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
    <%--</form>--%>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">&nbsp;</td>
<td width="1%">&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>

 <div id="Div1" class="loginCss1"  style="height:80px;">
     &nbsp;<img src="Images/flag_malaysia.gif" /></div>

 <div id="Div2"  class="loginCss2"  style="height:80px;">
     &nbsp;<img src="Images/flag_singapore.gif" /></div>
 
  <div id="Div3"  class="loginCss3"  style="height:80px;">
      &nbsp;<img src="Images/flag_indonesia_small.jpg" /></div>
 
</td>
<td>&nbsp;</td>
</tr>

<tr>
<td>&nbsp;</td>
<td>
 
  <table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
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
                                    <asp:Literal ID="Ltr1MalaysiaSMS" Text="1 MalaysiaSMS" runat="server"></asp:Literal> </div>
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
                    <asp:TextBox ID="Muser"  CssClass="loginTextBox100" MaxLength="11" runat="server" ValidationGroup="Vg1MayLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="Vg1MayLogin" 
                            Display="Dynamic" ControlToValidate="Muser" CssClass="font_12Msg_Error" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="valPassword" runat="server" 
                               ControlToValidate="Muser" ValidationGroup="Vg1MayLogin" Display="Dynamic" 
                               ErrorMessage="<br/> * Invalid Mobile No. Login" CssClass="font_12Msg_Error" 
                               ValidationExpression=".{11}.*" />
                        <asp:CustomValidator ID="CustomValidator1" runat="server"  CssClass="font_12Msg_Error" 
                         ErrorMessage="Should start with 60 only" ControlToValidate="Muser" Display="Dynamic"
                          ClientValidationFunction="CheckMAS_Login" ></asp:CustomValidator>
                               
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="Mpwd" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" ValidationGroup="Vg1MayLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                      <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="Vg1MayLogin" 
                            ControlToValidate="Mpwd" CssClass="font_12Msg_Error" Display="Dynamic" 
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
                    
                    <tr  style="height:5px;">
                    <td colspan="3">&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <asp:Button CssClass="stdButtonLogin" ID="btnSignIn_1Malaysia" runat="server"  
                            Height="26px" Text="Sign In" OnClick="btnSignIn_1Malaysia_Click" OnClientClick="aspnetForm.target ='_blank';"
                            
                            Width="56px" 
                            ValidationGroup="Vg1MayLogin" />
                          </td>
                    <td>&nbsp;</td>
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
                                        <asp:Literal ID="Ltr1Singapore" Text="1 SingaporeSMS" runat="server"></asp:Literal></div>
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
                    <asp:TextBox ID="txtSing_Login" MaxLength="10"  CssClass="loginTextBox100" runat="server" ValidationGroup="Vg1SingLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="Vg1SingLogin" 
                            ControlToValidate="txtSing_Login" CssClass="font_12Msg_Error" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                               ControlToValidate="txtSing_Login" ValidationGroup="Vg1SingLogin" Display="Dynamic"
                               ErrorMessage="<br/> * Invalid Mobile No. Login" CssClass="font_12Msg_Error" 
                               ValidationExpression=".{10}.*" />
                                <asp:CustomValidator ID="CustomValidator2" runat="server"  CssClass="font_12Msg_Error" 
                         ErrorMessage="Should start with 65 only" ControlToValidate="txtSing_Login" Display="Dynamic"
                          ClientValidationFunction="CheckSING_Login" ></asp:CustomValidator>
                               
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtSing_Password" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" ValidationGroup="Vg1SingLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="Vg1SingLogin" 
                            Display="Dynamic" ControlToValidate="txtSing_Password" 
                            CssClass="font_12Msg_Error" SetFocusOnError="True"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr style="height:5px;">
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                    
                     <tr  style="height:5px;">
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr  style="height:5px;">
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <asp:Button CssClass="stdButtonLogin" ID="btnSignIn_1Singapore" runat="server" 
                            Height="26px" Text="Sign In" 
                            Width="56px" onclick="btnSignIn_1Singapore_Click"  OnClientClick="aspnetForm.target ='_blank';" ValidationGroup="Vg1SingLogin" />
                          </td>
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
                                        <asp:Literal ID="Literal1" Text="1 IndonesiaSMS" runat="server"></asp:Literal></div>
                          </div>   
                        </td>
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
                    <td align="center" class="HomePageHeaderFont">
                        <asp:Literal ID="ltrComing" Text="Coming" runat="server"></asp:Literal>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center" class="HomePageHeaderFont"><asp:Literal ID="ltrSoon"  Text="Soon" runat="server"></asp:Literal></td>
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
              
                    
                    <%--</form>--%>
                    
                      <tr style="height:5px;">
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              
                    
              
                    
                      <tr style="height:5px;">
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              
                    
              
                    
                      </table>
         
        </div>
        
      </td>
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
<td>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
  <td>

        
        
        <div id="divPremiumSMS_IOD"  class="loginCss2">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <td colspan="3">
                         <div class="LogoBoxheadOren">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal6" Text="PremiumSMS IOD" runat="server"></asp:Literal></div>
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
                    <asp:TextBox ID="txtPre_IODlogin"  CssClass="loginTextBox100" MaxLength="13" 
                            runat="server" ValidationGroup="VgIODLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="VgIODLogin" 
                            Display="Dynamic" ControlToValidate="txtPre_IODlogin" CssClass="font_12Msg_Error" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                              
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtPre_IODPwd" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgIODLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                        <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="VgIODLogin" 
                            ControlToValidate="txtPre_IODPwd" CssClass="font_12Msg_Error" Display="Dynamic" 
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
                            Height="26px" Text="Sign In" OnClientClick="aspnetForm.target ='_blank';"
                            
                            Width="56px" 
                            ValidationGroup="VgIODLogin" onclick="BtnPreIODLogin_Click" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--<asp:Literal ID="Literal7" runat="server"></asp:Literal>--%>
                        <%--<asp:HyperLink ID="HyperLink2" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl="~/forgotPwd_Premium.aspx?PageType=IOD" Target="_blank">[Forgot Password]</asp:HyperLink>--%>
                       <a href="#" onclick='javascript: return fnOpenFPwindow("forgotPwd_Premium.aspx?PageType=IOD",700,250);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    

                    
                      </table>
         
        </div>
        
        
        <div id="divPremiumSMS_Subscription"  class="loginCss2">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <td colspan="3">
                         <div class="LogoBoxheadOren">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal2" Text="PremiumSMS Subscription" runat="server"></asp:Literal></div>
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
                    <asp:TextBox ID="txtPre_SmsSubLogin"  CssClass="loginTextBox100" MaxLength="11" 
                            runat="server" ValidationGroup="VgSMSSubLogin" 
                            ></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="VgSMSSubLogin" 
                            Display="Dynamic" ControlToValidate="txtPre_SmsSubLogin" CssClass="font_12Msg_Error" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                               
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtPre_SmsSubPwd" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgSMSSubLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                        <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="VgSMSSubLogin" 
                            ControlToValidate="txtPre_SmsSubLogin" CssClass="font_12Msg_Error" Display="Dynamic" 
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
                        <asp:Button CssClass="stdButtonLogin" ID="BtnPreSMSSubLogin" runat="server"  
                            Height="26px" Text="Sign In" OnClientClick="aspnetForm.target ='_blank';"
                            
                            Width="56px" 
                            ValidationGroup="VgSMSSubLogin" onclick="BtnPreSMSSubLogin_Click" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--<asp:Literal ID="Literal3" runat="server"></asp:Literal>--%>
                       <%-- <asp:HyperLink ID="HyperLink3" CssClass="links_ForgotPwd" runat="server" Target="_blank"  
                            NavigateUrl="~/forgotPwd_Premium.aspx?PageType=SUBSCRIBE">[Forgot Password]</asp:HyperLink>--%>
                            
                       <a href="#" onclick='javascript: return fnOpenFPwindow("forgotPwd_Premium.aspx?PageType=SUBSCRIBE",700,250);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
              
                    

                    
                      </table>
         
        </div>
        
        
        <div id="div3wayAbest_Corporate"  class="loginCss2">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <td colspan="3">
                         <div class="LogoBoxheadOren">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal5" Text="3way Abest Corporate" runat="server"></asp:Literal></div>
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
                    <asp:TextBox ID="txtPre_3wayLogin"  CssClass="loginTextBox100" MaxLength="13" 
                            runat="server" ValidationGroup="Vg3WayLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                            ErrorMessage="Please enter LoginID" ValidationGroup="Vg3WayLogin" 
                            Display="Dynamic" ControlToValidate="txtPre_3wayLogin" CssClass="font_12Msg_Error" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                          
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtPre_3wayPwd" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="Vg3WayLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                        <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                            ErrorMessage="Please enter password" ValidationGroup="Vg3WayLogin" 
                            ControlToValidate="txtPre_3wayPwd" CssClass="font_12Msg_Error" Display="Dynamic" 
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
                        <asp:Button CssClass="stdButtonLogin" ID="Btn3WayLogin" runat="server"  
                            Height="26px" Text="Sign In" OnClientClick="aspnetForm.target ='_blank';"
                            
                            Width="56px" 
                            ValidationGroup="Vg3WayLogin" onclick="Btn3WayLogin_Click" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--<asp:Literal ID="Literal4" runat="server"></asp:Literal>--%>
           <%-- <asp:HyperLink ID="HyperLink4" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl="~/forgotPwd_Premium.aspx?PageType=3WAY">[Forgot Password]</asp:HyperLink>--%>
                            
                        <a href="#" onclick='javascript: return fnOpenFPwindow("forgotPwd_Premium.aspx?PageType=3WAY",700,250);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>
                            
                        </td>
                    <td>&nbsp;</td>
                    </tr>
              
                    

                    
                      </table>
         
        </div>
      </td>
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
<td>
 <div id="Div4" class="loginCss1"  style="height:80px;">
     &nbsp;<img alt="smlogin" src="Images/SmsLogin_head.jpg" 
         style="width: 122px; height: 80px" /></div>

 <div id="Div5"  class="loginCss2"  style="height:80px;">
     &nbsp;<img src="Images/flag_admin.gif" /></div>
 
    <%--</form>--%>
          
          </td>
<td>&nbsp;</td>
</tr>


<tr>
<td>&nbsp;</td>
<td>
        
        

  <table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
  <td>

        <div id="dvSMSLogin" class="loginCss2">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                    
                    <td colspan="3">
                    
                        <%--</form>--%>
                        
                        <div class="LogoBoxheadBlue">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="LtrSMSAdminLogin" Text="SMS Login" runat="server"></asp:Literal></div>
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
                    <asp:TextBox ID="txtLogin_SMS" MaxLength="13" CssClass="loginTextBox100" runat="server" 
                            ValidationGroup="VgSMSLogin"></asp:TextBox>
                            </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ErrorMessage="Please enter LoginID"  CssClass="font_12Msg_Error" Display="Dynamic"
                            ControlToValidate="txtLogin_SMS" SetFocusOnError="True" 
                            ValidationGroup="VgSMSLogin"></asp:RequiredFieldValidator>
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                               ControlToValidate="txtLogin_SMS" ValidationGroup="VgSMSLogin" Display="Dynamic" 
                               ErrorMessage="<br/> * Invalid Mobile No. Login" CssClass="font_12Msg_Error" 
                               ValidationExpression=".{10,13}.*" />
                            
                            
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                     <asp:TextBox ID="txtPassword_SMS" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgSMSLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ErrorMessage="Please enter password" CssClass="font_12Msg_Error" 
                            ControlToValidate="txtPassword_SMS" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgSMSLogin"></asp:RequiredFieldValidator>
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
                        <asp:Button CssClass="stdButtonLogin" ID="btnSignIn_SMS" runat="server" 
                            Height="26px" Text="Sign In"  OnClientClick="aspnetForm.target ='_blank';"  
                            Width="56px" OnClick="btnSignIn_SMS_Click" ValidationGroup="VgSMSLogin" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <%--</form>--%>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--<asp:Literal ID="LtrErrMessage0" Text="" runat="server"></asp:Literal>--%>
                        <%--<asp:HyperLink ID="HyperLink5" CssClass="links_ForgotPwd" runat="server">[Forgot Password]</asp:HyperLink>--%>
                        
                        <a href="#" onclick='javascript: return fnOpenFPwindow("ForgotPwd_SmsLogin.htm",800,360);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>
                        
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
         
        </div>
        
        <div id="dvAdminLogin" class="loginCss1">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                    
                    <td colspan="3">
                    
                        <%--</form>--%>
                        
                        <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="LtrAdminLogin" Text="Admin Login" runat="server"></asp:Literal></div>
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
                     <asp:TextBox ID="txtLoginID"  CssClass="loginTextBox100" runat="server" 
                            ValidationGroup="VgMainLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Please enter LoginID"  CssClass="font_12Msg_Error" 
                            ControlToValidate="txtLoginID" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgMainLogin"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password
                    <asp:TextBox ID="txtPassword" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgMainLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Please enter password" CssClass="font_12Msg_Error" 
                            ControlToValidate="txtPassword" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgMainLogin"></asp:RequiredFieldValidator>
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
                            Width="56px" onclick="btnSignIn_Click" ValidationGroup="VgMainLogin" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <%--</form>--%>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <asp:Literal ID="LtrErrMessage" Text="" runat="server"></asp:Literal>
                        <asp:HyperLink ID="HyperLink6" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl="~/UserForgotPassword.aspx">[Forgot Password]</asp:HyperLink>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
         
        </div>
        
        
        <%--</form>--%>
        
      </td>
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


</table>

<%--</form>--%>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

