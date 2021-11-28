﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_StarRating_Accumulated.aspx.cs" Inherits="Admin_EBAd_StarRating_Accumulated" %>

<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_EBookSales.ascx" tagname="EBLeftMenu_EBookSales" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_EBookSales ID="EBLeftMenu_EBookSales1" runat="server" />
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

    <script language="javascript" type="text/javascript">

        function OpenWindow(ImageName) {
            window.open("EbAd_BankInSlipShow.aspx?qImage=" + ImageName, 'WinBankInImage', 'height=500,width=750,scrollbars=yes,resizable=yes');
        }

        function SelectAll(chkdbox_id) {

            var objChkbox = document.getElementById(chkdbox_id);
            //alert(objChkbox.checked);

            var frm = document.forms[0];

            for (var i = 0; i < frm.elements.length; i++) {
                if (frm.elements[i].type == "checkbox") {
                    frm.elements[i].checked = objChkbox.checked;
                }
            }
        }

        function SelectRow(cb_ID) {

            //Getting the ref. to GridView Control 
            var ObjgridViewCtlId = '<%=gridBankInBys.ClientID%>';

            //Getting ref. to GridView Row
            // ObjgridViewCtlId.rows


        }

</script>
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
                            &nbsp; Star Rating Admin Books - Accumulated</td>
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
                        
                            <asp:GridView ID="gridBankInBys" runat="server" AutoGenerateColumns="False"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="200" onpageindexchanging="gridBankInBys_PageIndexChanging"
                               AllowSorting="true"  
                                OnRowCreated="gridBankInBys_RowCreated"
                                onrowcancelingedit="gridBankInBys_RowCancelingEdit" 
                                onrowediting="gridBankInBys_RowEditing"  
                                onrowdeleting="gridBankInBys_RowDeleting" ondatabound="gridBankInBys_DataBound" 
                                onrowdatabound="gridBankInBys_RowDataBound" OnSorting="gridBankInBys_Sorting" OnRowCommand="gridBankInBys_RowCommand" ShowFooter="true">
                            <Columns>
                            
      <asp:TemplateField HeaderText="Sno">
           <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
           <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
      </asp:TemplateField>

        <asp:TemplateField HeaderText="Book Code">        
            <ItemTemplate>
                <asp:Label ID="lblBookCode" runat="server" Text='<% # Bind("BookCode")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Author Name">        
            <ItemTemplate>
                <asp:Label ID="lblAName" runat="server" Text='<% # Bind("AuthorName")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="Book Title">        
            <ItemTemplate>
                <asp:Label ID="lblBookTitle" runat="server" Text='<% # Bind("BookName")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Book Price">        
            <ItemTemplate>
                <asp:Label ID="lblBookPrice" runat="server" Text='<% # Bind("Price")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="No Sold">        
            <ItemTemplate>
                <asp:Label ID="lblCounter" runat="server" Text='<% # Bind("Counter")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Star Rating">        
            <ItemTemplate>
                <asp:Label ID="lblSRating" runat="server" Text='<% # Bind("StarRating")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="">
             <ItemTemplate>
                 <asp:HyperLink ID="hypBuyNow" runat="server" NavigateUrl='<%# Bind("buyURL")%>' Target="_blank">Buy Now</asp:HyperLink>
             </ItemTemplate>
             <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>  

                             
                             </Columns>
                             <PagerStyle CssClass="cssPager" />
                             
                             <PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
                                         <td width="100px">      
                                            <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" CommandArgument="First" runat="server"  ID="btnFirst" ImageUrl="~/Images/imgPg_First.gif" />
                                            <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" CommandArgument="Prev" runat="server" ID="btnPrevious" ImageUrl="~/Images/imgPg_Prev.gif"/>
                                                    </td>
                                                    
                                            <td width="100px">
                                                Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
                                                    ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td width="100px">
                                            <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" CommandArgument="Next" runat="server" ID="btnNext" ImageUrl="~/Images/imgPg_next.gif"/>
                                            <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" CommandArgument="Last" runat="server" ID="btnLast" ImageUrl="~/Images/imgPg_last.gif" />
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
            &nbsp; </td></tr></table>
    
    <asp:HiddenField ID="hdn_UId" runat="server" />
<asp:HiddenField ID="hdn_TranID" runat="server" />

</form>
</asp:Content>


