<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustTempPage.aspx.cs" Inherits="CustTempPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">

        function openNewWin_Temp(url) {

            alert(url);
            var oWin = window.open(url, 'mynewwin', 'width=600,height=600,toolbar=1');

            if (oWin == null || typeof (oWin) == "undefined") {
                alert('you have a pop blocker enabled.  Please allows pop ups for this site.');
                oWin.focus();
                return true;
            } else {
                alert('NO NO popup blocked');
                oWin.close();
                return false;

            }

        }
        
      function SetTarget() {
            document.forms[0].target = "_blank";
        }
        
</script>
        
</head>
<body runat="server" id="Body">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
