<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestEditor.aspx.cs" Inherits="TestEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

    <script src="OtherUtils/ckeditor/ckeditor.js" type="text/javascript"></script>

    <script src="OtherUtils/ckfinder/ckfinder.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table cellpadding="0" cellspacing="0" class="style1">
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
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <textarea id="myEditor" cols="20" name="myEditor" rows="2"></textarea></td>
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
        </table>
    
    </div>
    </form>
</body>
</html>
    <script language="javascript" type="text/javascript">
        var editor = CKEDITOR.replace('myEditor');
        CKFinder.setupCKEditor(editor, 'OtherUtils/ckfinder/');
        CKFinder.config.disableHelpButton = true;
        
        
        
        
</script>