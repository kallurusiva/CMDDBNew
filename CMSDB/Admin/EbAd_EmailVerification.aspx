<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_EmailVerification.aspx.cs" Inherits="Admin_EbAd_EmailVerification" %>
<%@ Register src="LeftMenu_Profile.ascx" tagname="LeftMenu_Profile" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:LeftMenu_Profile ID="LeftMenu_Profile1" runat="server" />
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
                            Profile&nbsp; : Update and Verify My Email </td>
                        
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
                               <asp:PlaceHolder ID="trCurrentEmail" runat="server">
                                <tr style="height:25px;" >
                                    <td>
                                        <asp:Literal ID="ltrCurrentEmail" runat="server" Text="Current Email Address"></asp:Literal>
                                    </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblCurrentEmail" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height:25px;" runat="server">
                                    <td>
                                        <asp:Literal ID="Literal1" runat="server" Text="Status Email Address"></asp:Literal>
                                    </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblCurrentEmailStatus" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                </asp:PlaceHolder>
                               <asp:PlaceHolder ID="trNewEmail" runat="server">
                                <tr style="height:25px;" >
                                    <td>
                                        <asp:Literal ID="ltrNewEmail" runat="server" Text="New Email Address"></asp:Literal>
                                    </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblNewEmail" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height:25px;" runat="server">
                                    <td>
                                        <asp:Literal ID="ltrNewEmailStatus" runat="server" Text="Status New Email "></asp:Literal>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label ID="lblNewEmailStatus" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                </asp:PlaceHolder> 
                                <tr  style="height:25px;">
                                    <td>
                                        <asp:Literal ID="ltrChangeEmail" runat="server" Text="Change New Email Address"></asp:Literal></td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="TextBox_Email" runat="server" CssClass="stdInput_BlackFont" 
                                            MaxLength="100" Text="" Width="220px" />
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="TextBox_Email" CssClass="txtValidateRed" Display="Dynamic" 
                                            ErrorMessage="Enter your Email" SetFocusOnError="true" ValidationGroup="VgCheck"/>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                            ControlToValidate="TextBox_Email" CssClass="txtValidateRed" Display="Dynamic" 
                                            ErrorMessage="Invalid Field. Enter a Valid Email. Eg:user@domain.com" 
                                            SetFocusOnError="true" ValidationGroup="VgCheck"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                               
                               
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
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

