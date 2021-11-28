<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_ButtonMobileWeb.aspx.cs" Inherits="SuperAdmin_SA_AncDomainsCreate" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>


<%@ Register src="SA_SideMenu_MobiWebButtons.ascx" tagname="SA_SideMenu_MobiWebButtons" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SA_SideMenu_MobiWebButtons ID="SA_SideMenu_MobiWebButtons1" 
        runat="server" />
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
                            <asp:Label ID="lblButtonNo" runat="server" CssClass="FontSubHeader" Text=""></asp:Label>
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
                            <asp:Label ID="lblButtonName" runat="server" Text="Button Name to appear at website : "></asp:Label>
                            &nbsp;&nbsp;: &nbsp;&nbsp;
                            <asp:Label ID="lblButtonValue" CssClass="SearchLabelBold" runat="server" Text='<%# Bind("userLinkName") %>'></asp:Label>
                             
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtnUpdate" runat="server" CommandName="Edit" 
                                CssClass="stdbuttonCRUD" Text=" EDIT " />
                             
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
                            
                            &nbsp;&nbsp;&nbsp;&nbsp;
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
                            <asp:Label ID="lblButtonName" runat="server" 
                                Text="Edit Button Name to appear at website : "></asp:Label>
                            <asp:TextBox ID="txtButtonName" MaxLength="20" runat="server" Text ='<%# Bind("userLinkName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtButtonName" runat="server" Display="Dynamic" ErrorMessage="- Button cannot be Empty"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtButtonName" ValidationExpression="^[a-zA-Z0-9_ ]+$" Display="Dynamic" runat="server" ErrorMessage=" - Only [Aa-Zz] Alphabhets, [0-9] numerals , space and undercore are allowed"></asp:RegularExpressionValidator>--%>
                            
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
                            
                             
                             &nbsp; 
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
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="BtnSave" runat="server" CommandName="Insert" 
                                CssClass="stdbuttonCRUD" Text="SAVE" />
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
                            <asp:Label ID="lblButtonName" runat="server" Text="Enter new Button Name to appear at website : "></asp:Label>
                            <asp:TextBox ID="txtButtonName" MaxLength="20" runat="server" Text ='<%# Bind("userLinkName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtButtonName" runat="server" Display="Dynamic" ErrorMessage="- Button cannot be Empty"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtButtonName" ValidationExpression="^[a-zA-Z0-9_ ]+$" Display="Dynamic" runat="server" ErrorMessage=" - Only [Aa-Zz] Alphabhets, [0-9] numerals , space and undercore are allowed"></asp:RegularExpressionValidator>--%>
                            
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

