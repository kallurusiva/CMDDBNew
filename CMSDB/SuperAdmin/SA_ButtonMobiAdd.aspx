<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_ButtonMobiAdd.aspx.cs" Inherits="SA_ButtonMobiAdd" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>


<%@ Register src="SA_SideMenu_MobiWebButtons.ascx" tagname="SA_SideMenu_MobiWebButtons" tagprefix="uc1" %>


<%@ Register src="SA_SideMenu_WebButtons.ascx" tagname="SA_SideMenu_WebButtons" tagprefix="uc2" %>


<%@ Register src="SA_SideMenu_MobiButtons.ascx" tagname="SA_SideMenu_MobiButtons" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:SA_SideMenu_MobiButtons ID="SA_SideMenu_MobiButtons1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script type="text/javascript">
{
    // Special FCK Editor disable & control script.
   // var editorInstance = FCKeditorAPI.GetInstance('FCKeditor1');
    
    function FCKeditor_OnComplete(editorInstance) {
        // editorInstance.BasePath = "/UserControls/fckeditor/"; - Note the path is now supplied in the HTML. - alert(editorInstance.Name);
        if ((editorInstance.Name == "ReferralForm_ReferralFormReferral_ViewReferral_FCKEditorManagerNotesItem") || (editorInstance.Name == "ReferralForm_ReferralFormReferral_ViewReferral_FCKEditorNotesItem"))
        {
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

    <script src="../OtherUtils/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript" src="../OtherUtils/ckfinder/ckfinder.js"></script>

    <form id="form2" runat="server">

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
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="LtrAddNewButtonPage" runat="server" 
                                Text=""></asp:Literal></td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
           <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="98%" runat="server">
            <tr>
            <td>&nbsp;</td>
            </tr> 
            <tr><td>
                <asp:FormView ID="FvOwnPage" runat="server"
                 GridLines="Vertical" Width="100%" onmodechanging="FvOwnPage_ModeChanging" 
                    ondatabound="FvOwnPage_DataBound" oniteminserting="FvOwnPage_ItemInserting" onitemupdating="FvOwnPage_ItemUpdating" 
                >
               <ItemTemplate>
            
                <table cellpadding="0" cellspacing="3" id="tblPlan" width="98%" runat="server">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <div id="dvButtonNo" class="LogoBoxheadBlue">
                            &nbsp;<br /> &nbsp;&nbsp; &nbsp;
                            <asp:Label ID="lblButtonNoHeader" runat="server" CssClass="FontSubHeader"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                  
                            
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="BtnUpdate" runat="server" CommandName="Edit" 
                                CssClass="stdbuttonCRUD" Text=" EDIT " />
                             
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBackToListing" runat="server" CssClass="stdbuttonCRUD" 
                                onclick="btnBackToListing_Click" Text="Back to Listing" />
                             
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <table class="style1" id="tblButtonInfo">
                                <tr>
                                    <td width="25%" class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        For AnchorDomain :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:Label ID="lblAnchorDomain" runat="server" CssClass="SearchLabelBold" 
                                            Text='<%# Bind("AnchorDomain") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        &nbsp;</td>
                                    <td class="tblFormText1" width="75%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Button No :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:Label ID="lblButtonNo" runat="server" CssClass="SearchLabelBold" 
                                            Text='<%# Bind("ButtonNo") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Button Name :</td>
                                    <td class="tblFormText1">
                                        <asp:Label ID="lblButtonName" runat="server" CssClass="SearchLabelBold" 
                                            Text='<%# Bind("ButtonName") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblEnterPageContent" runat="server" Text="The following content to appear at website : "></asp:Label>
                            
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left" valign="top">
     <%--                   <FCKeditorV2:FCKeditor ID="FCKeditor1"  runat="server"  Value='<%# Bind("userPagecontent") %>'>
                        </FCKeditorV2:FCKeditor>--%>
                        <textarea id="myEditor" cols="0" name="myEditor" rows="0" visible="false" runat="server"></textarea>  
                       <table cellpadding="0" cellspacing="1" class="stdtableBorder_Only" width="100%" style="min-height: 400px;">
                    <tr>
                        <td  align="left" valign="top">
                         <asp:Label ID="lblUserContent" runat="server" Text='<%# Bind("userPagecontent") %>'></asp:Label>
                         
                        </td>
                    </tr>
                </table>
                        
             <%--           <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="RTFMandatoryValidate"
                            ErrorMessage="Pls Enter Some Description"></asp:CustomValidator>--%>

                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                         &nbsp; 
                        </td>
                        <td>
                            &nbsp;
                            
                            </td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
            
                </ItemTemplate>
                
                <EditItemTemplate>
                
                <table cellpadding="0" cellspacing="3" id="tblPlan" width="98%" runat="server">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                     
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <div id="dvButtonNo" class="LogoBoxheadBlue">
                            <br />&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblButtonNo" CssClass="FontSubHeader" runat="server"></asp:Label>
                            </div>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                         <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                        &nbsp;&nbsp;
                        <asp:Button ID="BtnUpdate" CssClass="stdbuttonCRUD" CommandName="UPDATE" ToolTip="Edit My content" runat="server" Text="Update" />&nbsp; &nbsp;
                        <asp:Button ID="BtnCancel" CssClass="stdbuttonCRUD" CommandName="Cancel" runat="server" Text="Cancel" />
                      
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <table class="style1" id="tblButtonInfo">
                                <tr>
                                    <td width="25%" class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        &nbsp;&nbsp;For AnchorDomain :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:Label ID="lblEditAnchorDomain" runat="server" CssClass="SearchLabelBold" 
                                            Text='<%# Bind("AnchorDomain") %>'></asp:Label>
                                        <asp:HiddenField ID="HdEditAnchorDomainID" Value='<%# Bind("AnchorDomainID") %>' runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        &nbsp;</td>
                                    <td class="tblFormText1" width="75%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        &nbsp;&nbsp;Button No :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:Label ID="lblEditButtonNo" runat="server" CssClass="SearchLabelBold" 
                                            Text='<%# Bind("ButtonNo") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;&nbsp;Button Name :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtButtonName" runat="server" MaxLength="20" 
                                            Text='<%# Bind("ButtonName") %>' CssClass="stdTextField1"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtButtonName" Display="Dynamic" 
                                            ErrorMessage="- Button cannot be Empty"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                  &nbsp;</td>
                                </tr>
                            </table></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblEnterPageContent" runat="server" 
                                Text="Edit the content to appear at website : "></asp:Label>
                            
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left" valign="top">
                <%--        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Value='<%# Bind("userPagecontent") %>'>
                        </FCKeditorV2:FCKeditor>--%>
                        <textarea id="myEditor" cols="20" name="myEditor" rows="2" runat="server" Value='<%# Bind("userPagecontent") %>'></textarea>  
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                        &nbsp;
                               
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
                
                </EditItemTemplate>
                
                <InsertItemTemplate>
                
                <table cellpadding="0" cellspacing="3" id="tblPlan" width="98%" runat="server">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            </td>
                        <td align="left" class="style2">
                              <div id="dvButtonNo" class="LogoBoxheadBlue">
                              <br />&nbsp;&nbsp; &nbsp;
                             <asp:Label ID="lblButtonNo" runat="server" CssClass="FontSubHeader"></asp:Label>
                             </div>
                             &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        <td class="style2">
                            </td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="BtnSave" runat="server" CommandName="Insert" 
                                CssClass="stdbuttonCRUD" Text="SAVE" ValidationGroup="VgCheck"/>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <table class="style1" id="tblButtonInfo">
                                <tr>
                                    <td width="25%" class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        For AnchorDomain :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="stdDropDown" 
                                            Width="209px" AutoPostBack="True" 
                                            onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
                                            ValidationGroup="VgCheck">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="ddlCategory" Display="Dynamic" 
                                            ErrorMessage="Please select category" InitialValue="0" 
                                            ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        &nbsp;</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:Label ID="lblOverMessage" runat="server" CssClass="font_11Msg_Error"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Button No :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:RadioButton ID="rdoButton1" runat="server" GroupName="GrpButtonNo" 
                                            Text="Button 1" />
                                        &nbsp;
                                        <asp:RadioButton ID="rdoButton2" runat="server" GroupName="GrpButtonNo" 
                                            Text="Button 2" />
                                        &nbsp;
                                        <asp:RadioButton ID="rdoButton3" runat="server" GroupName="GrpButtonNo" 
                                            Text="Button 3" />
                                        &nbsp;&nbsp;
                                        <asp:CustomValidator ID="CustomValidator1" runat="server"
                                            ErrorMessage="Select any of the Button No." OnServerValidate="CustomVdr_Button_ServerValidate" ValidationGroup="VgCheck"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Button Name :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtButtonName" runat="server" MaxLength="20" 
                                            Text='<%# Bind("ButtonName") %>' CssClass="stdTextField1" 
                                            ValidationGroup="VgCheck"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="txtButtonName" Display="Dynamic" 
                                            ErrorMessage="- Button cannot be Empty" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                  &nbsp;</td>
                                </tr>
                            </table></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblEnterPageContent" runat="server" Text="Enter the content to appear at website : "></asp:Label>
                            
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left" valign="top">
             <%--           <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server"  Value='<%# Bind("userPagecontent") %>'>
                        </FCKeditorV2:FCKeditor>--%>
                         <textarea id="myEditor" cols="20" name="myEditor" rows="2" runat="server"></textarea>  
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                     &nbsp; 
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
                
                </InsertItemTemplate>
                
             </asp:FormView>
             </td></tr>
             </table>
             
             
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

    </form>


<script type="text/javascript" language="javascript">
    //    var editor = CKEDITOR.replace('myEditor');
    //    CKFinder.setupCKEditor(editor, 'OtherUtils/ckfinder/');
    //    CKFinder.config.disableHelpButton = true;



    var FormViewMode = '<%=FvOwnPage.CurrentMode.ToString() %>';
    //alert(FormViewMode);

    if (FormViewMode == 'ReadOnly') {
        //alert('yes read only');
    }
    else {
        var vEditor = document.getElementById('<%=FvOwnPage.FindControl("myEditor").ClientID%>');
        CKEDITOR.replace(vEditor,
                 {
                     filebrowserBrowseUrl: '../OtherUtils/ckfinder/ckfinder.html',
                     filebrowserImageBrowseUrl: '../OtherUtils/ckfinder/ckfinder.html?type=Images',
                     filebrowserFlashBrowseUrl: '../OtherUtils/ckfinder/ckfinder.html?type=Flash',
                     filebrowserUploadUrl: '../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                     filebrowserImageUploadUrl: '../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                     filebrowserFlashUploadUrl: '../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash',
                     filebrowserWindowWidth: '800',
                     filebrowserWindowHeight: '600'
                 }
             );

    }
 

</script> 
</asp:Content>

