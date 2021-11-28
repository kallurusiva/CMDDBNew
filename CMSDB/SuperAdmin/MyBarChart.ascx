<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyBarChart.ascx.cs" Inherits="SuperAdmin_MyBarChart" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>

 <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">&nbsp;<asp:Label ID="lblChartTitle" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
         <td>
                  <table style="border: solid 1px #AEADAD;" cellpadding="0" cellspacing="0">
                  <tr><td>
                        <table>
                          <asp:Label ID="lblItems" runat="server" Text=""></asp:Label>
                        </table>
                  </td></tr>
                  </table>
        </td>
        </tr>
        <tr>
         <td align="center">&nbsp;<asp:Label ID="lblXAxisTitle" runat="server" Text=""></asp:Label></td>
        </tr>
        
    </table>

<%--<table border="0" cellpadding="0" cellspacing="0">
<tr>
        <td align=center>
            <asp:Label id=lblChartTitle2 runat=server />            
        </td>
    </tr>
    <tr>
        <td>
            <table border=1 bordercolor='#777777' cellspacing=0 cellpadding=0>
                <tr>
                    <td>
                        <table>
                            <asp:Label id=lblItems runat=server />
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan=2 align=center>
            <asp:Label id=lblXAxisTitle2 runat=server />
        </td>
    </tr>
</table>--%>