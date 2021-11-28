<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_SendEbookbyEmail.aspx.cs" Inherits="Admin_EbAd_SendEbookbyEmail" %>
<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
        <uc1:EBLeftMenu_Books ID="EBLeftMenu_Books1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
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
                            &nbsp; Add new Feature Buy&nbsp; Ebook&nbsp; </td>
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
                        <td width="30%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                    
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
                            Book Name : <span class="font_12Msg_Error">*</span></td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtBookID" ValidationGroup="VgCheck" runat="server" CssClass="stdTextField1" TabIndex="2"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBookID" ErrorMessage=" Please enter Book ID" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>

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
                            <asp:Button ID="BtnPreview" runat="server" CssClass="stdbuttonAction" OnClick="BtnPreview_Click" Text="Preview Book Details"/>

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
                                              <td width="100px" class="RowFormLabel">Book ID:</td>
                                              <td width="150px" class="RowFormText"> <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Book Name:</td>
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
                                              <td class="RowFormText"> <asp:Label ID="lblNCurrencyPrice" runat="server" CssClass="fontCurrency" Text=""/>&nbsp;<asp:Label ID="lblOrgPrice" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                            <tr>
                                              <td class="RowFormLabel">After Discount:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblNDiscountPrice" runat="server" CssClass="fontCurrency" Text=""/>&nbsp;<asp:Label ID="lblAfterDiscount" runat="server" Text=""></asp:Label></td>
                                          </tr>
                                      </table>
                             </div>
                             <div id="dvValueBookPreview"  runat="server" visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="700px;" style="border: solid 1px #808080; padding: 5px; background-color: #FFFFFF;">
                                          <tr>
                                              <td width="350px" rowspan="6" align="center" valign="top">
                                                  <%-- Book Image here --%>
                                                    <div id="dvBook1" class="dvBookCss">
                                                        <asp:Label runat="server"  ID="BookName1" CssClass="FontNote"></asp:Label><br />
                                                        <asp:Image runat="server"  ID="ImageBook1" CssClass="ebookImgCss" ImageUrl="" style="border-wIDth:0px;" />
                                                    </div>                                                    <div id="dvBook2" class="dvBookCss">
                                                        <asp:Label runat="server"  ID="BookName2" CssClass="FontNote"></asp:Label><br />
                                                        <asp:Image runat="server"  ID="ImageBook2" CssClass="ebookImgCss" ImageUrl="" style="border-wIDth:0px;" />
                                                    </div>                                                    <div id="dvBook3" class="dvBookCss">
                                                        <asp:Label runat="server"  ID="BookName3" CssClass="FontNote"></asp:Label><br />
                                                        <asp:Image runat="server"  ID="ImageBook3" CssClass="ebookImgCss" ImageUrl="" style="border-wIDth:0px;" />
                                                    </div>                                                    <div id="dvBook4" class="dvBookCss">
                                                        <asp:Label runat="server"  ID="BookName4" CssClass="FontNote"></asp:Label><br />
                                                        <asp:Image runat="server"  ID="ImageBook4" CssClass="ebookImgCss" ImageUrl="" style="border-wIDth:0px;" />
                                                    </div>                                                    <div id="dvBook5" class="dvBookCss">
                                                        <asp:Label runat="server"  ID="BookName5" CssClass="FontNote"></asp:Label><br />
                                                        <asp:Image runat="server"  ID="ImageBook5" CssClass="ebookImgCss" ImageUrl="" style="border-wIDth:0px;" />
                                                    </div>
                                              </td>
                                              <td width="100px" class="RowFormLabel">Book ID:</td>
                                              <td width="150px" class="RowFormText"> <asp:Label ID="lblValueBookID" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Package Name:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblValueBookName" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Number of Books:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblValueBookCount" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Date Added:</td>
                                              <td class="RowFormText"> <asp:Label ID="lblValueDateAdded" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Orginal Price:</td>
                                              <td class="RowFormText"><asp:Label ID="lblCurrencyPrice" runat="server" CssClass="fontCurrency" Text=""/>&nbsp;<asp:Label ID="lblValueOrgPrice" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                            <tr>
                                              <td class="RowFormLabel">After Discount:</td>
                                              <td class="RowFormText"><asp:Label ID="lblCurrencyDiscount" runat="server" CssClass="fontCurrency" Text=""/>&nbsp;<asp:Label ID="lblValueAfterDiscount" runat="server" Text=""></asp:Label></td>
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
                            Signature :</td>
                        <td class="tblFormText1" align="left">
                                    <asp:DropDownList ID="ddlSignature" runat="server" CssClass="stdDropDown">
                                    <asp:ListItem Value="Best Regards">Best Regards</asp:ListItem>
                                    <asp:ListItem Value="Best Wishes">Best Wishes</asp:ListItem>
                                    <asp:ListItem Value="Cordially">Cordially</asp:ListItem>                                    
                                    <asp:ListItem Value="Sincerely Yours">Sincerely Yours</asp:ListItem>
                                    <asp:ListItem Value="Yours Truly">Yours Truly</asp:ListItem>
                                    <asp:ListItem Value="With Many Thanks">With Many Thanks</asp:ListItem>                                    
                                    </asp:DropDownList>
                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Your Name : </td>
                        <td class="tblFormText1" align="left">
                                                  <asp:TextBox ID="TextBoxYourName" runat="server" CssClass="stdTextField1" Width="180px" MaxLength="50"></asp:TextBox>
                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Remarks : </td>
                        <td class="tblFormText1" align="left">
                                                  <asp:TextBox ID="TextBoxRemarks" runat="server" TextMode="MultiLine" CssClass="stdTextArea1"></asp:TextBox>
                        </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="auto-style7" >
                            &nbsp;</td>
                        <td class="auto-style7" >
                            Email To : </td>
                        <td class="tblFormText1" align="left">
                                    <table border="0" cellpadding="0" cellspacing="0" width="700px;" style="border: solid 1px #808080; padding: 5px; background-color: #FFFFFF;">
                                         
                                           <tr>
                                              <td class="RowFormLabel">&nbsp;</td>
                                              <td class="RowFormText"> &nbsp;Name &nbsp;</td>
                                              <td class="RowFormText"> Email</td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Recipient 1<span class="font_12Msg_Error">*</span></td>
                                              <td class="RowFormText">
                                                  <asp:TextBox ID="TextBoxName1" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox><br />                                                  
                                                  <asp:RequiredFieldValidator ID="rfvName1" runat="server" ErrorMessage="Enter at least one recipient" ControlToValidate="TextBoxName1" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                               </td>
                                              <td class="RowFormText"> 
                                                  <asp:TextBox ID="TextBoxEmail1" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                                  <asp:RequiredFieldValidator ID="rfvEmail1" runat="server" ErrorMessage="Enter at least one email" ControlToValidate="TextBoxEmail1" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TextBoxEmail1" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                               </td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Recipient 2</td>
                                              <td class="RowFormText">  
                                                  <asp:TextBox ID="TextBoxName2" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox>
                                               </td>
                                              <td class="RowFormText">  
                                                  <asp:TextBox ID="TextBoxEmail2" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TextBoxEmail2" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                               </td>
                                          </tr>

                                           <tr>
                                              <td class="RowFormLabel">Recipient 3</td>
                                              <td class="RowFormText"> 
                                                  <asp:TextBox ID="TextBoxName3" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox>
                                               </td>
                                              <td class="RowFormText"> 
                                                  <asp:TextBox ID="TextBoxEmail3" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TextBoxEmail3" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                               </td>
                                          </tr>

                                            <tr>
                                              <td class="RowFormLabel">Recipient 4</td>
                                              <td class="RowFormText"> 
                                                  <asp:TextBox ID="TextBoxName4" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox>
                                                </td>
                                              <td class="RowFormText"> 
                                                  <asp:TextBox ID="TextBoxEmail4" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TextBoxEmail4" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                                </td>
                                          </tr>

                                            <tr>
                                              <td class="RowFormLabel">Recipient 5</td>
                                              <td class="RowFormText"> 
                                                  <asp:TextBox ID="TextBoxName5" runat="server" CssClass="stdTextField1" Width="120px" MaxLength="50"></asp:TextBox>
                                                </td>
                                              <td class="RowFormText"> 
                                                  <asp:TextBox ID="TextBoxEmail5" runat="server" CssClass="stdTextField1" Width="220px" MaxLength="150"></asp:TextBox><br />
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="TextBoxEmail5" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage="Enter a valid Email"></asp:RegularExpressionValidator>
                                                </td>
                                          </tr>
                                      </table>



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
                            <span class="FontNote">Note :&nbsp; SMS Balance credit deduction 0.5 credits per Email</span></td>
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
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" Visible="false" Text="Save" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD"  Visible="false" Text="Cancel" onclick="btnCancel_Click" />
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



