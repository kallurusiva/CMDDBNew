<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="PartnerWebRegistration.aspx.cs" Inherits="PartnerWebRegistration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> <asp:Literal ID="ltrContactUs" Text="Contact Us" runat="server"></asp:Literal> </td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/ContactUs_panel.jpg" />
    
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

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
            if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 0) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 97 && e.keyCode <= 122)) {
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


        if (SelCountryValue == 60) {
            if (tmpLength != 11) {
                source.innerText = " * Mobile no. for malaysia should be 11 characters";
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }

        }
        else if (SelCountryValue == 65) {
            if (tmpLength != 10) {
                source.innerText = " * Mobile no. for singapore should be 10 characters";
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
    
    

</script>

<%--<form id="form1" runat="server">--%>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
</tr>
<tr>
<td>&nbsp;</td>
<td>

    
            <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
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
                         
<%--              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">--%>
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                   
                        [ Domain Name will also be used as Admin Login ]</td>
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
                          
                    </td>
                </tr>
<%--              </table>
              </ContentTemplate>
                </asp:UpdatePanel>
               --%>
                
              <tr id="tr_ShowDomainError" runat="server" visible="true">
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      <%--<asp:UpdateProgress DisplayAfter="3000" ID="UpdateProgress1" runat="server">
                      <ProgressTemplate>
                      <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/> Please wait...while we check for availability of subdomain.
                      </div>
                    </ProgressTemplate>
                      </asp:UpdateProgress>--%>
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
                         ErrorMessage=" * Entered Password do not match"></asp:CompareValidator>
                               
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
                        </asp:DropDownList>
                    </td>
                </tr>
              
               <tr> 
                  <td class="tblFormLabel">&nbsp;</td>
                  <td  class="tblFormText">
                      [ Mobile number should be the same which you have used to purchased the PIN NO ]</td>
                
              </tr>
              
               <tr> 
                  <td class="tblFormLabel">&nbsp;<asp:Label ID="lblMobileNo" runat="server" 
                          Text="Mobile No."></asp:Label></td>
                  <td  class="tblFormText">
                  <asp:TextBox ID="txtMobileNo" CssClass="stdTextField1" MaxLength="13" runat="server"></asp:TextBox>
                   
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="txtMobileNo"  CssClass="font_11Msg_Error" Display="Dynamic" 
                          ErrorMessage="Please enter Mobile No." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                               ControlToValidate="txtMobileNo" ValidationGroup="VgCheck" Display="Dynamic" 
                               ErrorMessage=" * Invalid Mobile Number" 
                               ValidationExpression=".{10,13}.*" />
                               
                   </td>
                
              </tr>
               <tr>
                 
                  <td class="tblFormLabel">&nbsp;</td>
                  <td  class="tblFormText">
                      <asp:CustomValidator ID="CustVd_Prefix" runat="server" 
                          ClientValidationFunction="CheckMobileCountryPrefix" 
                          ControlToValidate="txtMobileNo" Display="Dynamic" 
                          ErrorMessage=" * Should start with 100 only"></asp:CustomValidator>
                          
                      <asp:CustomValidator ID="CustomValidator1" runat="server" 
                          ClientValidationFunction="CheckMobileMaxChars" 
                          ControlToValidate="txtMobileNo" Display="Dynamic" 
                          ErrorMessage=" * Max Characters"></asp:CustomValidator>
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
                <asp:Literal ID="Literal1" Text="NOTE" runat="server"></asp:Literal>
                </td>
<td>&nbsp;</td>
</tr>



<tr>
<td>&nbsp;</td>
<td>
     <table cellpadding="0" cellspacing="0" width="100%" class="stdtableBorder_Main">
         <tr  class="font_12BlueBold">
            <td  width="1%">1.&nbsp;</td>
             <td width="97%" align="left">
                  Partner website registration comes with a instant subdomain.</td>
             <td width="1%" align="center">
                 &nbsp;</td>
             <td width="1%">&nbsp;</td>
         </tr>
         <tr  class="font_12BlueBold">
            <td >2.&nbsp;</td>
             <td>
                  Those who purchase Web30 Own Domain will be requested to register their own 
                 domain inside their Admin Login. </td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
          <tr>
            <td >&nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
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
 <%--</form>--%>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

