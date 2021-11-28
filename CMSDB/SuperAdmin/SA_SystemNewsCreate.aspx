<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_SystemNewsCreate.aspx.cs" Inherits="SuperAdmin_SA_SystemNewsCreate" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="SA_SideMenu_Faq.ascx" tagname="SA_SideMenu_Faq" tagprefix="uc1" %>

<%@ Register src="SelectLanguage4Create.ascx" tagname="SelectLanguage4Create" tagprefix="uc2" %>

<%@ Register src="SA_SideMenu_SystemNews.ascx" tagname="SA_SideMenu_SystemNews" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:SA_SideMenu_SystemNews ID="SA_SideMenu_SystemNews1" runat="server" />
      
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <form id="faqForm" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
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
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; <asp:Literal ID="ltrSystemNews" runat="server" Text="" ></asp:Literal>&nbsp;
                            </td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="96%">
                    <tr>
                        <td width="5%">
                            &nbsp;</td>
                        <td width="20%">
                            &nbsp;</td>
                        <td width="5%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="5%">
                            &nbsp;</td>
                    </tr>
                    <%--&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>" />--%>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               Language</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <uc2:SelectLanguage4Create ID="ucSelectLanguage4Create" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               <asp:Literal ID="ltrSysSubject" runat="server" 
                                Text=""></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtSysSubject" CssClass="stdTextField2" runat="server" 
                                ToolTip="Enter News Subject"  ValidationGroup="VgCheck"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="VgCheck" 
                                ControlToValidate="txtSysSubject" Display="Dynamic" ErrorMessage="Enter News Subject" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="ltrSysContent" runat="server" 
                                Text=""></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtSysContent" CssClass="stdTextArea2" runat="server" 
                                Rows="3" TextMode="MultiLine" ToolTip="Enter News Content" ValidationGroup="VgCheck"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ValidationGroup="VgCheck" 
                                ControlToValidate="txtSysContent" Display="Dynamic" ErrorMessage="Enter News Content" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="ltrDisplayAtWebsite" runat="server"></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;<asp:CheckBox ID="chkActive" Checked="true" runat="server" /></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btnSave" runat="server" CssClass="stdbuttonAction" ValidationGroup="VgCheck" 
                                Text="Save" onclick="btnSave_Click" /> &nbsp; 
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonAction" 
                                Text="Cancel" onclick="btnCancel_Click" />
                                <%--&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>" />--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td align="left" >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td align="left" >
                            <asp:Button ID="btnSaveSend" CssClass="stdbuttonAction" runat="server" 
                                Text="Save and Send Email " onclick="btnSaveSend_Click" />
&nbsp; TO :&nbsp;
                            <asp:CheckBox ID="chkWEB10" runat="server" Checked="True" Text="WEB 10 Users" />
&nbsp;
                            <asp:CheckBox ID="chkWEB30" Checked="True" runat="server" Text="WEB 30 Users" />
                            </td>
                        <td >
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                     &nbsp;
                        </td>
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

