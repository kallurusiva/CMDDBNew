<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PartnerWebRegistrationNew.aspx.cs" Inherits="PartnerWebRegistrationNew" %>

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
     height: 300px;
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

</style>

<%--<script language="javascript" type="text/javascript">

    function ChangeMobileText() {

        var ObjSelCountry = '<%=DdlCountry.ClientID%>';
        var SelCountryValue = document.getElementById(ObjSelCountry).value;
        alert(SelCountryValue);
        var ObjtxtMobile = '<%=txtMobileNo.ClientID%>';
        document.getElementById(ObjtxtMobile).value = SelCountryValue;
        
        
    
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



    function CheckMobileMaxChars(source, arguments) {
        // even number?

        //alert(arguments.Value);

        var ObjSelCountry = '<%=DdlCountry.ClientID%>';
        

        //.. if Malaysia .. chars = 11
        //.. if Singapore.. chars = 10
        //.. if Indonesia.. chars between 10-13
        
        var SelCountryValue = document.getElementById(ObjSelCountry).value;
        var tmpValue = arguments.Value;
        var tmpLength = tmpValue.length;
        var tmpStart2Chars = tmpValue.substring(0,2);


        if (SelCountryValue == 60) {
            if (tmpLength != 11) {
                source.innerText = " * Mobile no. for malaysia should be 11 characters.";
                arguments.IsValid = false;
            }
            else if (tmpStart2Chars != SelCountryValue) {
            source.innerText = " * Mobile no. for malaysia should start with 60";
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }

        }
        else if (SelCountryValue == 65) {
            if (tmpLength != 10) {
                source.innerText = " * Mobile no. for singapore should be 10 characters.";
                arguments.IsValid = false;
            }
            else if (tmpStart2Chars != SelCountryValue)
            {
                source.innerText = " * Mobile no. for singapore should start with 65";
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }
        }
        else {
            arguments.IsValid = true;
        }

       // alert(SelCountryValue + "|" + SelCountryValue + "|" + tmpLength);

//        var tmpValue = arguments.Value;
//        tmpValue = tmpValue.substring(0, 2);
//        var EnteredMobileNumberPrefix = tmpValue;
//        alert(SelCountryValue + "|" + EnteredMobileNumberPrefix);

//        if (SelCountryValue == EnteredMobileNumberPrefix)
//            arguments.IsValid = true;
//        else
//            arguments.IsValid = false;
    }
    

    function CheckMobileCountryPrefix(source, arguments) {
        // even number?

        //alert(arguments.Value);

        var ObjSelCountry = '<%=DdlCountry.ClientID%>';
        var objCustomValidator = '';
        //sender.errormessage = "err msg 2";
        
        
        var SelCountryValue = document.getElementById(ObjSelCountry).value;
        source.innerText = " * Mobile no. should match you selected country code prefix";

        var tmpValue = arguments.Value;
        tmpValue = tmpValue.substring(0, 2);
        var EnteredMobileNumberPrefix = tmpValue;
       // alert(SelCountryValue + "|" + EnteredMobileNumberPrefix);
      
        if(SelCountryValue == EnteredMobileNumberPrefix)
            arguments.IsValid = true;
        else
            arguments.IsValid = false;
    }
    
    

</script>--%>


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
                <td align="right">
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
                <td align="left" valign="top" style="background-color:#03C0C6">
                    <img alt="topleftarc" src="Images/table_top_Leftarc.gif" 
                        style="width: 10px; height: 20px" /></td>
                <td style="background-color:#03C0C6">
                &nbsp;
                   <font class="AdminFont"> Welcome to EVENCHISE </font> </td>
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
                
                                 
                
             
             </td>
            </tr>
            <tr>
             <td>
             
             <table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    &nbsp;</td>
<td width="1%">&nbsp;</td>
</tr>

<tr>
<td>&nbsp;</td>
<td class="cssfaqQuestion font_14BoldGrey"> 
                <%--<asp:Literal ID="Literal1" Text="NOTE" runat="server">--%>
                <asp:Literal ID="Literal2" Text="" runat="server">
                </asp:Literal>
                </td>
<td>&nbsp;</td>
</tr>
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <table cellpadding="0" cellspacing="0" width="100%" class="stdtableBorder_Main">
         <tr  class="font_12Msg_Error">
            <td  width="1%">&nbsp;</td>
             <td width="97%" align="left">
                  <%--Partner website registration comes with a instant subdomain.--%>
                  
                  <%--<h4> Invalid  SubDomain or  SubDomain does not exist.</h4>--%>

             </td>
             <td width="1%" align="center">
                 &nbsp;</td>
             <td width="1%">&nbsp;</td>
         </tr>
         <tr  class="font_12BlueBold">
            <td >&nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         <tr  class="font_12BlueBold">
            <td >&nbsp;</td>
             <td>
                <%--Please register your subdomain inside your SMS Business Login.--%> 
                  <%--Those who purchase Web30 Own Domain will be requested to register their own 
                 domain inside their Admin Login.--%>
                 The Website URL or Download Ebook URL Page is Currently Busy.  Please click again at the URL Given after 10 Minutes.
                 <br /><br />
Thank you<br />
EVenchise Team

                  </td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
          <tr class="font_12BlueBold">
            <td ></td>
             <td>
                 <%--Admin login will be the same for Suddomain Name.--%></td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         
        
     </table>
     </td>
<td width="1%">&nbsp;</td>
</tr>
<%--<tr>
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
                <asp:Literal ID="ltrPartnerWebReg" Text="Partner Website Registration" runat="server"></asp:Literal>
                </div>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
    <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
     <tr>
     <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
     <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
     </tr>
     </table>
</td>
<td>&nbsp;</td>
</tr>--%>
<tr>
<td>&nbsp;</td>
<td>

    
            <%--<table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
              <tr>
                  
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
                      language ]</td>
                
              </tr>
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      [ Enter the PinNo which you have received after you purchase ]</td>
                
              </tr>
               <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;<asp:Label ID="Label1" 
                          runat="server" Text="Pin No"></asp:Label></td>
                  <td class="tblFormText" width="80%" >
                      <asp:TextBox ID="txtPinNo" CssClass="stdTextField1" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                          ControlToValidate="txtPinNo" Display="Dynamic" ErrorMessage="Please enter Pin No." 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                  </td>
                
              </tr>
                         

                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                   
                        [ SubDomain Name will also be used as Admin Login.&nbsp; Everyone will be given 
                        a subdomain first. Own domain registration will be done inside admin login for 
                        WEB30. ]</td>
                </tr>
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;<asp:Label ID="lblsubDomain" runat="server" Text="Sudomain Name"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                    
      
                        
                            <asp:TextBox ID="txtSubDomainName" runat="server" AutoPostBack="true" 
                            CssClass="stdTextField1" MaxLength="20" 
                            ontextchanged="txtSubDomainName_TextChanged" 
                            ToolTip="Enter Subdomain name. Only Alphanumeric values are allowed."></asp:TextBox>
                        
                                                 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtSubDomainName" Display="Dynamic" 
                            ErrorMessage="Please enter SubDomain Name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
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
                <%-- 
              <tr id="tr_ShowDomainError" runat="server" visible="true">
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                    
                    <div id="dv_ShowSbError" runat="server">[ Password should be a minimum of 6 
                        characters. ]</div>
                  </td>
                
              </tr>
              
               <tr>
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
                
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                        &nbsp;</td>
                </tr>
              
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                        &nbsp;</td>
                </tr>
              
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="stdTextField1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtName" CssClass="font_11Msg_Error" Display="Dynamic" 
                            ErrorMessage="Please enter name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                    </td>
                </tr>
              
                <tr>
                    <td class="tblFormLabel" valign="top">
                        &nbsp;<asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                    </td>
                    <td class="tblFormText" valign="top">
                        <asp:DropDownList ID="DdlCountry" runat="server" CssClass="stdDropDown1">
                            <asp:ListItem Value="60">Malaysia</asp:ListItem>
                            <asp:ListItem Value="65">Singapore</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
              
               <tr> 
                  <td class="tblFormLabel">&nbsp;</td>
                  <td  class="tblFormText">
                      &nbsp;</td>
                
              </tr>
              
               <tr> 
                  <td class="tblFormLabel">&nbsp;<asp:Label ID="lblMobileNo" runat="server" 
                          Text="Mobile No."></asp:Label></td>
                  <td  class="tblFormText">
                  <asp:TextBox ID="txtMobileNo" CssClass="stdTextField1" MaxLength="11" Text="60" runat="server"></asp:TextBox>
                   
                      &nbsp; [ International format e.g. 60123287777, 6597366888 ]
                               
                   </td>
                
              </tr>
               <tr>
                 
                  <td class="tblFormLabel">&nbsp;</td>
                  <td  class="tblFormText">
                   
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="txtMobileNo"  CssClass="font_11Msg_Error" Display="Dynamic" 
                          ErrorMessage="Please enter Mobile No." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                          &nbsp;
                  
                          
                      <asp:CustomValidator ID="CustomValidator1" runat="server" 
                          ClientValidationFunction="CheckMobileMaxChars" 
                          ControlToValidate="txtMobileNo" Display="Dynamic" 
                          ErrorMessage=" * Max Characters"></asp:CustomValidator>
                   &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                               ControlToValidate="txtMobileNo" ValidationGroup="VgCheck" Display="Dynamic" 
                               ErrorMessage=" * Invalid Mobile Number" 
                               ValidationExpression=".{10,11}.*" />
                               
                               
                   </td>
                 
              </tr>
              
              
              
                <tr>
                    <td class="tblFormLabel">
                        &nbsp;<asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="tblFormText">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="stdTextField1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" 
                            ErrorMessage="Please enter email." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" 
                            ErrorMessage="*  Enter a Valid Email" SetFocusOnError="True" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="VgCheck"></asp:RegularExpressionValidator>
                    </td>
                </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >
                      <asp:Button ID="btnRegister" runat="server" Text="Register" 
                          ValidationGroup="VgCheck" onclick="btnRegister_Click" />
                   </td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
              </table>--%>
             
             

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
     
    </td>
<td>&nbsp;</td>
</tr>


<tr>
<td>&nbsp;</td>
<td class="cssfaqQuestion font_14BoldGrey"> 
                &nbsp;</td>
<td>&nbsp;</td>
</tr>



<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
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
