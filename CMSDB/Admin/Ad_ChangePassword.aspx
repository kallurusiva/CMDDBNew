<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_ChangePassword.aspx.cs" Inherits="Admin_Ad_ChangePassword" %>

<%@ Register src="SideMenu_MyAccount.ascx" tagname="SideMenu_MyAccount" tagprefix="uc1" %>

<%@ Register src="LeftMenu_Profile.ascx" tagname="LeftMenu_Profile" tagprefix="uc2" %>

<%@ Register src="EbLeftMenu_Profile.ascx" tagname="EbLeftMenu_Profile" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:EbLeftMenu_Profile ID="EbLeftMenu_Profile1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

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
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;</td>
                        
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="1" class="stdtableBorder_Main" width="100%">
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
                        
                        
                            <table cellpadding="0" cellspacing="2" style="width: 100%;" class="stdtableBorder_Only">
                                <tr>
                                    <td width="20%">&nbsp;</td>
                                    <td width="2%">&nbsp;</td>
                                    <td width="50%">&nbsp;</td>
                                </tr>
                                <tr  style="height:25px;">
                                    <td>
                                        <asp:Literal ID="ltrCurrentPassword" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtCurrentPassword" ValidationGroup="VgCheck" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            Display="Dynamic" ErrorMessage="enter Current password"  ValidationGroup="VgCheck"  
                                            SetFocusOnError="True" ControlToValidate="txtCurrentPassword"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr  style="height:25px;">
                                    <td>
                                        <asp:Literal ID="ltrNewPassword" runat="server"></asp:Literal></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtNewPassword" MaxLength="20" CssClass="stdTextField1"  ValidationGroup="VgCheck" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="VgCheck" 
                                            Display="Dynamic" ErrorMessage="enter New password" SetFocusOnError="True" 
                                            ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
                                         <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                 runat="server"  ValidationGroup="VgCheck"  
                                                 ControlToValidate="txtNewPassword"
                                                 ErrorMessage="Must have at least 1 number, 1 special character, 
                                                    and more than 6 characters." 
                                                 ValidationExpression="(?=^.{6,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$"></asp:RegularExpressionValidator>
                               --%>
                                <asp:RegularExpressionValidator ID="valPassword" runat="server" 
                               ControlToValidate="txtNewPassword" ValidationGroup="VgCheck" 
                               ErrorMessage="<br/> * Password must be atleast 6 characters."
                               ValidationExpression=".{6,}.*" />
                               
                               
                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        <asp:Literal ID="ltrRetypeNewPassword" runat="server"></asp:Literal></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtRetypePassword" MaxLength="20" CssClass="stdTextField1" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            Display="Dynamic" ErrorMessage="enter retpe  password"  ValidationGroup="VgCheck"  
                                            SetFocusOnError="True" ControlToValidate="txtRetypePassword"></asp:RequiredFieldValidator>
                                            
                                            <asp:CompareValidator id="valCompare" runat="server"
                                               ControlToValidate="txtRetypePassword" ControlToCompare="txtNewPassword"
                                               Operator="Equal"  ValidationGroup="VgCheck" 
                                               ErrorMessage="* Entered New Password and reTyped password does not match"
                                               Display="dynamic">
                                            </asp:CompareValidator>

                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="stdbuttonAction" 
                                Text="Save"  ValidationGroup="VgCheck" onclick="btnSave_Click" /> &nbsp; 
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonAction" 
                                Text="Cancel" onclick="btnCancel_Click" />
                                <%--&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>" />--%>
                        </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
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
                                </tr>
                                
                              <%--  <tr>
                                    <td>
                                        <asp:Literal ID="ltrForGotPassword" runat="server"></asp:Literal></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="lnkForgotPassword" CssClass="links_SideMenu" runat="server" onclick="lnkForgotPassword_Click" 
                                            >Click here recieve your password by Email</asp:LinkButton>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>--%>
                                
                            </table>
                        </td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    </form>
</asp:Content>

