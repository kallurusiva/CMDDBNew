<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_BankIn_Edit.aspx.cs" Inherits="EBAd_BankIn_Edit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc3" %>

<%@ Register src="EBLeftMenu_PayPalCC.ascx" tagname="EBLeftMenu_PayPalCC" tagprefix="uc1" %>

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

        <uc1:EBLeftMenu_PayPalCC ID="EBLeftMenu_PayPalCC1" runat="server" />

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
                            Store ID :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lbleStoreID" runat="server"></asp:Label>

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Email : </td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lbleMailID" runat="server"></asp:Label>

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
                            Select Country :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="stdDropDown2" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            </asp:DropDownList>

                        &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlCountry" runat="server" CssClass="ValAlert_Error" ErrorMessage="Select Country" ValidationGroup="vCheck" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>          

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Select Bank :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:DropDownList ID="ddlMasterBanks" runat="server" CssClass="stdDropDown2">
                            </asp:DropDownList>

                        &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlMasterBanks" runat="server" CssClass="ValAlert_Error" ErrorMessage="Select Bank" ValidationGroup="vCheck" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>          

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
                            Full Name :<br />
                            ( Individual or Company )</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                         <asp:TextBox ID="txtFullName" CssClass="stdTextField2" runat="server" ValidationGroup="vCheck"></asp:TextBox>
                        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFullName" runat="server" CssClass="ValAlert_Error" ErrorMessage="Full Name cannot be Empty." ValidationGroup="vCheck" Display="Dynamic"></asp:RequiredFieldValidator>          
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
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtBankActNo" ValidationExpression="^\d+$" runat="server" CssClass="ValAlert_Error" ValidationGroup="vCheck" Display="Dynamic" ErrorMessage="Only Numerics Allowed in Bank Account"></asp:RegularExpressionValidator>&nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            Remarks / Note : </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtRemarks" runat="server" Rows="6" CssClass="stdTextArea1" TextMode="MultiLine" Width="400px"></asp:TextBox>
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
                        <td class="tblFormLabel1" >
                            Display at Website :</td>
                        <td class="tblFormText1" align="left">
                            <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
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
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="BtnSave" runat="server" ValidationGroup="vCheck" CssClass="stdbuttonCRUD" Text="Update my Bank Info" OnClick="BtnSave_Click" />
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

