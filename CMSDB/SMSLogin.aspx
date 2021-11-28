<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" maintainscrollpositiononpostback="true" CodeFile="SMSLogin.aspx.cs" inherits="SMSLogin" enableEventValidation="false" viewStateEncryptionMode="Never" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
.loginDivCss1       {width: 290px; height: 270px; float: left; margin-left: 20px; margin-right: 20px;}
.loginDivCss2       {width: 240px; height: 200px; float: left; margin-left: 10px; margin-right: 10px;
                      vertical-align: top;}


        .style2
        {
            height: 26px;
        }
        
        .valError
        {
        	border : solid 1px red; font-size: 12px; padding:  5px 7px 5px 7px; color: Red;
        }
        .modalBackground
                {

                    background-color:#ffffdd;
                    filter:alpha(opacity=40);
                    opacity:0.5;
                    border-width:1px;
                    border-style:solid;
                    border-color:#CCCCCC;
                    padding:3px;
                    position:absolute;
                }
                .modalInsideBackground
                {
                    background-color:#efefef;
                    border: 2px solid #ccda35;
                    color : #333333;
                    padding: 20px 20px 20px 20px;
                    
                }
                
                .panelheightWidth {max-height:70%; max-width:70%;}

        .modalPopup
    {
        background-color: #FFFFFF;
        width: 50%;
        border: 3px solid #0DA9D0;
        border-radius: 12px;
        padding:0
      
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
        border-top-left-radius: 6px;
        border-top-right-radius: 6px;
    }
    .modalPopup .body
    {
        min-height: 100px;
        line-height: 30px;
        text-align: center;
        font-weight: bold;

    }
    .modalPopup .footer
    {
        padding: 6px;
    }
    .modalPopup .yes, .modalPopup .no
    {
        height: 25px;
        color: White;
        line-height: 25px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        border-radius: 4px;
    }
    .modalPopup .yes
    {
        background-color: #2FBDF1;
        border: 1px solid #0DA9D0;
    }
    .modalPopup .no
    {
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }

        .style3
        {
            height: 19px;
        }

        .style4
        {
            height: 128px;
        }
        
        .inputTextBoxcss
        {
        	color:#474444; font-size: 9pt; font-family:Verdana,Tahoma,Helvetica,Arial,Trebuchet Ms; border: 1px solid #CCCCCC; height:20px;
                		  padding-left:5px; padding-top:2px; vertical-align:baseline; background-color: #FFF;
                		  -webkit-border-radius: 5px;
						  -moz-border-radius: 5px;
						  border-radius: 5px;
        }
        
        .links_Register		{COLOR: #FF320A; FONT-FAMILY: "Oswald","sans-serif","Lucida Console", "Trebuchet MS"; FONT-SIZE: 12pt;
               		  FONT-WEIGHT: normal; TEXT-DECORATION: underline;  cursor: pointer;
               		  text-shadow: 1px 1px 0 rgba(256,256,256,1.0);}
A.links_Register:hover	{COLOR: #E88F4D; FONT-FAMILY: "Oswald","sans-serif","Lucida Console", "Trebuchet MS"; FONT-SIZE: 14pt; TEXT-DECORATION: none;
                      	 text-shadow: 1px 1px 0 rgba(256,256,256,1.0);}
        
        
        .awesome, .awesome:visited {
	background: #222 url(alert-overlay.png) repeat-x; 
	display: inline-block; 
	padding: 9px 15px 9px 15px; 
	color: #fff; 
	font-weight: bold;
	text-decoration: none;

	-moz-border-radius: 5px; 
	-webkit-border-radius: 5px;
	-moz-box-shadow: 0 1px 3px rgba(0,0,0,0.5);
	-webkit-box-shadow: 0 1px 3px rgba(0,0,0,0.5);
	text-shadow: 0 -1px 1px rgba(0,0,0,0.25);
	position: relative;
	cursor: pointer;
            top: 0px;
            left: 4px;
             letter-spacing: 1px;
        }
    .awesome:hover							{ background-color: #111; color: #fff; }
	.awesome:active							{ top: 1px; }
	.large.awesome, .large.awesome:visited 			{ font-size: 12px; padding: 6px 10px 6px 10px; }    
    .blue.awesome, .blue.awesome:visited		{ background-color: #2daebf; }
	.blue.awesome:hover							{ background-color: #007d9a; }
	
	
	.red.awesome, .red.awesome:visited		{ background-color: #FB0000; }
	.red.awesome:hover						{ background-color: #9A001D; }


        .ContentRight 
{
width: 98% !important;   
float: left;
padding: 10px; 
}




        .style5
        {
            width: 169px;
        }
        



    </style>
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css'>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">

<script language="javascript" type="text/javascript">

/*
------------------------------------------------------------------------------------------------------
      Comments 
------------------------------------------------------------------------------------------------------
    - Added on 20-SEP-2012
    > SMS login page name changed to Customer Login. 
    > This page to contain WebPortal Login and Biz Partner Login , besides SMS login.
    


------------------------------------------------------------------------------------------------------


*/



    function fnOpenFPwindowXX(url) {
        var width = "600";
        var height = "500";
        
        
        var parameters = "width=" + width + ",height=" + height;
        //alert(parameters);
        parameters = parameters + "titlebar=no,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,dependent=yes,left=150,top=150";
        window.open(url, "winFP", parameters);


    }

    function fnOpenFPwindow(url) {
        //var w = "800";
        //var h = "600";
        var title = 'smsreg';
        //alert(screen.width + '|' + screen.height);
        var w = screen.width - 300;
        var h = screen.height - 200;
        
        var left = (screen.width / 2) - (w / 2);
        var top = (screen.height / 2) - (h / 2);
        
        return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
     }

        function openNewWin(url) {

            var oWin = window.open(url, 'mynewwin','_blank','width=600,height=600,toolbar=1');

            if (oWin == null || typeof (oWin) == "undefined") {
                alert('you have a pop blocker enabled.  Please allows pop ups for this site.');
                oWin.focus();
                return true;
            } else {
//                alert('NO popup blocked');
//                oWin.close();
//                return false;

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
<td align="center" class="subHeaderMenuFontGrad"> &nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> Logins </td>
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
    <%--<div>
        <asp:Button ID="ButtonHidden" runat="server" Text="Show PopUp" 
            onclick="ButtonHidden_Click" />
        <asp:ModalPopupExtender ID="HiddenField1_ModalPopupExtender" runat="server" TargetControlID="ButtonHidden" PopupControlID="panelBoard" CancelControlID="BtnSubmit" BackgroundCssClass="modalBackground"/>
           <asp:AnimationExtender ID="AnimationExtender1" runat="server"  TargetControlID="panelBoard">
            <Animations>
              <OnLoad>
                 <Parallel AnimationTarget="panelBoard" Fps="30">
                    <FadeIn Duration=".5" Fps="20" />
                  </Parallel>
               </OnLoad>
          </Animations>
           </asp:AnimationExtender>
           
        <asp:Panel ID="panelBoard"  runat="server" CssClass="modalInsideBackground panelheightWidth" Width="900px"> 

        <div class="bgTheme2" style="height:28px;line-height:27px">
        <asp:Label ID="lblSME_Header" runat="server" Text="SME WEB Registration" 
                CssClass="txtBlackBLarge"/>
        <div style="float:right;"><asp:Button ID="BtnSubmit1" runat="server" Text="Close" CssClass="btSubmitSmall" />
           </div>
        </div>
        <br />
        <div style="border:1px solid #ccda35;padding:3px 3px 3px 3px ; background-color:#FFF; overflow: auto; max-height:90%;">
        <br />
            abcd<br />
        </div>
        <div style="height:5px;"></div>
        <div><asp:Button ID="BtnSubmit" runat="server" Text="Close" CssClass="btSubmitSmall" />
        </div></asp:Panel>
   </div>--%>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false">
    </asp:ToolkitScriptManager>
    </td>
<td width="1%">&nbsp;</td>
</tr>


<%--
<tr>
<td class="style3"></td>
<td class="style3"></td>
<td class="style3"></td>
</tr>
--%>

<tr>
<td class="style3">&nbsp;</td>
<td class="style3" align="center" style="clear: both;">
        
    <table width="100%" cellpadding="0" border="0" cellspacing="0" style="border: 0px dotted red;">
        <tr>
            <td width="1%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
              <td>
                &nbsp;</td>
            <td  width="1%">
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td colspan="5"  align="center" style="padding-left:10px;">

                <div >
        <div id="dvSMSLogin" runat="server" visible="false" class="loginDivCss1">
        
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
                    <td class="loginfont12" style=" padding-left: 30px;">
                        <asp:Literal ID="ltrSMS_Login" Text="Login" runat="server"></asp:Literal>&nbsp;&nbsp;
                    <asp:TextBox ID="txtLogin_SMS" MaxLength="16" CssClass="inputTextBoxcss" runat="server" 
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
                            
                          <%--</form>--%>
                            
                            
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12" style=" padding-left: 27px;"> <asp:Literal ID="ltrSMS_Password" Text="Password" runat="server"></asp:Literal>
                     <asp:TextBox ID="txtPassword_SMS" CssClass="inputTextBoxcss" runat="server" 
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
                    <td align="center" style="padding-left:50px">
                        <asp:Button CssClass="stdButtonLogin" ID="btnSignIn_SMS" runat="server" 
                            Height="26px" Text="Sign In"  OnClientClick="aspnetForm.target ='_blank';"  
                            Width="72px" OnClick="btnSignIn_SMS_Click" ValidationGroup="VgSMSLogin" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <%--</form>--%>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                       <%-- <asp:Literal  ID="ltrErrMsg_SMSsystem" Visible="false" Text="InValid LoginID or Password" runat="server"></asp:Literal>--%>
                        <asp:Label ID="lblErrMsg_SmsSystem" CssClass="valError" Text="InValid LoginID or Password" Visible="false" runat="server"></asp:Label>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--</form>--%> <%--</form>--%>
                        <asp:HyperLink ID="HypSMS_fp" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl="~/UserForgotPassword.aspx?fp=SMS">[Forgot Password]</asp:HyperLink>
                        <%--</form>--%>
                        
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   <%-- <tr>
                    <td>&nbsp;</td>
                    <td align="left" class="bkgTestTitle">
                        Alternate login url:</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center"  class="bkgTestTitle2">
                        <a href="http://www.1smslogin.com" target="_blank" class="links_TopLineRed">www.1smslogin.com</a></td>
                    <td>&nbsp;</td>
                    </tr>--%>
                    
                      </table>
         
        </div>
        
        
         <div id="dvWebPortal" runat="server" visible="false" class="loginDivCss1">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                    
                    <td colspan="3">
                    
                      
                        
                        <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="LtrAdminLogin" Text="WebPortal Login" runat="server"></asp:Literal></div>
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
                    <td class="loginfont12" style=" padding-left: 30px;"> <asp:Literal ID="ltrWeb_Login" Text="Login" runat="server"></asp:Literal>&nbsp;&nbsp;
                     <asp:TextBox ID="txtLoginID"  CssClass="inputTextBoxcss" runat="server" 
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
                    <td  class="loginfont12" style=" padding-left: 27px;"> <asp:Literal ID="ltrWEB_Password" Text="Password" runat="server"></asp:Literal>
                    <asp:TextBox ID="txtPassword" CssClass="inputTextBoxcss" runat="server" 
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
                    <td align="center"  style="padding-left:50px">
                        <asp:Button CssClass="stdButtonLogin" ID="btnWebPlogin" runat="server" 
                            Height="26px" Text="Sign In" 
                            Width="72px" onclick="btnWebPlogin_Click" ValidationGroup="VgMainLogin" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right" class="font_11Msg_Error">
                        <asp:Literal ID="LtrErrMessage" Text="" runat="server"></asp:Literal>
                        
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;
                        <asp:HyperLink ID="HypWEB_fp" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl="~/UserForgotPassword.aspx">[Forgot Password]</asp:HyperLink>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    <%--<tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        1</td>
                    <td>&nbsp;</td>
                    </tr>--%>
                    
                   
                    
                   <%-- <tr>
                    <td>&nbsp;</td>
                    <td  align="left" class="font_12BoldGrey">
                        2</td>
                    <td>&nbsp;</td>
                    </tr>--%>
                    
                   
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
         
        </div>
        
        
        <div id="dvPartnerLogin" runat="server" visible="false" class="loginDivCss1">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                    
                    <td colspan="3">
                    
                      
                        
                        <div class="LogoBoxheadOren">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal1" Text="Business Partner Login" runat="server"></asp:Literal></div>
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
                    <td class="loginfont12" style=" padding-left: 30px;"> <asp:Literal ID="ltrBIZ_Login" Text="Login" runat="server"></asp:Literal>&nbsp;&nbsp;
                     <asp:TextBox ID="txtBizLogin"  CssClass="inputTextBoxcss" runat="server" 
                            ValidationGroup="VgBizLogin"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="Please enter LoginID"  CssClass="font_12Msg_Error" 
                            ControlToValidate="txtBizLogin" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgBizLogin"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12" style=" padding-left: 27px;"> <asp:Literal ID="ltrBIZ_Password" Text="Password" runat="server"></asp:Literal>
                    <asp:TextBox ID="txtBizPassword" CssClass="inputTextBoxcss" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgBizLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ErrorMessage="Please enter password" CssClass="font_12Msg_Error" 
                            ControlToValidate="txtBizPassword" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgBizLogin"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    <tr style="height:5px;">
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                    
                      <tr>
                    <td class="style2"></td>
                    <td align="center"  style="padding-left:50px" class="style2">
                        <asp:Button CssClass="stdButtonLogin" ID="BtnBizLogin" runat="server" 
                            Height="26px" Text="Sign In" 
                            Width="72px" onclick="BtnBizLogin_Click" ValidationGroup="VgBizLogin" />
                          </td>
                    <td class="style2"></td>
                    </tr>
                    
                   
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right"  class="font_11Msg_Error">
                        <asp:Literal ID="ltrBizLoginError" Text="" runat="server"></asp:Literal>
                        
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;
                        <asp:HyperLink ID="HypBIZ_fp" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl="~/UserForgotPassword.aspx">[Forgot Password]</asp:HyperLink>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                  <%--  <tr>
                    <td>&nbsp;</td>
                    <td align="left" class="bkgTestTitle">
                        Alternate Login url:</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                   
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center"  class="bkgTestTitle2">
                    <a href="http://www.1smsbusinesslogin.com" target="_blank" class="links_TopLine">www.1smsbusinesslogin.com</a>
                        </td>
                    <td>&nbsp;</td>
                    </tr>--%>
                    
                      </table>
         
        </div>
        </div>
            </td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
              <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
              <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>


                <td>
 
 
 <div id="div3wayAbest_Corporate"  class="loginDivCss2" style="visibility:hidden;">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <td colspan="3">
                         <div class="LogoBoxheadOren">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal5" Text="PremiumSMS 3way" runat="server"></asp:Literal></div>
                          </div>   
                        </td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td class="style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                                    
              
                    

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center" class="style5">
                     <font class='font_11Msg_Error'>Click here to Login into </font><br />
                        <br />
                        <asp:HyperLink ID="HyperLink5" NavigateUrl="http://183.81.165.110/GS/premiumsms3way/index4.asp" 
                        Target="_blank" CssClass="links_Register" runat="server">1premiumsms3way.com</asp:HyperLink>
                          
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              
                    

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right" class="style5">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              
                    

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right" class="style5">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              
                    

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center" class="style5">
                       
                            
                        <asp:HyperLink ID="HyperLink6" CssClass="awesome large red" NavigateUrl="http://183.81.165.110/GS/premiumsms3way/RegisterNewIOD.asp"
                          Target="_blank" runat="server"> Register NOW </asp:HyperLink>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
              
                     <%-- <tr>
                    <td>&nbsp;</td>
                    <td align="left" class="style6">
                        Alternate login url:</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center"  class="style7">
                        <a href="http://www.1premiumsms3way.com/premiumsms3way/index4.asp" target="_blank" class="links_TopLineRed">1premiumsms3way.com</a></td>
                    <td>&nbsp;</td>
                    </tr>--%>

                    
                      
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right" class="style5">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              
                                         
                      </table>
         
        </div>

            </td>



            <td style="min-width: 250px;">
 
 
 <div id="dvDIYlogin" runat="server" visible="false"   class="loginDivCss2">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                    
                    <td colspan="4">
                    
                      
                        
                        <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal2" Text="DIY WebSite" runat="server"></asp:Literal></div>
                                </div>   
                      </td> 
                        
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td width="5%">&nbsp;</td>
                    <td width="30%" class="loginfont12">&nbsp;</td>
                    <td width="60%" class="loginfont12">&nbsp;</td>
                    <td width="5%">&nbsp;</td>
                    </tr>
                    
                    <%--</form>--%>
                    
                   <%-- <tr>
                    <td>&nbsp;</td>
                    <td align="left" colspan="2" class="font_11Msg_Success">
                        <table class="style1" visible="false">
                            <tr>
                                <td align="right" style="padding-right: 10px;">
                                    Login ID:</td>
                                <td>
                    <asp:TextBox ID="txtLogin_SMEWEB" MaxLength="16" CssClass="loginTextBox100" runat="server" 
                            ValidationGroup="VgSMEWEBLogin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                </td>
                                <td class="style5">
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ErrorMessage="Please enter LoginID"  CssClass="font_12Msg_Error" Display="Dynamic"
                            ControlToValidate="txtLogin_SMEWEB" SetFocusOnError="True" 
                            ValidationGroup="VgSMEWEBLogin"></asp:RequiredFieldValidator>
                            
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-right: 10px;">
                                    Password:</td>
                                <td>
                     <asp:TextBox ID="txtPassword_SMSWEB" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgSMEWEBLogin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ErrorMessage="Please enter password" CssClass="font_12Msg_Error" 
                            ControlToValidate="txtPassword_SMSWEB" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgSMEWEBLogin"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                        <asp:Button CssClass="stdButtonLogin" ID="btnSignIn_SMSWEB" runat="server" 
                            Height="26px" Text="Sign In"   
                            Width="72px" ValidationGroup="VgSMEWEBLogin" onclick="btnSignIn_SMSWEB_Click" />
                                </td>
                            </tr>
                            <tr>
                            <td align="right" class="font_11Msg_Error" colspan="2">
                                <asp:Literal ID="ltrWebEmailSMSError" Text="" runat="server"></asp:Literal>
                        
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="right">
                        <asp:HyperLink ID="HypSMEWEB_fp" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl="~/UserForgotPassword.aspx?fp=SMS">[Forgot Password]</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                        </td>
                    <td>&nbsp;</td>
                    </tr>--%>
                    
                    
                    
                    <tr>
                    <td class="style3"></td>
                    <td align="center" colspan="2" class="style3">
                         
                        <font class='font_11Msg_Error'>Click here to Login into </font><br />
                        <br />
                        <asp:HyperLink ID="HypWebEmailSMS" NavigateUrl="http://www.webemailsms.com" Target="_blank" CssClass="links_Register" runat="server">WebEmailSMS.com</asp:HyperLink>
                  
                  
                    </td>
                    <td class="style3"></td>
                    </tr>
                    
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                   <%-- <td align="left" colspan="2" align="center" style="margin-left: 40px">
                        <asp:Button ID="BtnSMERegister" runat="server" CssClass="awesome large blue" 
                            Text="REGISTER WebEmailSMS" 
                            OnClientClick="fnOpenFPwindow('Mas1SmeWebRegAjax.aspx')"/>
&nbsp;</td>--%>
                    <td>&nbsp;</td>
                    </tr>
                    
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center" colspan="2">
                        <asp:HyperLink ID="HyperLink2" CssClass="awesome large red" NavigateUrl="http://www.WebEmailSms.com/RegPage.aspx"
                          Target="_blank" runat="server"> Register NOW </asp:HyperLink>
                          <%--
                              <asp:Button ID="Btn_PerSec_Register0" runat="server" CssClass="awesome large orange" 
                            Text="REGISTER NOW" 
                            
                            OnClientClick="fnOpenFPwindow('http://www.mobileSMSSecretary.biz/Register.aspx')"/>--%>
                       </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left" colspan="2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    
                    
                      </table>
         
        </div>
        
        
            </td>


            <td style="vertical-align:top; min-width: 250px;">
        
        
        <div id="dvCorporateLogin" runat="server" visible="false"  class="loginDivCss2">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                    
                    <td colspan="4">
                    
                      
                        
                        <div class="LogoBoxheadGreen">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal4" Text="Corporate SMS Biz" runat="server"></asp:Literal></div>
                                </div>   
                      </td> 
                        
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td width="5%">&nbsp;</td>
                    <td width="30%" class="loginfont12">&nbsp;</td>
                    <td width="60%" class="loginfont12">&nbsp;</td>
                    <td width="5%">&nbsp;</td>
                    </tr>
                    
                    
                    
              <%--      <tr>
                    <td>&nbsp;</td>
                    <td align="left" colspan="2" class="font_11Msg_Success">
                        <table class="style1">
                            <tr>
                                <td align="right" style="padding-right: 10px;">
                                    Login ID:</td>
                                <td class="style7">
                    <asp:TextBox ID="txtPerSec_Login" MaxLength="16" CssClass="loginTextBox100" runat="server" 
                            ValidationGroup="VgPerSecLogin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                </td>
                                <td class="style8">
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ErrorMessage="Please enter LoginID"  CssClass="font_12Msg_Error" Display="Dynamic"
                            ControlToValidate="txtPerSec_Login" SetFocusOnError="True" 
                            ValidationGroup="VgPerSecLogin"></asp:RequiredFieldValidator>
                            
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-right: 10px;">
                                    Password:</td>
                                <td class="style7">
                     <asp:TextBox ID="txtPerSec_Password" CssClass="loginTextBox100" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgPERSECLogin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ErrorMessage="Please enter password" CssClass="font_12Msg_Error" 
                            ControlToValidate="txtPerSec_Password" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgPERSECLogin"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                        <asp:Button CssClass="stdButtonLogin" ID="Btn_PerSec_Login" runat="server" 
                            Height="26px" Text="Sign In"   
                            Width="72px" ValidationGroup="VgPERSECLogin" onclick="Btn_PerSec_Login_Click" />
                                </td>
                            </tr>
                            <tr>
                            <td align="right" class="style6" colspan="2">
                                <asp:Literal ID="ltrPerSec" runat="server"></asp:Literal>
                        
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="right" class="style7">
                              <asp:HyperLink ID="Hyp_PerSec_FP" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl='http://www.mobileSMSSecretary.biz/ForgotPassword.aspx' Visible="true">[Forgot Password]</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                        </td>
                    <td>&nbsp;</td>
                    </tr>--%>
                    
                    
                    
                    <tr>
                    <td class="style3"></td>
                    <td align="center" colspan="2" class="style3">
                        <font class='font_11Msg_Error'>Click here to Login into </font><br />
                        <br />
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="http://www.CorporateBizsms.com" Target="_blank" CssClass="links_Register" runat="server">CorporateBizSms.Com</asp:HyperLink>
                            
                  
                  </td>
                    <td class="style3"></td>
                    </tr>
                    
                    
                    
                    <tr>
                    <td class="style3">&nbsp;</td>
                    <td align="left" colspan="2" class="style3">
                        &nbsp;</td>
                    <td class="style3">&nbsp;</td>
                    </tr>
                    
                    
                    
                    <tr>
                    <td class="style3">&nbsp;</td>
                    <td align="left" colspan="2" class="style3">
                        &nbsp;</td>
                    <td class="style3">&nbsp;</td>
                    </tr>
                    
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center" colspan="2" align="center">
                            <asp:HyperLink ID="HypRegMobileSMS" CssClass="awesome large red" NavigateUrl="http://www.mobileSMSSecretary.biz/Register.aspx"
                          Target="_blank" runat="server"> Register NOW </asp:HyperLink>
                          
                              <%--<asp:Button ID="Btn_PerSec_Register" runat="server" CssClass="awesome large red" 
                            Text="REGISTER NOW" 
                            OnClientClick="fnOpenFPwindow('http://www.mobileSMSSecretary.biz/Register.aspx')"/>--%>
                    &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
              
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center" colspan="2" align="center">
                            
                              &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
              
                      </table>
         
        </div>
  

            </td>

                        <td>



<div id="divPremiumSMS_Subscription"  class="loginDivCss2" style="visibility:hidden;">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <td colspan="3">
                         <div class="LogoBoxheadOren">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="Literal3" Text="PremiumSMS Subscription" runat="server"></asp:Literal></div>
                          </div>   
                        </td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <%--                   <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">Login&nbsp;ID&nbsp;&nbsp;
                    <asp:TextBox ID="txtPre_SmsSubLogin"  CssClass="loginTextBox100" MaxLength="20" 
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
                       
                            
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              
                    

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                       
                            
                       <a href="#" onclick='javascript: return fnOpenFPwindow("forgotPwd_Premium.aspx?PageType=SUBSCRIBE",700,250);' target="_blank" class="links_ForgotPwd">[Forgot Password]</a>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
              --%>
                    

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <font class='font_11Msg_Error'>Click here to Login into </font><br />
                        <br />
                        <asp:HyperLink ID="HyperLink3" NavigateUrl="http://183.81.165.110/GS/premiumsmssubscription/venchise/index4.asp" 
                        Target="_blank" CssClass="links_Register" runat="server">1PremiumSmsSubscription.com</asp:HyperLink>
                            
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                       
                            
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                       
                            
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                       
                            
                        <asp:HyperLink ID="HyperLink4" CssClass="awesome large red" NavigateUrl="http://183.81.165.110/GS/premiumsmssubscription/venchise/RegisterNewIOD.asp"
                          Target="_blank" runat="server"> Register NOW </asp:HyperLink>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
              

                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                       
                            
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
              
                     <%-- <tr>
                    <td>&nbsp;</td>
                    <td align="left" class="bkgTestTitle">
                        Alternate login url:</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center"  class="bkgTestTitle2">
                        <a href="http://www.1premiumsmssubscription.com/premiumsmssubscription/venchise/index4.asp" target="_blank" class="links_TopLineRed">1premiumsmssubscription.com</a></td>
                    <td>&nbsp;</td>
                    </tr>--%>

                    
                      </table>
         
        </div>
 
 
            </td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>

              <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

      
        
</td>
<td class="style3">&nbsp;</td>
</tr>


<tr>
<td class="style4"></td>
<td class="style4">


<%--</form>--%>
       

    
    
    
    
    </td>
<td class="style4"></td></tr><tr>
<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr>
<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr>
<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table><%--</form>--%>



        <%--MODAL POPUP ALTER LOGIN --%>
    <asp:Button runat="server" ID="btnModalPopUp" style="display:none"/>
    <asp:ModalPopupExtender ID="ModalPopUpExtender1" runat="server" BackgroundCssClass="modalBackground" TargetControlID="btnModalPopUp" PopupControlID="pnlPopUp" PopupDragHandleControlID="PanelList" RepositionMode="RepositionOnWindowResize" OkControlID="ButtonClose"/>
    <asp:AnimationExtender ID="AnimationExtender1" runat="server"  TargetControlID="pnlPopUp">  
            <Animations>
              <OnLoad>
                 <Parallel AnimationTarget="pnlPopUp" Fps="10">
                    <FadeIn Duration=".1" Fps="10"/>
                  </Parallel>
               </OnLoad>
          </Animations>
    </asp:AnimationExtender>

    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
    <div class="header">
        ALERT !!! 
    </div>
    <div class="body">
        <asp:Literal ID="LblNotice" runat="server">Your Account has already expired.</asp:Literal>
    </div>
    <div class="footer" align="right">
       <%-- <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />--%>
        <asp:Button ID="ButtonClose" runat="server" Text="Close" CssClass="yes"/>
    </div>
 </asp:Panel>


           
<%--    <asp:Panel runat="Server" ID="pnlPopUp" Width="900px" CssClass="modalInsideBackground panelheightWidth">
    <div class="alert-box notice"><span style="color:Red"><u>Login Alert :</u></span>
    <br /><asp:Literal ID="LblNotice" runat="server">Your Account has already expired.</asp:Literal><br />
    Thank you.
    </div>
    <div align="left"><asp:Button ID="ButtonClose" runat="server" Text="Close" CssClass="buttonBlack"/></div>

    </asp:Panel>

    --%>
    
    
    
    <%--END--%>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

