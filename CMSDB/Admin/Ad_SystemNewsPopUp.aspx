<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ad_SystemNewsPopUp.aspx.cs" Inherits="Admin_Ad_SystemNewsPopUp" %>

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
    <link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="2%">&nbsp;</td>
                <td width="96%">&nbsp;</td>
                <td width="2%">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="left" valign="middle">
                    <img alt="sys" src="../Images/sysNewsHead.jpg" 
                        style="width: 128px; height: 128px" />&nbsp;<asp:Label ID="lblsystemNews" runat="server" Text="System News" 
                        CssClass="Section_headtext"></asp:Label>
                        </td>
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
                    <table cellpadding="0" cellspacing="0" class="style1">
                        <tr>
                            <td width="50%">
                    <b>
                    <asp:Label ID="lblPostedonHead" CssClass="font_12Normal" runat="server" Text=""></asp:Label> &nbsp; : &nbsp
                    <asp:Label ID="lblPostedonText" CssClass="font_Content" runat="server" Text=""></asp:Label>
                    </b>
                            </td>
                            <td  width="50%" align="right">
                                &nbsp;
                                <div id="google_translate_element"></div>
		                          <script>
			                        function googleTranslateElementInit() {
			                          new google.translate.TranslateElement({
				                        pageLanguage: 'en',
				                        includedLanguages: 'af,sq,ar,be,bg,ca,zh-CN,zh-TW,hr,cs,da,nl,en,et,tl,fi,fr,gl,de,el,ht,iw,hi,hu,is,id,ga,it,ja,ko,lv,lt,mk,ms,mt,no,fa,pl,pt,ro,ru,sr,sk,sl,es,sw,sv,th,tr,uk,vi,cy,yi'
			                          }, 'google_translate_element');
			                        }
			                        </script>
                                    <script src="http://translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
            
                                </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="stdtableBorder_MainBold">
                              <tr>
                            <td align="left">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            </tr>
                              <tr>
                            <td align="left">
                                &nbsp;</td>
                            <td align="left">
                             <div class="cssfaq_head">
                                <asp:Label ID="lblNewsSubject" CssClass="font_stdupdateMsg" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            </tr>
                              <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                            </tr>
                            <tr>
                            <td align="left">
                                &nbsp;</td>
                            <td align="left">
                                <asp:Label ID="lblNewsContent" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                            <td align="left">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            </tr>
                            </table>
                            
                            
                            
                            
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <input name="Button" type="button"  value="Print Now" onClick="javascript:window.print();">&nbsp;       
					  <input name="Button" type="button" value="Close Window" onClick="javascript:window.close();">     </td>
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
