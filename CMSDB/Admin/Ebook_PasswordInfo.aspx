<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ebook_PasswordInfo.aspx.cs" Inherits="Admin_Ebook_PasswordInfo" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SideMenu_MyAccount.ascx" tagname="SideMenu_MyAccount" tagprefix="uc1" %>

<%@ Register src="LeftMenu_Profile.ascx" tagname="LeftMenu_Profile" tagprefix="uc2" %>

<%@ Register src="EbLeftMenu_Profile.ascx" tagname="EbLeftMenu_Profile" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:EbLeftMenu_Profile ID="EbLeftMenu_Profile1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script language="javascript" type="text/javascript">

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


</script>
<form id="MyAccountForm" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" visible="false" id="tblMessageBar"  runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; <asp:Literal ID="LtrMyActSettings" runat="server" 
                                Text="My Account Settings [Password Change]"></asp:Literal>&nbsp;
                          </td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="2" class="stdtableBorder_MainBold" width="100%">
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="96%">
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left" class="FontBRowText2">&nbsp;                           
                        </td>
                        <td>&nbsp;</td>

                    </tr>

                    <tr>
                        <td>&nbsp;</td>
                        <td>
                                <table border="0" cellpadding="0" cellspacing="2" width="100%" class="stdtableBorder_AccountPage">
                                    <tr>
                                        <td width="20%">&nbsp;</td>
                                        <td width="2%">&nbsp;</td>
                                        <td width="55%">&nbsp;</td>
                                        <td width="23%">&nbsp;</td>
                                    </tr>
                                <tr>
                                <td colspan="3"> <font class="Section_headtext">
                                
                                
                                 </font></td>
                               
                                <td align="left"><font class="Section_headtext2">
                                 </font></td>
                                </tr>
                                
                               
                                
                              
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td>&nbsp;: </td>
                                        <td align="left">
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>

                                      <tr>
                                 <td  align="left"> 
                                     &nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left" class="font_Content"> 
                                     <br />
                                     <b>&nbsp; <span class="auto-style1">NOTE:</span></b> 
                                     <br class="auto-style1" />
                                     &nbsp; To change password.<br />
                                     <span class="FontNote" >Please use your registered MobileNo.</span>   
                                     <span class="FontNote" >to issue sms instructions.</span><br />
                                     <span class="FontNote" >Please use SMS Format. </span><br />
                                     <br />
                                     <span class="font_14SuccessBold" >&nbsp; EB&nbsp; CPWD&nbsp; <em>oldPassword </em>&nbsp; <em>newPassword </em> </span>
                                     <em>
                                     <br />
                                     </em>
                                     <br />
                                     <span class="FontNote" >Send To +60146367111, +628989111995, +447860041399 </span></td>
                                 <td>&nbsp;</td>
                                </tr>

                                    <tr>
                                        <td colspan="4">&nbsp;</td>

                                    </tr>

                                 <tr>
                                 <td align="left"> 
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                <td>&nbsp;<</td>
                                </tr>

                              
                                 
                                
                                
                                
                                 <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>
                                    &nbsp;
                                 </td>
                                 <td>&nbsp;</td></tr><tr>
                                 <td align="left"> 
                                 <td align="left"> 
                                   
                                 </td>
                                 <td>&nbsp; </td>
                                </tr>
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table></td>
                           
                        </td>
                        <td>&nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td>
                            &nbsp;</td><td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr></table></form></asp:Content>