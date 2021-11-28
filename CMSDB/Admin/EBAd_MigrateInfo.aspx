<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_MigrateInfo.aspx.cs" Inherits="Admin_EBAd_MigrateInfo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    

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
        </style>


    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc3:EBLeftMenu_Dashboard ID="EBLeftMenu_Dashboard1" runat="server" />

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
        <%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                Temporary not available due to maintenance.  Will be up ASAP
                </td>
            <asp:Label ID="lblPgFrom" runat="server" Text=""></asp:Label>
        </tr>
            </table>--%>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </td>
            <asp:Label ID="lblPgFrom" runat="server" Text=""></asp:Label>
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
                            &nbsp; Upload Admin Book / Add New Book</td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">

                <asp:Image ID="imgMigration" runat="server" ImageUrl="~/Images/migrationImage.jpeg" />

                <%--<table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="25%">
                            </td>
                        <td width="60%">
                            </td>
                        <td width="15%">
                            </td>
                        <td width="2%">
                            </td>
                    </tr>
                   <tr style="color: #CC0000;align-content:center;">
                        <td colspan="4" style="font-weight: 700">
                            
                            New ebook upload or existing ebook changes with be completed with 3 working days (72 hours). <br />Authors will be notified via Telegram Notifications</td>
                    </tr>
                     <tr>
                        <td class="auto-style8" >
                            Select</td>
                        <td class="tblFormText1" align="left">
                            1.  <asp:Button ID="BtnSaveNew" runat="server" ValidationGroup="vCheck" CssClass="stdbuttonCRUD" Text="Add New Book" OnClick="BtnSaveNew_Click" /></td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8" >
                            </td>
                        <td class="tblFormText1" align="left">
                            2.  <asp:Button ID="BtnSave" runat="server" ValidationGroup="vCheck" CssClass="stdbuttonCRUD" Text="Update for Existing Book" OnClick="BtnSave_Click" /></td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Existing EBook Code :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                         <asp:TextBox ID="txtBookCode" CssClass="stdTextField2" runat="server" ValidationGroup="vCheck" Text="0"></asp:TextBox>
                        &nbsp;&nbsp;<br />
                            <asp:Image ID="ImageKeywordStatus" runat="server" ImageUrl="~/Images/imgUpdate.gif" Visible="false" />
                         &nbsp;<asp:Label ID="lblCatNameStatus" runat="server" CssClass="ValAlert_Error" Text="Label" Visible="false" />

                        </td>
                    
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" colspan="3" >
                            
                            &nbsp; &nbsp; &nbsp; <asp:Image ID="imgInst" runat="server" ImageUrl="~/Images/UploadBookInstructions.jpg" /> 
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                   
                </table>--%>
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

