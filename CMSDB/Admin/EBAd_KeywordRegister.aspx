<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_KeywordRegister.aspx.cs" Inherits="EBAd_KeywordRegister" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="EBLeftMenu_RegSTEPS.ascx" tagname="EBLeftMenu_RegSTEPS" tagprefix="uc5" %>

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
        </style>


    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc5:EBLeftMenu_RegSTEPS ID="EBLeftMenu_RegSTEPS1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    <script language="javascript" type="text/javascript">

       
        function CheckKeyCode(e) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 8)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 0)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }


        function CheckKeyCode_AlphaNum(e) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 8) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 97 && e.keyCode <= 122)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 0) || (e.charCode >= 65 && e.charCode <= 90) || (e.charCode >= 97 && e.charCode <= 122)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }



</script>

    <form id="tForm" runat="server" enctype="multipart/form-data" method="post"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </td>
        </tr>
        <tr style="height:20px">
            <td align="center">
             <div id="divNoticeBar" class="divNoticeBarInfo" runat="server" visible="false">
                <table class="tbNoticeBar" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="col1"></td>
                        <td><asp:Label ID="lblNoticebarMsg" runat="server" Text="Vendor Code created successfully!"/></td>                           
                    </tr>                   
                </table>
            </div>     
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
                            &nbsp; eBook Vendor Code Registration&nbsp; </td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">

                <table id="tblNotes" runat="server" cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>

                        <td width="5%">
                            &nbsp;</td>
                        <td width="90%" align="left" class="FontNote3">
                            <b> NOTE: </b>
                            <ul>
                                <li>Vendor Code is Only Available for Professional Vendors. 

                        </li>
                                <li>Vendore Code is your eBook Store&#39;s identity for ebook purchase by Premium SMS. Althought not compulsory, you may select a Vendor Code that is easy to remember and/or reflect your websitename. </li>
                                <li>You may select a Vendor Code that is same or different from your E-Store ID.</li>
                            </ul>

                        </td>
                        <td width="5%">
                            &nbsp;</td>

                    </tr>
                    </table>


                 <table id="tblVendorCodeExists" visible="false" runat="server" cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>

                        <td width="5%">
                            &nbsp;</td>
                        <td width="90%" align="left" class="FontNote3">
                            &nbsp; 

                        </td>
                        <td width="5%">
                            &nbsp;</td>

                    </tr>
                     <tr>
                         <td>&nbsp;</td>
                         <td class="FontSubHeader">&nbsp;Your registered Vendor Code :  <asp:Label ID="lblVendorCode" CssClass="font_14SuccessBold" runat="server" Text=""></asp:Label></td>
                         <td>&nbsp;</td>
                     </tr>

                        <tr>
                         <td>&nbsp;</td>
                         <td>&nbsp;</td>
                         <td>&nbsp;</td>
                     </tr>

                    </table>




                <table id="tblRegister" visible="false" runat="server" cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="25%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style8" >
                            </td>
                        <td class="auto-style8" >
                            Enter Vendor&nbsp; Code : <span class="font_12Msg_Error">*</span></td>
                        <td class="auto-style6" align="left">
                             <asp:TextBox ID="TextBoxKeyword" runat="server" CssClass="stdTextField1" MaxLength="15" />
                         <asp:RequiredFieldValidator ID="rfvKeyword" runat="server" ControlToValidate="TextBoxKeyword" Display="None" ErrorMessage="&lt;b&gt;Required Field&lt;/b&gt;&lt;br/&gt;Enter Keyword (Min 2 to Max 15 characters)" SetFocusOnError="true" />
                         <asp:RegularExpressionValidator ID="revKeyword" runat="server" ControlToValidate="TextBoxKeyword" Display="None" ErrorMessage="&lt;b&gt;Invalid Format&lt;/b&gt;&lt;br/&gt;Vendor Code supports Alphanumeric only" ValidationExpression="[a-zA-Z0-9]{1,15}" />
                         <asp:Image ID="ImageKeywordStatus" runat="server" ImageUrl="~/Images/inf_Sucess.gif" Visible="false" />
                         &nbsp;<asp:Label ID="LabelKeywordStatus" runat="server" CssClass="txtValidateBlue" Text="Label" Visible="false" />

                          
                            </td>
                        <td class="auto-style6" align="left">
                            </td>
                        <td class="auto-style4">
                            </td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style8" >
                            </td>
                        <td class="auto-style8" >
                            </td>
                        <td class="auto-style6" align="left">
                            <asp:Button ID="btnCheckKeyWAvail" runat="server" CssClass="stdbuttonCRUD" OnClick="btnCheckKeyWAvail_Click" Text="Check eVendor Code Availability" />
                         </td>
                        <td class="auto-style6" align="left">
                            </td>
                        <td class="auto-style4">
                            </td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            ShortCode :</td>
                        <td class="tblFormText1" align="left">

                             <asp:Label ID="lblShortCode" CssClass="SAAdminFont" runat="server" Text="32828"></asp:Label>



                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
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
                            </td>
                        <td class="auto-style3" align="left">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderColor="Red" BorderStyle="Dotted" CssClass="font_11Msg_Error" HeaderText="The Following errors occured while saving the Ebook." Height="70px" ShowMessageBox="True" ValidationGroup="VgCheck" />
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style1">
                            </td>
                    </tr>
                   
                     <tr id="trRegisterRow" runat="server" visible="false">
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD"
                                Text="Register Now" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD" 
                                Text="Cancel" onclick="btnCancel_Click" />
                          
                                </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
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

