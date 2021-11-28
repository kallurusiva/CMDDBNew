<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_PhysicalBookPurchase.aspx.cs" Inherits="Admin_EBAd_PhysicalBookPurchase" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="EBLeftMenu_EBookSales.ascx" tagname="EBLeftMenu_EBookSales" tagprefix="uc4" %>

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

        <uc4:EBLeftMenu_EBookSales ID="EBLeftMenu_EBookSales1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
   

    <form id="tForm" runat="server" enctype="application/x-www-form-urlencoded" >
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
                        <td width="60%" class="FontNote" align="left" style="font-size: medium; font-weight: bold; width: 75%;" colspan="2">
                           &nbsp;
                        </td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Enter EBook Code : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtCode"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" TabIndex="2" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCode" ErrorMessage=" Please enter EBook Code" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
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
                            <asp:DropDownList ID="txtSize" AutoPostBack="true" runat="server" CssClass="stdDropDown2" OnSelectedIndexChanged="txtSize_SelectedIndexChanged" TabIndex="6" ValidationGroup="VgCheck">
                                <asp:ListItem  Value="1" Text="A5"></asp:ListItem>
                                <%--<asp:ListItem  Value="2" Text="A4"></asp:ListItem>--%>
                             </asp:DropDownList>
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
                            Book Units: <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:DropDownList ID="txtUnits" AutoPostBack="true" runat="server" CssClass="stdDropDown2" OnSelectedIndexChanged="txtUnits_SelectedIndexChanged" TabIndex="6" ValidationGroup="VgCheck">
                                <asp:ListItem  Value="1" Text="5"></asp:ListItem>
                                <%--<asp:ListItem  Value="10" Text="10"></asp:ListItem>--%>
                             </asp:DropDownList>
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
                             <asp:DropDownList ID="txtPages" AutoPostBack="true" runat="server" CssClass="stdDropDown2" OnSelectedIndexChanged="txtPages_SelectedIndexChanged" TabIndex="6" ValidationGroup="VgCheck">
                                 
                             </asp:DropDownList>
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
                            Enter Shipping Address : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left" colspan="2">
                            <asp:TextBox ID="txtShippingAddress"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" TabIndex="2" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShippingAddress" ErrorMessage=" Please Enter Shipping Address" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                            </td>
                        <td>
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
                            Book Title : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                             <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            <asp:Image runat="server" ID="imgBook"  Height="100px" Width="70px" Visible="false" />
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
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Purchase Now" onclick="btnSave_Click" Visible="false" />

                            <asp:Button ID="btnConfirm" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Confirm Now" onclick="btnConfirm_Click" Visible="false" />
                        </td>
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

