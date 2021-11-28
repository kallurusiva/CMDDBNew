<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EBAd_WPNewsInfoByID.aspx.cs" Inherits="EBAd_WPNewsInfoByID" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/Default/EbookStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<div align="center">
        <asp:Panel ID="Panel1" runat="server">
               <div class="stdDiv02">
                <table id="tbModalExtender" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr style="background-color: #EB6E44; color: #FFFFFF;">
                    <td class="style1">&nbsp;</td>
                    <td align="center"><asp:Label ID="lblStatementTitle" runat="server" CssClass="subMenuFont" Text=""/></td>
                    <td style="width:10px">&nbsp;</td>
                    </tr>
                    <tr>
                    <td style="background-color:#fff" class="style1">&nbsp;</td>
                    <td style="background-color:#fff" align="center">&nbsp;</td>
                    <td style="background-color:#fff">&nbsp;</td>
                    </tr>
                     <tr>
                         <td class="style1" style="background-color:#fff">&nbsp;</td>
                         <td align="right" style="background-color:#fff">&nbsp;
                              <div id="google_translate_element" style="float:right; padding-right: 10px;"></div>
                      <script type="text/javascript">
                          function googleTranslateElementInit() {
                              new google.translate.TranslateElement({
                                  pageLanguage: 'en',
                                  layout: google.translate.TranslateElement.InlineLayout.HORIZONTAL,
                                  includedLanguages: 'af,sq,ar,be,bg,ca,zh-CN,zh-TW,hr,cs,da,nl,en,et,tl,fi,fr,gl,de,el,ht,iw,hi,hu,is,id,ga,it,ja,ko,lv,lt,mk,ms,mt,no,fa,pl,pt,ro,ru,sr,sk,sl,es,sw,sv,ta,te,th,tr,uk,ur,vi,cy,yi'
                              }, 'google_translate_element');
                          }
                        </script>
              <script type="text/javascript" src="http://translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>

                         </td>
                         <td style="background-color:#fff">&nbsp;</td>
                    </tr>
                     <tr><td colspan="3">&nbsp;

                         


                         </td></tr> 
                    <tr height: 25px;">
                    <td class="style1">&nbsp;</td>
                    <td><asp:Label ID="lblTitleNews" runat="server" Text="" Font-Underline="true" CssClass="FontBHeader2"></asp:Label></td>
                    <td>&nbsp;</td>
                    </tr> 
                    <tr>
                    <td class="style1" style="background-color:#fff">&nbsp;</td>
                    <td style="background-color:#fff"><asp:Label ID="lblNewsFull" runat="server" Text="" CssClass="font_Content"/></td>
                    <td style="background-color:#fff">&nbsp;</td>
                    </tr> 
                    <tr>
                    <td class="style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr> 
                    <tr style="background-color: #CCC; height: 25px;">
                        <td align="center" colspan="3" class="style3">
                        <asp:Label runat="server" ID="lblDate1" CssClass="FontBRowText" />
                        <br />
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="ButtonClose" runat="server" CssClass="btCancelSmall" 
                                Text="Close Window" />
                        </td>

                    </tr>
                </table> 
                </div>
   </asp:Panel>
    </div>
    <script language="javascript" type="text/javascript">
        function CloseWindow() {
            window.close();
        }
    </script>
    </form>
</body>
</html>
