<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_UnsubscribeEmailsHistory.aspx.cs" Inherits="Admin_EmailMkt_EbAd_UnsubscribeEmailsHistory" %>
<%@ Register src="EBLeftMenu_SendEmail.ascx" tagname="EBLeftMenu_SendEmail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SendEmail ID="EBLeftMenu_SendEmail1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
<form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">      
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../../Images/inf_Error.gif" alt="MessageImage"/></td>
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
                            &nbsp; Email Ebook Unsubscribed List</td>
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
                        <td width="98%" align="left" class="RowHead"><b>Note :</b> 
                        <br />
                        
                        These Emails owners unsubscribe to your 
                            marketing material and no longer wishes to recover your email.
                        <br />
                        Please DO NOT email them in future.
                            </td>
                        <td width="1%">&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td>                       
                            <asp:GridView ID="gridEbooks" runat="server" AutoGenerateColumns="False" 
CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="50" onpageindexchanging="gridEbooks_PageIndexChanging"
AllowSorting="true" ondatabound="gridEbooks_DataBound" OnSorting="gridEbooks_Sorting" 
                                onrowdatabound="gridEbooks_RowDataBound" >
    <Columns>        
    <asp:TemplateField HeaderText="Sno">
    <ItemTemplate><%#Eval("Row") + "."%></ItemTemplate>
    <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField> 
    <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblEmail" runat="server" Text='<% # Bind("Email")%>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" Width="400px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Subscription Status" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblStatus" runat="server" Text='<% # Bind("Status")%>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="300px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Turn On Subscription" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:HiddenField ID="hdnDeleted" runat="server" Value='<%#Bind("Deleted") %>' />
    <asp:LinkButton ID="LinkButton1" runat="server" Text="[Turn On]"  OnCommand="Subscribe_Email" CommandArgument='<%#Eval("sno") + "," + Eval("Email") %>' />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Active_Show.jpg" OnCommand="Subscribe_Email" CommandArgument='<%#Eval("sno") + "," + Eval("Email") %>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Date" SortExpression="TDate" HeaderStyle-HorizontalAlign="Right">        
    <ItemTemplate>
    <asp:Label ID="lblSendOn" runat="server" Text='<%# Bind("TDate","{0:dd-MMM-yyyy hh:mm tt}")  %>' />
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="210px"/>
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
                        <td>&nbsp;</td>                        
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
 </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>


