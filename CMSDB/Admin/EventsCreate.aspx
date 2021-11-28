<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EventsCreate.aspx.cs" Inherits="Admin_EventsCreate" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>



<%@ Register src="../SuperAdmin/SelectLanguage4Create.ascx" tagname="SelectLanguage4Create" tagprefix="uc2" %>



<%@ Register src="LeftMenu_Events.ascx" tagname="LeftMenu_Events" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:LeftMenu_Events ID="LeftMenu_Events1" runat="server" />
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
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                  <tr>
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; <asp:Literal ID="Literal1" runat="server" 
                                Text="<%$ Resources:LangResources, Add %>"></asp:Literal>&nbsp;
                         <asp:Literal ID="Literal2" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
                          </td>
                       
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
                    <%--<tr>
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
                            <asp:TextBox ID="txtEvtDate2" CssClass="stdTextField2" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtEvtDate2_CalendarExtender" CssClass="CalCss" runat="server" 
                                Enabled="True" PopupButtonID="ImgPopCal" TargetControlID="txtEvtDate2">
                            </asp:CalendarExtender>
                            <asp:Image ID="ImgPopCal" runat="server" BorderStyle="None" 
                                ImageUrl="~/Images/cal.gif" />
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtEvtFROMdate" runat="server" Display="Dynamic" ValidationGroup="vgEventCheck" ErrorMessage="<br/>Please enter FROM date"></asp:RequiredFieldValidator>                          
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtEvtTOdate" runat="server" Display="Dynamic" ValidationGroup="vgEventCheck" ErrorMessage="<br/>Please enter TO date"></asp:RequiredFieldValidator>                  
                              
                            </td>
                        <td>
                           &nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td align="left">
                    </td>       
                    <td>&nbsp;</td>       
                    </tr>
                    
                    <tr>
                        <td> 
                            &nbsp;
                             </td>
                        <td >
                               <asp:Literal ID="ltrEvents0" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
                                
&nbsp;<asp:Literal ID="ltrTitle0" runat="server" Text="<%$ Resources:LangResources, Title %>"></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEvtTitle" ValidationGroup="vgEventCheck" CssClass="stdTextField2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="<br/>Please enter Event title" ControlToValidate="txtEvtTitle" 
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="vgEventCheck"></asp:RequiredFieldValidator>
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
                            <asp:TextBox ID="txtEvtContent" ValidationGroup="vgEventCheck" CssClass="stdTextArea2" runat="server" 
                                Rows="3" TextMode="MultiLine"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ErrorMessage="<br/>Please enter Event Content" ControlToValidate="txtEvtTitle" 
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="vgEventCheck"></asp:RequiredFieldValidator>
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
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="vgEventCheck" CssClass="stdbuttonCRUD"  
                                Text="<%$ Resources:LangResources, Save %>" onclick="btnSave_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:LangResources, Cancel %>"   CssClass="stdbuttonCRUD"  
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

