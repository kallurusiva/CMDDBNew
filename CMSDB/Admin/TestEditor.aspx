<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="TestEditor.aspx.cs" Inherits="Admin_TestEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <script src="../OtherUtils/ckeditor/ckeditor.js" type="text/javascript"></script>
<body>
    <form id="frmTest" runat="server">
    <div>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
                                        
                               <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                   <tr height="0px">
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td width="2%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>                                      
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           <textarea id="myEditor" cols="20" name="myEditor" rows="20" style="width:600px; height:300px;"  runat="server"></textarea></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                </table>
                                <%--</ContentTemplate>
                              </asp:UpdatePanel>--%>
                                
                                
    </div>
    </form>
    
     <script type="text/javascript">
         var vEditor = document.getElementById('<%=frmTest.FindControl("myEditor").ClientID%>');
      //CKEDITOR.replace('myEditor');

//      CKEDITOR.replace(vEditor);
//      CKFinder.setupCKEditor(vEditor, '../OtherUtils/ckfinder/');

      CKEDITOR.replace(vEditor,
                 {
                     filebrowserBrowseUrl: '../OtherUtils/ckfinder/ckfinder.html',
                     filebrowserImageBrowseUrl: '../OtherUtils/ckfinder/ckfinder.html?type=Images',
                     filebrowserFlashBrowseUrl: '../OtherUtils/ckfinder/ckfinder.html?type=Flash',
                     filebrowserUploadUrl: '../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                     filebrowserImageUploadUrl: '../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                     filebrowserFlashUploadUrl: '../OtherUtils/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash',
                     filebrowserWindowWidth: '200',
                     filebrowserWindowHeight: '600'
                 }
             );
      
</script>

</body>


</asp:Content>

