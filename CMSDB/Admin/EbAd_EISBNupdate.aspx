<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_EISBNupdate.aspx.cs" Inherits="Admin_EbAd_EISBNupdate" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc4" %>

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
    .auto-style3 {
        font-size: 12px;
        color: #4E5163;
        height: 25px;
        border-left: 1pt solid #D4DFAA;
        border-bottom: 1pt solid #D4DFAA;
        padding-left: 20px;
        background-color: #EEEFEB;
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
        .stdDropDown2 {
        }
        .stdTextField2 {}
        .auto-style10 {
            color: #CC0000;
            font-size: medium;
        }
        </style>    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc4:EBLeftMenu_Dashboard ID="EBLeftMenu_Dashboard1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    


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
                            &nbsp; Update EISBN Information</td>
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
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            EBook Code : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtEBookCode"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEBookCode" 
                                    ErrorMessage=" Please enter EBook code" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            EISBN No. : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtEISBNcode"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEISBNcode" 
                                    ErrorMessage=" Please enter EISBN code" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Approval Letter </td>
                        <td class="tblFormText1" align="left">
                                                    <asp:FileUpload ID="UploadImgCtrl" runat="server" CssClass="control-label" TabIndex="32" ToolTip="Click Browse to button to select an image from your computer." />
                                                     &nbsp;
                                                    <br />
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="UploadImgCtrl" Display="Dynamic" runat="server" ErrorMessage="Please Choose an Image for Voucher."></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="FileUploadValidator" CssClass="col-md-12 text-danger text-center" runat="server"  ValidationGroup="VgCheck" Display="Dynamic"
                                                    ControlToValidate="UploadImgCtrl" ErrorMessage="Only jpg, gif or Png type images are allowed.<br> Please select another image." 
                                                    ValidationExpression="^.*\.(jpg|JPG|gif|GIF|png|PNG)$" Enabled="true"></asp:RegularExpressionValidator>
                                                    <asp:CustomValidator ID="CustomValidator_BookImage" runat="server" ControlToValidate="UploadImgCtrl" Display="Dynamic" ValidationGroup="VgCheck"
                                                                   CssClass="col-md-12 text-danger text-center" ErrorMessage="" OnServerValidate="CustomVdr_eBookImage_ServerValidate"></asp:CustomValidator>
                                                    <br />
                                                    <asp:Label ID="lblErrorImg" CssClass="col-md-12 text-warning text-center" runat="server" Text=""></asp:Label>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Remarks :  </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtPRemarks"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" MaxLength="100" TextMode="MultiLine" Height="94px" Width="421px"></asp:TextBox>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            </td>
                        <td class="auto-style3" align="left">
                            <span class="auto-style10">
                            <strong>Please ensure that you have uploaded the admin EBook with changes done to the pdf to include the EISBN otherwise it will be Rejected. 
                            </strong>
                            </span>
                            <br />
Once approve we will credit 20 SMS credits to your account automatically.

                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            </td>
                        <td class="auto-style3" align="left">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="btn btn-primary pull-right" 
                                            Text="Save" onclick="btnSave_Click" />
                            </td>
                        <td class="tblFormText1" align="left">
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

