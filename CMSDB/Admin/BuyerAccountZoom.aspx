<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="BuyerAccountZoom.aspx.cs" Inherits="Admin_BuyerAccountZoom" %>
<%@ Register src="EBLeftMenu_WebUser.ascx" tagname="EBLeftMenu_WebUser" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_WebUser ID="EBLeftMenu_WebUser1" runat="server" />
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
                            &nbsp; Registerd Users Listing</td>
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
                            LoginID: <asp:Label ID="lblLoginID" runat="server" ></asp:Label> <br />
                            MobileNo: <asp:Label ID="lblMobleNo" runat="server" ></asp:Label><br />
                            Account Status: <asp:Label ID="lblAccountStatus" runat="server" ></asp:Label>
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                          <asp:GridView ID="gridEbooks" runat="server" AutoGenerateColumns="False" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="500" onpageindexchanging="gridEbooks_PageIndexChanging"
    AllowSorting="true" ondatabound="gridEbooks_DataBound" onrowdatabound="gridEbooks_RowDataBound" OnSorting="gridEbooks_Sorting">
<AlternatingRowStyle CssClass="rowalt"></AlternatingRowStyle>
   <Columns>
                                                                            <asp:TemplateField HeaderText="Sno">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1 + "."%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Type" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblType" runat="server" Text='<% # Bind("tType")%>'></asp:Label><br />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="25px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="TransctionID" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTranID" runat="server" Text='<% # Bind("billid")%>'></asp:Label><br />
                                                                                    <asp:Label ID="lblAmt" runat="server" Text='<% # Bind("charges")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="25px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Purchase Date" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPDate" runat="server" Text='<% # Bind("TDate")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="25px" />
                                                                            </asp:TemplateField>
                                                                             <asp:TemplateField HeaderText="Purchased Items" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPItems" runat="server" Text='<% # Bind("itemname")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                            </asp:TemplateField>    
                                                                            <asp:TemplateField HeaderText="Book Password" >
                                                                              <ItemTemplate>
                                                                                   <asp:Label ID="lblBookPassword" CssClass="fontBlue12" runat="server" Text='<%# Bind("bookpassword")  %>'></asp:Label>
                                                                              </ItemTemplate>
                                                                              <ItemStyle HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                                                                             </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Download" >
                                                                              <ItemTemplate>
                                                                                  <asp:HyperLink ID="hypBookLink" runat="server" NavigateUrl='<%# Bind("booklink") %>' Target="_blank">
                                                                                   <asp:Label ID="lblDownload" CssClass="fontBlue12" runat="server" Text='<%# Bind("booklink") %>'></asp:Label>
                                                                                      </asp:HyperLink>
                                                                              </ItemTemplate>
                                                                              <ItemStyle HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                                                                             </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Re-Send Email" HeaderStyle-HorizontalAlign="Center">    
                                                                            <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkSendSMS" runat="server" CssClass="links_FuncLinks" Text='<%# Eval("resms")  %>' CommandArgument='<%# Eval("uid")%>' OnCommand="OnCommand_ImageSendSMSNew" ToolTip='<%# "Send SMS to : " + Eval("MobileNo")%>' /><br />
                                                                            <asp:TextBox ID="txtBuyerEmail" runat="server" Text='<%# Eval("Email")  %>' Visible="false"/><br />
                                                                            <asp:LinkButton ID="LinkSendEmail" runat="server" CssClass="links_FuncLinks" Text='<%# Eval("remail")  %>' CommandArgument='<%# Eval("UID")%>' OnCommand="OnCommand_ImageSendEmailNew" ToolTip='<%# "Send Email to : " + Eval("Email")%>' /><br /><br />
                                                                            <asp:HyperLink ID="wplink" runat="server" CssClass="links_FuncLinks" NavigateUrl='<%# Eval("wlink")  %>' Target="_blank">[whatsapp]</asp:HyperLink><br /><br />

                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px"/>
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

