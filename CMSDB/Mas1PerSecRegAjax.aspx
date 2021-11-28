<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mas1PerSecRegAjax.aspx.cs" Inherits="Mas1PerSecRegAjax" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
body {
    margin: 0;
    padding:0; 
    background: #fff;
}

#headercontent{
     width: 100%;
     height: 88px;
     margin: 0;
     border-width: 0 0 0 0;
 }

#maincontainer 
{
    width: 1020px;
    margin: 0 auto;
    
}

#ContentLeft {
    width: 20%;
    float: left;
    color: #000;
    padding: 10px; 
}

#ContentRight 
{
width: 76%;   
float: left;
padding: 10px; 
} 

#footer
{
    width: 100%;
    padding:10px;
    height :30px;
}


#dvUserAvailability {
  padding-left: 22px;
  line-height: 25px;
  background-position: left;
  background-repeat: no-repeat;
}
 
.invalid {
  background-image: url(images/imgDelete.gif);
  font: bold 12px "Trebuchet MS","Lucida Console", Arial, sans-serif;
  color: #FE0404;
  background-repeat: no-repeat;
   line-height: 25px;
    padding-left: 25px;
}
 
.valid {
  background-image: url(images/imgUpdate.gif);
  font: bold 12px "Trebuchet MS","Lucida Console", Arial, sans-serif;
  color: #1E990E;
  background-repeat: no-repeat;
  line-height: 25px;
   padding-left: 25px;
}

</style>

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


    function CheckKeyCode_Alpha(e) {
        if (navigator.appName == "Microsoft Internet Explorer") {
            if ((e.keyCode == 8) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 97 && e.keyCode <= 122)) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            if ((e.charCode == 0) || (e.charCode >= 65 && e.charCode <= 90) || (e.charCode >= 97 && e.charCode <= 122)) {
                return true;
            }
            else {
                return false;
            }
        }
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
             <div id="headercontent">
              <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr>
              <td  width="200px" style="height:66px"> 
                &nbsp;
               </td>
              <td valign="bottom">
              <table border="0" cellpadding="0" cellspacing="0" width="100%">
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
                &nbsp;
                   <font class="AdminFont"> SMS Personal Secretary</font></td>
                <td align="right" valign="top"  style="background-color:#03C0C6">
                    <img alt="toprightarc" src="Images/table_top_Rightarc.gif" 
                        style="width: 10px; height: 20px" /></td>
                </tr>
                </table>
              
              </td>
              </tr>
              <%--<tr>
              <td>
              <div id="dvBannerLeftPanel" runat="server" style="width:200px;">
                  
              </div>
              </td>
              <td>
              <div id="dvBannerImg" runat="server">
              &nbsp;</div>
              
              </td>
              </tr>--%>
              <tr class="underBannerBar">
              <%--<td>&nbsp;</td>--%>
              <td colspan="2">
                  <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMasUserMessage" runat="server">
                     <tr>
                     <td>&nbsp;</td>
                     <td align="left"><asp:Label ID="lblMasUserMessage" CssClass="font_12Msg_Error" runat="server" Text=""></asp:Label></td>
                     </tr>
                     </table>
              
              </td>
              </tr>
              </table>
             
             
             </div>
             
             </td>
            </tr>
            <tr>
             <td>
             
             <table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr>
<td width="1%">&nbsp;</td>
<td width="98%">

     
     </td>
<td width="1%">&nbsp;</td>
</tr>
<asp:ScriptManager ID="ScriptManager1"  runat="server">
    </asp:ScriptManager>
<%--<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    
    </td>
<td width="1%">&nbsp;</td>
</tr>--%>
<tr>
<td>&nbsp;</td>
<td>
     <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="ltrPerSecHeader" Text="SMS Personal Secretary - Registration" 
                        runat="server"></asp:Literal>
                </div>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
    <table cellpadding="0" cellspacing="0" style="margin: 3px; display:block; background-color:#FEFFDE; border: solid 9px #FB4242; width:100%; height:90px;" id="tblMessageBar" visible="false" runat="server">
     <tr>
     <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
     <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
     </tr>
     </table>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>

    
            <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
                                         
                <tr>
                    <td class="tblFormLabel1" width="20%">
                        &nbsp;</td>
                    <td class="tblFormText1" width="80%">
                   
                           &nbsp;</td>
                </tr>
                
                <tr>
                    <td class="tblFormLabel1" width="20%">
                        Enter User ID&nbsp;<font class="reqFieldCSS">*</font></td>
                    <td class="tblFormText1" width="80%">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <div style="float:left;">
                           <asp:TextBox ID="txtPerSecUserID" runat="server" 
                            CssClass="stdTextFieldRnd" MaxLength="20"  ValidationGroup="VgCheck"
                            ToolTip="Enter Personal Secretary  UserID / LoginID."
                               Width="200px" AutoPostBack="True" ontextchanged="txtPerSecUserID_TextChanged"></asp:TextBox>
                          <div runat="server" id="dvUserAvailability"></div>   
                          </div>
                        </ContentTemplate>
                         </asp:UpdatePanel>                        
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                            ControlToValidate="txtPerSecUserID" Display="Dynamic" 
                            ErrorMessage="Please enter UserID / LoginID." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                         </td>
                </tr>
                
                <tr>
                    <td class="tblFormLabel1" width="20%">
                        Enter Password&nbsp;<font class="reqFieldCSS">*</font></td>
                    <td class="tblFormText1" width="80%">
                   
                           <asp:TextBox ID="txtPerSecPwd" runat="server" 
                            CssClass="stdTextFieldRnd" MaxLength="20"  ValidationGroup="VgCheck"
                            ToolTip="Enter Password" 
                               Width="200px" TextMode="Password"></asp:TextBox>
                        
                                                 
                        &nbsp;
                        
                                                 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                            ControlToValidate="txtPerSecPwd" Display="Dynamic" 
                            ErrorMessage="Please enter Password" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                            
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                               ControlToValidate="txtPerSecPwd" ValidationGroup="VgCheck" Display="Dynamic"  
                               ErrorMessage=" * Password should be minimum of 6 Characters."
                               ValidationExpression=".{6,}.*" />
                               
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                           ControlToValidate="txtPerSecPwd" ValidationGroup="VgCheck" Display="Dynamic" 
                           ErrorMessage=" * Only Alphanumeric Characters Allowed." 
                           ValidationExpression="^[a-zA-Z0-9]*$" />
                               
                         </td>
                </tr>
                
                <tr>
                    <td class="tblFormLabel1" width="20%">
                        Re-Enter Password&nbsp;<font class="reqFieldCSS">*</font></td>
                    <td class="tblFormText1" width="80%">
                   
                           <asp:TextBox ID="txtPerSecPwd2" runat="server" 
                            CssClass="stdTextFieldRnd" MaxLength="20"  ValidationGroup="VgCheck"
                            ToolTip="Re-Enter Password." 
                               Width="200px" TextMode="Password"></asp:TextBox>
                        
                                                 
                        &nbsp;
                        
                                                 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                            ControlToValidate="txtPerSecPwd2" Display="Dynamic" 
                            ErrorMessage="Please Re-enter Password" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                             &nbsp;
                             <asp:CompareValidator id="CompareValidator1" runat="server"
                                               ControlToValidate="txtPerSecPwd2" ControlToCompare="txtPerSecPwd"
                                               Operator="Equal"  ValidationGroup="VgCheck" 
                                               ErrorMessage="* Entered New Password and reTyped password does not match"
                                               Display="dynamic">
                                            </asp:CompareValidator>
                            
                         </td>
                </tr>
                
                <tr>
                    <td class="tblFormLabel1" width="20%">
                        Enter Pin Number&nbsp;<font clas*</font></font>&nbsp;<font class="reqFieldCSS">*</font></td>
                    <td class="tblFormText1" width="80%">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                        <div style="float:left;">
                          <asp:TextBox ID="txtPerSecPIN" runat="server" 
                            CssClass="stdTextFieldRnd" MaxLength="12"  ValidationGroup="VgCheck" AutoPostBack="true" 
                            ToolTip="Enter Pin Number." 
                               Width="200px" ontextchanged="txtPerSecPIN_TextChanged"></asp:TextBox>
                        <div runat="server" id="dvPinNumberCheck"></div>   
                        </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                         
                                                 
                        &nbsp;
                        
                                                 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                            ControlToValidate="txtPerSecPIN" Display="Dynamic" 
                            ErrorMessage="Please enter Pin Number." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                         </td>
                </tr>
                
<%--              </table>
              </ContentTemplate>
                </asp:UpdatePanel>
               --%>
                
             
         <%--      <tr>
                
                  <td class="tblFormLabel1" >&nbsp;</td>
                  <td  class="tblFormText1" valign="bottom" ><font class="font_EventDates">Your Details">Your Details</font></td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1" >Full Name <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtFullName" class="stdTextFieldRnd" Width="200px" 
                          runat="server" MaxLength="99"></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                          ControlToValidate="txtFullName" ErrorMessage="Full Name cannot be Empty" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1" >Email <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtEmail" class="stdTextFieldRnd" Width="200px" runat="server"></asp:TextBox>
                       &nbsp;
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                          ControlToValidate="txtEmail" Display="Dynamic" 
                          ErrorMessage="Please enter email" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                      &nbsp;
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                          ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                          Display="Dynamic" runat="server" ErrorMessage="*  Enter a Valid Email" ValidationGroup="VgCheck" 
                          SetFocusOnError="True"></asp:RegularExpressionValidator>
                   &nbsp;
                   </td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1" >Mobile No <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtMobileNo" class="stdTextFieldRnd" Width="200px" 
                          runat="server"></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                          ControlToValidate="txtMobileNo" ErrorMessage="Please enter Mobile Number." 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
                      
               <tr>
                
                  <td class="tblFormLabel1"  height="10px">&nbsp;</td>
                  <td  class="tblFormText1" valign="bottom">
                      &nbsp;</td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1" >&nbsp;</td>
                  <td  class="tblFormText1" valign="bottom">
                  <font class="font_EventDates">Enter Full Address [Please ensure to enter proper 
                      Address as it would be used for the Google Location Map at Mobile Website. ]</font></td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1">Street&nbsp; <font class="reqFieldCSS">* </font> :</td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtStreet" class="stdTextFieldRnd" Width="200px" runat="server" 
                         ></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                          ControlToValidate="txtStreet" ErrorMessage="Enter Street" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1" >City <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtCity" class="stdTextFieldRnd" Width="200px" runat="server" 
                          ></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                          ControlToValidate="txtCity" ErrorMessage="Enter City" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1" >State <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtState" class="stdTextFieldRnd" Width="200px" runat="server"></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                          ControlToValidate="txtState" ErrorMessage="Enter State" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1" >Country<font class="reqFieldCSS"> *</font> :</td>
                  <td  class="tblFormText1"  >
                      <asp:DropDownList ID="ddlCountry" CssClass="stdDropDownRnd" Width="207" 
                          runat="server">
                          <asp:ListItem Value="60">Malaysia</asp:ListItem>
                          <asp:ListItem Value="65">Singapore</asp:ListItem>
                          <asp:ListItem Value="673">Brunei</asp:ListItem>
                          <asp:ListItem Value="62">Indonesia</asp:ListItem>
                          <asp:ListItem Value="63">Philiphines</asp:ListItem>
                          <asp:ListItem Value="66">Thailand</asp:ListItem>
                          <asp:ListItem Value="91">India</asp:ListItem>
                      </asp:DropDownList>
                   </td>
               
              </tr>
              
              
               <tr>
                
                  <td class="tblFormLabel1" >Post Code <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtPinCode" class="stdTextFieldRnd" Width="200px" runat="server"></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                          ControlToValidate="txtPinCode" ErrorMessage="Enter PostCode" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>--%>
              
          
              
               <tr>
                
                  <td class="tblFormLabel1" >Enter Full Name &nbsp;<font class="reqFieldCSS">*</font></td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtPerSecFullName" runat="server" CssClass="stdTextFieldRnd" 
                          ToolTip="Enter your Mobile Number." ValidationGroup="VgCheck" 
                          Width="200px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                            ControlToValidate="txtPerSecFullName" Display="Dynamic" 
                            ErrorMessage="Please enter Full Name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                         </td>
               
              </tr>
              
          
              
               <tr>
                
                  <td class="tblFormLabel1" >Enter Mobile No.&nbsp;&nbsp;<font class="reqFieldCSS">*</font></td>
                  <td  class="tblFormText1"  >
                      <asp:TextBox ID="txtPerSecMobile" runat="server" CssClass="stdTextFieldRnd" 
                          ToolTip="Enter your Mobile Number." ValidationGroup="VgCheck" Width="200px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                            ControlToValidate="txtPerSecMobile" Display="Dynamic" 
                            ErrorMessage="Please enter Mobile Number." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                         &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                          runat="server" ValidationExpression="^[1-9]\d*$" ControlToValidate="txtPerSecMobile" ValidationGroup="VgCheck" 
                          ErrorMessage="Invalid Mobile No. format. Cannot start with zero. Input prefixed with country code e.g. 60149664566"></asp:RegularExpressionValidator>
                         </td>
               
              </tr>
              
          
              
               <tr>
                
                  <td class="tblFormLabel1" >&nbsp;</td>
                  <td  class="tblFormText1"  >
                      &nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel1" >&nbsp;</td>
                  <td  class="tblFormText1"  >
                      <asp:Button ID="btnRegister" runat="server" Text="Submit for Registration" CssClass="stdButtonNormal" 
                          ValidationGroup="VgCheck" onclick="btnRegister_Click" />
                   </td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" >&nbsp;</td>
                  <td  class="tblFormText"  >&nbsp;</td>
               
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
<td class="cssfaqQuestion font_14BoldGrey"> 
                &nbsp;</td>
<td>&nbsp;</td>
</tr>



</table>
             
             </td>
            </tr>
            
            <tr>
             <td>
                 &nbsp;</td>
            </tr>
            
        </table>
    
    </div>

     </form> 
</body>
</html>
