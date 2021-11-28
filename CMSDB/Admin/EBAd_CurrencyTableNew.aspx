<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_CurrencyTableNew.aspx.cs" Inherits="Admin_EBAd_CurrencyTableNew" %>
<%@ Register src="EBLeftMenu_PaidSales.ascx" tagname="EBLeftMenu_PaidSales" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_PaidSales ID="EBLeftMenu_PaidSales1" runat="server" />
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
                            &nbsp; Currency Exchange</td>
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
                           <%-- Your Current Balance : USD <asp:Label runat="server" ID="lblCBal"></asp:Label><br />
                            Cashout amount (Exchange Rate <asp:Label runat="server" ID="Label1"></asp:Label>) : (Exchange Rate <asp:Label runat="server" ID="Label2"></asp:Label>) :
                             <asp:Label runat="server" ID="Label3"></asp:Label> <asp:Label runat="server" ID="Label4"></asp:Label>--%>
                                    
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
    <AlternatingRowStyle CssClass="rowalt"></AlternatingRowStyle>

    <Columns>




       
    <asp:TemplateField HeaderText="Country Code" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-Wrap="true" SortExpression="">    
    <ItemTemplate>
    <asp:Label ID="lblCountrycode" runat="server" Text='<%# Bind("CountryCode") %>' CssClass="flag2_60" Font-Bold="True" ForeColor="Red"/>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" Wrap="True"></HeaderStyle>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" />
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Country Name" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-Wrap="true" SortExpression="">    
    <ItemTemplate>
    <asp:Label ID="lblCountryName" runat="server" Text='<%# Bind("CountryName") %>' CssClass="flag2_60" Font-Bold="True" ForeColor="Red"/>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" Wrap="True"></HeaderStyle>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" />
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Denomination" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-Wrap="true" SortExpression="">    
    <ItemTemplate>
    <asp:Label ID="lblDenomination" runat="server" Text='<%# Bind("Denomination") %>' CssClass="flag2_60" Font-Bold="True" ForeColor="Red"/>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" Wrap="True"></HeaderStyle>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" />
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Exchange Rate USD -> Local" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-Wrap="true" SortExpression="">    
    <ItemTemplate>
    <asp:Label ID="lblExchangeRate" runat="server" Text='<%# Bind("ExchangeRate") %>' CssClass="flag2_60" Font-Bold="True" ForeColor="Red"/>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" Wrap="True"></HeaderStyle>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" />
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Sell Rate" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-Wrap="true" SortExpression="">    
    <ItemTemplate>
    <asp:Label ID="lblExchangeRateWD" runat="server" Text='<%# Bind("ExchangeRateWD") %>' CssClass="flag2_60" Font-Bold="True" ForeColor="Red"/>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" Wrap="True"></HeaderStyle>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" />
    </asp:TemplateField>
    
    </Columns> 

<HeaderStyle CssClass="rowheader"></HeaderStyle>

    <PagerStyle CssClass="cssPager" />
    <PagerTemplate>
    <table border="0">
    <tr align="right">
    <td width="100px">      
    <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" OnCommand="BtnPaging" CommandArgument="F" runat="server"  ID="btnFirst" ImageUrl="~/Images/imgPg_First.gif" />
    <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" OnCommand="BtnPaging" CommandArgument="P" runat="server" ID="btnPrevious" ImageUrl="~/Images/imgPg_Prev.gif"/>
    </td>        
    <td width="100px">
    Page&nbsp; <asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp; <asp:Label ID="PageCountLabel" runat="server" />
    </td>

    <td width="100px">
    <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" OnCommand="BtnPaging" CommandArgument="N" runat="server" ID="btnNext" ImageUrl="~/Images/imgPg_next.gif"/>
    <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" OnCommand="BtnPaging" CommandArgument="L" runat="server" ID="btnLast" ImageUrl="~/Images/imgPg_last.gif" />
    </td>
    <td width="20px">&nbsp;</td><td width="100px">
    </td>

    </tr>
    </table>
    </PagerTemplate>

    
                            </asp:GridView>  
                            
                        
                        </td>
                        <td>
                            &nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td align="left">
                        </td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp; </td></tr></table><br />
<asp:HiddenField ID="hdnPRMCode_ID" runat="server" />
<asp:HiddenField ID="hdnPRM_ID" runat="server" />
<asp:HiddenField ID="hdn_tid" runat="server" />
<asp:HiddenField ID="hdn_IdentifierID" runat="server" />
<asp:HiddenField ID="hdn_EmailID" runat="server" />
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

