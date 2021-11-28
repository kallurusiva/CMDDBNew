<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_FreeBookCodes.aspx.cs" Inherits="Admin_EbAd_FreeBookCodes" %>
<%@ Register src="EBLeftMenu_BookCodes.ascx" tagname="EBLeftMenu_BookCodes" tagprefix="uc1" %>
<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_FreeEbook ID="EBLeftMenu_FreeEbook1" runat="server" />
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
                            &nbsp;Products Listing</td>
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
    <asp:TemplateField HeaderText="Sno" HeaderStyle-HorizontalAlign="Left">
    <ItemTemplate><%#Eval("Row") + "."%></ItemTemplate>    
    <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top" CssClass="txtDefaultSmallFont"/>
    </asp:TemplateField> 
    <asp:TemplateField HeaderText="Product Code" SortExpression="Keyword" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblEbookCode" runat="server" Text='<% # Bind("Keyword")%>'/>
    <asp:HiddenField ID="hdn_EbookID" runat="server" Value='<% # Bind("EbookID")%>'/>
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="90px" CssClass="txtDefaultSmallFont"/>
    </asp:TemplateField> 
    <asp:TemplateField HeaderText="Product Name" SortExpression="EbookName" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblEbookName" runat="server" Text='<% # Bind("EbookName")%>'/>
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="120px" CssClass="txtDefaultSmallFont"/>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Category" SortExpression="Category" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblCategory" runat="server" Text='<% # Bind("Category")%>'/>
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" CssClass="txtDefaultSmallFont"/>
    </asp:TemplateField>  
    <asp:TemplateField HeaderText="Mobile" SortExpression="Mobile" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblMobile" runat="server" Text='<% # Bind("Mobile")%>'/>
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" CssClass="txtDefaultSmallFont"/>
    </asp:TemplateField> 
    <%--<asp:TemplateField HeaderText="Sub Keyword" HeaderStyle-HorizontalAlign="Left" SortExpression="Sub_Key">    
    <ItemTemplate>
    <asp:Label ID="lblParam" runat="server" Text='<% # Bind("SubKey")%>'/>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="120px"/>
    </asp:TemplateField>--%>
    <asp:TemplateField HeaderText="Name" SortExpression="FullName" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblFullName" runat="server" Text='<% # Bind("FullName")%>'  CssClass="txtDefaultSmallFont"/>
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" />
    </asp:TemplateField>    
    <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblEmail" runat="server" Text='<% # Bind("Email")%>'  CssClass="txtDefaultSmallFont"/>
    </ItemTemplate>            
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" />
    </asp:TemplateField>    
    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-Wrap="true" SortExpression="TDate">    
    <ItemTemplate>
    <asp:Label ID="lblMDate" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "TDate", "{0:dd/MM/yyyy h:mm:ss tt}")%>' CssClass="txtDefaultSmallFont"/>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Send SMS" HeaderStyle-HorizontalAlign="Center" >    
    <ItemTemplate>
    <asp:LinkButton ID="LinkButtonSendSMS" runat="server" Text="SMS" CommandArgument='<%# "0," + Eval("Mobile") %>' OnCommand="OnCommand_ImageSendSMS" ToolTip='<%# "Send SMS to : " + Eval("Mobile")%>' CssClass="txtDefaultSmallFont" PostBackUrl="EbAd_SendSMS.aspx?Status=F"/>    
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="70px"/>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="Re-Send Email" HeaderStyle-HorizontalAlign="Center">    
    <ItemTemplate>
    <asp:LinkButton ID="LinkSendEmail" runat="server" CssClass="txtDefaultSmallFont" Text="Re-Send Email" CommandArgument='<%# Eval("Email") + "," +  Eval("EbookCode")%>' OnCommand="OnCommand_ImageSendEmail" ToolTip='<%# "Send Email to : " + Eval("Email")%>' PostBackUrl="EbAd_SendEmail.aspx?Status=F"/>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px"/>
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
<asp:HiddenField ID="hdnPRMCode_ID" runat="server" />
<asp:HiddenField ID="hdnPRM_ID" runat="server" />
<asp:HiddenField ID="hdn_tid" runat="server" />
<asp:HiddenField ID="hdn_IdentifierID" runat="server" />
<asp:HiddenField ID="hdn_EmailID" runat="server" />
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>


