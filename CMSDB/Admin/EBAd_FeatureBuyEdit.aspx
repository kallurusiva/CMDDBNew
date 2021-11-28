<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_FeatureBuyEdit.aspx.cs" Inherits="EBAd_FeatureBuyEdit" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_BestSeller.ascx" tagname="EBLeftMenu_BestSeller" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="EBLeftMenu_FeatureBuy.ascx" tagname="EBLeftMenu_FeatureBuy" tagprefix="uc3" %>

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
        // This function will execute after file uploaded successfully
        function uploadComplete_Image(sender, args) {
            try {

                var fileTypes = ['png', 'jpg', 'gif'];

                /*Validation for file extension*/
                var fileName = args.get_fileName();
                var dots = fileName.split(".");

                var fileExtension = dots[dots.length - 1];

                if (fileTypes.indexOf(fileExtension) == -1)
                {
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
            catch(e)
            {


            }
           

        }

    // This function will execute if file upload fails
    function uploadError_Image() {
        
        try
        {

            document.getElementById('dvImageUploadInfo').style.display = 'none';
            document.getElementById('dvImageUploadErrorInfo').style.display = 'block';
            document.getElementById('<%=lblError.ClientID %>').innerHTML = "File Not Uploaded" + args.get_errorMessage();
            
        }
        catch(e)
        {

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


</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc3:EBLeftMenu_FeatureBuy ID="EBLeftMenu_FeatureBuy1" runat="server" />

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
                            &nbsp; Edit Feature Buy :&nbsp; Ebook&nbsp; </td>
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
                        <td width="60%">
                            &nbsp;</td>
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
                            Book Name : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtBookName"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" TabIndex="2" OnTextChanged="txtBookName_TextChanged"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBookName" ErrorMessage=" Please enter Book Name" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

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
                            Book Title :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtBookTitle" runat="server" CssClass="stdTextField2" TabIndex="4"></asp:TextBox>
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
                            Category : <span class="font_12Msg_Error">*</span></td>
                        <td class="auto-style3" align="left">
                            <asp:DropDownList ID="ddlCategory" CssClass="stdDropDown2" runat="server" ValidationGroup="VgCheck" TabIndex="6">
                            </asp:DropDownList>

                              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="ddlCategory" Display="Dynamic" 
                                            ErrorMessage="Please select category" InitialValue="0" 
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
                            Display at Website</td>
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
                            Can buy using PayPal ?</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoBuyPayPal" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="28">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
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
                            Can buy using SMS ?</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoBuySMS" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="28">
                                <asp:ListItem Selected="True" Value="True">YES</asp:ListItem>
                                <asp:ListItem Value="False">NO</asp:ListItem>
                            </asp:RadioButtonList>
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
                            <asp:TextBox ID="txtPrice"  runat="server" CssClass="stdTextField1" AutoPostBack="True" OnTextChanged="txtPrice_TextChanged" TabIndex="10"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Price cannot be Empty. " ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
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
                            <asp:TextBox ID="txtDiscount"  runat="server" CssClass="stdTextField1" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged" TabIndex="12"></asp:TextBox>
                            &nbsp;%</td>
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
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            <asp:Image ID="ImageBook" CssClass="ImgTestimonialCss" runat="server" /> </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            Upload Book Image: <span class="font_12Msg_Error">*</span></td>
                        <td class="auto-style6" align="left">
                            <asp:AsyncFileUpload ID="AsyncFU_Image" runat="server" BorderStyle="None" PersistFile="True" ThrobberID="BookImgThrobber" ToolTip="Select Image to be displayed for eBook" UploaderStyle="Modern"
                                OnClientUploadComplete="uploadComplete_Image" OnClientUploadError="uploadError_Image" OnUploadedComplete="AsyncFU_Image_UploadedComplete"
                                
                                 />

                         &nbsp;
                            <asp:Label runat="server" ID="BookImgThrobber" Style="display: none;">
                                <img alt="loader" id="BookImgLoader" class="auto-style8" src="../Images/Loader1.gif" />
                            </asp:Label>
                            

                            <asp:CustomValidator ID="CustomValidatorImageX" runat="server" CssClass="font_11Msg_Error" Display="None" ErrorMessage="&lt;br&gt;Ebook Image Size cannot exceed 2MB.Kindly upload an Image with size less than 2MB" SetFocusOnError="true" ValidationGroup="VgCheck" />
                            

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
                            &nbsp;</td>
                        <td class="auto-style6" align="left">
                            <asp:Label ID="lblCurrentEbookFile" CssClass="font_12Msg_Success" runat="server" Text=""></asp:Label></td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style5" >
                            &nbsp;</td>
                        <td class="auto-style5" >
                            Upload Book File : <span class="font_12Msg_Error">*</span></td>
                        <td class="auto-style6" align="left">
                            <asp:AsyncFileUpload ID="AsyncFU_EbFile" runat="server" BorderStyle="None" PersistFile="True" ThrobberID="BookFileThrobber" ToolTip="Select eBook File to be displayed for eBook" UploaderStyle="Modern"
                                OnClientUploadComplete="uploadComplete_File" OnClientUploadError="uploadComplete_File" OnUploadedComplete="AsyncFU_File_UploadedComplete"
                                 />
                              &nbsp;
                            <asp:Label runat="server" ID="BookFileThrobber" Text="Uploading File... Please Wait..." Style="display: none;">
                                <img alt="loader" id="BookfileLoader" class="auto-style8" src="../Images/Loader1.gif" />
                            </asp:Label>


                            <asp:CustomValidator ID="CustomValidatorFileX" runat="server" CssClass="font_11Msg_Error" Display="None" ErrorMessage="&lt;br&gt;Ebook File Size cannot exceed 5MB.Kindly upload an Image with size less than 5MB" SetFocusOnError="true" ValidationGroup="VgCheck" />
                            

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
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Subject : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtSubject"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField2" TabIndex="18"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSubject" ErrorMessage="Enter Subject" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
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
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            SMS Reply to Customer :</td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtSMSmessage"  runat="server" CssClass="stdTextArea2" TextMode="MultiLine" Width="600px" Height="100px" TabIndex="22"></asp:TextBox>
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
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Save" onclick="btnSave_Click" />
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

