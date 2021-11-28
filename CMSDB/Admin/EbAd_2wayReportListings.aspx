<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_2wayReportListings.aspx.cs" Inherits="Admin_EbAd_2wayReportListings" %>
<%@ Register src="EBLeftMenu_BookCodes.ascx" tagname="EBLeftMenu_BookCodes" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.fontred
{
    color:Red;font-weight:bold;font-size:11px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_BookCodes ID="EBLeftMenu_BookCodes1" runat="server" />
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
                            &nbsp; <asp:Literal ID="lblSubHeader" runat="server" Text="2 Way EBooks Report" /></td>
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
    <asp:TemplateField HeaderText="Trans ID" SortExpression="TID" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblTransID" runat="server" Text='<% # Bind("TID")%>' />
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="40px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Mobile" SortExpression="Mobile" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>' />
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Message" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblMessage" runat="server" Text='<% # Bind("Message")%>'/>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="110px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Reply Message" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblRMessage" runat="server" Text='<% # Bind("RMessage")%>'/>
    <asp:HiddenField ID="hdnRMessage" runat="server" Value='<% # Bind("RMessage")%>'/>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="400px" />
    </asp:TemplateField>      
    <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblDenom" runat="server" Text='<% # Bind("Denom")%>' CssClass="fontred" />
    <asp:Label ID="lblCreditType" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "PriceNew", "{0:0.00}")%>' CssClass="fontred" />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="50px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Send On" SortExpression="TDate" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>    
    <asp:Label ID="lblSendOn" runat="server" Text='<%# Bind("TDate","{0:dd-MMM-yyyy hh:mm tt}")  %>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="130px" />
    </asp:TemplateField> 
    <%--<asp:TemplateField HeaderText="<span class='txtWhiteSmallFont'>Respond<br/>Trans</span>" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:HiddenField ID="hdnHistID" runat="server" Value='<%#Bind("HistId") %>'/>
    <asp:LinkButton ID="LinkButtonR" runat="server" Text="View" OnCommand="CheckStatus"  CommandArgument='<%# Eval("HistId")%>' ToolTip='<%# "View Respond Trans Msg : " + Eval("HistId")%>' PostBackUrl="~/m1/SMSReport_2Way_Specific.aspx"/>
    <asp:ImageButton ID="ImageButtonR" runat="server"  ImageUrl="~/Images/icon_view_report.png" CommandArgument='<%# Eval("HistId")%>' OnCommand="CheckStatus" ToolTip='<%# "View Respond Trans Msg : " + Eval("HistId")%>' PostBackUrl="~/m1/SMSReport_2Way_Specific.aspx"/>      
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="55px" />
    </asp:TemplateField>        --%>
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

