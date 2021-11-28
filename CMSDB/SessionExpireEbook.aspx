<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionExpireEbook.aspx.cs" Inherits="SessionExpireEbook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">

        function ShowPopup() {
            alert("Your Session expired.\n\nPlease login Again.");
            window.location.href = "http://www.evenchiselogin.com/ev.html";
        }

        function ShowPopupWithArgs(arg1, arg2, arg3) {
            alert('Your Session expired.\n\nPlease login Again. \n\narg1='+ arg1 + '\narg2=' + arg2 + '\narg3=' + arg3);
            window.location.href = "default.aspx";
        }
    
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
