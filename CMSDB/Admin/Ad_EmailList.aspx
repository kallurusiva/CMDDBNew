<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_EmailList.aspx.cs" Inherits="Admin_Ad_EmailList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SideMenu_Email.ascx" tagname="SideMenu_Email" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SideMenu_Email ID="SideMenu_Email1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

<form id="form2" runat="server">

<script language="javascript" type="text/javascript">

    function Validate() {
       
        var objEmail1 = '<%=txtEmail1.ClientID%>';
        var objEmail2 = '<%=txtEmail2.ClientID%>';
        var objEmail3 = '<%=txtEmail3.ClientID%>';

        var objPassword1 = '<%=txtPassword1.ClientID%>';
        var objPassword2 = '<%=txtPassword2.ClientID%>';
        var objPassword3 = '<%=txtPassword3.ClientID%>';


        var tmpEmail1 = document.getElementById(objEmail1).value;
        var tmpEmail2 = document.getElementById(objEmail2).value;
        var tmpEmail3 = document.getElementById(objEmail3).value;

        var tmpPassword1 = document.getElementById(objPassword1).value;
        var tmpPassword2 = document.getElementById(objPassword2).value;
        var tmpPassword3 = document.getElementById(objPassword3).value;
        

        if ((tmpEmail1 == '') && (tmpEmail2 == '') && (tmpEmail3 == '')) {
            alert('Save operation cannot be Performed\n\nPlease enter atleast on email address to be save');
            return false;
        }

//        if ((tmpEmail1 != '') && (tmpEmail2 != '') && (tmpEmail3 != '')) {
//            if ((tmpEmail1 == tmpEmail2) || (tmpEmail1 == tmpEmail3)) {
//                alert(' One or more entered Email Addresses seems to match each other\n Please enter unique Email Address');
//                return false;
//            }
//            else if (tmpEmail2 == tmpEmail3) {
//                alert(' Email 2 and Email 3 seems to be Same \n Please enter unique Email Address');
//                return false;
//            }
//        }
//        else if ((tmpEmail1 != '') && (tmpEmail2 != '') && (tmpEmail3 == '')) {
//            if (tmpEmail1 == tmpEmail2) {
//                alert(' Email 1 and Email 2 seems to be Same \n Please enter unique Email Address');
//                return false;
//            }
//        }

//        else if ((tmpEmail1 != '') && (tmpEmail2 == '') && (tmpEmail3 != '')) {
//            if (tmpEmail1 == tmpEmail3) {
//                alert(' Email 1 and Email 3 seems to be Same \n Please enter unique Email Address');
//                return false;
//            }
//        }

//        else if ((tmpEmail1 == '') && (tmpEmail2 != '') && (tmpEmail3 != '')) {
//            if (tmpEmail2 == tmpEmail3) {
//                alert(' Email 2 and Email 3 seems to be Same \n Please enter unique Email Address');
//                return false;
//            }
        //        }

        if (tmpEmail1 != '') {
            if (tmpPassword1 == '') {
                alert(' Please enter password for Row one');
                return false;
            }
        }
        else if (tmpEmail2 != '') {
            if (tmpPassword2 == '') {
                alert(' Please enter password for Row two');
                return false;
            }
        }
        else if (tmpEmail3 != '') {
            if (tmpPassword3 == '') {
                alert(' Please enter password for Row three');
                return false;
            }
        }
        


    }


    


</script>

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
                            &nbsp;<asp:Literal ID="LtrEmailList" runat="server"></asp:Literal></td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="98%">
                    <tr style="height:30px;">
                        <td width="3%">&nbsp;</td>
                        <td width="4%">&nbsp;</td>
                        <td width="90%" align="left" class="font_12Msg_Error">
                            <asp:Literal ID="LtrValidEmailALert" runat="server"></asp:Literal> 
                            <asp:HiddenField ID="hdEmail1" runat="server" />
                            <asp:HiddenField ID="hdEmail2" runat="server" />
                            <asp:HiddenField ID="hdEmail3" runat="server" />
                          </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td align="left">
                        
                        
                            &nbsp;</td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td align="left">
                        
                        
                            <table cellpadding="0" cellspacing="0" width="100%" style="border : solid 1px #cdedea;">
                                <tr>
                                    <td width="2%">
                                        &nbsp;</td>
                                    <td width="25%">
                                        &nbsp;</td>
                                    <td width="25%">
                                        &nbsp;</td>
                                    <td width="10%">
                                        &nbsp;</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                                <tr class="PanelCss_Head">
                                    <td>
                                       &nbsp; </td>
                                    <td>
                                        <b>Email Name</b></td>
                                    <td>
                                        <b>Password</b></td>
                                    <td>
                                        <b>Status</b></td>
                                    <td>
                                        <b>Date Requested</b></td>
                                    <td>
                                        <b>Date Approved</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr runat="server" id="tRow1">
                                    <td>
                                        1</td>
                                    <td>
                        
                        
                            <asp:TextBox ID="txtEmail1" CssClass="stdTextField1" runat="server"></asp:TextBox>
                            <asp:Literal ID="ltrDomainName1" runat="server"></asp:Literal>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail1" ValidationExpression="^[0-9a-zA-Z_]+$" Display="Dynamic" runat="server" ErrorMessage="<br/>Invalid Email"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword1" CssClass="stdTextField1" runat="server"> </asp:TextBox>
                                            <asp:RegularExpressionValidator ID="valPassword" runat="server" 
                                               ControlToValidate="txtPassword1" ValidationGroup="Vg1MayLogin" 
                                               ErrorMessage="<br/> * Minimum Password haracter length is 6"
                                               ValidationExpression=".{6}.*" />
                                               

                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrPending1" Text="Pending" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrDateRequested1" Text="" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrDateApproved1" Text="" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr  runat="server" id="tRow2">
                                    <td>
                                        2</td>
                                    <td>
                            <asp:TextBox ID="txtEmail2"  CssClass="stdTextField1"  runat="server"></asp:TextBox>
                            <asp:Literal ID="ltrDomainName2" runat="server"></asp:Literal>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtEmail2" ValidationExpression="^[0-9a-zA-Z_]+$" Display="Dynamic" runat="server" ErrorMessage="<br/>Invalid Email"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword2" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                               ControlToValidate="txtPassword2" ValidationGroup="Vg1MayLogin" 
                                               ErrorMessage="<br/> * Minimum Password haracter length is 6"
                                               ValidationExpression=".{6}.*" />
                       
                                               
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrPending2" Text="Pending" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrDateRequested2" Text="" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrDateApproved2" Text="" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td  runat="server" id="tRow3">
                                        3</td>
                                    <td>
                            <asp:TextBox ID="txtEmail3"  CssClass="stdTextField1"  runat="server"></asp:TextBox>
                            <asp:Literal ID="ltrDomainName3" runat="server"></asp:Literal>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtEmail3" ValidationExpression="^[0-9a-zA-Z_]+$" Display="Dynamic" runat="server" ErrorMessage="<br/>Invalid Email"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword3" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                               ControlToValidate="txtPassword3" ValidationGroup="Vg1MayLogin" 
                                               ErrorMessage="<br/> * Minimum Password haracter length is 6"
                                               ValidationExpression=".{6}.*" />
                                
                                                                                              
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrPending3" Text="Pending" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrDateRequested3" Text="" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrDateApproved3" Text="" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
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
                            <asp:Button ID="BtnSave" runat="server" Text="SAVE" 
                                OnClientClick="return Validate();" onclick="BtnSave_Click" 
                                style="height: 26px" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
                        </td>
                        <td>
                        <font class="font_12Msg_Error">
                            <asp:Literal ID="LtrEmailNoteId" runat="server"></asp:Literal> 
                             </font>
                        </td></tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td></tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td></tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
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

