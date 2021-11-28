<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotPwd_Premium.aspx.cs" Inherits="forgotPwd_Premium" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Common/CommonStyleSheet.css" rel="stylesheet" 
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="stdtableBorder_Main">
          <tr>
            <td class="bgBlue"><span class="font_14SuccessBold">FORGOT PASSWORD</span></td>
          </tr>
          <tr>
            <td width="49%" valign="top" class="txt02Indent"> <form id="loginfrm" name="loginfrm" method="post" action="">
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                
                <tr>
                  <td height="1" colspan="3" bgcolor="#CCCCCC"></td>
                  <td height="1" bgcolor="#CCCCCC">&nbsp;</td>
                  <td height="1" bgcolor="#CCCCCC">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="3">
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  </tr>
                <tr>
                  <td colspan="5">
                      <asp:Label ID="lblMessage" Visible="false" CssClass="font_12Msg_Error" runat="server" Text="MsgError"></asp:Label>
                      <asp:Label ID="lblSuccessMsg" Visible="false" CssClass="font_12Msg_Success" runat="server" Text="MsgSucess"></asp:Label>
                    </td>
                  </tr>
                <tr>
                  <td width="75" class="font_14BoldGrey" height="30"> &nbsp;</td>
                  <td width="12" >&nbsp;</td>
                  <td width="400" align="center">
                      &nbsp;</td>
                  <td width="200">
                        
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
                </tr>
                <tr>
                  <td width="75" class="font_14BoldGrey" height="30"> Login ID </td>
                  <td width="12" ><div align="center">:</div></td>
                  <td width="400" align="center">
                      <asp:TextBox ID="txtloginID" runat="server" CssClass="stdTextField1"></asp:TextBox>
                  </td>
                  <td width="200">
                        
                      <asp:Button CssClass="stdbuttonAction" ID="btnSendFpwd" runat="server" 
                          Text="Send Now" onclick="btnSendFpwd_Click" />
                  </td>
                  <td>
                      &nbsp;</td>
                </tr>
                <tr>
                  <td height="1" colspan="3" bgcolor="#CCCCCC"></td>
                  <td height="1" bgcolor="#CCCCCC">&nbsp;</td>
                  <td height="1" bgcolor="#CCCCCC">&nbsp;</td>
                </tr>
               <tr>
                  <td height="23" colspan="3" style="padding-left:4px;"><span class="font_12Normal">Please key in a valid Login ID.You will receive your password via email.</span></td>
                  <td height="23" style="padding-left:4px;">&nbsp;</td>
                  <td height="23" style="padding-left:4px;">&nbsp;</td>
                </tr>                
              </table></form>
             
              
             </td>
          </tr>
          
          <tr>
            <td valign="top" >&nbsp;</td>
          </tr>
          <tr>
            <td align="right">&nbsp;
             <a href="#" onclick="javascript: window.close();" class="links_TopLineRed">
                [&nbsp;
                <img alt="winclose" border="0" src="Images/imgDelete.gif" 
                    style="width: 20px; height: 20px" /> Close Window ] </a>
            </td>
          </tr>
          </table>
    </div>
    </form>
</body>
</html>
