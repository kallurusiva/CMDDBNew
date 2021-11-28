<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_EventsCreate.aspx.cs" Inherits="SuperAdmin_SA_EventsCreate" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="SA_SideMenu_Events.ascx" tagname="SA_SideMenu_Events" tagprefix="uc1" %>

<%@ Register src="SelectLanguage4Create.ascx" tagname="SelectLanguage4Create" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

    <uc1:SA_SideMenu_Events ID="SA_SideMenu_Events1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script src="../OtherUtils/datetimepicker_css.js" type="text/javascript"></script>
    
    <script language="javascript" type="text/javascript">

    function ShowCal(CtrlName) {
        
      CalWindow = window.open('../PopCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, "PopUpCalendar", "width=270,height=280,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
  }

  function CheckWindow() {
      ChildWindow.close();
       }

</script>
        
    <form id="EventForm" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>&nbsp;
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
                                Text="<%$ Resources:LangResources, Add %>"></asp:Literal>&nbsp;
                         <asp:Literal ID="Literal2" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
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
                              <asp:Literal ID="Literal3" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
                                &nbsp;
                                 <asp:Literal ID="Literal4" runat="server" 
                                Text="<%$ Resources:LangResources, Date %>"></asp:Literal> </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                              From&nbsp;&nbsp;
                            <asp:TextBox ID="txtEvtFROMdate" CssClass="stdTextField" ValidationGroup="VgCheck" runat="server"></asp:TextBox>
                            &nbsp;
                             <img alt="Select Date" id="Img2" src="../Images/cal.gif"   
                                onclick="javascript:NewCssCal('<%=txtEvtFROMdate.ClientID%>','ddmmyyyy','ARROW',true);" align="middle" />
                                &nbsp;&nbsp;&nbsp; To :&nbsp;
                            <asp:TextBox ID="txtEvtTOdate" runat="server" ValidationGroup="VgCheck"  CssClass="stdTextField"></asp:TextBox>
                                &nbsp;&nbsp;
                            <img alt="Select Date" id="Img1" src="../Images/cal.gif"   
                                onclick="javascript:NewCssCal('<%=txtEvtTOdate.ClientID%>','ddmmyyyy','ARROW',true);" align="middle" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEvtFROMdate" runat="server" Display="Dynamic" ValidationGroup="VgCheck" ErrorMessage="<br/>Please enter FROM date"></asp:RequiredFieldValidator>                          
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEvtTOdate" runat="server" Display="Dynamic" ValidationGroup="VgCheck" ErrorMessage="<br/>Please enter TO date"></asp:RequiredFieldValidator>                  
                               <%-- <mark:DateTimePicker ID="Picker4" runat="server" ShowClearButton="true" UseImageButtons="true" ShowTimePicker="true" Width="100px" CancelButtonCssClass="stdButtonNormal" DateCellCssClass="font_12Msg_Success" />--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               <asp:Literal ID="ltrEvents0" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
                                
&nbsp;<asp:Literal ID="ltrTitle0" runat="server" Text="<%$ Resources:LangResources, Title %>"></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEvtTitle" CssClass="stdTextField2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEvtTitle" Display="Dynamic" ValidationGroup="VgCheck" ErrorMessage="Please enter Event Title"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Literal ID="ltrEvent1" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
&nbsp;<asp:Literal ID="ltrContent0" runat="server" Text="<%$ Resources:LangResources, Content %>"></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEvtContent" CssClass="stdTextArea2" runat="server" 
                                Rows="3" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEvtContent" Display="Dynamic" ValidationGroup="VgCheck" ErrorMessage="Please enter Event content"></asp:RequiredFieldValidator>
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
                        <td>
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
                        <td>
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
                            <asp:Button ID="btnSave" runat="server" 
                                Text="<%$ Resources:LangResources, Save %>" onclick="btnSave_Click"   ValidationGroup="VgCheck"  />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>" 
                                onclick="btnCancel_Click" />
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

