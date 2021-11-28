<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_BuyAdminBook.aspx.cs" Inherits="Admin_EbAd_BuyAdminBook" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            text-decoration: underline;
            width: 27%;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            width: 27%;
        }
        .auto-style6 {
            background-color: #EEEFEB;
            border-bottom: solid 1pt #D4DFAA;
            border-left: solid 1pt #D4DFAA;
            font-size: 12px;
            color: #4E5163;
            height: 25px;
            padding-left: 20px;
            width: 27%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
   
        <uc2:EBLeftMenu_Dashboard ID="EBLeftMenu_Dashboard1" runat="server" />
    
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
                                        &nbsp; Buying EBook&nbsp; </td>
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
                                    <td class="auto-style5">
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
                                    <td class="auto-style6" align="left">
                                        Buying EBook By MWallet Deduction</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblMW" runat="server" Text="Your MWallet Balance"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblMWallet" runat="server" Text=""></asp:Label></td>
                                </tr>

                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td rowspan="11" >
                                         <asp:Image ID="lblImageFilePath" Width="213px" Height="312px" runat="server" /><br />
                                         Added on : <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="auto-style6" align="left">                                        
                                            <asp:Label ID="lblBCode" runat="server" Text="Book Code"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblBookCode" runat="server" Text=""></asp:Label></td>
                                </tr>

                                

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblBTitle" runat="server" Text="Book Title"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblBookTitle" runat="server" Text=""></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblDes" runat="server" Text="Description"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblAPrice" runat="server" Text="Price"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblActualPrice" runat="server" Text="USD 2.00"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblDis" runat="server" Text="Discount"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblDiscount" runat="server" Text=""></asp:Label></td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblBPrice" runat="server" Text="Net Price"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblBookPrice" runat="server" Text="USD 2.00"></asp:Label></td>
                                </tr>
                   
                                 
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblFullName" runat="server" Text="Enter Full Name (*)"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtcName" runat="server"></asp:TextBox>
                                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="VgCheck" ControlToValidate="txtcName" CssClass="text-custom" ErrorMessage="Name cannot be Empty"></asp:RequiredFieldValidator></td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblEmail" runat="server" Text="Enter Email (*)"></asp:Label></td>
                                  
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtcEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqValImage" ControlToValidate="txtcEmail" runat="server" ErrorMessage="Enter Email ID." ValidationGroup="VgCheck" Display="Dynamic" CssClass="text-custom"></asp:RequiredFieldValidator>

                                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                  ControlToValidate="txtcEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                  Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Email" ValidationGroup="VgCheck" 
                                                  SetFocusOnError="True" CssClass="text-custom"></asp:RegularExpressionValidator></td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="left">
                                        <asp:Label ID="lblMobile" runat="server" Text="Enter Mobile (*)"></asp:Label></td>
                                  
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtcMobile" runat="server"></asp:TextBox> 
              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtcMobile" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Mobile No. cannot be Empty"></asp:RequiredFieldValidator>
              &nbsp; 
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                                                  ControlToValidate="txtcMobile" ValidationExpression="^[1-9][0-9]*$" 
                                                  Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Mobile without leading zero" ValidationGroup="VgCheck" 
                                                  SetFocusOnError="True" CssClass="text-custom"></asp:RegularExpressionValidator></td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="center">
                                        &nbsp;</td>
                                  
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" align="center">
                                        <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                            Text="Confirm Buy" onclick="btnSave_Click" Width="258px" OnClientClick="return confirm('Are you Confirm?');" />
                                        
                                        <asp:Label ID="lblFreeze" runat="server" Visible="true"></asp:Label>


                                            </td>
                      
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                            Text="Cancel" onclick="btnCancel_Click" Width="258px" /></td>
                                </tr>
                   
                                
                   
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td class="font_12Msg_Error" align="left" style=" padding-left: 36px;" >
                                        &nbsp;</td>
                                    <td style="text-align: left" class="auto-style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                    <td class="auto-style5">
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

