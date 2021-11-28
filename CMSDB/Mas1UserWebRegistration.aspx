<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mas1UserWebRegistration.aspx.cs" Inherits="Mas1UserWebRegistration" %>

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
     height: 100px;
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
                   <font class="AdminFont"> Welcome to SMSBusiness World</font></td>
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
    &nbsp;</td>
<td width="1%">&nbsp;</td>
</tr>

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
<td>&nbsp;</td>
<td class="cssfaqQuestion font_14BoldGrey"> 
                &nbsp;</td>
<td>&nbsp;</td>
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
                <asp:Literal ID="ltrPartnerWebReg" Text="SubDomain Registration" runat="server"></asp:Literal>
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
                      &nbsp;</td>
                
              </tr>
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
              
              <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                     
                        <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>
                     
                       <%-- <asp:TextBox ID="txtName" runat="server" CssClass="stdTextField1"></asp:TextBox>--%>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtName" CssClass="font_11Msg_Error" Display="Dynamic" 
                            ErrorMessage="Please enter name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>--%>
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
                    <asp:Label ID="lblUserMobileNo" runat="server" Text=""></asp:Label>
                  <%--<asp:TextBox ID="txtMobileNo" CssClass="stdTextField1" MaxLength="11" Text="60" runat="server"></asp:TextBox>--%>
                   
                      &nbsp;
                               
                   </td>
                
              </tr>
              
                         
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
                         
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
                         
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
                   
                        [&nbsp; Everyone will be provided with 
                        a subdomain first.<br />
&nbsp; Own domain registration will be done inside admin login for PLATINUM users. ]</td>
                </tr>
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;<asp:Label ID="lblsubDomain" runat="server" Text="Sudomain Name"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                    
                <%--    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" RenderMode="Inline" runat="server">
                        <ContentTemplate>--%>
                        
                            <asp:TextBox ID="txtSubDomainName" runat="server" 
                            CssClass="stdTextField1" MaxLength="20" 
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
                    <div id="dv_ShowSbError" runat="server">&nbsp;
                        
                                                                             
                        </div>
                  </td>
                
              </tr>
              
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
                    <td class="tblFormLabel" width="20%">
                                                &nbsp;Retype subDomain </td>
                    <td class="tblFormText" width="80%">
                        
                            <asp:TextBox ID="txtSubDomainNameRetyped" runat="server"
                            CssClass="stdTextField1" MaxLength="20" 
                            ToolTip="Enter Subdomain name. Only Alphanumeric values are allowed."></asp:TextBox>
                        
                                                 
                        &nbsp;<asp:CompareValidator id="valCompare" runat="server"
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
              
                <tr>
                    <td class="tblFormLabel" width="20%">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                        &nbsp;</td>
                </tr>
              
                
               <tr>
                 
                  <td class="tblFormLabel">&nbsp;</td>
                  <td  class="tblFormText">
                          &nbsp;
                   
                   </td>
                 
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
