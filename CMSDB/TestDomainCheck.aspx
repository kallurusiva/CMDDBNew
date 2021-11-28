<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestDomainCheck.aspx.cs" Inherits="TestDomainCheck" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmTest" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
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
                                        Enter Domain Name </td>
                                    <td>
                                        :</td>
                                    <td valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" width="50%">
                                    <tr>
                                    <td>
                                        <asp:TextBox ID="txtOwnDmChoice1" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                        <%--<asp:Button ID="btnDomainCheck1" CssClass="stdButtonNormal" runat="server" 
                                           ToolTip="Check if the Entered Domain Name is available ?"  
                                            Text="Check availabilty ?" OnClientClick="fnCheckDomain()"/>--%>
                                        
                                    </td>
                                    <td>
                                            &nbsp;
                                        <asp:DropDownList ID="ddlExtension" CssClass="stdDropDown" runat="server">
                                         <asp:ListItem Text=".com" Value=".com"></asp:ListItem>
                                         <asp:ListItem Text=".net" Value=".net"></asp:ListItem>
                                         <asp:ListItem Text=".biz" Value=".biz"></asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                        
                                        <td>
                                        &nbsp;
                                        <asp:Button ID="btnDomainCheckNow0" runat="server" ValidationGroup="VgCheck" 
                                            CssClass="stdButtonNormal" onclick="btnDomainCheckNow_Click" Text="Check availabilty" />
                                    </td>
                                    
                                    </tr>
                                    </table>
                                    
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtOwnDmChoice1" Display="Dynamic" 
                                            ErrorMessage="Domain Name cannot be empty" SetFocusOnError="True" 
                                            ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                     <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                         ControlToValidate="txtOwnDmChoice1" Display="Dynamic" ValidationGroup="VgCheck" 
                                         ErrorMessage="Domain Name is inValid. must contain .com or .net etc.," 
                                            ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>--%>
                                            
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtOwnDmChoice1"
                                             ValidationExpression="^[a-zA-Z0-9]+$" Display="Dynamic" runat="server" ValidationGroup="VgCheck"  
                                             ErrorMessage=" - Only [Aa-Zz] Alphabhets, [0-9] numerals"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                            
                                           <%--  <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="50" runat="server">
                                            <ProgressTemplate>
                                            <div id="progress" runat="server" visible="true">
                                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/>
                                                Please wait...while the system checks for domain name availability
                                             </div>
                                            </ProgressTemplate>
                                            
                                            </asp:UpdateProgress>--%>
                                            
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblDomainReq" runat="server" CssClass="font_11Msg_Error"></asp:Label>
                                        &nbsp;&nbsp;
                                        <%--<asp:Button ID="btnRegister" runat="server" CssClass="stdbuttonAction" 
                                            onclick="btnRegister_Click" Text="Register Domain" Visible="false" />--%>
                                    </td>
                                </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;<%--<asp:Label CssClass="font_11Msg_Error" ID="tmplabel" Text="label" runat="server"></asp:Label>--%></td>
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
</html>
