<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_NewReleaseADD.aspx.cs" Inherits="EBAd_NewReleaseADD" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_BestSeller.ascx" tagname="EBLeftMenu_BestSeller" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="EBLeftMenu_ebButtons.ascx" tagname="EBLeftMenu_ebButtons" tagprefix="uc3" %> 

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
        </style>


    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

        <uc3:EBLeftMenu_ebButtons ID="EBLeftMenu_ebButtons1" runat="server" />

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
                            &nbsp; Add New Release </td>
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
                            Product Code: <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                             <div ID="divwidth1" class="divAutoComplete"></div>
                            <asp:TextBox ID="txtBookID"  ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" TabIndex="2"></asp:TextBox>
                             <asp:AutoCompleteExtender ID="txtBookID_AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" ServiceMethod="GetBookIDs"  TargetControlID="txtBookID" FirstRowSelected="true" CompletionListElementID="divwidth1" CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem" MinimumPrefixLength="2" EnableCaching="true" CompletionSetCount="20" CompletionInterval="500" UseContextKey="True">
                             </asp:AutoCompleteExtender>
                            <asp:HiddenField ID="hdBookUID" Value="" runat="server" />
                            <br />

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBookID" ErrorMessage=" Please enter Product Code" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

                            </td>
                        <td class="auto-style6" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr class="auto-style7">
                        <td>
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Display Position at Website :</td>
                        <td class="tblFormText1" align="left">
                            
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="stdTextField1" Width="112px" Text="1"></asp:TextBox>

                            <asp:RequiredFieldValidator runat="server" Display="dynamic" ID="RequiredFieldValidator1" SetFocusOnError="true" ControlToValidate="txtPosition" ErrorMessage="Invalid Position value"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtPosition" ErrorMessage="Allows Numeric Only" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
 

                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <tr class="auto-style7">
                        <td>
                            &nbsp;</td>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            
                            Note:&nbsp; Position represents the order sorted and display at website accordingly.<br />
&nbsp;&nbsp;&nbsp;&nbsp; eg: Position 1 - means appear at the top.</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="BtnPreview" runat="server" CssClass="stdbuttonAction" OnClick="BtnPreview_Click" Text="Preview Product Details" />

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
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">

                             <div id="dvBookPreview"  runat="server" visible="false">

                                    <table border="0" cellpadding="0" cellspacing="0" width="700px;" style="border: solid 1px #808080; padding: 5px; background-color: #FFFFFF;">
                                          <tr>
                                              <td width="200px" rowspan="6" align="center" valign="top">
                                                  <%-- Book Image here --%>

                                                   <div id="dvEbImage" class="ebookShowBox ebImageBox"  runat="server">
                                                    <asp:Image ID="ImgEbook" CssClass="ebImgCss" ImageUrl="" runat="server" />

                                                   </div>

                                              </td>
                                              <td width="100px" class="RowFormLabel">Product Code:</td>
                                              <td width="150px" class="RowFormText"> <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">ProductName:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Category:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Date Added:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblDateAdded" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Orginal Price:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblOrgPrice" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                            <tr>
                                              <td class="RowFormLabel">After Discount:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblAfterDiscount" runat="server" Text=""></asp:Label></td>
                                          </tr>
                                      </table>


                            </div>
                            <div id="dvBookNotFound" runat="server" class="dvBookNotFoundCss" visible="false">

                            </div>



                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr id="trHomePageShow" runat="server" visible="false">
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Display on Home Page :</td>
                        <td class="tblFormText1" align="left">
                            <asp:RadioButtonList ID="rdoDisplayOnHomePage" runat="server" CellPadding="1" CellSpacing="5" RepeatDirection="Horizontal" TabIndex="26">
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
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" Visible="false" 
                                Text="Save" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD"  Visible="false" 
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

