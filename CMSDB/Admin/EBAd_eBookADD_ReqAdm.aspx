<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_eBookADD_ReqAdm.aspx.cs" Inherits="Admin_EBAd_eBookADD_ReqAdm" %>
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

            var fileTypes = ['pdf'];

            oFiles = document.getElementById('<%=UploadEbookFile.ClientID%>').files;
            nFiles = oFiles.length;

            nFilename = oFiles.name;
            nfileSize = oFiles.size;
            nfileType = oFiles.type;

            alert(nFiles);

            /*Validation for file extension*/
            var fileName = document.getElementById('<%=UploadEbookFile.ClientID%>').value;
            var dots = fileName.split(".");

            var fileExtension = dots[dots.length - 1];
            // alert(fileName);
            // alert(fileExtension);


            if (fileTypes.indexOf(fileExtension) == -1) {
                /* if (fileExtension.indexOf('.doc') != -1) { */
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Only pdf files are supported! for eBook.";
                return;
            }

            /*Validation for file size*/
            if (parseInt(nfileSize) > 21214400) {
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Book File size should be less then 20MB";
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

            var fileTypes = ['pdf'];

            /*Validation for file extension*/
            var fileName = args.get_fileName();
            var dots = fileName.split(".");

            var fileExtension = dots[dots.length - 1];

            if (fileTypes.indexOf(fileExtension) == -1) {
                /* if (fileExtension.indexOf('.doc') != -1) { */
                document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Only pdf files are supported!.";
                    return;
                }


                /*Validation for file size*/
            if (parseInt(args.get_length()) > 21214400) {
                    document.getElementById('dvEbFileUploadErrorInfo').style.display = 'block';
                    document.getElementById('dvEbFileUploadInfo').style.display = 'none';
                    document.getElementById('<%=lblError1.ClientID %>').innerHTML = "Book File size should be less then 20MB";
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
                            &nbsp; Request Upload New Admin Ebook&nbsp; </td>
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
                            Note:<br /><br />
                            1) Author Name and Picture must be part of the EBook Cover<br />
                            2) Can only request upload admin ebook. If you are the EBook Author and no exclusive agreement with other publisher on ecopy.<br />
                            3) Any missing information, if rejected ,must resubmit again.<br />
                            4) We reserved the right to print 5 Physical Copies for display promotion only.<br />
                            5) Please read Author Agreement (<a href="http://14.102.146.116/Admin/EbAd_WPInfo.aspx" target="_blank">view here</a>)<br />
                            6) Minimum Net Price - USD2. Maximum Net Price - USD30.<br />
                            7) Author with more than 5 eBooks will have standalone SubCategory under their name.<br />
                            8) Admin Book Upload Approval or Rejection - Every Monday/Wednesday/Friday.<br />
                            9) Currency Table (<a href="http://14.102.146.116/Admin/EbAd_CurrencyTableNew.aspx" target="_blank">view here</a>)<br />
                            10) Minimum 35 Pages required.
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
                            <span class="font_12Msg_Error"><asp:Literal runat="server" ID="ltrChanges" Text="Requet Changes for :" Visible="false"></asp:Literal></span>
                             </td>
                        <td class="tblFormText1" align="left">
                             <asp:CheckBoxList runat="server" ID="chkChanges" Visible="false">
                                <asp:ListItem Value="price" Text="Price"></asp:ListItem>
                                <asp:ListItem Value="description" Text="description"></asp:ListItem>
                                <asp:ListItem Value="pdf" Text="pdf"></asp:ListItem>
                                <asp:ListItem Value="bookcover" Text="bookcover"></asp:ListItem>
                                <asp:ListItem Value="title" Text="title"></asp:ListItem>
                            </asp:CheckBoxList>
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
                            Author Name : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtAuthorName"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" TabIndex="2" MaxLength="100"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAuthorName" ErrorMessage=" Please enter Author Name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

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
                   
                    
                            <asp:TextBox ID="txtBookTitle" runat="server" CssClass="stdTextField2" TabIndex="4" MaxLength="250" Text="" Visible="false"></asp:TextBox>
                            
                   
                     
                          
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;
                        </td>
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
                            Price : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <%--<asp:TextBox ID="txtPrice"  runat="server" CssClass="stdTextField1" AutoPostBack="True" OnTextChanged="txtPrice_TextChanged" TabIndex="10"></asp:TextBox>--%>
                            <%--&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Price cannot be Empty. " ValidationGroup="VgCheck"></asp:RequiredFieldValidator>--%>
                            <asp:DropDownList ID="txtPrice" runat="server" AutoPostBack="True" CssClass="stdDropDown2" OnSelectedIndexChanged="txtPrice_SelectedIndexChanged" TabIndex="6" ValidationGroup="VgCheck">
                               <asp:ListItem  Value="2.00" Text="2.00"></asp:ListItem>
                                <asp:ListItem  Value="2.10" Text="2.10"></asp:ListItem>
                                <asp:ListItem  Value="2.20" Text="2.20"></asp:ListItem>
                                <asp:ListItem  Value="2.30" Text="2.30"></asp:ListItem>
                                <asp:ListItem  Value="2.40" Text="2.40"></asp:ListItem>
                                <asp:ListItem  Value="2.50" Text="2.50"></asp:ListItem>
                                <asp:ListItem  Value="2.60" Text="2.60"></asp:ListItem>
                                <asp:ListItem  Value="2.70" Text="2.70"></asp:ListItem>
                                <asp:ListItem  Value="2.80" Text="2.80"></asp:ListItem>
                                <asp:ListItem  Value="2.90" Text="2.90"></asp:ListItem>
                                <asp:ListItem  Value="3.00" Text="3.00"></asp:ListItem>
                                <asp:ListItem  Value="3.10" Text="3.10"></asp:ListItem>
                                <asp:ListItem  Value="3.20" Text="3.20"></asp:ListItem>
                                <asp:ListItem  Value="3.30" Text="3.30"></asp:ListItem>
                                <asp:ListItem  Value="3.40" Text="3.40"></asp:ListItem>
                                <asp:ListItem  Value="3.50" Text="3.50"></asp:ListItem>
                                <asp:ListItem  Value="3.60" Text="3.60"></asp:ListItem>
                                <asp:ListItem  Value="3.70" Text="3.70"></asp:ListItem>
                                <asp:ListItem  Value="3.80" Text="3.80"></asp:ListItem>
                                <asp:ListItem  Value="3.90" Text="3.90"></asp:ListItem>
                                <asp:ListItem  Value="4.00" Text="4.00"></asp:ListItem>
                                <asp:ListItem  Value="4.10" Text="4.10"></asp:ListItem>
                                <asp:ListItem  Value="4.20" Text="4.20"></asp:ListItem>
                                <asp:ListItem  Value="4.30" Text="4.30"></asp:ListItem>
                                <asp:ListItem  Value="4.40" Text="4.40"></asp:ListItem>
                                <asp:ListItem  Value="4.50" Text="4.50"></asp:ListItem>
                                <asp:ListItem  Value="4.60" Text="4.60"></asp:ListItem>
                                <asp:ListItem  Value="4.70" Text="4.70"></asp:ListItem>
                                <asp:ListItem  Value="4.80" Text="4.80"></asp:ListItem>
                                <asp:ListItem  Value="4.90" Text="4.90"></asp:ListItem>
                                <asp:ListItem  Value="5.00" Text="5.00"></asp:ListItem>
                                <asp:ListItem  Value="5.10" Text="5.10"></asp:ListItem>
                                <asp:ListItem  Value="5.20" Text="5.20"></asp:ListItem>
                                <asp:ListItem  Value="5.30" Text="5.30"></asp:ListItem>
                                <asp:ListItem  Value="5.40" Text="5.40"></asp:ListItem>
                                <asp:ListItem  Value="5.50" Text="5.50"></asp:ListItem>
                                <asp:ListItem  Value="5.60" Text="5.60"></asp:ListItem>
                                <asp:ListItem  Value="5.70" Text="5.70"></asp:ListItem>
                                <asp:ListItem  Value="5.80" Text="5.80"></asp:ListItem>
                                <asp:ListItem  Value="5.90" Text="5.90"></asp:ListItem>
                                <asp:ListItem  Value="6.00" Text="6.00"></asp:ListItem>
                                <asp:ListItem  Value="6.10" Text="6.10"></asp:ListItem>
                                <asp:ListItem  Value="6.20" Text="6.20"></asp:ListItem>
                                <asp:ListItem  Value="6.30" Text="6.30"></asp:ListItem>
                                <asp:ListItem  Value="6.40" Text="6.40"></asp:ListItem>
                                <asp:ListItem  Value="6.50" Text="6.50"></asp:ListItem>
                                <asp:ListItem  Value="6.60" Text="6.60"></asp:ListItem>
                                <asp:ListItem  Value="6.70" Text="6.70"></asp:ListItem>
                                <asp:ListItem  Value="6.80" Text="6.80"></asp:ListItem>
                                <asp:ListItem  Value="6.90" Text="6.90"></asp:ListItem>
                                <asp:ListItem  Value="7.00" Text="7.00"></asp:ListItem>
                                <asp:ListItem  Value="7.10" Text="7.10"></asp:ListItem>
                                <asp:ListItem  Value="7.20" Text="7.20"></asp:ListItem>
                                <asp:ListItem  Value="7.30" Text="7.30"></asp:ListItem>
                                <asp:ListItem  Value="7.40" Text="7.40"></asp:ListItem>
                                <asp:ListItem  Value="7.50" Text="7.50"></asp:ListItem>
                                <asp:ListItem  Value="7.60" Text="7.60"></asp:ListItem>
                                <asp:ListItem  Value="7.70" Text="7.70"></asp:ListItem>
                                <asp:ListItem  Value="7.80" Text="7.80"></asp:ListItem>
                                <asp:ListItem  Value="7.90" Text="7.90"></asp:ListItem>
                                <asp:ListItem  Value="8.00" Text="8.00"></asp:ListItem>
                                <asp:ListItem  Value="8.10" Text="8.10"></asp:ListItem>
                                <asp:ListItem  Value="8.20" Text="8.20"></asp:ListItem>
                                <asp:ListItem  Value="8.30" Text="8.30"></asp:ListItem>
                                <asp:ListItem  Value="8.40" Text="8.40"></asp:ListItem>
                                <asp:ListItem  Value="8.50" Text="8.50"></asp:ListItem>
                                <asp:ListItem  Value="8.60" Text="8.60"></asp:ListItem>
                                <asp:ListItem  Value="8.70" Text="8.70"></asp:ListItem>
                                <asp:ListItem  Value="8.80" Text="8.80"></asp:ListItem>
                                <asp:ListItem  Value="8.90" Text="8.90"></asp:ListItem>
                                <asp:ListItem  Value="9.00" Text="9.00"></asp:ListItem>
                                <asp:ListItem  Value="9.10" Text="9.10"></asp:ListItem>
                                <asp:ListItem  Value="9.20" Text="9.20"></asp:ListItem>
                                <asp:ListItem  Value="9.30" Text="9.30"></asp:ListItem>
                                <asp:ListItem  Value="9.40" Text="9.40"></asp:ListItem>
                                <asp:ListItem  Value="9.50" Text="9.50"></asp:ListItem>
                                <asp:ListItem  Value="9.60" Text="9.60"></asp:ListItem>
                                <asp:ListItem  Value="9.70" Text="9.70"></asp:ListItem>
                                <asp:ListItem  Value="9.80" Text="9.80"></asp:ListItem>
                                <asp:ListItem  Value="9.90" Text="9.90"></asp:ListItem>
                                <asp:ListItem  Value="10.00" Text="10.00"></asp:ListItem>
                                <asp:ListItem  Value="10.20" Text="10.20"></asp:ListItem>
                                <asp:ListItem  Value="10.40" Text="10.40"></asp:ListItem>
                                <asp:ListItem  Value="10.60" Text="10.60"></asp:ListItem>
                                <asp:ListItem  Value="10.80" Text="10.80"></asp:ListItem>
                                <asp:ListItem  Value="11.00" Text="11.00"></asp:ListItem>
                                <asp:ListItem  Value="11.20" Text="11.20"></asp:ListItem>
                                <asp:ListItem  Value="11.40" Text="11.40"></asp:ListItem>
                                <asp:ListItem  Value="11.60" Text="11.60"></asp:ListItem>
                                <asp:ListItem  Value="11.80" Text="11.80"></asp:ListItem>
                                <asp:ListItem  Value="12.00" Text="12.00"></asp:ListItem>
                                <asp:ListItem  Value="12.20" Text="12.20"></asp:ListItem>
                                <asp:ListItem  Value="12.40" Text="12.40"></asp:ListItem>
                                <asp:ListItem  Value="12.60" Text="12.60"></asp:ListItem>
                                <asp:ListItem  Value="12.80" Text="12.80"></asp:ListItem>
                                <asp:ListItem  Value="13.00" Text="13.00"></asp:ListItem>
                                <asp:ListItem  Value="13.20" Text="13.20"></asp:ListItem>
                                <asp:ListItem  Value="13.40" Text="13.40"></asp:ListItem>
                                <asp:ListItem  Value="13.60" Text="13.60"></asp:ListItem>
                                <asp:ListItem  Value="13.80" Text="13.80"></asp:ListItem>
                                <asp:ListItem  Value="14.00" Text="14.00"></asp:ListItem>
                                <asp:ListItem  Value="14.20" Text="14.20"></asp:ListItem>
                                <asp:ListItem  Value="14.40" Text="14.40"></asp:ListItem>
                                <asp:ListItem  Value="14.60" Text="14.60"></asp:ListItem>
                                <asp:ListItem  Value="14.80" Text="14.80"></asp:ListItem>
                                <asp:ListItem  Value="15.00" Text="15.00"></asp:ListItem>
                                <asp:ListItem  Value="15.20" Text="15.20"></asp:ListItem>
                                <asp:ListItem  Value="15.40" Text="15.40"></asp:ListItem>
                                <asp:ListItem  Value="15.60" Text="15.60"></asp:ListItem>
                                <asp:ListItem  Value="15.80" Text="15.80"></asp:ListItem>
                                <asp:ListItem  Value="16.00" Text="16.00"></asp:ListItem>
                                <asp:ListItem  Value="16.20" Text="16.20"></asp:ListItem>
                                <asp:ListItem  Value="16.40" Text="16.40"></asp:ListItem>
                                <asp:ListItem  Value="16.60" Text="16.60"></asp:ListItem>
                                <asp:ListItem  Value="16.80" Text="16.80"></asp:ListItem>
                                <asp:ListItem  Value="17.00" Text="17.00"></asp:ListItem>
                                <asp:ListItem  Value="17.20" Text="17.20"></asp:ListItem>
                                <asp:ListItem  Value="17.40" Text="17.40"></asp:ListItem>
                                <asp:ListItem  Value="17.60" Text="17.60"></asp:ListItem>
                                <asp:ListItem  Value="17.80" Text="17.80"></asp:ListItem>
                                <asp:ListItem  Value="18.00" Text="18.00"></asp:ListItem>
                                <asp:ListItem  Value="18.20" Text="18.20"></asp:ListItem>
                                <asp:ListItem  Value="18.40" Text="18.40"></asp:ListItem>
                                <asp:ListItem  Value="18.60" Text="18.60"></asp:ListItem>
                                <asp:ListItem  Value="18.80" Text="18.80"></asp:ListItem>
                                <asp:ListItem  Value="19.00" Text="19.00"></asp:ListItem>
                                <asp:ListItem  Value="19.20" Text="19.20"></asp:ListItem>
                                <asp:ListItem  Value="19.40" Text="19.40"></asp:ListItem>
                                <asp:ListItem  Value="19.60" Text="19.60"></asp:ListItem>
                                <asp:ListItem  Value="19.80" Text="19.80"></asp:ListItem>
                                <asp:ListItem  Value="20.00" Text="20.00"></asp:ListItem>
                                <asp:ListItem  Value="20.50" Text="20.50"></asp:ListItem>
                                <asp:ListItem  Value="21.00" Text="21.00"></asp:ListItem>
                                <asp:ListItem  Value="21.50" Text="21.50"></asp:ListItem>
                                <asp:ListItem  Value="22.00" Text="22.00"></asp:ListItem>
                                <asp:ListItem  Value="22.50" Text="22.50"></asp:ListItem>
                                <asp:ListItem  Value="23.00" Text="23.00"></asp:ListItem>
                                <asp:ListItem  Value="23.50" Text="23.50"></asp:ListItem>
                                <asp:ListItem  Value="24.00" Text="24.00"></asp:ListItem>
                                <asp:ListItem  Value="24.50" Text="24.50"></asp:ListItem>
                                <asp:ListItem Value="25.00" Text="25.00"></asp:ListItem>
                                <asp:ListItem  Value="25.50" Text="25.50"></asp:ListItem>
                                <asp:ListItem Value="26.00" Text="26.00"></asp:ListItem>
                                <asp:ListItem  Value="26.50" Text="26.50"></asp:ListItem>
                                <asp:ListItem  Value="27.00" Text="27.00"></asp:ListItem>
                                <asp:ListItem  Value="27.50" Text="27.50"></asp:ListItem>
                                <asp:ListItem  Value="28.00" Text="28.00"></asp:ListItem>
                                <asp:ListItem  Value="28.50" Text="28.50"></asp:ListItem>
                                <asp:ListItem  Value="29.00" Text="29.00"></asp:ListItem>
                                <asp:ListItem  Value="29.50" Text="29.50"></asp:ListItem>
                                <asp:ListItem  Value="30.00" Text="30.00"></asp:ListItem>
                                <asp:ListItem  Value="30.50" Text="30.50"></asp:ListItem>
                                <asp:ListItem  Value="31.00" Text="31.00"></asp:ListItem>
                                <asp:ListItem  Value="31.50" Text="31.50"></asp:ListItem>
                                <asp:ListItem  Value="32.00" Text="32.00"></asp:ListItem>
                                <asp:ListItem  Value="32.50" Text="32.50"></asp:ListItem>
                                <asp:ListItem  Value="33.00" Text="33.00"></asp:ListItem>
                                <asp:ListItem  Value="33.50" Text="33.50"></asp:ListItem>
                                <asp:ListItem  Value="34.00" Text="34.00"></asp:ListItem>
                                <asp:ListItem  Value="34.50" Text="34.50"></asp:ListItem>
                                <asp:ListItem  Value="35.00" Text="35.00"></asp:ListItem>
                                <asp:ListItem  Value="35.50" Text="35.50"></asp:ListItem>
                                <asp:ListItem  Value="36.00" Text="36.00"></asp:ListItem>
                                <asp:ListItem  Value="36.50" Text="36.50"></asp:ListItem>
                                <asp:ListItem  Value="37.00" Text="37.00"></asp:ListItem>
                                <asp:ListItem  Value="37.50" Text="37.50"></asp:ListItem>
                                <asp:ListItem  Value="38.00" Text="38.00"></asp:ListItem>
                                <asp:ListItem  Value="38.50" Text="38.50"></asp:ListItem>
                                <asp:ListItem  Value="39.00" Text="39.00"></asp:ListItem>
                                <asp:ListItem  Value="39.50" Text="39.50"></asp:ListItem>
                                <asp:ListItem  Value="40.00" Text="40.00"></asp:ListItem>
                                <asp:ListItem  Value="40.50" Text="40.50"></asp:ListItem>
                                <asp:ListItem  Value="41.00" Text="41.00"></asp:ListItem>
                                <asp:ListItem  Value="41.50" Text="41.50"></asp:ListItem>
                                <asp:ListItem  Value="42.00" Text="42.00"></asp:ListItem>
                                <asp:ListItem  Value="42.50" Text="42.50"></asp:ListItem>
                                <asp:ListItem  Value="43.00" Text="43.00"></asp:ListItem>
                                <asp:ListItem  Value="43.50" Text="43.50"></asp:ListItem>
                                <asp:ListItem  Value="44.00" Text="44.00"></asp:ListItem>
                                <asp:ListItem  Value="44.50" Text="44.50"></asp:ListItem>
                                <asp:ListItem  Value="45.00" Text="45.00"></asp:ListItem>
                                <asp:ListItem  Value="45.50" Text="45.50"></asp:ListItem>
                                <asp:ListItem  Value="46.00" Text="46.00"></asp:ListItem>
                                <asp:ListItem  Value="46.50" Text="46.50"></asp:ListItem>
                                <asp:ListItem  Value="47.00" Text="47.00"></asp:ListItem>
                                <asp:ListItem  Value="47.50" Text="47.50"></asp:ListItem>
                                <asp:ListItem  Value="48.00" Text="48.00"></asp:ListItem>
                                <asp:ListItem  Value="48.50" Text="48.50"></asp:ListItem>
                                <asp:ListItem  Value="49.00" Text="49.00"></asp:ListItem>
                                <asp:ListItem  Value="49.50" Text="49.50"></asp:ListItem>
                                <asp:ListItem  Value="50.00" Text="50.00"></asp:ListItem>
                                <asp:ListItem  Value="51.00" Text="51.00"></asp:ListItem>
                                <asp:ListItem  Value="52.00" Text="52.00"></asp:ListItem>
                                <asp:ListItem  Value="53.00" Text="53.00"></asp:ListItem>
                                <asp:ListItem  Value="54.00" Text="54.00"></asp:ListItem>
                                <asp:ListItem  Value="55.00" Text="55.00"></asp:ListItem>
                                <asp:ListItem  Value="56.00" Text="56.00"></asp:ListItem>
                                <asp:ListItem  Value="57.00" Text="57.00"></asp:ListItem>
                                <asp:ListItem  Value="58.00" Text="58.00"></asp:ListItem>
                                <asp:ListItem  Value="59.00" Text="59.00"></asp:ListItem>
                                <asp:ListItem  Value="60.00" Text="60.00"></asp:ListItem>
                                <asp:ListItem  Value="61.00" Text="61.00"></asp:ListItem>
                                <asp:ListItem  Value="62.00" Text="62.00"></asp:ListItem>
                                <asp:ListItem  Value="63.00" Text="63.00"></asp:ListItem>
                                <asp:ListItem  Value="64.00" Text="64.00"></asp:ListItem>
                                <asp:ListItem  Value="65.00" Text="65.00"></asp:ListItem>
                                <asp:ListItem  Value="66.00" Text="66.00"></asp:ListItem>
                                <asp:ListItem  Value="67.00" Text="67.00"></asp:ListItem>
                                <asp:ListItem  Value="68.00" Text="68.00"></asp:ListItem>
                                <asp:ListItem  Value="69.00" Text="69.00"></asp:ListItem>
                                <asp:ListItem  Value="70.00" Text="70.00"></asp:ListItem>
                                <asp:ListItem  Value="71.00" Text="71.00"></asp:ListItem>
                                <asp:ListItem  Value="72.00" Text="72.00"></asp:ListItem>
                                <asp:ListItem  Value="73.00" Text="73.00"></asp:ListItem>
                                <asp:ListItem  Value="74.00" Text="74.00"></asp:ListItem>
                                <asp:ListItem  Value="75.00" Text="75.00"></asp:ListItem>
                                <asp:ListItem  Value="76.00" Text="76.00"></asp:ListItem>
                                <asp:ListItem  Value="77.00" Text="77.00"></asp:ListItem>
                                <asp:ListItem  Value="78.00" Text="78.00"></asp:ListItem>
                                <asp:ListItem  Value="79.00" Text="79.00"></asp:ListItem>
                                <asp:ListItem  Value="80.00" Text="80.00"></asp:ListItem>
                             </asp:DropDownList>
                            &nbsp; <a href="http://14.102.146.116/Admin/EbAd_CurrencyTableNew.aspx" target="_blank">View Currency Table</a><br />
                            <asp:Label runat="server" Text="Note: Price on USD only. (Take Currency Table to convert from Local currency)"></asp:Label>    
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
                                 <asp:ListItem Selected="True" Value="5" Text="5%"></asp:ListItem>
                                 <asp:ListItem Value="10" Text="10%"></asp:ListItem>
                                 <asp:ListItem Value="15" Text="15%"></asp:ListItem>
                                 <asp:ListItem  Value="20" Text="20%"></asp:ListItem>
                                 <asp:ListItem Value="25" Text="25%"></asp:ListItem>
                                 <asp:ListItem  Value="30" Text="30%"></asp:ListItem>
                                 <asp:ListItem Value="35" Text="35%"></asp:ListItem>
                                 <asp:ListItem  Value="40" Text="40%"></asp:ListItem>
                                 <asp:ListItem Value="45" Text="45%"></asp:ListItem>
                                 <asp:ListItem  Value="50" Text="50%"></asp:ListItem>
                                 <asp:ListItem Value="55" Text="55%"></asp:ListItem>
                                 <asp:ListItem  Value="60" Text="60%"></asp:ListItem>
                                 <asp:ListItem Value="65" Text="65%"></asp:ListItem>
                                 <asp:ListItem  Value="70" Text="70%"></asp:ListItem>
                                 <asp:ListItem Value="75" Text="75%"></asp:ListItem>
                                 <asp:ListItem  Value="80" Text="80%"></asp:ListItem>
                                 <asp:ListItem Value="85" Text="85%"></asp:ListItem>
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
                            Net Price :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtDiscountedPrice"  runat="server" CssClass="stdTextField1" TabIndex="14"></asp:TextBox>
                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                    <asp:TextBox ID="txtPrepaidPrice"  runat="server" CssClass="stdTextField1" TabIndex="14" Visible="false"></asp:TextBox>
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            Your Select Currency:</td>
                        <td class="auto-style6" align="left">
                            <asp:Label runat="server" ID="lblCurrency"></asp:Label></td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            Upload eBook Image: <span class="font_12Msg_Error">*</span><br />(.JPEG only)
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
                            Upload eBook File (PDF) : <span class="font_12Msg_Error">*</span></td>
                        <td class="auto-style6" align="left">
                              &nbsp;
                            <asp:Label runat="server" ID="BookFileThrobber" Text="Uploading File... Please Wait..." Style="display: none;">
                                <img alt="loader" id="BookfileLoader" class="auto-style8" src="../Images/Loader1.gif" />
                            </asp:Label>


                            <asp:FileUpload ID="UploadEbookFile" runat="server" TabIndex="34" ToolTip="Browse and Select Ebook File." />
&nbsp;
                              <br />
                              Only File less than 5 MB.<br />
                              Most Email eg; yahoo/gmail not accepting attachment more than 5MB.<br />
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
                            EBook Description :</td>
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
                            Uploader Remarks:(Suggested Categories and SubCategories)</td>
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

