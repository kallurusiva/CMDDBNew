<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_PayPalCC.aspx.cs" Inherits="EBAd_PayPalCC" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_PayPalCC.ascx" tagname="EBLeftMenu_PayPalCC" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            background-color: #EEEFEB;
            border-bottom: solid 1pt #D4DFAA;
            border-left: solid 1pt #D4DFAA;
            font-size: 12px;
            color: #0000FF;
            height: 25px;
            padding-left: 20px;
            text-align: left;
        }
        .auto-style3 {
            text-decoration: underline;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
   
        <uc2:EBLeftMenu_PayPalCC ID="EBLeftMenu_PayPalCC1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="tForm" runat="server" enctype="multipart/form-data" method="post">


        

            

            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
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
                            <table cellpadding="0" cellspacing="0" border="0" width="96%">
                    <tr>
                        <td align="center">
                             <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                              <tr>
                                    <td width="5%" align="left" valign="top">
                                        &nbsp;</td>
                                    <td width="90%" align="left" class="subHeaderFontGrad">
                                        &nbsp; Credit Card Payment&nbsp; </td>
                                    <td width="5%"  align="right" valign="top">
                                        &nbsp;</td>
                                </tr>
                             </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                                <tr>
                                    <td width="2%">
                                        &nbsp;</td>
                                    <td width="25%">
                                        &nbsp;</td>
                                    <td width="35%">
                                        &nbsp;</td>
                                    <td width="2%">
                                        &nbsp;</td>
                                </tr>
                    
                   
                                 <tr>
                                    <td class="auto-style7" >
                                        &nbsp;</td>
                                    <td class="auto-style7" >
                                        </td>
                                    <td class="auto-style3" align="left">
                                        &nbsp;</td>
                                    <td class="auto-style1">
                                        </td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                       <%-- Select your Email Address&nbsp; : --%></td>
                                    <td class="tblFormText1" align="left">
                                        <asp:RadioButton ID="rdoUsePayPalEmail" runat="server" CssClass="FontBHeader2" Checked="True" Text="Use My PayPal Email" GroupName="rdoEMAIL" />
                                            </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="left">
                                       <span class="FontNote"> Enter your PayPal Email </span></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        <%--Your Email ID :--%></td>
                                    <td class="tblFormText1" align="left">
                                        <asp:TextBox ID="txtPayPalEmail" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                     </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        <%--Your Password :--%> </td>
                                    <td class="tblFormText1" align="left">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="ValAlert_Error" 
                                      ControlToValidate="txtPayPalEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                      Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Email" ValidationGroup="VgCheck" 
                                      SetFocusOnError="True"></asp:RegularExpressionValidator>

                                      <asp:CustomValidator ID="CustomValidatorPaypal" Display="Dynamic" runat="server" ErrorMessage="" ControlToValidate="txtPayPalEmail"></asp:CustomValidator>
                         


                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        <%--URL to Login Email :--%></td>
                                    <td class="auto-style2">
                                        &nbsp;<span class="auto-style3"><strong>Instructions to Activate Paypal:</strong></span><br />
                                        <br />
                                        1)
                                        Pleae Login to your PAYPAL Account.<br />
                                        2)
                                        Click Dashboard.  At Left Menu -> Selling Tools<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        Please click at the Seller Preference
                                        <br />
                                        3)
                                        Choose Website Preferences -> Click Update<br />
                                        4)
                                        Select   <br />
                                         &nbsp;&nbsp;&nbsp;&nbsp;
                                         A)  AutoReturn ON <br />
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         B)  Key in Return URL - <br />
                                        <a href="http://183.81.165.110/WebApps/GsPayPal/EB_PayPalSuccess.aspx">http://183.81.165.110/WebApps/GsPayPal/EB_PayPalSuccess.aspx</a>
                                        <br />
                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                          C)  Select Payment Data Transfer ON<br />
                                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                      <strong>Click Save</strong>
                                        <br /><br />
                                        5) Go to DashBoard<br />
                                        6) Click Dashboard.  At Left Menu -> Selling Tools<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        Please click at the Seller Preference
                                        <br />
                                        7) Choose Instant Payment Notifications -> Update<br />
                                        8) Click Choose IPN Settings<br />
                                        9) Enter URL : <a href="http://183.81.165.110/WebApps/GsPayPal/EB_IPNHandler.aspx">http://183.81.165.110/WebApps/GsPayPal/EB_IPNHandler.aspx</a><br />
                                        10) Check Receive IPN Messages (Enabled)<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Click Save</strong><br />
                                     </td>
                                  
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="center">
                                        <asp:Label ID="lblError" runat="server" Visible="false" CssClass="ValAlert_Error"></asp:Label>
                                     </td>
                                  
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="center">
                                        <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                            Text="Save My Purchase Options" onclick="btnSave_Click" />
                                            </td>
                      
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="tblFormLabel1" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td class="font_12Msg_Error" align="left" style=" padding-left: 36px;" >
                                        <strong>NOTE</strong> : </td>
                                    <td style="text-align: left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td colspan="3" align="left" class="FontNote">
                                        <ul>
                                            <li>The PayPal Email account management is solely under your responsiblity. </li>
                                            <li>We encourage partners to change PayPal Password as it involves money in the account. </li>
                                            <li>Please remember your password. We do not manage or have any records with us with regards to your paypal account. </li>
                                        </ul>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
                
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

   
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

