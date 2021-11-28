<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="PrepaidCardRegisteredUsers.aspx.cs" Inherits="m1_PrepaidCardRegisteredUsers" %>
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
                            &nbsp; 
                                    
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="500" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/> Processing... Please wait... 
                             </div>
                            </ProgressTemplate>
                            
                            </asp:UpdateProgress>
                            <asp:Label ID="lblTotal" runat="server" Text="Total Users: "></asp:Label> &nbsp;
                            <asp:Label ID="lblTotalValue" runat="server" ></asp:Label>
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
           <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
           <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top"/>
      </asp:TemplateField>  

        <asp:TemplateField HeaderText="User Login">    
            <ItemTemplate>
                <asp:HyperLink ID="hypZoom" runat="server" NavigateUrl='<% # Bind("fUserID")%>' Target="_blank">
                <asp:Label ID="lblUserID" runat="server" Text='<% # Bind("userid")%>'/>
                    </asp:HyperLink>
            </ItemTemplate><FooterTemplate></FooterTemplate>
            <ItemStyle Width="50px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Password">    
            <ItemTemplate>
                <asp:Label ID="lblPassword" runat="server" Text='<% # Bind("password")%>'/>
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
            <ItemStyle Width="25px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Name">    
            <ItemTemplate>
                <asp:Label ID="lblUserName" runat="server" Text='<% # Bind("userName")%>'/>
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
            <ItemStyle Width="100px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Mobile">    
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hypWLink"  Target="_blank" NavigateUrl='<% # Bind("wlink")%>' >
                <asp:Label ID="lblMobile" runat="server" Text='<% # Bind("userMobile")%>'/>
                    </asp:HyperLink></ItemTemplate><FooterTemplate></FooterTemplate>
            <ItemStyle Width="25px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="Success Transaction">        
            <ItemTemplate>
                <asp:HyperLink ID="hypZoomNew" runat="server" NavigateUrl='<% # Bind("fUserID")%>' Target="_blank">
                <asp:Label ID="lblCcount" runat="server" Text='<% # Bind("cCount")%>'></asp:Label>
                </asp:HyperLink>
                </ItemTemplate>
           <ItemStyle  Width="100px" HorizontalAlign="Right"  VerticalAlign="Top" />
        </asp:TemplateField> 
       
        <asp:TemplateField HeaderText="Registered Date">        
            <ItemTemplate>
                <asp:Label ID="lblTDate" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "registeredon", "{0:MMMM d, yyyy h:mm:ss tt}")%>'>
                </asp:Label></ItemTemplate><ItemStyle  Width="200px" HorizontalAlign="Right"  VerticalAlign="Top" />
        </asp:TemplateField> 

       <%--<asp:TemplateField HeaderText="send SMS" SortExpression="TDate">        
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonSendSMS1" runat="server" Text="Send SMS" CommandArgument='<%# "0," + Eval("userMobile") %>' OnCommand="OnCommand_SendSMS" ToolTip='<%# "Send SMS to : " + Eval("userMobile")%>' CssClass="txtDefaultSmallFont" PostBackUrl="EbAd_SendSMSP.aspx"/>    
            </ItemTemplate>
            <ItemStyle  Width="300px" HorizontalAlign="Right"  VerticalAlign="Top" />
        </asp:TemplateField>--%>
       
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
                            &nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td align="left">
                           <%-- <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
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

