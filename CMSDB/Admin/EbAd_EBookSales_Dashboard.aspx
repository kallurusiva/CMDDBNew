<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_EBookSales_Dashboard.aspx.cs" Inherits="Admin_EbAd_EBookSales_Dashboard" %>



<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_EBookSales.ascx" tagname="EBLeftMenu_EBookSales" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            text-decoration: underline;
        }
        .auto-style4 {
            width: 31%;
        }
        .auto-style5 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: left;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        .auto-style7 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: center;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        .auto-style8 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 25px;
            padding-right: 20px;
            text-align: center;
            font-variant: normal;
            font-style: normal;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
   
        <uc2:EBLeftMenu_EBookSales ID="EBLeftMenu_EBookSales1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="tForm" runat="server" enctype="multipart/form-data" method="post">


        

            

            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="height:20px">
                        <td align="center">
                        <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
                         <tr>
                         <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
                         <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
                         </tr>
                         </table>
                       </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" border="0" width="96%">
                    <tr>
                        <td align="center">
                             <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                              <tr>
                                    <td width="5%" align="left" valign="top">
                                        &nbsp;</td>
                                    <td width="90%" align="left" class="subHeaderFontGrad">
                                        &nbsp; EBook Sales Dashboard&nbsp; </td>
                                    <td width="5%"  align="right" valign="top">
                                        &nbsp;</td>
                                </tr>
                             </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                                <tr>
                                    <td width="2%">
                                        &nbsp;</td>
                                    <td class="auto-style4">
                                        &nbsp;</td>
                                    <td width="35%">
                                        &nbsp;</td>
                                    <td width="2%">
                                        &nbsp;</td>
                                </tr>
                    
                   
                                 <tr>
                                    <td class="auto-style7" >
                                        &nbsp;</td>
                                    <td class="auto-style4" >
                                        &nbsp;</td>
                                    <td class="auto-style3" align="left">
                                        &nbsp;</td>
                                    <td class="auto-style1">
                                        </td>
                                </tr>
                   
                               <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style8" colspan="2" >
                                        <strong>Today Successful Sales Books</strong></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        Free EBook</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblFreeToday"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        MWallet</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblMWalletToday"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        Credit Card</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblCCToday"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        Online Banking</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblOnlineToday"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                               
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style8" colspan="2" >
                                        <strong style="text-align: center">Total Successful Books</strong></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        Free EBook</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblFree"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        MWallet</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblMWallet"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        Credit Card</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblCC"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        Online Banking</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblOnline"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style8" colspan="2" >
                                        <strong style="text-align: center">Last 30 Days Buy MWallet Admin Books</strong></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        My Admin EBook</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblOwnAdminBooks"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>

                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        Other Authors EBooks</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblOtherAdminBooks"> </asp:Label>&nbsp;&nbsp;&nbsp;
                                         <asp:HyperLink runat="server" Text="[Detail - Click Here]" NavigateUrl="~/Admin/EbAd_BookCodesOA.aspx" Target="_blank"></asp:HyperLink>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                              
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td class="auto-style4" >
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
                
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

   
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

