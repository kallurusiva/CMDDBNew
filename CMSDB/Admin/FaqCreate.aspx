<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="FaqCreate.aspx.cs" Inherits="Admin_FaqCreate" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../SuperAdmin/SelectLanguage4Create.ascx" tagname="SelectLanguage4Create" tagprefix="uc2" %>

<%@ Register src="LeftMenu_Faq.ascx" tagname="LeftMenu_Faq" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    
       
    <uc1:LeftMenu_Faq ID="LeftMenu_Faq1" runat="server" />
    
       
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <form id="faqForm" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
       <%-- <tr>
            <td>
                &nbsp;
                </td>
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
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                  <tr>
                       
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; <asp:Literal ID="Literal1" runat="server" 
                                Text="<%$ Resources:LangResources, Add %>"></asp:Literal>&nbsp;
                            FAQ</td>
                        
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
                    <tr id="trSelLanguage"  runat="server">
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
                        <td >
                               <asp:Literal ID="ltrEvents0" runat="server" 
                                Text="<%$ Resources:LangResources, Faq %>"></asp:Literal>
                                
&nbsp;<asp:Literal ID="ltrTitle0" runat="server" Text="<%$ Resources:LangResources, Question %>"></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtFaqQuestion" CssClass="stdTextField2" runat="server" 
                                ToolTip="Enter a FAQ Question"  ValidationGroup="vgFaqCheck"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtFaqQuestion" Display="Dynamic" ErrorMessage="Enter a FAQ Question" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="ltrEvent1" runat="server" 
                                Text="<%$ Resources:LangResources, Faq %>"></asp:Literal>
&nbsp;<asp:Literal ID="ltrContent0" runat="server" Text="<%$ Resources:LangResources, answer %>"></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtFaqAnswer" CssClass="stdTextArea2" runat="server" Width="399" 
                                Rows="3" TextMode="MultiLine" ToolTip="Enter an Anwer for FAQ question" ValidationGroup="vgFaqCheck"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtFaqAnswer" Display="Dynamic" ErrorMessage="Enter an FAQ answer" 
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
                        <td>
                            <asp:Literal ID="LtrDispWebsite" Text="Display at Website" runat="server"></asp:Literal>
                            </td>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:CheckBox ID="chkDisplaAtWeb" runat="server" Checked="True" 
                                ToolTip="To Show the entered Event at the Website.  Tick the Checkbox." />
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
                            <asp:Button ID="btnSave" runat="server" CssClass="stdbuttonCRUD" 
                                Text="Save" onclick="btnSave_Click" /> &nbsp; 
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD" 
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

