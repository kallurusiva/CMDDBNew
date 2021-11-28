<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="NewsCreate.aspx.cs" Inherits="Admin_NewsCreate" %>

<%--<%@ Register src="SideMenu_News.ascx" tagname="SideMenu_News" tagprefix="uc1" %>--%>

<%@ Register src="../SuperAdmin/SelectLanguage4Create.ascx" tagname="SelectLanguage4Create" tagprefix="uc2" %>
<%@ Register Src="~/Admin/LeftMenu_News.ascx" TagPrefix="uc1" TagName="LeftMenu_News" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 19px;
        }
        .style3
        {
            width: 39px;
        }
        .style4
        {
            height: 19px;
            width: 39px;
        }
        .style5
        {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <%--<uc1:SideMenu_News ID="SideMenu_News1" runat="server" />--%>
    <uc1:LeftMenu_News runat="server" ID="LeftMenu_News" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <%--  <tr>
            <td>
                &nbsp;</td>
        </tr>--%>
       
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
                            &nbsp; Add News</td>
                      
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
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
                    <tr  id="trSelLanguage"  runat="server">
                        <td>
                            &nbsp;</td>
                        <td >
                               <asp:Literal ID="ltrLanguage" runat="server"></asp:Literal>
                        </td>
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
                        <td class="style2">
                            <asp:Literal ID="ltrNews1" runat="server" 
                                Text="<%$ Resources:LangResources, News %>"></asp:Literal>
&nbsp;<asp:Literal ID="ltrTitle0" runat="server" Text="<%$ Resources:LangResources, Title %>"></asp:Literal>
                        </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtNewsTitle" CssClass="stdTextField2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNewsTitle" Display="Dynamic"  ValidationGroup="VgCheck" SetFocusOnError="true" runat="server" ErrorMessage="Please enter News title"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            <asp:Literal ID="ltrNews2" runat="server" 
                                Text="<%$ Resources:LangResources, News %>"></asp:Literal>
&nbsp;<asp:Literal ID="ltrContent0" runat="server" Text="<%$ Resources:LangResources, Content %>"></asp:Literal>
                        </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtNewsContent" CssClass="stdTextArea2" runat="server" 
                                Rows="3" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNewsContent" Display="Dynamic" ValidationGroup="VgCheck" SetFocusOnError="true" runat="server" ErrorMessage="Please enter News content"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            </td>
                        <td class="style2">
                            </td>
                        <td class="style4">
                            </td>
                        <td align="left" class="style2">
                            </td>
                        <td class="style2">
                            </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style2">
                            <asp:Literal ID="LtrDispWebsite" Text="Display at Website" runat="server"></asp:Literal>
                            </td>
                        <td class="style4">
                            &nbsp;</td>
                        <td align="left" class="style2">
                            <asp:CheckBox ID="chkDisplaAtWeb" runat="server" Checked="True" 
                                ToolTip="To Show the entered news at the Website.  Tick the Checkbox." />
                        </td>
                        <td class="style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td align="left" class="style2">
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="btnSave" runat="server" CssClass="stdbuttonCRUD" 
                                Text="<%$ Resources:LangResources, Save %>"  ValidationGroup="VgCheck" onclick="btnSave_Click" />
&nbsp;<asp:Button ID="btnCancel"  CssClass="stdbuttonCRUD"  runat="server" Text="<%$ Resources:LangResources, Cancel %>" 
                                onclick="btnCancel_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            </td>
                        <td class="style4">
                            </td>
                        <td class="style3">
                            </td>
                        <td align="left" class="style3">
                            </td>
                        <td class="style3">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
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
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</asp:Content>

