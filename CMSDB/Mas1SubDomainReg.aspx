<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mas1SubDomainReg.aspx.cs" Inherits="Mas1SubDomainReg" %>

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



.tblFormLabel   { background-color: #F2F0B2; border-bottom: solid 1pt #D4DFAA; font-variant: small-caps; color: #4E5163; font-size: 12px; font-weight:bold; height:20px;}
.tblFormText    { background-color: #F8F6BC; border-bottom: solid 1pt #D4DFAA; font-size: 11px; color: #4E5163;}

.tblFormLbl1   { background-color: #F2F0B2; border-bottom: solid 1pt #D4DFAA; font-variant: small-caps; color: #4E5163; font-size: 12px; font: bold 12px "Trebuchet MS","Lucida Console", Arial, sans-serif; height:25px; padding-right:20px; text-align: left;}
.tblFormTxt1    { background-color: #F8F6BC; border-bottom: solid 1pt #D4DFAA; border-left: solid 1pt #D4DFAA;   font-size: 11px; color: #4E5163; height:25px; padding-left: 20px;}



        .style2
        {
            font-weight: bold;
            text-decoration: underline;
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
                   <font class="AdminFont"> Welcome to HitechDigitalBiz World</font></td>
                <td align="right" valign="top"  style="background-color:#03C0C6">
                    <img alt="toprightarc" src="Images/table_top_Rightarc.gif" 
                        style="width: 10px; height: 20px" /></td>
                </tr>
                </table>
              
              </td>
              </tr>
              <tr>
              <td>
              <div id="dvBannerLeftPanel" runat="server" style="width:200px;">
                  
              </div>
              </td>
              <td>
              <div id="dvBannerImg" runat="server">
              &nbsp;</div>
              
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
             
             <table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMasUserMessage" runat="server">
     <tr>
     <td>&nbsp;</td>
     <td align="left"><asp:Label ID="lblMasUserMessage" CssClass="font_12Msg_Error" runat="server" Text=""></asp:Label></td>
     </tr>
     </table>
     
     </td>
<td width="1%">&nbsp;</td>
</tr>

<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    &nbsp;</td>
<td width="1%">&nbsp;</td>
</tr>

<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <table cellpadding="0" cellspacing="0" width="100%" class="stdtableBorder_Main">
         <tr  class="font_12BlueBold">
            <td  width="1%">&nbsp;</td>
             <td width="97%" align="left">
                  <%--This Page would not appear once your register your subdomain.--%>
                  Please register your FREE SubDomain, Register Only Once.
                  </td>
             <td width="1%" align="center">
                 &nbsp;</td>
             <td width="1%">&nbsp;</td>
         </tr>
         <%--<tr  class="font_12BlueBold">
            <td >2.&nbsp;</td>
             <td>
                  Those who purchase Web30 Own Domain will be requested to register their own 
                 domain inside their Admin Login. </td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
          <tr class="font_12BlueBold">
            <td >3.</td>
             <td>
                 Admin login will be the same for Suddomain Name.</td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>--%>
         
        
     </table>
     </td>
<td width="1%">&nbsp;</td>
</tr>
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <asp:ScriptManager ID="ScriptManager1"  runat="server">
    </asp:ScriptManager>
    </td>
<td width="1%">&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
     <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="ltrPartnerWebReg" Text="Free SubDomain Registration" runat="server"></asp:Literal>
                 <font class="font_12BlueBold"> &nbsp; for WebPortal Access.</font>
                </div>
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
              <%--<tr>
                  
                  <td class="tblFormLabel" width="20%" >
                      <asp:Label ID="lblSelectLang" runat="server" Text="Select Language"></asp:Label>
                  </td>
                  <td class="tblFormText" width="80%" >
                      <asp:RadioButtonList ID="rdolstLanguage" runat="server" CellPadding="5" 
                          CellSpacing="5" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">English</asp:ListItem>
                          <asp:ListItem Value="2">Bahasa Melayu</asp:ListItem>
                      </asp:RadioButtonList>
                      <br />[NOTE:&nbsp;&nbsp; Selected language will be your default 
                      language for you website. ]</td>
                
              </tr>--%>
                            
                         
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
                         
<%--              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">--%>
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                   
                        [NOTE: &nbsp; Everyone will be provided with 
                        a subdomain first.&nbsp; Own domain registration will be done inside WebPortal Login. ]</td>
                </tr>
                <tr>
                    <td class="tblFormLbl1" width="20%">
                        &nbsp;</td>
                    <td class="tblFormTxt1" width="80%" valign="bottom">
                        &nbsp;</td>
                </tr>
                
                 <tr id="tr_ShowDomainError" runat="server" visible="true">
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                    <div id="dv_ShowSbError" runat="server">&nbsp;
                        
                                                                             
                        </div>
                  </td>
                
              </tr>
              
                <tr>
                    <td class="tblFormLbl1" width="20%">
                        &nbsp;</td>
                    <td class="tblFormTxt1" width="80%" valign="bottom">
                        <font class="font_EventDates">Enter SubDomain Name</font>
                    </td>
                </tr>
                <tr>
                    <td class="tblFormLbl1" width="20%">
                        &nbsp;<asp:Label ID="lblsubDomain" runat="server" Text="Sudomain Name"></asp:Label>
                    &nbsp;<font class="reqFieldCSS">*</font></td>
                    <td class="tblFormTxt1" width="80%">
                    
                           <asp:TextBox ID="txtSubDomainName" runat="server" 
                            CssClass="stdTextFieldRnd" MaxLength="25"  ValidationGroup="VgCheck"
                            ToolTip="Enter Subdomain name. Only Alphanumeric values are allowed." 
                               Width="200px"></asp:TextBox>
                        
                                                 
                        &nbsp;
                        
                                                 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtSubDomainName" Display="Dynamic" 
                            ErrorMessage="Please enter SubDomain Name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                         &nbsp;
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                           ControlToValidate="txtSubDomainName" ValidationGroup="VgCheck" Display="Dynamic" 
                           ErrorMessage=" * Only Alphanumeric Characters Allowed." 
                           ValidationExpression="^[a-zA-Z0-9]*$" />
                           
       <%--              </ContentTemplate>
                     <Triggers>            
                        <asp:AsyncPostBackTrigger ControlID="txtSubDomainName" EventName="TextChanged" />            
                    </Triggers>
                     
                        </asp:UpdatePanel> --%>
                    </td>
                </tr>
<%--              </table>
              </ContentTemplate>
                </asp:UpdatePanel>
               --%>
                
              <%-- <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtPassword" MaxLength="15" TextMode="Password" runat="server" CssClass="stdTextField1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtPassword" CssClass="font_11Msg_Error" Display="Dynamic" 
                            ErrorMessage="Please enter password" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="valPassword" runat="server" 
                           ControlToValidate="txtPassword" ValidationGroup="VgCheck" Display="Dynamic"
                           ErrorMessage="* Password must be atleast 6 characters."
                           ValidationExpression=".{6,}.*" />
                               
                    </td>
                </tr>
                
                
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;<asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtPasswordConfirm" MaxLength="15" TextMode="Password" runat="server" CssClass="stdTextField1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtPasswordConfirm" CssClass="font_11Msg_Error" Display="Dynamic" 
                            ErrorMessage="Please enter password" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="font_11Msg_Error" Display="Dynamic"
                         ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" Operator="Equal" Type="String"
                         ErrorMessage=" * Entered Password and Confirm Password do not match"></asp:CompareValidator>
                               
                    </td>
                </tr>
                --%>
                <tr>
                    <td class="tblFormLbl1" width="20%">
                                                &nbsp;Retype subDomain <font class="reqFieldCSS">*</font> </td>
                    <td class="tblFormTxt1" width="80%">
                        
                            <asp:TextBox ID="txtSubDomainNameRetyped" runat="server"
                            CssClass="stdTextFieldRnd" MaxLength="20"  ValidationGroup="VgCheck" 
                            ToolTip="Enter Subdomain name. Only Alphanumeric values are allowed." 
                                Width="200px"></asp:TextBox>
                        
                              &nbsp;
                        
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorRetyped" runat="server" 
                            ControlToValidate="txtSubDomainNameRetyped" Display="Dynamic" 
                            ErrorMessage="Please reType SubDomain Name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>                   
                        &nbsp;&nbsp; <asp:CompareValidator id="valCompare" runat="server"
                                               ControlToValidate="txtSubDomainNameRetyped" ControlToCompare="txtSubDomainName"
                                               Operator="Equal"  ValidationGroup="VgCheck" 
                                               ErrorMessage="* Entered SubDomain and reTyped SubDomain does not match"
                                               Display="dynamic">
                                            </asp:CompareValidator></td>
                </tr>
              
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                        &nbsp;</td>
                </tr>
              
              
              
                <%--<tr>
                    <td class="tblFormLabel">
                        &nbsp;<asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="tblFormText">
                    <asp:Label ID="lblUserEmail" runat="server" Text=""></asp:Label>
                       
                        
                    </td>
                </tr>--%>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >&nbsp;</td>
                  <td  class="tblFormTxt1" valign="bottom" ><font class="font_EventDates">
                  You can change anchor domain accordingly to your business inside the webportal login. 
                  </font></td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >&nbsp;Anchor Domain <font class="reqFieldCSS">* </font>:</td>
                  <td  class="tblFormTxt1" >
                      <asp:TextBox ID="txtAnchorDomain" class="stdTextFieldRnd" Width="200px" 
                          runat="server" Text="hitechdigitalbiz.com" MaxLength="99"></asp:TextBox>
                      <%--<asp:DropDownList ID="ddlAnchorDomain" CssClass="stdDropDownRnd" Width="207" runat="server">
                      </asp:DropDownList>
                      
                       &nbsp;
                      
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="ddlAnchorDomain" Display="Dynamic" 
                                            ErrorMessage="Please select AnchorDomain" InitialValue="0" 
                                            ValidationGroup="VgCheck"></asp:RequiredFieldValidator>--%>
                   &nbsp;
                   </td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >&nbsp;</td>
                  <td  class="tblFormTxt1 font_EventDates11" valign="top">Default buttons will be created at Website and MobileWeb 
                      to reflect your industry.</td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >&nbsp;</td>
                  <td  class="tblFormTxt1" valign="bottom" ><font class="font_EventDates">Your Details</font></td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >Full Name <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormTxt1"  >
                      <asp:TextBox ID="txtFullName" class="stdTextFieldRnd" Width="200px" 
                          runat="server" MaxLength="99"></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                          ControlToValidate="txtFullName" ErrorMessage="Full Name cannot be Empty" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >Email <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormTxt1"  >
                  <font class="font_EventDates">
                  Important for password recovery. 
                      <br />
                  </font>
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
                
                  <td class="tblFormLbl1" >Mobile No :</td>
                  <td  class="tblFormTxt1"  >
                      <asp:TextBox ID="txtMobileNo" class="stdTextFieldRnd" Width="200px" 
                          runat="server"></asp:TextBox>
                   &nbsp;
                   </td>
               
              </tr>
              
              
              
               <%--<tr>
                
                  <td class="tblFormLbl1"  height="10px">MyKad No. (NRIC) /<br />
&nbsp;Passport No. :</td>
                  <td  class="tblFormTxt1" valign="bottom">
                      <asp:TextBox ID="txtICNO" class="stdTextFieldRnd" Width="200px" 
                          runat="server"></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                          ControlToValidate="txtICNO" ErrorMessage="Cannot be Empty" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>--%>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1"  height="10px">&nbsp;</td>
                  <td  class="tblFormTxt1" valign="bottom">
                      &nbsp;</td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >&nbsp;</td>
                  <td  class="tblFormTxt1" valign="bottom">
                  <font class="font_EventDates">Enter Full Address [Please ensure to enter proper 
                      Address as it would be used for the <span class="style2">Google Location Map</span> at Mobile Website. ]</font></td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1">Street&nbsp; <font class="reqFieldCSS">* </font> :</td>
                  <td  class="tblFormTxt1"  >
                      <asp:TextBox ID="txtStreet" class="stdTextFieldRnd" Width="200px" runat="server" 
                         ></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                          ControlToValidate="txtStreet" ErrorMessage="Enter Street" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >City <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormTxt1"  >
                      <asp:TextBox ID="txtCity" class="stdTextFieldRnd" Width="200px" runat="server" 
                          ></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                          ControlToValidate="txtCity" ErrorMessage="Enter City" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >State <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormTxt1"  >
                      <asp:TextBox ID="txtState" class="stdTextFieldRnd" Width="200px" runat="server"></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                          ControlToValidate="txtState" ErrorMessage="Enter State" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLbl1" >Country<font class="reqFieldCSS"> *</font> :</td>
                  <td  class="tblFormTxt1"  >
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
                
                  <td class="tblFormLbl1" >Post Code <font class="reqFieldCSS">*</font> :</td>
                  <td  class="tblFormTxt1"  >
                      <asp:TextBox ID="txtPinCode" class="stdTextFieldRnd" Width="200px" runat="server"></asp:TextBox>
                   &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                          ControlToValidate="txtPinCode" ErrorMessage="Enter PostCode" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
              
              
               <%--<tr>
                
                  <td class="tblFormLbl1" >&nbsp;</td>
                  <td  class="tblFormTxt1"  >&nbsp;</td>
               
              </tr>
               <tr>
                
                  <td class="tblFormLabel" >&nbsp;</td>
                  <td  class="tblFormText"  >
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:CheckBox ID="chkAgreement" runat="server" Text="   I AGREE" 
                          ValidationGroup="VgCheck" />
                      .&nbsp;&nbsp; <a href="#" target="_blank" class="links_ForgotPwd">[ Click here ]</a> to view the Terms and Conditions. 
                      <asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="VgCheck"
                          ErrorMessage="Please Agree with the Term and Conditions" OnServerValidate="CustomValidator1_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                   </td>
               
              </tr>--%>
              
               <tr>
                
                  <td class="tblFormLbl1" >&nbsp;</td>
                  <td  class="tblFormTxt1"  >
                      &nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLbl1" >&nbsp;</td>
                  <td  class="tblFormTxt1"  >
                      <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="stdButtonNormal" 
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
