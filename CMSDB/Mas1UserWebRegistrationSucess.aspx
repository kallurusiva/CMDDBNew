<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mas1UserWebRegistrationSucess.aspx.cs" Inherits="Mas1UserWebRegistrationSucess" %>

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
                   <font class="AdminFont"> Welcome to Website Registration </font> </td>
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
<td>&nbsp;</td>
<td class="cssfaqQuestion font_14BoldGrey"> 
                &nbsp;</td>
<td>&nbsp;</td>
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
                <asp:Literal ID="ltrPartnerWebReg" Text="Website Registration" runat="server"></asp:Literal>
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

  <table cellpadding="0" cellspacing="0" width="100%" class="stdtableBorder_Main">
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
             <td colspan="2">
                 
                 <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
              <tr>
                  
                  <td class="tblFormLabel" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
               <tr>
                  
                  <td class="tblFormLabel" >&nbsp;<asp:Label ID="Label1" 
                          runat="server" Text="Pin No"></asp:Label></td>
                  <td class="tblFormText" width="80%" >
                      <asp:TextBox ID="txtPinNo" CssClass="stdTextField1" runat="server" 
                          ReadOnly="True"></asp:TextBox>
                  </td>
                
              </tr>
                         
<%--              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">--%>
                <tr>
                    <td class="tblFormLabel">
                        &nbsp;<asp:Label ID="lblsubDomain" runat="server" Text="Sudomain Name"></asp:Label>
                    &nbsp;/ Admin Login</td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtSubDomainName" runat="server" AutoPostBack="true" 
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
                    <td class="tblFormLabel">
                        &nbsp;<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtloginPassword" MaxLength="15" runat="server" 
                            CssClass="stdTextField1" ReadOnly="True"></asp:TextBox>
                               
                    </td>
                </tr>
                
                
                <tr>
                    <td class="tblFormLabel">
                        &nbsp;</td>
                    <td class="tblFormText" width="80%">
                        &nbsp;</td>
                </tr>
              
                <tr>
                    <td class="tblFormLabel">
                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label>
                    </td>
                    <td class="tblFormText" width="80%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td class="tblFormLabel" valign="top">
                        &nbsp;<asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                    </td>
                    <td class="tblFormText" valign="top">
                        <asp:TextBox ID="txtCountryName" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
               <tr> 
                  <td class="tblFormLabel">&nbsp;<asp:Label ID="lblMobileNo" runat="server" 
                          Text="Mobile No."></asp:Label></td>
                  <td  class="tblFormText">
                  <asp:TextBox ID="txtMobileNo" CssClass="stdTextField1" MaxLength="11" Text="60" 
                          runat="server" ReadOnly="True"></asp:TextBox>
                   
                      &nbsp;
                               
                   </td>
                
              </tr>
              
              
              
                <tr>
                    <td class="tblFormLabel">
                        &nbsp;<asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="tblFormText">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="stdTextField1" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
              
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
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
         
        
          <tr>
            <td >&nbsp;</td>
           
             <td align="center" colspan="2">
        
        <div id="dvAdminLogin" class="loginCss1021">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                    
                    <td colspan="3">
                    
                      <%--  <td style="height:30px;" width="20px" align="left" valign="top">
                        <img alt="topleftarc" src="Images/table_top_Leftarc.gif" 
                        style="width: 10px; height: 20px" />
                        </td>
                        <td class="loginfontTitle">Members Login</td>--%>
                        
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
                    <td class="loginfont12">Login Id</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtLoginID"  CssClass="loginTextBox" runat="server" 
                            ValidationGroup="VgMainLogin"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Please enter LoginID"  CssClass="font_12Msg_Error" 
                            ControlToValidate="txtLoginID" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="VgMainLogin"></asp:RequiredFieldValidator>
                          </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr  style="height:20px; vertical-align:baseline;">
                    <td>&nbsp;</td>
                    <td  class="loginfont12">Password</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPassword" CssClass="loginTextBox" runat="server" 
                            style="margin-bottom: 0px" TextMode="Password" 
                            ValidationGroup="VgMainLogin"></asp:TextBox>
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
                    
                      <tr>
                    <td>&nbsp;</td>
                    <td class="font_forgotPwd" align="right">forgot password</td>
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td class="font_12Msg_Error">
                        <asp:Literal ID="LtrErrMessage" Text="" runat="server"></asp:Literal>
                        </td>
                    <td>&nbsp;</td>
                    </tr>
                    
                      </table>
         
        </div>
        
        
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
         
        
          <tr>
            <td >&nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>&nbsp;</td>
         </tr>
         
        
     </table></td>
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
