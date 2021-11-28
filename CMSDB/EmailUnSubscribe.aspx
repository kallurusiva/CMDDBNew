<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailUnSubscribe.aspx.cs" Inherits="EmailUnSubscribe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EVenchise</title>
     <link href="App_Themes/Common/CommonStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td width="2%"><a name="top"></a>
                &nbsp;</td>
            <td width="96%" class="font_12BlueBold" align="right">
                &nbsp;&nbsp;&nbsp;
                </td>
            <td width="2%">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="">
                <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                
                &nbsp;</div>
                
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
            <td class="font_12BlueBold">
                E-Vendor -&nbsp; A Digital Store for Partners to sell products to Everyone.
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
            <td class="font_EventDates11">
                Edigital Store allows to sell digital products thru web links.&nbsp; </td>
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
                <img alt="e-Book" src="Images/EVicons/icon_ebook.jpg" 
                    style="width: 150px; height: 150px" /><img alt="mobileapp" 
                    src="Images/EVicons/icon_mobileApp.jpg" style="width: 150px; height: 150px" /><img 
                    alt="etickets" src="Images/EVicons/icon_tickets.jpg" 
                    style="width: 150px; height: 150px" /><img alt="videos" 
                    src="Images/EVicons/icon_video.jpg" style="width: 150px; height: 150px" /><img 
                    alt="photos" src="Images/EVicons/icon_photos.jpg" 
                    style="width: 150px; height: 150px" /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="font_EventDates11">
                and many more products. </td>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="left">
                 <div align="left" id="divProducts"  class="divAdvertBox">
                 <div class="divAdvertBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText"> 
                                <asp:Literal ID="ltrProductHeader" Text="UnSubscribe Below" runat="server"></asp:Literal></div>
                  </div>   
                  
        </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <table cellpadding="0" cellspacing="0" class="stdtableBorder_Advert" width="99%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" width="90%">
                                <tr>
                                    <td class="font_14SuccessBold" align="left">
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="font_12BoldGrey">
                                        
                                        <p>
                                            <asp:Label ID="lblus" runat="server" Text="Enter Email here:"></asp:Label>
                                            <asp:TextBox ID="txtEmail" runat="server" Text=""></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" class="font_11Msg_Success">
                                        <asp:Button ID="BtSendSMS" runat="server" CssClass="stdbuttonCRUD" Text="Unsubscribe Now" onclick="btnSave_Click" /></td>
                                </tr>
                            </table>
                         </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                             <tr>
                        <td>
                            &nbsp;</td>
                            
                    </tr>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
