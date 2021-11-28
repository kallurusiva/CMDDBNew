<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_CreateList_email.aspx.cs" Inherits="Admin_SMS_EbAd_CreateList_email" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Admin/EBLeftMenu_DataList.ascx" tagname="EBLeftMenu_DataList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_DataList ID="EBLeftMenu_DataList1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script type="text/javascript">
        {
            // Special FCK Editor disable & control script.
            // var editorInstance = FCKeditorAPI.GetInstance('FCKeditor1');

            function FCKeditor_OnComplete(editorInstance) {
                // editorInstance.BasePath = "/UserControls/fckeditor/"; - Note the path is now supplied in the HTML. - alert(editorInstance.Name);
                if ((editorInstance.Name == "ReferralForm_ReferralFormReferral_ViewReferral_FCKEditorManagerNotesItem") || (editorInstance.Name == "ReferralForm_ReferralFormReferral_ViewReferral_FCKEditorNotesItem")) {
                    // Diable toolbar.
                    editorInstance.EditorDocument.body.disabled = true;
                    // Diable buttons.
                    editorInstance.EditorWindow.parent.FCK.ToolbarSet.Disable();
                    editorInstance.EditorWindow.parent.document.getElementById("xExpanded").style.display = "none";
                }
            }

            //    function RTFMandatoryValidate(source, args) {
            //        var RTF = FCKeditorAPI.GetInstance('FCKeditor1');
            //        if (RTF.EditorDocument.body.innerText.length == 0) {
            //            args.IsValid = false;
            //            RTF.EditorDocument.body.focus();
            //            return;
            //        }
            //        args.IsValid = true;
            //        return;
            //    }
        }
</script>

    <script src="../../OtherUtils/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../OtherUtils/ckfinder/ckfinder.js"></script>

<form id="tForm" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;</td>
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
                            &nbsp; Send Email</td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:PlaceHolder ID="tblSendSMS" runat="server">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="20%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="15%">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            SMS Balance :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelSMSBalanceVal" runat="server" CssClass="SearchLabelBold" 
                                Text=""/>
                            &nbsp;SMS Credits</td>
                        <td  align="left" class="tblFormText1">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            No. of Unique Emails :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelEmailcount" runat="server" CssClass="SearchLabelBold" 
                                Text=""/> &nbsp;SMS Credits
                            </td>
                        <td  align="left" class="tblFormText1">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Charge/Email :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelUnitPrice" runat="server" CssClass="SearchLabelBold" 
                                Text=""/>&nbsp;SMS Credits
                            </td>
                        <td  align="left" class="tblFormText1">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Total Charges :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelTotalCharges" runat="server" CssClass="SearchLabelBold" 
                                Text=""/> &nbsp;SMS Credits
                            </td>
                        <td  align="left" class="tblFormText1">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            <span class="font_12Msg_Error">*</span> Send Email To : </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="TextBoxMobileList" runat="server" CssClass="stdTextArea1" TextMode="MultiLine" Rows="4" Width="421px" Enabled="false" />
                            <br />
                            
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>                    
                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            <span class="font_12Msg_Error">*</span> Subject : </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="TextBoxSubject" runat="server" CssClass="font_12Msg_Error" Width="300px" MaxLength="200"></asp:TextBox>
                            <br />
                            
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>     
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" > <span class="font_12Msg_Error">*</span> Message :</td>
                        <td class="tblFormText1" align="left">
                            <%--<cc1:Editor ID="Editor1" Width="450px" Height="200px" runat="server"/>--%>
                            <textarea id="myEditor" cols="20" name="myEditor" rows="2" runat="server"></textarea>
                    <br />
                </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" > <span class="font_12Msg_Error">*</span> Upload Attachment :</td>
                        <td class="tblFormText1" align="left">
                            <asp:FileUpload ID="FU_Photo1" runat="server" TabIndex="32" ToolTip="Click Browse to button to select an image from your computer." />
                                &nbsp;
                       
                    <br />
                </td>
                        <td class="tblFormText1" align="left">
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
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="BtSendSMS" runat="server" CssClass="stdbuttonCRUD" Text="Send Email" onclick="btnSave_Click" />
                               
                                </td>
                        <td class="tblFormText1" align="left">
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
                    </tr>
                </table>
                </asp:PlaceHolder>
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

    <script type="text/javascript" language="javascript">
        //    var editor = CKEDITOR.replace('myEditor');
        //    CKFinder.setupCKEditor(editor, 'OtherUtils/ckfinder/');
        //    CKFinder.config.disableHelpButton = true;



     
       
        var vEditor = document.getElementById('<%=tForm.FindControl("myEditor").ClientID%>');
        //var vEditor = document.getElementById("myEditor").getAttribute("placeholder");
        CKEDITOR.replace(vEditor,
                 {
                     filebrowserBrowseUrl: '../../OtherUtils/ckfinder/ckfinder.html',
                     filebrowserImageBrowseUrl: '../../OtherUtils/ckfinder/ckfinder.html?type=Images',
                     filebrowserFlashBrowseUrl: '../../OtherUtils/ckfinder/ckfinder.html?type=Flash',
                     filebrowserUploadUrl: '../../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                     filebrowserImageUploadUrl: '../../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                     filebrowserFlashUploadUrl: '../../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash',
                     filebrowserWindowWidth: '800',
                     filebrowserWindowHeight: '600'
                 }
             );

    


</script> 

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

