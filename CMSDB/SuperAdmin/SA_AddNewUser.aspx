<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_AddNewUser.aspx.cs" Inherits="SuperAdmin_SA_AddNewUser" %>


<%@ Register src="SA_SideMenu_Settings.ascx" tagname="SA_SideMenu_Settings" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            font-variant: small-caps;
            color: #4E5163;
            font-size: 12px;
            font-weight: bold;
            height: 20px;
            width: 235px;
            border-bottom: 1pt solid #D4DFAA;
            background-color: #E3F2CA;
        }
        .style3
        {
            font-variant: small-caps;
            color: #4E5163;
            font-size: 12px;
            font-weight: bold;
            height: 22px;
            width: 235px;
            border-bottom: 1pt solid #D4DFAA;
            background-color: #E3F2CA;
        }
        .style4
        {
            font-size: 11px;
            color: #4E5163;
            height: 22px;
            border-bottom: 1pt solid #D4DFAA;
            background-color: #E7F1D8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_Settings ID="SA_SideMenu_Settings1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


<script language="javascript" type="text/javascript">

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

//    function CheckOwnDomainName(source, arguments) {

//        var objOwnDomainName = /*'<%//=txtOwnDomain.ClientID%>'; */
//        var tmpDomainName = document.getElementById(objOwnDomainName).value;
//        
//        if(tmpDomainName.length == 0)
//        return false;
//        else
//        return true;
//       
//    
//    }


//    function ShowHideDivOwnDomain() {

//       /* var objrdoList = '<%=rdolstDomainType.ClientID%>'; */
//        //var strDomainType = document.getElementById(objDomainType).value;


//        if (objrdoList[1].checked) {
//            document.getElementById('dvOwnDomain').style.display = 'block';
//        }
//        
//        if (objrdoList[0].checked)
//         {
//            document.getElementById('dvOwnDomain').style.display = 'none';
//         }
//        return true;
//    
//    
//    }

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
    
    

</script>

<form id="form1" runat="server">

<table border="0" cellpadding="0" cellspacing="0" width="100%">
       
       
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table id="tblRegister" runat="server" visible="true" cellpadding="0" cellspacing="1" class="stdtableBorder_Main" width="98%">
                    <tr style="height:30px;">
                        <td width="1%">&nbsp;</td>
                        <td width="98%" align="left" class="font_12Msg_Error">
                            &nbsp;</td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                        
                        
                            <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
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
                      <asp:TextBox ID="txtPinNo" CssClass="stdTextField1" Text="9999999999" ReadOnly="true" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                          ControlToValidate="txtPinNo" Display="Dynamic" ErrorMessage="Please enter Pin No." 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                  </td>
                
              </tr>
                         
<%--    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" RenderMode="Inline" runat="server">
                        <ContentTemplate>--%>
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
                    
                <%--              </ContentTemplate>
                     <Triggers>            
                        <asp:AsyncPostBackTrigger ControlID="txtSubDomainName" EventName="TextChanged" />            
                    </Triggers>
                     
                        </asp:UpdatePanel> --%>
                        
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
                           
       <%--              </table>
              </ContentTemplate>
                </asp:UpdatePanel>
               --%>
                    </td>
                </tr>
                                <%--<asp:UpdateProgress DisplayAfter="3000" ID="UpdateProgress1" runat="server">
                      <ProgressTemplate>
                      <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/> Please wait...while we check for availability of subdomain.
                      </div>
                    </ProgressTemplate>
                      </asp:UpdateProgress>--%>
                
              <tr id="tr_ShowDomainError" runat="server" visible="true">
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      <%--<asp:CustomValidator ID="CustVd_Prefix" runat="server" 
                          ClientValidationFunction="CheckMobileCountryPrefix" 
                          ControlToValidate="txtMobileNo" Display="Dynamic" 
                          ErrorMessage=" * Should start with 100 only"></asp:CustomValidator>--%>
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
                        Domain Type</td>
                    <td class="tblFormText" width="80%">
                      <asp:RadioButtonList ID="rdolstDomainType" runat="server" CellPadding="5" 
                          CellSpacing="5" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="WEB10">WEB10</asp:ListItem>
                          <asp:ListItem Value="WEB30">WEB30</asp:ListItem>
                      </asp:RadioButtonList>
                      
                     <%-- <div id="dvOwnDomain">
                          <asp:Label ID="lblOwnD" runat="server" Text="Enter Domain Name"></asp:Label>&nbsp; : &nbsp;
                          www.<asp:TextBox ID="txtOwnDomain" MaxLength="20" runat="server"></asp:TextBox>.com
                          
                          <asp:CustomValidator ID="CustomValidator2" runat="server" 
                          ClientValidationFunction="CheckOwnDomainName" 
                          ControlToValidate="txtOwnDomain" Display="Dynamic" 
                          ErrorMessage="Cannot be Empty"></asp:CustomValidator>
                          
                          
                      </div>--%>
                      </td>
                </tr>
              
                <tr>
                    <td class="tblFormLabel" width="20%">
                        Debtor Mobile</td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtDebtorMobile" MaxLength="11" runat="server"  ValidationGroup="VgCheck" CssClass="stdTextField1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8"  ValidationGroup="VgCheck" ControlToValidate="txtDebtorMobile" Display="Dynamic" runat="server" ErrorMessage="Please enter Debtor Mobile"></asp:RequiredFieldValidator>
                        </td>
                </tr>
              
                <tr>
                    <td class="tblFormLabel" width="20%">
                        Purchaser Mobile</td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtPurchaserMobile" MaxLength="11" runat="server"  ValidationGroup="VgCheck" CssClass="stdTextField1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  ValidationGroup="VgCheck" ControlToValidate="txtPurchaserMobile" Display="Dynamic" runat="server" ErrorMessage="Please enter Purchaser Mobile"></asp:RequiredFieldValidator>
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
                  <asp:TextBox ID="txtMobileNo" CssClass="stdTextField1" MaxLength="13" Text="60" runat="server"></asp:TextBox>
                   
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
                     <%--<asp:CustomValidator ID="CustVd_Prefix" runat="server" 
                          ClientValidationFunction="CheckMobileCountryPrefix" 
                          ControlToValidate="txtMobileNo" Display="Dynamic" 
                          ErrorMessage=" * Should start with 100 only"></asp:CustomValidator>--%>
                          
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
              
              </table>
                            
                            
                            </td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td></tr></table>
                            </td></tr>
                            
        <tr>
            <td align="center">
     <table id="tblRegSucess" runat="server" visible="false" cellpadding="0" cellspacing="0" width="98%" class="stdtableBorder_Main">
         <tr  class="font_12BlueBold">
            <td  width="5%">&nbsp;</td>
             <td width="10%" align="left">
                  &nbsp;</td>
             <td width="80%" align="center">
                 &nbsp;</td>
             <td width="5%">&nbsp;</td>
         </tr>
         <tr  class="font_14SuccessBold">
             <td >&nbsp;</td>
             <td align="center" colspan="2">
                  Congratulations !!!&nbsp; Registration successfully completed. </td>
             <td>&nbsp;</td>
         </tr>
          <tr>
            <td >&nbsp;</td>
             <td colspan="2">
                 &nbsp;</td>
             
             <td>&nbsp;</td>
         </tr>
         <tr>
         <td>&nbsp;</td>
         <td colspan="2">
          <table border="0" cellpadding="0" cellspacing="0" class="stdtableBorder_Search">
          <tr height="50px">
            <td >&nbsp;</td>
             <td colspan="2">
                <b>Your Instant SubDomain :&nbsp; </b>
                <asp:Label ID="lblInstantSubdomainName" CssClass="font_12BlueBold" runat="server" Text="Label"></asp:Label>
                 
              </td>
             
             <td>&nbsp;</td>
         </tr>
         </table>
         
         </td>
          <td>&nbsp;</td>
         </tr>
        
         
        
          <tr>
            <td >&nbsp;</td>
             <td colspan="2">
                 &nbsp;</td>
             
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td colspan="2" class="font_12BlueBold">
                 Registration Details : - </td>
             
             <td>&nbsp;</td>
         </tr>
         
        
          <tr>
            <td >&nbsp;</td>
             <td colspan="2" align="left">
                 
                 <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="Table1">
              <tr>
                  
                  <td class="style2" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
               <tr>
                  
                  <td class="style2" >&nbsp;<asp:Label ID="Label4" 
                          runat="server" Text="Pin No"></asp:Label></td>
                  <td class="tblFormText" width="80%" >
                      <asp:TextBox ID="txtSuc_PinNo" CssClass="stdTextField1" runat="server" 
                          ReadOnly="True"></asp:TextBox>
                  </td>
                
              </tr>
                         
<%--              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">--%>
                <tr>
                    <td class="style2">
                        &nbsp;<asp:Label ID="Label5" runat="server" Text="Sudomain Name"></asp:Label>
                    &nbsp;/ Admin Login</td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtSuc_SubDomainName" runat="server" AutoPostBack="true" 
                            CssClass="stdTextField1" MaxLength="20" 
                            ReadOnly="True"></asp:TextBox>
                        
                                                 
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
                
               <tr>
                    <td class="style3">
                        &nbsp;<asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="style4" width="80%">
                        <asp:TextBox ID="txtSuc_loginPassword" MaxLength="15" runat="server" 
                            CssClass="stdTextField1" ReadOnly="True"></asp:TextBox>
                               
                    </td>
                </tr>
                
                
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                        &nbsp;</td>
                </tr>
              
                <tr>
                    <td class="style2">
                        &nbsp;<asp:Label ID="Label7" runat="server" Text="Full Name"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtSuc_Name" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td class="style2" valign="top">
                        &nbsp;<asp:Label ID="Label8" runat="server" Text="Country"></asp:Label>
                    </td>
                    <td class="tblFormText" valign="top">
                        <asp:TextBox ID="txtSuc_CountryName" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
               <tr> 
                  <td class="style2">&nbsp;<asp:Label ID="Label9" runat="server" 
                          Text="Mobile No."></asp:Label></td>
                  <td  class="tblFormText">
                  <asp:TextBox ID="TextBox4" CssClass="stdTextField1" MaxLength="11" Text="60" 
                          runat="server" ReadOnly="True"></asp:TextBox>
                   
                      &nbsp;
                               
                   </td>
                
              </tr>
              
              
              
                <tr>
                    <td class="style2">
                        &nbsp;<asp:Label ID="Label10" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="tblFormText">
                        <asp:TextBox ID="txtSuc_Email" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
              
              
               <tr>
                
                  <td class="style2" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="style2" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" ><font class="font_12Msg_Success">Save the Registration Details at a safe 
                      place. </font></td>
               
              </tr>
              
               </table>
                 
                 
                 
                 
                 </td>
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
                
                </td></tr>
                            
             </table></td></tr><tr>
            <td>
                &nbsp;</td></tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</asp:Content>

