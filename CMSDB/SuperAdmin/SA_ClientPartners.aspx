<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_ClientPartners.aspx.cs" Inherits="SuperAdmin_SA_ClientPartners" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>


<%@ Register src="SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script src="../OtherUtils/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript" src="../OtherUtils/ckfinder/ckfinder.js"></script>
    

    <form id="form2" runat="server">

<asp:HiddenField ID="hidCpid" runat="server" />

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
                            <asp:Literal ID="ltrClientPartners" runat="server" 
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
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                        &nbsp;<uc3:SelectLanguage ID="ucSelectLanguage" runat="server" />
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
                        <td align="left" valign="top">
                        
                           <%--    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server">
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
                          <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                            <asp:Button ID="BtnSave" runat="server" onclick="BtnSave_Click" 
                                Text="SAVE" />
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
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


    CKEDITOR.replace('<%=myEditor.ClientID%>',
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
 

</script>       
</asp:Content>

