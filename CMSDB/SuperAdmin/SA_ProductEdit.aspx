<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_ProductEdit.aspx.cs" Inherits="SuperAdmin_SA_ProductEdit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="SA_SideMenu_Products.ascx" tagname="SA_SideMenu_Products" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_Products ID="SA_SideMenu_Products1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script language="javascript" type="text/javascript">

    function fnFileUploaded() {
    
    
    }

    function fnFileUploadErr() {


    }

    function IsImageUploaded() {
       
        var objUploadImgCtrl = document.getElementById('<%= UploadImgCtrl.ClientID %>');
        var FileUploadPath = objUploadImgCtrl.value;

        if (FileUploadPath != '') {
            // There is no file selected
            // args.IsValid = false;
            alert('You selected an Image but not uploaded           \nPlease click on the Upload Image button to upload.');
            return false;
        }
        
    
    
    }

</script>


    <form id="tForm" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
       
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
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Label ID="lblEditProducts" runat="server" Text="Edit Product"></asp:Label>
                            </td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="96%">
                    <tr>
                        <td width="5%">
                            &nbsp;</td>
                        <td width="20%">
                            &nbsp;</td>
                        <td width="5%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="5%">
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
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Literal ID="RT_ProductName" Text="Product Name" runat="server"></asp:Literal> :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtProductName"  ValidationGroup="vgCheck" runat="server" CssClass="stdTextField1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgCheck" ControlToValidate="txtProductName"
                             Display="Dynamic" SetFocusOnError="true"  runat="server" ErrorMessage="Enter Product Name"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="RT_ProductCode" Text="Product Code" runat="server"></asp:Literal> :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtProductCode"  ValidationGroup="vgCheck" runat="server" CssClass="stdTextField1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="vgCheck" ControlToValidate="txtProductCode"
                             Display="Dynamic" SetFocusOnError="true"  runat="server" ErrorMessage="Enter Product code"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="RT_ProductPrice" Text="Product Price" runat="server"></asp:Literal> :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtProductPrice"  ValidationGroup="vgCheck" runat="server" CssClass="stdTextField1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vgCheck" ControlToValidate="txtProductPrice"
                             Display="Dynamic" SetFocusOnError="true"  runat="server" ErrorMessage="Enter Product price"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ValidationExpression="^\d{0,7}(\.\d{1,2})?$"  runat="server" ErrorMessage="Only Decimal values are allowed. With the format 999999.99" Display="Dynamic" SetFocusOnError="True" ControlToValidate="txtProductPrice"></asp:RegularExpressionValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="RT_ProductDescription" Text="Product Description" runat="server"></asp:Literal> :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtProductDescription" TextMode="MultiLine"  ValidationGroup="vgCheck" runat="server" CssClass="stdTextArea2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="vgCheck" ControlToValidate="txtProductDescription"
                             Display="Dynamic" SetFocusOnError="true"  runat="server" ErrorMessage="Enter Product Description"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="RT_ProductBenefits" Text="Product Benefits" runat="server"></asp:Literal> :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtProductBenefits" TextMode="MultiLine"  ValidationGroup="vgCheck" runat="server" CssClass="stdTextArea2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="vgCheck" ControlToValidate="txtProductBenefits"
                             Display="Dynamic" SetFocusOnError="true"  runat="server" ErrorMessage="Enter Product Benefits"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td align="left">
                            <asp:Image ID="ImgProduct" BorderColor="ActiveBorder" BorderStyle="Solid" BorderWidth="1px" CssClass="ImgProductEditImg" Visible="false" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="RT_UploadProductImage" Text="Upload Product Image" runat="server"></asp:Literal></td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:FileUpload ID="UploadImgCtrl" runat="server"   
                                ToolTip="Click Browse to button to select an image from your computer." />&nbsp;
                            <%--<asp:CustomValidator ID="CustomValidator1" ValidationGroup="vgCheck" ControlToValidate="UploadImgCtrl" ClientValidationFunction="IsImageUploaded" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>   --%>
                            <asp:Button ID="btnUpload" CssClass="stdButtonNormal" runat="server" onclick="btnUpload_Click" 
                                Text="Upload Image" />
                                
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Label ID="lblUpMessage" runat="server" Text="" CssClass="font_12Msg_Success"></asp:Label>
                            <asp:RegularExpressionValidator ID="FileUploadValidator"  runat="server" 
                                ControlToValidate="UploadImgCtrl" ErrorMessage="Only jpg or gif type images are allowed.  Please select another image." 
                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg])" Enabled="true"></asp:RegularExpressionValidator>
                            
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="LtrDisplayweb" runat="server"></asp:Literal></td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:CheckBox ID="chkActive" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="vgCheck" CssClass="stdbuttonAction" 
                                Text="Save" onclick="btnSave_Click" OnClientClick="return IsImageUploaded()" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonAction" 
                                Text="Cancel" onclick="btnCancel_Click" />
                                <%--&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>" />--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td align="left" >
                            </td>
                        <td >
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                     &nbsp;
                        </td>
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

