<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_NewsCreate.aspx.cs" Inherits="SuperAdmin_SA_NewsCreate" %>


<%@ Register src="SA_SideMenu_News.ascx" tagname="SA_SideMenu_News" tagprefix="uc1" %>


<%@ Register src="SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc2" %>


<%@ Register src="SelectLanguage4Create.ascx" tagname="SelectLanguage4Create" tagprefix="uc3" %>


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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
   
    <uc1:SA_SideMenu_News ID="SA_SideMenu_News1" runat="server" />
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;</td>
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
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; Add News</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="98%">
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
                        <td class="style2">
                            Language
                        </td>
                        <td class="style3">
                            &nbsp;</td>
                        <td style="text-align: left">
                            <uc3:SelectLanguage4Create ID="ucSelectLanguage4Create" runat="server" />
                        </td>
                        <td>
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
                            <asp:Button ID="btnSave" runat="server" 
                                Text="<%$ Resources:LangResources, Save %>" onclick="btnSave_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>" 
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

