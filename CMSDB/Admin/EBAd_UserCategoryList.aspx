<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_UserCategoryList.aspx.cs" Inherits="EBAd_UserCategoryList" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    

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
        </style>


    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc3:EBLeftMenu_Dashboard ID="EBLeftMenu_Dashboard1" runat="server" />

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

    <form id="tForm" runat="server" enctype="multipart/form-data" method="post"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </td>
            <asp:Label ID="lblPgFrom" runat="server" Text=""></asp:Label>
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
                            &nbsp; Sub Category</td>
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
                        <td width="25%">
                            </td>
                        <td width="60%">
                            </td>
                        <td width="15%">
                            </td>
                        <td width="2%">
                            </td>
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
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Sub
                            Category Name :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                         <asp:TextBox ID="txtCategoryName" CssClass="stdTextField2" runat="server" ValidationGroup="vCheck"></asp:TextBox>
                        &nbsp;&nbsp;<br />
                            <asp:Image ID="ImageKeywordStatus" runat="server" ImageUrl="~/Images/imgUpdate.gif" Visible="false" />
                         &nbsp;<asp:Label ID="lblCatNameStatus" runat="server" CssClass="ValAlert_Error" Text="Label" Visible="false" />

                        </td>
                      <%--  <td class="auto-style6" align="left">
                            &nbsp;</td>--%>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCategoryName" runat="server" CssClass="ValAlert_Error" ErrorMessage="Category Name cannot be Empty." ValidationGroup="vCheck"></asp:RequiredFieldValidator>          
                          <%--  <asp:RegularExpressionValidator ID="regexCategoryName" runat="server" ControlToValidate="txtCategoryName" Display="None" ErrorMessage="&lt;b&gt;Invalid Format&lt;/b&gt;&lt;br/&gt;Category Name supports Alphanumeric only" ValidationExpression="[a-zA-Z0-9\-_\s]{1,36}" ValidationGroup="vCheck" />--%>

                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <%-- <tr>
                        <td class="tblFormLabel1" >
                            Display at WebSite :</td>
                        <td class="tblFormText1" align="left">
                            <asp:CheckBox ID="chkActive" Checked="true" runat="server" />

                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            Under Main Category :</td>
                        <td class="tblFormText1" align="left">
                            <asp:DropDownList ID="ddlMainCategory" runat="server" CssClass="stdDropDown2">
                            </asp:DropDownList>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="BtnSave" runat="server" ValidationGroup="vCheck" CssClass="stdbuttonCRUD" Text="Save my Category" OnClick="BtnSave_Click" />
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
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
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                         
                        <td colspan="3" align="center" >
                            <asp:GridView ID="GridCategory" runat="server" AllowPaging="false" ShowFooter="true"  
                                AllowSorting="true" AlternatingRowStyle-CssClass="rowalt" AutoGenerateColumns="False" 
                                CssClass="mGrid" DataKeyNames="CatID" HeaderStyle-CssClass="rowheader" 
                                onrowcancelingedit="GridCategory_RowCancelingEdit" 
                                onrowdatabound="GridCategory_RowDataBound" onrowdeleting="GridCategory_RowDeleting"
                                onrowediting="GridCategory_RowEditing" onrowupdating="GridCategory_RowUpdating" onsorting="GridCategory_Sorting"
                                PageSize="30" Width="800">
                                <Columns>
                            
                                    <asp:TemplateField HeaderText="Sl No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSlNo" runat="server" Text='<%# Bind("snodisp")  %>' />
                                            <%--<asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex + 1  %>" />--%>
                                            <asp:Literal ID="hdCatID" runat="server" Text='<%#Bind("CatID")%>' Visible="false"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Main Category" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCatMainName" runat="server" Text='<%# Bind("categoryname1")  %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sub Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("CategoryName")  %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("CategoryName")  %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryName" CssClass="ValAlert_Error" ErrorMessage="Category Name cannot be Empty."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="regexCategoryName" runat="server" ControlToValidate="txtCategoryName" Display="None" ErrorMessage="&lt;b&gt;Invalid Format&lt;/b&gt;&lt;br/&gt;Category Name supports Alphanumeric only" ValidationExpression="[a-zA-Z0-9]{1,15}" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Books Count">
                                        <ItemTemplate>
                                            <asp:Literal ID="LtrBooksCount" runat="server" Text='<%# Bind("BooksCount") %>'></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Display at Website">
                                        <ItemTemplate>
                                            <asp:Image ID="ImgActive" runat="server" />
                                            <asp:Literal ID="LtrActive" runat="server" Text='<%# Bind("isDisplay") %>' Visible="false"></asp:Literal>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Bind("isDisplay") %>' Enabled="true" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Functions">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="EDIT" ImageUrl="~/Images/imgEdit2.gif" ToolTip="Edit Anchor Domain" />
                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="DELETE" ImageUrl="~/Images/imgDelete.gif" OnClientClick="return confirm('Please click OK to confirm deletion');" ToolTip="Delete Anchor Domain" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImgUpdate" runat="server" CommandName="UPDATE" ImageUrl="~/Images/imgUpdate.gif" ToolTip="Update Anchor Domain" ValidationGroup="vgEdit" />
                                            <asp:ImageButton ID="ImgCancel" runat="server" CommandName="CANCEL" ImageUrl="~/Images/imgCancel.gif" ToolTip="Cancel" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                             
                                <HeaderStyle CssClass="rowheader" />
                                <AlternatingRowStyle CssClass="rowalt" />
                                <FooterStyle CssClass ="rowfooter" />
                            </asp:GridView>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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

