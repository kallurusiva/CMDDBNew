<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_1WayReportCheckMobile.aspx.cs" Inherits="Admin_SMS_EbAd_1WayReportCheckMobile" %>
<%@ Register src="EBLeftMenu_SMSSystem.ascx" tagname="EBLeftMenu_SMSSystem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SMSSystem ID="EBLeftMenu_SMSSystem1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                        <asp:GridView ID="gridEbooks" runat="server" AutoGenerateColumns="False" CssClass="mGrid" HeaderStyle-CssClass="rowheader" 
                        AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="50" onpageindexchanging="gridEbooks_PageIndexChanging"
                        AllowSorting="true" ondatabound="gridEbooks_DataBound" OnSorting="gridEbooks_Sorting">
                        <Columns>        
                        <asp:TemplateField HeaderText="Sno">
                        <ItemTemplate><%#Eval("Row") + "."%></ItemTemplate>
                        <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top"/>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Mobile" SortExpression="Mobile" HeaderStyle-HorizontalAlign="Left">        
                        <ItemTemplate>
                        <asp:Label ID="lblMobile" runat="server" Text='<% # Bind("Mobile")%>'/>
                        </ItemTemplate>            
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" />
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Country" HeaderStyle-HorizontalAlign="Left">        
                        <ItemTemplate>
                        <asp:Label ID="lblTotalSMS" runat="server" Text='<% # Bind("CountryName")%>'/>
                        </ItemTemplate>            
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delivery Status" HeaderStyle-HorizontalAlign="Left">        
                        <ItemTemplate>
                        <asp:Label ID="lblDelivery" runat="server" Text="NOT_DELIVERED"/>
                        </ItemTemplate>            
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left">        
                        <ItemTemplate>
                        <asp:Label ID="lblSMSStatus" runat="server" Text='<%# Bind("Status")%>'/>
                        </ItemTemplate>            
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" />
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
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


