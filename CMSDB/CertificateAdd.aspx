<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertificateAdd.aspx.cs" Inherits="CertificateAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Certificate</title>
     <link href="App_Themes/Common/CommonStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td width="2%"><a name="top"></a>
               <div class=" label-floating">
                                                    <label class="control-label">Upload Certiciate (pdf only)</label>
                                                    <asp:FileUpload ID="UploadImgCtrl" runat="server" CssClass="control-label" TabIndex="32" ToolTip="Click Browse to button to select a PDF from your computer." />
                                                     &nbsp;
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="UploadImgCtrl" Display="Dynamic" runat="server" ErrorMessage="Please Choose an Image for Voucher."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="FileUploadValidator" CssClass="col-md-12 text-danger text-center" runat="server"  ValidationGroup="VgCheck" Display="Dynamic"
                                                    ControlToValidate="UploadImgCtrl" ErrorMessage="Only pdf allowed." 
                                                    ValidationExpression="^.*\.(pdf|PDF)$" Enabled="true"></asp:RegularExpressionValidator>
                                                    <asp:CustomValidator ID="CustomValidator_BookImage" runat="server" ControlToValidate="UploadImgCtrl" Display="Dynamic" ValidationGroup="VgCheck"
                                                                   CssClass="col-md-12 text-danger text-center" ErrorMessage="" OnServerValidate="CustomVdr_eBookImage_ServerValidate"></asp:CustomValidator>
                                                    <br />
                                                    <asp:Label ID="lblErrorImg" CssClass="col-md-12 text-warning text-center" runat="server" Text=""></asp:Label>
                   <br /><br />
                   <asp:Button ID="btnSaveCont" runat="server" ValidationGroup="VgCheck" CssClass="btn btn-primary pull-right" 
                                            Text="Save and Continue" onclick="btnSaveCont_Click"  />
                                                </div></td>
            <td width="96%" class="font_12BlueBold" align="right">
                &nbsp;&nbsp;&nbsp;
                </td>
            <td width="2%">
                </td>
        </tr>
      
    </table>
    </div>
    </form>
</body>
</html>
