<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_PhyEBookRequest_Submit.aspx.cs" Inherits="EbAd_PhyEBookRequest_Submit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc1" %>



<%@ Register src="EBLeftMenu_RegSTEPS.ascx" tagname="EBLeftMenu_RegSTEPS" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 17px;
        }
        .stylehand
        {
            cursor: hand;
        }
        </style>
    <script language="javascript" type="text/javascript">

        function fnDeleteImage(imgID) {
            //alert(imgID);
            location.href = 'Ad_LogoSettings.aspx?ImgToDelete=' + imgID;
        
        }
    
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_RegSTEPS ID="EBLeftMenu_RegSTEPS1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="MyHomePageForm" runat="server" enctype="multipart/form-data">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss"  id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td>
                
                <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                  <tr>
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; Physical EBook Request&nbsp;
                            - Confirmation</td>
                     
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="2" class="stdtableBorder_MainBold" width="100%">
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="96%">
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                        </td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>

                             <table id="tblSubmitBook" class="stdtableBorder_MainBold" runat="server" border="0" cellpadding="0" cellspacing="2" width="100%">
                                <tr>
                                 <td width="5%">&nbsp;</td>
                                 <td width="90%">&nbsp;</td>
                                 <td width="5%">&nbsp;</td>
                                </tr>
                                  <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                                </tr>


                                  <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;<asp:Label ID="lblConfirm" CssClass="font_12Msg_Success" runat="server" Text="Thank you for your Submission."></asp:Label></td>
                                        <td> &nbsp;</td>
                                </tr>


                                  <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                </tr>


                                  <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                </tr>

                                  <td colspan="3">
                                    &nbsp;</td>
                                </tr>

                                 <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;<asp:Label ID="Label1" CssClass="ValAlert_Error" runat="server" Text="The Printed Books shall be delivered to your Delivery Address between 2-4 Weeks."></asp:Label></td>
                                        <td> &nbsp;</td>
                                </tr>


                                 <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                </tr>


                                 <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                </tr>


                                 <tr>
                                        <td> &nbsp;</td>
                                        <td> <b>NOTE:</b> <asp:Label ID="Label2" CssClass="font_12Msg_Error" runat="server" Text="Temporarily all collect from HQ after 5 working days. Except Saturday, Sundays or Public Holidays."></asp:Label> </td>
                                        <td> &nbsp;</td>
                                </tr>


                                 </table>

                            
                            
                            
                            </td>
                        <td>&nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td>
                            &nbsp;</td><td>
                            &nbsp;</td></tr></table></td></tr></table></td>
            </tr>
            <tr>
            <td>
                &nbsp;</td></tr></table></form>
                
                
</asp:Content>

