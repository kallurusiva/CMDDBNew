<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="PremiumSMSReport_Summary.aspx.cs" Inherits="Admin_PremiumSMSReport_Summary" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_PaidSales.ascx" tagname="EBLeftMenu_PaidSales" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            background-color: #EEEFEB;
            border-bottom: solid 1pt #D4DFAA;
            border-left: solid 1pt #D4DFAA;
            font-size: 12px;
            color: #0000FF;
            height: 25px;
            padding-left: 20px;
            text-align: left;
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
            width: 31%;
        }
        .auto-style6 {
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
            width: 14%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
   
            <uc2:EBLeftMenu_PaidSales ID="EBLeftMenu_PaidSales1" runat="server" />
    
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
                                        &nbsp; EBook Incentive Summary</td>
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
                                    <td class="auto-style4" colspan="2">
                                        &nbsp;</td>
                                    <td width="35%">
                                        &nbsp;</td>
                                    <td width="2%">
                                        &nbsp;</td>
                                </tr>
                    
                   
                                 <tr>
                                    <td class="auto-style7" >
                                        &nbsp;</td>
                                    <td class="auto-style4" colspan="2" >
                                        </td>
                                    <td class="auto-style3" align="left">
                                        &nbsp;</td>
                                    <td class="auto-style1">
                                        </td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        EBook Store</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblIncentive"> </asp:Label></td>
                                    <td>
                                        </td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
                                        </td>
                                    <td class="auto-style5" >
                                       Direct Partner</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblIncentiveS"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
                                        </td>
                                    <td class="auto-style5" >
                                        Author</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblIncentiveA"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
                                        </td>
                                    <td class="auto-style5" >
                                       Author Intro</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblIncentiveI"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
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
                                    <td class="auto-style6" >
                                        <%--Your Email ID :--%></td>
                                    <td class="auto-style5" >
                                        Total</td>
                                    <td class="tblFormText1" align="left">
                                        <asp:Label runat="server" ID="lblTotal"> </asp:Label></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
                                        <%--Your Password :--%> </td>
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
                                    <td class="auto-style6" >
                                        <%--URL to Login Email :--%></td>
                                    <td class="auto-style5" >
                                        &nbsp;</td>
                                    <td class="auto-style2">
                                        &nbsp;</td>
                                  
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="center">
                                        &nbsp;</td>
                                  
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="center">
                                        &nbsp;</td>
                      
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                 <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style6" >
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
                                    <td class="auto-style6" >
                                        &nbsp;</td>
                                    <td class="auto-style5" >
                                        &nbsp;</td>
                                    <td class="tblFormText1" align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                   
                                <tr>
                                    <td >
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

