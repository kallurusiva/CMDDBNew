<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_PhysicalBookPurchaseDone.aspx.cs" Inherits="Admin_EBAd_PhysicalBookPurchaseDone" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }


    .dispTable {
    /*border-collapse: collapse;*/
    border: 2px solid green;
    background-color: #FFFFFF; 
    FONT-SIZE: 12px; font-weight:bold; COLOR: #124C76; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;
    padding: 5px;
}
   
    .dispTable td {
       border-collapse: collapse;
        border: 1px dotted green;

    }

    </style>

    <style type="text/css">
    .style2
    {
        text-align: right;
    }
    .auto-style1 {
        height: 25px;
    }
    .auto-style3 {
        font-size: 12px;
        color: #4E5163;
        height: 25px;
        border-left: 1pt solid #D4DFAA;
        border-bottom: 1pt solid #D4DFAA;
        padding-left: 20px;
        background-color: #EEEFEB;
    }
        .auto-style4 {
            height: 27px;
        }
        .auto-style5 {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 27px;
            padding-right: 20px;
            text-align: left;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        .auto-style6 {
            background-color: #EEEFEB;
            border-bottom: solid 1pt #D4DFAA;
            border-left: solid 1pt #D4DFAA;
            font-size: 12px;
            color: #4E5163;
            height: 27px;
            padding-left: 20px;
        }
        .auto-style7 {
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
        .auto-style8 {
            width: 16px;
            height: 16px;
        }
        .stdDropDown2 {
        }
        </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc4:EBLeftMenu_Dashboard ID="EBLeftMenu_Dashboard1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
   

    <form id="tForm" runat="server" enctype="multipart/form-data" >
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </td>
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
                            &nbsp; Order Physical Book&nbsp; </td>
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
                        <td width="25%">
                            &nbsp;</td>
                        <td width="60%" class="FontNote" align="left" style="font-size: medium; font-weight: bold">
                           &nbsp;
                        </td>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            EBook Code : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="txtCode" runat="server"></asp:Label>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Book Size: <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="txtSize" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            </td>
                    </tr>

                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Book Size: <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="txtUnits" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            </td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            No. of Pages : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                             <asp:Label ID="txtPages" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Print Book Price : USD <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                             <asp:Label ID="txtPrice" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr> 
                    
                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Handling Price : USD <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                             <asp:Label ID="lblHandlingPrice" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>   
                    
                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Shipping Fees : USD <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                             <asp:Label ID="lblShippingFees" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>                 

                    <tr>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                  
                   <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Total to be Deducted : USD <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                             <asp:Label ID="lblTotal" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            MWallet Balance : USD <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                             <asp:Label ID="lblMWallet" runat="server"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Continue" onclick="btnSave_Click" /></td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                     &nbsp;
                        </td>
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

