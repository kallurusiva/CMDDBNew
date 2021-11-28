<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_ValueBuyEdit.aspx.cs" Inherits="EBAd_ValueBuyEdit" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc4" %>

<%@ Register src="EBLeftMenu_ValueBuy.ascx" tagname="EBLeftMenu_ValueBuy" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_ebButtons.ascx" tagname="EBLeftMenu_ebButtons" tagprefix="uc2" %>

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
        </style>


<script type="text/javascript">
      

</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc2:EBLeftMenu_ebButtons ID="EBLeftMenu_ebButtons1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    <script language="javascript" type="text/javascript">

        function CheckTextLength(text, long) {
            var maxlength = new Number(long); // Change number to your max length.
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                alert("for SMS Reply  Only " + long + " characters allowed");
            }
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



</script>

    <form id="tForm" runat="server" enctype="multipart/form-data">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </td>
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
                            &nbsp; Update Value Buy </td>
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
                        <td width="20%">
                            &nbsp;</td>
                        <td width="45%">
                            &nbsp;</td>
                        <td width="25%">
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
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
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Value Buy Product Code :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="lblBookCode" runat="server"></asp:Label>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Value Buy Title :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtBookName"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" TabIndex="2"></asp:TextBox>

                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="VgCheck" ControlToValidate="txtBookName" ErrorMessage="Cannot be Empty. " SetFocusOnError="True"></asp:RequiredFieldValidator>

                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            No. of Products :</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoNoOfBooks" runat="server" CellPadding="10" CellSpacing="1" CssClass="font_12Normal" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoNoOfBooks_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style1">
                            </td>
                        <td class="tblFormLabel1" >
                            </td>
                        <td class="auto-style1 FontBRowHelp" align="left">
                            Enter Book Codes to be included in Value Buy</td>
                        <td class="tblFormText1" align="left">
                            </td>
                        <td class="auto-style1">
                            </td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style1">
                            </td>
                        <td class="tblFormLabel1">
                            Product Code :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtBookID1"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" AutoPostBack="True" Visible="False" OnTextChanged="txtBookID1_TextChanged"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidatorBook1" runat="server" CssClass="ValAlert_Error" Display="None" ErrorMessage="BookID does not Exists" SetFocusOnError="true" ValidationGroup="VgCheck" />
                            <asp:Label ID="lblBookCheck1" runat="server" CssClass="" Visible="false" Text=""></asp:Label>

                            <br />
                            <br />
                            <asp:TextBox ID="txtBookID2"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" AutoPostBack="True" Visible="False" OnTextChanged="txtBookID2_TextChanged"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidatorBook2" runat="server" CssClass="ValAlert_Error" Display="None" ErrorMessage="BookID does not Exists" SetFocusOnError="true" ValidationGroup="VgCheck" />
                           <asp:Label ID="lblBookCheck2" runat="server" CssClass="" Visible="false" Text=""></asp:Label>

                            <br />
                            <br />
                            <asp:TextBox ID="txtBookID3"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" AutoPostBack="True"  Visible="False" OnTextChanged="txtBookID3_TextChanged"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidatorBook3" runat="server" CssClass="ValAlert_Error" Display="None" ErrorMessage="BookID does not Exists" SetFocusOnError="true" ValidationGroup="VgCheck" />
                           <asp:Label ID="lblBookCheck3" runat="server" CssClass="" Visible="false" Text=""></asp:Label>

                            <br />
                            <br />
                            <asp:TextBox ID="txtBookID4"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" AutoPostBack="True"  Visible="False" OnTextChanged="txtBookID4_TextChanged"></asp:TextBox>
                           
                            <asp:CustomValidator ID="CustomValidatorBook4" runat="server" CssClass="ValAlert_Error" Display="None" ErrorMessage="BookID does not Exists" SetFocusOnError="true" ValidationGroup="VgCheck" />
                           <asp:Label ID="lblBookCheck4" runat="server" CssClass="" Visible="false" Text=""></asp:Label>

                            <br />
                            <br />
                            <asp:TextBox ID="txtBookID5"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" AutoPostBack="True"  Visible="False" OnTextChanged="txtBookID5_TextChanged"></asp:TextBox>
                           
                            <asp:CustomValidator ID="CustomValidatorBook5" runat="server" CssClass="ValAlert_Error" Display="None" ErrorMessage="BookID does not Exists" SetFocusOnError="true" ValidationGroup="VgCheck" />
                           <asp:Label ID="lblBookCheck5" runat="server" CssClass="" Visible="false" Text=""></asp:Label>

                            <br />
                            <asp:Label ID="lblBookIDResult" Visible="false" CssClass="ValAlert_Error" runat="server"></asp:Label>
                            <br />
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style1">
                            </td>
                    </tr>
                   
                     <tr>
                        <td>
                            &nbsp;</td>
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
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Price :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtPrice"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" AutoPostBack="True" OnTextChanged="txtPrice_TextChanged"></asp:TextBox>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Discount :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtDiscount"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                            &nbsp;%</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Discounted Price :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtDiscountedPrice"  runat="server" CssClass="stdTextField1"></asp:TextBox>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td  class="tblFormLabel1" >
                            Display Status :</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoLaunchStatus" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="26">
                                <asp:ListItem Selected="True" Value="1">Launch Now</asp:ListItem>
                                <asp:ListItem Value="2">Coming Soon</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td  class="tblFormLabel1" >
                            Display at Website</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoDisplayatWebsite" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            </td>
                        <td class="tblFormLabel1" >
                            Display on HomePage</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoDispHomePage" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            </td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="" align="left">
                          
                         </td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Can buy using PayPal ?</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoBuyPayPal" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Can buy using SMS ?</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoBuySMS" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Subject :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtSubject"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="VgCheck" ControlToValidate="txtSubject" ErrorMessage="Enter Subject" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Sender Email ID :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtSenderEmailID"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2"></asp:TextBox>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            SMS reply to Customer :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtSMSmessage"  ValidationGroup="VgCheck" onKeyUp="CheckTextLength(this,150)" onChange="CheckTextLength(this,150)" MaxLength="150" runat="server" CssClass="stdTextArea2" TextMode="MultiLine" Width="600px" Height="100px"></asp:TextBox>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Email message to Customer :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtEmailMessage" CssClass="stdTextArea2" runat="server"  Width="600px" Height="200px"
                                ToolTip="Enter Description"  ValidationGroup="VgCheck" 
                                TextMode="MultiLine"></asp:TextBox>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                 <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            SMS CC copy&nbsp;
                            to following Mobiles.
                            <br />
                            <br />
                            ( e.g. to Supplier / Author / Publisher etc., )<br />
                         </td>
                        <td class="tblFormText1" align="left">
                           <br />  
                         1.
                                    <asp:TextBox ID="txtCCMobile1" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                    <br />
                                    2.
                                    <asp:TextBox ID="txtCCMobile2" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                    <br />
                                    3. <asp:TextBox ID="txtCCMobile3" runat="server" CssClass="stdTextField1"></asp:TextBox>
                         <br />
                            <br />
                        </td>
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
                            <asp:Label ID="lblShowSaveBtn" Visible="false" CssClass="ValAlert_Success" runat="server" Text=""></asp:Label>
                         </td>
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
                            <asp:Button ID="btnPreview" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Preview" OnClick="btnPreview_Click"/>
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Save" onclick="btnSave_Click" Visible="false" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD" 
                                Text="Cancel" onclick="btnCancel_Click" />
                                </td>
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
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                     &nbsp;
                        </td>
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

