﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_eBookADDtest.aspx.cs" Inherits="Admin_EBAd_eBookADDtest" %>
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
        </style>


    <script type="text/javascript">

        function up_Image(sender, args) {
            var fileTypes = ['png', 'jpg', 'gif'];

            /*Validation for file extension*/
            var fileName = document.getElementById('<%=UploadImgCtrl.ClientID%>').value;
            var dots = fileName.split(".");

            var fileExtension = dots[dots.length - 1];
            alert(fileName);
            alert(fileExtension);



            if (fileTypes.indexOf(fileExtension) == -1) {
                document.getElementById('dvImageUploadErrorInfo').style.display = 'block';
                document.getElementById('dvImageUploadInfo').style.display = 'none';
                document.getElementById('<%=lblError.ClientID %>').innerHTML = "Only Jpg, gif or Png files are supported! for eBook Image.";
                return;
            }


            document.getElementById('dvImageUploadInfo').style.display = 'block';
            document.getElementById('dvImageUploadErrorInfo').style.display = 'none';
            document.getElementById('<%=lblSuccess.ClientID %>').innerHTML = "eBook Image seleted";
            document.getElementById('<%=lblFileNameDisplay.ClientID %>').innerHTML = fileName;



        }



        function up_eBookFile(sender, args) {

            var fileTypes = ['doc', 'pdf'];

            oFiles = document.getElementById('<%=UploadEbookFile.ClientID%>').files;
            nFiles = oFiles.length;

            nFilename = oFiles.name;
            nfileSize = oFiles.size;
            nfileType = oFiles.type;

            alert(nFiles);

            /*Validation for file extension*/
            var fileName = document.getElementById('<%=UploadEbookFile.ClientID%>').value;
            var dots = fileName.split(".");
            var fileNameLength = fileName.length;

            var fileExtension = dots[dots.length - 1];
            // alert(fileName);
            // alert(fileExtension);


            if (fileTypes.indexOf(fileExtension) == -1) {
                /* if (fileExtension.indexOf('.doc') != -1) { */
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Only doc or pdf files are supported! for eBook.";
                return;
            }

            /*Validation for file size*/
            if (parseInt(nfileSize) > 21214400) {
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Book File size should be less then 20MB";
                return;
            }

            if (parseInt(fileNameLength) > 50) {
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Book File Name Length should be less then 50 Characters.";
                return;
            }

            document.getElementById('dvEbFileUploadInfo').style.display = 'block';
            document.getElementById('dvEbFileUploadErrorInfo').style.display = 'none';

            var bytes = nfileSize;
            if (bytes >= 1048576)
            { bytes = (bytes / 1048576).toFixed(2) + ' MB'; }
            else if (bytes >= 1024)
            { bytes = (bytes / 1024).toFixed(2) + ' KB'; }
            else
            {
                bytes = bytes + ' bytes';
            }




            document.getElementById('<%=lblSuccess1.ClientID %>').innerHTML = "Selected eBook File";
                document.getElementById('<%=lblFileNameDisplay1.ClientID %>').innerHTML = nFilename;
            document.getElementById('<%=lblFileSizeDisplay1.ClientID %>').innerHTML = bytes;
            document.getElementById('<%=lblContentTypeDisplay1.ClientID %>').innerHTML = nfileType;



        }






        // This function will execute after file uploaded successfully
        function uploadComplete_Image(sender, args) {
            try {

                var fileTypes = ['png', 'jpg', 'gif'];

                /*Validation for file extension*/
                var fileName = args.get_fileName();
                var dots = fileName.split(".");

                var fileExtension = dots[dots.length - 1];

                if (fileTypes.indexOf(fileExtension) == -1) {
                    /* if (fileExtension.indexOf('.doc') != -1) { */
                    document.getElementById('dvImageUploadErrorInfo').style.display = 'block';
                    document.getElementById('dvImageUploadInfo').style.display = 'none';
                    document.getElementById('<%=lblError.ClientID %>').innerHTML = "Only Jpg, gif or Png files are supported!.";
                    return;
                }


                /*Validation for file size*/
                if (parseInt(args.get_length()) > 2097152) {
                    document.getElementById('dvImageUploadErrorInfo').style.display = 'block';
                    document.getElementById('dvImageUploadInfo').style.display = 'none';
                    document.getElementById('<%=lblError.ClientID %>').innerHTML = "Book Image size should be less then 2MB";
                    return;
                }

                document.getElementById('dvImageUploadInfo').style.display = 'block';
                document.getElementById('dvImageUploadErrorInfo').style.display = 'none';

                var bytes = args.get_length();
                if (bytes >= 1048576)
                { bytes = (bytes / 1048576).toFixed(2) + ' MB'; }
                else if (bytes >= 1024)
                { bytes = (bytes / 1024).toFixed(2) + ' KB'; }
                else
                {
                    bytes = bytes + ' bytes';
                }


                document.getElementById('<%=lblSuccess.ClientID %>').innerHTML = "Book Image Uploaded Successfully";
                document.getElementById('<%=lblFileNameDisplay.ClientID %>').innerHTML = args.get_fileName();
                document.getElementById('<%=lblFileSizeDisplay.ClientID %>').innerHTML = bytes;
                document.getElementById('<%=lblContentTypeDisplay.ClientID %>').innerHTML = args.get_contentType();

            }
            catch (e) {


            }


        }

        // This function will execute if file upload fails
        function uploadError_Image() {

            try {

                document.getElementById('dvImageUploadInfo').style.display = 'none';
                document.getElementById('dvImageUploadErrorInfo').style.display = 'block';
                document.getElementById('<%=lblError.ClientID %>').innerHTML = "File Not Uploaded" + args.get_errorMessage();

        }
        catch (e) {

        }
    }




    function uploadComplete_File(sender, args) {
        try {

            var fileTypes = ['doc', 'pdf'];

            /*Validation for file extension*/
            var fileName = args.get_fileName();
            var dots = fileName.split(".");

            var fileExtension = dots[dots.length - 1];

            if (fileTypes.indexOf(fileExtension) == -1) {
                /* if (fileExtension.indexOf('.doc') != -1) { */
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Only doc or pdf files are supported!.";
                    return;
                }


                /*Validation for file size*/
                if (parseInt(args.get_length()) > 5242880) {
                    document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                    document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                    document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Book File size should be less then 5MB";
                    return;
                }

                document.getElementById('dvEbFileUploadInfo').style.display = 'block';
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'none';

                var bytes = args.get_length();
                if (bytes >= 1048576)
                { bytes = (bytes / 1048576).toFixed(2) + ' MB'; }
                else if (bytes >= 1024)
                { bytes = (bytes / 1024).toFixed(2) + ' KB'; }
                else
                {
                    bytes = bytes + ' bytes';
                }




                document.getElementById('<%=lblSuccess1.ClientID %>').innerHTML = "Book File Uploaded Successfully";
                document.getElementById('<%=lblFileNameDisplay1.ClientID %>').innerHTML = args.get_fileName();
                document.getElementById('<%=lblFileSizeDisplay1.ClientID %>').innerHTML = bytes;
                document.getElementById('<%=lblContentTypeDisplay1.ClientID %>').innerHTML = args.get_contentType();

            }
            catch (e) {


            }


        }

        // This function will execute if file upload fails
        function uploadError_File() {

            try {

                document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                document.getElementById('<%=lblError1.ClientID %>').innerHTML = "File Not Uploaded" + args.get_errorMessage();

            }
            catch (e) {

            }
        }



        function CheckTextLength(text, long) {
            var maxlength = new Number(long); // Change number to your max length.
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                alert("for SMS Reply Only " + long + " characters allowed");
            }
        }

</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc4:EBLeftMenu_Dashboard ID="EBLeftMenu_Dashboard1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    <script language="javascript" type="text/javascript">


        function CheckKeyCode(e) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                if ((e.keyCode >= 48 && e.keyCode <= 57 || event.keyCode == 46) || (e.keyCode == 8)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((e.charCode >= 48 && e.charCode <= 57 || e.charCode == 46) || (e.charCode == 0)) {
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

    <form id="tForm" runat="server" enctype="multipart/form-data">
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
                            &nbsp; Add new Ebook&nbsp; </td>
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
                            <%--<strong>Note</strong>:&nbsp; <span class="font_11Msg_Error">  <strong>5 credits</strong></span>  would be charged for ADDing a new eBook.--%>
                             Note:<br /><br />
                            1.. EBook Price - Minimum USD1 and Maximum USD50<br />
                            2.. Ensure that EBook have Agreement with Author.<br />
                            3.. Adhere to EBook Copyright Law<br />
                            4.  Ensure contents justify the Price of the EBook<br />
                            5.  Do not upload illegal EBooks or Private label EBooks
                        </td>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                    <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               <asp:Literal ID="Literal3" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
                                &nbsp;
                                 <asp:Literal ID="Literal4" runat="server" 
                                Text="<%$ Resources:LangResources, Date %>"></asp:Literal></td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEvtDate" CssClass="stdTextField1" runat="server"></asp:TextBox>
                            <a href="javascript:ShowCal('<%=txtEvtDate.ClientID%>');">
                            <asp:Image ID="ImgCal" runat="server" BorderStyle="None" 
                                ImageUrl="~/Images/cal.gif" /></a>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
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
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            eBook Name : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtBookName"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" TabIndex="2" OnTextChanged="txtBookName_TextChanged" MaxLength="100"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBookName" ErrorMessage=" Please enter eBook Name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <%--<tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            eBook Title :</td>
                        <td class="tblFormText1" align="left">--%>
                            <asp:TextBox ID="txtBookTitle" runat="server" CssClass="stdTextField2" TabIndex="4" MaxLength="250" Text="" Visible="false"></asp:TextBox>
                            <%--</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Main Category : <span class="font_12Msg_Error">*</span></td>
                        <td class="auto-style3" align="left">
                            <asp:DropDownList ID="ddlMainCategory" runat="server" AutoPostBack="True" CssClass="stdDropDown2" OnSelectedIndexChanged="ddlMainCategory_SelectedIndexChanged" TabIndex="6" ValidationGroup="VgCheck">
                            </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMainCategory" Display="Dynamic" ErrorMessage="Please select Main-Category" InitialValue="0" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style1">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Sub
                            Category : <span class="font_12Msg_Error">*</span></td>
                        <td class="auto-style3" align="left">
                            <asp:DropDownList ID="ddlCategory" CssClass="stdDropDown2" runat="server" ValidationGroup="VgCheck" TabIndex="6">
                            </asp:DropDownList>

                              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="ddlCategory" Display="Dynamic" 
                                            ErrorMessage="Please select SUB-category" InitialValue="0" 
                                            ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="auto-style1">
                            </td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Display Status :</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoLaunchStatus" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="26">
                                <asp:ListItem Selected="True" Value="1">Launch Now</asp:ListItem>
                                <asp:ListItem Value="2">Coming Soon</asp:ListItem>
                            </asp:RadioButtonList>
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
                            Display at Website ?</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoDisplayatWebsite" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="26">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                        <td class="tblFormText1" align="left">
                            <%--<asp:RadioButtonList ID="rdoFeatured" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="30">
                                <asp:ListItem Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False" Selected="True">NO</asp:ListItem>
                            </asp:RadioButtonList>--%>
                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            <%--Can buy using Credit/Debit Card ?--%></td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoBuyPayPal" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="28" Visible="false">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                    <%-- <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Can buy using SMS ?</td>
                        <td class="tblFormText1" align="left">--%>
                            <asp:RadioButtonList ID="rdoBuySMS" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="28" Visible="false">
                                <asp:ListItem Value="True">YES</asp:ListItem>
                                <asp:ListItem Selected="True" Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
                           <%-- </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>--%>

                    <%--<tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Can buy using Prepaid ?</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoBuyPrepaid" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="28">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>--%>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Your Selected BookStore Currency :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label runat="server" ID="urCurrency" Text=""></asp:Label></td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Price : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <%--<asp:TextBox ID="txtPrice"  runat="server" CssClass="stdTextField1" AutoPostBack="True" OnTextChanged="txtPrice_TextChanged" TabIndex="10"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Price cannot be Empty. " ValidationGroup="VgCheck"></asp:RequiredFieldValidator>--%>
                            <asp:DropDownList ID="txtPrice" runat="server" AutoPostBack="True" CssClass="stdDropDown2" OnSelectedIndexChanged="txtPrice_SelectedIndexChanged" TabIndex="6" ValidationGroup="VgCheck">
                                <asp:ListItem  Value="2" Text="2"></asp:ListItem>
                                <asp:ListItem  Value="3" Text="3"></asp:ListItem>
                                <asp:ListItem  Value="4" Text="4"></asp:ListItem>
                                <asp:ListItem  Value="5" Text="5"></asp:ListItem>
                                <asp:ListItem  Value="6" Text="6"></asp:ListItem>
                                <asp:ListItem  Value="7" Text="7"></asp:ListItem>
                                <asp:ListItem  Value="8" Text="8"></asp:ListItem>
                                <asp:ListItem  Value="9" Text="9"></asp:ListItem>
                                <asp:ListItem  Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem  Value="11" Text="11"></asp:ListItem>
                                <asp:ListItem  Value="12" Text="12"></asp:ListItem>
                                <asp:ListItem  Value="13" Text="13"></asp:ListItem>
                                <asp:ListItem  Value="14" Text="14"></asp:ListItem>
                                <asp:ListItem  Value="15" Text="15"></asp:ListItem>
                                <asp:ListItem  Value="16" Text="16"></asp:ListItem>
                                <asp:ListItem  Value="17" Text="17"></asp:ListItem>
                                <asp:ListItem  Value="18" Text="18"></asp:ListItem>
                                <asp:ListItem  Value="19" Text="19"></asp:ListItem>
                                <asp:ListItem  Value="20" Text="20"></asp:ListItem>
                                <asp:ListItem  Value="21" Text="21"></asp:ListItem>
                                <asp:ListItem  Value="22" Text="22"></asp:ListItem>
                                <asp:ListItem  Value="23" Text="23"></asp:ListItem>
                                <asp:ListItem  Value="24" Text="24"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                <asp:ListItem Value="26" Text="26"></asp:ListItem>
                                <asp:ListItem  Value="27" Text="27"></asp:ListItem>
                                <asp:ListItem  Value="28" Text="28"></asp:ListItem>
                                <asp:ListItem  Value="29" Text="29"></asp:ListItem>
                                <asp:ListItem  Value="30" Text="30"></asp:ListItem>
                                <asp:ListItem  Value="31" Text="31"></asp:ListItem>
                                <asp:ListItem  Value="32" Text="32"></asp:ListItem>
                                <asp:ListItem  Value="33" Text="33"></asp:ListItem>
                                <asp:ListItem  Value="34" Text="34"></asp:ListItem>
                                <asp:ListItem  Value="35" Text="35"></asp:ListItem>
                                <asp:ListItem  Value="36" Text="36"></asp:ListItem>
                                <asp:ListItem  Value="37" Text="37"></asp:ListItem>
                                <asp:ListItem  Value="38" Text="38"></asp:ListItem>
                                <asp:ListItem  Value="39" Text="39"></asp:ListItem>
                                <asp:ListItem  Value="40" Text="40"></asp:ListItem>
                                <asp:ListItem  Value="41" Text="41"></asp:ListItem>
                                <asp:ListItem  Value="42" Text="42"></asp:ListItem>
                                <asp:ListItem  Value="43" Text="43"></asp:ListItem>
                                <asp:ListItem  Value="44" Text="44"></asp:ListItem>
                                <asp:ListItem  Value="45" Text="45"></asp:ListItem>
                                <asp:ListItem  Value="46" Text="46"></asp:ListItem>
                                <asp:ListItem  Value="47" Text="47"></asp:ListItem>
                                <asp:ListItem  Value="48" Text="48"></asp:ListItem>
                                <asp:ListItem  Value="49" Text="49"></asp:ListItem>
                                <asp:ListItem  Value="50" Text="50"></asp:ListItem>
                                <asp:ListItem  Value="51" Text="51"></asp:ListItem>
                                <asp:ListItem  Value="52" Text="52"></asp:ListItem>
                                <asp:ListItem  Value="53" Text="53"></asp:ListItem>
                                <asp:ListItem  Value="54" Text="54"></asp:ListItem>
                                <asp:ListItem  Value="55" Text="55"></asp:ListItem>
                                <asp:ListItem  Value="56" Text="56"></asp:ListItem>
                                <asp:ListItem  Value="57" Text="57"></asp:ListItem>
                                <asp:ListItem  Value="58" Text="58"></asp:ListItem>
                                <asp:ListItem  Value="59" Text="59"></asp:ListItem>
                                <asp:ListItem  Value="60" Text="60"></asp:ListItem>
                                <asp:ListItem  Value="61" Text="61"></asp:ListItem>
                                <asp:ListItem  Value="62" Text="62"></asp:ListItem>
                                <asp:ListItem  Value="63" Text="63"></asp:ListItem>
                                <asp:ListItem  Value="64" Text="64"></asp:ListItem>
                                <asp:ListItem  Value="65" Text="65"></asp:ListItem>
                                <asp:ListItem  Value="66" Text="66"></asp:ListItem>
                                <asp:ListItem  Value="67" Text="67"></asp:ListItem>
                                <asp:ListItem  Value="68" Text="68"></asp:ListItem>
                                <asp:ListItem  Value="69" Text="69"></asp:ListItem>
                                <asp:ListItem  Value="70" Text="70"></asp:ListItem>
                                <asp:ListItem  Value="71" Text="71"></asp:ListItem>
                                <asp:ListItem  Value="72" Text="72"></asp:ListItem>
                                <asp:ListItem  Value="73" Text="73"></asp:ListItem>
                                <asp:ListItem  Value="74" Text="74"></asp:ListItem>
                                <asp:ListItem  Value="75" Text="75"></asp:ListItem>
                                <asp:ListItem  Value="76" Text="76"></asp:ListItem>
                                <asp:ListItem  Value="77" Text="77"></asp:ListItem>
                                <asp:ListItem  Value="78" Text="78"></asp:ListItem>
                                <asp:ListItem  Value="79" Text="79"></asp:ListItem>
                                <asp:ListItem  Value="80" Text="80"></asp:ListItem>
                             </asp:DropDownList>
                            <a href="http://14.102.146.116/Admin/EbAd_CurrencyTableNew.aspx" target="_blank">View Currency Table</a><br />
                            <asp:Label runat="server" Text="Note: BookStore only support display of 1 type of currency.<br>The Price you put on your ebook product will reflect on the currency type you have chosen.<br>No Currency conversion rate.<br>However admin ebook products will adjust accordingly to our admin set price for respective country."></asp:Label>    
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
                            Discount : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:DropDownList ID="txtDiscount" runat="server" AutoPostBack="True" CssClass="stdDropDown2" OnSelectedIndexChanged="txtDiscount_SelectedIndexChanged" TabIndex="6" ValidationGroup="VgCheck">
                                 <asp:ListItem Selected="True" Value="10" Text="10%"></asp:ListItem>
                                 <asp:ListItem  Value="20" Text="20%"></asp:ListItem>
                                 <asp:ListItem  Value="30" Text="30%"></asp:ListItem>
                                 <asp:ListItem  Value="40" Text="40%"></asp:ListItem>
                                 <asp:ListItem  Value="50" Text="50%"></asp:ListItem>
                                 <asp:ListItem  Value="60" Text="60%"></asp:ListItem>
                                 <asp:ListItem  Value="70" Text="70%"></asp:ListItem>
                                 <asp:ListItem  Value="80" Text="80%"></asp:ListItem>
                                 <asp:ListItem  Value="90" Text="90%"></asp:ListItem>
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
                            Discounted Price :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtDiscountedPrice"  runat="server" CssClass="stdTextField1" TabIndex="14"></asp:TextBox>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                    <asp:TextBox ID="txtPrepaidPrice"  runat="server" CssClass="stdTextField1" TabIndex="14" Visible="false"></asp:TextBox>
                    <%--<tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Prepaid Price Points :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtPrepaidPrice"  runat="server" CssClass="stdTextField1" TabIndex="14"></asp:TextBox>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>--%>
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            Upload eBook Image: <span class="font_12Msg_Error">*</span><br />(.JPEG or .PNG only)
                       
                        </td>
                        <td class="auto-style6" align="left">

                         &nbsp;
                            <asp:Label runat="server" ID="BookImgThrobber" Style="display: none;">
                                <img alt="loader" id="BookImgLoader" class="auto-style8" src="../Images/Loader1.gif" />
                            </asp:Label>
                            

                            <%--<asp:FileUpload ID="UploadImgCtrl" runat="server" TabIndex="32" onchange="up_Image(this)" ToolTip="Click Browse to button to select an image from your computer." />--%>
                             <asp:FileUpload ID="UploadImgCtrl" runat="server" TabIndex="32" ToolTip="Click Browse to button to select an image from your computer." />
                                &nbsp;
                            
                            <br />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="UploadImgCtrl" Display="Dynamic" runat="server" ErrorMessage="Please Choose an Image for EBook."></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="FileUploadValidator"  runat="server"  ValidationGroup="VgCheck" Display="Dynamic"
                                ControlToValidate="UploadImgCtrl" ErrorMessage="Only jpg, gif or Png type images are allowed.<br> Please select another image." 
                                ValidationExpression="^.*\.(jpg|JPG|gif|GIF|png|PNG)$" Enabled="true"></asp:RegularExpressionValidator>

                           
                             <asp:CustomValidator ID="CustomValidator_BookImage" runat="server" ControlToValidate="UploadImgCtrl" Display="Dynamic" ValidationGroup="VgCheck"
                                                                    ErrorMessage="" OnServerValidate="CustomVdr_eBookImage_ServerValidate"></asp:CustomValidator>
                            

                        </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
           
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                       
                            <div id="dvImageUploadInfo" style="display: none;">  

                                <table id="dvImageUploadInfoTable" class="dispTable" >
                                     <tr>
                                        <td width="100px">Status :</td>
                                        <td><asp:Label ID="lblSuccess" CssClass="font_12Msg_Success" runat="server" /></td>
                                    </tr>
                                     <tr>
                                        <td>File Name :</td>
                                        <td> <asp:Label ID="lblFileNameDisplay" runat="server" /> </td>
                                    </tr>

                                      <tr>
                                        <td>File Size :</td>
                                        <td><asp:Label ID="lblFileSizeDisplay" runat="server" /></td>
                                    </tr>

                                      <tr>
                                        <td>Content Type :</td>
                                        <td><asp:Label ID="lblContentTypeDisplay" runat="server" /></td>
                                    </tr>

                                </table>

                         </div>

                          <div style=" border: 2px solid red; padding: 15px; display: none; width: 350px" id="dvImageUploadErrorInfo">

                                <asp:Label ID="lblErrorStatus" CssClass="font_12Normal" Font-Bold="true" runat="server" Text="Status:-" /><asp:Label

                                    ID="lblError" CssClass="font_12Msg_Error" ForeColor="Red" runat="server" /><br />

                            </div>

                            <asp:Label ID="lblErrorImg" CssClass="font_12Msg_Error" runat="server" Text=""></asp:Label>
                         </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            Upload eBook File : <span class="font_12Msg_Error">*</span></td>
                        <td class="auto-style6" align="left">
                              &nbsp;
                            <asp:Label runat="server" ID="BookFileThrobber" Text="Uploading File... Please Wait..." Style="display: none;">
                                <img alt="loader" id="BookfileLoader" class="auto-style8" src="../Images/Loader1.gif" />
                            </asp:Label>


                            <asp:FileUpload ID="UploadEbookFile" runat="server" TabIndex="34" ToolTip="Browse and Select Ebook File." />
&nbsp;
                              <br />
                              Accept Files less than 10MB<br />
                              Filename should not be more than 25 characters and cannot consists of Special Characters. Filename only accept Alphanumeric characters<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UploadEbookFile" Display="Dynamic" runat="server" ErrorMessage="Please Choose a File for EBook."></asp:RequiredFieldValidator>

                             <asp:RegularExpressionValidator ID="FileUploadValidator0"  runat="server" Display="Dynamic"  ValidationGroup="VgCheck"
                                ControlToValidate="UploadEbookFile" ErrorMessage="Only Pdf files are allowed.  Special Characters are not allowed for File Name." 
                                ValidationExpression="([a-zA-Z0-9\s_\\\-:])+(.PDF|.pdf)$" Enabled="true"></asp:RegularExpressionValidator>
                            
                            <br />
                            
                            <asp:CustomValidator ID="CustomVdr_eBookFile" runat="server" Display="Dynamic" ControlToValidate="UploadEbookFile" ValidationGroup="VgCheck"
                                                                    ErrorMessage="" OnServerValidate="CustomVdr_eBookFile_ServerValidate"></asp:CustomValidator>
                           

                            

                         </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                           
                        
                        
                              <div id="dvEbFileUploadInfo" style="display: none;">  

                                <table id="dvEbFileUploadInfoTable" class="dispTable" >
                                     <tr>
                                        <td width="100px">Status :</td>
                                        <td><asp:Label ID="lblSuccess1" CssClass="font_12Msg_Success" runat="server" /></td>
                                    </tr>
                                     <tr>
                                        <td>File Name :</td>
                                        <td> <asp:Label ID="lblFileNameDisplay1" runat="server" /> </td>
                                    </tr>

                                      <tr>
                                        <td>File Size :</td>
                                        <td><asp:Label ID="lblFileSizeDisplay1" runat="server" /></td>
                                    </tr>

                                      <tr>
                                        <td>Content Type :</td>
                                        <td><asp:Label ID="lblContentTypeDisplay1" runat="server" /></td>
                                    </tr>

                                </table>

                         </div>

                          <div style=" border: 2px solid red; padding: 15px; display: none; width: 350px" id="dvEbFileUploadErrorInfo">

                                <asp:Label ID="lblErrorStatus1" CssClass="font_12Normal" Font-Bold="true" runat="server" Text="Status:-" /><asp:Label

                                    ID="lblError1" CssClass="font_12Msg_Error" ForeColor="Red" runat="server" /><br />

                            </div>
                        
                        <asp:Label ID="lblErrorFile" CssClass="font_12Msg_Error" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Description :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtDescription" CssClass="stdTextArea2" runat="server"  Width="600px" Height="200px"
                                ToolTip="Enter Description"  ValidationGroup="VgCheck" 
                                TextMode="MultiLine" TabIndex="16"></asp:TextBox>
                            </td>
                        <td class="tblFormText1" align="left">
                            
                            
                         </td>
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
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            </td>
                        <td class="auto-style3" align="left">
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   <asp:TextBox ID="txtSubject"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" TabIndex="18" MaxLength="100" Visible="false" Text="-"></asp:TextBox>
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Comments :
                            <br />
                            (Note: can include video link)</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtVideoLink"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextArea2" Width="600px" Height="200px" TabIndex="18" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                       <%-- <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Sender Email ID : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtSenderEmailID"   runat="server" CssClass="stdTextField2" TabIndex="20"></asp:TextBox>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="reqValImage" ControlToValidate="txtSenderEmailID" runat="server" ErrorMessage="Enter Email ID." ValidationGroup="VgCheck" Display="Dynamic"></asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                          ControlToValidate="txtSenderEmailID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                          Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Email" ValidationGroup="VgCheck" 
                          SetFocusOnError="True"></asp:RegularExpressionValidator>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>--%>
                    </tr>
                   <asp:TextBox ID="txtSMSmessage"  runat="server" Visible="false"></asp:TextBox>
                     <%--<tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            SMS Reply to Customer :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtSMSmessage"  runat="server" CssClass="stdTextArea2" onKeyUp="CheckTextLength(this,130)" onChange="CheckTextLength(this,130)" onkeypress="return this.value.length<=140" MaxLength="130" TextMode="MultiLine" Width="600px" Height="100px" TabIndex="22"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtSMSmessage" Display ="Dynamic" runat="server" ValidationExpression=".{0,140}" ErrorMessage="<br>Max. 140 characters allowed."></asp:RegularExpressionValidator>
                            <br />
                            <asp:Label ID="lblReplyMsgInfo" runat="server" Visible="false" CssClass="ValAlert_Error" Text=""></asp:Label>

                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                   <asp:TextBox ID="txtEmailMessage" CssClass="stdTextArea2" runat="server"  Width="600px" Height="200px"
                                ToolTip="Enter Description"  
                                TextMode="MultiLine" TabIndex="24" Visible="false"></asp:TextBox>
                     <%--<tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Email message to Customer :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtEmailMessage" CssClass="stdTextArea2" runat="server"  Width="600px" Height="200px"
                                ToolTip="Enter Description"  
                                TextMode="MultiLine" TabIndex="24"></asp:TextBox>
                         </td>
                        <td class="tblFormText1" align="left">
                           
                             
                           
&nbsp;
                            
                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                                    <asp:TextBox ID="txtCCMobile1" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtCCMobile2" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtCCMobile3" runat="server" Visible="false"></asp:TextBox>
                     <%--<tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            SMS CC copy&nbsp;
                            to following Mobiles.
                            <br />
                            <br />
                            ( e.g. to Supplier / Author / Publisher etc., )<br />
                         </td>
                        <td class="tblFormText1" align="left">
                           <br />  
                         1.
                                    <asp:TextBox ID="txtCCMobile1" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                    <br />
                                    2.
                                    <asp:TextBox ID="txtCCMobile2" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                    <br />
                                    3. <asp:TextBox ID="txtCCMobile3" runat="server" CssClass="stdTextField1"></asp:TextBox>
                         <br />
                            <br />
                        </td>
                        <td class="tblFormText1" align="left">
                           
                             
                           
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                   
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
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Save" onclick="btnSave_Click" />
                            &nbsp;<asp:Button ID="btnSaveCont" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Save and Continue" onclick="btnSaveCont_Click" Visible="false" />
                            &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD" 
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

