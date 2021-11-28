<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" maintainscrollpositiononpostback="true" CodeFile="EbWebLogin.aspx.cs" inherits="EbWebLogin" enableEventValidation="false" viewStateEncryptionMode="Never" %>

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
                
                .panelheightWidth {max-height:70%; max-width:70%; min-height:500px;}

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
    <%--
<tr>
<td class="style3"></td>
<td class="style3"></td>
<td class="style3"></td>
</tr>
--%>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false">
    </asp:ToolkitScriptManager>
    </td>
<td width="1%">&nbsp;</td>
</tr>


<%-- <asp:Literal  ID="ltrErrMsg_SMSsystem" Visible="false" Text="InValid LoginID or Password" runat="server"></asp:Literal>--%>

<tr>
<td class="style3">&nbsp;</td>
<td class="style3" align="center" style="clear: both;">
        
    <table class="style1">
        <tr>
            <td width="5%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td  width="5%">
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td colspan="4"  align="center" style="padding-left:30px;">

        <div id="dvSMSLogin" class="loginDivCss1">
        
        <table border="0" cellpadding="0" cellspacing="0" class="loginBkg">
                    <tr>
                    
                    <td colspan="4">
                    
                       
                        
                        <div class="LogoBoxheadBlue">
                                    <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                                    <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                                    <div class="sideBoxheadText"> 
                                        <asp:Literal ID="LtrSMSAdminLogin" Text="eVendor WEB Login" runat="server"></asp:Literal></div>
                                </div>   
                      </td> 
                        
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12">&nbsp;</td>
                    <td class="loginfont12">&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12" style=" padding-left: 30px;">
                        &nbsp;</td>
                    <td class="loginfont12" style=" padding-left: 30px;">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td class="loginfont12" style=" padding-left: 30px;">
                        <asp:Literal ID="ltrSMS_Login" Text="Login" runat="server"></asp:Literal>&nbsp;&nbsp;
                            </td>
                    <td class="loginfont12" style=" padding-left: 30px;">
                    <asp:TextBox ID="txtLogin_SMS" MaxLength="16" CssClass="inputTextBoxcss" runat="server" 
                            ValidationGroup="VgSMSLogin"></asp:TextBox>
                            </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        &nbsp;</td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ErrorMessage="Please enter LoginID"  CssClass="font_12Msg_Error" Display="Dynamic"
                            ControlToValidate="txtLogin_SMS" SetFocusOnError="True" 
                            ValidationGroup="VgSMSLogin"></asp:RequiredFieldValidator>
                            
                        
                            
                            
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12" style=" padding-left: 30px;"> <asp:Literal ID="ltrSMS_Password" Text="Password" runat="server"></asp:Literal>
                          </td>
                    <td  class="loginfont12" style=" padding-left: 30px;"> 
                     <asp:TextBox ID="txtPassword_SMS" CssClass="inputTextBoxcss" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgSMSLogin"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;</td>
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
                    <td>&nbsp;</td>
                    <td></td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td align="center" style="padding-left:50px">
                        &nbsp;</td>
                    <td align="center" style="padding-left:50px">
                        <asp:Button CssClass="stdButtonLogin" ID="btnSignIn_eVendor" runat="server" 
                            Height="26px" Text="Sign In"  Width="72px" OnClick="btnSignIn_eVendor_Click" ValidationGroup="VgSMSLogin" />
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                  
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <%--</form>--%>
                        </td>
                    <td align="right">
                        <asp:Label ID="lblErrMsg_SmsSystem" CssClass="valError" Text="InValid LoginID or Password" Visible="false" runat="server"></asp:Label>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        
                        &nbsp;</td>
                    <td align="right">
                        
                        <asp:HyperLink ID="HypSMS_fp" CssClass="links_ForgotPwd" runat="server" 
                            NavigateUrl="~/UserForgotPassword.aspx?fp=SMS">[Forgot Password]</asp:HyperLink>
                        
                        
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left" class="bkgTestTitle">
                        <%--Alternate login url:--%></td>
                    <td align="left" class="bkgTestTitle">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="center"  class="bkgTestTitle2">
                       <%-- <a href="http://www.1smslogin.com" target="_blank" class="links_TopLineRed">www.1smslogin.com</a>--%>

                    </td>
                    <td align="center"  class="bkgTestTitle2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
         
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


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

