<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_PartnerDetaills.aspx.cs" Inherits="Admin_EBAd_PartnerDetaills" %>



<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_PaidSales.ascx" tagname="EBLeftMenu_PaidSales" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_PaidSales ID="EBLeftMenu_PaidSales1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
        
     <style type="text/css">

         .CellPaddingRight { padding-right: 10px; 
         }

          .CellPaddingLeft { padding-left: 10px;
         }

         .FontColHeader {font: bold 12px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #E432A3; padding-left: 5px; text-decoration: underline;}
         .FontColHead  {font: normal 11px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #081363; padding-left: 5px;}
         .FontColText  {font: bold 11px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #3C4688; padding-left: 5px;}

     </style>


<form id="form2" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    
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
                            &nbsp; Partner Details</td>
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
                        
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AllowPaging="true" 
    AutoGenerateColumns="False"  PageSize="500" HeaderStyle-CssClass="rowheader"
    onsorting="GridView1_Sorting" DataKeyNames="MID" onpageindexchanging="GridView1_PageIndexChanging"
    CssClass="mGrid" ondatabound="GridView1_DataBound" onrowdatabound="GridView1_RowDataBound">

    <Columns>        
      <asp:TemplateField HeaderText="SNo">
           <ItemTemplate><asp:Label ID="lblRow" runat="server" Text='<%#Eval("Row") + "."%>'/></ItemTemplate>
           <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>          

        <asp:TemplateField HeaderText="Login_ID" SortExpression="Login_ID" HeaderStyle-ForeColor="White">        
            <ItemTemplate>
                    <asp:HiddenField ID="hdnCtryCode" runat="server" Value='<% # Bind("country")%>' />
                    <asp:Image ID="ImageCtry" runat="server" ToolTip='<% # Bind("CtryName")%>' Visible="false" />  
                    <asp:HiddenField ID="hdnCtryName" runat="server" Value='<% # Bind("CtryName")%>'/>    
                    
                <asp:HyperLink runat="server" ID="hypwapp" NavigateUrl='<%# Eval("wMessage") %>' Target="_blank">
                <asp:Label ID="lblLoginId" runat="server" Text='<% # Bind("Login_ID")%>'></asp:Label></asp:HyperLink>
                <asp:HiddenField ID="hdnEmailStatus" runat="server" Value='<% # Bind("EStatus")%>' /> 
            </ItemTemplate>            
            <ItemStyle Width="100px" HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Login">
            <ItemTemplate>
            <asp:Label ID="lblSLogin" runat="server" Text='<% # Bind("sLogin")%>'/>
           </ItemTemplate>
        <ItemStyle Width="30px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Name/Email" SortExpression="Member_Name" HeaderStyle-ForeColor="White">
            <ItemTemplate>
                <asp:Label ID="lblMemberName" runat="server" Text='<% # Bind("Member_Name")%>'/><br />                
                <asp:Label ID="lblEmailBiz" runat="server" Text='<% # Bind("Email")%>' CssClass="txtBlueSmall" /><br />
                <%--<asp:Label ID="lblEmailStatus" runat="server" Text='<% # Bind("EmailStatus")%>' /><br />--%>
                <asp:HyperLink ID="HyperLink3" runat="server" Target="HyperLink" NavigateUrl='<%# String.Format("http://{0}", Eval("SubDomain").ToString()) %>' Text='<%# Bind("SubDomain") %>'>
                <asp:Label ID="lblSubDomain" runat="server" Text='<% # Bind("SubDomain")%>'></asp:Label></asp:HyperLink> 
                <asp:HiddenField ID="hdnMID" runat="server" Value='<% # Bind("MID")%>' />
            </ItemTemplate>
            <ItemStyle Width="80px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>        
        
         <asp:TemplateField HeaderText="Status" >
            <ItemTemplate>
            <asp:Label ID="lblPackage" runat="server" Text='<% # Bind("Acc_type")%>'/>
           </ItemTemplate>
        <ItemStyle Width="30px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Royalty Gain" >
            <ItemTemplate>
                <asp:Label ID="lblRoyalityGain" runat="server" Text='<% # Bind("RoyalityEarned")%>'></asp:Label>                
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Center" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Royalty Lost" >
            <ItemTemplate>
                <asp:Label ID="lblRoyalityLost" runat="server" Text='<% # Bind("RoyalityLost")%>'></asp:Label>                
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Center" VerticalAlign="Top" />
        </asp:TemplateField>

        <%--<asp:TemplateField HeaderText="Bonus Gain" >
            <ItemTemplate>
                <asp:Label ID="lblBonusGain" runat="server" Text='<% # Bind("BonusGain")%>'></asp:Label>                
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Center" VerticalAlign="Top" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Bonus Lost" >
            <ItemTemplate>
                <asp:Label ID="lblBonusLost" runat="server" Text='<% # Bind("BonusLost")%>'></asp:Label>                
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Center" VerticalAlign="Top" />
        </asp:TemplateField>--%>

        <%--<asp:TemplateField HeaderText="  SMS <br/>Balance" HeaderStyle-ForeColor="White">
            <ItemTemplate>
                <asp:Label ID="lblSMSbal" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "BalanceCredit", "{0:0}")%>'></asp:Label>                
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Center" VerticalAlign="Top" />
        </asp:TemplateField>--%>
        
        <asp:TemplateField HeaderText="Registered Date" >
            <ItemTemplate>
                <asp:Label ID="lblRegistered" runat="server" Text='<% # Bind("RegisterDate")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>   

        <asp:TemplateField HeaderText="Last Upgrade Date" >
            <ItemTemplate>
                <asp:Label ID="lbluDate" runat="server" Text='<% # Bind("uDate")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Expiry Date" >
            <ItemTemplate>
                <asp:Label ID="lblExpiryDate" runat="server" Text='<% # Bind("ExpiryDate")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Digital Products" >
            <ItemTemplate>
                <asp:Label ID="llbProducts" runat="server" Text='<% # Bind("Product")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        </Columns>

    <HeaderStyle CssClass="table-bordered bg-green-active" />
     <AlternatingRowStyle CssClass="alternateRowStyle" />
     <RowStyle CssClass="rowStyle" />
     <PagerTemplate>
            <table border="0" width="100%" class="table no-margin table-striped table-bordered">
                <tr>                           
                 <td style="width:100px">      
                    <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" runat="server"  ID="btnFirst" ImageUrl="~/Images/arrow_left2.png" OnCommand="BtnPaging" CommandArgument="F" />
                    <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" runat="server" ID="btnPrevious" ImageUrl="~/Images/arrow_up2.png" OnCommand="BtnPaging" CommandArgument="P"/>
                    <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" runat="server" ID="btnNext" ImageUrl="~/Images/arrow_down2.png" OnCommand="BtnPaging" CommandArgument="N"/>            
                    <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" runat="server" ID="btnLast" ImageUrl="~/Images/arrow_right2.png" OnCommand="BtnPaging" CommandArgument="L" /> 
                  </td>
                <td class="txtBlackSmall" align="right">Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList"  AutoPostBack="true" runat="server" CssClass="txtBlackSmall" OnSelectedIndexChanged="pageNumberDropDownList_OnSelectedIndexChanged" />&nbsp;of&nbsp;<asp:Label ID="PageCountLabel" runat="server" />
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
            &nbsp; </td></tr></table><%--      </ContentTemplate>  


    </asp:UpdatePanel>--%><asp:HiddenField ID="hdn_UId" runat="server" />
<asp:HiddenField ID="hdn_TranID" runat="server" />

</form>
</asp:Content>
