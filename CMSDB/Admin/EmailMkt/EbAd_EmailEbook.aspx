<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_EmailEbook.aspx.cs" Inherits="Admin_EmailMkt_EbAd_EmailEbook" %>
<%@ Register src="EBLeftMenu_SendEmail.ascx" tagname="EBLeftMenu_SendEmail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.auto-style1 {
width: 100%;
}
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
.auto-style1 {
height: 25px;
}
.auto-style3 {
font-size: 12px;
color: #4E5163;
height: 25px;
border-left: 1pt solid #D4DFAA;
border-bottom: 1pt solid #D4DFAA;
padding-left: 20px;
background-color: #EEEFEB;
}
.auto-style4 {
height: 27px;
}
.auto-style6 {
background-color: #EEEFEB;
border-bottom: solid 1pt #D4DFAA;
border-left: solid 1pt #D4DFAA;
font-size: 12px;
color: #4E5163;
height: 27px;
padding-left: 20px;
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
        <uc1:EBLeftMenu_SendEmail ID="EBLeftMenu_SendEmail1" runat="server" />
        </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="tForm" runat="server" enctype="multipart/form-data" method="post"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                
                </td>
        </tr>
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../../Images/inf_Error.gif" alt="MessageImage"/></td>
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
                            &nbsp; Email Marketing </td>
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
                        <td style="width:2%"></td>
                        <td style="width:25%"></td>
                        <td></td>                            
                        <td style="width:2%"></td>
                    </tr>
                    
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >&nbsp;</td>
                        <td class="auto-style7">Product Code: <font color="red">*</font></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtBookID" ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" TabIndex="2"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBookID" ErrorMessage=" Please enter Book ID" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style7">Email To : </td>
                        <td class="tblFormText1" align="left">
                            <table border="0" cellpadding="0" cellspacing="0" width="520px;" style="border: solid 1px #808080; padding: 5px; background-color: #FFFFFF;">
                                    <tr>
                                    <td class="RowFormLabel">&nbsp;</td>
                                    <td class="RowFormText">&nbsp;Name &nbsp;</td>
                                    <td class="RowFormText"> Email</td>
                                    </tr>

                                    <tr>
                                    <td class="RowFormLabel" valign="top">Recipient 1<span class="font_12Msg_Error">*</span></td>
                                    <td class="RowFormText">
                                    <asp:TextBox ID="TextBoxName1" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox><br />                                                  
                                    <asp:RequiredFieldValidator ID="rfvName1" runat="server" Display="Dynamic" ErrorMessage="Enter at least one recipient" ControlToValidate="TextBoxName1" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="RowFormText"> 
                                    <asp:TextBox ID="TextBoxEmail1" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="rfvEmail1" runat="server" Display="Dynamic" ErrorMessage="Enter at least one email" ControlToValidate="TextBoxEmail1" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TextBoxEmail1" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                    </td>
                                    </tr>

                                    <tr>
                                    <td class="RowFormLabel">Recipient 2</td>
                                    <td class="RowFormText">  
                                    <asp:TextBox ID="TextBoxName2" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td class="RowFormText">  
                                    <asp:TextBox ID="TextBoxEmail2" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TextBoxEmail2" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                    </td>
                                    </tr>

                                    <tr>
                                    <td class="RowFormLabel">Recipient 3</td>
                                    <td class="RowFormText"> 
                                    <asp:TextBox ID="TextBoxName3" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td class="RowFormText"> 
                                    <asp:TextBox ID="TextBoxEmail3" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TextBoxEmail3" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                    </td>
                                    </tr>

                                    <tr>
                                    <td class="RowFormLabel">Recipient 4</td>
                                    <td class="RowFormText"> 
                                    <asp:TextBox ID="TextBoxName4" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td class="RowFormText"> 
                                    <asp:TextBox ID="TextBoxEmail4" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TextBoxEmail4" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                    </td>
                                    </tr>

                                    <tr>
                                    <td class="RowFormLabel">Recipient 5</td>
                                    <td class="RowFormText"> 
                                    <asp:TextBox ID="TextBoxName5" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td class="RowFormText"> 
                                    <asp:TextBox ID="TextBoxEmail5" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="TextBoxEmail5" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                    </td>
                                    </tr>
                        </table>
                        <br />
                            <span class="font_11Msg_Error">Note :&nbsp; SMS Balance credit deduction 0.5 credits per Email</span></td>
                        <td class="tblFormText1">&nbsp;</td>
                        <td>&nbsp;</td>
                        </tr>
                     <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1">&nbsp;</td>
                        <td class="style4">&nbsp;</td>
                    </tr>   
                     <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style7">Subject : </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="TextBoxSubject" runat="server" CssClass="stdTextField1" Width="250px" MaxLength="300" Text='Recommended Ebooks'/>
                        </td>
                        <td class="tblFormText1">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>   
                     <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style7">Remarks : </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="TextBoxRemarks" runat="server" TextMode="MultiLine" CssClass="stdTextArea1"/>
                        </td>
                        <td class="tblFormText1">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Email Sign Offs :</td>
                        <td class="tblFormText1" align="left">
                            <asp:DropDownList ID="ddlSignature" runat="server" CssClass="stdDropDown">
                            <asp:ListItem Value="Best Regards">Best Regards</asp:ListItem>
                            <asp:ListItem Value="Best Wishes">Best Wishes</asp:ListItem>
                            <asp:ListItem Value="Cordially">Cordially</asp:ListItem>                                    
                            <asp:ListItem Value="Sincerely Yours">Sincerely Yours</asp:ListItem>
                            <asp:ListItem Value="Yours Truly">Yours Truly</asp:ListItem>
                            <asp:ListItem Value="With Many Thanks">With Many Thanks</asp:ListItem>                                    
                            </asp:DropDownList>
                        </td>
                        <td class="tblFormText1">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>                   
                     <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style7">Signature : </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="TextBoxYourName" runat="server" CssClass="stdTextField1" Width="180px" MaxLength="50"/>
                        </td>
                        <td class="tblFormText1">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                   
                     
                   
                     <tr>
                        <td class="tblFormLabel1" >
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
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD"  Text="Preview and Confirm Email" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD"  Text="Cancel" onclick="btnCancel_Click" />
                                </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>                    
                       
                     <tr>
                        <td class="tblFormLabel1" >
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
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
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


