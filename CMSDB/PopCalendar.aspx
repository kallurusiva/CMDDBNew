<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopCalendar.aspx.cs" Inherits="PopCalendar" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calendar</title>
    <script language="Javascript" type="text/javascript">
    function ReturnDate()
        {

         window.opener.document.forms["<%= strFormName %>"].elements["<%= strCtrlName %>"].value = "<%= strSelectedDate %>";
         window.close();

        }
        
    function Close()
    
        {
            window.close();
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="tblCal" border="0" cellspacing="0" cellpadding="0" width="100%">
     <tr>
        <td align="Center">
            <asp:Calendar id="myCalendar" runat="server" BorderWidth="1px" BackColor="#FFFFCC" Width="220px" DayNameFormat="FirstLetter" ForeColor="#663399" Height="200px" Font-Size="8pt" Font-Names="Verdana" BorderColor="#FFCC66" ShowGridLines="True" OnSelectionChanged="myCalendar_SelectionChanged">
                <SelectorStyle backcolor="#FFCC66"></SelectorStyle>
                <NextPrevStyle font-size="9pt" forecolor="#FFFFCC"></NextPrevStyle>
                <DayHeaderStyle height="1px" backcolor="#FFCC66"></DayHeaderStyle>
                <SelectedDayStyle font-bold="True" backcolor="#CCCCFF"></SelectedDayStyle>
                <TitleStyle font-size="9pt" font-bold="True" forecolor="#FFFFCC" backcolor="#990000"></TitleStyle>
                <OtherMonthDayStyle forecolor="#CC9966"></OtherMonthDayStyle>
            </asp:Calendar>
        </td>
        </tr>
         <tr>
            <td align="Center">
                <input id="btnReturnDate" onclick="Javascript:ReturnDate()" type="button" value="Select" runat="Server" />&nbsp; 
                <input id="btnCloseWindow" onclick="Javascript:Close()" type="button" value="Close" runat="Server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
