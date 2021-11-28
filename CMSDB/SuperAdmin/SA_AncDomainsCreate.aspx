<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_AncDomainsCreate.aspx.cs" Inherits="SuperAdmin_SA_AncDomainsCreate" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="SA_SideMenu_Faq.ascx" tagname="SA_SideMenu_Faq" tagprefix="uc1" %>

<%@ Register src="SelectLanguage4Create.ascx" tagname="SelectLanguage4Create" tagprefix="uc2" %>

<%@ Register src="SA_SideMenu_Domains.ascx" tagname="SA_SideMenu_Domains" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:SA_SideMenu_Domains ID="SA_SideMenu_Domains1" runat="server" />
      
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
                            &nbsp; <asp:Literal ID="Literal1" runat="server" 
                                Text="<%$ Resources:LangResources, Add %>"></asp:Literal>&nbsp; Anchor Domain</td>
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
                        <td  align="right">
                         <asp:Literal ID="ltrTitle0" runat="server" Text="Enter Anchor Domain"></asp:Literal>
                        &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtAnchorDomain" CssClass="stdTextField1" runat="server" 
                                ToolTip="Enter a FAQ Question"  ValidationGroup="VgCheck"></asp:TextBox>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="VgCheck" 
                                ControlToValidate="txtAnchorDomain" Display="Dynamic" ErrorMessage="Enter Anchor Domain." 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td  align="right">
                         <asp:Literal ID="Literal2" runat="server" Text="Enter Sample URL"></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtSampleURL" CssClass="stdTextField1" runat="server" 
                                ToolTip="Enter a FAQ Question"  ValidationGroup="VgCheck"></asp:TextBox>
                            &nbsp;
                            </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            </td>
                        <td  align="right" >
                         <asp:Literal ID="Literal3" runat="server" Text="Select Anchor Domain Category"></asp:Literal>
                        </td>
                        <td class="style2" >
                            </td>
                        <td style="text-align: left" class="style2">
                            <asp:DropDownList ID="ddlAncCategory" runat="server" CssClass="stdDropDown1">
                            </asp:DropDownList>
                            &nbsp;
                            </td>
                        <td class="style2">
                            </td>
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
                        <td  align="right">
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
                            </td>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td align="left" >
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

