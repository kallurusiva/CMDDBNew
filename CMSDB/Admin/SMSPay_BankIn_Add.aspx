<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="SMSPay_BankIn_Add.aspx.cs" Inherits="EBAd_BankIn_Add" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc3" %>

<%@ Register src="EBLeftMenu_SMSPayment.ascx" tagname="EBLeftMenu_SMSPayment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    

    .dispTable {
    /*border-collapse: collapse;*/
    border: 2px solid green;
    background-color: #FFFFFF; 
    FONT-SIZE: 12px; font-weight:bold; COLOR: #124C76; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;
    padding: 5px;
}
   
    .dispTable td {
       border-collapse: collapse;
        border: 1px dotted green;

    }

    </style>

    <style type="text/css">
    .style2
    {
        text-align: right;
    }
        .auto-style7 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: left;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        </style>


    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc1:EBLeftMenu_SMSPayment ID="EBLeftMenu_SMSPayment1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    
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

    <form id="tForm" runat="server" enctype="multipart/form-data" method="post"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </td>
            <asp:Label ID="lblPgFrom" runat="server" Text=""></asp:Label>
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
                            SMS Payment
                            Add Bank-In Details</td>
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
                        <td width="25%">
                            </td>
                        <td width="60%">
                            </td>
                        <td width="15%">
                            </td>
                        <td width="2%">
                            </td>
                    </tr>
                    <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               <asp:Literal ID="Literal3" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
                                &nbsp;
                                 <asp:Literal ID="Literal4" runat="server" 
                                Text="<%$ Resources:LangResources, Date %>"></asp:Literal></td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEvtDate" CssClass="stdTextField1" runat="server"></asp:TextBox>
                            <a href="javascript:ShowCal('<%=txtEvtDate.ClientID%>');">
                            <asp:Image ID="ImgCal" runat="server" BorderStyle="None" 
                                ImageUrl="~/Images/cal.gif" /></a>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Full Name : </td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblMemberName" runat="server"></asp:Label>

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Mobile ID :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblMobileID" runat="server"></asp:Label>

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     
                   
                     <tr>
                        <td class="tblFormLabel1">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            IC&nbsp; :<br />
                            </td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                         <asp:TextBox ID="txtIC" CssClass="stdTextField2" runat="server" ValidationGroup="vCheck"></asp:TextBox>
                        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtIC" runat="server" CssClass="ValAlert_Error" ErrorMessage="IC cannot be Empty." ValidationGroup="vCheck" Display="Dynamic"></asp:RequiredFieldValidator>          
                            <br />

                        </td>
                      <%--  <td class="auto-style6" align="left">
                            &nbsp;</td>--%>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">

                          <%--  <asp:RegularExpressionValidator ID="regexCategoryName" runat="server" ControlToValidate="txtCategoryName" Display="None" ErrorMessage="&lt;b&gt;Invalid Format&lt;/b&gt;&lt;br/&gt;Category Name supports Alphanumeric only" ValidationExpression="[a-zA-Z0-9\-_\s]{1,36}" ValidationGroup="vCheck" />--%>

                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
               
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            Bank Account No. :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                         <asp:TextBox ID="txtBankActNo" CssClass="stdTextField2" runat="server" ValidationGroup="vCheck"></asp:TextBox>
                        &nbsp;

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtBankActNo" runat="server" CssClass="ValAlert_Error" ErrorMessage="Bank Account No. cannot be Empty." ValidationGroup="vCheck" Display="Dynamic"></asp:RequiredFieldValidator>          
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>


                    
                   
                     <tr>
                        <td class="tblFormLabel1">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtBankActNo" ValidationExpression="^\d+$" runat="server" CssClass="ValAlert_Error" ValidationGroup="vCheck" Display="Dynamic" ErrorMessage="Only Numerics Allowed in Bank Account"></asp:RegularExpressionValidator>

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   

                    
                   
                     <%--<tr>
                        <td class="tblFormLabel1">
                            &nbsp;Bank Name :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                         <asp:TextBox ID="txtBankName" CssClass="stdTextField2" runat="server" ValidationGroup="vCheck"></asp:TextBox>

                        &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtBankName" runat="server" CssClass="ValAlert_Error" ErrorMessage="Enter Bank Name" ValidationGroup="vCheck" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>          

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Bank Address :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                         <asp:TextBox ID="txtBankAddress" CssClass="stdTextArea" Width="400px" runat="server" ValidationGroup="vCheck" Rows="3" TextMode="MultiLine"></asp:TextBox>

                        &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td class="tblFormLabel1">
                            Select Country :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="stdDropDown2">
                            </asp:DropDownList>

                        &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlCountry" runat="server" CssClass="ValAlert_Error" ErrorMessage="Select Country" ValidationGroup="vCheck" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>          

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="BtnSave" runat="server" ValidationGroup="vCheck" CssClass="stdbuttonCRUD" Text="Save my Bank Info" OnClick="BtnSave_Click" />
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td>
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

