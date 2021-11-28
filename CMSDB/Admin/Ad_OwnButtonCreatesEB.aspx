<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_OwnButtonCreatesEB.aspx.cs" Inherits="Admin_Ad_OwnButtonCreatesEB" %>
<%@ Register src="../SuperAdmin/SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc1" %>
<%@ Register src="../SuperAdmin/SelectLanguage4Create.ascx" tagname="SelectLanguage4Create" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

  

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
                     
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="LtrAddNewButtonPage" runat="server" 
                                Text=""></asp:Literal></td>
                        
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
           <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="100%" runat="server">
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
                            &nbsp;&nbsp; &nbsp;
                            <asp:Button ID="BtnUpdate" CssClass="stdbuttonCRUD" CommandName="Edit" runat="server" Text=" EDIT " />
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
                            <asp:Image ID="ImgActive" runat="server" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Literal ID="ltrDisplayatWebsite" runat="server"></asp:Literal>
                            <asp:HiddenField ID="hidActive" runat="server" Value='<%# Bind("Active") %>' />
                            
                            <%-- <asp:CheckBox ID="chkActive" Text="Display at Website" runat="server" />--%>
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
                            &nbsp; &nbsp;
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
                            &nbsp;
                            <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Bind("Active") %>' 
                                Text="" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Literal ID="ltrDisplayatWebsite" runat="server"></asp:Literal>
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
                            <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager2" runat="server" CombineScripts="false"></ajaxtoolkit:toolkitscriptmanager>
                        <%--<textarea id="myEditor" cols="20" name="myEditor" rows="2" runat="server" Value='<%# Bind("userPagecontent") %>'></textarea>--%>  
                            <cc1:Editor 
                                 Content='<%# Bind("userPagecontent") %>'
            ID="myEditor" 
            Width="700px"  
            Height="400px"
            runat="server"/>
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
                            <%--<uc2:SelectLanguage4Create ID="ucSelectLanguage4Create" runat="server" />--%>
                             &nbsp;&nbsp;&nbsp; &nbsp;
                             <asp:Button ID="BtnSave" CssClass="stdbuttonCRUD" CommandName="Insert" runat="server" Text="SAVE" />&nbsp; &nbsp;
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
                            &nbsp;
                            <asp:CheckBox ID="chkActive" runat="server" Text="" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Literal ID="ltrDisplayatWebsite" runat="server"></asp:Literal>
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
                         <%--<textarea id="myEditor" cols="20" name="myEditor" rows="2" runat="server"></textarea>--%>
                            <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager2" runat="server" CombineScripts="false"></ajaxtoolkit:toolkitscriptmanager>
                            <cc1:Editor 
            ID="myEditor" 
            Width="700px"  
            Height="400px"
            runat="server"/>
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



</asp:Content>

