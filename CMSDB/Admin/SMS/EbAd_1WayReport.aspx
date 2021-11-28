<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_1WayReport.aspx.cs" Inherits="Admin_SMS_EbAd_1WayReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SMSSystem ID="EBLeftMenu_SMSSystem1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>    
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">    
    <ContentTemplate>--%>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      
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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; EBooks 1 Way Report</td>
                        <td width="30%" align="right"> 
                            &nbsp;</td>
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
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left" style="padding-top:20px;padding-bottom:20px">
                            <table id="tblSearchSimple" align="center" cellpadding="0" cellspacing="2" class="stdtableBorder_Search">
                                <tr>
                                    <td style="width:10px;">&nbsp;</td>
                                    <td style="width:120px;" class="SearchLabelBold">Date From</td>
                                    <td style="width:1px;">
                                                                                :</td>
                                    <td class="SearchLabel" align="left">
                                     <asp:DropDownList ID="ddlDateFromDay" runat="server" CssClass="stdDropDown" OnSelectedIndexChanged="ddlDateFromDay_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvDayFrom"  runat="server" ErrorMessage="Enter Day" ControlToValidate="ddlDateFromDay" Display="Dynamic" SetFocusOnError="true"/>                      
                                    <asp:DropDownList ID="ddlDateFromMonth" runat="server" CssClass="stdDropDown" OnSelectedIndexChanged="ddlDateFromMonth_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>                             
                                    <asp:RequiredFieldValidator ID="rfvMonthFrom" runat="server" ErrorMessage="Enter Month" ControlToValidate="ddlDateFromMonth" Display="Dynamic" SetFocusOnError="true"/>  
                                    <asp:DropDownList ID="ddlDateFromYear" runat="server" CssClass="stdDropDown" OnSelectedIndexChanged="ddlDateFromYear_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvYearFrom" runat="server" ErrorMessage="Enter Year" ControlToValidate="ddlDateFromYear" Display="Dynamic" SetFocusOnError="true"/>        
                                   </td>
                                </tr>                                
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="SearchLabelBold">Date To</td>
                                    <td>:</td>
                                    <td class="SearchLabel" align="left">
                                     <asp:DropDownList ID="ddlDateToDay" runat="server" CssClass="stdDropDown" OnSelectedIndexChanged="ddlDateToDay_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvYearTo" runat="server" ErrorMessage="Enter Year" ControlToValidate="ddlDateToYear" Display="Dynamic" SetFocusOnError="true"/>  
                                    <asp:DropDownList ID="ddlDateToMonth" runat="server" CssClass="stdDropDown" OnSelectedIndexChanged="ddlDateToMonth_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>        
                                    <asp:RequiredFieldValidator ID="rfvMonthTo" runat="server" ErrorMessage="Enter Month" ControlToValidate="ddlDateToMonth" Display="Dynamic" SetFocusOnError="true"/>                             
                                    <asp:DropDownList ID="ddlDateToYear" runat="server" CssClass="stdDropDown" OnSelectedIndexChanged="ddlDateToYear_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList> 
                                    <asp:RequiredFieldValidator ID="rfvDayTo" runat="server" ErrorMessage="Enter Day" ControlToValidate="ddlDateToDay" Display="Dynamic" SetFocusOnError="true"/>
                                    <asp:CustomValidator ID="ctvDate" runat="server" ErrorMessage="CustomValidator" onservervalidate="ctvDate_ServerValidate" Display="Dynamic"/>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td style="width:10px;">
                                        &nbsp;</td>
                                    <td class="SearchLabelBold">
                                        Search Report By</td>
                                    <td>:</td>
                                    <td align="left" class="SearchLabel">
                                        <asp:DropDownList ID="ddlSearchItem" runat="server" CssClass="stdDropDown">
                                         <asp:ListItem Value="MB" Text="Mobile" />
                                        <asp:ListItem Value="MSG" Text="Message" />
                                        <asp:ListItem Value="RPT" Text="Report Name" />
                                        </asp:DropDownList>
                                        &nbsp;<asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                                            RepeatDirection="Horizontal" RepeatLayout="Flow" 
                                            TextAlign="Right">
                                            <asp:ListItem Selected="True" Value="S">starts with</asp:ListItem>
                                            <asp:ListItem Value="E">exact match</asp:ListItem>
                                            <asp:ListItem Value="A">any match</asp:ListItem>
                                        </asp:RadioButtonList>&nbsp;<asp:TextBox ID="TextBoxSearchValue" runat="server" CssClass="stdTextField1" Width="140px"/>
                                        
                                       
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:10px;">
                                        &nbsp;</td>
                                    <td class="SearchLabelBold" colspan="3">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="stdbuttonAction" 
                                            onclick="btnSearch_Click" Text="Search Now" />
                                        &nbsp;
                                        <asp:Button ID="btnDownload" runat="server" CssClass="stdbuttonAction" 
                                            onclick="btnDownload_Click" Text="Download to Excel Sheet" />
&nbsp;<asp:Button ID="btnReset" runat="server" CssClass="stdbuttonAction" 
                                            onclick="btnReset_Click" Text="Reset" />
                                    </td>
                                </tr>
                            </table>
                            <%--<asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="500" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/> Processing... Please wait... 
                             </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>  --%>                          
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
           </table>
            </td>
        </tr>
        </table>
                
                </td>
        </tr>
      
    </table>
    <asp:HiddenField ID="hdnDFrom" runat="server" Value="" />
    <asp:HiddenField ID="hdnDTo" runat="server" Value="" />
    <%--</ContentTemplate>  
    </asp:UpdatePanel>--%>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

