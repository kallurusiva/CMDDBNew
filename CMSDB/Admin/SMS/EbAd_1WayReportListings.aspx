<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_1WayReportListings.aspx.cs" Inherits="Admin_SMS_EbAd_1WayReportListings" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SMSSystem ID="EBLeftMenu_SMSSystem1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
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
                            &nbsp; 1 Way EBooks Report</td>
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
                    <tr style="height:30px;">
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left">
                            &nbsp; 
                                    
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="500" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/> Processing... Please wait... 
                             </div>
                            </ProgressTemplate>
                            
                            </asp:UpdateProgress>
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                          <asp:GridView ID="gridEbooks" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="50" onpageindexchanging="gridEbooks_PageIndexChanging"
    AllowSorting="true" ondatabound="gridEbooks_DataBound" onrowdatabound="gridEbooks_RowDataBound" OnSorting="gridEbooks_Sorting">
    <Columns>        
    <asp:TemplateField HeaderText="Sno">
    <ItemTemplate><%#Eval("Row") + "."%></ItemTemplate>
    <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField> 
    <asp:TemplateField HeaderText="Trans ID" SortExpression="HistID" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblTransID" runat="server" Text='<% # Bind("HistID")%>' />
    <asp:HiddenField ID="hdnRefID" runat="server" Value='<% # Bind("refid")%>'/> 
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="30px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="SMS Type" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:HiddenField ID="hdnCreditType" runat="server" Value='<% # Bind("CreditType")%>'/>    
    <asp:ImageButton ID="ImageButtonSMSType" runat="server" ImageUrl="~/Images/icon_type_normal.png" ToolTip="Normal SMS"/>
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="30px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Report Name" SortExpression="ReportName" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblReportName" runat="server" Text='<%# Bind("ReportName") %>' ForeColor="Blue" />
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Message" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblMessage" runat="server" Text='<% # Bind("Message")%>' />
    <asp:HiddenField ID="hdnMessage" runat="server" Value='<% # Bind("Message")%>'/> 
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="400px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Sender" SortExpression="Sender" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblSender" runat="server" Text='<% # Bind("Sender")%>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="70px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Credits/Type">    
    <ItemTemplate>
    <asp:Label ID="lblCredits" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "Credits", "{0:0.0}" + " " + Eval("CreditType") )%>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="90px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Send On" SortExpression="TDateSend" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblSendOn" runat="server" Text='<%# Bind("TDateSend","{0:dd-MMM-yyyy hh:mm tt}")  %>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="160px"/>
    </asp:TemplateField> 
    <%--<asp:TemplateField HeaderText="Scheduled On" SortExpression="TDateSend" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblExecuteOn" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "TDateScheduleSend", "{0:dd/MM/yyyy h:mm:ss tt}")%>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="160px"/>
    </asp:TemplateField>--%> 
    <asp:TemplateField HeaderText="<span class='txtWhiteSmallFont'>Delivery<br/>Status</span>" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:LinkButton ID="LinkButtonR" runat="server" Text="Check" OnCommand="CheckStatus"   CommandArgument='<%# Eval("HistId")%>' ToolTip='<%# "Check Status : " + Eval("HistId")%>' PostBackUrl="~/Admin/SMS/EbAd_1WayReportSpecific.aspx"/>
    <asp:ImageButton ID="ImageButtonR" runat="server"  ImageUrl="~/Images/icon_check_status.png" CommandArgument='<%# Eval("HistId")%>' OnCommand="CheckStatus" ToolTip='<%# "Check Status : " + Eval("HistId")%>' PostBackUrl="~/Admin/SMS/EbAd_1WayReportSpecific.aspx"/> 
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="60px"  />
    </asp:TemplateField>        
    </Columns> 
    <PagerStyle CssClass="cssPager" />
    <PagerTemplate>
    <table border="0">
    <tr align="right">
    <td width="100px">      
    <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" OnCommand="BtnPaging" CommandArgument="F" runat="server"  ID="btnFirst" ImageUrl="~/Images/imgPg_First.gif" />
    <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" OnCommand="BtnPaging" CommandArgument="P" runat="server" ID="btnPrevious" ImageUrl="~/Images/imgPg_Prev.gif"/>
    </td>        
    <td width="100px">
    Page&nbsp;
    <asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;
    <asp:Label ID="PageCountLabel" runat="server" />
    </td>

    <td width="100px">
    <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" OnCommand="BtnPaging" CommandArgument="N" runat="server" ID="btnNext" ImageUrl="~/Images/imgPg_next.gif"/>
    <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" OnCommand="BtnPaging" CommandArgument="L" runat="server" ID="btnLast" ImageUrl="~/Images/imgPg_last.gif" />
    </td>
    <td width="20px">&nbsp;</td>
    <td width="100px">
    <%-- <asp:Button ID="btnDeleteMultiple" runat="server" Text="Delete Selected"/>--%>
    </td>

    </tr>
    </table>
    </PagerTemplate>

    <%--<PagerTemplate>
    <table border="0">
    <tr align="right">

    <td>      
    <asp:Button CssClass="stdPagerButton" Text="First" CommandName="Page" CommandArgument="First" runat="server"
    ID="btnFirst" />
    <asp:Button CssClass="stdPagerButton" Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
    ID="btnPrevious" />
        </td>
        
    <td>
    Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
        ID="PageCountLabel" runat="server" />
    </td>

    <td>
    <asp:Button CssClass="stdPagerButton" Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
    ID="btnNext" />
    <asp:Button  CssClass="stdPagerButton" Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
    ID="btnLast" />
    </td>
    </tr>
    </table>
    </PagerTemplate>--%>
                            </asp:GridView>  
                            
                        
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                           <%-- <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
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
        <tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
<br />
<asp:HiddenField ID="hdnHistID" runat="server" Value="" />
<asp:HiddenField ID="hdnReportType" runat="server" Value="2" />
<asp:HiddenField ID="hdnReportTypeSQL" runat="server" Value="2" />
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>



